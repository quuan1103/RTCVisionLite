using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;
using RTCBase.Drawing;
using System.Drawing.Drawing2D;

namespace PixelCountTool
{
    public class PixelCount
    {
        /// <summary>
        /// INPUT
        /// </summary>
        /// 

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
        public string PixelColor
        {
            set { _pixelColor = value; }
        }
        public string ThresholdMode
        {
            set { _thresholdMode = value; }
        }
        public Tuple<int, int> ThresholdRange
        {
            set { _thresholdRange = value; }
        }
        public bool Invert
        {
            set { _invert = value; }
        }
        public Tuple<int, int> PixelCountRange
        {
            set { _pixelCountRange = value; }
        }
        public bool IsShowImageResult
        {
            set { _isShowImageResult = value; }
        }
        /// <summary>
        /// OUTPUT
        /// </summary>
        public int Pixels
        {
            get { return _pixels; }
        }
        public bool Passed
        {
            get { return _passed; }
        }
        public Bitmap OutputImageShow
        {
            get { return _outputImageShow; }
        }
        public string ErrMessage
        {
            get { return _errMessage; }
        }
        /// <summary>
        /// Các biến cục bộ sủ dụng trong Class
        /// </summary>
        private Image<Gray, byte> _inputImage = null;
        private RTCRectangle _ROI = null;
        private Tuple<Point, double> _toolOrigin = null;
        private PointF[] _inSetOrigin = null;
        private string _pixelColor = null;
        private string _thresholdMode = null;
        private Tuple<int, int> _thresholdRange = null;
        private bool _invert = false;
        private Tuple<int, int> _pixelCountRange = null;
        private bool _isShowImageResult = true;

        private int _pixels = 0;
        private bool _passed = false;
        private Bitmap _outputImageShow = null;
        private string _errMessage;

        /// <summary>
        ///  SetROI() có chức năng cài đặt ROI gắn với ToolOrigin .
        ///  Cần set thuộc tính: ToolOrigin,ROI (có thể set ROI == null) .
        ///  Mỗi lần thay đổi link ToolOrigin hoặc ROI thì cần chạy lại hàm .
        /// </summary>
        /// <returns></returns>
        /// 
        private bool SetROI()
        {
            if (_toolOrigin == null)
            {
                _errMessage = "Lỗi chưa set ToolOrigin";
                int i = 10;
                return false;
            }
            try
            {
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
                _errMessage = ex.Message + "\n" + ex.StackTrace;
                return false;
            }

            return true;
        }


        /// <summary>
        /// Cần chạy SetToolOrigin() trước khi chạy Run() .
        /// Sét các thuộc tính : InputImage,ToolOrigin,PixelColor,ThresholdMode,ThresholdRange,Invert,PixelCountRange .
        /// Output: Pixels,Passed,OutputImage,ErrMessage
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            //Kiểm tra thuộc tính đầu vào
            if (_inputImage == null || _inputImage.Width == 0)
            {
                _errMessage = "Lỗi InputImage = null";
                return false;
            }
            _outputImageShow = null;


            if (_pixelCountRange == null)
            {
                _errMessage = "Lỗi chưa set PixelCountRange";
                return false;
            }
            if (_thresholdMode == null)
            {
                _errMessage = "Lỗi chưa set ThresholdMode";
                return false;
            }
            if (_pixelColor == null)
            {
                _errMessage = "Lỗi chưa set PixelColor";
                return false;
            }

            //SetROI();
            try
            {
                //Image<Gray, byte> inputImg = _inputImage.ToImage<Gray, byte>();
                var warped = new Mat();
                var blackImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var imgThes = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var imgShow = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var Matrix = new Mat();
                var M = new Mat();
                double theshold = -1;

                PointF[] points = new PointF[4];
                //Chuyển tọa độ 4 đỉnh rectangle trong hệ tọa độ ToolOrigin về hệ tọa độ ảnh
                for (int i = 0; i < 4; i++)
                {
                    points[i] = ConvertCoordinatesToOrigin(_toolOrigin, _inSetOrigin[i]);
                }

                //Đoạn này sẽ crop ảnh trong ROI 
                var rotateRecROI = CvInvoke.MinAreaRect(points);
                PointF[] box = CvInvoke.BoxPoints(rotateRecROI);
                int width = (int)Math.Round(_ROI.Width);
                int height = (int)Math.Round(_ROI.Height);
                var intBox = Array.ConvertAll(points, Point.Round);
                var srcPoints = Array.ConvertAll(intBox, p => new PointF(p.X, p.Y));
                var dstPoints = new PointF[] {
                         new PointF(0, rotateRecROI.Size.Height-1),
                        new PointF(0, 0),
                        new PointF(rotateRecROI.Size.Width-1, 0),
                        new PointF(rotateRecROI.Size.Width-1, rotateRecROI.Size.Height-1)};
                M = CvInvoke.GetPerspectiveTransform(srcPoints, dstPoints);
                Matrix = CvInvoke.GetPerspectiveTransform(dstPoints, srcPoints);
                CvInvoke.WarpPerspective(_inputImage, warped, M, new Size(width, height));
                theshold = CvInvoke.Threshold(warped, warped, 0, 255, ThresholdType.Otsu);


                var rect = CvInvoke.BoundingRectangle(intBox);
                width = rect.Width + 10;
                height = rect.Height + 10;
                RTCRectangle ROItmp = new RTCRectangle();
                ROItmp.Center = new RTCPoint(rotateRecROI.Center.X, rotateRecROI.Center.Y, 0);
                ROItmp.Width = width;
                ROItmp.Height = height;
                ROItmp.Phi = 0;
                GetRectangleVertices(ROItmp, out PointF[] pRect);
                intBox = Array.ConvertAll(pRect, Point.Round);
                srcPoints = Array.ConvertAll(intBox, p => new PointF(p.X, p.Y));
                dstPoints = new PointF[] {
                         new PointF(0, height-1),
                        new PointF(0, 0),
                        new PointF(width-1, 0),
                        new PointF(width-1, height-1)};
                M = CvInvoke.GetPerspectiveTransform(srcPoints, dstPoints);
                Matrix = CvInvoke.GetPerspectiveTransform(dstPoints, srcPoints);
                CvInvoke.WarpPerspective(_inputImage, warped, M, new Size(width, height));
                imgThes = warped.ToImage<Gray, byte>();

                switch (_thresholdMode)
                {
                    case RTCConst.cPixelCount.ThresholdModeAuto:
                        {
                            CvInvoke.Threshold(imgThes, imgThes, theshold, 255, ThresholdType.Binary);
                            break;
                        }
                    case RTCConst.cPixelCount.ThresholdModeManual:
                        {
                            if (_thresholdRange == null)
                            {
                                _errMessage = "Lỗi chưa set ThresholdRange";
                                return false;
                            }
                            var minThres = _thresholdRange.Item1;
                            var maxThres = _thresholdRange.Item2;
                            Image<Gray, byte> _outputImageLow = new Image<Gray, byte>(imgThes.Width, imgThes.Height, new Gray(0));
                            Image<Gray, byte> _outputImageHigh = new Image<Gray, byte>(imgThes.Width, imgThes.Height, new Gray(0));
                            if (maxThres == 255)
                            {
                                CvInvoke.Threshold(imgThes, imgThes, minThres, 255, ThresholdType.Binary);
                            }
                            else if (minThres == 0)
                            {
                                CvInvoke.Threshold(imgThes, imgThes, maxThres, 255, ThresholdType.Binary);
                                imgThes = 255 - imgThes;
                            }
                            else
                            {
                                CvInvoke.Threshold(imgThes, _outputImageHigh, maxThres, 255, ThresholdType.Binary);
                                CvInvoke.Threshold(imgThes, _outputImageLow, minThres, 255, ThresholdType.BinaryInv);
                                CvInvoke.Add(_outputImageHigh, _outputImageLow, imgThes);
                                imgThes = 255 - imgThes;
                            }
                            break;
                        }
                }

                switch (_pixelColor)
                {
                    case RTCConst.cPixelCount.PixelColorBlack:
                        {
                            imgThes = 255 - imgThes;
                            break;
                        }
                    case RTCConst.cPixelCount.PixelColorWhite:
                        {
                            break;
                        }
                }

                CvInvoke.WarpPerspective(imgThes, blackImage, Matrix, _inputImage.Size);
                VectorOfPoint contour = new VectorOfPoint();
                Point[] p0 = { new Point((int)Math.Round(points[0].X), (int)Math.Round(points[0].Y)) };
                Point[] p1 = { new Point((int)Math.Round(points[1].X), (int)Math.Round(points[1].Y)) };
                Point[] p2 = { new Point((int)Math.Round(points[2].X), (int)Math.Round(points[2].Y)) };
                Point[] p3 = { new Point((int)Math.Round(points[3].X), (int)Math.Round(points[3].Y)) };
                contour.Push(p0);
                contour.Push(p1);
                contour.Push(p2);
                contour.Push(p3);
                VectorOfVectorOfPoint lcontour = new VectorOfVectorOfPoint();
                lcontour.Push(contour);
                var imgInput = blackImage.Convert<Gray, byte>();
                var imgOut = blackImage.Convert<Gray, byte>();
                CvInvoke.DrawContours(imgInput, lcontour, -1, new MCvScalar(0), -1);
                imgOut = imgOut - imgInput;
                blackImage = imgOut.Convert<Gray, byte>();
                //Đếm pixel
                _pixels = CvInvoke.CountNonZero(blackImage);

                if (_isShowImageResult)
                {
                    imgOut = _inputImage.Clone();
                    CvInvoke.DrawContours(imgOut, lcontour, -1, new MCvScalar(0), -1);
                    imgOut = imgOut + blackImage;
                    _outputImageShow = imgOut.ToBitmap();
                }
                _passed = false;
                if (!_invert && _pixels >= _pixelCountRange.Item1 && _pixels <= _pixelCountRange.Item2)
                {
                    _passed = true;
                }
                else if (_invert && (_pixels < _pixelCountRange.Item1 || _pixels > _pixelCountRange.Item2))
                {
                    _passed = true;
                }
            }
            catch (Exception ex)
            {
                _errMessage = ex.Message + "\n" + ex.StackTrace;
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

        private PointF ConvertCoordinatesToOrigin(Tuple<Point, double> toolOrigin, PointF point)
        {
            PointF p = new PointF();
            var Angle = toolOrigin.Item2 * Math.PI / 180;
            var A = new Matrix<double>(new double[,] {
                { Math.Cos(Angle),-Math.Sin(Angle),toolOrigin.Item1.X},
                { Math.Sin(Angle),Math.Cos(Angle),toolOrigin.Item1.Y},
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

        private void GetRectangleVertices(RTCRectangle recROI, out PointF[] pointRec)
        {
            var halfwidth = recROI.Width;
            var halfheight = recROI.Height;
            var angle = recROI.Phi;
            var centerPoint = recROI.Center;
            double diag = Math.Sqrt(halfwidth * halfwidth + halfheight * halfheight);
            PointF vertex1 = new PointF(Convert.ToSingle(centerPoint.X + diag / 2 * Math.Cos(angle + Math.Atan(halfheight / halfwidth))), Convert.ToSingle(centerPoint.Y - diag / 2 * Math.Sin(angle + Math.Atan(halfheight / halfwidth))));
            PointF vertex2 = new PointF(Convert.ToSingle(centerPoint.X - diag / 2 * Math.Cos(angle - Math.Atan(halfheight / halfwidth))), Convert.ToSingle(centerPoint.Y + diag / 2 * Math.Sin(angle - Math.Atan(halfheight / halfwidth))));
            PointF vertex3 = new PointF(Convert.ToSingle(centerPoint.X - diag / 2 * Math.Cos(angle + Math.Atan(halfheight / halfwidth))), Convert.ToSingle(centerPoint.Y + diag / 2 * Math.Sin(angle + Math.Atan(halfheight / halfwidth))));
            PointF vertex4 = new PointF(Convert.ToSingle(centerPoint.X + diag / 2 * Math.Cos(angle - Math.Atan(halfheight / halfwidth))), Convert.ToSingle(centerPoint.Y - diag / 2 * Math.Sin(angle - Math.Atan(halfheight / halfwidth))));
            pointRec = new PointF[] { vertex1, vertex2, vertex3, vertex4 };
        }
    }
}
