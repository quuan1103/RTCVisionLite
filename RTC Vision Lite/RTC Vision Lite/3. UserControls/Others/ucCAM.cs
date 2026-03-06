using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
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

namespace RTC_Vision_Lite.UserControls
{
    public delegate void ucCAMButtonClickEvent(object CAMsender, object sender, EventArgs e);
    public partial class ucCAM : UserControl
    {
        public event ucCAMButtonClickEvent OnMaximizeButtonClickEvent;
        public event ucCAMButtonClickEvent OnMinimizeButtonClickEvent;
        public event ucCAMButtonClickEvent OnSetupToolsButtonClickEvent;
        public event ucCAMButtonClickEvent OnRunButtonClickEvent;
        public event ucCAMButtonClickEvent OnStopButtonClickEvent;
        public ucCAM()
        {
            InitializeComponent();
            SmartWindow.FitImage = true;
            SmartWindow.FitImageDoubleClick = true;

        }

        private cCAMTypes _myCAM;

        public cCAMTypes MyCAM
        {
            get => _myCAM;
            set
            {
                _myCAM = value;
                
            }
        }
        private bool _IsAlignCAM;
        public bool IsAlignCAM
        {
            get => _IsAlignCAM;
            set
            {
                _IsAlignCAM = value;
            }
        }
        private string _FileName_ImageTemplate;
        public string FileName_ImageTemplate
        {
            get => _FileName_ImageTemplate;
            set => _FileName_ImageTemplate = value;
        }
        #region PUBLIC FUNCTIÓN
        public void RebuildWindow()
        {
            if (MyCAM.IsHide || !MyCAM.IsActive)
                return;
            ViewImageMode();
            if (!string.IsNullOrEmpty(_FileName_ImageTemplate) && File.Exists(_FileName_ImageTemplate))
            {
                try
                {
                    Bitmap image = new Bitmap(_FileName_ImageTemplate);
                    if (image != null)
                    {

                    }
                }
                catch (Exception ex)
                {

                }
            }
            if (MyCAM.IsMaster)
                lblCamName.ForeColor = Color.Gold;
            else if (MyCAM.IsBackground)
                lblCamName.ForeColor = Color.Silver;
            else
                lblCamName.ForeColor = Color.White;
            RebuildButton();
        }
        public void ClearWindow()
        {
            if (this.MyCAM.IsHide || !this.MyCAM.IsActive) return;
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(ClearWindow));
                return;
            }
            tlpHeader.BackColor = Color.DimGray;
            //GlobFuncs.VisibleControl(btnPassFail, false)
            SmartWindow.ClearImage();
            SmartWindow.ClearAllRoi();
            SmartWindow.ClearDispText();
        }
        internal void UpdateFont()
        {
            if (MyCAM.IsHide || !MyCAM.IsActive)
                return;

            //if (lblCamName.InvokeRequired)
            //{
            //    lblCamName.Invoke(new Action(() =>
            //    {
            //        lblCamName.Font = CommonData.GetFontStyle(cFontStyles.WindowCaption);
            //        lblCamName.Font = CommonData.GetFontStyle(cFontStyles.WindowCaption);
            //    }));
            //}
            //else
            //{
            //    lblCamName.Appearance.Font = CommonData.GetFontStyle(cFontStyles.WindowCaption);
            //    lblCamName.Appearance.Font = CommonData.GetFontStyle(cFontStyles.WindowCaption);
            //}
        }
        /// <summary>
        /// Buid lại hệ thống button trên giao diện
        /// </summary>
        public void RebuildButton()
        {
            if (MyCAM.IsHide || !MyCAM.IsActive)
                return;
            //GlobFuncs.VisibleControl(tlpHeader, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewCoordinates ||
            //                                    GlobVar.RTCVision.ViewOptions.CamFooter_IsViewOKNGButton ||
            //                                    GlobVar.RTCVision.ViewOptions.CamFooter_IsViewRobotMoveButton ||
            //                                    GlobVar.RTCVision.ViewOptions.CamFooter_IsViewSnapImageButton ||
            //                                    GlobVar.RTCVision.ViewOptions.CamFooter_IsViewSaveImageButton ||
            //                                    GlobVar.RTCVision.ViewOptions.CamFooter_IsViewLiveCamButton ||
            //                                    GlobVar.RTCVision.ViewOptions.CamFooter_IsViewLogButton ||
            //                                    GlobVar.RTCVision.ViewOptions.CamFooter_IsViewRunButton ||
            //                                    GlobVar.RTCVision.ViewOptions.CamFooter_IsViewStopLiveCamButton);

            GlobFuncs.VisibleControl(btnOK, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewOKNGButton);
            GlobFuncs.EnableControl(btnOK, MyCAM.IsJoinResult);
            GlobFuncs.VisibleControl(btnNG, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewOKNGButton);
            GlobFuncs.EnableControl(btnNG, MyCAM.IsJoinResult);

            GlobFuncs.VisibleControl(btnRunCurrent, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewRunButton);
            GlobFuncs.EnableControl(btnRunCurrent, !MyCAM.GroupActions.IsRun);

            GlobFuncs.VisibleControl(btnRunBack, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewRunButton);
            GlobFuncs.EnableControl(btnRunBack, !MyCAM.GroupActions.IsRun);

            GlobFuncs.VisibleControl(btnRunNext, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewRunButton);
            GlobFuncs.EnableControl(btnRunNext, !MyCAM.GroupActions.IsRun);

            GlobFuncs.VisibleControl(btnLive, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewLiveCamButton);
            GlobFuncs.EnableControl(btnLive, !MyCAM.GroupActions.IsRun &&
                                             MyCAM.GroupActions.SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera);

            GlobFuncs.VisibleControl(btnStopLive, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewStopLiveCamButton);
            GlobFuncs.EnableControl(btnLive, !MyCAM.GroupActions.IsRun &&
                                             MyCAM.GroupActions.SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera);

            GlobFuncs.VisibleControl(btnSnap, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewSnapImageButton);
            GlobFuncs.EnableControl(btnSnap, !MyCAM.GroupActions.IsRun);

            GlobFuncs.VisibleControl(btnSaveImage, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewSaveImageButton);
            GlobFuncs.EnableControl(btnSaveImage, !MyCAM.GroupActions.IsRun);

            GlobFuncs.VisibleControl(btnMove, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewRobotMoveButton);
            GlobFuncs.EnableControl(btnMove, !MyCAM.GroupActions.IsRun);

            GlobFuncs.EnableControl(btnMove, !MyCAM.GroupActions.IsRun);

            GlobFuncs.VisibleControl(btnStop, MyCAM.GroupActions.IsRun && (MyCAM.IsBackground || MyCAM.IsMaster));
            GlobFuncs.VisibleControl(btnRun, !MyCAM.GroupActions.IsRun && (MyCAM.IsBackground || MyCAM.IsMaster));
            GlobFuncs.EnableControl(btnSetting, !MyCAM.GroupActions.IsRun);
            //GlobFuncs.VisibleControl(btnMaximize, !MyCAM.IsExtraCam());
            //GlobFuncs.VisibleControl(btnMinimize, MyCAM.IsExtraCam());

            GlobFuncs.VisibleControl(lblCoordinates, GlobVar.RTCVision.ViewOptions.CamFooter_IsViewCoordinates);
        }
        internal void UpdateCounterToUI()
        {
            if (MyCAM.IsHide || !MyCAM.IsActive)
                return;
            lblTotalCounter?.Invoke(new Action(() =>
            {
                lblTotalCounter.Visible = MyCAM.IsViewCounter;
                if (lblTotalCounter.Visible)
                    lblTotalCounter.Text =
                        $"TOTAL: {MyCAM.TotalCount}";
            }));

            lblNGCounter?.Invoke(new Action(() =>
            {
                lblNGCounter.Visible = MyCAM.IsViewCounter;
                if (lblNGCounter.Visible)
                    lblNGCounter.Text =
                        $"NG: {MyCAM.NGCount} ({GlobFuncs.GetPercent(MyCAM.NGCount, MyCAM.TotalCount)}%)";
            }));

            lblOKCounter?.Invoke(new Action(() =>
            {
                lblOKCounter.Visible = MyCAM.IsViewCounter;
                if (lblOKCounter.Visible)
                    lblOKCounter.Text =
                        $"OK: {MyCAM.OKCount} ({GlobFuncs.GetPercent(MyCAM.OKCount, MyCAM.TotalCount)}%)";
            }));
        }
        #endregion
        #region EVENTS

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (OnSetupToolsButtonClickEvent != null)
            {
                OnSetupToolsButtonClickEvent(this, sender, e);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (OnMinimizeButtonClickEvent != null)
            {
                OnMinimizeButtonClickEvent(this, sender, e);
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if(OnMaximizeButtonClickEvent != null)
            {
                OnMaximizeButtonClickEvent(this, sender, e);
            }
        }
       
        internal void ViewImageMode()
        {
            if (MyCAM.IsHide || !MyCAM.IsActive)
                return;

            if (SmartWindow.InvokeRequired)
                SmartWindow.Invoke(new Action(() =>
                {
                    switch (this.MyCAM.GroupActions.SourceImageSettings.ImageSourceType)
                    {
                        case EImageSourceTypes.Computer:
                            picImageMode.Image = imageList1.Images[0];
                            GlobFuncs.SetToolTipToControl(picImageMode, "Current Image Mode: COMPUTER", 
                                "If you want to change the mode, right_click on the window and select the mode you want to change.");
                            break;
                        case EImageSourceTypes.Camera:
                            picImageMode.Image = imageList1.Images[1];
                            GlobFuncs.SetToolTipToControl(picImageMode, "Current Image Mode: CAMERA",
                               "If you want to change the mode, right_click on the window and select the mode you want to change.");
                            break;
                    }
                }));
            else
            {
                switch (this.MyCAM.GroupActions.SourceImageSettings.ImageSourceType)
                {
                    case EImageSourceTypes.Computer:
                        picImageMode.Image = imageList1.Images[0];
                        GlobFuncs.SetToolTipToControl(picImageMode, "Current Image Mode: COMPUTER",
                            "If you want to change the mode, right_click on the window and select the mode you want to change.");
                        break;
                    case EImageSourceTypes.Camera:
                        picImageMode.Image = imageList1.Images[1];
                        GlobFuncs.SetToolTipToControl(picImageMode, "Current Image Mode: CAMERA",
                           "If you want to change the mode, right_click on the window and select the mode you want to change.");
                        break;
                }
            }
        }
        #endregion
       
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (OnRunButtonClickEvent != null)
            {
                OnRunButtonClickEvent(this, sender, e);
            }    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (OnStopButtonClickEvent != null)
            {
                OnStopButtonClickEvent(this, sender, e);
            }    
        }

        private void lblCamName_Click(object sender, EventArgs e)
        {

        }

        private void SmartWindow_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoordinates.Text = "R: " + e.Y.ToString() + ", C: " + e.X.ToString();
        }
    }
}
