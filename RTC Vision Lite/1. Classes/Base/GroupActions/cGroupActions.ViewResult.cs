using GraphicsWindow;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    public partial class cGroupActions
    {
        public void ViewResult_CleanData()
        {
            try
            {
                ViewResult_BackupImage();
                ViewResult_CleanWhenDone();
                ViewResult_RollBackImage();
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        
        private void ViewResult_RollBackImage()
        {
            foreach (cAction action in Actions.Values)
            {
                switch (action.ActionType)
                {
                    case EActionTypes.MainAction:
                        {
                            Image image = null;
                            action.RoolBackImage(ref image);
                            action.InputImage.rtcValue = image;
                            break;
                        }
                    case EActionTypes.SnapImage:
                        {

                            if (action.IsKeepImage.rtcValue)
                            {
                                Image image = null;
                                action.RoolBackImage(ref image);
                                action.InputImage.rtcValue = image;
                            }


                            break;
                        }
                    //case EActionTypes.LoadImage:
                    //    {
                    //        if (action.IsKeepImage.rtcValue)
                    //        {
                    //            Image image = null;
                    //            action.RoolBackImage(ref image);
                    //            action.InputImage.rtcValue = image;

                    //        }
                    //        break;
                    //    }
                    case EActionTypes.LoadImage:
                        {
                            if (action.IsKeepImage?.rtcValue == true)
                            {
                                Image image = null;
                                action.RoolBackImage(ref image);
                                if (action.OutputImage != null)
                                    action.OutputImage.rtcValue = image;
                            }
                            break;
                        }
                }
            }
        }

        private void ViewResult_CleanWhenDone()
        {
            if (!RunSimple) return;
            foreach (cAction action in Actions.Values.ToList())
            {
                var cleanProperty = action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(action, null)) != null
                    && ((RTCVariableType)x.GetValue(action, null)).rtcClearWhenRun).ToList();
                if (cleanProperty.Any())
                    foreach (PropertyInfo property in cleanProperty)
                    {
                        switch (property.PropertyType.Name)
                        {
                            case nameof(SImage):
                                {
                                    ((SImage)property.GetValue(action, null))?.Dispose();
                                    break;
                                }
                            default:
                                {
                                    property.GetValue(action, null).GetType().GetProperty(cPropertyName.rtcValue)?.SetValue(property.GetValue(action, null), null);
                                    break;
                                }
                        }
                        if (Refvalues.ContainsKey(action.ID + property.Name))
                            Refvalues.Remove(action.ID + property.Name);
                    }
            }
        }

        private void ViewResult_BackupImage()
        {
            foreach (cAction action in Actions.Values)
            {
                switch (action.ActionType)
                {
                    case EActionTypes.MainAction:
                        {
                            action.BackupImage(action.InputImage.rtcValue);
                            break;
                        }
                    case EActionTypes.SnapImage:
                        {
                            if (action.IsKeepImage.rtcValue)
                                action.BackupImage(action.InputImage.rtcValue);
                            break;
                        }
                    case EActionTypes.LoadImage:
                        {
                            if (action.IsKeepImage.rtcValue)
                                action.BackupImage(action.OutputImage.rtcValue);
                            break;
                        }
                }
            }
        }
        public void ViewResult(bool isViewResult = true)
        {
            try
            {
                if (isViewResult)
                {
                    if (!ViewResult_PrepareBeforeRun(SmartWindowControl))
                        return;
                    ViewResult_ViewToolData(SmartWindowControl);
                }

                ViewResult_CleanData();
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        private SImage actionImage = null;
        private void ViewResult_ViewToolData(GraphicsWindow.GraphicsWindow smartWindowControl, int actionOrderLimit = -1)
        {
            try
            {
                Font viewFont = CommonData.GetFontStyle(cFontStyle.GraphicResults);
                GlobVar.RTCVision.SWindowOptions.FontCamDisplay = $"{viewFont.Name}-{viewFont.Style}-{viewFont.Size}";

                double fontSize = GlobFuncs.ExtractNumberOfString(GlobVar.RTCVision.SWindowOptions.FontCamDisplay, 0, 16, true, ".") * MainAction.InputImage.rtcValue.Height / smartWindowControl.Height;
                int iRow = (MainAction.InputImage.rtcValue.Height - (int)fontSize);
                //double fontSize = GlobFuncs.ExtractNumberOfString(GlobVar.RTCVision.SWindowOptions.FontCamDisplay, 0);
                //int iRow = ((int)fontSize);
                int iWriteHistory = 0;
                actionImage = null;
                for (int i = 0; i < OrderActionId.Count; i++)
                {
                    cAction action = Actions[OrderActionId[i]];
                    if (action.ActionType == EActionTypes.MainAction)
                    {
                        actionImage = action.InputImage;
                        smartWindowControl.Image = actionImage.rtcValue;
                    }
                    if (!action.Enable.rtcValue &&
                        action.ActionType != EActionTypes.Branch &&
                        action.ActionType != EActionTypes.Switch &&
                        action.ActionType != EActionTypes.PassFail &&
                        action.ActionType != EActionTypes.CounterLoop)
                        continue;
                    if (action.IsAliveControl != null && action.IsAliveControl.rtcValue)
                        continue;
                    if (action.IDBranchItem != Guid.Empty && !action.IsCanRun && action.RunCountInProcess == 0)
                        continue;
                    if (!action.IsCanRun)
                        continue;
                    if (actionOrderLimit != -1 && action.STT == actionOrderLimit)
                        break;
                    if (action.ActionType != EActionTypes.MainAction
                        && action.Enable.rtcValue
                        && action.ActionType != EActionTypes.PassFail
                        && action.ActionType != EActionTypes.None
                        && (action.DisplayOutput != null && action.DisplayOutput.rtcValue))
                        ViewResult_Viewing(action, smartWindowControl, ref iRow, ref iWriteHistory);
                    ViewResult_RoiCheck(action, smartWindowControl);

                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }

        private void ViewResult_RoiCheck(cAction action, GraphicsWindow.GraphicsWindow smartWindowControl)
        {
            if (action.ShapeList != null && action.ShapeList.rtcDisplay)
            {
                ViewResult_Roicheck_UnMarkROIS(action, action.ROIs, smartWindowControl);
            }
        }

        private void ViewResult_Roicheck_UnMarkROIS(cAction action, Dictionary<long, object> roiDictionary, GraphicsWindow.GraphicsWindow smartWindowControl)
        {
            actionImage = action.InputImage;
            Guid parentActionImageSourceID = Guid.Empty;
            if (actionImage != null)
                parentActionImageSourceID = actionImage.rtcIDRef != Guid.Empty ? actionImage.rtcIDRef : action.ID;
            double length1 = 0;
            double length2 = 0;
            double phi = 0;
            if (roiDictionary != null)
            {
                var unMarkRoiList = roiDictionary.Values.Where(x => ((cDrawingBaseType)x).RoiType == ERoiTypes.Normal &&
                                                                      ((cDrawingBaseType)x).ConnectType == EConnectTypes.None &&
                                                                      (((cDrawingBaseType)x).MarkID == null || ((cDrawingBaseType)x).MarkID.Count <= 0 ||
                                                                      ((cDrawingBaseType)x).MarkID[0] == -1)).ToList();
                foreach (object unMarkROI in unMarkRoiList)
                {
                    cDrawingBaseType currentROI = (cDrawingBaseType)unMarkROI;
                    switch (currentROI.DrawingType)
                    {
                        case EDrawingtypes.Rectang:
                            {
                                length1 = ((cRectangType)unMarkROI).Width;
                                length2 = ((cRectangType)unMarkROI).Height;
                                phi = ((cRectangType)unMarkROI).Phi;
                                break;
                            }
                        case EDrawingtypes.Rectang1:
                            {
                                length1 = ((cRectangType)unMarkROI).Width;
                                length2 = ((cRectangType)unMarkROI).Height;
                                phi = ((cRectangType)unMarkROI).Phi;
                                break;
                            }
                        case EDrawingtypes.Ellipse:
                            {
                                length1 = ((cEllipseType)unMarkROI).Radius1;
                                length2 = ((cEllipseType)unMarkROI).Radius2;
                                phi = ((cRectangType)unMarkROI).Phi;
                                break;
                            }
                    }
                    var passed = action.IsMultiROI ? currentROI.Passed : action.Passed.rtcValue;

                }
            }
        }

        private void ViewResult_Viewing(cAction action, GraphicsWindow.GraphicsWindow smartWindowControl, ref int iRow, ref int iWriteHistory)
        {
            SListObject hOutputTextPosition = null;
            hOutputTextPosition = (SListObject)action.GetType().GetProperty(nameof(action.OutputDisplayTextPosition))?.GetValue(action, null);
            if (action.PropIsImageInfos != null)
                foreach (var propertyInfo in action.PropIsImageInfos)
                {
                    SImage image = ((SImage)propertyInfo.GetValue(action, null));
                    if (image.rtcValue != null)
                    {
                        smartWindowControl.ClearImage();
                        smartWindowControl.Image = image.rtcValue;
                    }
                }
            var propertyInfos = action.GetType().GetProperties().Where(x =>
            ((RTCVariableType)x.GetValue(action, null)) != null &&
            ((RTCVariableType)x.GetValue(action, null)).rtcDisplay && x.GetValue(action, null).GetType() != typeof(SImage)).ToList();

            string displayText = string.Empty;
            int displayTextRowCount = 0;
            var rtcValueTemp = MainAction.InputBgrImage.rtcValue;
            Color InColor = action.Passed.rtcValue ? Color.Green : Color.Red;
            foreach (var propertyInfo in propertyInfos)
            {
                try
                {
                    if (propertyInfo.Name == nameof(action.ShapeList) ||
                        propertyInfo.Name == nameof(action.FindShapeList))
                        continue;
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case nameof(SImage):
                            {
                                SImage image = ((SImage)propertyInfo.GetValue(action, null));
                                if (image.rtcValue != null)
                                {
                                    smartWindowControl.ClearImage();
                                    GlobFuncs.SmartSetPart(image.rtcValue, smartWindowControl);

                                }
                                break;
                            }
                        case nameof(SListVector):
                            {
                                SListVector Vectors = ((SListVector)propertyInfo.GetValue(action, null));
                                if (Vectors.rtcValue != null)
                                {

                                    GlobFuncs.DisplayGraphics(smartWindowControl, Vectors.rtcValue, ref rtcValueTemp, InColor);
                                }
                                break;
                            }

                        default:
                            {
                                if (action.ActionType == EActionTypes.DistanceMeasurement)
                                {
                                    if (propertyInfo.Name == nameof(action.DistanceErrorPoints) &&
                                        !action.DistanceErrorPoints.rtcDisplay)
                                    {
                                        //if (action.DistanceErrorPoints.rtcValue != null &&
                                        //    action.DistanceErrorPoints.rtcValue.Count > 0
                                        //    && GlobFuncs.ListObject2StrWithType(action.DistanceErrorPoints.rtcValue) != "all")
                                        //{

                                        //}
                                    }
                                }
                                if (action.ActionType == EActionTypes.LineFind && action.LineSegment.rtcValue.Count > 0)
                                {
                                    GlobFuncs.DisplayGraphics(smartWindowControl, action.LineSegment.rtcValue, ref rtcValueTemp, InColor);

                                }
                                if (hOutputTextPosition == null)
                                {
                                    if (string.IsNullOrEmpty(displayText))
                                        displayText = action.Name.rtcValue + (action.Passed.rtcValue ? ": OK" : ": NG");
                                    if (propertyInfo.Name != nameof(action.Passed))
                                    {
                                        displayText = $"{displayText}\n - {propertyInfo.Name} = {((RTCVariableType)propertyInfo.GetValue(action, null)).rtcValueView}";
                                        iWriteHistory += 1;
                                    }
                                }
                                else
                                    ViewResultInPosition(hOutputTextPosition, propertyInfo, action, smartWindowControl);
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    GlobFuncs.SaveErr(e);
                }
            }
            if (!string.IsNullOrEmpty(displayText))
            {
                double RateHight = (float)MainAction.InputImage.rtcValue.Height / smartWindowControl.Height;
                double RateWidth = (float)MainAction.InputImage.rtcValue.Width / smartWindowControl.Width;
                string Font = GlobVar.RTCVision.SWindowOptions.FontCamDisplay;

                double fsize = GlobFuncs.ExtractNumberOfString(GlobVar.RTCVision.SWindowOptions.FontCamDisplay, 0, 16, true, ".");
                double fontSize = fsize;//  + fsize* RateHight
                GraphicsWindow.GraphicsWindow.DataDispText DispText = new GraphicsWindow.GraphicsWindow.DataDispText();
                DispText.InFont = Font;
                DispText.InSize = (float)fontSize;
                DispText.TextView = displayText;
                DispText.InColor = InColor.Name;
                //DispText.InPoint = new PointF((float)(100 * RateWidth), (float)(smartWindowControl.Width - iWriteHistory * (fontSize + 10 * RateHight)));
                //DispText.InPoint = new PointF(10, (float)(iRow - iWriteHistory * (fontSize + 10 * RateHight)));
                DispText.InPoint = new PointF(10, (float)(10 + iWriteHistory * 2 * fontSize));
                //DispText.InPoint = new PointF(10, (float)(iWriteHistory * (fontSize + 10 * RateHight)));
                SmartWindowControl.DispText(DispText);
                iWriteHistory += 1;
            }
            hOutputTextPosition = null;
        }

        private void ViewResultInPosition(SListObject hOutputTextPosition, PropertyInfo propertyInfo, cAction action, GraphicsWindow.GraphicsWindow smartWindowControl)
        {
            if (hOutputTextPosition == null || hOutputTextPosition.rtcValue.Count <= 0)
                return;
            SListString value = new SListString();
            if (propertyInfo.PropertyType == typeof(SListString))
                value = ((SListString)propertyInfo.GetValue(action, null));
            else
            {
                SString sValue = ((SString)propertyInfo.GetValue(action, null));
                if (sValue != null)
                    value.rtcValue.Add(sValue.rtcValue);
            }
            int iIndex = hOutputTextPosition.rtcValue.IndexOf(propertyInfo.Name);
            if (iIndex < 0)
                return;
            for (int i1 = 0; i1 < value.rtcValue.Count; i1++)
            {
                string sDisplayText = value.rtcValue[i1];
                iIndex += 1;
                if (iIndex > hOutputTextPosition.rtcValue.Count - 1)
                    break;
                double dRow = (double)hOutputTextPosition.rtcValue[iIndex];
                iIndex += 1;
                if (sDisplayText == cStrings.NoRead)
                {

                }
                // smartWindowControl.di

            }

        }

        private bool ViewResult_PrepareBeforeRun(GraphicsWindow.GraphicsWindow smartControl)
        {
            if (smartControl == null)
                return false;
            //smartControl.ClearImage();
            smartControl.ClearDispText();
            if (Actions.TryGetValue(IDMainAction, out cAction actionMain))
            {
                if (actionMain.InputImage.rtcValue != null)
                {
                    //GlobFuncs.SmartSetPart(actionMain.InputImage.rtcValue, smartControl);
                }
            }
            else
                return false;
            return true;
        }
    }
}
