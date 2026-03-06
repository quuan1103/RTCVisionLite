using System;
using System.Collections.Generic;
using RTCBase.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.CvEnum;
using ZXing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Text.Json.Serialization;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using ZXing.QrCode;
using ZXing.Common;
using static System.Net.Mime.MediaTypeNames;
using Aspose.BarCode;
using Aspose.BarCode.BarCodeRecognition;
using System.Text;
using Emgu.CV.Reg;
using System.Drawing.Printing;
//using Spire.Barcode;
using Emgu.CV.Stitching;
using System.Data;
//using Spire.Barcode.Settings;

namespace CodeReader
{
    public class CodeReader
    {
        /// <summary>
        /// INPUT
        /// </summary>
        public Image<Gray, byte> InputImage
        {
            set { _inputImage = value; }
        }
        public Tuple<PointF, double> ToolOrigin
        {
            set { _toolOrigin = value; }
        }
        public PointF[] InSetOrigin
        {
            set { _inSetOrigin = value; }
        }
        public RTCRectangle ROITrain
        {
            set { _ROITrain = value; }
        }
        public RTCRectangle ROISearch
        {
            set { _ROISearch = value; }
        }
        public string CodeType
        {
            set { _codeType = value; }
        }
        public List<string> InputListFormatTrain
        {
            set { _inputlistFormatTrain = value; }
        }
        public string PathSaveFileTrain
        {
            set { _pathSaveFileTrain = value; }
        }
        public bool IsShowImageResult
        {
            set { _isShowImageResult = value; }
        }
        

        /// <summary>
        /// OUTPUT
        /// </summary>
        public bool Passed
        {
            get { return _passed; }
        }
        public string ErrMessage
        {
            get { return _errMessage; }
        }
        public List<string> OutputStringCode
        {
            get { return _outputStringCode; }
        }
        public string CodeFomat
        {
            get { return _codeFomat; }
        }
        public List<DataCodeTrain> DataTrain
        {
            get { return _dataTrain; }
        }
        public List<string> OutputCodeFomatTrain
        {
            get { return _outputListFomatTrain; }
        }
        public VectorOfVectorOfPoint OutputRegion
        {
            get { return _outputRegion; }
        }
        public Bitmap OutputImageShow
        {
            get { return _outputImageShow; }
        }
        /// <summary>
        /// Setting
        /// </summary>
        public int SetLineWidth
        {
            set { _lineWidth = value; }
        }
        public double SetFontSize
        {
            set { _fontSize = value; }
        }
        public string SetDraw
        {
            set { _setDraw = value; }
        }
        public MCvScalar Color
        {
            set { _color = value; }
        }
        /// <summary>
        /// Các biến cục bộ sủ dụng trong Class
        /// </summary>
        private Image<Gray, byte> _inputImage = null;
        private RTCRectangle _ROITrain = null;
        private RTCRectangle _ROISearch = null;
        private Tuple<PointF, double> _toolOrigin = null;
        private PointF[] _inSetOrigin = new PointF[4];
        private string _codeType = null;
        private string _codeFomat = null;
        private List<string> _inputlistFormatTrain = null;
        private bool _isShowImageResult = false;
        private string _pathSaveFileTrain = null;

        private string _errMessage = null;
        private bool _passed = false;
        private List<string> _outputStringCode = new List<string>();
        private List<DataCodeTrain> _dataTrain = null;
        private List<string> _outputListFomatTrain = new List<string>();
        private VectorOfVectorOfPoint _outputRegion = new VectorOfVectorOfPoint();
        private Bitmap _outputImageShow = null;
        private List<Point> _listPointString = new List<Point>();

        //Setting
        private int _lineWidth = 1;
        private double _fontSize = 1;
        private string _setDraw = "margin";
        private MCvScalar _color = new MCvScalar(0, 255, 0);
        public class DataCodeTrain
        {
            public string Format;
            public string FormatAspose;
            public int LengthCode;
        }
        

        public bool Train()
        {
            //Kiểm tra thuộc tính đầu vào
            if (_inputImage == null || _inputImage.Width == 0)
            {
                _errMessage = "Train: Lỗi InputImage = null";
                return false;
            }
            if (_codeType == null)
            {
                _errMessage = "Train: Lỗi chưa set CodeType";
                return false;
            }

            //Khởi tạo các giá trị output ban đầu
            //_listFormatTrain = new List<string> { "AZTEC", "CODABAR", "CODE_39", "CODE_93", "CODE_128", "EAN_8" , "EAN_13", "ITF", "UPC_A", "UPC_E" , "All_1D" };
            _outputStringCode.Clear();
            _dataTrain = new List<DataCodeTrain>();
            _passed = false;
            _outputImageShow = null;
            _outputListFomatTrain.Clear();
            _listPointString.Clear();
            _outputRegion.Clear();
            try
            {
                Image<Gray, byte> img = new Image<Gray, byte>(10, 10);
                PointF[] points = new PointF[4];
                //var imgThes = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var Matrix = new Mat();
                var M = new Mat();
                Point POriROI = new Point();
                double PAngleROI = 0;
                if(_codeType == "1D")
                {
                    //if (_inSetOrigin.Length > 0)
                    {
                        //if (_inSetOrigin != null) //Nếu có truyền vào ROI
                        {
                            //Chuyển tọa độ 4 đỉnh rectangle trong hệ tọa độ ToolOrigin về hệ tọa độ ảnh
                            //for (int i = 0; i < 4; i++)
                            //{
                            //    points[i] = ConvertCoordinatesToOrigin(_toolOrigin, _inSetOrigin[i]);
                            //}

                            ////Đoạn này sẽ crop ảnh trong ROI 
                            //var rotateRecROI = CvInvoke.MinAreaRect(points);
                            int width = (int)Math.Round(_ROITrain.Width);
                            int height = (int)Math.Round(_ROITrain.Height);

                            //
                            GetRectangleVertices(_ROITrain, out points);
                            var intBox = Array.ConvertAll(points, Point.Round);

                            var srcPoints = Array.ConvertAll(intBox, p => new PointF(p.X, p.Y));
                            var dstPoints = new PointF[] {
                                 new PointF(width-1, 0),
                                new PointF(0, 0),
                                new PointF(0, height-1),
                                new PointF(width-1, height-1)};
                            M = CvInvoke.GetPerspectiveTransform(srcPoints, dstPoints);
                            var warped = new Mat();
                            CvInvoke.WarpPerspective(_inputImage, warped, M, new Size(width, height), Inter.Cubic);
                            img = warped.ToImage<Gray, byte>();

                            POriROI = new Point((int)points[1].X, (int)points[1].Y);
                            PAngleROI = Math.Atan((points[0].Y - points[1].Y) / (points[0].X - points[1].X)) * 180 / Math.PI;
                        }
                    }
                    List<ZXing.BarcodeFormat> listFormat = new List<ZXing.BarcodeFormat>();
                    for (int i = 0; i < _inputlistFormatTrain.Count; i++)
                    {
                        Enum.TryParse(_inputlistFormatTrain[i], true, out ZXing.BarcodeFormat r);
                        listFormat.Add(r);
                    }
                    // ZXing
                    Mat lPoint = new Mat();

                    ZXing.BarcodeReader reader = new ZXing.BarcodeReader()
                    {
                        AutoRotate = true,
                        Options = new ZXing.Common.DecodingOptions
                        {
                            TryHarder = true,
                            PureBarcode = false,
                            TryInverted = true,
                            ReturnCodabarStartEnd = true,
                            PossibleFormats = listFormat,
                            AllowedLengths = Enumerable.Range(1,200).ToArray(),
                        }
                    };

                    ////ImageScanner scanner = new ImageScanner();
                    ////scanner.SetConfiguration(SymbolType.CODE128,Config.Enable,1);
                    ////var re = scanner.Scan(img.ToBitmap());
                    //string pathSR_Pro = "detect.prototxt";
                    //string pathModel = "detect.caffemodel";
                    //BarcodeDetector barcode = new BarcodeDetector(pathSR_Pro, pathModel);
                    //VectorOfPoint corners = new VectorOfPoint();
                    //Stopwatch stopwatch = new Stopwatch();
                    //stopwatch.Start();
                    //barcode.Detect(img, corners);
                    //stopwatch.Stop();

                    VectorOfVectorOfPoint contour = new VectorOfVectorOfPoint();
                    BarCodeReader detect = new BarCodeReader(img.ToBitmap());
                    List<SingleDecodeType> a = new List<SingleDecodeType>
                    {
                        DecodeType.Codabar,
                        DecodeType.Code39,
                        DecodeType.Code93,
                        DecodeType.Code128,
                        DecodeType.EAN8,
                        DecodeType.EAN13,
                        DecodeType.ITF14,
                        DecodeType.UPCA,
                        DecodeType.UPCE,
                        DecodeType.MSI,
                        DecodeType.Pharmacode
                    };
                    //detect.SetBarCodeReadType(a.ToArray());
                    detect.QualitySettings.InverseImage = InverseImageMode.Auto;
                    var result1 = detect.ReadBarCodes();



                    RotatedRect rec = new RotatedRect();
                    Image<Gray, byte> imgRotate = new Image<Gray, byte>(10, 10);
                    Mat M_inv = new Mat();
                    CvInvoke.Invert(M, M_inv, DecompMethod.LU);
                    if (result1.Length > 0)
                    {

                        // Duyệt qua từng PointF và chuyển nó thành Point (kiểu nguyên)
                        for (int i = 0; i < result1.Length; i++)
                        {
                            VectorOfPoint vectorOfPoint = new VectorOfPoint();
                            VectorOfPoint PContour = new VectorOfPoint();
                            List<PointF> vecPF = new List<PointF>();
                            for (int j = 0; j < 4; j++)
                            {
                                Point point = result1[i].Region.Points[j];
                                vectorOfPoint.Push(new[] { point });
                                vecPF.Add(point);
                            }
                            rec = CvInvoke.MinAreaRect(vectorOfPoint);

                            if(rec.Size.Width > rec.Size.Height)
                                rec.Size.Width = (int)(rec.Size.Width * 1.2);
                            else
                                rec.Size.Height = (int)(rec.Size.Height * 1.2);
                            imgRotate = CropRotatedRect(img, rec);


                            var result = reader.Decode(imgRotate.ToBitmap());

                            Image<Gray, byte> meanImg = new Image<Gray, byte>(img.Width, img.Height);
                            if (result != null)
                            {
                                _outputStringCode.Add(result.Text);
                                Point pc = new Point((int)rec.Center.X, (int)rec.Center.Y);
                                vecPF.Add(pc);
                                var pF = CvInvoke.PerspectiveTransform(vecPF.ToArray(), M_inv);
                                Point[] pointArray = Array.ConvertAll(pF, p => new Point((int)Math.Round(p.X), (int)Math.Round(p.Y)));
                                Point[] pointContour = pointArray.Take(4).ToArray();
                                PContour = new VectorOfPoint(pointContour);
                                _listPointString.Add(pointArray[4]);
                                DataCodeTrain dataCodeTrain = new DataCodeTrain();
                                dataCodeTrain.Format = result.BarcodeFormat.ToString();
                                dataCodeTrain.FormatAspose = result1[i].CodeTypeName;
                                _outputListFomatTrain.Add(result.BarcodeFormat.ToString());

                                dataCodeTrain.LengthCode = result.Text.ToString().Length;
                                
                                contour.Push(new[] { PContour });
                                _dataTrain.Add(dataCodeTrain);

                            }
                            else
                            {
                                List<int> k = new List<int> { -1, 1, -2, 2, -3, 3, -4, 4, -5, 5, -6, 6, -7, 7, -8, 8, -9, 9, -10, 10, -11, 11, -12, 12, -13, 13, -14, 14, -15, 15, -16, 16, -17, 17, -18, 18, -19, 19, -20, 20, -21, 21, -22, 22, -23, 23, -24, 24, -25, 25, -26, 26, -27, 27, -28, 28, -29, 29 };
                                //int wCode = (result1[i].Region.Rectangle.Width > result1[i].Region.Rectangle.Height) ? result1[i].Region.Rectangle.Width : result1[i].Region.Rectangle.Height;
                                
                                //int w, h;
                                //if (wCode>400)
                                //{
                                //    double scale = (double)wCode / 400;
                                //    w = (int)(imgRotate.Width/scale);
                                //    h = (int)(imgRotate.Height/scale);
                                //    //CvInvoke.Resize(imgRotate,mean, new Size(w, h));
                                //}   
                                //else
                                //{
                                //    w = (int)(imgRotate.Width);
                                //    h = (int)(imgRotate.Height);
                                //}
                                //Image<Gray, byte> mean = new Image<Gray, byte>(w,h);
                                //CvInvoke.Resize(imgRotate, mean, new Size(w, h));
                                //img = mean.Clone();
                                for (int j = 1; j <= 40; j++)
                                {
                                    //Image<Gray, byte> mean = new Image<Gray, byte>(img.Width, img.Height);
                                    meanImg = imgRotate - 10 * k[j];
                                    //CvInvoke.MedianBlur(mean, meanImg, 5);
                                    //CvInvoke.CLAHE(mean, 40, new Size(8, 8), meanImg);
                                    //img = mean.Clone();
                                    result = reader.Decode(meanImg.ToBitmap());
                                    if (result != null)
                                    {
                                        _outputStringCode.Add(result.Text);
                                        Point pc = new Point((int)rec.Center.X, (int)rec.Center.Y);
                                        vecPF.Add(pc);
                                        var pF = CvInvoke.PerspectiveTransform(vecPF.ToArray(), M_inv);
                                        Point[] pointArray = Array.ConvertAll(pF, p => new Point((int)Math.Round(p.X), (int)Math.Round(p.Y)));
                                        Point[] pointContour = pointArray.Take(4).ToArray();
                                        PContour = new VectorOfPoint(pointContour);
                                        _listPointString.Add(pointArray[4]);
                                        DataCodeTrain dataCodeTrain = new DataCodeTrain();
                                        dataCodeTrain.Format = result.BarcodeFormat.ToString();
                                        dataCodeTrain.FormatAspose = result1[i].CodeTypeName;
                                        _outputListFomatTrain.Add(result.BarcodeFormat.ToString());
                                        dataCodeTrain.LengthCode = result.Text.ToString().Length;
                                        contour.Push(new[] { PContour });
                                        _dataTrain.Add(dataCodeTrain);
                                        break;
                                    }
                                    meanImg.Dispose();
                                }

                            }
                            imgRotate.Dispose();
                        }
                    }
                    _outputRegion = contour;
                    if (_dataTrain.Count > 0)
                    {
                        File.WriteAllText(_pathSaveFileTrain, JsonConvert.SerializeObject(DataTrain, Newtonsoft.Json.Formatting.Indented));
                    }
                    if (_isShowImageResult)
                    {
                        var imgShow = _inputImage.Convert<Bgr, byte>();
                        if (_lineWidth < 1)
                        _lineWidth = 1;
                        if (_setDraw == "margin")
                            CvInvoke.DrawContours(imgShow, contour, -1, _color, _lineWidth);
                        else if (_setDraw == "fill")
                            CvInvoke.DrawContours(imgShow, contour, -1, _color, -1);
                        for (int i = 0; i < _listPointString.Count; i++)
                        {
                            CvInvoke.PutText(imgShow, _outputStringCode[i], _listPointString[i], FontFace.HersheySimplex, _fontSize, new MCvScalar(0, 255, 0),_lineWidth);
                        }
                        //CvInvoke.Circle(imgShow, new Point((int)(rec.Center.X), (int)(rec.Center.Y)), 1, new MCvScalar(0, 0, 255),5);
                        _outputImageShow = imgShow.ToBitmap();
                        imgShow.Dispose();
                    }
                    img.Dispose();
                }    
                else if (_codeType == "2D")
                {
                    int width = (int)Math.Round(_ROITrain.Width);
                    int height = (int)Math.Round(_ROITrain.Height);

                    //
                    GetRectangleVertices(_ROITrain, out points);
                    var intBox = Array.ConvertAll(points, Point.Round);

                    var srcPoints = Array.ConvertAll(intBox, p => new PointF(p.X, p.Y));
                    var dstPoints = new PointF[] {
                                 new PointF(width-1, 0),
                                new PointF(0, 0),
                                new PointF(0, height-1),
                                new PointF(width-1, height-1)};
                    M = CvInvoke.GetPerspectiveTransform(srcPoints, dstPoints);
                    var warped = new Mat();
                    CvInvoke.WarpPerspective(_inputImage, warped, M, new Size(width, height), Inter.Cubic);
                    img = warped.ToImage<Gray, byte>();
                    POriROI = new Point((int)points[1].X, (int)points[1].Y);
                    PAngleROI = Math.Atan((points[0].Y - points[1].Y) / (points[0].X - points[1].X)) * 180 / Math.PI;

                    List<ZXing.BarcodeFormat> listFormat = new List<ZXing.BarcodeFormat>();
                    for (int i = 0; i < _inputlistFormatTrain.Count; i++)
                    {
                        Enum.TryParse(_inputlistFormatTrain[i], true, out ZXing.BarcodeFormat r);
                        listFormat.Add(r);
                    }

                    DecodingOptions readOptions = new DecodingOptions()
                    {
                        PossibleFormats = listFormat,
                        TryHarder = true,
                        TryInverted = true,
                        PureBarcode = false
                    };
                    VectorOfVectorOfPoint contour = new VectorOfVectorOfPoint();
                    ZXing.BarcodeReader reader = new ZXing.BarcodeReader()
                    {
                        AutoRotate = true,
                        Options = readOptions
                    };

                    //Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(15, 15), new Point(-1, -1));
                    //Image<Gray, byte> imgErr = img.Clone();
                    //img = imgErr.MorphologyEx(MorphOp.Erode, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());


                    BarCodeReader detect = new BarCodeReader(img.ToBitmap());
                    List<SingleDecodeType> a = new List<SingleDecodeType>
                    {
                        DecodeType.Aztec,
                        DecodeType.DataMatrix,
                        DecodeType.MaxiCode,
                        DecodeType.QR,
                        DecodeType.Pdf417,
                    };
                    
                    detect.SetBarCodeReadType(a.ToArray());
                    var result1 = detect.ReadBarCodes();

                    
                    RotatedRect rec = new RotatedRect();
                    Mat M_inv = new Mat();
                    CvInvoke.Invert(M, M_inv, DecompMethod.LU);
                    if (result1.Length > 0)
                    {
                        
                        for(int i = 0; i < result1.Length; i++) 
                        {
                            VectorOfPoint vectorOfPoint = new VectorOfPoint();
                            VectorOfPoint PContour = new VectorOfPoint();
                            List<PointF> vecPF = new List<PointF>();
                            for (int j = 0; j < 4; j++)
                            {
                                Point point = result1[i].Region.Points[j];
                                vectorOfPoint.Push(new[] { point });
                                vecPF.Add(point);
                            }

                            rec = CvInvoke.MinAreaRect(vectorOfPoint);
                            rec.Size.Width = (int)(rec.Size.Height * 1.2);
                            rec.Size.Height = (int)(rec.Size.Width * 1.2);


                            var imgRotate = CropRotatedRect(img, rec);
                            Image<Gray, byte> meanImg = new Image<Gray, byte>(img.Width, img.Height);
                            var result = reader.Decode(imgRotate.ToBitmap());



                            if (result != null)
                            {
                                _outputStringCode.Add(result.Text);
                                Point pc = new Point((int)rec.Center.X, (int)rec.Center.Y);
                                vecPF.Add(pc);
                                var pF = CvInvoke.PerspectiveTransform(vecPF.ToArray(), M_inv);
                                Point[] pointArray = Array.ConvertAll(pF, p => new Point((int)Math.Round(p.X), (int)Math.Round(p.Y)));
                                Point[] pointContour = pointArray.Take(4).ToArray();
                                PContour = new VectorOfPoint(pointContour);
                                _listPointString.Add(pointArray[4]);
                                DataCodeTrain dataCodeTrain = new DataCodeTrain();
                                dataCodeTrain.Format = result.BarcodeFormat.ToString();
                                dataCodeTrain.FormatAspose = result1[i].CodeTypeName;
                                _outputListFomatTrain.Add(result.BarcodeFormat.ToString());

                                dataCodeTrain.LengthCode = result.Text.ToString().Length;

                                contour.Push(new[] { PContour });
                                _dataTrain.Add(dataCodeTrain);

                            }
                            else
                            {
                                List<int> k = new List<int> { -1, 1, -2, 2, -3, 3, -4, 4, -5, 5, -6, 6, -7, 7, -8, 8, -9, 9, -10, 10, -11, 11, -12, 12, -13, 13, -14, 14, -15, 15, -16, 16, -17, 17, -18, 18, -19, 19, -20, 20, -21, 21, -22, 22, -23, 23, -24, 24, -25, 25, -26, 26, -27, 27, -28, 28, -29, 29 };

                                for (int j = 1; j <= 20; j++)
                                {
                                    meanImg = imgRotate - 10 * j;

                                    result = reader.Decode(meanImg.ToBitmap());
                                    if (result != null)
                                    {
                                        _outputStringCode.Add(result.Text);
                                        Point pc = new Point((int)rec.Center.X, (int)rec.Center.Y);
                                        vecPF.Add(pc);
                                        var pF = CvInvoke.PerspectiveTransform(vecPF.ToArray(), M_inv);
                                        Point[] pointArray = Array.ConvertAll(pF, p => new Point((int)Math.Round(p.X), (int)Math.Round(p.Y)));
                                        Point[] pointContour = pointArray.Take(4).ToArray();
                                        PContour = new VectorOfPoint(pointContour);
                                        _listPointString.Add(pointArray[4]);
                                        DataCodeTrain dataCodeTrain = new DataCodeTrain();
                                        dataCodeTrain.Format = result.BarcodeFormat.ToString();
                                        dataCodeTrain.FormatAspose = result1[i].CodeTypeName;
                                        _outputListFomatTrain.Add(result.BarcodeFormat.ToString());

                                        dataCodeTrain.LengthCode = result.Text.ToString().Length;

                                        contour.Push(new[] { PContour });
                                        _dataTrain.Add(dataCodeTrain);
                                        break;
                                    }
                                    meanImg.Dispose();
                                }
                            }    
                            imgRotate.Dispose();
                        }
                    }
                    _outputRegion = contour;
                    if (_dataTrain.Count > 0)
                    {
                        File.WriteAllText(_pathSaveFileTrain, JsonConvert.SerializeObject(DataTrain, Newtonsoft.Json.Formatting.Indented));
                    }

                    if (_isShowImageResult)
                    {
                        var imgShow = _inputImage.Convert<Bgr, byte>();
                        if (_lineWidth < 1)
                            _lineWidth = 1 ;
                        if(_setDraw == "margin")
                            CvInvoke.DrawContours(imgShow, contour, -1, _color, _lineWidth);
                        else if(_setDraw == "fill")
                            CvInvoke.DrawContours(imgShow, contour, -1, _color, -1);
                        for (int i = 0; i < _listPointString.Count; i++)
                        {
                            CvInvoke.PutText(imgShow, _outputStringCode[i], _listPointString[i], FontFace.HersheyDuplex, _fontSize, new MCvScalar(0, 255, 0),_lineWidth);
                        }
                        //CvInvoke.Circle(imgShow, new Point((int)(rec.Center.X), (int)(rec.Center.Y)), 1, new MCvScalar(0, 0, 255),5);
                        _outputImageShow = imgShow.ToBitmap();
                        imgShow.Dispose();
                    }
                    img.Dispose();
                }    
                
            }
            catch (Exception ex)
            {
                _errMessage = "Train: " + ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            return true;
        }

        public bool LoadFile()
        {
            try
            {
                _dataTrain = JsonConvert.DeserializeObject<List<DataCodeTrain>>(File.ReadAllText(_pathSaveFileTrain));
            }
            catch(Exception ex)
            {
                _errMessage = "Train: " + ex.Message + "\n" + ex.StackTrace;
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
            if(_codeType == null)
            {
                _errMessage = "Run: Lỗi chưa set CodeType";
                return false;
            }
            if (_dataTrain == null || _dataTrain.Count ==0)
            {
                _errMessage = "Run: Lỗi chưa Train";
                return false;
            }
            //Khởi tạo các giá trị output ban đầu

            _outputStringCode.Clear();
            _passed = false;
            _outputImageShow = null;
            _listPointString.Clear();
            //BarcodeDetector reader = new BarcodeDetector(this);
            try
            {
                Image<Gray, byte> img = new Image<Gray, byte>(10, 10);
                PointF[] points = new PointF[4];
                //var imgThes = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                var Matrix = new Mat();
                var M = new Mat();
                Point POriROI = new Point();
                double PAngleROI = 0;
                if (_inSetOrigin.Length > 0)
                {
                    if (_inSetOrigin != null) //Nếu có truyền vào ROI
                    {
                        //Chuyển tọa độ 4 đỉnh rectangle trong hệ tọa độ ToolOrigin về hệ tọa độ ảnh
                        for (int i = 0; i < 4; i++)
                        {
                            points[i] = ConvertCoordinatesToOrigin(_toolOrigin, _inSetOrigin[i]);
                        }

                        //Đoạn này sẽ crop ảnh trong ROI 
                        var rotateRecROI = CvInvoke.MinAreaRect(points);
                        int width = (int)Math.Round(_ROISearch.Width);
                        int height = (int)Math.Round(_ROISearch.Height);
                        var intBox = Array.ConvertAll(points, Point.Round);

                        var srcPoints = Array.ConvertAll(intBox, p => new PointF(p.X, p.Y));
                        var dstPoints = new PointF[] {
                         new PointF(width-1, 0),
                        new PointF(0, 0),
                        new PointF(0, height-1),
                        new PointF(width-1, height-1)};
                        M = CvInvoke.GetPerspectiveTransform(srcPoints, dstPoints);
                        
                        var warped = new Mat();
                        CvInvoke.WarpPerspective(_inputImage, warped, M, new Size(width, height),Inter.Cubic);
                        img = warped.ToImage<Gray, byte>();
                        POriROI = new Point((int)points[1].X, (int)points[1].Y);
                        PAngleROI = Math.Atan((points[0].Y - points[1].Y) / (points[0].X - points[1].X)) * 180 / Math.PI;
                    }
                }
                List<ZXing.BarcodeFormat> formats = new List<ZXing.BarcodeFormat>();
                foreach (var data in _dataTrain)
                {
                    Enum.TryParse(data.Format, true, out ZXing.BarcodeFormat r);
                    formats.Add(r);
                }
                List<SingleDecodeType> formatAspose = new List<SingleDecodeType>();
                List<int> LengthCode = new List<int>();
                foreach (var data in _dataTrain)
                {
                    SingleDecodeType r = SingleDecodeType.Parse(data.FormatAspose);
                    formatAspose.Add(r);
                    LengthCode.Add(data.LengthCode);
                }
                VectorOfVectorOfPoint contour = new VectorOfVectorOfPoint();
                if (_codeType == "1D")
                {
                    //ZXing
                    Mat lPoint = new Mat();
                    ZXing.BarcodeReader reader = new ZXing.BarcodeReader()
                    {
                        AutoRotate = true,
                        
                        Options = new DecodingOptions
                        {
                            TryHarder = true,
                            TryInverted = true,
                            PureBarcode = false,
                            PossibleFormats = formats,
                            AllowedLengths = LengthCode.ToArray(),
                        }
                    };

                    //string pathSR_Pro = "detect.prototxt";
                    //string pathModel = "detect.caffemodel";
                    //BarcodeDetector barcode = new BarcodeDetector(pathSR_Pro, pathModel);
                    //VectorOfPoint corners = new VectorOfPoint();
                    //Stopwatch stopwatch = new Stopwatch();
                    //stopwatch.Start();
                    //barcode.Detect(img, corners);
                    //stopwatch.Stop();
                    BarCodeReader detect = new BarCodeReader(img.ToBitmap());
                    detect.SetBarCodeReadType(formatAspose.ToArray());
                    

                    var result1 = detect.ReadBarCodes();
                    RotatedRect rec = new RotatedRect();
                    Image<Gray, byte> imgRotate = new Image<Gray, byte>(10, 10);
                    Mat M_inv = new Mat();
                    CvInvoke.Invert(M, M_inv, DecompMethod.LU);
                    if (result1.Length > 0)
                    {
                        // Duyệt qua từng PointF và chuyển nó thành Point (kiểu nguyên)
                        for (int i = 0; i < result1.Length; i++)
                        {
                            VectorOfPoint vectorOfPoint = new VectorOfPoint();
                            VectorOfPoint PContour = new VectorOfPoint();
                            List<PointF> vecPF = new List<PointF>();
                            for (int j = 0; j < 4; j++)
                            {
                                Point point = result1[i].Region.Points[j];
                                vectorOfPoint.Push(new[] { point });
                                vecPF.Add(point);
                            }
                            
                            rec = CvInvoke.MinAreaRect(vectorOfPoint);
                            rec.Size.Width = (int)(rec.Size.Width * 1.1);
                            rec.Size.Height = (int)(rec.Size.Height * 1.1);
                            

                            //if(rec.Size.Width > rec.Size.Height) 
                            //{
                            //    if (rec.Size.Width < _dataTrain[0].LengthCode * 0.9)
                            //    {
                            //        break;
                            //    }
                            //}
                            //else
                            //{
                            //    if (rec.Size.Height < _dataTrain[0].LengthCode * 0.9)
                            //    { break; }
                            //}    


                            imgRotate = CropRotatedRect(img, rec);

                            var result = reader.Decode(imgRotate.ToBitmap());
                            Image<Gray, byte> meanImg = new Image<Gray, byte>(img.Width, img.Height);
                            if (result != null)
                            {
                                _outputStringCode.Add(result.Text);
                                Point pc = new Point((int)rec.Center.X, (int)rec.Center.Y);
                                vecPF.Add(pc);
                                var pF = CvInvoke.PerspectiveTransform(vecPF.ToArray(), M_inv);
                                Point[] pointArray = Array.ConvertAll(pF, p => new Point((int)Math.Round(p.X), (int)Math.Round(p.Y)));
                                Point[] pointContour = pointArray.Take(4).ToArray();
                                PContour = new VectorOfPoint(pointContour);
                                _listPointString.Add(pointArray[4]);
                                contour.Push(new[] { PContour });
                            }
                            else
                            {
                                //string[] datas = new string[1];
                                //if(formats.Contains(ZXing.BarcodeFormat.CODE_128)
                                //    ||formats.Contains(ZXing.BarcodeFormat.EAN_13) 
                                //    || formats.Contains(ZXing.BarcodeFormat.EAN_8) 
                                //    || formats.Contains(ZXing.BarcodeFormat.CODE_39)
                                //    || formats.Contains(ZXing.BarcodeFormat.CODABAR)
                                //    || formats.Contains(ZXing.BarcodeFormat.CODE_93))
                                //{
                                    
                                //    if (formats[0]== ZXing.BarcodeFormat.CODE_128)
                                //        datas = BarcodeScanner.Scan(imgRotate.ToBitmap(),BarCodeType.Code128);
                                //    else if(formats[0] == ZXing.BarcodeFormat.EAN_13)
                                //        datas = BarcodeScanner.Scan(imgRotate.ToBitmap(), BarCodeType.EAN13);
                                //    else if (formats[0] == ZXing.BarcodeFormat.EAN_8)
                                //        datas = BarcodeScanner.Scan(imgRotate.ToBitmap(), BarCodeType.EAN8);
                                //    else if (formats[0] == ZXing.BarcodeFormat.CODE_39)
                                //        datas = BarcodeScanner.Scan(imgRotate.ToBitmap(), BarCodeType.Code39);
                                //    else if (formats[0] == ZXing.BarcodeFormat.CODABAR)
                                //        datas = BarcodeScanner.Scan(imgRotate.ToBitmap(), BarCodeType.Codabar);
                                //    else if (formats[0] == ZXing.BarcodeFormat.CODE_93)
                                //        datas = BarcodeScanner.Scan(imgRotate.ToBitmap(), BarCodeType.Code93);

                                //}
                                //if (datas.Length > 0 && datas[0] != null )
                                //{
                                //    _outputStringCode.Add(datas[0]);
                                //    Point pc = new Point((int)rec.Center.X, (int)rec.Center.Y);
                                //    vecPF.Add(pc);
                                //    var pF = CvInvoke.PerspectiveTransform(vecPF.ToArray(), M_inv);
                                //    Point[] pointArray = Array.ConvertAll(pF, p => new Point((int)Math.Round(p.X), (int)Math.Round(p.Y)));
                                //    Point[] pointContour = pointArray.Take(4).ToArray();
                                //    PContour = new VectorOfPoint(pointContour);
                                //    _listPointString.Add(pointArray[4]);
                                //    contour.Push(new[] { PContour });
                                //}
                                //else
                                //{
                                //    List<int> k = new List<int> { -1, 1, -2, 2, -3, 3, -4, 4, -5, 5, -6, 6, -7, 7, -8, 8, -9, 9, -10, 10, -11, 11, -12, 12, -13, 13, -14, 14, -15, 15, -16, 16, -17, 17, -18, 18, -19, 19, -20, 20, -21, 21, -22, 22, -23, 23, -24, 24, -25, 25, -26, 26, -27, 27, -28, 28, -29, 29 };

                                //    for (int j = 1; j <= 20; j++)
                                //    {
                                //        meanImg = imgRotate - 10 * j;
                                //        result = reader.Decode(meanImg.ToBitmap());
                                //        if (result != null)
                                //        {
                                //            _outputStringCode.Add(result.Text);
                                //            Point pc = new Point((int)rec.Center.X, (int)rec.Center.Y);
                                //            vecPF.Add(pc);
                                //            var pF = CvInvoke.PerspectiveTransform(vecPF.ToArray(), M_inv);
                                //            Point[] pointArray = Array.ConvertAll(pF, p => new Point((int)Math.Round(p.X), (int)Math.Round(p.Y)));
                                //            Point[] pointContour = pointArray.Take(4).ToArray();
                                //            PContour = new VectorOfPoint(pointContour);
                                //            _listPointString.Add(pointArray[4]);
                                //            contour.Push(new[] { PContour });
                                //        }

                                //    }
                                //    //Cải thiện
                                //    //Mat kernel = new Mat(3, 3, DepthType.Cv32F, 1);
                                //    //kernel.SetTo(new float[] {
                                //    //                    -1, -1, -1,
                                //    //                    -1,  9, -1,
                                //    //                    -1, -1, -1
                                //    //                });
                                //    //Image<Gray, byte> sharpened = new Image<Gray, byte>(imgRotate.Width, imgRotate.Height);
                                //    //CvInvoke.Filter2D(imgRotate, sharpened, kernel, new Point(-1, -1));
                                //    //Image<Gray, byte> imgBur = new Image<Gray, byte>(imgRotate.Width, imgRotate.Height);
                                //    //CvInvoke.GaussianBlur(sharpened, imgBur, new Size(3, 3), 1.5);
                                //    //result = reader.Decode(imgBur.ToBitmap());

                                //    //img = imgBur.Clone();
                                //    meanImg.Dispose();

                                //}
                            }
                            
                            
                        }
                    }
                    imgRotate.Dispose();
                }
                else if (_codeType == "2D")
                {
                   
                    DecodingOptions readOptions = new DecodingOptions()
                    {
                        PossibleFormats = formats,
                        TryHarder = true,
                        TryInverted = true,
                        PureBarcode = false,
                    };
                    ZXing.BarcodeReader reader = new ZXing.BarcodeReader()
                    {
                        AutoRotate = true,
                        Options = readOptions
                    };
                    Stopwatch t = new Stopwatch();
                    t.Start();
                    BarCodeReader detect = new BarCodeReader(img.ToBitmap());
                    detect.SetBarCodeReadType(formatAspose.ToArray());
                    var result1 = detect.ReadBarCodes();
                    t.Stop();


                    RotatedRect rec = new RotatedRect();

                    Mat M_inv = new Mat();
                    CvInvoke.Invert(M, M_inv, DecompMethod.LU);
                    if (result1.Length > 0)
                    {

                        for (int i = 0; i < result1.Length; i++)
                        {
                            VectorOfPoint vectorOfPoint = new VectorOfPoint();
                            VectorOfPoint PContour = new VectorOfPoint();
                            List<PointF> vecPF = new List<PointF>();
                            for (int j = 0; j < 4; j++)
                            {
                                Point point = result1[i].Region.Points[j];
                                vectorOfPoint.Push(new[] { point });
                                vecPF.Add(point);
                            }

                            rec = CvInvoke.MinAreaRect(vectorOfPoint);
                            rec.Size.Width = (int)(rec.Size.Height * 1.15);
                            rec.Size.Height = (int)(rec.Size.Width * 1.15);

                            var imgRotate = CropRotatedRect(img, rec);
                            Image<Gray, byte> meanImg = new Image<Gray, byte>(img.Width, img.Height);
                            Stopwatch t1 = new Stopwatch();
                            t1.Start();
                            var result = reader.Decode(imgRotate.ToBitmap());
                            t1.Stop();
                            if (result != null)
                            {
                                _outputStringCode.Add(result.Text);
                                Point pc = new Point((int)rec.Center.X, (int)rec.Center.Y);
                                vecPF.Add(pc);
                                var pF = CvInvoke.PerspectiveTransform(vecPF.ToArray(), M_inv);
                                Point[] pointArray = Array.ConvertAll(pF, p => new Point((int)Math.Round(p.X), (int)Math.Round(p.Y)));
                                Point[] pointContour = pointArray.Take(4).ToArray();
                                PContour = new VectorOfPoint(pointContour);
                                _listPointString.Add(pointArray[4]);
                                contour.Push(new[] { PContour });
                            }
                            else
                            {

                                List<int> k = new List<int> { -1, 1, -2, 2, -3, 3, -4, 4, -5, 5, -6, 6, -7, 7, -8, 8, -9, 9, -10, 10, -11, 11, -12, 12, -13, 13, -14, 14, -15, 15, -16, 16, -17, 17, -18, 18, -19, 19, -20, 20, -21, 21, -22, 22, -23, 23, -24, 24, -25, 25, -26, 26, -27, 27, -28, 28, -29, 29 };

                                for (int j = 1; j <= 40; j++)
                                {
                                    meanImg = imgRotate - 10 * k[j];

                                    result = reader.Decode(meanImg.ToBitmap());
                                    if (result != null)
                                    {
                                        _outputStringCode.Add(result.Text);
                                        Point pc = new Point((int)rec.Center.X, (int)rec.Center.Y);
                                        vecPF.Add(pc);
                                        var pF = CvInvoke.PerspectiveTransform(vecPF.ToArray(), M_inv);
                                        Point[] pointArray = Array.ConvertAll(pF, p => new Point((int)Math.Round(p.X), (int)Math.Round(p.Y)));
                                        Point[] pointContour = pointArray.Take(4).ToArray();
                                        PContour = new VectorOfPoint(pointContour);
                                        _listPointString.Add(pointArray[4]);
                                        contour.Push(new[] { PContour });

                                        break;
                                    }
                                }
                                meanImg.Dispose();
                            }
                            imgRotate.Dispose();

                        }
                    }
                }
                _outputRegion = contour;
                img.Dispose();
                if (_isShowImageResult)
                {
                    var imgShow = _inputImage.Convert<Bgr, byte>();
                    if (_lineWidth < 1)
                        _lineWidth = 1;
                    if (_setDraw == "margin")
                        CvInvoke.DrawContours(imgShow, contour, -1, _color, _lineWidth);
                    else if (_setDraw == "fill")
                        CvInvoke.DrawContours(imgShow, contour, -1, _color, -1);
                    for (int i = 0; i < _listPointString.Count; i++)
                    {
                        CvInvoke.PutText(imgShow, _outputStringCode[i], _listPointString[i], FontFace.HersheyDuplex, _fontSize, new MCvScalar(0, 255, 0), _lineWidth);
                    }
                    //CvInvoke.Circle(imgShow, new Point((int)(rec.Center.X), (int)(rec.Center.Y)), 1, new MCvScalar(0, 0, 255),5);
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
        /// ConvertCoordinatesToOrigin() Chuyển tọa độ điểm "point" từ hệ tọa độ "toolOrigin" về hệ tọa độ ảnh
        /// </summary>
        /// <param name="toolOrigin"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private PointF ConvertCoordinatesToOrigin(Tuple<PointF, double> Coordinates, PointF point)
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
        private Size GetBestRotationSize(Size sizeSrc, double dRAngle)
        {
            double angle = dRAngle / 180 * Math.PI;
            double W = sizeSrc.Width * Math.Abs(Math.Cos(angle)) + sizeSrc.Height * Math.Abs(Math.Sin(angle));
            double H = sizeSrc.Width * Math.Abs(Math.Sin(angle)) + sizeSrc.Height * Math.Abs(Math.Cos(angle));
            Size sizeRet = new Size((int)W,(int)H);
            return sizeRet;
        }
        
        private Image<Gray, Byte> CropRotatedRect(Image<Gray, Byte> srcImage, RotatedRect rotatedRect)
        {
            var pRect = rotatedRect.GetVertices();
            var pImage = new PointF[] {
                         new PointF(srcImage.Width-1, 0),
                        new PointF(srcImage.Width-1, srcImage.Height-1),
                        new PointF(0, srcImage.Height-1),
                        new PointF(0, 0)};
            VectorOfPointF poly1 = new VectorOfPointF(pRect);
            VectorOfPointF poly2 = new VectorOfPointF(pImage);
            VectorOfPointF intersection = new VectorOfPointF();
            CvInvoke.IntersectConvexConvex(poly1, poly2, intersection, true);
            rotatedRect = CvInvoke.MinAreaRect(intersection);
            pRect = rotatedRect.GetVertices();
            var width = rotatedRect.Size.Width;
            var height = rotatedRect.Size.Height;
            Size rectSize = new Size((int)width, (int)height);
            Image<Gray, Byte> croppedImage = new Image<Gray, byte>(rectSize);
            var dstPoints = new PointF[] {
                         new PointF(width-1, 0),
                        new PointF(width-1, height-1),
                        new PointF(0, height-1),
                        new PointF(0, 0)};
            Mat Matrix = CvInvoke.GetPerspectiveTransform(pRect, dstPoints);
            CvInvoke.WarpPerspective(srcImage, croppedImage, Matrix, rectSize, Inter.Cubic);
            return croppedImage;
        }
        private Point ConvertCoordinatesToOrigin( Point POrigin, double Angle, Point point)
        {
            Point p = new Point();
            Angle = Angle * Math.PI / 180;
            //
            var A = new Matrix<double>(new double[,] {
                { Math.Cos(Angle),-Math.Sin(Angle),POrigin.X },
                { Math.Sin(Angle),Math.Cos(Angle),POrigin.Y },
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
