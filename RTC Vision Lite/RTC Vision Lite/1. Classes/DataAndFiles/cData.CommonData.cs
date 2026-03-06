using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public static class CommonData
    {
        private static  object locktb = new object();

        private static DataTable _ActionList = null;

        private static DataTable _PropertyDescript = null;

        public static DataTable PropertyDescript
        {
            get
            {
                if (_PropertyDescript == null)
                {
                    _PropertyDescript = Lib.GetDataTable("SELECT * FROM PropertyDescript", GlobVar.RTCVision.Files.Common);
                    if (_PropertyDescript != null)
                    {
                        var keys = new DataColumn[1];
                        keys[0] = _PropertyDescript.Columns[cColName.PropertyName];
                        _PropertyDescript.PrimaryKey = keys;
                    }
                }
                return _PropertyDescript;
            }
            set { _PropertyDescript = value; }
        }
        public static bool ExecuteQuery(string sqlString)
        {
            return Lib.ExecuteQuery(sqlString, GlobVar.RTCVision.Files.Common);
        }
        public static DataTable ActionList
        {
            get
            {
                if (_ActionList == null)
                {
                    lock (locktb)
                    {
                        _ActionList = Lib.GetDataTable("SELECT * FROM ActionList ORDER BY GroupName, ActionName", GlobVar.RTCVision.Files.Common);
                    }
                    if (_ActionList != null)
                    {
                        var keys = new DataColumn[1];
                        keys[0] = _ActionList.Columns[cColName.ActionName];
                        _ActionList.PrimaryKey = keys;
                    }
                }
                return _ActionList;
            }
            set => _ActionList = value;
        }
        public static string GetActionCaption(string actionName, string defaultValue = "")
        {
            string Result = defaultValue;

            if (ActionList == null)
                return Result;
            if (ActionList.Rows.Find(actionName) != null)
                Result = ActionList.Rows.Find(actionName)[cColName.ActionCaption].ToString();
            return Result;
        }

        public static string GetPropertyDescription(string propertyName)
        {
            string Result = string.Empty;

            if (PropertyDescript == null)
            {
                return Result;
            }

            if (PropertyDescript.Rows.Find(propertyName) != null)
            {
                if (GlobVar.RTCVision.Language == ELanguage.Eng)
                {
                    Result = PropertyDescript.Rows.Find(propertyName)[cColName.DescriptionE].ToString();
                }
                else
                {
                    Result = PropertyDescript.Rows.Find(propertyName)[cColName.DescriptionV].ToString();
                }
            }
            return Result;
        }
        public static string GetPropertyValues(string propertyName)
        {
            string Result = string.Empty;
            if (PropertyValues == null)
            {
                return Result;
            }
            if (PropertyValues.Rows.Find(propertyName) != null)
            {
                Result = PropertyValues.Rows.Find(propertyName)[cColName.Value].ToString();
            }
            return Result;

        }
        internal static string[] GetVstModelList()
        {
            List<string> result = new List<string>();
            DataTable vstTable =
                Lib.GetDataTable($"SELECT * FROM {cTableName_Common.VSTModels} ORDER BY {cColName.STT}", GlobVar.RTCVision.Files.Common);
            if (vstTable != null && vstTable.Rows.Count > 0)
                foreach (DataRow row in vstTable.Rows)
                    result.Add(GlobFuncs.Object2Str(row[cColName.Name]));
            return result.ToArray();
        }
        public static int GetDefaultValues_Int(string propertyName)
        {
            int Result = 0;
            if (PropertyValues == null)
            {
                return Result;
            }
            if (PropertyValues.Rows.Find(propertyName) != null)
            {
                if (!int.TryParse(PropertyValues.Rows.Find(propertyName)[cColName.DefaultI].ToString(), out Result))
                    Result = 0;
            }
            return Result;
        }
        public static string GetDefaultValues_Text(string propertyName)
        {
            string Result = string.Empty;
            lock (locktb)
            {
                if (PropertyValues == null)
                    return Result;
                if (PropertyValues.Rows.Find(propertyName) != null)
                {
                    Result = PropertyValues.Rows.Find(propertyName)[cColName.DefaultT].ToString();
                }
            }
            return Result;
        }
        public static double GetDefaultValues_Double(string propertyName)
        {
            double Result = 0;
            lock (locktb)
            {
                if (PropertyValues == null)
                {
                    return Result;
                }
                if (PropertyValues.Rows.Find(propertyName) != null)
                {
                    if (!double.TryParse(_PropertyValues.Rows.Find(propertyName)[cColName.DefaultD].ToString(), out Result))
                    {
                        Result = 0;
                    }
                }
            }
            return Result;
        }
        public static List<ShapeListItem> GetDefaultValues_ShapeList(string propertyName)
        {
            List<ShapeListItem> Result = new List<ShapeListItem>();
            lock(locktb)
            { 
                if (PropertyValues == null)
                {
                    return Result;
                }

                if (PropertyValues.Rows.Find(propertyName) != null)
                {
                    string DefaultT = PropertyValues.Rows.Find(propertyName)["DefaultH"].ToString();
                    string[] DefaultTs = DefaultT.Split(',');
                    int i = 0;
                    for (; i < DefaultT.Length; i++)
                    {
                        if (DefaultTs[i] == string.Empty) continue;
                        //if (int.TryParse(item, out int i))
                        //{
                        //    Result.Append(i);
                        //}
                        //else if (double.TryParse(item, out double d))
                        //{
                        //    Result.Append(d);
                        //}
                        //else
                        //{
                        //    Result.Append(item);
                        //}
                    }

                }
            }
            return Result;
        }
        public static bool GetDefaultValues_Bool(string propertyName)
        {
            bool Result = false;
            lock (locktb)
            {
                if (PropertyValues == null)
                {
                    return Result;
                }
                if (PropertyValues.Rows.Find(propertyName) != null)
                {
                    Result = bool.Parse(PropertyValues.Rows.Find(propertyName)[cColName.DefaultT].ToString());
                }
            }
            return Result;
        }
        public static List<double> GetDefaultValues_ListDouble(string propertyName)
        {

            List<double> Result = new List<double> { };
            lock (locktb)
            {
                if (PropertyValues == null)
                {
                    return Result;
                }
                if (PropertyValues.Rows.Find(propertyName) != null)
                {
                    string DefaultT = PropertyValues.Rows.Find(propertyName)["DefaultH"].ToString();
                    string[] DefaultTs = DefaultT.Split(',');
                    foreach (string item in DefaultTs)
                    {
                        if (item == string.Empty) continue;
                        if (int.TryParse(item, out int i))
                        {
                            Result.Add(i);
                        }
                        else if (double.TryParse(item, out double d))
                        {
                            Result.Add(d);
                        }
                        else
                        {
                            Result.Add(0);
                        }


                    }
                }
            }
            return Result;
        }
        //internal static List<ShapeListItem> GetDefaultValues_ShapeList(string propertyName)
        //{
        //    List<ShapeListItem> Result = new List<ShapeListItem>();
        //    if (PropertyValues == null)
        //    {
        //        return Result;
        //    }
        //    if (PropertyValues.Rows.Find(propertyName) != null)
        //    {
        //        string DefaulT = PropertyValues.Rows.Find(propertyName)["DefaultH"].ToString();
        //        string[] Defaults = DefaulT.Split(',');
        //        for(int i = 0; i <= Defaults.Length; i = i +10)
        //        {
        //            ShapeListItem NewShape = new ShapeListItem();
        //            NewShape.
        //           // Result.Add()
        //        }    
        //    }    
        //}
        public static List<object> GetDefaultValues_ListObject(string propertyName)
        {
            List<Object> Result = new List<Object> { };
            lock (locktb)
            {
                if (PropertyValues == null)
                {
                    return Result;
                }
                if (PropertyValues.Rows.Find(propertyName) != null)
                {
                    string DefaultT = PropertyValues.Rows.Find(propertyName)["DefaultH"].ToString();
                    string[] DefaultTs = DefaultT.Split(',');
                    foreach (string item in DefaultTs)
                    {
                        if (item == string.Empty) continue;
                        if (int.TryParse(item, out int i))
                        {
                            Result.Add(i);
                        }
                        else if (double.TryParse(item, out double d))
                        {
                            Result.Add(d);
                        }
                        else
                        {
                            Result.Add(item);
                        }
                    }
                }
            }
            return Result;
        }
        //public static List<ShapeListItem> GetDefaultValues_ShapeList(string propertyName)
        //{
        //   List<ShapeListItem> Result = new List<ShapeListItem>{ };
        //    if (PropertyValues == null)
        //    {
        //        return Result;
        //    }
        //    if (PropertyValues.Rows.Find(propertyName) != null)
        //    {
        //        string DefaultT = PropertyValues.Rows.Find(propertyName)["DefaultH"].ToString();
        //        string[] DefaultTs = DefaultT.Split(',');
        //        foreach (string item in DefaultTs)
        //        {
        //            //Result.Add(item);
        //        }


        //    }
        //    return Result;
        //}
        public static List<string> GetDefaultValues_ListString(string propertyName)
        {

            List<string> Result = new List<string> { };
            lock(locktb)
                {
                if (PropertyValues == null)
                {
                    return Result;
                }
                if (PropertyValues.Rows.Find(propertyName) != null)
                {
                    string DefaultT = PropertyValues.Rows.Find(propertyName)["DefaultH"].ToString();
                    string[] DefaultTs = DefaultT.Split(',');
                    foreach (string item in DefaultTs)
                    {
                        Result.Add(item);
                    }
                }
            }
            return Result;
        }
        private static DataTable _PropertyValues = null;

        public static DataTable PropertyValues
        {
            get
            {
                lock (locktb)
                {
                    if (_PropertyValues == null)
                    {
                        lock (locktb)
                        {
                            _PropertyValues = Lib.GetDataTable("SELECT * FROM PropertyValues", GlobVar.RTCVision.Files.Common);
                            if (_PropertyValues != null)
                            {
                                var keys = new DataColumn[1];
                                keys[0] = _PropertyValues.Columns[cColName.PropertyName];
                                _PropertyValues.PrimaryKey = keys;
                            }
                        }
                    }
                    return _PropertyValues;
                }

            }
            set { _PropertyValues = value; }
        }

        private static DataTable _actionGroupList = null;

        public static DataTable ActionGroupList
        {
            get
            {
                _actionGroupList = Lib.GetDataTable("SELECT * FROM ActionGroupList ORDER BY STT", GlobVar.RTCVision.Files.Common);

                return _actionGroupList;
            }
            set => _actionGroupList = value;
        }
        private static DataTable _propertyRef = null;
        public static DataTable PropertyRef
        {
            get
            {

                if (_propertyRef == null)
                    _propertyRef = Lib.GetDataTable("Select * FROM PropertyRef", GlobVar.RTCVision.Files.Common);
                return _propertyRef;
            }
            set => _propertyRef = value;
        }
        public static DataRow[] GetReferenceProperties(string actionName, string propertyName, string propertyValue)
        {
            DataRow[] result = new DataRow[] { };
            lock (locktb)
            {
                if (PropertyRef != null)
                {
                    try
                    {
                        var resultPri = PropertyRef.Select(cColName.ActionName + "='" + actionName
                                                         + "' AND " + cColName.PrimaryPropFlag + "='" + propertyName
                                                         + "' AND " + cColName.PrimaryPropFlagValue + " LIKE '%" + propertyValue + "%'");
                        var resultSec = PropertyRef.Select(cColName.ActionName + "='" + actionName
                                                           + "' AND " + cColName.SecondaryPropFlag + "='" + propertyName
                                                           + "' AND " + cColName.SecondaryPropFlagValue + " LIKE '%" + propertyValue + "%'");
                        var resultGet = PropertyRef.Select(cColName.ActionName + "='" + actionName
                                                           + "' AND " + cColName.PropGetValue + " LIKE '%" + propertyValue + "%'");

                        result = result.Concat(resultPri).Concat(resultSec).Concat(resultGet).ToArray();

                    }
                    catch (Exception ex)
                    {
                        result = new DataRow[] { };
                    }
                }
            } 
            return result;
        }
        public static DataRow GetReferenceProperty(string actionName, string propertyName, string propertyValue)
        {
            DataRow[] result = new DataRow[] { };
            if (PropertyRef != null)
            {
                try
                {
                    result = PropertyRef.Select(cColName.ActionName + "='" + actionName
                                                + "' AND " + cColName.PrimaryPropFlag + "='" + propertyName
                                                + "' AND " + cColName.PrimaryPropFlagValue + " = '" + propertyValue + "'");
                }
                catch
                {
                    result = new DataRow[] { };
                }
            }
            return result.Length > 0 ? result[0] : null;
        }
        public static Font GetFontStyle(string fontStyleName)
        {
            DataTable dataTable =
                Lib.GetDataTable(
                    $"SELECT {cColName.Font} FROM {cTableName_Common.ViewStyles} WHERE {cColName.CaptionEng} = '{fontStyleName}'",
                    GlobVar.RTCVision.Files.Common);
            if (dataTable != null && dataTable.Rows.Count > 0)
                return GlobFuncs.StrngtoFont(GlobFuncs.GetDataRowValue_String(dataTable.Rows[0], cColName.Font));
            else
                return GlobVar.DefaultFont;
        }
        private static DataTable _viewStyle = null;
        public static DataTable ViewStyles
        {
            get
            {
                _viewStyle =
                    Lib.GetDataTable($"SELECT * FROM {cTableName_Common.ViewStyles} ORDER BY {cColName.STT}",
                    GlobVar.RTCVision.Files.Common);
                return _viewStyle;
            }
            set => _viewStyle = value;
        }
        private static DataTable _ASCIITable = null;
        /// <summary>
        /// Bảng chứa chú thích của property
        /// </summary>
        public static DataTable ASCIITable
        {
            get
            {
                if (_ASCIITable == null)
                {
                    _ASCIITable = Lib.GetDataTable("SELECT * FROM ASCIITable ORDER BY OrderNum", GlobVar.RTCVision.Files.Common);
                    if (_ASCIITable != null)
                    {
                        var keys = new DataColumn[1];
                        keys[0] = _ASCIITable.Columns[cColName.HEX];
                        _ASCIITable.PrimaryKey = keys;
                    }
                }
                return _ASCIITable;
            }
            set { _ASCIITable = value; }

        }
    }
}