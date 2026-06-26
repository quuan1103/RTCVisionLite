using Emgu.CV.Util;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        private static readonly string LOG_PATH = @"d:\RTCVisionLite\01.RTCVision Lite\debug-c0a3f0.log";
        
        private void _Log(string msg, object data = null, string hypothesisId = "H0")
        {
            try
            {
                var entry = new
                {
                    sessionId = "c0a3f0",
                    id = $"log_{DateTime.Now:HHmmssfff}",
                    timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    location = "cActionType.DataInstance.cs",
                    message = msg,
                    data = data,
                    runId = "debug-run",
                    hypothesisId = hypothesisId
                };
                File.AppendAllText(LOG_PATH, Newtonsoft.Json.JsonConvert.SerializeObject(entry) + "\n");
            }
            catch { }
        }
        private bool _isAddDataByDataSet = false;
        public void Run_DataInstance()
        {
            try
            { 
                Passed.rtcValue = false;

            if (AppendMode.rtcValue == cAppendMode.Static)
            {
                Passed.rtcValue = true;
                if (!MyGroup.RunSimple && ViewInfo != null)
                    ((ucBaseActionDetail)ViewInfo).UpdatePropertyValueToAllControls(nameof(Value));
                return;
            }

            //if (Value.rtcIDRef == Guid.Empty)
            //{
            //    Value.rtcValue = GlobFuncs.CloneHTupe(DefaultValue.rtcValue);

            //    if (!MyGroup.RunSimple && ViewInfo != null)
            //        ((ucBaseActionDetail)ViewInfo).UpdatePropertyValueToAllControls(nameof(Value));

            //    Passed.rtcValue = true;
            //    return;
            //}

            string sKey = Value.rtcIDRef.ToString() + Value.rtcPropNameRef;
               MyGroup.BuildRefIndexValue(Value);
                if (MyGroup.RefValues.ContainsKey(sKey))
            {
                switch (AppendMode.rtcValue)
                {
                        //case cAppendMode.New:
                        //    {
                        //        var test11 = MyGroup.RefValues[sKey].GetType();
                        //        var test = MyGroup.RefValues[sKey].GetType().Name;
                        //        var testtt = MyGroup.RefValues[sKey].GetType().BaseType.Name;
                        //        var testtttt = nameof(List<double>);
                        //        if (MyGroup.RefValues[sKey].GetType().Name == "List`1")
                        //        {
                        //            string FullName = MyGroup.RefValues[sKey].GetType().FullName;
                        //            if (FullName == typeof(List<double>).FullName)
                        //            {
                        //                Value.rtcValue = GlobFuncs.GetValueStringByIndex(GlobFuncs.ListDoubleToListString((List<double>)MyGroup.RefValues[sKey]), Value.rtcRefIndex);

                        //            }
                        //            else if (FullName == typeof(List<string>).FullName)
                        //            {
                        //                Value.rtcValue = GlobFuncs.GetValueStringByIndex((List<string>)MyGroup.RefValues[sKey], Value.rtcRefIndex);
                        //            }
                        //            else if (FullName == typeof(List<object>).FullName)
                        //            {
                        //                Value.rtcValue = GlobFuncs.GetValueStringByIndex(GlobFuncs.ListObjectToListString((List<object>)MyGroup.RefValues[sKey]), Value.rtcRefIndex);

                        //            }
                        //        }
                        //        else if (MyGroup.RefValues[sKey].GetType().Name == nameof(Boolean))
                        //            Value.rtcValue = new List<string>() { (MyGroup.RefValues[sKey].ToString().ToLower()) };
                        //        else
                        //            Value.rtcValue = new List<string>() { MyGroup.RefValues[sKey].ToString() };
                        //        break;
                        //    }
                        case cAppendMode.New:
                            {
                                
                                if (MyGroup.RefValues.ContainsKey(sKey))
                                {
                                    var refVal = MyGroup.RefValues[sKey];
                                    
                                    if (refVal.GetType().Name == "List`1")
                                    {
                                        string FullName = refVal.GetType().FullName;
                                        
                                        if (FullName == typeof(List<double>).FullName)
                                        {
                                            var rawList = GlobFuncs.ListDoubleToListString((List<double>)refVal);
                                            if (string.IsNullOrEmpty(Value.rtcRefIndex))
                                                Value.rtcValue = new List<string>() { rawList[0] };
                                            else
                                                Value.rtcValue = GlobFuncs.GetValueStringByIndex(rawList, Value.rtcRefIndex);
                                        }
                                        else if (FullName == typeof(List<string>).FullName)
                                        {
                                            var rawList = (List<string>)refVal;                  
                                            if (string.IsNullOrEmpty(Value.rtcRefIndex))
                                                Value.rtcValue = new List<string>() { rawList[0] };
                                            else
                                                Value.rtcValue = GlobFuncs.GetValueStringByIndex(rawList, Value.rtcRefIndex);
                                        }
                                        else if (FullName == typeof(List<object>).FullName)
                                        {
                                            var objList = GlobFuncs.ListObjectToListString((List<object>)refVal);
                                            if (string.IsNullOrEmpty(Value.rtcRefIndex))
                                                Value.rtcValue = new List<string>() { objList[0] };
                                            else
                                                Value.rtcValue = GlobFuncs.GetValueStringByIndex(objList, Value.rtcRefIndex);
                                        }
                                    }
                                    else if (refVal.GetType().Name == nameof(Boolean))
                                    {
                                        Value.rtcValue = new List<string>() { refVal.ToString().ToLower() };
                                    }
                                    else
                                    {
                                        Value.rtcValue = new List<string>() { refVal.ToString() };
                                    }
                                }
                                else
                                {
                                    Value.rtcValue = new List<string>();
                                }

                                ValueCounterWhenAdd.rtcValue = (Value.rtcValue as List<string>)?.Count ?? 0;
                                break;
                            }
                        case cAppendMode.Add:
                        {

                            if (Value.rtcValue == null)
                                Value.rtcValue = new List<string>();
                            List<string> addValue = null;


                            if (MyGroup.RefValues.ContainsKey(sKey))
                            {
                                var refVal = MyGroup.RefValues[sKey];
                                
                                if (refVal.GetType().Name == "List`1")
                                {
                                    string FullName = refVal.GetType().FullName;
                                    if (FullName == typeof(List<double>).FullName)
                                    {
                                        addValue = GlobFuncs.ListDoubleToListString((List<double>)refVal);
                                    }
                                    else if (FullName == typeof(List<string>).FullName)
                                    {
                                        addValue = (List<string>)refVal;
                                    }
                                    else if (FullName == typeof(List<object>).FullName)
                                    {
                                        addValue = GlobFuncs.ListObjectToListString((List<object>)refVal);
                                    }
                                }
                                else if (refVal.GetType().Name == nameof(Boolean))
                                {
                                    addValue = new List<string>() { refVal.ToString().ToLower() };
                                }
                                else
                                {
                                    addValue = new List<string>() { refVal.ToString() };
                                }
                            }
                            else
                            {
                            }

                            if (Distinct.rtcValue)
                            {
                                if (addValue != null)
                                {
                                    List<string> newValues = addValue.Where(x => !Value.rtcValue.Contains(x)).ToList();
                                    Value.rtcValue.AddRange(newValues);
                                    ValueCounterWhenAdd.rtcValue = (Value.rtcValue as List<string>)?.Count ?? 0;
                                }
                            }
                            else
                            {
                                if (addValue != null && addValue.Count > 0)
                                {
                                    Value.rtcValue.Add(addValue[0]);
                                    ValueCounterWhenAdd.rtcValue = (Value.rtcValue as List<string>)?.Count ?? 0;
                                }
                            }

                            Value.rtcValue = Value.rtcValue;
                            break;
                        }
                }
            }
            else if (Value.rtcValue == null || Value.rtcValue.Count <= 0)
                Value.rtcValue = ((List<String>)GlobFuncs.CloneStringList(DefaultValue.rtcValue));

            if (ImageArray.rtcIDRef != Guid.Empty)
            {
                sKey = ImageArray.rtcIDRef.ToString() + ImageArray.rtcPropNameRef;
                    MyGroup.BuildRefIndexValue(Value);
                    var test111 = MyGroup.RefValues[sKey].GetType();
                var test = MyGroup.RefValues[sKey].GetType().Name;
                var test1 = nameof(Image);
                if (MyGroup.RefValues.ContainsKey(sKey) &&
                    MyGroup.RefValues[sKey].GetType().Name == nameof(Bitmap))
                {
                 
                    switch (AppendMode.rtcValue)
                    {
                        case cAppendMode.New:
                            {
                                ImageArray.rtcValue = GlobFuncs.GetValueFromSImageByIndex(
                                    new List<Image>() {(Image)MyGroup.RefValues[sKey]},
                                    ImageArray.rtcRefIndex);
                                break;
                            }
                        case cAppendMode.Add:
                            {
                                if (ImageArray.rtcValue == null || ImageArray.rtcValue.Count <= 0)
                                    ImageArray.rtcValue = GlobFuncs.GetValueFromSImageByIndex(
                                    new List<Image>() { (Image)MyGroup.RefValues[sKey] },
                                    ImageArray.rtcRefIndex);
                                else
                                {
                                    ImageArray.rtcValue.AddRange(GlobFuncs.GetValueFromSImageByIndex(
                                   new List<Image>() { (Image)MyGroup.RefValues[sKey] },
                                   ImageArray.rtcRefIndex));
                                    ImageArray.rtcValue = ImageArray.rtcValue;
                                }

                                break;
                            }
                    }
                }
                
            }
            if (BlobList.rtcIDRef != Guid.Empty)
            {
                sKey = BlobList.rtcIDRef.ToString() + BlobList.rtcPropNameRef;
                    MyGroup.BuildRefIndexValue(Value);
                    bool test = MyGroup.RefValues.ContainsKey(sKey);
                var test1 = MyGroup.RefValues[sKey].GetType().FullName;
                var tetsts = typeof(List<VectorOfVectorOfPoint>).FullName;
                if (MyGroup.RefValues.ContainsKey(sKey) && MyGroup.RefValues[sKey].GetType().FullName == typeof(List<VectorOfVectorOfPoint>).FullName)
                {
                    switch (AppendMode.rtcValue)
                    {
                        case cAppendMode.New:
                            {
                                BlobList.rtcValue = (List<VectorOfVectorOfPoint>)MyGroup.RefValues[sKey];
                                break;
                            }
                        case cAppendMode.Add:
                            {
                                if (BlobList.rtcValue == null ||
                                    BlobList.rtcValue.Count <= 0)
                                    BlobList.rtcValue = (List<VectorOfVectorOfPoint>)MyGroup.RefValues[sKey];
                                else
                                   BlobList.rtcValue.AddRange((List<VectorOfVectorOfPoint>)MyGroup.RefValues[sKey]);
                                BlobList.rtcValue = BlobList.rtcValue;
                                break;
                            }
                    }    
                }    
            }    
            if (!MyGroup.RunSimple && ViewInfo != null)
                ((ucBaseActionDetail)ViewInfo).UpdatePropertyValueToAllControls(nameof(Value));

            Passed.rtcValue = true;
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }
    }

}
