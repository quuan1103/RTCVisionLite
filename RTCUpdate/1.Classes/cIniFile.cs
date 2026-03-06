using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCUpdate.Classes
{
    public class cIniFile
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileStringA(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, System.Text.StringBuilder lpReturnedString, int nSize, string lpFileName);

        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);
        private const string EscapeChar = "#";

        public void WritePrivateProfileStringUnicode(string ApplicationName, string KeyName, string Value, string FileName)
        {
            string ValueUnicode = EncodeUnicodeString(Value);
            WritePrivateProfileString(ApplicationName, KeyName, ValueUnicode, FileName);
        }

        public string GetPrivateProfileStringUnicode(string ApplicationName, string KeyName, string FileName)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(500);
            GetPrivateProfileString(ApplicationName, KeyName, "", sb, sb.Capacity, FileName);
            return DecodeUnicodeString(sb.ToString());
        }

        public string EncodeUnicodeString(string value)
        {
            string NewValue = Strings.Replace(value, EscapeChar, EscapeChar + Strings.Asc(EscapeChar) + EscapeChar);
            if (IsUnicode(NewValue))
            {
                int i;
                string ValueUnicode = "";
                for (i = 1; i <= Strings.Len(NewValue); i++)
                {
                    string strChar = Strings.Mid(NewValue, i, 1);
                    if (Strings.AscW(strChar) > 255 | Strings.AscW(strChar) < 0)
                        strChar = EscapeChar + Strings.AscW(strChar) + EscapeChar;
                    ValueUnicode = ValueUnicode + strChar;
                }
                return ValueUnicode;
            }
            else
                return NewValue;
        }

        public string DecodeUnicodeString(string value)
        {
            if(Strings.InStr(value, EscapeChar) == 0)
                return value;
            else
            {
                int i;
                string[] Parts = Strings.Split(value, EscapeChar); // Split value to Array
                for (i = 1; i <= Information.UBound(Parts); i += 2) // If i is an odd number Parts(i) always contains a integer which should be converted back
                    Parts[i] = Strings.Trim(Convert.ToString(Strings.ChrW(Convert.ToInt32(Parts[i]))));
                return Strings.Join(Parts, "");
            }
        }

        private bool IsUnicode(string input)
        {
            var asciiBytesCount = System.Text.Encoding.ASCII.GetByteCount(input);
            var unicodBytesCount = System.Text.Encoding.UTF8.GetByteCount(input);

            return asciiBytesCount != unicodBytesCount;
        }

        private string strFileName;

        public cIniFile(string FileName)
        {
            strFileName = FileName;
        }

        public string FileName
        {
            get
            {
                return strFileName;
            }
        }

        public string GetString(string Section, string Key, string Default)
        {
            string sResult = GetPrivateProfileStringUnicode(Section, Key, strFileName);
            if (sResult == "")
                sResult = Default;
            return sResult;
        }

        public int GetInteger(string Section, string Key, int Default)
        {
            return GetPrivateProfileInt(Section, Key, Default, strFileName);
        }

        public double GetDouble(string Section, string Key, double Default)
        {
            string sResult = GetPrivateProfileStringUnicode(Section, Key, strFileName);
            if (!double.TryParse(sResult.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator), out double result))
                return Default;
            else
                return result;
        }

        public bool GetBoolean(string Section, string Key, bool Default)
        {
            int value = GetPrivateProfileInt(Section, Key, Convert.ToInt32(Default), strFileName);
            return (value == -1 || value == 1);
        }

        public void WriteString(string Section, string Key, string Value)
        {
            if (Value.Trim() == "")
                return;
            WritePrivateProfileStringUnicode(Section, Key, Value, strFileName);
        }

        public void WriteInteger(string Section, string Key, int Value)
        {
            WriteString(Section, Key, Convert.ToString(Value));
            Flush();
        }

        public void WriteBoolean(string Section, string Key, bool Value)
        {
            if (Value)
                WriteString(Section, Key, "-1");
            else
                WriteString(Section, Key, "0");
        }

        private void Flush()
        {

        }
    }
}
