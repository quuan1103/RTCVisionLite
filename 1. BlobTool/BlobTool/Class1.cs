using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Drawing.Drawing2D;
using Emgu.CV.Text;
using System.Reflection;
using RTCBase.Drawing;
using System.Runtime.InteropServices;

namespace BlobTool
{
    public class BlobTool
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
        public RTCRectangle ROI
        {
            set { _ROI = value; }
        }
        public string DetectType
        {
            set { _detectType = value; }
        }
        public bool FillHoles
        {
            set { _fillHoles = value; }
        }
        public string GreyLevelThresholdType
        {
            set { _greyLevelThresholdType = value; }
        }
        public Tuple<int, int> ThresholdRange
        {
            set { _thresholdRange = value; }
        }
        public bool EnableAreaFilter
        {
            set { _enableAreaFilter = value; }
        }
        public bool EnableRowFilter
        {
            set { _enableRowFilter = value; }
        }
        public bool EnableColumnFilter
        {
            set { _enableColumnFilter = value; }
        }
        public bool EnableWidthFilter
        {
            set { _enableWidthFilter = value; }
        }
        public bool EnableHeightFilter
        {
            set { _enableHeightFilter = value; }
        }
        public bool EnableOuterRadiusFilter
        {
            set { _enableOuterRadiusFilter = value;}
        }
        public bool EnableCircularityFilter
        {
            set { _enableCircularityFilter = value;}
        }
        public Tuple<double, double> AreaRange
        {
            set { _areaRange = value; }
        }
        public Tuple<double, double> RowRange
        {
            set { _rowRange = value; }
        }
        public Tuple<double, double> ColumnRange
        {
            set { _columnRange = value; }
        }
        public Tuple<double, double> WidthRange
        {
            set { _widthRange = value; }
        }
        public Tuple<double, double> HeightRange
        {
            set { _heightRange = value; }
        }
        public Tuple<double, double> OuterRadiusRange
        {
            set { _outerRadiusRange = value; }
        }
        public Tuple<double, double> CircularityRange
        {
            set { _circularityRange = value; }
        }
        public Tuple<int, int> RequireNumberOfBlobs
        {
            set { _requireNumberOfBlobs = value;}
        }
        public PointF PositionMouse
        {
            set { _positionMouse = value; }
        }

        /// <summary>
        /// OUTPUT
        /// </summary>

        public List<VectorOfVectorOfPoint> OutputBlobList
        {
            get { return _outputBlobList; }
        }
        public List<double> OutputAreaList
        {
            get { return _outputAreaList; }
        }
        public List<int> OutputWidthList
        {
            get { return _outputWidthList; }
        }
        public List<int> OutputHeightList
        {
            get { return _outputHeightList; }
        }
        public bool Passed
        {
            get { return _passed; }
        }
        public string ErrMessage
        {
            get { return _errMessage; }
        }
        public int NumberOfBlobsFound
        {
            get { return _numberOfBlobsFound; }
        }
        public Bitmap OutputImage
        {
            get { return _outputImage; }
        }
        public double AreaActual
        {
            get { return _areaActual; }
        }
        public double RowActual
        {
            get { return _rowActual; }
        }
        public double ColumnActual
        {
            get { return _columnActual; }
        }
        public double OuterRadiusActual
        {
            get { return _outerRadiusActual; }
        }
        public double CircularityActual
        {
            get { return _circularityActual; }
        }
        public double WidthActual
        {
            get { return _widthActual; }
        }
        public double HeightActual
        {
            get { return _heightActual; }
        }
        /// <summary>
        /// Các biến cục bộ sủ dụng trong Class
        /// </summary>
        private Image<Gray, byte> _inputImage = null;
        private RTCRectangle _ROI = null;
        private Tuple<Point, double> _toolOrigin = null;
        private PointF[] _outSetOrigin = null;
        private string _detectType = null;
        private bool _fillHoles = false;
        private string _greyLevelThresholdType = null;
        private Tuple<int, int> _thresholdRange = null;
        private bool _enableAreaFilter = false;
        private bool _enableRowFilter = false;
        private bool _enableColumnFilter = false;
        private bool _enableWidthFilter = false;
        private bool _enableHeightFilter = false;
        private bool _enableOuterRadiusFilter = false;
        private bool _enableCircularityFilter = false;
        private Tuple<double, double> _areaRange = null;
        private Tuple<double, double> _rowRange = null;
        private Tuple<double, double> _columnRange = null;
        private Tuple<double, double> _widthRange = null;
        private Tuple<double, double> _heightRange = null;
        private Tuple<double, double> _outerRadiusRange = null;
        private Tuple<double, double> _circularityRange = null;
        private Tuple<int, int> _requireNumberOfBlobs = null;
        private PointF _positionMouse = new PointF(-1,-1);


        private string _errMessage = null;
        private List<VectorOfVectorOfPoint> _outputBlobList = null;
        private List<double> _outputAreaList = null;
        private List<int> _outputWidthList = null;
        private List<int> _outputHeightList = null;
        private List<int> _outputRowList = null;
        private List<int> _outputColumnList = null;
        //private List<double> _outputOuterRadiusList = null;
        private List<double> _outputCircularityList = null;
        private int _numberOfBlobsFound = 0;
        private bool _passed = false;
        private Bitmap _outputImage = null;
        private double _areaActual = 0;
        private double _rowActual = 0;
        private double _columnActual = 0;
        private double _outerRadiusActual = 0;
        private double _circularityActual = 0;
        private double _widthActual = 0;
        private double _heightActual = 0;

        /// <summary>
        ///  SetROI() có chức năng cài đặt ROI gắn với ToolOrigin .
        ///  Cần set thuộc tính: ToolOrigin,ROI (có thể set ROI == null) .
        ///  Mỗi lần thay đổi link ToolOrigin hoặc ROI thì cần chạy lại hàm .
        /// </summary>
        /// <returns></returns>
        /// 
        public bool SetROI()
        {
            if (_toolOrigin == null)
            {
                _errMessage = "SetToolOrigin: Lỗi chưa set ToolOrigin";
                return false;
            }
            try
            {
                _outSetOrigin = new PointF[4];
                if (_ROI == null || _ROI.Width == 0 || _ROI.Height == 0)
                {
                    _outSetOrigin = null;
                }
                else
                {
                    //Hàm GetRectangleVertices() lấy tọa độ 4 đỉnh của rectangle
                    _ROI.Width = _ROI.Width ;
                    _ROI.Height = _ROI.Height ;
                    GetRectangleVertices(_ROI, out PointF[] inPointROI);
                    //_errMessage = inPointROI[2].ToString();
                    //Chuyển lần lượt tọa độ 4 đỉnh ROI trong hệ tọa độ ảnh về hệ tọa độ ToolOrigin
                    for (int i = 0; i < 4; i++)
                    {
                        _outSetOrigin[i] = ConvertCoordinatesToNewOrigin(_toolOrigin, inPointROI[i]);
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

        /// <summary>
        /// Phải chạy SetToolOrigin trước khi chạy Run() .
        /// Phải set lại ToolOrigin nếu ToolOrigin thay đổi .
        /// Set các thuộc tính: InputImage,ToolOrigin,DectectType,FillHold,GreyLevelThresholdType,ThresholdRange,RequireNumberOfBlobs
        ///                             EnableAreaFilter,EnableRowFilter,EnableColumnFilter,EnableWidthFilter,EnableHeightFilter,EnableOuterRadiusFilter,EnableCircularityFilter
        ///                             AreaRange,RowRange,ColumnRange,WidthRange,HeightRange,OuterRadiusRange,CircularityRange .
        /// Output: OutputBlobList,OutputAreaList,OutputWidthList,OutputHeightList,NumberOfBlobsFound,Passed,OutputImage,ErrMessage .
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            //Kiểm tra thuộc tính đầu vào
            if (_inputImage == null || _inputImage.Width == 0)
            {
                _errMessage = "Run: Lỗi InputImage = null";
                return false;
            }
            
            if (_detectType == null)
            {
                _errMessage = "Run: Lỗi chưa set DetectType";
                return false;
            }
            if(_greyLevelThresholdType == null)
            {
                _errMessage = "Run: Lỗi chưa set GreyLevelThresholdType";
                return false;
            }
            if(_thresholdRange == null)
            {
                _errMessage = "Run: Lỗi chưa set ThresholdRange";
                return false;
            }
            if(_requireNumberOfBlobs == null)
            {
                _errMessage = "Run: Lỗi chưa set RequireNumberOfBlobs";
                return false;
            }

            //Khởi tạo các giá trị output ban đầu
            _outputBlobList = new List<VectorOfVectorOfPoint>();
            _outputAreaList = new List<double>();
            _outputWidthList = new List<int>();
            _outputHeightList = new List<int>();
            _outputRowList = new List<int>();
            _outputColumnList = new List<int>();
            //_outputOuterRadiusList = new List<double>();
            _outputCircularityList = new List<double>();
            _numberOfBlobsFound = 0;
            _passed = false;
            _outputImage = null;
            _errMessage = null;
            try
            {
                
                //Image<Gray, byte> inputImg = _inputImage.ToImage<Gray, byte>();
                
                var warped = new Mat();
                var blackImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var imgThes = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var imgTest = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var Matrix = new Mat();
                var M = new Mat();
                double theshold = -1;
                PointF[] points = new PointF[4];
                //var outImg = _inputImage.ToImage<Bgr, byte>();
                
                if (_outSetOrigin != null) //Nếu có truyền vào ROI
                {

                    //Chuyển tọa độ 4 đỉnh rectangle trong hệ tọa độ ToolOrigin về hệ tọa độ ảnh
                    for (int i = 0; i < 4; i++)
                    {
                        points[i] = ConvertCoordinatesToOrigin(_toolOrigin, _outSetOrigin[i]);
                    }
                    Point pv1 = new Point((int)Math.Floor(points[0].X ), (int)Math.Floor(points[0].Y ));
                    Point pv2 = new Point((int)Math.Floor(points[1].X ), (int)Math.Floor(points[1].Y ));
                    Point pv3 = new Point((int)Math.Floor(points[2].X ), (int)Math.Floor(points[2].Y ));
                    Point pv4 = new Point((int)Math.Floor(points[3].X ), (int)Math.Floor(points[3].Y ));
                    Point[] p = { pv1,pv2,pv3,pv4 };
                    
                    int width = (int)Math.Round(_ROI.Width);
                    int height = (int)Math.Round(_ROI.Height);
                    
                    var rec = CvInvoke.BoundingRectangle(p);
                    _inputImage.ROI = rec;
                    var warp = _inputImage.Copy();
                    _inputImage.ROI = Rectangle.Empty;
                    theshold = CvInvoke.Threshold(warp, warp, 0, 255, ThresholdType.Otsu);
                }
                
                
                //Đoạn này sẽ Threshold ảnh theo các chế độ GreyLevelThresholdType

                
                switch (_greyLevelThresholdType)
                {
                    case RTCConst.cBlobTool.GreyLevelThresholdType_BrightPixels:
                        {
                            if(_outSetOrigin != null)
                            {
                                CvInvoke.Threshold(_inputImage, imgThes, theshold, 255, ThresholdType.Binary);
                            }
                            else
                            {
                                CvInvoke.Threshold(_inputImage, imgThes, theshold, 255, ThresholdType.Otsu);
                            }
                            break;
                        }
                    case RTCConst.cBlobTool.GreyLevelThresholdType_DarkPixels:
                        {
                            if (_outSetOrigin != null)
                            {
                                CvInvoke.Threshold(_inputImage, imgThes, theshold, 255, ThresholdType.BinaryInv);
                            }
                            else
                            {
                                CvInvoke.Threshold(_inputImage, imgThes, theshold, 255, ThresholdType.Otsu);
                                CvInvoke.Threshold(imgThes,imgThes,125,255,ThresholdType.BinaryInv);
                            }

                            break;
                        }
                    case RTCConst.cBlobTool.GreyLevelThresholdType_FixedThresholdRange:
                        {
                            var minThres = _thresholdRange.Item1;
                            var maxThres = _thresholdRange.Item2;
                            Image<Gray, byte> _outputImageLow = new Image<Gray, byte>(imgThes.Width, imgThes.Height, new Gray(0));
                            Image<Gray, byte> _outputImageHigh = new Image<Gray, byte>(imgThes.Width, imgThes.Height, new Gray(0));
                            if (_detectType == RTCConst.cBlobTool.DectectType_DetectInRangeBlobs)
                            {
                                if (maxThres == 255)
                                {
                                    CvInvoke.Threshold(_inputImage, imgThes, minThres, 255, ThresholdType.Binary);
                                }
                                else if (minThres == 0)
                                {
                                    CvInvoke.Threshold(_inputImage, imgThes, maxThres, 255, ThresholdType.BinaryInv);
                                }
                                else
                                {
                                    CvInvoke.Threshold(_inputImage, _outputImageHigh, maxThres, 255, ThresholdType.Binary);
                                    CvInvoke.Threshold(_inputImage, _outputImageLow, minThres, 255, ThresholdType.BinaryInv);
                                    CvInvoke.Add(_outputImageHigh, _outputImageLow, imgThes);
                                    CvInvoke.Threshold(imgThes, imgThes, 120, 255, ThresholdType.BinaryInv);
                                    
                                }
                            }
                            else if (_detectType == RTCConst.cBlobTool.DectectType_DetectOutOfRangeBlobs)
                            {
                                if (maxThres == 255)
                                {
                                    CvInvoke.Threshold(_inputImage, imgThes, minThres, 255, ThresholdType.BinaryInv);
                                }
                                else if (minThres == 0)
                                {
                                    CvInvoke.Threshold(_inputImage, imgThes, maxThres, 255, ThresholdType.Binary);
                                }
                                else
                                {
                                    CvInvoke.Threshold(_inputImage, _outputImageHigh, maxThres, 255, ThresholdType.Binary);
                                    CvInvoke.Threshold(_inputImage, _outputImageLow, minThres, 255, ThresholdType.BinaryInv);
                                    CvInvoke.Add(_outputImageHigh, _outputImageLow, imgThes);
                                }
                            }
                            break;
                        }
                }
                
                // Đoạn này sẽ Paint vùng ROI vào một ảnh cùng kích thước đầu vào và có nền đen
                if (_outSetOrigin != null)
                {
                    //blackImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height, new Gray(0));
                    VectorOfVectorOfPoint lcontour = new VectorOfVectorOfPoint();
                    VectorOfPoint contour = new VectorOfPoint();
                    Point[] p0 = { new Point((int)Math.Floor(points[0].X), (int)Math.Floor(points[0].Y)) };
                    Point[] p1 = { new Point((int)Math.Floor(points[1].X), (int)Math.Floor(points[1].Y)) };
                    Point[] p2 = { new Point((int)Math.Floor(points[2].X), (int)Math.Floor(points[2].Y)) };
                    Point[] p3 = { new Point((int)Math.Floor(points[3].X), (int)Math.Floor(points[3].Y)) };
                    contour.Push(p0);
                    contour.Push(p1);
                    contour.Push(p2);
                    contour.Push(p3);
                    lcontour.Push(contour);

                    //var h = new Mat();
                    //CvInvoke.DrawContours(blackImage, lcontour, -1, new MCvScalar(255), 1);
                    //lcontour = new VectorOfVectorOfPoint();
                    //CvInvoke.FindContours(blackImage, lcontour, h, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                    CvInvoke.DrawContours(blackImage, lcontour, -1, new MCvScalar(1), -1);

                    //CvInvoke.Subtract(blackImage, imgThes, blackImage);
                    CvInvoke.Multiply(imgThes, blackImage, blackImage);
                    
                }
                else
                {
                    blackImage = imgThes.Clone();
                }
                
                //Đoạn này sẽ tìm các contour và lọc theo các filter
                
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hier = new Mat();
                CvInvoke.FindContours(blackImage, contours, hier, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);
                Array arr = hier.GetData(true);
                
                if (contours.Size > 0)
                {
                    int k = 0;
                    while (k != -1)
                    {
                        if (!_fillHoles)
                        {
                            bool flag = true;
                            double area = CvInvoke.ContourArea(contours[k]);
                            int child = (int)arr.GetValue(0, k, 2);
                            VectorOfVectorOfPoint tmp = new VectorOfVectorOfPoint();
                            tmp.Push(contours[k]);
                            if (child != -1)
                            {
                                tmp.Push(contours[child]);
                                area = area - CvInvoke.ContourArea(contours[child]);
                                int child_next = (int)arr.GetValue(0, child, 0);
                                while (child_next != -1)
                                {
                                    tmp.Push(contours[child_next]);
                                    area = area - CvInvoke.ContourArea(contours[child_next]);
                                    child_next = (int)arr.GetValue(0, child_next, 0);
                                }
                            }
                            Rectangle rect;
                            double perimeter = CvInvoke.ArcLength(contours[k], true);
                            rect = CvInvoke.BoundingRectangle(contours[k]);
                            double circularity = Math.Round((4 * Math.PI * area / (perimeter * perimeter)), 3);
                            if (_enableAreaFilter&&(_areaRange.Item1 >= area || area >= _areaRange.Item2))
                            {
                                flag = false;
                            }
                            if(_enableRowFilter&&(_rowRange.Item1 >= (int)rect.Y || (int)rect.Y >= _rowRange.Item2))
                            {
                                flag = false;
                            }
                            if(_enableColumnFilter&&(_columnRange.Item1 >= (int)rect.X || (int)rect.X >= _columnRange.Item2))
                            {
                                flag = false;
                            }
                            if(_enableWidthFilter&&(_widthRange.Item1 >= rect.Width || rect.Width >= _widthRange.Item2))
                            {
                                flag = false;
                            }
                            if(_enableHeightFilter&&(_heightRange.Item1 >= rect.Height || rect.Height >= _heightRange.Item2))
                            {
                                flag = false;
                            }
                            if(_enableCircularityFilter&&(_circularityRange.Item1 >= circularity || circularity >= _circularityRange.Item2))
                            {
                                flag = false;
                            }
                            if (flag == true)
                            {
                                _outputBlobList.Add(tmp);
                                _outputAreaList.Add(area);
                                //_outputOuterRadiusList.Add(Math.Round(circle.Radius, 3));
                                _outputWidthList.Add(rect.Width);
                                _outputHeightList.Add(rect.Height);
                                _outputColumnList.Add((int)rect.X);
                                _outputRowList.Add((int)rect.Y);
                                _outputCircularityList.Add(circularity);
                                //CvInvoke.DrawContours(outImg, tmp, -1, new MCvScalar(0, 255, 0), -1);
                            }
                            k = (int)arr.GetValue(0, k, 0);
                        }
                        else
                        {
                            bool flag = true;
                            VectorOfVectorOfPoint tmp = new VectorOfVectorOfPoint();
                            double area = CvInvoke.ContourArea(contours[k]);
                            Rectangle rect;
                            double tmpArea = CvInvoke.ContourArea(contours[k]);
                            double perimeter = CvInvoke.ArcLength(contours[k], true);
                            double circularity = Math.Round((4 * Math.PI * area / (perimeter * perimeter)), 3);
                            rect = CvInvoke.BoundingRectangle(contours[k]);
                            tmp.Push(contours[k]);
                            if (_enableAreaFilter && (_areaRange.Item1 >= area || area >= _areaRange.Item2))
                            {
                                flag = false;
                            }
                            if (_enableRowFilter && (_rowRange.Item1 >= (int)rect.Y || (int)rect.Y >= _rowRange.Item2))
                            {
                                flag = false;
                            }
                            if (_enableColumnFilter && (_columnRange.Item1 >= (int)rect.X || (int)rect.X >= _columnRange.Item2))
                            {
                                flag = false;
                            }
                            if (_enableWidthFilter && (_widthRange.Item1 >= rect.Width || rect.Width >= _widthRange.Item2))
                            {
                                flag = false;
                            }
                            if (_enableHeightFilter && (_heightRange.Item1 >= rect.Height || rect.Height >= _heightRange.Item2))
                            {
                                flag = false;
                            }
                            if (_enableCircularityFilter && (_circularityRange.Item1 >= circularity || circularity >= _circularityRange.Item2))
                            {
                                flag = false;
                            }
                            if (flag == true)
                            {
                                _outputBlobList.Add(tmp);
                                _outputAreaList.Add(area);
                                //_outputOuterRadiusList.Add(Math.Round(circle.Radius, 3));
                                _outputWidthList.Add(rect.Width);
                                _outputHeightList.Add(rect.Height);
                                _outputColumnList.Add((int)rect.X);
                                _outputRowList.Add((int)rect.Y);
                                _outputCircularityList.Add(circularity);
                                //CvInvoke.DrawContours(outImg, tmp, -1, new MCvScalar(0, 255, 0), -1);
                            }
                            k = (int)arr.GetValue(0, k, 0);
                        }

                    }


                }
                
                //Paint các contour OK lên ảnh output
                //for (int i = 0; i < _outputBlobList.Count; i++)
                //{
                //    CvInvoke.DrawContours(outImg, _outputBlobList[i], -1, new MCvScalar(0, 255, 0), -1);
                //}
                //_outputImage = outImg.ToBitmap();
                //_outputImage = blackImage.ToBitmap();
                //Kiểm tra pass/fail
                _numberOfBlobsFound = _outputBlobList.Count;
                if (_numberOfBlobsFound >= _requireNumberOfBlobs.Item1 && _numberOfBlobsFound <= _requireNumberOfBlobs.Item2)
                {
                    _passed = true;
                }
            }
            catch (Exception ex)
            {
                _errMessage = "Run: "+ ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            
            return true;
        }


        /// <summary>
        ///ClickMouse: Lấy các thông tin của Region khi click chuột trong Region đó .
        ///Cần phải set PositionMouse .
        ///Output: AreaActual,RowActual,ColumnActual,WidthActual,HeightActual,OuterRadiusActual,CircularityActual .
        /// </summary>
        /// <returns></returns>
        public bool ClickMouse()
        {
            if (_positionMouse.X == -1 || _positionMouse.Y == -1)
            {
                _errMessage = "ClickMouse: Lỗi chưa set PositionMouse";
                return false;
            }
            
            try
            {
                _areaActual = 0;
                _widthActual = 0;
                _heightActual = 0;
                _rowActual = 0;
                _columnActual = 0;
                _outerRadiusActual = 0;
                _circularityActual = 0;
                double minDistance = (double)1 / 0;
                int indexPosition = -1;
                if(_outputBlobList.Count>0)
                {
                    for (int i = 0; i < _outputBlobList.Count; i++)
                    {
                        var contour = _outputBlobList[i];
                        double result = CvInvoke.PointPolygonTest(contour[0], _positionMouse, false);
                        bool isInside = false;
                        if (contour.Size > 1)
                        {
                            for (int j = 1; j < contour.Size; j++)
                            {
                                double inSide = CvInvoke.PointPolygonTest(contour[j], _positionMouse, false);
                                if (inSide >= 0)
                                {
                                    isInside = true;
                                    break;
                                }

                            }
                        }
                        if (result >= 0 && isInside == false)
                        {
                            double distance = CvInvoke.PointPolygonTest(contour[0], _positionMouse, true);
                            if (distance < minDistance)
                            {
                                indexPosition = i;
                            }
                        }

                    }
                    if (indexPosition != -1)
                    {
                        _areaActual = _outputAreaList[indexPosition];
                        _widthActual = _outputWidthList[indexPosition];
                        _heightActual = _outputHeightList[indexPosition];
                        _rowActual = _outputRowList[indexPosition];
                        _columnActual = _outputColumnList[indexPosition];
                        //_outerRadiusActual = _outputOuterRadiusList[indexPosition];
                        _circularityActual = _outputCircularityList[indexPosition];
                    }
                }
                
            }
            catch(Exception ex)
            {
                _errMessage = "ClickMouse: " + ex.Message + "\n" + ex.StackTrace;
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
            p.X = (float)C.Data[0, 0];
            p.Y = (float)C.Data[1, 0];
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
            PointF p = new PointF();
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
            p.X = (float)C.Data[0, 0];
            p.Y = (float)C.Data[1, 0];
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
            double diag = Math.Sqrt(halfwidth * halfwidth + halfheight * halfheight );
            PointF vertex1 = new PointF((float)Convert.ToSingle(centerPoint.X + diag / 2 * Math.Cos(angle + Math.Atan(halfheight / halfwidth))), (float)Convert.ToSingle(centerPoint.Y - diag / 2 * Math.Sin(angle + Math.Atan(halfheight / halfwidth))));
            PointF vertex2 = new PointF((float)Convert.ToSingle(centerPoint.X - diag / 2 * Math.Cos(angle - Math.Atan(halfheight / halfwidth))), (float)Convert.ToSingle(centerPoint.Y + diag / 2 * Math.Sin(angle - Math.Atan(halfheight / halfwidth))));
            PointF vertex3 = new PointF((float)Convert.ToSingle(centerPoint.X - diag / 2 * Math.Cos(angle + Math.Atan(halfheight / halfwidth))), (float)Convert.ToSingle(centerPoint.Y + diag / 2 * Math.Sin(angle + Math.Atan(halfheight / halfwidth))));
            PointF vertex4 = new PointF((float)Convert.ToSingle(centerPoint.X + diag / 2 * Math.Cos(angle - Math.Atan(halfheight / halfwidth))), (float)Convert.ToSingle(centerPoint.Y - diag / 2 * Math.Sin(angle - Math.Atan(halfheight / halfwidth))));
            pointRec = new PointF[] { vertex1, vertex2, vertex3, vertex4 };
        }

    }
}
