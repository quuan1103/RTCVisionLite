using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using RTCConst;

namespace Region_Processing
{
    public class RegionProcessing
    {
        /// <summary>
        /// INPUT
        /// </summary>
        public Image<Gray, byte> InputImage
        {
            set { _inputImage = value; }
        }
        public List<VectorOfVectorOfPoint> InputRegion
        {
            set { _inputRegion = value;}
        }
        public string Margin
        {
            set { _margin = value; }
        }
        public string MaskType
        {
            set { _maskType = value; }
        }
        public string MorphologyType
        {
            set { _morphologyType = value; }
        }
        public int MaskHeight
        {
            set { _maskHeight = value; }
        }
        public int MaskWidth
        {
            set { _maskWidth = value; }
        }
        public double MashRadius
        {
            set { _maskRadius = value; }
        }
        public int Interation
        {
            set { _iterations = value; }
        }

        /// <summary>
        /// OUTPUT
        /// </summary>
        public List<VectorOfVectorOfPoint> OutputRegion
        {
            get { return _outputRegion; }
        }
        public List<PointF> CenterPoint
        {
            get { return _centerPoint; }
        }
        public List<RotatedRect> SmallestRectangle
        { 
            get { return _smallestRectangle; } 
        }
        public string ErrMessage
        { 
            get { return _errMessage; } 
        }
        public Bitmap OutputImageShow 
        { 
            get { return _outputImageShow; } 
        }
        public bool IsShowImageResult
        {
            set { _isShowImageResult = value; }
        }



        private Image<Gray, byte> _inputImage = null;
        private List<VectorOfVectorOfPoint> _inputRegion = null;
        private string _margin = null;
        private string _maskType = null;
        private string _morphologyType = null;
        private int _maskHeight = 0;
        private int _maskWidth = 0;
        private double _maskRadius = 0;
        private int _iterations = 0;
        private bool _isShowImageResult = false;

        private List<VectorOfVectorOfPoint> _outputRegion = new List<VectorOfVectorOfPoint>();
        private List<PointF> _centerPoint = new List<PointF>();
        private List<RotatedRect> _smallestRectangle = new List<RotatedRect>();
        private string _errMessage = null;
        private Bitmap _outputImageShow = null;

        public bool Run()
        {
            if(_inputImage == null)
            {
                _errMessage = "Run: InputImage == null";
                return false;
            }
            if(_inputRegion == null)
            {
                _errMessage = "Run: InputRegion == null";
                return false;
            }            
            try
            {
                _outputRegion = new List<VectorOfVectorOfPoint>();
                _centerPoint = new List<PointF>();
                _smallestRectangle = new List<RotatedRect>();
                Mat mat = new Mat(_inputImage.Height, _inputImage.Width, DepthType.Cv8U, 1);
                Mat matMor = new Mat(_inputImage.Height, _inputImage.Width, DepthType.Cv8U, 1);

                for (int i = 0; i < _inputRegion.Count; i++)
                {
                    CvInvoke.FillPoly(mat, _inputRegion[i], new MCvScalar(255));
                }

                MorphOp operation = new MorphOp();
                if (_morphologyType == cRegionProcessing.MorphologyType_Erosion)
                {
                    operation = MorphOp.Erode;
                }
                else if (_morphologyType == cRegionProcessing.MorphologyType_Dilation)
                {
                    operation = MorphOp.Dilate;
                }
                else if (_morphologyType == cRegionProcessing.MorphologyType_Opening)
                {
                    operation = MorphOp.Open;
                }
                else if (_morphologyType == cRegionProcessing.MorphologyType_Closing)
                {
                    operation = MorphOp.Close;
                }
                ElementShape shape = new ElementShape();
                Mat kernel = new Mat();
                if (_maskType == cRegionProcessing.MaskType_Rectangle)
                {
                    shape = ElementShape.Rectangle;
                    kernel = CvInvoke.GetStructuringElement(shape, new Size(_maskWidth * 2 + 1, _maskHeight * 2 + 1), new Point(-1, -1));
                }
                else if (_maskType == cRegionProcessing.MaskType_Circle)
                {
                    shape = ElementShape.Ellipse;
                    kernel = CvInvoke.GetStructuringElement(shape, new Size((int)_maskRadius * 2, (int)_maskRadius * 2), new Point(-1, -1));
                }
                CvInvoke.MorphologyEx(mat, matMor, operation, kernel, new Point(-1, -1), _iterations, BorderType.Default, new MCvScalar());

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hier = new Mat();
                CvInvoke.FindContours(matMor, contours, hier, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);
                Array arr = hier.GetData(true);
                if (contours.Size > 0)
                {
                    int k = 0;
                    while (k != -1)
                    {
                        int child = (int)arr.GetValue(0, k, 2);
                        VectorOfVectorOfPoint tmp = new VectorOfVectorOfPoint();
                        tmp.Push(contours[k]);
                        RotatedRect rotRect = CvInvoke.MinAreaRect(contours[k]);
                        _smallestRectangle.Add(rotRect);
                        _centerPoint.Add(rotRect.Center);
                        if (child != -1)
                        {
                            tmp.Push(contours[child]);
                            int child_next = (int)arr.GetValue(0, child, 0);
                            while (child_next != -1)
                            {
                                tmp.Push(contours[child_next]);
                                child_next = (int)arr.GetValue(0, child_next, 0);
                            }
                        }
                        _outputRegion.Add(tmp);
                        k = (int)arr.GetValue(0, k, 0);
                    }
                }
                if(_isShowImageResult)
                {
                    var imgShow = _inputImage.Convert<Bgr, byte>();
                    if (_inputImage == null)
                        return false;
                    if (_outputRegion == null)
                        return false;
                    for (int i = 0; i < _outputRegion.Count; i++)
                    {
                        if (_margin == cRegionProcessing.Margin_Fill)
                            CvInvoke.FillPoly(imgShow, _outputRegion[i], new MCvScalar(0, 255, 0));
                        else if (_margin == cRegionProcessing.Margin_Margin)
                            CvInvoke.DrawContours(imgShow, _outputRegion[i], -1, new MCvScalar(0, 255, 0), 1);

                    }
                    _outputImageShow = imgShow.ToBitmap();
                    imgShow.Dispose();
                }
                mat.Dispose();
                matMor.Dispose();
            }
            catch (Exception ex)
            {
                _errMessage = "Run: " + ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            return true;
        }
        private bool GetImageResult()
        {
            var imgShow = _inputImage.Convert<Bgr, byte>();
            if (_inputImage == null)
                return false;
            if (_outputRegion == null)
                return false;
            for (int i = 0; i < _outputRegion.Count; i++)
            {
                if (_margin == RTCConst.cRegionProcessing.Margin_Fill)
                    CvInvoke.FillPoly(imgShow, _outputRegion[i], new MCvScalar(0, 255, 0));
                else if (_margin == RTCConst.cRegionProcessing.Margin_Margin)
                    CvInvoke.DrawContours(imgShow, _outputRegion[i], -1, new MCvScalar(0, 255, 0), 1);

            }
            _outputImageShow = imgShow.ToBitmap();
            return true;
        }
    }
}
