using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCLibs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        private int _csvOrder = 0;
        private string _csvCurrentFileName = string.Empty;
        public void Run_SaveCsv_Reset()
        {
            StartNumber.rtcValue = ResetNumber.rtcValue;
            OutputFileName.rtcValue = string.Empty;
            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        public void Run_SaveCsv_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MyGroup.GetValueToVariableIsRef(this);
            Run_SaveCsv();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        private string Run_SaveCsv_RebuildFileNameWhenOutOfLineCount(string oldFileName)
        {
            int count = 1;
            string sNewFileName = Path.GetFileNameWithoutExtension(oldFileName) + "_" + count.ToString() + cExtFile.DCSV;
            while (File.Exists(sNewFileName))
            {
                count++;
                sNewFileName = Path.GetFileNameWithoutExtension(oldFileName) + "_" + count.ToString() + cExtFile.DCSV;
            }
            return sNewFileName;
        }
        internal void Run_SaveCsv_Prepare()
        {
            if (Columns == null || Columns.Count <= 0)
                return;

            string sFileName = FileName.rtcValue.Trim();
            string sFolder = IsUseProjectFolder.rtcValue ? MyGroup.SaveFileFolder : FolderName.rtcValue;

            if (AutoCreateFolderByDate.rtcValue)
            {
                switch (DateFormat.rtcValue)
                {
                    case cDateTimeFormats.Split1:
                        {
                            sFolder = Path.Combine(sFolder, DateTime.Now.Year.ToString());
                            break;
                        }
                    case cDateTimeFormats.Split2:
                        {
                            sFolder = Path.Combine(sFolder, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());
                            break;
                        }
                    case cDateTimeFormats.Split3:
                        {
                            sFolder = Path.Combine(sFolder, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
                            break;
                        }
                    case cDateTimeFormats.Split4:
                        {
                            sFolder = Path.Combine(sFolder, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(),
                                DateTime.Now.Day.ToString(), DateTime.Now.Hour.ToString());
                            break;
                        }
                    default:
                        {
                            sFolder = Path.Combine(sFolder, DateTime.Now.ToString(DateFormat.rtcValue));
                            break;
                        }
                }
            }

            if (FixedFileName.rtcValue)
            {
                if (string.IsNullOrEmpty(sFileName))
                {
                    ErrMessage.rtcValue = new List<string> {cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                        new string[] { "File name" }, new string[] { "Tên tệp" }) };
                    return;
                }
                sFileName = GlobFuncs.FixedDirSepChar(sFolder) + FileName.rtcValue + cExtFile.DCSV;
            }
            else
            {
                sFileName = PrefixName.rtcValue;

                if (SuffixNameMode.rtcValue == cStrings.UseDateTime)
                {
                    if (DateTimeFormat.rtcValue == cDateTimeFormats.Tick)
                        sFileName = sFileName != "" ? sFileName + DateTime.Now.Ticks.ToString() : DateTime.Now.Ticks.ToString();
                    else
                        sFileName = sFileName != "" ? sFileName + DateTime.Now.ToString(DateTimeFormat.rtcValue) : DateTime.Now.ToString(DateTimeFormat.rtcValue);
                }
                else
                {
                    sFileName = sFileName != "" ? sFileName + StartNumber.rtcValue.ToString() : StartNumber.rtcValue.ToString();
                    if (StartNumber.rtcIDRef == Guid.Empty)
                    {
                        StartNumber.rtcValue += 1;
                        if (MaxNumber.rtcValue > 0 && StartNumber.rtcValue == MaxNumber.rtcValue)
                            StartNumber.rtcValue = ResetNumber.rtcValue;
                    }
                }

                sFileName = GlobFuncs.FixedDirSepChar(sFolder) + sFileName + cExtFile.DCSV;
            }

            if (sFileName != _csvCurrentFileName)
            {
                if (!File.Exists(sFileName))
                    _csvOrder = 0;
                else
                {
                    _csvOrder = File.ReadLines(sFileName).Count();
                    if (_csvOrder == 1048576) // Đã đạt max dòng
                        sFileName = Run_SaveCsv_RebuildFileNameWhenOutOfLineCount(sFileName);
                }
                _csvCurrentFileName = sFileName;
            }
            OutputFileName.rtcValue = sFileName;
        }
        /// <summary>
        /// Lưu file csv
        /// </summary>
        internal void Run_SaveCsv()
        {
            try
            {
                Passed.rtcValue = false;
                ErrMessage.rtcValue = new List<string>() { string.Empty };
                OutputFileName.rtcValue = string.Empty;

                if (Columns == null || Columns.Count <= 0)
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.War_CsvFileColumnCountRequiment };
                else
                {
                    Run_SaveCsv_Prepare();

                    if (!string.IsNullOrEmpty(OutputFileName.rtcValue))
                    {
                        var orderColumns = Columns.Where(x => x.Active).OrderBy(x => x.OrderNum).ToList();

                        var records = new List<CsvRecord>();
                        CsvRecord row = new CsvRecord();
                        bool isRowToCol = orderColumns.FirstOrDefault(x => x.IsRowToCol) != null;
                        if (isRowToCol)
                        {
                            #region Tạo các dữ liệu tự tách dòng
                            // Bắt đầu phân tích dữ liệu
                            List<string[]> list = new List<string[]>();
                            for (int i = 0; i < orderColumns.Count; i++)
                            {
                                string sValue = string.Empty;
                                if (orderColumns[i].RefID == Guid.Empty)
                                {
                                    if (orderColumns[i].DataType == cDataTypes.DateAndTime)
                                        sValue = DateTime.Now.ToString(orderColumns[i].Format);
                                    else
                                        sValue = orderColumns[i].Value;
                                }
                                else if (MyGroup.Actions.ContainsKey(orderColumns[i].RefID))
                                {
                                    cAction action = MyGroup.Actions[orderColumns[i].RefID];
                                    RTCVariableType rtcVariableType = (RTCVariableType)action.GetType()
                                        .GetProperty(orderColumns[i].PropName)?.GetValue(action, null);
                                    if (rtcVariableType != null)
                                        sValue = rtcVariableType.rtcValueS;
                                }

                                if (orderColumns[i].DataType == cDataTypes.AutoNumber)
                                    orderColumns[i].AutoNumber = _csvOrder;

                                list.Add(orderColumns[i].IsRowToCol
                                    ? sValue.Split(Separator.rtcValue[0])
                                    : new string[] { sValue });
                            }

                            int maxLength = list.Max(x => x.Length);
                            for (int i = 0; i < maxLength; i++)
                            {
                                row = new CsvRecord();
                                for (int j = 0; j < orderColumns.Count; j++)
                                {
                                    string[] strings = list[j];
                                    string s = strings.Length >= i + 1 ? strings[i] : strings[strings.Length - 1];

                                    switch (orderColumns[j].DataType)
                                    {
                                        case cDataTypes.Boolean:

                                        case cDataTypes.BooleanList:
                                            {
                                                if (orderColumns[j].Format == CDataFormat.BooleanOkNg)
                                                {
                                                    if (int.TryParse(s.Trim(), out int iValue))
                                                        s = iValue == 0 ? cStrings.False : cStrings.True;
                                                    s = s.Replace(cStrings.True, cStrings.OK);
                                                    s = s.Replace(cStrings.@true, cStrings.OK);
                                                    s = s.Replace(cStrings.False, cStrings.NG);
                                                    s = s.Replace(cStrings.@false, cStrings.NG);
                                                }
                                                break;
                                            }
                                        case cDataTypes.DateAndTime:
                                            {
                                                s = DateTime.Now.ToString(orderColumns[j].Format);
                                                break;
                                            }
                                        case cDataTypes.AutoNumber:
                                            {
                                                s = $"{orderColumns[j].AutoNumber += 1}";
                                                break;
                                            }
                                    }

                                    row.Value.Add(s);
                                }
                                records.Add(row);
                            }
                            #endregion
                        }
                        else
                        {
                            #region Tạo Row dữ liệu
                            // Ghi dòng dữ liệu
                            row = new CsvRecord();
                            for (int i = 0; i < orderColumns.Count; i++)
                            {
                                string sValue = string.Empty;
                                if (orderColumns[i].RefID == Guid.Empty)
                                    sValue = orderColumns[i].Value;

                                if (orderColumns[i].DataType == cDataTypes.AutoNumber)
                                    orderColumns[i].AutoNumber = _csvOrder;

                                else if (MyGroup.Actions.ContainsKey(orderColumns[i].RefID))
                                {
                                    cAction action = MyGroup.Actions[orderColumns[i].RefID];
                                    RTCVariableType rtcVariableType = (RTCVariableType)action.GetType()
                                        .GetProperty(orderColumns[i].PropName)?.GetValue(action, null);
                                    if (rtcVariableType != null)
                                        sValue = rtcVariableType.rtcValueS;
                                }

                                switch (orderColumns[i].DataType)
                                {
                                    case cDataTypes.Boolean:
                                        {
                                            if (orderColumns[i].Format == CDataFormat.BooleanOkNg)
                                            {
                                                sValue = sValue.Replace(cStrings.True, cStrings.OK);
                                                sValue = sValue.Replace(cStrings.@true, cStrings.OK);
                                                sValue = sValue.Replace(cStrings.False, cStrings.NG);
                                                sValue = sValue.Replace(cStrings.@false, cStrings.NG);
                                            }
                                            break;
                                        }
                                    case cDataTypes.BooleanList:
                                        {
                                            if (orderColumns[i].Format == CDataFormat.BooleanOkNg)
                                            {
                                                sValue = sValue.Replace(cStrings.True, cStrings.OK);
                                                sValue = sValue.Replace(cStrings.@true, cStrings.OK);
                                                sValue = sValue.Replace(cStrings.False, cStrings.NG);
                                                sValue = sValue.Replace(cStrings.@false, cStrings.NG);
                                            }
                                            break;
                                        }
                                    case cDataTypes.DateAndTime:
                                        {
                                            sValue = DateTime.Now.ToString(orderColumns[i].Format);
                                            break;
                                        }
                                    case cDataTypes.AutoNumber:
                                        {
                                            sValue = $"{orderColumns[i].AutoNumber += 1}";
                                            break;
                                        }
                                }
                                row.Value.Add(sValue);
                            }
                            records.Add(row);
                            #endregion
                        }

                        var haveSort = orderColumns.FirstOrDefault(x => x.SortMode != "" && x.SortMode != cSortMode.None) != null;
                        if (haveSort)
                        {
                            Dictionary<int, CsvRecord> dicRecords = new Dictionary<int, CsvRecord>();
                            int maxOrder = records.Count;

                            for (int i = 0; i < orderColumns.Count; i++)
                                if (orderColumns[i].SortMode != cSortMode.None)
                                {
                                    switch (orderColumns[i].SortMode)
                                    {
                                        case cSortMode.SortByNumber:
                                            {
                                                for (int j = 0; j < records.Count; j++)
                                                {
                                                    CsvRecord item = records[j];
                                                    if (int.TryParse(item.Value[i], out int iSort))
                                                    {
                                                        if (!dicRecords.ContainsKey(iSort))
                                                            dicRecords.Add(iSort, item);
                                                        else
                                                        {
                                                            maxOrder += 1;
                                                            dicRecords.Add(maxOrder, item);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        maxOrder += 1;
                                                        dicRecords.Add(maxOrder, item);
                                                    }
                                                }
                                                records = new List<CsvRecord>();
                                                records.AddRange(dicRecords.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value).Values.ToArray());
                                                break;
                                            }
                                        case cSortMode.SortByText:
                                            {
                                                records = records.OrderBy(x => x.Value[i]).ToList();
                                                break;
                                            }
                                        default:
                                            break;
                                    }
                                }
                        }

                        List<CsvRecord> finalRecords = new List<CsvRecord>();
                        if (_csvOrder == 0)
                        {
                            row = new CsvRecord();
                            for (int i = 0; i < orderColumns.Count; i++)
                                row.Value.Add(orderColumns[i].Name);
                            finalRecords.Add(row);
                            finalRecords.AddRange(records);
                        }
                        else
                            finalRecords = records;

                        Passed.rtcValue = RTCLibs.CsvFile.Write(finalRecords, OutputFileName.rtcValue, ref _csvOrder,
                            out string errMessage);

                        ErrMessage.rtcValue = new List<string>() { errMessage };
                        if (_csvOrder > cMaxRowCount.Csv) // Đã đạt max dòng
                        {
                            OutputFileName.rtcValue =
                                Run_SaveCsv_RebuildFileNameWhenOutOfLineCount(OutputFileName.rtcValue);
                            _csvOrder = 0;
                        }
                    }
                }

                //if (this.ViewInfo != null)
                //    ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
            }
            catch (Exception e)
            {
                GlobFuncs.SaveErr(e);
            }
        }

    }

}
