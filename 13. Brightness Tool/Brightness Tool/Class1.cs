using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTCBase.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV;

namespace Brightness_Tool
{
    public class Brightness
    {
        /// <summary>
        /// INPUT
        /// </summary>
        public Image<Gray,byte> InputImage
        {
            set { _inputImage = value; }
        }
        public Tuple<Point, double> ToolOrigin
        {
            set { _toolOrigin = value; }
        }
        public PointF[] InSetOrigin
        {
            set { _inSetOrigin = value; }
        }
        public RTCRectangle ROI
        {
            set { _ROI = value; }
        }
        public Tuple<double, double> BrightnessRange
        {
            set { _brightnessRange = value; }
        }
        public bool Invert
        {
            set { _invert = value; }
        }

        /// <summary>
        /// OUTPUT
        /// </summary>
        public double BrightnessValue
        {
            get { return _brightness; }
        }
        public bool Passed
        {
            get { return _passed; }
        }
        public string ErrMessage
        {
            get { return _errMessage; }
        }

        private Image<Gray, byte> _inputImage = null;
        private RTCRectangle _ROI = null;
        private Tuple<Point, double> _toolOrigin = null;
        private PointF[] _inSetOrigin = null;
        private Tuple<double, double> _brightnessRange = null;
        private bool _invert = false;

        private string _errMessage = null;
        private double _brightness = -1;
        private bool _passed = false;


        private bool SetToolOrigin()
        {
            if (_toolOrigin == null)
            {
                _errMessage = "SetToolOrigin: Lỗi chưa set ToolOrigin";
                return false;
            }
            try
            {
                if (_ROI == null)
                {
                    _inSetOrigin = null;
                }
                _inSetOrigin = new PointF[4];
                if (_ROI == null || _ROI.Width == 0 || _ROI.Height == 0)
                {
                    _inSetOrigin = null;
                }
                else
                {
                    //Hàm GetRectangleVertices() lấy tọa độ 4 đỉnh của rectangle
                    GetRectangleVertices(_ROI, out PointF[] inPointROI);

                    //Chuyển lần lượt tọa độ 4 đỉnh ROI trong hệ tọa độ ảnh về hệ tọa độ ToolOrigin
                    for (int i = 0; i < 4; i++)
                    {
                        _inSetOrigin[i] = ConvertCoordinatesToNewOrigin(_toolOrigin, inPointROI[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                _errMessage = "SetToolOrigin: " + ex.Message + "\n" + ex.StackTrace;
                return false;
            }

            return true;
        }

        public bool Run()
        {
            //Kiểm tra thuộc tính đầu vào
            if (_inputImage == null || _inputImage.Width == 0)
            {
                _errMessage = "Run: Lỗi InputImage = null";
                return false;
            }
            if (_brightnessRange == null)
            {
                _errMessage = "Run: Lỗi chưa set BrightnessRange";
                return false;
            }
            _passed = false;
            _brightness = -1;

            //SetToolOrigin();
            try
            {
                //Image<Gray, byte> inputImg = _inputImage.ToImage<Gray, byte>();
                var warped = new Mat();
                var blackImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var imgThes = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var Matrix = new Mat();
                var M = new Mat();
                PointF[] points = new PointF[4];
                if (_inSetOrigin != null) //Nếu có truyền vào ROI
                {
                    //Chuyển tọa độ 4 đỉnh rectangle trong hệ tọa độ ToolOrigin về hệ tọa độ ảnh
                    for (int i = 0; i < 4; i++)
                    {
                        points[i] = ConvertCoordinatesToOrigin(_toolOrigin, _inSetOrigin[i]);
                    }

                    //Đoạn này sẽ crop ảnh trong ROI 
                    var rotateRecROI = CvInvoke.MinAreaRect(points);
                    int width = (int)Math.Round(_ROI.Width);
                    int height = (int)Math.Round(_ROI.Height);
                    var intBox = Array.ConvertAll(points, Point.Round);

                    var srcPoints = Array.ConvertAll(intBox, p => new PointF(p.X, p.Y));
                    var dstPoints = new PointF[] {
                         new PointF(0, height-1),
                        new PointF(0, 0),
                        new PointF(width-1, 0),
                        new PointF(width-1, height-1)};
                    M = CvInvoke.GetPerspectiveTransform(srcPoints, dstPoints);
                    Matrix = CvInvoke.GetPerspectiveTransform(dstPoints, srcPoints);
                    CvInvoke.WarpPerspective(_inputImage, warped, M, new Size(width, height));
                    imgThes = warped.ToImage<Gray, byte>();
                }
                else //Ngược lại nếu không có ROI sẽ thực hiện trên toàn ảnh
                {
                    imgThes = _inputImage.Clone();
                }
                MCvScalar mean = CvInvoke.Mean(imgThes);
                _brightness = mean.V0;
                if (_invert == false && (_brightness >= _brightnessRange.Item1 && _brightness <= _brightnessRange.Item2))
                {
                    _passed = true;
                }
                else
                    _passed = false;
            }
            catch (Exception ex)
            {
                _errMessage = "Run: " + ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            return true;
        }

        /// <summary>
        /// ConvertCoordinatesToNewOrigin() chuyển tọa độ điểm "point" từ tọa độ gốc ảnh về hệ tọa độ "toolOrigin"
        /// </summary>
        private PointF ConvertCoordinatesToNewOrigin(Tuple<Point, double> toolOrigin, PointF point)
        {
            PointF p = new PointF();
            var A = new Matrix<double>(new double[,] {
                { Math.Cos(toolOrigin.Item2),-Math.Sin(toolOrigin.Item2),toolOrigin.Item1.X },
                { Math.Sin(toolOrigin.Item2),Math.Cos(toolOrigin.Item2),toolOrigin.Item1.Y },
                { 0,0,1} });
            var B = new Matrix<double>(new double[,]
            {
                {point.X },
                {point.Y},
                {1 }
            });
            var AT = new Matrix<double>(3, 1);
            CvInvoke.Invert(A, AT, DecompMethod.LU);
            var C = new Matrix<double>(3, 1);
            CvInvoke.Gemm(AT, B, 1.0, null, 0, C);
            p.X = (int)C.Data[0, 0];
            p.Y = (int)C.Data[1, 0];
            return p;
        }
        /// <summary>
        /// ConvertCoordinatesToOrigin() Chuyển tọa độ điểm "point" từ hệ tọa độ "toolOrigin" về hệ tọa độ ảnh
        /// </summary>
        /// <param name="toolOrigin"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private PointF ConvertCoordinatesToOrigin(Tuple<Point, double> Coordinates, PointF point)
        {
            PointF p = new Point();
            var Angle = Coordinates.Item2 * Math.PI / 180;
            var A = new Matrix<double>(new double[,] {
                { Math.Cos(Angle),-Math.Sin(Angle),Coordinates.Item1.X},
                { Math.Sin(Angle),Math.Cos(Angle),Coordinates.Item1.Y},
                { 0,0,1} });
            var B = new Matrix<double>(new double[,]
            {
                {point.X },
                {point.Y},
                {1 }
            });
            var C = new Matrix<double>(3, 1);
            CvInvoke.Gemm(A, B, 1.0, null, 0, C);
            p.X = (int)C.Data[0, 0];
            p.Y = (int)C.Data[1, 0];
            return p;
        }

        /// <summary>
        /// GetRectangleVertices() lấy tọa độ 4 đỉnh của rectangle
        /// </summary>
        /// <param name="recROI"></param>
        /// <param name="pointRec"></param>
        private void GetRectangleVertices(RTCRectangle recROI, out PointF[] pointRec)
        {
            var halfwidth = recROI.Width;
            var halfheight = recROI.Height;
            var angle = recROI.Phi;
            var centerPoint = recROI.Center;
            double diag = Math.Sqrt(halfwidth * halfwidth + halfheight * halfheight);
            PointF vertex1 = new PointF((float)Convert.ToSingle(centerPoint.X + diag / 2 * Math.Cos(angle + Math.Atan(halfheight / halfwidth))), (float)Convert.ToSingle(centerPoint.Y - diag / 2 * Math.Sin(angle + Math.Atan(halfheight / halfwidth))));
            PointF vertex2 = new PointF((float)Convert.ToSingle(centerPoint.X - diag / 2 * Math.Cos(angle - Math.Atan(halfheight / halfwidth))), (float)Convert.ToSingle(centerPoint.Y + diag / 2 * Math.Sin(angle - Math.Atan(halfheight / halfwidth))));
            PointF vertex3 = new PointF((float)Convert.ToSingle(centerPoint.X - diag / 2 * Math.Cos(angle + Math.Atan(halfheight / halfwidth))), (float)Convert.ToSingle(centerPoint.Y + diag / 2 * Math.Sin(angle + Math.Atan(halfheight / halfwidth))));
            PointF vertex4 = new PointF((float)Convert.ToSingle(centerPoint.X + diag / 2 * Math.Cos(angle - Math.Atan(halfheight / halfwidth))), (float)Convert.ToSingle(centerPoint.Y - diag / 2 * Math.Sin(angle - Math.Atan(halfheight / halfwidth))));
            pointRec = new PointF[] { vertex1, vertex2, vertex3, vertex4 };
        }
    }
}
