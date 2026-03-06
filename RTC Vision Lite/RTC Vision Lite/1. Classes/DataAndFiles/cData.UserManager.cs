using RTCConst;
using RTCEnums;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserManager.Classes;
using System;
using System.Data;
using System.Linq;
using RTCLibs;

namespace RTC_Vision_Lite.Classes
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A common data. </summary>
    ///
    /// <remarks>   DATRUONG, 30/08/2021. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class cUserManagerData
    {
        public bool ReloadData_User = false;
        public bool ReloadData_Position = false;
        public bool ReloadData_Department = false;
        public bool ReloadData_Permission = false;
        public bool ReloadData_PermissionDetail = false;
        public string DataFileName = string.Empty;
        public cSQLite MyConn = null;

        #region PROPERTY
        private DataTable _userData = null;
        public DataTable UserData
        {
            get
            {
                if (_userData == null || ReloadData_User)
                    _userData = MyConn.GetDataTable("SELECT * FROM " + cTableName_UserManager.User + " ORDER BY OrderNum");

                if (_userData != null)
                {
                    _userData.TableName = cTableName_UserManager.User;
                    _userData.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _userData.Columns[cColName.ID];
                    _userData.PrimaryKey = keys;
                    ReloadData_User = false;
                }
                return _userData;
            }
            set => _userData = value;
        }
        private DataTable _config = null;
        public DataTable Config
        {
            get
            {
                if (!MyConn.IsTableExists(cTableName_UserManager.Config))
                {
                    MyConn.ExecuteQuery("CREATE TABLE 'Config' (" +
                                        "'Name'  TEXT," +
                                        "'Value'  TEXT)");
                }

                _config = MyConn.GetDataTable("SELECT * FROM " + cTableName_UserManager.Config);

                return _config;
            }
            set => _config = value;
        }
        private DataTable _departmentData = null;
        public DataTable DepartmentData
        {
            get
            {
                if (_departmentData == null || ReloadData_Department)
                    _departmentData = MyConn.GetDataTable("SELECT * FROM " + cTableName_UserManager.Department + " ORDER BY OrderNum");

                if (_departmentData != null)
                {
                    _departmentData.TableName = cTableName_UserManager.Department;
                    _departmentData.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _departmentData.Columns[cColName.ID];
                    _departmentData.PrimaryKey = keys;
                    ReloadData_Department = false;
                }
                return _departmentData;
            }
            set => _departmentData = value;
        }

        private DataTable _permissionData = null;
        public DataTable PermissionData
        {
            get
            {
                if (_permissionData == null || ReloadData_Permission)
                    _permissionData = MyConn.GetDataTable("SELECT * FROM " + cTableName_UserManager.Permission + " ORDER BY OrderNum");

                if (_permissionData != null)
                {
                    _permissionData.TableName = cTableName_UserManager.Permission;
                    _permissionData.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _permissionData.Columns[cColName.ID];
                    _permissionData.PrimaryKey = keys;
                    ReloadData_Permission = false;
                }
                return _permissionData;
            }
            set => _permissionData = value;
        }

        private DataTable _permissionDataDetail = null;
        public DataTable PermissionDataDetail
        {
            get
            {
                if (_permissionDataDetail == null || ReloadData_PermissionDetail)
                    _permissionDataDetail = MyConn.GetDataTable($"SELECT * FROM {cTableName_UserManager.PermissionDetail} ORDER BY OrderNum");

                if (_permissionDataDetail != null)
                {
                    _permissionDataDetail.TableName = cTableName_UserManager.PermissionDetail;

                    _permissionData.Columns[cColName.ID].Caption = cColName.KEY;
                    _permissionData.Columns[cColName.PermissionName].Caption = cColName.KEY;
                    var keys = new DataColumn[2];
                    keys[0] = _permissionData.Columns[cColName.ID];
                    keys[1] = _permissionData.Columns[cColName.PermissionName];
                    _permissionData.PrimaryKey = keys;
                    ReloadData_PermissionDetail = false;
                }
                return _permissionDataDetail;
            }
            set => _permissionDataDetail = value;
        }

        private DataTable _positionData = null;
        public DataTable PositionData
        {
            get
            {
                if (_positionData == null || ReloadData_Position)
                    _positionData = MyConn.GetDataTable("SELECT * FROM " + cTableName_UserManager.Position + " ORDER BY OrderNum");

                if (_positionData != null)
                {
                    _positionData.TableName = cTableName_UserManager.Position;
                    _positionData.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _positionData.Columns[cColName.ID];
                    _positionData.PrimaryKey = keys;
                    ReloadData_Position = false;
                }
                return _positionData;
            }
            set => _positionData = value;
        }
        #endregion

        #region FUNCTIONS
        private void SetNullValueToDataRow(DataRow row)
        {
            foreach (DataColumn item in row.Table.Columns)
            {
                row[item] = DBNull.Value;
            }
        }
        public bool IsConnected()
        {
            return MyConn != null && MyConn.IsConnected;
        }
        public bool Connect(string dataFileName)
        {
            DataFileName = dataFileName;
            MyConn = new cSQLite(DataFileName);
            return MyConn.Connect();
        }
        public void Disconnect()
        {
            if (MyConn != null && MyConn.IsConnected)
            {
                MyConn.Close();
            }
            MyConn = null;
        }
        public DataTable LoadPermissionDetailById(Guid permissionId)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return null;
            DataTable dataTable = MyConn.GetDataTable($"SELECT * FROM {cTableName_UserManager.PermissionDetail} WHERE PermissionID='{permissionId}' ORDER BY OrderNum");

            if (dataTable != null)
            {
                dataTable.TableName = cTableName_UserManager.PermissionDetail;

                dataTable.Columns[cColName.PermissionID].Caption = cColName.KEY;
                dataTable.Columns[cColName.PermissionName].Caption = cColName.KEY;
                var keys = new DataColumn[2];
                keys[0] = dataTable.Columns[cColName.PermissionID];
                keys[1] = dataTable.Columns[cColName.PermissionName];
                dataTable.PrimaryKey = keys;
            }
            return dataTable;
        }
        public bool SaveUser(DataRow useRow, EUserActionData userActionData)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return false;

            switch (userActionData)
            {
                case EUserActionData.Add:
                    if (MyConn.AddRow(useRow))
                    {
                        if (_userData != null)
                            _userData.Rows.Add(useRow);
                        return true;
                    }
                    else return false;
                case EUserActionData.Edit:
                    return MyConn.EditRow(useRow);
            }

            return false;
        }
        public bool SavePermission(DataRow permissionRow, DataTable permissionDetail, EUserActionData userActionData)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return false;
            bool isSuccess = false;
            switch (userActionData)
            {
                case EUserActionData.Add:
                    {
                        isSuccess = MyConn.AddRow(permissionRow);
                        if (permissionDetail != null && isSuccess)
                            foreach (DataRow row in permissionDetail.Rows)
                            {
                                row[cColName.PermissionID] = permissionRow[cColName.ID];
                                isSuccess = MyConn.AddRow(row);
                                if (!isSuccess)
                                    break;
                            }
                        if (isSuccess)
                        {
                            _permissionData.Rows.Add(permissionRow);
                            if (_permissionDataDetail != null)
                                foreach (DataRow row in permissionDetail.Rows)
                                    _permissionDataDetail.Rows.Add(row);
                        }
                        break;
                    }
                case EUserActionData.Edit:
                    {
                        isSuccess = MyConn.EditRow(permissionRow);
                        if (permissionDetail != null && isSuccess)
                            foreach (DataRow row in permissionDetail.Rows)
                            {
                                isSuccess = MyConn.EditRow(row);
                                if (!isSuccess)
                                    break;
                            }
                        break;
                    }
            }

            return isSuccess;
        }
        public bool SaveDepartment(DataRow departmentRow, EUserActionData userActionData)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return false;
            switch (userActionData)
            {
                case EUserActionData.Add:
                    if (MyConn.AddRow(departmentRow))
                    {
                        if (_departmentData != null)
                            _departmentData.Rows.Add(departmentRow);
                        return true;
                    }
                    return false;
                case EUserActionData.Edit:
                    return MyConn.EditRow(departmentRow);
            }
            return false;
        }
        public bool SavePosition(DataRow positionRow, EUserActionData userActionData)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return false;
            switch (userActionData)
            {
                case EUserActionData.Add:
                    if (MyConn.AddRow(positionRow))
                    {
                        if (_positionData != null)
                            _positionData.Rows.Add(positionRow);
                        return true;
                    }
                    return false;
                case EUserActionData.Edit:
                    return MyConn.EditRow(positionRow);
            }
            return false;
        }
        public bool DeleteUser(DataRow useRow)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return false;
            if (MyConn.DeleteRow(useRow))
            {
                if (_userData != null)
                    _userData.Rows.Remove(useRow);
                return true;
            }
            return false;
        }
        public bool DeletePermission(DataRow permissionRow)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return false;
            if (MyConn.DeleteRow(permissionRow))
            {
                MyConn.ExecuteQuery("DELETE FROM " + cTableName_UserManager.PermissionDetail +
                    " WHERE " + cColName.PermissionID + "='" + permissionRow[cColName.ID].ToString() + "'");
                if (_permissionData != null)
                    _permissionData.Rows.Remove(permissionRow);
                return true;
            }
            return false;
        }
        public bool DeleteDepartment(DataRow departmentRow)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return false;

            if (MyConn.DeleteRow(departmentRow))
            {
                if (_departmentData != null)
                    _departmentData.Rows.Remove(departmentRow);
                return true;
            }
            return false;
        }
        public bool DeletePosition(DataRow positionRow)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return false;
            if (MyConn.DeleteRow(positionRow))
            {
                if (_positionData != null)
                    _positionData.Rows.Remove(positionRow);
                return true;
            }
            return false;
        }
        public int NameIsExists(string name, DataRow userRow, EUserActionData userActionData)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return 0;
            switch (userActionData)
            {
                case EUserActionData.Add:
                    return MyConn.ExecuteScalar_Int("SELECT Name FROM " + cTableName_UserManager.User + " WHERE Name='" + name + "'");
                case EUserActionData.Edit:
                    {
                        Guid id = GlobFuncs.GetDataRowValue_Guid(userRow, cColName.ID);
                        return MyConn.ExecuteScalar_Int("SELECT Name,ID FROM " + cTableName_UserManager.User +
                                                        " WHERE Name='" + name + "' AND ID<>'" + id.ToString() + "'");
                    }
            }

            return 0;
        }
        public int PermissionNameIsExists(string name, DataRow permissionRow, EUserActionData userActionData)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return 0;
            switch (userActionData)
            {
                case EUserActionData.Add:
                    return MyConn.ExecuteScalar_Int("SELECT Name FROM " + cTableName_UserManager.Permission + " WHERE Name='" + name + "'");
                case EUserActionData.Edit:
                    {
                        Guid id = GlobFuncs.GetDataRowValue_Guid(permissionRow, cColName.ID);
                        return MyConn.ExecuteScalar_Int("SELECT Name,ID FROM " + cTableName_UserManager.Permission +
                                                        " WHERE Name='" + name + "' AND ID<>'" + id.ToString() + "'");
                    }
            }

            return 0;
        }
        public int DepartmentNameIsExists(string name, DataRow departmentRow, EUserActionData userActionData)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return 0;
            switch (userActionData)
            {
                case EUserActionData.Add:
                    return MyConn.ExecuteScalar_Int("SELECT Name FROM " + cTableName_UserManager.Department + " WHERE Name='" + name + "'");
                case EUserActionData.Edit:
                    {
                        Guid id = GlobFuncs.GetDataRowValue_Guid(departmentRow, cColName.ID);
                        return MyConn.ExecuteScalar_Int("SELECT Name,ID FROM " + cTableName_UserManager.Department +
                                                        " WHERE Name='" + name + "' AND ID<>'" + id.ToString() + "'");
                    }
            }

            return 0;
        }
        public int PositionNameIsExists(string name, DataRow positionRow, EUserActionData userActionData)
        {
            if (MyConn == null || !MyConn.IsConnected)
                return 0;
            switch (userActionData)
            {
                case EUserActionData.Add:
                    return MyConn.ExecuteScalar_Int("SELECT Name FROM " + cTableName_UserManager.Position + " WHERE Name='" + name + "'");
                case EUserActionData.Edit:
                    {
                        Guid id = GlobFuncs.GetDataRowValue_Guid(positionRow, cColName.ID);
                        return MyConn.ExecuteScalar_Int("SELECT Name,ID FROM " + cTableName_UserManager.Position +
                                                        " WHERE Name='" + name + "' AND ID<>'" + id.ToString() + "'");
                    }
            }

            return 0;
        }
        /// <summary>
        /// Lấy thông tin quyền của 1 user từ data
        /// </summary>
        /// <param name="user">Đối tượng người dùng đăng nhập cần lấy dữ liệu</param>
        private void GetPermissionInData(cUser user)
        {
            //Lấy các quyền truy cập
            if (user.Permission == null)
                user.Permission = new cPermission();
            DataTable dataTable = MyConn.GetDataTable("SELECT * FROM PermissionDetail WHERE PermissionID='" + user.IDPermission.ToString() + "'");
            if (dataTable != null)
            {
                var keys = new DataColumn[2];
                keys[0] = dataTable.Columns[cColName.PermissionID];
                keys[1] = dataTable.Columns[cColName.PermissionName];
                dataTable.PrimaryKey = keys;

                //Settings
                DataRow rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.Settings) });
                GetPermissionDetail(user.Permission.Settings, rowPermissionDetail);

                //GeneralSettings
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.GeneralSettings) });
                GetPermissionDetail(user.Permission.GeneralSettings, rowPermissionDetail);

                //RunOptionsSettings
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.RunOptionsSettings) });
                GetPermissionDetail(user.Permission.RunOptionsSettings, rowPermissionDetail);

                //ViewOptionsSettings
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.ViewOptionsSettings) });
                GetPermissionDetail(user.Permission.ViewOptionsSettings, rowPermissionDetail);

                //ViewStyleSettings
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.ViewStyleSettings) });
                GetPermissionDetail(user.Permission.ViewStyleSettings, rowPermissionDetail);

                //ReportLogErrorSettings
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.ReportLogErrorSettings) });
                GetPermissionDetail(user.Permission.ReportLogErrorSettings, rowPermissionDetail);

                //ImageOptionsSettings
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.ImageOptionsSettings) });
                GetPermissionDetail(user.Permission.ImageOptionsSettings, rowPermissionDetail);

                //UpdateOptionsSettings
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.UpdateOptionsSettings) });
                GetPermissionDetail(user.Permission.UpdateOptionsSettings, rowPermissionDetail);

                //SecurityOptionsSettings
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.SecurityOptionsSettings) });
                GetPermissionDetail(user.Permission.SecurityOptionsSettings, rowPermissionDetail);

                //AcceptResult
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.AcceptResult) });
                GetPermissionDetail(user.Permission.AcceptResult, rowPermissionDetail);

                //SettingTools
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.SettingTools) });
                GetPermissionDetail(user.Permission.SettingTools, rowPermissionDetail);

                //Report
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.Report) });
                GetPermissionDetail(user.Permission.Report, rowPermissionDetail);

                //User
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.User) });
                GetPermissionDetail(user.Permission.User, rowPermissionDetail);

                //PermissionManager
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.Permission) });
                GetPermissionDetail(user.Permission.Permission, rowPermissionDetail);

                //DepartmentManager
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.Department) });
                GetPermissionDetail(user.Permission.Department, rowPermissionDetail);

                //Position
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.Position) });
                GetPermissionDetail(user.Permission.Position, rowPermissionDetail);

                //Position
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.Templates) });
                GetPermissionDetail(user.Permission.Templates, rowPermissionDetail);

                //Position
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.Model) });
                GetPermissionDetail(user.Permission.Model, rowPermissionDetail);

                //CleanImage
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.CleanImage) });
                GetPermissionDetail(user.Permission.CleanImage, rowPermissionDetail);

                //MovingTools
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.MovingTools) });
                GetPermissionDetail(user.Permission.MovingTools, rowPermissionDetail);

                //LinkValueTools
                rowPermissionDetail = dataTable.Rows.Find(new object[] { user.IDPermission, nameof(user.Permission.LinkValueTools) });
                GetPermissionDetail(user.Permission.LinkValueTools, rowPermissionDetail);
            }
        }
        public void GetPermission(Guid userId, out cUser user)
        {
            user = null;
            if (UserData != null)
            {
                DataRow row = _userData.Rows.Find(userId);

                if (row != null)
                {
                    user = new cUser
                    {
                        ID = GlobFuncs.GetDataRowValue_Guid(row, cColName.ID),
                        Name = GlobFuncs.GetDataRowValue_String(row, cColName.Name),
                        UserName = GlobFuncs.GetDataRowValue_String(row, cColName.UserName),
                        PassWordE = GlobFuncs.GetDataRowValue_String(row, cColName.PassWord),
                        PassWord = cEncryptDecrypt.Decrypt(GlobFuncs.GetDataRowValue_String(row, cColName.PassWord)),
                        Address = GlobFuncs.GetDataRowValue_String(row, cColName.Address),
                        Phone = GlobFuncs.GetDataRowValue_String(row, cColName.Phone),
                        Email = GlobFuncs.GetDataRowValue_String(row, cColName.Email),
                        Note = GlobFuncs.GetDataRowValue_String(row, cColName.Note),
                        IsActive = GlobFuncs.GetDataRowValue_Boolean(row, cColName.Active),
                        IDDepartment = GlobFuncs.GetDataRowValue_Guid(row, cColName.IDDepartment),
                        IDPermission = GlobFuncs.GetDataRowValue_Guid(row, cColName.IDPermission),
                        IDPosition = GlobFuncs.GetDataRowValue_Guid(row, cColName.IDPosition),
                        IsLogged = true
                    };

                    GetPermissionInData(user);
                }
            }
        }
        public void GetPermission(string userName, string passWord, out cUser user)
        {
            user = null;
            if (UserData != null)
            {
                DataRow[] rows = _userData.Select(cColName.UserName + " = '" + userName + "' AND " +
                    cColName.PassWord + "= '" + cEncryptDecrypt.Encrypt(passWord) + "'");
                if (rows.Any())
                {
                    user = new cUser
                    {
                        ID = GlobFuncs.GetDataRowValue_Guid(rows[0], cColName.ID),
                        Name = GlobFuncs.GetDataRowValue_String(rows[0], cColName.Name),
                        UserName = GlobFuncs.GetDataRowValue_String(rows[0], cColName.UserName),
                        PassWordE = GlobFuncs.GetDataRowValue_String(rows[0], cColName.PassWord),
                        PassWord = cEncryptDecrypt.Decrypt(GlobFuncs.GetDataRowValue_String(rows[0], cColName.PassWord)),
                        Address = GlobFuncs.GetDataRowValue_String(rows[0], cColName.Address),
                        Phone = GlobFuncs.GetDataRowValue_String(rows[0], cColName.Phone),
                        Email = GlobFuncs.GetDataRowValue_String(rows[0], cColName.Email),
                        Note = GlobFuncs.GetDataRowValue_String(rows[0], cColName.Note),
                        IsActive = GlobFuncs.GetDataRowValue_Boolean(rows[0], cColName.Active),
                        IDDepartment = GlobFuncs.GetDataRowValue_Guid(rows[0], cColName.IDDepartment),
                        IDPermission = GlobFuncs.GetDataRowValue_Guid(rows[0], cColName.IDPermission),
                        IDPosition = GlobFuncs.GetDataRowValue_Guid(rows[0], cColName.IDPosition),
                        IsLogged = true
                    };

                    GetPermissionInData(user);
                }
            }
        }
        private void GetPermissionDetail(cPermissionDetail permissionDetail, DataRow rowPermissionDetail)
        {
            if (rowPermissionDetail != null)
            {
                permissionDetail.Add = GlobFuncs.GetDataRowValue_Boolean(rowPermissionDetail, cColName.Add);
                permissionDetail.Edit = GlobFuncs.GetDataRowValue_Boolean(rowPermissionDetail, cColName.Edit);
                permissionDetail.Delete = GlobFuncs.GetDataRowValue_Boolean(rowPermissionDetail, cColName.Delete);
                permissionDetail.View = GlobFuncs.GetDataRowValue_Boolean(rowPermissionDetail, cColName.View);
                permissionDetail.Execute = GlobFuncs.GetDataRowValue_Boolean(rowPermissionDetail, cColName.Execute);
            }
        }
        public int GetMax(string tableName, string columnName)
        {
            try
            {
                return MyConn.ExecuteScalar_Int("SELECT MAX(" + columnName + ") FROM " + tableName);
            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }
}
