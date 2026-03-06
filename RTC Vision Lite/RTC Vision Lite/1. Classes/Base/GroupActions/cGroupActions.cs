using Emgu.CV.Structure;
using Emgu.CV;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.Properties;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cGroupActions
    {
        /// <summary>
        /// Danh sách các thuộc tính của tool là cha (Guid ở đây là ID của tool)
        /// </summary>
        internal Dictionary<Guid, List<PropertyInfo>> AllPropertyParentRef = null;
        /// <summary>
        /// Tạo 1 tool
        /// </summary>
        /// <param name="eActionType">lOẠI TOOL</param>
        /// <param name="eObjectType">KIỂU TOOL</param>
        /// <param name="onlyTool"></param>
        /// <returns></returns>
        public cAction CreateAction(EActionTypes eActionType, EObjectTypes eObjectType, bool onlyTool = false)
        {
            cAction _Action = new cAction(eActionType, eObjectType, frmHsmartWindow, this);
            // thành lập tên cho action
            if (_Action.InputImage != null && _Action.ActionType == EActionTypes.DialogMessage)
                _Action.InputImage.rtcValue = null;

            if (_Action.ActionType != EActionTypes.MainAction && _Action.ActionType != EActionTypes.None && _Action.ActionType != EActionTypes.PassFail)
            {
                // Link input image tự động
                cAction mainAction = Actions[IDMainAction];
                if (_Action.InputImage != null && _Action.ActionType != EActionTypes.SnapImage && _Action.ActionType != EActionTypes.DialogMessage)
                {
                    _Action.InputImage.rtcIDRef = IDMainAction;
                    _Action.InputImage.rtcPropNameRef = nameof(mainAction.InputImage);
                    _Action.InputImage.rtcRef = GlobFuncs.BuildRefString2(GlobVar.GroupActions, mainAction, nameof(mainAction.InputImage));
                    mainAction.InputImage.rtcIsParent = true;
                    _Action.InputImage.rtcValue = (Image)Actions[IDMainAction].InputImage.rtcValue?.Clone();

                    _Action.InputBgrImage.rtcValue = Actions[IDMainAction].InputBgrImage.rtcValue?.Clone();
                    _Action.InputBgrImage.rtcIDRef = IDMainAction;
                    _Action.InputBgrImage.rtcPropNameRef = nameof(mainAction.InputBgrImage);
                    _Action.InputBgrImage.rtcRef = GlobFuncs.BuildRefString2(GlobVar.GroupActions, mainAction, nameof(mainAction.InputBgrImage));
                    mainAction.InputBgrImage.rtcIsParent = true;
                    _Action.InputBgrImage.rtcValue = Actions[IDMainAction].InputBgrImage.rtcValue?.Clone();


                    _Action.InputGrayImage.rtcValue = Actions[IDMainAction].InputGrayImage.rtcValue?.Clone();
                    _Action.InputGrayImage.rtcIDRef = IDMainAction;
                    _Action.InputGrayImage.rtcPropNameRef = nameof(mainAction.InputGrayImage);
                    _Action.InputGrayImage.rtcRef = GlobFuncs.BuildRefString2(GlobVar.GroupActions, mainAction, nameof(mainAction.InputGrayImage));
                    mainAction.InputGrayImage.rtcIsParent = true;
                    _Action.InputGrayImage.rtcValue = Actions[IDMainAction].InputGrayImage.rtcValue?.Clone();
                }
                GenerateActionName(_Action);
            }
            else if (_Action.ActionType == EActionTypes.MainAction)
            {
                IDMainAction = _Action.ID;
            }
            STT += 1;
            _Action.STT = STT;
            Actions.Add(_Action.ID, _Action);
            SStringBuilderItem newItem = null;
            cAction action = null;
            if (!onlyTool)
            {
                switch (_Action.ActionType)
                {
                    case EActionTypes.Branch:
                        {
                            action = new cAction(EActionTypes.BranchItem, EObjectTypes.Action, frmHsmartWindow, this);
                            STT += 1;
                            action.STT = STT;
                            action.Name.rtcValue = cStrings.False.ToUpper();
                            action.IDBranch = _Action.ID;
                            action.Enable = _Action.Enable;
                            //action.IDBranchItem = action.ID;
                            Actions.Add(action.ID, action);

                            action = new cAction(EActionTypes.BranchItem, EObjectTypes.Action, frmHsmartWindow, this);
                            STT += 1;
                            action.STT = STT;
                            action.Name.rtcValue = cStrings.True.ToUpper();
                            action.Enable = _Action.Enable;
                            action.IDBranch = _Action.ID;
                            //action.IDBranchItem = action.ID;
                            Actions.Add(action.ID, action);

                            break;
                        }
                    case EActionTypes.Switch:
                        {
                            action = new cAction(EActionTypes.BranchItem, EObjectTypes.Action, frmHsmartWindow, this);
                            STT += 1;
                            action.STT = STT;
                            _Action.STTBranch += 1;
                            action.Name.rtcValue = cStrings.CASE + " " + _Action.STTBranch.ToString();
                            action.Name.rtcReadOnly = false;
                            action.IDBranch = _Action.ID;
                            action.BranchItemType.rtcValue = cStrings.Case;
                            action.DataItems = new List<SStringBuilderItem>();
                            newItem = new SStringBuilderItem
                            {
                                Name = cStrings.value
                            };
                            action.DataItems.Add(newItem);
                            Actions.Add(action.ID, action);

                            action = new cAction(EActionTypes.BranchItem, EObjectTypes.Action, frmHsmartWindow, this);
                            STT += 1;
                            action.STT = STT;
                            _Action.STTBranch += 1;
                            action.Name.rtcValue = cStrings.CASE + " " + _Action.STTBranch.ToString();
                            action.Name.rtcReadOnly = false;
                            action.IDBranch = _Action.ID;
                            action.BranchItemType.rtcValue = cStrings.Case;
                            action.DataItems = new List<SStringBuilderItem>();
                            newItem = new SStringBuilderItem
                            {
                                Name = cStrings.value
                            };
                            action.DataItems.Add(newItem);
                            Actions.Add(action.ID, action);

                            action = new cAction(EActionTypes.BranchItem, EObjectTypes.Action, frmHsmartWindow, this);
                            STT += 1;
                            action.STT = STT;
                            action.Name.rtcValue = cStrings.DEFAULTCASE;
                            action.IDBranch = _Action.ID;
                            action.BranchItemType.rtcValue = cStrings.DefaultCase;
                            Actions.Add(action.ID, action);
                            break;
                        }
                    case EActionTypes.PassFail:
                        {
                            action = new cAction(EActionTypes.BranchItem, EObjectTypes.Action, frmHsmartWindow, this);
                            STT += 1;
                            action.STT = STT;
                            action.Name.rtcValue = cStrings.Pass.ToUpper();
                            action.IDBranch = _Action.ID;
                            Actions.Add(action.ID, action);

                            action = new cAction(EActionTypes.BranchItem, EObjectTypes.Action, frmHsmartWindow, this);
                            STT += 1;
                            action.STT = STT;
                            action.Name.rtcValue = cStrings.Fail.ToUpper();
                            action.IDBranch = _Action.ID;
                            Actions.Add(action.ID, action);
                            break;
                        }
                    case EActionTypes.CounterLoop:
                        {
                            action = new cAction(EActionTypes.BranchItem, EObjectTypes.Action, frmHsmartWindow, this);
                            STT += 1;
                            action.STT = STT;
                            action.Name.rtcValue = cStrings.Loop.ToUpper();
                            action.IDBranch = _Action.ID;
                            Actions.Add(action.ID, action);
                            break;
                        }
                    case EActionTypes.RunDLL:
                        {
                            _Action.DataItems = new List<SStringBuilderItem>();
                            break;
                        }
                }
            }
            DataChanged = true;
            return _Action;
        }

        public void GenerateActionName(cAction action)
        {
            int i = 1;
            while (Actions.Values.Where(x => x.Name.rtcValue.ToLower() == action.Name.rtcValue.ToLower()).ToList().Count >= 1)
            {
                action.Name.rtcValue = CommonData.GetActionCaption(Enum.GetName(typeof(EActionTypes), action.ActionType), Enum.GetName(typeof(EActionTypes), action.ActionType)) + " " + i.ToString();
                i += 1;
            }
        }
        public bool RemoveAllAction()
        {
            try
            {
                var orderedlist = Actions.OrderBy(x => x.Value.STT).ToList();
                for (int i = 1; i < orderedlist.Count; i++)
                {
                    Actions.Remove(orderedlist[i].Value.ID);
                }
                Refvalues.Clear();
                DataChanged = true;
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool RemoveAction(Guid ActionID)
        {
            if (ActionID != Guid.Empty && Actions.ContainsKey(ActionID))
            {
                return RemoveAction(Actions[ActionID]);
            }
            return true;
        }
        /// <summary>
        /// Xóa bỏ 1 tool
        /// </summary>
        /// <param name="Action"> tool cần xóa</param>
        /// <returns> True if it susceeds, false if it fails</returns>
        public bool RemoveAction(cAction Action)
        {
            bool Result = false;
            try
            {
                if (Actions != null)
                {
                    RemoveActionLink(Action);

                    // Loại bỏ toàn bộ các property value trong bảng tham chiếu ref
                    var PropertyIsParents = Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(Action, null)) != null &&
                    ((RTCVariableType)x.GetValue(Action, null)).rtcActive && ((RTCVariableType)x.GetValue(Action, null)).rtcIsParent);

                    foreach (PropertyInfo nProperty in PropertyIsParents)
                    {
                        string sKey = Action.ID.ToString() + nProperty.Name;
                        if (Refvalues.ContainsKey(sKey)) Refvalues.Remove(sKey);

                    }
                    // Loại bỏ trong action Pass/Fail
                    var listPassFail = Actions.Values.Where(x => x.ActionType == EActionTypes.PassFail).ToList();
                    if (listPassFail.Any())
                    {
                        cAction _ActionPassFail = null;
                        for (int i = 0; i < listPassFail.Count(); i++)
                        {
                            _ActionPassFail = listPassFail[i];
                            var listLinkPassFail = _ActionPassFail.LinkPassFail.Where(x => x.rtcIDref == Action.ID).ToList();
                            if (listLinkPassFail != null && listLinkPassFail.Count > 0)
                                for (int i1 = 0; i1 < listLinkPassFail.Count; i1++)
                                {
                                    _ActionPassFail.LinkPassFail.Remove(listLinkPassFail[i1]);
                                }
                        }
                    }
                    // Loại bỏ trong ImageFilter
                    var listImageFilter = Actions.Values.Where(x => x.ActionType == EActionTypes.ImageFilter).ToList();
                    if (listImageFilter.Any())
                    {
                        foreach (cAction actionImageFilter in listImageFilter)
                        {
                            var listLinkImageFilterProperty = actionImageFilter.ImageFilterProperty.Where(x => x.IDRefRegion == Action.ID).ToList();
                            if (listLinkImageFilterProperty.Any())
                                foreach (cImageFilterProperty filterProperty in listLinkImageFilterProperty)
                                {
                                    filterProperty.IDRefRegion = Guid.Empty;
                                    filterProperty.PropNameRefRegion = string.Empty;
                                }
                        }
                    }
                    if (Action.ActionType == EActionTypes.Branch || Action.ActionType == EActionTypes.Switch
                        || Action.ActionType == EActionTypes.PassFail || Action.ActionType == EActionTypes.CounterLoop)
                    {
                        var listOperands = Actions.Values.Where(x => x.ActionType == EActionTypes.BranchItem && x.IDBranch == Action.ID).ToList();
                        cAction _ActionOperand = null;
                        for (int i = 0; i < listOperands.Count(); i++)
                        {
                            _ActionOperand = listOperands[i];
                            var listActionInOperand = Actions.Values.Where(x => x.IDBranchItem == _ActionOperand.ID).ToList();
                            if (listActionInOperand.Any())
                                for (int i1 = 0; i1 < listActionInOperand.Count; i1++)
                                    RemoveAction(listActionInOperand[i1]);
                            RemoveAction(_ActionOperand);
                        }
                    }

                }
                Actions.Remove(Action.ID);
                DataChanged = true;
                Result = true;
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        private void RemoveActionLink(cAction _Action)
        {
            foreach (cAction item in Actions.Values)
                if (item.ID != _Action.ID)
                {
                    var PropertyHaveRefs = item.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(item, null)) != null &&
                    ((RTCVariableType)x.GetValue(item, null)).rtcActive && ((RTCVariableType)x.GetValue(item, null)).rtcIDRef != Guid.Empty &&
                    ((RTCVariableType)x.GetValue(item, null)).rtcIDRef == _Action.ID);

                    foreach (PropertyInfo nProperty in PropertyHaveRefs)
                    {
                        RTCVariableType rtcvar = (RTCVariableType)item.GetType().GetProperty(nProperty.Name).GetValue(item, null);
                        if (rtcvar == null || !rtcvar.rtcActive || rtcvar.rtcIDRef == Guid.Empty) { continue; };
                        PropertyInfo PropIDRef = rtcvar.GetType().GetProperty(cPropertyName.rtcIDRef);
                        PropIDRef.SetValue(rtcvar, Guid.Empty);
                        PropertyInfo PropValue = rtcvar.GetType().GetProperty(cPropertyName.rtcValue);
                        switch (PropValue.PropertyType.Name)
                        {
                            case nameof(List<double>):
                                PropValue.SetValue(rtcvar, PropValue.GetValue(rtcvar, null));
                                break;
                            case nameof(Bitmap):
                                PropValue.SetValue(rtcvar, null);
                                break;
                            default:
                                PropValue.SetValue(rtcvar, PropValue.GetValue(rtcvar, null));
                                break;

                        }
                        if (item.ViewInfo != null)
                        {
                            ((ucBaseActionDetail)item.ViewInfo).UpdatePropertyValueToAllControls(nProperty.Name);
                        }
                    }

                }
        }

        public cGroupActions Clone(out bool isSuccess, bool isUseTempFile = true)
        {
            isSuccess = false;
            cGroupActions groupActionsClone = null;
            string oldFileName = FileName;
            string oldFileNameIconic = FileNameIconic;
            try
            {   // thành lập 1 tệp tạm
                if (isUseTempFile)
                {
                    FileName = Path.GetTempFileName();
                    FileNameIconic = !File.Exists(FileNameIconic) ? string.Empty : Path.GetTempFileName();
                }

                cSaveOpenFiles saveOpenFile = new cSaveOpenFiles();
                if (saveOpenFile.SaveGroup(this, false, false, false) == EFunctionReturn.Success)
                {
                    groupActionsClone = saveOpenFile.OpenGroup(this.frmHsmartWindow, this.SmartWindowControl, out EFunctionReturn eFunctionReturn, FileName, FileNameIconic, false);
                    groupActionsClone.SaveFileFolder = SaveFileFolder;
                    if (isUseTempFile)
                    {
                        groupActionsClone.FileName = oldFileName;
                        groupActionsClone.FileNameIconic = oldFileNameIconic;
                        try
                        {
                            if (File.Exists(FileName)) File.Delete(FileName);
                            if (File.Exists(FileNameIconic)) File.Delete(FileNameIconic);
                        }
                        catch (Exception ex)
                        {
                            GlobFuncs.SaveErr(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                if (isUseTempFile)
                {
                    if (File.Exists(FileName)) File.Delete(FileName);
                    if (File.Exists(FileNameIconic)) File.Delete(FileNameIconic);

                    FileName = oldFileName;
                    FileNameIconic = oldFileNameIconic;
                }
            }
            isSuccess = (groupActionsClone != null);
            return groupActionsClone ?? (groupActionsClone = this);
        }

        public cGroupActions(FrmHsmartWindow _frmHsmartWindow, bool IsTemplate = false)
        {
            ID = Guid.NewGuid();
            IDMainAction = Guid.Empty;
            STT = -1;
            RunCount = 0;
            PassCount = 0;
            FailCount = 0;
            Name = new SString(string.Empty);
            FeedbackData = string.Empty;
            SourceImageSettings = new cSourceImageSettings();
            ImageErrors = new List<string>();
            Refvalues = new Dictionary<string, object>();
            MyCam = null;
            Actions = new Dictionary<Guid, cAction>();
            Passed = false;
            RunSimple = true;
            frmHsmartWindow = _frmHsmartWindow;
            // Luôn tạo ra 1 action MAIN KHI tạo mới
            if (!IsTemplate)
            {
                Name.rtcValue = CreateAction(EActionTypes.MainAction, EObjectTypes.Group).Name.rtcValue;
            }
            DataChanged = false;
        }
        public cGroupActions(string groupName, FrmHsmartWindow _frmHsmartWindow, bool IsTemplate = false)
        {
            ID = Guid.NewGuid();
            IDMainAction = Guid.Empty;
            STT = -1;
            RunCount = 0;
            PassCount = 0;
            FailCount = 0;
            Name = new SString(string.Empty);
            FeedbackData = string.Empty;
            SourceImageSettings = new cSourceImageSettings();
            ImageErrors = new List<string>();
            Refvalues = new Dictionary<string, object>();
            MyCam = null;
            Actions = new Dictionary<Guid, cAction>();
            Passed = false;
            RunSimple = true;
            frmHsmartWindow = _frmHsmartWindow;
            // Luôn tạo ra 1 action MAIN KHI tạo mới
            if (!IsTemplate)
            {
                Name.rtcValue = CreateAction(EActionTypes.MainAction, EObjectTypes.Group).Name.rtcValue;
            }
            DataChanged = false;
        }

        public void SavePart(bool isThreading = false)
        {

        }
        private string SaveOriginImage_CreateFileName()
        {
            string fileName = SourceImageSettings.CameraSettings.SaveImagePrefixName != ""
                 ? SourceImageSettings.CameraSettings.SaveImagePrefixName + "_"
                 : "";
            switch (SourceImageSettings.CameraSettings.SuffixMode)
            {
                case ESuffixMode.Numbered:
                    {
                        SourceImageSettings.CameraSettings.SaveImageOrder =
                            SourceImageSettings.CameraSettings.SaveImageOrderOK >=
                            SourceImageSettings.CameraSettings.SaveImageOrderNG
                                ? SourceImageSettings.CameraSettings.SaveImageOrderOK
                                : SourceImageSettings.CameraSettings.SaveImageOrderNG;
                        if (SourceImageSettings.CameraSettings.AutoResetSaveImageOrder &&
                           SourceImageSettings.CameraSettings.SaveImageOrder == SourceImageSettings.CameraSettings.MaxSaveImageOrder)
                            SourceImageSettings.CameraSettings.SaveImageOrder = 0;

                        SourceImageSettings.CameraSettings.SaveImageOrder += 1;
                        fileName = $"{fileName} {SourceImageSettings.CameraSettings.SaveImageOrder}.{SourceImageSettings.CameraSettings.SaveImageType}";
                        break;
                    }
                default:
                    {
                        fileName = $"{fileName} {DateTime.Now.ToString(SourceImageSettings.CameraSettings.SaveImageDateTimeFormat)}.{SourceImageSettings.CameraSettings.SaveImageType}";
                        break;
                    }
            }
            return fileName.Trim();
        }
        /// <summary>
        /// REBUILD PASSFAIL LINK ITEM
        /// </summary>
        public void RebuildPassFailLinkItem()
        {

            var listActionPassFails = Actions.Values.Where(x => x.ActionType == EActionTypes.PassFail).ToList();
            foreach (cAction actionPassFail in listActionPassFails)
            {
                cAction action = null;
                List<cLinkPassFail> newLinkPassFails = new List<cLinkPassFail>();
                var orderedList = GlobVar.GroupActions.Actions.OrderBy(x => x.Value.STT).ToList();
                foreach (var t in orderedList)
                {
                    action = t.Value;
                    if (action.ActionType == EActionTypes.MainAction ||
                        action.ID == actionPassFail.ID ||
                        action.STT >= actionPassFail.STT ||
                        action.Passed == null)
                        continue;

                    cLinkPassFail oldLinkPassFail = actionPassFail.LinkPassFail.FirstOrDefault(x => x.rtcIDref == action.ID);
                    cLinkPassFail newLinkPassFail = new cLinkPassFail
                    {
                        rtcActive = false,
                        rtcIDref = action.ID,
                        rtcPropNameRef = nameof(action.Passed)
                    };
                    PropertyInfo propertyInfoSrc = action.GetType().GetProperty(nameof(action.Passed));
                    newLinkPassFail.rtcRef = GlobFuncs.BuildRefString_Property(GlobVar.GroupActions, action, propertyInfoSrc);

                    if (oldLinkPassFail != null)
                    {
                        newLinkPassFail.rtcPropNameRef = oldLinkPassFail.rtcPropNameRef;
                        newLinkPassFail.rtcActive = oldLinkPassFail.rtcActive;
                        newLinkPassFail.rtcInvert = oldLinkPassFail.rtcInvert;
                        newLinkPassFail.rtcGetResult = oldLinkPassFail.rtcGetResult;
                        newLinkPassFail.rtcIDGetResult = oldLinkPassFail.rtcIDGetResult;
                    }
                    newLinkPassFails.Add(newLinkPassFail);
                }

                foreach (cLinkPassFail linkPassFail in newLinkPassFails)
                    if (linkPassFail.rtcIDGetResult != actionPassFail.ID && newLinkPassFails.FirstOrDefault(x => x.rtcIDref == linkPassFail.rtcIDGetResult) == null)
                        linkPassFail.rtcIDGetResult = Guid.Empty;

                actionPassFail.LinkPassFail = newLinkPassFails;
            }
        }
        /// <summary>
        /// REBUILD RESET TOOLS ITEM
        /// </summary>
        public void RebuildResetToolsItem()
        {

            var resetTools = Actions.Values.Where(x => x.ActionType == EActionTypes.ResetTool);
            if (!resetTools.Any()) return;

            var orderedList = Actions.OrderBy(x => x.Value.STT).ToList();
            foreach (var resetAction in resetTools)
            {
                List<cLinkPassFail> newListResetTools = new List<cLinkPassFail>();
                foreach (var item in orderedList)
                {
                    cAction normalAction = item.Value;

                    if (normalAction.ActionType == EActionTypes.MainAction ||
                        normalAction.ActionType == EActionTypes.PassFail ||
                        normalAction.ActionType == EActionTypes.Branch ||
                        normalAction.ActionType == EActionTypes.Switch ||
                        normalAction.ActionType == EActionTypes.CounterLoop ||
                        normalAction.ActionType == EActionTypes.BranchItem ||
                        normalAction.ActionType == EActionTypes.ResetTool)
                        continue;
                    cLinkPassFail oldResetAction = resetAction.ListResetTools.FirstOrDefault(x => x.rtcIDref == normalAction.ID);
                    cLinkPassFail newResetAction = new cLinkPassFail
                    {
                        rtcActive = false,
                        rtcIDref = normalAction.ID,
                    };

                    if (oldResetAction != null)
                        newResetAction.rtcActive = oldResetAction.rtcActive;
                    newListResetTools.Add(newResetAction);
                }
                resetAction.ListResetTools = newListResetTools;
            }
        }
        public void CreateSaveFolder()
        {
            SourceImageSettings.CameraSettings.SaveImageFolder_Origin_Withday =
                GlobFuncs.CreateSaveFolderWithDay(SourceImageSettings.CameraSettings.SaveImageFolder_Origin);
            if (!Directory.Exists(SourceImageSettings.CameraSettings.SaveImageFolder_Origin_Withday))
                Directory.CreateDirectory(SourceImageSettings.CameraSettings.SaveImageFolder_Origin_Withday);

            SourceImageSettings.CameraSettings.SaveImageFolder_Pass_Withday =
               GlobFuncs.CreateSaveFolderWithDay(SourceImageSettings.CameraSettings.SaveImageFolder_Pass);
            if (!Directory.Exists(SourceImageSettings.CameraSettings.SaveImageFolder_Pass_Withday))
                Directory.CreateDirectory(SourceImageSettings.CameraSettings.SaveImageFolder_Pass_Withday);

            SourceImageSettings.CameraSettings.SaveImageFolder_Fail_Withday =
               GlobFuncs.CreateSaveFolderWithDay(SourceImageSettings.CameraSettings.SaveImageFolder_Fail);
            if (!Directory.Exists(SourceImageSettings.CameraSettings.SaveImageFolder_Fail_Withday))
                Directory.CreateDirectory(SourceImageSettings.CameraSettings.SaveImageFolder_Fail_Withday);

            SourceImageSettings.CameraSettings.SaveImageFolder_Snap_Withday =
               GlobFuncs.CreateSaveFolderWithDay(SourceImageSettings.CameraSettings.SaveImageFolder_Snap);
            if (!Directory.Exists(SourceImageSettings.CameraSettings.SaveImageFolder_Snap_Withday))
                Directory.CreateDirectory(SourceImageSettings.CameraSettings.SaveImageFolder_Snap_Withday);
        }

        public void TriggerBySoftware(bool isOnlySnap = false)
        {
            lock (LockTriggerSoftwareObject)
            {

                if (IsTriggerBySoftware)
                    return;
                if (SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera || !IsRun)
                {
                    if (!ConnectAllCameraUse(true))
                        return;
                }
                if (!IsRun)
                {
                    try
                    {
                        IsTriggerBySoftware = true;
                        SnapImage(true, true);
                    }
                    finally
                    {
                        IsTriggerBySoftware = false;
                    }
                }
                else
                {
                    IsTriggerBySoftware = true;
                }
            }
            IsTriggerBySoftware = true;
            if (isOnlySnap)
                SnapImage(true, true);
            else if (!IsRun)
                Setting_Run(ERunActionMode.Next, true);
        }

        public void RunBefore(cAction Action, bool _WithShowMessage = false)
        {
            if (Actions.Count <= 0) return;
            Image inputImage;
            Bitmap bitmapImage = null;
            if (frmHsmartWindow != null) frmHsmartWindow.FileName = string.Empty;

            if (SourceImageSettings.ImageSourceType == EImageSourceTypes.Computer)
            {
                if (SourceImageSettings.IsNoImage)
                {
                    inputImage = GetDefaultImage();
                    bitmapImage = new Bitmap(inputImage);
                }
                else
                {
                    SourceImageSettings.ComputerSettings.CurrentImgIndex =
                        (SourceImageSettings.ComputerSettings.CurrentImgIndex >= 0 &&
                        SourceImageSettings.ComputerSettings.CurrentImgIndex <=
                        SourceImageSettings.ComputerSettings.Images.Count - 1)
                        ? SourceImageSettings.ComputerSettings.CurrentImgIndex
                        : 0;
                    inputImage = Image.FromFile(SourceImageSettings.ComputerSettings
                        .Images[SourceImageSettings.ComputerSettings.CurrentImgIndex].FileName);
                    frmHsmartWindow.FileName = SourceImageSettings.ComputerSettings
                        .Images[SourceImageSettings.ComputerSettings.CurrentImgIndex].FileName;
                    bitmapImage = new Bitmap(inputImage);
                }
            }
            else
            {
                if (GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsLive)
                {
                    GlobVar.GroupActions.SetLiveCamera(false);
                    inputImage = GlobVar.GroupActions.SnapImage();
                    bitmapImage = new Bitmap(inputImage);
                }
                else if (GlobVar.GroupActions.frmHsmartWindow != null && GlobVar.GroupActions.frmHsmartWindow.Image != null)
                {
                    inputImage = GlobVar.GroupActions.frmHsmartWindow.Image;
                    bitmapImage = new Bitmap(inputImage);
                }
                else
                {
                    inputImage = ((ucMainActions)Actions[IDMainAction].ViewInfo).TakePicture(true);
                    if (inputImage != null)
                        bitmapImage = new Bitmap(inputImage);
                }

            }
            //if (inputImage == null) return;
            MainAction.InputImage.rtcValue = bitmapImage;
            if (bitmapImage != null)
            {
                MainAction.InputGrayImage.rtcValue = GlobFuncs.BitmapToGrayImage(bitmapImage);
                MainAction.InputBgrImage.rtcValue = GlobFuncs.BitmapToBgrImage(bitmapImage);
            }
            //using (Bitmap clonedImage = (Bitmap)inputImage.Clone())
            //{
            //    GlobVar.BGRImage = GlobFuncs.BitmapToBgrImage(clonedImage);
            //    GlobVar.GrayImage = GlobFuncs.BitmapToGrayImage(clonedImage);
            //    MainAction.InputImage.rtcGray = GlobVar.GrayImage;
            //    MainAction.InputImage.rtcBgr = GlobVar.BGRImage;
            //}
            SetValuetoVariableIsParentRef(MainAction);
            // tạm thời rem bỏ đây theo y/c mới nhằm không chạy những tool trước đó, việc thay đổi thông số hoặc ảnh sẽ bắt buộc bấm run toàn bộ.
            var orderedList = Actions.Where(x => x.Value.STT < Action.STT).OrderBy(x => x.Value.STT).ToList();
            for (int i = 1; i < orderedList.Count; i++)
                if (orderedList[i].Value.STT < Action.STT)
                {
                    SetValuetoVariableIsParentRef(orderedList[i].Value);
                }

        }
        ////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Lưu giá trị của toàn bộ property được link đến các tool khác trong bảng giá trị.
        /// </summary>
        /// ///
        /// <param name="action">Tool cần lưu</param>
        /// ////////////////////////////////////////////////////////////////////////////////////
        public void SetValuetoVariableIsParentRef(cAction action)
        {
            List<PropertyInfo> propertyParentRefs = null;
            if (RunSimple && AllPropertyParentRef != null)
                AllPropertyParentRef?.TryGetValue(action.ID, out propertyParentRefs);
            if (propertyParentRefs == null)
                propertyParentRefs = action.GetType().GetProperties().Where(x =>
                ((RTCVariableType)x.GetValue(action, null)) != null &&
                ((RTCVariableType)x.GetValue(action, null)).rtcActive &&
                ((RTCVariableType)x.GetValue(action, null)).rtcIsParent).ToList();
            foreach (PropertyInfo nProperty in propertyParentRefs)
            {
                object obj = action.GetType().GetProperty(nProperty.Name)?.GetValue(action, null);
                //TODO: Chỗ này đang thử để hàm này
                SetValueToDicRefValue(action, nProperty.Name,
                    obj?.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(obj, null));


            }
            List<SStringBuilderItem> dataItems = action.DataItems ?? ((action.MyExpression != null && action.MyExpression.Operands != null)
                ? action.MyExpression.Operands
                : null);
            if (dataItems != null)
                foreach (var dataItem in dataItems)
                    if (dataItem.IsParent)
                        SetValueToDicRefValue(action, dataItem.Name, dataItem.ListStringValue);

            propertyParentRefs = null;
        }
        ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Lưu giá trị của 1 property vào bảng giá trị
        /// </summary>
        /// <param name="action"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// ///////////////////////////////////////////////////////////////////////////////
        private void SetValueToDicRefValue(cAction action, string propertyName, object value)
        {
            if (Refvalues == null)
                Refvalues = new Dictionary<string, object>();
            string sKey = string.Empty;
            if (value != null)
            {
                sKey = action.ID.ToString() + propertyName;
            }
            else
            {
                sKey = action.ID.ToString() + propertyName;
            }
            if (Refvalues.ContainsKey(sKey))
            {
                Refvalues[sKey] = null;
                if (value != null)
                {
                    //var tesr = value.GetType();
                    if (value.GetType() == typeof(List<object>))
                        Refvalues[sKey] = GlobFuncs.CloneValue((List<object>)value);
                    else if (value.GetType() == typeof(List<string>))
                        Refvalues[sKey] = (List<string>)value;
                    else if (value.GetType() == typeof(List<double>))
                        Refvalues[sKey] = (List<double>)value;
                    else
                        Refvalues[sKey] = value;
                }
            }
            else
            {
                if (value == null)
                    Refvalues.Add(sKey, null);
                else
                {
                    if (value.GetType() == typeof(List<object>))
                    {
                        //var test = GlobFuncs.CloneList((List<string>)value);
                        Refvalues.Add(sKey, GlobFuncs.CloneValue((List<object>)value));
                    }
                    else
                        Refvalues.Add(sKey, value);
                }
            }
        }

        private Image GetDefaultImage()
        {
            if (SourceImageSettings.IsNoImage)
            {
                Bitmap bitmap = RTC_Vision_Lite.Properties.Resources.Default;
                Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                BitmapData bmData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                bitmap.UnlockBits(bmData);
                return (Image)bitmap;
            }
            return null;
        }
        public void Run1Action(ref cAction action,
            bool isSetRunIsSilent = true,
            bool isCheckCanRun = true,
            bool isGetRunningTime = true)
        {
            Stopwatch time = Stopwatch.StartNew();
            if (action.ActionType == EActionTypes.GaugeDualROI)
                return;
            action.RunIsSilent.rtcValue = isSetRunIsSilent;
            action.Run(true, isCheckCanRun, isCheckCanRun);
            action.RunIsSilent.rtcValue = false;
            if (action.IsRunned)
                SetValuetoVariableIsParentRef(action);
            time.Stop();
        }
        public bool GetValueToVariableIsRef(cAction action)
        {
            try
            {
                if (action.ActionType == EActionTypes.StringBuilder)
                    GetValueToVariableIsRef_StringBuiler(action);
                else
                {
                    GetValueToVariableIsRef_UpdateShapeListOriginal(action);
                    GetValueToVariableIsRef_Properties(action);
                    GetValueToVariableIsRef_Expression(action);
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        private void GetValueToVariableIsRef_Expression(cAction action)
        {
            if (action.MyExpression != null && action.MyExpression.Operands != null && action.MyExpression.Operands.Count > 0)
            {
                var operandsHaveRefs = action.MyExpression.Operands.Where(x => x.RefID != Guid.Empty);
                foreach (SStringBuilderItem sbItem in operandsHaveRefs)
                {
                    sbItem.ListDoubleValue = new List<double>() { };
                    sbItem.ListStringValue = new List<string>() { };
                    string sKey = sbItem.RefID.ToString() + sbItem.RefPropName;
                    if (!Refvalues.ContainsKey(sKey))
                        SetValuetoVariableIsParentRef(Actions[sbItem.RefID]);
                    if (!Refvalues.TryGetValue(sKey, out object value))
                        continue;
                    string sValue = string.Empty;
                    var test = nameof(List<string>);
                    if (Refvalues[sKey]?.GetType().Name != null &&
                        Refvalues[sKey]?.GetType().Name == "List`1")

                    {
                        var testt = Refvalues[sKey]?.GetType();
                        switch (Refvalues[sKey]?.GetType())
                        {
                            case Type t when t == typeof(List<string>):
                                sValue = GlobFuncs.Ve2Str(GlobFuncs.GetValueStringByIndex((List<string>)Refvalues[sKey], sbItem.RefIndex));
                                break;
                            case Type t when t == typeof(List<double>):
                                sValue = GlobFuncs.Ve2Str(GlobFuncs.GetValueDoubleByIndex((List<double>)Refvalues[sKey], sbItem.RefIndex));
                                break;
                            case Type t when t == typeof(List<object>):
                                sValue = GlobFuncs.Ve2Str(GlobFuncs.GetValueObjectByIndex((List<object>)Refvalues[sKey], sbItem.RefIndex));
                                break;
                        }

                    }
                    else
                        sValue = GlobFuncs.Object2Str(value);
                    switch (sbItem.ValueStyle)
                    {
                        case EHTupleStyle.Boolean:
                            {
                                sbItem.ListStringValue = new List<string>() { (bool.TryParse(sValue, out bool bValue) && bValue).ToString().ToLower() };
                                break;
                            }
                        case EHTupleStyle.Integer:
                            {
                                if (int.TryParse(sValue, out int iValue))
                                    sbItem.ListDoubleValue = new List<double>() { iValue };
                                break;
                            }
                        case EHTupleStyle.String:
                            {
                                sbItem.ListStringValue = new List<string>() { sValue };
                                break;
                            }
                        case EHTupleStyle.Real:
                            {
                                if (double.TryParse(sValue, out double dValue))
                                    sbItem.ListDoubleValue = new List<double>() { dValue };
                            }
                            break;
                    }
                    if (!RunSimple)
                        ((ucBaseActionDetail)action.ViewInfo)?.UpdatePropertyValueToPropertyGrid(sbItem.Name);


                }
            }
        }

        private void GetValueToVariableIsRef_Properties(cAction action)
        {
            List<PropertyInfo> propertyHaveRefs = null;
            if (RunSimple && AllPropertyParentRef != null)
                AllPropertyHaveRef.TryGetValue(action.ID, out propertyHaveRefs);
            if (propertyHaveRefs == null)
                propertyHaveRefs = action.GetType().GetProperties().Where(x =>
                ((RTCVariableType)x.GetValue(action, null)) != null &&
                ((RTCVariableType)x.GetValue(action, null)).rtcActive &&
                ((RTCVariableType)x.GetValue(action, null)).rtcIDRef != Guid.Empty).ToList();
            foreach (PropertyInfo propertyInfoDes in propertyHaveRefs)
            {
                if (propertyInfoDes.Name == nameof(action.DestinationPort) && action.ActionType == EActionTypes.DataSet)
                    continue;
                RTCVariableType variableTypeDes = (RTCVariableType)action.GetType().GetProperty(propertyInfoDes.Name)?.GetValue(action, null);
                if (variableTypeDes == null)
                    return;
                PropertyInfo PropValue = variableTypeDes.GetType().GetProperty(cPropertyName.rtcValue);
                PropertyInfo GrayInfo = variableTypeDes.GetType().GetProperty(cPropertyName.rtcGray);
                PropertyInfo BgrInfo = variableTypeDes.GetType().GetProperty(cPropertyName.rtcBgr);
                if (PropValue == null)
                    return;
                string sKey = variableTypeDes.rtcIDRef.ToString() + variableTypeDes.rtcPropNameRef;
                if (!Refvalues.ContainsKey(sKey))
                    SetValuetoVariableIsParentRef(Actions[variableTypeDes.rtcIDRef]);
                if (Refvalues.ContainsKey(sKey))
                {
                    RTCVariableType variableTypeSrc = (RTCVariableType)Actions[variableTypeDes.rtcIDRef].GetType().
                        GetProperty(variableTypeDes.rtcPropNameRef)?.GetValue(Actions[variableTypeDes.rtcIDRef], null);
                    PropertyInfo propertyInfoSrc = Actions[variableTypeDes.rtcIDRef].GetType()
                        .GetProperty(variableTypeDes.rtcPropNameRef);
                    if (variableTypeSrc.rtcIsIconic && variableTypeDes.rtcIsIconic) // cả 2 thuộc tính đều là iconnic
                    {
                        if (propertyInfoSrc.PropertyType == typeof(SImage) &&
                            propertyInfoDes.PropertyType == typeof(SImage))
                        {
                            if (Refvalues[sKey] != null)

                                PropValue.SetValue(variableTypeDes, ((Image)Refvalues[sKey]).Clone());

                            continue;
                            //GlobFuncs.GetValueFromSImageByIndex())
                            //return;
                        }
                        else if (propertyInfoDes.PropertyType == propertyInfoDes.PropertyType)
                            switch (propertyInfoSrc.PropertyType.Name)
                            {
                                case nameof(SGrayImage):
                                    {
                                        PropValue.SetValue(variableTypeDes, (Image<Gray, byte>)Refvalues[sKey]);
                                        break;
                                    }
                                case nameof(SBgrImage):
                                    {
                                        PropValue.SetValue(variableTypeDes, (Image<Bgr, byte>)Refvalues[sKey]);
                                        break;
                                    }

                            }

                    }
                    else if (!variableTypeDes.rtcIsIconic && !variableTypeSrc.rtcIsIconic)
                    {
                        if (propertyInfoDes.PropertyType.Name == nameof(SListString) &&
                             Refvalues[sKey].GetType().Name != nameof(SListString))
                        {
                            if (Refvalues[sKey].GetType().Name != nameof(Boolean))
                                PropValue.SetValue(variableTypeDes, new List<string>() { GlobFuncs.Ve2Str(Refvalues[sKey]) });
                            else
                                PropValue.SetValue(variableTypeDes, new List<string>() { Refvalues[sKey].ToString().ToString().ToLower() });
                        }
                        else if (propertyInfoDes.PropertyType.Name == nameof(SListDouble) &&
                             Refvalues[sKey].GetType().Name != nameof(SListDouble))
                        {
                            PropValue.SetValue(variableTypeDes, GlobFuncs.GetValueDoubleByIndex((List<double>)Refvalues[sKey], variableTypeDes.rtcRefIndex));
                        }
                        else if (propertyInfoDes.PropertyType.Name == nameof(SListObject) &&
                             Refvalues[sKey].GetType().Name != nameof(SListObject))
                        {
                            PropValue.SetValue(variableTypeDes, GlobFuncs.GetValueObjectByIndex(new List<object> { Refvalues[sKey] }, variableTypeDes.rtcRefIndex));
                        }

                        else
                        {
                            if ((propertyInfoDes.PropertyType.Name != nameof(SListDouble) &&
                             propertyInfoDes.PropertyType.Name != nameof(SListString) &&
                             propertyInfoDes.PropertyType.Name != nameof(SListObject)) &&
                             (Refvalues[sKey]?.GetType().Name != null &&
                             (Refvalues[sKey]?.GetType() == typeof(List<double>) ||
                              Refvalues[sKey]?.GetType() == typeof(List<string>) ||
                              Refvalues[sKey]?.GetType() == typeof(List<object>))))
                            {
                                string sValue = string.Empty;
                                switch (Refvalues[sKey]?.GetType())
                                {
                                    case Type t when t == typeof(List<string>):
                                        {
                                            List<string> hValue = GlobFuncs.GetValueStringByIndex((List<string>)Refvalues[sKey], variableTypeDes.rtcRefIndex);
                                            sValue = GlobFuncs.Ve2Str(hValue);
                                            break;
                                        }
                                    case Type t when t == typeof(List<double>):
                                        {

                                            List<double> hValue = GlobFuncs.GetValueDoubleByIndex((List<double>)Refvalues[sKey], variableTypeDes.rtcRefIndex);
                                            sValue = GlobFuncs.Ve2Str(hValue);
                                            break;
                                        }
                                    case Type t when t == typeof(List<object>):
                                        {
                                            PropValue.SetValue(variableTypeDes, GlobFuncs.GetValueObjectByIndex((List<object>)Refvalues[sKey], variableTypeDes.rtcRefIndex));
                                            break;
                                        }
                                }
                                switch (propertyInfoDes.PropertyType.Name)
                                {
                                    case nameof(SString):
                                        {
                                            PropValue.SetValue(variableTypeDes, sValue);
                                            break;
                                        }
                                    case nameof(SInt):
                                        {
                                            PropValue.SetValue(variableTypeDes, int.TryParse(sValue, out int iValue) ? iValue : 0);
                                            break;
                                        }
                                    case nameof(SDouble):
                                        {
                                            PropValue.SetValue(variableTypeDes, double.TryParse(sValue, out double iValue) ? iValue : 0);
                                            break;
                                        }
                                    case nameof(SBool):
                                        {
                                            PropValue.SetValue(variableTypeDes, bool.TryParse(sValue, out bool bValue) && bValue);
                                            break;
                                        }
                                }
                            }
                            else if ((propertyInfoDes.PropertyType.Name == nameof(SListDouble) ||
                                 propertyInfoDes.PropertyType.Name == nameof(SListString) ||
                                 propertyInfoDes.PropertyType.Name == nameof(SListObject)) &&
                                 (Refvalues[sKey]?.GetType().Name != null &&
                                 (Refvalues[sKey]?.GetType() == typeof(List<double>) ||
                                  Refvalues[sKey]?.GetType() == typeof(List<string>) ||
                                  Refvalues[sKey]?.GetType() == typeof(List<object>))))
                                switch (Refvalues[sKey]?.GetType())
                                {

                                    case Type t when t == typeof(List<string>):
                                        {
                                            PropValue.SetValue(variableTypeDes, GlobFuncs.GetValueStringByIndex((List<string>)Refvalues[sKey], variableTypeDes.rtcRefIndex));
                                            break;

                                        }
                                    case Type t when t == typeof(List<double>):
                                        {

                                            PropValue.SetValue(variableTypeDes, GlobFuncs.GetValueDoubleByIndex((List<double>)Refvalues[sKey], variableTypeDes.rtcRefIndex));
                                            break;
                                        }
                                    case Type t when t == typeof(List<object>):
                                        {
                                            PropValue.SetValue(variableTypeDes, GlobFuncs.GetValueObjectByIndex((List<object>)Refvalues[sKey], variableTypeDes.rtcRefIndex));
                                            break;
                                        }
                                }
                            else
                                PropValue.SetValue(variableTypeDes, Refvalues[sKey]);
                            if (action.MyExpression != null && propertyInfoDes.Name == nameof(action.Expression))
                                action.MyExpression.Expression = PropValue.GetValue(variableTypeDes).ToString();



                        }
                    }

                    else
                        GlobFuncs.SetDefaultValue(variableTypeDes);
                }
                else
                    break;
            }
            propertyHaveRefs = null;
        }

        private void GetValueToVariableIsRef_UpdateShapeListOriginal(cAction action)
        {
            switch (action.ActionType)
            {
                case EActionTypes.MainAction:
                    break;
                case EActionTypes.Pattern:
                    {
                        if (action.TrainPressed.rtcValue || (action.ShapeListOriginal.rtcValue.Count <= 0 &&
                                                             action.ShapeList.rtcValue.Count > 0))
                            action.UpdateShapeListOriginal();
                        if (action.TabPassActive.rtcActive || action.Pattern_ROITrain_Find)
                            action.UpdateFindShapeListOriginal();
                        break;
                    }
                case EActionTypes.Metrology:
                    {
                        if (action.TrainPressed.rtcValue || (action.ShapeListOriginal.rtcValue.Count <= 0 &&
                                                             action.ShapeList.rtcValue.Count > 0))
                            action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.DeformablePattern:
                    {
                        if (action.TrainPressed.rtcValue || (action.ShapeListOriginal.rtcValue.Count <= 0 &&
                                                             action.ShapeList.rtcValue.Count > 0))
                            action.UpdateShapeListOriginal();
                        if (action.TabPassActive.rtcValue || action.DeformablePattern_ROITrain_Find)
                            action.UpdateFindShapeListOriginal();
                        break;
                    }
                case EActionTypes.Blob:
                    if (action.Blob_ROITrain_Roi)
                    {
                        action.UpdateShapeListOriginal();
                    }
                    break;
                case EActionTypes.GaugeDualROI:
                    if (action.Blob_ROITrain_Roi)
                    {
                        action.UpdateShapeListOriginal();
                    }
                    break;
                case EActionTypes.PixelCount:
                    {
                        if (action.PixelCount_ROITrain_ROI) action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.Brightness:
                    {
                        if (action.Brightness_ROITrain_ROI) action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.BlobMultipleROI:
                    {
                        if (action.Blob_ROITrain_Roi) action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.LineFind:
                    {
                        if (action.LineFind_ROITrain_ROI) action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.ColorBlob:
                    {
                        if (action.ColorBlob_ROITrain_Find) action.UpdateShapeListOriginal();
                        if (action.TabPassActive.rtcValue && action.ColorBlob_ROITrain_Find)
                            action.UpdateFindShapeListOriginal();
                        break;
                    }
                case EActionTypes.ColorBlobMultipleROI:
                    {
                        if (action.ColorBlob_ROITrain_ROI) action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.CalibrateEdgetoEdge:
                    {
                        if (action.Calibrate_ROITrain_ROI) action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.Origin:
                    {
                        if (action.Origin_ROITrain_ROI) action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.OCR:
                    {
                        if (action.OCR_ROITrain_ROI) action.UpdateShapeListOriginal();
                        if (action.TabPassActive.rtcValue && action.OCR_ROITrain_Find) action.UpdateFindShapeListOriginal();
                        break;
                    }
                case EActionTypes.CodeReader:
                    {
                        if (action.Brightness_ROITrain_ROI) action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.AffineImage:
                    {
                        if (action.Brightness_ROITrain_ROI) action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.ImageSplit:
                    {
                        if (action.ImageSplit_ROITrain_ROI) action.UpdateShapeListOriginal();
                        break;
                    }
                case EActionTypes.VariationModel:
                    {
                        if (action.VariationModel_ROITrain_ROI) action.UpdateShapeListOriginal();
                        if (action.VariationModel_ROITrain_Find) action.UpdateFindShapeListOriginal();
                        break;
                    }
                case EActionTypes.CorrelationPattern:
                    {
                        if (action.TrainPressed.rtcValue || (action.ShapeListOriginal.rtcValue.Count <= 0 &&
                                                             action.ShapeList.rtcValue.Count > 0))
                            action.UpdateShapeListOriginal();
                        if (action.CorrelationPattern_ROITrain_Find) action.UpdateFindShapeListOriginal();
                        break;
                    }
                case EActionTypes.None:
                    break;
                default:
                    break;
            }
        }

        public bool ValidateDataBeforeRun()
        {
            bool result = true;
            try
            {
                GlobFuncs.ShowWaitForm("Validate Data Before Run...");
                if (Actions.Values.FirstOrDefault(x =>
                    x.ActionType != EActionTypes.MainAction && x.ActionType != EActionTypes.None &&
                    x.Enable.rtcValue) == null)
                {
                    cMessageBox.Warning(Resources.NoHaveActionIsActive);
                    return false;
                }

                Setting_CloseAllConnectionInControls();
                GlobFuncs.ChangeWaitFormDescription("Validate All Connection...");
                result = Setting_CheckAllConnection();
                if (result)
                {
                    GlobFuncs.ChangeWaitFormDescription("Validate All Camera Connection...");
                    result = ConnectAllCameraUse();
                    if (!result)
                        DisconnectAllCameraUse();
                }
                if (!result && !string.IsNullOrEmpty(ErrMessage))
                    cMessageBox.Warning(ErrMessage);

            }
            finally
            {
                GlobFuncs.CloseWaitForm();
            }
            return result;
        }
        private void GetValueToVariableIsRef_StringBuiler(cAction action)
        {
            var sbItemHaveRef = action.StringBuilders.Where(x => x.RefID != Guid.Empty);
            foreach (SStringBuilderItem sbItem in sbItemHaveRef)
            {
                if (!Actions.TryGetValue(sbItem.RefID, out cAction actionRef))
                    continue;
                RTCVariableType rtcVariableType = (RTCVariableType)actionRef.GetType().GetProperty(sbItem.RefPropName)?.GetValue(actionRef, null);
                if (rtcVariableType == null)
                    continue;
                PropertyInfo propValue = rtcVariableType.GetType().GetProperty(cPropertyName.rtcValue);
                if (propValue == null)
                    continue;
                object value = propValue.GetValue(rtcVariableType, null);
                if (value == null)
                {
                    sbItem.ListDoubleValue = new List<double>();
                    sbItem.ListStringValue = new List<string>();
                }
                else
                {
                    var tesstt = value.GetType().FullName;
                    switch (value)
                    {
                        case List<string> listString:
                            sbItem.ListStringValue = listString;
                            break;

                        case List<double> listDouble:
                            sbItem.ListDoubleValue = listDouble;
                            break;
                        default:
                            sbItem.ListStringValue = (List<string>)value;
                            break;
                    }
                }
            }
        }
        internal void PrepareDataBeforeRun()
        {
            AllPropertyParentRef = null;
            AllPropertyParentRef = new Dictionary<Guid, List<PropertyInfo>>();
            foreach (cAction action in Actions.Values)
            {
                AllPropertyParentRef.Add(action.ID, action.GetType().GetProperties().Where(x =>
                ((RTCVariableType)x.GetValue(action, null)) != null &&
                ((RTCVariableType)x.GetValue(action, null)).rtcActive &&
                ((RTCVariableType)x.GetValue(action, null)).rtcIsParent).ToList());
            }
            AllPropertyHaveRef = null;
            AllPropertyHaveRef = new Dictionary<Guid, List<PropertyInfo>>();
            foreach (cAction action in Actions.Values)
            {
                AllPropertyHaveRef.Add(action.ID, action.GetType().GetProperties().Where(x =>
                    ((RTCVariableType)x.GetValue(action, null)) != null &&
                    ((RTCVariableType)x.GetValue(action, null)).rtcActive &&
                    ((RTCVariableType)x.GetValue(action, null)).rtcIDRef != Guid.Empty).ToList());
            }
        }
        public bool ValidateBeforeRun()
        {
            bool result = true;
            try
            {
                if (Actions.Values.FirstOrDefault(x =>
                x.ActionType != EActionTypes.MainAction && x.ActionType != EActionTypes.None &&
                x.Enable.rtcValue) == null)
                {
                    cMessageBox.Warning(Resources.NoHaveActionIsActive);
                    return false;
                }
                Setting_CloseAllConnectionInControls();
                result = Setting_CheckAllConnection();
                if (result)
                {
                    result = ConnectAllCameraUse();
                    if (!result)
                        DisconnectAllCameraUse();
                }
            }

            finally
            {
                GlobFuncs.CloseWaitForm();
            }
            return result;
        }
        internal void ClearDataBeforeRun()
        {
            AllPropertyHaveRef = null;
            AllPropertyParentRef = null;
        }
        internal void EnableControlWhenRun()
        {
            foreach (cAction action in Actions.Values)
            {
                if (action.ActionType == EActionTypes.MainAction)
                {
                    ((ucMainActions)action.ViewInfo).IsRun = false;
                }
                else if (action.ViewInfo != null)
                    ((ucBaseActionDetail)action.ViewInfo).IsRun = false;
            }
        }
        internal void AddAction(cAction action)
        {
            Actions?.Add(action.ID, action);
            DataChanged = true;
        }
        internal bool SaveCameraDefaultSettings()
        {
            GroupActionsData groupActionsData = new GroupActionsData();
            if (groupActionsData.Connect(FileName))
            {
                bool Result = groupActionsData.DeleteDataTable(cTableName_SaveTemplate.CameraSettings);
                if (Result)
                    Result = groupActionsData.SaveGroup_CameraSettings(this);
                groupActionsData.Disconnect();
                return Result;
            }
            else
                return false;
        }
        internal void DisableControlWhenRun()
        {
            foreach (cAction action in Actions.Values)
            {
                if (action.ActionType == EActionTypes.MainAction)
                {
                    ((ucMainActions)action.ViewInfo).IsRun = true;
                }
                else if (action.ViewInfo != null)
                    ((ucBaseActionDetail)action.ViewInfo).IsRun = true;
            }
        }
    }
}

