using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using RTCBase.Drawing;
using RTCConst;

namespace ImageMath
{
    public class ImageMath
    {
        /// <summary>
        /// INPUT
        /// </summary>
        public Image<Gray, byte> InputImage
        {
            set { _inputImage = value; }
        }
        public Image<Gray, byte> InputImage2
        {
            set { _inputImage2 = value; }
        }
        public double ScaleFactor
        {
            set { _scaleFactor = value; }
        }
        public double OffsetValue
        {
            set { _offsetValue = value; }
        }
        public string ImageOperation
        {
            set { _imageOperation = value; }
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

        private Image<Gray, byte> _inputImage = null;
        private Image<Gray, byte> _inputImage2 = null;
        private string _imageOperation = null;
        private double _scaleFactor = 1;
        private double _offsetValue = 0;
        private bool _isShowImageResult = false;

        private bool _passed = false;
        private string _errMessage = null;
        private Image<Gray, byte> _outputImage = null;
        private Bitmap _outputImageShow = null;

        public bool Run()
        {
            _outputImage = null;
            _passed = false;
            //Kiểm tra thuộc tính đầu vào
            if (_inputImage == null || _inputImage.Width == 0)
            {
                _errMessage = "Lỗi InputImage = null";
                return false;
            }
            if (_imageOperation == null)
            {
                _errMessage = "Lỗi ImageOperation = null";
                return false;
            }
            try
            {
                switch(_imageOperation)
                {
                    case RTCConst.cImageMath.ImageMath_Operation_Add:
                        {
                            if(_inputImage2 == null || _inputImage2.Width==0)
                            {
                                _errMessage = "Lỗi InputImage2 = null";
                                return false;
                            }
                            if(_inputImage.Width != _inputImage2.Width || _inputImage.Height != _inputImage2.Height)
                            {
                                _errMessage = "The size of InputImage is different from InputImage2 ";
                                return false;
                            }
                            _outputImage = new Image<Gray, byte>(_inputImage.Width,_inputImage.Height);
                            CvInvoke.Add(_inputImage, _inputImage2, _outputImage);
                            _outputImage = _outputImage * _scaleFactor + _offsetValue;
                            break;
                        }
                    case RTCConst.cImageMath.ImageMath_Operation_Sub:
                        {
                            if (_inputImage2 == null || _inputImage2.Width == 0)
                            {
                                _errMessage = "Lỗi InputImage2 = null";
                                return false;
                            }
                            if (_inputImage.Width != _inputImage2.Width || _inputImage.Height != _inputImage2.Height)
                            {
                                _errMessage = "The size of InputImage is different from InputImage2 ";
                                return false;
                            }
                            _outputImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                            CvInvoke.Subtract(_inputImage, _inputImage2, _outputImage);
                            _outputImage = _outputImage * _scaleFactor + _offsetValue;
                            break;
                        }
                    case RTCConst.cImageMath.ImageMath_Operation_Abs:
                        {
                            if (_inputImage2 == null || _inputImage2.Width == 0)
                            {
                                _errMessage = "Lỗi InputImage2 = null";
                                return false;
                            }
                            if (_inputImage.Width != _inputImage2.Width || _inputImage.Height != _inputImage2.Height)
                            {
                                _errMessage = "The size of InputImage is different from InputImage2 ";
                                return false;
                            }
                            _outputImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                            CvInvoke.AbsDiff(_inputImage, _inputImage2, _outputImage);
                            _outputImage = _outputImage * _scaleFactor;
                            break;
                        }
                    case RTCConst.cImageMath.ImageMath_Operation_AND:
                        {
                            if (_inputImage2 == null || _inputImage2.Width == 0)
                            {
                                _errMessage = "Lỗi InputImage2 = null";
                                return false;
                            }
                            if (_inputImage.Width != _inputImage2.Width || _inputImage.Height != _inputImage2.Height)
                            {
                                _errMessage = "The size of InputImage is different from InputImage2 ";
                                return false;
                            }
                            _outputImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                            CvInvoke.BitwiseAnd(_inputImage, _inputImage2, _outputImage);
                            //_outputImage = _outputImage * _scaleFactor;
                            break;
                        }
                    case RTCConst.cImageMath.ImageMath_Operation_OR:
                        {
                            if (_inputImage2 == null || _inputImage2.Width == 0)
                            {
                                _errMessage = "Lỗi InputImage2 = null";
                                return false;
                            }
                            if (_inputImage.Width != _inputImage2.Width || _inputImage.Height != _inputImage2.Height)
                            {
                                _errMessage = "The size of InputImage is different from InputImage2 ";
                                return false;
                            }
                            _outputImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                            CvInvoke.BitwiseOr(_inputImage, _inputImage2, _outputImage);
                            break;
                        }
                    case RTCConst.cImageMath.ImageMath_Operation_XOR:
                        {
                            if (_inputImage2 == null || _inputImage2.Width == 0)
                            {
                                _errMessage = "Lỗi InputImage2 = null";
                                return false;
                            }
                            if (_inputImage.Width != _inputImage2.Width || _inputImage.Height != _inputImage2.Height)
                            {
                                _errMessage = "The size of InputImage is different from InputImage2 ";
                                return false;
                            }
                            _outputImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                            CvInvoke.BitwiseXor(_inputImage, _inputImage2, _outputImage);
                            break;
                        }
                    case RTCConst.cImageMath.ImageMath_Operation_Div:
                        {
                            if (_inputImage2 == null || _inputImage2.Width == 0)
                            {
                                _errMessage = "Lỗi InputImage2 = null";
                                return false;
                            }
                            if (_inputImage.Width != _inputImage2.Width || _inputImage.Height != _inputImage2.Height)
                            {
                                _errMessage = "The size of InputImage is different from InputImage2 ";
                                return false;
                            }
                            _outputImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                            CvInvoke.Divide(_inputImage, _inputImage2, _outputImage);
                            _outputImage = _outputImage * _scaleFactor + _offsetValue;
                            break;
                        }
                    case RTCConst.cImageMath .ImageMath_Operation_Mul:
                        {
                            if (_inputImage2 == null || _inputImage2.Width == 0)
                            {
                                _errMessage = "Lỗi InputImage2 = null";
                                return false;
                            }
                            if (_inputImage.Width != _inputImage2.Width || _inputImage.Height != _inputImage2.Height)
                            {
                                _errMessage = "The size of InputImage is different from InputImage2 ";
                                return false;
                            }
                            _outputImage = new Image<Gray, byte>(_inputImage.Width, _inputImage.Height);
                            CvInvoke.Multiply(_inputImage, _inputImage2, _outputImage);
                            _outputImage = _outputImage * _scaleFactor + _offsetValue;
                            break;
                        }
                    case RTCConst.cImageMath.ImageMath_Operation_Scale:
                        {
                            _outputImage = _inputImage * _scaleFactor + _offsetValue;
                            break;
                        }
                    case RTCConst.cImageMath.ImageMath_Operation_Zoom:
                        {
                            _outputImage = new Image<Gray, byte>((int)(_inputImage.Width / _offsetValue), (int)(_inputImage.Height / _scaleFactor));
                            CvInvoke.Resize(_inputImage, _outputImage, new Size((int)(_inputImage.Width/ _offsetValue),(int)(_inputImage.Height/ _scaleFactor)));
                            break;
                        }
                }    
            }
            catch (Exception ex)
            {
                _errMessage = ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            if(_isShowImageResult )
            {
                _outputImageShow = _outputImage.AsBitmap();
            }
            _passed = true;
            return true;
        }
    }
}
