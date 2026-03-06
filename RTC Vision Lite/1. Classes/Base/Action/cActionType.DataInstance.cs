using Emgu.CV.Util;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;

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
        private bool _isAddDataByDataSet = false;
        public void Run_DataInstance()
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
            if (MyGroup.Refvalues.ContainsKey(sKey))
            {
                switch (AppendMode.rtcValue)
                {
                    case cAppendMode.New:
                        {
                            var test11 = MyGroup.Refvalues[sKey].GetType();
                            var test = MyGroup.Refvalues[sKey].GetType().Name;
                            var testtt = MyGroup.Refvalues[sKey].GetType().BaseType.Name;
                            var testtttt = nameof(List<double>);
                            if (MyGroup.Refvalues[sKey].GetType().Name == "List`1")
                            {
                                string FullName = MyGroup.Refvalues[sKey].GetType().FullName;
                                if (FullName == typeof(List<double>).FullName)
                                {
                                    Value.rtcValue = GlobFuncs.GetValueStringByIndex(GlobFuncs.ListDoubleToListString((List<double>)MyGroup.Refvalues[sKey]), Value.rtcRefIndex);

                                }
                                else if (FullName == typeof(List<string>).FullName)
                                {
                                    Value.rtcValue = GlobFuncs.GetValueStringByIndex((List<string>)MyGroup.Refvalues[sKey], Value.rtcRefIndex);
                                }
                                else if (FullName == typeof(List<object>).FullName)
                                {
                                    Value.rtcValue = GlobFuncs.GetValueStringByIndex(GlobFuncs.ListObjectToListString((List<object>)MyGroup.Refvalues[sKey]), Value.rtcRefIndex);

                                }
                            }
                            else if (MyGroup.Refvalues[sKey].GetType().Name == nameof(Boolean))
                                Value.rtcValue = new List<string>() { (MyGroup.Refvalues[sKey].ToString().ToLower()) };
                            else
                                Value.rtcValue = new List<string>() { MyGroup.Refvalues[sKey].ToString() };
                            break;
                        }
                    case cAppendMode.Add:
                        {
                            if (Value.rtcValue == null)
                                Value.rtcValue = new List<string>();
                            List<string> addValue = null;


                            if (MyGroup.Refvalues[sKey].GetType().Name == "List`1")
                            {
                                string FullName = MyGroup.Refvalues[sKey].GetType().FullName;
                                if (FullName == typeof(List<double>).FullName)
                                {

                                    addValue = GlobFuncs.ListDoubleToListString((List<double>)MyGroup.Refvalues[sKey]);

                                }
                                else if (FullName == typeof(List<string>).FullName)
                                {
                                    addValue = (List<string>)MyGroup.Refvalues[sKey];
                                }
                                else if (FullName == typeof(List<object>).FullName)
                                {
                                    addValue = GlobFuncs.ListObjectToListString((List<object>)MyGroup.Refvalues[sKey]);

                                }
                            }

                            else if (MyGroup.Refvalues[sKey].GetType().Name == nameof(Boolean))
                                addValue = new List<string>() { MyGroup.Refvalues[sKey].ToString().ToLower() };
                            else
                                addValue = new List<string>() { MyGroup.Refvalues[sKey].ToString() };

                            if (Distinct.rtcValue)
                            {
                                
                            }
                            else
                                Value.rtcValue.Add(addValue[0]);
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
                var test111 = MyGroup.Refvalues[sKey].GetType();
                var test = MyGroup.Refvalues[sKey].GetType().Name;
                var test1 = nameof(Image);
                if (MyGroup.Refvalues.ContainsKey(sKey) &&
                    MyGroup.Refvalues[sKey].GetType().Name == nameof(Bitmap))
                {
                    switch (AppendMode.rtcValue)
                    {
                        case cAppendMode.New:
                            {
                                ImageArray.rtcValue = GlobFuncs.GetValueFromSImageByIndex(
                                    new List<Image>() {(Image)MyGroup.Refvalues[sKey]},
                                    ImageArray.rtcRefIndex);
                                break;
                            }
                        case cAppendMode.Add:
                            {
                                if (ImageArray.rtcValue == null || ImageArray.rtcValue.Count <= 0)
                                    ImageArray.rtcValue = GlobFuncs.GetValueFromSImageByIndex(
                                    new List<Image>() { (Image)MyGroup.Refvalues[sKey] },
                                    ImageArray.rtcRefIndex);
                                else
                                {
                                    ImageArray.rtcValue.AddRange(GlobFuncs.GetValueFromSImageByIndex(
                                   new List<Image>() { (Image)MyGroup.Refvalues[sKey] },
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
                bool test = MyGroup.Refvalues.ContainsKey(sKey);
                var test1 = MyGroup.Refvalues[sKey].GetType().FullName;
                var tetsts = typeof(List<VectorOfVectorOfPoint>).FullName;
                if (MyGroup.Refvalues.ContainsKey(sKey) && MyGroup.Refvalues[sKey].GetType().FullName == typeof(List<VectorOfVectorOfPoint>).FullName)
                {
                    switch (AppendMode.rtcValue)
                    {
                        case cAppendMode.New:
                            {
                                BlobList.rtcValue = (List<VectorOfVectorOfPoint>)MyGroup.Refvalues[sKey];
                                break;
                            }
                        case cAppendMode.Add:
                            {
                                if (BlobList.rtcValue == null ||
                                    BlobList.rtcValue.Count <= 0)
                                    BlobList.rtcValue = (List<VectorOfVectorOfPoint>)MyGroup.Refvalues[sKey];
                                else
                                   BlobList.rtcValue.AddRange((List<VectorOfVectorOfPoint>)MyGroup.Refvalues[sKey]);
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
    }

}
