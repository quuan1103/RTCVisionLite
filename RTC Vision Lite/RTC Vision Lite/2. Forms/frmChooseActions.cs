using BrightIdeasSoftware;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmActionsChoose : FrmBase
    {
      
        public FrmActionsChoose()
        {
            InitializeComponent();

            ListToolIdChoose = null;
            OldMode = 0;
            OldFileName = string.Empty;
            OldSelect = true;
            OldMainActionID = Guid.Empty;
            tlChoosedActions.TreeColumnRenderer.IsShowLines = false;

            tlChoosedActions.SmallImageList = GlobVar.imlActionType16;
            blank = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(blank))
            {
                // Đặt màu nền (tùy chọn)
                g.Clear(Color.White);

                // Lưu ảnh dưới dạng file PNG

            }
        }
        private class ActionsChoose
        {
            public Guid ID { get; set; }
            public bool Select { get; set; }
            public string Name { get; set; }
            public int ActionType { get; set; }
            public List<ActionsChoose> child = new List<ActionsChoose>();
        }
        private string _currentFileName = string.Empty;
        private cGroupActions _groupActions;
        private Bitmap blank = null;
        public cGroupActions GroupActions
        {
            get => _groupActions;
            set => _groupActions = value;
        }

        public List<Guid> ListToolIdChoose { get; set; }
        public string OldFileName { get; set; }
        public int OldMode { get; set; }
        public bool OldSelect { get; set; }
        public Guid OldMainActionID { get; set; }
        private void PreviewData_Actions(cAction action, List<Guid> idViewed, ActionsChoose parentNode)
        {
            tlChoosedActions.BeginUpdate();
            try
            {
                if (action.ActionType == EActionTypes.MainAction)
                    return;
                if (idViewed.Contains(action.ID))
                    return;
                idViewed.Add(action.ID);
                //parentNode = tlChoosedActions.AppendNode(new object[] { action.ID, false, action.Name.rtcValue }, parentNode);
                ActionsChoose Child = new ActionsChoose();
                Child.ID = action.ID;
                Child.Select = false;
                Child.Name = action.Name.rtcValue;
                Child.ActionType = Lib.ToInt(action.ActionType);

                if (parentNode != null)
                {
                    parentNode.child.Add(Child);
                    tlChoosedActions.RefreshObject(parentNode);
                    tlChoosedActions.Refresh();
                }
                else
                {
                    tlChoosedActions.AddObject(Child);
                }
                if (action.ActionType == EActionTypes.BranchItem)
                {
                    var childActions = _groupActions.Actions.Values.Where(x => x.IDBranchItem == action.ID).OrderBy(x => x.STT)
                        .ToList();
                    if (childActions.Any())
                        foreach (cAction childAction in childActions)
                            PreviewData_Actions(childAction, idViewed, Child);
                }
                else
                {
                    var childActions = _groupActions.Actions.Values.Where(x => x.IDBranch == action.ID).OrderBy(x => x.STT)
                        .ToList();
                    if (childActions.Any())
                        foreach (cAction childAction in childActions)
                            PreviewData_Actions(childAction, idViewed, Child);
                }
            }
            catch(Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                tlChoosedActions.EndUpdate();
            }
          
            
        }
        private void PreviewData()
        {
            try
            {
                GlobVar.LockEvents = true;
                tlChoosedActions.ClearObjects();
                if (_groupActions == null)
                    return;

                var orderListActions = _groupActions.Actions.Values.OrderBy(x => x.STT).ToList();
                List<Guid> idViewed = new List<Guid>();

                foreach (cAction action in orderListActions)
                    if (action.ActionType != EActionTypes.MainAction)
                    {
                        if (idViewed.Contains(action.ID))
                            continue;
                        PreviewData_Actions(action, idViewed, null);
                    }
            }
            finally
            {
                tlChoosedActions.CanExpandGetter = x => (x as ActionsChoose).child.Count > 0;
                tlChoosedActions.ChildrenGetter = x => (x as ActionsChoose).child;
                tlChoosedActions.ExpandAll();
                GlobVar.LockEvents = false;
                chkSelectAll.Checked = true;
                chkSelectAll_CheckedChanged(null, null);
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            GlobVar.LockEvents = true;
            SelectAll(tlChoosedActions.Objects.Cast<ActionsChoose>().ToList(), chkSelectAll.Checked);
            GlobVar.LockEvents = false;
        }
        private void SelectAll(List<ActionsChoose> nodes, bool select)
        {
            if (nodes?.Count <= 0)
                return;

            foreach (ActionsChoose node in nodes)
                if (node.Select != null)
                {
                    node.Select = select;
                    if (node.child?.Count > 0)
                        SelectAll(node.child, select);
                    tlChoosedActions.RefreshObject(node);
                }
        }

        private void tlChoosedActions_SubItemChecking(object sender, BrightIdeasSoftware.SubItemCheckingEventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            if (tlChoosedActions.SelectedColumn == null)
                return;
            if (tlChoosedActions.SelectedColumn == colSelect)
            {
                Guid actionId = GlobFuncs.Object2Guid(colID.GetValue(tlChoosedActions.SelectedObject), Guid.Empty);
                bool select = GlobFuncs.Object2Bool(colSelect.GetValue(tlChoosedActions.SelectedObject));
                colSelect.PutValue(tlChoosedActions.FocusedObject, !select);
                if (actionId != Guid.Empty &&
                    (_groupActions.Actions[actionId].ActionType == EActionTypes.Branch ||
                     _groupActions.Actions[actionId].ActionType == EActionTypes.Switch ||
                     _groupActions.Actions[actionId].ActionType == EActionTypes.CounterLoop ||
                     _groupActions.Actions[actionId].ActionType == EActionTypes.PassFail))
                    SelectAll(((ActionsChoose)(tlChoosedActions.FocusedObject)).child, !select);

                SetCheckSelectTrueFalse();
            }
        }
        private void SetCheckSelectTrueFalse(bool setFocusedNodeValue = false)
        {
            GlobVar.LockEvents = true;
            if (setFocusedNodeValue && tlChoosedActions.SelectedObject != null)
                colSelect.PutValue(tlChoosedActions.SelectedObject, !(bool)colSelect.GetValue(tlChoosedActions.SelectedObject));

            foreach (ActionsChoose node in tlChoosedActions.Objects)
                if (node.Select != null)
                    if (!(bool)node.Select)
                    {
                        chkSelectAll.Checked = false;
                        GlobVar.LockEvents = false;
                        return;
                    }

            chkSelectAll.Checked = true;
            GlobVar.LockEvents = false;
        }
        private void FrmActionsChoose_Load_LoadOldCheck(List<ActionsChoose> nodes)
        {
            if (nodes?.Count > 0 && ListToolIdChoose?.Count > 0)
                foreach (ActionsChoose node in nodes)
                {
                    Guid actionId = GlobFuncs.Object2Guid(node.ID, Guid.Empty);
                    if (ListToolIdChoose.Contains(actionId))
                        node.Select =  true;
                    else
                    {
                        node.Select = false;
                        chkSelectAll.Checked = false;
                    }

                    FrmActionsChoose_Load_LoadOldCheck(node.child);
                }
        }

        private void FrmActionsChoose_Load(object sender, EventArgs e)
        {
            try
            {
                GlobVar.LockEvents = true;
                LoadProjectListToCombo();

                //radSource.SelectedIndex = OldMode;
                if (OldMode == 0 && cbCamName.Items.IndexOf(OldFileName) >= 0)
                    cbCamName.Text = OldFileName;
                if (OldMode == 1)
                    txtFileName.Text = OldFileName;
                chkSelectAll.Checked = OldSelect;
                cbCamName.Enabled = OldMode == 0;
                txtFileName.Enabled = !cbCamName.Enabled;

                LoadProject();
                PreviewData();
                FrmActionsChoose_Load_LoadOldCheck(tlChoosedActions.Objects.Cast<ActionsChoose>().ToList());
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        private void LoadProjectListToCombo()
        {
            cbCamName.Items.Clear();
            if (GlobVar.CurrentProject != null)
                foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                    cbCamName.Items.Add(cam.Name);
            if (cbCamName.Items.Count > 0)
                cbCamName.SelectedIndex = 0;
        }
        private void LoadProject()
        {
            _groupActions = null;
            _currentFileName = string.Empty;
            switch (rdCurrentProject.Checked)
            {
                case true:
                    {
                        if (cbCamName.SelectedIndex < 0)
                            return;
                        cCAMTypes cam =
                            GlobVar.CurrentProject?.CAMs.Values.FirstOrDefault(x => x.Name == cbCamName.Text);
                        if (cam == null)
                            return;

                        GroupActionsData groupActionsData = new GroupActionsData();
                        try
                        {
                            if (!groupActionsData.Connect(cam.GroupActions.FileName))
                                return;
                            _groupActions = new cGroupActions(cStrings.GroupCAM, null)
                            {
                                FileName = groupActionsData.DataFileName,
                                //FileNameIconic = Path.ChangeExtension(groupActionsData.DataFileName, cExtFile.GroupIconic)
                            };

                            groupActionsData.OpenActionList(_groupActions);
                            _groupActions.IDMainAction = _groupActions.Actions.Values
                                .FirstOrDefault(x => x.ActionType == EActionTypes.MainAction).ID;
                            OldMainActionID = _groupActions.IDMainAction;
                            _currentFileName = groupActionsData.DataFileName;
                        }
                        finally
                        {
                            groupActionsData.Disconnect();
                            groupActionsData = null;
                        }
                        break;
                    }

                case false:
                    {
                        if (!File.Exists(txtFileName.Text))
                            return;

                        GroupActionsData groupActionsData = new GroupActionsData();
                        try
                        {
                            if (!groupActionsData.Connect(txtFileName.Text))
                                return;
                            _groupActions = new cGroupActions(cStrings.GroupCAM, null)
                            {
                                FileName = groupActionsData.DataFileName,
                                //FileNameIconic = Path.ChangeExtension(groupActionsData.DataFileName, cExtFile.GroupIconic)
                            };
                            groupActionsData.OpenActionList(_groupActions);
                            _groupActions.IDMainAction = _groupActions.Actions.Values
                                .FirstOrDefault(x => x.ActionType == EActionTypes.MainAction).ID;
                            OldMainActionID = _groupActions.IDMainAction;
                            _currentFileName = groupActionsData.DataFileName;
                        }
                        finally
                        {
                            groupActionsData.Disconnect();
                            groupActionsData = null;
                        }
                        break;
                    }
            }
        }

        private void cbCamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            LoadProject();
            PreviewData();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = cStrings.SelectProjectFile;
            openFileDialog.Filter = cStrings.GroupFilter;
            openFileDialog.InitialDirectory = GlobVar.RTCVision.Paths.Projects;
            if (openFileDialog.ShowDialog() == DialogResult.OK && _currentFileName != openFileDialog.FileName)
            {
                txtFileName.Text = openFileDialog.FileName;
                LoadProject();
                PreviewData();
            }
        }

        private void txtFileName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && _currentFileName != txtFileName.Text)
            {
                LoadProject();
                PreviewData();
            }
        }

        private void rdCurrentProject_CheckedChanged(object sender, EventArgs e)
        {

            if (GlobVar.LockEvents)
                return;
            cbCamName.Enabled = rdCurrentProject.Checked;
            txtFileName.Enabled = !cbCamName.Enabled;

            LoadProject();
            PreviewData();

        }

        private void tlChoosedActions_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if(e.Column == colSelect)
            {
                bool Checked = ((ActionsChoose)e.Model).Select;
                colSelect.PutCheckState(e.Model, Checked ? CheckState.Unchecked : CheckState.Checked);
            }    
        }

        private void tlChoosedActions_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            //if (e.Column == colName)
            //{
            //    e.SubItem.ImageSelector = GlobVar.imlActionType16.Images[Lib.ToInt(((ActionsChoose)(e.Model)).ActionType)];
            //}
            if (e.Column == colSelect)
            {
                e.SubItem.Text = "";
                Guid actionId = GlobFuncs.Object2Guid(colID.GetValue(e.Model), Guid.Empty);
                if (actionId == Guid.Empty || _groupActions.Actions[actionId].ActionType == EActionTypes.BranchItem)
                {
                   
                    ImageDecoration image = new ImageDecoration(blank, 255);
                    e.SubItem.ImageSelector = blank;
                }
              
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ListToolIdChoose = new List<Guid>();
            GetSelectedNodes(tlChoosedActions.Roots.Cast<ActionsChoose>().ToList());

            OldMode = rdCurrentProject.Checked ? 0 : 1;
            OldFileName = OldMode == 0 ? cbCamName.Text : txtFileName.Text;
            OldSelect = chkSelectAll.Checked;

            DialogResult = DialogResult.OK;
        }
        private void GetSelectedNodes(List<ActionsChoose> nodes)
        {
            if (nodes?.Count <= 0)
                return;

            foreach (ActionsChoose node in nodes)
            {
                if (node.Select != null && node.Select )
                {
                    Guid actionId = GlobFuncs.Object2Guid(node.ID, Guid.Empty);
                    if (actionId != Guid.Empty && !ListToolIdChoose.Contains(actionId))
                    {
                        ListToolIdChoose.Add(actionId);
                        var childTools = _groupActions.Actions.Values.Where(x => x.IDBranch == actionId).ToList();
                        foreach (cAction childTool in childTools)
                            if (!ListToolIdChoose.Contains(childTool.ID))
                                ListToolIdChoose.Add(childTool.ID);
                    }
                }
                GetSelectedNodes(node.child);
            }
        }

        private void tlChoosedActions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }
    }
}
