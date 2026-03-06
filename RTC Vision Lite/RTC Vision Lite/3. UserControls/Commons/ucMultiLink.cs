using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
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
    public partial class ucMultiLink : UserControl
    {
        public ucMultiLink()
        {
            InitializeComponent();
        }
        private ComboBox cbCam = new ComboBox();
        private ComboBox cbSourceProperty = new ComboBox();
        private ComboBox cbSourceTool = new ComboBox();

        private cAction _rtcAction;
        public cAction RTCAction
        {
            get => _rtcAction;
            set
            {
                _rtcAction = value;
                InitHeaderCaption();
                ReviewValue();
                LoadListCamToCombo();
            }
        }
        private string _propertyName;
        public string PropertyName
        {
            get => _propertyName;
            set
            {
                _propertyName = value;
                InitHeaderCaption();
                ReviewValue();
            }
        }

        #region FUNCTION
        /// <summary>
        /// View thông tin tên biến lên giao diện
        /// </summary>
        private void InitHeaderCaption()
        {
            panActions.Enabled = false;
            if (RTCAction != null)
            {
                if (string.IsNullOrEmpty(PropertyName))
                    return;
                else
                {
                    PropertyInfo propertyInfo = RTCAction.GetType().GetProperty(PropertyName);
                    if (propertyInfo == null)
                        grpMain.Text = $"Link: {PropertyName}";
                    else
                    {
                        //grpMain.Text = $"Link: <color='blue'> {propertyInfo.PropertyType.Name} </color>- {PropertyName}";
                        grpMain.Text = $" {propertyInfo.PropertyType.Name} {PropertyName}";
                        panActions.Enabled = true;
                    }
                }
            }
            else
                grpMain.Text = $"Link: {PropertyName}";
        }
        internal void ReviewValue()
        {
            lblValue.Text = string.Empty;
            if (RTCAction != null)
            {
                if (string.IsNullOrEmpty(PropertyName))
                    return;
                else
                {
                    RTCVariableType rtcVariableType = (RTCVariableType)RTCAction.GetType()
                        .GetProperty(PropertyName)?.GetValue(RTCAction, null);

                    if (rtcVariableType == null)
                        return;
                    else
                        lblValue.Text = rtcVariableType.rtcValueView;
                }
            }
        }
        /// <summary>
        /// Nạp danh sách các link vào trong Danh Sách TreeListView
        /// </summary>
        public void LoadLinkProperty()
        {
            try
            {
                GlobVar.LockEvents = true;
                LoadListCamToCombo();

                tlLink.SuspendLayout();
                tlLink.ClearObjects();
                List<cLinkProperty> listRemoves = new List<cLinkProperty>();

                //Hiển thị danh sách các link
                if (RTCAction != null && RTCAction.LinkProperty != null)
                {
                    var orderList = from linkItem in RTCAction.LinkProperty
                                    orderby linkItem.OrderNum
                                    select linkItem;

                    foreach (cLinkProperty linkItem in orderList)
                        if (linkItem.TargetName == PropertyName)
                        {
                            cCAMTypes sourceCam = null;
                            cCAMTypes targetCam = null;
                            cAction sourceAction = null;
                            cAction targetAction = null;
                            cGroupActions sourceGroup = null;
                            cGroupActions targetGroup = null;
                            GlobVar.CurrentProject?.CAMs.TryGetValue(linkItem.SourceCamID, out sourceCam);
                            GlobVar.CurrentProject?.CAMs.TryGetValue(linkItem.TargetCamID, out targetCam);
                            sourceCam?.GroupActions.Actions.TryGetValue(linkItem.SourceID, out sourceAction);
                            targetCam?.GroupActions.Actions.TryGetValue(linkItem.TargetID, out targetAction);
                            if (sourceCam == null || targetCam == null)
                            {
                                listRemoves.Add(linkItem);
                                continue;
                            }


                            GlobVar.CurrentProject?.CAMs.TryGetValue(linkItem.SourceCamID, out sourceCam);
                            sourceGroup = linkItem.SourceCamID == RTCAction.MyGroup.MyCam.ID ? GlobVar.GroupActions : sourceCam?.GroupActions;
                            GlobVar.CurrentProject?.CAMs.TryGetValue(linkItem.TargetCamID, out targetCam);
                            targetGroup = linkItem.TargetCamID == RTCAction.MyGroup.MyCam.ID ? GlobVar.GroupActions : targetCam?.GroupActions;
                            if (sourceGroup == null || targetGroup == null)
                            {
                                listRemoves.Add(linkItem);
                                continue;
                            }

                            sourceGroup?.Actions.TryGetValue(linkItem.SourceID, out sourceAction);
                            targetGroup?.Actions.TryGetValue(linkItem.TargetID, out targetAction);
                            if (sourceAction == null || targetAction == null)
                            {
                                listRemoves.Add(linkItem);
                                continue;
                            }

                            RTCVariableType targetValue = (RTCVariableType)targetAction?.GetType().GetProperties()
                                .FirstOrDefault(x => x.Name == linkItem.TargetName)?.GetValue(targetAction, null);
                            SStringBuilderItem targetDataItem = null;
                            if (targetValue == null)
                                if (targetAction.MyExpression != null && targetAction.MyExpression.Operands != null)
                                    targetDataItem =
                                        targetAction.MyExpression.Operands.FirstOrDefault(x => x.Name == linkItem.TargetName);
                            MultiLink newNode = new MultiLink();
                            newNode.OrderNumber = linkItem.OrderNum;
                            newNode.SourceCam = sourceCam != null ? (sourceCam.Name == RTCAction.MyGroup.MyCam.Name ? cStrings.This : sourceCam.Name) : string.Empty;
                            newNode.SourceTool = sourceAction?.Name.rtcValue ?? string.Empty;
                            newNode.SourceName = linkItem.SourceName;
                            newNode.SourceIndex = linkItem.SourceIndex[0].ToString().Replace("[", "").Replace("]", "").Replace(@"""", "");
                            tlLink.AddObject(newNode);
                        }

                    foreach (cLinkProperty linkProperty in listRemoves)
                        RTCAction.LinkProperty.Remove(linkProperty);
                }
                List<MultiLink> AllNodes = tlLink.Objects.Cast<MultiLink>().ToList();
                if (AllNodes.Count > 0)
                    tlLink.FocusedObject = (AllNodes[0]);
            }
            finally
            {
                tlLink.ResumeLayout();
                GlobVar.LockEvents = false;
            }
        }

        public void LoadListCamToCombo()
        {
            if (RTCAction == null)
                return;
            cbCam.Items.Clear();
            if (GlobVar.CurrentProject == null)
                return;
            foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
            {
                if (RTCAction.MyGroup.MyCam != null && cam.Name == RTCAction.MyGroup.MyCam.Name)
                    cbCam.Items.Add(cStrings.This);
                else
                    cbCam.Items.Add(cam.Name);
            }
        }
        private DataTable LoadSourceTool()
        {
            if (tlLink.FocusedObject == null)
                return null;
            string sCamName = ((MultiLink)tlLink.FocusedObject).SourceCam;
            cGroupActions groupActions = sCamName == cStrings.This
                ? GlobVar.GroupActions
                : GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName)?.GroupActions;
            if (groupActions == null)
                return null;
            var orderActions = groupActions.Actions.Values.OrderBy(x => x.STT).ToList();

            DataTable data = new DataTable();
            data.Columns.Add(cColName.Name, typeof(string));
            data.Columns.Add(cColName.Value, typeof(string));

            foreach (cAction action in orderActions)
                data.Rows.Add(new object[] { action.Name.rtcValue, action.Name.rtcValue });
            return data;
        }
        private void LoadSourceToolToCombo()
        {
            string sCamName = ((MultiLink)tlLink.FocusedObject).SourceCam;
            cGroupActions groupActions = sCamName == cStrings.This
         ? GlobVar.GroupActions
         : GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName)?.GroupActions;
            if (groupActions == null)
                return;
            var orderActions = groupActions.Actions.Values.OrderBy(x => x.STT).ToList();
            foreach (cAction action in orderActions)
                cbSourceTool.Items.Add(action.Name.rtcValue);
        }
        private void LoadSourcePropertyToCom()
        {
            string sCamName = colSourceCam.GetValue(tlLink.FocusedObject)?.ToString();
            cGroupActions groupActions = sCamName == cStrings.This
                ? GlobVar.GroupActions
                : GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName)?.GroupActions;
            if (groupActions == null)
                return;
            string sToolName = colSourceTool.GetValue(tlLink.FocusedObject).ToString();
            cAction sourceAction = groupActions.Actions.Values.FirstOrDefault(x => x.Name.rtcValue == sToolName);
            if (sourceAction == null)
                return;
            var listPropertyInfo = sourceAction.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(sourceAction, null)) != null &&
                ((RTCVariableType)x.GetValue(sourceAction, null)).rtcActive).ToList();
            foreach (var property in listPropertyInfo)
                cbSourceProperty.Items.Add(property.Name);
            if (sourceAction.MyExpression != null && sourceAction.MyExpression.Operands != null)
                foreach (SStringBuilderItem operand in sourceAction.MyExpression.Operands)
                    cbSourceProperty.Items.Add(operand.Name);
            if (sourceAction.DataItems != null)
                foreach (SStringBuilderItem item in sourceAction.DataItems)
                    cbSourceProperty.Items.Add(item.Name);
        }    

        /// <summary>
        /// Đánh lại số thứ tự
        /// </summary>
        private void ReOrderNum()
        {
            if (RTCAction == null || RTCAction.LinkProperty == null)
                return;
            List<MultiLink> AllNode = tlLink.Objects.Cast<MultiLink>().ToList();
            Dictionary<int, int> orderOldNew = new Dictionary<int, int>();
            for (int i = 0; i < AllNode.Count; i++)
            {
                MultiLink node = AllNode[i];
                orderOldNew.Add(node.OrderNumber, i + 1);
                node.OrderNumber = i + 1;
                tlLink.RefreshObject(node);
            }

            foreach (cLinkProperty linkProperty in RTCAction.LinkProperty)
                linkProperty.OrderNum = orderOldNew[linkProperty.OrderNum];
        }

        /// <summary>
        /// Nạp 1 link thuộc tính vào trong treelist hiển thị
        /// </summary>
        /// <param name="linkItem">Đối tượng link cần hiển thị</param>
        /// <returns>True: View thành công; False: View thất bại</returns>
        private bool AddLinkItemToTreeList(cLinkProperty linkItem)
        {
            try
            {
                tlLink.SuspendLayout();
                cCAMTypes sourceCam = null;
                cCAMTypes targetCam = null;
                cGroupActions sourceGroup = null;
                cGroupActions targetGroup = null;

                cAction sourceAction = null;
                cAction targetAction = null;

                GlobVar.CurrentProject?.CAMs.TryGetValue(linkItem.SourceCamID, out sourceCam);
                sourceGroup = linkItem.SourceCamID == RTCAction.MyGroup.MyCam.ID ? GlobVar.GroupActions : sourceCam?.GroupActions;

                GlobVar.CurrentProject?.CAMs.TryGetValue(linkItem.TargetCamID, out targetCam);
                targetGroup = linkItem.TargetCamID == RTCAction.MyGroup.MyCam.ID ? GlobVar.GroupActions : targetCam?.GroupActions;

                sourceGroup?.Actions.TryGetValue(linkItem.SourceID, out sourceAction);
                targetGroup?.Actions.TryGetValue(linkItem.TargetID, out targetAction);

                RTCVariableType targetValue = (RTCVariableType)targetAction?.GetType().GetProperties()
                    .FirstOrDefault(x => x.Name == linkItem.TargetName)?.GetValue(targetAction, null);
                MultiLink newNode = new MultiLink();
                newNode.OrderNumber = linkItem.OrderNum;
                newNode.SourceCam = sourceCam != null ? (sourceCam.Name == RTCAction.MyGroup.MyCam.Name ? cStrings.This : sourceCam.Name) : string.Empty;
                newNode.SourceTool = sourceAction?.Name.rtcValue ?? string.Empty;
                newNode.SourceName = linkItem.SourceName;
                newNode.SourceIndex = GlobFuncs.ListObject2Str(linkItem.SourceIndex).ToString().Replace("[", "").Replace("]", "").Replace(@"""", "");
                tlLink.AddObject(newNode);
                return true;
            }
            finally
            {
                tlLink.ResumeLayout();
            }
        }
        /// <summary>
        /// Lấy thông tin của các link item khi có sự thay đổi trên treelist
        /// </summary>
        private void GetLinkItemValue()
        {
            if (tlLink.FocusedObject == null)
                return;
            if (!int.TryParse(colOrderNumber.GetValue(tlLink.FocusedObject).ToString(), out int orderNum))
                return;
            cLinkProperty linkItem = RTCAction.LinkProperty?.FirstOrDefault(x => x.OrderNum == orderNum);

            if (linkItem == null)
                return;
            MultiLink SelectedNode = ((MultiLink)tlLink.FocusedObject);
            string sCamName = SelectedNode.SourceCam;
            cCAMTypes sourceCam = (sCamName == cStrings.This) ? RTCAction.MyGroup.MyCam :
                GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName);
            linkItem.SourceCamID = sourceCam?.ID ?? Guid.Empty;
            string sToolName = SelectedNode.SourceTool;
            cGroupActions sourceGroup = linkItem.SourceCamID == RTCAction.MyGroup.MyCam.ID ? GlobVar.GroupActions : sourceCam?.GroupActions;
            cAction sourceAction = sourceGroup?.Actions.Values.FirstOrDefault(x => x.Name.rtcValue == sToolName);
            linkItem.SourceID = sourceAction?.ID ?? Guid.Empty;
            linkItem.SourceName = SelectedNode.SourceName;
            linkItem.SourceIndex = GlobFuncs.Str2StringObj(SelectedNode.SourceIndex, cDelimiterValues.Comma);
        }



        #endregion

        #region EVENTS 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (RTCAction == null || string.IsNullOrEmpty(PropertyName))
                return;
            if (RTCAction.LinkProperty == null)
                RTCAction.LinkProperty = new List<cLinkProperty>();
            int orderNum = 0;
            if (RTCAction.LinkProperty.Count > 0)
                orderNum = RTCAction.LinkProperty[RTCAction.LinkProperty.Count - 1].OrderNum + 1;
            else
                orderNum += 1;
            cLinkProperty linkItem = new cLinkProperty
            {
                OrderNum = orderNum,
                SourceCamID = Guid.Empty,
                SourceID = Guid.Empty,
                SourceName = string.Empty,
                SourceIndex = new List<object>(),
                TargetCamID = RTCAction.MyGroup.MyCam.ID,
                TargetID = RTCAction.ID,
                TargetName = PropertyName,
                TargetIndex = new List<object>(),
                DefaultValue = new List<object>()

            };
            linkItem.SourceIndex.Add(cStrings.None);
            linkItem.TargetIndex.Add(cStrings.None);
            RTCAction.LinkProperty.Add(linkItem);
            AddLinkItemToTreeList(linkItem);
        }
        private void btnDulicate_Click(object sender, EventArgs e)
        {
            if (tlLink.FocusedObject == null || RTCAction == null)
                return;
            List<MultiLink> AllNodes = tlLink.Objects.Cast<MultiLink>().ToList();
            int currentNodeIndex = tlLink.IndexOf(tlLink.FocusedObject);
            bool isMoveWhenAfterAdd = currentNodeIndex != AllNodes.Count - 1;
            int iOrderNum = ((MultiLink)tlLink.FocusedObject).OrderNumber;
            cLinkProperty cloneProperty = RTCAction.LinkProperty.Find(x => x.OrderNum == iOrderNum);
            if (cloneProperty == null)
                return;
            cLinkProperty newLink = cloneProperty.Clone();
            int newLinkOrder = 0;
            foreach (cLinkProperty linkProperty in RTCAction.LinkProperty)
                if (newLinkOrder <= linkProperty.OrderNum)
                    newLinkOrder = linkProperty.OrderNum;
            newLinkOrder += 1;
            newLink.OrderNum = newLinkOrder;
            RTCAction.LinkProperty.Add(newLink);
            AddLinkItemToTreeList(newLink);
            AllNodes = tlLink.Objects.Cast<MultiLink>().ToList();
            if (isMoveWhenAfterAdd)
            {
                MultiLink nodeMove = AllNodes[AllNodes.Count - 1];
                AllNodes.Remove(AllNodes[AllNodes.Count - 1]);
                AllNodes.Insert(currentNodeIndex + 1, nodeMove );
                tlLink.ClearObjects();
               foreach(MultiLink Node in AllNodes)
                {
                    tlLink.AddObject(Node);
                }    
                ReOrderNum();
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (tlLink.FocusedObject == null || RTCAction == null)
                return;
            if (cMessageBox.Question_YesNo("Do you want delete link item?") == DialogResult.No)
                return;
            int iOrderNumber = ((MultiLink)tlLink.FocusedObject).OrderNumber;
            RTCAction.LinkProperty.Remove(RTCAction.LinkProperty.Find(x => x.OrderNum == iOrderNumber));
            tlLink.RemoveObject(tlLink.FocusedObject);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (RTCAction == null) return;
            if (cMessageBox.Question_YesNo("Do you want clear all link item?") == DialogResult.No)
                return;
            RTCAction.LinkProperty = new List<cLinkProperty>();
            LoadLinkProperty();
        }




        #endregion

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                GlobVar.LockEvents = true;
                if (RTCAction == null || RTCAction.LinkProperty == null) return;
                MultiLink FocusNode = (MultiLink)tlLink.FocusedObject;
                if (FocusNode == null) return;
                int IndexNode = tlLink.IndexOf(FocusNode);
                List<MultiLink> AllNodes = tlLink.Objects.Cast<MultiLink>().ToList();
                MultiLink nodeMove = AllNodes[IndexNode];
                AllNodes.Remove(AllNodes[IndexNode]);
                AllNodes.Insert(IndexNode - 1, nodeMove);
                tlLink.ClearObjects();
                foreach (MultiLink Node in AllNodes)
                {
                    tlLink.AddObject(Node);
                }
                ReOrderNum();
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                GlobVar.LockEvents = true;
                if (RTCAction == null || RTCAction.LinkProperty == null) return;
                MultiLink FocusNode = (MultiLink)tlLink.FocusedObject;
                if (FocusNode == null) return;
                int IndexNode = tlLink.IndexOf(FocusNode);
                List<MultiLink> AllNodes = tlLink.Objects.Cast<MultiLink>().ToList();
                if(IndexNode >= AllNodes.Count - 1)
                {
                    return;
                }    
                MultiLink nodeMove = AllNodes[IndexNode];
                AllNodes.Remove(AllNodes[IndexNode]);
                AllNodes.Insert(IndexNode + 1, nodeMove);
                tlLink.ClearObjects();
                foreach (MultiLink Node in AllNodes)
                {
                    tlLink.AddObject(Node);
                }
                ReOrderNum();
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }

        private void tlLink_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column == colSourceCam)
            {
                cbCam = new ComboBox();
                LoadListCamToCombo();
                
                cbCam.DropDownStyle = ComboBoxStyle.DropDownList;
                cbCam.Bounds = e.CellBounds;
                if (e.Value != null)
                    cbCam.SelectedItem = e.Value;
                //cbBool.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
                cbCam.SelectedIndexChanged += cbCam_SelectedIndexChanged;
                e.Control = cbCam;
            }
            else if(e.Column == colSourceTool)
            {
                cbSourceTool = new ComboBox();
                LoadSourceToolToCombo();
                cbSourceTool.DropDownStyle = ComboBoxStyle.DropDownList;
                cbSourceTool.Bounds = e.CellBounds;
                if (e.Value != null)
                    cbSourceTool.SelectedItem = e.Value;
                cbSourceTool.SelectedIndexChanged += cbSourceTool_SelectedIndexChanged;
                e.Control = cbSourceTool;
            }    
            else if (e.Column == colSourceName)
            {
                cbSourceProperty = new ComboBox();
                LoadSourcePropertyToCom();
                cbSourceProperty.DropDownStyle = ComboBoxStyle.DropDownList;
                cbSourceProperty.Bounds = e.CellBounds;
                if (e.Value != null)
                    cbSourceProperty.SelectedItem = e.Value;
                cbSourceProperty.SelectedIndexChanged += cbSourceProperty_SelectedIndexChanged;
                e.Control = cbSourceProperty;
            }    
        }

        private void cbCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSourceTool.Items.Clear();
            cbSourceProperty.Items.Clear();
            if (tlLink.FocusedObject == null)
                return;
            ComboBox edit = (ComboBox)sender;
            string sCamName = edit.Text;
            colSourceCam.PutValue(tlLink.FocusedObject, sCamName);
            tlLink.FinishCellEdit();
        }
        private void cbSourceTool_SelectedIndexChanged (object sender, EventArgs e)
        {
            cbSourceProperty.Items.Clear();
            if (tlLink.FocusedObject == null)
                return;
            string sCamName = colSourceCam.GetValue(tlLink.FocusedObject).ToString();
            cGroupActions groupActions = sCamName == cStrings.This
                ? GlobVar.GroupActions
                : GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName)?.GroupActions;
            if (groupActions == null)
                return;
            ComboBox edit = (ComboBox)sender;
            string sToolName = edit.Text;
            colSourceTool.PutValue(tlLink.FocusedObject, sToolName);
            cAction sourceAction = groupActions.Actions.Values.FirstOrDefault(x => x.Name.rtcValue == sToolName);
            if (sourceAction == null)
                return;
            var listPropertyInfo = sourceAction.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(sourceAction, null)) != null &&
                ((RTCVariableType)x.GetValue(sourceAction, null)).rtcActive).ToList();
            foreach (var property in listPropertyInfo)
                cbSourceProperty.Items.Add(property.Name);
            if (sourceAction.MyExpression != null && sourceAction.MyExpression.Operands != null)
                foreach (SStringBuilderItem operand in sourceAction.MyExpression.Operands)
                    cbSourceProperty.Items.Add(operand.Name);
            if (sourceAction.DataItems != null)
                foreach (SStringBuilderItem item in sourceAction.DataItems)
                    cbSourceProperty.Items.Add(item.Name);
            tlLink.FinishCellEdit();

        }
        private void cbSourceProperty_SelectedIndexChanged (object sender, EventArgs e)
        {
            tlLink.FinishCellEdit();
        }
        private void tlLink_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column == colSourceCam)
            {
                ComboBox Combobox = (ComboBox)e.Control;
                e.NewValue = Combobox.SelectedItem;

            }
            if (e.Column == colSourceTool)
            {
                ComboBox Combobox = (ComboBox)e.Control;
                e.NewValue = Combobox.SelectedItem;

            }
            if (e.Column == colSourceName)
            {
                ComboBox Combobox = (ComboBox)e.Control;
               
                e.NewValue = Combobox.SelectedItem;

            }
        }

        private void tlLink_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            GetLinkItemValue();
        }

        private void tlLink_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            tlLink.FocusedObject = e.Model;
        }
    }
}
