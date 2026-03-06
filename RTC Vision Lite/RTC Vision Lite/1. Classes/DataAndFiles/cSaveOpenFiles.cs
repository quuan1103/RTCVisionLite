using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    public class cSaveOpenFiles
    {
        private bool IsFileLocked(string filename)
        {
            bool Locked = false;
            try
            {
                FileStream fs = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch(IOException)
            {
                Locked = true;
            }
            return Locked;
        }

        public EFunctionReturn SaveGroup(cGroupActions _Group, bool _WidthDialog = false, bool _WidthMessageBox = true, bool _WidthBackup = false)
        {
            EFunctionReturn Result = EFunctionReturn.Error;
            string _OldFileNameIconic = string.Empty;
            GroupActionsData groupActionsData = null;
            try
            {
                string _FileName = string.Empty;
                string _FileNameBAK = string.Empty;
                if(_Group == null)
                {
                    if (_WidthMessageBox)
                        cMessageBox.Warning(cMessageContent.War_GroupIsNotExists);
                    return EFunctionReturn.Error;
                }
                _OldFileNameIconic = _Group.FileNameIconic;

                if (_WidthDialog || _Group.FileName == string.Empty)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = cDialogCaptions.SaveFile;
                    saveFileDialog.InitialDirectory = GlobVar.RTCVision.Paths.OldPathSaveGroup;
                    saveFileDialog.Filter = cDialogFilters.SaveGroup;
                    saveFileDialog.CheckFileExists = false;
                    saveFileDialog.OverwritePrompt = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                        return EFunctionReturn.Cancel;
                    _FileName = saveFileDialog.FileName;
                    if (!_FileName.EndsWith(cExtFile.GroupD))
                        _FileName = _FileName + cExtFile.GroupD;
                }
                else _FileName = _Group.FileName;
                // thành lập luôn tên file iconnic
                _Group.FileNameIconic = Path.GetDirectoryName(_FileName) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(_FileName) + cExtFile.GroupIconicD;

                if(_WidthBackup)
                    if(!BackupFile(_FileName, out _FileNameBAK))
                    {
                        if (_WidthMessageBox)
                            cMessageBox.Warning(cMessageContent.Err_SaveGroup_SaveBAKErr);
                    }
                //Tiến hành sao chép tệp mẫu lưu thành tệp lưu
                if (!File.Exists(GlobVar.RTCVision.Files.SaveTemplate))
                {
                    if (_WidthMessageBox)
                        cMessageBox.Warning(cMessageContent.Err_Save_SaveTemplateIsNotExist);
                    return EFunctionReturn.Error;
                }
                // sao chép thành file cần lưu
                File.Copy(GlobVar.RTCVision.Files.SaveTemplate, _FileName, true);
                groupActionsData = new GroupActionsData();

               //thực hiện kết nối
                if (groupActionsData.Connect(_FileName))
                    Result = EFunctionReturn.Success;
                else
                {
                    if (_WidthMessageBox)
                        cMessageBox.Warning(cMessageContent.Err_Save_SaveTemplateIsNotExist);
                    Result = EFunctionReturn.Error;
                }
                try
                {
                    groupActionsData.Myconn.StartTransaction();

                    bool KQ = groupActionsData.ClearAllData();
                    if (KQ) KQ = groupActionsData.SaveGroup(_Group);
                    if (KQ) KQ = groupActionsData.SaveGroup_ComputerSettings(_Group);
                    if (KQ) KQ = groupActionsData.SaveGroup_CameraSettings(_Group);
                    if (KQ) KQ = groupActionsData.SaveGroup_SourceImages(_Group);
                    if (KQ) KQ = groupActionsData.SaveGroup_Trigger(_Group);
                    if (KQ) KQ = groupActionsData.SaveGroup_Info(_Group);
                   // if (KQ) KQ = groupActionsData.SaveGroup_Trigger(_Group);
                    if (KQ) KQ = groupActionsData.SaveActionList(_Group);
                    if (KQ)
                        groupActionsData.Myconn.Commit();
                    else
                        groupActionsData.Myconn.RollBack();
                }
                catch
                {
                    groupActionsData.Myconn.RollBack();
                    Result = EFunctionReturn.Error;
                }
                finally
                {
                    groupActionsData.Disconnect();
                }

                if(Result == EFunctionReturn.Success)
                {
                    _Group.FileName = _FileName;
                }
                else
                {
                    if(_WidthBackup)
                    {
                        RestoreBackUpFile(_FileName, _FileNameBAK);
                        _Group.FileNameIconic = _OldFileNameIconic;
                    }
                }
            }
            catch(Exception ex)
            {
                if (_WidthMessageBox)
                    cMessageBox.Warning(cMessageContent.Err_SaveGroup);
                GlobFuncs.SaveErr(ex);
                Result = EFunctionReturn.Error;
                _Group.FileNameIconic = _OldFileNameIconic;
            }

            return Result;
        }

        public cGroupActions OpenGroup(FrmHsmartWindow _frmHsmartWindow, GraphicsWindow.GraphicsWindow _picture, out EFunctionReturn eFunctionReturn, string _FileName = "", string _FileNameIconic = "", bool _WidthMessageBox = true)
        {
            cGroupActions _Group = new cGroupActions(_frmHsmartWindow);
            _Group.SmartWindowControl = _picture;

            eFunctionReturn = EFunctionReturn.Cancel;
            try
            {
                if(_FileName == "")
                {
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Title = cDialogCaption.OpenFile;
                    openDialog.InitialDirectory = GlobVar.RTCVision.Paths.OldPathOpenGroup;
                    openDialog.Filter = cDialogFilters.OpenGroup;
                    openDialog.CheckFileExists = true;

                    if(openDialog.ShowDialog() == DialogResult.Cancel)
                    {
                        eFunctionReturn = EFunctionReturn.Cancel;
                        return null;
                    }

                    _FileName = openDialog.FileName;
                    if (!_FileName.EndsWith(cExtFile.GroupD))
                        _FileName = _FileName + cExtFile.GroupD;

                    _FileNameIconic = Path.GetDirectoryName(_FileName) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(_FileName) + cExtFile.GroupIconicD;
                }

                if(!File.Exists(_FileName))
                {
                    if(_WidthMessageBox)
                        cMessageBox.Warning(string.Format(cMessageContent.War_FileNotExists, _FileName));
                    eFunctionReturn = EFunctionReturn.Error;
                    return null;
                }

                GroupActionsData groupActionsData = new GroupActionsData();

                if (groupActionsData.Connect(_FileName))
                    eFunctionReturn = EFunctionReturn.Success;
                else
                {
                    if (_WidthMessageBox)
                        cMessageBox.Warning(cMessageContent.Err_OpenGroup_CanNotConnectToFile);
                    eFunctionReturn = EFunctionReturn.Error;
                    return null;
                }
                try
                {
                    groupActionsData.Myconn.StartTransaction();
                    _Group.FileName = _FileName;
                    _Group.FileNameIconic = _FileNameIconic;
                    //groupActionsData.OpenGroup_GetInfo();
                    groupActionsData.OpenGroup_GetInfo();
                    bool KQ = groupActionsData.OpenGroup(_Group);
                    if (KQ) KQ = groupActionsData.OpenGroup_ComputerSettings(_Group);
                    if (KQ) KQ = groupActionsData.OpenGroup_CameraSettings(_Group);
                    if (KQ) KQ = groupActionsData.OpenGroup_SourceImages(_Group);
                    //if (KQ) KQ = groupActionsData.OpenGroup_Trigger(_Group);
                    if (KQ) KQ = groupActionsData.OpenActionList(_Group);
                    _Group.SourceImageSettings.OldImageSourceType = _Group.SourceImageSettings.ImageSourceType;
                    eFunctionReturn = KQ ? EFunctionReturn.Success : EFunctionReturn.Error;

                    if (eFunctionReturn == EFunctionReturn.Success)
                        _Group.FileName = _FileName;
                    else
                        _Group = null;
              


                }
                catch
                {
                    _Group = null;
                    eFunctionReturn = EFunctionReturn.Error;
                }
                finally
                {
                    groupActionsData.Myconn.Commit();
                    groupActionsData.Disconnect();
                }
            }
            catch(Exception ex)
            {
                _Group = null;
                GlobFuncs.SaveErr(ex);
            }

            return _Group;
        }

        private bool RestoreBackUpFile(string _FileName, string _FileNameBAK, bool _WidthMessageBox = false)
        {
            try
            {
                if(File.Exists(_FileName))
                {
                    if(IsFileLocked(_FileName))
                    {
                        if (_WidthMessageBox)
                            cMessageBox.Warning(string.Format(cMessageContent.War_FileIsUsed));
                        return false;
                    }
                }
                if (File.Exists(_FileNameBAK))
                {
                    if (IsFileLocked(_FileNameBAK))
                    {
                        if (_WidthMessageBox)
                            cMessageBox.Warning(string.Format(cMessageContent.War_FileIsUsed, _FileNameBAK));
                        return false;
                    }
                }
                File.Delete(_FileName);

                File.Move(_FileNameBAK, _FileName);

                return true;
            }
            catch(Exception ex)
            {
                if(_WidthMessageBox)
                    cMessageBox.Warning(string.Format(cMessageContent.Err_SaveGroup_RestoreBAKErr));
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        private bool BackupFile(string _FileName, out string _FileNameBAK, bool _WidthMessageBox = false)
        {
            try
            {
                _FileNameBAK = _FileName + cExtFile.BAKD;
                if(File.Exists(_FileNameBAK))
                {
                    if(IsFileLocked(_FileNameBAK))
                    {
                        if (_WidthMessageBox)
                            cMessageBox.Warning(cMessageContent.War_SaveGroup_BakIsUsed);
                        return false;
                    }

                    File.Delete(_FileNameBAK);
                }
                else
                {
                    _FileNameBAK = string.Empty;
                    return true;
                }

                File.Copy(_FileName, _FileNameBAK, true);
                return true;
            }
            catch(Exception ex)
            {
                _FileNameBAK = string.Empty;
                if(_WidthMessageBox)
                    cMessageBox.Warning(cMessageContent.War_SaveGroup_BakIsUsed);
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public EFunctionReturn SaveConfig(cGroupActions group, string dbFileName, string iconicFileName, out string errMessage, bool withMessageBox = false)
        {
            errMessage = string.Empty;
            try
            {
                EFunctionReturn eFunctionReturn = EFunctionReturn.Error;
                if (!File.Exists(dbFileName))
                    File.Copy(GlobVar.RTCVision.Files.SaveTemplate, dbFileName);
                GroupActionsData groupActionsData = new GroupActionsData();
                if (!groupActionsData.Connect(dbFileName))
                {
                    errMessage = cMessageContent.Err_OpenGroup_CanNotConnectToFile;
                    return EFunctionReturn.Error;
                }
                try
                {
                    groupActionsData.Myconn.StartTransaction();
                    bool KQ = groupActionsData.ClearAllData();
                    if (KQ)
                        KQ = groupActionsData.SaveActionSettingsConfig(group);
                    eFunctionReturn = KQ ? EFunctionReturn.Success : EFunctionReturn.Error;
                }
                catch (Exception ex)
                {
                    GlobFuncs.SaveErr(ex);
                    errMessage = ex.Message;
                    eFunctionReturn = EFunctionReturn.Error;
                }
                finally
                {
                    if (eFunctionReturn == EFunctionReturn.Success)
                        groupActionsData.Myconn.Commit();
                    else
                        groupActionsData.Myconn.RollBack();
                    groupActionsData.Disconnect();
                    if (!string.IsNullOrWhiteSpace(errMessage) && withMessageBox)
                    {
                        cMessageBox.Warning(errMessage);
                    }
                }
                return eFunctionReturn;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                errMessage = ex.Message;
                if (withMessageBox)
                {
                    cMessageBox.Warning(errMessage);
                }
                return EFunctionReturn.Error;
            }
        }
        public EFunctionReturn LoadConfig(cGroupActions group, string dbFileName, string iconicFileName, out string errMessage, bool withMessageBox = false)
        {
            errMessage = string.Empty;
            try
            {
                EFunctionReturn eFunctionReturn = EFunctionReturn.Error;
                if (!File.Exists(dbFileName))
                {
                    errMessage = cMessageContent.BuildMessage(cMessageContent.War_FileNameIsExists, new string[] { dbFileName }, new string[] { dbFileName });
                    return EFunctionReturn.Error;
                }
                GroupActionsData groupActionsData = new GroupActionsData();
                if (!groupActionsData.Connect(dbFileName))
                {
                    errMessage = cMessageContent.Err_OpenGroup_CanNotConnectToFile;
                    return EFunctionReturn.Error;
                }
                ////Read File dict lên
                //SListObject dict = null;
                //if(File.Exists(iconicFileName))
                //    try
                //    {

                //    }
                //    catch
                //    {
                //        dict = null;
                //    }
                try
                {
                    bool KQ = false;
                    foreach (cAction action in group.Actions.Values)
                    {
                        KQ = groupActionsData.OpenActionSettingsConfig(action);
                        if (KQ)
                            KQ = groupActionsData.OpenActionROIProperties(action);
                        if (!KQ)
                            break;
                    }
                }
                catch (Exception e)
                {
                    GlobFuncs.SaveErr(e);
                    errMessage = e.Message;
                    eFunctionReturn = EFunctionReturn.Error;
                }
                finally
                {
                    groupActionsData.Disconnect();
                    if (!string.IsNullOrEmpty(errMessage) && withMessageBox)
                    {
                        cMessageBox.Warning(errMessage);
                    }
                }
                return eFunctionReturn;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                errMessage = ex.Message;
                if (withMessageBox)
                {
                    cMessageBox.Warning(errMessage);
                }
                return EFunctionReturn.Error;
            }
        }

    }
}
