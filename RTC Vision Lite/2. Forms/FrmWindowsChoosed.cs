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
    public partial class frmWindowChoosed : FrmBase
    {
      
        public frmWindowChoosed()
        {
            InitializeComponent();
            ListCamChoosed = null; 
            
        }
        public List<Guid> ListCamChoosed { get; set; }
        public List<string> ListCamNameChoosed { get; set; }
        private class WindowChoosed
        {
            public Guid ID { get; set; }
            public bool Select { get; set; }
            public string Name { get; set; }
            public int ActionType { get; set; }
            public List<WindowChoosed> child = new List<WindowChoosed>();
        }


        #region FUNCTIONS
        private void PreviewData()
        {
            try
            {
                GlobVar.LockEvents = true;
                tlChoosedCams.ClearObjects();
                if (GlobVar.CurrentProject == null)
                    return;
                var cams = GlobVar.CurrentProject.CAMs.Values.OrderBy(x => x.STT).ToList();
                if (!cams.Any())
                    return;
                foreach(var cam in cams)
                {
                    bool choosed = false;
                    if (ListCamChoosed != null && ListCamChoosed.Contains(cam.ID))
                        choosed = true;
                    tlChoosedCams.ExpandAll();
                }    
            }    
            finally
            {
                GlobVar.LockEvents = false;
                SetCheckSelectTrueFalse();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ListCamChoosed = new List<Guid>();
            ListCamNameChoosed = new List<string>();
            
            foreach(WindowChoosed node in tlChoosedCams.Roots.Cast<WindowChoosed>().ToList())
                if (node.Select != null && node.Select)
                {
                    ListCamChoosed.Add(node.ID);
                    ListCamNameChoosed.Add(node.Name);
                }    
            DialogResult = DialogResult.OK;
        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            GlobVar.LockEvents = true;
            SelectAll(tlChoosedCams.Objects.Cast<WindowChoosed>().ToList(), chkSelectAll.Checked);
            GlobVar.LockEvents = false;
        }


        #endregion
        
       
       
        private void SelectAll(List<WindowChoosed> nodes, bool select)
        {
            if (nodes?.Count <= 0)
                return;

            foreach (WindowChoosed node in nodes)
                if (node.Select != null)
                {
                    node.Select = select;
                    if (node.child?.Count > 0)
                        SelectAll(node.child, select);
                    tlChoosedCams.RefreshObject(node);
                }
        }

        private void tlChoosedActions_SubItemChecking(object sender, BrightIdeasSoftware.SubItemCheckingEventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            if (tlChoosedCams.SelectedColumn == null)
                return;
            if (tlChoosedCams.SelectedColumn == colSelect)
            {
                SetCheckSelectTrueFalse(true);
            }
        }
        private void SetCheckSelectTrueFalse(bool setFocusedNodeValue = false)
        {
            GlobVar.LockEvents = true;
            if (setFocusedNodeValue && tlChoosedCams.SelectedObject != null)
                colSelect.PutValue(tlChoosedCams.SelectedObject, !(bool)colSelect.GetValue(tlChoosedCams.SelectedObject));

            foreach (WindowChoosed node in tlChoosedCams.Objects)
                if (node.Select != null)
                    if (!node.Select)
                    {
                        chkSelectAll.Checked = false;
                        GlobVar.LockEvents = false;
                        return;
                    }

            chkSelectAll.Checked = true;
            GlobVar.LockEvents = false;
        }
        
        private void FrmActionsChoose_Load(object sender, EventArgs e)
        {
            try
            {
                //GlobVar.LockEvents = true;
                //LoadProjectListToCombo();

                ////radSource.SelectedIndex = OldMode;
                //if (OldMode == 0 && cbCamName.Items.IndexOf(OldFileName) >= 0)
                //    cbCamName.Text = OldFileName;
                //if (OldMode == 1)
                //    txtFileName.Text = OldFileName;
                //chkSelectAll.Checked = OldSelect;
                //cbCamName.Enabled = OldMode == 0;
                //txtFileName.Enabled = !cbCamName.Enabled;

                //LoadProject();
                //PreviewData();
                //FrmActionsChoose_Load_LoadOldCheck(tlChoosedActions.Objects.Cast<ActionsChoose>().ToList());
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        
       

       

       
        private void txtFileName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter && _currentFileName != txtFileName.Text)
            //{
            //    LoadProject();
            //    PreviewData();
            //}
        }

       

        private void tlChoosedActions_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if(e.Column == colSelect)
            {
                bool Checked = ((WindowChoosed)e.Model).Select;
                colSelect.PutCheckState(e.Model, Checked ? CheckState.Unchecked : CheckState.Checked);
            }    
        }

        private void tlChoosedActions_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            //if (e.Column == colName)
            //{
            //    e.SubItem.ImageSelector = GlobVar.imlActionType16.Images[Lib.ToInt(((ActionsChoose)(e.Model)).ActionType)];
            //}
            //if (e.Column == colSelect)
            //{
            //    e.SubItem.Text = "";
            //    Guid actionId = GlobFuncs.Object2Guid(colID.GetValue(e.Model), Guid.Empty);
            //    if (actionId == Guid.Empty || _groupActions.Actions[actionId].ActionType == EActionTypes.BranchItem)
            //    {
                   
            //        ImageDecoration image = new ImageDecoration(blank, 255);
            //        e.SubItem.ImageSelector = blank;
            //    }
              
            //}
        }


        //private void GetSelectedNodes(List<ActionsChoose> nodes)
        //{
        //    if (nodes?.Count <= 0)
        //        return;

        //    foreach (ActionsChoose node in nodes)
        //    {
        //        if (node.Select != null && node.Select )
        //        {
        //            Guid actionId = GlobFuncs.Object2Guid(node.ID, Guid.Empty);
        //            if (actionId != Guid.Empty && !ListToolIdChoose.Contains(actionId))
        //            {
        //                ListToolIdChoose.Add(actionId);
        //                var childTools = _groupActions.Actions.Values.Where(x => x.IDBranch == actionId).ToList();
        //                foreach (cAction childTool in childTools)
        //                    if (!ListToolIdChoose.Contains(childTool.ID))
        //                        ListToolIdChoose.Add(childTool.ID);
        //            }
        //        }
        //        GetSelectedNodes(node.child);
        //    }
        //}
    }
}
