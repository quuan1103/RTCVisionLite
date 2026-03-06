using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV.Util;

namespace Blob_Filter
{
    public class BlobFilter
    {
        /// <summary>
        /// INPUT
        /// </summary>
        public Image<Gray, byte> InputImage
        {
            set { _inputImage = value; }
        }
        public List<VectorOfVectorOfPoint> InputBlobList
        {
            set { _inputBlobList = value; }
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
            set { _enableOuterRadiusFilter = value; }
        }
        public string SelectedIndex
        {
            set { _SelectedIndex = value; }
        }
        public bool EnableCircularityFilter
        {
            set { _enableCircularityFilter = value; }
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
            set { _requireNumberOfBlobs = value; }
        }
        public PointF PositionMouse
        {
            set { _positionMouse = value; }
        }
        public bool IsShowImageResult
        {
            set { _isShowImageResult = value; }
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
        public Bitmap OutputImageShow
        {
            get { return _outputImageShow; }
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
        private List<VectorOfVectorOfPoint> _inputBlobList = null;
        private bool _enableAreaFilter = false;
        private bool _enableRowFilter = false;
        private bool _enableColumnFilter = false;
        private bool _enableWidthFilter = false;
        private bool _enableHeightFilter = false;
        private bool _enableOuterRadiusFilter = false;
        private bool _enableCircularityFilter = false;
        private string _SelectedIndex = "All";
        private Tuple<double, double> _areaRange = null;
        private Tuple<double, double> _rowRange = null;
        private Tuple<double, double> _columnRange = null;
        private Tuple<double, double> _widthRange = null;
        private Tuple<double, double> _heightRange = null;
        private Tuple<double, double> _outerRadiusRange = null;
        private Tuple<double, double> _circularityRange = null;
        private Tuple<int, int> _requireNumberOfBlobs = null;
        private PointF _positionMouse = new PointF(-1, -1);
        private bool _isShowImageResult = false;

        private string _errMessage = null;
        private List<VectorOfVectorOfPoint> _outputBlobList = null;
        private List<double> _outputAreaList = null;
        private List<int> _outputWidthList = null;
        private List<int> _outputHeightList = null;
        private List<int> _outputRowList = null;
        private List<int> _outputColumnList = null;
        private List<double> _outputOuterRadiusList = null;
        private List<double> _outputCircularityList = null;
        private int _numberOfBlobsFound = 0;
        private bool _passed = false;
        private Bitmap _outputImageShow = null;
        private double _areaActual = 0;
        private double _rowActual = 0;
        private double _columnActual = 0;
        private double _outerRadiusActual = 0;
        private double _circularityActual = 0;
        private double _widthActual = 0;
        private double _heightActual = 0;

        public bool Run()
        {
            //Kiểm tra thuộc tính đầu vào
            if (_inputImage == null || _inputImage.Width == 0)
            {
                _errMessage = "Run: Lỗi InputImage = null";
                return false;
            }
            if(_inputBlobList == null)
            {
                _errMessage = "Run: Lỗi InputBlobList = null";
            }

            //Khởi tạo các giá trị output ban đầu
            _outputBlobList = new List<VectorOfVectorOfPoint>();
            _outputAreaList = new List<double>();
            _outputWidthList = new List<int>();
            _outputHeightList = new List<int>();
            _outputRowList = new List<int>();
            _outputColumnList = new List<int>();
            _outputOuterRadiusList = new List<double>();
            _outputCircularityList = new List<double>();
            _numberOfBlobsFound = 0;
            _passed = false;
            _outputImageShow = null;
            try
            {
                for (int i = 0; i < _inputBlobList.Count; i++)
                {
                    VectorOfVectorOfPoint region = _inputBlobList[i];
                    bool flag = true;
                    double area = CvInvoke.ContourArea(region[0]);
                    if (region.Size > 1)
                    {
                        for(int j = 1; j < region.Size; j++)
                        {
                            area = area - CvInvoke.ContourArea(region[j]);
                        }
                    }
                    Rectangle rect;
                    double perimeter = CvInvoke.ArcLength(region[0], true);
                    rect = CvInvoke.BoundingRectangle(region[0]);
                    double circularity = Math.Round((4 * Math.PI * area / (perimeter * perimeter)), 3);
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
                        _outputBlobList.Add(region);
                        _outputAreaList.Add(area);
                        //_outputOuterRadiusList.Add(Math.Round(circle.Radius, 3));
                        _outputWidthList.Add(rect.Width);
                        _outputHeightList.Add(rect.Height);
                        _outputColumnList.Add((int)rect.X);
                        _outputRowList.Add((int)rect.Y);
                        _outputCircularityList.Add(circularity);
                        //CvInvoke.DrawContours(outImg, tmp, -1, new MCvScalar(0, 255, 0), -1);
                    }
                }
                //Kiểm tra pass/fail
                _numberOfBlobsFound = _outputBlobList.Count;
                if (_numberOfBlobsFound >= _requireNumberOfBlobs.Item1 && _numberOfBlobsFound <= _requireNumberOfBlobs.Item2)
                {
                    _passed = true;
                }

                //Paint Region
                if (_isShowImageResult)
                {
                    if (_inputImage == null)
                        return false;
                    if (_outputBlobList == null)
                        return false;
                    var imgShow = _inputImage.Convert<Bgr, byte>();
                    bool Selected = int.TryParse(_SelectedIndex, out int Index);
                    for (int i = 0; i < _outputBlobList.Count; i++)
                    {

                        //CvInvoke.DrawContours(imgShow, _outputBlobList[i], -1, new MCvScalar(0, 255, 0), -1);
                        if (_SelectedIndex.ToLower() == "all")
                        {

                            CvInvoke.FillPoly(imgShow, _outputBlobList[i], new MCvScalar(0, 255, 0));
                        }
                        else if (Index == i)
                        {
                            CvInvoke.FillPoly(imgShow, _outputBlobList[i], new MCvScalar(0, 0, 255));
                        }
                        else
                        {
                            CvInvoke.FillPoly(imgShow, _outputBlobList[i], new MCvScalar(0, 255, 0));

                        }
                    }
                    _outputImageShow = imgShow.ToBitmap();
                    imgShow.Dispose();
                }
            }
            catch (Exception ex)
            {
                _errMessage = "Run: " + ex.Message + "\n" + ex.StackTrace;
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
                if (_outputBlobList.Count > 0)
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
                        _outerRadiusActual = _outputOuterRadiusList[indexPosition];
                        _circularityActual = _outputCircularityList[indexPosition];
                    }
                }

            }
            catch (Exception ex)
            {
                _errMessage = "ClickMouse: " + ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            return true;
        }
    }
}
