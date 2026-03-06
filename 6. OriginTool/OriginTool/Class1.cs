using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using RTCBase.Drawing;

namespace OriginTool
{
    public class Origin
    {
        /// <summary>
        /// INPUT
        /// </summary>
        public Image<Gray, byte> InputImage
        {
            set { _inputImage = value; }
        }
        public Tuple<Point, double> ToolOrigin
        {
            set { _toolOrigin = value; }
        }
        public RTCRectangle ROI1
        {
            set { _ROI1 = value; }
        }
        public RTCRectangle ROI2
        {
            set { _ROI2 = value; }
        }
        public string OriginType
        {
            set { _originType = value; }
        }
        public string EdgeTransitionROI1
        {
            set { _edgeTransitionROI1 = value;}
        }
        public string EdgeTransitionROI2
        {
            set { _edgeTransitionROI2 = value; }
        }
        public string EdgeTypeROI1
        {
            set { _edgeTypeROI1 = value;}
        }
        public string EdgeTypeROI2
        {
            set { _edgeTypeROI2 = value; }
        }
        public int EdgeDetectionThresholdROI1
        {
            set { _edgeDetectionThresholdROI1 = value;}
        }
        public int EdgeDetectionThresholdROI2
        {
            set { _edgeDetectionThresholdROI2 = value; }
        }
        public int OutlierDistanceThresholdROI1
        {
            set { _outlierDistanceThresholdROI1 = value; }
        }
        public int OutlierDistanceThresholdROI2
        {
            set { _outlierDistanceThresholdROI2 = value; }
        }
        public int SamplingPercentROI1
        {
            set { _samplingPercentROI1 = value;}
        }
        public int SamplingPercentROI2
        {
            set { _samplingPercentROI2 = value; }
        }
        
        public bool EnableAngleRangeCheck
        {
            set { _enableAngleRangeCheck = value; }
        }
        public bool EnableColumnFilter
        {
            set { _enableColumnFilter = value; }
        }
        public bool EnableRowFilter
        {
            set { _enableRowFilter = value; }
        }
        public Tuple<double, double> AngleRange
        {
            set { _angleRange = value; }
        }
        public Tuple<int, int> ColumnRange
        {
            set { _columnRange = value; }
        }
        public Tuple<int, int> RowRange
        {
            set { _rowRange = value; }
        }
        public bool IsShowImageResult
        {
            set { _isShowImageResult = value; }
        }
        /// <summary>
        /// OUTPUT
        /// </summary>

        public Tuple<Point, double> OutputOrigin
        {
            get { return _outputOrigin; }
        }
        public bool Passed
        {
            get { return _passed; }
        }
        public string ErrMessage
        {
            get { return _errMessage; }
        }
        public Bitmap OutputImage
        {
            get { return _outputImage; }
        }

        /// <summary>
        /// Các biến cục bộ sủ dụng trong Class
        /// </summary>
        private Image<Gray, byte> _inputImage = null;
        private RTCRectangle _ROI1 = null;
        private RTCRectangle _ROI2 = null;
        private Tuple<Point, double> _toolOrigin = null;
        private string _originType = null;
        private PointF[] _outSetOriginROI1 = null;
        private PointF[] _outSetOriginROI2 = null;
        private string _edgeTransitionROI1 = null;
        private string _edgeTransitionROI2 = null;
        private string _edgeTypeROI1 = null;
        private string _edgeTypeROI2 = null;
        private int _edgeDetectionThresholdROI1 = -1;
        private int _edgeDetectionThresholdROI2 = -1;
        private int _outlierDistanceThresholdROI1 = -1;
        private int _outlierDistanceThresholdROI2 = -1;
        private int _samplingPercentROI1 = -1;
        private int _samplingPercentROI2 = -1;
        private bool _enableAngleRangeCheck = false;
        private bool _enableColumnFilter = false;
        private bool _enableRowFilter = false;
        private Tuple<double, double> _angleRange = null;
        private Tuple<int, int> _columnRange = null;
        private Tuple<int, int> _rowRange = null;
        private bool _isShowImageResult = false;


        private Tuple<Point, double> _outputOrigin = null;
        private bool _passed = false;
        private Bitmap _outputImage = null;
        private string _errMessage = null;

        /// <summary>
        /// SetROI() có chức năng cài đặt ROI gắn với ToolOrigin .
        /// Cần set thuộc tính: ToolOrigin,ROI (có thể set ROI == null) .
        /// Mỗi lần thay đổi link ToolOrigin hoặc ROI thì cần chạy lại hàm .
        /// </summary>
        /// <returns></returns>
        private bool SetROI()
        {
            if (_toolOrigin == null)
            {
                _errMessage = "SetToolOrigin: Lỗi chưa set ToolOrigin";
                return false;
            }
            try
            {
                _outSetOriginROI1 = new PointF[4];
                _outSetOriginROI2 = new PointF[4];
                if (_ROI1 == null || _ROI1.Width == 0 || _ROI1.Height == 0)
                {
                    _outSetOriginROI1 = null;
                }
                else
                {
                    //Hàm GetRectangleVertices() lấy tọa độ 4 đỉnh của rectangle
                    GetRectangleVertices(_ROI1, out PointF[] inPointROI);

                    //Chuyển lần lượt tọa độ 4 đỉnh ROI trong hệ tọa độ ảnh về hệ tọa độ ToolOrigin
                    for (int i = 0; i < 4; i++)
                    {
                        _outSetOriginROI1[i] = ConvertCoordinatesToNewOrigin(_toolOrigin, inPointROI[i]);
                    }
                }
                if (_ROI2 == null || _ROI2.Width == 0 || _ROI2.Height == 0)
                {
                    _outSetOriginROI2 = null;
                }
                else
                {
                    //Hàm GetRectangleVertices() lấy tọa độ 4 đỉnh của rectangle
                    GetRectangleVertices(_ROI2, out PointF[] inPointROI);

                    //Chuyển lần lượt tọa độ 4 đỉnh ROI trong hệ tọa độ ảnh về hệ tọa độ ToolOrigin
                    for (int i = 0; i < 4; i++)
                    {
                        _outSetOriginROI2[i] = ConvertCoordinatesToNewOrigin(_toolOrigin, inPointROI[i]);
                    }
                }
            }
            catch(Exception ex)
            {
                _errMessage = "SetToolOrigin: " + ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Phải chạy SetROI trước khi chạy Run() .
        /// Phải set lại ToolOrigin nếu ToolOrigin thay đổi .
        /// Set các thuộc tính: InputImage,ToolOrigin,OriginType,EdgeTransition,EdgeType,EdgeDetectionThreshold,OutlierDistanceThreshold
        ///                             SamplingPercent,MaxPercentageOfOutliers,MinEdgePointNumber,EnableAngleRangeCheck,
        ///                             EnableColumnFilter,EnableRowFilter,AngleRange,ColumnRange,RowRange .
        /// Output: OutputOrigin,Passed,OutputImage,ErrMessage .
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            if (_inputImage == null || _inputImage.Width == 0)
            {
                _errMessage = "Run: Lỗi InputImage = null";
                return false;
            }
            if (_originType == null)
            {
                _errMessage = "Run: Lỗi chưa run OriginType";
                return false;
            }
            _outputOrigin = null;
            _passed = false;
            _outputImage = null;

            //Set ROI cho tool
            SetROI();
            try
            {
                if (_originType == RTCConst.cOriginTool.OriginType_TwoLine)
                {
                    if (_outSetOriginROI2 == null)
                    {
                        _errMessage = "Run: Lỗi chưa run SetToolOrigin() hoặc chưa set ROI2";
                        return false;
                    }
                    if (_edgeTransitionROI1 == null)
                    {
                        _errMessage = "Run: Lỗi chưa set EdgeTransitionROI1";
                        return false;
                    }
                    if (_edgeTransitionROI2 == null)
                    {
                        _errMessage = "Run: Lỗi chưa set EdgeTransitionROI2";
                        return false;
                    }
                    if (_edgeTypeROI1 == null)
                    {
                        _errMessage = "Run: Lỗi chưa set EdgeTypeROI1";
                        return false;
                    }
                    if (_edgeTypeROI2 == null)
                    {
                        _errMessage = "Run: Lỗi chưa set EdgeTypeROI2";
                        return false;
                    }
                    if (_edgeDetectionThresholdROI1 == -1)
                    {
                        _errMessage = "Run: Lỗi chưa set EdgeDetectionThresholdROI1";
                        return false;
                    }
                    if (_edgeDetectionThresholdROI2 == -1)
                    {
                        _errMessage = "Run: Lỗi chưa set EdgeDetectionThresholdROI2";
                        return false;
                    }
                    if (_outlierDistanceThresholdROI1 == -1)
                    {
                        _errMessage = "Run: Lỗi chưa set OutlierDistanceThresholdROI1";
                        return false;
                    }
                    if (_outlierDistanceThresholdROI2 == -1)
                    {
                        _errMessage = "Run: Lỗi chưa set OutlierDistanceThresholdROI2";
                        return false;
                    }
                    if (_samplingPercentROI1 == -1)
                    {
                        _errMessage = "Run: Lỗi chưa set SamplingPercentROI1";
                        return false;
                    }
                    if (_samplingPercentROI2 == -1)
                    {
                        _errMessage = "Run: Lỗi chưa set SamplingPercentROI2";
                        return false;
                    }

                    Tuple<Point, Point> lineSegment1 = null;
                    Tuple<Point, Point> lineSegment2 = null;
                    //var inputImg = _inputImage.ToImage<Gray,byte>();
                    try
                    {
                        FindLine(_inputImage, _outSetOriginROI1,_ROI1, _toolOrigin, _edgeTransitionROI1, _edgeTypeROI1, _edgeDetectionThresholdROI1,
                    _outlierDistanceThresholdROI1, _samplingPercentROI1, out lineSegment1);

                        FindLine(_inputImage, _outSetOriginROI2,_ROI2 ,_toolOrigin, _edgeTransitionROI2, _edgeTypeROI2, _edgeDetectionThresholdROI2,
                            _outlierDistanceThresholdROI2, _samplingPercentROI2, out lineSegment2);
                    }
                    catch (Exception)
                    {
                        _errMessage = "Run: Lỗi chạy hàm FindLine()";
                        return false;
                    }
                    
                    double a1 = 0, b1 = 0, a2 = 0, b2 = 0;
                    //Tìm pt dt dạng ax + by = 1
                    b1 = (double)(lineSegment1.Item2.X - lineSegment1.Item1.X) / (lineSegment1.Item2.X * lineSegment1.Item1.Y - lineSegment1.Item1.X * lineSegment1.Item2.Y);
                    if (lineSegment1.Item1.X != 0)
                    {
                        a1 = (double)(1 - b1 * lineSegment1.Item1.Y) / lineSegment1.Item1.X;
                    }
                    else
                    {
                        a1 = (double)(1 - b1 * lineSegment1.Item2.Y) / lineSegment1.Item2.X;
                    }

                    b2 = (double)(lineSegment2.Item2.X - lineSegment2.Item1.X) / (lineSegment2.Item2.X * lineSegment2.Item1.Y - lineSegment2.Item1.X * lineSegment2.Item2.Y);
                    if (lineSegment1.Item1.X != 0)
                    {
                        a2 = (double)(1 - b2 * lineSegment2.Item1.Y) / lineSegment2.Item1.X;
                    }
                    else
                    {
                        a2 = (double)(1 - b2 * lineSegment2.Item2.Y) / lineSegment2.Item2.X;
                    }

                    Point originPoint = new Point(0, 0);
                    if (a1 * b2 == a2 * b1 || (a1 == 0 && b1 == 0) || (a2 == 0 && b2 == 0))
                    {
                        _outputOrigin = new Tuple<Point, double>(new Point(0, 0), 0);
                    }
                    else
                    {
                        originPoint.Y = (int)Math.Round((double)(a2 - a1) / (a2 * b1 - a1 * b2));
                        if (a1 != 0)
                        {
                            originPoint.X = (int)Math.Round((double)(1 - originPoint.Y * b1) / a1);
                        }
                        else
                        {
                            originPoint.X = (int)Math.Round((double)(1 - originPoint.Y * b2) / a2);
                        }
                        if (lineSegment1 != null && lineSegment2 != null)
                        {
                            double disSeg11, disSeg12, disSeg21, disSeg22;
                            disSeg11 = (double)Math.Sqrt(Math.Pow(originPoint.X - lineSegment1.Item1.X, 2) + Math.Pow(originPoint.Y - lineSegment1.Item1.Y, 2));
                            disSeg12 = (double)Math.Sqrt(Math.Pow(originPoint.X - lineSegment1.Item2.X, 2) + Math.Pow(originPoint.Y - lineSegment1.Item2.Y, 2));
                            disSeg21 = (double)Math.Sqrt(Math.Pow(originPoint.X - lineSegment2.Item1.X, 2) + Math.Pow(originPoint.Y - lineSegment2.Item1.Y, 2));
                            disSeg22 = (double)Math.Sqrt(Math.Pow(originPoint.X - lineSegment2.Item2.X, 2) + Math.Pow(originPoint.Y - lineSegment2.Item2.Y, 2));
                            Point p1, p2;
                            if (disSeg11 > disSeg12)
                            {
                                p1 = lineSegment1.Item1;
                            }
                            else
                            {
                                p1 = lineSegment1.Item2;
                            }
                            if (disSeg21 > disSeg22)
                            {
                                p2 = lineSegment2.Item1;
                            }
                            else
                            {
                                p2 = lineSegment2.Item2;
                            }

                            // Tìm góc của đường thẳng tìm được
                            PointF vecLine = new PointF(p1.X - originPoint.X, p1.Y - originPoint.Y);
                            double CosAngle = (double)vecLine.X / Math.Sqrt(Math.Pow(vecLine.X, 2) + Math.Pow(vecLine.Y, 2));
                            var angleOrigin = Math.Acos(CosAngle);
                            if (originPoint.Y > p1.Y)
                            {
                                angleOrigin = -angleOrigin;
                            }

                            _outputOrigin = new Tuple<Point, double>(originPoint, angleOrigin);
                            _passed = true;
                            if (_enableRowFilter)
                            {
                                if (_rowRange == null)
                                {
                                    _errMessage = "Run: Lỗi chưa set RowRange";
                                    _passed = false;
                                    return false;
                                }
                                if (originPoint.X < _rowRange.Item1 || originPoint.X > _rowRange.Item2)
                                {
                                    _passed = false;
                                }
                            }
                            if (_enableColumnFilter)
                            {
                                if (_columnRange == null)
                                {
                                    _errMessage = "Run: Lỗi chưa set ColumnRange";
                                    _passed = false;
                                    return false;
                                }
                                if (originPoint.Y < _columnRange.Item1 || originPoint.Y > _columnRange.Item2)
                                {
                                    _passed = false;
                                }
                            }
                            if (_enableAngleRangeCheck)
                            {
                                if (_angleRange == null)
                                {
                                    _errMessage = "Run: Lỗi chưa set AngleRange";
                                    _passed = false;
                                    return false;
                                }
                                if (angleOrigin < _angleRange.Item1 || angleOrigin > _angleRange.Item2)
                                {
                                    _passed = false;
                                }
                            }
                            if(_isShowImageResult)
                            {
                                var outputImg = _inputImage.Convert<Bgr, byte>();
                                if (_passed)
                                {
                                    CvInvoke.ArrowedLine(outputImg, originPoint, p1, new MCvScalar(0, 255, 0), 2);
                                    CvInvoke.ArrowedLine(outputImg, originPoint, p2, new MCvScalar(0, 215, 255), 2);
                                }
                                else
                                {
                                    CvInvoke.ArrowedLine(outputImg, originPoint, p1, new MCvScalar(0, 0, 255), 2);
                                    CvInvoke.ArrowedLine(outputImg, originPoint, p2, new MCvScalar(0, 0, 255), 2);
                                }
                                _outputImage = outputImg.ToBitmap();
                            }
                            
                        }
                    }

                }
                else if (_originType == RTCConst.cOriginTool.OriginType_OneLine)
                {
                    if (_edgeTransitionROI1 == null)
                    {
                        _errMessage = "Run: Lỗi chưa set EdgeTransitionROI1";
                        return false;
                    }
                    if (_edgeTypeROI1 == null)
                    {
                        _errMessage = "Run: Lỗi chưa set EdgeTypeROI1";
                        return false;
                    }
                    if (_edgeDetectionThresholdROI1 == -1)
                    {
                        _errMessage = "Run: Lỗi chưa set EdgeDetectionThresholdROI1";
                        return false;
                    }
                    if (_outlierDistanceThresholdROI1 == -1)
                    {
                        _errMessage = "Run: Lỗi chưa set OutlierDistanceThresholdROI1";
                        return false;
                    }
                    if (_samplingPercentROI1 == -1)
                    {
                        _errMessage = "Run: Lỗi chưa set SamplingPercentROI1";
                        return false;
                    }

                    Tuple<Point, Point> lineSegment1 = null;
                    //var inputImg = _inputImage.ToImage<Gray, byte>();
                    try
                    {
                        FindLine(_inputImage, _outSetOriginROI1,_ROI1, _toolOrigin, _edgeTransitionROI1, _edgeTypeROI1, _edgeDetectionThresholdROI1,
                    _outlierDistanceThresholdROI1, _samplingPercentROI1, out lineSegment1);
                    }
                    catch (Exception)
                    {
                        _errMessage = "Run: Lỗi chạy hàm FindLine()";
                        return false;
                    }
                    
                    Point originPoint = new Point(0, 0);
                    if (lineSegment1 != new Tuple<Point, Point>(new Point(0, 0), new Point(0, 0)))
                    {
                        //lineSegment1 = new Tuple<Point, Point>(new Point(1,1),new Point(1,1));
                        originPoint.X = (int)Math.Round((double)(lineSegment1.Item1.X + lineSegment1.Item2.X) / 2);
                        originPoint.Y = (int)Math.Round((double)(lineSegment1.Item1.Y + lineSegment1.Item2.Y) / 2);

                        Point p1 = lineSegment1.Item2;
                        // Tìm góc của đường thẳng tìm được
                        PointF vecLine = new PointF(p1.X - originPoint.X, p1.Y - originPoint.Y);
                        double CosAngle = (double)vecLine.X / Math.Sqrt(Math.Pow(vecLine.X, 2) + Math.Pow(vecLine.Y, 2));
                        var angleOrigin = Math.Acos(CosAngle);
                        if (originPoint.Y < p1.Y)
                        {
                            angleOrigin = -angleOrigin;
                        }
                        _outputOrigin = new Tuple<Point, double>(originPoint, angleOrigin);
                        _passed = true;
                        if (_enableRowFilter)
                        {
                            if (_rowRange == null)
                            {
                                _errMessage = "Run: Lỗi chưa set RowRange";
                                _passed = false;
                                return false;
                            }
                            if (originPoint.X < _rowRange.Item1 || originPoint.X > _rowRange.Item2)
                            {
                                _passed = false;
                            }
                        }
                        if (_enableColumnFilter)
                        {
                            if (_columnRange == null)
                            {
                                _errMessage = "Run: Lỗi chưa set ColumnRange";
                                _passed = false;
                                return false;
                            }
                            if (originPoint.Y < _columnRange.Item1 || originPoint.Y > _columnRange.Item2)
                            {
                                _passed = false;
                            }
                        }
                        if (_enableAngleRangeCheck)
                        {
                            if (_angleRange == null)
                            {
                                _errMessage = "Run: Lỗi chưa set AngleRange";
                                _passed = false;
                                return false;
                            }
                            if (angleOrigin < _angleRange.Item1 || angleOrigin > _angleRange.Item2)
                            {
                                _passed = false;
                            }
                        }
                        
                        if (_isShowImageResult)
                        {
                            var outputImg = _inputImage.Convert<Bgr, byte>();
                            if (_passed)
                            {
                                CvInvoke.ArrowedLine(outputImg, lineSegment1.Item1, p1, new MCvScalar(0, 255, 0), 2);
                                CvInvoke.Circle(outputImg, originPoint,3, new MCvScalar(0, 0, 255), -1);
                            }
                            else
                            {
                                CvInvoke.ArrowedLine(outputImg, lineSegment1.Item1, p1, new MCvScalar(0, 0, 255), 2);
                                CvInvoke.Circle(outputImg, originPoint, 3, new MCvScalar(0, 0, 255), -1);
                            }
                            _outputImage = outputImg.ToBitmap();
                        }
                    }
                }


            }
            catch(Exception ex)
            {
                _errMessage = "Run: " + ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Tim đường thẳng
        /// </summary>
        private void FindLine(Image<Gray, byte> inputImage, PointF[] outSetOrigin,RTCRectangle ROI, Tuple<Point, double> toolOrigin,
            string edgeTransition, string edgeType, int edgeDetectionThreshold, int outlierDistanceThreshold, int samplingPercent,
             out Tuple<Point, Point> lineSegment)
        {
            List<Point> outputPointList = new List<Point>();
            List<Point> edgePoints = new List<Point>();
            lineSegment = null;

            if (outSetOrigin != null)
            {
                //var imgFind = inputImage.Clone();
                PointF[] pointRs = new PointF[4];
                for (int i = 0; i < 4; i++)
                {
                    pointRs[i] = ConvertCoordinatesToOrigin(toolOrigin, outSetOrigin[i]);
                }
                int width = (int)Math.Round(ROI.Width);
                int height = (int)Math.Round(ROI.Height);
                var srcPoints = pointRs;
                var dstPoints = new PointF[] {
                         new PointF((float)ROI.Width - 1, 0),
                        new PointF(0, 0),
                        new PointF(0, (float)ROI.Height - 1),
                        new PointF((float)ROI.Width - 1,  (float)ROI.Height - 1)};
                var M = CvInvoke.GetPerspectiveTransform(srcPoints, dstPoints);
                var Matrix = CvInvoke.GetPerspectiveTransform(dstPoints, srcPoints);
                var warped = new Mat();
                CvInvoke.WarpPerspective(inputImage, warped, M, new Size(width, height));
                Matrix<byte> matrix = new Matrix<byte>(warped.Size);
                warped.CopyTo(matrix);
                List<Point> points = new List<Point>();

                var step = (int)Math.Round(100.0 / samplingPercent);
                List<int> x = new List<int>();
                List<int> y = new List<int>();
                if (edgeTransition == RTCConst.cOriginTool.EdgeTransition_LighttoDark && edgeType == RTCConst.cOriginTool.EdgeType_FirstEdge)
                {
                    for (int i = 0; i < warped.Height;)
                    {
                        for (int j = 5; j < warped.Width; j = j + 2)
                        {
                            if (matrix[i, j - 5] - matrix[i, j] >= edgeDetectionThreshold)
                            {
                                if (j > 5)
                                {
                                    if (matrix[i, j - 5 - 1] - matrix[i, j - 1] >= edgeDetectionThreshold)
                                    {
                                        outputPointList.Add(new Point(j - 1, i));
                                    }
                                    else
                                    {
                                        outputPointList.Add(new Point(j, i));
                                    }
                                }
                                else
                                {
                                    outputPointList.Add(new Point(j, i));
                                }
                                break;
                            }

                        }
                        i = i + step;
                    }
                }
                if (edgeTransition == RTCConst.cOriginTool.EdgeTransition_DarktoLight && edgeType == RTCConst.cOriginTool.EdgeType_FirstEdge)
                {
                    for (int i = 0; i < warped.Height;)
                    {
                        for (int j = 5; j < warped.Width; j = j + 2)
                        {
                            if (matrix[i, j] - matrix[i, j - 5] >= edgeDetectionThreshold)
                            {
                                if (j > 5)
                                {
                                    if (matrix[i, j - 1] - matrix[i, j - 5 - 1] >= edgeDetectionThreshold)
                                    {
                                        outputPointList.Add(new Point(j - 1, i));
                                    }
                                    else
                                    {
                                        outputPointList.Add(new Point(j, i));
                                    }
                                }
                                else
                                {
                                    outputPointList.Add(new Point(j, i));
                                }
                                break;
                            }
                        }
                        i = i + step;
                    }
                }
                if (edgeTransition == RTCConst.cOriginTool.EdgeTransition_LighttoDark && edgeType == RTCConst.cOriginTool.EdgeType_LastEdge)
                {
                    for (int i = 0; i < warped.Height;)
                    {
                        for (int j = warped.Width - 1; j > 5 - 1; j = j - 2)
                        {
                            if (matrix[i, j - 5] - matrix[i, j] >= edgeDetectionThreshold)
                            {
                                if (j < warped.Width)
                                {
                                    if (matrix[i, j - 5 + 1] - matrix[i, j + 1] >= edgeDetectionThreshold)
                                    {
                                        outputPointList.Add(new Point(j - 5 + 1, i));
                                    }
                                    else
                                    {
                                        outputPointList.Add(new Point(j - 5, i));
                                    }
                                }
                                else
                                {
                                    outputPointList.Add(new Point(j - 5, i));
                                }
                                break;
                            }
                        }
                        i = i + step;
                    }
                }
                if (edgeTransition == RTCConst.cOriginTool.EdgeTransition_DarktoLight && edgeType == RTCConst.cOriginTool.EdgeType_LastEdge)
                {
                    for (int i = 0; i < warped.Height;)
                    {
                        for (int j = warped.Width - 1; j > 5 - 1; j--)
                        {
                            if (matrix[i, j] - matrix[i, j - 5] >= edgeDetectionThreshold)
                            {
                                if (j < warped.Width)
                                {
                                    if (matrix[i, j + 1] - matrix[i, j - 5 + 1] >= edgeDetectionThreshold)
                                    {
                                        outputPointList.Add(new Point(j - 5 + 1, i));
                                    }
                                    else
                                    {
                                        outputPointList.Add(new Point(j - 5, i));
                                    }
                                }
                                else
                                {
                                    outputPointList.Add(new Point(j - 5, i));
                                }

                                break;
                            }
                        }
                        i = i + step;
                    }
                }
                PointF[] pointFs = points.Select(p => new PointF(p.X, p.Y)).ToArray();
                //pointFs = CvInvoke.PerspectiveTransform(pointFs, Matrix);
                //points = pointFs.Select(p => new Point((int)p.X, (int)p.Y)).ToList();


                Point pointSegment1 = new Point();
                Point pointSegment2 = new Point();
                PointF pSeg1 = new PointF();
                PointF pSeg2 = new PointF();
                double a = new double();
                double b = new double();
                double c = new double();

                var lineBest = FitLine(outputPointList, out edgePoints, out List<Point> outlierPoints);
                pSeg1 = lineBest.P1;
                pSeg2 = lineBest.P2;

                PointF[] outPL = new PointF[] { pSeg1, pSeg2 };
                outPL = CvInvoke.PerspectiveTransform(outPL, Matrix);
                pSeg1 = outPL[0];
                pointSegment1 = new Point((int)Math.Round(pSeg1.X), (int)Math.Round(pSeg1.Y));
                pSeg2 = outPL[1];
                pointSegment2 = new Point((int)Math.Round(pSeg2.X), (int)Math.Round(pSeg2.Y));
                lineSegment = new Tuple<Point, Point>(pointSegment1, pointSegment2);
            }
        }

        /// <summary>
        /// ConvertCoordinatesToNewOrigin() chuyển tọa độ điểm "point" từ tọa độ gốc ảnh về hệ tọa độ "toolOrigin"
        /// </summary>
        /// <returns></returns>
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
        private PointF ConvertCoordinatesToOrigin(Tuple<Point, double> Coordinates, PointF point)
        {
            PointF p = new Point();
            var Angle = Coordinates.Item2;
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
        private void GetRectangleVertices(RTCRectangle recROI, out PointF[] pointRec)
        {
            var halfwidth = recROI.Width;
            var halfheight = recROI.Height;
            var angle = recROI.Phi;
            var centerPoint = recROI.Center;
            double diag = Math.Sqrt(halfwidth * halfwidth  + halfheight * halfheight );
            PointF vertex1 = new PointF(Convert.ToSingle(centerPoint.X + diag / 2 * Math.Cos(angle + Math.Atan(halfheight / halfwidth))), Convert.ToSingle(centerPoint.Y - diag / 2 * Math.Sin(angle + Math.Atan(halfheight / halfwidth))));
            PointF vertex2 = new PointF(Convert.ToSingle(centerPoint.X - diag / 2 * Math.Cos(angle - Math.Atan(halfheight / halfwidth))), Convert.ToSingle(centerPoint.Y + diag / 2 * Math.Sin(angle - Math.Atan(halfheight / halfwidth))));
            PointF vertex3 = new PointF(Convert.ToSingle(centerPoint.X - diag / 2 * Math.Cos(angle + Math.Atan(halfheight / halfwidth))), Convert.ToSingle(centerPoint.Y + diag / 2 * Math.Sin(angle + Math.Atan(halfheight / halfwidth))));
            PointF vertex4 = new PointF(Convert.ToSingle(centerPoint.X + diag / 2 * Math.Cos(angle - Math.Atan(halfheight / halfwidth))), Convert.ToSingle(centerPoint.Y - diag / 2 * Math.Sin(angle - Math.Atan(halfheight / halfwidth))));
            pointRec = new PointF[] { vertex1, vertex2, vertex3, vertex4 };
        }
        private LineSegment2D FitLine(List<Point> listPoint, out List<Point> edgePoints, out List<Point> outlierPoints)
        {
            edgePoints = new List<Point>();
            outlierPoints = new List<Point>();
            PointF[] points = listPoint.ConvertAll(p => new PointF(p.X, p.Y)).ToArray();
            PointF direction = new PointF();
            PointF pointOnLine = new PointF();
            CvInvoke.FitLine(points, out direction, out pointOnLine, Emgu.CV.CvEnum.DistType.L12, 0, 0.01, 0.01);
            double a = direction.Y / direction.X;
            double b = pointOnLine.Y - a * pointOnLine.X;
            LineSegment2D line = new LineSegment2D(new Point((int)Math.Round((listPoint[0].Y - b) / a), (int)listPoint[0].Y), new Point((int)Math.Round((listPoint[listPoint.Count - 1].Y - b) / a), (int)listPoint[listPoint.Count - 1].Y));
            foreach (var point in points)
            {
                double distance = DistancePointToLine(point, line);
                if (distance <= 3)
                {
                    edgePoints.Add(new Point((int)Math.Round(point.X), (int)Math.Round(point.Y)));
                }
                else
                {
                    outlierPoints.Add(new Point((int)Math.Round(point.X), (int)Math.Round(point.Y)));
                }
            }
            var bestLine = new LineSegment2D(new Point((int)Math.Round((edgePoints[0].Y - b) / a), edgePoints[0].Y), new Point((int)Math.Round((edgePoints[edgePoints.Count - 1].Y - b) / a), edgePoints[edgePoints.Count - 1].Y));
            return bestLine;
        }
        private double DistancePointToLine(PointF point, LineSegment2D line)
        {
            double a = line.P1.Y - line.P2.Y;
            double b = line.P2.X - line.P1.X;
            double c = line.P1.X * line.P2.Y - line.P2.X * line.P1.Y;

            double numerator = Math.Abs(a * point.X + b * point.Y + c);
            double denominator = Math.Sqrt(a * a + b * b);
            double distace = numerator / denominator;
            return distace;
        }
        
    }
}
