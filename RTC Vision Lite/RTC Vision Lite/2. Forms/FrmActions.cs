//using CommonTools;
using BrightIdeasSoftware;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTC_Vision_Lite.UserManager.Classes;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public delegate void SavejobEvents(cProjectTypes _CurrentProject);

    public partial class FrmActions : FrmBase
    {

        public SavejobEvents OnSaveJobEvents;
        private RTCE_CsvWrite_RowCellClickEventArgs _csvWriteRowCellClickEventArgs;
        private RTCE_ExcelWrite_RowCellClickEventArgs _excelWriteRowCellClickEventArgs;

        private bool _IsChildForm = false;
        private ActionTools _OldFocusNode;
        UserActivityHook actHook;

        public bool IsChildForm
        {
            get => _IsChildForm;
            set => _IsChildForm = value;
        }

        private cProjectTypes _CurrentProject;

        public cProjectTypes CurrentProject
        {
            get => _CurrentProject;
            set => _CurrentProject = value;
        }

        private Guid _CurrentCAMID;

        public Guid CurrentCAMID
        {
            get => _CurrentCAMID;
            set => _CurrentCAMID = value;
        }

        private DataTable _ApplyActionTable;

        public DataTable ApplyActionTable
        {
            get { return _ApplyActionTable; }
            set
            {
                _ApplyActionTable = value;
            }
        }
        #region VARIABLES
        private RTCE_ActionDetailProperties_RowCellClickEventArgs eRTC_ADP_RCC;
        private RTCE_StringBuilderItem_RowCellClickEventArgs eRTC_SBItem_RCC;

        #endregion
        public FrmActions()
        {
            InitializeComponent();
        }

        public void CreatefHsmartWindow()
        {
            try
            {
                GlobVar.fHsmartWindow = new FrmHsmartWindow();
                GlobVar.fHsmartWindow.TopLevel = false;
                GlobVar.fHsmartWindow.AutoScroll = true;
                GlobVar.fHsmartWindow.Dock = DockStyle.Fill;
                PanHsmartWindow.Controls.Add(GlobVar.fHsmartWindow);
                GlobVar.fHsmartWindow.Show();
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void FrmActions_Load(object sender, EventArgs e)
        {
            try
            {
                actHook = new UserActivityHook();
                actHook.KeyDown += new KeyEventHandler(FrmActionsKeyDown);
                this.SuspendLayout();
                if (!IsChildForm)
                {
                    mnuCreateData.PerformClick();
                    mnuSaveAndClose.Visible = false;
                    mnuApplyActionsToOtherCAMs.Visible = false;
                }
                else
                {
                    mnuSaveJob.Visible = false;
                }
                GlobVar.GroupActions.SourceImageSettings.OnImageSourceTypeChanged += OnImageSourceTypeChanged;
                GlobVar.GroupActions.SourceImageSettings.CameraSettings.OnCameraLiveAndConnectChanged += OnCameraLiveAndConnectChanged;


                ucTemplateTools.ShowAction();

                ucActionList.ViewData();

                if (CurrentProject != null)
                {
                    cCAMTypes _CAM = CurrentProject.CAMs.Values.FirstOrDefault(x => x.ID == _CurrentCAMID);
                    if (_CAM != null)
                        this.Text = GlobVar.ProgramName + " [Model: " + CurrentProject.ProjectName + " - Window: " + _CAM.Name + "]";
                }
                GlobVar.ColName = ucActionList.colName;
                GlobVar.Description = ucActionList.colDescription;
                GlobVar.RunCount = ucActionList.colRunCount;
                GlobVar.FailCount = ucActionList.colFailCount;
                GlobVar.ProcessTime = ucActionList.colProcessTime;
                GlobVar.TotalTime = ucActionList.colTotalTime;
                GlobVar.AbortCause = ucActionList.colAbortCause;
                GlobVar.tl = ucActionList.tl;


                ucActionList.EnableAllActionButton();
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        private void FrmActionsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && GlobVar.IsLinkMode)
                EndLinkValue(null);
            else if (e.KeyCode == Keys.Escape && GlobVar.IsLinkStringBuilderItemMode)
                StringBuilder_EndLinkValue(null);
            //else if (e.KeyCode == Keys.Escape && GlobVar.IsLinkImageFilterMode)
            //    ImageFilter_EndLinkValue(null);
            //else if (e.KeyCode == Keys.Escape && GlobVar.IsLinkCsvWriteValue)
            //    CsvWrite_EndLinkValue(null);
            else if (e.KeyCode == Keys.Escape && GlobVar.IsSelectMode)
            {
                GlobVar.IsSelectMode = false;
                GlobVar.fHsmartWindow?.UpdateSelectMode();
            }
            //else if (e.KeyCode == Keys.F12 && e.Control && e.Shift)
            //{
            //    frmControlPropertyViewer frmControlPropertyViewer = new FrmControlPropertyViewer();
            //    frmControlPropertyViewer.RTCControls = this.Controls;
            //    frmControlPropertyViewer.Show();
            //}
            //else if (e.KeyCode == Keys.F11 && e.Control && e.Shift)
            //{
            //    if (!GlobVar.IsAdminMode && !GlobFuncs.InputAdminPassword())
            //        return;
            //    GlobVar.IsAdminMode = !GlobVar.IsAdminMode;
            //}
            else if (e.KeyCode == Keys.F10 && e.Control && e.Shift)
            {
                GlobVar.RTCVision.SecurityOptions.IsAdminKeepLogin = false;
                GlobVar.RTCVision.SecurityOptions.IsKeepLoginToolSetting = false;
            }
            //else if ((e.KeyCode == Keys.Left ||
            //          e.KeyCode == Keys.Right ||
            //          e.KeyCode == Keys.Up ||
            //          e.KeyCode == Keys.Down) && e.Control)
            //    GlobVar.fHsmartWindow?.MoveRoiByShortcutKey(e.KeyCode);
            //else if ((e.KeyCode == Keys.Up ||
            //          e.KeyCode == Keys.Down) && e.Shift)
            //    GlobVar.fHsmartWindow?.RotateRoiByShortcutKey(e.KeyCode);
            //else if (e.Control && e.KeyCode == Keys.C)
            //    ucActionList.CopyTools();
            //else if (e.Control && e.KeyCode == Keys.V)
            //    ucActionList.PasteTools();
            //else if (e.Control && e.KeyCode == Keys.L)
            //    ucActionList.LockEditTools();
            //else if (e.Control && e.KeyCode == Keys.M)
            //    ucActionList.SmallViewMode();
            //else if (e.KeyCode == Keys.Delete)
            //    ucActionList.SmallViewMode();
            //else if (e.Control && e.Shift && e.KeyCode == Keys.Delete)
            //    ucActionList.DeleteAllTool();
        }

        private void OnCameraLiveAndConnectChanged(object sender, EventArgs e)
        {
            if (GlobVar.GroupActions != null)
            {
                GlobVar.GroupActions.frmHsmartWindow.UpdateLiveControlsVisible();
                var orderlist = GlobVar.GroupActions.Actions.OrderBy(x => x.Value.STT).ToList();
                cAction action = orderlist[0].Value;

                if (action.ViewInfo != null) ((ucMainActions)action.ViewInfo).UpdateLiveControlsVisible();
            }
        }

        private void OnImageSourceTypeChanged(object sender, EventArgs e)
        {
            switch (GlobVar.GroupActions.SourceImageSettings.ImageSourceType)
            {
                case EImageSourceTypes.Computer:
                    mnuRunOneJob.Visible = true;
                    // mnuRunPrevious.Visible = true;
                    //munuRunCurrentImage.Visible = true;
                    //mnuRunNext.Visible = true;
                    //mnuListHistory.Visible = true;
                    break;
                case EImageSourceTypes.Camera:
                    mnuRunOneJob.Visible = false;
                    // mnuRunPrevious.Visible = false;
                    //munuRunCurrentImage.Visible = false;
                    //mnuRunNext.Visible = false;
                    //mnuListHistory.Visible = false;
                    break;
                default:
                    break;

            }
        }

        private void InitPanHSmartWindow(cAction action)
        {
            if (PanHsmartWindow.Controls.Count > 0)
            {
                switch (action.ActionType)
                {
                    case EActionTypes.Script:
                        break;
                    default:
                        {
                            if (GlobVar.fHsmartWindow == null)
                                CreatefHsmartWindow();
                            else if (PanHsmartWindow.Controls.Contains(GlobVar.fHsmartWindow))
                                return;
                            else
                            {
                                PanHsmartWindow.Controls.Clear();
                                GlobVar.fHsmartWindow.Dock = DockStyle.Fill;
                                PanHsmartWindow.Controls.Add(GlobVar.fHsmartWindow);
                            }
                            break;
                        }
                }
            }
        }


        private void OnMainActionForceSave()
        {
            mnuSave.PerformClick();
        }

        private void btnLocatePart_Click(object sender, EventArgs e)
        {
            ucTemplateTools.IsLocate = true;
            ucTemplateTools.ShowAction();
        }

        private void btnInspectPart_Click(object sender, EventArgs e)
        {
            ucTemplateTools.IsLocate = false;
            ucTemplateTools.ShowAction();
            ucTemplateTools._action = ucActionList._Action;
        }

        private void ucTemplateTools_OnAddAction(object sender, RTCE_AddActionEventArgs e)
        {
            if (GlobVar.GroupActions != null)
                ucActionList.AddNewNode(GlobVar.GroupActions.CreateAction(e.ActionTypes, EObjectTypes.Action));
        }



        private void ucActionList1_OnFocusedNodeChanged(object sender, RTCE_ActionList_FocusedNodeChangedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (GlobVar.IsLinkMode)
            {
                if (e.node == null ||
                (GlobFuncs.GetNodeType(e.node, ucActionList.colNodeType) != ENodeTypes.Property &&
                GlobFuncs.GetNodeType(e.node, ucActionList.colNodeType) != ENodeTypes.DataItem &&
                GlobFuncs.GetNodeType(e.node, ucActionList.colNodeType) != ENodeTypes.Operand &&
                GlobFuncs.GetNodeType(e.node, ucActionList.colNodeType) != ENodeTypes.DataItemParent))
                {
                    return;
                }
                EndLinkValue(e.node);
            }
            else if (GlobVar.IsLinkStringBuilderItemMode)
            {
                if (e.node == null ||
                    !(bool)ucActionList.colEnable.GetValue(e.node) ||
                 (GlobFuncs.GetNodeType(e.node, ucActionList.colNodeType) != ENodeTypes.Property &&
                GlobFuncs.GetNodeType(e.node, ucActionList.colNodeType) != ENodeTypes.DataItem &&
                GlobFuncs.GetNodeType(e.node, ucActionList.colNodeType) != ENodeTypes.DataItemParent))
                {
                    return;
                }
                StringBuilder_EndLinkValue(e.node);
            }
            else if (GlobVar.IsLinkCsvWriteValue)
            {
                if (e.node == null ||
                    !e.node.Enable ||
                    (GlobFuncs.GetNodeType(e.node, ucActionList.colNodeType) != ENodeTypes.Property &&
                     GlobFuncs.GetNodeType(e.node, ucActionList.colNodeType) != ENodeTypes.DataItem &&
                     GlobFuncs.GetNodeType(e.node, ucActionList.colNodeType) != ENodeTypes.DataItemParent))
                {
                    return;
                }
                CsvWrite_EndLinkValue(e.node);
            }
            else
            {
                stopwatch.Stop();
                stopwatch.Start();

                try
                {
                    int PageActionSettingTabIndex = 0;
                    if (PanActionInfo.Controls.Count == 1)
                    {
                        if (PanActionInfo.Controls[0] is ucBaseActionDetail)
                        {
                            PageActionSettingTabIndex = ((ucBaseActionDetail)PanActionInfo.Controls[0]).PageActionSettingTabIndex;
                            ((ucBaseActionDetail)PanActionInfo.Controls[0]).OnPropertiesRowCellClickbtnLink -= new PropertiesRowCellClick(ViewInfo_tlPropertiesRowCellbtnLinkClick);
                            ((ucBaseActionDetail)PanActionInfo.Controls[0]).OnPropertiesRowCellClickbtnRemoveLink -= new PropertiesRowCellClick(ViewInfo_tlPropertiesRowCellbtnRemoveLinkClick);

                            ((ucBaseActionDetail)PanActionInfo.Controls[0]).OnStringBuiderDetail_BtnLinkClickEvent -= StringBuiderDetail_BtnLinkClickEvent;
                            ((ucBaseActionDetail)PanActionInfo.Controls[0]).OnStringBuiderDetail_BtnRemoveLinkClickEvent -= StringBuiderDetail_BtnRemoveLinkClickEvent;
                            ((ucBaseActionDetail)PanActionInfo.Controls[0]).OnCsvWriteBtnLinkValueClickEvent -= CsvWriteDetail_BtnLinkClickEvent;
                            ((ucBaseActionDetail)PanActionInfo.Controls[0]).OnExcelWriteBtnLinkValueClickEvent -= ExcelWriteDetail_BtnLinkClickEvent;


                            if (GlobVar.GroupActions.Actions.ContainsKey(((ucBaseActionDetail)PanActionInfo.Controls[0]).Action.ID))
                            {
                                GlobVar.GroupActions.Actions[((ucBaseActionDetail)PanActionInfo.Controls[0]).Action.ID] = ((ucBaseActionDetail)PanActionInfo.Controls[0]).Action;
                                PanActionInfo.Controls.RemoveAt(0);
                            }
                            else
                            {
                                ((ucBaseActionDetail)PanActionInfo.Controls[0]).Action = null;

                                PanActionInfo.Controls.RemoveAt(0);
                            }
                        }
                        else
                        {
                            GlobVar.GroupActions.SourceImageSettings = ((ucMainActions)PanActionInfo.Controls[0]).SourceImageSettings;
                            GlobVar.GroupActions.SetLiveCamera(false);
                            PanActionInfo.Controls.RemoveAt(0);
                        }
                    }

                    stopwatch.Stop();
                    stopwatch.Start();

                    cAction Action = ucActionList.GetActionFormNode(e.node);
                    if (Action != null)
                    {
                        bool isNewViewInfo = false;
                        Action.OnbtnLineCalibEtoEClickEvent -= btnGetLineCalibEtoE_Clicked;
                        Action.OnbtnLineCalibEtoEClickEvent += btnGetLineCalibEtoE_Clicked;
                        if (Action.ViewInfo == null)
                        {
                            Action.CreateViewInfo();
                            isNewViewInfo = true;
                            //if (Action.ActionType == EActionTypes.EasyHandEye || Action.ActionType == EActionTypes.EasyAlign)
                            //{
                            //    switch (Action.ActionType)
                            //    {
                            //        case EActionTypes.EasyHandEye:
                            //            {
                            //                Action.Pattern.vi =
                            //                    ((ucEasyHandEyeActionDetail)Action.ViewInfo).ucPatternActionDetail1;
                            //                break;
                            //            }
                            //        case EActionTypes.EasyAlign:
                            //            {
                            //                Action.Pattern.ViewInfo =
                            //                    ((ucEasyAlignActionDetail)Action.ViewInfo).ucPatternActionDetail1;
                            //                break;
                            //            }
                            //    }

                            //}
                            if (Action.ViewInfo is ucBaseActionDetail detail)
                                PageActionSettingTabIndex = detail.GetPageActionSettingTabIndexDefault();
                            ((ucBaseActionDetail)Action.ViewInfo).SetEffectButtonMain();
                            if (((ucBaseActionDetail)Action.ViewInfo).IsTabRoiActive())
                                ((ucBaseActionDetail)Action.ViewInfo).btnROI.PerformClick();
                        }

                        stopwatch.Stop();
                        stopwatch.Start();

                        if (Action.ViewInfo != null)
                        {
                            //Action.ActionType = EActionTypes.Blob;
                            if (Action.ActionType == EActionTypes.MainAction)
                            {
                                ((ucMainActions)Action.ViewInfo).Action = Action;
                                ((ucMainActions)Action.ViewInfo).ReviewImage();
                                ((ucMainActions)Action.ViewInfo).SourceImageSettings = GlobVar.GroupActions.SourceImageSettings;

                                ////GlobVar.GroupActions.IsMasterMode = 
                                ////    ((ucMainActions)Action.ViewInfo).pageMain.SelectedTab ==
                                //    ((ucMainActions)Action.ViewInfo).t
                                if (GlobVar.GroupActions.IsMasterMode)
                                    ((ucMainActions)Action.ViewInfo).ShowMasterMode();
                                //((ucMainActions)Action.ViewInfo).IsRun = Action.MyGroup.IsRun;
                            }
                            else
                            {
                                GlobVar.GroupActions.IsMasterMode = false;
                                ((ucBaseActionDetail)Action.ViewInfo).PageActionSettingTabIndex = PageActionSettingTabIndex;
                                ((ucBaseActionDetail)Action.ViewInfo).OnPropertiesRowCellClickbtnLink += new PropertiesRowCellClick(ViewInfo_tlPropertiesRowCellbtnLinkClick);
                                ((ucBaseActionDetail)Action.ViewInfo).OnPropertiesRowCellClickbtnRemoveLink += new PropertiesRowCellClick(ViewInfo_tlPropertiesRowCellbtnRemoveLinkClick);
                                if (isNewViewInfo || !Action.MyGroup.IsRun)
                                {
                                    ((ucBaseActionDetail)Action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                                    ((ucBaseActionDetail)Action.ViewInfo).ViewActionLinkSummary();
                                    ((ucBaseActionDetail)Action.ViewInfo).BindingDataToControls();
                                }
                                     ((ucBaseActionDetail)Action.ViewInfo).IsRun = Action.MyGroup.IsRun;
                                Action.EnableOrDisableTabRoiByActionType();
                            }

                            stopwatch.Stop();
                            stopwatch.Start();

                            switch (Action.ActionType)
                            {
                                case EActionTypes.MainAction:
                                    break;
                                case EActionTypes.PassFail:
                                    break;
                                default:
                                    ((ucBaseActionDetail)Action.ViewInfo).OnStringBuiderDetail_BtnLinkClickEvent += StringBuiderDetail_BtnLinkClickEvent;
                                    ((ucBaseActionDetail)Action.ViewInfo).OnStringBuiderDetail_BtnRemoveLinkClickEvent += StringBuiderDetail_BtnRemoveLinkClickEvent;
                                    ((ucBaseActionDetail)Action.ViewInfo).OnCsvWriteBtnLinkValueClickEvent += CsvWriteDetail_BtnLinkClickEvent;
                                    ((ucBaseActionDetail)Action.ViewInfo).OnExcelWriteBtnLinkValueClickEvent += ExcelWriteDetail_BtnLinkClickEvent;

                                    break;
                            }

                            PanActionInfo.Controls.Add(Action.ViewInfo);
                            Action.ViewInfo.Width = PanActionInfo.Width - 2;
                            Action.ViewInfo.Height = PanActionInfo.Height - 2;
                            Action.ViewInfo.Location = new Point(1, 1);
                            Action.ViewInfo.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                        }

                        InitPanHSmartWindow(Action);

                        GlobVar.GroupActions.frmHsmartWindow.Action = Action;

                        stopwatch.Stop();
                        stopwatch.Start();
                    }
                }
                finally
                {
                    GlobFuncs.EndControlUpdate(PanActionInfo);
                }
            }
        }

        private void ViewInfo_tlPropertiesRowCellbtnRemoveLinkClick(object sender, RTCE_ActionDetailProperties_RowCellClickEventArgs eRTC)
        {
            if (GlobVar.IsLinkMode && eRTC.ActionType == ENodeTypes.PropertyDetail)
            {
                return;
            }
            if (eRTC.IDRef != Guid.Empty)
            {
                RemoveLink(eRTC);
            }
        }

        private void RemoveLink(RTCE_ActionDetailProperties_RowCellClickEventArgs eRTC)
        {
            //if (!cUser.CheckPermision(nameof(GlobVar.User.Permission.LinkValueTool),
            //    nameof(GlobVar.User.Permission.LinkValueTools.Execute), false))
            //    return;
            PropertyInfo PropertyInfoSrc = eRTC.action.GetType().GetProperty(eRTC.ActionName);
            RTCVariableType propRemoveLink = (RTCVariableType)eRTC.action.GetType().GetProperty(eRTC.ActionName).GetValue(eRTC.action, null);
            propRemoveLink.rtcIDRef = Guid.Empty;
            propRemoveLink.rtcPropNameRef = string.Empty;
            propRemoveLink.rtcRef = string.Empty;
            PropertyInfo propRemoveLinkValue = propRemoveLink.GetType().GetProperty(cPropertyName.rtcValue);
            propRemoveLinkValue.SetValue(propRemoveLink, GlobFuncs.GetPropDefaultValueByBaseType(eRTC.action._SuffixName, PropertyInfoSrc.Name, PropertyInfoSrc.PropertyType));
            eRTC.CIDRef.PutValue(eRTC.Node, propRemoveLink.rtcIDRef);
            eRTC.CValue.PutValue(eRTC.Node, propRemoveLink.rtcIDRef != Guid.Empty ? propRemoveLink.rtcValueView + " " + propRemoveLink.rtcRef : propRemoveLink.rtcValueView);
            if (eRTC.action.IsMultiROI)
            {
                cROIProperty roiProperty = eRTC.action.GetROIPropertiesSelected();
                if (roiProperty != null)
                {
                    propRemoveLink = (RTCVariableType)roiProperty.GetType().GetProperty(eRTC.ActionName)?.GetValue(roiProperty, null);
                    if (propRemoveLink != null)
                    {
                        propRemoveLink.rtcIDRef = Guid.Empty;
                        propRemoveLink.rtcPropNameRef = string.Empty;
                        propRemoveLink.rtcRef = string.Empty;
                        propRemoveLinkValue = propRemoveLink.GetType().GetProperty(cPropertyName.rtcValue);
                        propRemoveLinkValue.SetValue(propRemoveLink, GlobFuncs.GetPropDefaultValueByBaseType(eRTC.action._SuffixName, PropertyInfoSrc.Name, PropertyInfoSrc.PropertyType));
                    }
                }
            }

            ((ucBaseActionDetail)eRTC.action.ViewInfo).RaiseOnSetActionEvent(null);

        }
        private void CsvWrite_EndLinkValue(ActionTools nodeSrc)
        {
            cAction actionLinkSrc = null;
            try
            {
                ucActionList.ChangeModeView(EModeViewGrid.MainView, null);
                GlobVar.IsLinkCsvWriteValue = false;

                foreach (object item in _csvWriteRowCellClickEventArgs.TreeList.Objects)
                    _csvWriteRowCellClickEventArgs.EnableColumn.PutValue(item, true);

                if (nodeSrc == null)
                {
                    ucActionList.ViewData_ActionDetail_ClearProperties(ucActionList.tl.Roots.Cast<ActionTools>().ToList());
                    return;
                }

                Guid idSrc = nodeSrc.ID;
                if (idSrc == Guid.Empty) { return; }
                actionLinkSrc = GlobVar.GroupActions.Actions[idSrc];
                string propertyLinkSrc = nodeSrc.Name;
                _csvWriteRowCellClickEventArgs.ColumnProperty.RefID = actionLinkSrc.ID;
                _csvWriteRowCellClickEventArgs.ColumnProperty.PropName = propertyLinkSrc;
                _csvWriteRowCellClickEventArgs.ColumnProperty.Ref = GlobFuncs.BuildRefString_Property_PropName(GlobVar.GroupActions, actionLinkSrc, propertyLinkSrc);
                PropertyInfo propertyInfo = actionLinkSrc.GetType().GetProperty(propertyLinkSrc);

                if (propertyInfo.PropertyType == typeof(SInt))
                {
                    _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Integer;
                    _csvWriteRowCellClickEventArgs.ColumnProperty.Format = string.Empty;
                }
                else if (propertyInfo.PropertyType == typeof(SBool))
                {
                    _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Boolean;
                    _csvWriteRowCellClickEventArgs.ColumnProperty.Format = CDataFormat.BooleanOkNg;
                }
                else if (propertyInfo.PropertyType == typeof(SDouble))
                {
                    _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Real;
                }
                else if (propertyInfo.PropertyType == typeof(SString))
                {
                    _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.String;
                    _csvWriteRowCellClickEventArgs.ColumnProperty.Format = cDateTimeFormats.yyyyddMM;
                }
                else if (propertyInfo.PropertyType == typeof(SByte))
                {
                    _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Integer;
                }
                else if (propertyInfo.PropertyType == typeof(SDateTime))
                {
                    _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.DateAndTime;
                }
                else if (propertyInfo.PropertyType == typeof(SListDouble)
                    || propertyInfo.PropertyType == typeof(SListDouble)
                    || propertyInfo.PropertyType == typeof(SListDouble))
                {
                    _csvWriteRowCellClickEventArgs.ColumnProperty.Format = string.Empty;
                    switch (((RTCVariableType)propertyInfo.GetValue(actionLinkSrc, null)).ValueStyle)
                    {
                        case EHTupleStyle.PointList:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.PointList;
                            break;
                        case EHTupleStyle.Rectangle:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Rectangle;
                            break;
                        case EHTupleStyle.Origin:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Origin;
                            break;
                        case EHTupleStyle.StringRange:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.String;
                            break;
                        case EHTupleStyle.ValueList:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.StringList;
                            break;
                        case EHTupleStyle.Tolerance:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.String;
                            break;
                        case EHTupleStyle.OriginList:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.OriginList;
                            break;
                        case EHTupleStyle.RectangleList:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.RectangleList;
                            break;
                        case EHTupleStyle.Point:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Point;
                            break;
                        case EHTupleStyle.Boolean:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Boolean;
                            _csvWriteRowCellClickEventArgs.ColumnProperty.Format = CDataFormat.BooleanOkNg;
                            break;
                        case EHTupleStyle.BooleanList:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.BooleanList;
                            _csvWriteRowCellClickEventArgs.ColumnProperty.Format = CDataFormat.BooleanOkNg;
                            break;
                        case EHTupleStyle.Integer:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Integer;
                            break;
                        case EHTupleStyle.IntegerList:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.IntegerList;
                            break;
                        case EHTupleStyle.String:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.String;
                            break;
                        case EHTupleStyle.StringList:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.StringList;
                            break;
                        case EHTupleStyle.DateAndTime:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.DateAndTime;
                            _csvWriteRowCellClickEventArgs.ColumnProperty.Format = cDateTimeFormats.yyyyddMM;
                            break;
                        case EHTupleStyle.Real:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Real;
                            break;
                        case EHTupleStyle.RealList:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.RealList;
                            break;
                        case EHTupleStyle.Long:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Integer;
                            break;
                        case EHTupleStyle.Double:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Real;
                            break;
                        case EHTupleStyle.DoubleList:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.RealList;
                            break;
                        default:
                            _csvWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.String;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                if (_csvWriteRowCellClickEventArgs != null)
                {
                    ucActionList.tl.FocusedObject = _csvWriteRowCellClickEventArgs.Action.MyNode;
                    ((ucCsvWriteActionDetail)_csvWriteRowCellClickEventArgs.View).UpdateColumnPropertyInfo(
                        _csvWriteRowCellClickEventArgs.ColumnProperty,
                        _csvWriteRowCellClickEventArgs.ColumnPropertyNode);
                    _csvWriteRowCellClickEventArgs.TreeList.Refresh();
                }
                ucActionList.ViewData_ActionDetail_ClearProperties(actionLinkSrc?.MyNode?.child);
                ucActionList.tl.Refresh();
                GlobVar.LockEvents = false;
            }
        }
        private void CsvWrite_BeginLinkValue(RTCE_CsvWrite_RowCellClickEventArgs csvWriteRowCellClickEventArgs)
        {
            //if (!cUser.CheckPermission(nameof(GlobVar.User.Permission.LinkValueTools),
            //    nameof(GlobVar.User.Permission.LinkValueTools.Execute), false))
            //    return;

            GlobVar.LockEvents = true;
            _csvWriteRowCellClickEventArgs = csvWriteRowCellClickEventArgs;
            ucActionList.masterAction = csvWriteRowCellClickEventArgs.Action;
            ucActionList.MasterPropertyTypeName = nameof(SListDouble);
            GlobVar.IsLinkCsvWriteValue = true;
            if (csvWriteRowCellClickEventArgs.View != null) csvWriteRowCellClickEventArgs.View.RemoveEventCustomCellStyle();
            foreach (object item in csvWriteRowCellClickEventArgs.TreeList.Objects)
            {
                if (csvWriteRowCellClickEventArgs.ColumnProperty.ID != (Guid)csvWriteRowCellClickEventArgs.IdColumn.GetValue(item))
                {
                    csvWriteRowCellClickEventArgs.EnableColumn.PutValue(item, false);
                }
            }
            GlobVar.LockEvents = false;
            if (csvWriteRowCellClickEventArgs.View != null) csvWriteRowCellClickEventArgs.View.SetEventCustomCellStyle();
            csvWriteRowCellClickEventArgs.TreeList.Refresh();
            ucActionList.tl.Refresh();
        }


        private void CsvWriteDetail_BtnLinkClickEvent(object sender, RTCE_CsvWrite_RowCellClickEventArgs eRTC)
        {
            if (GlobVar.IsLinkCsvWriteValue)
                CsvWrite_EndLinkValue(null);
            else
                CsvWrite_BeginLinkValue(eRTC);
        }

        private void ExcelWrite_EndLinkValue(ActionTools nodeSrc)
        {
            cAction actionLinkSrc = null;
            try
            {
                ucActionList.ChangeModeView(EModeViewGrid.MainView, null);
                GlobVar.IsLinkCsvWriteValue = false;

                foreach (object item in _excelWriteRowCellClickEventArgs.TreeList.Objects)
                    _excelWriteRowCellClickEventArgs.EnableColumn.PutValue(item, true);

                if (nodeSrc == null)
                {
                    ucActionList.ViewData_ActionDetail_ClearProperties(ucActionList.tl.Roots.Cast<ActionTools>().ToList());
                    return;
                }

                Guid idSrc = nodeSrc.ID;
                if (idSrc == Guid.Empty) { return; }
                actionLinkSrc = GlobVar.GroupActions.Actions[idSrc];
                string propertyLinkSrc = nodeSrc.Name;
                _excelWriteRowCellClickEventArgs.ColumnProperty.RefID = actionLinkSrc.ID;
                _excelWriteRowCellClickEventArgs.ColumnProperty.PropName = propertyLinkSrc;
                _excelWriteRowCellClickEventArgs.ColumnProperty.Ref = GlobFuncs.BuildRefString_Property_PropName(GlobVar.GroupActions, actionLinkSrc, propertyLinkSrc);
                PropertyInfo propertyInfo = actionLinkSrc.GetType().GetProperty(propertyLinkSrc);

                if (propertyInfo.PropertyType == typeof(SInt))
                {
                    _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Integer;
                    _excelWriteRowCellClickEventArgs.ColumnProperty.Format = string.Empty;
                }
                else if (propertyInfo.PropertyType == typeof(SBool))
                {
                    _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Boolean;
                    _excelWriteRowCellClickEventArgs.ColumnProperty.Format = CDataFormat.BooleanOkNg;
                }
                else if (propertyInfo.PropertyType == typeof(SDouble))
                {
                    _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Real;
                }
                else if (propertyInfo.PropertyType == typeof(SString))
                {
                    _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.String;
                    _excelWriteRowCellClickEventArgs.ColumnProperty.Format = cDateTimeFormats.yyyyddMM;
                }
                else if (propertyInfo.PropertyType == typeof(SByte))
                {
                    _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Integer;
                }
                else if (propertyInfo.PropertyType == typeof(SDateTime))
                {
                    _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.DateAndTime;
                }
                else if (propertyInfo.PropertyType == typeof(SListDouble)
                    || propertyInfo.PropertyType == typeof(SListDouble)
                    || propertyInfo.PropertyType == typeof(SListDouble))
                {
                    _excelWriteRowCellClickEventArgs.ColumnProperty.Format = string.Empty;
                    switch (((RTCVariableType)propertyInfo.GetValue(actionLinkSrc, null)).ValueStyle)
                    {
                        case EHTupleStyle.PointList:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.PointList;
                            break;
                        case EHTupleStyle.Rectangle:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Rectangle;
                            break;
                        case EHTupleStyle.Origin:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Origin;
                            break;
                        case EHTupleStyle.StringRange:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.String;
                            break;
                        case EHTupleStyle.ValueList:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.StringList;
                            break;
                        case EHTupleStyle.Tolerance:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.String;
                            break;
                        case EHTupleStyle.OriginList:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.OriginList;
                            break;
                        case EHTupleStyle.RectangleList:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.RectangleList;
                            break;
                        case EHTupleStyle.Point:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Point;
                            break;
                        case EHTupleStyle.Boolean:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Boolean;
                            _excelWriteRowCellClickEventArgs.ColumnProperty.Format = CDataFormat.BooleanOkNg;
                            break;
                        case EHTupleStyle.BooleanList:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.BooleanList;
                            _excelWriteRowCellClickEventArgs.ColumnProperty.Format = CDataFormat.BooleanOkNg;
                            break;
                        case EHTupleStyle.Integer:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Integer;
                            break;
                        case EHTupleStyle.IntegerList:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.IntegerList;
                            break;
                        case EHTupleStyle.String:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.String;
                            break;
                        case EHTupleStyle.StringList:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.StringList;
                            break;
                        case EHTupleStyle.DateAndTime:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.DateAndTime;
                            _excelWriteRowCellClickEventArgs.ColumnProperty.Format = cDateTimeFormats.yyyyddMM;
                            break;
                        case EHTupleStyle.Real:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Real;
                            break;
                        case EHTupleStyle.RealList:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.RealList;
                            break;
                        case EHTupleStyle.Long:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Integer;
                            break;
                        case EHTupleStyle.Double:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.Real;
                            break;
                        case EHTupleStyle.DoubleList:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.RealList;
                            break;
                        default:
                            _excelWriteRowCellClickEventArgs.ColumnProperty.DataType = cDataTypes.String;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                if (_excelWriteRowCellClickEventArgs != null)
                {
                    ucActionList.tl.FocusedObject = _excelWriteRowCellClickEventArgs.Action.MyNode;
                    ((ucExcelWriteActionDetail)_excelWriteRowCellClickEventArgs.View).UpdateColumnPropertyInfo(
                        _excelWriteRowCellClickEventArgs.ColumnProperty,
                        _excelWriteRowCellClickEventArgs.ColumnPropertyNode);
                    _excelWriteRowCellClickEventArgs.TreeList.Refresh();
                }
                ucActionList.ViewData_ActionDetail_ClearProperties(actionLinkSrc?.MyNode?.child);
                ucActionList.tl.Refresh();
                GlobVar.LockEvents = false;
            }
        }
        private void ExcelWrite_BeginLinkValue(RTCE_ExcelWrite_RowCellClickEventArgs excelWriteRowCellClickEventArgs)
        {
            //if (!cUser.CheckPermission(nameof(GlobVar.User.Permission.LinkValueTools),
            //    nameof(GlobVar.User.Permission.LinkValueTools.Execute), false))
            //    return;

            GlobVar.LockEvents = true;
            _excelWriteRowCellClickEventArgs = excelWriteRowCellClickEventArgs;
            ucActionList.masterAction = excelWriteRowCellClickEventArgs.Action;
            ucActionList.MasterPropertyTypeName = nameof(SListDouble);
            GlobVar.IsLinkCsvWriteValue = true;
            if (excelWriteRowCellClickEventArgs.View != null) excelWriteRowCellClickEventArgs.View.RemoveEventCustomCellStyle();
            foreach (object item in excelWriteRowCellClickEventArgs.TreeList.Objects)
            {
                if (excelWriteRowCellClickEventArgs.ColumnProperty.ID != (Guid)excelWriteRowCellClickEventArgs.IdColumn.GetValue(item))
                {
                    excelWriteRowCellClickEventArgs.EnableColumn.PutValue(item, false);
                }
            }
            GlobVar.LockEvents = false;
            if (excelWriteRowCellClickEventArgs.View != null) excelWriteRowCellClickEventArgs.View.SetEventCustomCellStyle();
            excelWriteRowCellClickEventArgs.TreeList.Refresh();
            ucActionList.tl.Refresh();
        }


        private void ExcelWriteDetail_BtnLinkClickEvent(object sender, RTCE_ExcelWrite_RowCellClickEventArgs eRTC)
        {
            if (GlobVar.IsLinkCsvWriteValue)
                ExcelWrite_EndLinkValue(null);
            else
                ExcelWrite_BeginLinkValue(eRTC);
        }

        private void StringBuiderDetail_BtnRemoveLinkClickEvent(object sender, RTCE_StringBuilderItem_RowCellClickEventArgs eRTC)
        {
            if (eRTC.SBItem.RefID != Guid.Empty)
            {
                StringBuilder_RemoveLink(eRTC);
            }
        }

        private void StringBuilder_RemoveLink(RTCE_StringBuilderItem_RowCellClickEventArgs eRTC)
        {
            eRTC.SBItem.RefID = Guid.Empty;
            eRTC.SBItem.ListDoubleValue = new List<double>();
            eRTC.SBItem.ListStringValue = new List<string>();
            eRTC.CIDRef.PutValue(eRTC.Node, eRTC.SBItem.RefID);
            eRTC.CValue.PutValue(eRTC.Node, eRTC.SBItem.ValueView);

        }

        private void StringBuiderDetail_BtnLinkClickEvent(object sender, RTCE_StringBuilderItem_RowCellClickEventArgs eRTC)
        {
            if (GlobVar.IsLinkStringBuilderItemMode)
                StringBuilder_EndLinkValue(null);
            else
                StringBuider_BeginLinkValue(eRTC);
        }

        private void StringBuider_BeginLinkValue(RTCE_StringBuilderItem_RowCellClickEventArgs eRTC)
        {
            GlobVar.LockEvents = true;
            eRTC_SBItem_RCC = eRTC;
            ucActionList.masterAction = eRTC.Action;

            string _Type = string.Empty;
            switch (eRTC.SBItem.ValueStyle)
            {
                case EHTupleStyle.PointList:
                    _Type = nameof(SListDouble);
                    break;
                case EHTupleStyle.Rectangle:
                    _Type = nameof(SListDouble);
                    break;
                case EHTupleStyle.Origin:
                    _Type = nameof(SListDouble);
                    break;
                case EHTupleStyle.OriginList:
                    _Type = nameof(SListDouble);
                    break;
                case EHTupleStyle.RectangleList:
                    _Type = nameof(SListDouble);
                    break;
                case EHTupleStyle.Point:
                    _Type = nameof(SListDouble);
                    break;
                case EHTupleStyle.Boolean:
                    _Type = nameof(SBool);
                    break;
                case EHTupleStyle.BooleanList:
                    _Type = nameof(SListDouble);
                    break;
                case EHTupleStyle.Integer:
                    _Type = nameof(SInt);
                    break;
                case EHTupleStyle.IntegerList:
                    _Type = nameof(SListDouble);
                    break;
                case EHTupleStyle.String:
                    _Type = nameof(SString);
                    break;
                case EHTupleStyle.StringList:
                    _Type = nameof(SListDouble);
                    break;
                case EHTupleStyle.DateAndTime:
                    _Type = nameof(SDateTime);
                    break;
                case EHTupleStyle.Real:
                    _Type = nameof(SDouble);
                    break;
                case EHTupleStyle.RealList:
                    _Type = nameof(SListDouble);
                    break;
            }
            ucActionList.MasterPropertyTypeName = _Type;

            GlobVar.IsLinkStringBuilderItemMode = true;
            eRTC_SBItem_RCC.treeList.BeginUpdate();
            eRTC_SBItem_RCC.CEnable.PutValue(eRTC_SBItem_RCC.Node, true);

            //if (eRTC.View != null)
            //    eRTC.View.StringBuilder_RemoveEventCustomCellStyle();
            if (eRTC.Base != null)
                eRTC.Base.RemoveEventCustomCellStyle();

            foreach (MyPropertiesItem item in eRTC.treeList.Objects)
            {
                if (eRTC.SBItem.Name != item.Name)
                {
                    eRTC.CEnable.PutValue(item, false);
                }
            }

            GlobVar.LockEvents = false;
            eRTC_SBItem_RCC.treeList.EndUpdate();
            //if (eRTC.View != null)
            //    eRTC.View.StringBuilder_SetEventCustomCellStyle();
            if (eRTC_SBItem_RCC.Base != null)
                eRTC_SBItem_RCC.Base.SetEventCustomCellStyle();
            eRTC_SBItem_RCC.treeList.Refresh();
            ucActionList.tl.Refresh();
        }

        private void StringBuilder_EndLinkValue(ActionTools nodeSrc)
        {
            eRTC_SBItem_RCC.treeList.BeginUpdate();
            cAction actionLinkSrc = null;
            try
            {
                ucActionList.ChangeModeView(EModeViewGrid.MainView, null);
                GlobVar.IsLinkStringBuilderItemMode = false;
                foreach (MyPropertiesItem item in eRTC_SBItem_RCC.treeList.Objects)
                {
                    eRTC_SBItem_RCC.CEnable.PutCheckState(item, CheckState.Checked);
                }
                if (nodeSrc == null)
                {
                    ucActionList.ViewData_ActionDetail_ClearProperties(ucActionList.tl.Roots.Cast<ActionTools>().ToList());
                    return;
                }
                Guid idSrc = Guid.Parse(ucActionList.colID.GetStringValue(nodeSrc));
                if (idSrc == Guid.Empty) { return; }
                actionLinkSrc = GlobVar.GroupActions.Actions[idSrc];
                string propertyLinkSrc = ucActionList.colName.GetStringValue(nodeSrc);
                PropertyInfo propertyInfoSrc = actionLinkSrc.GetType().GetProperty(propertyLinkSrc);
                if (propertyInfoSrc != null)
                    StringBuilder_EndLinkValue_Property(actionLinkSrc, propertyLinkSrc);
                else
                    StringBuilder_EndLinkValue_DataItem(actionLinkSrc, propertyLinkSrc);
            }
            catch (Exception Ex)
            {
                GlobFuncs.SaveErr(Ex);
            }
            finally
            {
                GlobVar.LockEvents = false;
                ucActionList.tl.FocusedObject = eRTC_SBItem_RCC?.Action?.MyNode;
                ucActionList.ViewData_ActionDetail_ClearProperties(actionLinkSrc?.MyNode?.child);
                ucActionList.tl.Refresh();
                eRTC_SBItem_RCC?.Dispose();
                eRTC_SBItem_RCC.treeList.EndUpdate();

            }
        }

        private void StringBuilder_EndLinkValue_DataItem(cAction actionLinkSrc, string propertyLinkSrc)
        {
            if (eRTC_SBItem_RCC.Action == null) return;
            if (!eRTC_SBItem_RCC.Action.RebuidValueWhenLink(actionLinkSrc, propertyLinkSrc, eRTC_SBItem_RCC.SBItem.Name)) return;
            eRTC_SBItem_RCC.CValue.PutValue(eRTC_SBItem_RCC.Node, eRTC_SBItem_RCC.SBItem.ValueView + " " + eRTC_SBItem_RCC.SBItem.Ref);
            eRTC_SBItem_RCC.CIDRef.PutValue(eRTC_SBItem_RCC.Node, eRTC_SBItem_RCC.SBItem.RefID);

            GlobVar.LockEvents = false;
            ucActionList.tl.FocusedObject = eRTC_SBItem_RCC.Action.MyNode;
        }

        private void StringBuilder_EndLinkValue_Property(cAction actionLinkSrc, string DataItemName)
        {
            if (eRTC_SBItem_RCC.Action == null) return;
            if (!eRTC_SBItem_RCC.Action.RebuidValueWhenLink(actionLinkSrc, DataItemName, eRTC_SBItem_RCC.SBItem.Name)) return;
            eRTC_SBItem_RCC.CValue.PutValue(eRTC_SBItem_RCC.Node, eRTC_SBItem_RCC.SBItem.ValueView + " " + eRTC_SBItem_RCC.SBItem.Ref);
            eRTC_SBItem_RCC.CIDRef.PutValue(eRTC_SBItem_RCC.Node, eRTC_SBItem_RCC.SBItem.RefID);

            GlobVar.LockEvents = false;
            ucActionList.tl.FocusedObject = eRTC_SBItem_RCC.Action.MyNode;

        }

        private void btnGetLineCalibEtoE_Clicked(object sender, EventArgs e)
        {
            GlobVar.IsSelectMode = !GlobVar.IsSelectMode;
            GlobVar.fHsmartWindow.UpdateSelectMode();
        }

        private void ViewInfo_tlPropertiesRowCellbtnLinkClick(object sender, RTCE_ActionDetailProperties_RowCellClickEventArgs eRTC)
        {
            if (eRTC.ActionType == ENodeTypes.PropertyDetail)
            {
                return;
            }
            if (GlobVar.IsLinkMode)
            {
                if (eRTC.Enable
                    && eRTC.ActionType == ENodeTypes.Property)
                {
                    EndLinkValue(null);
                }
                return;
            }
            BeginLinkValue(eRTC);
        }

        private void BeginLinkValue(RTCE_ActionDetailProperties_RowCellClickEventArgs eRTC)
        {
            GlobVar.LockEvents = true;
            _OldFocusNode = (ActionTools)ucActionList.tl.FocusedObject;
            eRTC_ADP_RCC = eRTC;
            ucActionList.masterAction = eRTC.action;
            ucActionList.MasterPropertyTypeName = eRTC.Type;
            GlobVar.IsLinkMode = true;
            eRTC_ADP_RCC.TreeList.BeginUpdate();
            eRTC_ADP_RCC.Node.Enable = true;

            eRTC_ADP_RCC.Base.RemoveEventCustomCellStyle();
            int NumberNode = eRTC_ADP_RCC.TreeList.GetItemCount();

            foreach (object item in eRTC_ADP_RCC.TreeList.Objects)
            {
                if (eRTC_ADP_RCC.ActionName != ((MyPropertiesItem)item).Name) ;
                {
                    eRTC_ADP_RCC.CEnable.PutValue(item, false);
                }
            }
            GlobVar.LockEvents = false;
            eRTC_ADP_RCC.TreeList.EndUpdate();
            eRTC_ADP_RCC.Base.SetEventCustomCellStyle();
            eRTC_ADP_RCC.TreeList.Refresh();
            ucActionList.tl.Refresh();
        }

        private void EndLinkValue(ActionTools NodeSrc)
        {
            cAction actionLinkSrc = null;
            try
            {
                ucActionList.ChangeModeView(EModeViewGrid.MainView, null);
                GlobVar.IsLinkMode = false;
                GlobVar.LockEvents = true;
                eRTC_ADP_RCC.TreeList.BeginUpdate();
                //foreach (ListViewItem Item in eRTC_ADP_RCC.TreeList.Items)
                //{
                //    Item.ListView.Visible = false;
                //}
                GlobVar.LockEvents = false;
                eRTC_ADP_RCC.TreeList.EndUpdate();
                if (NodeSrc == null)
                {
                    ucActionList.ViewData_ActionDetail_ClearProperties(ucActionList.tl.Roots.Cast<ActionTools>().ToList());
                    return;
                }
                Guid idSrc = Guid.Parse(ucActionList.colID.GetValue(NodeSrc).ToString());
                if (idSrc == Guid.Empty)
                    return;
                actionLinkSrc = GlobVar.GroupActions.Actions[idSrc];
                string propertyLinkSrc = ucActionList.colName.GetValue(NodeSrc).ToString();
                PropertyInfo propertyInfoSrc = actionLinkSrc.GetType().GetProperty(propertyLinkSrc);

                if (propertyInfoSrc != null)
                    EndLinkValue_Property(actionLinkSrc, propertyLinkSrc);
                else
                    EndLinkValue_DataItem(actionLinkSrc, propertyLinkSrc);
                if (eRTC_ADP_RCC.action.IsMultiROI)
                {
                    var roiProperties = eRTC_ADP_RCC.action.ROIProperties.Values.Where(x => x.Selected);
                    if (roiProperties.Any())
                    {
                        var crp = (cROIProperty)roiProperties.First();
                        crp.GetValueFromAction(eRTC_ADP_RCC.action);
                        eRTC_ADP_RCC.action.ROIProperties[crp.ID] = crp;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                if (eRTC_ADP_RCC != null)
                {
                    ucActionList.tl.FocusedObject = eRTC_ADP_RCC.action.MyNode;
                    ucActionList.tl.SelectedObject = eRTC_ADP_RCC.action.MyNode;

                    eRTC_ADP_RCC.Dispose();
                }
                ucActionList.ViewData_ActionDetail_ClearProperties(actionLinkSrc?.MyNode?.child);
                GlobVar.LockEvents = false;
                if (_OldFocusNode != null)
                {
                    ucActionList.tl.FocusedObject = null;
                    ucActionList.tl.FocusedObject = _OldFocusNode;
                    ucActionList.tl.FocusedItem.Selected = true;
                }
                ucActionList.tl.RefreshObject(actionLinkSrc);
                ucActionList.tl.Refresh();
            }
        }

        private void EndLinkValue_DataItem(cAction actionLinkSrc, string dataItemName)
        {
            if (eRTC_ADP_RCC.action == null) return;
            if (!eRTC_ADP_RCC.action.RebuidValueWhenLink(actionLinkSrc, dataItemName, eRTC_ADP_RCC.ActionName)) return;
            RTCVariableType PropDes = (RTCVariableType)eRTC_ADP_RCC.action.GetType().GetProperty(eRTC_ADP_RCC.ActionName)?.GetValue(eRTC_ADP_RCC.action, null);
            if (PropDes == null) return;

            eRTC_ADP_RCC.CValue.PutValue(eRTC_ADP_RCC.Node, PropDes.rtcValueView + " " + PropDes.rtcRef);
            eRTC_ADP_RCC.CIDRef.PutValue(eRTC_ADP_RCC.Node, PropDes.rtcRef);
            ((ucBaseActionDetail)eRTC_ADP_RCC.action.ViewInfo).RaiseOnSetActionEvent(null);
            ((ucBaseActionDetail)eRTC_ADP_RCC.action.ViewInfo).UpdatePropertyValueToAllControls(eRTC_ADP_RCC.ActionName);
            GlobVar.LockEvents = false;
            ucActionList.tl.FocusedObject = eRTC_ADP_RCC.action.MyNode;
        }

        private void EndLinkValue_Property(cAction ActionLink_Src, string PropertyLink_Src)
        {
            if (eRTC_ADP_RCC.action == null) return;
            if (!eRTC_ADP_RCC.action.RebuidValueWhenLink(ActionLink_Src, PropertyLink_Src, eRTC_ADP_RCC.ActionName)) return;
            RTCVariableType PropDes = (RTCVariableType)eRTC_ADP_RCC.action.GetType().GetProperty(eRTC_ADP_RCC.ActionName)?.GetValue(eRTC_ADP_RCC.action, null);
            if (PropDes == null) return;

            eRTC_ADP_RCC.CValue.PutValue(eRTC_ADP_RCC.Node, PropDes.rtcValueView + " " + PropDes.rtcRef);
            eRTC_ADP_RCC.CIDRef.PutValue(eRTC_ADP_RCC.Node, PropDes.rtcIDRef);
            ((ucBaseActionDetail)eRTC_ADP_RCC.action.ViewInfo).RaiseOnSetActionEvent(null);
            ((ucBaseActionDetail)eRTC_ADP_RCC.action.ViewInfo).UpdatePropertyValueToAllControls(eRTC_ADP_RCC.ActionName);
            GlobVar.LockEvents = false;
            ucActionList.tl.FocusedObject = eRTC_ADP_RCC.action.MyNode;
        }



        private void btnSaveJob_Click(object sender, EventArgs e)
        {
            ((ucMainActions)GlobVar.GroupActions.MainAction.ViewInfo).SaveDefaultCameraSettings();
            if (OnSaveJobEvents != null)
                OnSaveJobEvents(CurrentProject);
        }
        private void FrmActions_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                try
                {

                    if (actHook != null)
                    {
                        actHook.Stop();
                        actHook = null;
                    }
                }
                catch
                {

                }



                if (GlobVar.GroupActions != null && GlobVar.GroupActions.DataChanged)
                {
                    DialogResult dialogResult = cMessageBox.Question_YesNoCancel(cMessageContent.Que_SaveProject);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            {
                                if (OnSaveJobEvents != null)
                                    OnSaveJobEvents(CurrentProject);
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                e.Cancel = true;
                                return;
                            }
                    }

                }

                if (GlobVar.GroupActions != null)
                {
                    GlobVar.GroupActions.RunSimple = true;
                    GlobVar.GroupActions.Setting_StopRun();
                    GlobVar.GroupActions.Setting_StopRunFinal();
                    GlobVar.GroupActions.CleanData();
                    GlobVar.GroupActions = null;

                }
                GlobVar.IsLinkCsvWriteValue = false;
                GlobVar.IsLinkStringBuilderItemMode = false;
                GlobVar.IsLinkImageFilterMode = false;
                GlobVar.IsLinkMode = false;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void btnIInsertTool_Click(object sender, EventArgs e)
        {
            ucActionList.InsertTools();
        }

        private void mnuRunJob_Click(object sender, EventArgs e)
        {
           RunJobProcess();
        }

        private void RunJobProcess()
        {
            this.Invoke(new Action(() =>
            {

                if (GlobVar.GroupActions.ValidateBeforeRun())
                {
                    try
                    {
                        GlobFuncs.BeginControlUpdate(this);
                        GlobVar.GroupActions.StopLoop = false;
                        GlobVar.GroupActions.IsRun = false;
                        GlobVar.fHsmartWindow.IsRun = true;
                        GlobVar.GroupActions.DisableControlWhenRun();
                        mnuStop.Visible = true;
                        mnuRunJob.Visible = false;
                        GlobFuncs.EndControlUpdate(this);

                        GlobVar.GroupActions.Setting_StartRun(ERunActionMode.Endless, false, "", true, true);
                        if (string.IsNullOrEmpty(GlobVar.GroupActions.ErrMessage))
                        {
                            pnlTemplate.Enabled = false;
                        }
                    }
                    catch(Exception ex)
                    {
                        GlobFuncs.SaveErr(ex);
                    }
                    finally
                    {
                        GlobFuncs.EndControlUpdate(this);
                    }
                }
            }));
        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            GlobVar.IsStop = true;
            mnuStop.Visible = false;
            mnuRunJob.Visible = true;
            Stop();
        }

        private void Stop()
        {

            try
            {
                //Thread.Sleep(100);
                GlobVar.GroupActions.Setting_StopRun();
                ViewControlWhenStop();
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally

            {

                GlobFuncs.CloseWaitForm();
            }


        }
        public void ViewControlWhenStop()
        {
            GlobVar.GroupActions.EnableControlWhenRun();
            ucActionList.EnableAllActionButton();
            pnlTemplate.Enabled = true;
            var TEST = GlobVar.fHsmartWindow.Image;
            GlobVar.fHsmartWindow.IsRun = false;
        }

        private void mnuRunOneJob_Click(object sender, EventArgs e)
        {
            if (GlobVar.GroupActions.ValidateBeforeRun()) ;
            {
                try
                {
                    GlobFuncs.BeginControlUpdate(this);
                    GlobVar.GroupActions.IsRun = false;
                    GlobVar.fHsmartWindow.IsRun = true;
                    GlobVar.GroupActions.DisableControlWhenRun();
                    GlobVar.GroupActions.Setting_StartRun(ERunActionMode.All);
                    GlobFuncs.EndControlUpdate(this);

                    if (string.IsNullOrEmpty(GlobVar.GroupActions.ErrMessage))
                    {
                        pnlTemplate.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    GlobFuncs.SaveErr(ex);
                }
                finally
                {
                    ViewControlWhenStop();
                    GlobFuncs.EndControlUpdate(this);
                }
            }
        }

        private void mnuResetCounter_Click(object sender, EventArgs e)
        {
            try
            {
                ucActionList.tl.BeginUpdate();


                foreach (cAction _Action in GlobVar.GroupActions.Actions.Values)
                    _Action.ResetCount(true);
            }
            finally
            {

                ucActionList.tl.EndUpdate();
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            ((ucMainActions)GlobVar.GroupActions.MainAction.ViewInfo).SaveDefaultCameraSettings();
            if (OnSaveJobEvents != null)
                OnSaveJobEvents(CurrentProject);
            DialogResult = DialogResult.Cancel;
        }

        private void FrmActions_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void mnuRunprevius_Click(object sender, EventArgs e)
        {

            if (GlobVar.GroupActions.ValidateBeforeRun()) ;
            {
                try
                {
                    GlobFuncs.BeginControlUpdate(this);
                    GlobVar.GroupActions.IsRun = false;
                    GlobVar.fHsmartWindow.IsRun = true;
                    GlobVar.GroupActions.DisableControlWhenRun();
                    GlobVar.GroupActions.Setting_StartRun(ERunActionMode.Prev);
                    if (string.IsNullOrEmpty(GlobVar.GroupActions.ErrMessage))
                    {
                        pnlTemplate.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    GlobFuncs.SaveErr(ex);
                }
                finally
                {
                    ViewControlWhenStop();
                    GlobFuncs.EndControlUpdate(this);
                }
            }
        }

        private void mnuRunNext_Click(object sender, EventArgs e)
        {

            if (GlobVar.GroupActions.ValidateBeforeRun()) 
            {
                try
                {
                    GlobFuncs.BeginControlUpdate(this);
                    GlobVar.GroupActions.IsRun = false;
                    GlobVar.fHsmartWindow.IsRun = true;
                    GlobVar.GroupActions.DisableControlWhenRun();
                    GlobFuncs.EndControlUpdate(this);

                    GlobVar.GroupActions.Setting_StartRun(ERunActionMode.Next); 

                    if (string.IsNullOrEmpty(GlobVar.GroupActions.ErrMessage))
                    {
                        pnlTemplate.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    GlobFuncs.SaveErr(ex);
                }
                finally
                {
                    ViewControlWhenStop();
                    GlobFuncs.EndControlUpdate(this);
                }
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            if (cMessageBox.Question_YesNo("New creation will delete all existing data.\n" +
                                  "Do you want to continue?") == DialogResult.No)
                return;

            if (PanActionInfo.Controls.Count > 0) PanActionInfo.Controls.RemoveAt(0);
            Guid camID = GlobVar.GroupActions.MyCam.ID;
            foreach (cAction item in GlobVar.GroupActions.Actions.Values)
                if (item.ViewInfo != null)
                {
                    item.ViewInfo.Dispose();
                    item.ViewInfo = null;
                }

            ucActionList.tl.ClearObjects();
            ucActionList.tl.Refresh();
            mnuCreateData.PerformClick();
            GlobVar.GroupActions.RunSimple = false;
            GlobVar.GroupActions.MyCam = GlobVar.CurrentProject.CAMs[camID];
            ucActionList.ViewData();
            //Stattus_Notify.Caption = GlobVar.GroupActions.FileName;
        }

        private void mnuCreateData_Click(object sender, EventArgs e)
        {
            GlobVar.GroupActions = new cGroupActions(GlobVar.fHsmartWindow);
        }

        private void mnuApplyActionsToOtherCAMs_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                FrmApplyActionToOtherCAMs f = new FrmApplyActionToOtherCAMs();
                if (ApplyActionTable == null)
                {
                    ApplyActionTable = new DataTable();
                    ApplyActionTable.Columns.Add(cColName.ID, typeof(Guid));
                    ApplyActionTable.Columns.Add(cColName.Select, typeof(bool));
                    ApplyActionTable.Columns.Add(cColName.Name, typeof(string));
                    foreach (cCAMTypes _CAM in CurrentProject.CAMs.Values)
                        if (_CAM.ID != CurrentCAMID)
                            ApplyActionTable.Rows.Add(new object[] { _CAM.ID, false, _CAM.Name });
                }

                f.Data = ApplyActionTable;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ApplyActionTable = f.Data;
                }

            }
            //public void ChangeModeView(EModeViewGrid )
            //private void ViewInfo_tlPropertiesRowCellbtnLinkClick(object sender, RTC_ActionList_FocusedNodeChangedEventArgs )



        }

        private void mnuSaveSettingAs_Click(object sender, EventArgs e)
        {
            cSaveOpenFiles saveOpenFiles = new cSaveOpenFiles();

            EFunctionReturn eFunctionReturn = saveOpenFiles.SaveGroup(GlobVar.GroupActions, true, true, true);
            if (eFunctionReturn == EFunctionReturn.Success)
            {
                cMessageBox.Notification(cMessageContent.Inf_SaveGroupSuccess);
            }
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            if (!cUser.CheckPermission(nameof(GlobVar.User.Permission.Settings),
            nameof(GlobVar.User.Permission.SettingTools.View), true))
                return;

            GlobFuncs.ViewApplicationSettings();
        }

        private void mnuRunCurrentImage_Click(object sender, EventArgs e)
        {
            if (GlobVar.GroupActions.ValidateBeforeRun()) ;
            {
                try
                {
                    GlobFuncs.BeginControlUpdate(this);
                    GlobVar.GroupActions.IsRun = false;
                    GlobVar.fHsmartWindow.IsRun = true;
                    GlobVar.GroupActions.DisableControlWhenRun();
                    GlobFuncs.EndControlUpdate(this);

                    GlobVar.GroupActions.Setting_StartRun(ERunActionMode.Current);
                    if (string.IsNullOrEmpty(GlobVar.GroupActions.ErrMessage))
                    {
                        pnlTemplate.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    GlobFuncs.SaveErr(ex);
                }
                finally
                {
                    GlobFuncs.EndControlUpdate(this);
                }
            }
        }
    }
}


