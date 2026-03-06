using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Emgu;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ImageFilterTool
{
    public class ImageFilter
    {
        /// <summary>
        /// INPUT
        /// </summary>
        public Image<Gray, byte> InputImageGray
        {
            set { _inputImageGray = value; }
        }
        public Image<Bgr, byte> InputImageBgr
        {
            set { _inputImageBgr = value; }
        }
        public string FilterType
        {
            set { _filterType = value; }
        }
        public int MaskWidth
        {
            set { _maskWidth = value; }
        }
        public int MaskHeight
        {
            set { _maskHeight = value; }
        }
        public string MaskType
        {
            set { _maskType = value; }
        }
        public Tuple<int, int> ThresholdRange
        {
            set { _thresholdRange = value; }
        }
        public int GrayValue
        {
            set { _grayValue = value; }
        }
        public double ScaleFactor
        {
            set { _scaleFactor = value; }
        }
        public bool IsShowImageResult
        {
            set { _isShowImageResult = value; }
        }
        /// <summary>
        /// OUTPUT
        /// </summary>
        public Image<Gray, byte> OutputImage
        {
            get { return _outputImage; }
        }
        public string ErrMessage
        {
            get { return _errMessage; }
        }
        public bool Passed
        {
            get { return _passed; }
        }
        public Bitmap OutputImageShow
        {
            get { return _outputImageShow; }
        }
        /// <summary>
        /// Cac bien cuc bo su dung trong class
        /// </summary>
        private Image<Gray, byte> _inputImageGray = null;
        private Image<Bgr, byte> _inputImageBgr = null;

        private string _filterType = null;
        private int _maskWidth = -1;
        private int _maskHeight = -1;
        private string _maskType = null;
        private Tuple<int, int> _thresholdRange = null;
        private int _grayValue = -1;
        private bool _isShowImageResult = false;
        private double _scaleFactor = -1;

        private Image<Gray, byte> _outputImage = null;
        private string _errMessage;
        private bool _passed = false;
        private Bitmap _outputImageShow = null;

        public bool Run()
        {
            //Kiểm tra thuộc tính đầu vào
            if (_filterType == null)
            {
                _errMessage = "Lỗi chưa set FilterType";
                return false;
            }
            if (_maskWidth == -1)
            {
                _errMessage = "Lỗi chưa set MaskWidth";
                return false;
            }
            if (_maskHeight == -1)
            {
                _errMessage = "Lỗi chưa set MaskHeight";
                return false;
            }
            if (_maskType == null)
            {
                _errMessage = "Lỗi chưa set MaskType";
                return false;
            }
            if (_thresholdRange == null)
            {
                _errMessage = "Lỗi chưa set ThresholdRange";
                return false;
            }
            if (_grayValue == -1)
            {
                _errMessage = "Lỗi chưa set GrayValue";
                return false;
            }
            if (_scaleFactor == -1)
            {
                _errMessage = "Lỗi chưa set ScaleFactor";
                return false;
            }
            _passed = false;
            try
            {
                //_outputImage = _inputImage;
                ElementShape shape = new ElementShape();
                switch (_maskType)
                {
                    case RTCConst.cImageFilterTool.MaskType_Rectangle:
                        shape = ElementShape.Rectangle;
                        break;
                    case RTCConst.cImageFilterTool.MaskType_Cross:
                        shape = ElementShape.Cross;
                        break;
                    case RTCConst.cImageFilterTool.MaskType_Ellipse:
                        shape = ElementShape.Ellipse;
                        break;
                }

                switch (_filterType)
                {
                    case RTCConst.cImageFilterTool.FilterType_Opening:
                        {
                            if (_inputImageGray != null)
                            {
                                MorphOp operation = MorphOp.Open;
                                //var inputImg = _inputImage.ToImage<Gray, byte>();
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();
                                Mat kernel = CvInvoke.GetStructuringElement(shape, new Size(2 * _maskWidth + 1, 2 * _maskHeight + 1), new Point(-1, -1));
                                _outputImage = _inputImageGray.MorphologyEx(operation, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());
                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;

                            }
                            break;

                        }
                    case RTCConst.cImageFilterTool.FilterType_Closing:
                        {
                            if (_inputImageGray != null)
                            {
                                MorphOp operation = MorphOp.Close;
                                //var inputImg = _inputImage.ToImage<Gray, byte>();
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();

                                Mat kernel = CvInvoke.GetStructuringElement(shape, new Size(2 * _maskWidth + 1, 2 * _maskHeight + 1), new Point(-1, -1));
                                _outputImage = _inputImageGray.MorphologyEx(operation, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());
                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Dilation:
                        {
                            if (_inputImageGray != null)
                            {
                                MorphOp operation = MorphOp.Dilate;
                                //var inputImg = _inputImage.ToImage<Gray, byte>();
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();

                                Mat kernel = CvInvoke.GetStructuringElement(shape, new Size(2 * _maskWidth + 1, 2 * _maskHeight + 1), new Point(-1, -1));
                                _outputImage = _inputImageGray.MorphologyEx(operation, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());

                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Erosion:
                        {
                            if (_inputImageGray != null)
                            {
                                MorphOp operation = MorphOp.Erode;
                                //var inputImg = _inputImage.ToImage<Gray, byte>();
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();

                                Mat kernel = CvInvoke.GetStructuringElement(shape, new Size(2 * _maskWidth + 1, 2 * _maskHeight + 1), new Point(-1, -1));
                                _outputImage = _inputImageGray.MorphologyEx(operation, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());

                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Mean:
                        {
                            if (_inputImageGray != null)
                            {
                                //var inputImg = _inputImage.ToImage<Gray, byte>();
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();
                                _outputImage = _inputImageGray.SmoothBlur(_maskWidth, _maskHeight);

                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Median:
                        {
                            if (_inputImageGray != null)
                            {
                                //var inputImg = _inputImage.ToImage<Gray, byte>();
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();

                                _outputImage = _inputImageGray.SmoothMedian(((int)_maskWidth / 2) * 2 + 1);

                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Gaussian:
                        {
                            if (_inputImageGray != null)
                            {
                                //var inputImg = _inputImage.ToImage<Gray, byte>();
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();
                                _outputImage = _inputImageGray.SmoothGaussian(((int)_maskWidth / 2) * 2 + 1);

                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Binary:
                        {
                            if (_inputImageGray != null)
                            {
                                var minThres = _thresholdRange.Item1;
                                var maxThres = _thresholdRange.Item2;
                                int thresholdLow = _thresholdRange.Item1;
                                int thresholdHigh = _thresholdRange.Item2;
                                var imgThes = new Image<Gray, byte>(_inputImageGray.Width, _inputImageGray.Height);
                                Image<Gray, byte> outputImageLow = new Image<Gray, byte>(_inputImageGray.Width, _inputImageGray.Height, new Gray(0));
                                Image<Gray, byte> outputImageHigh = new Image<Gray, byte>(_inputImageGray.Width, _inputImageGray.Height, new Gray(0));
                                if (maxThres == 255)
                                {
                                    CvInvoke.Threshold(_inputImageGray, imgThes, minThres, 255, ThresholdType.Binary);
                                }
                                else if (minThres == 0)
                                {
                                    CvInvoke.Threshold(_inputImageGray, imgThes, maxThres, 255, ThresholdType.BinaryInv);

                                }
                                else
                                {
                                    CvInvoke.Threshold(imgThes, outputImageHigh, maxThres, 255, ThresholdType.Binary);
                                    CvInvoke.Threshold(imgThes, outputImageLow, minThres, 255, ThresholdType.BinaryInv);
                                    CvInvoke.Add(outputImageHigh, outputImageLow, imgThes);
                                    CvInvoke.Threshold(imgThes, imgThes, 120, 255, ThresholdType.BinaryInv);

                                }
                                _outputImage = imgThes.Clone();

                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Invert:
                        {
                            if (_inputImageGray != null)
                            {
                                //var inputImg = _inputImage.ToImage<Gray, byte>();
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();

                                var invert = new Image<Gray, byte>(_inputImageGray.Width, _inputImageGray.Height);
                                CvInvoke.BitwiseNot(_inputImageGray, invert);
                                _outputImage = invert.Clone();
                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_BandPass:
                        {
                            if (_inputImageGray != null)
                            {
                                Image<Gray, byte> imgThres = new Image<Gray, byte>(_inputImageGray.Width, _inputImageGray.Height);
                                //var inputImg = _inputImage.ToImage<Gray, byte>();
                                double val = CvInvoke.Threshold(_inputImageGray, imgThres, 0, 255, ThresholdType.Otsu);
                                Mat bandpass = new Mat(imgThres.Size, DepthType.Cv8U, 1);
                                float[,] matrix3 = new float[5, 5]
                                {
                              { 0, -2, -2, -2, 0 },
                              { -2, 0, 3, 0, -2  },
                              { -2, 3, 12, 3 ,-2 },
                              { -2, 0, 3, 0, -2  },
                              { 0, -2, -2, -2, 0 }
                                };
                                ConvolutionKernelF kernel3 = new ConvolutionKernelF(matrix3);
                                CvInvoke.Filter2D(imgThres, bandpass, kernel3, new Point(0, 0));
                                _outputImage = bandpass.ToImage<Gray, byte>();

                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Emphasize:
                        {
                            if (_inputImageGray != null)
                            {
                                //var inputImg = _inputImage.ToImage<Gray, byte>();
                                var meanImg = _inputImageGray.SmoothBlur(_maskWidth, _maskHeight);
                                Image<Gray, byte> subtract = new Image<Gray, byte>(_inputImageGray.Width, _inputImageGray.Height);
                                CvInvoke.Subtract(_inputImageGray, meanImg, subtract);
                                Image<Gray, byte> result = new Image<Gray, byte>(_inputImageGray.Width, _inputImageGray.Height);
                                CvInvoke.Add(_inputImageGray, subtract * _scaleFactor, result);
                                _outputImage = result.Clone();
                            }
                            else
                            {
                                _errMessage = "InputImageGray = null";
                                return false;
                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Blue:
                        {
                            if (_inputImageBgr != null)
                            {
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();

                                _outputImage = _inputImageBgr[0];

                            }
                            else
                            {
                                _errMessage = "InputImageBgr = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Red:
                        {
                            if (_inputImageBgr != null)
                            {
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();

                                _outputImage = _inputImageBgr[2];

                            }
                            else
                            {
                                _errMessage = "InputImageBgr = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Green:
                        {
                            if (_inputImageBgr != null)
                            {
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();

                                _outputImage = _inputImageBgr[1];

                            }
                            else
                            {
                                _errMessage = "InputImageBgr = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Hue:
                        {
                            if (_inputImageBgr != null)
                            {
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();
                                var outImage = new Image<Bgr, byte>(_inputImageBgr.Width, _inputImageBgr.Height);
                                CvInvoke.CvtColor(_inputImageBgr, outImage, ColorConversion.Rgb2Hsv);
                                _outputImage = outImage[0];

                            }
                            else
                            {
                                _errMessage = "InputImageBgr = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Saturation:
                        {
                            if (_inputImageBgr != null)
                            {
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();
                                var outImage = new Image<Bgr, byte>(_inputImageBgr.Width, _inputImageBgr.Height);
                                CvInvoke.CvtColor(_inputImageBgr, outImage, ColorConversion.Rgb2Hsv);
                                _outputImage = outImage[1];

                            }
                            else
                            {
                                _errMessage = "InputImageBgr = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_Intensity:
                        {
                            if (_inputImageBgr != null)
                            {
                                //var inputImg = _inputImage.ToImage<Bgr, byte>();
                                var outImage = new Image<Bgr, byte>(_inputImageBgr.Width, _inputImageBgr.Height);
                                CvInvoke.CvtColor(_inputImageBgr, outImage, ColorConversion.Rgb2Hsv);
                                _outputImage = outImage[2];

                            }
                            else
                            {
                                _errMessage = "InputImageBgr = null";
                                return false;

                            }
                            break;
                        }
                    case RTCConst.cImageFilterTool.FilterType_RGBToGray:
                        {
                            if (_inputImageBgr != null)
                            {
                                _outputImage = _inputImageBgr.Convert<Gray, byte>();

                            }
                            else
                            {
                                _errMessage = "InputImageBgr = null";
                                return false;

                            }
                            break;
                        }

                }
                //_outputImage = outImage.ToBitmap();
                if (_isShowImageResult)
                {
                    _outputImageShow = _outputImage.AsBitmap();
                }
                _passed = true;
            }
            catch (Exception ex)
            {
                _errMessage = ex.Message + "\n" + ex.StackTrace;
                return false;
            }


            return true;
        }
    }
}
