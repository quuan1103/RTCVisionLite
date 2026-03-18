using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void Run_SendDialogMessage_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_SendDialogMessage(true);
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void Run_SendDialogMessage(bool isTest = false)
        {
            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.DialogResult.None;
            dialogResult = cMessageBox.Custom(DialogCaption.rtcValue,
                Message.rtcValue,
                DialogType.rtcValue,
                MessageBoxButtons.rtcValue,
                IsShowDialogMode.rtcValue,
                Position.rtcValue,
                this.MyGroup.RunSimple ? (Form)GlobVar.FormMain : (Form)GlobVar.FrmActions,
                GlobFuncs.Object2Int(WidthForm),
                GlobFuncs.Object2Int(HeightForm),
                //InputImage.rtcIDRef != Guid.Empty ? InputImage.rtcValue : null,
                InputImage.rtcValue,
                IsAutoClose.rtcValue,
                AutoCloseWaitTime.rtcValue / 1000);
            DialogResultI.rtcValue = (int)dialogResult;
            switch (dialogResult)
            {
                case System.Windows.Forms.DialogResult.None:
                    DialogResult.rtcValue = cDialogResults.None;
                    break;
                case System.Windows.Forms.DialogResult.OK:
                    DialogResult.rtcValue = cDialogResults.OK;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                    DialogResult.rtcValue = cDialogResults.Cancel;
                    break;
                case System.Windows.Forms.DialogResult.Abort:
                    DialogResult.rtcValue = cDialogResults.Abort;
                    break;
                case System.Windows.Forms.DialogResult.Retry:
                    DialogResult.rtcValue = cDialogResults.Retry;
                    break;
                case System.Windows.Forms.DialogResult.Ignore:
                    DialogResult.rtcValue = cDialogResults.Ignore;
                    break;
                case System.Windows.Forms.DialogResult.Yes:
                    DialogResult.rtcValue = cDialogResults.Yes;
                    break;
                case System.Windows.Forms.DialogResult.No:
                    DialogResult.rtcValue = cDialogResults.No;
                    break;
                default:
                    DialogResult.rtcValue = cDialogResults.None;
                    break;
            }
            Passed.rtcValue = true;
            if (IsRunOneTime.rtcValue && !isTest)
                IsFinishRunOneTime.rtcValue = Passed.rtcValue;
        }
    }
}
