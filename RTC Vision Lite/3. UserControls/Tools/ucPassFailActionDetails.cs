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
    public partial class ucPassFailActionDetails : ucBaseActionDetail
    {

        Dictionary<int, Guid> dicToolID = new Dictionary<int, Guid>();
        public ucPassFailActionDetails()
        {
            InitializeComponent();
            tlInputPassCriteria.TreeColumnRenderer.IsShowLines = false;
            tlInputPassCriteria.ShowImagesOnSubItems = true;

        }

        private void UpdateData(List<PassFail> nodes)
        {
            if (nodes == null)
                return;

            foreach (PassFail node in nodes)
            {
                Guid actionId = node.IDref;
                if (!GlobVar.GroupActions.Actions.TryGetValue(actionId, out cAction action))
                    continue;
                cLinkPassFail linkPassFail = Action.LinkPassFail?.FirstOrDefault(x => x.rtcIDref == actionId);
                if (linkPassFail == null)
                    continue;

                PropertyInfo propertyInfoSrc = action.GetType().GetProperty(linkPassFail.rtcPropNameRef);
                if (propertyInfoSrc == null)
                    continue;

                RTCVariableType propertyInfo = (RTCVariableType)action.GetType().GetProperty(linkPassFail.rtcPropNameRef)?.GetValue(action, null);
                PropertyInfo propertyInfoValue = propertyInfoSrc.PropertyType.GetProperty(cPropertyName.rtcValue);
                if (propertyInfoValue == null)
                    continue;
                object obj = propertyInfoValue.GetValue(propertyInfo, null);
                bool linkValue = GlobFuncs.GetBoolValueFromObject(obj);
                Image resultImage = null;
                Image currentImage = imageListValue.Images[linkValue.ToString()];
                if (linkPassFail.rtcInvert)
                {
                    bool bResult = !linkValue;
                    resultImage = imageListValue.Images[bResult.ToString()];
                }
                else
                    resultImage = imageListValue.Images[linkValue.ToString()];
              // tlInputPassCriteria.SetSubItemImage(tl.)
              // node.SetValue(colResult, resultImage);
                UpdateData(node.child);
            }
        }
        internal void LoadLinkData(bool onlyValue = false)
        {
            try
            {
                tlInputPassCriteria.BeginUpdate();
                if (onlyValue)
                {
                    UpdateData(tlInputPassCriteria.Roots.Cast<PassFail>().ToList());
                }
                else
                {
                    Guid currentID = Guid.Empty;
                    if (tlInputPassCriteria.FocusedObject != null && colIDRef.GetValue(tlInputPassCriteria.FocusedObject) != null)
                        currentID = (Guid)colIDRef.GetValue(tlInputPassCriteria.FocusedObject);

                    // Hiển thị danh sách các link 
                    tlInputPassCriteria.ClearObjects();

                    if (Action != null && Action.LinkPassFail != null)
                        foreach (cLinkPassFail _Link in Action.LinkPassFail)
                        {
                            Image typeImage = null;
                            Image currentImage = null;
                            Image resultImage = null;
                            bool _bResult = false;

                            if (!GlobVar.GroupActions.Actions.ContainsKey(_Link.rtcIDref))
                                continue;

                            // lấy action
                            cAction _ActionLink = GlobVar.GroupActions.Actions[_Link.rtcIDref];

                            if (_ActionLink.STT >= Action.STT)
                                continue;

                            typeImage = GlobVar.imlActionType16.Images[GlobVar.imlActionType16.Images.IndexOfKey(Enum.GetName(typeof(EActionTypes), _ActionLink.ActionType))];

                            PropertyInfo PropertyInfoSrc = _ActionLink.GetType().GetProperty(_Link.rtcPropNameRef);
                            if (PropertyInfoSrc == null)
                                continue;

                            RTCVariableType propertyInfo = (RTCVariableType)_ActionLink.GetType().GetProperty(_Link.rtcPropNameRef)?.GetValue(_ActionLink, null);
                            PropertyInfo propertyInfoValue = PropertyInfoSrc.PropertyType.GetProperty(cPropertyName.rtcValue);
                            object obj = propertyInfoValue.GetValue(propertyInfo, null);

                            _Link.rtcRef = GlobFuncs.BuildRefString_Property(GlobVar.GroupActions, _ActionLink, PropertyInfoSrc);

                            bool linkValue = GlobFuncs.GetBoolValueFromObject(obj);

                            //currentImage = imageListValue.Images[linkValue.ToString()];
                            if (_Link.rtcInvert)
                            {
                                 _bResult = !linkValue;
                               // resultImage = imageListValue.Images[_bResult.ToString()];
                            }
                            //else resultImage = imageListValue.Images[linkValue.ToString()];

                            //if (_ActionLink.Passed != null)
                            //{
                            //    PropertyInfo PropertyInfoSrc = _ActionLink.GetType().GetProperty(nameof(Action.Passed));
                            //    _Link.rtcRef = GlobFuncs.BuildRefString_Property(GlobVar.GroupActions, _ActionLink, PropertyInfoSrc);
                            //}

                            string toolName = _Link.rtcRef;
                            if (_ActionLink.ActionType == EActionTypes.BranchItem)
                                toolName = "    " + _Link.rtcRef;
                            else if (_ActionLink.IDBranchItem != Guid.Empty)
                                toolName = "        " + _Link.rtcRef;

                            string toolNameGetResult = _ActionLink.Name.rtcValue;
                            if (GlobVar.GroupActions.Actions.ContainsKey(_Link.rtcIDGetResult))
                                toolNameGetResult = GlobVar.GroupActions.Actions[_Link.rtcIDGetResult].Name.rtcValue;
                            PassFail node = new PassFail();
                            node.IDref = _Link.rtcIDref;
                            node.Active = _Link.rtcActive;
                            node.Ref = toolName;
                            node.PropName = _Link.rtcPropNameRef;
                            node.Invert = _Link.rtcInvert;
                            node.GetResult = _Link.rtcGetResult;
                            node.ToolGetResult = toolNameGetResult;
                            node.Type = Enum.GetName(typeof(EActionTypes), _ActionLink.ActionType);
                            node.CurrentValue = linkValue.ToString();
                            node.Result = _bResult.ToString();
                            tlInputPassCriteria.AddObject(node);
                        }

                    if (currentID != Guid.Empty)
                    {
                        foreach (PassFail nodeLink in tlInputPassCriteria.Roots.Cast<PassFail>().ToList())
                        {
                            if ((Guid)colIDRef.GetValue(nodeLink) == currentID)
                            {
                                tlInputPassCriteria.FocusedObject = nodeLink;
                                //tlInputPassCriteria.MakeNodeVisible(tlInputPassCriteria.FocusedNode);
                                return;
                            }
                        }
                    }
                }
            }
            finally
            {
                tlInputPassCriteria.Refresh();
                tlInputPassCriteria.EndUpdate();
            }

        }

        private void tlInputPassCriteria_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if(e.Column == colActive)
            {
                if(e.Item.CheckState == CheckState.Checked)
                {
                    //e.SubItem.Decoration.SubItem.ImageSelector =
                    e.SubItem.ImageSelector = imageListValue.Images[1];
                }    
                else
                {
                    e.SubItem.ImageSelector = imageListValue.Images[0];
                }
            }
            else if (e.Column == colType)
            {
               e.SubItem.ImageSelector =  GlobVar.imlActionType16.Images[GlobVar.imlActionType16.Images.IndexOfKey(e.CellValue.ToString())];
                e.SubItem.Text = "";
            }
            else if (e.Column == colCurrentValue)
            {
                e.SubItem.ImageSelector = imageListValue.Images[e.CellValue.ToString()];
                e.SubItem.Text = "";
            }    
            else if (e.Column == colResult)
            {
                bool bResult = false;
                bool bInvert = false;

                bInvert = ((PassFail)e.Model).Invert;
                bResult = Lib.ToBoolean(((PassFail)e.Model).CurrentValue);
                if (bInvert)
                {
                    bResult = !bResult;
                }    
                e.SubItem.ImageSelector = imageListValue.Images[bResult.ToString()];
                e.SubItem.Text = "";
            }    
            
                
        }

        private void tlInputPassCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PageActionSetting_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tlInputPassCriteria_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            
            if (e.Column == colPropName)
           {
                ComboBox cbPropName= new ComboBox();
                cbPropName.DropDownStyle = ComboBoxStyle.DropDownList;
                cbPropName.Items.Clear();
                cbPropName.Bounds = e.CellBounds;
                if (GlobVar.GroupActions == null)
                    tlInputPassCriteria.FinishCellEdit();

               
                cLinkPassFail _Link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)tlInputPassCriteria.FocusedObject).IDref);
                cAction _ActionLink = GlobVar.GroupActions.Actions[_Link.rtcIDref];

                var listPropertyInfo = _ActionLink.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(_ActionLink, null)) != null &&
                    ((RTCVariableType)x.GetValue(_ActionLink, null)).rtcActive).ToList();
                foreach (var property in listPropertyInfo)
                    if (property.PropertyType == typeof(SBool) ||
                       property.PropertyType == typeof(SString) ||
                       property.PropertyType == typeof(SInt) ||
                       property.PropertyType == typeof(SListDouble) ||
                       property.PropertyType == typeof(SListString) ||
                       property.PropertyType == typeof(SListObject)
                       )
                        cbPropName.Items.Add(property.Name);

                if (_ActionLink.MyExpression != null && _ActionLink.MyExpression.Operands != null)
                    foreach (SStringBuilderItem operand in _ActionLink.MyExpression.Operands)
                        cbPropName.Items.Add(operand.Name);

                if (_ActionLink.DataItems != null)
                    foreach (SStringBuilderItem item in _ActionLink.DataItems)
                        cbPropName.Items.Add(item.Name);
                cbPropName.SelectedItem = e.Value;
                e.Control = cbPropName;

            }
           else if (e.Column == colToolGetResult)
            {
                dicToolID = new Dictionary<int, Guid>();
                int Index = 0;
                ComboBox cbTool = new ComboBox();
                cbTool.DropDownStyle = ComboBoxStyle.DropDownList;
                cbTool.Bounds = e.CellBounds;
                if (GlobVar.GroupActions == null)
                    tlInputPassCriteria.FinishCellEdit();
                var orderActions = GlobVar.GroupActions.Actions.Values.OrderBy(x => x.STT).ToList();
                foreach (cAction action in orderActions)
                {
                    if (Action.LinkPassFail.FirstOrDefault(x => x.rtcIDref == action.ID) != null)
                    {
                        cbTool.Items.Add(action.Name.rtcValue);
                        dicToolID.Add(Index, action.ID);
                        Index += 1;
                    }    
                }
                cbTool.Items.Add(Action.Name.rtcValue);
                dicToolID.Add(Index, Action.ID);
                cbTool.SelectedItem = e.Value;
                e.Control = cbTool;
            }
            else if (e.Column == colInvert)
            {
                cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)e.RowObject).IDref);
                if (link != null)
                    link.rtcInvert = !link.rtcInvert;
                else
                    return;
                e.Column.PutValue(e.RowObject, link.rtcIDref);
                cAction actionLink = GlobVar.GroupActions.Actions[link.rtcIDref];
                base.RunAction();
            }

            else if (e.Column == colGetResult)
            {
                cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)e.RowObject).IDref);
                if (link != null)
                {
                    link.rtcGetResult = !link.rtcGetResult;
                    colGetResult.PutValue(e.RowObject, link.rtcGetResult);
                    base.RunAction();
                }
            }
            else if (e.Column == colActive)
            {
                cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)e.RowObject).IDref);
                if (link != null)
                {
                    link.rtcGetResult = !link.rtcGetResult;
                    colActive.PutValue(e.RowObject, link.rtcActive);
                    base.RunAction();
                }
            }

        }

        private void ComBoBoxPropNameSelectedIndexChange(object sender, EventArgs e)
        {
            ComboBox cbPropName = (ComboBox)sender;
            object focusNode = tlInputPassCriteria.FocusedObject;

            cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)tlInputPassCriteria.FocusedObject).IDref);
            if (link != null)
            {
                link.rtcPropNameRef = cbPropName.SelectedItem.ToString();
                this.colPropName.PutValue(focusNode, link.rtcPropNameRef);
            }

        }
        private void ComBoBoxToolResultSelectedIndexChange(object sender, EventArgs e)
        {
            ComboBox cbToolResult = (ComboBox)sender;
            object focusNode = tlInputPassCriteria.FocusedObject;

            cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)tlInputPassCriteria.FocusedObject).IDref);
            if (link != null)
            {
                if (cbToolResult == null || dicToolID == null || !dicToolID.ContainsKey(cbToolResult.SelectedIndex))
                    return;
                cAction action = GlobVar.GroupActions.Actions[dicToolID[cbToolResult.SelectedIndex]];
                if (action != null)
                {
                    link.rtcIDGetResult = action.ID;
                    colToolGetResult.PutValue(tlInputPassCriteria.FocusedObject, action.Name.rtcValue);
                }    
            }    


        }
        private void tlInputPassCriteria_CellEditFinishing_1(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column == colPropName)
            {
                ComboBox Combobox = (ComboBox)e.Control;
                if (Combobox.SelectedItem == null)
                {
                    e.Cancel = true;
                }
                Combobox.SelectedIndexChanged += ComBoBoxPropNameSelectedIndexChange;
                e.NewValue = Combobox.SelectedItem;
                base.RunAction();
            }
            else if (e.Column == colToolGetResult)
            {
                ComboBox Combobox = (ComboBox)e.Control;
                if (Combobox.SelectedItem == null)
                {
                    e.Cancel = true;
                }
                Combobox.SelectedIndexChanged += ComBoBoxPropNameSelectedIndexChange;
                e.NewValue = Combobox.SelectedItem;
                base.RunAction();
            }
            else if (e.Column ==  colInvert)
            {
                cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)e.RowObject).IDref);
                if (link != null)
                    link.rtcInvert = !link.rtcInvert;
                else
                    return;
                e.Column.PutValue(e.RowObject, link.rtcIDref);
                cAction actionLink = GlobVar.GroupActions.Actions[link.rtcIDref];
                base.RunAction();
            }
           
            else if (e.Column == colGetResult)
            {
                cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)e.RowObject).IDref);
                if (link != null)
                {
                    link.rtcGetResult = !link.rtcGetResult;
                    colGetResult.PutValue(e.RowObject, link.rtcGetResult);
                    base.RunAction();
                }
            }
            else if (e.Column == colActive)
            {
                cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)e.RowObject).IDref);
                if (link != null)
                {
                    link.rtcGetResult = !link.rtcGetResult;
                    colActive.PutValue(e.RowObject, link.rtcActive);
                    base.RunAction();
                }
            }


        }

        private void tlInputPassCriteria_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            

        }

        private void tlInputPassCriteria_SubItemChecking(object sender, BrightIdeasSoftware.SubItemCheckingEventArgs e)
        {
            if (e.Column == colInvert)
            {
                cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)e.RowObject).IDref);
                if (link != null)
                    link.rtcInvert = !link.rtcInvert;
                else
                    return;
                e.Column.PutValue(e.RowObject, link.rtcIDref);
                cAction actionLink = GlobVar.GroupActions.Actions[link.rtcIDref];
                base.RunAction();
            }

            else if (e.Column == colGetResult)
            {
                cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)e.RowObject).IDref);
                if (link != null)
                {
                    link.rtcGetResult = !link.rtcGetResult;
                    colGetResult.PutValue(e.RowObject, link.rtcGetResult);
                    base.RunAction();
                }
            }
            else if (e.Column == colActive)
            {
                cLinkPassFail link = Action.LinkPassFail.Find(x => x.rtcIDref == ((PassFail)e.RowObject).IDref);
                if (link != null)
                {
                    link.rtcActive = !link.rtcActive;
                    colActive.PutValue(e.RowObject, link.rtcActive);
                    base.RunAction();
                }
            }
        }
    }
}
