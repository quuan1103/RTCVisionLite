using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using RTCBase.Drawing;

namespace NewPattern
{
    public class NewPattern
    {
        public Image<Gray, byte> InputImage
        {
            set { _inputImage = value; }
        }
        public Bitmap InputTrain
        {
            set { _inputTrain = value; }
        }
        public List<RTCRectangle> ROITrain
        {
            set { _ROITrain = value; }
        }
        public List<RTCRectangle> ROISearch
        {
            set { _ROISearch = value; }
        }
        public Tuple<PointF, double> ToolOrigin
        {
            set { _toolOrigin = value; }
        }
        public PointF[] InSetOrigin
        {
            set { _inSetOrigin = value; }
        }
        public Tuple<int, int> AngleRangePattern
        {
            set { _angleRangePattern = value; }
        }
        public double MinSearchScore
        {
            set { m_dScore = value; }
        }
        public int MaxNumberToSearch
        {
            set { m_iMaxPos = value; }
        }
        public int MinReduceArea
        {
            set { iMinReduceArea = value; }
        }
        public string Accuracy
        {
            set { _accuracy = value; }
        }
        public double MaxOverLap
        {
            set { m_dMaxOverlap = value; }
        }
        public string PossibleRotations
        {
            set { _possibleRotations = value; }
        }
        public Tuple<int, int> NumberToFindRange
        {
            set { _numberToFindRange = value; }
        }
        public double MinScorePass
        {
            set { _minScorePass = value; }
        }
        public bool IsShowImageResult
        {
            set { _isShowImageResult = value; }
        }


        public bool Trained
        {
            get { return _trained; }
        }
        public Bitmap OutputImageShow
        {
            get { return _outputImageShow; }
        }
        public List<Tuple<PointF, double>> OutputOriginList
        {
            get { return _outputOriginList; }
        }
        public Tuple<PointF, double> OutputBestOrigin
        {
            get { return _outputBestOrigin; }
        }
        public Tuple<PointF, double> OutputMasterOrigin
        {
            get { return _outputMasterOrigin; }
        }
        public List<double> OutPutScoreList
        {
            get { return _outputScoreList; }
        }
        public int NumberFound
        {
            get { return _numberFound; }
        }
        public bool Passed
        {
            get { return _passed; }
        }
        public string ErrMessage
        {
            get { return _errMessage; }
        }


        private const double VISION_TOLERANCE = 0.01;
        private const double D2R = Math.PI / 180.0;
        private const double R2D = 180.0 / Math.PI;
        private const int MATCH_CANDIDATE_NUM = 3;



        private Image<Gray, byte> _inputImage = null;
        private Bitmap _inputTrain = null;

        private List<RTCRectangle> _ROITrain = null;
        private List<RTCRectangle> _ROISearch = null;
        private Tuple<PointF, double> _toolOrigin = null;
        private PointF[] _inSetOrigin = null;
        private Mat matSrc = null;
        private Mat matDst = null;
        private s_TemplData templData = null;
        private double iMinReduceArea = 256;
        private Tuple<int, int> _angleRangePattern = null;
        private double m_dScore = -1;
        private int m_iMaxPos = -1;
        private string _accuracy = null;
        private bool m_bStopLayer1 = true;
        private double m_dMaxOverlap = -1;
        private string _possibleRotations = null;
        private Tuple<int, int> _numberToFindRange = null;
        private double _minScorePass = 0;
        //private bool bSubPixelEstimation = true;
        private bool bAccTest = true;
        private bool _isShowImageResult = false;


        private Bitmap _outputImageShow = null;
        private bool _trained = false;
        private List<Tuple<PointF, double>> _outputOriginList = null;
        private Tuple<PointF, double> _outputBestOrigin = null;
        private Tuple<PointF, double> _outputMasterOrigin = null;
        private List<double> _outputScoreList = null;
        private int _numberFound = 0;
        private bool _passed = false;
        private string _errMessage = null;

        //private Mat matShow = null;
        private class s_TemplData
        {
            public VectorOfMat vecPyramid;

            public List<bool> vecResultEqual1;
            public List<double> vecTemplNorm;
            public List<double> vecInvArea;
            public List<MCvScalar> vecTemplMean;
            public bool bIsPatternLearned;
            public int iBorderColor;
            public void clear()
            {
                vecPyramid = new VectorOfMat();
            }

            public s_TemplData()
            {
                bIsPatternLearned = false;
                vecPyramid = new VectorOfMat();
                bIsPatternLearned = false;
                iBorderColor = 0;
            }
        }

        private class s_MatchParameter
        {
            public PointF pt;
            public PointF ptLT;
            public double dMatchScore;
            public double dMatchAngle;
            public Rectangle rectRoi;
            public double dAngleStart;
            public double dAngleEnd;
            public RotatedRect rectR;
            public Rectangle rectBounding;
            public bool bDelete;
            public double[,] vecResult;
            public int iMaxScoreIndex;
            public bool bPosOnBorder;
            public PointF ptSubPixel;
            public double dNewAngle;

            public s_MatchParameter(PointF ptMinMax, double dScore, double dAngle)
            {
                pt = ptMinMax;
                dMatchScore = dScore;
                dMatchAngle = dAngle;

                bDelete = false;
                dNewAngle = 0;

                bPosOnBorder = false;
                vecResult = new double[3, 3];
                iMaxScoreIndex = 0;
                ptSubPixel = new Point();

                rectRoi = new Rectangle();
                rectBounding = new Rectangle();
                rectR = new RotatedRect();
                dAngleStart = 0;
                dAngleEnd = 0;

            }
            public s_MatchParameter()
            {
                dMatchAngle = 0;
                dMatchScore = 0;
            }
        }

        private class s_SingleTargetMatch
        {
            public PointF ptLT, ptRT, ptRB, ptLB, ptCenter;
            public double dMatchedAngle;
            public double dMatchScore;
        }

        private class s_BlockMax
        {
            public class Block
            {
                public Rectangle rect;
                public double dMax;
                public Point ptMaxLoc;
                public Block()
                { }
                public Block(Rectangle rect_, double dMax_, Point ptMaxLoc_)
                {
                    rect = rect_;
                    dMax = dMax_;
                    ptMaxLoc = ptMaxLoc_;
                }
            }
            public s_BlockMax() { }
            public List<Block> vecBlock;
            public Mat matSrc;
            public s_BlockMax(Mat matSrc_, Size sizeTemplate)
            {
                matSrc = matSrc_;
                int iBlockW = sizeTemplate.Width * 2;
                int iBlockH = sizeTemplate.Height * 2;
                int iCol = matSrc.Cols / iBlockW;
                bool bHResidue = matSrc.Cols % iBlockW != 0;
                int iRow = matSrc.Rows / iBlockH;
                bool bVResidue = matSrc.Rows % iBlockH != 0;
                if (iCol == 0 || iRow == 0)
                {
                    vecBlock.Clear();
                    return;
                }
                vecBlock = new List<Block>(iCol * iRow);
                int iCount = 0;
                for (int y = 0; y < iRow; y++)
                {
                    for (int x = 0; x < iCol; x++)
                    {
                        Rectangle rectBlock = new Rectangle(x * iBlockW, y * iBlockH, iBlockW, iBlockH);
                        vecBlock[iCount].rect = rectBlock;
                        Mat subMat = new Mat(matSrc, rectBlock);
                        Point minLoc = new Point(), maxLoc = new Point();
                        double minVal = 0, maxVal = 0;
                        CvInvoke.MinMaxLoc(subMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                        vecBlock[iCount].dMax = maxVal;
                        vecBlock[iCount].ptMaxLoc = new Point(maxLoc.X + rectBlock.X, maxLoc.Y + rectBlock.Y);
                        iCount++;
                    }
                }
                if (bHResidue && bVResidue)
                {
                    Rectangle rectRight = new Rectangle(iCol * iBlockW, 0, matSrc.Cols - iCol * iBlockW, matSrc.Rows);
                    Block blockRight = new Block();
                    blockRight.rect = rectRight;
                    Mat subMat = new Mat(matSrc, rectRight);
                    Point minLoc = new Point(), maxLoc = new Point();
                    double minVal = 0, maxVal = 0;
                    CvInvoke.MinMaxLoc(subMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                    vecBlock[iCount].dMax = maxVal;
                    vecBlock[iCount].ptMaxLoc = new Point(maxLoc.X + rectRight.X, maxLoc.Y + rectRight.Y);
                    vecBlock.Add(blockRight);

                    Rectangle rectBottom = new Rectangle(0, iRow * iBlockH, iCol * iBlockW, matSrc.Rows - iRow * iBlockH);
                    Block blockBottom = new Block();
                    blockBottom.rect = rectBottom;
                    subMat = new Mat(matSrc, rectBottom);
                    CvInvoke.MinMaxLoc(subMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                    vecBlock[iCount].dMax = maxVal;
                    vecBlock[iCount].ptMaxLoc = new Point(maxLoc.X + rectBottom.X, maxLoc.Y + rectBottom.Y);
                    vecBlock.Add(blockBottom);
                }
                else if (bHResidue)
                {
                    Rectangle rectRight = new Rectangle(iCol * iBlockW, 0, matSrc.Cols - iCol * iBlockW, matSrc.Rows);
                    Block blockRight = new Block();
                    blockRight.rect = rectRight;
                    Mat subMat = new Mat(matSrc, rectRight);
                    Point minLoc = new Point(), maxLoc = new Point();
                    double minVal = 0, maxVal = 0;
                    CvInvoke.MinMaxLoc(subMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                    vecBlock[iCount].dMax = maxVal;
                    vecBlock[iCount].ptMaxLoc = new Point(maxLoc.X + rectRight.X, maxLoc.Y + rectRight.Y);
                    vecBlock.Add(blockRight);
                }
                else
                {
                    Rectangle rectBottom = new Rectangle(0, iRow * iBlockH, iCol * iBlockW, matSrc.Rows - iRow * iBlockH);
                    Block blockBottom = new Block();
                    blockBottom.rect = rectBottom;
                    Mat subMat = new Mat(matSrc, rectBottom);
                    Point minLoc = new Point(), maxLoc = new Point();
                    double minVal = 0, maxVal = 0;
                    CvInvoke.MinMaxLoc(subMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                    vecBlock[iCount].dMax = maxVal;
                    vecBlock[iCount].ptMaxLoc = new Point(maxLoc.X + rectBottom.X, maxLoc.Y + rectBottom.Y);
                    vecBlock.Add(blockBottom);
                }
            }
            public void UpdateMax(Rectangle rectIgnore)
            {
                if (vecBlock.Count == 0)
                {
                    return;
                }
                int iSize = vecBlock.Count;
                for (int i = 0; i < iSize; i++)
                {
                    Rectangle rectIntersec = Rectangle.Intersect(rectIgnore, vecBlock[i].rect);
                    if (rectIntersec.Width == 0 && rectIntersec.Height == 0)
                        continue;
                    Mat subMat = new Mat(matSrc, vecBlock[i].rect);
                    Point minLoc = new Point(), maxLoc = new Point();
                    double minVal = 0, maxVal = 0;
                    CvInvoke.MinMaxLoc(subMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                    vecBlock[i].dMax = maxVal;
                    vecBlock[i].ptMaxLoc = new Point(maxLoc.X + vecBlock[i].rect.X, maxLoc.Y + vecBlock[i].rect.Y);
                }
            }
            public void GetMaxValueLoc(out double dMax, out Point ptMaxLoc)
            {
                int iSize = vecBlock.Count;
                dMax = 0;
                ptMaxLoc = new Point();
                if (iSize == 0)
                {
                    Mat subMat = matSrc;
                    Point minLoc = new Point(), maxLoc = new Point();
                    double minVal = 0, maxVal = 0;
                    CvInvoke.MinMaxLoc(subMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                    dMax = maxVal;
                    ptMaxLoc = maxLoc;
                    return;
                }
                int iIndex = 0;
                dMax = vecBlock[0].dMax;
                for (int i = 1; i < iSize; i++)
                {
                    if (vecBlock[i].dMax >= dMax)
                    {
                        iIndex = i;
                        dMax = vecBlock[i].dMax;
                    }
                }
                ptMaxLoc = vecBlock[iIndex].ptMaxLoc;
            }
        }

        public void LearnPattern()
        {
            //matDst = new Mat();
            matDst = _inputTrain.ToMat();
            templData = new s_TemplData();
            int iTopLayer = GetTopLayer(matDst, (int)Math.Sqrt(iMinReduceArea));

            CvInvoke.BuildPyramid(matDst, templData.vecPyramid, iTopLayer);

            templData.iBorderColor = CvInvoke.Mean(matDst).V0 < 128 ? 255 : 0;
            templData.bIsPatternLearned = true;

        }
        public bool Train()
        {
            if (_inputImage == null)
            {
                _errMessage = "Train : InputImage = null";
                return false;
            }
            if (_ROITrain == null)
            {
                _errMessage = "Train: ROITrain = null";
                return false;
            }
            matSrc = _inputImage.Mat;
            matDst = new Mat();
            templData = new s_TemplData();
            Image<Bgr, byte> showTrain = matSrc.ToImage<Bgr, byte>();

            for (int i = 0; i < _ROITrain.Count; i++)
            {
                PointF ptCenter = new PointF((float)_ROITrain[i].Center.X, (float)_ROITrain[i].Center.Y);
                double angle = _ROITrain[i].Phi * R2D;
                Mat matR = new Mat();
                CvInvoke.GetRotationMatrix2D(ptCenter, angle, 1, matR);

                float fTranslationX = (float)(_ROITrain[i].Width - 1) / 2.0f - ptCenter.X;
                float fTranslationY = (float)(_ROITrain[i].Height - 1) / 2.0f - ptCenter.Y;

                double gValue = GetDoubleValue(matR, 0, 2);
                SetDoubleValue(ref matR, 0, 2, gValue + fTranslationX);
                gValue = GetDoubleValue(matR, 1, 2);
                SetDoubleValue(ref matR, 1, 2, gValue + fTranslationY);

                Size sizeROI = new Size((int)Math.Round(_ROITrain[i].Width), (int)Math.Round(_ROITrain[i].Height));
                CvInvoke.WarpAffine(matSrc, matDst, matR, sizeROI, Inter.Cubic, Warp.Default, BorderType.Replicate);

                int iTopLayer = GetTopLayer(matDst, (int)Math.Sqrt(iMinReduceArea));

                CvInvoke.BuildPyramid(matDst, templData.vecPyramid, iTopLayer);

                templData.iBorderColor = CvInvoke.Mean(matDst).V0 < 128 ? 255 : 0;
                templData.bIsPatternLearned = true;
                _trained = true;
                GetRectangleVertices(_ROITrain[i], out PointF[] inPointROI);
                double lLine = (_ROITrain[i].Width > _ROITrain[i].Height) ? _ROITrain[i].Width : _ROITrain[i].Height;
                double xP1 = ptCenter.X + lLine * Math.Cos(0);
                double yP1 = ptCenter.Y - lLine * Math.Sin(0);
                double xP2 = ptCenter.X + lLine * Math.Cos(0 + Math.PI / 2);
                double yP2 = ptCenter.Y - lLine * Math.Sin(0 + Math.PI / 2);
                CvInvoke.Circle(showTrain, Point.Round(ptCenter), 2, new MCvScalar(0, 0, 255), 1);
                CvInvoke.ArrowedLine(showTrain, new Point((int)ptCenter.X, (int)ptCenter.Y), new Point((int)xP1, (int)yP1), new MCvScalar(0, 255, 0), 1);
                CvInvoke.ArrowedLine(showTrain, new Point((int)ptCenter.X, (int)ptCenter.Y), new Point((int)xP2, (int)yP2), new MCvScalar(113, 184, 248), 1);

                _outputMasterOrigin = new Tuple<PointF, double>(ptCenter, angle);
            }
            _outputImageShow = showTrain.ToBitmap();
            TrainTemplate(templData.vecPyramid[0]);
            showTrain.Dispose();
            return true;
        }

        public bool Run()
        {
            if (_inputImage == null)
            {
                _errMessage = "Run : InputImage = null";
                return false;
            }
            //if(templData.bIsPatternLearned == false)
            //{
            //    _errMessage = "Run : Pattern has not been trained yet";
            //    return false;
            //}
            if (m_dScore == -1)
            {
                _errMessage = "Run : MinSearchScore = null";
                return false;
            }
            if (m_iMaxPos == -1)
            {
                _errMessage = "Run : MaxNumberToSearch = null";
                return false;
            }
            if (m_dMaxOverlap == -1)
            {
                _errMessage = "Run : MaxOverLap = null";
                return false;
            }
            if (_possibleRotations == null)
            {
                _errMessage = "Run : PossibleRotations = null";
                return false;
            }
            if (_numberToFindRange == null)
            {
                _errMessage = "Run : NumberToFindRange = null";
                return false;
            }
            if (_accuracy == null)
            {
                _errMessage = "Run : Accuracy = null";
                return false;
            }

            if (_accuracy == "Low")
                m_bStopLayer1 = true;
            else if (_accuracy == "High")
                m_bStopLayer1 = false;
            _outputOriginList = new List<Tuple<PointF, double>>();
            _outputScoreList = new List<double>();
            _outputBestOrigin = Tuple.Create<PointF, double>(new PointF(0, 0), 0);
            _numberFound = 0;
            _passed = false;
            //_outputImageShow.Dispose();
            Rectangle recCrop = new Rectangle();
            PointF[] points = new PointF[4];
            if (_inSetOrigin != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    points[i] = ConvertCoordinatesToOrigin(_toolOrigin, _inSetOrigin[i]);
                }
                Point pv1 = new Point((int)Math.Floor(points[0].X), (int)Math.Floor(points[0].Y));
                Point pv2 = new Point((int)Math.Floor(points[1].X), (int)Math.Floor(points[1].Y));
                Point pv3 = new Point((int)Math.Floor(points[2].X), (int)Math.Floor(points[2].Y));
                Point pv4 = new Point((int)Math.Floor(points[3].X), (int)Math.Floor(points[3].Y));
                Point[] p = { pv1, pv2, pv3, pv4 };

                recCrop = CvInvoke.BoundingRectangle(p);
                _inputImage.ROI = recCrop;
                matSrc = _inputImage.Copy().Mat;
                _inputImage.ROI = new Rectangle();
            }
            else
                matSrc = _inputImage.Mat;


            Image<Bgr, byte> showImage = null;
            //matShow = matSrc.Clone();
            int iTopLayer = GetTopLayer(matDst, (int)Math.Sqrt(iMinReduceArea));
            VectorOfMat vecMatSrcPyr = new VectorOfMat();
            CvInvoke.BuildPyramid(matSrc, vecMatSrcPyr, iTopLayer);

            s_TemplData pTemplData = templData;
            double tan = 2 / (double)(Math.Max(pTemplData.vecPyramid[iTopLayer].Cols, pTemplData.vecPyramid[iTopLayer].Rows));
            double dAngleStep = Math.Atan(tan) * 180 / (Math.PI);

            List<double> vecAngles = new List<double>();
            if (_possibleRotations == RTCConst.cCorrelationPatternTool.PossibleRotations_NoRotation)
            {
                vecAngles.Add(0);
            }
            if (_possibleRotations == RTCConst.cCorrelationPatternTool.PossibleRotations_Full360DegreesRange)
            {
                for (double dAngle = 0; dAngle < 360 + dAngleStep; dAngle += dAngleStep)
                    vecAngles.Add(dAngle);
            }
            if (_possibleRotations == RTCConst.cCorrelationPatternTool.PossibleRotations_AFewDegrees)
            {
                if (_angleRangePattern == null)
                {
                    _errMessage = "Run : AngleRangePattern = null";
                    return false;
                }
                for (double dAngle = _angleRangePattern.Item1; dAngle < _angleRangePattern.Item2 + dAngleStep; dAngle += dAngleStep)
                    vecAngles.Add(dAngle);
            }
            if (_possibleRotations == RTCConst.cCorrelationPatternTool.PossibleRotations_0And180AFewDegrees)
            {
                if (_angleRangePattern == null)
                {
                    _errMessage = "Run : AngleRangePattern = null";
                    return false;
                }
                for (double dAngle = _angleRangePattern.Item1; dAngle < _angleRangePattern.Item2 + dAngleStep; dAngle += dAngleStep)
                    vecAngles.Add(dAngle);
                for (double dAngle = _angleRangePattern.Item1 + 180; dAngle < _angleRangePattern.Item2 + dAngleStep + 180; dAngle += dAngleStep)
                    vecAngles.Add(dAngle);
            }

            int iTopSrcW = vecMatSrcPyr[iTopLayer].Cols, iTopSrcH = vecMatSrcPyr[iTopLayer].Rows;
            PointF ptCenter = new PointF((iTopSrcW - 1) / 2.0f, (iTopSrcH - 1) / 2.0f);
            int iSize = (int)vecAngles.Count;

            List<s_MatchParameter> vecMatchParameter = new List<s_MatchParameter>();
            //double LayerScore = m_dScore * Math.Pow(0.9, iTopLayer + 1);
            List<double> vecLayerScore = new List<double>(iTopLayer + 1);
            for (int i = 0; i <= iTopLayer; i++)
            {
                vecLayerScore.Add(m_dScore);
            }
            for (int iLayer = 1; iLayer <= iTopLayer; iLayer++)
                vecLayerScore[iLayer] = vecLayerScore[iLayer - 1] * 0.95;

            //for (int i = 0; i < iSize; i++)
            Parallel.For(0, vecAngles.Count, i =>
            {
                // Các Mat tạo trong vòng lặp phải được giải phóng
                using (Mat matRotatedSrc = new Mat())
                {
                    Mat matR = new Mat();
                    Mat matResult = new Mat();
                    CvInvoke.GetRotationMatrix2D(ptCenter, vecAngles[i], 1, matR);
                    Size sizeBest = GetBestRotationSize(vecMatSrcPyr[iTopLayer].Size, pTemplData.vecPyramid[iTopLayer].Size, vecAngles[i]);
                    float fTranslationX = (sizeBest.Width - 1) / 2.0f - ptCenter.X;
                    float fTranslationY = (sizeBest.Height - 1) / 2.0f - ptCenter.Y;

                    double gValue = GetDoubleValue(matR, 0, 2);
                    SetDoubleValue(ref matR, 0, 2, gValue + fTranslationX);
                    gValue = GetDoubleValue(matR, 1, 2);
                    SetDoubleValue(ref matR, 1, 2, gValue + fTranslationY);

                    CvInvoke.WarpAffine(vecMatSrcPyr[iTopLayer], matRotatedSrc, matR, sizeBest, Inter.Cubic, Warp.Default, BorderType.Replicate);
                    CvInvoke.MatchTemplate(matRotatedSrc, pTemplData.vecPyramid[iTopLayer], matResult, TemplateMatchingType.CcoeffNormed);

                    double dMinVal = 0, dMaxVal = 0;
                    Point ptMinLoc = new Point(), ptMaxLoc = new Point();
                    CvInvoke.MinMaxLoc(matResult, ref dMinVal, ref dMaxVal, ref ptMinLoc, ref ptMaxLoc);

                    if (dMaxVal >= vecLayerScore[iTopLayer])
                    {
                        lock (vecMatchParameter)
                        {
                            vecMatchParameter.Add(new s_MatchParameter(new PointF(ptMaxLoc.X - fTranslationX, ptMaxLoc.Y - fTranslationY), dMaxVal, vecAngles[i]));
                            for (int j = 0; j < m_iMaxPos + MATCH_CANDIDATE_NUM - 1; j++)
                            {
                                ptMaxLoc = GetNextMaxLoc(ref matResult, ptMaxLoc, pTemplData.vecPyramid[iTopLayer].Size, ref dMaxVal, m_dMaxOverlap);
                                if (dMaxVal < vecLayerScore[iTopLayer])
                                    break;
                                vecMatchParameter.Add(new s_MatchParameter(new PointF(ptMaxLoc.X - fTranslationX, ptMaxLoc.Y - fTranslationY), dMaxVal, vecAngles[i]));
                            }
                        }
                    }
                    matResult.Dispose();
                    matRotatedSrc.Dispose();
                }
            });
            vecMatchParameter.Sort((x, y) => y.dMatchScore.CompareTo(x.dMatchScore));
            int iMatchSize = (int)vecMatchParameter.Count;
            int iDstW = pTemplData.vecPyramid[iTopLayer].Cols, iDstH = pTemplData.vecPyramid[iTopLayer].Rows;
            int iStopLayer = m_bStopLayer1 ? 1 : 0;

            List<s_MatchParameter> vecAllResult = new List<s_MatchParameter>();
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            for (int i = 0; i < (int)vecMatchParameter.Count; i++)
            //Parallel.For(0, vecMatchParameter.Count, i =>
            {
                double dRAngle = -vecMatchParameter[i].dMatchAngle * D2R;
                PointF ptLT = ptRotatePt2f(vecMatchParameter[i].pt, ptCenter, dRAngle);

                dAngleStep = Math.Atan(2.0 / (double)Math.Max(iDstW, iDstH)) * R2D;
                vecMatchParameter[i].dAngleStart = vecMatchParameter[i].dMatchAngle - dAngleStep;
                vecMatchParameter[i].dAngleEnd = vecMatchParameter[i].dMatchAngle + dAngleStep;

                if (iTopLayer <= iStopLayer)
                {
                    vecMatchParameter[i].pt = new PointF(ptLT.X * ((iTopLayer == 0) ? 1 : 2), ptLT.Y * ((iTopLayer == 0) ? 1 : 2));
                    vecAllResult.Add(vecMatchParameter[i]);
                }
                else
                {
                    for (int iLayer = iTopLayer - 1; iLayer >= iStopLayer; iLayer--)
                    {
                        if (m_bStopLayer1)
                        {
                            if (iLayer == 1)
                                dAngleStep = 0.05;
                            else if (iLayer == 2)
                                dAngleStep = 2;
                            else
                                dAngleStep = Math.Atan(2.0 / (double)Math.Max(pTemplData.vecPyramid[iLayer].Cols, pTemplData.vecPyramid[iLayer].Rows));
                        }
                        else
                        {
                            if (iLayer == 1)
                                dAngleStep = 1;
                            else if (iLayer == 0)
                                dAngleStep = 0.05;
                            else
                                dAngleStep = Math.Atan(2.0 / (double)Math.Max(pTemplData.vecPyramid[iLayer].Cols, pTemplData.vecPyramid[iLayer].Rows));
                        }
                        if (iLayer == 1)
                            dAngleStep = 2;
                        else if (iLayer == 0)
                            dAngleStep = 0.05;
                        else
                            dAngleStep = Math.Atan(2.0 / (double)Math.Max(pTemplData.vecPyramid[iLayer].Cols, pTemplData.vecPyramid[iLayer].Rows)) * R2D;
                        vecAngles = new List<double>(5);
                        double dMatchedAngle = vecMatchParameter[i].dMatchAngle;

                        if (iLayer >= 2)
                        {
                            for (double j = -2; j <= 2; j = j + 1)
                                vecAngles.Add(dMatchedAngle + dAngleStep * j * 0.5);
                        }
                        else
                            for (double j = -2; j <= 2; j = j + 1)
                                vecAngles.Add(dMatchedAngle + dAngleStep * j);

                        //////////////////////////////////////////////////////////////

                        PointF ptSrcCenter = new PointF((vecMatSrcPyr[iLayer].Cols - 1) / 2.0f, (vecMatSrcPyr[iLayer].Rows - 1) / 2.0f);
                        iSize = vecAngles.Count;

                        List<s_MatchParameter> vecNewMatchParameter = new List<s_MatchParameter>(iSize);
                        int iMaxScoreIndex = 0;
                        double dBigValue = -1;
                        for (int idx = 0; idx < iSize; idx++)
                        {
                            Mat matResult = new Mat(), matRotatedSrc = new Mat();
                            double dMaxValue = 0, dMinValue = 0;
                            Point ptMaxLoc = new Point(), ptMinLoc = new Point();
                            float ptLTX = ptLT.X * 2;
                            float ptLTY = ptLT.Y * 2;
                            GetRotatedROI(vecMatSrcPyr[iLayer], pTemplData.vecPyramid[iLayer].Size, new PointF(ptLTX, ptLTY), vecAngles[idx], out matRotatedSrc);

                            CvInvoke.MatchTemplate(matRotatedSrc, pTemplData.vecPyramid[iLayer], matResult, TemplateMatchingType.CcoeffNormed);
                            CvInvoke.MinMaxLoc(matResult, ref dMinValue, ref dMaxValue, ref ptMinLoc, ref ptMaxLoc);
                            vecNewMatchParameter.Add(new s_MatchParameter(ptMaxLoc, dMaxValue, vecAngles[idx]));
                            if (vecNewMatchParameter[idx].dMatchScore > dBigValue)
                            {
                                iMaxScoreIndex = idx;
                                dBigValue = vecNewMatchParameter[idx].dMatchScore;
                            }
                            if (ptMaxLoc.X == 0 || ptMaxLoc.Y == 0 || ptMaxLoc.X == matResult.Cols - 1 || ptMaxLoc.Y == matResult.Rows - 1)
                                vecNewMatchParameter[idx].bPosOnBorder = true;
                            if (!vecNewMatchParameter[idx].bPosOnBorder)
                            {
                                //for (int y = -1; y <= 1; y++)
                                //    for (int x = -1; x <= 1; x++)
                                //        vecNewMatchParameter[idx].vecResult[x + 1, y + 1] = GetDoubleValue(matResult, ptMaxLoc.X + x, ptMaxLoc.Y + y);

                            }
                            matResult.Dispose();
                            matRotatedSrc.Dispose();
                        }
                        if (vecNewMatchParameter[iMaxScoreIndex].dMatchScore < vecLayerScore[iLayer])
                            break;
                        //if (iLayer == 1 && iMaxScoreIndex != 0 && iMaxScoreIndex != 2)
                        //{
                        //    double dNewX = 0, dNewY = 0, dNewAngle = 0;
                        //    SubPixEsimation(ref vecNewMatchParameter, ref dNewX, ref dNewY, ref dNewAngle, 0.2, iMaxScoreIndex);
                        //    //vecNewMatchParameter[iMaxScoreIndex].pt = new PointF((float)dNewX, (float)dNewY);
                        //   // vecNewMatchParameter[iMaxScoreIndex].dMatchAngle = dNewAngle;
                        //}

                        double dNewMatchAngle = vecNewMatchParameter[iMaxScoreIndex].dMatchAngle;
                        PointF ptPaddingLT = ptRotatePt2f(new PointF(ptLT.X * 2, ptLT.Y * 2), ptSrcCenter, dNewMatchAngle * D2R);
                        ptPaddingLT = new PointF(ptPaddingLT.X - 3, ptPaddingLT.Y - 3);
                        PointF pt = new PointF(vecNewMatchParameter[iMaxScoreIndex].pt.X + ptPaddingLT.X, vecNewMatchParameter[iMaxScoreIndex].pt.Y + ptPaddingLT.Y);

                        pt = ptRotatePt2f(pt, ptSrcCenter, -dNewMatchAngle * D2R);
                        if (iLayer == iStopLayer)
                        {
                            vecNewMatchParameter[iMaxScoreIndex].pt = new PointF(pt.X * (iStopLayer == 0 ? 1 : 2), pt.Y * (iStopLayer == 0 ? 1 : 2));
                            vecNewMatchParameter[iMaxScoreIndex].ptLT = pt;
                            vecAllResult.Add(vecNewMatchParameter[iMaxScoreIndex]);
                        }
                        else
                        {
                            vecMatchParameter[i].dMatchAngle = dNewMatchAngle;
                            vecMatchParameter[i].dAngleStart = vecMatchParameter[i].dMatchAngle - dAngleStep / 2;
                            vecMatchParameter[i].dAngleEnd = vecMatchParameter[i].dMatchAngle + dAngleStep / 2;
                            ptLT = pt;
                        }
                        vecNewMatchParameter.Clear();
                    }

                }
            }
            FilterWithScore(ref vecAllResult, m_dScore);
            iDstW = pTemplData.vecPyramid[iStopLayer].Cols * (iStopLayer == 0 ? 1 : 2);
            iDstH = pTemplData.vecPyramid[iStopLayer].Rows * (iStopLayer == 0 ? 1 : 2);


            for (int i = 0; i < (int)vecAllResult.Count; i++)
            {
                PointF ptLT, ptRT, ptRB, ptLB;
                double dRAngle = -vecAllResult[i].dMatchAngle * D2R;
                ptLT = vecAllResult[i].pt;
                ptRT = new PointF(ptLT.X + iDstW * (float)Math.Cos(dRAngle), ptLT.Y - iDstW * (float)Math.Sin(dRAngle));
                ptLB = new PointF(ptLT.X + iDstH * (float)Math.Sin(dRAngle), ptLT.Y + iDstH * (float)Math.Cos(dRAngle));
                ptRB = new PointF(ptRT.X + iDstH * (float)Math.Sin(dRAngle), ptRT.Y + iDstH * (float)Math.Cos(dRAngle));

                PointF ptC = new PointF((ptLT.X + ptRB.X + ptRT.X + ptLB.X) / 4, (ptLT.Y + ptRB.Y + ptRT.Y + ptLB.Y) / 4);
                PointF[] ptRect = new PointF[4] { ptLT, ptRT, ptRB, ptLB };

                RotatedRect r = CvInvoke.MinAreaRect(ptRect);

                vecAllResult[i].rectR = r;
            }
            FilterWithRotatedRect(ref vecAllResult, TemplateMatchingType.CcoeffNormed, m_dMaxOverlap);
            vecAllResult.Sort((x, y) => y.dMatchScore.CompareTo(x.dMatchScore));

            FilterWithScore(ref vecAllResult, _minScorePass);

            FilterWithNumber(ref vecAllResult, m_iMaxPos);

            int iW = pTemplData.vecPyramid[0].Cols, iH = pTemplData.vecPyramid[0].Rows;


            List<s_SingleTargetMatch> outResult = new List<s_SingleTargetMatch>();
            //showImage = matSrc.ToImage<Bgr, byte>();
            if (_isShowImageResult)
            {
                showImage = _inputImage.Convert<Bgr, byte>();
            }
            if (vecAllResult.Count > 0)
            {
                for (int i = 0; i < vecAllResult.Count; i++)
                {
                    s_SingleTargetMatch sstm = new s_SingleTargetMatch();
                    double dRAngle = -vecAllResult[i].dMatchAngle * D2R;

                    sstm.ptLT = vecAllResult[i].pt;
                    sstm.ptRT = new PointF((float)(sstm.ptLT.X + iW * Math.Cos(dRAngle)), (float)(sstm.ptLT.Y - iW * Math.Sin(dRAngle)));
                    sstm.ptLB = new PointF((float)(sstm.ptLT.X + iH * Math.Sin(dRAngle)), (float)(sstm.ptLT.Y + iH * Math.Cos(dRAngle)));
                    sstm.ptRB = new PointF((float)(sstm.ptRT.X + iH * Math.Sin(dRAngle)), (float)(sstm.ptRT.Y + iH * Math.Cos(dRAngle)));

                    sstm.ptCenter = new PointF((sstm.ptLT.X + sstm.ptRT.X + sstm.ptRB.X + sstm.ptLB.X) / 4 + recCrop.X, (sstm.ptLT.Y + sstm.ptRT.Y + sstm.ptRB.Y + sstm.ptLB.Y) / 4 + recCrop.Y);


                    sstm.dMatchedAngle = vecAllResult[i].dMatchAngle;
                    sstm.dMatchScore = vecAllResult[i].dMatchScore;

                    for (int j = 0; j < _ROITrain.Count; j++)
                    {
                        dRAngle = _ROITrain[j].Phi + dRAngle;
                        double lLine = (iW < iH) ? iW : iH;

                        double xP1 = sstm.ptCenter.X + lLine * Math.Cos(dRAngle);
                        double yP1 = sstm.ptCenter.Y - lLine * Math.Sin(dRAngle);
                        double xP2 = sstm.ptCenter.X + lLine * Math.Cos(dRAngle + Math.PI / 2);
                        double yP2 = sstm.ptCenter.Y - lLine * Math.Sin(dRAngle + Math.PI / 2);

                        outResult.Add(sstm);
                        if (_isShowImageResult)
                        {
                            CvInvoke.Circle(showImage, new Point((int)sstm.ptCenter.X, (int)sstm.ptCenter.Y), 2, new MCvScalar(0, 0, 255), 1);
                            //Hiển thị ROI
                            CvInvoke.ArrowedLine(showImage, new Point((int)sstm.ptCenter.X, (int)sstm.ptCenter.Y), new Point((int)xP1, (int)yP1), new MCvScalar(0, 255, 0), 6);
                            CvInvoke.ArrowedLine(showImage, new Point((int)sstm.ptCenter.X, (int)sstm.ptCenter.Y), new Point((int)xP2, (int)yP2), new MCvScalar(113, 184, 248), 6);

                        }

                        _outputScoreList.Add(sstm.dMatchScore);
                        _outputOriginList.Add(new Tuple<PointF, double>(sstm.ptCenter, sstm.dMatchedAngle));

                        if (i == 0)
                        {
                            //_outputBestOrigin = new Tuple<PointF, double>(sstm.ptCenter, sstm.dMatchedAngle);
                            _outputBestOrigin = Tuple.Create<PointF, double>(sstm.ptCenter, sstm.dMatchedAngle);
                        }
                    }
                }
            }
            if (_isShowImageResult)
            {
                _outputImageShow = showImage.ToBitmap();
                //showImage = _inputImage.Convert<Bgr, byte>();
            }
            _numberFound = _outputOriginList.Count;
            if (_numberFound >= _numberToFindRange.Item1 && _numberFound <= _numberToFindRange.Item2)
            {
                _passed = true;
            }
            //matSrc.Dispose();
            vecMatSrcPyr.Dispose();
            vecMatchParameter.Clear();
            vecMatchParameter = null;
            vecAllResult.Clear();
            vecAllResult = null;
            //showImage = null;
            showImage.Dispose();

            return true;
        }

        private void CCOEFF_Denominator(Mat matSrc, s_TemplData pTemplData, Mat matResult, int iLayer)
        {
            double[] q0 = null, q1 = null, q2 = null, q3 = null;
            Mat sum = new Mat();
            Mat sqsum = new Mat();
            CvInvoke.Integral(matSrc, sum, sqsum, null, DepthType.Cv64F);
            sqsum.CopyTo<double>(q0);
            q1 = q0.Skip(pTemplData.vecPyramid[iLayer].Cols).ToArray();
            q2 = q0.Skip(pTemplData.vecPyramid[iLayer].Rows * sqsum.Step / sizeof(double)).ToArray();
            q3 = q2.Skip(pTemplData.vecPyramid[iLayer].Cols).ToArray();

            double[] p0 = null, p1 = null, p2 = null, p3 = null;
            sum.CopyTo<double>(p0);
            p1 = p0.Skip(pTemplData.vecPyramid[iLayer].Cols).ToArray();
            p2 = p0.Skip(pTemplData.vecPyramid[iLayer].Rows * sum.Step / sizeof(double)).ToArray();
            p3 = p2.Skip(pTemplData.vecPyramid[iLayer].Cols).ToArray();

            int sumstep = sum != new Mat() ? sum.Step / sizeof(double) : 0;
            int sqstep = sqsum != new Mat() ? sqsum.Step / sizeof(double) : 0;

            double dTemplMean0 = pTemplData.vecTemplMean[iLayer].V0;
            double dTemplNorm = pTemplData.vecTemplNorm[iLayer];
            double dInvArea = pTemplData.vecInvArea[iLayer];

        }
        private void GetRotatedROI(Mat matSrc, Size size, PointF ptLT, double dAngle, out Mat matROI)
        {
            matROI = new Mat();
            double dAngle_radian = dAngle * D2R;
            PointF ptC = new PointF((matSrc.Cols - 1) / 2.0f, (matSrc.Rows - 1) / 2.0f);
            PointF ptLT_rotate = ptRotatePt2f(ptLT, ptC, dAngle_radian);
            Size sizePadding = new Size(size.Width + 6, size.Height + 6);

            Mat rMat = new Mat();
            CvInvoke.GetRotationMatrix2D(ptC, dAngle, 1, rMat);
            SetDoubleValue(ref rMat, 0, 2, GetDoubleValue(rMat, 0, 2) - (ptLT_rotate.X - 3));
            SetDoubleValue(ref rMat, 1, 2, GetDoubleValue(rMat, 1, 2) - (ptLT_rotate.Y - 3));

            CvInvoke.WarpAffine(matSrc, matROI, rMat, sizePadding, Inter.Cubic, Warp.Default, BorderType.Replicate);
        }
        private int GetTopLayer(Mat matTempl, int iMinDstLength)
        {
            int iTopLayer = 0;
            int iMinReduceArea = iMinDstLength * iMinDstLength;
            int iArea = matTempl.Cols * matTempl.Rows;
            while (iArea > iMinReduceArea)
            {
                iArea /= 4;
                iTopLayer++;
            }
            return iTopLayer;
        }
        private bool SubPixEsimation(ref List<s_MatchParameter> vec, ref double dNewX, ref double dNewY, ref double dNewAngle, double dAngleStep, int iMaxScoreIndex)
        {
            Mat matA = new Mat(27, 10, DepthType.Cv64F, 1);
            Mat matZ = new Mat(10, 1, DepthType.Cv64F, 1);
            Mat matS = new Mat(27, 1, DepthType.Cv64F, 1);

            double dX_maxScore = vec[iMaxScoreIndex].pt.X;
            double dY_maxScore = vec[iMaxScoreIndex].pt.Y;
            double dTheata_maxScore = vec[iMaxScoreIndex].dMatchAngle;
            int iRow = 0;

            for (int theta = 0; theta <= 2; theta++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        double dX = dX_maxScore + x;
                        double dY = dY_maxScore + y;
                        double dT = (dTheata_maxScore + (theta - 1) * dAngleStep) * D2R;

                        SetDoubleValue(ref matA, iRow, 0, dX * dX);
                        SetDoubleValue(ref matA, iRow, 1, dY * dY);
                        SetDoubleValue(ref matA, iRow, 2, dT * dT);
                        SetDoubleValue(ref matA, iRow, 3, dX * dY);
                        SetDoubleValue(ref matA, iRow, 4, dX * dT);
                        SetDoubleValue(ref matA, iRow, 5, dY * dT);
                        SetDoubleValue(ref matA, iRow, 6, dX);
                        SetDoubleValue(ref matA, iRow, 7, dY);
                        SetDoubleValue(ref matA, iRow, 8, dT);
                        SetDoubleValue(ref matA, iRow, 9, 1);
                        SetDoubleValue(ref matS, iRow, 0, vec[iMaxScoreIndex + (theta - 1)].vecResult[x + 1, y + 1]);
                        iRow++;
                    }
                }
            }
            Mat matA_t = new Mat();
            Mat matK1 = new Mat(3, 3, DepthType.Cv64F, 1);
            Mat matK2 = new Mat(3, 1, DepthType.Cv64F, 1);
            Mat matDelta = new Mat(3, 1, DepthType.Cv64F, 1);

            CvInvoke.Transpose(matA, matA_t);
            Mat matAtA = new Mat();
            CvInvoke.Gemm(matA_t, matA, 1, null, 0, matAtA);
            Mat matAtA_inv = new Mat();
            CvInvoke.Invert(matAtA, matAtA_inv, DecompMethod.Svd);
            Mat matAtS = new Mat();
            CvInvoke.Gemm(matAtA_inv, matA_t, 1, null, 0, matAtS);
            CvInvoke.Gemm(matAtS, matS, 1, null, 0, matZ);
            Mat matZ_t = new Mat();
            CvInvoke.Transpose(matZ, matZ_t);
            double[] dZ = new double[matZ_t.Cols];
            for (int i = 0; i < matZ_t.Cols; i++)
            {
                dZ[i] = GetDoubleValue(matZ_t, 0, i);
            }

            SetDoubleValue(ref matK1, 0, 0, 2 * dZ[0]);
            SetDoubleValue(ref matK1, 0, 1, dZ[3]);
            SetDoubleValue(ref matK1, 0, 2, dZ[4]);
            SetDoubleValue(ref matK1, 1, 0, dZ[3]);
            SetDoubleValue(ref matK1, 1, 1, 2 * dZ[1]);
            SetDoubleValue(ref matK1, 1, 2, dZ[5]);
            SetDoubleValue(ref matK1, 2, 0, dZ[4]);
            SetDoubleValue(ref matK1, 2, 1, dZ[5]);
            SetDoubleValue(ref matK1, 2, 2, 2 * dZ[2]);

            SetDoubleValue(ref matK2, 0, 0, -dZ[6]);
            SetDoubleValue(ref matK2, 1, 0, -dZ[7]);
            SetDoubleValue(ref matK2, 2, 0, -dZ[8]);

            Mat matK1_inv = new Mat();
            CvInvoke.Invert(matK1, matK1_inv, DecompMethod.Svd);
            CvInvoke.Gemm(matK1_inv, matK2, 1, null, 0, matDelta);

            dNewX = GetDoubleValue(matDelta, 0, 0);
            dNewY = GetDoubleValue(matDelta, 1, 0);
            dNewAngle = GetDoubleValue(matDelta, 2, 0) * R2D;

            return true;
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
        private Size GetBestRotationSize(Size sizeSrc, Size sizeDst, double dRAngle)
        {
            double dRAngle_radian = dRAngle * Math.PI / 180.0;
            Point ptLT = new Point(0, 0);
            Point ptLB = new Point(0, sizeSrc.Height - 1);
            Point ptRB = new Point(sizeSrc.Width - 1, sizeSrc.Height - 1);
            Point ptRT = new Point(sizeSrc.Width - 1, 0);

            PointF ptCenter = new PointF((sizeSrc.Width - 1) / 2.0f, (sizeSrc.Height - 1) / 2.0f);
            PointF ptLT_R = ptRotatePt2f(new PointF(ptLT.X, ptLT.Y), ptCenter, dRAngle_radian);
            PointF ptLB_R = ptRotatePt2f(new PointF(ptLB.X, ptLB.Y), ptCenter, dRAngle_radian);
            PointF ptRB_R = ptRotatePt2f(new PointF(ptRB.X, ptRB.Y), ptCenter, dRAngle_radian);
            PointF ptRT_R = ptRotatePt2f(new PointF(ptRT.X, ptRT.Y), ptCenter, dRAngle_radian);

            float fTopY = Math.Max(Math.Max(ptLT_R.Y, ptLB_R.Y), Math.Max(ptRB_R.Y, ptRT_R.Y));
            float fBottomY = Math.Min(Math.Min(ptLT_R.Y, ptLB_R.Y), Math.Min(ptRB_R.Y, ptRT_R.Y));
            float fRightX = Math.Max(Math.Max(ptLT_R.X, ptLB_R.X), Math.Max(ptRB_R.X, ptRT_R.X));
            float fLeftX = Math.Min(Math.Min(ptLT_R.X, ptLB_R.X), Math.Min(ptRB_R.X, ptRT_R.X));

            if (dRAngle > 360)
                dRAngle -= 360;
            else if (dRAngle < 0)
                dRAngle += 360;

            if (Math.Abs(Math.Abs(dRAngle) - 90) < VISION_TOLERANCE || Math.Abs(Math.Abs(dRAngle) - 270) < VISION_TOLERANCE)
            {
                return new Size(sizeSrc.Height, sizeSrc.Width);
            }
            else if (Math.Abs(dRAngle) < VISION_TOLERANCE || Math.Abs(Math.Abs(dRAngle) - 180) < VISION_TOLERANCE)
            {
                return sizeSrc;
            }
            double dAngle = dRAngle;

            if (dAngle > 0 && dAngle < 90)
            {
                // Đoạn mã để ở đây nếu cần xử lý gì đó với góc dAngle
            }
            else if (dAngle > 90 && dAngle < 180)
            {
                dAngle -= 90;
            }
            else if (dAngle > 180 && dAngle < 270)
            {
                dAngle -= 180;
            }
            else if (dAngle > 270 && dAngle < 360)
            {
                dAngle -= 270;
            }
            else //Debug
            {
                Console.WriteLine("Unknown");
            }
            float fH1 = (float)(sizeDst.Width * Math.Sin(dAngle * Math.PI / 180.0) * Math.Cos(dAngle * Math.PI / 180.0));
            float fH2 = (float)(sizeDst.Height * Math.Sin(dAngle * Math.PI / 180.0) * Math.Cos(dAngle * Math.PI / 180.0));

            int iHalfHeight = (int)Math.Ceiling(fTopY - ptCenter.Y - fH1);
            int iHalfWidth = (int)Math.Ceiling(fRightX - ptCenter.X - fH2);

            Size sizeRet = new Size(iHalfWidth * 2, iHalfHeight * 2);
            bool bWrongSize = (sizeDst.Width < sizeRet.Width && sizeDst.Height > sizeRet.Height)
            || (sizeDst.Width > sizeRet.Width && sizeDst.Height < sizeRet.Height
            || (sizeDst.Width * sizeDst.Height) > (sizeRet.Width * sizeRet.Height));
            if (bWrongSize)
            {
                sizeRet = new Size((int)(fRightX - fLeftX + 0.5), (int)(fTopY - fBottomY + 0.5));
            }
            return sizeRet;

        }

        private PointF ptRotatePt2f(PointF ptInput, PointF ptOrg, double dAngle)
        {
            double dWidth = ptOrg.X * 2;
            double dHeight = ptOrg.Y * 2;
            double dY1 = dHeight - ptInput.Y;
            double dY2 = dHeight - ptOrg.Y;

            double dX = (ptInput.X - ptOrg.X) * Math.Cos(dAngle) - (dY1 - ptOrg.Y) * Math.Sin(dAngle) + ptOrg.X;
            double dY = (ptInput.X - ptOrg.X) * Math.Sin(dAngle) + (dY1 - ptOrg.Y) * Math.Cos(dAngle) + dY2;
            dY = -dY + dHeight;

            return new PointF((float)dX, (float)dY);
        }
        private void FilterWithScore(ref List<s_MatchParameter> vec, double dScore)
        {
            // Sắp xếp theo điểm số giảm dần
            vec.Sort((x, y) => y.dMatchScore.CompareTo(x.dMatchScore));
            int iSize = vec.Count;
            int iIndexDelete = iSize + 1;
            for (int i = 0; i < iSize; i++)
            {
                if (vec[i].dMatchScore < dScore)
                {
                    iIndexDelete = i;
                    break;
                }
            }
            if (iIndexDelete == iSize + 1) // Không có phần tử nào nhỏ hơn dScore
                return;
            // Xóa các phần tử từ iIndexDelete đến cuối danh sách
            vec.RemoveRange(iIndexDelete, iSize - iIndexDelete);
        }

        private void FilterWithNumber(ref List<s_MatchParameter> vec, int number)
        {
            if (vec.Count > number)
            {
                List<s_MatchParameter> vecTmp = new List<s_MatchParameter>();
                vecTmp = vec.Take(number).ToList();
                vec = vecTmp;
            }
        }

        private void FilterWithRotatedRect(ref List<s_MatchParameter> vec, TemplateMatchingType iMethod, double dMaxOverLap)
        {
            int iMatchSize = vec.Count;
            for (int i = 0; i < iMatchSize - 1; i++)
            {
                if (vec[i].bDelete)
                    continue;
                for (int j = i + 1; j < iMatchSize; j++)
                {
                    if (vec[j].bDelete)
                        continue;
                    RotatedRect rect1 = vec[i].rectR;
                    RotatedRect rect2 = vec[j].rectR;
                    VectorOfPointF vecInterSec = new VectorOfPointF();
                    RectIntersectType iInterSecType = CvInvoke.RotatedRectangleIntersection(rect1, rect2, vecInterSec);

                    if (iInterSecType == RectIntersectType.None)
                        continue;
                    else if (iInterSecType == RectIntersectType.Full)
                    {
                        int iDeleteIndex = 0;
                        if (iMethod == TemplateMatchingType.Sqdiff)
                        {
                            iDeleteIndex = (vec[i].dMatchScore <= vec[j].dMatchScore) ? j : i;
                        }
                        else
                        {
                            iDeleteIndex = (vec[i].dMatchScore >= vec[j].dMatchScore) ? j : i;
                        }
                        vec[iDeleteIndex].bDelete = true;
                    }
                    else // Có giao điểm > 0
                    {
                        if (vecInterSec.Size < 3) // Một hoặc hai điểm giao nhau
                            continue;
                        else
                        {
                            int iDeleteIndex = 0;
                            // Tính diện tích và tỷ lệ giao nhau
                            //vecInterSec = SortPtWithCenter(vecInterSec);
                            double dArea = CvInvoke.ContourArea(vecInterSec);
                            double dRatio = dArea / (double)(rect1.Size.Width * rect1.Size.Height);
                            // Nếu tỷ lệ giao nhau lớn hơn tỷ lệ giao động tối đa, chọn điểm có điểm số cao hơn
                            if (dRatio > dMaxOverLap)
                            {
                                iDeleteIndex = (vec[i].dMatchScore >= vec[j].dMatchScore) ? j : i;
                                vec[iDeleteIndex].bDelete = true;
                            }
                        }
                    }
                }
            }
            for (int i = vec.Count - 1; i >= 0; i--)
            {
                if (vec[i].bDelete == true)
                {
                    vec.RemoveAt(i);
                }
            }
        }
        private Point GetNextMaxLoc(ref Mat matResult, Point ptMaxLoc, Size sizeTemplate, ref double dMaxValue, double dMaxOverlap)
        {
            int iStartX = ptMaxLoc.X - (int)(sizeTemplate.Width * (1 - dMaxOverlap));
            int iStartY = ptMaxLoc.Y - (int)(sizeTemplate.Height * (1 - dMaxOverlap));

            Rectangle rectIgnore = new Rectangle(iStartX, iStartY, (int)(2 * sizeTemplate.Width * (1 - dMaxOverlap)), (int)(2 * sizeTemplate.Height * (1 - dMaxOverlap)));

            CvInvoke.Rectangle(matResult, rectIgnore, new MCvScalar(-1), -1);

            Point ptNewMaxLoc = new Point(), ptMinLoc = new Point();
            double minVal = 0, maxVal = 0;
            CvInvoke.MinMaxLoc(matResult, ref minVal, ref maxVal, ref ptMinLoc, ref ptNewMaxLoc);
            dMaxValue = maxVal;
            return ptNewMaxLoc;
        }

        private VectorOfPointF SortPtWithCenter(VectorOfPointF vecSort)
        {
            int iSize = (int)vecSort.Size;
            //List<PointF> result = new List<PointF>(iSize);
            PointF ptCenter = new PointF();

            for (int i = 0; i < iSize; i++)
            {
                ptCenter.X += vecSort[i].X;
                ptCenter.Y += vecSort[i].Y;
            }
            ptCenter.X /= iSize;
            ptCenter.Y /= iSize;

            List<Tuple<PointF, double>> vecPtAngle = new List<Tuple<PointF, double>>(iSize);
            for (int i = 0; i < iSize; i++)
            {
                vecPtAngle.Add(new Tuple<PointF, double>(vecSort[i], 0));
                PointF vec1 = new PointF(vecSort[i].X - ptCenter.X, vecSort[i].Y - ptCenter.Y);
                float fNormVec1 = vec1.X * vec1.X + vec1.Y * vec1.Y;
                float fDot = vec1.X;
                if (vec1.Y < 0) // Nếu điểm nằm phía trên trung tâm
                {
                    vecPtAngle[i] = new Tuple<PointF, double>(vecPtAngle[i].Item1, Math.Acos(fDot / fNormVec1) * 180.0 / Math.PI);
                }
                else if (vec1.Y > 0) // Nếu điểm nằm phía dưới trung tâm
                {
                    vecPtAngle[i] = new Tuple<PointF, double>(vecPtAngle[i].Item1, 360.0 - Math.Acos(fDot / fNormVec1) * 180.0 / Math.PI);
                }
                else // Nếu điểm và trung tâm nằm trên cùng một đường ngang (cùng y)
                {
                    if (vec1.X - ptCenter.X > 0)
                        vecPtAngle[i] = new Tuple<PointF, double>(vecPtAngle[i].Item1, 0);
                    else
                        vecPtAngle[i] = new Tuple<PointF, double>(vecPtAngle[i].Item1, 180);
                }
            }
            vecPtAngle = vecPtAngle.OrderByDescending(item => item.Item2).ToList();
            VectorOfPointF t = new VectorOfPointF();
            for (int i = 0; i < iSize; i++)
            {
                PointF[] point = new PointF[] { vecPtAngle[i].Item1 };
                t.Push(point);
            }
            return t;
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





        //////////////////////////////////////////////////////////////////
        public class PointInfo
        {
            /// <summary>
            /// Point of edge 
            /// </summary>
            /// <remarks>
            /// (x,y)
            /// </remarks>
            public Point Point;

            /// <summary>
            /// Center of edge 
            /// </summary>
            /// <remarks>
            /// (x0,y0)
            /// </remarks>
            public PointF Center { get; private set; }

            /// <summary>
            /// Point-Center 
            /// </summary>
            /// <remarks>
            /// (x-x0,y-y0)
            /// </remarks>
            public PointF Offset { get; private set; }

            /// <summary>
            /// Derivative at Point
            /// </summary>
            /// <remarks>
            /// (dx,dy)
            /// </remarks>
            public PointF Derivative;

            /// <summary>
            /// Magnitude at Point
            /// </summary>
            /// <remarks>
            /// 1/√(dx²+dy²)
            /// </remarks>
            public double Magnitude;

            /// <summary>
            /// Direction at Point
            /// </summary>
            /// <remarks>
            /// atan2(dy,dx) (not currently in use)
            /// </remarks>
            public double Direction;
            public void Update(PointF center)
            {
                Center = center;
                Offset = new PointF(Point.X - center.X, Point.Y - center.Y);
            }

        }
        private List<PointInfo> results = new List<PointInfo>();
        private void TrainTemplate(Mat template)
        {
            results.Clear();

            Mat hier = new Mat();
            Mat output = new Mat();
            Mat gx = new Mat();
            Mat gy = new Mat();
            Mat magnitude = new Mat();
            Mat direction = new Mat();
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();



            CvInvoke.Canny(template, output, 10, 100);
            CvInvoke.FindContours(output, contours, hier, RetrType.External, ChainApproxMethod.ChainApproxNone);
            double areaMax = 0;
            int iMaxIdex = -1;
            for (int i = 0; i < contours.Size; i++)
            {
                var a = CvInvoke.ContourArea(contours[i]);
                if (a > areaMax)
                {
                    areaMax = a;
                    iMaxIdex = i;
                }
            }

            CvInvoke.Sobel(template, gx, DepthType.Cv64F, 1, 0, 3);
            CvInvoke.Sobel(template, gy, DepthType.Cv64F, 0, 1, 3);

            CvInvoke.CartToPolar(gx, gy, magnitude, direction);

            PointF sum = new PointF(0, 0);

            for (int j = 0; j < contours[iMaxIdex].Size; j++)
            {
                var cur = contours[iMaxIdex][j];
                double fdx = GetDoubleValue(gx, cur.Y, cur.X);
                double fdy = GetDoubleValue(gy, cur.Y, cur.X);
                PointF der = new PointF((float)fdx, (float)fdy);
                double mag = GetDoubleValue(magnitude, cur.Y, cur.X);
                double dir = GetDoubleValue(direction, cur.Y, cur.X);
                results.Add(new PointInfo
                {
                    Point = cur,
                    Derivative = der,
                    Direction = dir,
                    Magnitude = mag == 0 ? 0 : 1 / mag
                });
                sum.X = sum.X + cur.X;
                sum.Y = sum.Y + sum.Y;
            }

            var center = new PointF(sum.X / results.Count, sum.Y / results.Count);
            foreach (var item in results)
            {
                item.Update(center);
            }
        }

        private void MatchSearch(Mat image, out Point center, out double resultScore)
        {
            Mat output = new Mat();
            Mat gx = new Mat();
            Mat gy = new Mat();
            Mat magnitude = new Mat();
            Mat direction = new Mat();

            CvInvoke.Sobel(image, gx, DepthType.Cv64F, 1, 0, 3);
            CvInvoke.Sobel(image, gy, DepthType.Cv64F, 0, 1, 3);
            CvInvoke.CartToPolar(gx, gy, magnitude, direction);
            double minScore = 0.9;
            double greediness = 0.9;

            long noOfCordinates = results.Count;
            double normMinScore = minScore / noOfCordinates;
            double normGreediness = (1 - greediness * minScore) / (1 - greediness) / noOfCordinates;
            double partialScore = 0;
            resultScore = 0;
            center = new Point();

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    double partialSum = 0;
                    for (var m = 0; m < noOfCordinates; m++)
                    {
                        var item = results[m];
                        var curX = (int)(j + item.Offset.X);
                        var curY = (int)(i + item.Offset.Y);
                        var iTx = item.Derivative.X;
                        var iTy = item.Derivative.Y;
                        if (curX < 0 || curY < 0 || curY > image.Height - 1 || curX > image.Width - 1)
                            continue;
                        double iSx = GetDoubleValue(gx, curY, curX);
                        double iSy = GetDoubleValue(gy, curY, curX);
                        if ((iSx != 0 || iSy != 0) && (iTx != 0 || iTy != 0))
                        {
                            var mag = GetDoubleValue(magnitude, curY, curX);
                            var matGradMag = mag == 0 ? 0 : 1 / mag; // 1/√(dx²+dy²)
                            partialSum += ((iSx * iTx) + (iSy * iTy)) * (item.Magnitude * matGradMag);
                        }
                        var sumOfCoords = m + 1;
                        partialScore = partialSum / sumOfCoords;
                        if (partialScore < Math.Min((minScore - 1) + normGreediness * sumOfCoords, normMinScore * sumOfCoords))
                            break;

                    }
                    if (partialScore > resultScore)
                    {
                        resultScore = partialScore;
                        center.X = j;
                        center.Y = i;
                    }
                }
            }
        }
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
                {point.X},
                {point.Y},
                {1 }
            });
            var C = new Matrix<double>(3, 1);
            CvInvoke.Gemm(A, B, 1.0, null, 0, C);
            p.X = (int)C.Data[0, 0];
            p.Y = (int)C.Data[1, 0];
            return p;
        }

    }
}
