using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.QualityTools.Testing.Fakes.FakesDelegates;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucPropertyLinkActionDetail : ucBaseActionDetail
    {
        public ucPropertyLinkActionDetail()
        {
            InitializeComponent();

        }
        private ComboBox cbCam = new ComboBox();
        private ComboBox cbCamera = new ComboBox();
        private ComboBox cbTargetCam = new ComboBox();
        private ComboBox cbTargetProperty = new ComboBox();
        private ComboBox cbSourceProperty = new ComboBox();
        private ComboBox cbSourceTool = new ComboBox();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Action == null)
                return;
            if (Action.LinkProperty == null)
                Action.LinkProperty = new List<cLinkProperty>();
            int orderNum = 0;
            if (Action.LinkProperty.Count > 0)
                orderNum = Action.LinkProperty[Action.LinkProperty.Count - 1].OrderNum + 1;
            else
                orderNum += 1;
            cLinkProperty linkItem = new cLinkProperty
            {
                OrderNum = orderNum,
                SourceCamID = Guid.Empty,
                SourceID = Guid.Empty,
                SourceName = string.Empty,
                SourceIndex = new List<object>(),
                TargetCamID = Action.MyGroup.MyCam.ID,
                TargetID = Action.ID,
                TargetName = string.Empty,
                TargetIndex = new List<object>(),
                DefaultValue = new List<object>()

            };
            linkItem.SourceIndex.Add(cStrings.None);
            linkItem.TargetIndex.Add(cStrings.None);
            Action.LinkProperty.Add(linkItem);
            AddLinkItemToTreeList(linkItem);
        }
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
                sourceGroup = linkItem.SourceCamID == Action.MyGroup.MyCam.ID ? GlobVar.GroupActions : sourceCam?.GroupActions;

                GlobVar.CurrentProject?.CAMs.TryGetValue(linkItem.TargetCamID, out targetCam);
                targetGroup = linkItem.TargetCamID == Action.MyGroup.MyCam.ID ? GlobVar.GroupActions : targetCam?.GroupActions;

                sourceGroup?.Actions.TryGetValue(linkItem.SourceID, out sourceAction);
                targetGroup?.Actions.TryGetValue(linkItem.TargetID, out targetAction);

                RTCVariableType targetValue = (RTCVariableType)targetAction?.GetType().GetProperties()
                    .FirstOrDefault(x => x.Name == linkItem.TargetName)?.GetValue(targetAction, null);
                PropertyLink newNode = new PropertyLink();
                newNode.OrderNumber = linkItem.OrderNum;
                newNode.SourceCam = sourceCam != null ? (sourceCam.Name == Action.MyGroup.MyCam.Name ? cStrings.This : sourceCam.Name) : string.Empty;
                newNode.SourceTool = sourceAction?.Name.rtcValue ?? string.Empty;
                newNode.SourceName = linkItem.SourceName;
                newNode.SourceIndex = GlobFuncs.ListObject2Str(linkItem.SourceIndex).ToString().Replace("[", "").Replace("]", "").Replace(@"""", "");
                newNode.TargetCam = targetCam != null ? (targetCam.Name == Action.MyGroup.MyCam.Name ? cStrings.This : targetCam.Name) : string.Empty;
                newNode.TargetTool = targetAction?.Name.rtcValue ?? string.Empty;
                newNode.TargetName = linkItem.TargetName;
                newNode.TargetIndex = GlobFuncs.ListObject2Str(linkItem.TargetIndex).ToString().Replace("[", "").Replace("]", "").Replace(@"""", "");
                tlLink.AddObject(newNode);
                // QUân sửa
                var firstObject = tlLink.Objects.Cast<PropertyLink>().FirstOrDefault();
                if (firstObject != null)
                    tlLink.FocusedObject = firstObject;
                tlLink.SelectedObject = firstObject;
                tlLink.Focus();
                return true;
            }
            finally
            {
                tlLink.ResumeLayout();
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            if (tlLink.FocusedObject == null || Action == null)
                return;
            List<PropertyLink> AllNodes = tlLink.Objects.Cast<PropertyLink>().ToList();
            int currentNodeIndex = tlLink.IndexOf(tlLink.FocusedObject);
            bool isMoveWhenAfterAdd = currentNodeIndex != AllNodes.Count - 1;
            int iOrderNum = ((PropertyLink)tlLink.FocusedObject).OrderNumber;
            cLinkProperty cloneProperty = Action.LinkProperty.Find(x => x.OrderNum == iOrderNum);
            if (cloneProperty == null)
                return;
            cLinkProperty newLink = cloneProperty.Clone();
            int newLinkOrder = 0;
            foreach (cLinkProperty linkProperty in Action.LinkProperty)
                if (newLinkOrder <= linkProperty.OrderNum)
                    newLinkOrder = linkProperty.OrderNum;
            newLinkOrder += 1;
            newLink.OrderNum = newLinkOrder;
            Action.LinkProperty.Add(newLink);
            AddLinkItemToTreeList(newLink);
            AllNodes = tlLink.Objects.Cast<PropertyLink>().ToList();
            if (isMoveWhenAfterAdd)
            {
                PropertyLink nodeMove = AllNodes[AllNodes.Count - 1];
                AllNodes.Remove(AllNodes[AllNodes.Count - 1]);
                AllNodes.Insert(currentNodeIndex + 1, nodeMove);
                tlLink.ClearObjects();
                foreach (PropertyLink Node in AllNodes)
                {
                    tlLink.AddObject(Node);
                }
                ReOrderNum();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Action == null) return;
            if (cMessageBox.Question_YesNo("Do you want clear all link item?") == DialogResult.No)
                return;
            Action.LinkProperty = new List<cLinkProperty>();
            LoadLinkProperty();
        }
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
                if (Action != null && Action.LinkProperty != null)
                {
                    var orderList = from linkItem in Action.LinkProperty
                                    orderby linkItem.OrderNum
                                    select linkItem;

                    foreach (cLinkProperty linkItem in orderList)

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
                        sourceGroup = linkItem.SourceCamID == Action.MyGroup.MyCam.ID ? GlobVar.GroupActions : sourceCam?.GroupActions;
                        GlobVar.CurrentProject?.CAMs.TryGetValue(linkItem.TargetCamID, out targetCam);
                        targetGroup = linkItem.TargetCamID == Action.MyGroup.MyCam.ID ? GlobVar.GroupActions : targetCam?.GroupActions;
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
                        PropertyLink newNode = new PropertyLink();
                        newNode.OrderNumber = linkItem.OrderNum;
                        newNode.SourceCam = sourceCam != null ? (sourceCam.Name == Action.MyGroup.MyCam.Name ? cStrings.This : sourceCam.Name) : string.Empty;
                        newNode.SourceTool = sourceAction?.Name.rtcValue ?? string.Empty;
                        newNode.SourceName = linkItem.SourceName;
                        newNode.SourceIndex = linkItem.SourceIndex[0].ToString().Replace("[", "").Replace("]", "").Replace(@"""", "");
                        newNode.TargetCam = targetCam != null ? (targetCam.Name == Action.MyGroup.MyCam.Name ? cStrings.This : targetCam.Name) : string.Empty;
                        newNode.TargetTool = targetAction?.Name.rtcValue ?? string.Empty;
                        newNode.TargetName = linkItem.TargetName;
                        newNode.TargetIndex = linkItem.TargetIndex.Count > 0 ? linkItem.TargetIndex[0].ToString().Replace("[", "").Replace("]", "").Replace(@"""", "") : "None";
                        tlLink.AddObject(newNode);
                    }

                    foreach (cLinkProperty linkProperty in listRemoves)
                        Action.LinkProperty.Remove(linkProperty);
                }
                List<PropertyLink> AllNodes = tlLink.Objects.Cast<PropertyLink>().ToList();
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
            cbCam.Items.Clear();
            if (GlobVar.CurrentProject == null)
                return;
            foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
            {
                if (Action.MyGroup.MyCam != null && cam.Name == Action.MyGroup.MyCam.Name)
                    cbCam.Items.Add(cStrings.This);
                else
                    cbCam.Items.Add(cam.Name);
            }

            cbTargetCam.Items.Clear();
            if (GlobVar.CurrentProject == null)
                return;
            foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
            {
                if (Action.MyGroup.MyCam != null && cam.Name == Action.MyGroup.MyCam.Name)
                    cbTargetCam.Items.Add(cStrings.This);
                else
                    cbTargetCam.Items.Add(cam.Name);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (tlLink.FocusedObject == null || Action == null)
                return;
            if (cMessageBox.Question_YesNo("Do you want delete link item?") == DialogResult.No)
                return;
            int iOrderNumber = ((PropertyLink)tlLink.FocusedObject).OrderNumber;
            Action.LinkProperty.Remove(Action.LinkProperty.Find(x => x.OrderNum == iOrderNumber));
            tlLink.RemoveObject(tlLink.FocusedObject);
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            Action.Run_LinkValue_Test();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                GlobVar.LockEvents = true;
                if (Action == null || Action.LinkProperty == null) return;
                PropertyLink FocusNode = (PropertyLink)tlLink.FocusedObject;
                if (FocusNode == null) return;
                int IndexNode = tlLink.IndexOf(FocusNode);
                List<PropertyLink> AllNodes = tlLink.Objects.Cast<PropertyLink>().ToList();
                if (IndexNode >= AllNodes.Count - 1)
                {
                    return;
                }
                PropertyLink nodeMove = AllNodes[IndexNode];
                AllNodes.Remove(AllNodes[IndexNode]);
                AllNodes.Insert(IndexNode + 1, nodeMove);
                tlLink.ClearObjects();
                //foreach (PropertyLink Node in AllNodes)
                //{
                //    tlLink.AddObject(Node);
                //}

                // QUân sửa
                foreach (PropertyLink Node in AllNodes)
                    tlLink.AddObject(Node);
                ReOrderNum();
                tlLink.FocusedObject = nodeMove;
                tlLink.SelectObject(nodeMove);
                tlLink.EnsureModelVisible(nodeMove);
                tlLink.Focus();


            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                GlobVar.LockEvents = true;
                if (Action == null || Action.LinkProperty == null) return;
                PropertyLink FocusNode = (PropertyLink)tlLink.FocusedObject;
                if (FocusNode == null) return;
                int IndexNode = tlLink.IndexOf(FocusNode);
                List<PropertyLink> AllNodes = tlLink.Objects.Cast<PropertyLink>().ToList();
                PropertyLink nodeMove = AllNodes[IndexNode];
                AllNodes.Remove(AllNodes[IndexNode]);
                AllNodes.Insert(IndexNode - 1, nodeMove);
                tlLink.ClearObjects();
                //foreach (PropertyLink Node in AllNodes)
                //{
                //    tlLink.AddObject(Node);
                //}

                // Quân sửa
                foreach (PropertyLink Node in AllNodes)
                    tlLink.AddObject(Node);
                ReOrderNum();
                tlLink.FocusedObject = nodeMove;
                tlLink.SelectObject(nodeMove);
                tlLink.EnsureModelVisible(nodeMove);
                tlLink.Focus(); ;


            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        private void ReOrderNum()
        {
            if (Action == null || Action.LinkProperty == null)
                return;
            List<PropertyLink> AllNode = tlLink.Objects.Cast<PropertyLink>().ToList();
            Dictionary<int, int> orderOldNew = new Dictionary<int, int>();
            for (int i = 0; i < AllNode.Count; i++)
            {
                PropertyLink node = AllNode[i];
                orderOldNew.Add(node.OrderNumber, i + 1);
                node.OrderNumber = i + 1;
                tlLink.RefreshObject(node);
            }

            foreach (cLinkProperty linkProperty in Action.LinkProperty)
                linkProperty.OrderNum = orderOldNew[linkProperty.OrderNum];
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
            else if (e.Column == colSourceTool)
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
            if (e.Column == colTargetCam)
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
            else if (e.Column == colTargetTool)
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
            else if (e.Column == colTargetName)
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
        private void LoadSourceToolToCombo()
        {
            if (tlLink.SelectedColumn == colSourceTool)
            {
                string sCamName = ((PropertyLink)tlLink.FocusedObject).SourceCam;
                cGroupActions groupActions = sCamName == cStrings.This
             ? GlobVar.GroupActions
             : GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName)?.GroupActions;
                if (groupActions == null)
                    return;
                var orderActions = groupActions.Actions.Values.OrderBy(x => x.STT).ToList();
                foreach (cAction action in orderActions)
                    cbSourceTool.Items.Add(action.Name.rtcValue);
            }
            else if (tlLink.SelectedColumn == colTargetTool)
            {
                string sCamName = ((PropertyLink)tlLink.FocusedObject).TargetCam;
                cGroupActions groupActions = sCamName == cStrings.This
             ? GlobVar.GroupActions
             : GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName)?.GroupActions;
                if (groupActions == null)
                    return;
                var orderActions = groupActions.Actions.Values.OrderBy(x => x.STT).ToList();
                foreach (cAction action in orderActions)
                    cbSourceTool.Items.Add(action.Name.rtcValue);
            }

        }
        private void LoadSourcePropertyToCom()
        {
            if (tlLink.SelectedColumn == colSourceName)
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
            else if (tlLink.SelectedColumn == colTargetName)
            {
                string sCamName = colTargetCam.GetValue(tlLink.FocusedObject)?.ToString();
                cGroupActions groupActions = sCamName == cStrings.This
                    ? GlobVar.GroupActions
                    : GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName)?.GroupActions;
                if (groupActions == null)
                    return;
                string sToolName = colTargetTool.GetValue(tlLink.FocusedObject).ToString();
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
        }
        private void cbCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSourceTool.Items.Clear();
            cbSourceProperty.Items.Clear();
            if (tlLink.FocusedObject == null)
                return;
            ComboBox edit = (ComboBox)sender;
            string sCamName = edit.Text;
            if (tlLink.SelectedColumn == colSourceCam)
            {
                colSourceCam.PutValue(tlLink.FocusedObject, sCamName);

            }
            else if (tlLink.SelectedColumn == colTargetCam)
            {
                colTargetCam.PutValue(tlLink.FocusedObject, sCamName);

            }

            tlLink.FinishCellEdit();
        }
        private void cbSourceTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSourceProperty.Items.Clear();
            if (tlLink.FocusedObject == null)
                return;
            cGroupActions groupActions;
            string sCamName;
            ComboBox edit = (ComboBox)sender;
            string sToolName = edit.Text;
            if (tlLink.SelectedColumn == colSourceTool)
            {
                sCamName = colSourceCam.GetValue(tlLink.FocusedObject).ToString();
                groupActions = sCamName == cStrings.This
                   ? GlobVar.GroupActions
                   : GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName)?.GroupActions;
                if (groupActions == null)
                    return;
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
            else if (tlLink.SelectedColumn == colTargetTool)
            {
                sCamName = colTargetCam.GetValue(tlLink.FocusedObject).ToString();
                groupActions = sCamName == cStrings.This
                   ? GlobVar.GroupActions
                   : GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName)?.GroupActions;
                if (groupActions == null)
                    return;
                colTargetTool.PutValue(tlLink.FocusedObject, sToolName);
                cAction targetAction = groupActions.Actions.Values.FirstOrDefault(x => x.Name.rtcValue == sToolName);
                if (targetAction == null)
                    return;
                var listPropertyInfo = targetAction.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(targetAction, null)) != null &&
                    ((RTCVariableType)x.GetValue(targetAction, null)).rtcActive).ToList();
                foreach (var property in listPropertyInfo)
                    cbSourceProperty.Items.Add(property.Name);
                if (targetAction.MyExpression != null && targetAction.MyExpression.Operands != null)
                    foreach (SStringBuilderItem operand in targetAction.MyExpression.Operands)
                        cbSourceProperty.Items.Add(operand.Name);
                if (targetAction.DataItems != null)
                    foreach (SStringBuilderItem item in targetAction.DataItems)
                        cbSourceProperty.Items.Add(item.Name);
                tlLink.FinishCellEdit();
            }
        }
        private void cbSourceProperty_SelectedIndexChanged(object sender, EventArgs e)
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
            else if (e.Column == colSourceTool)
            {
                ComboBox Combobox = (ComboBox)e.Control;
                e.NewValue = Combobox.SelectedItem;

            }
            else if (e.Column == colSourceName)
            {
                ComboBox Combobox = (ComboBox)e.Control;
                e.NewValue = Combobox.SelectedItem;

            }
            else if (e.Column == colTargetCam)
            {
                ComboBox Combobox = (ComboBox)e.Control;
                e.NewValue = Combobox.SelectedItem;

            }
            else if (e.Column == colTargetTool)
            {
                ComboBox Combobox = (ComboBox)e.Control;
                e.NewValue = Combobox.SelectedItem;

            }
            else if (e.Column == colTargetName)
            {
                ComboBox Combobox = (ComboBox)e.Control;
                e.NewValue = Combobox.SelectedItem;

            }
        }

        private void tlLink_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            tlLink.SelectedColumn = e.Column;
        }

        private void tlLink_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            GetLinkItemValue();
        }
        private void GetLinkItemValue()
        {
            if (tlLink.FocusedObject == null)
                return;
            if (!int.TryParse(colOrderNumber.GetValue(tlLink.FocusedObject).ToString(), out int orderNum))
                return;
            cLinkProperty linkItem = Action.LinkProperty?.FirstOrDefault(x => x.OrderNum == orderNum);

            if (linkItem == null)
                return;
            PropertyLink SelectedNode = ((PropertyLink)tlLink.FocusedObject);
            string sCamName = SelectedNode.SourceCam;
            cCAMTypes sourceCam = (sCamName == cStrings.This) ? Action.MyGroup.MyCam :
                GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName);
            sCamName = SelectedNode.TargetCam;
            cCAMTypes TargetCam = (sCamName == cStrings.This) ? Action.MyGroup.MyCam :
            GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == sCamName);
            linkItem.SourceCamID = sourceCam?.ID ?? Guid.Empty;
            linkItem.TargetCamID = TargetCam?.ID ?? Guid.Empty;


            string sToolName = SelectedNode.SourceTool;

            cGroupActions sourceGroup = linkItem.SourceCamID == Action.MyGroup.MyCam.ID ? GlobVar.GroupActions : sourceCam?.GroupActions;
            cGroupActions targetGroup = linkItem.SourceCamID == Action.MyGroup.MyCam.ID ? GlobVar.GroupActions : TargetCam?.GroupActions;

            cAction sourceAction = sourceGroup?.Actions.Values.FirstOrDefault(x => x.Name.rtcValue == sToolName);
            sToolName = SelectedNode.TargetTool;
            cAction targetAction = targetGroup?.Actions.Values.FirstOrDefault(x => x.Name.rtcValue == sToolName);

            linkItem.SourceID = sourceAction?.ID ?? Guid.Empty;
            linkItem.TargetID = targetAction?.ID ?? Guid.Empty;
            linkItem.SourceName = SelectedNode.SourceName;
            linkItem.TargetName = SelectedNode.TargetName;
            linkItem.SourceIndex = GlobFuncs.Str2StringObj(SelectedNode.SourceIndex, cDelimiterValues.Comma);
            linkItem.TargetIndex = GlobFuncs.Str2StringObj(SelectedNode.TargetIndex, cDelimiterValues.Comma);
        }
    }
}
