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

            // Clean up the native memory of the previous output image before recreating
            if (AffineImage != null)
            {
                AffineImage.OutputImage?.Dispose();
            }

            AffineImage = new AffineImage.AffineImage();
            
            // Pass reference directly to avoid cloning and leaking native memory
            AffineImage.InputImage = InputBgrImage.rtcValue;
            AffineImage.AffineMode = AffineMode.rtcValue;

            switch (AffineMode.rtcValue)
            {
                case "Rotation":
                    AffineImage.InputX = InputX.rtcValue != null && InputX.rtcValue.Count > 0 ? InputX.rtcValue[0] : 0;
                    AffineImage.InputY = InputY.rtcValue != null && InputY.rtcValue.Count > 0 ? InputY.rtcValue[0] : 0;
                    AffineImage.InputAngle = InputAngle.rtcValue != null && InputAngle.rtcValue.Count > 0 ? InputAngle.rtcValue[0] : 0;
                    break;

                case "Rotation About Center":
                    AffineImage.InputAngle = InputAngle.rtcValue != null && InputAngle.rtcValue.Count > 0 ? InputAngle.rtcValue[0] : 0;
                    break;

                case "Translation":
                    AffineImage.InputTransX = InputTransX.rtcValue != null && InputTransX.rtcValue.Count > 0 ? InputTransX.rtcValue[0] : 0;
                    AffineImage.InputTransY = InputTransY.rtcValue != null && InputTransY.rtcValue.Count > 0 ? InputTransY.rtcValue[0] : 0;
                    break;

                case "Translation and Rotation":
                    AffineImage.InputX = InputX.rtcValue != null && InputX.rtcValue.Count > 0 ? InputX.rtcValue[0] : 0;
                    AffineImage.InputY = InputY.rtcValue != null && InputY.rtcValue.Count > 0 ? InputY.rtcValue[0] : 0;
                    AffineImage.InputTransX = InputTransX.rtcValue != null && InputTransX.rtcValue.Count > 0 ? InputTransX.rtcValue[0] : 0;
                    AffineImage.InputTransY = InputTransY.rtcValue != null && InputTransY.rtcValue.Count > 0 ? InputTransY.rtcValue[0] : 0;
                    AffineImage.InputAngle = InputAngle.rtcValue != null && InputAngle.rtcValue.Count > 0 ? InputAngle.rtcValue[0] : 0;
                    break;

                case "Rigid Transform":
                    PointF p1 = PointF.Empty;
                    double angle1 = 0;
                    if (InputOrigin1.rtcValue != null && InputOrigin1.rtcValue.Count >= 3)
                    {
                        p1 = new PointF(Lib.ToInt(InputOrigin1.rtcValue[0]), Lib.ToInt(InputOrigin1.rtcValue[1]));
                        angle1 = InputOrigin1.rtcValue[2];
                    }
                    AffineImage.InputOrigin1 = Tuple.Create(p1, angle1);

                    PointF p2 = PointF.Empty;
                    double angle2 = 0;
                    if (InputOrigin2.rtcValue != null && InputOrigin2.rtcValue.Count >= 3)
                    {
                        p2 = new PointF(Lib.ToInt(InputOrigin2.rtcValue[0]), Lib.ToInt(InputOrigin2.rtcValue[1]));
                        angle2 = InputOrigin2.rtcValue[2];
                    }
                    AffineImage.InputOrigin2 = Tuple.Create(p2, angle2);
                    break;
            }

            AffineImage.Interpolation = Interpolation.rtcValue;

            if (AffineImage.Run())
            {
                // Convert to GDI+ Bitmap only once to optimize memory allocation and performance
                Bitmap bmp = AffineImage.OutputImage?.ToBitmap();
                if (bmp != null)
                {
                    if (WindowHandle.rtcValue.InvokeRequired)
                    {
                        WindowHandle.rtcValue.Invoke(new Action(() =>
                        {
                            WindowHandle.rtcValue.Image = bmp;
                            if (OutputImage.rtcValue != bmp)
                            {
                                OutputImage.rtcValue?.Dispose();
                                OutputImage.rtcValue = bmp;
                            }
                        }));
                    }
                    else
                    {
                        WindowHandle.rtcValue.Image = bmp;
                        if (OutputImage.rtcValue != bmp)
                        {
                            OutputImage.rtcValue?.Dispose();
                            OutputImage.rtcValue = bmp;
                        }
                    }
                }
                Passed.rtcValue = AffineImage.Passed;
            }
        }
    }
}
