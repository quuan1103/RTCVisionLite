using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCLibs
{
    public class cIniFile
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);
        public void WritePrivateProfileStringUnicode(string ApplicationName, string KeyName, string Value, string FileName)
        {
            string ValueUnicode = EncodeUnicodeString(Value);
            WritePrivateProfileString(ApplicationName, KeyName, ValueUnicode, FileName);
        }
        private const string EscapeChar = "#";

        private string strFilename;
        public string EncodeUnicodeString(string value)
        {
            string NewValue = Strings.Replace(value, EscapeChar, EscapeChar + Strings.Asc(EscapeChar) + EscapeChar);
            if (IsUnicode(NewValue))
            {
                int i;
                string ValueUnicode = "";
                for (i = 1; i < Strings.Len(NewValue); i++)
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
        private bool IsUnicode(string input)
        {
            var asciiBytesCount = System.Text.Encoding.ASCII.GetByteCount(input);
            var unicodeBytesCount = System.Text.Encoding.UTF8.GetByteCount(input);
            return asciiBytesCount != unicodeBytesCount;
        }
        public cIniFile(string Filename)
        {
            strFilename = Filename;
        }

        public string Filename
        {
            get
            {
                return strFilename;
            }
        }

        public string GetString(string Section, string Key, string Default)
        {
            string sResult = GetPrivateProfileStringUnicode(Section, Key, strFilename);
            if (sResult == "")
                sResult = Default;
            return sResult;
        }

        public string GetPrivateProfileStringUnicode(string ApplicationName, string KeyName, string FileName)
        {
            StringBuilder sb = new StringBuilder(500);
            GetPrivateProfileString(ApplicationName, KeyName, "", sb, sb.Capacity, FileName);
            return DecodeUnicodeString(sb.ToString());
        }

        public string DecodeUnicodeString(string value)
        {
            if (Strings.InStr(value, EscapeChar) == 0)
                return value;
            else
            {
                int i;
                string[] Parts = Strings.Split(value, EscapeChar);
                for (i = 1; i <= Information.UBound(Parts); i += 2)
                    Parts[i] = Strings.Trim(Convert.ToString(Strings.ChrW(Convert.ToInt32(Parts[i]))));
                return Strings.Join(Parts, "");
            }
        }
        public double GetDouble(string Section, string Key, double Default)
        {
            string sResult = GetPrivateProfileStringUnicode(Section, Key, strFilename);
            if (!double.TryParse(sResult.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator), out double result))
                return Default;
            else
                return result;
        }
        public bool GetBoolean(string Section, string Key, bool Default)
        {
            int value = GetPrivateProfileInt(Section, Key, System.Convert.ToInt32(Default), strFilename);
            return (value == -1 || value == 1);
        }
        public int GetInteger(string section, string Key, int Default)
        {
            return GetPrivateProfileInt(section, Key, Default, strFilename);
        }

        public void WriteString(string Section, string Key, string Value)
        {
            if (Value.Trim() == "")
                return;
            WritePrivateProfileStringUnicode(Section, Key, Value, strFilename);
        }
        public void WriteInteger(string Section, string Key, int Value)
        {
            WriteString(Section, Key, System.Convert.ToString(Value));
            //Flush();
        }
        public void WriteDouble(string Section, string Key, double Value)
        {
            string sValue = Value.ToString().Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".");
            WriteString(Section, Key, sValue);
        }
        public void WriteBoolean(string Section, string Key, bool Value)
        {
            if (Value)
                WriteString(Section, Key, "-1");
            else
                WriteString(Section, Key, "0");
        }
    }
}
