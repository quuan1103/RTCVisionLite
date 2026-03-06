using Emgu.CV.Util;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void Run_LinkValue_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_LinkValue();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void Run_LinkValue_LinkPropToProp(cLinkProperty linkItem, RTCVariableType sourceInfo,
                 RTCVariableType targetInfo)
        {
            if (sourceInfo == null || targetInfo == null)
                return;

            //Lấy giá trị của source
            object objectValue = null;
            Image imageValue = null;
            List<VectorOfVectorOfPoint> regionValue = null;

            List<string> ListStringValue = new List<string>();
            List<object> ListObjectValue = new List<object>();
            List<double> ListDoubleValue = new List<double>();
            int intValue = 0;
            double doubleValue = 0;
            bool boolValue = false;
            string stringValue = string.Empty;

            string sourceValueType = nameof(Object);

            if (sourceInfo.GetType().Name == nameof(SListString))
            {
                SListString value = (SListString)sourceInfo;

                if (linkItem.SourceIndex == null || linkItem.SourceIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.SourceIndex[0]) == cStrings.None)
                {
                    ListStringValue = value.rtcValue;
                    sourceValueType = nameof(SListString);
                }
                else
                {
                    int indexGetValue = 0;
                    int lengthGetValue = 0;

                    for (int i = 0; i < linkItem.SourceIndex.Count; i++)
                    {
                        bool bBreak = false;
                        int index = GlobFuncs.Ve2Interger(linkItem.SourceIndex[i]);
                        switch (i)
                        {
                            case 0:
                                {
                                    switch (value.ValueStyle)
                                    {
                                        case EHTupleStyle.OriginList:
                                            {
                                                indexGetValue = 3 * index;
                                                lengthGetValue = 3;
                                                break;
                                            }
                                        case EHTupleStyle.PointList:
                                            {
                                                indexGetValue = 2 * index;
                                                lengthGetValue = 2;
                                                break;
                                            }
                                        case EHTupleStyle.RectangleList:
                                            {
                                                indexGetValue = 5 * index;
                                                lengthGetValue = 5;
                                                break;
                                            }
                                        default:
                                            {
                                                indexGetValue = index;
                                                lengthGetValue = 1;
                                                bBreak = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    indexGetValue = indexGetValue + index;
                                    lengthGetValue = 1;
                                    break;
                                }
                        }
                        if (bBreak)
                            break;
                    }

                    if (value.rtcValue.Count > indexGetValue + lengthGetValue)
                    {
                        ListStringValue = new List<string>();
                        for (int i = indexGetValue; i < indexGetValue + lengthGetValue; i++)
                            ListStringValue.Add(value.rtcValue[i]);
                        sourceValueType = nameof(SListString);
                    }
                }
            }

            if (sourceInfo.GetType().Name == nameof(SListDouble))
            {
                SListDouble value = (SListDouble)sourceInfo;

                if (linkItem.SourceIndex == null || linkItem.SourceIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.SourceIndex[0]) == cStrings.None)
                {
                    ListDoubleValue = value.rtcValue;
                    sourceValueType = nameof(SListDouble);
                }
                else
                {
                    int indexGetValue = 0;
                    int lengthGetValue = 0;

                    for (int i = 0; i < linkItem.SourceIndex.Count; i++)
                    {
                        bool bBreak = false;
                        int index = GlobFuncs.Ve2Interger(linkItem.SourceIndex[i]);
                        switch (i)
                        {
                            case 0:
                                {
                                    switch (value.ValueStyle)
                                    {
                                        case EHTupleStyle.OriginList:
                                            {
                                                indexGetValue = 3 * index;
                                                lengthGetValue = 3;
                                                break;
                                            }
                                        case EHTupleStyle.PointList:
                                            {
                                                indexGetValue = 2 * index;
                                                lengthGetValue = 2;
                                                break;
                                            }
                                        case EHTupleStyle.RectangleList:
                                            {
                                                indexGetValue = 5 * index;
                                                lengthGetValue = 5;
                                                break;
                                            }
                                        default:
                                            {
                                                indexGetValue = index;
                                                lengthGetValue = 1;
                                                bBreak = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    indexGetValue = indexGetValue + index;
                                    lengthGetValue = 1;
                                    break;
                                }
                        }
                        if (bBreak)
                            break;
                    }

                    if (value.rtcValue.Count > indexGetValue + lengthGetValue)
                    {
                        ListDoubleValue = new List<double>();
                        for (int i = indexGetValue; i < indexGetValue + lengthGetValue; i++)
                            ListDoubleValue.Add(value.rtcValue[i]);
                        sourceValueType = nameof(SListDouble);
                    }
                }
            }
            if (sourceInfo.GetType().Name == nameof(SListObject))
            {
                SListObject value = (SListObject)sourceInfo;

                if (linkItem.SourceIndex == null || linkItem.SourceIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.SourceIndex[0]) == cStrings.None)
                {
                    ListObjectValue = value.rtcValue;
                    sourceValueType = nameof(ListObjectValue);
                }
                else
                {
                    int indexGetValue = 0;
                    int lengthGetValue = 0;

                    for (int i = 0; i < linkItem.SourceIndex.Count; i++)
                    {
                        bool bBreak = false;
                        int index = GlobFuncs.Ve2Interger(linkItem.SourceIndex[i]);
                        switch (i)
                        {
                            case 0:
                                {
                                    switch (value.ValueStyle)
                                    {
                                        case EHTupleStyle.OriginList:
                                            {
                                                indexGetValue = 3 * index;
                                                lengthGetValue = 3;
                                                break;
                                            }
                                        case EHTupleStyle.PointList:
                                            {
                                                indexGetValue = 2 * index;
                                                lengthGetValue = 2;
                                                break;
                                            }
                                        case EHTupleStyle.RectangleList:
                                            {
                                                indexGetValue = 5 * index;
                                                lengthGetValue = 5;
                                                break;
                                            }
                                        default:
                                            {
                                                indexGetValue = index;
                                                lengthGetValue = 1;
                                                bBreak = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    indexGetValue = indexGetValue + index;
                                    lengthGetValue = 1;
                                    break;
                                }
                        }
                        if (bBreak)
                            break;
                    }

                    if (value.rtcValue.Count > indexGetValue + lengthGetValue)
                    {
                        ListObjectValue = new List<object>();
                        for (int i = indexGetValue; i < indexGetValue + lengthGetValue; i++)
                            ListObjectValue.Add(value.rtcValue[i]);
                        sourceValueType = nameof(SListObject);
                    }
                }
            }

            else
            {
                switch (sourceInfo.GetType().Name)
                {
                    case nameof(SString):
                        {
                            stringValue = (string)sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            sourceValueType = nameof(SString);
                            break;
                        }
                    case nameof(SInt):
                        {
                            intValue = (int)sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            sourceValueType = nameof(SInt);
                            break;
                        }
                    case nameof(SDouble):
                        {
                            doubleValue = (double)sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            sourceValueType = nameof(SDouble);
                            break;
                        }
                    case nameof(SBool):
                        {
                            boolValue = (bool)sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            sourceValueType = nameof(SBool);
                            break;
                        }
                    case nameof(SListImage):
                        {
                            imageValue = (Image)sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            imageValue = GlobFuncs.GetValueFromSImageByIndex(new List<Image>() { imageValue }, GlobFuncs.Ve2Str(linkItem.SourceIndex))[0];
                            if (imageValue != null)
                                imageValue = (Image)imageValue.Clone();
                            sourceValueType = nameof(SImage);
                            break;
                        }
                    case nameof(SListVector):
                        {
                            regionValue = (List<VectorOfVectorOfPoint>)sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            regionValue = GlobFuncs.GetValueListVectorByIndex(regionValue, GlobFuncs.Ve2Str(linkItem.SourceIndex));
                            sourceValueType = nameof(SListVector);
                            break;
                        }
                    default:
                        {
                            objectValue = sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            sourceValueType = nameof(Object);
                            break;
                        }
                }
            }

            //Gán vào target
            PropertyInfo targetInfoValue = targetInfo.GetType().GetProperty(cPropertyName.rtcValue);
            if (targetInfoValue == null) return;
            if (targetInfo.GetType().Name == nameof(SListString))
            {
                SListString value = (SListString)targetInfo;

                if (linkItem.TargetIndex == null || linkItem.TargetIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.TargetIndex[0]) == cStrings.None)
                {
                    ListStringValue = value.rtcValue;
                    sourceValueType = nameof(SListString);
                }
                else
                {
                    int indexGetValue = 0;
                    int lengthGetValue = 0;

                    for (int i = 0; i < linkItem.TargetIndex.Count; i++)
                    {
                        bool bBreak = false;
                        int index = GlobFuncs.Ve2Interger(linkItem.TargetIndex[i]);
                        switch (i)
                        {
                            case 0:
                                {
                                    switch (value.ValueStyle)
                                    {
                                        case EHTupleStyle.OriginList:
                                            {
                                                indexGetValue = 3 * index;
                                                lengthGetValue = 3;
                                                break;
                                            }
                                        case EHTupleStyle.PointList:
                                            {
                                                indexGetValue = 2 * index;
                                                lengthGetValue = 2;
                                                break;
                                            }
                                        case EHTupleStyle.RectangleList:
                                            {
                                                indexGetValue = 5 * index;
                                                lengthGetValue = 5;
                                                break;
                                            }
                                        default:
                                            {
                                                indexGetValue = index;
                                                lengthGetValue = 1;
                                                bBreak = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    indexGetValue = indexGetValue + index;
                                    lengthGetValue = 1;
                                    break;
                                }
                        }
                        if (bBreak)
                            break;
                    }

                    if (value.rtcValue.Count > indexGetValue + lengthGetValue)
                    {
                        ListStringValue = new List<string>();
                        for (int i = indexGetValue; i < indexGetValue + lengthGetValue; i++)
                            ListStringValue.Add(value.rtcValue[i]);
                        sourceValueType = nameof(SListString);
                    }
                }
            }

            if (sourceInfo.GetType().Name == nameof(SListDouble))
            {
                SListDouble value = (SListDouble)sourceInfo;

                if (linkItem.TargetIndex == null || linkItem.TargetIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.TargetIndex[0]) == cStrings.None)
                {
                    ListDoubleValue = value.rtcValue;
                    sourceValueType = nameof(SListDouble);
                }
                else
                {
                    int indexGetValue = 0;
                    int lengthGetValue = 0;

                    for (int i = 0; i < linkItem.TargetIndex.Count; i++)
                    {
                        bool bBreak = false;
                        int index = GlobFuncs.Ve2Interger(linkItem.TargetIndex[i]);
                        switch (i)
                        {
                            case 0:
                                {
                                    switch (value.ValueStyle)
                                    {
                                        case EHTupleStyle.OriginList:
                                            {
                                                indexGetValue = 3 * index;
                                                lengthGetValue = 3;
                                                break;
                                            }
                                        case EHTupleStyle.PointList:
                                            {
                                                indexGetValue = 2 * index;
                                                lengthGetValue = 2;
                                                break;
                                            }
                                        case EHTupleStyle.RectangleList:
                                            {
                                                indexGetValue = 5 * index;
                                                lengthGetValue = 5;
                                                break;
                                            }
                                        default:
                                            {
                                                indexGetValue = index;
                                                lengthGetValue = 1;
                                                bBreak = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    indexGetValue = indexGetValue + index;
                                    lengthGetValue = 1;
                                    break;
                                }
                        }
                        if (bBreak)
                            break;
                    }

                    if (value.rtcValue.Count > indexGetValue + lengthGetValue)
                    {
                        ListDoubleValue = new List<double>();
                        for (int i = indexGetValue; i < indexGetValue + lengthGetValue; i++)
                            ListDoubleValue.Add(value.rtcValue[i]);
                        sourceValueType = nameof(SListDouble);
                    }
                }
            }
            if (sourceInfo.GetType().Name == nameof(SListObject))
            {
                SListObject value = (SListObject)sourceInfo;

                if (linkItem.TargetIndex == null || linkItem.TargetIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.TargetIndex[0]) == cStrings.None)
                {
                    ListObjectValue = value.rtcValue;
                    sourceValueType = nameof(ListObjectValue);
                }
                else
                {
                    int indexGetValue = 0;
                    int lengthGetValue = 0;

                    for (int i = 0; i < linkItem.TargetIndex.Count; i++)
                    {
                        bool bBreak = false;
                        int index = GlobFuncs.Ve2Interger(linkItem.TargetIndex[i]);
                        switch (i)
                        {
                            case 0:
                                {
                                    switch (value.ValueStyle)
                                    {
                                        case EHTupleStyle.OriginList:
                                            {
                                                indexGetValue = 3 * index;
                                                lengthGetValue = 3;
                                                break;
                                            }
                                        case EHTupleStyle.PointList:
                                            {
                                                indexGetValue = 2 * index;
                                                lengthGetValue = 2;
                                                break;
                                            }
                                        case EHTupleStyle.RectangleList:
                                            {
                                                indexGetValue = 5 * index;
                                                lengthGetValue = 5;
                                                break;
                                            }
                                        default:
                                            {
                                                indexGetValue = index;
                                                lengthGetValue = 1;
                                                bBreak = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    indexGetValue = indexGetValue + index;
                                    lengthGetValue = 1;
                                    break;
                                }
                        }
                        if (bBreak)
                            break;
                    }

                    if (value.rtcValue.Count > indexGetValue + lengthGetValue)
                    {
                        ListObjectValue = new List<object>();
                        for (int i = indexGetValue; i < indexGetValue + lengthGetValue; i++)
                            ListObjectValue.Add(value.rtcValue[i]);
                        sourceValueType = nameof(SListObject);
                    }
                }
            }

            else
            {
                switch (targetInfo.GetType().Name)
                {
                    case nameof(SString):
                        {
                            switch (sourceValueType)
                            {
                                case nameof(SInt):
                                    {
                                        targetInfoValue.SetValue(targetInfo, intValue.ToString());
                                        break;
                                    }
                                case nameof(SDouble):
                                    {
                                        targetInfoValue.SetValue(targetInfo, doubleValue.ToString());
                                        break;
                                    }
                                case nameof(SString):
                                    {
                                        targetInfoValue.SetValue(targetInfo, stringValue);
                                        break;
                                    }
                                case nameof(SBool):
                                    {
                                        targetInfoValue.SetValue(targetInfo, boolValue.ToString().ToLower());
                                        break;
                                    }
                                case nameof(SListString):
                                    {
                                        targetInfoValue.SetValue(targetInfo, GlobFuncs.Ve2Str(ListStringValue));
                                        break;
                                    }
                                case nameof(SListDouble):
                                    {
                                        targetInfoValue.SetValue(targetInfo, GlobFuncs.Ve2Str(ListDoubleValue));
                                        break;
                                    }
                                case nameof(SListObject):
                                    {
                                        targetInfoValue.SetValue(targetInfo, GlobFuncs.Ve2Str(ListObjectValue));
                                        break;
                                    }
                                case nameof(Object):
                                    {
                                        targetInfoValue.SetValue(targetInfo, int.TryParse(objectValue.ToString(), out intValue) ? intValue : 0);
                                        break;
                                    }
                                default:
                                    {
                                        targetInfoValue.SetValue(targetInfo, string.Empty);
                                        break;
                                    }
                            }
                            break;
                        }
                    case nameof(SInt):
                        {
                            switch (sourceValueType)
                            {
                                case nameof(SInt):
                                    {
                                        targetInfoValue.SetValue(targetInfo, intValue);
                                        break;
                                    }
                                case nameof(SDouble):
                                    {
                                        targetInfoValue.SetValue(targetInfo, (int)doubleValue);
                                        break;
                                    }
                                case nameof(SString):
                                    {
                                        targetInfoValue.SetValue(targetInfo, int.TryParse(stringValue, out intValue) ? intValue : 0);
                                        break;
                                    }
                                case nameof(SBool):
                                    {
                                        targetInfoValue.SetValue(targetInfo, boolValue ? 1 : 0);
                                        break;
                                    }
                                case nameof(SListDouble):
                                    {
                                        targetInfoValue.SetValue(targetInfo, ListDoubleValue.Count > 0 ? GlobFuncs.Ve2Interger(ListDoubleValue[0]) : 0);
                                        break;
                                    }
                                case nameof(SListString):
                                    {
                                        targetInfoValue.SetValue(targetInfo, ListStringValue.Count > 0 ? GlobFuncs.Ve2Interger(ListStringValue[0]) : 0);
                                        break;
                                    }
                                case nameof(SListObject):
                                    {
                                        targetInfoValue.SetValue(targetInfo, ListObjectValue.Count > 0 ? GlobFuncs.Ve2Interger(ListObjectValue[0]) : 0);
                                        break;
                                    }
                                case nameof(Object):
                                    {
                                        targetInfoValue.SetValue(targetInfo, int.TryParse(objectValue.ToString(), out intValue) ? intValue : 0);
                                        break;
                                    }
                            }
                            break;
                        }
                    case nameof(SDouble):
                        {
                            switch (sourceValueType)
                            {
                                case nameof(SInt):
                                    {
                                        targetInfoValue.SetValue(targetInfo, intValue);
                                        break;
                                    }
                                case nameof(SDouble):
                                    {
                                        targetInfoValue.SetValue(targetInfo, doubleValue);
                                        break;
                                    }
                                case nameof(SString):
                                    {
                                        targetInfoValue.SetValue(targetInfo, double.TryParse(stringValue, out doubleValue) ? doubleValue : 0);
                                        break;
                                    }
                                case nameof(SBool):
                                    {
                                        targetInfoValue.SetValue(targetInfo, boolValue ? 1 : 0);
                                        break;
                                    }
                                case nameof(SListDouble):
                                    {
                                        targetInfoValue.SetValue(targetInfo, ListDoubleValue.Count > 0 ? GlobFuncs.Ve2Interger(ListDoubleValue[0]) : 0);
                                        break;
                                    }
                                case nameof(SListString):
                                    {
                                        targetInfoValue.SetValue(targetInfo, ListStringValue.Count > 0 ? GlobFuncs.Ve2Interger(ListStringValue[0]) : 0);
                                        break;
                                    }
                                case nameof(SListObject):
                                    {
                                        targetInfoValue.SetValue(targetInfo, ListDoubleValue.Count > 0 ? GlobFuncs.Ve2Interger(ListDoubleValue[0]) : 0);
                                        break;
                                    }
                                case nameof(Object):
                                    {
                                        targetInfoValue.SetValue(targetInfo, double.TryParse(objectValue.ToString(), out doubleValue) ? doubleValue : 0);
                                        break;
                                    }
                            }
                            break;
                        }
                    case nameof(SBool):
                        {
                            switch (sourceValueType)
                            {
                                case nameof(SInt):
                                    {
                                        targetInfoValue.SetValue(targetInfo, intValue != 0);
                                        break;
                                    }
                                case nameof(SDouble):
                                    {
                                        targetInfoValue.SetValue(targetInfo, doubleValue != 0);
                                        break;
                                    }
                                case nameof(SString):
                                    {
                                        targetInfoValue.SetValue(targetInfo, bool.TryParse(stringValue, out boolValue) && boolValue);
                                        break;
                                    }
                                case nameof(SBool):
                                    {
                                        targetInfoValue.SetValue(targetInfo, boolValue);
                                        break;
                                    }
                                case nameof(SListObject):
                                    {
                                        targetInfoValue.SetValue(targetInfo, ListObjectValue.Count > 0 && GlobFuncs.Ve2Bool(ListObjectValue[0]));
                                        break;
                                    }
                                case nameof(SListString):
                                    {
                                        targetInfoValue.SetValue(targetInfo, ListStringValue.Count > 0 && GlobFuncs.Ve2Bool(ListStringValue[0]));
                                        break;
                                    }
                                case nameof(SListDouble):
                                    {
                                        targetInfoValue.SetValue(targetInfo, ListDoubleValue.Count > 0 && GlobFuncs.Ve2Bool(ListDoubleValue[0]));
                                        break;
                                    }
                                case nameof(Object):
                                    {
                                        targetInfoValue.SetValue(targetInfo, bool.TryParse(objectValue.ToString(), out boolValue) && boolValue);
                                        break;
                                    }
                            }
                            break;
                        }
                    case nameof(SImage):
                        {
                            targetInfoValue.SetValue(targetInfo, imageValue);
                            //imageValue.WriteImage("bmp",0,@"D:\1.bmp");

                            break;
                        }
                    case nameof(SListVector):
                        {
                            targetInfoValue.SetValue(targetInfo, regionValue);
                            break;
                        }
                    //case nameof(SHXLDCont):
                    //    {
                    //        targetInfoValue.SetValue(targetInfo, xldValue);
                    //        break;
                    //    }
                    //case nameof(SHObject):
                    //    {
                    //        targetInfoValue.SetValue(targetInfo, objValue);
                    //        break;
                    //    }
                    default:
                        {
                            targetInfoValue.SetValue(targetInfo, objectValue);
                            break;
                        }
                }
            }
        }
        public void Run_LinkValue_LinkPropToDataItem(cLinkProperty linkItem, RTCVariableType sourceInfo,
                 SStringBuilderItem dataItem)
        {
            if (sourceInfo == null || dataItem == null)
                return;

            //Lấy giá trị của source
            object objectValue = null;
            Image imageValue = null;
            List<VectorOfVectorOfPoint> regionValue = null;

            List<string> ListStringValue = new List<string>();
            List<object> ListObjectValue = new List<object>();
            List<double> ListDoubleValue = new List<double>();
            int intValue = 0;
            double doubleValue = 0;
            bool boolValue = false;
            string stringValue = string.Empty;

            string sourceValueType = nameof(Object);

            if (sourceInfo.GetType().Name == nameof(SListString))
            {
                SListString value = (SListString)sourceInfo;

                if (linkItem.SourceIndex == null || linkItem.SourceIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.SourceIndex[0]) == cStrings.None)
                {
                    ListStringValue = value.rtcValue;
                    sourceValueType = nameof(SListString);
                }
                else
                {
                    int indexGetValue = 0;
                    int lengthGetValue = 0;

                    for (int i = 0; i < linkItem.SourceIndex.Count; i++)
                    {
                        bool bBreak = false;
                        int index = GlobFuncs.Ve2Interger(linkItem.SourceIndex[i]);
                        switch (i)
                        {
                            case 0:
                                {
                                    switch (value.ValueStyle)
                                    {
                                        case EHTupleStyle.OriginList:
                                            {
                                                indexGetValue = 3 * index;
                                                lengthGetValue = 3;
                                                break;
                                            }
                                        case EHTupleStyle.PointList:
                                            {
                                                indexGetValue = 2 * index;
                                                lengthGetValue = 2;
                                                break;
                                            }
                                        case EHTupleStyle.RectangleList:
                                            {
                                                indexGetValue = 5 * index;
                                                lengthGetValue = 5;
                                                break;
                                            }
                                        default:
                                            {
                                                indexGetValue = index;
                                                lengthGetValue = 1;
                                                bBreak = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    indexGetValue = indexGetValue + index;
                                    lengthGetValue = 1;
                                    break;
                                }
                        }
                        if (bBreak)
                            break;
                    }

                    if (value.rtcValue.Count > indexGetValue + lengthGetValue)
                    {
                        ListStringValue = new List<string>();
                        for (int i = indexGetValue; i < indexGetValue + lengthGetValue; i++)
                            ListStringValue.Add(value.rtcValue[i]);
                        sourceValueType = nameof(SListString);
                    }
                }
            }

            else if (sourceInfo.GetType().Name == nameof(SListDouble))
            {
                SListDouble value = (SListDouble)sourceInfo;

                if (linkItem.SourceIndex == null || linkItem.SourceIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.SourceIndex[0]) == cStrings.None)
                {
                    ListDoubleValue = value.rtcValue;
                    sourceValueType = nameof(SListDouble);
                }
                else
                {
                    int indexGetValue = 0;
                    int lengthGetValue = 0;

                    for (int i = 0; i < linkItem.SourceIndex.Count; i++)
                    {
                        bool bBreak = false;
                        int index = GlobFuncs.Ve2Interger(linkItem.SourceIndex[i]);
                        switch (i)
                        {
                            case 0:
                                {
                                    switch (value.ValueStyle)
                                    {
                                        case EHTupleStyle.OriginList:
                                            {
                                                indexGetValue = 3 * index;
                                                lengthGetValue = 3;
                                                break;
                                            }
                                        case EHTupleStyle.PointList:
                                            {
                                                indexGetValue = 2 * index;
                                                lengthGetValue = 2;
                                                break;
                                            }
                                        case EHTupleStyle.RectangleList:
                                            {
                                                indexGetValue = 5 * index;
                                                lengthGetValue = 5;
                                                break;
                                            }
                                        default:
                                            {
                                                indexGetValue = index;
                                                lengthGetValue = 1;
                                                bBreak = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    indexGetValue = indexGetValue + index;
                                    lengthGetValue = 1;
                                    break;
                                }
                        }
                        if (bBreak)
                            break;
                    }

                    if (value.rtcValue.Count > indexGetValue + lengthGetValue)
                    {
                        ListDoubleValue = new List<double>();
                        for (int i = indexGetValue; i < indexGetValue + lengthGetValue; i++)
                            ListDoubleValue.Add(value.rtcValue[i]);
                        sourceValueType = nameof(SListDouble);
                    }
                }
            }
            else if (sourceInfo.GetType().Name == nameof(SListObject))
            {
                SListObject value = (SListObject)sourceInfo;

                if (linkItem.SourceIndex == null || linkItem.SourceIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.SourceIndex[0]) == cStrings.None)
                {
                    ListObjectValue = value.rtcValue;
                    sourceValueType = nameof(ListObjectValue);
                }
                else
                {
                    int indexGetValue = 0;
                    int lengthGetValue = 0;

                    for (int i = 0; i < linkItem.SourceIndex.Count; i++)
                    {
                        bool bBreak = false;
                        int index = GlobFuncs.Ve2Interger(linkItem.SourceIndex[i]);
                        switch (i)
                        {
                            case 0:
                                {
                                    switch (value.ValueStyle)
                                    {
                                        case EHTupleStyle.OriginList:
                                            {
                                                indexGetValue = 3 * index;
                                                lengthGetValue = 3;
                                                break;
                                            }
                                        case EHTupleStyle.PointList:
                                            {
                                                indexGetValue = 2 * index;
                                                lengthGetValue = 2;
                                                break;
                                            }
                                        case EHTupleStyle.RectangleList:
                                            {
                                                indexGetValue = 5 * index;
                                                lengthGetValue = 5;
                                                break;
                                            }
                                        default:
                                            {
                                                indexGetValue = index;
                                                lengthGetValue = 1;
                                                bBreak = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    indexGetValue = indexGetValue + index;
                                    lengthGetValue = 1;
                                    break;
                                }
                        }
                        if (bBreak)
                            break;
                    }

                    if (value.rtcValue.Count > indexGetValue + lengthGetValue)
                    {
                        ListObjectValue = new List<object>();
                        for (int i = indexGetValue; i < indexGetValue + lengthGetValue; i++)
                            ListObjectValue.Add(value.rtcValue[i]);
                        sourceValueType = nameof(SListObject);
                    }
                }
            }

            else
            {
                switch (sourceInfo.GetType().Name)
                {
                    case nameof(SString):
                        {
                            stringValue = (string)sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            sourceValueType = nameof(SString);
                            break;
                        }
                    case nameof(SInt):
                        {
                            intValue = (int)sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            sourceValueType = nameof(SInt);
                            break;
                        }
                    case nameof(SDouble):
                        {
                            doubleValue = (double)sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            sourceValueType = nameof(SDouble);
                            break;
                        }
                    case nameof(SBool):
                        {
                            boolValue = (bool)sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            sourceValueType = nameof(SBool);
                            break;
                        }

                    default:
                        {
                            objectValue = sourceInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(sourceInfo, null);
                            sourceValueType = nameof(Object);
                            break;
                        }
                }
            }
            if (linkItem.TargetIndex == null || linkItem.TargetIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.TargetIndex[0]) == cStrings.None)
            {



                switch (sourceValueType)
                {
                    case nameof(SInt):
                        {
                            dataItem.ListDoubleValue = new List<double>() { intValue };
                            break;
                        }
                    case nameof(SDouble):
                        {
                            dataItem.ListDoubleValue = new List<double> () { doubleValue };
                            break;
                        }
                    case nameof(SString):
                        {
                            dataItem.ListStringValue = new List<string>() { stringValue };
                            break;
                        }
                    case nameof(SBool):
                        {
                            dataItem.ListStringValue = new List<string> () { boolValue.ToString() };
                            break;
                        }
                    case nameof(SListString):
                        {
                            dataItem.ListStringValue = ListStringValue;
                            break;
                        }
                    case nameof(SListDouble):
                        {
                            dataItem.ListDoubleValue = ListDoubleValue;
                            break;
                        }
                    case nameof(SListObject):
                        {
                            dataItem.ListStringValue = ListObjectValue.Cast<string>().ToList();
                            break;
                        }
                    default:
                        {
                            dataItem.ListStringValue = new List<string>() { GlobFuncs.Object2Str(objectValue) };
                            break;
                        }
                }

            }
            else
            {
                bool isNew = false;
                if ((dataItem.ListStringValue == null && dataItem.ListDoubleValue == null) || (dataItem.ListDoubleValue.Count <= 0 && dataItem.ListStringValue.Count <= 0))
                    isNew = true;


                for (int i = 0; i < linkItem.TargetIndex.Count; i++)
                {
                    if (isNew)
                    {
                        switch (sourceValueType)
                        {
                            case nameof(SInt):
                                {
                                    dataItem.ListDoubleValue = new List<double>() { intValue };
                                    break;
                                }
                            case nameof(SDouble):
                                {
                                    dataItem.ListDoubleValue = new List<double>() { doubleValue };
                                    break;
                                }
                            case nameof(SString):
                                {
                                    dataItem.ListStringValue = new List<string>() { stringValue };
                                    break;
                                }
                            case nameof(SBool):
                                {
                                    dataItem.ListStringValue = new List<string>() { boolValue.ToString().ToLower() };
                                    break;
                                }
                            case nameof(SListDouble):
                                {
                                    dataItem.ListDoubleValue = ListDoubleValue;
                                    break;
                                }
                            case nameof(SListString):
                                {
                                    dataItem.ListStringValue = ListStringValue;
                                    break;
                                }
                            case nameof(Object):
                                {
                                    dataItem.ListStringValue = new List<string>() { GlobFuncs.Object2Str(objectValue) };
                                    break;
                                }
                        }
                    }
                    else if (dataItem.ListDoubleValue.Count > i)
                    {
                        switch (sourceValueType)
                        {
                            case nameof(SInt):
                                {
                                    dataItem.ListDoubleValue[i] = intValue;
                                    break;
                                }
                            case nameof(SDouble):
                                {
                                    dataItem.ListDoubleValue[i] = doubleValue;
                                    break;
                                }
                            case nameof(SString):
                                {
                                    dataItem.ListStringValue[i] = stringValue;
                                    break;
                                }
                            case nameof(SBool):
                                {
                                    dataItem.ListStringValue[i] = boolValue.ToString().ToLower();
                                    break;
                                }
                            case nameof(ListDoubleValue):
                                {
                                    dataItem.ListDoubleValue = ListDoubleValue;
                                    break;
                                }
                            case nameof(Object):
                                {
                                    dataItem.ListDoubleValue[i] = GlobFuncs.Object2Int(objectValue);
                                    break;
                                }
                        }

                    }
                    else if (dataItem.ListStringValue.Count > i)
                    {
                        switch (sourceValueType)
                        {
                            case nameof(SInt):
                                {
                                    dataItem.ListDoubleValue[i] = intValue;
                                    break;
                                }
                            case nameof(SDouble):
                                {
                                    dataItem.ListDoubleValue[i] = doubleValue;
                                    break;
                                }
                            case nameof(SString):
                                {
                                    dataItem.ListStringValue[i] = stringValue;
                                    break;
                                }
                            case nameof(SBool):
                                {
                                    dataItem.ListStringValue[i] = boolValue.ToString().ToLower();
                                    break;
                                }
                            case nameof(ListDoubleValue):
                                {
                                    dataItem.ListDoubleValue = ListDoubleValue;
                                    break;
                                }
                            case nameof(Object):
                                {
                                    dataItem.ListStringValue[i] = GlobFuncs.Object2Str(objectValue);
                                    break;
                                }
                        }

                    }
                }
            }
        


        } 
        
        public void Run_LinkValue_LinkDataItemToProp(cLinkProperty linkItem, SStringBuilderItem datItem,
           RTCVariableType targetInfo)
        {
            if (datItem == null || targetInfo == null)
                return;

            //Lấy giá trị của source
            object objectValue = null;
            List<string> ListStringValue = new List<string>();
            List<object> ListObjectValue = new List<object>();
            List<double> ListDoubleValue = new List<double>();
            string stringValue = string.Empty;

            if (datItem.ListStringValue == null || datItem.ListDoubleValue.Count <= 0)
            {
                objectValue = datItem.ListDoubleValue;
            }
            else
                objectValue = datItem.ListStringValue;

            if (linkItem.SourceIndex == null || linkItem.SourceIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.SourceIndex[0]) == cStrings.None)
            {
                ListStringValue = datItem.ListStringValue;
            }
            else
            {
                for (int i = 0; i < linkItem.SourceIndex.Count; i++)
                {
                    int index = GlobFuncs.Ve2Interger(linkItem.SourceIndex[i]);
                    if (datItem.ListStringValue.Count > index)
                        ListStringValue.Add(datItem.ListStringValue[i]);
                    else if (datItem.ListDoubleValue.Count > index)
                        ListDoubleValue.Add(datItem.ListDoubleValue[i]);
                }
            }

            //Gán vào target
            PropertyInfo targetInfoValue = targetInfo.GetType().GetProperty(cPropertyName.rtcValue);
            if (targetInfo.GetType().Name == nameof(SListDouble))
            {
                SListDouble value = (SListDouble)targetInfo;

                if (linkItem.TargetIndex == null || linkItem.TargetIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.TargetIndex[0]) == cStrings.None)
                    value.rtcValue = ListDoubleValue;
                else
                {
                    if (value.rtcValue == null)
                        value.rtcValue = ListDoubleValue;
                    else
                    {
                        int count = 0;
                        for (int i = 0; i < linkItem.TargetIndex.Count; i++)
                        {
                            int index = GlobFuncs.Ve2Interger(linkItem.TargetIndex[i]);

                            if (ListDoubleValue != null && ListDoubleValue.Count > count && value.rtcValue.Count > index)
                            {
                                value.rtcValue[index] = ListDoubleValue[count];
                                count += 1;
                            }
                        }
                    }
                }
            }
            if (targetInfo.GetType().Name == nameof(SListString))
            {
                SListString value = (SListString)targetInfo;

                if (linkItem.TargetIndex == null || linkItem.TargetIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.TargetIndex[0]) == cStrings.None)
                    value.rtcValue = ListStringValue;
                else
                {
                    if (value.rtcValue == null)
                        value.rtcValue = ListStringValue;
                    else
                    {
                        int count = 0;
                        for (int i = 0; i < linkItem.TargetIndex.Count; i++)
                        {
                            int index = GlobFuncs.Ve2Interger(linkItem.TargetIndex[i]);

                            if (ListStringValue != null && ListStringValue.Count > count && value.rtcValue.Count > index)
                            {
                                value.rtcValue[index] = ListStringValue[count];
                                count += 1;
                            }
                        }
                    }
                }
            }
            if (targetInfo.GetType().Name == nameof(SListObject))
            {
                SListObject value = (SListObject)targetInfo;

                if (linkItem.TargetIndex == null || linkItem.TargetIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.TargetIndex[0]) == cStrings.None)
                    value.rtcValue = ListObjectValue;
                else
                {
                    if (value.rtcValue == null)
                        value.rtcValue = ListObjectValue;
                    else
                    {
                        int count = 0;
                        for (int i = 0; i < linkItem.TargetIndex.Count; i++)
                        {
                            int index = GlobFuncs.Ve2Interger(linkItem.TargetIndex[i]);

                            if (ListObjectValue != null && ListObjectValue.Count > count && value.rtcValue.Count > index)
                            {
                                value.rtcValue[index] = ListObjectValue[count];
                                count += 1;
                            }
                        }
                    }
                }
            }
            else
            {
                switch (targetInfo.GetType().Name)
                {
                    case nameof(SString):
                        {
                            if (ListStringValue.Count > 0)
                                targetInfoValue.SetValue(targetInfo, GlobFuncs.Ve2Str(ListStringValue[1]));
                            else if (ListObjectValue.Count > 0)
                                targetInfoValue.SetValue(targetInfo, GlobFuncs.Ve2Str(ListObjectValue[1]));
                            break;
                        }
                    case nameof(SInt):
                        {
                            if (ListDoubleValue.Count > 0)
                                targetInfoValue.SetValue(targetInfo, GlobFuncs.Ve2Interger(ListDoubleValue[0]));
                            else if (ListObjectValue.Count > 0)
                                targetInfoValue.SetValue(targetInfo, GlobFuncs.Ve2Interger(ListObjectValue[1]));
                            break;
                        }
                    case nameof(SDouble):
                        {
                            if (ListDoubleValue.Count > 0)
                                targetInfoValue.SetValue(targetInfo, GlobFuncs.Ve2Double(ListDoubleValue[0]));
                            else if (ListObjectValue.Count > 0)
                                targetInfoValue.SetValue(targetInfo, GlobFuncs.Ve2Double(ListObjectValue[1]));
                            break;
                        }
                    case nameof(SBool):
                        {
                            if (ListStringValue.Count > 0)
                            {
                                if (bool.TryParse(GlobFuncs.Ve2Str(ListStringValue[1]), out bool boolValue))
                                    targetInfoValue.SetValue(targetInfo, boolValue.ToString().ToLower());
                            }
                            else if (ListObjectValue.Count > 0)
                                if (bool.TryParse(GlobFuncs.Ve2Str(ListObjectValue[1]), out bool boolValue))
                                    targetInfoValue.SetValue(targetInfo, boolValue.ToString().ToLower());
                            break;
                        }
                    default:
                        {
                            targetInfoValue.SetValue(targetInfo, objectValue);
                            break;
                        }
                }
            }
        }
        public void Run_LinkValue_LinkDataItemToDataItem(cLinkProperty linkItem, SStringBuilderItem datItemSource,
          SStringBuilderItem datItemDes)
        {
            if (datItemSource == null || datItemDes == null)
                return;

            //Lấy giá trị của source
            object objectValue = null;
            List<string> ListStringValue = new List<string>();
            List<object> ListObjectValue = new List<object>();
            List<double> ListDoubleValue = new List<double>();
            int intValue = 0;
            double doubleValue = 0;
            bool boolValue = false;
            string stringValue = string.Empty;

            string sourceValueType = nameof(Object);

            if (linkItem.SourceIndex == null || linkItem.SourceIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.SourceIndex[0]) == cStrings.None)
            {
                ListStringValue = datItemSource.ListStringValue;
                ListDoubleValue = datItemSource.ListDoubleValue;
            }

            else
            {
                ListDoubleValue = new List<double>();
                ListDoubleValue = new List<double>();

                for (int i = 0; i < linkItem.SourceIndex.Count; i++)
                {
                    int index = GlobFuncs.Ve2Interger(linkItem.SourceIndex[i]);
                    if (datItemSource.ListDoubleValue.Count > index)
                        ListDoubleValue.Add(datItemSource.ListDoubleValue[index]);
                    if (datItemSource.ListStringValue.Count > index)
                        ListStringValue.Add(datItemSource.ListStringValue[index]);
                }
            }

            //Gán vào target
            if (linkItem.TargetIndex == null || linkItem.TargetIndex.Count <= 0 || GlobFuncs.Ve2Str(linkItem.TargetIndex[0]) == cStrings.None)
            {
                ListStringValue = datItemSource.ListStringValue;
                ListDoubleValue = datItemSource.ListDoubleValue;
            }
            else
            {
                if (datItemDes.ListStringValue == null)
                    datItemDes.ListStringValue = ListStringValue;
                else
                {
                    int count = 0;
                    for (int i = 0; i < linkItem.TargetIndex.Count; i++)
                    {
                        int index = GlobFuncs.Ve2Interger(linkItem.TargetIndex[i]);
                        if (datItemDes.ListStringValue.Count > index && ListStringValue != null && ListStringValue.Count > count)
                        {
                            datItemDes.ListStringValue[index] = ListStringValue[count];
                            count += 1;
                        }
                    }
                }
                if (datItemDes.ListDoubleValue == null)
                    datItemDes.ListDoubleValue = ListDoubleValue;
                else
                {
                    int count = 0;
                    for (int i = 0; i < linkItem.TargetIndex.Count; i++)
                    {
                        int index = GlobFuncs.Ve2Interger(linkItem.TargetIndex[i]);
                        if (datItemDes.ListDoubleValue.Count > index && ListDoubleValue != null && ListDoubleValue.Count > count)
                        {
                            datItemDes.ListDoubleValue[index] = ListDoubleValue[count];
                            count += 1;
                        }
                    }
                }
            }
        }

        public void Run_LinkValue()
        {
            try
            {
                Passed.rtcValue = false;
                if (GlobVar.CurrentProject == null)
                    return;

                if (LinkProperty == null || LinkProperty.Count <= 0)
                    return;

                foreach (var linkItem in LinkProperty)
                {
                    cCAMTypes sourceCam = null;
                    cCAMTypes targetCam = null;
                    cAction sourceAction = null;
                    cAction targetAction = null;
                    cGroupActions sourceGroup = null;
                    cGroupActions targetGroup = null;

                    GlobVar.CurrentProject.CAMs?.TryGetValue(linkItem.SourceCamID, out sourceCam);
                    GlobVar.CurrentProject.CAMs?.TryGetValue(linkItem.TargetCamID, out targetCam);

                    if (sourceCam == null || targetCam == null)
                        continue;
                    if (GlobVar.GroupActions != null && !GlobVar.GroupActions.RunSimple)
                    {
                        if (sourceCam.ID == GlobVar.GroupActions.MyCam.ID)
                            sourceGroup = GlobVar.GroupActions;
                        else sourceGroup = sourceCam.GroupActions;
                        if (targetCam.ID == GlobVar.GroupActions.MyCam.ID)
                            targetGroup = GlobVar.GroupActions;
                        else targetGroup = targetCam.GroupActions;
                    }
                    else
                    {
                        sourceGroup = sourceCam.GroupActions;
                        targetGroup = targetCam.GroupActions;
                    }

                    sourceGroup?.Actions.TryGetValue(linkItem.SourceID, out sourceAction);
                    targetGroup?.Actions.TryGetValue(linkItem.TargetID, out targetAction);

                    if (sourceAction == null || targetAction == null)
                        continue;
                    //Lấy property
                    RTCVariableType sourceInfo = (RTCVariableType)sourceAction.GetType().GetProperties()
                        .FirstOrDefault(x => x.Name == linkItem.SourceName)?.GetValue(sourceAction, null); ;
                    RTCVariableType targetInfo = (RTCVariableType)targetAction.GetType().GetProperties()
                        .FirstOrDefault(x => x.Name == linkItem.TargetName)?.GetValue(targetAction, null);

                    SStringBuilderItem sourceDataItem = null;
                    SStringBuilderItem targetDataItem = null;

                    if (sourceInfo == null)
                    {
                        if (sourceAction.MyExpression != null && sourceAction.MyExpression.Operands != null)
                            sourceDataItem =
                                sourceAction.MyExpression.Operands.FirstOrDefault(x => x.Name == linkItem.SourceName);

                        if (sourceDataItem == null && sourceAction.DataItems != null)
                            sourceDataItem =
                                sourceAction.DataItems.FirstOrDefault(x => x.Name == linkItem.SourceName);
                    }

                    if (targetInfo == null)
                    {
                        if (targetAction.MyExpression != null && targetAction.MyExpression.Operands != null)
                            targetDataItem =
                                targetAction.MyExpression.Operands.FirstOrDefault(x => x.Name == linkItem.TargetName);

                        if (sourceDataItem == null && targetAction.DataItems != null)
                            targetDataItem =
                                targetAction.DataItems.FirstOrDefault(x => x.Name == linkItem.TargetName);
                    }
                    //sourceAction.OutputImage.rtcValue.WriteImage("bmp", 0, @"F:\2.bmp");
                    if (sourceInfo != null && targetInfo != null)
                        Run_LinkValue_LinkPropToProp(linkItem, sourceInfo, targetInfo);
                    else if (sourceInfo != null && targetDataItem != null)
                        Run_LinkValue_LinkPropToDataItem(linkItem, sourceInfo, targetDataItem);
                    else if (sourceDataItem != null && targetInfo != null)
                        Run_LinkValue_LinkDataItemToProp(linkItem, sourceDataItem, targetInfo);
                    else if (sourceDataItem != null && targetDataItem != null)
                        Run_LinkValue_LinkDataItemToDataItem(linkItem, sourceDataItem, targetDataItem);

                    targetAction.MyGroup.SetValuetoVariableIsParentRef(targetAction);
                    if (!targetAction.MyGroup.RunSimple && targetAction.ViewInfo != null && targetAction.ViewInfo.GetType() == typeof(ucBaseActionDetail))
                        ((ucBaseActionDetail)targetAction.ViewInfo).ReviewAllPropertyValueToViewInfo();
                    if (GlobVar.GroupActions != null && targetAction.MyGroup.ID == GlobVar.GroupActions.ID)
                        GlobVar.GroupActions.SetValuetoVariableIsParentRef(targetAction);
                }

                Passed.rtcValue = true;
            }

            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        } 

    }
}
