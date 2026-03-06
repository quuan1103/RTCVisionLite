using RTC_Vision_Lite.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
      
        private void CreateViewInfo_MainAction()
        {
            ViewInfo = new ucMainActions();
            ((ucMainActions)ViewInfo).Action = this;
        }
        private void CreateViewInfo_Blob()
        {
            ViewInfo = new ucBlobActionDetail();
            ((ucBlobActionDetail)ViewInfo).Action = this;

            this.TabRoiActive.rtcValue = (((ucBlobActionDetail)ViewInfo).PageSetup.SelectedTab == ((ucBlobActionDetail)ViewInfo).ROI);
            this.TabPassActive.rtcValue = (((ucBlobActionDetail)ViewInfo).PageSetup.SelectedTab == ((ucBlobActionDetail)ViewInfo).PassFail);
        }
        private void CreateViewInfo_BlobFilter()
        {
            ViewInfo = new ucBlobFilterActionDetail();
            ((ucBlobFilterActionDetail)ViewInfo).Action = this;

            this.TabRoiActive.rtcValue = (((ucBlobFilterActionDetail)ViewInfo).PageSetup.SelectedTab == ((ucBlobFilterActionDetail)ViewInfo).ROI);
            
        }
        private void CreateViewInfo_Pattern()
        {
            ViewInfo = new ucPatternActionDetail();
            ((ucPatternActionDetail)ViewInfo).Action = this;

            this.TabRoiActive.rtcValue = (((ucPatternActionDetail)ViewInfo).PageSetup.SelectedTab == ((ucPatternActionDetail)ViewInfo).ROI);
            this.TabPassActive.rtcValue = (((ucPatternActionDetail)ViewInfo).PageSetup.SelectedTab == ((ucPatternActionDetail)ViewInfo).PassFail);
        }
        private void CreateViewInfo_BlobMultipleROI()
        {
            ViewInfo = new ucBlobMultipleROIActionDetail();
            ((ucBlobMultipleROIActionDetail)ViewInfo).Action = this;

            this.TabRoiActive.rtcValue = (((ucBlobMultipleROIActionDetail)ViewInfo).PageSetup.SelectedTab == ((ucBlobMultipleROIActionDetail)ViewInfo).ROI);
           // this.TabPassActive.rtcValue = (((ucBlobMultipleROIActionDetail)ViewInfo).PageSetup.SelectedTab == ((ucBlobMultipleROIActionDetail)ViewInfo).PassFail);
        }
        private void CreateViewInfo_Math()
        {
            ViewInfo = new ucMathActionDetail();
            ((ucMathActionDetail)ViewInfo).Action = this;

            this.TabRoiActive.rtcValue = (((ucMathActionDetail)ViewInfo).PageSetup.SelectedTab == ((ucMathActionDetail)ViewInfo).ROI);
            //this.TabPassActive.rtcValue = (((ucMathActionDetail)ViewInfo).PageSetup.SelectedTab == ((ucMathActionDetail)ViewInfo).PassFail);
        }
        private void CreateViewInfo_BranchItem()
        {
            ViewInfo = new ucBranchItemActionDetail();
            ((ucBranchItemActionDetail)ViewInfo).Action = this;
        }

        private void CreateViewInfo_Brach()
        {
            ViewInfo = new ucBranchActionDetails();
            ((ucBranchActionDetails)ViewInfo).Action = this;
        }
        private void CreateViewInfo_Brightness()
        {
            ViewInfo = new ucBrightnessActionDetails();
            ((ucBrightnessActionDetails)ViewInfo).Action = this;
        }
        private void CreateViewInfo_PixelCount()
        {
            ViewInfo = new ucPixelCountActionDetails();
            ((ucPixelCountActionDetails)ViewInfo).Action = this;
        }
        private void CreateViewInfo_LineFine()
        {
            ViewInfo = new ucLineFindActionDetails();
            ((ucLineFindActionDetails)ViewInfo).Action = this;
        }
        private void CreateViewInfo_ColorBlob()
        {
            ViewInfo = new ucColorBlobActionDetails();
            ((ucColorBlobActionDetails)ViewInfo).Action = this;
            this.TabRoiActive.rtcValue = (((ucColorBlobActionDetails)ViewInfo).PageSetup.SelectedTab == ((ucColorBlobActionDetails)ViewInfo).ROI);
            this.TabPassActive.rtcValue = (((ucColorBlobActionDetails)ViewInfo).PageSetup.SelectedTab == ((ucColorBlobActionDetails)ViewInfo).PassFail);
        }    
        private void CreateViewInfo_DistanceMeasurement()
        {
            ViewInfo = new ucDistanceMeasurementActionDetails();
            ((ucDistanceMeasurementActionDetails)ViewInfo).Action = this;
        }
        private void CreateViewInfo_ImageFilter()
        {
            ViewInfo = new ucImageFilterActionDetail();
            ((ucImageFilterActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_HandEye()
        {
            ViewInfo = new ucHandEyeActionDetail();
            ((ucHandEyeActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_Origin()
        {
            if (ViewInfo != null)
            {
                return;
            }

            ViewInfo = new ucOriginActionDetail();
            ((ucOriginActionDetail)ViewInfo).Action = this;
            this.TabRoiActive.rtcValue = (((ucOriginActionDetail)ViewInfo).PageSetup.SelectedTab ==
                                          ((ucOriginActionDetail)ViewInfo).ROI);
            this.TabPassActive.rtcValue = (((ucOriginActionDetail)ViewInfo).PageSetup.SelectedTab ==
                                           ((ucOriginActionDetail)ViewInfo).PassFail);
        }
        private void CreateViewInfo_TCPIPRead()
        {
            ViewInfo = new ucTCPIPReadActionDetail();
            ((ucTCPIPReadActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_CSTLightRead()
        {
            ViewInfo = new ucCSTLightReadActiondetail();
            ((ucCSTLightReadActiondetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_CSTLightWrite()
        {
            ViewInfo = new ucCSTLightWriteActionDetail();
            ((ucCSTLightWriteActionDetail)ViewInfo).Action = this;
        }

        private void CreateViewInfo_COMWriter()
        {
            ViewInfo = new ucCOMWriterActionDetails();
            ((ucCOMWriterActionDetails)ViewInfo).Action = this;
        }
        private void CreateViewInfo_TCPIPWrite()
        {
            ViewInfo = new ucTCPIPWriteActionDetail();
            ((ucTCPIPWriteActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_SLMPRead()
        {
            ViewInfo = new ucSLMPReadActionDetail();
            ((ucSLMPReadActionDetail)ViewInfo).Action = this;
        }    
        private void CreateViewInfo_SLMPWrite()
        {
            ViewInfo = new ucSLMPWriteActionDetail();
            ((ucSLMPWriteActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_Switch()
        {
            ViewInfo = new ucSwitchActionDetail();
            ((ucSwitchActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_CounterLoop()
        {
            ViewInfo = new ucCounterLoopActionDetail();
            ((ucCounterLoopActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_PassFail()
        {
            ViewInfo = new ucPassFailActionDetails();
            ((ucPassFailActionDetails)ViewInfo).Action = this;
        }
        private void CreateViewInfo_Return()
        {
            ViewInfo = new ucReturnActionDetails();
            ((ucReturnActionDetails)ViewInfo).Action = this;
        }
        private void CreateViewInfo_Reset()
        {
            ViewInfo = new ucResetToolActionDetail();
            ((ucResetToolActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_RegionProcessing()
        {
            ViewInfo = new ucRegionProcessingActionDetails();
            ((ucRegionProcessingActionDetails)ViewInfo).Action = this;
        }
        private void CreateViewInfo_ColorBlobMultiROI()
        {
            ViewInfo = new ucColorBlobMultipleROIActionDetail();
            ((ucColorBlobMultipleROIActionDetail)ViewInfo).Action = this;
            this.TabRoiActive.rtcValue = (((ucColorBlobMultipleROIActionDetail)ViewInfo).PageSetup.SelectedTab == ((ucColorBlobMultipleROIActionDetail)ViewInfo).ROI);
        }
        private void CreateViewInfo_SnapImage()
        {
            ViewInfo = new ucSnapImageActionDetail();
            ((ucSnapImageActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_LoadImage()
        {
            ViewInfo = new ucLoadImageActionDetail();
            ((ucLoadImageActionDetail)ViewInfo).Action = this;
        }
        //Quân thử
        private void CreateViewInfo_LoadObject()
        {
            //ViewInfo = new ucLoadImageActionDetail();
            //((ucLoadImageActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_StopLiveCam()
        {
            ViewInfo = new ucStopLiveCamActionDetail();
            ((ucStopLiveCamActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_DataSet()
        {
            ViewInfo = new ucDataSetActionDetail();
            ((ucDataSetActionDetail)ViewInfo).Action = this;
        }    
        private void CreateViewInfo_DataIntance()
        {
            ViewInfo = new ucDataIntanceActionDetail();
            ((ucDataIntanceActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_SaveImage()
        {
            ViewInfo = new ucSaveImageActionDetail();
            ((ucSaveImageActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_ComReader()
        {
            ViewInfo = new ucCOMReaderActionDetails();
            ((ucCOMReaderActionDetails)ViewInfo).Action = this;
        }
        private void CreateViewInfo_CSVWrite()
        {
            ViewInfo = new ucCsvWriteActionDetail();
            ((ucCsvWriteActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_ExcelWrite()
        {
            ViewInfo = new ucExcelWriteActionDetail();
            ((ucExcelWriteActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_RunProgram()
        {
            ViewInfo = new ucRunProgramActionDetail();
            ((ucRunProgramActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_PropertyLink()
        {
            ViewInfo = new ucPropertyLinkActionDetail();
            ((ucPropertyLinkActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_ChangeJob()
        {
            ViewInfo = new ucChangeJobActionDetail();
            ((ucChangeJobActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_MXComponentRead()
        {
            ViewInfo = new ucMXComponentReadActionDetail();
            ((ucMXComponentReadActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_MXComponentWrite()
        {
            ViewInfo = new ucMXComponentWriteActionDetail();
            ((ucMXComponentWriteActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_ClearWindow()
        {
            ViewInfo = new ucClearWindowActionDetail();
            ((ucClearWindowActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_CycleTimeStart()
        {
            ViewInfo = new ucCycleTimeStartActionDetail();
            ((ucCycleTimeStartActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_CycleTimeStop()
        {
            ViewInfo = new ucCycleTimeStopActionDetail();
            ((ucCycleTimeStopActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_DetectFileStatus()
        {
            ViewInfo = new ucDetectFileStatusActionDetail();
            ((ucDetectFileStatusActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_RunCommand()
        {
            ViewInfo = new ucRunCommandActionDetail();
            ((ucRunCommandActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_StringBuilder()
        {
            ViewInfo = new ucStringBuilderDetail();
            ((ucStringBuilderDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_SplitImage()
        {
            ViewInfo = new ucSplitImageActionDetail();
            ((ucSplitImageActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_SaveProject()
        {
            ViewInfo = new ucSaveProjectActionDetail();
            ((ucSaveProjectActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_DialogMessage()
        {
            ViewInfo = new ucDialogMessageActionDetail();
            ((ucDialogMessageActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_SendMessage()
        {
            ViewInfo = new ucSendAlarmMessageActionDetail();
            ((ucSendAlarmMessageActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_SystemInfo()
        {
            ViewInfo = new ucSystemInfoActionDetail();
            ((ucSystemInfoActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_OkNgCounter()
        {
            ViewInfo = new ucOkNgCounterActionDetail();
            ((ucOkNgCounterActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_ViewResult()
        {
            ViewInfo = new ucViewResultActionDetail();
            ((ucViewResultActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_HookKeyboard()
        {
            ViewInfo = new ucHookKeyboardActionDetail();
            ((ucHookKeyboardActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_Wait()
        {
            ViewInfo = new ucWaitActionDetail();
            ((ucWaitActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_Stop()
        {
            ViewInfo = new ucStopActionDetail();
            ((ucStopActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_LoadConfig()
        {
            ViewInfo = new ucLoadConfigActionDetail();
            ((ucLoadConfigActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_SaveConfig()
        {
            ViewInfo = new ucSaveConfigActionDetail();
            ((ucSaveConfigActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_Count()
        {
            ViewInfo = new ucCounterActionDetail();
            ((ucCounterActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_Script()
        {
            ViewInfo = new ucScriptActionDetail();
            ((ucScriptActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_SaveObject()
        {
            ViewInfo = new ucSaveObjectActionDetail();
            ((ucSaveObjectActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_LiveCam()
        {
            ViewInfo = new ucLiveCamActionDetail();
            ((ucLiveCamActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_ImageMath()
        {
            ViewInfo = new ucImageMathActionDetail();
            ((ucImageMathActionDetail)ViewInfo).Action = this;
            this.TabRoiActive.rtcValue = (((ucImageMathActionDetail)ViewInfo).PageSetup.SelectedTab ==
                                          ((ucImageMathActionDetail)ViewInfo).ROI);

        }
        private void CreateViewInfo_CodeReader()
        {
            ViewInfo = new ucCodeReaderActionDetail();
            ((ucCodeReaderActionDetail)ViewInfo).Action = this;
            this.TabRoiActive.rtcValue = (((ucCodeReaderActionDetail)ViewInfo).PageSetup.SelectedTab ==
                                                      ((ucCodeReaderActionDetail)ViewInfo).ROI);
            this.TabPassActive.rtcValue =
                (((ucCodeReaderActionDetail)ViewInfo).PageSetup.SelectedTab ==
                 ((ucCodeReaderActionDetail)ViewInfo).PassFail);
        }
        private void CreateViewInfo_IOControllerRead()
        {
            ViewInfo = new ucIOControllerReadActionDetail();
            ((ucIOControllerReadActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_IOControllerWrite()
        {
            ViewInfo = new ucIOControllerWriteActionDetail();
            ((ucIOControllerWriteActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_POCIORead()
        {
            ViewInfo = new ucPOCIOControllerReadActionDetail();
            ((ucPOCIOControllerReadActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_POCIOWrite()
        {
            ViewInfo = new ucPOCIOControllerWriteActionDetail();
            ((ucPOCIOControllerWriteActionDetail)ViewInfo).Action = this;
        }
        private void CreateViewInfo_AffineImage()
        {
            ViewInfo = new ucAffineImageActionDetail();
            ((ucAffineImageActionDetail)ViewInfo).Action = this;
        }
        // private
    }
}
