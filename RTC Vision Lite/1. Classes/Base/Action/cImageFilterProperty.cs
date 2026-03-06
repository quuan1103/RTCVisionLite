using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public class cImageFilterProperty
    {
        public Guid ID { get; set; }
        public bool Active { get; set; }
        public int OrderNum { get; set; }
        public string FilterType { get; set; }
        public int MaskHeight { get; set; }
        public int MaskWidth { get; set; }
        public int Iterations { get; set; }
        public int InRangeOutputPixel { get; set; }
        public int OutRangeOutputPixel { get; set; }
        public double ScaleFactor { get; set; }
        public SListDouble GrayValue { get; set; }
        public Guid IDRefRegion { get; set; }
        public string PropNameRefRegion { get; set; }
        public SListDouble ThresholdRange { get; set; }
        public string Margin { get; set; }
        public string MaskType { get; set; }
        public cImageFilterProperty()
        {
            ID = Guid.NewGuid();
            OrderNum = 1;
            Active = true;
            FilterType = cImageFilterType.Mean;
            MaskHeight = 3;
            MaskWidth = 3;
            Iterations = 1;
            InRangeOutputPixel = 255;
            Margin = cDrawingMode.Margin;
            MaskType = cDrawingType.Rectangle;
            OutRangeOutputPixel = 0;
            IDRefRegion = Guid.Empty;
            PropNameRefRegion = string.Empty;
            ThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ThresholdRange)),
                                            EHTupleStyle.RangeMinMaxLimit)
            {
                rtcValue = new List<double> { 0, 55, 0, 255 }
            };
            GrayValue = new SListDouble(CommonData.GetPropertyDescription(nameof(ThresholdRange)),
                                            EHTupleStyle.ValueList)
            {
                rtcValue = new List<double> { 255 }
            };
          

        }
        public cImageFilterProperty Clone()
        {
            cImageFilterProperty cloneProperty = new cImageFilterProperty
            {
                OrderNum = this.OrderNum,
                FilterType = this.FilterType,
                MaskHeight = this.MaskHeight,
                MaskWidth = this.MaskWidth,
                Iterations = this.Iterations,
                InRangeOutputPixel = this.InRangeOutputPixel,
                OutRangeOutputPixel = this.OutRangeOutputPixel,
                ScaleFactor = this.ScaleFactor,
                IDRefRegion = this.IDRefRegion,
                PropNameRefRegion = this.PropNameRefRegion,
                Margin = this.Margin,
                ThresholdRange =
                {
                    rtcValue = this.ThresholdRange.rtcValue
                },
                GrayValue =
                {
                    rtcValue = this.GrayValue.rtcValue
                },
               
            };
            return cloneProperty;
        }

    }

}
