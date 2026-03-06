using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        private void Run_AffineImage()
        {
            if (InputBgrImage.rtcValue == null)
            {
                ErrMessage.rtcValue = new List<string>() { "Image Is Null" };
                return;
            }
            AffineImage = new AffineImage.AffineImage();
            AffineImage.InputImage = InputBgrImage.rtcValue.Clone();
            AffineImage.AffineMode = AffineMode.rtcValue;
            AffineImage.InputOrigin1 = Tuple.Create(new PointF(Lib.ToInt(InputOrigin1.rtcValue[0]), Lib.ToInt(InputOrigin1.rtcValue[1])),
                InputOrigin1.rtcValue[2]);
            AffineImage.InputOrigin2 = Tuple.Create(new PointF(Lib.ToInt(InputOrigin2.rtcValue[0]), Lib.ToInt(InputOrigin2.rtcValue[1])),
                InputOrigin2.rtcValue[2]);
            AffineImage.Interpolation = Interpolation.rtcValue;
            AffineImage.InputAngle = InputAngle.rtcValue[0];
            AffineImage.Interpolation = Interpolation.rtcValue;
            AffineImage.InputTransX = InputTransX.rtcValue[0];
            AffineImage.InputTransY = InputTransY.rtcValue[0];
            AffineImage.InputX = InputX.rtcValue[0];
            AffineImage.InputY = InputX.rtcValue[0];
            if (AffineImage.Run())
            {
                if (WindowHandle.rtcValue.InvokeRequired)
                {
                    WindowHandle.rtcValue.Invoke(new Action(() =>
                    {
                        WindowHandle.rtcValue.Image = AffineImage.OutputImage.ToBitmap();
                        OutputImage.rtcValue = (Image)AffineImage.OutputImage.ToBitmap();
                        //OutputBgrImage.rtcValue = AffineImage.OutputImage;
                    }));
                }
                else
                {
                    WindowHandle.rtcValue.Image = AffineImage.OutputImage?.ToBitmap();
                }
                Passed.rtcValue = AffineImage.Passed;
            }
        }
    }
}
