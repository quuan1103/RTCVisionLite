using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using RTCBase.Drawing;
using RTCConst;

namespace ImageSplit
{
    public class ImageSplit
    {
        /// <summary>
        /// INPUT
        /// </summary>
        public Image<Gray, byte> InputImageGray
        {
            set { _inputImageGray = value; }
        }
        public Image<Bgr, byte> InputImageColor
        {
            set { _inputImageColor = value; }
        }
        public bool IsImageColor
        {
            set { _isImageColor = value; }
        }
        public List<VectorOfVectorOfPoint> InputRegion
        {
            set { _inputRegion = value; }
        }
        public List<RTCRectangle> ROI
        {
            set { _ROI = value; }
        }
        public Tuple<PointF, double> ToolOrigin
        {
            set { _toolOrigin = value; }
        }
        public List<PointF[]> InSetOrigin
        {
            set { _inSetOrigin = value; }
        }
        public string SplitType
        {
            set { _splitType = value; }
        }
        public string SplitROIType
        {
            set { _splitROIType = value; }
        }
        public bool IsAdaptImageSize
        {
            set { _isAdaptImageSize = value; }
        }
        public int RowNumber
        {
            set { _rowNumber = value; }
        }
        public int ColumnNumber
        {
            set { _colNumber = value; }
        }
        public bool IsShowImageResult
        {
            set { _isShowImageResult = value; }
        }
        /// <summary>
        /// OUTPUT
        /// </summary>
        public List<Bitmap> OutputImage
        {
            get { return _outputListImage; }
        }
        public Bitmap OutputImageShow
        {
            get { return _outputImageShow; }
        }
        public string ErrMessage
        {
            get { return _errMessage; }
        }
        public bool Passed
        {
            get { return _passed; }
        }

        private Image<Gray, byte> _inputImageGray = null;
        private Image<Bgr, byte> _inputImageColor = null;
        private bool _isImageColor = false;
        private List<VectorOfVectorOfPoint> _inputRegion = null;
        private List<RTCRectangle> _ROI = null;
        private Tuple<PointF, double> _toolOrigin = null;
        private List<PointF[]> _inSetOrigin = new List<PointF[]>();
        private string _splitType = null;
        private string _splitROIType = null;
        private bool _isAdaptImageSize = false;
        private int _rowNumber = 0;
        private int _colNumber = 0;

        private bool _passed = false;
        private string _errMessage = null;
        private List<Bitmap> _outputListImage = null;
        private Bitmap _outputImageShow = null;
        private bool _isShowImageResult = false;

        public bool Run()
        {
            _passed = false;
            int imgWidth, imgHeight;
            _outputListImage = new List<Bitmap>();
            if (_isImageColor)
            {
                imgWidth = _inputImageColor.Width;
                imgHeight = _inputImageColor.Height;
            }
            else
            {
                imgWidth = _inputImageGray.Width;
                imgHeight = _inputImageGray.Height;
            }
            //Kiểm tra thuộc tính đầu vào
            if (imgWidth == 0 || imgHeight == 0)
            {
                _errMessage = "Lỗi InputImage = null";
                return false;
            }
            if (_splitType == null)
            {
                _errMessage = "Lỗi SplitType = null";
                return false;
            }
            if (_splitROIType == null)
            {
                _errMessage = "Lỗi SplitROIType = null";
                return false;
            }
            try
            {
                if (_inputRegion == null || _inputRegion.Count == 0)
                {
                    if (_inSetOrigin != null)
                    {
                        if (_splitType == cImageSplit.SplitType_ROI)
                        {
                            if (_isAdaptImageSize)
                            {
                                if (_splitROIType == cImageSplit.ROIType_OneROI)
                                {
                                    var blackImage = new Image<Gray, byte>(imgWidth, imgHeight, new Gray(0));
                                    VectorOfVectorOfPoint lcontour = new VectorOfVectorOfPoint();
                                    Rectangle boundingBox = new Rectangle();
                                    for (int i = 0; i < _inSetOrigin.Count; i++)
                                    {
                                        //Xử lí Origin
                                        PointF[] points = new PointF[4];
                                        for (int j = 0; j < 4; j++)
                                        {
                                            points[j] = ConvertCoordinatesToOrigin(_toolOrigin, _inSetOrigin[i][j]);
                                        }


                                        //Old
                                        //GetRectangleVertices(_ROI[i], out PointF[] points);
                                        Point[] pRec = points.Select(p => new Point((int)p.X, (int)p.Y)).ToArray();
                                        VectorOfPoint contour = new VectorOfPoint(pRec);
                                        lcontour.Push(contour);
                                        if (i == 0)
                                        {
                                            boundingBox = CvInvoke.BoundingRectangle(contour);
                                        }
                                        else
                                        {
                                            Rectangle rect = CvInvoke.BoundingRectangle(contour);
                                            boundingBox = Rectangle.Union(boundingBox, rect);
                                        }
                                    }
                                    CvInvoke.DrawContours(blackImage, lcontour, -1, new MCvScalar(1), -1);
                                    if (_isImageColor)
                                    {
                                        Image<Bgr, byte> img = _inputImageColor.Clone();
                                        CvInvoke.Multiply(img, blackImage, img);
                                        img = img.GetSubRect(boundingBox);
                                        _outputListImage.Add(img.ToBitmap());
                                        if (_isShowImageResult)
                                        {
                                            _outputImageShow = img.ToBitmap();
                                        }
                                    }
                                    else
                                    {
                                        Image<Gray, byte> img = _inputImageGray.Clone();
                                        CvInvoke.Multiply(img, blackImage, img);
                                        img = img.GetSubRect(boundingBox);
                                        _outputListImage.Add(img.ToBitmap());
                                        if (_isShowImageResult)
                                        {
                                            _outputImageShow = img.ToBitmap();
                                        }
                                    }
                                }
                                else
                                {
                                    
                                    Rectangle boundingBox = new Rectangle();
                                    Rectangle boundingBoxShow = new Rectangle();
                                    VectorOfVectorOfPoint lcontourshow = new VectorOfVectorOfPoint();
                                    for (int i = 0; i < _inSetOrigin.Count; i++)
                                    {
                                        VectorOfVectorOfPoint lcontour = new VectorOfVectorOfPoint();
                                        //Xử lí Origin
                                        PointF[] points = new PointF[4];
                                        for (int j = 0; j < 4; j++)
                                        {
                                            points[j] = ConvertCoordinatesToOrigin(_toolOrigin, _inSetOrigin[i][j]);
                                        }


                                        //Old
                                        //GetRectangleVertices(_ROI[i], out PointF[] points);
                                        Point[] pRec = points.Select(p => new Point((int)p.X, (int)p.Y)).ToArray();
                                        VectorOfPoint contour = new VectorOfPoint(pRec);
                                        lcontour.Push(contour);
                                        boundingBox = CvInvoke.BoundingRectangle(contour);
                                        
                                        if (_isImageColor)
                                        {
                                            var blackImage = new Image<Bgr, byte>(imgWidth, imgHeight, new Bgr(0,0,0));
                                            CvInvoke.DrawContours(blackImage, lcontour, -1, new MCvScalar(1,1,1), -1);
                                            Image<Bgr, byte> img = _inputImageColor.Clone();
                                            CvInvoke.Multiply(img, blackImage, img);
                                            img = img.GetSubRect(boundingBox);
                                            _outputListImage.Add(img.ToBitmap());
                                        }
                                        else
                                        {
                                            var blackImage = new Image<Gray, byte>(imgWidth, imgHeight, new Gray(0));
                                            CvInvoke.DrawContours(blackImage, lcontour, -1, new MCvScalar(1), -1);
                                            Image<Gray, byte> img = _inputImageGray.Clone();
                                            CvInvoke.Multiply(img, blackImage, img);
                                            img = img.GetSubRect(boundingBox);
                                            _outputListImage.Add(img.ToBitmap());
                                        }
                                        lcontourshow.Push(contour);
                                        if (i == 0)
                                        {
                                            boundingBoxShow = CvInvoke.BoundingRectangle(contour);
                                        }
                                        else
                                        {
                                            Rectangle rect = CvInvoke.BoundingRectangle(contour);
                                            boundingBoxShow = Rectangle.Union(boundingBoxShow, rect);
                                        }
                                    }
                                    if (_isShowImageResult)
                                    {
                                        if (_isImageColor)
                                        {
                                            var blackImage = new Image<Bgr, byte>(imgWidth, imgHeight, new Bgr(0, 0, 0));
                                            CvInvoke.DrawContours(blackImage, lcontourshow, -1, new MCvScalar(1, 1, 1), -1);
                                            Image<Bgr, byte> img = _inputImageColor.Clone();
                                            CvInvoke.Multiply(img, blackImage, img);
                                            img = img.GetSubRect(boundingBoxShow);
                                            if (_isShowImageResult)
                                            {
                                                _outputImageShow = img.ToBitmap();
                                            }
                                        }
                                        else
                                        {
                                            var blackImage = new Image<Gray, byte>(imgWidth, imgHeight, new Gray(0));
                                            CvInvoke.DrawContours(blackImage, lcontourshow, -1, new MCvScalar(1), -1);
                                            Image<Gray, byte> img = _inputImageGray.Clone();
                                            CvInvoke.Multiply(img, blackImage, img);
                                            img = img.GetSubRect(boundingBoxShow);
                                            if (_isShowImageResult)
                                            {
                                                _outputImageShow = img.ToBitmap();
                                            }
                                        }
                                    }

                                }


                            }
                            else
                            {
                                if (_splitROIType == cImageSplit.ROIType_OneROI)
                                {
                                    var blackImage = new Image<Gray, byte>(imgWidth, imgHeight, new Gray(0));
                                    VectorOfVectorOfPoint lcontour = new VectorOfVectorOfPoint();
                                    for (int i = 0; i < _inSetOrigin.Count; i++)
                                    {
                                        PointF[] points = new PointF[4];
                                        for (int j = 0; j < 4; j++)
                                        {
                                            points[j] = ConvertCoordinatesToOrigin(_toolOrigin, _inSetOrigin[i][j]);
                                        }
                                        //GetRectangleVertices(_ROI[i], out PointF[] points);
                                        Point[] pRec = points.Select(p => new Point((int)p.X, (int)p.Y)).ToArray();
                                        VectorOfPoint contour = new VectorOfPoint(pRec);
                                        lcontour.Push(contour);
                                    }
                                    CvInvoke.DrawContours(blackImage, lcontour, -1, new MCvScalar(1), -1);
                                    if (_isImageColor)
                                    {
                                        Image<Bgr, byte> img = _inputImageColor.Clone();
                                        CvInvoke.Multiply(img, blackImage, img);
                                        _outputListImage.Add(img.ToBitmap());
                                        if (_isShowImageResult)
                                        {
                                            _outputImageShow = img.ToBitmap();
                                        }
                                    }
                                    else
                                    {
                                        Image<Gray, byte> img = _inputImageGray.Clone();
                                        CvInvoke.Multiply(img, blackImage, img);
                                        _outputListImage.Add(img.ToBitmap());
                                        if (_isShowImageResult)
                                        {
                                            _outputImageShow = img.ToBitmap();
                                        }
                                    }
                                }
                                else
                                {
                                    var blackImage = new Image<Gray, byte>(imgWidth, imgHeight, new Gray(0));
                                    for (int i = 0; i < _inSetOrigin.Count; i++)
                                    {
                                        VectorOfVectorOfPoint lcontour = new VectorOfVectorOfPoint();
                                        PointF[] points = new PointF[4];
                                        for (int j = 0; j < 4; j++)
                                        {
                                            points[j] = ConvertCoordinatesToOrigin(_toolOrigin, _inSetOrigin[i][j]);
                                        }
                                        //GetRectangleVertices(_ROI[i], out PointF[] points);
                                        Point[] pRec = points.Select(p => new Point((int)p.X, (int)p.Y)).ToArray();
                                        VectorOfPoint contour = new VectorOfPoint(pRec);
                                        lcontour.Push(contour);
                                        CvInvoke.DrawContours(blackImage, lcontour, -1, new MCvScalar(1), -1);
                                        if (_isImageColor)
                                        {
                                            Image<Bgr, byte> img = _inputImageColor.Clone();
                                            CvInvoke.Multiply(img, blackImage, img);
                                            _outputListImage.Add(img.ToBitmap());
                                            if (_isShowImageResult)
                                            {
                                                _outputImageShow = img.ToBitmap();
                                            }
                                        }
                                        else
                                        {
                                            Image<Gray, byte> img = _inputImageGray.Clone();
                                            CvInvoke.Multiply(img, blackImage, img);
                                            _outputListImage.Add(img.ToBitmap());
                                            if (_isShowImageResult)
                                            {
                                                _outputImageShow = img.ToBitmap();
                                            }
                                        }
                                    }

                                }

                            }
                        }
                        else if (_splitType == cImageSplit.SplitType_Ratio)
                        {
                            if (_isImageColor)
                            {
                                _outputListImage.Add(_inputImageColor.ToBitmap());
                                if (_isShowImageResult)
                                {
                                    _outputImageShow = _inputImageColor.ToBitmap();
                                }
                            }
                            else
                            {
                                _outputListImage.Add(_inputImageGray.ToBitmap());
                                if (_isShowImageResult)
                                {
                                    _outputImageShow = _inputImageGray.ToBitmap();
                                }
                            }

                        }
                        else
                        {
                            _errMessage = "Lỗi SplitType không đúng";
                            return false;
                        }
                    }
                    else
                    {
                        if (_splitType == cImageSplit.SplitType_Ratio)
                        {
                            if (_isAdaptImageSize)
                            {
                                Rectangle rec = new Rectangle(0, 0, _colNumber, _rowNumber);
                                if (_isImageColor)
                                {
                                    Image<Bgr, byte> img = _inputImageColor.GetSubRect(rec);
                                    _outputListImage.Add(img.ToBitmap());
                                    if (_isShowImageResult)
                                    {
                                        _outputImageShow = img.ToBitmap();
                                    }
                                }
                                else
                                {
                                    Image<Gray, byte> img = _inputImageGray.GetSubRect(rec);
                                    _outputListImage.Add(img.ToBitmap());
                                    if (_isShowImageResult)
                                    {
                                        _outputImageShow = img.ToBitmap();
                                    }
                                }

                            }
                            else
                            {
                                var blackImage = new Image<Gray, byte>(imgWidth, imgHeight, new Gray(0));
                                Rectangle rec = new Rectangle(0, 0, _colNumber, _rowNumber);
                                CvInvoke.Rectangle(blackImage, rec, new MCvScalar(1), -1);
                                if (_isImageColor)
                                {
                                    Image<Bgr, byte> img = _inputImageColor.Clone();
                                    CvInvoke.Multiply(img, blackImage, img);
                                    _outputListImage.Add(img.ToBitmap());
                                    if (_isShowImageResult)
                                    {
                                        _outputImageShow = img.ToBitmap();
                                    }
                                }
                                else
                                {
                                    Image<Gray, byte> img = _inputImageGray.Clone();
                                    CvInvoke.Multiply(img, blackImage, img);
                                    _outputListImage.Add(img.ToBitmap());
                                    if (_isShowImageResult)
                                    {
                                        _outputImageShow = img.ToBitmap();
                                    }
                                }

                            }
                        }
                        else if (_splitType == cImageSplit.SplitType_ROI)
                        {
                            if (_isImageColor)
                            {
                                _outputListImage.Add(_inputImageColor.ToBitmap());
                                if (_isShowImageResult)
                                {
                                    _outputImageShow = _inputImageColor.ToBitmap();
                                }
                            }
                            else
                            {
                                _outputListImage.Add(_inputImageGray.ToBitmap());
                                if (_isShowImageResult)
                                {
                                    _outputImageShow = _inputImageGray.ToBitmap();
                                }
                            }
                        }
                        else
                        {
                            _errMessage = "Lỗi SplitType không đúng";
                            return false;
                        }
                    }
                }
                else
                {
                    if (_isAdaptImageSize)
                    {
                        var blackImage = new Image<Gray, byte>(imgWidth, imgHeight, new Gray(0));
                        if (_isImageColor)
                        {
                            Image<Bgr, byte> img = _inputImageColor.Clone();
                            Rectangle boundingBox = new Rectangle();
                            for (int i = 0; i < _inputRegion.Count; i++)
                            {
                                CvInvoke.DrawContours(blackImage, _inputRegion[i], -1, new MCvScalar(1), -1);
                                if (i == 0)
                                {
                                    boundingBox = CvInvoke.BoundingRectangle(_inputRegion[i][0]);
                                }
                                else
                                {
                                    Rectangle rect = CvInvoke.BoundingRectangle(_inputRegion[i][0]);
                                    boundingBox = Rectangle.Union(boundingBox, rect);
                                }
                            }
                            CvInvoke.Multiply(img, blackImage, img);
                            img = img.GetSubRect(boundingBox);
                            _outputListImage.Add(img.ToBitmap());
                            if (_isShowImageResult)
                            {
                                _outputImageShow = img.ToBitmap();
                            }
                        }
                        else
                        {
                            Image<Gray, byte> img = _inputImageGray.Clone();
                            Rectangle boundingBox = new Rectangle();
                            for (int i = 0; i < _inputRegion.Count; i++)
                            {
                                CvInvoke.DrawContours(blackImage, _inputRegion[i], -1, new MCvScalar(1), -1);
                                if (i == 0)
                                {
                                    boundingBox = CvInvoke.BoundingRectangle(_inputRegion[i][0]);
                                }
                                else
                                {
                                    Rectangle rect = CvInvoke.BoundingRectangle(_inputRegion[i][0]);
                                    boundingBox = Rectangle.Union(boundingBox, rect);
                                }
                            }
                            CvInvoke.Multiply(img, blackImage, img);
                            img = img.GetSubRect(boundingBox);
                            _outputListImage.Add(img.ToBitmap());
                            if (_isShowImageResult)
                            {
                                _outputImageShow = img.ToBitmap();
                            }
                        }

                    }
                    else
                    {
                        var blackImage = new Image<Gray, byte>(imgWidth, imgHeight, new Gray(0));
                        if (_isImageColor)
                        {
                            Image<Bgr, byte> img = _inputImageColor.Clone();
                            for (int i = 0; i < _inputRegion.Count; i++)
                            {
                                CvInvoke.DrawContours(blackImage, _inputRegion[i], -1, new MCvScalar(1), -1);
                            }
                            CvInvoke.Multiply(img, blackImage, img);
                            _outputListImage.Add(img.ToBitmap());
                            if (_isShowImageResult)
                            {
                                _outputImageShow = img.ToBitmap();
                            }
                        }
                        else
                        {
                            Image<Gray, byte> img = _inputImageGray.Clone();
                            for (int i = 0; i < _inputRegion.Count; i++)
                            {
                                CvInvoke.DrawContours(blackImage, _inputRegion[i], -1, new MCvScalar(1), -1);
                            }
                            CvInvoke.Multiply(img, blackImage, img);
                            _outputListImage.Add(img.ToBitmap());
                            if (_isShowImageResult)
                            {
                                _outputImageShow = img.ToBitmap();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _errMessage = ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            _passed = true;
            return true;
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
        private PointF ConvertCoordinatesToOrigin(Tuple<PointF, double> Coordinates, PointF point)
        {
            PointF p = new PointF();
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
            p.X = (float)C.Data[0, 0];
            p.Y = (float)C.Data[1, 0];
            return p;
        }
    }
}
