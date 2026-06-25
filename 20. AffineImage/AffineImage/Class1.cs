using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace AffineImage
{
    /// <summary>
    /// INPUT
    /// </summary>
    public class AffineImage
    {
        public Image<Bgr, byte> InputImage
        {
            set { _inputImage = value; }
        }
        public string AffineMode
        {
            set { _affineMode = value; }
        }
        public string Interpolation
        {
            set { _interpolation = value; }
        }
        public double InputX
        {
            set { _inputX = value; }
        }
        public double InputY
        {
            set { _inputY = value; }
        }
        public double InputAngle
        {
            set { _inputAngle = value; }
        }
        public double InputTransX
        {
            set { _inputTransX = value; }
        }
        public double InputTransY
        {
            set { _inputTransY = value; }
        }
        public Tuple<PointF, double> InputOrigin1
        {
            set { _inputOrigin1 = value; }
        }
        public Tuple<PointF, double> InputOrigin2
        {
            set { _inputOrigin2 = value; }
        }
        /// <summary>
        /// OUTPUT
        /// </summary>
        public Image<Bgr, byte> OutputImage
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


        private Image<Bgr, byte> _inputImage = null;
        private string _affineMode = null;
        private string _interpolation = null;
        private double _inputX = 0;
        private double _inputY = 0;
        private double _inputAngle = 0;
        private double _inputTransX = 0;
        private double _inputTransY = 0;
        private Tuple<PointF, double> _inputOrigin1 = null;
        private Tuple<PointF, double> _inputOrigin2 = null;

        private bool _passed = false;
        private string _errMessage = null;
        private Image<Bgr, byte> _outputImage = null;

        public bool Run()
        {
            _outputImage = null;
            _passed = false;
            if (_inputImage == null || _inputImage.Width == 0)
            {
                _errMessage = "Lỗi InputImage = null";
                return false;
            }
            if (_affineMode == null)
            {
                _errMessage = "Lỗi AffineMode = null";
                return false;
            }
            if (_interpolation == null)
            {
                _errMessage = "Lỗi Interpolation = null";
                return false;
            }
            try
            {
                Inter inter = new Inter();
                switch(_interpolation)
                {
                    case RTCConst.cAffineImage.AffineImage_Inter_Bicubic:
                        inter = Inter.Cubic;
                        break;
                    case RTCConst.cAffineImage.AffineImage_Inter_Linear:
                        inter = Inter.Linear;
                        break;
                    case RTCConst.cAffineImage.AffineImage_Inter_Nearest:
                        inter = Inter.Nearest;
                        break;
                    case RTCConst.cAffineImage.AffineImage_Inter_Area:
                        inter = Inter.Area;
                        break;
                    case RTCConst.cAffineImage.AffineImage_Inter_Lanczos4:
                        inter = Inter.Lanczos4;
                        break;
                    case RTCConst.cAffineImage.AffineImage_Inter_LinearExact:
                        inter = Inter.LinearExact;
                        break;
                    case RTCConst.cAffineImage.AffineImage_Inter_NearestExact:
                        inter = Inter.NearestExact;
                        break;
                }
                switch(_affineMode)
                {
                    case RTCConst.cAffineImage.AffineImage_Mode_Rotation:
                        _outputImage = Rotate(_inputImage, _inputX, _inputY, _inputAngle, inter);
                        break;
                    case RTCConst.cAffineImage.AffineImage_Mode_RotationAboutCenter:
                        _outputImage = Rotate(_inputImage, _inputImage.Width / 2, _inputImage.Height / 2, _inputAngle, inter);
                        break;
                    case RTCConst.cAffineImage.AffineImage_Mode_Translation:
                        _outputImage = TranslateAndRotate(_inputImage, 0, 0, _inputTransX, _inputTransY, 0, inter);
                        break;
                    case RTCConst.cAffineImage.AffineImage_Mode_TranslationAndRotation:
                        _outputImage = TranslateAndRotate(_inputImage, _inputX, _inputY, _inputTransX, _inputTransY, _inputAngle, inter);
                        break;
                    case RTCConst.cAffineImage.AffineImage_Mode_RigidTransform:
                        _outputImage = RigidTransform(_inputImage, _inputOrigin1, _inputOrigin2, inter);
                        break;
                }
            }
            catch (Exception ex)
            {
                _errMessage = ex.Message + "\n" + ex.StackTrace;
                return false;
            }
            return true;
        }

        private Image<Bgr, byte> TranslateAndRotate(Image<Bgr,byte> img, double x, double y,double transX, double transY, double angle, Inter inter)
        {
            Image<Bgr, byte> transformedImg = new Image<Bgr, byte>(img.Width, img.Height);
            //PointF center = new PointF((float)x, (float)y);
            //Mat rotationMatrix = new Mat();
            //CvInvoke.GetRotationMatrix2D(center, angle, 1.0, rotationMatrix);
            //SetDoubleValue(ref rotationMatrix, 0, 2, GetDoubleValue(rotationMatrix, 0, 2) + transX);
            //SetDoubleValue(ref rotationMatrix, 1, 2, GetDoubleValue(rotationMatrix, 1, 2) + transY);
            //transformedImg = img.WarpAffine(rotationMatrix, inter, Warp.Default, BorderType.Constant, new Bgr(0, 0, 0));
            double theta = -angle * Math.PI / 180.0;
            double cosTheta = Math.Cos(theta);
            double sinTheta = Math.Sin(theta);
            //Ma tran tinh tien
            Mat transMatrix = new Mat();
            CvInvoke.GetRotationMatrix2D(new PointF(0, 0), 0, 1.0, transMatrix);
            SetDoubleValue(ref transMatrix, 0, 0, 1);
            SetDoubleValue(ref transMatrix, 0, 1, 0);
            SetDoubleValue(ref transMatrix, 0, 2, transX);
            SetDoubleValue(ref transMatrix, 1, 0, 0);
            SetDoubleValue(ref transMatrix, 1, 1, 1);
            SetDoubleValue(ref transMatrix, 1, 2, transY);

            //Ma tran xoay
            Mat rotationMatrix = new Mat();
            CvInvoke.GetRotationMatrix2D(new PointF(0, 0), 0, 1.0, rotationMatrix);
            SetDoubleValue(ref rotationMatrix, 0, 0, cosTheta);
            SetDoubleValue(ref rotationMatrix, 0, 1, -sinTheta);
            SetDoubleValue(ref rotationMatrix, 0, 2, (x * (1 - cosTheta) + y * sinTheta));
            SetDoubleValue(ref rotationMatrix, 1, 0, sinTheta);
            SetDoubleValue(ref rotationMatrix, 1, 1, cosTheta);
            SetDoubleValue(ref rotationMatrix, 1, 2, y * (1 - cosTheta) - x * sinTheta);

            Mat matRT = new Mat();
            CvInvoke.GetRotationMatrix2D(new PointF(0, 0), 0, 1.0, matRT);
            SetDoubleValue(ref matRT, 0, 0, GetDoubleValue(rotationMatrix, 0, 0) * GetDoubleValue(transMatrix, 0, 0) + GetDoubleValue(rotationMatrix, 0, 1) * GetDoubleValue(transMatrix, 1, 0));
            SetDoubleValue(ref matRT, 0, 1, GetDoubleValue(rotationMatrix, 0, 0) * GetDoubleValue(transMatrix, 0, 1) + GetDoubleValue(rotationMatrix, 0, 1) * GetDoubleValue(transMatrix, 1, 1));
            SetDoubleValue(ref matRT, 0, 2, GetDoubleValue(rotationMatrix, 0, 0) * GetDoubleValue(transMatrix, 0, 2) + GetDoubleValue(rotationMatrix, 0, 1) * GetDoubleValue(transMatrix, 1, 2) + GetDoubleValue(rotationMatrix, 0, 2));
            SetDoubleValue(ref matRT, 1, 0, GetDoubleValue(rotationMatrix, 1, 0) * GetDoubleValue(transMatrix, 0, 0) + GetDoubleValue(rotationMatrix, 1, 1) * GetDoubleValue(transMatrix, 1, 0));
            SetDoubleValue(ref matRT, 1, 1, GetDoubleValue(rotationMatrix, 1, 0) * GetDoubleValue(transMatrix, 0, 1) + GetDoubleValue(rotationMatrix, 1, 1) * GetDoubleValue(transMatrix, 1, 1));
            SetDoubleValue(ref matRT, 1, 2, GetDoubleValue(rotationMatrix, 1, 0) * GetDoubleValue(transMatrix, 0, 2) + GetDoubleValue(rotationMatrix, 1, 1) * GetDoubleValue(transMatrix, 1, 2) + GetDoubleValue(rotationMatrix, 1, 2));
            transformedImg = img.WarpAffine(matRT, inter, Warp.Default, BorderType.Constant, new Bgr(0, 0, 0));
            return transformedImg;
        }
        private Image<Bgr, byte> RigidTransform(Image<Bgr, byte> img, Tuple<PointF, double> Origin1,  Tuple<PointF, double> Origin2, Inter inter)
        {
            Image<Bgr, byte> transformedImg = new Image<Bgr, byte>(img.Width, img.Height);
            double angle = Origin2.Item2 - Origin1.Item2;
            double transX = Origin2.Item1.X - Origin1.Item1.X;
            double transY = Origin2.Item1.Y - Origin1.Item1.Y;
            Mat rotationMatrix = new Mat();
            CvInvoke.GetRotationMatrix2D(new PointF(0,0), angle, 1.0, rotationMatrix);
            SetDoubleValue(ref rotationMatrix, 0, 2, GetDoubleValue(rotationMatrix, 0, 2) + transX);
            SetDoubleValue(ref rotationMatrix, 1, 2, GetDoubleValue(rotationMatrix, 1, 2) + transY);
            transformedImg = img.WarpAffine(rotationMatrix, inter, Warp.FillOutliers, BorderType.Constant, new Bgr(0, 0, 0));

            return transformedImg;
        }
        private Image<Bgr, byte> Rotate(Image<Bgr, byte> img, double x, double y, double angle, Inter inter)
        {
            Image<Bgr, byte> transformedImg = new Image<Bgr, byte>(img.Width, img.Height);
            PointF center = new PointF((float)x, (float)y);
            Mat rotationMatrix = new Mat();
            CvInvoke.GetRotationMatrix2D(center, angle, 1.0, rotationMatrix);
            transformedImg = img.WarpAffine(rotationMatrix, inter, Warp.Default, BorderType.Constant, new Bgr(0, 0, 0));
            return transformedImg;
        }
        private double GetDoubleValue(Mat mat, int row, int col)
        {
            var value = new double[1];
            Marshal.Copy(mat.DataPointer + (row * mat.Cols + col) * mat.ElementSize, value, 0, 1);
            return value[0];
        }
        private void SetDoubleValue(ref Mat mat, int row, int col, double value)
        {
            var target = new[] { value };
            Marshal.Copy(target, 0, mat.DataPointer + (row * mat.Cols + col) * mat.ElementSize, 1);
        }
    }
}
