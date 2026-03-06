using Emgu.CV;
using Emgu.CV.Structure;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
   public partial class cAction
    {
        internal List<int> ImageFilter_NGIndex { get; private set; }
        internal List<int> ImageFilter_OKIndex { get; private set; }
        public void Run_ImageFilter_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MyGroup.GetValueToVariableIsRef(this);
            Run_ImageFilter(true, GlobVar.IsDebugMode);
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
            if (this.ViewInfo != null && !MyGroup.RunSimple)
                ((ucBaseActionDetail)ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        private void Run_ImageFilter(bool isTest = false, bool setwaitForDebugConnecttion = false)
        {
            Passed.rtcValue = false;
            string errorMessage = string.Empty;
            //ImageFilter_NGIndex = new List<int>();
            //ImageFilter_OKIndex = new List<int>();
            ImageFilter = new ImageFilterTool.ImageFilter();
            if (ImageFilterProperty == null || ImageFilterProperty.Count <=0)
            {
                Passed.rtcValue = true;
                return;
            }
            var orderlist = from filter in ImageFilterProperty
                            orderby filter.OrderNum
                            select filter;
            int i = 0;
            Passed.rtcValue = true;
            Image<Gray, byte> InImage = InputGrayImage.rtcValue;
            foreach (cImageFilterProperty filterProperty in orderlist)
            {
                if(filterProperty.Active)
                {
                    if (i != 0)
                        InImage = ImageFilter.OutputImage;
                    FilterType.rtcValue = filterProperty.FilterType;
                    MaskWidth.rtcValue = filterProperty.MaskWidth;
                    Interations.rtcValue = filterProperty.Iterations;
                    ThresholdRange.rtcValue = filterProperty.ThresholdRange.rtcValue;
                    InRangeOutputPixel.rtcValue = filterProperty.InRangeOutputPixel;
                    OutRangeOutputPixel.rtcValue = filterProperty.OutRangeOutputPixel;
                    GrayValue.rtcValue = filterProperty.GrayValue.rtcValue;
                    Margin.rtcValue = filterProperty.Margin;
                    ScaleFactor.rtcValue = filterProperty.ScaleFactor;
                    if (filterProperty.IDRefRegion != Guid.Empty)
                    {
                        cAction action = MyGroup.Actions[filterProperty.IDRefRegion];
                        RTCVariableType propSrc = (RTCVariableType)action.GetType().GetProperty(filterProperty.PropNameRefRegion)?.GetValue(action, null);
                        if (propSrc == null)
                            return;
                        PropertyInfo propValue = propSrc.GetType().GetProperty(cPropertyName.rtcValue);
                        //if (propValue != null)
                        //    InputRegion.rtcValue = GlobFuncs.GetValueDoubleByIndex()
                    }
                    ImageFilter = new ImageFilterTool.ImageFilter();
                    ImageFilter.InputImageBgr = InputBgrImage.rtcValue;
                    ImageFilter.InputImageGray = InImage;
                    ImageFilter.FilterType = FilterType.rtcValue;
                    ImageFilter.MaskType = filterProperty.MaskType;
                    ImageFilter.MaskWidth = MaskWidth.rtcValue;
                    ImageFilter.MaskHeight = MaskHeight.rtcValue;
                    ImageFilter.ThresholdRange = new Tuple<int, int>((int)ThresholdRange.rtcValue[1], (int)ThresholdRange.rtcValue[3]);
                    ImageFilter.GrayValue = (int)GrayValue.rtcValue[0];
                    ImageFilter.ScaleFactor = ScaleFactor.rtcValue;
                    ImageFilter.IsShowImageResult = true;
                    bool result = ImageFilter.Run();
                    ErrMessage.rtcValue = new List<string> { ImageFilter.ErrMessage };
                    OutputGrayImage.rtcValue = ImageFilter.OutputImage;
                    OutputImage.rtcValue = ImageFilter.OutputImageShow;
                    if (WindowHandle.rtcValue.InvokeRequired)
                    {
                        WindowHandle.rtcValue.Invoke(new Action(() =>
                        {
                            OutputImage.rtcValue = ImageFilter.OutputImageShow;
                            WindowHandle.rtcValue.Image = ImageFilter.OutputImageShow;
                            WindowHandle.rtcValue.Refresh();


                        }));
                    }
                    else
                    {
                        OutputImage.rtcValue = ImageFilter.OutputImageShow;
                        WindowHandle.rtcValue.Image = ImageFilter.OutputImageShow;
                        WindowHandle.rtcValue.Refresh();
                    }
                    i++;
                }
            }

        }
    }
}
