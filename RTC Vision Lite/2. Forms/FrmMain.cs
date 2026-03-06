using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Classes.ProjectFunctions;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTC_Vision_Lite.UserManager.Classes;
using RTCConst;
using RTCEnums;
using RTCSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmMain : FrmBase
    {
        public List<TableLayoutPanel> ListTableLayoutPanel;

        public List<ucCAM> listCam;

        public List<ucCAM> ListCam
        {
            get => listCam;
            set => listCam = value;
        }

        public List<ucCAM> listExtraCam;

        public List<ucCAM> ListExtraCam
        {
            get => listExtraCam;
            set => listExtraCam = value;
        }

        public List<ucGroupCAMs> listGroupCam;

        public List<ucGroupCAMs> ListGroupCam
        {
            get => listGroupCam;
            set => listGroupCam = value;
        }
        public FrmMain()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        #region VARIABLES
        private int OldRowCAM = -1;
        private int OldColCAM = -1;
        private Thread _threadRealTime = null;
        private Thread _threadCleanImageByTask = null;
        private Label _labelNoModelData = null;
        #endregion

        public void RunOnlyFrmAction()
        {
            GlobVar.imlActionType32 = imlActionType;
            GlobVar.imlActionType24 = imlActionType24;
            GlobVar.imlActionType16 = imlActionType16;
        }
        private void mnuNew_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProject f = new FrmProject();
                f.IsAdd = true;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    GlobVar.CurrentProject = f.Project;

                    if (cProjectFunctions.SaveProject(GlobVar.CurrentProject, Guid.Empty))
                    {
                        cbProjects1.Items.Add(GlobVar.CurrentProject.ProjectName);
                        cbProjects.Items.Add(GlobVar.CurrentProject.ProjectName);

                        GlobVar.DicProjects.Add(GlobVar.CurrentProject.ID, GlobVar.CurrentProject);
                        GlobVar.LockEvents = true;
                        GlobVar.DataTableProjects.Rows.Add(new object[]
                        {
                            GlobVar.CurrentProject.ID, GlobVar.CurrentProject.OrderNum,
                            GlobVar.CurrentProject.ProjectName, GlobVar.CurrentProject.Note, string.Empty, null, GlobVar.CurrentProject.Pinned
                        });
                        //cbProjects1.Items.Add(GlobVar.CurrentProject.ProjectName);
                        cbProjects1.SelectedItem = GlobVar.CurrentProject.ProjectName;

                        ShowProjectCAMToLayoutControl();

                        EnableOrDisableControls();
                    }
                }
                else
                {
                    //ShowProjectCAMToLayoutControl();
                    GetCurrentProject();
                }
            }
            finally
            {
                GetCurrentProject();
                ShowProjectCAMToLayoutControl();
                GlobVar.LockEvents = false;
            }
        }
        internal void ShowLogo()
        {
            this.picLogo?.Invoke(new Action(() =>
            {
                this.picLogo.Visible = GlobVar.RTCVision.ViewOptions.IsShowLogo;
                if (File.Exists(GlobVar.RTCVision.ViewOptions.LogoFileName))
                {
                    this.picLogo.Image = Image.FromFile(GlobVar.RTCVision.ViewOptions.LogoFileName);
                }
            }));
        }
        internal void LockOrUnlockControls()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LockOrUnlockControls));
            else
            {
                bool isStillCamRunning = cProjectFunctions.IsStillCamRunning(GlobVar.CurrentProject);
                cbProjects1.Enabled = !isStillCamRunning;
                mnuNew.Enabled = !isStillCamRunning;
                mnuNew1.Enabled = !isStillCamRunning;
                mnuSave.Enabled = !isStillCamRunning;
                mnuSave1.Enabled = !isStillCamRunning;
                mnuSaveAs.Enabled = !isStillCamRunning;
                mnuSaveAs1.Enabled = !isStillCamRunning;
                mnuProjectSetting.Enabled = !isStillCamRunning;
                mnuProjectSetting1.Enabled = !isStillCamRunning;
                mnuDelete.Enabled = !isStillCamRunning;
                mnuDelete1.Enabled = !isStillCamRunning;
                mnuModelTemplates.Enabled = !isStillCamRunning;
                mnuRetypeOrderNumber.Enabled = !isStillCamRunning;
                mnuRefeshProjectList.Enabled = !isStillCamRunning;
                if (cProjectFunctions.IsAllCamRunning(GlobVar.CurrentProject))
                {
                    mnuRun.Visible = false;
                    mnuStop.Visible = true;
                }
                else
                {
                    mnuRun.Visible = true;
                    mnuStop.Visible = false;
                }
                if (GlobVar.CurrentProject != null)
                    foreach (cCAMTypes _CAM in GlobVar.CurrentProject.CAMs.Values)
                        if (_CAM.View != null && _CAM.IsActive && !_CAM.IsHide && _CAM.IsMaster)
                            GlobFuncs.EnableControl(_CAM.View.btnSetting, !_CAM.GroupActions.IsRun);
            }
        }

        private void LayoutCAMWhenResize()
        {
            try
            {
                if (LayoutCAM.Height == 0 || Width == 0) return;
                GlobFuncs.BeginControlUpdate(this);
                if (LayoutCAM.RowCount == 0) return;
                int heightCAM = (int)((LayoutCAM.Height - LayoutCAM.RowCount * 6) / LayoutCAM.RowCount);
                if (heightCAM <= 0 || LayoutCAM.RowStyles.Count <= 0)
                    return;
                for (int i = 0; i < LayoutCAM.RowCount; i++)
                    LayoutCAM.RowStyles[i].Height = heightCAM;

                int widthCam = (int)((Width - LayoutCAM.ColumnCount * 10) / LayoutCAM.ColumnCount);
                if (widthCam > 0)
                {
                    for (int i = 0; i < LayoutCAM.ColumnCount; i++)
                    {
                        LayoutCAM.ColumnStyles[i].Width = widthCam;
                    }
                }
            }
            finally
            {
                GlobFuncs.EndControlUpdate(this);
            }
        }
        private void ShowProjectCAMToLayoutControl_Normal()
        {
            Guid _GroupID = Guid.Empty;

            int count = 0;
            int rowcount = 0;
            int columncount = 0;

            int _UserControlNumbers = GlobVar.CurrentProject.CAMs.Values.Count(x => x.IsActive && !x.IsHide && !x.IsAlignMasterCam() && !x.IsChangeJobMasterCam());
            if (_UserControlNumbers <= 0)
            {
                return;
            }
            else
            {

            }
            rowcount = _UserControlNumbers / GlobVar.RTCVision.Options.MaximumColumnCAM;
            if (_UserControlNumbers % GlobVar.RTCVision.Options.MaximumColumnCAM != 0) rowcount += 1;
            LayoutCAM.RowCount = rowcount;
            int heightCAM = (int)((LayoutCAM.Height - rowcount * 6) / rowcount);
            for (int i = 0; i < rowcount; i++)
                LayoutCAM.RowStyles.Add(new RowStyle(SizeType.Absolute, heightCAM));

            var orderCAMs = GlobVar.CurrentProject.CAMs.Values.Where(x => x.IsActive && !x.IsHide && !x.IsAlignMasterCam() && !x.IsChangeJobMasterCam()).OrderBy(x => x.STT).ToList();

            for (int i = 0; i < orderCAMs.Count(); i++)
            {
                ((cCAMTypes)orderCAMs[i]).BuildCaptionView();
                count += 1;
                if (count > GlobVar.RTCVision.Options.MaximumColumnCAM) count = 0;
                if (count > columncount)
                    columncount += 1;
            }
            LayoutCAM.ColumnCount = columncount;
            int widthCam = (int)((Width - columncount * 10 - 100) / columncount);
            for (int i = 0; i < columncount; i++)
                LayoutCAM.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, widthCam));

            for (int i = 0; i < orderCAMs.Count(); i++)
            {
                ucCAM cam = orderCAMs[i].View;
                cam.OnMaximizeButtonClickEvent -= OnMaximizeButtonClickEvent;
                cam.OnMaximizeButtonClickEvent += OnMaximizeButtonClickEvent;
                cam.OnMinimizeButtonClickEvent -= OnMinimizeButtonClickEvent;
                cam.OnMinimizeButtonClickEvent += OnMinimizeButtonClickEvent;
                cam.OnSetupToolsButtonClickEvent -= OnSetupToolsButtonClickEvent;
                cam.OnSetupToolsButtonClickEvent += OnSetupToolsButtonClickEvent;
                ListCam.Add(cam);
                cam.Dock = DockStyle.Fill;
                LayoutCAM.Controls.Add(cam);
                cam.RebuildWindow();
            }
        }

        private void ShowProjectCAMToLayoutControl_SimpleCAM()
        {
            Guid groupId = Guid.Empty;

            int count = 0;
            int rowCount = 0;
            int columnCount = 0;

            int userControlNumbers = GlobVar.CurrentProject.CAMs.Values.Count(x => x.IsActive && !x.IsHide && !x.IsAlignMasterCam() && !x.IsChangeJobMasterCam() && x.GroupID == Guid.Empty);

            if (userControlNumbers <= 0)
            {
                return;
            }
            else
            {
            }

            rowCount = userControlNumbers / GlobVar.RTCVision.Options.MaximumColumnCAM;

            if (userControlNumbers % GlobVar.RTCVision.Options.MaximumColumnCAM != 0) rowCount += 1;
            LayoutCAM.RowCount = rowCount;
            int heightCAM = (int)((LayoutCAM.Height - rowCount * 6) / rowCount);
            for (int i = 0; i < rowCount; i++)
                LayoutCAM.RowStyles.Add(new RowStyle(SizeType.Absolute, heightCAM));

            var orderCAMs = GlobVar.CurrentProject.CAMs.Values.Where(x => x.IsActive && !x.IsHide && !x.IsAlignMasterCam() && !x.IsChangeJobMasterCam() && x.GroupID == Guid.Empty).OrderBy(x => x.STT).ToList();

            for (int i = 0; i < orderCAMs.Count(); i++)
            {
                ((cCAMTypes)orderCAMs[i]).BuildCaptionView();
                count += 1;
                if (count > GlobVar.RTCVision.Options.MaximumColumnCAM) count = 0;
                if (count > columnCount)
                    columnCount += 1;
            }
            LayoutCAM.ColumnCount = columnCount;
            int widthCam = (int)((Width - columnCount * 10) / columnCount);
            for (int i = 0; i < columnCount; i++)
                LayoutCAM.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, widthCam));

            for (int i = 0; i < orderCAMs.Count(); i++)
            {
                ucCAM cam = orderCAMs[i].View;
                cam.OnMaximizeButtonClickEvent -= OnMaximizeButtonClickEvent;
                cam.OnMaximizeButtonClickEvent += OnMaximizeButtonClickEvent;
                cam.OnMinimizeButtonClickEvent -= OnMinimizeButtonClickEvent;
                cam.OnMinimizeButtonClickEvent += OnMinimizeButtonClickEvent;
                cam.OnSetupToolsButtonClickEvent -= OnSetupToolsButtonClickEvent;
                cam.OnSetupToolsButtonClickEvent += OnSetupToolsButtonClickEvent;
                ListCam.Add(cam);
                cam.Dock = DockStyle.Fill;
                LayoutCAM.Controls.Add(cam);
                cam.RebuildWindow();
            }
        }

        private void ShowProjectCAMToLayoutControl_GroupCAM()
        {
            Guid _GroupID = Guid.Empty;
            foreach (cCAMTypes item in GlobVar.CurrentProject.CAMs.Values)
            {
                if (_GroupID != item.GroupID)
                {
                    _GroupID = item.GroupID;

                    TabPage tab = new TabPage();
                    tab.BackColor = Color.Black;
                    tab.BorderStyle = BorderStyle.None;
                    tab.Text = GlobVar.CurrentProject.GroupCAMs[_GroupID].Name;

                    ucGroupCAMs _GroupCAM = GlobVar.CurrentProject.GroupCAMs[_GroupID].View;
                    GlobVar.CurrentProject.GroupCAMs[_GroupID].BuildCaptionView();

                    _GroupCAM.MyGroup = GlobVar.CurrentProject.GroupCAMs[_GroupID];
                    ListGroupCam.Add(_GroupCAM);
                    tab.Controls.Add(_GroupCAM);
                    _GroupCAM.Width = TabControlCAM.TabPages[0].Width;
                    _GroupCAM.Height = TabControlCAM.TabPages[0].Height;
                    _GroupCAM.ViewCAMsToLayoutCAMs();
                    _GroupCAM.Dock = DockStyle.Fill;
                }
            }
        }

        private void ShowProjectCAMToLayoutControl_Mixed()
        {

            int count = 0;
            int rowCount = 0;
            int columnCount = 0;

            int userControlNumbers = 0;
            var groupId = Guid.Empty;

            foreach (cCAMTypes item in GlobVar.CurrentProject.CAMs.Values)
            {
                if (item.GroupID == Guid.Empty && item.IsNormal())
                {
                    userControlNumbers += 1;
                }
                else if (groupId != item.GroupID)
                {
                    groupId = item.GroupID;
                    userControlNumbers += 1;
                }
            }

            if (userControlNumbers <= 0)
            {
                return;
            }
            else
            {
            }

            rowCount = userControlNumbers / GlobVar.RTCVision.Options.MaximumColumnCAM;

            if (userControlNumbers % GlobVar.RTCVision.Options.MaximumColumnCAM != 0) rowCount += 1;
            LayoutCAM.RowCount = rowCount;
            int heightCAM = (int)((LayoutCAM.Height - rowCount * 6) / rowCount);
            for (int i = 0; i < rowCount; i++)
                LayoutCAM.RowStyles.Add(new RowStyle(SizeType.Absolute, heightCAM));

            var orderCAMs = GlobVar.CurrentProject.CAMs.Values.Where(x => x.IsNormal()).OrderBy(x => x.STT).ToList();

            groupId = Guid.Empty;
            for (int i = 0; i < orderCAMs.Count(); i++)
            {
                if (orderCAMs[i].IsHide) continue;
                ((cCAMTypes)orderCAMs[i]).BuildCaptionView();

                if (orderCAMs[i].GroupID == Guid.Empty)
                {
                    count += 1;
                    if (count > GlobVar.RTCVision.Options.MaximumColumnCAM) count = 0;
                    if (count > columnCount)
                        columnCount += 1;
                }
                else if (orderCAMs[i].GroupID != groupId)
                {
                    groupId = orderCAMs[i].GroupID;
                    count += 1;
                    if (count > GlobVar.RTCVision.Options.MaximumColumnCAM) count = 0;
                    if (count > columnCount)
                        columnCount += 1;
                }
            }
            LayoutCAM.ColumnCount = columnCount;
            int widthCam = (int)((Width - columnCount * 10) / columnCount);
            for (int i = 0; i < columnCount; i++)
                LayoutCAM.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, widthCam));
            groupId = Guid.Empty;
            for (int i = 0; i < orderCAMs.Count(); i++)
            {
                if (orderCAMs[i].IsHide) continue;

                if (orderCAMs[i].GroupID == Guid.Empty)
                {
                    ucCAM cam = orderCAMs[i].View;
                    cam.OnMaximizeButtonClickEvent -= OnMaximizeButtonClickEvent;
                    cam.OnMaximizeButtonClickEvent += OnMaximizeButtonClickEvent;
                    cam.OnMinimizeButtonClickEvent -= OnMinimizeButtonClickEvent;
                    cam.OnMinimizeButtonClickEvent += OnMinimizeButtonClickEvent;
                    cam.OnSetupToolsButtonClickEvent -= OnSetupToolsButtonClickEvent;
                    cam.OnSetupToolsButtonClickEvent += OnSetupToolsButtonClickEvent;
                    ListCam.Add(cam);
                    cam.Dock = DockStyle.Fill;
                    LayoutCAM.Controls.Add(cam);
                    cam.RebuildWindow();
                }
                else if (orderCAMs[i].GroupID != groupId)
                {
                    groupId = orderCAMs[i].GroupID;
                    ucGroupCAMs groupCam = GlobVar.CurrentProject.GroupCAMs[groupId].View;
                    GlobVar.CurrentProject.GroupCAMs[groupId].BuildCaptionView();
                    groupCam.MyGroup = GlobVar.CurrentProject.GroupCAMs[groupId];
                    ListGroupCam.Add(groupCam);
                    groupCam.Dock = DockStyle.Fill;
                    LayoutCAM.Controls.Add(groupCam);
                    groupCam.ViewCAMsToLayoutCAMs();
                }
            }
        }

        private void ShowProjectCAMToLayoutControl_NormalWidthGroupInRow()
        {
            Guid groupId = Guid.Empty;

            int count = 0;
            int rowCount = 0;
            int columnCount = 0;

            int userControlNumbers = GlobVar.CurrentProject.CAMs.Values.Count(x => x.IsNormal());
            ListTableLayoutPanel = null;
            if (userControlNumbers <= 0)
            {
                return;
            }
            else
            {
            }
            LayoutCAM.ColumnCount = 1;
            LayoutCAM.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            ListTableLayoutPanel = new List<TableLayoutPanel>();

            userControlNumbers = GlobVar.CurrentProject.GroupCAMs.Values.Count(x => x.IsActive);
            if (GlobVar.CurrentProject.CAMs.Values.Any(x => x.IsNormal() && x.GroupID == Guid.Empty))
                userControlNumbers += 1;

            int heightCAM = (int)((LayoutCAM.Height - rowCount * 6) / userControlNumbers);
            double percentRow = 100 / userControlNumbers;
            percentRow = Math.Round(percentRow, 2);
            LayoutCAM.RowCount = rowCount;
            for (int i = 0; i < userControlNumbers; i++)
                LayoutCAM.RowStyles.Add(new RowStyle(SizeType.Absolute, heightCAM));
            int maxColumn = 0;
            int widthCAM = 0;

            var orderGroupCAMs = GlobVar.CurrentProject.CAMs.Values.Where(x => x.IsActive).OrderBy(x => x.STT).ToList();

            for (int i = 0; i < orderGroupCAMs.Count(); i++)
            {
                userControlNumbers = GlobVar.CurrentProject.CAMs.Values.Count(x => x.IsNormal() && x.GroupID == orderGroupCAMs[i].ID);

                maxColumn = userControlNumbers >= GlobVar.RTCVision.Options.MaximumColumnCAM ? GlobVar.RTCVision.Options.MaximumColumnCAM : userControlNumbers;

                rowCount = userControlNumbers / maxColumn;
                if (userControlNumbers % maxColumn != 0) rowCount += 1;
                TableLayoutPanel tableLayout = new TableLayoutPanel();

                tableLayout.ColumnStyles.Clear();
                tableLayout.RowStyles.Clear();

                tableLayout.RowCount = rowCount;
                percentRow = 100 / rowCount;

                for (int i1 = 0; i1 < rowCount; i1++)
                    tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, (float)percentRow));

                var orderCAMs = GlobVar.CurrentProject.CAMs.Values.Where(x => x.IsNormal() && x.GroupID == orderGroupCAMs[i].ID).OrderBy(x => x.STT).ToList();

                for (int j = 0; j < orderCAMs.Count(); j++)
                {
                    ((cCAMTypes)orderCAMs[i]).BuildCaptionView();
                    count += 1;
                    if (count > GlobVar.RTCVision.Options.MaximumColumnCAM) count = 0;
                    if (count > columnCount)
                        columnCount += 1;
                }
                tableLayout.ColumnCount = columnCount;
                percentRow = 100 / columnCount;
                widthCAM = (int)((Width - columnCount * 10) / columnCount);

                for (int i1 = 0; i1 < columnCount; i1++)
                    tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)percentRow));
                for (int i1 = 0; i1 < orderCAMs.Count; i1++)
                {
                    ucCAM _CAM = orderCAMs[i1].View;
                    _CAM.OnMaximizeButtonClickEvent -= OnMaximizeButtonClickEvent;
                    //_CAM.OnMaximizeButtonClickEvent += OnMaximizeButtonClickEvent;
                    _CAM.OnMinimizeButtonClickEvent -= OnMinimizeButtonClickEvent;
                    _CAM.OnMinimizeButtonClickEvent += OnMinimizeButtonClickEvent;
                    _CAM.OnSetupToolsButtonClickEvent -= OnSetupToolsButtonClickEvent;
                    _CAM.OnSetupToolsButtonClickEvent += OnSetupToolsButtonClickEvent;
                    ListCam.Add(_CAM);
                    _CAM.Dock = DockStyle.Fill;
                    tableLayout.Controls.Add(_CAM);
                    _CAM.RebuildWindow();
                }
                tableLayout.Dock = DockStyle.Fill;
                ListTableLayoutPanel.Add(tableLayout);
                LayoutCAM.Controls.Add(tableLayout);
            }

            // CAM thường
            userControlNumbers = GlobVar.CurrentProject.CAMs.Values.Count(x => x.IsActive && !x.IsHide && x.CamType == ECamTypes.Normal && x.GroupID == Guid.Empty);
            if (userControlNumbers > 0)
            {
                TableLayoutPanel tableLayout = new TableLayoutPanel();
                maxColumn = userControlNumbers >= GlobVar.RTCVision.Options.MaximumColumnCAM ? GlobVar.RTCVision.Options.MaximumColumnCAM : userControlNumbers;
                rowCount = userControlNumbers / maxColumn;
                if (userControlNumbers % maxColumn != 0) rowCount += 1;
                tableLayout.RowCount = rowCount;
                heightCAM = (int)((tableLayout.Height - rowCount * 6) / rowCount);
                for (int i = 0; i < rowCount; i++)
                    tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, heightCAM));

                var orderCAMs = GlobVar.CurrentProject.CAMs.Values.Where(x => x.IsActive && !x.IsHide && x.CamType == ECamTypes.Normal && x.GroupID == Guid.Empty).OrderBy(x => x.STT).ToList();

                for (int i = 0; i < orderCAMs.Count(); i++)
                {
                    ((cCAMTypes)orderCAMs[i]).BuildCaptionView();
                    count += 1;
                    if (count > maxColumn) count = 0;
                    if (count > columnCount)
                        columnCount += 1;
                }
                tableLayout.ColumnCount = columnCount;
                widthCAM = (int)((Width - columnCount * 10) / columnCount);

                for (int i = 0; i < columnCount; i++)
                    tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, widthCAM));

                for (int i = 0; i < orderCAMs.Count(); i++)
                {
                    ucCAM _CAM = orderCAMs[i].View;
                    _CAM.OnMaximizeButtonClickEvent += OnMaximizeButtonClickEvent;
                    _CAM.OnMaximizeButtonClickEvent -= OnMaximizeButtonClickEvent;
                    _CAM.OnMinimizeButtonClickEvent -= OnMinimizeButtonClickEvent;
                    _CAM.OnMinimizeButtonClickEvent += OnMinimizeButtonClickEvent;
                    _CAM.OnSetupToolsButtonClickEvent -= OnSetupToolsButtonClickEvent;
                    _CAM.OnSetupToolsButtonClickEvent += OnSetupToolsButtonClickEvent;
                    ListCam.Add(_CAM);
                    _CAM.Dock = DockStyle.Fill;
                    tableLayout.Controls.Add(_CAM);
                }
                tableLayout.Dock = DockStyle.Fill;
                ListTableLayoutPanel.Add(tableLayout);
                LayoutCAM.Controls.Add(tableLayout);
            }
        }

        internal void ShowProjectCAMToLayoutControl(bool isAutoSetMaximize = true)
        {
            try
            {
                GlobFuncs.BeginControlUpdate(this);

                ClearOldLayout();

                if (GlobVar.CurrentProject == null)
                    return;

                switch (GlobVar.RTCVision.Options.ViewCamInMainFormMode)
                {
                    case EViewCamInMainFormMode.Normal:
                        ShowProjectCAMToLayoutControl_Normal();
                        break;
                    case EViewCamInMainFormMode.GroupCAMWithTab:
                        ShowProjectCAMToLayoutControl_SimpleCAM();
                        ShowProjectCAMToLayoutControl_GroupCAM();
                        break;
                    case EViewCamInMainFormMode.GroupCAMWithoutTab:
                        ShowProjectCAMToLayoutControl_Mixed();
                        break;
                    case EViewCamInMainFormMode.GroupCAMWithoutTabInRow:
                        ShowProjectCAMToLayoutControl_NormalWidthGroupInRow();
                        break;
                    default:
                        break;
                }
                LayoutCAM.BringToFront();
                foreach (var item in GlobVar.CurrentProject.CAMs.Values)
                {
                    item.GroupActions.MyCam = item;
                    if (item.IsMaximize && isAutoSetMaximize)
                        item.View.btnMaximize.PerformClick();
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
        /// <summary>
        /// Xóa bỏ các layout cũ
        /// </summary>
        private void ClearOldLayout(TableLayoutPanel tableLayoutPanel)
        {
            if (ListCam != null && ListCam.Count > 0)
            {
                foreach (ucCAM _ucCAM in ListCam)
                {
                    if (tableLayoutPanel.Controls.Contains(_ucCAM))
                    {
                        _ucCAM.Dock = DockStyle.None;
                        _ucCAM.OnMaximizeButtonClickEvent -= OnMaximizeButtonClickEvent;
                        _ucCAM.OnMinimizeButtonClickEvent -= OnMinimizeButtonClickEvent;
                        _ucCAM.OnSetupToolsButtonClickEvent -= OnSetupToolsButtonClickEvent;
                        tableLayoutPanel.Controls.Remove(_ucCAM);
                    }
                }
            }
            if (ListGroupCam != null && ListGroupCam.Count > 0)
            {
                foreach (ucGroupCAMs _ucGroupCAM in ListGroupCam)
                {
                    _ucGroupCAM.ClearListucCAM();
                    _ucGroupCAM.Dock = DockStyle.None;
                    _ucGroupCAM.GroupCAM_OnMaximizeButtonClickEvent -= GroupCAM_OnMaximizeBttonClickEvent;
                    _ucGroupCAM.GroupCAM_OnMinimizeButtonClickEvent -= GroupCAM_OnMinimizeButtonClickEvent;
                    if (tableLayoutPanel.Controls.Contains(_ucGroupCAM)) tableLayoutPanel.Controls.Remove(_ucGroupCAM);
                }
            }
        }

        private void GroupCAM_OnMaximizeBttonClickEvent(object CAMsender, object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    GlobFuncs.BeginControlUpdate(this);
                    ucGroupCAMs ucGroupCam = (ucGroupCAMs)CAMsender;

                    ucGroupCam.Dock = DockStyle.None;
                    OldRowCAM = LayoutCAM.GetRow(ucGroupCam);
                    OldColCAM = LayoutCAM.GetRow(ucGroupCam);
                    LayoutCAM.Controls.Remove(ucGroupCam);
                    LayoutCAM_Maximize.Controls.Add(ucGroupCam);
                    ucGroupCam.Dock = DockStyle.Fill;
                    ucGroupCam.btnMaximize.Visible = false;
                    ucGroupCam.btnMinimize.Visible = true;
                    ucGroupCam.LayoutCAMWhenResize();
                    LayoutCAM_Maximize.BringToFront();
                }
                catch (Exception ex)
                {
                    GlobFuncs.SaveErr(ex);
                }
                finally
                {
                    GlobFuncs.EndControlUpdate(this);
                }
            }));
        }

        private void GroupCAM_OnMinimizeButtonClickEvent(object CAMsender, object sender, EventArgs e)
        {
            ShowProjectCAMToLayoutControl();
            ucGroupCAMs ucGroupCam = (ucGroupCAMs)CAMsender;
            ucGroupCam.Invoke(new Action(() =>
            {
                ucGroupCam.btnMaximize.Visible = true;
                ucGroupCam.btnMinimize.Visible = false;
            }));
        }
        /// <summary>
        /// Dọn dẹp lại layout cũ
        /// </summary>
        private void ClearOldLayout()
        {
            if (ListTableLayoutPanel != null && ListTableLayoutPanel.Count > 0)
            {
                foreach (TableLayoutPanel tableLayoutPanel in ListTableLayoutPanel)
                {
                    ClearOldLayout(tableLayoutPanel);
                    LayoutCAM.Controls.Remove(tableLayoutPanel);
                }
            }
            else
                ClearOldLayout(LayoutCAM);
            ListCam = new List<ucCAM>();
            ListGroupCam = new List<ucGroupCAMs>();
            ListExtraCam = new List<ucCAM>();
            ListTableLayoutPanel = new List<TableLayoutPanel>();
            LayoutCAM.RowStyles.Clear();
            LayoutCAM.ColumnStyles.Clear();
            int _PageCount = TabControlCAM.TabPages.Count - 1;
            for (int i = _PageCount; i > 1; i--)
                TabControlCAM.TabPages.RemoveAt(i);

        }
        /// <summary>
        /// Sự kiện khi nhấn vào nút maximize
        /// </summary>
        /// <param name="CAMSender"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMaximizeButtonClickEvent(object CAMSender, object sender, EventArgs e)
        {
            if (LayoutCAM_Maximize.InvokeRequired || LayoutCAM.InvokeRequired)
                LayoutCAM_Maximize.Invoke(new MethodInvoker(() => OnMaximizeButtonClickEvent(CAMSender, sender, e)));
            else
            {
                ucCAM ucCam = (ucCAM)CAMSender;
                //Bốc cam này khỏi layout cũ
                ucCam.Dock = DockStyle.None;
                OldRowCAM = LayoutCAM.GetRow(ucCam);
                OldColCAM = LayoutCAM.GetRow(ucCam);
                LayoutCAM_Maximize.Controls.Add(ucCam);

                ucCam.Dock = DockStyle.Fill;
                ucCam.btnMaximize.Visible = false;
                ucCam.btnMinimize.Visible = true;
                LayoutCAM_Maximize.BringToFront();
            }
        }
        private void OnMinimizeButtonClickEvent(object CAMsender, object sender, EventArgs e)
        {
            ShowProjectCAMToLayoutControl(false);
            ucCAM ucCam = (ucCAM)CAMsender;
            ucCam.Invoke(new Action(() =>
            {
                ucCam.btnMaximize.Visible = true;
                ucCam.btnMinimize.Visible = false;
            }));
        }

        private void OnSetupToolsButtonClickEvent(object CAMsender, object sender, EventArgs e)
        {
            if (GlobVar.CurrentProject == null) return;
            ucCAM _ucCAM = (ucCAM)CAMsender;
            _ucCAM.MyCAM.ShowActionTool(GlobVar.CurrentProject);
            GlobVar.CurrentProject.CAMs[_ucCAM.MyCAM.ID] = _ucCAM.MyCAM;
            EnableOrDisableControls();
        }
        private void mnuShowCurentProjectFolder_Click(object sender, EventArgs e)
        {
            if (GlobVar.CurrentProject != null)
                Process.Start(GlobVar.CurrentProject.FolderNameFullPath);
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (GlobVar.CurrentProject == null) return;
            if (cProjectFunctions.SaveProject(GlobVar.CurrentProject, Guid.Empty))
                cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Inf_SaveObjectSuccess,
                    new string[] { cStrings.Project.ToLower() }, new string[] { cStrings.ProjectV.ToLower() }));
            else
                cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Err_SaveObject,
                   new string[] { cStrings.Project.ToLower() }, new string[] { cStrings.ProjectV.ToLower() }));
            EnableOrDisableControls();
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            if (GlobVar.CurrentProject == null)
                return;
            ProjectData projectData = new ProjectData();
            EFunctionReturn functionReturn = projectData.SaveAs(GlobVar.CurrentProject, out cProjectTypes newProject);
            switch (functionReturn)
            {
                case EFunctionReturn.Success:
                    {
                        cMessageBox.Notification("Save As Is Success");
                        //Thêm vào mảng
                        if (GlobVar.DicProjects.ContainsKey(newProject.ID))
                            newProject.ID = Guid.NewGuid();
                        GlobVar.DicProjects.Add(newProject.ID, newProject);
                        ToolStripComboBox _cb = (ToolStripComboBox)cbProjects;
                        _cb.Items.Add(newProject.ProjectName);
                        GlobVar.DataTableProjects.Rows.Add(new object[]
                        {
                            newProject.ID, newProject.OrderNum,
                            newProject.ProjectName, newProject.Note,string.Empty,null,newProject.Pinned
                        });
                        break;
                    }
                case EFunctionReturn.Error:
                    cMessageBox.Error("Save As Cannot Success");
                    break;
                case EFunctionReturn.Cancel:
                    break;
            }

        }

        private void mnuProjectSetting_Click(object sender, EventArgs e)
        {
            if (GlobVar.CurrentProject == null)
                return;
            foreach (cCAMTypes _CAM in GlobVar.CurrentProject.CAMs.Values)
                _CAM.OldName = _CAM.Name;
            string oldProjectName = GlobVar.CurrentProject.ProjectName;
            string oldFileName = GlobVar.CurrentProject.FileName;
            FrmProject f = new FrmProject();
            f.IsAdd = false;
            f.Project = GlobVar.CurrentProject;
            f.Project.DataChange = false;
            if (f.ShowDialog() == DialogResult.OK)
            {
                GlobVar.CurrentProject = f.Project;

                foreach (cCAMTypes _CAM in GlobVar.CurrentProject.CAMs.Values)
                {
                    _CAM.OnButtonRunClickEvents -= OnRunButtonClickEvent;
                    _CAM.OnButtonRunClickEvents += OnRunButtonClickEvent;

                    _CAM.OnButtonStopClickEvents -= OnStopButtonClickEvent;
                    _CAM.OnButtonStopClickEvents += OnStopButtonClickEvent;

                    _CAM.GroupActions.MyCam = _CAM;
                }

                if (GlobVar.CurrentProject.FolderNameFullPathBAK.ToLower() != GlobVar.CurrentProject.FolderNameFullPath.ToLower())
                {
                    try
                    {
                        Directory.Move(GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath.ToLower());
                    }
                    catch (Exception ex)
                    {
                        cMessageBox.Error(ex.Message);
                        ReGetCurrentProject();
                        return;
                    }

                    foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                    {
                        cam.GroupActions.SourceImageSettings.MasterImage = cam.GroupActions.SourceImageSettings.MasterImage.Replace(
                            GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                        var dataArchives = cam.GroupActions.Actions.Values.Where(x =>
                        x.ActionType == EActionTypes.DataArchive ||
                        x.ActionType == EActionTypes.DataArchiveRead ||
                        x.ActionType == EActionTypes.SaveConfig ||
                        x.ActionType == EActionTypes.LoadConfig ||
                        x.ActionType == EActionTypes.SaveImage ||
                        x.ActionType == EActionTypes.LoadImage ||
                        x.ActionType == EActionTypes.SaveObject ||
                        x.ActionType == EActionTypes.LoadObject).ToList();
                        if (dataArchives.Any())
                            foreach (cAction action in dataArchives)
                            {
                                switch (action.ActionType)
                                {
                                    case EActionTypes.SaveImage:
                                        {
                                            action.FileName.rtcValue = action.FileName.rtcValue.Replace(
                                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                                            break;
                                        }
                                    case EActionTypes.LoadImage:
                                        {
                                            action.FileName.rtcValue = action.FileName.rtcValue.Replace(
                                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                                            break;
                                        }
                                    case EActionTypes.SaveConfig:
                                        {
                                            action.FileName.rtcValue = action.FileName.rtcValue.Replace(
                                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                                            break;
                                        }
                                    case EActionTypes.LoadConfig:
                                        {
                                            action.FileName.rtcValue = action.FileName.rtcValue.Replace(
                                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                                            break;
                                        }
                                    case EActionTypes.SaveObject:
                                        {
                                            action.FileName.rtcValue = action.FileName.rtcValue.Replace(
                                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                                            break;
                                        }
                                    case EActionTypes.LoadObject:
                                        {
                                            action.FileName.rtcValue = action.FileName.rtcValue.Replace(
                                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                                            break;
                                        }
                                    default:
                                        {
                                            if (action.FolderName != null)
                                                action.FolderName.rtcValue = action.FolderName.rtcValue.Replace(
                                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                                            if (action.DataArchive_FolderName != null)
                                                action.DataArchive_FolderName.rtcValue = action.DataArchive_FolderName.rtcValue.Replace(
                                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                                            if (action.FileName != null)
                                                action.FileName.rtcValue = action.FileName.rtcValue.Replace(
                                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                                            if (action.DataArchive_FileName != null)
                                                action.DataArchive_FileName.rtcValue = action.DataArchive_FileName.rtcValue.Replace(
                                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                                            break;
                                        }
                                }
                            }
                    }
                }
                foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                {
                    if (cam.OldName.ToLower() != cam.Name.ToLower())
                    {
                        try
                        {
                            string oldFileName_Actions = Path.Combine(GlobVar.CurrentProject.FolderNameFullPath, cam.FileName_Actions + cExtFile.GroupD);
                            string oldFileName_Iconic = Path.Combine(GlobVar.CurrentProject.FolderNameFullPath, cam.FileName_Actions + cExtFile.GroupIconicD);
                            cam.FileName_Actions = GlobFuncs.SwitchToUnsigned(cam.Name);
                            string newFileName_Actions = Path.Combine(GlobVar.CurrentProject.FolderNameFullPath, cam.FileName_Actions + cExtFile.GroupD);
                            string newFileName_Iconic = Path.Combine(GlobVar.CurrentProject.FolderNameFullPath, cam.FileName_Actions + cExtFile.GroupIconicD);

                            if (File.Exists(oldFileName_Actions))
                                File.Move(oldFileName_Actions, newFileName_Actions);
                            if (File.Exists(oldFileName_Iconic))
                                File.Move(oldFileName_Iconic, newFileName_Iconic);


                            cam.BuildDefaultFolderPath(GlobVar.CurrentProject.FolderNameFullPath);
                            cam.BuidDefaultSettingsSaveImage(GlobVar.CurrentProject.FolderNameFullPath);
                            cam.GroupActions.SourceImageSettings.MasterImage = cam.GroupActions.SourceImageSettings.MasterImage.Replace(
                                GlobVar.CurrentProject.FolderNameFullPathBAK, GlobVar.CurrentProject.FolderNameFullPath);
                            cam.OldName = cam.Name;
                        }
                        catch (Exception ex)
                        {
                            cMessageBox.Error(ex.Message);
                            GlobFuncs.SaveErr(ex);
                        }
                    }
                    GlobVar.CurrentProject.FolderNameFullPathBAK = GlobVar.CurrentProject.FolderNameFullPath;
                    if (cProjectFunctions.SaveProject(GlobVar.CurrentProject, Guid.Empty))
                    {
                        if (oldProjectName.ToLower() != GlobVar.CurrentProject.ProjectName.ToLower())
                            try
                            {
                                oldFileName = Path.Combine(GlobVar.CurrentProject.FolderNameFullPath, Path.GetFileName(oldFileName));
                                File.Delete(oldFileName);
                            }
                            catch
                            {

                            }
                        GlobVar.DicProjects[GlobVar.CurrentProject.ID] = GlobVar.CurrentProject;
                        string oldName = cbProjects1.Text;
                        GlobVar.LockEvents = true;
                        cbProjects1.SelectedItem = GlobVar.CurrentProject.ProjectName;
                        cbProjects1.SelectedItem = GlobVar.CurrentProject.ProjectName;
                        cbProjects1.Items[cbProjects1.Items.IndexOf(oldName)] = GlobVar.CurrentProject.ProjectName;
                        GlobVar.DataTableProjects.Rows.Find(GlobVar.CurrentProject.ID)[cColName.ProjectName] = GlobVar.CurrentProject.ProjectName;
                        GlobVar.DataTableProjects.Rows.Find(GlobVar.CurrentProject.ID)[cColName.OrderNum] = GlobVar.CurrentProject.OrderNum;
                        GlobVar.LockEvents = false;
                        ShowProjectCAMToLayoutControl();
                        EnableOrDisableControls();
                        GlobVar.RTCVision.Files.LastProjectOpenName = GlobVar.CurrentProject?.ProjectName;
                        GlobVar.RTCVision.SaveIniConfig();

                    }

                    else
                    {
                        cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Err_SaveObject,
                            new string[] { cStrings.Project.ToLower() }, new string[] { cStrings.ProjectV.ToLower() }));
                        if (f.Project.DataChange)
                            ReGetCurrentProject();
                    }
                }
            }

            else if (f.Project.DataChange)
                ReGetCurrentProject();

        }



        private void OnRunButtonClickEvent(cCAMTypes sender, EventArgs e)
        {
            if (GlobVar.CurrentProject == null)
                return;
            try
            {
                GlobFuncs.ShowWaitForm("Prepare Before Run...");
                sender.GroupActions.Setting_PrepareDataAllBrachTools();
                GlobVar.CurrentProject.SetOnlineCam(sender);
                if (!sender.GroupActions.ConnectAllCameraUse(true))
                {
                    sender.GroupActions.DisconnectAllCameraUse();
                    GlobVar.CurrentProject.SetOfflineCam(sender);
                    return;
                }

                if (!sender.GroupActions.Setting_CheckAllConnection())
                {
                    cMessageBox.Warning(sender.GroupActions.ErrMessage);
                    GlobVar.CurrentProject.SetOfflineCam(sender);
                    sender.GroupActions.DisconnectAllCameraUse();
                    return;
                }

                //if (!sender.GroupActions.Setting_CheckAllConnecttion())
                //    GlobVar.CurrentProject.PrepareDataBeforeRun();
                cProjectFunctions.Run(sender);
            }
            finally
            {
                GlobFuncs.CloseWaitForm();
            }
        }

        private void OnStopButtonClickEvent(cCAMTypes sender, EventArgs e)
        {
            if (GlobVar.CurrentProject == null)
                return;
            cProjectFunctions.Stop(sender);
        }

        private void ReGetCurrentProject()
        {
            ProjectData projectData = new ProjectData();
            if (projectData.Connect(GlobVar.CurrentProject.FileName))
            {
                projectData.OpenProject_GetGroupCAMs(GlobVar.CurrentProject);
                projectData.OpenProject_GetCAMs(GlobVar.CurrentProject);

                foreach (cCAMTypes _CAM in GlobVar.CurrentProject.CAMs.Values)
                {
                    _CAM.OnButtonRunClickEvents -= OnRunButtonClickEvent;
                    _CAM.OnButtonRunClickEvents += OnRunButtonClickEvent;

                    _CAM.OnButtonStopClickEvents -= OnStopButtonClickEvent;
                    _CAM.OnButtonStopClickEvents += OnStopButtonClickEvent;

                    _CAM.GroupActions.MyCam = _CAM;
                }
                projectData.Disconnect();
            }
            GlobVar.CurrentProject.DataChange = false;
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            cProjectFunctions.DeleteProject(ref GlobVar.CurrentProject);
            int ItemIndex = cbProjects1.Items.IndexOf(cbProjects1.Text);
            cbProjects1.Items.RemoveAt(ItemIndex);
            if (cbProjects1.Items.Count > 0)
            {
                if (ItemIndex > cbProjects1.Items.Count - 1)
                    cbProjects1.SelectedItem = cbProjects1.Items[cbProjects1.Items.Count - 1];
                else
                    cbProjects1.SelectedItem = cbProjects1.Items[ItemIndex];
            }
            else cbProjects1.SelectedItem = string.Empty;
            cbProjects1.SelectedItem = cbProjects1.SelectedItem;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnableOrDisableControls()
        {
            mnuProjectSetting1.Enabled = GlobVar.CurrentProject != null;
            mnuDelete1.Enabled = GlobVar.CurrentProject != null;
            mnuSave1.Enabled = GlobVar.CurrentProject != null;
            mnuSaveAs1.Enabled = GlobVar.CurrentProject != null;
            mnuShowProjectFolder.Enabled = GlobVar.CurrentProject != null;
            mnuRun.Enabled = GlobVar.CurrentProject != null;

            pnlMainMenu.Visible = !GlobVar.RTCVision.Options.RunMode;
            barMenu.Visible = !GlobVar.RTCVision.Options.RunMode;
            barTools.Visible = !GlobVar.RTCVision.Options.RunMode;
            picLogo.Visible = !GlobVar.RTCVision.Options.RunMode && GlobVar.RTCVision.ViewOptions.IsShowLogo;
        }

        private void cbProject1_TextChanged(object sender, EventArgs e)
        {
            // cbProjects1.SelectedItem = cbProjects.SelectedItem;
        }
        /// <summary>
        /// Lấy model hiện tại đang làm việc
        /// </summary>
        private async void GetCurrentProject()
        {
            try
            {
                if (GlobVar.CurrentProject != null)
                {
                    cProjectFunctions.SaveProject_OnlySetting(GlobVar.CurrentProject);
                    cProjectFunctions.StopAllCam(GlobVar.CurrentProject);
                    foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                    {
                        cam.RemoveEvent();
                        cam.OnButtonRunClickEvents -= OnRunButtonClickEvent;
                        cam.OnButtonStopClickEvents -= OnStopButtonClickEvent;
                        if (cam.View != null)
                        {
                            cam.View.Dispose();
                            cam.View = null;
                        }
                    }
                }

                GlobVar.CurrentProject = null;
                GlobVar.ListCams = null;

                if (cbProjects1.SelectedItem == null)
                    return;

                foreach (cProjectTypes project in GlobVar.DicProjects.Values)
                {
                    if (project.ProjectName == cbProjects1.SelectedItem.ToString())
                    {
                        GlobVar.CurrentProject = project;
                        ProjectData projectData = new ProjectData();
                        if (projectData.Connect(project.FileName))
                        {
                            projectData.OpenProject_GetGroupCAMs(GlobVar.CurrentProject);
                            //projectData.OpenProject_GetCAMs(GlobVar.CurrentProject);
                            await projectData.OpenProject_GetCAMsTestAsync(GlobVar.CurrentProject);
                            projectData.OpenProject_TrayResult_Settings(project);
                            projectData.OpenProject_TrayReSult_ProgramName(project);
                            foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                            {
                                cam.OnButtonRunClickEvents -= OnRunButtonClickEvent;
                                cam.OnButtonRunClickEvents += OnRunButtonClickEvent;
                                cam.OnButtonStopClickEvents -= OnStopButtonClickEvent;
                                cam.OnButtonStopClickEvents += OnStopButtonClickEvent;
                                cam.GroupActions.MyCam = cam;
                            }
                            projectData.Disconnect();
                        }
                        GlobVar.CurrentProject.DataChange = false;
                        project.OldFileName = project.FileName;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                GlobVar.CurrentProject = null;
            }

        }


        private void timerLoad_Tick(object sender, EventArgs e)
        {
            try
            {
                timerLoad.Enabled = false;
                GlobVar.FormMain = this;

                GlobVar.imlActionType32 = imlActionType;
                GlobVar.imlActionType24 = imlActionType24;
                GlobVar.imlActionType16 = imlActionType16;

                cProjectFunctions.LoadAllProjects();
                cProjectFunctions.ViewAllProjectToCombobox(cbProjects);

                cbProjects1.SelectedItem = GlobVar.CurrentProject?.ProjectName;
                // GetCurrentProject();

                //ShowProjectCAMToLayoutControl();

                EnableOrDisableControls();

                GlobVar.ProgramMode = cProgramMode.Auto;
                _threadRealTime = new Thread(AllRealTimeControlStatus)
                {
                    IsBackground = true
                };
                _threadRealTime.Start();
                if (GlobVar.User == null || !GlobVar.User.IsLogged)
                {
                    mnuUserName.Visible = false;
                    mnuLogout.Visible = mnuUserName.Visible;
                    mnuLogin.Visible = true;
                }
                else
                {
                    mnuUserName.Visible = mnuUserManager.Visible == false;
                    mnuLogin.Visible = mnuUserManager.Visible == true;
                    mnuLogout.Visible = mnuUserName.Visible;
                    mnuUserName.Text = GlobVar.User.UserName;
                }
            }
            finally
            {

            }
        }
        private void AllRealTimeControlStatus()
        {
            while (true)
            {
                if (lblTime.InvokeRequired)
                {
                    lblTime.Invoke(new Action(() =>
{
    this.lblTime.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy, HH:mm:ss");
}));
                }
                else
                {
                    this.lblTime.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy, HH:mm:ss");
                }

                Thread.Sleep(1000);
            }
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Ver: " + GlobVar.Version;
            this.Text = $"{GlobVar.AppName}";
            ShowLogo();
            ShowMainCounter();
            timerLoad.Enabled = true;
        }

        internal void ShowMainCounter()
        {
            GlobFuncs.VisibleControl(lblTotal, GlobVar.RTCVision.ViewOptions.IsShowMainCounter);
            GlobFuncs.VisibleControl(lblNG, GlobVar.RTCVision.ViewOptions.IsShowMainCounter);
            GlobFuncs.VisibleControl(lblOK, GlobVar.RTCVision.ViewOptions.IsShowMainCounter);
        }
        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            LayoutCAMWhenResize();
        }

        private void cbProjects1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProjects.SelectedItem = cbProjects1.SelectedItem;
            //ShowProjectCAMToLayoutControl();

            //EnableOrDisableControls();
        }



        private void mnuRun_Click(object sender, EventArgs e)
        {
            try
            {
                GlobFuncs.ShowWaitForm("Prepare Before Run...");
                if (GlobVar.CurrentProject == null) return;
                if (GlobVar.ListCams == null)
                    GlobVar.ListCams = new Dictionary<string, Guid>();

                foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                    if (cam.IsActive && !cam.IsRun)
                    {
                        if (cam.IsMaster && cam.GroupActions.Actions.Values.FirstOrDefault(x =>
                            x.ActionType != EActionTypes.MainAction && x.ActionType != EActionTypes.None &&
                            x.Enable.rtcValue) == null)
                        {
                            if (cMessageBox.Question_YesNo(cMessageContent.BuildMessage(cMessageContent.Que_ClearObject,
                                new[] { cam.Name }, new[] { cam.Name })) != DialogResult.Yes)
                                return;
                        }
                        GlobVar.CurrentProject.SetOnlineCam(cam);
                        if (!cam.GroupActions.ConnectAllCameraUse(true))
                        {
                            GlobVar.CurrentProject.SetOfflineCam(cam);
                            cam.GroupActions.DisconnectAllCameraUse();
                            return;
                        }

                        if (!cam.GroupActions.Setting_CheckAllConnection())
                        {
                            cMessageBox.Warning(cam.GroupActions.ErrMessage);
                            // cam.GroupActions.Setting_CloseAllConnection();
                            GlobVar.CurrentProject.SetOfflineCam(cam);
                            return;
                        }

                        if (cam.GroupActions.Actions.Values.FirstOrDefault(x => x.ActionType == EActionTypes.HookKeyboard && x.Enable.rtcValue) != null)
                            cKeyboardHook.HookKeyboard_Start();
                    }
                GlobVar.CurrentProject.PrepareDataBeforeRun();

                cProjectFunctions.Run(GlobVar.CurrentProject);

                cProjectFunctions.RebuildContent(cMainStatus.STOP);
            }
            finally
            {
                GlobFuncs.CloseWaitForm();
            }
        }

        private void cbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stopwatch test = new Stopwatch();

            if (GlobVar.LockEvents)
                return;
            try
            {
                test.Start();
                cbProjects1.Text = cbProjects.Text;
                GlobVar.ProgramMode = cProgramMode.Manual;

                mnuStop.PerformClick();

                GlobFuncs.ShowWaitForm("Load Project...");

                // GetCurrentProject();
                GetCurrentProject(); // Chạy bất đồng bộ
                ShowProjectCAMToLayoutControl();

                //LoadRunningTemplatList();

                EnableOrDisableControls();

                GlobVar.RTCVision.Files.LastProjectOpenName = cbProjects.SelectedItem != null ? cbProjects.SelectedItem.ToString() : string.Empty;
                if (GlobVar.CurrentProject != null)
                    GlobVar.RTCVision.Files.LastProjectOpenName = GlobVar.CurrentProject.ProjectName;
                else
                    GlobVar.RTCVision.Files.LastProjectOpenName = string.Empty;
                GlobVar.RTCVision.SaveIniConfig();

                if (GlobVar.CurrentProject != null)
                    this.Text = $"{GlobVar.AppName} [{GlobVar.CurrentProject.ProjectName}]";
                else
                    this.Text = $"{GlobVar.AppName}";
            }
            finally
            {
                GlobFuncs.CloseWaitForm();
                test.Stop();
            }
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            GlobFuncs.ViewApplicationSettings();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (GlobVar.CurrentProject != null)
                {
                    cProjectFunctions.SaveProject_OnlySetting(GlobVar.CurrentProject);
                    cProjectFunctions.StopAllCam(GlobVar.CurrentProject);
                    if (GlobVar.CurrentProject.DataChange)
                    {
                        DialogResult dialogResult = cMessageBox.Question_YesNoCancel(cMessageContent.Que_SaveProject);
                        switch (dialogResult)
                        {
                            case DialogResult.Yes:
                                if (cProjectFunctions.SaveProject(GlobVar.CurrentProject, Guid.Empty))
                                    cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Inf_SaveObjectSuccess,
                                        new string[] { cStrings.Project.ToLower() }, new string[] { cStrings.ProjectV.ToLower() }));
                                else
                                {
                                    cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Err_SaveObject,
                                        new string[] { cStrings.Project.ToLower() }, new string[] { cStrings.ProjectV.ToLower() }));
                                    e.Cancel = true;
                                    return;
                                }
                                break;
                            case DialogResult.No:
                                break;
                            default:
                                e.Cancel = true;
                                return;
                        }
                    }
                }
                GlobVar.RTCVision.SaveIniConfig();
                if (File.Exists(GlobVar.DeepCopyFileName) && GlobVar.DeepCopyFileName.ToLower() != GlobVar.RTCVision.Files.SaveTemplate.ToLower())
                {
                    DeepCopyData.Disconnect();
                    File.Delete(GlobVar.DeepCopyFileName);
                }

                GlobFuncs.AbortThread(_threadRealTime);
                GlobFuncs.AbortThread(_threadCleanImageByTask);

                cProjectFunctions.CleanSavedImageByTask(cCleanImageEvent.ExitProgram);
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }

        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            if (GlobVar.CurrentProject == null)
                return;
            try
            {
                GlobFuncs.ShowWaitForm("Closing Process...");
                cProjectFunctions.StopAllCam(GlobVar.CurrentProject);
                cProjectFunctions.RebuildContent(cMainStatus.STOP);

                LockOrUnlockControls();
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

        private void mnuRunMode_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            GlobVar.RTCVision.Options.RunMode = (bool)mnuRunMode.Checked;
            EnableOrDisableControls();
        }

        private void mnuOnlineMode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {
            if (GlobVar.CurrentProject == null)
                return;
            if (cMessageBox.Question_YesNo("Do you want reset counter?") == DialogResult.No)
                return;
            GlobVar.CurrentProject.OKCount = 0;
            GlobVar.CurrentProject.NGCount = 0;
            GlobVar.CurrentProject.TotalCount = 0;
            cProjectFunctions.SaveProject_OnlyCounter(GlobVar.CurrentProject);
            cProjectFunctions.UpdateCounterToForm();
        }

        private void mnuAutoMode_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            GlobVar.ProgramMode = mnuAutoMode.Checked ? cProgramMode.Auto : cProgramMode.Manual;
            lblAutoMode.Text = GlobVar.ProgramMode + " " + cStrings.Mode;
        }

        private void mnuSetupTools_Click(object sender, EventArgs e)
        {
            GlobVar.RTCVision.ViewOptions.TabControlMainView = ETabControlMainView.Setup;
            //TabControlMainButtonSelect();
        }

        private void lisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobVar.License == null)
                GlobVar.License = new cLicense();
            GlobVar.License.ShowFormLicense();
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            if (cUser.ShowFormLogin())
            {
                mnuUser.Visible = true;
                mnuLogin.Visible = false;
                mnuLogout.Visible = true;
            }
        }

        private void mnuUser_Click(object sender, EventArgs e)
        {
            cUser.ShowFormUserManager();
        }

        private void mnuPosition_Click(object sender, EventArgs e)
        {
            cUser.ShowFormPositionManager();
        }

        private void mnuDepartment_Click(object sender, EventArgs e)
        {
            cUser.ShowFormDepartmentManager();
        }

        private void mnuPermisstion_Click(object sender, EventArgs e)
        {
            cUser.ShowFormPermissionManager();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void mnuCleanWindow_Click(object sender, EventArgs e)
        {
            if (GlobVar.CurrentProject != null)
                foreach (cCAMTypes item in GlobVar.CurrentProject.CAMs.Values)
                    if (item.IsActive && !item.IsHide)
                    {
                        item.GroupActions.ViewResult_CleanData();
                        if (item.View != null)
                            item.View.ClearWindow();
                    }
        }

        private void barTools_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuPDFDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(GlobVar.RTCVision.Files.PdfManual))
                    Process.Start(GlobVar.RTCVision.Files.PdfManual);
            }
            catch
            {
            }
        }

        private void mnuWordDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(GlobVar.RTCVision.Files.WordManual))
                    Process.Start(GlobVar.RTCVision.Files.WordManual);
            }
            catch
            {
            }
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            cUser.Logout();
            mnuLogin.Visible = true;
            mnuUserName.Visible = false;
            mnuLogout.Visible = false;

        }

        private void mnuCleanImage_Click(object sender, EventArgs e)
        {
            if (!cUser.ShowFormLoginAndCheckPermission(nameof(GlobVar.User.Permission.CleanImage),
           nameof(GlobVar.User.Permission.CleanImage.Execute)))
                return;
            cProjectFunctions.CleanSavedImage(GlobVar.CurrentProject);
        }
    }

}
