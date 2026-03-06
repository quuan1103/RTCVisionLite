using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using RTCBase.Drawing;
using RTCConst;

namespace Blob_Color_Multi_ROI
{
    public class BlobColor
    {
        /// <summary>
        /// INPUT
        /// </summary>
        public Image<Bgr, byte> InputImage
        {
            set { _inputImage = value; }
        }
        public Tuple<Point, double> ToolOrigin
        {
            set { _toolOrigin = value; }
        }
        public List<PointF[]> InSetOrigin
        {
            set { _inSetOrigin = value; }
        }
        private List<PointF[]> _inSetOrigin = new List<PointF[]>();
        public List<RTCRectangle> ROITrain
        {
            set { _ROITrain = value; }
        }
        public bool FillHoles
        {
            set { _fillHoles = value; }
        }
        public string ColorSpace
        {
            set { _colorSpace = value; }
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
        public bool EnableCircularityFilter
        {
            set { _enableCircularityFilter = value; }
        }
        public bool RequiredPass
        {
            set { _RequiredPass = value; }
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
        public Tuple<int, int, int> HueTolerance
        {
            set { _hueTolerance = value; }
            get { return _hueTolerance; }
        }
        public Tuple<int, int, int> SaturationTolerance
        {
            set { _saturationTolerance = value; }
            get { return _saturationTolerance; }
        }
        public Tuple<int, int, int> IntensityTolerance
        {
            set { _intensityTolerance = value; }
            get { return _intensityTolerance; }
        }
        public Tuple<int, int, int> BlueTolerance
        {
            set { _blueTolerance = value; }
            get { return _blueTolerance; }
        }
        public Tuple<int, int, int> GreenTolerance
        {
            set { _greenTolerance = value; }
            get { return _greenTolerance; }
        }
        public Tuple<int, int, int> RedTolerance
        {
            set { _redTolerance = value; }
            get { return _redTolerance; }
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


        private Image<Bgr, byte> _inputImage = null;
        //private List<RTCRectangle> _ROI = null;
        private List<RTCRectangle> _ROITrain = null;
        private Tuple<Point, double> _toolOrigin = null;
        //private List<PointF[]> _outSetOrigin = new List<PointF[]>();
        private Tuple<int, int, int> _hueTolerance = null;
        private Tuple<int, int, int> _saturationTolerance = null;
        private Tuple<int, int, int> _intensityTolerance = null;
        private Tuple<int, int, int> _blueTolerance = null;
        private Tuple<int, int, int> _greenTolerance = null;
        private Tuple<int, int, int> _redTolerance = null;
        private string _colorSpace = null;
        private bool _fillHoles = false;
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
        private bool _RequiredPass = true;

        /// <summary>
        ///  SetROI() có chức năng cài đặt ROI gắn với ToolOrigin .
        ///  Cần set thuộc tính: ToolOrigin,ROI (có thể set ROI == null) .
        ///  Mỗi lần thay đổi link ToolOrigin hoặc ROI thì cần chạy lại hàm .
        /// </summary>
        /// <returns></returns>
        /// 
        //public bool SetToolOrigin()
        //{
        //    _outSetOrigin = new List<PointF[]>();
        //    if (_toolOrigin == null)
        //    {
        //        _errMessage = "SetToolOrigin: Lỗi chưa set ToolOrigin";
        //        return false;
        //    }
        //    try
        //    {
        //        if (_ROI == null)
        //        {
        //            _outSetOrigin = null;
        //        }
        //        else
        //        {
        //            for (int i = 0; i < _ROI.Count; i++)
        //            {
        //                var pROI = new PointF[4];
        //                //Hàm GetRectangleVertices() lấy tọa độ 4 đỉnh của rectangle
        //                GetRectangleVertices(_ROI[i], out PointF[] inPointROI);

        //                //Chuyển lần lượt tọa độ 4 đỉnh ROI trong hệ tọa độ ảnh về hệ tọa độ ToolOrigin
        //                for (int j = 0; j < 4; j++)
        //                {
        //                    pROI[j] = ConvertCoordinatesToNewOrigin(_toolOrigin, inPointROI[j]);
        //                }
        //                _outSetOrigin.Add(pROI);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _errMessage = "SetToolOrigin: " + ex.Message + "\n" + ex.StackTrace;
        //        return false;
        //    }

        //    return true;
        //}

        /// <summary>
        /// Train() Lấy các thông tin các kênh màu HSV, BGR .
        /// Cần set thuộc tính: InputImage, ROITrain .
        /// Output: HueTolerance,SaturationTolerance,IntensityTolerance,BlueTolerance,GreenTolerance,RedTolerance .
        /// </summary>
        /// <returns></returns>
        /// 
        public bool Train()
        {
            //Kiểm tra thuộc tính đầu vào
            if (_inputImage == null || _inputImage.Width == 0)
            {
                _errMessage = "Train: Lỗi InputImage = null";
                return false;
            }
            if (_ROITrain == null)
            {
                _errMessage = "Train: Lỗi chưa set ROITrain";
                return false;
            }
            try
            {
                _hueTolerance = null;
                _saturationTolerance = null;
                _intensityTolerance = null;
                _blueTolerance = null;
                _greenTolerance = null;
                _redTolerance = null;
                //var imgInput = _inputImage.ToImage<Bgr, byte>();



                List<Mat> lImageH = new List<Mat>();
                List<Mat> lImageS = new List<Mat>();
                List<Mat> lImageV = new List<Mat>();
                List<Mat> lImageR = new List<Mat>();
                List<Mat> lImageG = new List<Mat>();
                List<Mat> lImageB = new List<Mat>();


                for (int i = 0; i < _ROITrain.Count; i++)
                {
                    GetRectangleVertices(_ROITrain[i], out PointF[] srcPoints);
                    var dstPoints = new PointF[] {
                         new PointF(0, (int)_ROITrain[i].Height-1),
                        new PointF(0, 0),
                        new PointF((int)_ROITrain[i].Width-1, 0),
                        new PointF((int)_ROITrain[i].Width-1, (int)_ROITrain[i].Height-1)};
                    var M = CvInvoke.GetPerspectiveTransform(srcPoints, dstPoints);

                    Mat imageWarp = new Mat();
                    CvInvoke.WarpPerspective(_inputImage, imageWarp, M, new Size((int)_ROITrain[i].Width, (int)_ROITrain[i].Height));

                    Image<Hsv, byte> imgHSV = imageWarp.ToImage<Hsv, byte>();
                    Image<Bgr, byte> imgBGR = imageWarp.ToImage<Bgr, byte>();
                    Rectangle cropRect = new Rectangle(0, 0, (int)_ROITrain[i].Width - 3, (int)_ROITrain[i].Height);
                    Mat imgHSVCrop_0 = new Mat(imgHSV[0].Mat, cropRect);
                    Mat imgHSVCrop_1 = new Mat(imgHSV[1].Mat, cropRect);
                    Mat imgHSVCrop_2 = new Mat(imgHSV[2].Mat, cropRect);
                    Mat imgBGRCrop_0 = new Mat(imgBGR[0].Mat, cropRect);
                    Mat imgBGRCrop_1 = new Mat(imgBGR[1].Mat, cropRect);
                    Mat imgBGRCrop_2 = new Mat(imgBGR[2].Mat, cropRect);

                    // Set default values for output parameters
                    lImageH.Add(imgHSVCrop_0);
                    lImageS.Add(imgHSVCrop_1);
                    lImageV.Add(imgHSVCrop_2);

                    lImageB.Add(imgBGRCrop_0);
                    lImageG.Add(imgBGRCrop_1);
                    lImageR.Add(imgBGRCrop_2);

                }
                byte[] arrayH = CombineMultipleImageArrays(lImageH);
                byte[] arrayS = CombineMultipleImageArrays(lImageS);
                byte[] arrayV = CombineMultipleImageArrays(lImageV);

                byte[] arrayB = CombineMultipleImageArrays(lImageB);
                byte[] arrayG = CombineMultipleImageArrays(lImageG);
                byte[] arrayR = CombineMultipleImageArrays(lImageR);

                int sArr = arrayH.Count();

                Image<Gray, byte> imageH = new Image<Gray, byte>(sArr, 1);
                Buffer.BlockCopy(arrayH, 0, imageH.Data, 0, sArr);

                Image<Gray, byte> imageS = new Image<Gray, byte>(sArr, 1);
                Buffer.BlockCopy(arrayS, 0, imageS.Data, 0, sArr);

                Image<Gray, byte> imageV = new Image<Gray, byte>(sArr, 1);
                Buffer.BlockCopy(arrayV, 0, imageV.Data, 0, sArr);

                Image<Gray, byte> imageB = new Image<Gray, byte>(sArr, 1);
                Buffer.BlockCopy(arrayB, 0, imageB.Data, 0, sArr);

                Image<Gray, byte> imageG = new Image<Gray, byte>(sArr, 1);
                Buffer.BlockCopy(arrayG, 0, imageG.Data, 0, sArr);

                Image<Gray, byte> imageR = new Image<Gray, byte>(sArr, 1);
                Buffer.BlockCopy(arrayR, 0, imageR.Data, 0, sArr);


                var Hmin = new double[1];
                var Hmax = new double[1];
                var Smin = new double[1];
                var Smax = new double[1];
                var Vmin = new double[1];
                var Vmax = new double[1];
                var Rmin = new double[1];
                var Rmax = new double[1];
                var Gmin = new double[1];
                var Gmax = new double[1];
                var Bmin = new double[1];
                var Bmax = new double[1];
                Point[] minLoc = new Point[1], maxLoc = new Point[1];
                Image<Bgr, byte> imgBgr = new Image<Bgr, byte>(sArr, 1);
                imgBgr[0] = imageB;
                imgBgr[1] = imageG;
                imgBgr[2] = imageR;

                Image<Hsv, byte> imgHsv = new Image<Hsv, byte>(sArr, 1);
                imgHsv[0] = imageH;
                imgHsv[1] = imageS;
                imgHsv[2] = imageV;


                imgHsv[0].MinMax(out Hmin, out Hmax, out minLoc, out maxLoc);
                imgHsv[1].MinMax(out Smin, out Smax, out minLoc, out maxLoc);
                imgHsv[2].MinMax(out Vmin, out Vmax, out minLoc, out maxLoc);
                imgBgr[0].MinMax(out Bmin, out Bmax, out minLoc, out maxLoc);
                imgBgr[1].MinMax(out Gmin, out Gmax, out minLoc, out maxLoc);
                imgBgr[2].MinMax(out Rmin, out Rmax, out minLoc, out maxLoc);




                //var BGRMean = arrayH.Average( b =>(int)b);

                var hMean = (int)arrayH.Average(b => (int)b);
                var sMean = (int)arrayS.Average(b => (int)b);
                var vMean = (int)arrayV.Average(b => (int)b);
                var bMean = (int)arrayB.Average(b => (int)b);
                var gMean = (int)arrayG.Average(b => (int)b);
                var rMean = (int)arrayR.Average(b => (int)b);



                //imgBGR[0].MinMax(out Bmin, out Bmax, out minLoc, out maxLoc);
                //imgBGR[1].MinMax(out Gmin, out Gmax, out minLoc, out maxLoc);
                //imgBGR[2].MinMax(out Rmin, out Rmax, out minLoc, out maxLoc);

                //MCvScalar BGRMean = CvInvoke.Mean(imgBGR);
                //var bMean = (int)Math.Round(BGRMean.V0);
                //var gMean = (int)Math.Round(BGRMean.V1);
                //var rMean = (int)Math.Round(BGRMean.V2);

                _hueTolerance = Tuple.Create((int)(hMean - Hmin[0]), hMean, (int)(Hmax[0] - hMean));
                _saturationTolerance = Tuple.Create((int)(sMean - Smin[0]), sMean, (int)(Smax[0] - sMean));
                _intensityTolerance = Tuple.Create((int)(vMean - Vmin[0]), vMean, (int)(Vmax[0] - vMean));
                _blueTolerance = Tuple.Create((int)(bMean - Bmin[0]), bMean, (int)(Bmax[0] - bMean));
                _greenTolerance = Tuple.Create((int)(gMean - Gmin[0]), gMean, (int)(Gmax[0] - gMean));
                _redTolerance = Tuple.Create((int)(rMean - Rmin[0]), rMean, (int)(Rmax[0] - rMean));


            }
            catch (Exception ex)
            {
                _errMessage = "Train: " + ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            return true;
        }
        private byte[] ConvertImageTo1DArray(Mat img)
        {
            int width = img.Width;
            int height = img.Height;
            byte[] pixelValues = new byte[width * height];
            Buffer.BlockCopy(img.GetData(), 0, pixelValues, 0, pixelValues.Length);
            return pixelValues;
        }

        private byte[] CombineMultipleImageArrays(List<Mat> images)
        {
            // Calculate the total length of the combined array
            int totalLength = 0;
            foreach (var img in images)
            {
                totalLength += img.Width * img.Height;
            }

            // Create a new array to hold all the images
            byte[] combinedArray = new byte[totalLength];

            int currentPosition = 0;
            foreach (var img in images)
            {
                byte[] pixelValues = ConvertImageTo1DArray(img);
                Buffer.BlockCopy(pixelValues, 0, combinedArray, currentPosition, pixelValues.Length);
                currentPosition += pixelValues.Length;
            }

            return combinedArray;
        }




        //public bool Train()
        //{
        //    //Kiểm tra thuộc tính đầu vào
        //    if (_inputImage == null || _inputImage.Width == 0)
        //    {
        //        _errMessage = "Train: Lỗi InputImage = null";
        //        return false;
        //    }
        //    if (_ROITrain == null)
        //    {
        //        _errMessage = "Train: Lỗi chưa set ROITrain";
        //        return false;
        //    }
        //    try
        //    {
        //        _hueTolerance = null;
        //        _saturationTolerance = null;
        //        _intensityTolerance = null;
        //        _blueTolerance = null;
        //        _greenTolerance = null;
        //        _redTolerance = null;
        //        //var imgInput = _inputImage.ToImage<Bgr, byte>();
        //        GetRectangleVertices(_ROITrain, out PointF[] srcPoints);
        //        var dstPoints = new PointF[] {
        //                 new PointF(0, (float)_ROITrain.Height-1),
        //                new PointF(0, 0),
        //                new PointF((float)_ROITrain.Width-1, 0),
        //                new PointF((float)_ROITrain.Width-1, (float)_ROITrain.Height-1)};
        //        var M = CvInvoke.GetPerspectiveTransform(srcPoints, dstPoints);
        //        Mat imageWarp = new Mat();
        //        CvInvoke.WarpPerspective(_inputImage, imageWarp, M, new Size((int)_ROITrain.Width, (int)_ROITrain.Height));
        //        var imgHSV = imageWarp.ToImage<Hsv, byte>();
        //        var imgBGR = imageWarp.ToImage<Bgr, byte>();
        //        Rectangle cropRect = new Rectangle(0, 0, (int)_ROITrain.Width - 3, (int)_ROITrain.Height);
        //        Mat imgHSVCrop_0 = new Mat(imgHSV[0].Mat, cropRect);
        //        Mat imgHSVCrop_1 = new Mat(imgHSV[1].Mat, cropRect);
        //        Mat imgHSVCrop_2 = new Mat(imgHSV[2].Mat, cropRect);
        //        Mat imgBGRCrop_0 = new Mat(imgBGR[0].Mat, cropRect);
        //        Mat imgBGRCrop_1 = new Mat(imgBGR[1].Mat, cropRect);
        //        Mat imgBGRCrop_2 = new Mat(imgBGR[2].Mat, cropRect);

        //        // Set default values for output parameters
        //        //Find Param
        //        var Hmin = new double[1];
        //        var Hmax = new double[1];
        //        var Smin = new double[1];
        //        var Smax = new double[1];
        //        var Vmin = new double[1];
        //        var Vmax = new double[1];
        //        var Rmin = new double[1];
        //        var Rmax = new double[1];
        //        var Gmin = new double[1];
        //        var Gmax = new double[1];
        //        var Bmin = new double[1];
        //        var Bmax = new double[1];
        //        Point[] minLoc = new Point[1], maxLoc = new Point[1];
        //        imgHSVCrop_0.MinMax(out Hmin, out Hmax, out minLoc, out maxLoc);
        //        imgHSVCrop_1.MinMax(out Smin, out Smax, out minLoc, out maxLoc);
        //        imgHSVCrop_2.MinMax(out Vmin, out Vmax, out minLoc, out maxLoc);

        //        MCvScalar HSVMean = CvInvoke.Mean(imgHSV);
        //        var hMean = (int)Math.Round(HSVMean.V0);
        //        var sMean = (int)Math.Round(HSVMean.V1);
        //        var vMean = (int)Math.Round(HSVMean.V2);

        //        imgBGRCrop_0.MinMax(out Bmin, out Bmax, out minLoc, out maxLoc);
        //        imgBGRCrop_1.MinMax(out Gmin, out Gmax, out minLoc, out maxLoc);
        //        imgBGRCrop_2.MinMax(out Rmin, out Rmax, out minLoc, out maxLoc);

        //        MCvScalar BGRMean = CvInvoke.Mean(imgBGR);
        //        var bMean = (int)Math.Round(BGRMean.V0);
        //        var gMean = (int)Math.Round(BGRMean.V1);
        //        var rMean = (int)Math.Round(BGRMean.V2);

        //        _hueTolerance = Tuple.Create((int)(hMean - Hmin[0]), hMean, (int)(Hmax[0] - hMean));
        //        _saturationTolerance = Tuple.Create((int)(sMean - Smin[0]), sMean, (int)(Smax[0] - sMean));
        //        _intensityTolerance = Tuple.Create((int)(vMean - Vmin[0]), vMean, (int)(Vmax[0] - vMean));
        //        _blueTolerance = Tuple.Create((int)(bMean - Bmin[0]), bMean, (int)(Bmax[0] - bMean));
        //        _greenTolerance = Tuple.Create((int)(gMean - Gmin[0]), gMean, (int)(Gmax[0] - gMean));
        //        _redTolerance = Tuple.Create((int)(rMean - Rmin[0]), rMean, (int)(Rmax[0] - rMean));
        //    }
        //    catch (Exception ex)
        //    {
        //        _errMessage = "Train: " + ex.Message + "\n" + ex.StackTrace;
        //        return false;
        //    }
        //    return true;
        //}


        /// <summary>
        /// Phải chạy SetToolOrigin trước khi chạy Run() .
        /// Phải set lại ToolOrigin nếu ToolOrigin thay đổi .
        /// Set các thuộc tính: InputImage,ToolOrigin,FillHold,ColorSpace,HueTolerance,SaturationTolerance,IntensityTolerance,BlueTolerance,GreenTolerance,RedTolerance,RequireNumberOfBlobs,
        /// EnableAreaFilter,EnableRowFilter,EnableColumnFilter,EnableWidthFilter,EnableHeightFilter,EnableOuterRadiusFilter,EnableCircularityFilter,AreaRange,RowRange,ColumnRange,WidthRange,HeightRange,OuterRadiusRange,CircularityRange .
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

            if (_requireNumberOfBlobs == null)
            {
                _errMessage = "Run: Lỗi chưa set RequireNumberOfBlobs";
                return false;
            }
            if (_colorSpace == null)
            {
                _errMessage = "Run: Lỗi chưa set ColorSpace";
                return false;
            }
            //if (_hueTolerance == null)
            //{
            //    _errMessage = "Run: Lỗi chưa set HueTolerance";
            //    return false;
            //}
            //if (_saturationTolerance == null)
            //{
            //    _errMessage = "Run: Lỗi chưa set SaturationTolerance";
            //    return false;
            //}
            //if (_intensityTolerance == null)
            //{
            //    _errMessage = "Run: Lỗi chưa set IntensityTolerance";
            //    return false;
            //}
            if (_blueTolerance == null)
            {
                _errMessage = "Run: Lỗi chưa set BlueTolerance";
                return false;
            }
            if (_greenTolerance == null)
            {
                _errMessage = "Run: Lỗi chưa set GreenTolerance";
                return false;
            }
            if (_redTolerance == null)
            {
                _errMessage = "Run: Lỗi chưa set RedTolerance";
                return false;
            }

            //Set tool Origin cho ROI
            //SetROI();
            try
            {
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
                //_outputImage = _inputImage;
                //Image<Bgr, byte> inputImg = _inputImage.ToImage<Bgr, byte>();
                var imgInRange = new Mat();
                var warped = new Mat();
                var blackImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var Matrix = new Mat();
                var M = new Mat();
                var imgThes = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                ScalarArray lower = new ScalarArray(1);
                ScalarArray upper = new ScalarArray(1);
                if (_colorSpace == cBlobColorTool.ColorSpace_BGR)
                {
                    lower = new ScalarArray(new MCvScalar(_blueTolerance.Item2 - _blueTolerance.Item1, _greenTolerance.Item2 - _greenTolerance.Item1, _redTolerance.Item2 - _redTolerance.Item1));
                    upper = new ScalarArray(new MCvScalar(_blueTolerance.Item2 + _blueTolerance.Item3, _greenTolerance.Item2 + _greenTolerance.Item3, _redTolerance.Item2 + _redTolerance.Item3));
                    CvInvoke.InRange(_inputImage, lower, upper, imgInRange);
                }
                if (_colorSpace == cBlobColorTool.ColorSpace_HSV)
                {
                    lower = new ScalarArray(new MCvScalar(_hueTolerance.Item2 - _hueTolerance.Item1, _saturationTolerance.Item2 - _saturationTolerance.Item1, _intensityTolerance.Item2 - _intensityTolerance.Item1));
                    upper = new ScalarArray(new MCvScalar(_hueTolerance.Item2 + _hueTolerance.Item3, _saturationTolerance.Item2 + _saturationTolerance.Item3, _intensityTolerance.Item2 + _intensityTolerance.Item3));
                    CvInvoke.InRange(_inputImage, lower, upper, imgInRange);
                }

                // Đoạn này sẽ Paint vùng ROI vào một ảnh cùng kích thước đầu vào và có nền đen
                if (_inSetOrigin != null && _inSetOrigin.Count > 0)
                {
                    blackImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height, new Gray(0));
                    VectorOfVectorOfPoint lcontour = new VectorOfVectorOfPoint();
                    for (int j = 0; j < _inSetOrigin.Count; j++)
                    {
                        var arrROI = _inSetOrigin[j];
                        PointF[] points = new PointF[4];
                        for (int i = 0; i < 4; i++)
                        {
                            points[i] = ConvertCoordinatesToOrigin(_toolOrigin, arrROI[i]);
                        }
                        VectorOfPoint contour = new VectorOfPoint();
                        Point[] p0 = { new Point((int)Math.Round(points[0].X), (int)Math.Round(points[0].Y)) };
                        Point[] p1 = { new Point((int)Math.Round(points[1].X), (int)Math.Round(points[1].Y)) };
                        Point[] p2 = { new Point((int)Math.Round(points[2].X), (int)Math.Round(points[2].Y)) };
                        Point[] p3 = { new Point((int)Math.Round(points[3].X), (int)Math.Round(points[3].Y)) };
                        contour.Push(p0);
                        contour.Push(p1);
                        contour.Push(p2);
                        contour.Push(p3);
                        lcontour.Push(contour);
                        CvInvoke.DrawContours(blackImage, lcontour, -1, new MCvScalar(1), -1);

                    }
                    imgThes = imgInRange.ToImage<Gray, byte>();
                    //CvInvoke.Subtract(blackImage, imgThes, blackImage);
                    CvInvoke.Multiply(imgThes, blackImage, blackImage);
                }
                else
                {
                    blackImage = imgInRange.ToImage<Gray, byte>();
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

                //var outImg = _inputImage.ToImage<Bgr, byte>();
                ////Paint các contour OK lên ảnh output
                //for (int i = 0; i < _outputBlobList.Count; i++)
                //{
                //    CvInvoke.DrawContours(outImg, _outputBlobList[i], -1, new MCvScalar(0, 255, 0), -1);
                //}
                //_outputImage = outImg.ToBitmap();
                //_outputImage = blackImage.ToBitmap();
                //Kiểm tra pass/fail
                _numberOfBlobsFound = _outputBlobList.Count;
                if (_RequiredPass)
                {
                    if (_numberOfBlobsFound >= _requireNumberOfBlobs.Item1 && _numberOfBlobsFound <= _requireNumberOfBlobs.Item2)
                    {
                        _passed = true;
                    }
                }
                else
                    _passed = true;
                //Paint Region
                if (_isShowImageResult)
                {
                    if (_inputImage == null)
                        return false;
                    if (_outputBlobList == null)
                        return false;
                    var imgShow = _inputImage.Convert<Bgr, byte>();
                    for (int i = 0; i < _outputBlobList.Count; i++)
                    {
                        //CvInvoke.DrawContours(imgShow, _outputBlobList[i], -1, new MCvScalar(0, 255, 0), -1);
                        CvInvoke.FillPoly(imgShow, _outputBlobList[i], new MCvScalar(0, 255, 0));
                    }
                    _outputImageShow = imgShow.ToBitmap();
                    //_outputImageShow = blackImage.ToBitmap();
                    imgShow.Dispose();
                }
                imgThes.Dispose();
                blackImage.Dispose();
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
                double minDistance = (double)1 / 0;
                int indexPosition = -1;
                if (_outputBlobList != null && _outputBlobList.Count > 0)
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
