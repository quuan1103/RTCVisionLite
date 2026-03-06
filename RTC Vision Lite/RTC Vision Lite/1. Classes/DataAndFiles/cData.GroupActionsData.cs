using MathNet.Numerics.Distributions;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public class GroupActionsData
    {
        public string DataFileName = string.Empty;
        public cSQLite Myconn = null;
        private bool isNotFixIsCanReset = true;
        private int _dataVersion = -1;
        public bool IsHaveLevel = true;
        public object lockdata = new object();
        #region PROPERTY
        private DataTable _GroupList = null;
        private DataTable _ActionList = null;
        private DataTable _ActionSettings = null;
        public DataTable GroupList
        {
            get
            {
                if (_GroupList == null) _GroupList = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.GroupList);

                if (_GroupList != null)
                {
                    if (!_GroupList.Columns.Contains(cColName.CurrentPart_R1))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.GroupList, cColName.CurrentPart_R1, "INT");
                        _GroupList.Columns.Add(cColName.CurrentPart_R1, typeof(int));
                    }
                    if (!_GroupList.Columns.Contains(cColName.CurrentPart_R2))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.GroupList, cColName.CurrentPart_R2, "INT");
                        _GroupList.Columns.Add(cColName.CurrentPart_R2, typeof(int));
                    }
                    if (!_GroupList.Columns.Contains(cColName.CurrentPart_C1))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.GroupList, cColName.CurrentPart_C1, "INT");
                        _GroupList.Columns.Add(cColName.CurrentPart_C1, typeof(int));
                    }
                    if (!_GroupList.Columns.Contains(cColName.CurrentPart_C2))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.GroupList, cColName.CurrentPart_C2, "INT");
                        _GroupList.Columns.Add(cColName.CurrentPart_C2, typeof(int));
                    }
                    if (!_GroupList.Columns.Contains(cColName.EnableSnap))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.GroupList, cColName.EnableSnap, "TEXT");
                        _GroupList.Columns.Add(cColName.EnableSnap, typeof(string));
                    }
                    if (!_GroupList.Columns.Contains(cColName.MasterImage))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.GroupList, cColName.MasterImage, "TEXT");
                        _GroupList.Columns.Add(cColName.MasterImage, typeof(string));
                    }
                    if (!_GroupList.Columns.Contains(cColName.DefaultImageSourceType))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.GroupList, cColName.DefaultImageSourceType, "INT");
                        Myconn.ExecuteQuery($"UPDATE {cTableName_SaveTemplate.GroupList} SET {cColName.DefaultImageSourceType} = 999");
                        _GroupList.Columns.Add(cColName.DefaultImageSourceType, typeof(int));
                        foreach (DataRow row in _GroupList.Rows)
                            row[cColName.DefaultImageSourceType] = (int)EImageSourceTypes.None;
                    }
                    if (!_GroupList.Columns.Contains(cColName.IsLockMoveTool))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.GroupList, cColName.IsLockMoveTool, "TEXT");
                        _GroupList.Columns.Add(cColName.IsLockMoveTool, typeof(string));
                    }
                    _GroupList.TableName = cTableName_SaveTemplate.GroupList;
                    _GroupList.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _GroupList.Columns[cColName.ID];
                    _GroupList.PrimaryKey = keys;
                }
                return _GroupList;
            }
            set
            {
                _GroupList = value;
            }
        }
        private DataTable _ComputerSettings = null;
        public DataTable ComputerSettings
        {
            get
            {
                if (_ComputerSettings == null) _ComputerSettings = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ComputerSettings);

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
        public DataTable ActionList
        {
            get
            {
                if (_ActionList == null) _ActionList = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ActionList);
                if (_ActionList != null)
                {
                    if (!_ActionList.Columns.Contains(cColName.IDBranch))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ActionList, cColName.IDBranch, "TEXT");
                        _ActionList.Columns.Add(cColName.IDBranch, typeof(string));
                    }
                    if (!_ActionList.Columns.Contains(cColName.IDBranchItem))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ActionList, cColName.IDBranchItem, "TEXT");
                        _ActionList.Columns.Add(cColName.IDBranchItem, typeof(string));
                    }
                    _ActionList.TableName = cTableName_SaveTemplate.ActionList;
                    _ActionList.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _ActionList.Columns[cColName.ID];
                    _ActionList.PrimaryKey = keys;
                }
                return _ActionList;
            }
            set
            {
                _ActionList = value;
            }
        }

        private DataTable _CameraSettings = null;
        /// <summary>
        /// Bảng camera setting
        /// </summary>
        public DataTable CameraSettings
        {
            get
            {

                if (_CameraSettings == null) _CameraSettings = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.CameraSettings);

                if (_CameraSettings != null)
                {
                    if (!_CameraSettings.Columns.Contains(cColName.RTCPropName))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.CameraSettings, cColName.RTCPropName, "TEXT");
                        _CameraSettings.Columns.Add(cColName.RTCPropName, typeof(string));
                    }
                    if (!_CameraSettings.Columns.Contains(cColName.ActionID))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.CameraSettings, cColName.ActionID, "TEXT");
                        _CameraSettings.Columns.Add(cColName.ActionID, typeof(string));
                    }
                    foreach (DataRow dataRow in _CameraSettings.Rows)
                        if (dataRow[cColName.ActionID] == DBNull.Value)
                            dataRow[cColName.ActionID] = Guid.Empty.ToString();

                    _CameraSettings.TableName = cTableName_SaveTemplate.CameraSettings;
                    _CameraSettings.Columns[cColName.GroupID].Caption = cColName.KEY;
                    _CameraSettings.Columns[cColName.ActionID].Caption = cColName.KEY;
                    _CameraSettings.Columns[cColName.PropName].Caption = cColName.KEY;
                    var keys = new DataColumn[3];
                    keys[0] = _CameraSettings.Columns[cColName.GroupID];
                    keys[1] = _CameraSettings.Columns[cColName.ActionID];
                    keys[2] = _CameraSettings.Columns[cColName.PropName];
                    _CameraSettings.PrimaryKey = keys;
                }
                return _CameraSettings;
            }
            set { _CameraSettings = value; }
        }
        private DataTable _imageFilterList = null;
        /// <summary>
        /// Bảng ROIs
        /// </summary>
        public DataTable ImageFilterList
        {
            get
            {
                if (!Myconn.IsTableExists(cTableName_SaveTemplate.ImageFilterList))
                {

                    Myconn.ExecuteQuery("CREATE TABLE 'ImageFilterList'(" +
                    "'ActionID'  TEXT," +
                    "'ID'    TEXT," +
                    "'OrderNum'    INTEGER," +
                    "'Active'    TEXT," +
                    "'FilterType'    TEXT, " +
                    "'MaskWidth' INTEGER," +
                    "'MaskHeight'    INTEGER, " +
                    "'Iterations'    INTEGER," +
                    "'ThresholdRange'    TEXT," +
                    "'GrayValue'    TEXT," +
                    "'InRangeOutputPixel'    INTEGER, " +
                    "'OutRangeOutputPixel'   INTEGER," +
                    "'Margin'    TEXT," +
                    "'IDRefRegion'   TEXT," +
                    "'PropNameRefRegion' TEXT," +
                    "PRIMARY KEY('ID'))");
                }

                if (_imageFilterList == null)
                    _imageFilterList = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ImageFilterList + " ORDER BY ActionID, OrderNum");

                if (_imageFilterList != null)
                {
                    if (!_imageFilterList.Columns.Contains(cColName.GrayValue))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ImageFilterList, cColName.GrayValue, "TEXT");
                        _imageFilterList.Columns.Add(cColName.GrayValue, typeof(string));
                    }
                    _imageFilterList.TableName = cTableName_SaveTemplate.ImageFilterList;
                }
                return _imageFilterList;
            }
            set => _imageFilterList = value;
        }



        private DataTable _camInfo = null;
        /// <summary>
        /// Bảng CAMList
        /// </summary>
        public DataTable CamInfo
        {
            get
            {
                if (!Myconn.Connect())
                    return null;

                if (_camInfo == null) _camInfo = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.Info);

                if (_camInfo != null)
                    _camInfo.TableName = cTableName_SaveTemplate.Info;
                return _camInfo;
            }
            set { _camInfo = value; }
        }

        public DataTable ActionSettings
        {
            get
            {
                if (_ActionSettings == null) _ActionSettings = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ActionSettings);
                if (_ActionSettings != null)
                {
                    if (!_ActionSettings.Columns.Contains(cColName.rtcDisplay))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ActionSettings, cColName.rtcDisplay, "TEXT");
                        _ActionSettings.Columns.Add(cColName.rtcDisplay, typeof(string));
                    }
                    if (!_ActionSettings.Columns.Contains(cColName.rtcDisplayValueInHistory))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ActionSettings, cColName.rtcDisplayValueInHistory, "TEXT");
                        _ActionSettings.Columns.Add(cColName.rtcDisplayValueInHistory, typeof(string));
                    }
                    if (!_ActionSettings.Columns.Contains(cColName.ParentIDResets))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ActionSettings, cColName.ParentIDResets, "TEXT");
                        _ActionSettings.Columns.Add(cColName.ParentIDResets, typeof(string));
                    }
                    if (!_ActionSettings.Columns.Contains(cColName.rtcResetWhenStart))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ActionSettings, cColName.rtcResetWhenStart, "TEXT");
                        _ActionSettings.Columns.Add(cColName.rtcResetWhenStart, typeof(string));
                    }
                    if (!_ActionSettings.Columns.Contains(cColName.rtcResetWhenStop))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ActionSettings, cColName.rtcResetWhenStop, "TEXT");
                        _ActionSettings.Columns.Add(cColName.rtcResetWhenStop, typeof(string));
                    }
                    if (!_ActionSettings.Columns.Contains(cColName.rtcRefIndex))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ActionSettings, cColName.rtcRefIndex, "TEXT");
                        _ActionSettings.Columns.Add(cColName.rtcRefIndex, typeof(string));
                    }
                    if (!_ActionSettings.Columns.Contains(cColName.rtcIsHighLight))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ActionSettings, cColName.rtcIsHighLight, "TEXT");
                        _ActionSettings.Columns.Add(cColName.rtcIsHighLight, typeof(string));
                    }
                    if (!_ActionSettings.Columns.Contains(cColName.rtcSaveToFileConfig))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ActionSettings, cColName.rtcSaveToFileConfig, "TEXT");
                        _ActionSettings.Columns.Add(cColName.rtcSaveToFileConfig, typeof(string));
                    }
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



        private DataTable _SourceImages = null;
        /// <summary>
        /// Bảng FindROIs
        /// </summary>
        public DataTable SourceImages
        {
            get
            {
                if (_SourceImages == null)
                    _SourceImages = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.SourceImages + " ORDER BY STT");

                if (_SourceImages != null)
                    _SourceImages.TableName = cTableName_SaveTemplate.SourceImages;
                return _SourceImages;
            }
            set { _SourceImages = value; }
        }
        private DataTable _Trigger = null;
        /// <summary>
        /// Bảng chứa thông số Trigger
        /// </summary>
        public DataTable Trigger
        {
            get
            {
                if (_Trigger == null) _Trigger = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.Trigger);

                if (_Trigger != null)
                {
                    _Trigger.TableName = cTableName_SaveTemplate.Trigger;
                    _Trigger.Columns[cColName.GroupID].Namespace = cColName.KEY;
                    _Trigger.Columns[cColName.PropName].Namespace = cColName.KEY;

                    var keys = new DataColumn[2];
                    keys[0] = _Trigger.Columns[cColName.GroupID];
                    keys[1] = _Trigger.Columns[cColName.PropName];
                    _Trigger.PrimaryKey = keys;
                }
                return _Trigger;
            }
            set { _Trigger = value; }
        }
        private DataTable _Info = null;
        /// <summary>
        /// Bảng chứa chú thích của property
        /// </summary>
        public DataTable Info
        {
            get
            {
                if (_Info == null)
                {
                    if (!Myconn.IsTableExists(cTableName_SaveTemplate.Info))
                    {
                        Myconn.ExecuteQuery("CREATE TABLE 'Info' (" +
                                            "'Name'  TEXT," +
                                            "'Value' TEXT," +
                                            "PRIMARY KEY('Name'))");
                    }
                    _Info = Myconn.GetDataTable("SELECT * FROM Info");
                    if (_Info != null)
                    {
                        _Info.TableName = cTableName_SaveTemplate.Info;
                        var keys = new DataColumn[1];
                        keys[0] = _Info.Columns[cColName.Name];
                        _Info.PrimaryKey = keys;
                    }
                }
                return _Info;
            }
            set => _Info = value;
        }



        private DataTable _ROIProperties = null;
        /// <summary>
        /// Bảng FindROIs
        /// </summary>
        public DataTable ROIProperties
        {
            get
            {
                if (_ROIProperties == null) _ROIProperties = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ROIProperties);

                if (_ROIProperties != null)
                {
                    if (!_ROIProperties.Columns.Contains(cColName.rtcIDRef))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIProperties, cColName.rtcIDRef, "TEXT");
                        _ROIProperties.Columns.Add(cColName.rtcIDRef, typeof(string));
                    }
                    if (!_ROIProperties.Columns.Contains(cColName.rtcRef))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIProperties, cColName.rtcRef, "TEXT");
                        _ROIProperties.Columns.Add(cColName.rtcRef, typeof(string));
                    }
                    if (!_ROIProperties.Columns.Contains(cColName.rtcPropNameRef))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIProperties, cColName.rtcPropNameRef, "TEXT");
                        _ROIProperties.Columns.Add(cColName.rtcPropNameRef, typeof(string));
                    }
                    if (!_ROIProperties.Columns.Contains(cColName.rtcIsParent))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIProperties, cColName.rtcIsParent, "TEXT");
                        _ROIProperties.Columns.Add(cColName.rtcIsParent, typeof(string));
                    }
                    if (!_ROIProperties.Columns.Contains(cColName.rtcRefIndex))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIProperties, cColName.rtcRefIndex, "TEXT");
                        _ROIProperties.Columns.Add(cColName.rtcRefIndex, typeof(string));
                    }
                    if (!_ROIProperties.Columns.Contains(cColName.rtcSaveToFileConfig))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIProperties, cColName.rtcSaveToFileConfig, "TEXT");
                        _ROIProperties.Columns.Add(cColName.rtcSaveToFileConfig, typeof(string));
                    }
                    if (!_ROIProperties.Columns.Contains(cColName.GID))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIProperties, cColName.GID, "TEXT");
                        _ROIProperties.Columns.Add(cColName.GID, typeof(string));
                    }
                    _ROIProperties.TableName = cTableName_SaveTemplate.ROIProperties;
                    _ROIProperties.Columns[cColName.ActionID].Namespace = cColName.KEY;
                    _ROIProperties.Columns[cColName.ID].Namespace = cColName.KEY;
                    _ROIProperties.Columns[cColName.PropName].Namespace = cColName.KEY;

                    var keys = new DataColumn[3];
                    keys[0] = _ROIProperties.Columns[cColName.ActionID];
                    keys[1] = _ROIProperties.Columns[cColName.ID];
                    keys[2] = _ROIProperties.Columns[cColName.PropName];
                    _ROIProperties.PrimaryKey = keys;
                }
                return _ROIProperties;
            }
            set { _ROIProperties = value; }
        }

        private DataTable _columnList = null;
        /// <summary>
        /// Bảng ROIs
        /// </summary>
        public DataTable ColumnList
        {
            get
            {
                if (!Myconn.IsTableExists(cTableName_SaveTemplate.ColumnList))
                {
                    Myconn.ExecuteQuery("CREATE TABLE 'ColumnList' (" +
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
                                        "'IsRowToCol'    TEXT," +
                                        "'SortMode'    TEXT," +
                                        "'Ref'   TEXT)");
                }

                if (_columnList == null)
                    _columnList = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ColumnList + " ORDER BY ActionID, OrderNum");
                if (_columnList != null)
                {
                    if (!_columnList.Columns.Contains(cColName.IsRowToCol))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ColumnList, cColName.IsRowToCol, "TEXT");
                        _columnList.Columns.Add(cColName.IsRowToCol, typeof(string));
                    }

                    if (!_columnList.Columns.Contains(cColName.SortMode))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ColumnList, cColName.SortMode, "TEXT");
                        _columnList.Columns.Add(cColName.SortMode, typeof(string));
                        foreach (DataRow row in _columnList.Rows)
                            row[cColName.SortMode] = cSortMode.None;
                    }
                    _columnList.TableName = cTableName_SaveTemplate.ColumnList;
                }
                return _columnList;

            }
            set { _columnList = value; }
        }

        //public bool SaveActionColumns(cAction action)
        //{
        //    //try
        //    //{
        //    //    if (ColumnList == null)
        //    //        return false;
        //    //    if (action.Columns == null || action.Columns.Count <= 0)
        //    //        return true;
        //    //    bool result = false;
        //    //    foreach (cColumnProperty columnProperty in action.Columns)
        //    //    {
        //    //        DataRow r = ColumnList.NewRow();
        //    //        SetNullValueToDataRow(r);
        //    //        r[cColName.ID] = columnProperty.ID;
        //    //        r[cColName.ActionID] = action.ID;
        //    //        r[cColName.OrderNum] = columnProperty.OrderNum;

        //    //        r[cColName.Active] = columnProperty.Active;
        //    //        r[cColName.Name] = columnProperty.Name;
        //    //        r[cColName.DataType] = columnProperty.DataType;
        //    //        r[cColName.Format] = columnProperty.Format;
        //    //        r[cColName.DisplayFormat] = columnProperty.DisplayFormat;
        //    //        r[cColName.Value] = columnProperty.Value;
        //    //        r[cColName.RefID] = columnProperty.RefId;
        //    //        r[cColName.PropName] = columnProperty.PropName;
        //    //        r[cColName.Ref] = columnProperty.Ref;
        //    //        r[cColName.IsRowToCol] = columnProperty.IsRowToCol;
        //    //        r[cColName.SortMode] = columnProperty.SortMode;

        //    //        result = MyConn.AddRow(r);

        //    //        if (!result) break;
        //    //    }

        //    //    return result;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    GlobFuncs.SaveErr(ex);
        //    //    return false;
        //    //}
        //}

        private DataTable _FindROIs = null;
        /// <summary>
        /// Bảng FindROIs
        /// </summary>
        public DataTable FindROIs
        {
            get
            {
                if (_FindROIs == null) _FindROIs = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.FindROIs);

                if (_FindROIs != null)
                {
                    if (!_FindROIs.Columns.Contains(cColName.IsDisplayOutput))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.FindROIs, cColName.IsDisplayOutput, "TEXT");
                        _FindROIs.Columns.Add(cColName.IsDisplayOutput, typeof(string));
                    }
                    if (!_FindROIs.Columns.Contains(cColName.RoiType))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.FindROIs, cColName.RoiType, "INT");
                        _FindROIs.Columns.Add(cColName.RoiType, typeof(int));
                    }
                    if (!_FindROIs.Columns.Contains(cColName.Name))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.FindROIs, cColName.Name, "TEXT");
                        _FindROIs.Columns.Add(cColName.Name, typeof(string));
                    }
                    if (!_FindROIs.Columns.Contains(cColName.MarkID))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.FindROIs, cColName.MarkID, "TEXT");
                        _FindROIs.Columns.Add(cColName.MarkID, typeof(string));
                    }
                    if (!_FindROIs.Columns.Contains(cColName.MasterID))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.FindROIs, cColName.MasterID, "TEXT");
                        _FindROIs.Columns.Add(cColName.MasterID, typeof(string));
                    }
                    if (!_FindROIs.Columns.Contains(cColName.RoiLegend))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.FindROIs, cColName.RoiLegend, "INT");
                        _FindROIs.Columns.Add(cColName.RoiLegend, typeof(int));
                    }
                    _FindROIs.TableName = cTableName_SaveTemplate.FindROIs;
                }
                return _FindROIs;
            }
            set { _FindROIs = value; }
        }

        private DataTable _ROIs = null;
        /// <summary>
        /// Bảng ROIs
        /// </summary>
        public DataTable ROIs
        {
            get
            {
                if (_ROIs == null) _ROIs = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ROIs);

                if (_ROIs != null)
                {
                    if (!_ROIs.Columns.Contains(cColName.IsDisplayOutput))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIs, cColName.IsDisplayOutput, "TEXT");
                        _ROIs.Columns.Add(cColName.IsDisplayOutput, typeof(string));
                    }
                    if (!_ROIs.Columns.Contains(cColName.RoiType))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIs, cColName.RoiType, "INT");
                        _ROIs.Columns.Add(cColName.RoiType, typeof(int));
                    }
                    if (!_ROIs.Columns.Contains(cColName.Name))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIs, cColName.Name, "TEXT");
                        _ROIs.Columns.Add(cColName.Name, typeof(string));
                    }
                    if (!_ROIs.Columns.Contains(cColName.MarkID))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIs, cColName.MarkID, "TEXT");
                        _ROIs.Columns.Add(cColName.MarkID, typeof(string));
                    }
                    if (!_ROIs.Columns.Contains(cColName.MasterID))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIs, cColName.MasterID, "TEXT");
                        _ROIs.Columns.Add(cColName.MasterID, typeof(string));
                    }
                    if (!_ROIs.Columns.Contains(cColName.RoiLegend))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.ROIs, cColName.RoiLegend, "INT");
                        _ROIs.Columns.Add(cColName.RoiLegend, typeof(int));
                    }
                    _ROIs.TableName = cTableName_SaveTemplate.ROIs;
                }
                return _ROIs;
            }
            set { _ROIs = value; }
        }

        private DataTable _LinkProperty = null;
        /// <summary>
        /// Bảng ROIs
        /// </summary>
        public DataTable LinkProperty
        {
            get
            {
                if (!Myconn.IsTableExists(cTableName_SaveTemplate.LinkProperty))
                {
                    Myconn.ExecuteQuery("CREATE TABLE 'LinkProperty' (" +
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
                    _LinkProperty = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.LinkProperty + " ORDER BY ActionID, OrderNum");
                if (_LinkProperty != null)
                    _LinkProperty.TableName = cTableName_SaveTemplate.LinkProperty;
                return _LinkProperty;
            }
            set { _LinkProperty = value; }
        }
        private DataTable _StringBuilderItems = null;
        public DataTable StringBuilderItems
        {
            get
            {
                if (_StringBuilderItems == null) _StringBuilderItems = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.StringBuilderItems + " ORDER BY ActionID, OrderNum");

                if (_StringBuilderItems != null)
                {
                    if (!_StringBuilderItems.Columns.Contains(cColName.IsCanReset))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.StringBuilderItems, cColName.IsCanReset, "TEXT");
                        _StringBuilderItems.Columns.Add(cColName.IsCanReset, typeof(string));
                        foreach (DataRow row in _StringBuilderItems.Rows)
                            row[cColName.IsCanReset] = bool.FalseString.ToLower();
                    }
                    if (!_StringBuilderItems.Columns.Contains(cColName.IsParent))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.StringBuilderItems, cColName.IsParent, "TEXT");
                        _StringBuilderItems.Columns.Add(cColName.IsParent, typeof(string));
                        foreach (DataRow row in _StringBuilderItems.Rows)
                            row[cColName.IsParent] = bool.FalseString.ToLower();
                    }
                    if (!_StringBuilderItems.Columns.Contains(cColName.RefIndex))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.StringBuilderItems, cColName.RefIndex, "TEXT");
                        _StringBuilderItems.Columns.Add(cColName.RefIndex, typeof(string));
                    }
                    if (!_StringBuilderItems.Columns.Contains(cColName.Leading))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.StringBuilderItems, cColName.Leading, "TEXT");
                        _StringBuilderItems.Columns.Add(cColName.Leading, typeof(string));
                    }
                    if (!_StringBuilderItems.Columns.Contains(cColName.Tralling))
                    {
                        Myconn.AddCol(cTableName_SaveTemplate.StringBuilderItems, cColName.Tralling, "TEXT");
                        _StringBuilderItems.Columns.Add(cColName.Tralling, typeof(string));
                    }
                    _StringBuilderItems.TableName = cTableName_SaveTemplate.StringBuilderItems;
                }
                return _StringBuilderItems;
            }
            set => _StringBuilderItems = value;
        }
        private static DataTable _LinkPassFail = null;
        /// <summary>
        /// Bảng FindROIs
        /// </summary>
        public DataTable LinkPassFail
        {
            get
            {
                if (_LinkPassFail == null)
                {
                    _LinkPassFail =
                        Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.LinkPassFail + " ORDER BY STT");

                    if (_LinkPassFail != null)
                    {
                        if (!_LinkPassFail.Columns.Contains(cColName.ActionID))
                        {
                            Myconn.AddCol(cTableName_SaveTemplate.LinkPassFail, cColName.ActionID, "TEXT");
                            _LinkPassFail.Columns.Add(cColName.ActionID, typeof(string));
                        }
                        if (!_LinkPassFail.Columns.Contains(cColName.ParentIDResets))
                        {
                            Myconn.AddCol(cTableName_SaveTemplate.LinkPassFail, cColName.ParentIDResets, "TEXT");
                            _LinkPassFail.Columns.Add(cColName.ParentIDResets, typeof(string));
                        }
                        if (!_LinkPassFail.Columns.Contains(cColName.GetResult))
                        {
                            Myconn.AddCol(cTableName_SaveTemplate.LinkPassFail, cColName.GetResult, "TEXT");
                            _LinkPassFail.Columns.Add(cColName.GetResult, typeof(string));
                        }
                        if (!_LinkPassFail.Columns.Contains(cColName.IDGetResult))
                        {
                            Myconn.AddCol(cTableName_SaveTemplate.LinkPassFail, cColName.IDGetResult, "TEXT");
                            _LinkPassFail.Columns.Add(cColName.IDGetResult, typeof(string));
                        }

                        _LinkPassFail.TableName = cTableName_SaveTemplate.LinkPassFail;
                    }
                }
                return _LinkPassFail;
            }
            set { _LinkPassFail = value; }
        }
        #endregion
        #region FUNCTION
        public bool Connect(string _DataFileName, bool ReadOnly = false)
        {
            try
            {
                DataFileName = _DataFileName;
                Myconn = new cSQLite(DataFileName, ReadOnly);
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

                return Myconn.Connect();


            }
            catch
            {
                return false;
            }
        }
        public void Disconnect()
        {
            if (Myconn != null && Myconn.IsConnected)
            {
                Myconn.Close();
            }
            Myconn = null;
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

        public bool ClearAllData()
        {
            try
            {
                if (!Myconn.IsConnected)
                    return false;

                return Myconn.DeleteDataMultiTable(new string[] {   cTableName_SaveTemplate.ActionList,
                                                                    cTableName_SaveTemplate.ActionSettings,
                                                                    cTableName_SaveTemplate.CameraSettings,
                                                                    cTableName_SaveTemplate.ComputerSettings,
                                                                    cTableName_SaveTemplate.CAMList,
                                                                    cTableName_SaveTemplate.GroupList,
                                                                    cTableName_SaveTemplate.ProjectList,
                                                                    cTableName_SaveTemplate.ProjectSetting,
                                                                    cTableName_SaveTemplate.SourceImages,
                                                                    cTableName_SaveTemplate.ROIs,
                                                                    cTableName_SaveTemplate.FindROIs,
                                                                    cTableName_SaveTemplate.LinkPassFail,
                                                                    cTableName_SaveTemplate.ROIProperties,
                                                                    cTableName_SaveTemplate.StringBuilderItems,
                                                                    cTableName_SaveTemplate.Communications,
                                                                    cTableName_SaveTemplate.TCPIPSettings,
                                                                    cTableName_SaveTemplate.LinkProperty,
                                                                    cTableName_SaveTemplate.ImageFilterList,
                                                                    cTableName_SaveTemplate.Info,
                                                                    cTableName_SaveTemplate.ColumnList,
                                                                    cTableName_SaveTemplate.ManualDeviceCameraList,
                                                                    cTableName_SaveTemplate.Trigger
                });
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        #region FUNCTION SAVE DATA
        private bool SaveActionLinkProperty(cAction _Action)
        {
            try
            {
                if (LinkProperty == null)
                    return false;
                if (_Action.LinkProperty == null || _Action.LinkProperty.Count <= 0)
                    return true;
                bool Result = false;
                foreach (cLinkProperty linkItem in _Action.LinkProperty)
                {
                    DataRow r = LinkProperty.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.ID] = linkItem.ID;
                    r[cColName.ActionID] = _Action.ID;
                    r[cColName.OrderNum] = linkItem.OrderNum;

                    r[cColName.SourceCamID] = linkItem.SourceCamID;
                    r[cColName.SourceID] = linkItem.SourceID;
                    r[cColName.SourceName] = linkItem.SourceName;
                    r[cColName.SourceIndex] = GlobFuncs.ListObject2StrWithType(linkItem.SourceIndex);

                    r[cColName.TargetCamID] = linkItem.TargetCamID;
                    r[cColName.TargetID] = linkItem.TargetID;
                    r[cColName.TargetName] = linkItem.TargetName;
                    r[cColName.TargetIndex] = GlobFuncs.ListObject2StrWithType(linkItem.TargetIndex);

                    Result = Myconn.AddRow(r);

                    if (!Result) break;
                }

                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
            return true;
        }

        private bool SaveActionSettings_CameraSettings(cAction _Action)
        {
            try
            {
                if (_Action.ActionType != EActionTypes.CameraSettings || _Action.CameraSettings == null)
                    return true;

                if (CameraSettings == null)
                    return false;
                bool Result = false;

                PropertyInfo[] pCameraSettings = _Action.CameraSettings.GetType().GetProperties();
                foreach (PropertyInfo item in pCameraSettings)
                {
                    DataRow r = _CameraSettings.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.GroupID] = _Action.MyGroup.ID;
                    r[cColName.ActionID] = _Action.ID.ToString();
                    r[cColName.PropName] = item.Name;

                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            r[cColName.ValueT] = item.GetValue(_Action.CameraSettings, null).ToString();
                            break;
                        case "Boolean":
                            r[cColName.ValueT] = item.GetValue(_Action.CameraSettings, null).ToString().ToLower();
                            break;
                        case "Int32":
                            r[cColName.ValueI] = (int)item.GetValue(_Action.CameraSettings, null);
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                List<string> obj = (List<string>)item.GetValue(_Action.CameraSettings, null);
                                r[cColName.ValueT] = string.Join(",", obj.ToArray());
                            }
                            break;
                        default:
                            continue;
                    }

                    Result = Myconn.AddRow(r);
                    if (!Result) break;
                }

                if (_Action.CameraSettings.PropCompareDefault != null)
                    foreach (cPropCompare item in _Action.CameraSettings.PropCompareDefault.Values)
                    {
                        DataRow r = _CameraSettings.NewRow();
                        SetNullValueToDataRow(r);
                        r[cColName.GroupID] = _Action.MyGroup.ID;
                        r[cColName.ActionID] = _Action.ID.ToString();
                        r[cColName.PropName] = cStrings.PropCompareDefaultWithDot + item.PropCAMName;
                        r[cColName.RTCPropName] = cStrings.PropCompareDefaultWithDot + item.RTCPropCAMName;
                        if (item.DataType.Name == typeof(string).Name)
                            r[cColName.ValueT] = item.SValue;
                        else
                            r[cColName.ValueD] = item.DValue;

                        Result = Myconn.AddRow(r);
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

        private bool SaveActionSettings(cAction _Action)
        {
            try
            {
                try
                {
                    if (ActionSettings == null)
                        return false;
                    bool Result = false;
                    if (_Action.AreaActual != null)
                        _Action.AreaActual.rtcValue = new List<double>();
                    if (_Action.WidthActual != null)
                        _Action.WidthActual.rtcValue = new List<double>();
                    if (_Action.HeightActual != null)
                        _Action.HeightActual.rtcValue = new List<double>();
                    if (_Action.OuterRadiusActual != null)
                        _Action.OuterRadiusActual.rtcValue = new List<double>();
                    if (_Action.CircularityActual != null)
                        _Action.CircularityActual.rtcValue = new List<double>();
                    if (_Action.RectangularityActual != null)
                        _Action.RectangularityActual.rtcValue = new List<double>();
                    if (_Action.ColumnActual != null)
                        _Action.ColumnActual.rtcValue = new List<double>();
                    if (_Action.RowActual != null)
                        _Action.RowActual.rtcValue = new List<double>();

                    //Lấy toàn bộ properties của action này
                    var orderedProperty = _Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(_Action, null)) != null).ToList();

                    PropertyInfo nProperty;
                    for (int i = 0; i < orderedProperty.Count; i++)
                    {
                        nProperty = orderedProperty[i];
                        RTCVariableType rtcvar = (RTCVariableType)_Action.GetType().GetProperty(nProperty.Name).GetValue(_Action, null);

                        PropertyInfo rtcvarValue = nProperty.PropertyType.GetProperty(cPropertyName.rtcValue);
                        DataRow r = _ActionSettings.NewRow();
                        SetNullValueToDataRow(r);
                        r[cColName.ActionID] = _Action.ID;
                        r[cColName.PropName] = nProperty.Name;
                        r[cColName.rtcIsParent] = rtcvar.rtcIsParent.ToString().ToLower();
                        r[cColName.rtcIDRef] = rtcvar.rtcIDRef;
                        r[cColName.rtcPropNameRef] = rtcvar.rtcPropNameRef;
                        r[cColName.rtcRef] = rtcvar.rtcRef;
                        r[cColName.rtcValueView] = rtcvar.rtcValueView;
                        r[cColName.rtcValueViewFull] = rtcvar.rtcValueViewFull;
                        r[cColName.rtcDisplay] = rtcvar.rtcDisplay.ToString().ToLower();
                        r[cColName.rtcDisplayValueInHistory] = rtcvar.rtcDisplayValueInHistory.ToString().ToLower();
                        r[cColName.rtcIsCanReset] = rtcvar.rtcIsCanReset.ToString().ToLower();
                        r[cColName.rtcResetWhenStart] = rtcvar.rtcResetWhenStart.ToString().ToLower();
                        r[cColName.rtcResetWhenStop] = rtcvar.rtcResetWhenStop.ToString().ToLower();
                        r[cColName.ParentIDResets] = GlobFuncs.ListGuid2String(rtcvar.ParentIDResets, cChars.Comma);
                        r[cColName.rtcRefIndex] = rtcvar.rtcRefIndex;
                        r[cColName.rtcIsHighLight] = rtcvar.rtcIsHighLight.ToString().ToLower();
                        r[cColName.rtcSaveToFileConfig] = rtcvar.rtcSaveToFileConfig.ToString().ToLower();

                        if (!rtcvar.rtcSaveToFile)
                        {
                            object obj = rtcvarValue.GetValue(rtcvar, null);
                            switch (nProperty.PropertyType.Name)
                            {
                                case nameof(SBool):
                                    r[cColName.ValueT] = obj.ToString().ToLower();
                                    break;
                                case nameof(SWindow):
                                    break;
                                case nameof(SImage):
                                    break;
                                case nameof(SListDouble):
                                    r[cColName.ValueH] = GlobFuncs.ListDouble2StrWithType((List<double>)obj);
                                    break;
                                case nameof(SListString):
                                    r[cColName.ValueH] = GlobFuncs.ListString2StrWithType((List<string>)obj);
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
                                case nameof(SLong):
                                    r[cColName.ValueL] = (long)obj;
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

                        Result = Myconn.AddRow(r);

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
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool SaveGroup(cGroupActions _Group)
        {
            try
            {
                if (GroupList == null)
                    return false;

                DataRow r = _GroupList.NewRow();
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
                r[cColName.IsLockMoveTool] = _Group.IsLockMoveTool.ToString().ToLower();

                if (_Group.CurrentPart_R1 != null)
                    r[cColName.CurrentPart_R1] = GlobFuncs.HTEToI(_Group.CurrentPart_R1);
                if (_Group.CurrentPart_R2 != null)
                    r[cColName.CurrentPart_R2] = GlobFuncs.HTEToI(_Group.CurrentPart_R2);
                if (_Group.CurrentPart_C1 != null)
                    r[cColName.CurrentPart_C1] = GlobFuncs.HTEToI(_Group.CurrentPart_C1);
                if (_Group.CurrentPart_C2 != null)
                    r[cColName.CurrentPart_C2] = GlobFuncs.HTEToI(_Group.CurrentPart_C2);


                GroupList.Rows.Add(r);
                return Myconn.AddRow(r);
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool SaveGroup_SourceImages(cGroupActions _Group)
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
                    DataRow r = _SourceImages.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.STT] = STT;
                    r[cColName.FileName] = _Image.FileName;
                    r[cColName.Passed] = _Image.Passed;
                    r[cColName.Ran] = _Image.Ran;
                    Result = Myconn.AddRow(r);
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
        public bool SaveActionImageFilterList(cAction _Action)
        {
            try
            {
                if (ImageFilterList == null)
                    return false;
                if (_Action.ImageFilterProperty == null || _Action.ImageFilterProperty.Count <= 0)
                    return true;
                bool Result = false;
                foreach (cImageFilterProperty filterProperty in _Action.ImageFilterProperty)
                {
                    DataRow r = _imageFilterList.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.ActionID] = _Action.ID;
                    r[cColName.ID] = filterProperty.ID;
                    r[cColName.OrderNum] = filterProperty.OrderNum;
                    r[cColName.Active] = filterProperty.Active;
                    r[cColName.FilterType] = filterProperty.FilterType;
                    r[cColName.MaskWidth] = filterProperty.MaskWidth;
                    r[cColName.MaskHeight] = filterProperty.MaskHeight;
                    r[cColName.Iterations] = filterProperty.Iterations;
                    r[cColName.ThresholdRange] = GlobFuncs.ListDouble2StrWithType(filterProperty.ThresholdRange.rtcValue);
                    r[cColName.GrayValue] = GlobFuncs.ListDouble2StrWithType(filterProperty.GrayValue.rtcValue);
                    r[cColName.InRangeOutputPixel] = filterProperty.InRangeOutputPixel;
                    r[cColName.OutRangeOutputPixel] = filterProperty.OutRangeOutputPixel;
                    r[cColName.Margin] = filterProperty.Margin;
                    r[cColName.IDRefRegion] = filterProperty.IDRefRegion;
                    r[cColName.PropNameRefRegion] = filterProperty.PropNameRefRegion;
                    Result = Myconn.AddRow(r);
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
        public bool SaveGroup_CameraSettings(cGroupActions _Group)
        {
            try
            {
                if (CameraSettings == null)
                    return false;
                bool Result = false;

                PropertyInfo[] pCameraSettings = _Group.SourceImageSettings.CameraSettings.GetType().GetProperties();
                foreach (PropertyInfo item in pCameraSettings)
                {
                    DataRow r = _CameraSettings.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.GroupID] = _Group.ID;
                    r[cColName.ActionID] = Guid.Empty.ToString();
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
                        case "ESdkModes":
                            {
                                r[cColName.ValueI] = (int)item.GetValue(_Group.SourceImageSettings.CameraSettings, null);
                                break;
                            }
                        default:
                            continue;
                    }

                    Result = Myconn.AddRow(r);
                    if (!Result) break;
                }

                if (_Group.SourceImageSettings.CameraSettings.PropCompareDefault != null)
                    foreach (cPropCompare item in _Group.SourceImageSettings.CameraSettings.PropCompareDefault.Values)
                    {
                        DataRow r = _CameraSettings.NewRow();
                        SetNullValueToDataRow(r);
                        r[cColName.GroupID] = _Group.ID;
                        r[cColName.ActionID] = Guid.Empty.ToString();
                        r[cColName.PropName] = cStrings.PropCompareDefaultWithDot + item.PropCAMName;
                        r[cColName.RTCPropName] = cStrings.PropCompareDefaultWithDot + item.RTCPropCAMName;
                        if (item.DataType.Name == typeof(string).Name)
                            r[cColName.ValueT] = item.SValue;
                        else
                            r[cColName.ValueD] = item.DValue;

                        Result = Myconn.AddRow(r);
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

        public bool SaveGroup_Trigger(cGroupActions _Group)
        {
            try
            {
                if (Trigger == null)
                    return true;
                var Triggerprops = _Group.SourceImageSettings.Trigger.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in Triggerprops)
                {
                    DataRow r = Trigger.NewRow();
                    SetNullValueToDataRow(r);

                    r[cColName.GroupID] = _Group.ID.ToString();
                    r[cColName.PropName] = propertyInfo.Name;
                    object obj = propertyInfo.GetValue(_Group.SourceImageSettings.Trigger, null);
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case "Boolean":
                            r[cColName.ValueT] = obj.ToString().ToLower();
                            break;
                        case "ETriggerType":
                            r[cColName.ValueI] = (ETriggerType)obj;
                            break;
                        case "ETriggerMode":
                            r[cColName.ValueI] = (ETriggerMode)obj;
                            break;
                        case "Parity":
                            r[cColName.ValueI] = (Parity)obj;
                            break;
                        case "StopBits":
                            r[cColName.ValueI] = (StopBits)obj;
                            break;
                        case "EPLCReadType":
                            r[cColName.ValueI] = (EPLCReadType)obj;
                            break;
                        //case "ControllerTypeConst":
                        //    r[cColName.ValueI] = (ControllerTypeConst)obj;
                        //    break;
                        case "String":
                            r[cColName.ValueT] = obj.ToString();
                            break;
                        case "Int32":
                            r[cColName.ValueI] = int.Parse(obj.ToString());
                            break;
                        default:
                            break;
                    }
                    if (!Myconn.AddRow(r)) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }

            //try
            //{
            //    if (Trigger == null)
            //        return false;

            //    DataRow r = _Trigger.NewRow();
            //    SetNullValueToDataRow(r);
            //    r[cColName.GroupID] = groupActions.ID;
            //    r[cColName.TriggerMode] = groupActions.SourceImageSettings.Trigger.TriggerMode;
            //    r[cColName.TriggerType] = groupActions.SourceImageSettings.Trigger.TriggerType;
            //    r[cColName.COMName] = groupActions.SourceImageSettings.Trigger.COMName;
            //    r[cColName.IP] = groupActions.SourceImageSettings.Trigger.IP;
            //    r[cColName.Port] = groupActions.SourceImageSettings.Trigger.Port;
            //    r[cColName.TriggerValue] = groupActions.SourceImageSettings.Trigger.TriggerValue;
            //    if (!MyConn.AddRow(r)) return false;

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    GlobFuncs.SaveErr(ex);
            //    return false;
            //}
        }

        public bool SaveGroup_Info(cGroupActions _Group)
        {
            try
            {
                if (Info == null)
                    return true;
                DataRow r = Info.NewRow();
                r[cColName.Name] = cStrings.Version;
                r[cColName.Value] = GlobVar.Version;
                if (!Myconn.AddRow(r)) return false;

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }

            //try
            //{
            //    if (Trigger == null)
            //        return false;

            //    DataRow r = _Trigger.NewRow();
            //    SetNullValueToDataRow(r);
            //    r[cColName.GroupID] = groupActions.ID;
            //    r[cColName.TriggerMode] = groupActions.SourceImageSettings.Trigger.TriggerMode;
            //    r[cColName.TriggerType] = groupActions.SourceImageSettings.Trigger.TriggerType;
            //    r[cColName.COMName] = groupActions.SourceImageSettings.Trigger.COMName;
            //    r[cColName.IP] = groupActions.SourceImageSettings.Trigger.IP;
            //    r[cColName.Port] = groupActions.SourceImageSettings.Trigger.Port;
            //    r[cColName.TriggerValue] = groupActions.SourceImageSettings.Trigger.TriggerValue;
            //    if (!MyConn.AddRow(r)) return false;

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    GlobFuncs.SaveErr(ex);
            //    return false;
            //}
        }
        public bool SaveActionList(cGroupActions _Group)
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
                        DataRow r = _ActionList.NewRow();
                        r[cColName.ID] = action.ID;
                        r[cColName.IDBranch] = action.IDBranch;
                        r[cColName.IDBranchItem] = action.IDBranchItem;
                        r[cColName.GroupID] = _Group.ID;
                        r[cColName.STT] = action.STT;
                        r[cColName.Name] = action.Name.rtcValue;
                        r[cColName.ActionType] = action.ActionType;
                        r[cColName.ObjectType] = action.ObjectType;
                        r[cColName.Level] = action.Level;

                        Result = Myconn.AddRow(r);

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

                        #region MyRegion

                        //TODO: Tạm REM lại để xem lại phần này vì sao lại phải lấy ROIs từ đây ra vì mặc nhiên ROIs được lưu trữ
                        // trong mảng ROIs
                        //if (action.ShapeListOriginal != null && action.ShapeListOriginal.rtcValue.Length > 0)
                        //    action.ROIs = ShapeListToDictionaryROI(action.ShapeListOriginal.rtcValue);
                        //if (action.FindShapeListOriginal != null && action.FindShapeListOriginal.rtcValue.Length > 0)
                        //    action.FindROIs = ShapeListToDictionaryROI(action.FindShapeListOriginal.rtcValue);
                        //Phần lưu multi task
                        //List<Task<bool>> lstTask = new List<Task<bool>>();
                        //lstTask.Add(Task.Factory.StartNew(() => SaveActionSettings(action)));
                        //lstTask.Add(Task.Factory.StartNew(() => SaveActionLinkProperty(action)));
                        //lstTask.Add(Task.Factory.StartNew(() => SaveActionROIs(action)));
                        //lstTask.Add(Task.Factory.StartNew(() => SaveActionFindROIs(action)));
                        //lstTask.Add(Task.Factory.StartNew(() => SaveActionROIProperties(action)));
                        //if (action.ActionType == EActionTypes.PassFail || action.ActionType == EActionTypes.ResetTool)
                        //    lstTask.Add(Task.Factory.StartNew(() => SaveActionLinkPassFail(action)));
                        //if (action.ActionType == EActionTypes.StringBuilder ||
                        //    action.ActionType == EActionTypes.Branch ||
                        //    action.ActionType == EActionTypes.BranchItem ||
                        //    action.ActionType == EActionTypes.Switch)
                        //    lstTask.Add(Task.Factory.StartNew(() => SaveDataAsStringBuilderType(action)));
                        //Task t = Task.WhenAll(lstTask);
                        //try
                        //{
                        //    t.Wait();
                        //}
                        //catch { }
                        //Result = lstTask.All(tr => tr.Result);
                        /////////////////////////////////////////////////////////////////////////////////////////////
                        // bool Result1 = Result;
                        // bool Result2 = Result;

                        // List<Task> lstTask = new List<Task>();

                        // Task task = Task.Factory.StartNew(() =>
                        // {
                        //     if (Result) Result = SaveActionSettings(action);
                        // }
                        // );
                        // lstTask.Add(task);

                        // task = Task.Factory.StartNew(() =>
                        // {
                        //     if (Result1) Result1 = SaveActionLinkProperty(action);
                        //     if (Result1) Result1 = SaveActionROIs(action);
                        //     if (Result1) Result1 = SaveActionFindROIs(action);
                        //     if (Result1) Result1 = SaveActionROIProperties(action);
                        // }
                        // );

                        // lstTask.Add(task);

                        // task = Task.Factory.StartNew(() =>
                        // {
                        //     if (Result2 && (action.ActionType == EActionTypes.PassFail || action.ActionType == EActionTypes.ResetTool))
                        //         Result2 = SaveActionLinkPassFail(action);
                        //     if (Result2 &&
                        //         (action.ActionType == EActionTypes.StringBuilder ||
                        //         action.ActionType == EActionTypes.Branch ||
                        //         action.ActionType == EActionTypes.BranchItem ||
                        //         action.ActionType == EActionTypes.Switch))
                        //         Result2 = SaveDataAsStringBuilderType(action);
                        // }
                        //);

                        // lstTask.Add(task);

                        // Task t = Task.WhenAll(lstTask);
                        // try
                        // {
                        //     t.Wait();
                        // }
                        // catch { }
                        // if (!Result || !Result1 || !Result2) break;
                        //Phần này để đây để khi cần debug

                        #endregion

                        if (Result) Result = SaveActionSettings(action);
                        if (Result) Result = SaveActionSettings_CameraSettings(action);
                        if (Result) Result = SaveActionLinkProperty(action);
                        if (Result) Result = SaveActionImageFilterList(action);
                        if (Result) Result = SaveActionROIs(action);
                        if (Result) Result = SaveActionFindROIs(action);
                        if (Result) Result = SaveActionColumns(action);
                        if (Result && (action.ActionType == EActionTypes.PassFail || action.ActionType == EActionTypes.ResetTool)) Result = SaveActionLinkPassFail(action);
                        if (Result &&
                            (action.ActionType == EActionTypes.StringBuilder ||
                            action.ActionType == EActionTypes.Branch ||
                            action.ActionType == EActionTypes.BranchItem ||
                            action.ActionType == EActionTypes.Switch))
                            Result = SaveDataAsStringBuilderType(action);
                        if (Result) Result = SaveActionROIProperties(action);

                        if (!Result) break;
                    }
                    finally
                    {
                        if (ROIBak != null) action.ROIs = ROIBak.ToDictionary(x => x.Key, x => x.Value);
                        if (FindROIBak != null) action.FindROIs = FindROIBak.ToDictionary(x => x.Key, x => x.Value);
                    }
                }

                //if(dict!=null)
                //{
                //    groupActions.FileNameIconic = System.IO.Path.GetDirectoryName(_GroupFileName) + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileNameWithoutExtension(_GroupFileName) +cExtFile.GroupIconicD;
                //    HOperatorSet.WriteDict(dict, groupActions.FileNameIconic, new HTuple(), new HTuple());
                //}

                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool SaveActionLinkPassFail(cAction _Action)
        {
            try
            {
                if (LinkPassFail == null)
                    return false;
                switch (_Action.ActionType)
                {
                    case EActionTypes.PassFail:
                        {
                            if (_Action.LinkPassFail == null) return true;
                            foreach (cLinkPassFail _Link in _Action.LinkPassFail)
                            {
                                DataRow r = LinkPassFail.NewRow();
                                SetNullValueToDataRow(r);
                                r[cColName.ActionID] = _Action.ID;
                                r[cColName.Active] = _Link.rtcActive;
                                r[cColName.STT] = _Link.rtcSTT;
                                r[cColName.IDRef] = _Link.rtcIDref.ToString();
                                r[cColName.PropName] = _Link.rtcPropNameRef;
                                r[cColName.Ref] = _Link.rtcRef;
                                r[cColName.Invert] = _Link.rtcInvert;
                                r[cColName.GetResult] = _Link.rtcGetResult;
                                r[cColName.IDGetResult] = _Link.rtcIDGetResult;
                                if (!Myconn.AddRow(r)) return false;
                            }

                            break;
                        }
                    case EActionTypes.ResetTool:
                        {
                            if (_Action.ListResetTools == null) return true;
                            foreach (cLinkPassFail _Link in _Action.ListResetTools)
                            {
                                DataRow r = LinkPassFail.NewRow();
                                SetNullValueToDataRow(r);
                                r[cColName.ActionID] = _Action.ID;
                                r[cColName.Active] = _Link.rtcActive;
                                r[cColName.STT] = _Link.rtcSTT;
                                r[cColName.IDRef] = _Link.rtcIDref.ToString();
                                r[cColName.PropName] = _Link.rtcPropNameRef;
                                r[cColName.Ref] = _Link.rtcRef;
                                r[cColName.Invert] = _Link.rtcInvert;
                                r[cColName.GetResult] = _Link.rtcGetResult;
                                r[cColName.IDGetResult] = _Link.rtcIDGetResult;
                                if (!Myconn.AddRow(r)) return false;
                            }

                            break;
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

        private bool SaveActionFindROIs(cAction _Action)
        {
            try
            {
                if (FindROIs == null)
                    return false;
                if (_Action.FindROIs == null) return true;
                foreach (object item in _Action.FindROIs.Values)
                {
                    DataRow r = _FindROIs.NewRow();
                    cDrawingBaseType ROI = (cDrawingBaseType)item;
                    r[cColName.ID] = ROI.ID;
                    r[cColName.Name] = ROI.Name;
                    r[cColName.MarkID] = GlobFuncs.ListDouble2Str(ROI.MarkID);
                    r[cColName.MasterID] = ROI.MasterID;
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

                    if (!Myconn.AddRow(r)) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool SaveActionROIs(cAction _Action)
        {
            try
            {
                if (ROIs == null)
                    return false;
                if (_Action.ROIs == null) return true;

                foreach (object item in _Action.ROIs.Values)
                {
                    DataRow r = _ROIs.NewRow();
                    cDrawingBaseType ROI = (cDrawingBaseType)item;
                    r[cColName.ID] = ROI.ID;
                    r[cColName.Name] = ROI.Name;
                    r[cColName.MarkID] = GlobFuncs.ListDouble2Str(ROI.MarkID);
                    r[cColName.MasterID] = ROI.MasterID;
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

                    if (!Myconn.AddRow(r)) return false;
                }

                switch (_Action.ActionType)
                {
                    case EActionTypes.Pattern:
                        {
                            if (_Action.PlacementMode.rtcValue == cPlacementMode.WherePlacedOnImage &&
                                _Action.ReferencePointRectangle != null)
                            {
                                DataRow r = _ROIs.NewRow();
                                cDrawingBaseType ROI = (cDrawingBaseType)_Action.ReferencePointRectangle;
                                r[cColName.ID] = ROI.ID;
                                r[cColName.ActionID] = _Action.ID;
                                r[cColName.X] = ROI.Center.Col;
                                r[cColName.Y] = ROI.Center.Row;
                                r[cColName.Z] = ROI.Center.Z;
                                r[cColName.DrawingType] = ROI.DrawingType;
                                r[cColName.ConnectType] = ROI.ConnectType;
                                r[cColName.AnimationType] = ROI.AnimationType;
                                r[cColName.IsDisplayOutput] = ROI.IsDisplayOutPut.ToString().ToLower();
                                r[cColName.Phi] = ((cRectangType)_Action.ReferencePointRectangle).Phi;
                                r[cColName.Length1] = ((cRectangType)_Action.ReferencePointRectangle).Width;
                                r[cColName.Length2] = ((cRectangType)_Action.ReferencePointRectangle).Height;

                                if (!Myconn.AddRow(r)) return false;
                            }
                            break;
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
        public bool SaveActionROIProperties(cAction _Action)
        {
            try
            {
                if (ROIProperties == null)
                    return true;
                if (_Action.ROIProperties == null) return true;
                foreach (cROIProperty ROIP in _Action.ROIProperties.Values)
                {
                    var ROIPprops = ROIP.GetType().GetProperties().Where(x => x != null && x.GetValue(ROIP, null) != null);
                    PropertyInfo propertyInfoValue = null;
                    foreach (PropertyInfo propertyInfo in ROIPprops)
                    {
                        RTCVariableType rtcvar = (RTCVariableType)ROIP.GetType().GetProperty(propertyInfo.Name).GetValue(ROIP, null);
                        DataRow r = _ROIProperties.NewRow();
                        SetNullValueToDataRow(r);

                        r[cColName.GID] = ROIP.GID.ToString();
                        r[cColName.ActionID] = _Action.ID.ToString();
                        r[cColName.ActionType] = _Action.ActionType;
                        r[cColName.ID] = ROIP.ID.ToString();
                        r[cColName.IDLink] = ROIP.IDLink.ToString();
                        r[cColName.rtcIDRef] = rtcvar.rtcIDRef.ToString();
                        r[cColName.rtcPropNameRef] = rtcvar.rtcPropNameRef;
                        r[cColName.rtcRef] = rtcvar.rtcRef;
                        r[cColName.rtcRefIndex] = rtcvar.rtcRefIndex;
                        r[cColName.rtcSaveToFileConfig] = rtcvar.rtcSaveToFileConfig;

                        propertyInfoValue = rtcvar.GetType().GetProperty(cPropertyName.rtcValue);

                        r[cColName.PropName] = propertyInfo.Name;

                        object obj = propertyInfoValue.GetValue(rtcvar, null);
                        switch (propertyInfo.PropertyType.Name)
                        {
                            case nameof(SBool):
                                r[cColName.ValueT] = obj.ToString().ToLower();
                                break;
                            //case nameof(SHWindow):
                            //    break;
                            case nameof(SImage):
                                break;
                            case nameof(SListDouble):
                                r[cColName.ValueH] = GlobFuncs.ListDouble2StrWithType((List<double>)obj);
                                break;
                            case nameof(SListString):
                                r[cColName.ValueH] = GlobFuncs.ListString2StrWithType((List<string>)obj);
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
                        if (!Myconn.AddRow(r)) return false;
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
        public bool SaveActionColumns(cAction action)
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
                    r[cColName.IsRowToCol] = columnProperty.IsRowToCol;
                    r[cColName.SortMode] = columnProperty.SortMode;

                    result = Myconn.AddRow(r);

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
        private bool SaveDataAsStringBuilderType(cAction action)
        {
            try
            {
                if (StringBuilderItems == null)
                    return false;

                switch (action.ActionType)
                {
                    case EActionTypes.StringBuilder:
                        return SaveStringBuilder(action);
                    case EActionTypes.Branch:
                        return SaveExpression(action);
                    case EActionTypes.BranchItem:
                        return SaveDataItems(action); 
                    case EActionTypes.Switch:
                        return SaveExpression(action);
                    //case EActionTypes.DataInstance:
                    //    return SaveDataItems(_Action);
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
        public bool SaveExpression(cAction action)
        {
            if (action.MyExpression.Operands == null) return true;

            foreach (SStringBuilderItem item in action.MyExpression.Operands)
            {
                DataRow r = _StringBuilderItems.NewRow();
                r[cColName.ActionID] = action.ID;
                r[cColName.OrderNum] = item.OrderNum;
                r[cColName.Name] = item.Name;
                r[cColName.RefID] = item.RefID;
                r[cColName.RefPropName] = item.RefPropName;
                r[cColName.Ref] = item.Ref;
                r[cColName.RefIndex] = item.RefIndex;
                r[cColName.IsCanReset] = item.IscanReset;
                r[cColName.IsParent] = item.IsParent;

                r[cColName.Value] = GlobFuncs.ListDouble2StrWithType(item.ListDoubleValue) == string.Empty ? GlobFuncs.ListString2StrWithType(item.ListStringValue) : GlobFuncs.ListDouble2StrWithType(item.ListDoubleValue);
                r[cColName.ValueView] = item.ValueView;
                r[cColName.ValueViewFull] = item.ValueViewFull;

                r[cColName.ValueStyle] = item.ValueStyle;
                r[cColName.TrueText] = item.TrueText;
                r[cColName.FalseText] = item.FalseText;
                r[cColName.DateFormat] = item.DateFormat;
                r[cColName.DelimiterDate] = item.DelimiterDate;
                r[cColName.TimeFormat] = item.TimeFormat;
                r[cColName.DelimiterTime] = item.DelimiterTime;
                r[cColName.UseDecimalPlaces] = item.UseDecimalPlaces;
                r[cColName.DecimalPlaces] = item.DecimalPlaces;
                r[cColName.UseMiniumLength] = item.UseMiniumLength;
                r[cColName.MiniumLength] = item.MiniumLength;
                r[cColName.UseLimitInput] = item.UseLimitInput;
                r[cColName.MaximumLength] = item.MaximumLength;
                r[cColName.UsePadOutput] = item.UsePadOutput;
                r[cColName.PadOutput] = item.PadOutPut;
                r[cColName.PadWith] = item.PadWith;
                r[cColName.GroupingBracket] = item.GroupingBracket;
                r[cColName.XYDelimiter] = item.XYDelimiter;
                r[cColName.E_DelimiterType] = item.ElementDelimiter.DelimiterTypes;
                r[cColName.E_StandardValue] = item.ElementDelimiter.StandardValue;
                r[cColName.E_CustomValue] = item.ElementDelimiter.CustomValue;
                if (!Myconn.AddRow(r)) return false;
            }

            return true;
        }

        public bool SaveStringBuilder(cAction action)
        {
            if (action.StringBuilders == null) return true;

            foreach (SStringBuilderItem item in action.StringBuilders)
            {
                DataRow r = _StringBuilderItems.NewRow();
                r[cColName.ActionID] = action.ID;
                r[cColName.OrderNum] = item.OrderNum;
                r[cColName.Name] = item.Name;
                r[cColName.RefID] = item.RefID;
                r[cColName.RefPropName] = item.RefPropName;
                r[cColName.Ref] = item.Ref;
                r[cColName.RefIndex] = item.RefIndex;
                r[cColName.IsCanReset] = item.IscanReset;
                r[cColName.IsParent] = item.IsParent;

                r[cColName.Value] = GlobFuncs.ListDouble2StrWithType(item.ListDoubleValue) == string.Empty ? GlobFuncs.ListString2StrWithType(item.ListStringValue) : GlobFuncs.ListDouble2StrWithType(item.ListDoubleValue);
                r[cColName.ValueView] = item.ValueView;
                r[cColName.ValueViewFull] = item.ValueViewFull;

                r[cColName.ValueStyle] = item.ValueStyle;
                r[cColName.TrueText] = item.TrueText;
                r[cColName.FalseText] = item.FalseText;
                r[cColName.DateFormat] = item.DateFormat;
                r[cColName.DelimiterDate] = item.DelimiterDate;
                r[cColName.TimeFormat] = item.TimeFormat;
                r[cColName.DelimiterTime] = item.DelimiterTime;
                r[cColName.UseDecimalPlaces] = item.UseDecimalPlaces;
                r[cColName.DecimalPlaces] = item.DecimalPlaces;
                r[cColName.UseMiniumLength] = item.UseMiniumLength;
                r[cColName.MiniumLength] = item.MiniumLength;
                r[cColName.UseLimitInput] = item.UseLimitInput;
                r[cColName.MaximumLength] = item.MaximumLength;
                r[cColName.UsePadOutput] = item.UsePadOutput;
                r[cColName.PadOutput] = item.PadOutPut;
                r[cColName.PadWith] = item.PadWith;
                r[cColName.GroupingBracket] = item.GroupingBracket;
                r[cColName.XYDelimiter] = item.XYDelimiter;
                r[cColName.E_DelimiterType] = item.ElementDelimiter.DelimiterTypes;
                r[cColName.E_StandardValue] = item.ElementDelimiter.StandardValue;
                r[cColName.E_CustomValue] = item.ElementDelimiter.CustomValue;
                r[cColName.Leading] = item.Leading;
                r[cColName.Tralling] = item.Tralling;
                if (!Myconn.AddRow(r)) return false;
            }

            return true;
        }
        public bool SaveDataItems(cAction action)
        {
            if (action.DataItems == null) return true;

            foreach (SStringBuilderItem item in action.DataItems)
            {
                DataRow r = _StringBuilderItems.NewRow();
                r[cColName.ActionID] = action.ID;
                r[cColName.OrderNum] = item.OrderNum;
                r[cColName.Name] = item.Name;
                r[cColName.RefID] = item.RefID;
                r[cColName.RefPropName] = item.RefPropName;
                r[cColName.Ref] = item.Ref;
                r[cColName.RefIndex] = item.RefIndex;
                r[cColName.IsCanReset] = item.IscanReset;
                r[cColName.IsParent] = item.IsParent;

                r[cColName.Value] = GlobFuncs.ListDouble2StrWithType(item.ListDoubleValue) == string.Empty ? GlobFuncs.ListString2StrWithType(item.ListStringValue) : GlobFuncs.ListDouble2StrWithType(item.ListDoubleValue);
                r[cColName.ValueView] = item.ValueView;
                r[cColName.ValueViewFull] = item.ValueViewFull;

                r[cColName.ValueStyle] = item.ValueStyle;
                r[cColName.TrueText] = item.TrueText;
                r[cColName.FalseText] = item.FalseText;
                r[cColName.DateFormat] = item.DateFormat;
                r[cColName.DelimiterDate] = item.DelimiterDate;
                r[cColName.TimeFormat] = item.TimeFormat;
                r[cColName.DelimiterTime] = item.DelimiterTime;
                r[cColName.UseDecimalPlaces] = item.UseDecimalPlaces;
                r[cColName.DecimalPlaces] = item.DecimalPlaces;
                r[cColName.UseMiniumLength] = item.UseMiniumLength;
                r[cColName.MiniumLength] = item.MiniumLength;
                r[cColName.UseLimitInput] = item.UseLimitInput;
                r[cColName.MaximumLength] = item.MaximumLength;
                r[cColName.UsePadOutput] = item.UsePadOutput;
                r[cColName.PadOutput] = item.PadOutPut;
                r[cColName.PadWith] = item.PadWith;
                r[cColName.GroupingBracket] = item.GroupingBracket;
                r[cColName.XYDelimiter] = item.XYDelimiter;
                r[cColName.E_DelimiterType] = item.ElementDelimiter.DelimiterTypes;
                r[cColName.E_StandardValue] = item.ElementDelimiter.StandardValue;
                r[cColName.E_CustomValue] = item.ElementDelimiter.CustomValue;
                if (!Myconn.AddRow(r)) return false;
            }

            return true;
        }
        public bool SaveActionWhenClone(cAction action)
        {
            bool bResult = false;
            try
            {
                bResult = Myconn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ActionSettings + " WHERE ActionID = '" +
                                           action.ID.ToString() + "'");
                if (bResult) bResult = Myconn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.LinkProperty + " WHERE ActionID = '" +
                                                          action.ID.ToString() + "'");
                if (bResult) bResult = Myconn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ROIs + " WHERE ActionID = '" +
                                                           action.ID.ToString() + "'");
                if (bResult) bResult = Myconn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.FindROIs + " WHERE ActionID = '" +
                                                           action.ID.ToString() + "'");
                if (bResult) bResult = Myconn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.LinkPassFail + " WHERE ActionID = '" +
                                                           action.ID.ToString() + "'");
                if (bResult) bResult = Myconn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.StringBuilderItems + " WHERE ActionID = '" +
                                                           action.ID.ToString() + "'");
                if (bResult) bResult = Myconn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ROIProperties + " WHERE ActionID = '" +
                                                           action.ID.ToString() + "'");
                if (bResult) bResult = Myconn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ImageFilterList + " WHERE ActionID = '" +
                                                           action.ID.ToString() + "'");

                if (bResult) bResult = SaveActionSettings(action);
                if (bResult) bResult = SaveActionLinkProperty(action);
                if (bResult) bResult = SaveActionLinkPassFail(action);
                if (bResult) bResult = SaveActionImageFilterList(action);
                if (bResult) bResult = SaveActionROIs(action);
                if (bResult) bResult = SaveActionFindROIs(action);
                if (bResult) bResult = SaveActionColumns(action);
                if (bResult &&
                    (action.ActionType == EActionTypes.StringBuilder ||
                     action.ActionType == EActionTypes.Branch ||
                     action.ActionType == EActionTypes.BranchItem ||
                     action.ActionType == EActionTypes.Switch))
                    bResult = SaveDataAsStringBuilderType(action);
                if (bResult) bResult = SaveActionROIProperties(action);

                #region TASK
                //List<Task> lstTask = new List<Task>();
                //List<bool> lstResult = new List<bool>();
                //lstTask.Add(Task.Factory.StartNew(() =>
                //    {
                //        lstResult.Add(SaveActionSettings(action));
                //    }
                //));
                //lstTask.Add(Task.Factory.StartNew(() =>
                //    {
                //        lstResult.Add(SaveActionLinkProperty(action));
                //    }
                //));
                //lstTask.Add(Task.Factory.StartNew(() =>
                //    {
                //        lstResult.Add(SaveActionImageFilterList(action));
                //    }
                //));
                //lstTask.Add(Task.Factory.StartNew(() =>
                //    {
                //        lstResult.Add(SaveActionROIs(action));
                //    }
                //));
                //lstTask.Add(Task.Factory.StartNew(() =>
                //    {
                //        lstResult.Add(SaveActionFindROIs(action));
                //    }
                //));

                //if (bResult &&
                //    (action.ActionType == EActionTypes.StringBuilder ||
                //     action.ActionType == EActionTypes.Branch ||
                //     action.ActionType == EActionTypes.BranchItem ||
                //     action.ActionType == EActionTypes.Switch))
                //    lstTask.Add(Task.Factory.StartNew(() =>
                //        {
                //            lstResult.Add(SaveDataAsStringBuilderType(action));
                //        }
                //    ));
                //lstTask.Add(Task.Factory.StartNew(() =>
                //    {
                //        lstResult.Add(SaveActionROIProperties(action));
                //    }
                //));
                //Task t = Task.WhenAll(lstTask);
                //try
                //{
                //    t.Wait();
                //}
                //catch { }
                #endregion

                return bResult;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        #endregion

        private void SetNullValueToDataRow(DataRow _Row)
        {
            foreach (DataColumn item in _Row.Table.Columns)
            {
                _Row[item] = DBNull.Value;
            }
        }



        #region FUNCTION OPEN DATA
        public bool OpenGroup(cGroupActions _Group)
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
                _Group.SourceImageSettings.MasterImage = GlobFuncs.GetDataRowValue_String(r, cColName.MasterImage);
                if (_GroupList.Columns.Contains(cColName.RunCount))
                    _Group.RunCount = GlobFuncs.GetDataRowValue_Int(r, cColName.RunCount);
                if (_GroupList.Columns.Contains(cColName.PassCount))
                    _Group.PassCount = GlobFuncs.GetDataRowValue_Int(r, cColName.PassCount);
                if (_GroupList.Columns.Contains(cColName.FailCount))
                    _Group.FailCount = GlobFuncs.GetDataRowValue_Int(r, cColName.FailCount);

                _Group.CurrentPart_R1 = null;
                _Group.CurrentPart_R2 = null;
                _Group.CurrentPart_C1 = null;
                _Group.CurrentPart_C2 = null;

                if (r[cColName.CurrentPart_R1] != DBNull.Value)
                    _Group.CurrentPart_R1 = new List<double>(GlobFuncs.GetDataRowValue_Int(r, cColName.CurrentPart_R1));

                if (r[cColName.CurrentPart_R2] != DBNull.Value)
                    _Group.CurrentPart_R2 = new List<double>(GlobFuncs.GetDataRowValue_Int(r, cColName.CurrentPart_R2));

                if (r[cColName.CurrentPart_C1] != DBNull.Value)
                    _Group.CurrentPart_C1 = new List<double>(GlobFuncs.GetDataRowValue_Int(r, cColName.CurrentPart_C1));

                if (r[cColName.CurrentPart_C2] != DBNull.Value)
                    _Group.CurrentPart_C2 = new List<double>(GlobFuncs.GetDataRowValue_Int(r, cColName.CurrentPart_C2));

                return true;
                //_Group.CurrentPart_R1 = null;
            }
            catch (Exception e)
            {
                GlobFuncs.SaveErr(e);
                return false;
            }
        }


        public bool OpenActionList(cGroupActions groupActions)
        {


            try
            {
                if (ActionList == null)
                    return false;
                bool result = true;
                groupActions.Actions = new Dictionary<Guid, cAction>();
                cAction action = null;
                var tasks = new List<Task>();
                foreach (DataRow item in _ActionList.Rows)
                {
                    action = new cAction((EActionTypes)GlobFuncs.GetDataRowValue_Int(item, cColName.ActionType),
                        (EObjectTypes)GlobFuncs.GetDataRowValue_Int(item, cColName.ObjectType), groupActions.frmHsmartWindow, groupActions);
                    //return true;

                    action.ID = GlobFuncs.GetDataRowValue_Guid(item, cColName.ID);
                    action.IDBranch = GlobFuncs.GetDataRowValue_Guid(item, cColName.IDBranch);
                    action.IDBranchItem = GlobFuncs.GetDataRowValue_Guid(item, cColName.IDBranchItem);
                    action.STT = GlobFuncs.GetDataRowValue_Int(item, cColName.STT);
                    action.Name.rtcValue = GlobFuncs.GetDataRowValue_String(item, cColName.Name);

                    result = OpenActionSettings(action);
                    if (result) result = OpenActionSettings_CameraSettings(action);
                    if (result) result = OpenActionLinkProperty(action);
                    if (result) result = OpenActionImageFilterList(action);
                    if (result) result = OpenActionROIs(action);
                    if (result) result = OpenActionFindROIs(action);
                    if (result) result = OpenActionColumns(action);
                    if (result)
                        switch (action.ActionType)
                        {
                            case EActionTypes.MainAction:
                                {
                                    action.ProgramMode.rtcValue = cProgramMode.Auto;
                                    action.ManualAction.rtcValue = cManualAction.None;
                                    break;
                                }
                            case EActionTypes.StringBuilder:
                                {
                                    result = OpenStringBuilderItems(action);
                                    break;
                                }
                            case EActionTypes.Switch:
                                {
                                    result = OpenStringBuilderItems(action);
                                    break;
                                }
                            case EActionTypes.BranchItem:
                                {
                                    result = OpenStringBuilderItems(action);
                                    break;
                                }
                            case EActionTypes.Branch:
                                {
                                    result = OpenStringBuilderItems(action);
                                    break;
                                }
                            case EActionTypes.CameraSettings:
                                {
                                    result = OpenStringBuilderItems(action);
                                    break;
                                }
                            case EActionTypes.Count:
                                {
                                    action.StartNumber.rtcValue = action.KeepValueToNextSession.rtcValue
                                                                    ? action.StartNumber.rtcValue
                                                                    : action.ResetNumber.rtcValue;
                                    break;

                                }
                            case EActionTypes.PassFail:
                                {
                                    result = OpenActionLinkPassFail(action);
                                    break;
                                }
                            case EActionTypes.ResetTool:
                                {
                                    result = OpenActionLinkPassFail(action);
                                    break;
                                }
                        }
                    if (result) OpenActionROIProperties(action);

                    if (result)
                    {
                        action.SetFlagTrainToDefault(false);

                        if (action.ShapeList != null && action.TabRoiActive != null)
                            action.TabRoiActive.rtcValue = false;
                        if (action.FindShapeList != null && action.TabPassActive != null)
                            action.TabPassActive.rtcValue = false;
                        if (action.TrainPressed != null) action.TrainPressed.rtcValue = false;
                    }
                    //Gen ShapeListOriginnal
                    foreach (object roi in action.ROIs.Values)
                    {
                        cDrawingBaseType Normal = null;
                        Normal = (cDrawingBaseType)roi;
                        switch (Normal.RoiType)
                        {
                            case ERoiTypes.Normal:
                                {
                                    if (Normal.ConnectType != EConnectTypes.None)
                                        continue;
                                    break;
                                }
                            case ERoiTypes.Mark:
                                {
                                    break;
                                }
                            case ERoiTypes.Master:
                                {
                                    continue;
                                }
                            default:
                                continue;
                        }
                        if (Normal.RoiType == ERoiTypes.Normal)
                            GlobFuncs.AddROIToShapeList(roi, action.ShapeList, 2);
                    }
                    try
                    {
                        if (groupActions.frmHsmartWindow != null)
                            action.WindowHandle.rtcValue = groupActions.frmHsmartWindow.SmartWindow;
                        else if (groupActions.SmartWindowControl != null)
                            action.WindowHandle.rtcValue = groupActions.SmartWindowControl;
                    }
                    catch (Exception ex)
                    {
                        GlobFuncs.SaveErr(ex);
                    }
                    groupActions.Actions.Add(action.ID, action);


                }
                return result;
            }


            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public async Task<bool> OpenActionListAsync(cGroupActions groupActions)
        {
            try
            {
                if (ActionList == null)
                    return false;

                bool overallResult = true;
                groupActions.Actions = new Dictionary<Guid, cAction>();

                int maxConcurrentTasks = 10; // Số luồng tối đa
                var semaphore = new SemaphoreSlim(maxConcurrentTasks);

                // Danh sách các Task hoàn thành
                var tasks = new List<Task<bool>>();

                foreach (DataRow item in _ActionList.Rows)
                {
                    await semaphore.WaitAsync();

                    // Thêm task vào danh sách

                    bool result = true;
                    try
                    {
                        var action = new cAction(
                            (EActionTypes)GlobFuncs.GetDataRowValue_Int(item, cColName.ActionType),
                            (EObjectTypes)GlobFuncs.GetDataRowValue_Int(item, cColName.ObjectType),
                            groupActions.frmHsmartWindow,
                            groupActions
                        );

                        action.ID = GlobFuncs.GetDataRowValue_Guid(item, cColName.ID);
                        action.IDBranch = GlobFuncs.GetDataRowValue_Guid(item, cColName.IDBranch);
                        action.IDBranchItem = GlobFuncs.GetDataRowValue_Guid(item, cColName.IDBranchItem);
                        action.STT = GlobFuncs.GetDataRowValue_Int(item, cColName.STT);
                        action.Name.rtcValue = GlobFuncs.GetDataRowValue_String(item, cColName.Name);
                        tasks.Add(Task.Run(async () =>
                        {
                            // Load các thiết lập và xử lý khác
                            result &= OpenActionSettings(action);
                            result &= OpenActionSettings_CameraSettings(action);
                            result &= OpenActionLinkProperty(action);
                            result &= OpenActionImageFilterList(action);
                            result &= OpenActionROIs(action);
                            result &= OpenActionFindROIs(action);
                            result &= OpenActionColumns(action);
                            if (result)
                            {
                                switch (action.ActionType)
                                {
                                    case EActionTypes.MainAction:
                                        action.ProgramMode.rtcValue = cProgramMode.Auto;
                                        action.ManualAction.rtcValue = cManualAction.None;
                                        break;
                                    case EActionTypes.StringBuilder:
                                    case EActionTypes.Switch:
                                    case EActionTypes.BranchItem:
                                    case EActionTypes.Branch:
                                    case EActionTypes.CameraSettings:
                                        result &= OpenStringBuilderItems(action);
                                        break;
                                    case EActionTypes.Count:
                                        action.StartNumber.rtcValue = action.KeepValueToNextSession.rtcValue
                                                                       ? action.StartNumber.rtcValue
                                                                       : action.ResetNumber.rtcValue;
                                        break;
                                    case EActionTypes.PassFail:
                                    case EActionTypes.ResetTool:
                                        result &= OpenActionLinkPassFail(action);
                                        break;
                                }
                                result &= OpenActionROIProperties(action);

                                action.SetFlagTrainToDefault(false);
                                if (action.ShapeList != null && action.TabRoiActive != null)
                                    action.TabRoiActive.rtcValue = false;
                                if (action.FindShapeList != null && action.TabPassActive != null)
                                    action.TabPassActive.rtcValue = false;
                                if (action.TrainPressed != null) action.TrainPressed.rtcValue = false;

                                foreach (object roi in action.ROIs.Values)
                                {
                                    if (roi is cDrawingBaseType Normal)
                                    {
                                        switch (Normal.RoiType)
                                        {
                                            case ERoiTypes.Normal when Normal.ConnectType == EConnectTypes.None:
                                                GlobFuncs.AddROIToShapeList(roi, action.ShapeList, 2);
                                                break;
                                            case ERoiTypes.Mark:
                                            case ERoiTypes.Master:
                                                break;
                                        }
                                    }
                                }

                                if (groupActions.frmHsmartWindow != null)
                                    action.WindowHandle.rtcValue = groupActions.frmHsmartWindow.SmartWindow;
                                else if (groupActions.SmartWindowControl != null)
                                    action.WindowHandle.rtcValue = groupActions.SmartWindowControl;
                            }

                            // Thêm `action` vào groupActions nếu thành công
                            if (result)
                            {
                                groupActions.Actions[action.ID] = action;
                            }
                            return result;
                        }));
                    }
                    catch (Exception ex)
                    {
                        GlobFuncs.SaveErr(ex);
                        result = false;
                    }
                    finally
                    {
                        semaphore.Release();
                        var tess = GlobVar.CurrentProject;
                    }


                }

                // Chờ tất cả các task hoàn thành và tổng hợp kết quả
                var results = await Task.WhenAll(tasks);
                overallResult = results.All(r => r); // Kiểm tra tất cả các kết quả
                return overallResult;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool OpenActionImageFilterList(cAction action)
        {
            try
            {
                if (action.ActionType != EActionTypes.ImageFilter)
                    return true;
                action.ImageFilterProperty = new List<cImageFilterProperty>();
                if (ImageFilterList == null)
                    return true;
                DataRow[] dataRows = _imageFilterList.Select(cColName.ActionID + "='" + action.ID.ToString() + "'");
                foreach (DataRow r in dataRows)
                {
                    cImageFilterProperty filterProperty = new cImageFilterProperty();
                    filterProperty.ID = GlobFuncs.GetDataRowValue_Guid(r, cColName.ID);
                    filterProperty.OrderNum = GlobFuncs.GetDataRowValue_Int(r, cColName.OrderNum);
                    filterProperty.Active = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Active);
                    filterProperty.FilterType = GlobFuncs.GetDataRowValue_String(r, cColName.FilterType);
                    filterProperty.MaskWidth = GlobFuncs.GetDataRowValue_Int(r, cColName.MaskWidth);
                    filterProperty.MaskHeight = GlobFuncs.GetDataRowValue_Int(r, cColName.MaskHeight);
                    filterProperty.Iterations = GlobFuncs.GetDataRowValue_Int(r, cColName.Iterations);
                    filterProperty.InRangeOutputPixel = GlobFuncs.GetDataRowValue_Int(r, cColName.InRangeOutputPixel);
                    filterProperty.OutRangeOutputPixel = GlobFuncs.GetDataRowValue_Int(r, cColName.OutRangeOutputPixel);
                    filterProperty.Margin = GlobFuncs.GetDataRowValue_String(r, cColName.Margin);
                    filterProperty.IDRefRegion = GlobFuncs.GetDataRowValue_Guid(r, cColName.IDRefRegion);
                    filterProperty.PropNameRefRegion = GlobFuncs.GetDataRowValue_String(r, cColName.PropNameRefRegion);
                    filterProperty.ThresholdRange.rtcValue = GlobFuncs.GetHTupleFromHTupleSaveData(GlobFuncs.GetDataRowValue_String(r, cColName.ThresholdRange));
                    filterProperty.GrayValue.rtcValue = GlobFuncs.GetHTupleFromHTupleSaveData(GlobFuncs.GetDataRowValue_String(r, cColName.GrayValue));
                    action.ImageFilterProperty.Add(filterProperty);
                }

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool OpenActionColumns(cAction action)
        {
            try
            {
                if (action.ActionType != EActionTypes.CsvWrite &&
                    action.ActionType != EActionTypes.CsvRead &&
                    action.ActionType != EActionTypes.ExcelRead &&
                    action.ActionType != EActionTypes.ExcelWrite)
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
                    columnProperty.IsRowToCol = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsRowToCol);
                    columnProperty.SortMode = GlobFuncs.GetDataRowValue_String(r, cColName.SortMode);

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

        public bool OpenActionFindROIs(cAction _Action)
        {
            try
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
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public bool OpenActionROIs(cAction _Action)
        {
            try
            {
                _Action.ROIs = new Dictionary<long, object>();
                if (ROIs == null)
                    return true;
                DataRow[] dataRows = _ROIs.Select(cColName.ActionID + "='" + _Action.ID.ToString() + "' AND " +
                                                  cColName.ConnectType + "<>" + ((int)EConnectTypes.Reference).ToString());
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
                                        Rec.MarkID.Add(long.Parse(id));
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
                                Rec.Color = Color.Red;
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
                                Rec.Color = Color.Red;
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

                switch (_Action.ActionType)
                {
                    case EActionTypes.Pattern:
                        {
                            if (_Action.PlacementMode.rtcValue == cPlacementMode.WherePlacedOnImage)
                            {
                                dataRows = _ROIs.Select(cColName.ActionID + "='" + _Action.ID.ToString() + "' AND " +
                                                        cColName.ConnectType + "=" + ((int)EConnectTypes.Reference).ToString());
                                if (dataRows != null && dataRows.Length > 0)
                                {
                                    DataRow r = dataRows[0];
                                    _Action.ReferencePointRectangle = new cRectangType();
                                    _Action.ReferencePointRectangle.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                                    _Action.ReferencePointRectangle.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                                    _Action.ReferencePointRectangle.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                                    _Action.ReferencePointRectangle.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                                    _Action.ReferencePointRectangle.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                                    _Action.ReferencePointRectangle.Width = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                                    _Action.ReferencePointRectangle.Height = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                                    _Action.ReferencePointRectangle.DrawingType = eDrawingTypes;
                                    _Action.ReferencePointRectangle.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                                    _Action.ReferencePointRectangle.AnimationType = (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                                    _Action.ReferencePointRectangle.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                                    _Action.ReferencePointRectangle.RoiType = (ERoiTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.RoiType);
                                }
                            }
                            break;
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

        public bool OpenActionSettings_CameraSettings(cAction _Action)
        {
            try
            {
                if (_Action.ActionType != EActionTypes.CameraSettings)
                    return true;
                _Action.CameraSettings = new cCameraSettings();
                PropertyInfo[] pCameraSettings = _Action.CameraSettings.GetType().GetProperties();
                foreach (PropertyInfo item in pCameraSettings)
                {
                    DataRow r = _CameraSettings.Rows.Find(new object[] { _Action.MyGroup.ID, _Action.ID, item.Name });
                    if (r == null) continue;
                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            item.SetValue(_Action.CameraSettings, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                            break;
                        case "Boolean":
                            item.SetValue(_Action.CameraSettings, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                            break;
                        case "Int32":
                            item.SetValue(_Action.CameraSettings, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                item.SetValue(_Action.CameraSettings, GlobFuncs.String2ListString(GlobFuncs.GetDataRowValue_String(r, cColName.ValueT), cStrings.SepPhay));
                            }
                            break;
                        default:
                            continue;
                    }
                }

                _Action.CameraSettings.IsConnected = false;
                _Action.CameraSettings.IsLive = false;

                _Action.CameraSettings.PropCompareDefault = new Dictionary<string, cPropCompare>();
                DataRow[] propCompares = _CameraSettings.Select("GroupID ='" + _Action.MyGroup.ID.ToString() +
                                                                "' AND ActionID = '" + _Action.ID.ToString() +
                                                                "' AND PropName LIKE 'PropCompareDefault.%'");
                if (propCompares != null)
                    foreach (DataRow row in propCompares)
                    {
                        cPropCompare propCompare = new cPropCompare
                        {
                            RTCPropCAMName = GlobFuncs.GetDataRowValue_String(row, cColName.RTCPropName).Replace(cStrings.PropCompareDefaultWithDot, ""),
                            PropCAMName = GlobFuncs.GetDataRowValue_String(row, cColName.PropName).Replace(cStrings.PropCompareDefaultWithDot, "")
                        };
                        if (!row.IsNull(cColName.ValueT))
                        {
                            propCompare.SValue = GlobFuncs.GetDataRowValue_String(row, cColName.ValueT);
                            propCompare.DataType = typeof(string);
                        }
                        else
                        {
                            propCompare.DValue = GlobFuncs.GetDataRowValue_Decimal(row, cColName.ValueD);
                            propCompare.DataType = typeof(double);
                        }

                        _Action.CameraSettings.PropCompareDefault.Add(propCompare.RTCPropCAMName, propCompare);
                    }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public bool OpenActionSettings(cAction action)
        {
            try
            {
                if (ActionSettings == null)
                    return false;
                var orderedProperty = action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(action, null)) != null).ToList();

                foreach (var nProperty in orderedProperty)
                {
                    string oldPropertyName = nProperty.Name;

                    if (action.ActionType == EActionTypes.DataArchive ||
                        action.ActionType == EActionTypes.DataArchiveRead)
                    {
                        if (oldPropertyName == nameof(action.Header))
                            oldPropertyName = "DataArchive_Header";
                        else if (oldPropertyName == nameof(action.StringList))
                            oldPropertyName = "DataArchive_StringList";
                        else if (oldPropertyName == nameof(action.OutputFileName))
                            oldPropertyName = "DataArchive_FileName";
                        else if (oldPropertyName == nameof(action.FileName))
                            oldPropertyName = "DataArchive_ArchiveName";
                        else if (oldPropertyName == nameof(action.FolderName))
                            oldPropertyName = "DataArchive_FolderName";
                        else if (oldPropertyName == nameof(action.DestinationTypes))
                            oldPropertyName = "DataArchive_DestinationTypes";
                        else if (oldPropertyName == nameof(action.WriteMode))
                            oldPropertyName = "DataArchive_WriteMode";
                        else if (oldPropertyName == nameof(action.BinaryMode))
                            oldPropertyName = "DataArchive_BinaryMode";
                        else if (oldPropertyName == nameof(action.TranferMode))
                            oldPropertyName = "DataArchive_TranferMode";
                        else if (oldPropertyName == nameof(action.MaximumNumberOfTextItemsInQueue))
                            oldPropertyName = "DataArchive_MaximumNumberOfTextItemsInQueue";
                        //else if (oldPropertyName == nameof(action.IsReadHeader))
                        //    oldPropertyName = "DataArchive_ReadHeader";
                        //else if (oldPropertyName == nameof(action.FileLengthRange))
                        //    oldPropertyName = "DataArchive_FileLengthRange";
                        //else if (oldPropertyName == nameof(action.BeginLine))
                        //    oldPropertyName = "DataArchive_BeginLine";
                        //else if (oldPropertyName == nameof(action.EndLine))
                        //    oldPropertyName = "DataArchive_EndLine";
                        //else if (oldPropertyName == nameof(action.IsReadLineLimit))
                        //    oldPropertyName = "DataArchive_ReadLineLimit";
                    }
                    RTCVariableType property = (RTCVariableType)action.GetType().GetProperty(nProperty.Name)?.GetValue(action, null);
                    if (property == null) continue;
                    PropertyInfo valueInfo = nProperty.PropertyType.GetProperty(cPropertyName.rtcValue);
                    if (valueInfo == null)
                        continue;
                    DataRow r = _ActionSettings.Rows.Find(new object[] { action.ID, nProperty.Name });
                    if (r == null)
                        r = _ActionSettings.Rows.Find(new object[] { action.ID, oldPropertyName });
                    if (r == null) continue;
                    string rowValueString = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);

                    switch (nProperty.PropertyType.Name)
                    {
                        case nameof(SBool):
                            valueInfo.SetValue(property, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                            break;
                        //case nameof(SHWindow):
                        //    continue;
                        //case nameof(SHImage):
                        case nameof(SListDouble):
                            //HTuple hTuple = new HTuple(new object[] { GlobFuncs.GetDataRowValue_String(r, cColName.ValueH).Split(cStrings.SepPhay) });
                            if (rowValueString != "")
                            {
                                string[] strings = rowValueString.Split(cStrings.SepGDung);
                                if (strings.Length != 2)
                                    valueInfo.SetValue(property, new List<double>());
                                else
                                    switch (strings[1])
                                    {
                                        case cValueTypes.INTEGER:
                                            valueInfo.SetValue(property, GlobFuncs.Str2DoubleArr(strings[0]));
                                            break;
                                        case cValueTypes.LONG:
                                            valueInfo.SetValue(property, GlobFuncs.Str2DoubleArr(strings[0]));
                                            break;
                                        case cValueTypes.DOUBLE:
                                            valueInfo.SetValue(property, GlobFuncs.Str2DoubleArr(strings[0]));
                                            break;

                                        case cValueTypes.EMPTY:
                                            valueInfo.SetValue(property, new List<double>());
                                            break;
                                        default:
                                            break;
                                    }
                            }
                            else valueInfo.SetValue(property, new List<double>());

                            break;
                        case nameof(SListString):
                            if (rowValueString != "")
                            {
                                string[] strings = rowValueString.Split(cStrings.SepGDung);
                                if (strings.Length != 2)
                                {
                                    if (strings[strings.Length - 1] == cValueTypes.STRING)
                                    {
                                        rowValueString = rowValueString.Substring(0, rowValueString.Length - 7);
                                        valueInfo.SetValue(property, GlobFuncs.Str2StringArr(rowValueString));
                                    }
                                    else
                                        valueInfo.SetValue(property, new List<string>());

                                }
                                else
                                    switch (strings[1])
                                    {
                                        case cValueTypes.STRING:
                                            valueInfo.SetValue(property, GlobFuncs.Str2StringArr(strings[0]));
                                            break;
                                        case cValueTypes.EMPTY:
                                            valueInfo.SetValue(property, new List<string>());
                                            break;
                                        default:
                                            break;
                                    }
                            }
                            else
                                valueInfo.SetValue(property, new List<string>());
                            break;
                        case nameof(SListObject):
                            {
                                if (rowValueString != "")
                                {
                                    List<object> Mixed = new List<object>();
                                    List<object> MixedValue = new List<object>();
                                    string[] strings = rowValueString.Split(cStrings.SepGDung);
                                    if (strings.Length != 2)
                                    {
                                        if (strings[strings.Length - 1] == cValueTypes.STRING)
                                        {
                                            rowValueString = rowValueString.Substring(0, rowValueString.Length - 7);
                                            valueInfo.SetValue(property, GlobFuncs.Str2StringObj(rowValueString));
                                        }
                                        else if (strings[strings.Length - 1] == cValueTypes.DOUBLE)
                                        {
                                            rowValueString = rowValueString.Substring(0, rowValueString.Length - 7);
                                            Mixed = GlobFuncs.Str2StringObj(rowValueString);
                                            MixedValue = new List<object>();
                                            foreach (string item in Mixed)
                                            {
                                                if (GlobFuncs.IsNumeric(item))
                                                    MixedValue.Add(double.Parse(item));
                                                else if (GlobFuncs.IsInt(item))
                                                    MixedValue.Add(int.Parse(item));
                                                else
                                                    MixedValue.Add(item);
                                            }
                                            valueInfo.SetValue(property, MixedValue);
                                        }
                                        else if (strings[strings.Length - 1] == cValueTypes.MIXED)
                                        {
                                            rowValueString = rowValueString.Substring(0, rowValueString.Length - 7);
                                            Mixed = GlobFuncs.Str2StringObj(rowValueString);
                                            foreach (string item in Mixed)
                                            {
                                                if (GlobFuncs.IsNumeric(item))
                                                    MixedValue.Add(double.Parse(item));
                                                else if (GlobFuncs.IsInt(item))
                                                    MixedValue.Add(int.Parse(item));
                                                else
                                                    MixedValue.Add(item);
                                            }
                                            valueInfo.SetValue(property, MixedValue);
                                        }
                                        else
                                            valueInfo.SetValue(property, new List<object>());
                                    }
                                    else
                                        switch (strings[1])
                                        {
                                            case cValueTypes.STRING:
                                                {
                                                    valueInfo.SetValue(property, GlobFuncs.Str2StringObj(strings[0]));
                                                    break;
                                                }
                                            case cValueTypes.MIXED:
                                                {
                                                    Mixed = GlobFuncs.Str2StringObj(strings[0]);
                                                    foreach (string item in Mixed)
                                                    {
                                                        if (GlobFuncs.IsNumeric(item))
                                                            MixedValue.Add(double.Parse(item));
                                                        else if (GlobFuncs.IsInt(item))
                                                            MixedValue.Add(int.Parse(item));
                                                        else
                                                            MixedValue.Add(item);
                                                    }
                                                    valueInfo.SetValue(property, MixedValue);
                                                    break;
                                                }
                                            case cValueTypes.DOUBLE:
                                                {
                                                    Mixed = GlobFuncs.Str2StringObj(strings[0]);
                                                    MixedValue = new List<object>();
                                                    foreach (string item in Mixed)
                                                    {
                                                        if (GlobFuncs.IsNumeric(item))
                                                            MixedValue.Add(double.Parse(item));
                                                        else if (GlobFuncs.IsInt(item))
                                                            MixedValue.Add(int.Parse(item));
                                                        else
                                                            MixedValue.Add(item);
                                                    }
                                                    valueInfo.SetValue(property, MixedValue);
                                                    break;
                                                }
                                            case cValueTypes.EMPTY:
                                                valueInfo.SetValue(property, new List<object>());
                                                break;
                                            default:
                                                break;
                                        }
                                }
                                else valueInfo.SetValue(property, new List<object>());
                                break;
                            }
                        case nameof(SString):
                            valueInfo.SetValue(property, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                            break;
                        case nameof(SInt):
                            valueInfo.SetValue(property, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        //case nameof(SLong):
                        //    valueInfo.SetValue(property, GlobFuncs.GetDataRowValue_Long(r, cColName.ValueL));
                        //    break;
                        case nameof(SDouble):
                            valueInfo.SetValue(property, GlobFuncs.GetDataRowValue_Double(r, cColName.ValueD));
                            break;
                        default:
                            break;
                    }
                    if (action.RunIsSilent != null && nProperty.Name == nameof(action.RunIsSilent))
                        action.RunIsSilent.rtcValue = true;
                    if (action.InputImage != null && nProperty.Name == nameof(action.InputImage))
                        action.InputImage.rtcValue = null;
                    property.rtcIsParent = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcIsParent);
                    property.rtcIDRef = GlobFuncs.GetDataRowValue_Guid(r, cColName.rtcIDRef);
                    property.rtcPropNameRef = GlobFuncs.GetDataRowValue_String(r, cColName.rtcPropNameRef);


                    property.rtcRef = GlobFuncs.GetDataRowValue_String(r, cColName.rtcRef);
                    OpenActionSettings_FixDataArchive(action, property);
                    property.rtcDisplay = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcDisplay);
                    property.rtcDisplayValueInHistory = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcDisplayValueInHistory);
                    if (_dataVersion < 408 && property.rtcDisplayValueInHistory)
                        property.rtcDisplay = property.rtcDisplayValueInHistory;

                    if (r.Table.Columns.Contains(cColName.rtcIsCanReset))
                        property.rtcIsCanReset = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcIsCanReset);
                    property.rtcResetWhenStart = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcResetWhenStart);
                    property.rtcResetWhenStop = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcResetWhenStop);
                    property.ParentIDResets = GlobFuncs.String2ListGuid(GlobFuncs.GetDataRowValue_String(r, cColName.ParentIDResets), cChars.Comma);
                    property.rtcRefIndex = GlobFuncs.GetDataRowValue_String(r, cColName.rtcRefIndex);
                    property.rtcIsHighLight = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcIsHighLight);
                    property.rtcSaveToFileConfig = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcSaveToFileConfig);
                }
                switch (action.ActionType)
                {
                    case EActionTypes.Branch:
                        action.MyExpression = new cExpression(action.Expression.rtcValue, action.CalculateMode.rtcValue, EExpressionResultTypes.Boolean, false);
                        break;
                    case EActionTypes.Switch:
                        action.MyExpression = new cExpression(action.Expression.rtcValue, action.CalculateMode.rtcValue, EExpressionResultTypes.HTuple, false);
                        break;
                    //    case EActionTypes.ImageFilter:
                    //        {
                    //            if (action.FilterType.rtcValue == "Y")
                    //                action.FilterType.rtcValue = "Y - Luminance";
                    //            else if (action.FilterType.rtcValue == "U")
                    //                action.FilterType.rtcValue = "U - Chroma Blue";
                    //            else if (action.FilterType.rtcValue == "V")
                    //                action.FilterType.rtcValue = "V - Chroma Red";
                    //            break;
                    //        }
                    //    //case EActionTypes.OCR:
                    //    //    {
                    //    //        OpenActionSettings_CreateOCRData(action);
                    //    //        break;
                    //    //    }
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
        private void OpenActionSettings_FixDataArchive(cAction action, RTCVariableType property)
        {
            if (property.rtcPropNameRef == "DataArchive_Header")
            {
                property.rtcPropNameRef = nameof(action.Header);
                property.rtcRef = property.rtcRef.Replace("DataArchive_Header", nameof(action.Header));
            }
            else if (property.rtcPropNameRef == "DataArchive_StringList")
            {
                property.rtcPropNameRef = nameof(action.StringList);
                property.rtcRef = property.rtcRef.Replace("DataArchive_StringList", nameof(action.StringList));
            }
            else if (property.rtcPropNameRef == "DataArchive_ArchiveName")
            {
                property.rtcPropNameRef = nameof(action.FileName);
                property.rtcRef = property.rtcRef.Replace("DataArchive_ArchiveName", nameof(action.FileName));
            }
            else if (property.rtcPropNameRef == "DataArchive_FolderName")
            {
                property.rtcPropNameRef = nameof(action.FolderName);
                property.rtcRef = property.rtcRef.Replace("DataArchive_FolderName", nameof(action.FolderName));
            }
            else if (property.rtcPropNameRef == "DataArchive_DestinationTypes")
            {
                property.rtcPropNameRef = nameof(action.DestinationTypes);
                property.rtcRef = property.rtcRef.Replace("DataArchive_DestinationTypes", nameof(action.DestinationTypes));
            }
            else if (property.rtcPropNameRef == "DataArchive_WriteMode")
            {
                property.rtcPropNameRef = nameof(action.WriteMode);
                property.rtcRef = property.rtcRef.Replace("DataArchive_WriteMode", nameof(action.WriteMode));
            }
            else if (property.rtcPropNameRef == "DataArchive_BinaryMode")
            {
                property.rtcPropNameRef = nameof(action.BinaryMode);
                property.rtcRef = property.rtcRef.Replace("DataArchive_BinaryMode", nameof(action.BinaryMode));
            }
            else if (property.rtcPropNameRef == "DataArchive_TranferMode")
            {
                property.rtcPropNameRef = nameof(action.TranferMode);
                property.rtcRef = property.rtcRef.Replace("DataArchive_TranferMode", nameof(action.TranferMode));
            }
            else if (property.rtcPropNameRef == "DataArchive_MaximumNumberOfTextItemsInQueue")
            {
                property.rtcPropNameRef = nameof(action.MaximumNumberOfTextItemsInQueue);
                property.rtcRef = property.rtcRef.Replace("DataArchive_MaximumNumberOfTextItemsInQueue", nameof(action.MaximumNumberOfTextItemsInQueue));
            }
        }
        public bool OpenGroup_CameraSettings(cGroupActions _Group)
        {
            try
            {
                if (CameraSettings == null)
                    return false;

                PropertyInfo[] pCameraSettings = _Group.SourceImageSettings.CameraSettings.GetType().GetProperties();
                foreach (PropertyInfo item in pCameraSettings)
                {
                    DataRow r = _CameraSettings.Rows.Find(new object[] { _Group.ID, Guid.Empty, item.Name });
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
                        case "ESdkModes":
                            {
                                item.SetValue(_Group.SourceImageSettings.CameraSettings, (ESdkModes)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                                break;
                            }
                        default:
                            continue;
                    }
                }
                _Group.SourceImageSettings.CameraSettings.PropCompareDefault = new Dictionary<string, cPropCompare>();
                DataRow[] propCompares = _CameraSettings.Select("GroupID ='" + _Group.ID.ToString() +
                                                                "' AND ActionID = '" + Guid.Empty.ToString() +
                                                                "' AND PropName LIKE 'PropCompareDefault.%'");
                if (propCompares != null)
                    foreach (DataRow row in propCompares)
                    {
                        cPropCompare propCompare = new cPropCompare();
                        propCompare.RTCPropCAMName = GlobFuncs.GetDataRowValue_String(row, cColName.RTCPropName).Replace(cStrings.PropCompareDefaultWithDot, "");
                        propCompare.PropCAMName = GlobFuncs.GetDataRowValue_String(row, cColName.PropName).Replace(cStrings.PropCompareDefaultWithDot, "");
                        if (!row.IsNull(cColName.ValueT))
                        {
                            propCompare.SValue = GlobFuncs.GetDataRowValue_String(row, cColName.ValueT);
                            propCompare.DataType = typeof(string);
                        }
                        else
                        {
                            propCompare.DValue = GlobFuncs.GetDataRowValue_Decimal(row, cColName.ValueD);
                            propCompare.DataType = typeof(double);
                        }

                        _Group.SourceImageSettings.CameraSettings.PropCompareDefault.Add(propCompare.RTCPropCAMName, propCompare);
                    }

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public void OpenGroup_GetInfo()
        {
            _dataVersion = -1;
            try
            {
                if (CamInfo != null)
                {
                    DataRow[] rows = CamInfo.Select($"{cColName.Name} = 'Version'");
                    if (rows.Length > 0)
                        _dataVersion = GlobFuncs.SVersionToIVersion(GlobFuncs.Object2Str(rows[0][cColName.Value]));
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        public bool OpenGroup_ComputerSettings(cGroupActions _Group)
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
        public bool SaveGroup_ComputerSettings(cGroupActions _Group)
        {
            try
            {
                if (ComputerSettings == null)
                    return false;
                bool Result = false;

                PropertyInfo[] pComputerSettings = _Group.SourceImageSettings.ComputerSettings.GetType().GetProperties();
                foreach (PropertyInfo item in pComputerSettings)
                {
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

                    Result = Myconn.AddRow(r);
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
        public bool OpenGroup_SourceImages(cGroupActions _Group)
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
        public bool OpenGroup_Trigger(cGroupActions _Group)
        {
            try
            {
                if (Trigger == null)
                    return true;

                var Triggerprops = _Group.SourceImageSettings.Trigger.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in Triggerprops)
                {
                    DataRow r = _Trigger.Rows.Find(new object[] { _Group.ID, propertyInfo.Name });
                    if (r == null) continue;
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case "bool":
                            propertyInfo.SetValue(_Group.SourceImageSettings.Trigger, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                            break;
                        case "Boolean":
                            propertyInfo.SetValue(_Group.SourceImageSettings.Trigger, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                            break;
                        case "ETriggerType":
                            propertyInfo.SetValue(_Group.SourceImageSettings.Trigger, (ETriggerType)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case "ETriggerMode":
                            propertyInfo.SetValue(_Group.SourceImageSettings.Trigger, (ETriggerMode)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case "Parity":
                            propertyInfo.SetValue(_Group.SourceImageSettings.Trigger, (Parity)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case "StopBits":
                            propertyInfo.SetValue(_Group.SourceImageSettings.Trigger, (StopBits)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case "EPLCReadType":
                            propertyInfo.SetValue(_Group.SourceImageSettings.Trigger, (EPLCReadType)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        //case "ControllerTypeConst":
                        //    propertyInfo.SetValue(_Group.SourceImageSettings.Trigger, (ControllerTypeConst)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                        //    break;
                        case "String":
                            propertyInfo.SetValue(_Group.SourceImageSettings.Trigger, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                            break;
                        case "Int32":
                            propertyInfo.SetValue(_Group.SourceImageSettings.Trigger, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        default:
                            break;
                    }
                }

                //DataRow rTrigger = _Trigger.Rows.Find(new object[] { groupActions.ID });
                //if (rTrigger == null) return true;
                //groupActions.SourceImageSettings.Trigger.TriggerMode = (ETriggerMode)GlobFuncs.GetDataRowValue_Int(rTrigger,cColName.TriggerMode);
                //groupActions.SourceImageSettings.Trigger.TriggerType = (ETriggerType)GlobFuncs.GetDataRowValue_Int(rTrigger,cColName.TriggerType);
                //groupActions.SourceImageSettings.Trigger.COMName = GlobFuncs.GetDataRowValue_String(rTrigger,cColName.COMName);
                //groupActions.SourceImageSettings.Trigger.IP = GlobFuncs.GetDataRowValue_String(rTrigger,cColName.IP);
                //groupActions.SourceImageSettings.Trigger.Port = GlobFuncs.GetDataRowValue_Int(rTrigger,cColName.Port);
                //groupActions.SourceImageSettings.Trigger.TriggerValue = GlobFuncs.GetDataRowValue_String(rTrigger,cColName.TriggerValue);

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool OpenActionLinkPassFail(cAction action)
        {
            try
            {
                switch (action.ActionType)
                {
                    case EActionTypes.PassFail:
                        action.LinkPassFail = new List<cLinkPassFail>();
                        break;
                    case EActionTypes.ResetTool:
                        action.ListResetTools = new List<cLinkPassFail>();
                        break;
                }

                if (LinkPassFail == null)
                    return true;
                DataRow[] rows = _LinkPassFail.Select(cColName.ActionID + "='" + action.ID.ToString() + "'");
                foreach (DataRow r in rows)
                {
                    cLinkPassFail link = new cLinkPassFail
                    {
                        rtcActive = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Active),
                        rtcIDref = GlobFuncs.GetDataRowValue_Guid(r, cColName.IDRef),
                        rtcInvert = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Invert),
                        rtcGetResult = GlobFuncs.GetDataRowValue_Boolean(r, cColName.GetResult),
                        rtcIDGetResult = GlobFuncs.GetDataRowValue_Guid(r, cColName.IDGetResult),
                        rtcPropNameRef = GlobFuncs.GetDataRowValue_String(r, cColName.PropName),
                        rtcRef = GlobFuncs.GetDataRowValue_String(r, cColName.Ref),
                        rtcSTT = GlobFuncs.GetDataRowValue_Int(r, cColName.STT)
                    };
                    switch (action.ActionType)
                    {
                        case EActionTypes.PassFail:
                            {
                                if (string.IsNullOrEmpty(link.rtcPropNameRef))
                                    link.rtcPropNameRef = nameof(action.Passed);
                                action.LinkPassFail.Add(link);
                                break;
                            }
                        case EActionTypes.ResetTool:
                            action.ListResetTools.Add(link);
                            break;
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
        public bool OpenActionROIProperties(cAction _Action)
        {
            try
            {
                _Action.ROIProperties = new Dictionary<long, cROIProperty>();
                if (ROIProperties == null)
                    return true;
                // Lấy danh sách các ID ROIProperties
                DataRow[] dataRows = _ROIProperties.Select(cColName.ActionID + "='" + _Action.ID.ToString() + "'");
                if (!dataRows.Any())
                    return true;
                var datarowIDs = dataRows.GroupBy(x => x[cColName.ID]).Select(x => x.First());
                foreach (DataRow r in datarowIDs)
                {
                    cROIProperty _ROIProp = new cROIProperty(_Action.ActionType, GlobFuncs.GetDataRowValue_Long(r, cColName.ID));
                    _ROIProp.GID = GlobFuncs.GetDataRowValue_Guid(r, cColName.GID);
                    _ROIProp.IDLink = GlobFuncs.GetDataRowValue_Int(r, cColName.IDLink);
                    //if (_ROIProperties.Columns.Contains(cColName.Name))
                    //{
                    //    if (_Action.ROIs != null && _Action.ROIs.ContainsKey(_ROIProp.ID))
                    //        ((cDrawingBaseType)_Action.ROIs[_ROIProp.ID]).Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                    //    if (_Action.FindROIs != null && _Action.FindROIs.ContainsKey(_ROIProp.ID))
                    //        ((cDrawingBaseType)_Action.FindROIs[_ROIProp.ID]).Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                    //}

                    var ROIPprops = _ROIProp.GetType().GetProperties().Where(x => x != null);

                    foreach (PropertyInfo propertyInfo in ROIPprops)
                    {
                        DataRow rprop = _ROIProperties.Rows.Find(new object[] { _Action.ID, _ROIProp.ID, propertyInfo.Name });
                        if (rprop == null) continue;
                        RTCVariableType rtcvar = (RTCVariableType)propertyInfo.GetValue(_ROIProp, null);
                        string HtupleVal = GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH);
                        string[] HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                        if (rtcvar == null) continue;
                        rtcvar.rtcIDRef = GlobFuncs.GetDataRowValue_Guid(rprop, cColName.rtcIDRef);
                        rtcvar.rtcRef = GlobFuncs.GetDataRowValue_String(rprop, cColName.rtcRef);
                        rtcvar.rtcPropNameRef = GlobFuncs.GetDataRowValue_String(rprop, cColName.rtcPropNameRef);
                        rtcvar.rtcRefIndex = GlobFuncs.GetDataRowValue_String(rprop, cColName.rtcRefIndex);
                        var propertyInfoValue = propertyInfo.PropertyType.GetProperty(cPropertyName.rtcValue);
                        if (propertyInfoValue == null)
                            continue;

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
                                HtupleVal = GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH);
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
                                    if (HtupleVals.Length != 2) propertyInfoValue.SetValue(rtcvar, new List<string>());
                                    else
                                        switch (HtupleVals[1])
                                        {

                                            case cValueTypes.STRING:
                                                propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2StringArr(HtupleVals[0]));
                                                break;


                                            case cValueTypes.EMPTY:
                                                propertyInfoValue.SetValue(rtcvar, new List<string>());
                                                break;
                                            default:
                                                break;
                                        }
                                }
                                else propertyInfoValue.SetValue(rtcvar, new List<double>());
                                //propertyInfoValue.SetValue(rtcvar,new HTuple(GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH)));
                                break;
                            case nameof(SListObject):
                                HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                                if (HtupleVal != "")
                                {
                                    HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                                    if (HtupleVals.Length != 2) propertyInfoValue.SetValue(rtcvar, new List<string>());
                                    else
                                        switch (HtupleVals[1])
                                        {

                                            case cValueTypes.MIXED:
                                                propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2StringObj(HtupleVals[0]));
                                                break;
                                            case cValueTypes.EMPTY:
                                                propertyInfoValue.SetValue(rtcvar, new List<object>());
                                                break;
                                            default:
                                                break;
                                        }
                                }
                                else propertyInfoValue.SetValue(rtcvar, new List<double>());
                                //propertyInfoValue.SetValue(rtcvar,new HTuple(GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH)));
                                break;
                            case nameof(SDouble):
                                propertyInfoValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Double(rprop, cColName.ValueD));
                                break;
                            default:
                                continue;
                        }
                    }
                    if (_ROIProp.IDLink == 0) _ROIProp.IDLink = -1;
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

        public bool OpenActionLinkProperty(cAction action)
        {
            try
            {
                if (action.ActionType != EActionTypes.LinkValue && action.ActionType != EActionTypes.DataSet)
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
                        List<object> HtupleVals = HtupleVal.Split(cStrings.SepGDung).Cast<object>().ToList();
                        if (HtupleVals.Count != 2)
                        {
                            linkItem.SourceIndex = new List<object>();
                        }
                        else
                            switch (HtupleVals[1])
                            {
                                case cValueTypes.INTEGER:
                                    linkItem.SourceIndex = new List<object>() { GlobFuncs.ListObject2Str(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.STRING:
                                    linkItem.SourceIndex = new List<object>() { GlobFuncs.ListObject2Str(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.DOUBLE:
                                    linkItem.SourceIndex = new List<object>() { GlobFuncs.ListObject2Str(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.MIXED:
                                    List<object> HtupleValo = new List<object>();
                                    foreach (string item in HtupleVals)
                                        if (GlobFuncs.IsNumeric(item))
                                            HtupleValo.Append(double.Parse(item));
                                        else if (GlobFuncs.IsInt(item))
                                            HtupleValo.Append(int.Parse(item));
                                        else
                                            HtupleValo.Append(item);

                                    linkItem.SourceIndex = GlobFuncs.Str2StringObj(HtupleValo[0].ToString());
                                    break;
                                case cValueTypes.EMPTY:
                                    linkItem.SourceIndex = new List<object>();
                                    break;
                                default:
                                    linkItem.SourceIndex = new List<object>() { GlobFuncs.ListObject2Str(new List<object>() { HtupleVals[0] }) };
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
                                    linkItem.TargetIndex = new List<object>() { GlobFuncs.ListObject2StrWithType(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.STRING:
                                    linkItem.TargetIndex = new List<object>() { GlobFuncs.ListObject2StrWithType(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.DOUBLE:
                                    linkItem.TargetIndex = new List<object>() { GlobFuncs.ListObject2StrWithType(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.MIXED:
                                    List<object> HtupleValo = new List<object>();
                                    foreach (string item in HtupleVals)
                                        if (GlobFuncs.IsNumeric(item))
                                            HtupleValo.Append(double.Parse(item));
                                        else if (GlobFuncs.IsInt(item))
                                            HtupleValo.Append(int.Parse(item));
                                        else
                                            HtupleValo.Append(item);

                                    linkItem.TargetIndex = GlobFuncs.Str2StringObj(HtupleValo[0].ToString());
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

        public bool OpenStringBuilderItems(cAction _Action)
        {
            try
            {
                switch (_Action.ActionType)
                {
                    case EActionTypes.StringBuilder:
                        _Action.StringBuilders = new List<SStringBuilderItem>();
                        break;
                    case EActionTypes.Branch:
                        _Action.MyExpression.Operands = new List<SStringBuilderItem>();
                        break;
                    case EActionTypes.BranchItem:
                        _Action.DataItems = new List<SStringBuilderItem>();
                        break;
                    case EActionTypes.Switch:
                        _Action.MyExpression.Operands = new List<SStringBuilderItem>();
                        break;
                    case EActionTypes.CameraSettings:
                        _Action.DataItems = new List<SStringBuilderItem>();
                        break;
                        //case EActionTypes.DataInstance:
                        //    _Action.DataItems = new List<SStringBuilderItem>();
                        //    break;
                }
                if (StringBuilderItems == null)
                    return true;
                DataRow[] actionStringBuilderItems = _StringBuilderItems.Select("ActionID='" + _Action.ID.ToString() + "'");
                foreach (DataRow r in actionStringBuilderItems)
                {
                    SStringBuilderItem sbItem = new SStringBuilderItem();
                    sbItem.ValueStyle = (EHTupleStyle)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueStyle);
                    sbItem.OrderNum = GlobFuncs.GetDataRowValue_Int(r, cColName.OrderNum);
                    sbItem.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                    sbItem.RefID = GlobFuncs.GetDataRowValue_Guid(r, cColName.RefID);
                    sbItem.RefPropName = GlobFuncs.GetDataRowValue_String(r, cColName.RefPropName);
                    sbItem.Ref = GlobFuncs.GetDataRowValue_String(r, cColName.Ref);
                    sbItem.RefIndex = GlobFuncs.GetDataRowValue_String(r, cColName.RefIndex);

                    sbItem.ListDoubleValue = new List<double>();

                    sbItem.ListStringValue = new List<string>();
                    string htupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.Value);
                    if (htupleVal != "")
                    {
                        string[] htupleVals = htupleVal.Split(cStrings.SepGDung);
                        if (htupleVals.Length != 2)
                        {
                            sbItem.ListStringValue = new List<string>();
                            sbItem.ListDoubleValue = new List<double>();
                        }
                        else
                            switch (htupleVals[1].ToUpper())
                            {
                                case cValueTypes.INTEGER:
                                    sbItem.ListDoubleValue = GlobFuncs.Str2DoubleArr(htupleVals[0]);
                                    break;
                                case cValueTypes.LONG:
                                    sbItem.ListDoubleValue = GlobFuncs.Str2DoubleArr(htupleVals[0]);
                                    break;
                                case cValueTypes.STRING:
                                    sbItem.ListStringValue = GlobFuncs.Str2StringArr(htupleVals[0]);
                                    break;
                                case cValueTypes.DOUBLE:
                                    sbItem.ListDoubleValue = GlobFuncs.Str2DoubleArr(htupleVals[0]);
                                    break;
                                case cValueTypes.MIXED:
                                    List<object> HtupleValo = new List<object>();
                                    foreach (string item in htupleVals)
                                        if (GlobFuncs.IsNumeric(item))
                                            HtupleValo.Append(double.Parse(item));
                                        else if (GlobFuncs.IsInt(item))
                                            HtupleValo.Append(int.Parse(item));
                                        else
                                            HtupleValo.Append(item);

                                    sbItem.ListDoubleValue = GlobFuncs.Str2DoubleArr(GlobFuncs.Object2Str(HtupleValo[0]));
                                    break;
                                case cValueTypes.EMPTY:
                                    sbItem.ListStringValue = new List<string>();
                                    sbItem.ListDoubleValue = new List<double>();
                                    break;
                                default:
                                    break;
                            }
                    }
                    sbItem.IscanReset = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsCanReset);
                    sbItem.IsParent = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsParent);
                    sbItem.TrueText = GlobFuncs.GetDataRowValue_String(r, cColName.TrueText);
                    sbItem.FalseText = GlobFuncs.GetDataRowValue_String(r, cColName.FalseText);
                    sbItem.DateFormat = (EDateFormat)GlobFuncs.GetDataRowValue_Int(r, cColName.DateFormat);
                    sbItem.DelimiterDate = (EDelimiterDate)GlobFuncs.GetDataRowValue_Int(r, cColName.DelimiterDate);
                    sbItem.TimeFormat = (ETimeFormat)GlobFuncs.GetDataRowValue_Int(r, cColName.TimeFormat);
                    sbItem.DelimiterTime = (EDelimiterTime)GlobFuncs.GetDataRowValue_Int(r, cColName.DelimiterTime);
                    sbItem.UseDecimalPlaces = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UseDecimalPlaces);
                    sbItem.DecimalPlaces = GlobFuncs.GetDataRowValue_Int(r, cColName.DecimalPlaces);
                    sbItem.UseMiniumLength = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UseMiniumLength);
                    sbItem.MiniumLength = GlobFuncs.GetDataRowValue_Int(r, cColName.MiniumLength);
                    sbItem.UseLimitInput = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UseLimitInput);
                    sbItem.MaximumLength = GlobFuncs.GetDataRowValue_Int(r, cColName.MaximumLength);
                    sbItem.UsePadOutput = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UsePadOutput);
                    sbItem.PadOutPut = (EPadOutPut)GlobFuncs.GetDataRowValue_Int(r, cColName.PadOutput);
                    sbItem.PadWith = (EPadWiths)GlobFuncs.GetDataRowValue_Int(r, cColName.PadWith);
                    sbItem.GroupingBracket = (EGroupingBracket)GlobFuncs.GetDataRowValue_Int(r, cColName.GroupingBracket);
                    sbItem.XYDelimiter = (EXYDelimiter)GlobFuncs.GetDataRowValue_Int(r, cColName.XYDelimiter);
                    sbItem.ElementDelimiter.DelimiterTypes = (EDelimiterTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.E_DelimiterType);
                    sbItem.ElementDelimiter.StandardValue = (EDelimiter)GlobFuncs.GetDataRowValue_Int(r, cColName.E_StandardValue);
                    sbItem.ElementDelimiter.CustomValue = GlobFuncs.GetDataRowValue_String(r, cColName.E_CustomValue);
                    sbItem.Leading = GlobFuncs.GetDataRowValue_String(r, cColName.Leading);
                    sbItem.Tralling = GlobFuncs.GetDataRowValue_String(r, cColName.Tralling);

                    switch (_Action.ActionType)
                    {
                        case EActionTypes.StringBuilder:
                            _Action.StringBuilders.Add(sbItem);
                            break;
                        case EActionTypes.Branch:
                            _Action.MyExpression.Operands.Add(sbItem);
                            break;
                        case EActionTypes.BranchItem:
                            _Action.DataItems.Add(sbItem);
                            break;
                        case EActionTypes.Switch:
                            _Action.MyExpression.Operands.Add(sbItem);
                            break;
                            //case EActionTypes.DataInstance:
                            //    _Action.DataItems.Add(sbItem);
                            //    break;
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

        #endregion

        #endregion
        #region CLONE ACTIONS
        public cAction CloneAction(cAction sourceAction)
        {
            cAction targetAction = null;

            if (sourceAction == null)
                return null;

            if (!Connect(sourceAction.MyGroup.FileName))
                return null;
            try
            {
                Myconn.StartTransaction();

                if (!SaveActionWhenClone(sourceAction))
                    return null;

                targetAction = sourceAction.MyGroup.CreateAction(sourceAction.ActionType, sourceAction.ObjectType, true);
                string sNewName = targetAction.Name.rtcValue;
                bool bResult = CloneAction_ActionSettings(sourceAction, targetAction);
                if (bResult) bResult = CloneAction_ActionLinkProperty(sourceAction, targetAction);
                if (bResult) bResult = CloneAction_ActionROIs(sourceAction, targetAction);
                if (bResult) bResult = CloneAction_FindROIs(sourceAction, targetAction);
                #region EDITTING
                switch (targetAction.ActionType)
                {
                    case EActionTypes.MainAction:
                        {
                            targetAction.ProgramMode.rtcValue = cProgramMode.Auto;
                            targetAction.ManualAction.rtcValue = cManualAction.None;
                            break;
                        }
                    case EActionTypes.PassFail:
                        {
                            if (bResult) bResult = CloneAction_ActionLinkPassFail(sourceAction, targetAction);
                            break;
                        }
                    case EActionTypes.ResetTool:
                        {
                            if (bResult) bResult = CloneAction_ActionLinkPassFail(sourceAction, targetAction);
                            break;
                        }
                    case EActionTypes.StringBuilder:
                        {
                            if (bResult) bResult = CloneAction_StringBuilderItems(sourceAction, targetAction);
                            break;
                        }
                    case EActionTypes.Switch:
                        {
                            if (bResult) bResult = CloneAction_StringBuilderItems(sourceAction, targetAction);
                            break;
                        }
                    case EActionTypes.BranchItem:
                        {
                            if (bResult) bResult = CloneAction_StringBuilderItems(sourceAction, targetAction);
                            break;
                        }
                    case EActionTypes.Branch:
                        {
                            if (bResult) bResult = CloneAction_StringBuilderItems(sourceAction, targetAction);
                            break;
                        }
                    case EActionTypes.Count:
                        {
                            targetAction.StartNumber.rtcValue = targetAction.KeepValueToNextSession.rtcValue
                                ? targetAction.StartNumber.rtcValue
                                : targetAction.ResetNumber.rtcValue;
                            break;
                        }
                    case EActionTypes.ImageFilter:
                        {
                            if (bResult) bResult = CloneAction_ImageFilterList(sourceAction, targetAction);
                            break;
                        }
                }
                if (bResult) bResult = CloneAction_ROIProperties(sourceAction, targetAction);



                targetAction.IDBranch = sourceAction.IDBranch;
                targetAction.IDBranchItem = sourceAction.IDBranchItem;
                targetAction.Name.rtcValue = sourceAction.ActionType == EActionTypes.BranchItem
                    ? sourceAction.Name.rtcValue
                    : sNewName;
                if (bResult)
                {
                    targetAction.SetFlagTrainToDefault(false);

                    if (targetAction.ShapeList != null && targetAction.TabRoiActive != null)
                        targetAction.TabRoiActive.rtcValue = false;
                    if (targetAction.FindShapeList != null && targetAction.TabPassActive != null)
                        targetAction.TabPassActive.rtcValue = false;
                    if (targetAction.TrainPressed != null)
                        targetAction.TrainPressed.rtcValue = false;
                }

                targetAction.MyGroup = sourceAction.MyGroup;


                ;
                try
                {
                    if (targetAction.MyGroup.frmHsmartWindow != null)
                        targetAction.WindowHandle.rtcValue = targetAction.MyGroup.frmHsmartWindow.SmartWindowControl;
                    else if (targetAction.MyGroup.SmartWindowControl != null)
                        targetAction.WindowHandle.rtcValue = targetAction.MyGroup.SmartWindowControl;
                }
                catch
                {
                }
            }
            #endregion
            finally
            {
                if (Myconn != null && Myconn.IsConnected)
                    Myconn.RollBack();
                Disconnect();
            }

            return targetAction;
        }
        public bool CloneAction_ActionSettings(cAction sourceAction, cAction targetAction)
        {
            DataTable data = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ActionSettings + " WHERE ActionID = '" + sourceAction.ID.ToString() + "'");

            if (data != null)
            {
                data.TableName = cTableName_SaveTemplate.ActionSettings;
                data.Columns[cColName.ActionID].Caption = cColName.KEY;
                data.Columns[cColName.PropName].Caption = cColName.KEY;
                var keys = new DataColumn[2];
                keys[0] = data.Columns[cColName.ActionID];
                keys[1] = data.Columns[cColName.PropName];
                data.PrimaryKey = keys;
            }
            else return false;

            //Lấy toàn bộ properties của action này
            var orderedProperty = targetAction.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(targetAction, null)) != null).ToList();

            PropertyInfo nProperty;
            for (int i = 0; i < orderedProperty.Count; i++)
            {
                nProperty = orderedProperty[i];
                RTCVariableType rtcvar = (RTCVariableType)targetAction.GetType().GetProperty(nProperty.Name).GetValue(targetAction, null);
                PropertyInfo rtcvarValue = nProperty.PropertyType.GetProperty(cPropertyName.rtcValue);
                DataRow r = data.Rows.Find(new object[] { sourceAction.ID, nProperty.Name });
                if (r == null) continue;
                string HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);

                switch (nProperty.PropertyType.Name)
                {
                    case nameof(SBool):
                        rtcvarValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                        break;
                    //case nameof(SHWindow):
                    //    continue;
                    //case nameof(SHImage):
                    //    break;

                    case nameof(SListDouble):
                        //HTuple hTuple = new HTuple(new object[] { GlobFuncs.GetDataRowValue_String(r, cColName.ValueH).Split(cStrings.SepPhay) });
                        if (HtupleVal != "")
                        {
                            string[] HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                            if (HtupleVals.Length != 2) rtcvarValue.SetValue(rtcvar, new List<double>());
                            else
                                switch (HtupleVals[1])
                                {
                                    case cValueTypes.INTEGER:
                                        rtcvarValue.SetValue(rtcvar, GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                        break;
                                    case cValueTypes.LONG:
                                        rtcvarValue.SetValue(rtcvar, GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                        break;
                                    case cValueTypes.STRING:
                                        rtcvarValue.SetValue(rtcvar, HtupleVals[0]);
                                        break;
                                    case cValueTypes.DOUBLE:
                                        rtcvarValue.SetValue(rtcvar, GlobFuncs.Str2DoubleArr(HtupleVals[0]));
                                        break;
                                    case cValueTypes.MIXED:
                                        List<object> HtupleValo = new List<object>();
                                        foreach (string item in HtupleVals)
                                            if (GlobFuncs.IsNumeric(item))
                                                HtupleValo.Append(double.Parse(item));
                                            else if (GlobFuncs.IsInt(item))
                                                HtupleValo.Append(int.Parse(item));
                                            else
                                                HtupleValo.Append(item);

                                        rtcvarValue.SetValue(rtcvar, GlobFuncs.Str2StringObj(HtupleValo[0].ToString()));
                                        break;
                                    default:
                                        break;
                                }


                        }
                        else rtcvarValue.SetValue(rtcvar, new List<double>());

                        break;
                    case nameof(SListString):
                        {
                            HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                            if (HtupleVal != "")
                            {
                                string[] HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                                if (HtupleVals.Length != 2) rtcvarValue.SetValue(rtcvar, new List<object>());
                                else
                                    switch (HtupleVals[1])
                                    {
                                        case cValueTypes.STRING:
                                            rtcvarValue.SetValue(rtcvar, GlobFuncs.Str2StringArr(HtupleVals[0]));
                                            break;
                                        default:
                                            break;
                                    }


                            }
                            break;
                        }
                    case nameof(SListObject):
                        {
                            HtupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                            if (HtupleVal != "")
                            {
                                string[] HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                                if (HtupleVals.Length != 2) rtcvarValue.SetValue(rtcvar, new List<object>());
                                else
                                    switch (HtupleVals[1])
                                    {
                                        case cValueTypes.MIXED:
                                            rtcvarValue.SetValue(rtcvar, GlobFuncs.Str2StringObj(HtupleVals[0]));
                                            break;
                                        default:
                                            break;
                                    }


                            }
                            break;
                        }
                    case nameof(SString):
                        rtcvarValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                        break;
                    case nameof(SInt):
                        rtcvarValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                        break;
                    //case nameof(SLong):
                    //    rtcvarValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Long(r, cColName.ValueI));
                    //    break;
                    case nameof(SDouble):
                        rtcvarValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Double(r, cColName.ValueD));
                        break;
                    default:
                        break;
                }

                if (targetAction.RunIsSilent != null && nProperty.Name == nameof(targetAction.RunIsSilent))
                    targetAction.RunIsSilent.rtcValue = true;
                if (targetAction.InputImage != null && nProperty.Name == nameof(targetAction.InputImage))
                    targetAction.InputImage.rtcValue = null;
                rtcvar.rtcIsParent = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcIsParent);
                rtcvar.rtcIDRef = GlobFuncs.GetDataRowValue_Guid(r, cColName.rtcIDRef);
                rtcvar.rtcPropNameRef = GlobFuncs.GetDataRowValue_String(r, cColName.rtcPropNameRef);
                rtcvar.rtcRef = GlobFuncs.GetDataRowValue_String(r, cColName.rtcRef);
                rtcvar.rtcDisplay = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcDisplay);
                rtcvar.rtcDisplayValueInHistory = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcDisplayValueInHistory);
                if (r.Table.Columns.Contains(cColName.rtcIsCanReset))
                    rtcvar.rtcIsCanReset = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcIsCanReset);
                rtcvar.rtcResetWhenStart = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcResetWhenStart);
                rtcvar.rtcResetWhenStop = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcResetWhenStop);
                rtcvar.ParentIDResets = GlobFuncs.String2ListGuid(GlobFuncs.GetDataRowValue_String(r, cColName.ParentIDResets), cChars.Comma);
            }

            switch (targetAction.ActionType)
            {
                case EActionTypes.Branch:
                    targetAction.MyExpression = new cExpression(targetAction.Expression.rtcValue, targetAction.CalculateMode.rtcValue, EExpressionResultTypes.Boolean, false);
                    break;
                case EActionTypes.Switch:
                    targetAction.MyExpression = new cExpression(targetAction.Expression.rtcValue, targetAction.CalculateMode.rtcValue, EExpressionResultTypes.HTuple, false);
                    break;

                default:
                    break;
            }

            return true;
        }
        public bool CloneAction_ActionLinkProperty(cAction sourceAction, cAction targetAction)
        {
            try
            {
                if (targetAction.ActionType != EActionTypes.LinkValue)
                    return true;
                targetAction.LinkProperty = new List<cLinkProperty>();
                DataTable data = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.LinkProperty +
                                                     " WHERE " + cColName.ActionID + "='" + sourceAction.ID.ToString() +
                                                     "' ORDER BY OrderNum");
                if (data == null)
                    return true;

                foreach (DataRow r in data.Rows)
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
                                    linkItem.SourceIndex = new List<object>() { GlobFuncs.ListObject2StrWithType(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.STRING:
                                    linkItem.SourceIndex = new List<object>() { GlobFuncs.ListObject2StrWithType(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.DOUBLE:
                                    linkItem.SourceIndex = new List<object>() { GlobFuncs.ListObject2StrWithType(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.MIXED:
                                    List<object> HtupleValo = new List<object>();
                                    foreach (string item in HtupleVals)
                                        if (GlobFuncs.IsNumeric(item))
                                            HtupleValo.Append(double.Parse(item));
                                        else if (GlobFuncs.IsInt(item))
                                            HtupleValo.Append(int.Parse(item));
                                        else
                                            HtupleValo.Append(item);

                                    linkItem.SourceIndex = GlobFuncs.Str2StringObj(HtupleValo[0].ToString());
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
                                    linkItem.TargetIndex = new List<object>() { GlobFuncs.ListObject2StrWithType(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.STRING:
                                    linkItem.TargetIndex = new List<object>() { GlobFuncs.ListObject2StrWithType(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.DOUBLE:
                                    linkItem.TargetIndex = new List<object>() { GlobFuncs.ListObject2StrWithType(new List<object>() { HtupleVals[0] }) };
                                    break;
                                case cValueTypes.MIXED:
                                    List<object> HtupleValo = new List<object>();
                                    foreach (string item in HtupleVals)
                                        if (GlobFuncs.IsNumeric(item))
                                            HtupleValo.Append(double.Parse(item));
                                        else if (GlobFuncs.IsInt(item))
                                            HtupleValo.Append(int.Parse(item));
                                        else
                                            HtupleValo.Append(item);

                                    linkItem.TargetIndex = GlobFuncs.Str2StringObj(HtupleValo[0].ToString());
                                    break;
                                case cValueTypes.EMPTY:
                                    linkItem.TargetIndex = new List<object>();
                                    break;
                                default:
                                    break;
                            }
                    }
                    else linkItem.TargetIndex = new List<object>();
                    targetAction.LinkProperty.Add(linkItem);
                }

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public bool CloneAction_ActionROIs(cAction sourceAction, cAction targetAction)
        {
            try
            {
                targetAction.ROIs = new Dictionary<long, object>();
                DataTable data = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ROIs + " WHERE " +
                                                     cColName.ActionID + "='" + sourceAction.ID.ToString() + "' AND " +
                                                     cColName.ConnectType + "<>" +
                                                     ((int)EConnectTypes.Reference).ToString());
                if (data == null)
                    return true;
                EDrawingtypes eDrawingTypes = EDrawingtypes.none;
                foreach (DataRow r in data.Rows)
                {
                    eDrawingTypes = (EDrawingtypes)GlobFuncs.GetDataRowValue_Int(r, cColName.DrawingType);
                    switch (eDrawingTypes)
                    {
                        case EDrawingtypes.Rectang:
                            cRectangType Rec = new cRectangType();
                            Rec.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                            Rec.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                            Rec.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                            Rec.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                            Rec.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                            Rec.Width = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                            Rec.Height = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                            Rec.DrawingType = eDrawingTypes;
                            Rec.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                            Rec.AnimationType = (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                            Rec.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            targetAction.ROIs.Add(Rec.ID, Rec);
                            break;
                        case EDrawingtypes.Ellipse:
                            cEllipseType Ell = new cEllipseType();
                            Ell.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                            Ell.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                            Ell.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                            Ell.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                            Ell.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                            Ell.Radius1 = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                            Ell.Radius2 = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                            Ell.DrawingType = eDrawingTypes;
                            Ell.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                            Ell.AnimationType = (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                            Ell.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            targetAction.ROIs.Add(Ell.ID, Ell);
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

                switch (targetAction.ActionType)
                {
                    case EActionTypes.Pattern:
                        {
                            if (targetAction.PlacementMode.rtcValue == cPlacementMode.WherePlacedOnImage)
                            {
                                data = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ROIs + " WHERE " +
                                                           cColName.ActionID + "='" + sourceAction.ID.ToString() + "' AND " +
                                                           cColName.ConnectType + "=" +
                                                           ((int)EConnectTypes.Reference).ToString());
                                if (data == null)
                                    return true;
                                DataRow r = data.Rows[0];
                                targetAction.ReferencePointRectangle = new cRectangType();
                                targetAction.ReferencePointRectangle.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                                targetAction.ReferencePointRectangle.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                                targetAction.ReferencePointRectangle.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                                targetAction.ReferencePointRectangle.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                                targetAction.ReferencePointRectangle.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                                targetAction.ReferencePointRectangle.Width = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                                targetAction.ReferencePointRectangle.Height = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                                targetAction.ReferencePointRectangle.DrawingType = eDrawingTypes;
                                targetAction.ReferencePointRectangle.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                                targetAction.ReferencePointRectangle.AnimationType = (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                                targetAction.ReferencePointRectangle.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            }
                            break;
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
        public bool CloneAction_FindROIs(cAction sourceAction, cAction targetAction)
        {
            try
            {
                targetAction.FindROIs = new Dictionary<long, object>();
                DataTable data = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.FindROIs + " WHERE " +
                                                     cColName.ActionID + "='" + sourceAction.ID.ToString() + "'");
                if (data == null)
                    return true;
                EDrawingtypes eDrawingTypes = EDrawingtypes.none;
                foreach (DataRow r in data.Rows)
                {
                    eDrawingTypes = (EDrawingtypes)GlobFuncs.GetDataRowValue_Int(r, cColName.DrawingType);
                    switch (eDrawingTypes)
                    {
                        case EDrawingtypes.Rectang:
                            cRectangType Rec = new cRectangType();
                            Rec.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                            Rec.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                            Rec.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                            Rec.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                            Rec.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                            Rec.Width = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                            Rec.Height = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                            Rec.DrawingType = eDrawingTypes;
                            Rec.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                            Rec.AnimationType = (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                            Rec.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            targetAction.FindROIs.Add(Rec.ID, Rec);
                            break;
                        case EDrawingtypes.Ellipse:
                            cEllipseType Ell = new cEllipseType();
                            Ell.ID = GlobFuncs.GetDataRowValue_Long(r, cColName.ID);
                            Ell.Center.Col = GlobFuncs.GetDataRowValue_Double(r, cColName.X);
                            Ell.Center.Row = GlobFuncs.GetDataRowValue_Double(r, cColName.Y);
                            Ell.Center.Z = GlobFuncs.GetDataRowValue_Double(r, cColName.Z);
                            Ell.Phi = GlobFuncs.GetDataRowValue_Double(r, cColName.Phi);
                            Ell.Radius1 = GlobFuncs.GetDataRowValue_Double(r, cColName.Length1);
                            Ell.Radius2 = GlobFuncs.GetDataRowValue_Double(r, cColName.Length2);
                            Ell.DrawingType = eDrawingTypes;
                            Ell.ConnectType = (EConnectTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ConnectType);
                            Ell.AnimationType = (EAnimationTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.AnimationType);
                            Ell.IsDisplayOutPut = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsDisplayOutput);
                            targetAction.FindROIs.Add(Ell.ID, Ell);
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
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool CloneAction_ActionLinkPassFail(cAction sourceAction, cAction targetAction)
        {
            try
            {
                switch (targetAction.ActionType)
                {
                    case EActionTypes.PassFail:
                        targetAction.LinkPassFail = new List<cLinkPassFail>();
                        break;
                    case EActionTypes.ResetTool:
                        targetAction.ListResetTools = new List<cLinkPassFail>();
                        break;
                }
                DataTable data = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.LinkPassFail + " WHERE " +
                                                     cColName.ActionID + "='" + sourceAction.ID.ToString() + "' ORDER BY STT");
                if (data == null)
                    return true;
                foreach (DataRow r in data.Rows)
                {
                    cLinkPassFail link = new cLinkPassFail
                    {
                        rtcActive = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Active),
                        rtcIDref = GlobFuncs.GetDataRowValue_Guid(r, cColName.IDRef),
                        rtcInvert = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Invert),
                        rtcGetResult = GlobFuncs.GetDataRowValue_Boolean(r, cColName.GetResult),
                        rtcIDGetResult = GlobFuncs.GetDataRowValue_Guid(r, cColName.IDGetResult),
                        rtcPropNameRef = GlobFuncs.GetDataRowValue_String(r, cColName.PropName),
                        rtcRef = GlobFuncs.GetDataRowValue_String(r, cColName.Ref),
                        rtcSTT = GlobFuncs.GetDataRowValue_Int(r, cColName.STT)
                    };
                    switch (targetAction.ActionType)
                    {
                        case EActionTypes.PassFail:
                            targetAction.LinkPassFail.Add(link);
                            break;
                        case EActionTypes.ResetTool:
                            targetAction.ListResetTools.Add(link);
                            break;
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
        public bool CloneAction_StringBuilderItems(cAction sourceAction, cAction targetAction)
        {
            try
            {
                switch (targetAction.ActionType)
                {
                    case EActionTypes.StringBuilder:
                        targetAction.StringBuilders = new List<SStringBuilderItem>();
                        break;
                    case EActionTypes.Branch:
                        targetAction.MyExpression.Operands = new List<SStringBuilderItem>();
                        break;
                    case EActionTypes.BranchItem:
                        targetAction.DataItems = new List<SStringBuilderItem>();
                        break;
                    case EActionTypes.Switch:
                        targetAction.MyExpression.Operands = new List<SStringBuilderItem>();
                        break;
                }
                DataTable data = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.StringBuilderItems + " WHERE " +
                                                     cColName.ActionID + "='" + sourceAction.ID.ToString() + "' ORDER BY OrderNum");
                if (data == null)
                    return true;
                foreach (DataRow r in data.Rows)
                {
                    SStringBuilderItem sbItem = new SStringBuilderItem();
                    sbItem.ValueStyle = (EHTupleStyle)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueStyle);
                    sbItem.OrderNum = GlobFuncs.GetDataRowValue_Int(r, cColName.OrderNum);
                    sbItem.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                    sbItem.RefID = GlobFuncs.GetDataRowValue_Guid(r, cColName.RefID);
                    sbItem.RefPropName = GlobFuncs.GetDataRowValue_String(r, cColName.RefPropName);
                    sbItem.Ref = GlobFuncs.GetDataRowValue_String(r, cColName.Ref);

                    sbItem.ListDoubleValue = new List<double>();
                    sbItem.ListDoubleValue = new List<double>();

                    string htupleVal = GlobFuncs.GetDataRowValue_String(r, cColName.Value);
                    if (htupleVal != "")
                    {
                        string[] htupleVals = htupleVal.Split(cStrings.SepGDung);
                        if (htupleVals.Length != 2) sbItem.ListDoubleValue = new List<double>();
                        else
                            switch (htupleVals[1])
                            {
                                case cValueTypes.INTEGER:
                                    sbItem.ListDoubleValue = GlobFuncs.Str2DoubleArr(htupleVals[0]);
                                    break;
                                case cValueTypes.STRING:
                                    sbItem.ListStringValue = GlobFuncs.Str2StringArr(htupleVals[0]);
                                    break;
                                case cValueTypes.DOUBLE:
                                    sbItem.ListDoubleValue = GlobFuncs.Str2DoubleArr(htupleVals[0]);
                                    break;
                                case cValueTypes.MIXED:
                                    List<string> hTuple = new List<string>();
                                    List<string> mixed = GlobFuncs.Str2StringArr(htupleVals[0]);
                                    foreach (string item in mixed)

                                        if (GlobFuncs.IsNumeric(item))
                                            hTuple.Add(double.Parse(item).ToString());
                                        else if (GlobFuncs.IsInt(item))
                                            hTuple.Add(int.Parse(item).ToString());
                                        else
                                            hTuple.Add(item);
                                    sbItem.ListStringValue = hTuple;
                                    break;
                                case cValueTypes.EMPTY:
                                    sbItem.ListStringValue = new List<string>();
                                    sbItem.ListDoubleValue = new List<double>();

                                    break;
                                default:
                                    break;
                            }
                    }
                    sbItem.IscanReset = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsCanReset);
                    sbItem.IsParent = GlobFuncs.GetDataRowValue_Boolean(r, cColName.IsParent);
                    sbItem.TrueText = GlobFuncs.GetDataRowValue_String(r, cColName.TrueText);
                    sbItem.FalseText = GlobFuncs.GetDataRowValue_String(r, cColName.FalseText);
                    sbItem.DateFormat = (EDateFormat)GlobFuncs.GetDataRowValue_Int(r, cColName.DateFormat);
                    sbItem.DelimiterDate = (EDelimiterDate)GlobFuncs.GetDataRowValue_Int(r, cColName.DelimiterDate);
                    sbItem.TimeFormat = (ETimeFormat)GlobFuncs.GetDataRowValue_Int(r, cColName.TimeFormat);
                    sbItem.DelimiterTime = (EDelimiterTime)GlobFuncs.GetDataRowValue_Int(r, cColName.DelimiterTime);
                    sbItem.UseDecimalPlaces = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UseDecimalPlaces);
                    sbItem.DecimalPlaces = GlobFuncs.GetDataRowValue_Int(r, cColName.DecimalPlaces);
                    sbItem.UseMiniumLength = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UseMiniumLength);
                    sbItem.MiniumLength = GlobFuncs.GetDataRowValue_Int(r, cColName.MiniumLength);
                    sbItem.UseLimitInput = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UseLimitInput);
                    sbItem.MaximumLength = GlobFuncs.GetDataRowValue_Int(r, cColName.MaximumLength);
                    sbItem.UsePadOutput = GlobFuncs.GetDataRowValue_Boolean(r, cColName.UsePadOutput);
                    sbItem.PadOutPut = (EPadOutPut)GlobFuncs.GetDataRowValue_Int(r, cColName.PadOutput);
                    sbItem.PadWith = (EPadWiths)GlobFuncs.GetDataRowValue_Int(r, cColName.PadWith);
                    sbItem.GroupingBracket = (EGroupingBracket)GlobFuncs.GetDataRowValue_Int(r, cColName.GroupingBracket);
                    sbItem.XYDelimiter = (EXYDelimiter)GlobFuncs.GetDataRowValue_Int(r, cColName.XYDelimiter);
                    sbItem.ElementDelimiter.DelimiterTypes = (EDelimiterTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.E_DelimiterType);
                    sbItem.ElementDelimiter.StandardValue = (EDelimiter)GlobFuncs.GetDataRowValue_Int(r, cColName.E_StandardValue);
                    sbItem.ElementDelimiter.CustomValue = GlobFuncs.GetDataRowValue_String(r, cColName.E_CustomValue);

                    switch (targetAction.ActionType)
                    {
                        case EActionTypes.StringBuilder:
                            targetAction.StringBuilders.Add(sbItem);
                            break;
                        case EActionTypes.Branch:
                            targetAction.MyExpression.Operands.Add(sbItem);
                            break;
                        case EActionTypes.BranchItem:
                            targetAction.DataItems.Add(sbItem);
                            break;
                        case EActionTypes.Switch:
                            targetAction.MyExpression.Operands.Add(sbItem);
                            break;
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
        public bool CloneAction_ImageFilterList(cAction sourceAction, cAction targetAction)
        {
            try
            {
                targetAction.ImageFilterProperty = new List<cImageFilterProperty>();
                DataTable data = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ImageFilterList + " WHERE " +
                                                     cColName.ActionID + "='" + sourceAction.ID.ToString() + "' ORDER BY OrderNum");
                if (data == null)
                    return true;
                foreach (DataRow r in data.Rows)
                {
                    cImageFilterProperty filterProperty = new cImageFilterProperty
                    {
                        ID = Guid.NewGuid(),
                        OrderNum = GlobFuncs.GetDataRowValue_Int(r, cColName.OrderNum),
                        Active = GlobFuncs.GetDataRowValue_Boolean(r, cColName.Active),
                        FilterType = GlobFuncs.GetDataRowValue_String(r, cColName.FilterType),
                        MaskWidth = GlobFuncs.GetDataRowValue_Int(r, cColName.MaskWidth),
                        MaskHeight = GlobFuncs.GetDataRowValue_Int(r, cColName.MaskHeight),
                        Iterations = GlobFuncs.GetDataRowValue_Int(r, cColName.Iterations),
                        InRangeOutputPixel = GlobFuncs.GetDataRowValue_Int(r, cColName.InRangeOutputPixel),
                        OutRangeOutputPixel = GlobFuncs.GetDataRowValue_Int(r, cColName.OutRangeOutputPixel),
                        Margin = GlobFuncs.GetDataRowValue_String(r, cColName.Margin),
                        IDRefRegion = GlobFuncs.GetDataRowValue_Guid(r, cColName.IDRefRegion),
                        PropNameRefRegion = GlobFuncs.GetDataRowValue_String(r, cColName.PropNameRefRegion),
                        ThresholdRange =
                        {
                            rtcValue = GlobFuncs.GetHTupleFromHTupleSaveData(GlobFuncs.GetDataRowValue_String(r, cColName.ThresholdRange))
                        },
                        GrayValue =
                        {
                            rtcValue = GlobFuncs.GetHTupleFromHTupleSaveData(GlobFuncs.GetDataRowValue_String(r, cColName.GrayValue))
                        }
                    };
                    targetAction.ImageFilterProperty.Add(filterProperty);
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool CloneAction_ROIProperties(cAction sourceAction, cAction targetAction)
        {
            try
            {
                targetAction.ROIProperties = new Dictionary<long, cROIProperty>();
                DataTable data = Myconn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ROIProperties + " WHERE " +
                                                     cColName.ActionID + "='" + sourceAction.ID.ToString() + "'");
                if (data == null)
                    return true;
                data.TableName = cTableName_SaveTemplate.ROIProperties;
                data.Columns[cColName.ActionID].Namespace = cColName.KEY;
                data.Columns[cColName.ID].Namespace = cColName.KEY;
                data.Columns[cColName.PropName].Namespace = cColName.KEY;

                var keys = new DataColumn[3];
                keys[0] = data.Columns[cColName.ActionID];
                keys[1] = data.Columns[cColName.ID];
                keys[2] = data.Columns[cColName.PropName];
                data.PrimaryKey = keys;

                // Lấy danh sách các ID ROIProperties
                DataRow[] dataRows = data.Select();
                var datarowIDs = dataRows.GroupBy(x => x[cColName.ID]).Select(x => x.First());
                foreach (DataRow r in datarowIDs)
                {
                    cROIProperty _ROIProp = new cROIProperty(targetAction.ActionType, GlobFuncs.GetDataRowValue_Long(r, cColName.ID));
                    _ROIProp.IDLink = GlobFuncs.GetDataRowValue_Int(r, cColName.IDLink);
                    var ROIPprops = _ROIProp.GetType().GetProperties().Where(x => x != null);
                    PropertyInfo propertyInfoValue = null;

                    foreach (PropertyInfo propertyInfo in ROIPprops)
                    {
                        DataRow rprop = data.Rows.Find(new object[] { sourceAction.ID, _ROIProp.ID, propertyInfo.Name });
                        if (rprop == null) continue;
                        RTCVariableType rtcvar = (RTCVariableType)propertyInfo.GetValue(_ROIProp, null);
                        if (rtcvar == null) continue;
                        propertyInfoValue = propertyInfo.PropertyType.GetProperty(cPropertyName.rtcValue);
                        string HtupleVal = GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH);

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
                                HtupleVal = GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH);
                                if (HtupleVal != "")
                                {
                                    string[] HtupleVals = HtupleVal.Split(cStrings.SepGDung);
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

                                //propertyInfoValue.SetValue(rtcvar,new HTuple(GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH)));
                                break;
                            case nameof(SListString):
                                {
                                    HtupleVal = GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH);
                                    if (HtupleVal != "")
                                    {
                                        string[] HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                                        if (HtupleVals.Length != 2) propertyInfoValue.SetValue(rtcvar, new List<string>());
                                        else
                                            switch (HtupleVals[1])
                                            {

                                                case cValueTypes.STRING:
                                                    propertyInfoValue.SetValue(rtcvar, GlobFuncs.Str2StringArr(HtupleVals[0]));
                                                    break;

                                                case cValueTypes.EMPTY:
                                                    propertyInfoValue.SetValue(rtcvar, new List<string>());
                                                    break;
                                                default:
                                                    break;
                                            }
                                    }
                                    else propertyInfoValue.SetValue(rtcvar, new List<double>());

                                    //propertyInfoValue.SetValue(rtcvar,new HTuple(GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH)));
                                    break;
                                }
                            case nameof(SListObject):
                                {
                                    HtupleVal = GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH);
                                    if (HtupleVal != "")
                                    {
                                        string[] HtupleVals = HtupleVal.Split(cStrings.SepGDung);
                                        if (HtupleVals.Length != 2) propertyInfoValue.SetValue(rtcvar, new List<string>());
                                        else
                                            switch (HtupleVals[1])
                                            {

                                                case cValueTypes.MIXED:
                                                    List<object> hTuple = new List<object>();
                                                    List<string> mixed = GlobFuncs.Str2StringArr(HtupleVals[0]);
                                                    foreach (string item in mixed)
                                                        if (GlobFuncs.IsInt(item))
                                                            hTuple.Add(int.Parse(item));
                                                        else if (GlobFuncs.IsNumeric(item))
                                                            hTuple.Add(double.Parse(item));
                                                        else
                                                            hTuple.Add(item);

                                                    propertyInfoValue.SetValue(rtcvar, hTuple);
                                                    break;


                                                default:
                                                    break;
                                            }
                                    }
                                    else propertyInfoValue.SetValue(rtcvar, new List<double>());

                                    //propertyInfoValue.SetValue(rtcvar,new HTuple(GlobFuncs.GetDataRowValue_String(rprop, cColName.ValueH)));
                                    break;
                                }
                            case nameof(SDouble):
                                propertyInfoValue.SetValue(rtcvar, GlobFuncs.GetDataRowValue_Double(rprop, cColName.ValueD));
                                break;
                            default:
                                continue;
                        }
                    }
                    if (_ROIProp.IDLink == 0) _ROIProp.IDLink = -1;
                    targetAction.ROIProperties.Add(_ROIProp.ID, _ROIProp);
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool SaveActionSettingsConfig(cGroupActions _Group)
        {
            try
            {
                if (ActionSettings == null)
                    return false;
                bool Result = false;
                foreach (cAction action in _Group.Actions.Values)
                {
                    var listPropertiesSaveConfig = action.GetType().GetProperties().Where(x => x != null
                    && ((RTCVariableType)x.GetValue(action, null)) != null
                    && ((RTCVariableType)x.GetValue(action, null)).rtcSaveToFile
                    && ((RTCVariableType)x.GetValue(action, null)).rtcSaveToFileConfig).ToList();
                    if (!listPropertiesSaveConfig.Any())
                    {
                        continue;
                    }
                    PropertyInfo nProperty;
                    for (int i = 0; i < listPropertiesSaveConfig.Count; i++)
                    {
                        nProperty = listPropertiesSaveConfig[i];
                        RTCVariableType rtcvar = (RTCVariableType)action.GetType().GetProperty(nProperty.Name).GetValue(action, null);

                        PropertyInfo rtcvarValue = nProperty.PropertyType.GetProperty(cPropertyName.rtcValue);
                        DataRow r = _ActionSettings.NewRow();
                        SetNullValueToDataRow(r);
                        r[cColName.ActionID] = action.ID;
                        r[cColName.rtcDisplay] = rtcvar.rtcDisplay.ToString().ToLower();
                        r[cColName.rtcDisplayValueInHistory] = rtcvar.rtcDisplayValueInHistory.ToString().ToLower();
                        r[cColName.rtcDisplayText] = rtcvar.rtcDisplayText;
                        r[cColName.rtcIsHighLight] = rtcvar.rtcIsHighLight.ToString().ToLower();
                        r[cColName.PropName] = nProperty.Name;
                        object obj = rtcvarValue.GetValue(rtcvar, null);
                        switch (nProperty.PropertyType.Name)
                        {
                            case nameof(SBool):
                                r[cColName.ValueT] = obj.ToString().ToLower();
                                break;
                            case nameof(SWindow):
                                break;
                            case nameof(SString):
                                r[cColName.ValueT] = (string)obj;
                                break;
                            case nameof(SListDouble):
                                r[cColName.ValueH] = GlobFuncs.ListDouble2StrWithType((List<double>)obj);
                                break;
                            case nameof(SListString):
                                r[cColName.ValueH] = GlobFuncs.ListString2StrWithType((List<string>)obj);
                                break;
                            case nameof(SListObject):
                                r[cColName.ValueH] = GlobFuncs.ListObject2StrWithType((List<object>)obj);
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
                        Result = Myconn.AddRow(r);
                        if (!Result) break;
                    }
                    if (action.IsMultiROI)
                        Result = SaveActionROIPropertiesConfig(action);
                    if (!Result) return false;
                }
                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool SaveActionROIPropertiesConfig(cAction action)
        {
            try
            {
                if (ROIProperties == null)
                    return true;
                if (action.ROIProperties == null) return true;
                foreach (cROIProperty ROIP in action.ROIProperties.Values)
                {
                    var ROIPprops = ROIP.GetType().GetProperties().Where(x => x != null && x.GetValue(ROIP, null) != null && ((RTCVariableType)x.GetValue(ROIP, null)).rtcSaveToFileConfig);
                    PropertyInfo propertyInfoValue = null;
                    foreach (PropertyInfo propertyInfo in ROIPprops)
                    {
                        RTCVariableType rtcvar = (RTCVariableType)ROIP.GetType().GetProperty(propertyInfo.Name).GetValue(ROIP, null);
                        DataRow r = _ROIProperties.NewRow();
                        SetNullValueToDataRow(r);

                        r[cColName.ActionID] = action.ID.ToString();
                        r[cColName.ActionType] = action.ActionType;
                        r[cColName.ID] = ROIP.ID.ToString();
                        r[cColName.PropName] = propertyInfo.Name;

                        propertyInfoValue = rtcvar.GetType().GetProperty(cPropertyName.rtcValue);
                        object obj = propertyInfoValue.GetValue(rtcvar, null);
                        switch (propertyInfo.PropertyType.Name)
                        {
                            case nameof(SBool):
                                r[cColName.ValueT] = obj.ToString().ToLower();
                                break;
                            case nameof(SWindow):
                                break;
                            case nameof(SImage):
                                break;
                            case nameof(SListDouble):
                                r[cColName.ValueH] = GlobFuncs.ListDouble2StrWithType((List<double>)obj);
                                break;
                            case nameof(SListString):
                                r[cColName.ValueH] = GlobFuncs.ListString2StrWithType((List<string>)obj);
                                break;
                            case nameof(SListObject):
                                r[cColName.ValueH] = GlobFuncs.ListObject2StrWithType((List<object>)obj);
                                break;
                            case nameof(SString):
                                r[cColName.ValueT] = (string)obj;
                                break;
                            case nameof(SDouble):
                                r[cColName.ValueD] = (double)obj;
                                break;
                            case nameof(SInt):
                                r[cColName.ValueI] = (int)obj;
                                break;
                            case nameof(SObject):
                                r[cColName.ValueH] = obj;
                                break;
                            default:
                                break;
                        }
                        if (!Myconn.AddRow(r)) return false;
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
        public bool OpenActionSettingsConfig(cAction action)
        {
            try
            {
                if (ActionSettings == null)
                    return false;
                var orderedProperty = action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(action, null)) != null &&
                    !((RTCVariableType)x.GetValue(action, null)).rtcSaveToFile &&
                    ((RTCVariableType)x.GetValue(action, null)).rtcSaveToFileConfig).ToList();
                foreach (var nProperty in orderedProperty)
                {
                    RTCVariableType property = (RTCVariableType)action.GetType().GetProperty(nProperty.Name)?.GetValue(action, null);
                    if (property == null) continue;
                    PropertyInfo valueInfo = nProperty.PropertyType.GetProperty(cPropertyName.rtcValue);
                    if (valueInfo == null)
                        continue;
                    DataRow r = _ActionSettings.Rows.Find(new object[] { action.ID, nProperty.Name });
                    if (r == null) continue;
                    string rowValueString = GlobFuncs.GetDataRowValue_String(r, cColName.ValueH);
                    switch (nProperty.PropertyType.Name)
                    {
                        case nameof(SBool):
                            valueInfo.SetValue(property, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                            break;
                        case nameof(SWindow):
                            continue;
                        case nameof(SImage):
                            break;
                        case nameof(SListDouble):
                            //HTuple hTuple = new HTuple(new object[] { GlobFuncs.GetDataRowValue_String(r, cColName.ValueH).Split(cStrings.SepPhay) });
                            if (rowValueString != "")
                            {
                                string[] strings = rowValueString.Split(cStrings.SepGDung);
                                if (strings.Length != 2) valueInfo.SetValue(property, new List<double>());
                                else
                                    switch (strings[1])
                                    {
                                        case cValueTypes.INTEGER:
                                            valueInfo.SetValue(property, GlobFuncs.Str2DoubleArr(strings[0]));
                                            break;
                                        case cValueTypes.LONG:
                                            valueInfo.SetValue(property, GlobFuncs.Str2DoubleArr(strings[0]));
                                            break;
                                        case cValueTypes.DOUBLE:
                                            valueInfo.SetValue(property, GlobFuncs.Str2DoubleArr(strings[0]));
                                            break;

                                        case cValueTypes.EMPTY:
                                            valueInfo.SetValue(property, new List<double>());
                                            break;
                                        default:
                                            break;
                                    }
                            }
                            else valueInfo.SetValue(property, new List<double>());

                            break;
                        case nameof(SListString):
                            if (rowValueString != "")
                            {
                                string[] strings = rowValueString.Split(cStrings.SepGDung);
                                if (strings.Length != 2) valueInfo.SetValue(property, new List<double>());
                                else
                                    switch (strings[1])
                                    {
                                        case cValueTypes.STRING:
                                            valueInfo.SetValue(property, GlobFuncs.Str2StringArr(strings[0]));
                                            break;
                                        case cValueTypes.EMPTY:
                                            valueInfo.SetValue(property, new List<string>());
                                            break;
                                        default:
                                            break;
                                    }
                            }
                            else valueInfo.SetValue(property, new List<string>());
                            break;
                        case nameof(SListObject):
                            {
                                if (rowValueString != "")
                                {
                                    string[] strings = rowValueString.Split(cStrings.SepGDung);
                                    if (strings.Length != 2) valueInfo.SetValue(property, new List<double>());
                                    else
                                        switch (strings[1])
                                        {
                                            case cValueTypes.MIXED:
                                                List<object> Mixed = GlobFuncs.Str2StringObj(strings[0]);
                                                List<object> MixedValue = new List<object>();
                                                foreach (string item in Mixed)
                                                {
                                                    if (GlobFuncs.IsNumeric(item))
                                                        MixedValue.Add(double.Parse(item));
                                                    else if (GlobFuncs.IsInt(item))
                                                        MixedValue.Add(int.Parse(item));
                                                    else
                                                        MixedValue.Add(item);
                                                }
                                                valueInfo.SetValue(property, MixedValue);
                                                break;
                                            case cValueTypes.EMPTY:
                                                valueInfo.SetValue(property, new List<object>());
                                                break;
                                            default:
                                                break;
                                        }
                                }
                                else valueInfo.SetValue(property, new List<object>());
                                break;
                            }
                        case nameof(SString):
                            valueInfo.SetValue(property, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                            break;
                        case nameof(SInt):
                            valueInfo.SetValue(property, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case nameof(SDouble):
                            valueInfo.SetValue(property, GlobFuncs.GetDataRowValue_Double(r, cColName.ValueD));
                            break;
                        default:
                            break;
                    }
                    property.rtcDisplay = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcDisplay);
                    property.rtcDisplayValueInHistory = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcDisplayValueInHistory);
                    property.rtcIsHighLight = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcIsHighLight);
                    property.rtcSaveToFileConfig = GlobFuncs.GetDataRowValue_Boolean(r, cColName.rtcSaveToFileConfig);
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        #endregion
        #region OTHER FUNCTION
        internal bool DeleteDataTable(string tableName)
        {
            return Myconn.DeleteDataTable(tableName);
        }
        #endregion
    }
}
