using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucResetToolActionDetail : ucBaseActionDetail
    {
        private bool _canShowEditor;
        public ucResetToolActionDetail()
        {
            InitializeComponent();
            tlInputPassCriteria.TreeColumnRenderer.IsShowLines = false;
        }

        #region FUNCTIONS

        public void LoadLinkData()
        {
            try
            {
                tlInputPassCriteria.BeginUpdate();
                Guid currentID = Guid.Empty;
                if (tlInputPassCriteria.SelectedObject != null && colIDRef.GetValue(tlInputPassCriteria.SelectedObject) != null)
                    currentID = (Guid)colIDRef.GetValue(tlInputPassCriteria.FocusedObject);

                // Hiển thị danh sách các link 
                tlInputPassCriteria.ClearObjects();
                var orderActions = GlobVar.GroupActions.Actions.Values.OrderBy(x => x.STT).ToList();
                if (Action != null && Action.ListResetTools != null)
                    foreach (var orderAction in orderActions)
                    {
                        cLinkPassFail _Link = Action.ListResetTools.FirstOrDefault(x => x.rtcIDref == orderAction.ID);
                        if (_Link != null)
                        {

                            // lấy action
                            cAction _ActionLink = GlobVar.GroupActions.Actions[_Link.rtcIDref];
                            _Link.rtcRef = GlobFuncs.BuildRefString_Property(GlobVar.GroupActions, _ActionLink, null);
                            string toolName = _Link.rtcRef;
                            if (_ActionLink.ActionType == EActionTypes.BranchItem)
                                toolName = "    " + _Link.rtcRef;
                            else if (_ActionLink.IDBranchItem != Guid.Empty)
                                toolName = "        " + _Link.rtcRef;

                            ResetTool Reset = new ResetTool();
                            Reset.IDref = _Link.rtcIDref;
                            Reset.IsReset = _Link.rtcActive;
                            Reset.ToolName = toolName;
                            Reset.Type = Enum.GetName(typeof(EActionTypes), _ActionLink.ActionType);
                            Reset.Settings = cStrings.Setting;
                            Reset.SettingsValue = cStrings.Hide;

                            tlInputPassCriteria.AddObject(Reset);
                        }
                    }

                if (currentID != Guid.Empty)
                {
                    foreach (var nodeLink in tlInputPassCriteria.Roots)
                    {
                        if ((Guid)colIDRef.GetValue(nodeLink) == currentID)
                        {
                            tlInputPassCriteria.FocusedObject = nodeLink;
                            return;
                        }
                    }
                }
            }
            finally
            {
                tlInputPassCriteria.EndUpdate();
            }

        }
        private void tlInputPassCriteria_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {

            if (e.Column == colType)
            {
                int ImageIndex = GlobVar.imlActionType16.Images.IndexOfKey(e.CellValue.ToString());
                if (ImageIndex != -1)
                {
                    e.SubItem.ImageSelector = GlobVar.imlActionType16.Images[ImageIndex];
                    e.SubItem.Text = "";
                }

            }
        }

        #endregion

        private void tlInputPassCriteria_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.Column == colSetting)
            {
                ResetTool parentNode = (ResetTool)e.Model;
                if (parentNode == null) return;
                string mode = colSettingValue.GetValue(parentNode).ToString();
                switch (mode)
                {
                    case cStrings.Hide:
                        ShowActionProperties(parentNode);
                        break;

                    case cStrings.Show:
                        HideActionProperties(parentNode);
                        break;
                }
            }
        }
        private void ShowActionProperties(ResetTool parentNode)
        {
            if (parentNode == null) return;
            //Get Action
            cLinkPassFail _Link = Action.ListResetTools.Find(x => x.rtcIDref == parentNode.IDref);
            if (!GlobVar.GroupActions.Actions.ContainsKey(_Link.rtcIDref)) return;
            cAction actionLink = GlobVar.GroupActions.Actions[_Link.rtcIDref];
            // Show all ActionLink properties to tree list
            var properties = actionLink.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(actionLink, null)) != null &&
                                                                              ((RTCVariableType)x.GetValue(actionLink, null)).rtcActive &&
                                                                              !((RTCVariableType)x.GetValue(actionLink, null)).rtcSystem &&
                                                                              !((RTCVariableType)x.GetValue(actionLink, null)).rtcHidden);
            foreach (PropertyInfo property in properties)
            {
                RTCVariableType value = (RTCVariableType)actionLink.GetType().GetProperty(property.Name)?.GetValue(actionLink, null);
                if (value == null)
                    continue;
                if (value.ParentIDResets != null && value.ParentIDResets.Contains(Action.ID))
                {
                    ResetTool Reset = new ResetTool();
                    Reset.IDref = actionLink.ID;
                    Reset.IsReset = true;
                    Reset.ToolName = property.Name;
                    Reset.Type = "";
                    Reset.Settings = "";
                    Reset.SettingsValue = cStrings.None;
                    parentNode.child.Add(Reset);
                }
                else
                {
                    ResetTool Reset = new ResetTool();
                    Reset.IDref = actionLink.ID;
                    Reset.IsReset = false;
                    Reset.ToolName = property.Name;
                    Reset.Type = "";
                    Reset.Settings = "";
                    Reset.SettingsValue = cStrings.None;
                    parentNode.child.Add(Reset);
                }

            }

            if (actionLink.DataItems != null)
                foreach (var dataItem in actionLink.DataItems)
                {
                    if (dataItem.ParentIDResets != null && dataItem.ParentIDResets.Contains(Action.ID))
                    {
                        ResetTool Reset = new ResetTool();
                        Reset.IDref = actionLink.ID;
                        Reset.IsReset = true;
                        Reset.ToolName = dataItem.Name;
                        Reset.Type = "";
                        Reset.Settings = "";
                        Reset.SettingsValue = cStrings.None;
                        parentNode.child.Add(Reset);
                    }

                    else
                    {
                        ResetTool Reset = new ResetTool();
                        Reset.IDref = actionLink.ID;
                        Reset.IsReset = false;
                        Reset.ToolName = dataItem.Name;
                        Reset.Type = "";
                        Reset.Settings = "";
                        Reset.SettingsValue = cStrings.None;
                        parentNode.child.Add(Reset);
                    }

                }

            if (actionLink.MyExpression != null && actionLink.MyExpression.Operands != null)
                foreach (var operandItem in actionLink.MyExpression.Operands)
                {
                    if (operandItem.ParentIDResets != null && operandItem.ParentIDResets.Contains(Action.ID))
                    {
                        ResetTool Reset = new ResetTool();
                        Reset.IDref = actionLink.ID;
                        Reset.IsReset = true;
                        Reset.ToolName = operandItem.Name;
                        Reset.Type = "";
                        Reset.Settings = "";
                        Reset.SettingsValue = cStrings.None;
                        parentNode.child.Add(Reset);
                    }

                    else
                    {
                        ResetTool Reset = new ResetTool();
                        Reset.IDref = actionLink.ID;
                        Reset.IsReset = false;
                        Reset.ToolName = operandItem.Name;
                        Reset.Type = "";
                        Reset.Settings = "";
                        Reset.SettingsValue = cStrings.None;
                        parentNode.child.Add(Reset);
                    }
                }

            colSettingValue.PutValue(parentNode, cStrings.Show);
            tlInputPassCriteria.RefreshObject(parentNode);
            tlInputPassCriteria.CanExpandGetter = x => (x as ResetTool).child.Count > 0;
            tlInputPassCriteria.ChildrenGetter = x => (x as ResetTool).child;
            tlInputPassCriteria.ExpandAll();


        }
        private void HideActionProperties(ResetTool parentNode)
        {
            if (parentNode == null || parentNode.child.Count < 0) return;
            parentNode.child.Clear();
            colSettingValue.PutValue(parentNode, cStrings.Hide);
            tlInputPassCriteria.RefreshObject(parentNode);

        }

        private void tlInputPassCriteria_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
        }

        private void tlInputPassCriteria_SubItemChecking(object sender, BrightIdeasSoftware.SubItemCheckingEventArgs e)
        {
            if (e.Column == colActive)
            {
                cLinkPassFail link = Action.ListResetTools.Find(x => x.rtcIDref == ((ResetTool)(e.RowObject)).IDref);

                if (link == null || !GlobVar.GroupActions.Actions.ContainsKey(link.rtcIDref)) return;
                cAction actionLink = GlobVar.GroupActions.Actions[link.rtcIDref];
                
                string mode = colSettingValue.GetValue(e.RowObject)?.ToString();
                switch (mode)
                {
                    case cStrings.Hide:
                        link.rtcActive = !link.rtcActive;
                        break;

                    case cStrings.Show:
                        link.rtcActive = !link.rtcActive;
                        break;

                    default:
                        {
                            bool isCanReset = e.NewValue == CheckState.Checked ? true : false;
                            string propertyName = colRef.GetValue(e.RowObject).ToString();
                            RTCVariableType value = (RTCVariableType)actionLink.GetType().GetProperty(propertyName)
                                ?.GetValue(actionLink, null);
                            if (value != null)
                            {
                                if (value.ParentIDResets == null)
                                    value.ParentIDResets = new List<Guid>();
                                if (isCanReset && !value.ParentIDResets.Contains(Action.ID))
                                    value.ParentIDResets.Add(Action.ID);
                                else if (!isCanReset && value.ParentIDResets.Contains(Action.ID))
                                    value.ParentIDResets.Remove(Action.ID);
                                return;
                            }

                            if (actionLink.DataItems != null)
                            {
                                SStringBuilderItem dataItem =
                                    actionLink.DataItems.FirstOrDefault(x => x.Name == propertyName);
                                if (dataItem != null)
                                {
                                    if (dataItem.ParentIDResets == null)
                                        dataItem.ParentIDResets = new List<Guid>();
                                    if (isCanReset && !dataItem.ParentIDResets.Contains(Action.ID))
                                        dataItem.ParentIDResets.Add(Action.ID);
                                    else if (!isCanReset && dataItem.ParentIDResets.Contains(Action.ID))
                                        dataItem.ParentIDResets.Remove(Action.ID);
                                    return;
                                }
                            }

                            if (actionLink.MyExpression != null && actionLink.MyExpression.Operands != null)
                            {
                                SStringBuilderItem operandItem =
                                    actionLink.MyExpression.Operands.FirstOrDefault(x => x.Name == propertyName);

                                if (operandItem != null)
                                {
                                    if (operandItem.ParentIDResets == null)
                                        operandItem.ParentIDResets = new List<Guid>();
                                    if (isCanReset && !operandItem.ParentIDResets.Contains(Action.ID))
                                        operandItem.ParentIDResets.Add(Action.ID);
                                    else if (!isCanReset && operandItem.ParentIDResets.Contains(Action.ID))
                                        operandItem.ParentIDResets.Remove(Action.ID);
                                    return;
                                }
                            }

                            break;
                        }
                }
            }
        }

        private void tlInputPassCriteria_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            tlInputPassCriteria.FocusedObject = tlInputPassCriteria.SelectedObject = e.Model;
        }
    }
}


