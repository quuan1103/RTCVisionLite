using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        #region RUN ACTION STRINGBUILDER

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets string builder item value if have link. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="_SBItem">  Dòng dữ liệu nối. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void GetStringBuilderItemValueIfHaveLink(SStringBuilderItem _SBItem)
        {
            if (_SBItem == null || _SBItem.RefID == Guid.Empty) return;
        }

        /// <summary>
        /// Thay thế các kí tự mô phỏng cho các kí tự đặc biệt bằng kí tự thực.
        /// </summary>
        /// <param name="delemiterString">Chuỗi cần thay thế</param>
        /// <returns>Chuỗi sau khi thay thế</returns>
        internal string ReplaceDelemiterStringToSendDataString(string delemiterString)
        {
            if (delemiterString.Trim() == "")
                return delemiterString;

            delemiterString = delemiterString.Replace("[NULL]", ((char)GlobVar.DicASCII["0x00"]).ToString());
            delemiterString = delemiterString.Replace("[SOH]", ((char)GlobVar.DicASCII["0x01"]).ToString());
            delemiterString = delemiterString.Replace("[STX]", ((char)GlobVar.DicASCII["0x02"]).ToString());
            delemiterString = delemiterString.Replace("[ETX]", ((char)GlobVar.DicASCII["0x03"]).ToString());
            delemiterString = delemiterString.Replace("[EOT]", ((char)GlobVar.DicASCII["0x04"]).ToString());
            delemiterString = delemiterString.Replace("[ENQ]", ((char)GlobVar.DicASCII["0x05"]).ToString());
            delemiterString = delemiterString.Replace("[ACK]", ((char)GlobVar.DicASCII["0x06"]).ToString());
            delemiterString = delemiterString.Replace("[BEL]", ((char)GlobVar.DicASCII["0x07"]).ToString());
            delemiterString = delemiterString.Replace("[BS]", ((char)GlobVar.DicASCII["0x08"]).ToString());
            delemiterString = delemiterString.Replace("[HT]", ((char)GlobVar.DicASCII["0x09"]).ToString());
            delemiterString = delemiterString.Replace("[LF]", ((char)GlobVar.DicASCII["0x0A"]).ToString());
            delemiterString = delemiterString.Replace("[VT]", ((char)GlobVar.DicASCII["0x0B"]).ToString());
            delemiterString = delemiterString.Replace("[FF]", ((char)GlobVar.DicASCII["0x0C"]).ToString());
            delemiterString = delemiterString.Replace("[CR]", ((char)GlobVar.DicASCII["0x0D"]).ToString());
            delemiterString = delemiterString.Replace("[SO]", ((char)GlobVar.DicASCII["0x0E"]).ToString());
            delemiterString = delemiterString.Replace("[SI]", ((char)GlobVar.DicASCII["0x0F"]).ToString());
            delemiterString = delemiterString.Replace("[DLE]", ((char)GlobVar.DicASCII["0x10"]).ToString());
            delemiterString = delemiterString.Replace("[DC1]", ((char)GlobVar.DicASCII["0x11"]).ToString());
            delemiterString = delemiterString.Replace("[DC2]", ((char)GlobVar.DicASCII["0x12"]).ToString());
            delemiterString = delemiterString.Replace("[DC3]", ((char)GlobVar.DicASCII["0x13"]).ToString());
            delemiterString = delemiterString.Replace("[DC4]", ((char)GlobVar.DicASCII["0x14"]).ToString());
            delemiterString = delemiterString.Replace("[NAK]", ((char)GlobVar.DicASCII["0x15"]).ToString());
            delemiterString = delemiterString.Replace("[SYN]", ((char)GlobVar.DicASCII["0x16"]).ToString());
            delemiterString = delemiterString.Replace("[ETB]", ((char)GlobVar.DicASCII["0x17"]).ToString());
            delemiterString = delemiterString.Replace("[CAN]", ((char)GlobVar.DicASCII["0x18"]).ToString());
            delemiterString = delemiterString.Replace("[EM]", ((char)GlobVar.DicASCII["0x19"]).ToString());
            delemiterString = delemiterString.Replace("[SUB]", ((char)GlobVar.DicASCII["0x1A"]).ToString());
            delemiterString = delemiterString.Replace("[ESC]", ((char)GlobVar.DicASCII["0x1B"]).ToString());
            delemiterString = delemiterString.Replace("[FS]", ((char)GlobVar.DicASCII["0x1C"]).ToString());
            delemiterString = delemiterString.Replace("[GS]", ((char)GlobVar.DicASCII["0x1D"]).ToString());
            delemiterString = delemiterString.Replace("[RS]", ((char)GlobVar.DicASCII["0x1E"]).ToString());
            delemiterString = delemiterString.Replace("[US]", ((char)GlobVar.DicASCII["0x1F"]).ToString());

            return delemiterString;
        }

        /// <summary>   Lấy kí tự nối nội tại của 1 dòng dữ liệu. </summary>
        /// <param name="sbDelimiter"> Đối tượng chứa thông tin nối. </param>
        /// <param name="isSend">      (Optional) Cờ báo lấy kí tự để truyền thông. </param>
        /// <returns>   Kí tự nối. </returns>
        private string GetDelimiter(SElementDelimiter sbDelimiter, bool isSend = false)
        {
            string result = string.Empty;
            if (sbDelimiter == null) return result;

            switch (sbDelimiter.DelimiterTypes)
            {
                case EDelimiterTypes.Standard:
                    switch (sbDelimiter.StandardValue)
                    {
                        case EDelimiter.None:
                            break;
                        case EDelimiter.Comma:
                            result = cDelimiterValues.Comma;
                            break;
                        case EDelimiter.Space:
                            result = cDelimiterValues.Space;
                            break;
                        case EDelimiter.Tab:
                            result = cDelimiterValues.Tab;
                            break;
                        case EDelimiter.Semicolon:
                            result = cDelimiterValues.Semicolon;
                            break;
                        case EDelimiter.Underscore:
                            result = cDelimiterValues.Underscore;
                            break;
                        default:
                            break;
                    }
                    break;
                case EDelimiterTypes.Custom:
                    if (isSend)
                    {
                        //Chuyển các kí tự ASCII về kí tự
                        result = sbDelimiter.CustomValue;
                        result = ReplaceDelemiterStringToSendDataString(result);
                    }
                    else
                        result = sbDelimiter.CustomValue;

                    //_Result = _SBDelimiter.CustomValue;
                    //_Result = ReplaceDelemiterStringToSendDataString(_Result);

                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>   Lấy kí tự nối giữa các dòng dữ liệu. </summary>
        /// <param name="isSend">  (Optional) Cờ báo lấy kí tự để truyền thông. </param>
        /// <returns>   Kí tự nối giữa các dòng dữ liệu. </returns>
        private string GetDelimiterAction(bool isSend = false)
        {
            string result = string.Empty;

            switch ((EDelimiterTypes)DelimiterType.rtcValue)
            {
                case EDelimiterTypes.Standard:
                    switch ((EDelimiter)DelimiterStandard.rtcValue)
                    {
                        case EDelimiter.None:
                            break;
                        case EDelimiter.Comma:
                            result = cDelimiterValues.Comma;
                            break;
                        case EDelimiter.Space:
                            result = cDelimiterValues.Space;
                            break;
                        case EDelimiter.Tab:
                            if (isSend)
                                result = ((char)GlobVar.DicASCII["0x09"]).ToString();
                            else
                                result = cDelimiterValues.Tab;
                            break;
                        case EDelimiter.Semicolon:
                            result = cDelimiterValues.Semicolon;
                            break;
                        case EDelimiter.Underscore:
                            result = cDelimiterValues.Underscore;
                            break;
                        default:
                            break;
                    }
                    break;
                case EDelimiterTypes.Custom:
                    if (isSend)
                    {
                        //Chuyển các kí tự ASCII về kí tự
                        result = DelimiterCustom.rtcValue;
                        result = ReplaceDelemiterStringToSendDataString(result);
                    }
                    else
                        result = DelimiterCustom.rtcValue;
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>   Gen chuỗi với kiểu Boolean. </summary>
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        /// <returns>   Chuỗi kiểu Boolean sau khi được Gen ra từ các thông số thiết lập. </returns>

        private string Run_StringBuilder_GetBoolean(SStringBuilderItem sbItem)
        {
            string result = string.Empty;
            if (sbItem.ValueView != string.Empty)
                result = GlobFuncs.Ve2Str(sbItem.ListStringValue[0]).ToLower() == cStrings.@true ? sbItem.TrueText : sbItem.FalseText;
            return result;
        }

        /// <summary>   Gen chuỗi với kiểu Boolean List. </summary>
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        /// <param name="itemSend">Chuỗi kết quả thực tế dùng để gửi</param>
        /// <returns>   Chuỗi kiểu Boolean List sau khi được Gen ra từ các thông số thiết lập. </returns>
        private string Run_StringBuilder_GetBooleanList(SStringBuilderItem sbItem, out string itemSend)
        {
            itemSend = string.Empty;
            string result = string.Empty;
            if (sbItem.ValueView != string.Empty && !sbItem.ValueView.StartsWith("0"))
            {
                for (int i = 0; i < sbItem.ListStringValue.Count - 1; i++)
                {
                    if (sbItem.ListStringValue[i].ToString().ToLower() == "true")
                    {
                        result = i == 0
                            ? sbItem.TrueText
                            : result + GetDelimiter(sbItem.ElementDelimiter) + sbItem.TrueText;
                        itemSend = i == 0 ? sbItem.TrueText
                            : itemSend + GetDelimiter(sbItem.ElementDelimiter) + sbItem.TrueText;

                    }
                    else
                    {
                        result = i == 0 ? sbItem.FalseText : result + GetDelimiter(sbItem.ElementDelimiter) + sbItem.FalseText;
                        itemSend = i == 0 ? sbItem.FalseText
                            : itemSend + GetDelimiter(sbItem.ElementDelimiter) + sbItem.FalseText;
                    }
                }
            }
            return result;
        }

        private string AddPadWith(string result, int minimumLength, EPadWiths padWith)
        {
            int i = 0;
            while (result.Length < minimumLength)
            {
                switch (padWith)
                {
                    case EPadWiths.LeadingZeros:
                        {
                            result = "0" + result;
                            break;
                        }
                    case EPadWiths.LeadSpaces:
                        {
                            result = " " + result;
                            break;
                        }
                    case EPadWiths.TrallingZeros:
                        {
                            result += "0";
                            break;
                        }
                    case EPadWiths.TrallingSpaces:
                        {
                            result += " ";
                            break;
                        }
                    case EPadWiths.AutoAddDecimal:
                        {
                            if (i == 0 && !result.Contains(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                                result += Thread.CurrentThread.CurrentCulture.NumberFormat
                                    .NumberDecimalSeparator;
                            else
                                result += "0";
                            i++;
                            break;
                        }
                    default:
                        break;
                }
            }

            return result;
        }
        /// <summary>   Gen chuỗi với kiểu Integer. </summary>
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        /// <returns>   Chuỗi kiểu Integer sau khi được Gen ra từ các thông số thiết lập. </returns>
        private string Run_StringBuilder_GetInteger(SStringBuilderItem sbItem)
        {
            string result = sbItem.ValueView;

            if (sbItem.ValueView != string.Empty)
                if (sbItem.UseMiniumLength)
                    result = AddPadWith(result, sbItem.MiniumLength, sbItem.PadWith);
            return result;
        }

        /// <summary>   Gen chuỗi với kiểu Integer List. </summary>
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        /// <param name="itemSend">Chuỗi kết quả thực tế dùng để gửi</param>
        /// <returns>   Chuỗi kiểu Integer List sau khi được Gen ra từ các thông số thiết lập. </returns>

        private string Run_StringBuilder_GetIntegerList(SStringBuilderItem sbItem, out string itemSend)
        {
            string result = string.Empty;
            itemSend = string.Empty;
            if (sbItem.ValueView != string.Empty && !sbItem.ValueView.StartsWith("0"))
            {
                for (int i = 0; i < sbItem.ListDoubleValue.Count; i++)
                {
                    string sValue = GlobFuncs.Ve2Str(sbItem.ListDoubleValue[i]);
                    if (sbItem.UseMiniumLength)
                        sValue = AddPadWith(sValue, sbItem.MiniumLength, sbItem.PadWith);
                    result = i == 0 ? sValue : result + GetDelimiter(sbItem.ElementDelimiter) + sValue;
                    itemSend = i == 0 ? sValue : itemSend + GetDelimiter(sbItem.ElementDelimiter, true) + sValue;
                }
            }
            return result;
        }

        /// <summary>   Gen chuỗi với kiểu Real. </summary>
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        /// <returns>   Chuỗi kiểu Real sau khi được Gen ra từ các thông số thiết lập. </returns>

        private string Run_StringBuilder_GetReal(SStringBuilderItem sbItem)
        {
            string result = sbItem.ValueView;

            if (sbItem.ValueView != string.Empty)
                result = GetStringToDoubleInSBItem(sbItem.ListDoubleValue[0], sbItem);
            return result;
        }

        /// <summary>   Gen chuỗi với kiểu Real List. </summary>
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        /// <param name="itemSend">Chuỗi kết quả thực tế dùng để gửi</param>
        /// <returns>   Chuỗi kiểu Real List sau khi được Gen ra từ các thông số thiết lập. </returns>
        private string Run_StringBuilder_GetRealList(SStringBuilderItem sbItem, out string itemSend)
        {
            string result = string.Empty;
            itemSend = string.Empty;
            if (sbItem.ValueView != string.Empty && !sbItem.ValueView.StartsWith("0"))
            {
                for (int i = 0; i < sbItem.ListDoubleValue.Count; i++)
                {
                    string sValue = GetStringToDoubleInSBItem(sbItem.ListDoubleValue[i], sbItem);
                    result = i == 0 ? sValue : result + GetDelimiter(sbItem.ElementDelimiter) + sValue;
                    itemSend = i == 0 ? sValue : itemSend + GetDelimiter(sbItem.ElementDelimiter, true) + sValue;
                }
            }
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Lấy kí tự nối ngày tháng năm. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="_DelimiterDate">   Thông tin nối ngày tháng năm. </param>
        ///
        /// <returns>   The date delimiter. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string GetDateDelimiter(EDelimiterDate _DelimiterDate)
        {
            switch (_DelimiterDate)
            {
                case EDelimiterDate.Slash:
                    return cDelimiterDateValues.Slash;
                case EDelimiterDate.Dash:
                    return cDelimiterDateValues.Dash;
                case EDelimiterDate.Dot:
                    return cDelimiterDateValues.Dot;
                case EDelimiterDate.Space:
                    return cDelimiterDateValues.Space;
                case EDelimiterDate.None:
                    return cDelimiterDateValues.None;
                default:
                    return cDelimiterDateValues.None;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Lấy định dạng ngày tháng năm. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="_SBItem">  Dòng dữ liệu nối. </param>
        ///
        /// <returns>   The date format. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string GetDateFormat(SStringBuilderItem _SBItem)
        {
            if (_SBItem.DateFormat == EDateFormat.none) return string.Empty;
            if (_SBItem.DelimiterDate == EDelimiterDate.None)
            {
                switch (_SBItem.DateFormat)
                {
                    case EDateFormat.yymmdd:
                        return cDateFormat.yymmdd;
                    case EDateFormat.yyyymmdd:
                        return cDateFormat.yyyymmdd;
                    case EDateFormat.ddmmyy:
                        return cDateFormat.ddmmyy;
                    case EDateFormat.ddmmyyyy:
                        return cDateFormat.ddmmyyyy;
                    case EDateFormat.mmddyy:
                        return cDateFormat.mmddyy;
                    case EDateFormat.mmddyyyy:
                        return cDateFormat.mmddyyyy;
                }
            }
            else
            {
                switch (_SBItem.DateFormat)
                {
                    case EDateFormat.yymmdd:
                        return cDateFormat.yymmdde.Replace("e", GetDateDelimiter(_SBItem.DelimiterDate));
                    case EDateFormat.yyyymmdd:
                        return cDateFormat.yyyymmdde.Replace("e", GetDateDelimiter(_SBItem.DelimiterDate));
                    case EDateFormat.ddmmyy:
                        return cDateFormat.ddmmyye.Replace("e", GetDateDelimiter(_SBItem.DelimiterDate));
                    case EDateFormat.ddmmyyyy:
                        return cDateFormat.ddmmyyyye.Replace("e", GetDateDelimiter(_SBItem.DelimiterDate));
                    case EDateFormat.mmddyy:
                        return cDateFormat.mmddyye.Replace("e", GetDateDelimiter(_SBItem.DelimiterDate));
                    case EDateFormat.mmddyyyy:
                        return cDateFormat.mmddyyyye.Replace("e", GetDateDelimiter(_SBItem.DelimiterDate));
                }
            }

            return string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Lấy kí tự nối thời gian. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="delimiterTime">   Thông tin nối thời gian. </param>
        ///
        /// <returns>   The time delimiter. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string GetTimeDelimiter(EDelimiterTime delimiterTime)
        {
            switch (delimiterTime)
            {
                case EDelimiterTime.Colon:
                    return cDelimiterTimeValues.Colon;
                case EDelimiterTime.Dot:
                    return cDelimiterTimeValues.Dot;
                case EDelimiterTime.Space:
                    return cDelimiterTimeValues.Space;
                case EDelimiterTime.None:
                    return cDelimiterTimeValues.None;
                default:
                    return cDelimiterTimeValues.None;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Lấy định dạng thời gian. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        ///
        /// <returns>   The time format. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string GetTimeFormat(SStringBuilderItem sbItem)
        {
            if (sbItem.TimeFormat == ETimeFormat.None) return string.Empty;

            if (sbItem.DelimiterTime == EDelimiterTime.None)
            {
                switch (sbItem.TimeFormat)
                {
                    case ETimeFormat.hhmmss24:
                        return cTimeFormat.hhmmss24;
                    case ETimeFormat.hhmmss12:
                        return cTimeFormat.hhmmss12;
                }
            }
            else
            {
                string result = string.Empty;
                switch (sbItem.TimeFormat)
                {
                    case ETimeFormat.hhmmss24:
                        result = cTimeFormat.hhmmss24e.Replace("e", GetTimeDelimiter(sbItem.DelimiterTime));
                        break;
                    case ETimeFormat.hhmmss12:
                        result = cTimeFormat.hhmmss12e.Replace("e", GetTimeDelimiter(sbItem.DelimiterTime));
                        break;
                }

                string sDecimalPlace = string.Empty;

                if (sbItem.UseDecimalPlaces)
                {
                    while (sDecimalPlace.Length < sbItem.DecimalPlaces)
                    {
                        sDecimalPlace = sDecimalPlace + "f";
                    }
                    sDecimalPlace = sDecimalPlace != string.Empty ? "." + sDecimalPlace : string.Empty;
                }

                return result.Replace("d", sDecimalPlace);
            }

            return string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gen chuỗi với kiểu DateTime. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="_SBItem">  Dòng dữ liệu nối. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string Run_StringBuilder_GetDateTime(SStringBuilderItem _SBItem)
        {
            string _Result = _SBItem.ValueView;

            if (_SBItem.ValueView != string.Empty)
            {
                if (GetDateFormat(_SBItem) != string.Empty)
                    _Result = DateTime.Now.Date.ToString(GetDateFormat(_SBItem));
                else
                    _Result = string.Empty;

                string sFormat = GetTimeFormat(_SBItem);
                if (sFormat != string.Empty)
                    _Result = _Result == string.Empty ? DateTime.Now.ToString(sFormat) : _Result + " " + DateTime.Now.ToString(sFormat);
            }
            return _Result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gen chuỗi với kiểu String. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string Run_StringBuilder_GetString(SStringBuilderItem sbItem)
        {
            string result = sbItem.ValueView;

            if (sbItem.ValueView != string.Empty)
            {
                result = GlobFuncs.Ve2Str(sbItem.ListStringValue[0]);

                if (sbItem.UseLimitInput && result.Length > sbItem.MaximumLength)
                    result = result.Substring(0, sbItem.MaximumLength);

                if (sbItem.UseMiniumLength)
                    result = AddPadWith(result, sbItem.MiniumLength, sbItem.PadWith);
            }
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gen chuỗi với kiểu String List. </summary>
        /// 
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        /// 
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        /// <param name="itemSend"></param>
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string Run_StringBuilder_GetStringList(SStringBuilderItem sbItem, out string itemSend)
        {
            string result = string.Empty;
            itemSend = string.Empty;
            if (sbItem.ValueView != string.Empty && !sbItem.ValueView.StartsWith("0"))
            {
                for (int i = 0; i < sbItem.ListStringValue.Count; i++)
                {
                    string value = GlobFuncs.Ve2Str(sbItem.ListStringValue[i]);

                    if (sbItem.UseMiniumLength)
                        value = AddPadWith(value, sbItem.MiniumLength, sbItem.PadWith);
                    if (sbItem.UseLimitInput && value.Length > sbItem.MaximumLength)
                        value = value.Substring(0, sbItem.MaximumLength);
                    result = i == 0 ? value : result + GetDelimiter(sbItem.ElementDelimiter) + value;
                    itemSend = i == 0 ? value : itemSend + GetDelimiter(sbItem.ElementDelimiter, true) + value;
                }
            }
            return result;
        }

        /// <summary>
        /// Lấy kí tự nối các phần tử
        /// </summary>
        /// <param name="delimiter">Loại kí tự nối</param>
        /// <returns>Chuỗi sau khi nối</returns>
        private string GetInternalDelimiter(EXYDelimiter delimiter)
        {
            switch (delimiter)
            {
                case EXYDelimiter.None:
                    return string.Empty;
                case EXYDelimiter.Comma:
                    return cDelimiterValues.Comma;
                case EXYDelimiter.Space:
                    return cDelimiterValues.Space;
                case EXYDelimiter.Colon:
                    return cDelimiterValues.Colon;
                case EXYDelimiter.Semicolon:
                    return cDelimiterValues.Semicolon;
                case EXYDelimiter.Underscore:
                    return cDelimiterValues.Underscore;
                default:
                    return string.Empty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Nối 2 phần tử trong list. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="s1">          Phần tử 1. </param>
        /// <param name="s2">          Phần tử 2. </param>
        /// <param name="delimiter">   Thông tin nối phần tử. </param>
        ///
        /// <returns>   Chuỗi sau nối. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string JoinStringWithInternalDelimiter(string s1, string s2, EXYDelimiter delimiter)
        {
            switch (delimiter)
            {
                case EXYDelimiter.None:
                    return s1 + s2;
                case EXYDelimiter.Comma:
                    return s1 + cDelimiterValues.Comma + s2;
                case EXYDelimiter.Space:
                    return s1 + cDelimiterValues.Space + s2;
                case EXYDelimiter.Colon:
                    return s1 + cDelimiterValues.Colon + s2;
                case EXYDelimiter.Semicolon:
                    return s1 + cDelimiterValues.Semicolon + s2;
                case EXYDelimiter.Underscore:
                    return s1 + cDelimiterValues.Underscore + s2;
                default:
                    return s1 + s2;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Chuẩn hóa lại kí tự bọc phần tử. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="value">               Phần tử. </param>
        /// <param name="groupingBracket"> Thông tin bọc phần tử. </param>
        ///
        /// <returns>   Chuỗi sau chuẩn hóa. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string ReplaceGroupingBracket(string value, EGroupingBracket groupingBracket)
        {
            string result = value;
            switch (groupingBracket)
            {
                case EGroupingBracket.None:
                    result = result.Replace(cGroupingBracketValues.ParenthesesB, "");
                    result = result.Replace(cGroupingBracketValues.ParenthesesE, "");
                    break;
                case EGroupingBracket.Parenttheses:
                    result = result.Replace(cGroupingBracketValues.ParenthesesB, cGroupingBracketValues.ParenthesesB);
                    result = result.Replace(cGroupingBracketValues.ParenthesesE, cGroupingBracketValues.ParenthesesE);
                    break;
                case EGroupingBracket.Braces:
                    result = result.Replace(cGroupingBracketValues.ParenthesesB, cGroupingBracketValues.BracesB);
                    result = result.Replace(cGroupingBracketValues.ParenthesesE, cGroupingBracketValues.BracesE);
                    break;
                case EGroupingBracket.SquareBracket:
                    result = result.Replace(cGroupingBracketValues.ParenthesesB, cGroupingBracketValues.SquareBracketB);
                    result = result.Replace(cGroupingBracketValues.ParenthesesE, cGroupingBracketValues.SquareBracketE);
                    break;
                case EGroupingBracket.SmallBig:
                    result = result.Replace(cGroupingBracketValues.ParenthesesB, cGroupingBracketValues.SmallBigB);
                    result = result.Replace(cGroupingBracketValues.ParenthesesE, cGroupingBracketValues.SmallBigE);
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>Lấy string từ giá trị Double trong 1 dòng dữ liệu nối.</summary>
        /// <remarks>DATRUONG, 11/11/2021.</remarks>
        /// <param name="value"> Giá trị dạng HTuple.</param>
        /// <param name="sbItem">Dòng dữ liệu nối.</param>
        /// <returns>Chuỗi sau replace.</returns>

        private string GetStringToDoubleInSBItem(object value, SStringBuilderItem sbItem)
        {
            double dItem = GlobFuncs.Object2Double(value);
            dItem = Math.Round(dItem, sbItem.DecimalPlaces);
            var result = dItem.ToString();
            if (sbItem.UseMiniumLength)
                result = AddPadWith(result, sbItem.MiniumLength, sbItem.PadWith);
            if (sbItem.UseLimitInput && result.Length > sbItem.MaximumLength)
                result = result.Substring(0, sbItem.MaximumLength);

            return result;
        }

        /// <summary>Gen chuỗi với kiểu Point.</summary>
        /// <remarks>DATRUONG, 11/11/2021.</remarks>
        /// <param name="sbItem">Dòng dữ liệu nối.</param>
        /// <returns>Chuỗi sau GEN.</returns>

        private string Run_StringBuilder_GetPoint(SStringBuilderItem sbItem)
        {
            string result = sbItem.ValueView;
            if (sbItem.ValueView != string.Empty)
            {
                result = "(" + GetStringToDoubleInSBItem(sbItem.ListDoubleValue[0], sbItem);
                result = JoinStringWithInternalDelimiter(result, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[1], sbItem), sbItem.XYDelimiter) + ")";
                result = ReplaceGroupingBracket(result, sbItem.GroupingBracket);
            }
            return result;
        }

        /// <summary>Gen chuỗi với kiểu Point List.</summary>
        /// <remarks>DATRUONG, 11/11/2021.</remarks>
        /// <param name="sbItem"> Dòng dữ liệu nối.</param>
        /// <param name="itemSend">[out] The item send.</param>
        /// <returns>Chuỗi sau GEN.</returns>

        private string Run_StringBuilder_GetPointList(SStringBuilderItem sbItem, out string itemSend)
        {
            string result = string.Empty;
            itemSend = string.Empty;
            if (sbItem.ValueView != string.Empty && !sbItem.ValueView.StartsWith("0"))
            {
                for (int i = 0; i < sbItem.ListDoubleValue.Count; i += 2)
                {
                    string value = "(" + GetStringToDoubleInSBItem(sbItem.ListDoubleValue[i], sbItem);
                    value = JoinStringWithInternalDelimiter(value, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[i + 1], sbItem), sbItem.XYDelimiter) + ")";
                    value = ReplaceGroupingBracket(value, sbItem.GroupingBracket);

                    result = i == 0 ? value : result + GetDelimiter(sbItem.ElementDelimiter) + value;
                    itemSend = i == 0 ? value : itemSend + GetDelimiter(sbItem.ElementDelimiter, true) + value;
                }
            }
            return result;
        }

        /// <summary>Gen chuỗi với kiểu Origin.</summary>
        /// <remarks>DATRUONG, 11/11/2021.</remarks>
        /// <param name="sbItem">Dòng dữ liệu nối.</param>
        /// <returns>Chuỗi sau GEN.</returns>

        private string Run_StringBuilder_GetOrigin(SStringBuilderItem sbItem)
        {
            string result = sbItem.ValueView;
            if (sbItem.ValueView != string.Empty)
            {
                result = "((" + GetStringToDoubleInSBItem(sbItem.ListDoubleValue[0], sbItem);
                result = JoinStringWithInternalDelimiter(result, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[1], sbItem), sbItem.XYDelimiter) + ")";
                result = JoinStringWithInternalDelimiter(result, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[2], sbItem), sbItem.XYDelimiter) + ")";
                result = ReplaceGroupingBracket(result, sbItem.GroupingBracket);
            }
            return result;
        }

        /// <summary>Gen chuỗi với kiểu Origin List.</summary>
        /// <remarks>DATRUONG, 11/11/2021.</remarks>
        /// <param name="sbItem">Dòng dữ liệu nối.</param>
        /// <param name="itemSend"></param>
        /// <returns>Chuỗi sau GEN.</returns>
        private string Run_StringBuilder_GetOriginList(SStringBuilderItem sbItem, out string itemSend)
        {
            string result = string.Empty;
            itemSend = string.Empty;
            if (sbItem.ValueView != string.Empty && !sbItem.ValueView.StartsWith("0"))
            {
                for (int i = 0; i < sbItem.ListDoubleValue.Capacity; i += 3)
                {
                    string value = "((" + GetStringToDoubleInSBItem(sbItem.ListDoubleValue[i], sbItem);
                    value = JoinStringWithInternalDelimiter(value, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[i + 1], sbItem), sbItem.XYDelimiter) + ")";
                    value = JoinStringWithInternalDelimiter(value, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[i + 2], sbItem), sbItem.XYDelimiter) + ")";
                    value = ReplaceGroupingBracket(value, sbItem.GroupingBracket);

                    result = i == 0 ? value : result + GetDelimiter(sbItem.ElementDelimiter) + value;
                    itemSend = i == 0 ? value : itemSend + GetDelimiter(sbItem.ElementDelimiter, true) + value;
                }
            }
            return result;
        }

        /// <summary>Gen chuỗi với kiểu Rectange.</summary>
        /// <remarks>DATRUONG, 11/11/2021.</remarks>
        /// <param name="sbItem">Dòng dữ liệu nối.</param>
        /// <returns>Chuỗi sau GEN.</returns>

        private string Run_StringBuilder_GetRectange(SStringBuilderItem sbItem)
        {
            string result = sbItem.ValueView;
            if (sbItem.ValueView != string.Empty)
            {
                result = "(((" + GetStringToDoubleInSBItem(sbItem.ListDoubleValue[0], sbItem);
                result = JoinStringWithInternalDelimiter(result, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[1], sbItem), sbItem.XYDelimiter) + ")";
                result = JoinStringWithInternalDelimiter(result, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[2], sbItem), sbItem.XYDelimiter) + "°)" +
                    GetInternalDelimiter(sbItem.XYDelimiter) + "(";
                result = JoinStringWithInternalDelimiter(result, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[3], sbItem), sbItem.XYDelimiter);
                result = JoinStringWithInternalDelimiter(result, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[4], sbItem), sbItem.XYDelimiter) + "))";
                result = ReplaceGroupingBracket(result, sbItem.GroupingBracket);
            }
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gen chuỗi với kiểu Rectange List. </summary>
        /// 
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        /// 
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        /// <param name="itemSend"></param>
        /// <returns>   Chuỗi sau GEN. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string Run_StringBuilder_GetRectangeList(SStringBuilderItem sbItem, out string itemSend)
        {
            string result = string.Empty;
            itemSend = string.Empty;
            if (sbItem.ValueView != string.Empty && !sbItem.ValueView.StartsWith("0"))
            {
                for (int i = 0; i < sbItem.ListDoubleValue.Count; i += 3)
                {
                    string value = "(((" + GetStringToDoubleInSBItem(sbItem.ListDoubleValue[0], sbItem);
                    value = JoinStringWithInternalDelimiter(value, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[1], sbItem), sbItem.XYDelimiter) + ")";
                    value = JoinStringWithInternalDelimiter(value, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[2], sbItem), sbItem.XYDelimiter) + "°)" +
                        GetInternalDelimiter(sbItem.XYDelimiter) + "(";
                    value = JoinStringWithInternalDelimiter(value, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[3], sbItem), sbItem.XYDelimiter);
                    value = JoinStringWithInternalDelimiter(value, GetStringToDoubleInSBItem(sbItem.ListDoubleValue[4], sbItem), sbItem.XYDelimiter) + "))";
                    value = ReplaceGroupingBracket(value, sbItem.GroupingBracket);

                    result = i == 0 ? value : result + GetDelimiter(sbItem.ElementDelimiter) + value;
                    itemSend = i == 0 ? value : itemSend + GetDelimiter(sbItem.ElementDelimiter, true) + value;
                }
            }
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the string builder get data list operation. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="sbItem">  Dòng dữ liệu nối. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_StringBuilder_GetDataList(SStringBuilderItem sbItem)
        {
            if (sbItem != null && sbItem.ListStringValue != null)
            {
                for (int i = 0; i < sbItem.ListStringValue.Count; i++)
                {
                    string sValue = GlobFuncs.Ve2Str(sbItem.ListStringValue[i]);
                    if (double.TryParse(sValue, out double dValue))
                        OutputDataList.rtcValue.Add(dValue);
                    else if (int.TryParse(sValue, out int iValue))
                        OutputDataList.rtcValue.Add(iValue);
                    else if (bool.TryParse(sValue.ToLower(), out bool bValue))
                        OutputDataList.rtcValue.Add(bValue ? sbItem.TrueText : sbItem.FalseText);
                    else
                        OutputDataList.rtcValue.Add(sValue);
                }
            }
            if (sbItem != null && sbItem.ListDoubleValue != null)
            {
                for (int i = 0; i < sbItem.ListDoubleValue.Count; i++)
                {
                    string sValue = GlobFuncs.Ve2Str(sbItem.ListDoubleValue[i]);
                    if (double.TryParse(sValue, out double dValue))
                        OutputDataList.rtcValue.Add(dValue);
                    else if (int.TryParse(sValue, out int iValue))
                        OutputDataList.rtcValue.Add(iValue);
                    else if (bool.TryParse(sValue.ToLower(), out bool bValue))
                        OutputDataList.rtcValue.Add(bValue ? sbItem.TrueText : sbItem.FalseText);
                    else
                        OutputDataList.rtcValue.Add(sValue);
                }
            }
        }
        private void Run_StringBuilder_AddToDataList(string value)
        {
            if (double.TryParse(value, out double dValue))
                OutputDataList.rtcValue.Append(dValue);
            else if (int.TryParse(value, out int iValue))
                OutputDataList.rtcValue.Append(iValue);
            else if (bool.TryParse(value.ToLower(), out bool bValue))
                OutputDataList.rtcValue.Append(bValue.ToString().ToLower());
            else
                OutputDataList.rtcValue.Append(value);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Hàm chính lấy chuỗi truyền thông. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_StringBuilder()
        {
            Stopwatch watch = null;
            if (!MyGroup.RunSimple)
                watch = System.Diagnostics.Stopwatch.StartNew();

            StringBuilder _ResultH = new StringBuilder();
            StringBuilder _ResultV = new StringBuilder();
            StringBuilder _ResultSend = new StringBuilder();
            OutputDataList.rtcValue = new List<object>();
            if (StringBuilders != null)
            {
                var orderList = from sbItem in StringBuilders
                                orderby sbItem.OrderNum
                                select sbItem;
                string sItem = string.Empty;
                string sItemView = string.Empty;
                string sItemSend = string.Empty;
                string sItemDelimiter = GetDelimiterAction();
                string sItemDelimiterSend = GetDelimiterAction(true);
                foreach (SStringBuilderItem sbItem in orderList)
                {
                    switch (sbItem.ValueStyle)
                    {
                        case EHTupleStyle.Point:
                            sItem = Run_StringBuilder_GetPoint(sbItem);
                            sItemSend = sItem;
                            break;
                        case EHTupleStyle.PointList:
                            sItem = Run_StringBuilder_GetPointList(sbItem, out sItemSend);
                            break;
                        case EHTupleStyle.Rectangle:
                            sItem = Run_StringBuilder_GetRectange(sbItem);
                            sItemSend = sItem;
                            break;
                        case EHTupleStyle.RectangleList:
                            sItem = Run_StringBuilder_GetRectangeList(sbItem, out sItemSend);
                            break;
                        case EHTupleStyle.Origin:
                            sItem = Run_StringBuilder_GetOrigin(sbItem);
                            sItemSend = sItem;
                            break;
                        case EHTupleStyle.OriginList:
                            sItem = Run_StringBuilder_GetOriginList(sbItem, out sItemSend);
                            break;
                        case EHTupleStyle.Boolean:
                            sItem = Run_StringBuilder_GetBoolean(sbItem);
                            sItemSend = sItem;
                            break;
                        case EHTupleStyle.BooleanList:
                            sItem = Run_StringBuilder_GetBooleanList(sbItem, out sItemSend);
                            break;
                        case EHTupleStyle.Integer:
                            sItem = Run_StringBuilder_GetInteger(sbItem);
                            sItemSend = sItem;
                            break;
                        case EHTupleStyle.IntegerList:
                            sItem = Run_StringBuilder_GetIntegerList(sbItem, out sItemSend);
                            break;
                        case EHTupleStyle.String:
                            sItem = Run_StringBuilder_GetString(sbItem);
                            sItemSend = sItem;
                            break;
                        case EHTupleStyle.StringList:
                            sItem = Run_StringBuilder_GetStringList(sbItem, out sItemSend);
                            break;
                        case EHTupleStyle.DateAndTime:
                            sItem = Run_StringBuilder_GetDateTime(sbItem);
                            sItemSend = sItem;
                            break;
                        case EHTupleStyle.Real:
                            sItem = Run_StringBuilder_GetReal(sbItem);
                            sItemSend = sItem;
                            break;
                        case EHTupleStyle.RealList:
                            sItem = Run_StringBuilder_GetRealList(sbItem, out sItemSend);
                            break;
                    }

                    if (sbItem.ValueStyle != EHTupleStyle.DateAndTime)
                        Run_StringBuilder_GetDataList(sbItem);
                    else
                        Run_StringBuilder_AddToDataList(sItemSend);

                    sItemView = sItem;
                    sItem = ReplaceDelemiterStringToSendDataString(sbItem.Leading) + sItem + ReplaceDelemiterStringToSendDataString(sbItem.Tralling);
                    sItemView = sbItem.Leading + sItemView + sbItem.Tralling;
                    sItemSend = ReplaceDelemiterStringToSendDataString(sbItem.Leading) + sItemSend + ReplaceDelemiterStringToSendDataString(sbItem.Tralling);

                    if (_ResultV.Length >= 1)
                    {
                        _ResultV.Append(sItemDelimiter);
                        _ResultH.Append(sItemDelimiter);
                        _ResultSend.Append(sItemDelimiterSend);
                    }
                    _ResultV.Append(sItemView);
                    _ResultH.Append(sbItem.Leading + sbItem.Name + sbItem.Tralling);
                    _ResultSend.Append(sItemSend);
                }

                OutputString.rtcValue = LeadingText.rtcValue + _ResultV.ToString() + TrallingText.rtcValue;
                OutputHeaderString.rtcValue = LeadingText.rtcValue + _ResultH.ToString() + TrallingText.rtcValue;
                OutputStringSend.rtcValue = ReplaceDelemiterStringToSendDataString(LeadingText.rtcValue) + _ResultSend.ToString() + ReplaceDelemiterStringToSendDataString(TrallingText.rtcValue);
                OutputDataList.rtcValue = OutputDataList.rtcValue;

                switch ((ETermiator)Terminator.rtcValue)
                {
                    case ETermiator.None:
                        break;
                    case ETermiator.CarriageReturn:
                        OutputString.rtcValue = OutputString.rtcValue + "[CR]";
                        OutputHeaderString.rtcValue = OutputHeaderString.rtcValue + "[CR]";
                        OutputStringSend.rtcValue = OutputStringSend.rtcValue + "\r";
                        break;
                    case ETermiator.LineFeed:
                        OutputString.rtcValue = OutputString.rtcValue + "[LF]";
                        OutputHeaderString.rtcValue = OutputHeaderString.rtcValue + "[LF]";
                        OutputStringSend.rtcValue = OutputStringSend.rtcValue + "\n";
                        break;
                    case ETermiator.CarriageReturnAndLineFeed:
                        OutputString.rtcValue = OutputString.rtcValue + "[CR][LF]";
                        OutputHeaderString.rtcValue = OutputHeaderString.rtcValue + "[CR][LF]";
                        OutputStringSend.rtcValue = OutputStringSend.rtcValue + "\r\n";
                        break;
                    default:
                        break;
                }
            }
          
            Passed.rtcValue = true;
            if (!MyGroup.RunSimple)
            {
                watch.Stop();

                this.ViewInfo?.Invoke(new Action(() =>
                {
                    //GlobFuncs.BeginControlUpdate(this.ViewInfo);
                    ((ucStringBuilderDetail)this.ViewInfo).ShowStringResult();
                    ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
                    //GlobFuncs.EndControlUpdate(this.ViewInfo);
                }));
                //this.RunCount += 1;
                //this.FailCount += (this.Passed != null && !this.Passed.rtcValue) ? 1 : 0;
                //this.ProcessTime = watch.ElapsedMilliseconds;
                //this.TotalTime += this.ProcessTime;
                //if (this.ErrMessage != null && this.ErrMessage.rtcValue.Length > 0)
                //{
                //    this.AbortCause = this.ErrMessage.rtcValue[2];
                //}
                //else this.AbortCause = string.Empty;

                //this.MyNode.SetValue(this.MyNode.TreeList.Columns[nameof(this.RunCount)], this.RunCount);
                //this.MyNode.SetValue(this.MyNode.TreeList.Columns[nameof(this.FailCount)], this.FailCount);
                //this.MyNode.SetValue(this.MyNode.TreeList.Columns[nameof(this.ProcessTime)], this.ProcessTime);
                //this.MyNode.SetValue(this.MyNode.TreeList.Columns[nameof(this.TotalTime)], this.TotalTime);
                //this.MyNode.SetValue(this.MyNode.TreeList.Columns[nameof(this.AbortCause)], this.AbortCause);
            }
        }
        #endregion    
    }
}
