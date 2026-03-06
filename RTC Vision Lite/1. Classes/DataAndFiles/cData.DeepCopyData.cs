using RTCConst;
using RTCEnums;
using RTC_Vision_Lite.PublicFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using RTC_Vision_Lite.Classes;

namespace RTC_Vision_Lite.Classes
{
    public static class DeepCopyData
    {
        public static string DataFileName = string.Empty;
        public static cSQLite MyConn = null;
        #region "PROPERTY"

        private static DataTable _ActionList = null;
        /// <summary>
        /// Bảng ActionList
        /// </summary>
        public static DataTable ActionList
        {
            get
            {
                if (_ActionList == null) _ActionList = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ActionList);

                if (_ActionList != null)
                {
                    _ActionList.TableName = cTableName_SaveTemplate.ActionList;
                    _ActionList.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _ActionList.Columns[cColName.ID];
                    _ActionList.PrimaryKey = keys;
                }
                return _ActionList;
            }
            set { _ActionList = value; }
        }

        private static DataTable _ActionSettings = null;
        /// <summary>
        /// Bảng ActionSettings
        /// </summary>
        public static DataTable ActionSettings
        {
            get
            {
                if (_ActionSettings == null) _ActionSettings = MyConn.GetDataTable("SELECT TOP 1 FROM " + cTableName_SaveTemplate.ActionSettings);

                if (_ActionSettings != null)
                {
                    _ActionSettings.TableName = cTableName_SaveTemplate.ActionSettings;
                    _ActionSettings.Columns[cColName.ActionID].Caption = cColName.KEY;
                    _ActionSettings.Columns[cColName.PropName].Caption = cColName.KEY;
                    var keys = new DataColumn[2];
                    keys[0] = _ActionSettings.Columns[cColName.ActionID];
                    keys[1] = _ActionSettings.Columns[cColName.PropName];
                    _ActionSettings.PrimaryKey = keys;
                }
                return _ActionSettings;
            }
            set { _ActionSettings = value; }
        }
        private static DataTable _CameraSettings = null;
        /// <summary>
        /// Bảng CameraSettings
        /// </summary>
        public static DataTable CameraSettings
        {
            get
            {
                if (_CameraSettings == null) _CameraSettings = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.CameraSettings);

                if (_CameraSettings != null)
                {
                    _CameraSettings.TableName = cTableName_SaveTemplate.CameraSettings;
                    _CameraSettings.Columns[cColName.GroupID].Caption = cColName.KEY;
                    _CameraSettings.Columns[cColName.PropName].Caption = cColName.KEY;
                    var keys = new DataColumn[2];
                    keys[0] = _CameraSettings.Columns[cColName.GroupID];
                    keys[1] = _CameraSettings.Columns[cColName.PropName];
                    _CameraSettings.PrimaryKey = keys;
                }
                return _CameraSettings;
            }
            set { _CameraSettings = value; }
        }
        private static DataTable _ComputerSettings = null;
        /// <summary>
        /// Bảng ComputerSettings
        /// </summary>
        public static DataTable ComputerSettings
        {
            get
            {
                if (_ComputerSettings == null) _ComputerSettings = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ComputerSettings);

                if (_ComputerSettings != null)
                {
                    _ComputerSettings.TableName = cTableName_SaveTemplate.ComputerSettings;
                    _ComputerSettings.Columns[cColName.GroupID].Caption = cColName.KEY;
                    _ComputerSettings.Columns[cColName.PropName].Caption = cColName.KEY;
                    var keys = new DataColumn[2];
                    keys[0] = _ComputerSettings.Columns[cColName.GroupID];
                    keys[1] = _ComputerSettings.Columns[cColName.PropName];
                    _ComputerSettings.PrimaryKey = keys;
                }
                return _ComputerSettings;
            }
            set { _ComputerSettings = value; }
        }
        private static DataTable _GroupList = null;
        /// <summary>
        /// Bảng GroupList
        /// </summary>
        public static DataTable GroupList
        {
            get
            {
                if (_GroupList == null) _GroupList = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.GroupList);

                if (_GroupList != null)
                {
                    if (!_GroupList.Columns.Contains(cColName.CurrentPart_R1))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.GroupList, cColName.CurrentPart_R1, "INT");
                        _GroupList.Columns.Add(cColName.CurrentPart_R1, typeof(int));
                    }
                    if (!_GroupList.Columns.Contains(cColName.CurrentPart_R2))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.GroupList, cColName.CurrentPart_R2, "INT");
                        _GroupList.Columns.Add(cColName.CurrentPart_R2, typeof(int));
                    }
                    if (!_GroupList.Columns.Contains(cColName.CurrentPart_C1))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.GroupList, cColName.CurrentPart_C1, "INT");
                        _GroupList.Columns.Add(cColName.CurrentPart_C1, typeof(int));
                    }
                    if (!_GroupList.Columns.Contains(cColName.CurrentPart_C2))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.GroupList, cColName.CurrentPart_C2, "INT");
                        _GroupList.Columns.Add(cColName.CurrentPart_C2, typeof(int));
                    }
                    if (!_GroupList.Columns.Contains(cColName.EnableSnap))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.GroupList, cColName.EnableSnap, "TEXT");
                        _GroupList.Columns.Add(cColName.EnableSnap, typeof(string));
                    }
                    if (!_GroupList.Columns.Contains(cColName.MasterImage))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.GroupList, cColName.MasterImage, "TEXT");
                        _GroupList.Columns.Add(cColName.MasterImage, typeof(string));
                    }
                    if (!_GroupList.Columns.Contains(cColName.DefaultImageSourceType))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.GroupList, cColName.DefaultImageSourceType, "INT");
                        MyConn.ExecuteQuery(
                            $"UPDATE {cTableName_SaveTemplate.GroupList} SET {cColName.DefaultImageSourceType} = 999");
                        _GroupList.Columns.Add(cColName.DefaultImageSourceType, typeof(int));
                        foreach (DataRow row in _GroupList.Rows)
                            row[cColName.DefaultImageSourceType] = (int)EImageSourceTypes.None;
                    }
                    _GroupList.TableName = cTableName_SaveTemplate.GroupList;
                    _GroupList.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _GroupList.Columns[cColName.ID];
                    _GroupList.PrimaryKey = keys;
                }
                return _GroupList;
            }
            set { _GroupList = value; }
        }
        private static DataTable _ROIs = null;
        /// <summary>
        /// Bảng ROIs
        /// </summary>
        public static DataTable ROIs
        {
            get
            {
                if (_ROIs == null) _ROIs = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ROIs);

                if (_ROIs != null)
                {
                    if (!_ROIs.Columns.Contains(cColName.IsDisplayOutput))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.ROIs, cColName.IsDisplayOutput, "TEXT");
                        _ROIs.Columns.Add(cColName.IsDisplayOutput, typeof(string));
                    }
                    _ROIs.TableName = cTableName_SaveTemplate.ROIs;
                }
                return _ROIs;
            }
            set { _ROIs = value; }
        }
        private static DataTable _FindROIs = null;
        /// <summary>
        /// Bảng FindROIs
        /// </summary>
        public static DataTable FindROIs
        {
            get
            {
                if (_FindROIs == null) _FindROIs = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.FindROIs);

                if (_FindROIs != null)
                {
                    if (!_FindROIs.Columns.Contains(cColName.IsDisplayOutput))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.FindROIs, cColName.IsDisplayOutput, "TEXT");
                        _FindROIs.Columns.Add(cColName.IsDisplayOutput, typeof(string));
                    }
                    _FindROIs.TableName = cTableName_SaveTemplate.FindROIs;
                }

                return _FindROIs;
            }
            set { _FindROIs = value; }
        }
        private static DataTable _LinkProperty = null;
        /// <summary>
        /// Bảng ROIs
        /// </summary>
        public static DataTable LinkProperty
        {
            get
            {
                if (!MyConn.IsTableExists(cTableName_SaveTemplate.LinkProperty))
                {
                    MyConn.ExecuteQuery("CREATE TABLE 'LinkProperty' (" +
                                        "'ActionID'  TEXT," +
                                        "'ID'    TEXT," +
                                        "'OrderNum'  INTEGER," +
                                        "'SourceCamID'   TEXT," +
                                        "'SourceID'  TEXT," +
                                        "'SourceName'    TEXT," +
                                        "'SourceIndex'   TEXT," +
                                        "'TargetCamID'   TEXT," +
                                        "'TargetID'  TEXT," +
                                        "'TargetName'    TEXT," +
                                        "'TargetIndex'   TEXT)");

                }

                if (_LinkProperty == null)
                    _LinkProperty = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.LinkProperty + " ORDER BY ActionID, OrderNum");
                if (_LinkProperty != null)
                    _LinkProperty.TableName = cTableName_SaveTemplate.LinkProperty;
                return _LinkProperty;
            }
            set { _LinkProperty = value; }
        }
        private static DataTable _ColumnList = null;
        /// <summary>
        /// Bảng ROIs
        /// </summary>
        public static DataTable ColumnList
        {
            get
            {
                if (!MyConn.IsTableExists(cTableName_SaveTemplate.ColumnList))
                {
                    MyConn.ExecuteQuery("CREATE TABLE 'ColumnList' (" +
                                        "'ActionID'  TEXT," +
                                        "'ID'    TEXT," +
                                        "'OrderNum'  INTEGER," +
                                        "'Active'  TEXT," +
                                        "'Name'   TEXT," +
                                        "'DataType'  TEXT," +
                                        "'Format'    TEXT," +
                                        "'DisplayFormat'   TEXT," +
                                        "'Value'   TEXT," +
                                        "'RefID'  TEXT," +
                                        "'PropName'    TEXT," +
                                        "'Ref'   TEXT)");
                }

                if (_ColumnList == null)
                    _ColumnList = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ColumnList + " ORDER BY ActionID, OrderNum");
                if (_ColumnList != null)
                    _ColumnList.TableName = cTableName_SaveTemplate.ColumnList;
                return _ColumnList;
            }
            set { _ColumnList = value; }
        }
        private static DataTable _ROIProperties = null;
        /// <summary>
        /// Bảng FindROIs
        /// </summary>
        public static DataTable ROIProperties
        {
            get
            {
                if (_ROIProperties == null) _ROIProperties = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ROIProperties);

                if (_ROIProperties != null)
                {
                    _ROIProperties.TableName = cTableName_SaveTemplate.ROIProperties;
                    _ROIProperties.Columns[cColName.ID].Caption = cColName.KEY;
                    _ROIProperties.Columns[cColName.PropName].Caption = cColName.KEY;
                    var keys = new DataColumn[2];
                    keys[0] = _ROIProperties.Columns[cColName.ID];
                    keys[1] = _ROIProperties.Columns[cColName.PropName];
                    _ROIProperties.PrimaryKey = keys;
                }
                return _ROIProperties;
            }
            set { _ROIProperties = value; }
        }
        private static DataTable _Trigger = null;
        /// <summary>
        /// Bảng chứa thông số Trigger
        /// </summary>
        public static DataTable Trigger
        {
            get
            {
                if (_Trigger == null) _Trigger = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.Trigger);

                if (_Trigger != null)
                {
                    _Trigger.TableName = cTableName_SaveTemplate.Trigger;
                    _Trigger.Columns[cColName.GroupID].Namespace = cColName.KEY;

                    var keys = new DataColumn[1];
                    keys[0] = _Trigger.Columns[cColName.GroupID];
                    _Trigger.PrimaryKey = keys;
                }
                return _Trigger;
            }
            set { _Trigger = value; }
        }
        private static DataTable _SourceImages = null;
        /// <summary>
        /// Bảng FindROIs
        /// </summary>
        public static DataTable SourceImages
        {
            get
            {
                if (_SourceImages == null) _SourceImages = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.SourceImages + " ORDER BY STT");

                if (_SourceImages != null)
                    _SourceImages.TableName = cTableName_SaveTemplate.SourceImages;
                return _SourceImages;
            }
            set { _SourceImages = value; }
        }
        private static DataTable _LinkPassFail = null;
        /// <summary>
        /// Bảng FindROIs
        /// </summary>
        public static DataTable LinkPassFail
        {
            get
            {
                if (_LinkPassFail == null) _LinkPassFail = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.LinkPassFail + " ORDER BY STT");

                if (_LinkPassFail != null)
                    _LinkPassFail.TableName = cTableName_SaveTemplate.LinkPassFail;
                return _LinkPassFail;
            }
            set { _LinkPassFail = value; }
        }
        private static DataTable _StringBuilderItems = null;
        /// <summary>
        /// Bảng chứa danh sách các dòng string cần nối để truyền thông
        /// </summary>
        public static DataTable StringBuilderItems
        {
            get
            {
                if (_StringBuilderItems == null) _StringBuilderItems = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.StringBuilderItems + " ORDER BY ActionID, OrderNum");

                if (_StringBuilderItems != null)
                {
                    if (!_StringBuilderItems.Columns.Contains(cColName.IsCanReset))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.StringBuilderItems, cColName.IsCanReset, "TEXT");
                        _StringBuilderItems.Columns.Add(cColName.IsCanReset, typeof(string));
                        foreach (DataRow row in _StringBuilderItems.Rows)
                            row[cColName.IsCanReset] = bool.FalseString.ToLower();
                    }
                    if (!_StringBuilderItems.Columns.Contains(cColName.IsParent))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.StringBuilderItems, cColName.IsParent, "TEXT");
                        _StringBuilderItems.Columns.Add(cColName.IsParent, typeof(string));
                        foreach (DataRow row in _StringBuilderItems.Rows)
                            row[cColName.IsParent] = bool.FalseString.ToLower();
                    }
                    _StringBuilderItems.TableName = cTableName_SaveTemplate.StringBuilderItems;
                    var keys = new DataColumn[2];
                    keys[0] = _Trigger.Columns[cColName.ActionID];
                    keys[1] = _Trigger.Columns[cColName.OrderNum];
                    _StringBuilderItems.PrimaryKey = keys;
                }
                return _StringBuilderItems;
            }
            set { _StringBuilderItems = value; }
        }
        #endregion
        #region "FUNCTIONS"        
        private static void SetAllTableIsNull()
        {
            ROIs = null;
            FindROIs = null;
            ActionList = null;
            ActionSettings = null;
            CameraSettings = null;
            ComputerSettings = null;
            GroupList = null;
            SourceImages = null;
            LinkPassFail = null;
            ROIProperties = null;
            Trigger = null;
        }
        private static void SetNullValueToDataRow(DataRow _Row)
        {
            foreach (DataColumn item in _Row.Table.Columns)
            {
                _Row[item] = DBNull.Value;
            }
        }
        public static bool Connect(string _DataFileName)
        {
            DataFileName = _DataFileName;
            MyConn = new cSQLite(DataFileName);
            SetAllTableIsNull();
            return MyConn.Connect();
        }
        /// <summary>
        /// Hàm connect (gán file name data trước khi connect)
        /// </summary>
        /// <returns></returns>
        public static bool Connect()
        {
            if (DataFileName == string.Empty || !File.Exists(DataFileName))
            {
                return false;
            }
            MyConn = new cSQLite(DataFileName);
            SetAllTableIsNull();
            return MyConn.Connect();
        }
        public static void Disconnect()
        {
            if (MyConn != null && MyConn.IsConnected)
            {
                MyConn.Close();
            }
            MyConn = null;
            SetAllTableIsNull();
        }
        #region "FUNCTIONS SAVE DATA"
        public static bool ClearAllData()
        {
            try
            {
                if (!MyConn.Connect())
                    return false;

                bool Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ActionList);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ActionSettings);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.CameraSettings);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ComputerSettings);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.CAMList);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.GroupList);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ProjectList);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ProjectSetting);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.SourceImages);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ROIs);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.FindROIs);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.LinkPassFail);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.Trigger);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ROIProperties);
                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool SaveGroup(cGroupActions _Group)
        {
            try
            {
                if (GroupList == null)
                    return false;

                DataRow r = GroupList.NewRow();
                r[cColName.ID] = _Group.ID;
                r[cColName.Name] = _Group.Name.rtcValue;
                r[cColName.IDMainAction] = _Group.IDMainAction;
                r[cColName.STT] = _Group.STT;
                r[cColName.ImageSourceType] = _Group.SourceImageSettings.ImageSourceType;
                r[cColName.DefaultImageSourceType] = _Group.SourceImageSettings.DefaultImageSourceType;
                r[cColName.MasterImage] = _Group.SourceImageSettings.MasterImage;
                r[cColName.RunCount] = _Group.RunCount;
                r[cColName.PassCount] = _Group.PassCount;
                r[cColName.FailCount] = _Group.FailCount;
                r[cColName.EnableSnap] = _Group.SourceImageSettings.IsEnableSnap.ToString().ToLower();

                GroupList.Rows.Add(r);
                return true;
                //return MyConn.AddRow(r);
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        //public static bool SaveGroup_ComputerSettings_Images(cGroupActions groupActions)
        //{

        //}
        public static bool SaveGroup_ComputerSettings(cGroupActions _Group)
        {
            try
            {
                if (ComputerSettings == null)
                    return false;
                bool Result = false;

                PropertyInfo[] pComputerSettings = _Group.SourceImageSettings.ComputerSettings.GetType().GetProperties();
                foreach (PropertyInfo item in pComputerSettings)
                {
                    Result = false;
                    DataRow r = _ComputerSettings.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.GroupID] = _Group.ID;
                    r[cColName.PropName] = item.Name;

                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            r[cColName.ValueT] = item.GetValue(_Group.SourceImageSettings.ComputerSettings, null).ToString();
                            break;
                        case "Boolean":
                            r[cColName.ValueT] = item.GetValue(_Group.SourceImageSettings.ComputerSettings, null).ToString().ToLower();
                            break;
                        case "Int32":
                            r[cColName.ValueI] = (int)item.GetValue(_Group.SourceImageSettings.ComputerSettings, null);
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                List<string> obj = (List<string>)item.GetValue(_Group.SourceImageSettings.ComputerSettings, null);
                                r[cColName.ValueT] = string.Join(",", obj.ToArray());
                            }
                            break;
                        default:
                            continue;
                    }
                    _ComputerSettings.Rows.Add(r);
                    Result = true;
                    //Result = MyConn.AddRow(r);
                    //if (!Result) break;
                }

                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool SaveGroup_CameraSettings(cGroupActions _Group)
        {
            try
            {
                if (CameraSettings == null)
                    return false;
                bool Result = false;

                PropertyInfo[] pCameraSettings = _Group.SourceImageSettings.CameraSettings.GetType().GetProperties();
                foreach (PropertyInfo item in pCameraSettings)
                {
                    Result = false;
                    DataRow r = _CameraSettings.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.GroupID] = _Group.ID;
                    r[cColName.PropName] = item.Name;

                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            r[cColName.ValueT] = item.GetValue(_Group.SourceImageSettings.CameraSettings, null).ToString();
                            break;
                        case "Boolean":
                            r[cColName.ValueT] = item.GetValue(_Group.SourceImageSettings.CameraSettings, null).ToString().ToLower();
                            break;
                        case "Int32":
                            r[cColName.ValueI] = (int)item.GetValue(_Group.SourceImageSettings.CameraSettings, null);
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                List<string> obj = (List<string>)item.GetValue(_Group.SourceImageSettings.CameraSettings, null);
                                r[cColName.ValueT] = string.Join(",", obj.ToArray());
                            }
                            break;
                        default:
                            continue;
                    }
                    _CameraSettings.Rows.Add(r);
                    Result = true;
                }

                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool SaveGroup_SourceImages(cGroupActions _Group)
        {
            try
            {
                if (SourceImages == null)
                    return false;

                List<cImage> _Images = null;
                switch (_Group.SourceImageSettings.ImageSourceType)
                {
                    case EImageSourceTypes.Computer:
                        _Images = _Group.SourceImageSettings.ComputerSettings.Images;
                        break;
                    case EImageSourceTypes.Camera:
                        _Images = _Group.SourceImageSettings.CameraSettings.Images;
                        break;
                    default:
                        break;
                }

                if (_Images == null || _Images.Count <= 0)
                    return true;
                bool Result = false;
                int STT = 1;
                foreach (cImage _Image in _Images)
                {
                    Result = false;
                    DataRow r = _SourceImages.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.STT] = STT;
                    r[cColName.FileName] = _Image.FileName;
                    r[cColName.Passed] = _Image.Passed;
                    r[cColName.Ran] = _Image.Ran;
                    _SourceImages.Rows.Add(r);
                    Result = true;
                }

                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool SaveGroup_Trigger(cGroupActions _Group)
        {
            try
            {
                if (Trigger == null)
                    return false;

                DataRow r = _Trigger.NewRow();
                SetNullValueToDataRow(r);
                r[cColName.GroupID] = _Group.ID;
                r[cColName.TriggerMode] = _Group.SourceImageSettings.Trigger.TriggerMode;
                r[cColName.TriggerType] = _Group.SourceImageSettings.Trigger.TriggerType;
                r[cColName.COMName] = _Group.SourceImageSettings.Trigger.COMName;
                r[cColName.IP] = _Group.SourceImageSettings.Trigger.IP;
                r[cColName.Port] = _Group.SourceImageSettings.Trigger.Port;
                r[cColName.TriggerValue] = _Group.SourceImageSettings.Trigger.TriggerValue;

                Trigger.Rows.Add(r);
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        /// <summary>
        /// Lưu thông tin ROIs vào bảng tạm để chuyển đổi
        /// </summary>
        /// <param name="_Action">Action cần chuyển</param>
        /// <returns></returns>
        public static bool SaveActionROIs(cAction _Action)
        {
            if (ROIs == null)
                return false;
            if (_Action.ROIs == null) return true;

            foreach (object item in _Action.ROIs.Values)
            {
                DataRow r = _ROIs.NewRow();
                cDrawingBaseType ROI = (cDrawingBaseType)item;
                r[cColName.ID] = ROI.ID;
                r[cColName.ActionID] = _Action.ID;
                r[cColName.X] = ROI.Center.Col;
                r[cColName.Y] = ROI.Center.Row;
                r[cColName.Z] = ROI.Center.Z;
                r[cColName.DrawingType] = ROI.DrawingType;
                r[cColName.ConnectType] = ROI.ConnectType;
                r[cColName.AnimationType] = ROI.AnimationType;
                r[cColName.IsDisplayOutput] = ROI.IsDisplayOutPut.ToString().ToLower();
                r[cColName.RoiType] = ROI.RoiType;
                r[cColName.RoiLegend] = ROI.RoiLegend;
                switch (ROI.DrawingType)
                {
                    case EDrawingtypes.Rectang:
                        r[cColName.Phi] = ((cRectangType)item).Phi;
                        r[cColName.Length1] = ((cRectangType)item).Width;
                        r[cColName.Length2] = ((cRectangType)item).Height;
                        break;
                    case EDrawingtypes.Rectang1:
                        r[cColName.Phi] = ((cRectangType)item).Phi;
                        r[cColName.Length1] = ((cRectangType)item).Width;
                        r[cColName.Length2] = ((cRectangType)item).Height;
                        break;
                    case EDrawingtypes.Ellipse:
                        r[cColName.Phi] = ((cEllipseType)item).Phi;
                        r[cColName.Length1] = ((cEllipseType)item).Radius1;
                        r[cColName.Length2] = ((cEllipseType)item).Radius2;
                        break;
                    case EDrawingtypes.Line:
                        break;
                    case EDrawingtypes.Polygon:
                        break;
                    case EDrawingtypes.none:
                        break;
                    default:
                        break;
                }
                ROIs.Rows.Add(r);
            }
            return true;
        }
        /// <summary>
        /// Lưu thông tin FindROIs vào bảng tạm để chuyển đổi
        /// </summary>
        /// <param name="_Action">Action cần chuyển</param>
        /// <returns></returns>
        public static bool SaveActionFindROIs(cAction _Action)
        {
            if (FindROIs == null)
                return false;
            if (_Action.FindROIs == null) return true;
            foreach (object item in _Action.FindROIs.Values)
            {
                DataRow r = FindROIs.NewRow();
                cDrawingBaseType ROI = (cDrawingBaseType)item;
                r[cColName.ID] = ROI.ID;
                r[cColName.ActionID] = _Action.ID;
                r[cColName.X] = ROI.Center.Col;
                r[cColName.Y] = ROI.Center.Row;
                r[cColName.Z] = ROI.Center.Z;
                r[cColName.DrawingType] = ROI.DrawingType;
                r[cColName.ConnectType] = ROI.ConnectType;
                r[cColName.AnimationType] = ROI.AnimationType;
                r[cColName.IsDisplayOutput] = ROI.IsDisplayOutPut.ToString().ToLower();
                r[cColName.RoiType] = ROI.RoiType;
                r[cColName.RoiLegend] = ROI.RoiLegend;
                switch (ROI.DrawingType)
                {
                    case EDrawingtypes.Rectang:
                        r[cColName.Phi] = ((cRectangType)item).Phi;
                        r[cColName.Length1] = ((cRectangType)item).Width;
                        r[cColName.Length2] = ((cRectangType)item).Height;
                        break;
                    case EDrawingtypes.Rectang1:
                        r[cColName.Phi] = ((cRectangType)item).Phi;
                        r[cColName.Length1] = ((cRectangType)item).Width;
                        r[cColName.Length2] = ((cRectangType)item).Height;
                        break;
                    case EDrawingtypes.Ellipse:
                        r[cColName.Phi] = ((cEllipseType)item).Phi;
                        r[cColName.Length1] = ((cEllipseType)item).Radius1;
                        r[cColName.Length2] = ((cEllipseType)item).Radius2;
                        break;
                    case EDrawingtypes.Line:
                        break;
                    case EDrawingtypes.Polygon:
                        break;
                    case EDrawingtypes.none:
                        break;
                    default:
                        break;
                }
                FindROIs.Rows.Add(r);
            }
            return true;
        }
        /// <summary>
        /// Lưu các thuộc tính ROI trong BlobMultiROI
        /// </summary>
        /// <param name="_Action"></param>
        /// <returns></returns>
        public static bool SaveActionROIProperties(cAction _Action)
        {
            if (ROIProperties == null)
                return false;
            if (_Action.ROIProperties == null) return true;
            foreach (object item in _Action.ROIProperties.Values)
            {
                DataRow r = ROIProperties.NewRow();
                SetNullValueToDataRow(r);

                cROIProperty ROIP = (cROIProperty)item;
                r[cColName.ActionID] = _Action.ID.ToString();
                r[cColName.ID] = ROIP.ID.ToString();

                var ROIPprops = ROIP.GetType().GetProperties().Where(x => x != null);
                PropertyInfo propertyInfoValue = null;
                foreach (PropertyInfo propertyInfo in ROIPprops)
                {
                    RTCVariableType rtcvar = (RTCVariableType)ROIP.GetType().GetProperty(propertyInfo.Name).GetValue(ROIP, null);
                    propertyInfoValue = rtcvar.GetType().GetProperty(cPropertyName.rtcValue);

                    object obj = propertyInfoValue.GetValue(rtcvar, null);
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case nameof(SBool):
                            r[cColName.ValueT] = obj.ToString().ToLower();
                            break;
                     
                        case nameof(SImage):
                            break;
                        case nameof(SListDouble):
                            r[cColName.ValueH] = GlobFuncs.ListDouble2StrWithType((List<double>)obj);
                            break;
                        case nameof(SListObject):
                            r[cColName.ValueH] = GlobFuncs.ListObject2StrWithType((List<object>)obj);
                            break;
                        case nameof(SString):
                            r[cColName.ValueT] = (string)obj;
                            break;
                        case nameof(SInt):
                            r[cColName.ValueI] = (int)obj;
                            break;
                        case nameof(SDouble):
                            r[cColName.ValueD] = (double)obj;
                            break;
                        case nameof(SObject):
                            r[cColName.ValueH] = obj;
                            break;
                        default:
                            break;
                    }
                }

                ROIProperties.Rows.Add(r);
            }
            return true;
        }
        public static bool SaveActionLinkProperty(cAction action)
        {
            try
            {
                if (LinkProperty == null)
                    return false;
                if (action.LinkProperty == null || action.LinkProperty.Count <= 0)
                    return true;
                bool Result = false;
                foreach (cLinkProperty linkItem in action.LinkProperty)
                {
                    DataRow r = LinkProperty.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.ID] = linkItem.ID;
                    r[cColName.ActionID] = action.ID;
                    r[cColName.OrderNum] = linkItem.OrderNum;

                    r[cColName.SourceCamID] = linkItem.SourceCamID;
                    r[cColName.SourceID] = linkItem.SourceID;
                    r[cColName.SourceName] = linkItem.SourceName;
                    r[cColName.SourceIndex] = GlobFuncs.ListObject2StrWithType(linkItem.SourceIndex);

                    r[cColName.TargetCamID] = linkItem.TargetCamID;
                    r[cColName.TargetID] = linkItem.TargetID;
                    r[cColName.TargetName] = linkItem.TargetName;
                    r[cColName.TargetIndex] = GlobFuncs.ListObject2StrWithType(linkItem.TargetIndex);

                    Result = MyConn.AddRow(r);

                    if (!Result) break;
                }

                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool SaveActionColumns(cAction action)
        {
            try
            {
                if (ColumnList == null)
                    return false;
                if (action.Columns == null || action.Columns.Count <= 0)
                    return true;
                bool result = false;
                foreach (cColumnProperty columnProperty in action.Columns)
                {
                    DataRow r = ColumnList.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.ID] = columnProperty.ID;
                    r[cColName.ActionID] = action.ID;
                    r[cColName.OrderNum] = columnProperty.OrderNum;

                    r[cColName.Active] = columnProperty.Active;
                    r[cColName.Name] = columnProperty.Name;
                    r[cColName.DataType] = columnProperty.DataType;
                    r[cColName.Format] = columnProperty.Format;
                    r[cColName.DisplayFormat] = columnProperty.DisplayFormat;
                    r[cColName.Value] = columnProperty.Value;
                    r[cColName.RefID] = columnProperty.RefID;
                    r[cColName.PropName] = columnProperty.PropName;
                    r[cColName.Ref] = columnProperty.Ref;

                    result = MyConn.AddRow(r);

                    if (!result) break;
                } 

                return result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool SaveActionROIProperties(cROIProperty _ROI)
        {
            if (ROIProperties == null || _ROI == null)
                return false;
            ROIProperties.Clear();
            var ROIPprops = _ROI.GetType().GetProperties().Where(x => x != null);
            PropertyInfo propertyInfoValue = null;
            foreach (PropertyInfo propertyInfo in ROIPprops)
            {
                DataRow r = ROIProperties.NewRow();
                SetNullValueToDataRow(r);
                r[cColName.ID] = _ROI.ID.ToString();
                r[cColName.PropName] = propertyInfo.Name;

                RTCVariableType rtcvar = (RTCVariableType)_ROI.GetType().GetProperty(propertyInfo.Name)?.GetValue(_ROI, null);
                if (rtcvar == null) continue;
                propertyInfoValue = rtcvar.GetType().GetProperty(cPropertyName.rtcValue);

                object obj = propertyInfoValue.GetValue(rtcvar, null);
                switch (propertyInfo.PropertyType.Name)
                {
                    case nameof(SBool):
                        r[cColName.ValueT] = obj.ToString().ToLower();
                        break;
                  
                    case nameof(SListDouble):
                        r[cColName.ValueH] = GlobFuncs.ListDouble2Str((List<double>)obj);
                        break;
                    case nameof(SListObject):
                        r[cColName.ValueH] = GlobFuncs.ListObject2Str((List<object>)obj);
                        break;
                    case nameof(SString):
                        r[cColName.ValueT] = (string)obj;
                        break;
                    case nameof(SInt):
                        r[cColName.ValueI] = (int)obj;
                        break;
                    case nameof(SDouble):
                        r[cColName.ValueD] = (double)obj;
                        break;
                    default:
                        r[cColName.ValueH] = obj;
                        break;
                }
                ROIProperties.Rows.Add(r);
            }
            return true;
        }
        public static bool SaveActionLinkPassFail(cAction _Action)
        {
            if (LinkPassFail == null)
                return false;
            if (_Action.LinkPassFail == null) return true;
            foreach (cLinkPassFail _Link in _Action.LinkPassFail)
            {
                DataRow r = LinkPassFail.NewRow();
                SetNullValueToDataRow(r);
                r[cColName.Active] = _Link.rtcActive;
                r[cColName.STT] = _Link.rtcSTT;
                r[cColName.IDRef] = _Link.rtcIDref.ToString();
                r[cColName.PropName] = _Link.rtcPropNameRef;
                r[cColName.Ref] = _Link.rtcRef;
                r[cColName.Invert] = _Link.rtcInvert;
                LinkPassFail.Rows.Add(r);
            }
            return true;
        }
        public static bool SaveStringBuilderItems(cAction _Action)
        {
            try
            {
                if (StringBuilderItems == null)
                    return false;
                if (_Action.StringBuilders == null) return true;

                foreach (SStringBuilderItem _Item in _Action.StringBuilders)
                {
                    DataRow r = _StringBuilderItems.NewRow();
                    r[cColName.ActionID] = _Action.ID;
                    r[cColName.OrderNum] = _Item.OrderNum;
                    r[cColName.Name] = _Item.Name;
                    r[cColName.RefID] = _Item.RefID;
                    r[cColName.RefPropName] = _Item.RefPropName;
                    r[cColName.Ref] = _Item.Ref;

                    r[cColName.Value] = GlobFuncs.ListDouble2StrWithType(_Item.ListDoubleValue) == string.Empty ? GlobFuncs.ListString2StrWithType(_Item.ListStringValue) : GlobFuncs.ListDouble2StrWithType(_Item.ListDoubleValue);
                    r[cColName.ValueView] = _Item.ValueView;
                    r[cColName.ValueViewFull] = _Item.ValueViewFull;

                    r[cColName.Value] = _Item.ValueStyle;
                    r[cColName.TrueText] = _Item.TrueText;
                    r[cColName.FalseText] = _Item.FalseText;
                    r[cColName.DateFormat] = _Item.DateFormat;
                    r[cColName.DelimiterDate] = _Item.DelimiterDate;
                    r[cColName.TimeFormat] = _Item.TimeFormat;
                    r[cColName.DelimiterTime] = _Item.DelimiterTime;
                    r[cColName.UseDecimalPlaces] = _Item.UseDecimalPlaces;
                    r[cColName.DecimalPlaces] = _Item.DecimalPlaces;
                    r[cColName.UseMiniumLength] = _Item.UseMiniumLength;
                    r[cColName.MiniumLength] = _Item.MiniumLength;
                    r[cColName.UseLimitInput] = _Item.UseLimitInput;
                    r[cColName.MaximumLength] = _Item.MaximumLength;
                    r[cColName.UsePadOutput] = _Item.UsePadOutput;
                    r[cColName.PadOutput] = _Item.PadOutPut;
                    r[cColName.PadWith] = _Item.PadWith;
                    r[cColName.GroupingBracket] = _Item.GroupingBracket;
                    r[cColName.XYDelimiter] = _Item.XYDelimiter;
                    r[cColName.E_DelimiterType] = _Item.ElementDelimiter.DelimiterTypes;
                    r[cColName.E_StandardValue] = _Item.ElementDelimiter.StandardValue;
                    r[cColName.E_CustomValue] = _Item.ElementDelimiter.CustomValue;
                    if (!MyConn.AddRow(r)) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool SaveActionSettings(cAction _Action)
        {
            if (ActionSettings == null)
                return false;

            //Lấy toàn bộ properties của action này
            var orderedProperty = _Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(_Action, null)) != null).ToList();

            PropertyInfo nProperty;
            for (int i = 0; i < orderedProperty.Count; i++)
            {
                nProperty = orderedProperty[i];
                RTCVariableType rtcvar = (RTCVariableType)_Action.GetType().GetProperty(nProperty.Name).GetValue(_Action, null);
                PropertyInfo rtcvarValue = nProperty.PropertyType.GetProperty(cPropertyName.rtcValue);
                DataRow r = ActionSettings.NewRow();
                SetNullValueToDataRow(r);
                r[cColName.ActionID] = _Action.ID;
                r[cColName.PropName] = nProperty.Name;
                r[cColName.rtcIsParent] = rtcvar.rtcIsParent.ToString().ToLower();
                r[cColName.rtcIDRef] = rtcvar.rtcIDRef;
                r[cColName.rtcPropNameRef] = rtcvar.rtcPropNameRef;
                r[cColName.rtcRef] = rtcvar.rtcRef;
                r[cColName.rtcValueView] = rtcvar.rtcValueView;
                r[cColName.rtcValueViewFull] = rtcvar.rtcValueViewFull;

                object obj = rtcvarValue.GetValue(rtcvar, null);
                switch (nProperty.PropertyType.Name)
                {
                    case nameof(SBool):
                        r[cColName.ValueT] = obj.ToString().ToLower();
                        break;
                       
                    case nameof(SListDouble):
                        r[cColName.ValueH] = GlobFuncs.ListDouble2StrWithType((List<double>)obj);
                        break;
                    case nameof(SListObject):
                        r[cColName.ValueH] = GlobFuncs.ListObject2StrWithType((List<object>)obj);
                        break;
                    case nameof(SString):
                        r[cColName.ValueT] = (string)obj;
                        break;
                    case nameof(SInt):
                        r[cColName.ValueI] = (int)obj;
                        break;
                    case nameof(SDouble):
                        r[cColName.ValueD] = (double)obj;
                        break;
                    default:
                        r[cColName.ValueH] = obj;
                        break;
                }

                ActionSettings.Rows.Add(r);
            }
            return true;
        }
        private static Dictionary<long, object> ShapeListToDictionaryROI(List<object> _ShapeList)
        {
            int count = GlobVar.ShapeListCount;
            Dictionary<long, object> Result = new Dictionary<long, object>();


            if (_ShapeList.Count >= count && _ShapeList.Count % count == 0)
            {
                int ipd = _ShapeList.Count / count;
                for (int i = 0; i < ipd; i++)
                {
                    EDrawingtypes eDrawingTypes = (EDrawingtypes)(int)_ShapeList[i * count + 5];
                    switch (eDrawingTypes)
                    {
                        case EDrawingtypes.Rectang:
                            cRectangType Rec = new cRectangType();
                            Rec.Center.Row = (double)_ShapeList[i * count];
                            Rec.Center.Col = (double)_ShapeList[i * count + 1];
                            Rec.Phi = (double)_ShapeList[i* count + 2];
                            Rec.Width = (double)_ShapeList[i * count + 3];
                            Rec.Height = (double)_ShapeList[i * count + 4];
                            Rec.ConnectType = (EConnectTypes)(int)_ShapeList[i * count + 6];
                            Rec.ID = (long)_ShapeList[i * count + 8];
                            Result.Add(Rec.ID, Rec);
                            break;
                        case EDrawingtypes.Ellipse:
                            cEllipseType Elip = new cEllipseType();

                            Elip.Center.Row = (double)_ShapeList[i * count];
                            Elip.Center.Col = (double)_ShapeList[i * count + 1];
                            Elip.Phi = (double)_ShapeList[i * count + 2];
                            Elip.Radius1 = (double)_ShapeList[i * count + 3];
                            Elip.Radius2 = (double)_ShapeList[i * count + 4];
                            Elip.ConnectType = (EConnectTypes)(int)_ShapeList[i * count + 6];
                            Elip.ID = (long)_ShapeList[i * count + 8];
                            Result.Add(Elip.ID, Elip);
                            break;
                        case EDrawingtypes.Line:
                            break;
                        case EDrawingtypes.Polygon:
                            break;
                        case EDrawingtypes.none:
                            break;
                        default:
                            break;
                    }
                }
            }
            
            return Result;
        }
        public static bool SaveActionList_Iconic(cGroupActions _Group, string _GroupFileName)
        {
            //try
            //{
            //    HTuple dict = null;
            //    foreach (cAction action in _Group.Actions.Values)
            //    {
            //        var orderedProperty = action.GetType().GetProperties().Where(
            //            x => ((RTCVariableType)x.GetValue(action, null)) != null &&
            //            ((RTCVariableType)x.GetValue(action, null)).rtcSaveToFile).ToList();
            //        PropertyInfo nProperty;
            //        for (int i = 0; i < orderedProperty.Count; i++)
            //        {
            //            nProperty = orderedProperty[i];
            //            RTCVariableType rtcvar = (RTCVariableType)action.GetType().GetProperty(nProperty.Name).GetValue(action, null);

            //            if (dict == null) HOperatorSet.CreateDict(out dict); //else dict.TupleAdd(nameof(nProperty.Name) + action.ID.ToString());
            //            switch (nProperty.PropertyType.Name)
            //            {
            //                case nameof(SHTuple):
            //                    HOperatorSet.SetDictTuple(dict, nProperty.Name + action.ID.ToString(), ((SHTuple)rtcvar).rtcValue);
            //                    break;
            //                case nameof(SHImage):
            //                    HOperatorSet.SetDictObject(((SHImage)rtcvar).rtcValue, dict, nProperty.Name + action.ID.ToString());
            //                    break;
            //                case nameof(SHRegion):
            //                    HOperatorSet.SetDictObject(((SHRegion)rtcvar).rtcValue, dict, nProperty.Name + action.ID.ToString());
            //                    break;
            //                case nameof(SHXLDCont):
            //                    HOperatorSet.SetDictObject(((SHXLDCont)rtcvar).rtcValue, dict, nProperty.Name + action.ID.ToString());
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //    }

            //    if (dict != null)
            //    {
            //        _Group.FileNameIconic = System.IO.Path.GetDirectoryName(_GroupFileName) + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileNameWithoutExtension(_GroupFileName) + cExtFile.GroupIconicD;
            //        HOperatorSet.WriteDict(dict, _Group.FileNameIconic, new HTuple(), new HTuple());
            //    }

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    GlobFuncs.SaveErr(ex);
            //    return false;
            //}
            return true;
        }
        public static bool SaveActionList(cGroupActions _Group)
        {
            try
            {
                if (ActionList == null)
                    return false;
                //HTuple dict = null; 
                bool Result = false;
                foreach (cAction action in _Group.Actions.Values)
                {
                    Dictionary<long, object> ROIBak = null;
                    Dictionary<long, object> FindROIBak = null;
                    try
                    {
                        DataRow r = ActionList.NewRow();
                        r[cColName.ID] = action.ID;
                        r[cColName.GroupID] = _Group.ID;
                        r[cColName.STT] = action.STT;
                        r[cColName.Name] = action.Name.rtcValue;
                        r[cColName.ActionType] = action.ActionType;
                        r[cColName.ObjectType] = action.ObjectType;

                        Result = MyConn.AddRow(r);

                        if (action.ROIs != null && action.ROIs.Count > 0)
                        {
                            ROIBak = new Dictionary<long, object>();
                            ROIBak = action.ROIs.ToDictionary(x => x.Key, x => x.Value);
                        }
                        if (action.FindROIs != null && action.FindROIs.Count > 0)
                        {
                            FindROIBak = new Dictionary<long, object>();
                            FindROIBak = action.FindROIs.ToDictionary(x => x.Key, x => x.Value);
                        }

                        if (action.ShapeListOriginal != null && action.ShapeListOriginal.rtcValue.Count > 0)
                            action.ROIs = ShapeListToDictionaryROI(action.ShapeListOriginal.rtcValue);
                        if (action.FindShapeListOriginal != null && action.FindShapeListOriginal.rtcValue.Count > 0)
                            action.FindROIs = ShapeListToDictionaryROI(action.FindShapeListOriginal.rtcValue);

                        if (Result) Result = SaveActionSettings(action);
                        if (Result) Result = SaveActionROIs(action);
                        if (Result) Result = SaveActionFindROIs(action);
                        if (Result && action.ActionType == EActionTypes.PassFail) Result = SaveActionLinkPassFail(action);
                        if (Result && action.ActionType == EActionTypes.StringBuilder) Result = SaveStringBuilderItems(action);
                        if (Result) Result = SaveActionROIProperties(action);
                        if (Result) Result = SaveActionLinkProperty(action);
                        if (Result) Result = SaveActionColumns(action);

                        if (!Result) break;
                    }
                    finally
                    {
                        if (ROIBak != null) action.ROIs = ROIBak.ToDictionary(x => x.Key, x => x.Value);
                        if (FindROIBak != null) action.FindROIs = FindROIBak.ToDictionary(x => x.Key, x => x.Value);
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        #endregion
        #region "FUNCTIONS OPEN DATA"
        /// <summary>
        /// Lấy thông tin của 1 groupActions
        /// </summary>
        /// <param name="_Group">Group cần lấy thông tin ra</param>
        /// <returns>True: Thành công; False: Thất bại</returns>
        public static bool OpenGroup(cGroupActions _Group)
        {
            try
            {
                if (GroupList == null || GroupList.Rows.Count <= 0)
                    return false;

                DataRow r = _GroupList.Rows[0];
                _Group.ID = GlobFuncs.GetDataRowValue_Guid(r, cColName.ID);
                _Group.Name.rtcValue = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                _Group.IDMainAction = GlobFuncs.GetDataRowValue_Guid(r, cColName.IDMainAction);
                _Group.STT = GlobFuncs.GetDataRowValue_Int(r, cColName.STT);
                _Group.SourceImageSettings.ImageSourceType = (EImageSourceTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ImageSourceType);
                _Group.SourceImageSettings.DefaultImageSourceType = (EImageSourceTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.DefaultImageSourceType);
                _Group.SourceImageSettings.IsEnableSnap = GlobFuncs.GetDataRowValue_Boolean(r, cColName.EnableSnap);
                if (_GroupList.Columns.Contains(cColName.RunCount))
                    _Group.RunCount = GlobFuncs.GetDataRowValue_Int(r, cColName.RunCount);
                if (_GroupList.Columns.Contains(cColName.PassCount))
                    _Group.PassCount = GlobFuncs.GetDataRowValue_Int(r, cColName.PassCount);
                if (_GroupList.Columns.Contains(cColName.FailCount))
                    _Group.FailCount = GlobFuncs.GetDataRowValue_Int(r, cColName.FailCount);
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        /// <summary>
        /// Đọc dữ liệu cài đặt hình ảnh với TH lấy từ máy
        /// </summary>
        /// <param name="_Group">Group cần lấy dữ liệu</param>
        /// <returns></returns>
        public static bool OpenGroup_ComputerSettings(cGroupActions _Group)
        {
            try
            {
                if (ComputerSettings == null)
                    return false;

                PropertyInfo[] pComputerSettings = _Group.SourceImageSettings.ComputerSettings.GetType().GetProperties();
                foreach (PropertyInfo item in pComputerSettings)
                {
                    DataRow r = _ComputerSettings.Rows.Find(new object[] { _Group.ID, item.Name });
                    if (r == null) continue;
                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            item.SetValue(_Group.SourceImageSettings.ComputerSettings, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                            break;
                        case "Boolean":
                            item.SetValue(_Group.SourceImageSettings.ComputerSettings, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                            break;
                        case "Int32":
                            item.SetValue(_Group.SourceImageSettings.ComputerSettings, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                item.SetValue(_Group.SourceImageSettings.ComputerSettings, GlobFuncs.String2ListString(GlobFuncs.GetDataRowValue_String(r, cColName.ValueT), cStrings.SepPhay));
                            }
                            break;
                        default:
                            continue;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool OpenGroup_CameraSettings(cGroupActions _Group)
        {
            try
            {
                if (CameraSettings == null)
                    return false;

                PropertyInfo[] pCameraSettings = _Group.SourceImageSettings.CameraSettings.GetType().GetProperties();
                foreach (PropertyInfo item in pCameraSettings)
                {
                    DataRow r = _CameraSettings.Rows.Find(new object[] { _Group.ID, item.Name });
                    if (r == null) continue;
                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            item.SetValue(_Group.SourceImageSettings.CameraSettings, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                            break;
                        case "Boolean":
                            item.SetValue(_Group.SourceImageSettings.CameraSettings, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                            break;
                        case "Int32":
                            item.SetValue(_Group.SourceImageSettings.CameraSettings, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                item.SetValue(_Group.SourceImageSettings.CameraSettings, GlobFuncs.String2ListString(GlobFuncs.GetDataRowValue_String(r, cColName.ValueT), cStrings.SepPhay));
                            }
                            break;
                        default:
                            continue;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public static bool OpenGroup_SourceImages(cGroupActions _Group)
        {
            try
            {
                if (SourceImages == null)
                    return false;
                List<cImage> _Images = new List<cImage>();
                foreach (DataRow r in _SourceImages.Rows)
                {
                    cImage _Image = new cImage();
                    _Image.FileName = GlobFuncs.GetDataRowValue_String(r, cColName.FileName);
                    _Image.Passed = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Passed);
                    _Image.Ran = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Ran);
                    _Images.Add(_Image);
                }

                switch (_Group.SourceImageSettings.ImageSourceType)
                {
                    case EImageSourceTypes.Computer:
                        _Group.SourceImageSettings.ComputerSettings.Images = _Images;
                        break;
                    case EImageSourceTypes.Camera:
                        _Group.SourceImageSettings.CameraSettings.Images = _Images;
                        break;
                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool OpenGroup_Trigger(cGroupActions _Group)
        {
            try
            {
                if (Trigger == null)
                    return true;
                DataRow rTrigger = _Trigger.Rows.Find(new object[] { _Group.ID });
                if (rTrigger == null) return true;

                _Group.SourceImageSettings.Trigger.TriggerMode = (ETriggerMode)GlobFuncs.GetDataRowValue_Int(rTrigger, cColName.TriggerMode);
                _Group.SourceImageSettings.Trigger.TriggerType = (ETriggerType)GlobFuncs.GetDataRowValue_Int(rTrigger, cColName.TriggerType);
                _Group.SourceImageSettings.Trigger.COMName = GlobFuncs.GetDataRowValue_String(rTrigger, cColName.COMName);
                _Group.SourceImageSettings.Trigger.IP = GlobFuncs.GetDataRowValue_String(rTrigger, cColName.IP);
                _Group.SourceImageSettings.Trigger.Port = GlobFuncs.GetDataRowValue_Int(rTrigger, cColName.Port);
                _Group.SourceImageSettings.Trigger.TriggerValue = GlobFuncs.GetDataRowValue_String(rTrigger, cColName.TriggerValue);

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool OpenActionSettings(cAction _Action)
        {
            if (ActionSettings == null)
                return false;
            string HtupleVal;
            string[] HtupleVals;
            //Lấy toàn bộ properties của action này
            var orderedProperty = _Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(_Action, null)) != null).ToList();

            PropertyInfo nProperty;
            for (int i = 0; i < orderedProperty.Count; i++)
            {
                nProperty = orderedProperty[i];
                RTCVariableType rtcvar = (RTCVariableType)_Action.GetType().GetProperty(nProperty.Name).GetValue(_Action, null);
                PropertyInfo rtcvarValue = nProperty.PropertyType.GetProperty(cPropertyName.rtcValue);
                DataRow r = _ActionSettings.Rows.Find(new object[] { _Action.ID, nProperty.Name });


                if (r == null) continue;
                switch (nProperty.PropertyType.Name)
                {
                    case nameof(SBool):
                        rtcvarValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                        break;

                    case nameof(SListDouble):
                        //HTuple hTuple = new HTuple(new object[] { GlobFuncs.GetDataRowValue_String(r, cColName.ValueH).Split(cStrings.SepPhay) });
                        HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                        HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                        if (HtupleVal != "")
                        {
                            if (HtupleVals.Length != 2) rtcvarValue.SetValue(rtcvar, new List<double>());
                            else
                                switch (HtupleVals[1])
                                {
                                    case cValueTypes.INTEGER:
                                        rtcvarValue.SetValue(rtcvar, GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                        break;

                                    case cValueTypes.DOUBLE:
                                        rtcvarValue.SetValue(rtcvar, GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                        break;

                                    case cValueTypes.EMPTY:
                                        rtcvarValue.SetValue(rtcvar, new List<double>());
                                        break;
                                    default:
                                        break;
                                }
                        }
                        else rtcvarValue.SetValue(rtcvar, new List<double>());

                        break;
                    case nameof(SListString):

                        HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                        HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                        if (HtupleVals.Length != 2) rtcvarValue.SetValue(rtcvar, new List<double>());
                        else
                        {
                            switch (HtupleVals[1])
                            {
                                case cValueTypes.STRING:
                                    rtcvarValue.SetValue(rtcvar, GlobFuncs.Str2StringArr(HtupleVals[0]));
                                    break;
                            }
                        }

                        break;
                    case nameof(SListObject):

                        HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                        HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                        if (HtupleVals.Length != 2) rtcvarValue.SetValue(rtcvar, new List<double>());
                        else
                        {
                            switch (HtupleVals[1])
                            {
                                case cValueTypes.MIXED:
                                    rtcvarValue.SetValue(rtcvar, GlobFuncs.Str2StringObj(HtupleVals[0]));
                                    break;
                            }
                        }

                        break;

                    case nameof(SString):
                        rtcvarValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                        break;
                    case nameof(SInt):
                        rtcvarValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                        break;
                    case nameof(SDouble):
                        rtcvarValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Double(r, cColName.ValueD));
                        break;
                    default:
                        break;
                }

                rtcvar.rtcIsParent = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcIsParent);
                rtcvar.rtcIDRef = GlobFuncs.GetDataRowValue_Guid(r, cColName.rtcIDRef);
                rtcvar.rtcPropNameRef = GlobFuncs.GetDataRowValue_String(r, cColName.rtcPropNameRef);
                rtcvar.rtcRef = GlobFuncs.GetDataRowValue_String(r, cColName.rtcRef);
            }

            return true;
        }
        public static bool OpenActionROIs(cAction _Action)
        {
            _Action.ROIs = new Dictionary<long, object>();
            if (ROIs == null)
                return true;
            DataRow[] dataRows = _ROIs.Select(cColName.ActionID + "='" + _Action.ID.ToString() + "'");
            EDrawingtypes eDrawingTypes = EDrawingtypes.none;
            foreach (DataRow r in dataRows)
            {
                eDrawingTypes = (EDrawingtypes)GlobFuncs.GetDataRowValue_Int(r, cColName.DrawingType);
                switch (eDrawingTypes)
                {
                    case EDrawingtypes.Rectang:
                        {
                            cRectangType Rec = new cRectangType();
                            Rec.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                            Rec.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                            Rec.MarkID = new List<double>();
                            string markID = GlobFuncs.GetDataRowValue_String(r, cColName.MarkID);
                            if (!string.IsNullOrEmpty(markID))
                            {
                                string[] markIDs = markID.Split(cChars.Comma);
                                foreach (string id in markIDs)
                                    Rec.MarkID.Append(long.Parse(id));
                            }

                            Rec.MasterID = GlobFuncs.GetDataRowValue_Long(r, cColName.MasterID);
                            Rec.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                            Rec.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                            Rec.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                            Rec.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                            Rec.Width = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                            Rec.Height = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                            Rec.DrawingType = eDrawingTypes;
                            Rec.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                            Rec.AnimationType =
                                (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                            Rec.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            Rec.RoiType = (ERoiTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiType);
                            Rec.RoiLegend = (EROILegend)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiLegend);
                            _Action.ROIs.Add(Rec.ID, Rec);
                            break;
                        }
                    case EDrawingtypes.Rectang1:
                        {
                            cRectangType Rec = new cRectangType();
                            Rec.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                            Rec.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                            Rec.MarkID = new List<double>();
                            string markID = GlobFuncs.GetDataRowValue_String(r, cColName.MarkID);
                            if (!string.IsNullOrEmpty(markID))
                            {
                                string[] markIDs = markID.Split(cChars.Comma);
                                foreach (string id in markIDs)
                                    Rec.MarkID.Append(long.Parse(id));
                            }

                            Rec.MasterID = GlobFuncs.GetDataRowValue_Long(r, cColName.MasterID);
                            Rec.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                            Rec.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                            Rec.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                            Rec.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                            Rec.Width = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                            Rec.Height = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                            Rec.DrawingType = eDrawingTypes;
                            Rec.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                            Rec.AnimationType =
                                (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                            Rec.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            Rec.RoiType = (ERoiTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiType);
                            Rec.RoiLegend = (EROILegend)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiLegend);
                            _Action.ROIs.Add(Rec.ID, Rec);
                            break;
                        }
                    case EDrawingtypes.Ellipse:
                        {
                            cEllipseType Ell = new cEllipseType();
                            Ell.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                            Ell.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                            Ell.MarkID = new List<double>();
                            string markID = GlobFuncs.GetDataRowValue_String(r, cColName.MarkID);
                            if (!string.IsNullOrEmpty(markID))
                            {
                                string[] markIDs = markID.Split(cChars.Comma);
                                foreach (string id in markIDs)
                                    Ell.MarkID.Append(long.Parse(id));
                            }

                            Ell.MasterID = GlobFuncs.GetDataRowValue_Long(r, cColName.MasterID);
                            Ell.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                            Ell.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                            Ell.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                            Ell.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                            Ell.Radius1 = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                            Ell.Radius2 = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                            Ell.DrawingType = eDrawingTypes;
                            Ell.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                            Ell.AnimationType =
                                (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                            Ell.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            Ell.RoiType = (ERoiTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiType);
                            Ell.RoiLegend = (EROILegend)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiLegend);
                            _Action.ROIs.Add(Ell.ID, Ell);
                            break;
                        }
                    case EDrawingtypes.Line:
                        break;
                    case EDrawingtypes.Polygon:
                        break;
                    case EDrawingtypes.none:
                        break;
                    default:
                        break;
                }
            }
            return true;
        }
        public static bool OpenActionFindROIs(cAction _Action)
        {
            _Action.FindROIs = new Dictionary<long, object>();
            if (FindROIs == null)
                return true;
            DataRow[] dataRows = _FindROIs.Select(cColName.ActionID + "='" + _Action.ID.ToString() + "'");
            EDrawingtypes eDrawingTypes = EDrawingtypes.none;
            foreach (DataRow r in dataRows)
            {
                eDrawingTypes = (EDrawingtypes)GlobFuncs.GetDataRowValue_Int(r, cColName.DrawingType);
                switch (eDrawingTypes)
                {
                    case EDrawingtypes.Rectang:
                        {
                            cRectangType Rec = new cRectangType();
                            Rec.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                            Rec.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                            Rec.MarkID = new List<double>();
                            string markID = GlobFuncs.GetDataRowValue_String(r, cColName.MarkID);
                            if (!string.IsNullOrEmpty(markID))
                            {
                                string[] markIDs = markID.Split(cChars.Comma);
                                foreach (string id in markIDs)
                                    Rec.MarkID.Append(long.Parse(id));
                            }

                            Rec.MasterID = GlobFuncs.GetDataRowValue_Long(r, cColName.MasterID);
                            Rec.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                            Rec.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                            Rec.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                            Rec.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                            Rec.Width = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                            Rec.Height = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                            Rec.DrawingType = eDrawingTypes;
                            Rec.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                            Rec.AnimationType =
                                (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                            Rec.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            Rec.RoiType = (ERoiTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiType);
                            Rec.RoiLegend = (EROILegend)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiLegend);
                            _Action.FindROIs.Add(Rec.ID, Rec);
                            break;
                        }
                    case EDrawingtypes.Rectang1:
                        {
                            cRectangType Rec = new cRectangType();
                            Rec.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                            Rec.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                            Rec.MarkID = new List<double>();
                            string markID = GlobFuncs.GetDataRowValue_String(r, cColName.MarkID);
                            if (!string.IsNullOrEmpty(markID))
                            {
                                string[] markIDs = markID.Split(cChars.Comma);
                                foreach (string id in markIDs)
                                    Rec.MarkID.Append(long.Parse(id));
                            }

                            Rec.MasterID = GlobFuncs.GetDataRowValue_Long(r, cColName.MasterID);
                            Rec.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                            Rec.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                            Rec.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                            Rec.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                            Rec.Width = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                            Rec.Height = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                            Rec.DrawingType = eDrawingTypes;
                            Rec.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                            Rec.AnimationType =
                                (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                            Rec.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            Rec.RoiType = (ERoiTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiType);
                            Rec.RoiLegend = (EROILegend)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiLegend);
                            _Action.FindROIs.Add(Rec.ID, Rec);
                            break;
                        }
                    case EDrawingtypes.Ellipse:
                        {
                            cEllipseType Ell = new cEllipseType();
                            Ell.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                            Ell.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                            Ell.MarkID = new List<double>();
                            string markID = GlobFuncs.GetDataRowValue_String(r, cColName.MarkID);
                            if (!string.IsNullOrEmpty(markID))
                            {
                                string[] markIDs = markID.Split(cChars.Comma);
                                foreach (string id in markIDs)
                                    Ell.MarkID.Append(long.Parse(id));
                            }

                            Ell.MasterID = GlobFuncs.GetDataRowValue_Long(r, cColName.MasterID);

                            Ell.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                            Ell.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                            Ell.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                            Ell.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                            Ell.Radius1 = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                            Ell.Radius2 = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                            Ell.DrawingType = eDrawingTypes;
                            Ell.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                            Ell.AnimationType =
                                (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                            Ell.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            Ell.RoiType = (ERoiTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiType);
                            Ell.RoiLegend = (EROILegend)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiLegend);
                            _Action.FindROIs.Add(Ell.ID, Ell);
                            break;
                        }
                    case EDrawingtypes.Line:
                        break;
                    case EDrawingtypes.Polygon:
                        break;
                    case EDrawingtypes.none:
                        break;
                    default:
                        break;
                }
            }
            return true;
        }
        public static bool OpenActionROIProperties(cAction _Action)
        {
            try
            {
                _Action.ROIProperties = new Dictionary<long, cROIProperty>();
                if (ROIProperties == null)
                    return true;
                string HtupleVal;
                string[] HtupleVals;
                // Lấy danh sách các ID ROIProperties
                DataRow[] dataRows = _ROIProperties.Select(cColName.ActionID + "='" + _Action.ID.ToString() + "'");
                if (dataRows == null || dataRows.Count() <= 0) return true;
                var datarowIDs = dataRows.GroupBy(x => x[cColName.ID]).Select(x => x.First());
                foreach (DataRow r in datarowIDs)
                {
                    cROIProperty _ROIProp = new cROIProperty(_Action.ActionType, GlobFuncs.GetDataRowValue_Long(r, cColName.ID));
                    _ROIProp.IDLink = GlobFuncs.GetDataRowValue_Int(r, cColName.IDLink);
                    var ROIPprops = _ROIProp.GetType().GetProperties().Where(x => x != null);
                    PropertyInfo propertyInfoValue = null;

                    foreach (PropertyInfo propertyInfo in ROIPprops)
                    {
                        DataRow rprop = _ROIProperties.Rows.Find(new object[] { _Action.ID, _ROIProp.ID, propertyInfo.Name });
                        RTCVariableType rtcvar = (RTCVariableType)propertyInfo.GetValue(_ROIProp, null);
                        propertyInfoValue = propertyInfo.PropertyType.GetProperty(cPropertyName.rtcValue);

                        switch (propertyInfo.PropertyType.Name)
                        {
                            case nameof(SString):
                                propertyInfoValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueT));
                                break;
                            case nameof(SBool):
                                propertyInfoValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Boolean(rprop, cColName.ValueT));
                                break;
                            case nameof(SInt):
                                propertyInfoValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Int(rprop, cColName.ValueI));
                                break;
                            case nameof(SListDouble):
                                //HTuple hTuple = new HTuple(new object[] { GlobFuncs.GetDataRowValue_String(r, cColName.ValueH).Split(cStrings.SepPhay) });
                                HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                                HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                                if (HtupleVal != "")
                                {
                                    if (HtupleVals.Length != 2) propertyInfoValue.SetValue(rtcvar, new List<double>());
                                    else
                                        switch (HtupleVals[1])
                                        {
                                            case cValueTypes.INTEGER:
                                                propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                                break;

                                            case cValueTypes.DOUBLE:
                                                propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                                break;

                                            case cValueTypes.EMPTY:
                                                propertyInfoValue.SetValue(rtcvar, new List<double>());
                                                break;
                                            default:
                                                break;
                                        }
                                }
                                else propertyInfoValue.SetValue(rtcvar, new List<double>());

                                break;
                            case nameof(SListString):

                                HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                                HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                                if (HtupleVals.Length != 2) propertyInfoValue.SetValue(rtcvar, new List<double>());
                                else
                                {
                                    switch (HtupleVals[1])
                                    {
                                        case cValueTypes.STRING:
                                            propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2StringArr(HtupleVals[0]));
                                            break;
                                    }
                                }

                                break;
                            case nameof(SListObject):

                                HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                                HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                                if (HtupleVals.Length != 2) propertyInfoValue.SetValue(rtcvar, new List<double>());
                                else
                                {
                                    switch (HtupleVals[1])
                                    {
                                        case cValueTypes.MIXED:
                                            propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2StringObj(HtupleVals[0]));
                                            break;
                                    }
                                }

                                break;
                            case nameof(SDouble):
                                propertyInfoValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Double(rprop, cColName.ValueD));
                                break;
                            default:
                                continue;
                        }
                    }

                    _Action.ROIProperties.Add(_ROIProp.ID, _ROIProp);
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool OpenActionLinkProperty(cAction action)
        {
            try
            {
                if (action.ActionType != EActionTypes.LinkValue)
                    return true;
                action.LinkProperty = new List<cLinkProperty>();
                if (LinkProperty == null)
                    return true;
                DataRow[] dataRows = _LinkProperty.Select(cColName.ActionID + "='" + action.ID.ToString() + "'");
                foreach (DataRow r in dataRows)
                {
                    cLinkProperty linkItem = new cLinkProperty();
                    linkItem.ID = GlobFuncs.GetDataRowValue_Guid(r, cColName.ID);
                    linkItem.OrderNum = GlobFuncs.GetDataRowValue_Int(r, cColName.OrderNum);
                    linkItem.SourceCamID = GlobFuncs.GetDataRowValue_Guid(r, cColName.SourceCamID);
                    linkItem.SourceID = GlobFuncs.GetDataRowValue_Guid(r, cColName.SourceID);
                    linkItem.SourceName = GlobFuncs.GetDataRowValue_String(r, cColName.SourceName);

                    string HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.SourceIndex);
                    if (HtupleVal != "")
                    {
                        string[] HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                        if (HtupleVals.Length != 2)
                            linkItem.SourceIndex = new List<object>();
                        else
                            switch (HtupleVals[1])
                            {
                                case cValueTypes.INTEGER:
                                    linkItem.SourceIndex =  GlobFuncs.Str2StringObj(HtupleVals[0]);
                                    break;
                               
                                case cValueTypes.DOUBLE:
                                    linkItem.SourceIndex = GlobFuncs.Str2StringObj(HtupleVals[0]);
                                    break;
                                case cValueTypes.MIXED:
                                    foreach (string item in HtupleVals)
                                        if (GlobFuncs.IsNumeric(item))
                                            HtupleVals.Append(double.Parse(item).ToString());
                                        else if (GlobFuncs.IsInt(item))
                                            HtupleVals.Append(int.Parse(item).ToString());
                                        else
                                            HtupleVals.Append(item);
                                    linkItem.TargetIndex = GlobFuncs.Str2StringObj(HtupleVals[0]);
                                    break;
                                case cValueTypes.EMPTY:
                                    linkItem.SourceIndex = new List<object>();
                                    break;
                                default:
                                    break;
                            }
                    }
                    else linkItem.SourceIndex = new List<object>();

                    linkItem.TargetCamID = GlobFuncs.GetDataRowValue_Guid(r, cColName.TargetCamID);
                    linkItem.TargetID = GlobFuncs.GetDataRowValue_Guid(r, cColName.TargetID);
                    linkItem.TargetName = GlobFuncs.GetDataRowValue_String(r, cColName.TargetName);

                    HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.TargetIndex);
                    if (HtupleVal != "")
                    {
                        string[] HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                        if (HtupleVals.Length != 2)
                            linkItem.TargetIndex = new List<object>();
                        else
                            switch (HtupleVals[1])
                            {
                                case cValueTypes.INTEGER:
                                    linkItem.TargetIndex = GlobFuncs.Str2StringObj(HtupleVals[0]);
                                    break;
                                case cValueTypes.STRING:
                                    linkItem.TargetIndex = GlobFuncs.Str2StringObj(HtupleVals[0]);
                                    break;
                                case cValueTypes.DOUBLE:
                                    linkItem.TargetIndex = GlobFuncs.Str2StringObj(HtupleVals[0]);
                                    break;
                                case cValueTypes.MIXED:
                                    foreach (string item in HtupleVals)
                                        if (GlobFuncs.IsNumeric(item))
                                            HtupleVals.Append(double.Parse(item).ToString());
                                        else if (GlobFuncs.IsInt(item))
                                            HtupleVals.Append(int.Parse(item).ToString());
                                        else
                                            HtupleVals.Append(item);

                                    linkItem.TargetIndex = GlobFuncs.Str2StringObj(HtupleVals[0]);
                                    break;
                                case cValueTypes.EMPTY:
                                    linkItem.TargetIndex = new List<object>();
                                    break;
                                default:
                                    break;
                            }
                    }
                    else linkItem.TargetIndex = new List<object>();
                    action.LinkProperty.Add(linkItem);
                }

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool OpenActionROIProperties(cROIProperty _ROI)
        {
            if (ROIProperties == null)
                return false;

            var ROIPprops = _ROI.GetType().GetProperties().Where(x => x != null);
            PropertyInfo propertyInfoValue = null;
            string HtupleVal;
            string[] HtupleVals;

            foreach (PropertyInfo propertyInfo in ROIPprops)
            {
                DataRow r = _ROIProperties.Rows.Find(new object[] { _ROI.ID, propertyInfo.Name });
                if (r == null) continue;

                RTCVariableType rtcvar = (RTCVariableType)propertyInfo.GetValue(_ROI, null);

                propertyInfoValue = propertyInfo.PropertyType.GetProperty(cPropertyName.rtcValue);

                switch (propertyInfo.PropertyType.Name)
                {
                    case nameof(SString):
                        propertyInfoValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                        break;
                    case nameof(SBool):
                        propertyInfoValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                        break;
                    case nameof(SInt):
                        propertyInfoValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                        break;
                    case nameof(SListDouble):
                         HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                        if (HtupleVal != "")
                        {
                            HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                            if (HtupleVals.Length != 2) propertyInfoValue.SetValue(rtcvar, new List<double>());
                            else
                                switch (HtupleVals[1])
                                {
                                    case cValueTypes.INTEGER:
                                        propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                        break;
                                    case cValueTypes.LONG:
                                        propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                        break;
                                    case cValueTypes.STRING:
                                        propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2StringArr(HtupleVals[0]));
                                        break;
                                    case cValueTypes.DOUBLE:
                                        propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                        break;
                                   
                                    case cValueTypes.EMPTY:
                                        propertyInfoValue.SetValue(rtcvar, new List<double>());
                                        break;
                                    default:
                                        break;
                                }
                        }
                        else propertyInfoValue.SetValue(rtcvar, new List<double>());
                        break;
                    case nameof(SListString):
                        HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                        if (HtupleVal != "")
                        {
                            HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                            if (HtupleVals.Length != 2) propertyInfoValue.SetValue(rtcvar, new List<double>());
                            else
                                switch (HtupleVals[1])
                                {
                                   
                                    case cValueTypes.STRING:
                                        propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2StringArr(HtupleVals[0]));
                                        break;
                                 

                                    case cValueTypes.EMPTY:
                                        propertyInfoValue.SetValue(rtcvar, new List<double>());
                                        break;
                                    default:
                                        break;
                                }
                        }
                        else propertyInfoValue.SetValue(rtcvar, new List<double>());
                        break;

                    case nameof(SListObject):
                        HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                        if (HtupleVal != "")
                        {
                            HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                            if (HtupleVals.Length != 2) propertyInfoValue.SetValue(rtcvar, new List<double>());
                            else
                                switch (HtupleVals[1])
                                {
                                    case cValueTypes.OBJECT:
                                        propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2StringArr(HtupleVals[0]));
                                        break;


                                    case cValueTypes.EMPTY:
                                        propertyInfoValue.SetValue(rtcvar, new List<double>());
                                        break;
                                    default:
                                        break;
                                }
                        }
                        else propertyInfoValue.SetValue(rtcvar, new List<double>());
                        //propertyInfoValue.SetValue(rtcvar,new HTuple(GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH)));
                        break;

                    case nameof(SDouble):
                        propertyInfoValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Double(r, cColName.ValueI));
                        break;
                    default:
                        continue;
                }
            }

            return true;
        }
        public static bool OpenStringBuilderItems(cAction _Action)
        {
            try
            {
                _Action.StringBuilders = new List<SStringBuilderItem>();
                if (StringBuilderItems == null)
                    return true;
                DataRow[] _ActionStringBuilderItems = _StringBuilderItems.Select("ActionID='" + _Action.ID.ToString() + "'");
                foreach (DataRow r in _ActionStringBuilderItems)
                {
                    SStringBuilderItem _SItem = new SStringBuilderItem();
                    _SItem.OrderNum = GlobFuncs.GetDataRowValue_Int(r, cColName.OrderNum);
                    _SItem.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                    _SItem.RefID = GlobFuncs.GetDataRowValue_Guid(r, cColName.RefID);
                    _SItem.RefPropName = GlobFuncs.GetDataRowValue_String(r, cColName.RefPropName);
                    _SItem.Ref = GlobFuncs.GetDataRowValue_String(r, cColName.Ref);
                    _SItem.ValueStyle = (EHTupleStyle)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueStyle);

                    _SItem.ListDoubleValue = new List<double>();
                    _SItem.ListStringValue = new List<string>();
                    
                    string HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.Value);
                    if (HtupleVal != "")
                    {
                        string[] HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                        if (HtupleVals.Length != 2)
                        {
                            _SItem.ListDoubleValue = new List<double>();
                            _SItem.ListStringValue = new List<string>();
                        }

                        else
                            switch (HtupleVals[1])
                            {
                                case cValueTypes.INTEGER:
                                    _SItem.ListDoubleValue = (GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                    break;
                                case cValueTypes.STRING:
                                    _SItem.ListStringValue = GlobFuncs.Str2StringArr(HtupleVals[0]);
                                    break;
                                case cValueTypes.DOUBLE:
                                    _SItem.ListDoubleValue = GlobFuncs.Str2DoubleArr(HtupleVals[0]);
                                    break;
                                case cValueTypes.MIXED:
                                    foreach (string item in HtupleVals)
                                        if (GlobFuncs.IsNumeric(item))
                                            HtupleVals.Append(double.Parse(item).ToString());
                                        else if (GlobFuncs.IsInt(item))
                                            HtupleVals.Append(int.Parse(item).ToString());
                                        else
                                            HtupleVals.Append(item);

                                    _SItem.ListDoubleValue = GlobFuncs.Str2DoubleArr(HtupleVals[0]);
                                    break;
                                case cValueTypes.EMPTY:
                                    _SItem.ListDoubleValue = new List<double>();
                                    break;
                                default:
                                    break;
                            }
                    }
                    _SItem.TrueText = GlobFuncs.GetDataRowValue_String(r, cColName.TrueText);
                    _SItem.FalseText = GlobFuncs.GetDataRowValue_String(r, cColName.FalseText);
                    _SItem.DateFormat = (EDateFormat)GlobFuncs.GetDataRowValue_Int(r, cColName.DateFormat);
                    _SItem.DelimiterDate = (EDelimiterDate)GlobFuncs.GetDataRowValue_Int(r, cColName.DelimiterDate);
                    _SItem.TimeFormat = (ETimeFormat)GlobFuncs.GetDataRowValue_Int(r, cColName.TimeFormat);
                    _SItem.DelimiterTime = (EDelimiterTime)GlobFuncs.GetDataRowValue_Int(r, cColName.DelimiterTime);
                    _SItem.UseDecimalPlaces = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UseDecimalPlaces);
                    _SItem.DecimalPlaces = GlobFuncs.GetDataRowValue_Int(r, cColName.DecimalPlaces);
                    _SItem.UseMiniumLength = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UseMiniumLength);
                    _SItem.MiniumLength = GlobFuncs.GetDataRowValue_Int(r, cColName.MiniumLength);
                    _SItem.UseLimitInput = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UseLimitInput);
                    _SItem.MaximumLength = GlobFuncs.GetDataRowValue_Int(r, cColName.MaximumLength);
                    _SItem.UsePadOutput = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UsePadOutput);
                    _SItem.PadOutPut = (EPadOutPut)GlobFuncs.GetDataRowValue_Int(r, cColName.PadOutput);
                    _SItem.PadWith = (EPadWiths)GlobFuncs.GetDataRowValue_Int(r, cColName.PadWith);
                    _SItem.GroupingBracket = (EGroupingBracket)GlobFuncs.GetDataRowValue_Int(r, cColName.GroupingBracket);
                    _SItem.XYDelimiter = (EXYDelimiter)GlobFuncs.GetDataRowValue_Int(r, cColName.XYDelimiter);
                    _SItem.ElementDelimiter.DelimiterTypes = (EDelimiterTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.E_DelimiterType);
                    _SItem.ElementDelimiter.StandardValue = (EDelimiter)GlobFuncs.GetDataRowValue_Int(r, cColName.E_StandardValue);
                    _SItem.ElementDelimiter.CustomValue = GlobFuncs.GetDataRowValue_String(r, cColName.E_CustomValue);

                    _Action.StringBuilders.Add(_SItem);
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool OpenActionLinkPassFail(cAction _Action)
        {
            _Action.LinkPassFail = new List<cLinkPassFail>();
            if (LinkPassFail == null)
                return true;

            foreach (DataRow r in _LinkPassFail.Rows)
            {
                cLinkPassFail _Link = new cLinkPassFail();
                _Link.rtcActive = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Active);
                _Link.rtcIDref = GlobFuncs.GetDataRowValue_Guid(r, cColName.IDRef);
                _Link.rtcInvert = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Invert);
                _Link.rtcPropNameRef = GlobFuncs.GetDataRowValue_String(r, cColName.PropName);
                _Link.rtcRef = GlobFuncs.GetDataRowValue_String(r, cColName.Ref);
                _Link.rtcSTT = GlobFuncs.GetDataRowValue_Int(r, cColName.STT);
                _Action.LinkPassFail.Add(_Link);
            }
            return true;
        }
        public static bool OpenActionColumns(cAction action)
        {
            try
            {
                if (action.ActionType != EActionTypes.CsvWrite && 
                    action.ActionType != EActionTypes.CsvRead &&
                    action.ActionType != EActionTypes.ExcelWrite &&
                    action.ActionType != EActionTypes.ExcelRead)
                    return true;
                action.Columns = new List<cColumnProperty>();
                if (ColumnList == null)
                    return true;
                DataRow[] dataRows = ColumnList.Select(cColName.ActionID + "='" + action.ID.ToString() + "'");
                foreach (DataRow r in dataRows)
                {
                    cColumnProperty columnProperty = new cColumnProperty();
                    columnProperty.ID = GlobFuncs.GetDataRowValue_Guid(r, cColName.ID);
                    columnProperty.OrderNum = GlobFuncs.GetDataRowValue_Int(r, cColName.OrderNum);
                    columnProperty.Active = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Active);
                    columnProperty.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                    columnProperty.DataType = GlobFuncs.GetDataRowValue_String(r, cColName.DataType);
                    columnProperty.Format = GlobFuncs.GetDataRowValue_String(r, cColName.Format);
                    columnProperty.DisplayFormat = GlobFuncs.GetDataRowValue_String(r, cColName.DisplayFormat);
                    columnProperty.Value = GlobFuncs.GetDataRowValue_String(r, cColName.Value);
                    columnProperty.RefID = GlobFuncs.GetDataRowValue_Guid(r, cColName.RefID);
                    columnProperty.PropName = GlobFuncs.GetDataRowValue_String(r, cColName.PropName);
                    columnProperty.Ref = GlobFuncs.GetDataRowValue_String(r, cColName.Ref);
                    action.Columns.Add(columnProperty);
                }

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public static bool OpenActionList(cGroupActions _Group, string _GroupFileName)
        {
            try
            {
                if (ActionList == null)
                    return false;
                bool Result = true;

                _Group.Actions = new Dictionary<Guid, cAction>();
                cAction action = null;

                DataRow[] _GroupActions = _ActionList.Select(cColName.GroupID + "='" + _Group.ID.ToString() + "'");

                List<double> dict = null;
                _Group.FileNameIconic = System.IO.Path.GetDirectoryName(_GroupFileName) +
                    System.IO.Path.DirectorySeparatorChar +
                    System.IO.Path.GetFileNameWithoutExtension(_GroupFileName) + cExtFile.GroupIconicD;
                //if (_Group.FileNameIconic != "" && System.IO.File.Exists(_Group.FileNameIconic))
                //    try
                //    {
                //        HOperatorSet.ReadDict(_Group.FileNameIconic, new HTuple(), new HTuple(), out dict);
                //    }
                //    catch
                //    {
                //        dict = null;
                //    }

                foreach (DataRow item in _GroupActions)
                {
                    action = new cAction((EActionTypes)GlobFuncs.GetDataRowValue_Int(item, cColName.ActionType),
                        (EObjectTypes)GlobFuncs.GetDataRowValue_Int(item, cColName.ObjectType), _Group.frmHsmartWindow, _Group);
                    action.ID = GlobFuncs.GetDataRowValue_Guid(item, cColName.ID);
                    action.STT = GlobFuncs.GetDataRowValue_Int(item, cColName.STT);
                    action.Name.rtcValue = GlobFuncs.GetDataRowValue_String(item, cColName.Name);

                    Result = OpenActionSettings(action);
                    if (Result) Result = OpenActionROIs(action);
                    if (Result) Result = OpenActionFindROIs(action);
                    if (Result && action.ActionType == EActionTypes.PassFail) Result = OpenActionLinkPassFail(action);
                    if (Result && action.ActionType == EActionTypes.StringBuilder) Result = OpenStringBuilderItems(action);
                    if (Result) Result = OpenActionROIProperties(action);
                    if (Result) Result = OpenActionLinkProperty(action);
                    if (Result) Result = OpenActionColumns(action);

                    if (Result && (action.ActionType == EActionTypes.PassFail || action.ActionType == EActionTypes.ResetTool)) Result = OpenActionLinkPassFail(action);
                    if (Result &&
                        (action.ActionType == EActionTypes.StringBuilder ||
                         action.ActionType == EActionTypes.Switch ||
                         action.ActionType == EActionTypes.BranchItem ||
                         //action.ActionType == EActionTypes.DataInstance ||
                         action.ActionType == EActionTypes.Branch))
                        Result = OpenStringBuilderItems(action);
                    if (Result && action.ActionType == EActionTypes.Count)
                        action.StartNumber.rtcValue = action.KeepValueToNextSession.rtcValue
                            ? action.StartNumber.rtcValue
                            : action.ResetNumber.rtcValue;

                    if (Result)
                    {
                        action.Pattern_ROITrain_Find = true;
                        action.Blob_ROITrain_Roi = true;
                        action.Brightness_ROITrain_ROI = true;
                        action.ImageSplit_ROITrain_ROI = true;
                        action.PixelCount_ROITrain_ROI = true;

                        if (action.ShapeList != null && action.TabRoiActive != null)
                            action.TabRoiActive.rtcValue = false;
                        if (action.FindShapeList != null && action.TabPassActive != null)
                            action.TabPassActive.rtcValue = false;
                        if (action.TrainPressed != null) action.TrainPressed.rtcValue = false;
                    }

                    if (!Result) return false;

                    if (dict != null)
                    {
                        var orderedProperty = action.GetType().GetProperties().Where(
                        x => ((RTCVariableType)x.GetValue(action, null)) != null &&
                        ((RTCVariableType)x.GetValue(action, null)).rtcSaveToFile).ToList();
                        PropertyInfo nProperty;
                        for (int i = 0; i < orderedProperty.Count; i++)
                        {
                            nProperty = orderedProperty[i];
                            RTCVariableType rtcvar = (RTCVariableType)action.GetType().GetProperty(nProperty.Name).GetValue(action, null);

                            //if (dict == null) HOperatorSet.CreateDict(out dict);
                            //switch (nProperty.PropertyType.Name)
                            //{
                            //    case nameof(SHTuple):
                            //        HOperatorSet.GetDictTuple(dict, nProperty.Name + action.ID.ToString(), out HTuple val);
                            //        ((SHTuple)rtcvar).rtcValue = val;
                            //        break;
                            //    case nameof(SHImage):
                            //        HOperatorSet.GetDictObject(out HObject obj, dict, nProperty.Name + action.ID.ToString());
                            //        ((SHImage)rtcvar).rtcValue = (HImage)obj;
                            //        break;
                            //    case nameof(SHRegion):
                            //        HOperatorSet.GetDictObject(out HObject reg, dict, nProperty.Name + action.ID.ToString());
                            //        ((SHRegion)rtcvar).rtcValue = (HRegion)reg;
                            //        break;
                            //    case nameof(SHXLDCont):
                            //        HOperatorSet.GetDictObject(out HObject cont, dict, nProperty.Name + action.ID.ToString());
                            //        ((SHXLDCont)rtcvar).rtcValue = (HXLDCont)cont;
                            //        break;
                            //    default:
                            //        break;
                            //}
                        }
                    }
                    //if(dict!=null && action.ActionType==EActionTypes.Pattern)
                    //{
                    //    HOperatorSet.GetDictTuple(dict, nameof(action.InputModelID) + action.ID.ToString(), out HTuple val);
                    //    action.InputModelID.rtcValue = val;
                    //}
                    if (_Group.frmHsmartWindow != null)
                        action.WindowHandle.rtcValue = _Group.frmHsmartWindow.SmartWindow;
                    else if (_Group.SmartWindowControl != null)
                        action.WindowHandle.rtcValue = _Group.SmartWindowControl;
                    _Group.Actions.Add(action.ID, action);
                }
                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        #endregion

        #region CLONE FUNCTIONS
        public static cAction Clone_Action(cAction _Action, bool _WithConnect = true)
        {
            cAction _ActionR = null;

            try
            {
                if (_WithConnect)
                    if (!Connect()) return _Action; // Trường hợp không clone được thì tạm thời gán thẳng.

                if (_Action.ShapeListOriginal != null && _Action.ShapeListOriginal.rtcValue.Count > 0)
                    _Action.ROIs = ShapeListToDictionaryROI(_Action.ShapeListOriginal.rtcValue);
                if (_Action.FindShapeListOriginal != null && _Action.FindShapeListOriginal.rtcValue.Count > 0)
                    _Action.FindROIs = ShapeListToDictionaryROI(_Action.FindShapeListOriginal.rtcValue);

                bool Result = SaveActionSettings(_Action);
                if (Result) Result = SaveActionROIs(_Action);
                if (Result) Result = SaveActionFindROIs(_Action);
                if (Result && _Action.ActionType == EActionTypes.PassFail) Result = SaveActionLinkPassFail(_Action);
                if (Result) Result = SaveActionROIProperties(_Action);
                if (Result) Result = SaveActionLinkProperty(_Action);
                if (Result) Result = SaveActionColumns(_Action);

                if (Result)
                {
                    _ActionR = new cAction(_Action.ActionType, _Action.ObjectType, _Action.frmHsmartWindow, _Action.MyGroup);
                    _ActionR.ID = _Action.ID;
                    Result = OpenActionSettings(_ActionR);
                    if (Result) Result = OpenActionROIs(_ActionR);
                    if (Result) Result = OpenActionFindROIs(_ActionR);
                    if (Result && _Action.ActionType == EActionTypes.PassFail) Result = OpenActionLinkPassFail(_ActionR);
                    if (Result) Result = OpenActionROIProperties(_ActionR);
                    if (Result) Result = OpenActionLinkProperty(_ActionR);
                    if (Result) Result = OpenActionColumns(_ActionR);
                }

                return _ActionR;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return _Action;
            }
            finally
            {
                if (_WithConnect) Disconnect();
            }
        }

        public static cROIProperty Clone_ROIProperties(cROIProperty _ROISrc, bool _WithConnect = true)
        {
            cROIProperty _ROIDes = null;

            try
            {
                if (_WithConnect)
                    if (!Connect()) return _ROISrc; // Trường hợp không clone được thì tạm thời gán thẳng.

                bool Result = SaveActionROIProperties(_ROISrc);
                if (Result)
                {
                    _ROIDes = new cROIProperty(_ROISrc.ActionType, _ROISrc.ID);
                    Result = OpenActionROIProperties(_ROIDes);
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return _ROISrc;
            }
            finally
            {
                if (_WithConnect) Disconnect();
            }
            return _ROIDes;
        }
        #endregion
        #endregion
    }
}
