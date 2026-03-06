using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucGroupCAMs : UserControl
    {
        public event ucCAMButtonClickEvent GroupCAM_OnMaximizeButtonClickEvent;
        public event ucCAMButtonClickEvent GroupCAM_OnMinimizeButtonClickEvent;
        public event ucCAMButtonClickEvent GroupCAM_OnCloseButtonClickEvent;
        public ucGroupCAMs()
        {
            InitializeComponent();
        }

        #region PROPERTIES
        public cGroupCAMTypes MyGroup;

        public List<ucCAM> listucCAM;

        public List<ucCAM> ListucCam
        {
            get => listucCAM;
            set => listucCAM = value;
        }

        private int OldRowCAM = -1;
        private int OldColCAM = -1;
        #endregion

        private void OnMaximizeButtonClickEvent(object CAMSender, object sender, EventArgs e)
        {
            try
            {
                GlobFuncs.BeginControlUpdate(this);
                ucCAM ucCam = (ucCAM)CAMSender;
                //Bốc cam này khỏi layout cũ
                ucCam.Dock = DockStyle.None;
                OldRowCAM = LayoutCAM.GetRow(ucCam);
                OldColCAM = LayoutCAM.GetRow(ucCam);
                LayoutCAM.Controls.Remove(ucCam);
                LayoutCAM_Maximize.Controls.Add(ucCam);
                ucCam.Dock = DockStyle.Fill;
                ucCam.btnMaximize.Visible = false;
                ucCam.btnMinimize.Visible = true;
                LayoutCAM_Maximize.BringToFront();
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
        private void OnMinimizeButtonClickEvent(object CAMsender, object sender, EventArgs e)
        {
            ViewCAMsToLayoutCAMs();
            ucCAM ucCam = (ucCAM)CAMsender;
            ucCam.btnMaximize.Visible = true;
            ucCam.btnMinimize.Visible = false;
        }

        private void OnSetupToolsButtonClickEvent(object CAMsender, object sender, EventArgs e)
        {
            if (GlobVar.CurrentProject == null) return;
            ucCAM _ucCAM = (ucCAM)CAMsender;
            _ucCAM.MyCAM.ShowActionTool(GlobVar.CurrentProject);
            GlobVar.CurrentProject.DataChange = true;
        }

        public void ClearListucCAM()
        {
            if(ListucCam != null && ListucCam.Count > 0)
                foreach(ucCAM _ucCAM in ListucCam)
                    if(LayoutCAM.Controls.Contains(_ucCAM))
                    {
                        _ucCAM.Dock = DockStyle.None;
                        _ucCAM.OnMaximizeButtonClickEvent -= OnMaximizeButtonClickEvent;
                        _ucCAM.OnMinimizeButtonClickEvent -= OnMinimizeButtonClickEvent;
                        _ucCAM.OnSetupToolsButtonClickEvent -= OnSetupToolsButtonClickEvent;
                    }
        }

        public void ViewCAMsToLayoutCAMs()
        {
            try
            {
                GlobFuncs.BeginControlUpdate(this);
                if(MyGroup == null || GlobVar.CurrentProject == null)
                {
                    LayoutCAM.Controls.Clear();
                    return;
                }

                var orderCams = GlobVar.CurrentProject.CAMs.Values.Where(x => x.GroupID == MyGroup.ID).OrderBy(x => x.STT).ToList();

                if (orderCams.Count == 0) return;

                ClearListucCAM();

                listucCAM = new List<ucCAM>();
                LayoutCAM.RowStyles.Clear();
                LayoutCAM.ColumnStyles.Clear();

                int count = 0;
                int rowCount = 0;
                int columnCount = 0;
                int numberCamInRow = 3;

                rowCount = orderCams.Count / numberCamInRow;
                if (orderCams.Count % numberCamInRow != 0) rowCount += 1;
                LayoutCAM.RowCount = rowCount;
                int heightCam = (int)((LayoutCAM.Height - rowCount * 6) / rowCount);
                for (int i = 0; i < rowCount; i++)
                    LayoutCAM.RowStyles.Add(new RowStyle(SizeType.Absolute, heightCam));

                for(int i = 0; i < orderCams.Count(); i++)
                {
                    ((cCAMTypes)orderCams[i]).BuildCaptionView();
                    count += 1;
                    if (count > numberCamInRow) count = 0;
                    if (count > columnCount)
                        columnCount += 1;
                }

                columnCount = columnCount == 0 ? 1 : columnCount;
                LayoutCAM.ColumnCount = columnCount;
                int widthCam = (int)((Width - columnCount * 6) / columnCount);

                for (int i = 0; i < columnCount; i++)
                    LayoutCAM.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, widthCam));
                for(int i = 0; i < orderCams.Count(); i++)
                {
                    ucCAM cam = orderCams[i].View;
                    cam.OnMaximizeButtonClickEvent += OnMaximizeButtonClickEvent;
                    cam.OnMinimizeButtonClickEvent += OnMinimizeButtonClickEvent;
                    cam.OnSetupToolsButtonClickEvent += OnSetupToolsButtonClickEvent;
                    ListucCam.Add(cam);
                    cam.Dock = DockStyle.Fill;
                    LayoutCAM.Controls.Add(cam);
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                LayoutCAM.BringToFront();
                GlobFuncs.EndControlUpdate(this);
            }
        }
        public void LayoutCAMWhenResize()
        {
            try
            {
                if (LayoutCAM.Height == 0 || Width == 0) return;
                GlobFuncs.BeginControlUpdate(this);
                int heightCAM = (int)((LayoutCAM.Height - LayoutCAM.RowCount * 6) / LayoutCAM.RowCount);
                for (int i = 0; i < LayoutCAM.RowCount; i++)
                    LayoutCAM.RowStyles[i].Height = heightCAM;
                int widthCAM = (int)((Width - LayoutCAM.ColumnCount * 10) / LayoutCAM.ColumnCount);
                for (int i = 0; i < LayoutCAM.ColumnCount; i++)
                    LayoutCAM.ColumnStyles[i].Width = widthCAM;
            }
            finally
            {
                GlobFuncs.EndControlUpdate(this);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if(GroupCAM_OnMinimizeButtonClickEvent != null)
            {
                GroupCAM_OnMinimizeButtonClickEvent(this, sender, e);
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (GroupCAM_OnMaximizeButtonClickEvent != null)
            {
                GroupCAM_OnMaximizeButtonClickEvent(this, sender, e);
            }
        }
    }
}
