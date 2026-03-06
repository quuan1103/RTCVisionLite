using MS.WindowsAPICodePack.Internal;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void Run_Math_ReplaceString()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            Result.rtcValue = new List<object>();

            if (InputOne.rtcValue.Count > 0 &&
                InputTwo.rtcValue.Count > 0)
            {
                switch (ReplaceDataInteractionType.rtcValue)
                {
                    case cSelect_DataInteractionType.ByIndex:
                        {
                            Result.rtcValue = GlobFuncs.CloneValue(Run_Math_ReplaceString_ByIndex());
                            break;
                        }
                    case cSelect_DataInteractionType.ByValue:
                        {
                            string replaceString = GlobFuncs.Ve2Str(InputThree.rtcValue);
                            for (int i = 0; i < InputOne.rtcValue.Count; i++)
                            {
                                string value = GlobFuncs.Ve2Str(InputOne.rtcValue[i]);
                                string findValue = GlobFuncs.Ve2Str(InputTwo.rtcValue);

                                while (true)
                                {
                                    int index = value.IndexOf(findValue,
                                        MatchCase.rtcValue ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                                    if (index >= 0)
                                    {
                                        var builder = new StringBuilder(value);
                                        builder.Remove(index, findValue.Length);
                                        builder.Insert(index, replaceString);
                                        value = builder.ToString();
                                    }
                                    else
                                        break;
                                }
                                Result.rtcValue.Add(value);
                            }

                            Result.rtcValue = new List<object> { Result.rtcValue };
                            break;
                        }
                }
            }
            else if (InputTwo.rtcValue.Count <= 0)
                Result.rtcValue = GlobFuncs.CloneValue(new List<object> { InputOne.rtcValue });

            Passed.rtcValue = true;
        }

        public void Run_Math_ToBinary()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>();
            Result.rtcValue = new List<object>();
            List<object> originValue = new List<object>();

            originValue.Add(InputOne.rtcValue);
            originValue.Add(InputTwo.rtcValue);
            originValue.Add(InputThree.rtcValue);

            bool[] bResults = GlobFuncs.Ve2ArrayBool(originValue);
            foreach (bool b in bResults)
                Result.rtcValue.Add(b ? 1 : 0);
            Passed.rtcValue = true;
        }
        public void Run_Math_MaxWithAbs()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>();
            Result.rtcValue = new List<object>();

            List<object> originValue = new List<object>();
            originValue.Add(InputOne.rtcValue);
            originValue.Add(InputTwo.rtcValue);
            originValue.Add(InputThree.rtcValue);
            Result.rtcValue = new List<object> { FindMaxWithAbs(originValue) };
            Passed.rtcValue = true;

        }
        public void Run_Math_Random()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>();
            Random random = new Random();

            int benginValue = GlobFuncs.Ve2Interger(InputOne.rtcValue?[0]);
            int endValue = GlobFuncs.Ve2Interger(InputTwo.rtcValue?[0]);
            int count = GlobFuncs.Ve2Interger(InputThree.rtcValue?[0]);

            for (int i = 0; i < count; i++)
                Result.rtcValue.Add(random.Next(benginValue, endValue));

            Result.rtcValue = new List<object> { Result.rtcValue };
            Passed.rtcValue = true;
        }
        public object FindMaxWithAbs(List<object> valueList)
        {
            if (valueList == null || valueList.Count == 0)
                return null;

            object maxObj = valueList[0];
            double maxAbs = Math.Abs(GlobFuncs.Object2Double(maxObj));

            foreach (var item in valueList)
            {
                double itemAbs = Math.Abs(GlobFuncs.Object2Double(item));
                if (itemAbs > maxAbs)
                {
                    maxAbs = itemAbs;
                    maxObj = item;
                }
            }

            return maxObj;
        }
        /// <summary>
        /// Chạy chu trình thay thế của tool Math
        /// </summary>
        public void Run_Math_Replace()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            Result.rtcValue = GlobFuncs.Clone(InputOne.rtcValue);
            Result.rtcValue = PreprocessingData(Result.rtcValue);
            if (Result.rtcValue.Count > 0 &&
                InputTwo.rtcValue.Count > 0)
            {
                switch (ReplaceDataInteractionType.rtcValue)
                {
                    case cReplace_DataInteractionType.ByIndex:
                        {
                            /*
                             Với việc tua Index:
                             - Giá trị của 2 sẽ là các index cần tua để thay thế, nó có thể có cấu trúc full như sau: 1,2-5,7
                            Mỗi một giá trị sau dấu phẩy sẽ là index hoặc vùng index cần thay thế giá trị
                            - Giá trị của 3 sẽ là giá trị thay thế, có thể có cấu trúc full: 1,2,3
                            Khi chương trình chạy sẽ lấy index tách từ chuỗi 2 theo dấu phẩy và giá trị tương ứng với index đó ở 3 để thay thế.
                            Với trường hợp 2 nhiều hơn 3, các giá trị index sau index max của 3 sẽ được thay thế bằng các giá trị rỗng.
                            Giá trị thay thế là null ==> Loại bỏ phần tử đó ra khỏi mảng
                            */
                            // Tua index
                            List<object> result = GlobFuncs.Clone(Result.rtcValue);
                            for (int i1 = 0; i1 < InputTwo.rtcValue.Count; i1++)
                            {
                                //Nếu là 1 giá trị int ==> Thay đúng vào vị trí này giá trị tại đúng index của vùng giá trị Three
                                string sIndex = GlobFuncs.Ve2Str(InputTwo.rtcValue[i1]);
                                if (int.TryParse(sIndex, out int iIndex))
                                {
                                    if (result.Count > iIndex)
                                    {
                                        string sReplace = string.Empty;
                                        if (InputThree.rtcValue.Count > i1)
                                            sReplace = GlobFuncs.Ve2Str(InputThree.rtcValue[i1]);
                                        GlobFuncs.ReplaceValueToHTupleWithAutoDetectType(ref result, sReplace, iIndex);
                                    }
                                }
                                else if (sIndex.Contains(cChars.Minus.ToString()))
                                {
                                    string[] arrIndex = sIndex.Split(cChars.Minus);
                                    if (!int.TryParse(sIndex, out int iStart))
                                        continue;
                                    if (!int.TryParse(sIndex, out int iStop))
                                        continue;
                                    if (iStart < 0 || iStop < 0)
                                        continue;
                                    if (iStart > iStop)
                                        (iStart, iStop) = (iStop, iStart);
                                    for (int i2 = iStart; i2 <= iStop; i2++)
                                    {
                                        string sReplace = string.Empty;
                                        if (InputThree.rtcValue.Count > i1)
                                            sReplace = GlobFuncs.Ve2Str(InputThree.rtcValue[i1]);
                                        GlobFuncs.ReplaceValueToHTupleWithAutoDetectType(ref result, sReplace, i1);
                                    }
                                }
                            }
                            Result.rtcValue = GlobFuncs.Clone(result) ;
                            break;
                        }
                    case cReplace_DataInteractionType.ByValue:
                        {
                            /*Với việc tua value:
                            - Giá trị của 2 sẽ là các giá trị cần thay thế trong mảng 1
                            - Giá trị của 3 sẽ là giá trị thay thế
                            Nếu thay thế theo kiểu 1-1 tức là giá trị tại vị trí thứ n của 2 sẽ được thay bằng giá trị thứ n của 3 thì 2 và 3 phải có độ dài bằng nhau.
                            Nếu muốn thay thế kiểu n-1 tức là thay thế nhiều giá trị thành 1 giá trị thì chuỗi 3 chỉ được chứa 1 phần tử.
                            Trong trường hợp thay thế kiểu n-n, sẽ thay thế tuần tự theo index của các mảng giá trị 2-3
                            Giá trị thay thế là null ==> Loại bỏ phần tử đó ra khỏi mảng
                            Khi chương trình chạy sẽ lấy index tách từ chuỗi 2 theo dấu phẩy và giá trị tương ứng với index đó ở 3 để thay thế.
                            Với trường hợp 2 nhiều hơn 3, các giá trị index sau index max của 3 sẽ được thay thế bằng các giá trị rỗng*/
                            List<object> result = GlobFuncs.Clone(Result.rtcValue);
                            for (int i1 = 0; i1 < InputTwo.rtcValue.Count; i1++)
                            {
                                string sFind = GlobFuncs.Ve2Str(InputTwo.rtcValue[i1]);
                                for (int i2 = 0; i2 < result.Count; i2++)
                                {
                                    string sResult = GlobFuncs.Ve2Str(result[i2]);
                                    string sReplace = "";
                                    if (InputThree.rtcValue != null && InputThree.rtcValue.Count > i1)
                                        sReplace = GlobFuncs.Ve2Str(InputThree.rtcValue[i1]);
                                    else if (InputThree.rtcValue != null && InputThree.rtcValue.Count == 1)
                                        sReplace = GlobFuncs.Ve2Str(InputThree.rtcValue[0]);
                                    if (double.TryParse(sResult, out double dResult) &&
                                        double.TryParse(sFind, out double dFind))
                                    {
                                        if (dResult == dFind)
                                        {
                                            GlobFuncs.ReplaceValueToHTupleWithAutoDetectType(ref result, sReplace, i2);
                                            if (Result.rtcValue.Count != result.Count)
                                                Result.rtcValue.RemoveAt(i2);
                                            else
                                                Result.rtcValue[i2] = result[i2];
                                        }
                                        continue;
                                    }

                                    sResult = sResult.Replace(sFind, sReplace);
                                    GlobFuncs.ReplaceValueToHTupleWithAutoDetectType(ref result, sResult, i2);
                                    if (Result.rtcValue.Count != result.Count)
                                        Result.rtcValue.RemoveAt(i2);
                                    else
                                        Result.rtcValue[i2] = result[i2];
                                    Result.rtcValue[i2] = result[i2];
                                }
                            }
                            break;
                        }
                }

            }

            Passed.rtcValue = true;
        }
        /// <summary>
        /// Chạy tính chiều dài chuỗi
        /// </summary>
        internal void Run_Math_Length()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            Result.rtcValue = new List<object>() { };

            if (InputOne.rtcValue == null)
            {
                ErrMessage.rtcValue = new List<string>() { "Input One Value Is Empty." };
                return;
            } else if (InputOne.rtcValue.Count > 0)
                Result.rtcValue.Add(GlobFuncs.Ve2Str(InputOne.rtcValue[0]).Length);
            else if (Result.rtcValue.Count == 0)
                Result.rtcValue.Add(0);

            Passed.rtcValue = true;
        }

        private bool Run_Math_Select_GetValueInObjectList(ref List<object> result, object o, int iIndex)
        {
            if (o == null)
            {
                ErrMessage.rtcValue = new List<string>() { $"Input value is empty." };
                return false;
            }

            string valueType = o.GetType().FullName;
            if (valueType != null && valueType.Contains("List`1[[System.String"))
            {
                List<string> list = (List<string>)o;
                if (list.Count <= iIndex)
                {
                    ErrMessage.rtcValue = new List<string>() { $"Index {iIndex} out of range." };
                    return false;
                }
                GlobFuncs.AddValueToHTupleWittAutoDetectType(ref result, list[iIndex]);
                return true;
            }
            else if (valueType != null && valueType.Contains("List`1[[System.Integer"))
            {
                List<int> list = (List<int>)o;
                if (list.Count <= iIndex)
                {
                    ErrMessage.rtcValue = new List<string>() { $"Index {iIndex} out of range." };
                    return false;
                }
                GlobFuncs.AddValueToHTupleWittAutoDetectType(ref result, list[iIndex].ToString());
                return true;
            }
            else if (valueType != null && valueType.Contains("List`1[[System.Double"))
            {
                List<double> list = (List<double>)o;
                if (list.Count <= iIndex)
                {
                    ErrMessage.rtcValue = new List<string>() { $"Index {iIndex} out of range." };
                    return false;
                }
                GlobFuncs.AddValueToHTupleWittAutoDetectType(ref result, list[iIndex].ToString());
                return true;
            }
            else if (valueType != null && valueType.Contains("List`1[[System.Object"))
            {
                List<object> list = (List<object>)o;
                if (list.Count <= iIndex)
                {
                    ErrMessage.rtcValue = new List<string>() { $"Index {iIndex} out of range." };
                    return false;
                }
                GlobFuncs.AddValueToHTupleWittAutoDetectType(ref result, GlobFuncs.Ve2Str(list[iIndex]));
                return true;
            }

            ErrMessage.rtcValue = new List<string>() { "Input One Value Is Empty." };
            return false;
        }

        internal void Run_Math_SumElement()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };

            if (InputOne.rtcValue == null)
            {
                ErrMessage.rtcValue = new List<string>() { "Input One Value Is Empty." };
                return;
            }
            string valueType = InputOne.rtcValue.GetType().Name;
            if (valueType == "List`1") // Đây là 1 biến dạng list value
            {
                List<object> inputOne = (List<object>)InputOne.rtcValue;
                if (inputOne == null || inputOne.Count <= 0)
                {
                    ErrMessage.rtcValue = new List<string>() { "Input One Value Is Empty." };
                    return;
                }
                object o = InputOne.rtcValue[0];
                if (o == null)
                {
                    ErrMessage.rtcValue = new List<string>() { $"Input value is empty." };
                    return;
                }

                double sum = 0;
                valueType = o.GetType().FullName;

                if (valueType == null) return;

                if (valueType != null && valueType.Contains("List`1[[System.String"))
                {
                    List<string> list = (List<string>)o;
                    foreach (string value in list)
                    {
                        if (double.TryParse(value, out double dValue))
                            sum += dValue;
                    }
                    Result.rtcValue = new List<object>() { sum };
                    Passed.rtcValue = true;
                }
                else if (valueType != null && valueType.Contains("List`1[[System.Integer"))
                {
                    List<int> list = (List<int>)o;
                    foreach (int value in list)
                        sum += value;
                    Result.rtcValue = new List<object>() { sum };
                    Passed.rtcValue = true;
                }
                else if (valueType != null && valueType.Contains("List`1[[System.Double"))
                {
                    List<double> list = (List<double>)o;
                    foreach (double value in list)
                        sum += value;
                    Result.rtcValue = new List<object>() { sum };
                    Passed.rtcValue = true;
                }
                else if (valueType != null && valueType.Contains("List`1[[System.Object"))
                {
                    List<object> list = (List<object>)o;
                    foreach (object o1 in list)
                    {
                        string s = GlobFuncs.Object2Str(o1);
                        if (double.TryParse(s, out double dValue))
                            sum += dValue;
                    }
                    Result.rtcValue = new List<object>() { sum };
                    Passed.rtcValue = true;
                }
            }
            else
            {
                double sum = 0;
                List<string> values = GlobFuncs.ListObject2ListStr(InputOne.rtcValue);
                foreach (string value in values)
                {
                    if (double.TryParse(value, out double dValue))
                        sum += dValue;
                }
                Result.rtcValue = new List<object>() { sum };
                Passed.rtcValue = true;
            }
        }

        /// <summary>
        /// Chạy chu trình lựa chọn của tool Math
        /// </summary>
        internal void Run_Math_Select()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            Result.rtcValue = new List<object>();
            List<object> result = new List<object>();
            if (InputOne.rtcValue.Count > 0 &&
                InputTwo.rtcValue.Count > 0)
            {
                switch (SelectDataInteractionType.rtcValue)
                {
                    case cSelect_DataInteractionType.ByIndex:
                        {
                            // Tua index
                            for (int i = 0; i < InputTwo.rtcValue.Count; i++)
                            {
                                string sIndex = GlobFuncs.Ve2Str(InputTwo.rtcValue[i]);
                                if (int.TryParse(sIndex, out int iIndex))
                                {
                                    string valueType = InputOne.rtcValue.GetType().Name;
                                    if (valueType == "List`1") // Đây là 1 biến dạng list value
                                    {
                                        List<object> inputOne = (List<object>)InputOne.rtcValue;
                                        if (inputOne == null || inputOne.Count <= 0)
                                        {
                                            ErrMessage.rtcValue = new List<string>() { "Input One Value Is Empty." };
                                            return;
                                        }
                                        object o = InputOne.rtcValue[0];
                                        if (!Run_Math_Select_GetValueInObjectList(ref result, o, iIndex))
                                            return;
                                    }
                                }
                                else if (sIndex.Contains(cChars.Minus.ToString()))
                                {
                                    string[] arrIndex = sIndex.Split(cChars.Minus);
                                    if (arrIndex.Length < 2)
                                        continue;
                                    if (!int.TryParse(arrIndex[0], out int iStart))
                                        continue;
                                    if (!int.TryParse(arrIndex[arrIndex.Length - 1], out int iStop))
                                        continue;
                                    if (iStart < 0 || iStop < 0)
                                        continue;
                                    if (iStart > iStop)
                                        (iStart, iStop) = (iStop, iStart);
                                    for (int i2 = iStart; i2 <= iStop; i2++)
                                    {
                                        if (InputOne.rtcValue.Count > i2)
                                            GlobFuncs.AddValueToHTupleWittAutoDetectType(ref result, GlobFuncs.Ve2Str(InputOne.rtcValue[i2]));
                                    }
                                }
                            }
                            Result.rtcValue = GlobFuncs.Clone(result);
                            break;
                        }
                    case cSelect_DataInteractionType.ByValue:
                        {
                            for (int i = 0; i < InputOne.rtcValue.Count; i++)
                            {
                                List<object> finds = InputTwo.rtcValue.FindAll(x => x == InputOne.rtcValue[i]);
                                if (finds != null && finds.Count > 0 && Lib.ToInt(finds[0]) != -1)
                                    Result.rtcValue.Add(InputOne.rtcValue[i]);
                            }
                            break;
                        }
                    case cSelect_DataInteractionType.EvenPosition:
                         {
                            for (int i = 0; i < InputOne.rtcValue.Count; i += 2)
                                Result.rtcValue.Add(InputOne.rtcValue[i]);
                            break;
                        }
                    case cSelect_DataInteractionType.OddPosition:
                        {
                            for (int i = 1; i < InputOne.rtcValue.Count; i += 2)
                                Result.rtcValue.Add(InputOne.rtcValue[i]);
                            break;
                        }
                }
            }
            Passed.rtcValue = true;
        }
        private List<object> Run_Math_ReplaceString_ByIndex()
        {
            List<object> result = new List<object>();
            if (InputOne.rtcValue.Count <= 0 ||
                InputTwo.rtcValue.Count <= 0)
                return result;


            string replaceString = GlobFuncs.Ve2Str(InputThree.rtcValue);
            for (int i = 0; i < InputTwo.rtcValue.Count; i++)
            {
                string sIndex = GlobFuncs.Ve2Str(InputTwo.rtcValue[i]);
                if (int.TryParse(sIndex, out int iIndex))
                {
                    for (int i1 = 0; i1 < InputOne.rtcValue.Count; i1++)
                    {
                        string s = GlobFuncs.Ve2Str(InputOne.rtcValue[i1]);
                        if (s.Length > iIndex)
                        {
                            var builder = new StringBuilder(s);
                            builder.Remove(iIndex, 1);
                            builder.Insert(iIndex, replaceString);
                            result.Add(builder.ToString());
                        }
                    }
                }
                else if (sIndex.Contains(cChars.Minus.ToString()))
                {
                    string[] arrIndex = sIndex.Split(cChars.Minus);
                    if (arrIndex.Length < 2)
                        continue;
                    if (!int.TryParse(arrIndex[0], out int iStart))
                        continue;
                    if (!int.TryParse(arrIndex[arrIndex.Length - 1], out int iStop))
                        continue;
                    if (iStart < 0 || iStop < 0)
                        continue;
                    if (iStart > iStop)
                        (iStart, iStop) = (iStop, iStart);

                    for (int i1 = 0; i1 < InputOne.rtcValue.Count; i1++)
                    {
                        string s = GlobFuncs.Ve2Str(InputOne.rtcValue[i1]);
                        var builder = new StringBuilder(s);
                        for (int j = iStop; j >= iStart; j--)
                        {
                            builder.Remove(j, 1);
                            builder.Insert(j, replaceString);
                        }
                        result.Add(builder.ToString());
                    }
                }
            }

            return result;
        }
        private List<object> Run_Math_SelectString_ByIndex()
        {
            List<object> result = new List<object>();
            if (InputOne.rtcValue.Count <= 0 ||
                InputTwo.rtcValue.Count <= 0)
                return result;

            for (int i = 0; i < InputTwo.rtcValue.Count; i++)
            {
                string sIndex = GlobFuncs.Ve2Str(InputTwo.rtcValue[i]);
                if (int.TryParse(sIndex, out int iIndex))
                {
                    for (int i1 = 0; i1 < InputOne.rtcValue.Count; i1++)
                        GlobFuncs.AddValueToHTupleWittAutoDetectType(ref result, GlobFuncs.Ve2Str(InputOne.rtcValue[i1]), iIndex);
                }
                else if (sIndex.Contains(cChars.Minus.ToString()))
                {
                    string[] arrIndex = sIndex.Split(cChars.Minus);
                    if (arrIndex.Length < 2)
                        continue;
                    if (!int.TryParse(arrIndex[0], out int iStart))
                        continue;
                    if (!int.TryParse(arrIndex[arrIndex.Length - 1], out int iStop))
                        continue;
                    if (iStart < 0 || iStop < 0)
                        continue;
                    if (iStart > iStop)
                        (iStart, iStop) = (iStop, iStart);

                    for (int i1 = 0; i1 < InputOne.rtcValue.Count; i1++)
                    {
                        string s = GlobFuncs.Ve2Str(InputOne.rtcValue[i1]);
                        if (s.Length > iStop)
                            result = new List<object> { s.Substring(iStart, iStop - iStart + 1) };
                        //GlobFuncs.AddValueToHTupleWittAutoDetectType(ref result, s.Substring(iStart, iStop - iStart + 1));
                    }
                }
            }

            return result;
        }
        internal void Run_Math_SelectString()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>();
            Result.rtcValue = new List<object>();
            List<object> result = new List<object>();
            if (InputOne.rtcValue.Count > 0 &&
                InputTwo.rtcValue.Count > 0)
            {
                switch (SelectDataInteractionType.rtcValue)
                {
                    case cSelect_DataInteractionType.ByIndex:
                        {
                            Result.rtcValue = new List<object> { GlobFuncs.CloneValue(Run_Math_SelectString_ByIndex()) };
                            break;
                        }
                    case cSelect_DataInteractionType.ByValue:
                        {
                            for (int i = 0; i < InputOne.rtcValue.Count; i++)
                            {
                                string value = GlobFuncs.Ve2Str(InputOne.rtcValue[i]);
                                string findValue = GlobFuncs.Ve2Str(InputTwo.rtcValue);
                                bool correct = MatchCase.rtcValue ? value == findValue : value.ToLower() == findValue.ToLower();
                                if (correct)
                                    Result.rtcValue.Add(value);
                            }

                            Result.rtcValue = Result.rtcValue;
                            break;
                        }
                    case cSelect_DataInteractionType.Extract:
                        {
                            for (int i = 0; i < InputOne.rtcValue.Count; i++)
                            {
                                string value = GlobFuncs.Ve2Str(InputOne.rtcValue[i]);

                                for (int j = 0; j < InputTwo.rtcValue.Count; j++)
                                {
                                    string findValue = GlobFuncs.Ve2Str(InputTwo.rtcValue[j]);

                                    bool correct = MatchCase.rtcValue ? value.Contains(findValue) : value.ToLower().Contains(findValue.ToLower());
                                    if (correct)
                                    {
                                        int index = -1;
                                        if (MatchCase.rtcValue)
                                            index = value.IndexOf(findValue);
                                        else
                                            index = value.ToLower().IndexOf(findValue.ToLower());
                                        if (index >= 0)
                                        {
                                            Result.rtcValue.Add(value.Substring(index, findValue.Length));
                                            break;
                                        }
                                    }
                                }
                            }

                            Result.rtcValue = Result.rtcValue;
                            break;
                        }
                    case cSelect_DataInteractionType.Contains:
                        {
                            for (int i = 0; i < InputOne.rtcValue.Count; i++)
                            {
                                string value = GlobFuncs.Ve2Str(InputOne.rtcValue[i]);

                                for (int j = 0; j < InputTwo.rtcValue.Count; j++)
                                {
                                    string findValue = GlobFuncs.Ve2Str(InputTwo.rtcValue[j]);

                                    bool correct = MatchCase.rtcValue ? value.Contains(findValue) : value.ToLower().Contains(findValue.ToLower());
                                    if (correct)
                                    {
                                        Result.rtcValue.Add(value);
                                        break;
                                    }
                                }
                            }

                            Result.rtcValue = Result.rtcValue;
                            break;
                        }
                    case cSelect_DataInteractionType.StartWith:
                        {
                            for (int i = 0; i < InputOne.rtcValue.Count; i++)
                            {
                                string value = GlobFuncs.Ve2Str(InputOne.rtcValue[i]);

                                for (int j = 0; j < InputTwo.rtcValue.Count; j++)
                                {
                                    string findValue = GlobFuncs.Ve2Str(InputTwo.rtcValue[j]);

                                    bool correct = MatchCase.rtcValue ? value.StartsWith(findValue) : value.ToLower().StartsWith(findValue.ToLower());
                                    if (correct)
                                    {
                                        Result.rtcValue.Add(value);
                                        break;
                                    }
                                }
                            }

                            Result.rtcValue = Result.rtcValue;
                            break;
                        }
                    case cSelect_DataInteractionType.EndWith:
                        {
                            for (int i = 0; i < InputOne.rtcValue.Count; i++)
                            {
                                string value = GlobFuncs.Ve2Str(InputOne.rtcValue[i]);

                                for (int j = 0; j < InputTwo.rtcValue.Count; j++)
                                {
                                    string findValue = GlobFuncs.Ve2Str(InputTwo.rtcValue[j]);
                                    bool correct = MatchCase.rtcValue ? value.EndsWith(findValue) : value.ToLower().EndsWith(findValue.ToLower());
                                    if (correct)
                                    {
                                        Result.rtcValue.Add(value);
                                        break;
                                    }
                                }
                            }

                            Result.rtcValue = Result.rtcValue;
                            break;
                        }
                }
            }

            Passed.rtcValue = true;
        }
        /// <summary>
        /// Đảo vị trí của chuỗi đưa vào
        /// </summary>
        internal void Run_Math_InvertPosition()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            Result.rtcValue = new List<object>();
            List<string> lstValue = GlobFuncs.String2ListString(GlobFuncs.Ve2Str(InputOne.rtcValue[0]), cStrings.SepPhay);
            if (lstValue.Count > 0)
                for (int i = lstValue.Count - 1; i >= 0; i--)
                    Result.rtcValue.Add(lstValue[i]);

            Passed.rtcValue = true;
        }
        /// <summary>
        /// Chuyển đổi từ nhị phân sang số nguyên
        /// </summary>
        internal void Run_Math_BinaryToInteger()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            Result.rtcValue = new List<object>();
            if (InputOne.rtcValue.Count > 0)
            {
                List<object> newValue = new List<object>();
                for (int i = 0; i < InputOne.rtcValue.Count; i++)
                {
                    string s = GlobFuncs.Ve2Str(InputOne.rtcValue[i]);
                    if (double.TryParse(s, out double dValue))
                    {
                        if (dValue != 0)
                            dValue = 1;
                        newValue.Add((int)dValue);
                    }
                    else
                    {
                        string[] ss = s.Split(cChars.Semicolon);
                        for (int j = 0; j < ss.Length; j++)
                        {
                            if (double.TryParse(ss[j], out double dValue1))
                            {
                                if (dValue1 != 0)
                                    dValue1 = 1;
                                newValue.Add((int)dValue1);
                            }
                            else
                                newValue.Add(0);
                            if (j < ss.Length - 1)
                                newValue.Add(cChars.Semicolon.ToString());
                        }
                    }
                }

                string value = GlobFuncs.Ve2StrWithoutComma(newValue);
                string[] values = value.Split(cChars.Semicolon);
                foreach (string s in values)
                    Result.rtcValue.Add(Convert.ToInt32(s, 2));
            }

            Passed.rtcValue = true;
        }
        private void Run_Math_ResultComplete()
        {
            // Làm tròn
            if (RoundResult.rtcValue && Result.rtcValue.Count > 0)
            {
                for (int i = 0; i < Result.rtcValue.Count; i++)
                {
                    string sResult = GlobFuncs.Ve2Str(Result.rtcValue[i]);
                    if (double.TryParse(sResult, out double dValue))
                    {
                        dValue = Math.Round(dValue, GlobFuncs.Ve2Interger(RoundFactor.rtcValue));
                        Result.rtcValue[i] = new List<object> { dValue };
                    }
                }
            }
            // Lấy trị tuyệt đối
            if (AbsoluteResult.rtcValue && Result.rtcValue.Count > 0)
            {
                for (int i = 0; i < Result.rtcValue.Count; i++)
                {
                    string sResult = GlobFuncs.Ve2Str(Result.rtcValue[i]);
                    if (double.TryParse(sResult, out double dValue))
                    {
                        dValue = Math.Abs(dValue);
                        Result.rtcValue[i] = new List<object> { dValue };
                    }
                }
            }
        }
        internal void Run_Math_Split()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>();
            Result.rtcValue = new List<object>();

            string inputOneValue = GlobFuncs.Ve2Str(InputOne.rtcValue);
            string inputTwoValue = GlobFuncs.Ve2Str(InputTwo.rtcValue);
            bool a = inputOneValue.Contains(inputTwoValue);
            if (inputTwoValue.Length == 0 || !inputOneValue.Contains(inputTwoValue))
                Result.rtcValue = new List<object> { InputOne.rtcValue };
            else
            {
                string[] inputOneValues = inputOneValue.Split(new[] { inputTwoValue }, StringSplitOptions.None);
                foreach (string value in inputOneValues)
                {
                    if (int.TryParse(value, out int iValue))
                        Result.rtcValue.Add(iValue);
                    else if (double.TryParse(value, out double dValue))
                        Result.rtcValue.Add(dValue);
                    else
                        Result.rtcValue.Add(value);
                }
            }

            //Run_Math_ResultComplete();

            Result.rtcValue = Result.rtcValue;

            Passed.rtcValue = true;
        }
        internal void Run_Math_Trim()
        {
            ErrMessage.rtcValue = new List<string>();
            Result.rtcValue = new List<object>();
            List<object> result = new List<object>();
            for (int i = 0; i < InputOne.rtcValue.Count; i++)
            {
                string value = GlobFuncs.Ve2Str(InputOne.rtcValue[i]). Trim();
                Result.rtcValue.Add(value);
            }
            //Run_Math_ResultComplete();
            Result.rtcValue = Result.rtcValue;
            Passed.rtcValue = true;
        }
        public void Run_Math_Operator()
        {
            //Todo: *Vinh Thêm Tool Math*
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>();
            Result.rtcValue = new List<object>();
            object ResultOperator = new object();
            List<object> originValue = new List<object>();
            originValue.Add(InputOne.rtcValue);
            originValue.Add(InputTwo.rtcValue);
            bool IsString = originValue.Any(item => item is string);
            if (InputOne.rtcValue.Count != InputTwo.rtcValue.Count)
            {
                if (InputOne.rtcValue.Count != 1)
                {
                    if (InputTwo.rtcValue.Count != 1)
                    {
                        Passed.rtcValue = false;
                        return;
                    }
                }
            }

            if (Operator.rtcValue != cAdvancedMathematicsMode.Summation && IsString)
            {
                Passed.rtcValue = false;
                return;
            }
            else if (Operator.rtcValue == cAdvancedMathematicsMode.Summation)
            {
                Run_Single_Math_Operator(Operator.rtcValue);
            }
            else if (Operator.rtcValue == cAdvancedMathematicsMode.Subtraction)
            {
                Run_Single_Math_Operator(Operator.rtcValue);
            }
            else if (Operator.rtcValue == cAdvancedMathematicsMode.Multiplication)
            {
                Run_Single_Math_Operator(Operator.rtcValue);
            }
            else
            {
                Run_Single_Math_Operator(Operator.rtcValue);
            }
            Passed.rtcValue = true;

        }
        private void Run_Math_CountElenment()
        {
            try
            {
                InputOne.rtcValue = PreprocessingData(InputOne.rtcValue);
                InputTwo.rtcValue = PreprocessingData(InputTwo.rtcValue);
                InputThree.rtcValue = PreprocessingData(InputThree.rtcValue);
                Result.rtcValue = new List<object> { InputOne.rtcValue.Count + InputTwo.rtcValue.Count + InputThree.rtcValue.Count };
                Passed.rtcValue = true;
            }
            catch (Exception ex)
            {
                Passed.rtcValue = false;
            }

        }
        private void Run_Math_Concat()
        {
            try
            {
                Result.rtcValue = new List<object>();
                InputOne.rtcValue = PreprocessingData(InputOne.rtcValue);
                InputTwo.rtcValue = PreprocessingData(InputTwo.rtcValue);
                Result.rtcValue.Add(InputOne.rtcValue);
                Result.rtcValue.Add(InputTwo.rtcValue);
                Passed.rtcValue = true;
            }
            catch (Exception ex)
            {
                Passed.rtcValue = false;
            }

        }
        /// <summary>
        /// Chạy đơn phép toán
        /// </summary>
        public void Run_Single_Math_Operator(string InputOperator)
        {
            //Todo: *Vinh Thêm Tool Math*
            var operations = new Dictionary<string, Func<double, double, double>>
            {
                ["+"] = (a, b) => a + b,
                ["-"] = (a, b) => a - b,
                ["x"] = (a, b) => a * b,
                ["/"] = (a, b) => a / b
            };
            int Start = 0;
            InputOne.rtcValue = PreprocessingData(InputOne.rtcValue);
            InputTwo.rtcValue = PreprocessingData(InputTwo.rtcValue);

            foreach (var item1 in InputOne.rtcValue)
            {
                for (int i = Start; i < InputTwo.rtcValue.Count; i++)
                {
                    // Nếu 1 trong 2 là string
                    if (item1 is string || InputTwo.rtcValue[i] is string)
                    {
                        Result.rtcValue.Add(item1.ToString() + InputTwo.rtcValue[i].ToString());
                    }
                    // Nếu cả hai là số
                    else if (double.TryParse(item1.ToString(), out double Data1) && double.TryParse(InputTwo.rtcValue[i].ToString(), out double Data2))
                    {
                        Result.rtcValue.Add(operations[InputOperator](Data1, Data2));
                    }
                    else
                    {
                        // Nếu không rõ, giữ nguyên cặp đó
                        Result.rtcValue.Add(null);
                    }
                    if (InputOne.rtcValue.Count == InputTwo.rtcValue.Count && InputOne.rtcValue.Count != 1)
                    {
                        Start += 1;
                        break;
                    }
                }
            }
        }
        private List<object> PreprocessingData(List<object> Data)
        {
            List<object> DataInputNew = new List<object>();
            foreach (var item in Data)
            {
                if (item is IList list)
                {
                    foreach (var item1 in list)
                    {
                        string s = GlobFuncs.Object2Str(item1);

                        if (int.TryParse(s, out int iValue))
                            DataInputNew.Add(iValue);
                        else if (double.TryParse(s, out double dValue))
                            DataInputNew.Add(dValue);
                        else
                            DataInputNew.Add(item1);
                    }
                }

            }
            return DataInputNew.Count > 0 ? DataInputNew : Data;
        }
    }

}
