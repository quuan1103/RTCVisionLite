using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTCEnums;
using RTCConst;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using System.Reflection;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Threading;
using RTCBase.Drawing;
using System.Windows.Controls;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        internal void CTTest(Action action)
        {
            try
            {
                GlobVar.RunByTest = true;
                CTStart(true);
                action.Invoke();
                CTStop(true);
            }
            finally
            {
                GlobVar.RunByTest = false;
            }
        }
        internal void CTStart(bool isReset = false)
        {
            if (MyStopwatch == null || isReset)
            {
                MyStopwatch = new Stopwatch();
                MyStopwatchUi = new Stopwatch();
                if (ActionType == EActionTypes.MainAction)
                    TotalTime = 0;
                ProcessTime = 0;
                GroupTime = 0;
                CycleTime.rtcValue = ProcessTime;
            }
            MyStopwatch.Start();
        }
        internal void CTStop(bool isSetTotalTime = false)
        {
            if (MyStopwatch != null)
            {
                MyStopwatch.Stop();
                if (isSetTotalTime)
                {
                    long uiTime = 0;
                    if (MyStopwatchUi != null)
                        uiTime = MyStopwatchUi.ElapsedMilliseconds;

                    ProcessTime = MyStopwatch.ElapsedMilliseconds - uiTime;
                    // Tất cả các tool đều cộng dồn Total Time cho các lần chạy
                    TotalTime += ProcessTime;
                    CycleTime.rtcValue = ProcessTime;
                    if (IDBranchItem != Guid.Empty)
                    {
                        // Nếu là 1 tool trong 1 nhánh nào đó của 1 tool logic khác, thì cộng time của nó lên cho chính group đó
                        cAction branchItemAction = MyGroup.Actions[IDBranchItem];
                        if (MyGroup.Actions[branchItemAction.IDBranch].ActionType == EActionTypes.CounterLoop)
                        {
                            MyGroup.Actions[branchItemAction.IDBranch].GroupTime += ProcessTime;
                            MyGroup.Actions[branchItemAction.IDBranch].TotalTime += ProcessTime;
                        }
                    }
                    else if (ActionType == EActionTypes.CounterLoop)
                    {
                        MyGroup.Actions[ID].GroupTime += ProcessTime;
                        MyGroup.Actions[ID].TotalTime += ProcessTime;
                    }
                    //else if (GroupActionID != Guid.Empty && MyGroup.Actions.ContainsKey(GroupActionID))
                    //{
                    //    // Nếu là 1 tool trong 1 group, thì cộng time của nó lên cho chính group đó
                    //    MyGroup.Actions[GroupActionID].GroupTime += ProcessTime;
                    //    MyGroup.Actions[GroupActionID].TotalTime += ProcessTime;
                    //}
                    //else if (ActionType == EActionTypes.GroupAction)
                    //{
                    //    MyGroup.Actions[ID].GroupTime += ProcessTime;
                    //    MyGroup.Actions[ID].TotalTime += ProcessTime;
                    //}

                    // Luôn cộng thời gian chạy của các tool lên cho Main
                    if (ActionType != EActionTypes.MainAction)
                        MyGroup.MainAction.TotalTime += ProcessTime;

                    if (MyGroup.UseLog)
                        if (ActionType != EActionTypes.TCPIPRead && ActionType != EActionTypes.UdpRead &&
                            ActionType != EActionTypes.DetectFileStatus)
                            GlobFuncs.WriteLog(this);

                    //if (!MyGroup.RunSimple)
                    //    MyGroup.cycleTimeList.Add(new Tuple<Guid, long>(ID, ProcessTime));

                    if (ActionType != EActionTypes.MainAction)
                        ViewResultToUi();

                    ViewResultWhenAfterRun();
                }
            }
        }
        internal void StartStopWatch()
        {
            MyStopWatch = new Stopwatch();
            MyStopWatch.Start();

        }
     
        internal void AutoCreateRoi()
        {

        }
        public bool ResetMyPropertyValue()
        {
            bool isRefreshRef = false;
            var properties = this.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(this, null)) != null);
            foreach (PropertyInfo item in properties)
            {
                RTCVariableType propertyInfo = (RTCVariableType)this.GetType().GetProperty(item.Name)?.GetValue(this, null);
                PropertyInfo propertyInfoValue = item.PropertyType.GetProperty(cPropertyName.rtcValue);
                switch (this.ActionType)
                {
                    case EActionTypes.DataInstance:
                        {
                            if (item.Name == nameof(Value))
                            {
                                Value.rtcValue = (List<string>)GlobFuncs.CloneStringList(DefaultValue.rtcValue);
                                isRefreshRef = true;
                                if (this.ViewInfo != null)
                                    ((ucBaseActionDetail)this.ViewInfo).UpdatePropertyValueToAllControls(item.Name);
                                continue;
                            }
                            break;
                        }
                }
                switch (item.PropertyType.Name)
                {
                    case nameof(SBool):
                        propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_Bool(nameof(item.Name) + _SuffixName));
                        break;
                    //case nameof(SHWindow):
                    //    propertyInfoValue.SetValue(propertyInfo, null);
                    //    break;
                    case nameof(SImage):
                        ((SImage)propertyInfo)?.Dispose();
                        break;
                    case nameof(SListString):
                        propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_ListString(nameof(item.Name) + _SuffixName));
                        break;
                    case nameof(SString):
                        propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_Text(nameof(item.Name) + _SuffixName));
                        break;
                    case nameof(SInt):
                        propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_Int(nameof(item.Name) + _SuffixName));
                        break;
                    case nameof(SDouble):
                        propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_Double(nameof(item.Name) + _SuffixName));
                        break;
                    //case nameof(SHRegion):
                    //    ((SHRegion)propertyInfo)?.Dispose();
                    //    break;
                    //case nameof(SHObject):
                    //    ((SHObject)propertyInfo)?.Dispose();
                    //    break;
                    //case nameof(SHXLDCont):
                    //    ((SHXLDCont)propertyInfo)?.Dispose();
                    //    break;
                    default:
                        break;
                }
                if (this.ViewInfo != null && this.ViewInfo.GetType() == typeof(ucBaseActionDetail))
                    ((ucBaseActionDetail)this.ViewInfo).UpdatePropertyValueToAllControls(item.Name);
            }
            if (DataItems != null)
            {
                foreach (var dataItem in DataItems)
                {
                    switch (dataItem.ValueStyle)
                    {
                        case EHTupleStyle.Boolean:
                            dataItem.ListStringValue = new List<string> { (false.ToString().ToLower()) };
                            break;
                        case EHTupleStyle.Integer:
                            dataItem.ListDoubleValue = new List<double>(0);
                            break;
                        case EHTupleStyle.Real:
                            dataItem.ListDoubleValue = new List<double>(0);
                            break;
                        default:
                            dataItem.ListDoubleValue = new List<double>();
                            break;
                    }
                    if (this.ViewInfo != null)
                        ((ucBaseActionDetail)this.ViewInfo).UpdatePropertyValueToAllControls(dataItem.Name);
                }
            }
            if (MyExpression != null && MyExpression.Operands != null)
            {
                foreach (var operandItem in MyExpression.Operands)
                {
                    switch (operandItem.ValueStyle)
                    {
                        case EHTupleStyle.Boolean:
                            operandItem.ListStringValue = new List<string> { (false.ToString().ToLower()) };
                            break;
                        case EHTupleStyle.Integer:
                            operandItem.ListDoubleValue = new List<double>(0);
                            break;
                        case EHTupleStyle.Real:
                            operandItem.ListDoubleValue = new List<double>(0);
                            break;
                        default:
                            operandItem.ListDoubleValue = new List<double>();
                            break;
                    }
                    if (this.ViewInfo != null)
                        ((ucBaseActionDetail)this.ViewInfo).UpdatePropertyValueToAllControls(operandItem.Name);
                }
            }
            this.MyGroup.SetValuetoVariableIsParentRef(this);
            return true;


        }
        public void RunExpresion()
        {
            EExpressionResultTypes resultTypes = (ActionType == EActionTypes.Branch) ? EExpressionResultTypes.Boolean : EExpressionResultTypes.HTuple;
            if (this.MyExpression != null && this.MyExpression.ExpressionOrigin.Trim() != "")
                this.MyExpression.SetNewExpression(Expression.rtcValue, CalculateMode.rtcValue, resultTypes);
            else
                this.MyExpression = new cExpression(Expression.rtcValue, CalculateMode.rtcValue, resultTypes);
            if (ViewInfo != null)
            {
                ((ucBaseActionDetail)ViewInfo).UpdateBranchOpennds();
            }
        }
        public bool RebuidValueWhenLink(cAction actionSrc, string propNameSrc, string propNameDes)
        {
            PropertyInfo PropertyInfoDes = null;
            PropertyInfo PropertyInfoSrc = null;
            SStringBuilderItem dataItemDes = null;
            SStringBuilderItem dataItemSrc = null;
            PropertyInfoDes = this.GetType().GetProperty(propNameDes);
            if (PropertyInfoDes != null && (RTCVariableType)PropertyInfoDes.GetValue(this, null) == null)
                PropertyInfoDes = null;

            if (PropertyInfoDes == null && this.DataItems != null)
                dataItemDes = this.DataItems.FirstOrDefault(x => x.Name == propNameDes);
            if (PropertyInfoDes == null && dataItemDes == null && this.MyExpression != null && this.MyExpression.Operands != null)
                dataItemDes = this.MyExpression.Operands.FirstOrDefault(x => x.Name == propNameDes);
            if (PropertyInfoDes == null && this.StringBuilders != null)
                dataItemDes = this.StringBuilders.FirstOrDefault(x => x.Name == propNameDes);
            // Xác nhận các thành phần cha
            if (PropertyInfoDes != null)
            {
                RTCVariableType PropDes = (RTCVariableType)PropertyInfoDes.GetValue(this, null);
                if (PropDes != null)
                {
                    PropertyInfoSrc = actionSrc.GetType().GetProperty(propNameSrc);
                    if (PropertyInfoSrc == null && actionSrc.DataItems != null)
                        dataItemSrc = actionSrc.DataItems.FirstOrDefault(x => x.Name == propNameSrc);
                    if (PropertyInfoSrc == null && dataItemSrc == null && actionSrc.MyExpression != null && actionSrc.MyExpression.Operands != null)
                        dataItemSrc = actionSrc.MyExpression.Operands.FirstOrDefault(x => x.Name == propNameSrc);

                    if (PropertyInfoSrc == null && dataItemSrc == null)
                        return false;

                    if (PropertyInfoSrc != null)
                    {
                        PropDes.rtcIDRef = actionSrc.ID;
                        PropDes.rtcPropNameRef = propNameSrc;
                        PropDes.rtcRef = GlobFuncs.BuildRefString_Property(GlobVar.GroupActions, actionSrc, PropertyInfoSrc);
                        ((RTCVariableType)PropertyInfoSrc.GetValue(actionSrc, null)).rtcIsParent = true;
                        RebuildValueWhenLink_PropToProp(PropertyInfoSrc, PropertyInfoDes, actionSrc);
                        if (propNameDes == cOriginTool.Origin)
                        {
                            Dictionary<long, RTCRectangle> DataShape = GlobFuncs.GenShapeList(ShapeListOriginal);
                            Tuple<PointF, double> toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                            ToolOrigin.rtcValue[2]);
                            InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(DataShape.Values.Cast<RTCRectangle>().ToList(), toolOrigin));
                        }
                        return true;
                    }
                    else
                    {
                        PropDes.rtcIDRef = actionSrc.ID;
                        PropDes.rtcPropNameRef = propNameSrc;
                        PropDes.rtcRef = GlobFuncs.BuildRefString_DataItem(GlobVar.GroupActions, actionSrc, dataItemSrc);
                        dataItemSrc.IsParent = true;
                        RebuildValueWhenLink_DataItemToProp(dataItemSrc, PropertyInfoDes, actionSrc);
                        if (propNameDes == cOriginTool.Origin)
                        {
                            Dictionary<long, RTCRectangle> DataShape = GlobFuncs.GenShapeList(ShapeListOriginal);
                            Tuple<PointF, double> toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                            ToolOrigin.rtcValue[2]);
                            InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(DataShape.Values.Cast<RTCRectangle>().ToList(), toolOrigin));
                        }
                        return true;
                    }
                    
                }
            }
            else if (dataItemDes != null)
            {
                PropertyInfoSrc = actionSrc.GetType().GetProperty(propNameSrc);
                if (PropertyInfoSrc == null && actionSrc.DataItems != null)
                    dataItemSrc = actionSrc.DataItems.FirstOrDefault(x => x.Name == propNameSrc);
                if (PropertyInfoSrc == null && dataItemSrc == null && actionSrc.MyExpression != null && actionSrc.MyExpression.Operands != null)
                    dataItemSrc = actionSrc.MyExpression.Operands.FirstOrDefault(x => x.Name == propNameSrc);

                if (PropertyInfoSrc == null && dataItemSrc == null)
                    return false;

                if (PropertyInfoSrc != null)
                {
                    dataItemDes.RefID = actionSrc.ID;
                    dataItemDes.RefPropName = propNameSrc;
                    dataItemDes.Ref = GlobFuncs.BuildRefString_Property(GlobVar.GroupActions, actionSrc, PropertyInfoSrc);
                    ((RTCVariableType)PropertyInfoSrc.GetValue(actionSrc, null)).rtcIsParent = true;
                    RebuildValueWhenLink_PropToDataItem(PropertyInfoSrc, dataItemDes, actionSrc);
                    return true;
                }
                else
                {
                    dataItemDes.RefID = actionSrc.ID;
                    dataItemDes.RefPropName = propNameSrc;
                    dataItemDes.Ref = GlobFuncs.BuildRefString_DataItem(GlobVar.GroupActions, actionSrc, dataItemSrc);
                    dataItemSrc.IsParent = true;
                    RebuildValueWhenLink_DataItemToDataItem(dataItemSrc, dataItemDes, actionSrc);
                    return true;
                }
            }

            return false;
        }

        private void RebuildValueWhenLink_DataItemToDataItem(SStringBuilderItem dataItemSrc, SStringBuilderItem dataItemDes, cAction actionSrc)
        {
            dataItemDes.RefID = actionSrc.ID;
            dataItemDes.RefPropName = dataItemDes.Name;
            dataItemDes.Ref = GlobFuncs.BuildRefString_DataItem(GlobVar.GroupActions, actionSrc, dataItemSrc);
            dataItemDes.ListDoubleValue = GlobFuncs.GetValueDoubleByIndex(dataItemSrc.ListDoubleValue, dataItemDes.RefIndex);
            dataItemDes.ListStringValue = GlobFuncs.GetValueStringByIndex(dataItemDes.ListStringValue, dataItemDes.RefIndex);
        }

        public void RebuildValueWhenLink_PropToDataItem(PropertyInfo PropertyInfoSrc, SStringBuilderItem dataItemDes, cAction actionSrc)
        {
            dataItemDes.RefID = actionSrc.ID;
            dataItemDes.RefPropName = PropertyInfoSrc.Name;
            dataItemDes.Ref = GlobFuncs.BuildRefString_Property(GlobVar.GroupActions, actionSrc, PropertyInfoSrc);
            RTCVariableType PropSrc = (RTCVariableType)PropertyInfoSrc?.GetValue(this, null);
            dataItemDes.ListDoubleValue = new List<double>();
            dataItemDes.ListStringValue = new List<string>();

            switch (PropertyInfoSrc.PropertyType.Name)
            {
                case nameof(SListDouble):
                    {
                        
                            dataItemDes.ListDoubleValue = GlobFuncs.GetValueDoubleByIndex(
                                ((SListDouble)PropertyInfoSrc.GetValue(actionSrc, null)).rtcValue, dataItemDes.RefIndex);
                            break;
                      
                    }
                case nameof(SListString):
                    {
                        dataItemDes.ListStringValue = GlobFuncs.GetValueStringByIndex(
                                ((SListString)PropertyInfoSrc.GetValue(actionSrc, null)).rtcValue, dataItemDes.RefIndex);
                        break;
                    }
                //case nameof(SListObject):
                //    {
                //        dataItemDes.LisObjectValue = GlobFuncs.GetValueObjectByIndex(
                //                ((SListObject)PropertyInfoSrc.GetValue(actionSrc, null)).rtcValue, dataItemDes.RefIndex);
                //        break;
                //    }
                case nameof(SInt):
                    {
                        dataItemDes.ListDoubleValue.Add(((SInt)PropertyInfoSrc
                            .GetValue(actionSrc, null)).rtcValue);
                        break;
                    }
                case nameof(SDouble):
                    {
                        dataItemDes.ListDoubleValue.Add(((SDouble)PropertyInfoSrc
                            .GetValue(actionSrc, null)).rtcValue);
                        break;
                    }
                case nameof(SString):
                    {
                        dataItemDes.ListStringValue.Add(((SBool)PropertyInfoSrc
                            .GetValue(actionSrc, null))?.rtcValue.ToString().ToString().ToLower());
                        break;
                    }
                case nameof(SBool):
                    {
                        dataItemDes.ListStringValue.Add(((SBool)PropertyInfoSrc
                            .GetValue(actionSrc, null))?.rtcValue.ToString().ToLower());
                        break;
                    }
            }
            dataItemDes.ListDoubleValue = dataItemDes.ListDoubleValue;
            //dataItemDes.ListStringValue = dataItemDes.ListStringValue;
        }


        public void RebuildValueWhenLink_PropToProp(PropertyInfo PropertyInfoSrc, PropertyInfo PropertyInfoDes,
           cAction actionSrc)
        {
            RTCVariableType PropDes = (RTCVariableType)PropertyInfoDes.GetValue(this, null);
            if (PropDes == null) return;
            // Lấy ra đối tượng mà thuộc tính propName tool này link đến (Src)
            if (PropDes.rtcIDRef == Guid.Empty && this.MyGroup.Actions.ContainsKey(PropDes.rtcIDRef)) return;
            RTCVariableType PropSrc = (RTCVariableType)PropertyInfoSrc.GetValue(actionSrc, null);

            // Bắt đầu rebuild lại giá value cho đối tượng được link đến (Des)
            PropertyInfo PropSrcValue = PropSrc.GetType().GetProperty(cPropertyName.rtcValue);
            PropertyInfo PropDesValue = PropDes.GetType().GetProperty(cPropertyName.rtcValue);
            if (PropSrcValue == null || PropDesValue == null)
                return;
            #region Comment
            if (PropSrc.rtcIsIconic && PropDes.rtcIsIconic)
            {
                // Trường hợp SImage (InputImage) dùng System.Drawing.Image
                if (PropSrcValue.PropertyType == typeof(System.Drawing.Image) &&
                    PropDesValue.PropertyType == typeof(System.Drawing.Image))
                {
                    var srcImg = (System.Drawing.Image)PropSrcValue.GetValue(PropSrc, null);
                    PropDesValue.SetValue(PropDes,
                        srcImg != null ? (System.Drawing.Image)srcImg.Clone() : null);

                    //return; 
                }

                // (Nếu bạn có thêm các kiểu iconic khác như HObject, HRegion...
                //  thì có thể giữ hoặc khôi phục code comment cũ ở đây.)
                //Cả 2 thuộc tính là biến Iconic
                //{
                //    if (PropSrcValue.PropertyType == typeof(Image) &&
                //        PropDesValue.PropertyType == typeof(Image))
                //        PropDesValue.SetValue(PropDes,
                //            GlobFuncs.GetValueFromHImageByIndex((Image)PropSrcValue.GetValue(PropSrc, null),
                //                PropDes.rtcRefIndex));
                //    else if (PropSrcValue.PropertyType == PropDesValue.PropertyType)
                //        switch (PropSrcValue.PropertyType.Name)
                //        {
                //            case nameof(SHObject):
                //                {
                //                    PropDesValue.SetValue(PropDes,
                //                        GlobFuncs.GetValueFromHObjectByIndex((HObject)PropSrcValue.GetValue(PropSrc, null),
                //                            PropDes.rtcRefIndex));
                //                    break;
                //                }
                //            case nameof(SHRegion):
                //                {
                //                    PropDesValue.SetValue(PropDes,
                //                        GlobFuncs.GetValueFromHRegionByIndex((HRegion)PropSrcValue.GetValue(PropSrc, null),
                //                            PropDes.rtcRefIndex));
                //                    break;
                //                }
                //            case nameof(SHXLDCont):
                //                {
                //                    PropDesValue.SetValue(PropDes,
                //                        GlobFuncs.GetValueFromHXLDByIndex((HXLD)PropSrcValue.GetValue(PropSrc, null),
                //                            PropDes.rtcRefIndex));
                //                    break;
                //                }
                //        }
                //    else if (PropDesValue.PropertyType == typeof(HObject))
                //    {
                //        switch (PropSrcValue.PropertyType.Name)
                //        {
                //            case nameof(HRegion):
                //                {
                //                    PropDesValue.SetValue(PropDes,
                //                        GlobFuncs.GetValueFromHRegionByIndex((HRegion)PropSrcValue.GetValue(PropSrc, null),
                //                            PropDes.rtcRefIndex));
                //                    break;
                //                }
                //            case nameof(HXLDCont):
                //                {
                //                    PropDesValue.SetValue(PropDes,
                //                        GlobFuncs.GetValueFromHXLDByIndex((HXLD)PropSrcValue.GetValue(PropSrc, null),
                //                            PropDes.rtcRefIndex));
                //                    break;
                //                }
                //            default:
                //                {
                //                    PropDesValue.SetValue(PropDes, null);
                //                    break;
                //                }
                //        }
                //    }
                //    else if (PropSrcValue.PropertyType == typeof(HObject))
                //    {
                //        switch (PropDesValue.PropertyType.Name)
                //        {
                //            case nameof(HRegion):
                //                {
                //                    PropDesValue.SetValue(PropDes,
                //                        GlobFuncs.GetValueFromHRegionByIndex(new HRegion((HObject)PropSrcValue.GetValue(PropSrc, null)),
                //                            PropDes.rtcRefIndex));
                //                    break;
                //                }
                //            case nameof(HXLDCont):
                //                {
                //                    PropDesValue.SetValue(PropDes,
                //                        GlobFuncs.GetValueFromHXLDByIndex(new HXLDCont((HObject)PropSrcValue.GetValue(PropSrc, null)),
                //                            PropDes.rtcRefIndex));
                //                    break;
                //                }
                //            default:
                //                {
                //                    PropDesValue.SetValue(PropDes, null);
                //                    break;
                //                }
                //        }
                //    }
                //    else
                //        PropDesValue.SetValue(PropDes, null);
                //}
            }
            #endregion

            else if ((PropertyInfoDes.PropertyType.Name == nameof(SListDouble) ||
                PropertyInfoDes.PropertyType.Name == nameof(SListString) ||
                PropertyInfoDes.PropertyType.Name == nameof(SListObject)) &&
                PropertyInfoSrc.PropertyType.Name == nameof(SBool))
                PropDesValue.SetValue(PropDes, ((bool)PropSrcValue.GetValue(PropSrc, null)).ToString());

            else if ((PropertyInfoDes.PropertyType.Name == nameof(SListDouble) ||
                PropertyInfoDes.PropertyType.Name == nameof(SListString) ||
                PropertyInfoDes.PropertyType.Name == nameof(SListObject)) &&
               (PropertyInfoSrc.PropertyType.Name != nameof(SListObject) &&
                PropertyInfoSrc.PropertyType.Name != nameof(SListDouble) &&
                PropertyInfoSrc.PropertyType.Name != nameof(SListString)))
                PropDesValue.SetValue(PropDes, PropSrcValue.GetValue(PropSrc, null));
            else if ((PropertyInfoDes.PropertyType.Name != nameof(SListDouble) &&
                 PropertyInfoDes.PropertyType.Name != nameof(SListString) &&
                 PropertyInfoDes.PropertyType.Name != nameof(SListObject)) &&
                (PropertyInfoSrc.PropertyType.Name == nameof(SListDouble) ||
                 PropertyInfoSrc.PropertyType.Name == nameof(SListObject) ||
                 PropertyInfoSrc.PropertyType.Name == nameof(SListString)))
            {

                string sValue = string.Empty;

                switch (PropSrcValue.PropertyType.Name)
                {

                    case nameof(SListDouble):
                        List<double> ldValue = (List<double>)PropSrcValue.GetValue(PropSrc, null);
                        if (ldValue != null && ldValue.Count > 0)
                        {
                            if (string.IsNullOrEmpty(PropDes.rtcRefIndex))
                                sValue = GlobFuncs.Ve2Str(ldValue[0]);
                            else if (int.TryParse(PropDes.rtcRefIndex, out int indexSrc))
                                if (indexSrc < ldValue.Count)
                                    sValue = GlobFuncs.Ve2Str(ldValue[indexSrc]);
                        }
                        break;
                    case nameof(SListString):
                        List<string> lsValue = (List<string>)PropSrcValue.GetValue(PropSrc, null);
                        if (lsValue != null && lsValue.Count > 0)
                        {
                            if (string.IsNullOrEmpty(PropDes.rtcRefIndex))
                                sValue = GlobFuncs.Ve2Str(lsValue[0]);
                            else if (int.TryParse(PropDes.rtcRefIndex, out int indexSrc))
                                if (indexSrc < lsValue.Count)
                                    sValue = GlobFuncs.Ve2Str(lsValue[indexSrc]);
                        }
                        break;
                    case nameof(SListObject):
                        List<object> loValue = (List<object>)PropSrcValue.GetValue(PropSrc, null);
                        if (loValue != null && loValue.Count > 0)
                        {
                            if (string.IsNullOrEmpty(PropDes.rtcRefIndex))
                                sValue = GlobFuncs.Ve2Str(loValue[0]);
                            else if (int.TryParse(PropDes.rtcRefIndex, out int indexSrc))
                                if (indexSrc < loValue.Count)
                                    sValue = GlobFuncs.Ve2Str(loValue[indexSrc]);
                        }
                        break;
                }

                //List hValue = (HTuple)PropSrcValue.GetValue(PropSrc, null);
                //if (hValue != null && hValue.Length > 0)
                //{
                //    if (string.IsNullOrEmpty(PropDes.rtcRefIndex))
                //        sValue = GlobFuncs.He2Str(hValue.TupleSelect(0));
                //    else if (int.TryParse(PropDes.rtcRefIndex, out int indexSrc))
                //        if (indexSrc < hValue.Length)
                //            sValue = GlobFuncs.He2Str(hValue.TupleSelect(indexSrc));
                //}

                switch (PropertyInfoDes.PropertyType.Name)
                {
                    case nameof(SString):
                        PropDesValue.SetValue(PropDes, sValue);
                        break;
                    case nameof(SInt):
                        PropDesValue.SetValue(PropDes, int.TryParse(sValue, out int iValue) ? iValue : 0);
                        break;
                    case nameof(SDouble):
                        if (double.TryParse(sValue, out double dValue))
                            PropDesValue.SetValue(PropDes, dValue);
                        else
                            PropDesValue.SetValue(PropDes, 0);
                        break;
                    case nameof(SBool):
                        PropDesValue.SetValue(PropDes, bool.TryParse(sValue, out bool bValue) && bValue);
                        break;
                }
            }
            else
                try
                {
                    string sValue = string.Empty;

                    switch (PropSrc.GetType().Name)
                    {
                        case nameof(SListDouble):
                                List<double> ldValue = (List<double>)(PropSrcValue.GetValue(PropSrc, null));
                                ldValue = GlobFuncs.GetValueDoubleByIndex(ldValue,PropDes.rtcRefIndex);
                                 sValue = GlobFuncs.Ve2Str(ldValue);
                            switch (PropertyInfoDes.PropertyType.Name)
                            {
                                case nameof(SString):
                                    {
                                        PropDesValue.SetValue(PropDes, sValue);
                                        break;
                                    }
                                case nameof(SInt):
                                    {
                                        PropDesValue.SetValue(PropDes, int.TryParse(sValue, out int iValue) ? iValue : 0);
                                        break;
                                    }
                                case nameof(SDouble):
                                    {
                                        if (double.TryParse(sValue, out double dValue))
                                            PropDesValue.SetValue(PropDes, dValue);
                                        else
                                            PropDesValue.SetValue(PropDes, 0);
                                        break;
                                    }
                                case nameof(SBool):
                                    {
                                        PropDesValue.SetValue(PropDes, bool.TryParse(sValue, out bool bValue) && bValue);
                                        break;
                                    }
                                case nameof(SListDouble):
                                    {
                                        PropDesValue.SetValue(PropDes, ldValue);
                                        break;
                                    }
                                case nameof(SListString):
                                    {
                                        PropDesValue.SetValue(PropDes, GlobFuncs.ListDoubleToListString(ldValue));
                                        break;
                                    }
                                case nameof(SListObject):
                                    {
                                        PropDesValue.SetValue(PropDes, GlobFuncs.ListDoubleToListObject(ldValue));
                                        break;
                                    }
                                default:
                                    {
                                        PropDesValue.SetValue(PropDes, sValue);
                                        break;
                                    }
                            }
                            break;
                        case nameof(SListString):
                            List<string> lsValue = (List<string>)(PropSrcValue.GetValue(PropSrc, null));
                            lsValue = GlobFuncs.GetValueStringByIndex(lsValue, PropDes.rtcRefIndex);
                            sValue = GlobFuncs.Ve2Str(lsValue);
                            switch (PropertyInfoDes.PropertyType.Name)
                            {
                                case nameof(SString):
                                    {
                                        PropDesValue.SetValue(PropDes, sValue);
                                        break;
                                    }
                                case nameof(SInt):
                                    {
                                        PropDesValue.SetValue(PropDes, int.TryParse(sValue, out int iValue) ? iValue : 0);
                                        break;
                                    }
                                case nameof(SDouble):
                                    {
                                        if (double.TryParse(sValue, out double dValue))
                                            PropDesValue.SetValue(PropDes, dValue);
                                        else
                                            PropDesValue.SetValue(PropDes, 0);
                                        break;
                                    }
                                case nameof(SBool):
                                    {
                                        PropDesValue.SetValue(PropDes, bool.TryParse(sValue, out bool bValue) && bValue);
                                        break;
                                    }
                                case nameof(SListDouble):
                                    {
                                        PropDesValue.SetValue(PropDes, GlobFuncs.Ve2Double(lsValue));
                                        break;
                                    }
                                case nameof(SListString):
                                    {
                                        PropDesValue.SetValue(PropDes, lsValue);
                                        break;
                                    }
                                case nameof(SListObject):
                                    {
                                        PropDesValue.SetValue(PropDes, lsValue);
                                        break;
                                    }
                                default:
                                    {
                                        PropDesValue.SetValue(PropDes, sValue);
                                        break;
                                    }
                            }
                            break;
                        case nameof(SListObject):
                            List<object> loValue = (List<object>)(PropSrcValue.GetValue(PropSrc, null));
                            loValue = GlobFuncs.GetValueObjectByIndex(loValue, PropDes.rtcRefIndex);
                            sValue = GlobFuncs.Ve2Str(loValue);
                            switch (PropertyInfoDes.PropertyType.Name)
                            {
                                case nameof(SString):
                                    {
                                        PropDesValue.SetValue(PropDes, sValue);
                                        break;
                                    }
                                case nameof(SInt):
                                    {
                                        PropDesValue.SetValue(PropDes, int.TryParse(sValue, out int iValue) ? iValue : 0);
                                        break;
                                    }
                                case nameof(SDouble):
                                    {
                                        if (double.TryParse(sValue, out double dValue))
                                            PropDesValue.SetValue(PropDes, dValue);
                                        else
                                            PropDesValue.SetValue(PropDes, 0);
                                        break;
                                    }
                                case nameof(SBool):
                                    {
                                        PropDesValue.SetValue(PropDes, bool.TryParse(sValue, out bool bValue) && bValue);
                                        break;
                                    }
                                case nameof(SListDouble):
                                    {
                                        PropDesValue.SetValue(PropDes, GlobFuncs.Ve2Double(loValue));
                                        break;
                                    }
                                case nameof(SListString):
                                    {
                                        PropDesValue.SetValue(PropDes, loValue.Cast<string>().ToList());
                                        break;
                                    }
                                case nameof(SListObject):
                                    {
                                        PropDesValue.SetValue(PropDes, loValue);
                                        break;
                                    }
                                default:
                                    {
                                        PropDesValue.SetValue(PropDes, sValue);
                                        break;
                                    }
                            }
                            break;
                    }
                    
                    //HTuple hValue = new HTuple(PropSrcValue.GetValue(PropSrc, null));
                    //ldValue = GlobFuncs.GetValueFromHTupleByIndex(hValue,
                    //    PropDes.rtcRefIndex);
                    //string sValue = GlobFuncs.HTuple2Str(hValue);

                    //switch (PropertyInfoDes.PropertyType.Name)
                    //{
                    //    case nameof(SString):
                    //        {
                    //            PropDesValue.SetValue(PropDes, sValue);
                    //            break;
                    //        }
                    //    case nameof(SInt):
                    //        {
                    //            PropDesValue.SetValue(PropDes, int.TryParse(sValue, out int iValue) ? iValue : 0);
                    //            break;
                    //        }
                    //    case nameof(SDouble):
                    //        {
                    //            if (double.TryParse(sValue, out double dValue))
                    //                PropDesValue.SetValue(PropDes, dValue);
                    //            else
                    //                PropDesValue.SetValue(PropDes, 0);
                    //            break;
                    //        }
                    //    case nameof(SBool):
                    //        {
                    //            PropDesValue.SetValue(PropDes, bool.TryParse(sValue, out bool bValue) && bValue);
                    //            break;
                    //        }
                    //    case nameof(SHTuple):
                    //        {
                    //            PropDesValue.SetValue(PropDes, hValue);
                    //            break;
                    //        }
                    //    default:
                    //        {
                    //            PropDesValue.SetValue(PropDes, sValue);
                    //            break;
                    //        }
                    //}
                }
                catch
                {
                    PropDesValue.SetValue(PropDes, null);
                }
        }
        
        public void RebuildValueWhenLink_DataItemToProp(SStringBuilderItem dataItemSrc, PropertyInfo PropertyInfoDes,
            cAction actionSrc)
        {
            RTCVariableType PropDes = (RTCVariableType)PropertyInfoDes.GetValue(this, null);
            if (PropDes == null) return;
            PropertyInfo PropDesValue = PropDes.GetType().GetProperty(cPropertyName.rtcValue);
            if (PropDesValue == null)
                return;
            string sValue;
            switch (PropertyInfoDes.PropertyType.Name)
            {
                case nameof(SListDouble):
                    {
                        try
                        {
                            PropDesValue.SetValue(PropDes, GlobFuncs.GetValueDoubleByIndex(dataItemSrc.ListDoubleValue, PropDes.rtcRefIndex));
                        }
                        catch
                        {
                            PropDesValue.SetValue(PropDes, dataItemSrc.ListDoubleValue);
                        }

                        break;
                    }
                case nameof(SListString):
                    {
                        try
                        {
                            PropDesValue.SetValue(PropDes, GlobFuncs.GetValueStringByIndex(dataItemSrc.ListStringValue, PropDes.rtcRefIndex));
                        }
                        catch
                        {
                            PropDesValue.SetValue(PropDes, dataItemSrc.ListStringValue);
                        }

                        break;
                    }
                case nameof(SString):
                    {
                        if (dataItemSrc.ListStringValue == null || dataItemSrc.ListStringValue.Count <= 0)
                            PropDesValue.SetValue(PropDes, GlobFuncs.Ve2Str(string.Empty));
                        else
                            PropDesValue.SetValue(PropDes, GlobFuncs.Ve2Str(dataItemSrc.ListStringValue[0]));
                        break;
                    }
                case nameof(SInt):
                    {
                        if (dataItemSrc.ListDoubleValue == null || dataItemSrc.ListDoubleValue.Count <= 0)
                            sValue = "0";
                        else
                            sValue = GlobFuncs.Ve2Str(dataItemSrc.ListDoubleValue[0]);
                        int.TryParse(sValue, out int iValue);
                        PropDesValue.SetValue(PropDes, iValue);
                        break;
                    }
                case nameof(SDouble):
                    {
                        if (dataItemSrc.ListDoubleValue == null || dataItemSrc.ListDoubleValue.Count <= 0)
                            sValue = "0";
                        else
                            sValue = GlobFuncs.Ve2Str(dataItemSrc.ListDoubleValue[0]);
                        double.TryParse(sValue, out double dValue);
                        PropDesValue.SetValue(PropDes, dValue);
                        break;
                    }
                case nameof(SBool):
                    {
                        if (dataItemSrc.ListStringValue == null || dataItemSrc.ListStringValue.Count <= 0)
                            sValue = "false";
                        else
                            sValue = GlobFuncs.Ve2Str(dataItemSrc.ListStringValue[0]);
                        bool.TryParse(sValue, out bool bValue);
                        PropDesValue.SetValue(PropDes, bValue);
                        break;
                    }
            }
        }
        public bool ResetPropertyValue(Guid resetToolID)
        {
            bool isRefreshRef = false;
            var properties = this.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(this, null)) != null &&
                                                                       ((RTCVariableType)x.GetValue(this, null)).ParentIDResets != null &&
                                                                       ((RTCVariableType)x.GetValue(this, null)).ParentIDResets.Contains(resetToolID));
            foreach (PropertyInfo item in properties)
            {
                RTCVariableType propertyInfo = (RTCVariableType)this.GetType().GetProperty(item.Name)?.GetValue(this, null);
                if (propertyInfo == null)
                    continue;

                PropertyInfo propertyInfoValue = item.PropertyType.GetProperty(cPropertyName.rtcValue);
                if (propertyInfoValue?.GetValue(propertyInfo, null) != null)
                {
                    switch (this.ActionType)
                    {
                        case EActionTypes.DataInstance:
                            {
                                if (item.Name == nameof(Value))
                                {
                                    Value.rtcValue = GlobFuncs.Clone(DefaultValue.rtcValue);
                                    isRefreshRef = true;
                                    if (this.ViewInfo != null)
                                        ((ucBaseActionDetail)this.ViewInfo).UpdatePropertyValueToAllControls(item.Name);
                                    continue;
                                }
                                break;
                            }
                    }

                    object obj = propertyInfoValue.GetValue(propertyInfo, null);
                    switch (item.PropertyType.Name)
                    {
                        case nameof(SBool):
                            propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_Bool(nameof(item.Name) + _SuffixName));
                            break;
                        //case nameof(SWindow):
                        //    propertyInfoValue.SetValue(propertyInfo, null);
                        //    break;
                        case nameof(SImage):
                            ((SImage)propertyInfo).Dispose();
                            break;
                        case nameof(SListDouble):
                            propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_ListDouble(nameof(item.Name) + _SuffixName));
                            break;
                        case nameof(SListString):
                            propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_ListString(nameof(item.Name) + _SuffixName));
                            break;
                        case nameof(SListObject):
                            propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_ListObject(nameof(item.Name) + _SuffixName));
                            break;
                        case nameof(SString):
                            propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_Text(nameof(item.Name) + _SuffixName));
                            break;
                        case nameof(SInt):
                            propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_Int(nameof(item.Name) + _SuffixName));
                            break;
                        case nameof(SDouble):
                            propertyInfoValue.SetValue(propertyInfo, CommonData.GetDefaultValues_Double(nameof(item.Name) + _SuffixName));
                            break;
                        //case nameof(SHRegion):
                        //    ((SHRegion)propertyInfo).Dispose();
                        //    break;
                        //case nameof(SHObject):
                        //    ((SHObject)propertyInfo).Dispose();
                        //    break;
                        //case nameof(SHXLDCont):
                        //    ((SHXLDCont)propertyInfo).Dispose();
                        //    //propertyInfoValue.SetValue(propertyInfo, null);
                            break;
                        default:
                            break;
                    }

                    isRefreshRef = true;
                    if (this.ViewInfo != null)
                        ((ucBaseActionDetail)this.ViewInfo).UpdatePropertyValueToAllControls(item.Name);
                }
            }
            if (DataItems != null)
            {
                var dataItems = DataItems.Where(x => x.ParentIDResets != null &&
                                                     x.ParentIDResets.Contains(resetToolID)).ToList();

                foreach (var dataItem in dataItems)
                {
                    if (!dataItem.ParentIDResets.Contains(resetToolID))
                        continue;
                    switch (dataItem.ValueStyle)
                    {
                        case EHTupleStyle.Boolean:
                            dataItem.ListStringValue = new List<string>() { false.ToString().ToLower() };
                            break;
                        case EHTupleStyle.Integer:
                            dataItem.ListDoubleValue = new List<double>() { 0 };
                            break;
                        case EHTupleStyle.Real:
                            dataItem.ListDoubleValue = new List<double>() { 0 }; 
                            break;
                        default:
                            {
                                dataItem.ListDoubleValue = new List<double>();
                                dataItem.ListStringValue = new List<string>();

                            }
                            break;
                    }

                    isRefreshRef = true;
                    if (this.ViewInfo != null)
                        ((ucBaseActionDetail)this.ViewInfo).UpdatePropertyValueToAllControls(dataItem.Name);
                }
            }

            if (MyExpression != null && MyExpression.Operands != null)
            {
                var operands = MyExpression.Operands.Where(x => x.ParentIDResets != null &&
                                                                x.ParentIDResets.Contains(resetToolID)).ToList();
                foreach (var operandItem in operands)
                {
                    if (!operandItem.ParentIDResets.Contains(resetToolID))
                        continue;
                    switch (operandItem.ValueStyle)
                    {
                        case EHTupleStyle.Boolean:
                            operandItem.ListStringValue = new List<string>() { false.ToString().ToLower() };
                            break;
                        case EHTupleStyle.Integer:
                            operandItem.ListDoubleValue = new List<double>() { 0 };
                            break;
                        case EHTupleStyle.Real:
                            operandItem.ListDoubleValue = new List<double>() { 0 };
                            break;
                        default:
                            operandItem.ListDoubleValue = new List<double>();
                            operandItem.ListStringValue = new List<string>();
                            break;
                    }

                    isRefreshRef = true;
                    if (this.ViewInfo != null)
                        ((ucBaseActionDetail)this.ViewInfo).UpdatePropertyValueToAllControls(operandItem.Name);
                }
            }
            if (isRefreshRef)
                this.MyGroup.SetValuetoVariableIsParentRef(this);

            return true;
        }
        public void Run_Wait()
        {
            Passed.rtcValue = true;
            Thread.Sleep(TimeDelay.rtcValue);
            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        //public void Run_SaveProject()
        //{
        //    IsFinishRunOneTime.rtcValue = false;
        //    ErrMessage.rtcValue = new List<String>() { string.Empty };
        //    Passed.rtcValue = false;
        //    if (!ProjectFunctions.cProjectFunctions.SaveProject(GlobVar.CurrentProject, this.MyGroup.MyCam.ID, ESaveMode.OneCam, false))
        //    {
        //        ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.Err_SaveObject, new string[] { cStrings.Project.ToLower() }, new string[] { cStrings.ProjectV.ToLower() }) };
        //        return;
        //    }
        //    else
        //        Passed.rtcValue = true;
        //    this.MyGroup.DataChanged = false;
        //    if (IsRunOneTime.rtcValue)
        //        IsFinishRunOneTime.rtcValue = Passed.rtcValue;
        //}
        public void Run_ResetActionCount()
        {
            Passed.rtcValue = true;
            StartNumber.rtcValue = ResetNumber.rtcValue;
            if (!MyGroup.RunSimple && DisplayOutput.rtcValue && ActionType != EActionTypes.MainAction && ViewInfo != null)
            {
                ((ucBaseActionDetail)ViewInfo).UpdatePropertyValueToAllControls(nameof(StartNumber));
                ((ucBaseActionDetail)ViewInfo).ReviewAllPropertyValueToViewInfo();

            }
        }
        public void Run_ActionCount(bool isViewValueToViewInfo = false)
        {
            Passed.rtcValue = true;
            StartNumber.rtcValue += Step.rtcValue;
            if (Step.rtcValue < 0)
            {
                if (StartNumber.rtcValue <= NumberBeginRestart.rtcValue)
                    StartNumber.rtcValue = ResetNumber.rtcValue;
            }
            else if (StartNumber.rtcValue >= NumberBeginRestart.rtcValue)
                StartNumber.rtcValue = ResetNumber.rtcValue;
            if (ResetNumberWhenNewDay.rtcValue)
                if (OldDay.rtcValue != DateTime.Now.ToString(cDateTimeFormats.yyyyMMdd))
                {
                    StartNumber.rtcValue = ResetNumber.rtcValue;
                    OldDay.rtcValue = DateTime.Now.ToString(cDateTimeFormats.yyyyMMdd);
                }
            if (StartNumber.rtcValue == FailNumber.rtcValue)
                Passed.rtcValue = false;

        }

    }

}

