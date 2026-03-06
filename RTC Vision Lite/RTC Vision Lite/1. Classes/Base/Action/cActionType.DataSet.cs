using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public async void Run_DataSet()
        {
            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            Run_DataSet_CalculateBlobList();
            Run_DataSet_CalculateValue();
            Run_DataSet_CalculateImageArray();
            if (DestinationPort.rtcIDRef != Guid.Empty)
            {
                if (MyGroup.Actions.TryGetValue(DestinationPort.rtcIDRef, out cAction action))
                {
                    bool isRefreshRef = false;
                    RTCVariableType rtcVariableType = (RTCVariableType)action.GetType()
                        .GetProperty(DestinationPort.rtcPropNameRef)?.GetValue(action, null);
                    if (rtcVariableType != null)
                    {
                        if (action.ActionType == EActionTypes.DataInstance && DestinationPort.rtcPropNameRef == nameof(Value))
                        {
                            if (ForceSetValueDataInstance.rtcValue)
                                action.Value.rtcValue = Value.rtcValue;
                            else
                            {
                                if (action.AppendMode.rtcValue == cAppendMode.Add)
                                {
                                    action.Value.rtcValue.AddRange(Value.rtcValue);
                                    action.Value.rtcValue = action.Value.rtcValue;
                                }
                                else
                                    action.Value.rtcValue = Value.rtcValue;
                            }
                            DestinationPort.rtcValue = action.Value.rtcValue;


                        }
                        else
                        {
                            PropertyInfo propertyInfoValue = rtcVariableType.GetType().GetProperty(cPropertyName.rtcValue);
                            if (propertyInfoValue != null)
                            {
                                switch (rtcVariableType.GetType().Name)
                                {
                                    case nameof(SBool):
                                        {
                                            propertyInfoValue.SetValue(rtcVariableType, bool.TryParse(GlobFuncs.Ve2Str(Value.rtcValue), out bool value) && value);
                                            break;
                                        }
                                    case nameof(SInt):
                                        {
                                            propertyInfoValue.SetValue(rtcVariableType, int.TryParse(GlobFuncs.Ve2Str(Value.rtcValue), out int value) ? value : 0);
                                            break;
                                        }
                                    case nameof(SDouble):
                                        {
                                            propertyInfoValue.SetValue(rtcVariableType,
                                                double.TryParse(GlobFuncs.Ve2Str(Value.rtcValue), out double value) ? value : 0);
                                            break;
                                        }
                                    case nameof(SString):
                                        {
                                            propertyInfoValue.SetValue(rtcVariableType, GlobFuncs.Ve2Str(Value.rtcValue));
                                            break;
                                        }
                                    case nameof(SListDouble):
                                        {
                                            propertyInfoValue.SetValue(rtcVariableType, GlobFuncs.Ve2Double(Value.rtcValue) );
                                            break;
                                        }
                                    default:
                                        {
                                            propertyInfoValue.SetValue(rtcVariableType, Value.rtcValue);
                                            break;
                                        }
                                }
                            }
                            DestinationPort.rtcValue = Value.rtcValue;
                        }
                        isRefreshRef = true;
                        if (action.ActionType != EActionTypes.MainAction && action.ViewInfo != null)
                        {
                            ((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                            ((ucBaseActionDetail)action.ViewInfo).UpdatePropertyValueToAllControls(DestinationPort.rtcPropNameRef);
                        }
                        action.UpdatePropertyToNodeValue(DestinationPort.rtcPropNameRef);
                    }

                    else if (action.DataItems != null)
                    {
                        SStringBuilderItem sbItem = action.DataItems.FirstOrDefault(x => x.Name == DestinationPort.rtcPropNameRef);
                        if (sbItem != null)
                        {
                            sbItem.ListStringValue = Value.rtcValue;
                            isRefreshRef = true;
                            if (action.ActionType != EActionTypes.MainAction && action.ViewInfo != null)
                                ((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo();


                            DestinationPort.rtcValue = Value.rtcValue;
                        }
                        if (isRefreshRef)
                            action.MyGroup.SetValuetoVariableIsParentRef(action);
                    }
                }
                Passed.rtcValue = true;
                if (IsRunOneTime.rtcValue)
                    IsFinishRunOneTime.rtcValue = Passed.rtcValue;
            }
        }
        private void Run_DataSet_CalculateImageArray()
        {
            // tính toán value
            if (LinkProperty == null || LinkProperty.Count <= 0)
                return;

            var orderList = LinkProperty.Where(x => x.TargetName == nameof(ImageArray)).OrderBy(x => x.OrderNum).ToList();
            if(orderList.Count > 0)
            {
                ImageArray.rtcValue = new List<Image>();
            }    
            foreach (cLinkProperty linkProperty in orderList)
            {
                if (!GlobVar.CurrentProject.CAMs.TryGetValue(linkProperty.SourceCamID, out cCAMTypes cam))
                    continue;
                cAction action = null;
                if (this.MyGroup.RunSimple)
                {
                    if (!cam.GroupActions.Actions.TryGetValue(linkProperty.SourceID, out action))
                        continue;
                }
                else if (cam.ID == this.MyGroup.MyCam.ID)
                {
                    if (!GlobVar.GroupActions.Actions.TryGetValue(linkProperty.SourceID, out action))
                        continue;
                }
                else if (!cam.GroupActions.Actions.TryGetValue(linkProperty.SourceID, out action))
                    continue;

                RTCVariableType rtcVariableType = (RTCVariableType)action.GetType()
                    .GetProperty(linkProperty.SourceName)?.GetValue(action, null);
                var test = rtcVariableType.GetType();
                if (rtcVariableType != null && rtcVariableType.GetType() == typeof(SImage))
                {
                    PropertyInfo propertyInfoValue = rtcVariableType.GetType().GetProperty(cPropertyName.rtcValue);
                    if (propertyInfoValue == null)
                        continue;

                    Image obj = (Image)propertyInfoValue.GetValue(rtcVariableType, null);
                    if (obj != null)
                    {
                        ImageArray.rtcValue.AddRange(GlobFuncs.GetValueFromSImageByIndex(
                                   new List<Image>() { obj},
                                   ImageArray.rtcRefIndex));
                        ImageArray.rtcValue = ImageArray.rtcValue;
                    }
                }
            }
        }    
        private void Run_DataSet_CalculateValue()
        {
            // tính toán value
            if (LinkProperty == null || LinkProperty.Count <= 0)
                return;
            var orderlist = LinkProperty.Where(x => x.TargetName == nameof(Value)).OrderBy(x => x.OrderNum).ToList();
            if (orderlist.Count > 0)
                Value.rtcValue = new List<string>();
            foreach (cLinkProperty linkProperty in orderlist)
            {
                if (!GlobVar.CurrentProject.CAMs.TryGetValue(linkProperty.SourceCamID, out cCAMTypes cam))
                    continue;
                cAction action = null;
                if (this.MyGroup.RunSimple)
                {
                    if (!cam.GroupActions.Actions.TryGetValue(linkProperty.SourceID, out action))
                        continue;
                }
                else if (cam.ID == this.MyGroup.MyCam.ID)
                {
                    if (!GlobVar.GroupActions.Actions.TryGetValue(linkProperty.SourceID, out action))
                        continue;
                }
                else if (!cam.GroupActions.Actions.TryGetValue(linkProperty.SourceID, out action))
                    continue;
                RTCVariableType rtcVariableType = (RTCVariableType)action.GetType().GetProperty(linkProperty.SourceName)?.GetValue(action, null);
                if (rtcVariableType != null && !rtcVariableType.rtcIsIconic)
                {
                    PropertyInfo propertyInfoValue = rtcVariableType.GetType().GetProperty(cPropertyName.rtcValue);
                    if (propertyInfoValue == null)
                        continue;
                    object obj = propertyInfoValue.GetValue(rtcVariableType, null);
                    var test = rtcVariableType.GetType().Name;
                    switch (rtcVariableType.GetType().Name)
                    {
                        case nameof(SBool):
                            {
                                Value.rtcValue.Append(GlobFuncs.Object2Str(obj).ToString().ToLower());
                                break;
                            }
                        case nameof(SInt):
                            {
                                Value.rtcValue.Append(GlobFuncs.Object2Str(obj));
                                break;
                            }
                        case nameof(SDouble):
                            {
                                Value.rtcValue.Append(GlobFuncs.Object2Str(obj));
                                break;
                            }
                        case nameof(SString):
                            {
                                Value.rtcValue.Append(GlobFuncs.Object2Str(obj));
                                break;
                            }
                        case nameof(SListString):
                            {
                                Value.rtcValue.AddRange(GlobFuncs.GetValueStringByIndex((List<string>)obj, linkProperty.SourceIndex[0].ToString()));
                                break;
                            }
                        case nameof(SListDouble):
                            {
                                Value.rtcValue.AddRange(GlobFuncs.GetValueStringByIndex(GlobFuncs.ListDoubleToListString((List<double>)obj), linkProperty.SourceIndex[0].ToString()));
                                break;
                            }
                        case nameof(SListObject):
                            {
                                Value.rtcValue.AddRange(GlobFuncs.GetValueStringByIndex(GlobFuncs.ListObjectToListString((List<object>)obj), linkProperty.SourceIndex[0].ToString()));
                                break;
                            }
                    }
                }
                else if (this.DataItems != null && this.DataItems.Count > 0 &&
                    this.DataItems.FirstOrDefault(X => X.Name == linkProperty.SourceName) != null)
                {
                    SStringBuilderItem stringBuilderItem = this.DataItems.FirstOrDefault(x => x.Name == linkProperty.SourceName);
                    if(stringBuilderItem.ListStringValue != null && stringBuilderItem.ListStringValue.Count > 0)
                    {
                        Value.rtcValue.AddRange(GlobFuncs.GetValueStringByIndex(stringBuilderItem.ListStringValue, linkProperty.SourceIndex[0].ToString()));
                    }
                    else
                    {
                        Value.rtcValue.AddRange(GlobFuncs.GetValueDoubleByIndex(stringBuilderItem.ListDoubleValue, linkProperty.SourceIndex[0].ToString()).
                            Cast<string>().ToList());
                    }    

                }
                else if (this.MyExpression != null && this.DataItems.Count > 0 &&
                    this.DataItems.FirstOrDefault(x => x.Name == linkProperty.SourceName) != null)
                {
                    SStringBuilderItem stringBuilderItem = this.MyExpression.Operands.FirstOrDefault(x => x.Name == linkProperty.SourceName);
                    if (stringBuilderItem.ListStringValue != null && stringBuilderItem.ListStringValue.Count > 0)
                    {
                        Value.rtcValue.AddRange(GlobFuncs.GetValueStringByIndex(stringBuilderItem.ListStringValue, linkProperty.SourceIndex[0].ToString()));
                    }
                    else
                    {
                        Value.rtcValue.AddRange(GlobFuncs.GetValueDoubleByIndex(stringBuilderItem.ListDoubleValue, linkProperty.SourceIndex[0].ToString()).
                            Cast<string>().ToList());
                    }
                }    
            }
            Value.rtcValue = Value.rtcValue;
        }
        private void Run_DataSet_CalculateBlobList()
        {
            if (LinkProperty == null || LinkProperty.Count <= 0)
                return;

            var orderList = LinkProperty.Where(x => x.TargetName == nameof(BlobList)).OrderBy(x => x.OrderNum).ToList();
            if (orderList.Count > 0)
            {
                BlobList.rtcValue = new List<Emgu.CV.Util.VectorOfVectorOfPoint>();
            }    
            foreach(cLinkProperty linkProperty in orderList)
            {
                if (!GlobVar.CurrentProject.CAMs.TryGetValue(linkProperty.SourceCamID, out cCAMTypes cam))
                    continue;
                cAction action = null;
                if (this.MyGroup.RunSimple)
                {
                    if (!cam.GroupActions.Actions.TryGetValue(linkProperty.SourceID, out action))
                        continue;
                }
                else if (cam.ID == this.MyGroup.MyCam.ID)
                {
                    if (!GlobVar.GroupActions.Actions.TryGetValue(linkProperty.SourceID, out action))
                        continue;
                }
                else if (!cam.GroupActions.Actions.TryGetValue(linkProperty.SourceID, out action))
                    continue;
                RTCVariableType rtcVariableType = (RTCVariableType)action.GetType().GetProperty(linkProperty.SourceName)?.GetValue(action, null);
                if(rtcVariableType != null && rtcVariableType.GetType() == typeof(SListVector))
                {
                    PropertyInfo propertyInfoValue = rtcVariableType.GetType().GetProperty(cPropertyName.rtcValue);
                    if (propertyInfoValue == null)
                        continue;
                    List<Emgu.CV.Util.VectorOfVectorOfPoint> obj =
                        (List<Emgu.CV.Util.VectorOfVectorOfPoint>)propertyInfoValue.GetValue(rtcVariableType, null);
                    if(obj != null)
                    {
                        BlobList.rtcValue.AddRange(GlobFuncs.GetValueListVectorByIndex(obj, linkProperty.SourceIndex[0].ToString()));
                    }    
                }    
            }    
        }
    }
}

