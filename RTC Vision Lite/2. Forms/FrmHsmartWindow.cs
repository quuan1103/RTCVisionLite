using GraphicsWindow;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmHsmartWindow : Form
    {
        public delegate void BtnConnectCameraClickEvents();
        public GraphicsWindow.GraphicsWindow SmartWindowControl => SmartWindow;
        public event BtnConnectCameraClickEvents OnBtnConnectClickEvents;
   
  
        private Image _Image = null;
        public Image Image
        {
            get => _Image;
            set
            {
                //GlobFuncs.DisposeImage(_Image);
                _Image = value;
                _ImageOrigin = value;
                SmartWindow.ClearImage();
                if (_Image != null)
                {
                    GlobFuncs.SmartSetPart(_Image, SmartWindow);
                    //Task.Factory.StartNew(RGBToHSV);
                }
                VisibleOrHideControlByContext();
            }

        }
        private bool _isRun;
        public bool IsRun
        {
            get => _isRun;
            set
            {
                _isRun = value;
                GlobFuncs.EnableControl(pnlTools, !_isRun);
                GlobFuncs.EnableControl(mnuIsViewMasterRoi, !_isRun);
                GlobFuncs.EnableControl(mnuIsViewMasterName, !_isRun);
                GlobFuncs.EnableControl(mnuIsViewMasterRoi, !_isRun);
                GlobFuncs.EnableControl(mnuViewMarkName, !_isRun);
                GlobFuncs.EnableControl(mnuIsViewNormalRoi, !_isRun);
                GlobFuncs.EnableControl(mnuViewRoiName, !_isRun);
                GlobFuncs.EnableControl(btnMultiSelect, !_isRun);
                GlobFuncs.EnableControl(btnMoveROIWithKey, !_isRun);
                GlobFuncs.EnableControl(btnLockROI, !_isRun);


            }
        }
        private Dictionary<long, GraphicsWindow.GraphicsWindow.DataRoi> DrawingObjects;
        private Dictionary<long, GraphicsWindow.GraphicsWindow.DataRoi> _multiDrawingObjects;

        private Image _ImageOrigin = null;
        private string CurrentDrawingObjectColor;
        private double rowRB = -1;
        private double colRB = -1;
        private bool IsZoom = false;
        private int RowDB1 = 0;
        private bool isCustomDraw = false;
        private Rectangle SelectionRectangle;
        private bool _isMultiSelect = false;
        private GraphicsWindow.GraphicsWindow.DataRoi currentDrawingObject;
        private List<object> ROICopy = null;
        private cExtendData extendDataCopy = null;
        private GraphicsWindow.GraphicsWindow.DataRoi CurrentDrawingObject
        {
            get => currentDrawingObject;
            set
            {
                currentDrawingObject = value;
                btnDelete.Enabled = CurrentDrawingObject != null;
            }
        }


        // static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        // private const int MOUSEEVENTF_WHEEL = 0X0800;

        public Dictionary<long, object> ROIS;

        private cAction _Action;

        public cAction Action
        {
            get => _Action;
            set
            {
                _isMultiSelect = false;
                MultiSelect_RefreshControls();
                if (_Action != null && _Action.ID != value.ID && Action.IsMultiROI)
                {
                    SwitchRoi(true);
                    //if(Action.ActionType == EActionTypes.DrawingROI)
                    //    Action.Run
                }
                _Action = value;
                //_Action.GetImageToInputImage();
                var ROI = new GraphicsWindow.GraphicsWindow.DataRoi();
                VisibleOrHideControlByContext();
                ClearAllRoi();
               // ReViewImage(true, true);
              //  ListDataRoi = new List<GraphicsWindow.GraphicsWindow.DataRoi>();
                ReviewAllROIS();
                //List<cRectangType> DataRois = _Action.ROIs.Values.Cast<cRectangType>().ToList();
                //foreach (cRectangType item in DataRois)
                //{
                //    ROI = new GraphicsWindow.GraphicsWindow.DataRoi((GraphicsWindow.GraphicsWindow.ERoiTypes)item.DrawingType, (float)item.Center.Row,
                //        (float)item.Center.Col, (float)item.Width, (float)item.Height, (float)item.Phi,
                //        (GraphicsWindow.GraphicsWindow.EConnectTypes)item.ConnectType, item.Color, GraphicsWindow.GraphicsWindow.ECentreTypes.TheCenterDoesNotChange, GlobFuncs.ConvertLongToGuid(item.ID));

                 //  SmartWindow.DrawROI(new List<GraphicsWindow.GraphicsWindow.DataRoi>() { ROI });
                //}


            }
        }

        private void MultiSelect_RefreshControls()
        {
            this.Invoke(new Action(() =>
            {
                btnMultiSelect.BackColor = _isMultiSelect ? Color.Blue : btnMoveROIWithKey.BackColor;
                btnMultiSelect.ForeColor = _isMultiSelect ? Color.Blue : btnMoveROIWithKey.BackColor;

            }));
        }

        private string _FileName = string.Empty;

        public string FileName
        {
            get => _FileName;
            set
            {
                _FileName = value;
                this.Invoke(new Action(
                    delegate ()
                    {

                    }));
            }
        }

        public FrmHsmartWindow()
        {
            InitializeComponent();

            SmartWindow.FitImageDoubleClick = true;
            CurrentDrawingObject = null;
            DrawingObjects = new Dictionary<long, GraphicsWindow.GraphicsWindow.DataRoi>();

        }

        private void FrmHsmartWindow_Load(object sender, EventArgs e)
        {
            panel1.BringToFront();

        }

        public void ReViewImage(bool isWithSetPart = false, bool isClean = false)
        {
            try
            {
                if (isClean)
                    SmartWindow.Controls.Clear();

                if (Action.ActionType == EActionTypes.MainAction && GlobVar.GroupActions.IsMasterMode)
                {
                    if (File.Exists(Action.MasterImageFile.rtcValue))
                    {
                        _Image = new Bitmap(Action.MasterImageFile.rtcValue);
                        if (_Image != null)
                            SmartWindow.Image = _Image;
                        if (isWithSetPart)
                        {
                            GlobFuncs.SmartSetPart(_Image, SmartWindow);
                        }
                    }
                }
                else if (Action.InputImage != null && Action.InputImage.rtcValue != null)
                {
                    _Image = new Bitmap(Action.InputImage.rtcValue);
                    if (_Image.PixelFormat == System.Drawing.Imaging.PixelFormat.DontCare)
                    {
                        return;
                    }
                    if (_Image != null)
                        SmartWindow.Image = _Image;
                    if (isWithSetPart)
                    {
                        GlobFuncs.SmartSetPart(_Image, SmartWindow);
                    }
                }
                else if (_Image != null)
                {
                    SmartWindow.Image = Image;
                    if (isWithSetPart)
                    {
                        GlobFuncs.SmartSetPart(_Image, SmartWindow);
                    }
                }
                //Task.Factory.StartNew(RBGToHSV);
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }

        private void RBGToHSV()
        {
            throw new NotImplementedException();
        }

        public void ShowMasterMode()
        {
            cAction mainAction = GlobVar.GroupActions.MainAction;
            Image = File.Exists(mainAction.MasterImageFile.rtcValue) ? new Bitmap(mainAction.MasterImageFile.rtcValue) : null;
        }

        public void VisibleOrHideControlByContext()
        {
            if (GlobVar.LockEvents) return;
            if (GlobVar.GroupActions.IsMasterMode)
            {
                this.Invoke(new Action(() =>
                {
                    btnDraw.Visible = true;
                    btnStep1.Visible = btnDraw.Visible;
                    GlobVar.Draw = true;
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    btnDraw.Visible = Action != null && ((Action.ShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnROI.Font.Bold) ||
                                                          (Action.FindShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnPass.Font.Bold));
                    GlobVar.Draw = Action != null && ((Action.ShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnROI.Font.Bold) ||
                                                         (Action.FindShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnPass.Font.Bold));
                    btnStep1.Visible = btnDraw.Visible;
                    btnRenameROI.Visible = Action != null && Action.IsMultiROI;
                    VisibleOrHideControlByActionType();
                }));
            }
        }

        private void VisibleOrHideControlByActionType()
        {
            if (Action == null)
                return;
            btnDraw.Enabled = true;
            btnCut.Enabled = true;
            btnCut.Enabled = true;
            btnPaste.Enabled = true;
            btnDelete.Enabled = true;
            mnuAddRectangSub.Visible = mnuAddCircleSub.Visible = Visible;
            mnuCopyROI.Visible = mnuCopyThisROIToMaster.Visible = mnuPatseRoi.Visible = mnuPasteOrigin.Visible = mnuPasteWithLink.Visible = true;
            mnuDelete.Visible = mnuDeselectAll.Visible = true;
            mnuMultiSelect.Visible = true; mnuAddMarkRoi.Visible = mnuChangeName.Visible = true;
            mnuAddRectang_Diff.Visible = mnuAddRectang_I.Visible = mnuAddRectang_U.Visible = true;
            mnuAddRectang1_Diff.Visible = mnuAddRectang1_I.Visible = mnuAddRectang1_U.Visible = true;
            mnuAddCircle_Diff.Visible = mnuAddCircle_I.Visible = mnuAddCircle_U.Visible = true;
            btnMultiSelect.Visible = true;
            mnuAddShapeWithRangMode.Visible = true;
            mnuChange.Visible = true;
            mnuAddMasterRoi.Visible = mnuLinkToMaster.Visible = mnuCopyThisROIToMaster.Visible = true;


            if (Action.IsMultiROI)
            {
                mnuAddCircle_Diff.Visible = false;
                mnuAddCircle_I.Visible = false;
                mnuAddCircle_U.Visible = false;

                mnuAddRectang_Diff.Visible = false;
                mnuAddRectang_I.Visible = false;
                mnuAddRectang_U.Visible = false;

                mnuAddRectang1_Diff.Visible = false;
                mnuAddRectang1_I.Visible = false;
                mnuAddRectang1_U.Visible = false;
                mnuLinkToMaster.Visible = false;
                mnuChange.Visible = false;


            }
            switch (Action.ActionType)
            {
                case EActionTypes.MainAction:
                    {
                        mnuAddRectangSub.Visible = mnuAddCircleSub.Visible = false;
                        mnuCopyROI.Visible = mnuCopyThisROIToMaster.Visible = mnuPatseRoi.Visible = mnuPasteOrigin.Visible = mnuPasteWithLink.Visible = false;
                        mnuDelete.Visible = mnuClearAll.Visible = mnuSelectAll.Visible = mnuDeselectAll.Visible = false;
                        mnuMultiSelect.Visible = mnuAddMarkRoi.Visible = mnuChangeName.Visible = false;
                        mnuAddMasterRoi.Visible = mnuLinkToMaster.Visible = mnuCopyThisROIToMaster.Visible = false;

                        btnDraw.Enabled = false;
                        btnCut.Enabled = false;
                        btnCopy.Enabled = false;
                        btnPaste.Enabled = false;
                        btnDelete.Enabled = false;
                        break;
                    }
                case EActionTypes.CalibrateEdgetoEdge:
                    {
                        btnDraw.Enabled = !Action.SmartFeature.rtcValue;
                        btnCut.Enabled = !Action.SmartFeature.rtcValue;
                        btnCopy.Enabled = !Action.SmartFeature.rtcValue;
                        btnPaste.Enabled = !Action.SmartFeature.rtcValue;
                        btnDelete.Enabled = !Action.SmartFeature.rtcValue;

                        mnuAddRectangSub.Visible = mnuAddCircleSub.Visible = Action.SmartFeature.rtcValue ? true : false;

                        mnuCopyROI.Visible = mnuCopyThisROIToMaster.Visible = mnuPatseRoi.Visible = mnuPasteOrigin.Visible = mnuPasteWithLink.Visible = Action.SmartFeature.rtcValue ? true : false;
                        mnuDelete.Visible = mnuClearAll.Visible = mnuSelectAll.Visible = mnuDeselectAll.Visible = Action.SmartFeature.rtcValue ? true : false;
                        mnuMultiSelect.Visible = mnuAddMarkRoi.Visible = mnuChangeName.Visible = Action.SmartFeature.rtcValue ? true : false;
                        mnuAddMasterRoi.Visible = mnuLinkToMaster.Visible = mnuCopyThisROIToMaster.Visible = Action.SmartFeature.rtcValue ? true : false;

                        mnuAddShapeWithRangMode.Visible = false;
                        btnMultiSelect.Visible = false;
                        break;
                    }
                case EActionTypes.GaugeDualROI:
                    {
                        mnuAddRectangSub.Visible = mnuAddCircleSub.Visible = false;
                        mnuCopyROI.Visible = mnuCopyThisROIToMaster.Visible = mnuPatseRoi.Visible = mnuPasteOrigin.Visible = mnuPasteWithLink.Visible = false;
                        mnuDelete.Visible = mnuClearAll.Visible = mnuSelectAll.Visible = mnuDeselectAll.Visible = false;
                        mnuMultiSelect.Visible = mnuAddMarkRoi.Visible = mnuChangeName.Visible = false;
                        mnuAddMasterRoi.Visible = mnuLinkToMaster.Visible = mnuCopyThisROIToMaster.Visible = false;

                        btnDraw.Enabled = false;
                        btnCut.Enabled = false;
                        btnCopy.Enabled = false;
                        btnPaste.Enabled = false;
                        btnDelete.Enabled = false;
                        break;

                    }
            }

            mnuClearAll.Visible = true;



        }

        public void UpdateLiveControlsVisible()
        {
            if (GlobVar.GroupActions != null && GlobVar.GroupActions.SourceImageSettings != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblLive_Run.Visible = GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsLive && GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                        lblLive_Stop.Visible = !GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsLive && GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                        if (GlobVar.GroupActions.SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera)
                            lblSnap.Visible = GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                        else
                            lblSnap.Visible = true;
                        btnConnectCamera.Visible = GlobVar.GroupActions.SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera &&
                        !GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;

                    });
                }
                else
                {
                    lblLive_Run.Visible = GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsLive && GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                    lblLive_Stop.Visible = !GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsLive && GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                    if (GlobVar.GroupActions.SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera)
                        lblSnap.Visible = GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                    else
                        lblSnap.Visible = true;
                    btnConnectCamera.Visible = GlobVar.GroupActions.SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera &&
                    !GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                }
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblLive_Run.Visible = false;
                        lblLive_Stop.Visible = false;
                        lblSnap.Visible = false;
                    });
                }
                else
                {
                    lblLive_Run.Visible = false;
                    lblLive_Stop.Visible = false;
                    lblSnap.Visible = false;
                }
            }
        }
        public void UpdateSelectMode()
        {
            pnlTools.Enabled = !GlobVar.IsSelectMode;
            if (GlobVar.IsSelectMode)
            {
                //CancelSelectMode();
                //((ucCalibrateEdgeToEdgeActionDetails)Action.ViewInfo).btnGe
            }
        }
        private void btnConnectCamera_Click(object sender, EventArgs e)
        {
            if (OnBtnConnectClickEvents != null)
                OnBtnConnectClickEvents();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnCut_Click(object sender, EventArgs e)
        {
            //var test = SmartWindow.ListDataRoiOutput;
            //var test2 = ListDataRoi;
        }

        private void btnDrawRectang_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Rectang, EConnectTypes.None);
        }
        private List<GraphicsWindow.GraphicsWindow.DataRoi> _ListDataRoi;

        public List<GraphicsWindow.GraphicsWindow.DataRoi> ListDataRoi
        {
            get => _ListDataRoi;
            set
            {
                _ListDataRoi = value;
                ListCurrentDataRoi = value;
            }


        }
        public List<GraphicsWindow.GraphicsWindow.DataRoi> ListCurrentDataRoi;

        private object AddShape(EDrawingtypes drawingTypes,
                                EConnectTypes connectTypes,
                                double row = -1,
                                double col = -1,
                                EAnimationTypes eAninationTypes = EAnimationTypes.e2D,
                                bool isDuplicate = false,
                                bool isLink = false,
                                bool isCopyRoi = false,
                                object copyROI = null,
                                ERoiTypes roiTypes = ERoiTypes.Normal)
        {

            if (Action == null) return null;
            object resultObject = null;
            GraphicsWindow.GraphicsWindow.DataRoi ROI;

            if (GetROIS() == null)
                ROIS = new Dictionary<long, Object>();
            if (Action.ActionType == EActionTypes.BlobMultipleROI && Action.ROIProperties == null)
                Action.ROIProperties = new Dictionary<long, cROIProperty>();
            switch (drawingTypes)
            {

                case EDrawingtypes.Rectang:
                    {
                        cRectangType Rec = new cRectangType(Image);
                        if (row != -1 && col != -1)
                        {
                            Rec.Center.Row = row;
                            Rec.Center.Col = col;
                        }
                        else
                        {
                            Rec.Center.Row = SmartWindow.Image.Width / 2;
                            Rec.Center.Col = SmartWindow.Image.Height / 2;

                        }
                        Rec.AnimationType = eAninationTypes;
                        Rec.ConnectType = connectTypes;
                        Rec.RoiType = roiTypes;
                        Rec.Name = GetRoiName(Rec, ROIS);
                        Rec.IsDisplayOutPut = true;

                        if (isCopyRoi && copyROI != null)
                        {
                            Rec.Width = ((cRectangType)copyROI).Width;
                            Rec.Height = ((cRectangType)copyROI).Height;
                            Rec.MarkID = new List<double> { ((cRectangType)copyROI).MasterID }; 
                            Rec.MasterID = ((cRectangType)copyROI).MasterID;
                            Rec.Phi = ((cRectangType)copyROI).Phi;
                            Rec.Center.Row = ((cRectangType)copyROI).Width;
                            Rec.Center.Col = ((cRectangType)copyROI).Width;

                        }
                          ROI = new GraphicsWindow.GraphicsWindow.DataRoi((GraphicsWindow.GraphicsWindow.ERoiTypes)drawingTypes, (float)Rec.Center.Row, (float)Rec.Center.Col, (float)Rec.Width, (float)Rec.Height, 0,
                           GraphicsWindow.GraphicsWindow.EConnectTypes.None, Color.Red, GraphicsWindow.GraphicsWindow.ECentreTypes.TheCenterDoesNotChange, Guid.NewGuid());
                        Rec.ID = GlobFuncs.ConvertGuidToLong(ROI.Key);
                        ROIS.Add(Rec.ID, Rec);
                        DrawingObjects.Add(GlobFuncs.ConvertGuidToLong(ROI.Key), ROI);
                        SmartWindow.AddRoi(ROI);
                        //SmartWindow.DrawROI(ListDataRoi);

                        //ListCurrentDataRoi.Add(ROI);

                        if (IsShapeListView() && roiTypes == ERoiTypes.Normal)
                        {
                            Action.AddROIProperties(Rec.ID, ROIS.Count <= 1);
                            if (isDuplicate)
                            {
                                Action.CopyROIProperties(GlobFuncs.ConvertGuidToLong(currentDrawingObject.Key), GlobFuncs.ConvertGuidToLong(ROI.Key));
                                if (isLink)
                                {
                                    Action.SetLinkROIProperties(GlobFuncs.ConvertGuidToLong(currentDrawingObject.Key), GlobFuncs.ConvertGuidToLong(ROI.Key));
                                }

                            }
                        }
                        if (Action.ActionType == EActionTypes.DrawingROI)
                        {
                            if (ROIS.Count > 1)
                            {
                                cROIProperty roiProperty = Action.ROIProperties[GlobFuncs.ConvertGuidToLong(ROI.Key)];
                                roiProperty.ROIName.rtcValue = Rec.Name;
                                roiProperty.CenterPoint.rtcValue = new List<double> { Rec.Center.Row, Rec.Center.Col };
                                roiProperty.CenterPoint.rtcValue = roiProperty.CenterPoint.rtcValue;
                                roiProperty.Width.rtcValue = new List<double> { Rec.Width };
                                roiProperty.Height.rtcValue = new List<double> { Rec.Height };
                                roiProperty.Angle.rtcValue = new List<double> { Rec.Phi };
                                roiProperty.Width.rtcValue = new List<double> { Rec.Width };
                                roiProperty.DrawingType.rtcValue = cDrawingType.Rectangle;
                                roiProperty.DrawingMode.rtcValue = cDrawingMode.margin;
                            }
                            else
                            {
                                Action.ROIName.rtcValue = Rec.Name;
                                Action.CenterPoint.rtcValue = new List<double> { Rec.Center.Row, Rec.Center.Col };
                                Action.CenterPoint.rtcValue = Action.CenterPoint.rtcValue;
                                Action.Width.rtcValue = new List<double> { Rec.Width };
                                Action.Height.rtcValue = new List<double> { Rec.Height };
                                Action.Angle.rtcValue = new List<double> { Rec.Phi };
                                Action.Width.rtcValue = new List<double> { Rec.Width };
                                Action.DrawingType.rtcValue = cDrawingType.Rectangle;
                                Action.DrawingMode.rtcValue = cDrawingMode.margin;
                            }
                        }
                        if (ROIS.Count <= 1)
                        {
                            CurrentDrawingObject = ROI;
                            SwitchRoi();
                        }
                        resultObject = Rec;
                        break;
                    }
                case EDrawingtypes.Ellipse:
                    {
                        cEllipseType Ell = new cEllipseType(Image);
                        if (row != -1 && col != -1)
                        {
                            Ell.Center.Row = row;
                            Ell.Center.Col = col;
                        }
                        else
                        {
                            Ell.Center.Row = SmartWindow.Width / 2;
                            Ell.Center.Col = SmartWindow.Height / 2;

                        }
                        Ell.AnimationType = eAninationTypes;
                        Ell.ConnectType = connectTypes;
                        Ell.RoiType = roiTypes;
                        Ell.Name = GetRoiName(Ell, ROIS);
                        Ell.IsDisplayOutPut = true;
                        if (isCopyRoi && copyROI != null)
                        {
                            Ell.Radius1 = ((cRectangType)copyROI).Width;
                            Ell.Radius2 = ((cRectangType)copyROI).Height;
                            Ell.MarkID = new List<double> { ((cRectangType)copyROI).MasterID };
                            Ell.MasterID = ((cRectangType)copyROI).MasterID;
                            Ell.Phi = ((cRectangType)copyROI).Phi;
                            Ell.Center.Row = ((cRectangType)copyROI).Width;
                            Ell.Center.Col = ((cRectangType)copyROI).Width;

                        }
                        ROI = new GraphicsWindow.GraphicsWindow.DataRoi((GraphicsWindow.GraphicsWindow.ERoiTypes)drawingTypes, (float)Ell.Center.Row, (float)Ell.Center.Col, (float)Ell.Radius1, (float)Ell.Radius2, 0,
                           GraphicsWindow.GraphicsWindow.EConnectTypes.None, Color.Red, GraphicsWindow.GraphicsWindow.ECentreTypes.TheCenterDoesNotChange, Guid.NewGuid());
                        //ListDataRoi.Add(ROI);
                        //SmartWindow.DrawROI(ListDataRoi);
                        Ell.ID = GlobFuncs.ConvertGuidToLong(ROI.Key);

                        SmartWindow.AddRoi(ROI);
                        ROIS.Add(Ell.ID, Ell);
                        DrawingObjects.Add(GlobFuncs.ConvertGuidToLong(ROI.Key), ROI);
                        if (IsShapeListView() && roiTypes == ERoiTypes.Normal)
                        {
                            Action.AddROIProperties(GlobFuncs.ConvertGuidToLong(ROI.Key), ROIS.Count <= 1);
                            if (isDuplicate && CurrentDrawingObject != null)
                            {
                                Action.CopyROIProperties(GlobFuncs.ConvertGuidToLong(CurrentDrawingObject.Key), GlobFuncs.ConvertGuidToLong(ROI.Key));
                            }
                        }
                        if (Action.ActionType == EActionTypes.DrawingROI)
                        {
                            cROIProperty roiProperty = Action.ROIProperties[GlobFuncs.ConvertGuidToLong(ROI.Key)];
                            roiProperty.ROIName.rtcValue = Ell.Name;
                            roiProperty.CenterPoint.rtcValue = new List<double>();
                            roiProperty.CenterPoint.rtcValue.Add(Ell.Center.Row);
                            roiProperty.CenterPoint.rtcValue.Add(Ell.Center.Col);
                            roiProperty.CenterPoint.rtcValue = roiProperty.CenterPoint.rtcValue;
                            roiProperty.Width.rtcValue = new List<double>() { Ell.Radius1 };
                            roiProperty.Height.rtcValue = new List<double>() { Ell.Radius2 };
                            roiProperty.Angle.rtcValue = new List<double>() { Ell.Phi };
                            roiProperty.DrawingType.rtcValue = cDrawingType.Rectangle;
                            roiProperty.DrawingMode.rtcValue = cDrawingMode.margin;

                        }
                        if (ROIS.Count <= 1)
                        {
                            CurrentDrawingObject = ROI;
                            SwitchRoi();
                        }
                        resultObject = Ell;
                        break;
                        SmartWindow.FitImageDoubleClick = true;
                    }
                case EDrawingtypes.Line:
                    break;
                case EDrawingtypes.Polygon:
                    break;
                case EDrawingtypes.none:
                    break;
                default:
                    break;


            }
            SetRoiTrainFlagValue();
            SetROIs();
            CalcRegions();

            return resultObject;

        }

        private void CalcRegions(int drawID = -1)
        {
            if (Action != null &&
                Action.ViewInfo != null &&
                Action.ViewInfo.GetType().BaseType.Name == nameof(ucBaseActionDetail))
            {
                if (((ucBaseActionDetail)Action.ViewInfo).btnROI.Font.Bold)
                    CalcRegions_General();
                else if (((ucBaseActionDetail)Action.ViewInfo).btnPass.Font.Bold)
                {
                    CalcRegions_PassFail();

                }
            }
        }

        private void CalcRegions_General()
        {
            //if (Action.ActionType == EActionTypes.CalibrateEdgetoEdge && Action.SmartFeature.rtcValue)
            ReViewImage();
            if (Action == null || Action.ShapeList == null || Image == null || Action.ROIs == null) return;
            Action.ShapeList.rtcValue = new List<object>();
            cDrawingBaseType Normal = null;
            cDrawingBaseType Other = null;
            GraphicsWindow.GraphicsWindow.DataRoi Region = new GraphicsWindow.GraphicsWindow.DataRoi();

            foreach (object item in Action.ROIs.Values)
                ((cDrawingBaseType)item).MarkID = new List<double>();
            foreach (object item in Action.ROIs.Values)
            {
                Normal = (cDrawingBaseType)item;
                switch (Normal.RoiType)
                {
                    case ERoiTypes.Normal:
                        {
                            if (Normal.ConnectType != EConnectTypes.None)
                                continue;
                            break;
                        }
                    case ERoiTypes.Mark:
                        {
                            break;
                        }
                    case ERoiTypes.Master:
                        {
                            continue;
                        }
                    default:
                        continue;
                }
                if (Normal.DrawingType != EDrawingtypes.Line)
                {
                   // Region = DrawingObjects[Normal.ID];
                }
                //if (Normal.RoiType == ERoiTypes.Normal && GlobVar.RTCVision.ViewOptions.IsViewNormalRoi)
                //    SmartWindow.AddRoi(Region);

                // THÊM ROI NÀY VÀO SHAPE LIST VỚI THÂN PHẬN ROI CHA
                if (Normal.RoiType == ERoiTypes.Normal)
                    AddROIToShapeList(item, Action.ShapeList, 1);
            }
        }
        private void CalcRegions_PassFail()
        {
            if (Action == null || Action.FindShapeList == null || Image == null || Action.FindROIs == null) return;
            //if (Action.FindRegions == null) Action.FindRegions = new Dictionary<long, HObject>();
            //Action.FindRegions.Clear();
            Action.FindShapeList.rtcValue = new List<object>();
            ReViewImage();
            cDrawingBaseType Normal = null;
            cDrawingBaseType Other = null;
            GraphicsWindow.GraphicsWindow.DataRoi Region = new GraphicsWindow.GraphicsWindow.DataRoi();

            foreach (object item in Action.FindROIs.Values)
                ((cDrawingBaseType)item).MarkID = new List<double>();
            foreach (object item in Action.FindROIs.Values)
            {
                Normal = (cDrawingBaseType)item;
                switch (Normal.RoiType)
                {
                    case ERoiTypes.Normal:
                        {
                            if (Normal.ConnectType != EConnectTypes.None)
                                continue;
                            break;
                        }
                    case ERoiTypes.Mark:
                        {
                            break;
                        }
                    case ERoiTypes.Master:
                        {
                            continue;
                        }
                    default:
                        continue;
                }
                if (Normal.DrawingType != EDrawingtypes.Line)
                {
                    Region = DrawingObjects[Normal.ID];
                }
                //if (Normal.RoiType == ERoiTypes.Normal && GlobVar.RTCVision.ViewOptions.IsViewNormalRoi)
                //    SmartWindow.AddRoi(Region);

                // THÊM ROI NÀY VÀO SHAPE LIST VỚI THÂN PHẬN ROI CHA
                if (Normal.RoiType == ERoiTypes.Normal)
                    AddROIToShapeList(item, Action.FindShapeList, 1);
            }
        }
        private void AddROIToShapeList(object item, SListObject shapeList, int type)
        {
            cDrawingBaseType Normal = (cDrawingBaseType)item;
            switch (Normal.DrawingType)
            {
                case EDrawingtypes.Rectang:
                    {
                        shapeList.rtcValue.Add(Normal.Center.Row);
                        shapeList.rtcValue.Add(Normal.Center.Col);
                        shapeList.rtcValue.Add(((cRectangType)item).Phi);
                        shapeList.rtcValue.Add(((cRectangType)item).Width);
                        shapeList.rtcValue.Add(((cRectangType)item).Height);
                        shapeList.rtcValue.Add((int)Normal.DrawingType);
                        shapeList.rtcValue.Add((int)Normal.ConnectType);
                        shapeList.rtcValue.Add(type);
                        shapeList.rtcValue.Add(Normal.ID);
                        shapeList.rtcValue.Add(Normal.Name);
                        break;
                    }
                case EDrawingtypes.Rectang1:
                    {
                        shapeList.rtcValue.Add(Normal.Center.Row);
                        shapeList.rtcValue.Add(Normal.Center.Col);
                        shapeList.rtcValue.Add(((cRectangType)item).Phi);
                        shapeList.rtcValue.Add(((cRectangType)item).Width);
                        shapeList.rtcValue.Add(((cRectangType)item).Height);
                        shapeList.rtcValue.Add((int)Normal.DrawingType);
                        shapeList.rtcValue.Add((int)Normal.ConnectType);
                        shapeList.rtcValue.Add(type);
                        shapeList.rtcValue.Add(Normal.ID);
                        shapeList.rtcValue.Add(Normal.Name);
                        break;
                    }
                case EDrawingtypes.Ellipse:
                    {
                        shapeList.rtcValue.Add(Normal.Center.Row);
                        shapeList.rtcValue.Add(Normal.Center.Col);
                        shapeList.rtcValue.Add(((cEllipseType)item).Phi);
                        shapeList.rtcValue.Add(((cEllipseType)item).Radius1);
                        shapeList.rtcValue.Add(((cEllipseType)item).Radius2);
                        shapeList.rtcValue.Add((int)Normal.DrawingType);
                        shapeList.rtcValue.Add((int)Normal.ConnectType);
                        shapeList.rtcValue.Add(type);
                        shapeList.rtcValue.Add(Normal.ID);
                        shapeList.rtcValue.Add(Normal.Name);
                        break;
                    }
            }
        }
        private bool IsShapeListView()
        {
            if (Action != null &&
                Action.ViewInfo != null &&
                Action.ViewInfo.GetType().BaseType.Name == nameof(ucBaseActionDetail))
            {
                if (Action.ShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnROI.Font.Bold)
                    return true;
            }
            return false;
        }

        private string GetRoiName(cDrawingBaseType roi, Dictionary<long, object> rois)
        {
            string roiName = string.Empty;
            switch (roi.RoiType)
            {
                case ERoiTypes.Normal:
                    {
                        int i = 1;
                        bool result = false;
                        while (!result)
                        {
                            roiName = "ROI - " + i.ToString();
                            result = true;
                            foreach (long key in rois.Keys)
                                if (key != roi.ID && ((cDrawingBaseType)rois[key]).Name.Trim().ToLower() ==
                                    roiName.ToLower())
                                {
                                    result = false;
                                    break;
                                }
                            i += 1;
                        }
                        break;
                    }
                case ERoiTypes.Mark:
                    {
                        int i = 1;
                        bool result = false;
                        while (!result)
                        {
                            roiName = "Mark - " + i.ToString();
                            result = true;
                            foreach (long key in rois.Keys)
                                if (key != roi.ID && ((cDrawingBaseType)rois[key]).Name.Trim().ToLower() ==
                                    roiName.ToLower())
                                {
                                    result = false;
                                    break;
                                }
                            i += 1;
                            GraphicsWindow.GraphicsWindow.DataDispText test = new GraphicsWindow.GraphicsWindow.DataDispText();
                            SmartWindow.DispText(test);
                        }
                        break;
                    }
                case ERoiTypes.Master:
                    {
                        int i = 1;
                        bool result = false;
                        while (!result)
                        {
                            roiName = "MASTER - " + i.ToString();
                            result = true;
                            foreach (long key in rois.Keys)
                                if (key != roi.ID && ((cDrawingBaseType)rois[key]).Name.Trim().ToLower() ==
                                    roiName.ToLower())
                                {
                                    result = false;
                                    break;
                                }
                            i += 1;

                        }
                        break;
                    }
            }
            return roiName;
        }

        private Dictionary<long, object> GetROIS()
        {
            ROIS = null;
            if (Action != null &&
                Action.ViewInfo != null
                && Action.ViewInfo.GetType().BaseType.Name == nameof(ucBaseActionDetail))
            {
                if (Action.ShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnROI.Font.Bold)
                    ROIS = Action.ROIs;
                else if (Action.FindShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnPass.Font.Bold)
                    ROIS = Action.FindROIs;

            }
            else if (Action != null && Action.ActionType == EActionTypes.MainAction && GlobVar.GroupActions.IsMasterMode)
                ROIS = Action.ROIs;
            return ROIS;
        }
        private object GetROI(Guid roiID)
        {
            long longID = GlobFuncs.ConvertGuidToLong(roiID);
            if (ROIS != null)
            {
                if (ROIS.ContainsKey(longID))
                {
                    return ROIS[longID];
                }
                else
                    return null;
            }
            else
                return null;
        }
        private void btnDrawCircle_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Ellipse, EConnectTypes.None);
        }
        private bool _isGetPossition = true;
        private void SmartWindow_MouseDown(object sender, MouseEventArgs e)
        {
            ROIS = GetROIS();

            if (e.Button != MouseButtons.Left || e.Clicks > 1 || _isGetPossition)
            {
                ListDataRoi = new List<GraphicsWindow.GraphicsWindow.DataRoi>();
                ListDataRoi = SmartWindow.ListDataRoiOutput;
                _isGetPossition = false;

            }

            //CurrentDrawingObject = SmartWindow.KeySelect;
            //ListCurrentDataRoi = ListCurrentDataRoi;
            //if (SmartWindow.MoveImage && e.Button == MouseButtons.Left)
            //{
            //ListDataRoi.Clear();  
            //ListDataRoi = SmartWindow.ListDataRoiOutput;
            //    //SmartWindow.DrawROI(ListDataRoi);
            //}
            
        }

        private void SmartWindow_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    _isGetPossition = true;
                    if (Action.TabPassActive != null && !Action.TabPassActive.rtcValue)
                    {
                        SmartWindow.Image = Action.MyGroup.Actions[Action.MyGroup.IDMainAction].InputImage.rtcValue;
                    }
                }
                PointF pointImage = SmartWindow.PointImage;
                lblCordinate.Text = "R: " + Math.Round(pointImage.Y,1).ToString() + ", C: " + Math.Round(pointImage.X, 1).ToString();

                //Task.Factory.StartNew(() => ShowPointInfo(sender, e));
            }
            catch(Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }

            //if (_isGetPossition && e.Button == MouseButtons.Left)
            //{
            //    ListDataRoi.Clear();
            //    ListDataRoi = SmartWindow.ListDataRoiOutput;
            //    SmartWindow.DrawROI(ListDataRoi);
            //}
        }

        private void ShowPointInfo(object sender, MouseEventArgs e)
        {
            if (this.IsDisposed)
                return;
            GraphicsWindow.GraphicsWindow hSmartWindowControl = (GraphicsWindow.GraphicsWindow)sender;
            if (hSmartWindowControl.IsDisposed)
                return;

            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action(() => ShowPointInfo(sender, e)));
                }
                catch
                {
                    // ignored
                }
                return;
            }
            try
            {
                GlobFuncs.BeginControlUpdate(this);
                lblPopup.Visible = false;
                //int regionIndex = GetRegionIndexInMousePoint(e);
                //if (regionIndex != -1)
                //{
                //    regionIndex -= 1;
                //    lblRegionIndex.Text = "Region InputThree:" + regionIndex.ToString();
                //}
                //else
                //    lblRegionIndex.Text = "Region InputThree: None";
                //HOperatorSet.GenRegionPoints(out HObject hObject,e.X,)
                pnlQuickInfo.Visible = false;

                List<double> grayValue = new List<double>(0);
                List<double> mingrayValue = new List<double>(0);
                List<double> maxgrayValue = new List<double>(0);
                List<double> rangegrayValue = new List<double>(0);
                string roiName = "Image";

            }
            catch
            {

            }
        }

        private void SmartWindow_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
                ROIS = GetROIS();
                CurrentDrawingObject = DrawingObjects.FirstOrDefault(x => x.Key == GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)).Value;
                cRectangType ROISelected;
                cEllipseType ROICircleSelected;
                if (isCustomDraw)
                {
                    ControlPaint.DrawReversibleFrame(new Rectangle(PointToScreen(SelectionRectangle.Location), SelectionRectangle.Size), BackColor, FrameStyle.Dashed);
                    Invalidate();
                }
                else
                {
                    if (!_isGetPossition)
                        GetRegionInMousePoint(e);
                    if (Action == null || GlobVar.IsSelectMode || !GlobVar.Draw || !Action.IsCanEdit.rtcValue)
                        return;
                    if (CurrentDrawingObject != null)
                    {
                        if (Action.TabPassActive != null && Action.TabPassActive.rtcValue)
                        {
                            if (CurrentDrawingObject.RoiType == GraphicsWindow.GraphicsWindow.ERoiTypes.Circle)
                            {
                                ROICircleSelected = ((cEllipseType)Action.FindROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)]);
                                var DataRoiSelected = SmartWindow.ListDataRoiOutput.Find(X => X.Key == SmartWindow.KeySelect);
                                ROICircleSelected.Center.Col = DataRoiSelected.CenterPointY;
                                ROICircleSelected.Center.Row = DataRoiSelected.CenterPointX;
                                ROICircleSelected.Radius2 = DataRoiSelected.ShapeHeight;
                                ROICircleSelected.Radius1 = DataRoiSelected.ShapeWidth;
                                ROICircleSelected.Phi = DataRoiSelected.Angle;
                                ROICircleSelected.ConnectType = (EConnectTypes)DataRoiSelected.ConnectType;
                                ROICircleSelected.DrawingType = (EDrawingtypes)DataRoiSelected.RoiType;
                                ROICircleSelected.ID = GlobFuncs.ConvertGuidToLong(DataRoiSelected.Key);
                                ROICircleSelected.Color = DataRoiSelected.ColorRoi;
                                Action.FindROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)] = ROICircleSelected;
                            }
                            else
                            {
                                ROISelected = ((cRectangType)Action.FindROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)]);
                                var DataRoiSelected = SmartWindow.ListDataRoiOutput.Find(X => X.Key == SmartWindow.KeySelect);
                                ROISelected.Center.Col = DataRoiSelected.CenterPointY;
                                ROISelected.Center.Row = DataRoiSelected.CenterPointX;
                                ROISelected.Height = DataRoiSelected.ShapeHeight;
                                ROISelected.Width = DataRoiSelected.ShapeWidth;
                                ROISelected.Phi = DataRoiSelected.Angle;
                                ROISelected.ConnectType = (EConnectTypes)DataRoiSelected.ConnectType;
                                ROISelected.DrawingType = (EDrawingtypes)DataRoiSelected.RoiType;
                                ROISelected.ID = GlobFuncs.ConvertGuidToLong(DataRoiSelected.Key);
                                ROISelected.Color = DataRoiSelected.ColorRoi;
                                Action.FindROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)] = ROISelected;
                            }
                        }
                        else
                        {
                            if (CurrentDrawingObject.RoiType == GraphicsWindow.GraphicsWindow.ERoiTypes.Circle)
                            {
                                ROICircleSelected = ((cEllipseType)Action.ROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)]);
                                var DataRoiSelected = SmartWindow.ListDataRoiOutput.Find(X => X.Key == SmartWindow.KeySelect);
                                ROICircleSelected.Center.Col = DataRoiSelected.CenterPointY;
                                ROICircleSelected.Center.Row = DataRoiSelected.CenterPointX;
                                ROICircleSelected.Radius2 = DataRoiSelected.ShapeHeight;
                                ROICircleSelected.Radius1 = DataRoiSelected.ShapeWidth;
                                ROICircleSelected.Phi = DataRoiSelected.Angle;
                                ROICircleSelected.ConnectType = (EConnectTypes)DataRoiSelected.ConnectType;
                                ROICircleSelected.DrawingType = (EDrawingtypes)DataRoiSelected.RoiType;
                                ROICircleSelected.ID = GlobFuncs.ConvertGuidToLong(DataRoiSelected.Key);
                                ROICircleSelected.Color = DataRoiSelected.ColorRoi;
                                Action.ROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)] = ROICircleSelected;
                            }
                            else
                            {
                                ROISelected = ((cRectangType)Action.ROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)]);
                                var DataRoiSelected = SmartWindow.ListDataRoiOutput.Find(X => X.Key == SmartWindow.KeySelect);
                                ROISelected.Center.Col = DataRoiSelected.CenterPointY;
                                ROISelected.Center.Row = DataRoiSelected.CenterPointX;
                                ROISelected.Height = DataRoiSelected.ShapeHeight;
                                ROISelected.Width = DataRoiSelected.ShapeWidth;
                                ROISelected.Phi = DataRoiSelected.Angle;
                                ROISelected.ConnectType = (EConnectTypes)DataRoiSelected.ConnectType;
                                ROISelected.DrawingType = (EDrawingtypes)DataRoiSelected.RoiType;
                                ROISelected.ID = GlobFuncs.ConvertGuidToLong(DataRoiSelected.Key);
                                ROISelected.Color = DataRoiSelected.ColorRoi;
                                Action.ROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)] = ROISelected;
                            }

                        }
                        if (e.Button == MouseButtons.Middle && mnuMultiSelect.Visible == true)
                            mnuMultiSelect.PerformClick();
                        if (_isGetPossition)
                        {
                            SetRoiTrainFlagValue();
                            SetROIs();
                            SwitchRoi();
                            CalcRegions();
                        }
                    }
                    Point mnuLocation = GraphicsWindow.GraphicsWindow.MousePosition;
                    Point NewRoiLocation = new Point((int)SmartWindow.PointImage.X, (int)SmartWindow.PointImage.Y);
                    rowRB = NewRoiLocation.X;
                    colRB = NewRoiLocation.Y;
                    if (e.Button == MouseButtons.Right && !GlobVar.IsSelectMode)
                        mnuMenuShape.Show(mnuLocation);
                }
            
            //}
            //else
            //{
            //    if (!_isGetPossition)
            //        GetRegionInMousePoint(e);
            //    else if (!GlobVar.IsSelectMode)
            //    {
            //        Point mnuLocation = GraphicsWindow.GraphicsWindow.MousePosition;
            //        mnuMenuShape.Show(mnuLocation);
            //    }
            //}

        }
        private void SwitchRoi(bool onlyGetValue = false)
        {
            if (Action == null || !Action.IsMultiROI) return;
            var roiProperties = Action.ROIProperties.Values.Where(x => x.Selected);
            cROIProperty crp = null;
            if (roiProperties != null && roiProperties.Any())
            {
                crp = (cROIProperty)roiProperties.First();
                crp.GetValueFromAction(Action);
                crp.Selected = false;
                Action.ROIProperties[crp.ID] = crp;
            }
            if (onlyGetValue) return;
            if (currentDrawingObject != null && Action.ROIProperties.ContainsKey(GlobFuncs.ConvertGuidToLong(CurrentDrawingObject.Key)))
            {
                crp = Action.ROIProperties[GlobFuncs.ConvertGuidToLong(CurrentDrawingObject.Key)];
                crp.Selected = true;
                crp.SetValueToAction(Action);
                SmartWindow.KeySelect = CurrentDrawingObject.Key;
                Action.ROIProperties[crp.ID] = crp;
                ((ucBaseActionDetail)Action.ViewInfo).BindingDataToControls();
                ((ucBaseActionDetail)Action.ViewInfo).RefreshPropertiesList();
            }
        }
        private void GetRegionInMousePoint(MouseEventArgs e)
        {
            if (Action == null || (Action.ActionType != EActionTypes.Blob &&
                Action.ActionType != EActionTypes.ColorBlob &&
                Action.ActionType != EActionTypes.ColorBlobMultipleROI &&
                Action.ActionType != EActionTypes.BlobFilter &&
                Action.ActionType != EActionTypes.BlobMultipleROI))
                return;
            switch (Action.ActionType)
            {
                case EActionTypes.Blob:
                    {
                        if (Action._BlobTool == null) return;
                        //Point mousePosNow = e.Location;
                        //int x = (int)(mousePosNow.X * SmartWindow.Width);
                        //int y = (int)(mousePosNow.Y * SmartWindow.Height);
                        Action._BlobTool.PositionMouse = SmartWindow.PointImage;
                        Action._BlobTool.ClickMouse();
                        Action.AreaActual.rtcValue = new List<double> { Action._BlobTool.AreaActual };
                        Action.WidthActual.rtcValue = new List<double> { Action._BlobTool.WidthActual };
                        Action.HeightActual.rtcValue = new List<double> { Action._BlobTool.HeightActual };
                        Action.OuterRadiusActual.rtcValue = new List<double> { Action._BlobTool.OuterRadiusActual };
                        Action.CircularityActual.rtcValue = new List<double> { Action._BlobTool.CircularityActual };
                        Action.ColumnActual.rtcValue = new List<double> { Action._BlobTool.ColumnActual };
                        Action.RowActual.rtcValue = new List<double> { Action._BlobTool.RowActual };
                        Action.Passed.rtcValue = Action._BlobTool.Passed;
                        Action.NumberOfBlobsFound.rtcValue = new List<double> { Action._BlobTool.NumberOfBlobsFound };
                       
                        if (Action.ViewInfo != null)
                            ((ucBaseActionDetail)Action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                        break;
                    }
                case EActionTypes.BlobMultipleROI:
                    {
                        if (Action.BlobView == null) return;
                        //Point mousePosNow = e.Location;
                        //int x = (int)(mousePosNow.X * SmartWindow.Width);
                        //int y = (int)(mousePosNow.Y * SmartWindow.Height);
                        Action.BlobView.PositionMouse = SmartWindow.PointImage;
                        Action.BlobView.ClickMouse();
                        Action.AreaActual.rtcValue = new List<double> { Action.BlobView.AreaActual };
                        Action.WidthActual.rtcValue = new List<double> { Action.BlobView.WidthActual };
                        Action.HeightActual.rtcValue = new List<double> { Action.BlobView.HeightActual };
                        Action.OuterRadiusActual.rtcValue = new List<double> { Action.BlobView.OuterRadiusActual };
                        Action.Passed.rtcValue = Action.BlobView.Passed;
                        //Action.NumberOfBlobsFound.rtcValue = new List<double> { Action.BlobView.NumberOfBlobsFound };

                        if (Action.ViewInfo != null)
                            ((ucBaseActionDetail)Action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                        break;
                    }
                case EActionTypes.BlobFilter:
                    {
                        if (Action.BlobFilter == null) return;
                        //Point mousePosNow = e.Location;
                        //int x = (int)(mousePosNow.X * SmartWindow.Width);
                        //int y = (int)(mousePosNow.Y * SmartWindow.Height);
                        Action.BlobFilter.PositionMouse = SmartWindow.PointImage;
                        Action.BlobFilter.ClickMouse();
                        Action.AreaActual.rtcValue = new List<double> { Action.BlobFilter.AreaActual };
                        Action.WidthActual.rtcValue = new List<double> { Action.BlobFilter.WidthActual };
                        Action.HeightActual.rtcValue = new List<double> { Action.BlobFilter.HeightActual };
                        Action.OuterRadiusActual.rtcValue = new List<double> { Action.BlobFilter.OuterRadiusActual };
                        Action.CircularityActual.rtcValue = new List<double> { Action.BlobFilter.CircularityActual };
                        Action.ColumnActual.rtcValue = new List<double> { Action.BlobFilter.ColumnActual };
                        Action.RowActual.rtcValue = new List<double> { Action.BlobFilter.RowActual };
                        Action.Passed.rtcValue = Action.BlobFilter.Passed;
                        Action.NumberOfBlobsFound.rtcValue = new List<double> { Action.BlobFilter.NumberOfBlobsFound };
                        if (Action.ViewInfo != null)
                            ((ucBaseActionDetail)Action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                        break;
                    }
                case EActionTypes.ColorBlob:
                    {
                        if (Action.ColorBlob == null) return;
                        Action.ColorBlob.PositionMouse = SmartWindow.PointImage;
                        Action.ColorBlob.ClickMouse();
                        Action.AreaActual.rtcValue = new List<double> { Action.ColorBlob.AreaActual };
                        Action.WidthActual.rtcValue = new List<double> { Action.ColorBlob.WidthActual };
                        Action.HeightActual.rtcValue = new List<double> { Action.ColorBlob.HeightActual };
                        Action.ColumnActual.rtcValue = new List<double> { Action.ColorBlob.ColumnActual };
                        Action.RowActual.rtcValue = new List<double> { Action.ColorBlob.RowActual };
                        Action.Passed.rtcValue = Action.ColorBlob.Passed;
                        Action.NumberOfBlobsFound.rtcValue = new List<double> { Action.ColorBlob.NumberOfBlobsFound };
                        if (Action.ViewInfo != null)
                            ((ucBaseActionDetail)Action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                        break;
                    }
                case EActionTypes.ColorBlobMultipleROI:
                    {
                        if (Action.ColorBlobMultiROIS == null) return;
                        Action.BlobView.PositionMouse = SmartWindow.PointImage;
                        Action.BlobView.ClickMouse();
                        Action.AreaActual.rtcValue = new List<double> { Action.BlobView.AreaActual };
                        Action.WidthActual.rtcValue = new List<double> { Action.BlobView.WidthActual };
                        Action.HeightActual.rtcValue = new List<double> { Action.BlobView.HeightActual };
                        Action.OuterRadiusActual.rtcValue = new List<double> { Action.BlobView.OuterRadiusActual };
                        Action.Passed.rtcValue = Action.BlobView.Passed;
                        //Action.NumberOfBlobsFound.rtcValue = new List<double> { Action.BlobView.NumberOfBlobsFound };
                        if (Action.ViewInfo != null)
                            ((ucBaseActionDetail)Action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                        break;
                    }
            }
            if (Action.OutputBlobList == null || e == null)
                return;
        }
        private void mnuMultiSelect_Click(object sender, EventArgs e)
        {
            MultiSelect();
        }
        private void MultiSelect()
        {
           if(_isMultiSelect)
            {
                _isMultiSelect = false;
                MultiSelect_RefreshControls();
                return;
            }
            _isMultiSelect = true;
            MultiSelect_RefreshControls();
        }
        private void btnMultiSelect_Click(object sender, EventArgs e)
        {
            mnuMultiSelect.PerformClick();
        }
        private void mnuAddRectang_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Rectang, EConnectTypes.None, rowRB, colRB);
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteROI();
            }
            catch (Exception ex)
            {
              
            }
        }
        private void DeleteROI()
        {
            try
            {
                if (_isMultiSelect)
                {
                    if (GetROIS() == null) return;
                    for (int i = 0; i < ListDataRoi.Count; i++)
                    {
                        ROIS.Remove(GlobFuncs.ConvertGuidToLong(ListDataRoi[i].Key));
                        Action.ROIProperties.Remove(GlobFuncs.ConvertGuidToLong(ListDataRoi[i].Key));
                        SmartWindow.CleraRoi(ListDataRoi[i].Key);
                    }
                    SetRoiTrainFlagValue();
                    SetROIs();
                }
                else if (SmartWindow.KeySelect != null)
                {
                    if (GetROIS() == null) return;
                    ROIS.Remove(GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect));
                    Action.ROIProperties.Remove(GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect));
                    SmartWindow.CleraRoi(SmartWindow.KeySelect);
                    SetRoiTrainFlagValue();
                    SetROIs();
                }
                
            }
            catch(Exception ex )
            {

            }
            
        }
        private void SetROIs()
        {
            if (Action != null &&
                 Action.ViewInfo != null &&
                 Action.ViewInfo.GetType().BaseType?.Name == nameof(ucBaseActionDetail))
            {
                if (Action.ShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnROI.Font.Bold)
                {
                    Action.ROIs = ROIS;
                }
                else if (Action.FindShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnPass.Font.Bold)
                    Action.FindROIs = ROIS;
            }
        }
        private void SetRoiTrainFlagValue()
        {
            Action.Pattern_ROITrain_Find = GlobVar.Draw;
            Action.CorrelationPattern_ROITrain_Find = GlobVar.Draw;
            Action.Blob_ROITrain_Roi = GlobVar.Draw;
            Action.Brightness_ROITrain_ROI = GlobVar.Draw;
            Action.ImageSplit_ROITrain_ROI = GlobVar.Draw;
            Action.PixelCount_ROITrain_ROI = GlobVar.Draw;
            Action.LineFind_ROITrain_ROI = GlobVar.Draw;
            Action.ColorBlob_ROITrain_Find = GlobVar.Draw;
            Action.ColorBlob_ROITrain_ROI = GlobVar.Draw;
            Action.Calibrate_ROITrain_ROI = GlobVar.Draw;
            Action.Origin_ROITrain_ROI = GlobVar.Draw;
            Action.CodeReader_ROITrain_ROI = GlobVar.Draw;
            Action.OCR_ROITrain_Find = GlobVar.Draw;
            Action.AffineImage_ROITrain_ROI = GlobVar.Draw;
            Action.DeformablePattern_ROITrain_Find = GlobVar.Draw;
            Action.VariationModel_ROITrain_Find = GlobVar.Draw;
            Action.VariationModel_ROITrain_ROI = GlobVar.Draw;
        }
        private void mnuAddRectang1_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Rectang1, EConnectTypes.None, rowRB, colRB);
        }
        private void mnuAddRectang_Diff_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Rectang, EConnectTypes.Different, rowRB, colRB);
        }
        private void mnuAddRectang1_Diff_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Rectang1, EConnectTypes.Different, rowRB, colRB);
        }
        private void mnuAddRectang_I_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Rectang, EConnectTypes.Intersection, rowRB, colRB);
        }
        private void mnuAddRectang1_I_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Rectang1, EConnectTypes.Intersection, rowRB, colRB);
        }
        private void mnuAddRectang_U_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Rectang, EConnectTypes.Union, rowRB, colRB);
        }
        private void mnuAddRectang1_U_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Rectang1, EConnectTypes.Union, rowRB, colRB);
        }
        private void mnuAddCircle_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Ellipse, EConnectTypes.None, rowRB, colRB);
        }
        public void ResetImage()
        {
            SmartWindow.ClearImage();
           // SmartWindow.cl();
        }

        internal void ClearAllRoi()
        {
            SmartWindow.ClearAllRoi();
            DrawingObjects = new Dictionary<long, GraphicsWindow.GraphicsWindow.DataRoi>();
            //SmartWindow.ClearImage();
        }
        private void mnuAddCircle_Diff_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Ellipse, EConnectTypes.Different, rowRB, colRB);
        }
        private void mnuAddCircle_I_Click(object sender, EventArgs e)
        {
            AddShape(EDrawingtypes.Ellipse, EConnectTypes.Intersection, rowRB, colRB);
        }
        internal void ReviewAllROIS(bool _OnlycalcShapeList = false, bool isViewResult = false)
        {
            if (GlobVar.GroupActions.IsRun)
                return;
            if (Action != null &&
                Action.ViewInfo != null &&
                Action.ViewInfo.GetType().BaseType.Name == nameof(ucBaseActionDetail))
            {
                if (Action.ShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnROI.Font.Bold)
                    ReviewAllROIS_General(isViewResult);
                else if (Action.FindShapeList != null &&
                    ((ucBaseActionDetail)Action.ViewInfo).btnPass.Font.Bold)
                    ReviewAllROIS_PassFail(isViewResult);
            }
            else if (Action.ActionType == EActionTypes.MainAction &&
                GlobVar.GroupActions.IsMasterMode)
              ReviewAllROIS_Master();
            if (_OnlycalcShapeList)
                CalcRegions_OnlyCalcShapeList();
                
            else
                CalcRegions();

        }
        private void CalcRegions_OnlyCalcShapeList()
        {
            if (Action != null && Action.ViewInfo != null &&
                Action.ViewInfo.GetType().BaseType.Name == nameof(ucBaseActionDetail))
            {
                if (Action.ShapeList != null && ((ucBaseActionDetail)Action.ViewInfo).btnROI.Font.Bold)
                    //CalcRegions_OnlyCalcShapeList_General();
                    return;
            }    
        }
        
        private void ReviewAllROIS_General(bool isViewResult)
        {
            if (Action == null || Action.ActionType == EActionTypes.MainAction || Image == null) return;
            cROIProperty crp = Action.GetROIPropertiesSelected();
            if (Action.ROIs != null && Action.ROIs.Count > 0)
            {
                Dictionary<long, object> pROIs = new Dictionary<long, object>();
                List<GraphicsWindow.GraphicsWindow.DataRoi> ListRoi = new List<GraphicsWindow.GraphicsWindow.DataRoi>();
                foreach (object ROI in Action.ROIs.Values)
                {
                    cDrawingBaseType ROIB = (cDrawingBaseType)ROI;
                    long OldID = ROIB.ID;
                    switch (ROIB.DrawingType)
                    {
                        case EDrawingtypes.Rectang:
                            {
                                cRectangType Rec = (cRectangType)ROI;
                                GraphicsWindow.GraphicsWindow.DataRoi DataRoi = new GraphicsWindow.GraphicsWindow.DataRoi();
                                DataRoi.Angle = (float)Rec.Phi;
                                DataRoi.ShapeWidth = (float)Rec.Width;
                                DataRoi.ShapeHeight = (float)Rec.Height;
                                DataRoi.Key = GlobFuncs.ConvertLongToGuid(Rec.ID);
                                DataRoi.ConnectType = (GraphicsWindow.GraphicsWindow.EConnectTypes)Rec.ConnectType;
                                DataRoi.CenterPointX = (float)Rec.Center.Row;
                                DataRoi.CenterPointY = (float)Rec.Center.Col;
                                DataRoi.ColorRoi = ROIB.Color;
                           
                                DataRoi.RoiType = GraphicsWindow.GraphicsWindow.ERoiTypes.Rectangle;// quân sửa
                                DrawingObjects.Add(Rec.ID, DataRoi);
                                ListRoi.Add(DataRoi);
                                //SmartWindow.DrawROI(DataRoi);
                                if (DrawingObjects.Count == 1)
                                {
                                    CurrentDrawingObject = DrawingObjects[Rec.ID];
                                }
                                //else if (DrawingObjects.Count >= 1 && crp != null && crp.ID == OldID)
                                //{
                                //    CurrentDrawingObject = DrawingObjects[Rec.ID];
                                //}
                                break;
                            }
                        case EDrawingtypes.Ellipse:
                            {
                                cEllipseType Ell = (cEllipseType)ROI;
                                GraphicsWindow.GraphicsWindow.DataRoi DataRoi = new GraphicsWindow.GraphicsWindow.DataRoi();
                                DataRoi.Angle = (float)Ell.Phi;
                                DataRoi.ShapeWidth = (float)Ell.Radius1;
                                DataRoi.ShapeHeight = (float)Ell.Radius2;
                                DataRoi.Key = GlobFuncs.ConvertLongToGuid(Ell.ID);
                                DataRoi.ConnectType = (GraphicsWindow.GraphicsWindow.EConnectTypes)Ell.ConnectType;
                                DataRoi.CenterPointX = (float)Ell.Center.Row;
                                DataRoi.CenterPointY = (float)Ell.Center.Col;
                                DataRoi.ColorRoi = ROIB.Color;
                            
                                DataRoi.RoiType = GraphicsWindow.GraphicsWindow.ERoiTypes.Circle;// quân sửa
                                DrawingObjects.Add(Ell.ID, DataRoi);
                                ListRoi.Add(DataRoi);
                                //SmartWindow.DrawROI(DataRoi);
                               
                                if (DrawingObjects.Count == 1)
                                {
                                    CurrentDrawingObject = DrawingObjects[Ell.ID];
                                }
                                //else if (DrawingObjects.Count >= 1 && crp != null && crp.ID == OldID)
                                //{
                                //    CurrentDrawingObject = DrawingObjects[Ell.ID];
                                //}
                                break;
                            }
                    }
                }
                SmartWindow.DrawROI(ListRoi);
                SwitchRoi();
            }
            else
                Action.ROIs = new Dictionary<long, object>();
            //{
            //    Dictionary<long, object> pROIS = new Dictionary<long, object>();
            //    foreach (object ROI in ROIS.Values.ToList())
            //    {
            //        //ListData_ROI.Add((GraphicsWindow.GraphicsWindow.DataRoi)ROI);
            //        cRectangType ROIB = (cRectangType)ROI;
            //        long Old = ROIB.ID;
            //        switch (ROIB.DrawingType)
            //        {

            //            case EDrawingtypes.Rectang:
            //                GraphicsWindow.GraphicsWindow.DataRoi dataROI = new GraphicsWindow.GraphicsWindow.DataRoi();
            //                dataROI.Key = GlobFuncs.ConvertLongToGuid(ROIB.ID);
            //                dataROI.Angle = (float)ROIB.Phi;
            //                dataROI.CenterPointX = (float)ROIB.Center.Row;
            //                dataROI.CenterPointY = (float)ROIB.Center.Col;
            //                dataROI.ShapeWidth = (float)ROIB.Width;
            //                dataROI.ShapeHeight = (float)ROIB.Height;
            //                dataROI.RoiType = (GraphicsWindow.GraphicsWindow.ERoiTypes)ROIB.RoiType;
            //                dataROI.ConnectType = (GraphicsWindow.GraphicsWindow.EConnectTypes)ROIB.ConnectType;
            //                dataROI.ColorRoi = ROIB.Color;
            //                SmartWindow.AddRoi(dataROI);
            //                break;
            //        }
            //    }
            //}

        }
        private void ReviewAllROIS_PassFail(bool isViewResult)
        {
            if (Action == null || Action.ActionType == EActionTypes.MainAction || Image == null) return;
            if (Action.FindROIs != null && Action.FindROIs.Count > 0)
            {
                Dictionary<long, object> pROIs = new Dictionary<long, object>();
                List<GraphicsWindow.GraphicsWindow.DataRoi> ListRoi = new List<GraphicsWindow.GraphicsWindow.DataRoi>();
                foreach (object ROI in Action.FindROIs.Values)
                {
                    cDrawingBaseType ROIB = (cDrawingBaseType)ROI;
                    long OldID = ROIB.ID;
                    switch (ROIB.DrawingType)
                    {
                        case EDrawingtypes.Rectang:
                            {
                                cRectangType Rec = (cRectangType)ROI;
                                GraphicsWindow.GraphicsWindow.DataRoi DataRoi = new GraphicsWindow.GraphicsWindow.DataRoi();
                                DataRoi.Angle = (float)Rec.Phi;
                                DataRoi.ShapeWidth = (float)Rec.Width;
                                DataRoi.ShapeHeight = (float)Rec.Height;
                                DataRoi.Key = GlobFuncs.ConvertLongToGuid(Rec.ID);
                                DataRoi.ConnectType = (GraphicsWindow.GraphicsWindow.EConnectTypes)Rec.ConnectType;
                                DataRoi.CenterPointX = (float)Rec.Center.Row;
                                DataRoi.CenterPointY = (float)Rec.Center.Col;
                                DataRoi.ColorRoi = ROIB.Color;
                                DataRoi.RoiType = GraphicsWindow.GraphicsWindow.ERoiTypes.Rectangle;
                                DrawingObjects.Add(Rec.ID, DataRoi);
                                ListRoi.Add(DataRoi);
                                //SmartWindow.DrawROI(DataRoi);
                                if (DrawingObjects.Count == 1)
                                {
                                    CurrentDrawingObject = DrawingObjects[Rec.ID];
                                }
                                break;
                            }
                        case EDrawingtypes.Ellipse:
                            {
                                cEllipseType Ell = (cEllipseType)ROI;
                                 GraphicsWindow.GraphicsWindow.DataRoi DataRoi = new GraphicsWindow.GraphicsWindow.DataRoi();
                                DataRoi.Angle = (float)Ell.Phi;
                                DataRoi.ShapeWidth = (float)Ell.Radius1;
                                DataRoi.ShapeHeight = (float)Ell.Radius2;
                                DataRoi.Key = GlobFuncs.ConvertLongToGuid(Ell.ID);
                                DataRoi.ConnectType = (GraphicsWindow.GraphicsWindow.EConnectTypes)Ell.ConnectType;
                                DataRoi.CenterPointX = (float)Ell.Center.Row;
                                DataRoi.CenterPointY = (float)Ell.Center.Col;
                                DataRoi.ColorRoi = ROIB.Color;
                                DataRoi.RoiType = GraphicsWindow.GraphicsWindow.ERoiTypes.Circle;
                                DrawingObjects.Add(Ell.ID, DataRoi);
                                ListRoi.Add(DataRoi);
                                //SmartWindow.DrawROI(DataRoi);
                                if (DrawingObjects.Count == 1)
                                {
                                    CurrentDrawingObject = DrawingObjects[Ell.ID];
                                }
                                break;
                            }
                    }
                }
                SmartWindow.DrawROI(ListRoi);
                SwitchRoi();
            }
            else
                Action.FindROIs = new Dictionary<long, object>();
            //{
            //    Dictionary<long, object> pROIS = new Dictionary<long, object>();
            //    foreach (object ROI in ROIS.Values.ToList())
            //    {
            //        //ListData_ROI.Add((GraphicsWindow.GraphicsWindow.DataRoi)ROI);
            //        cRectangType ROIB = (cRectangType)ROI;
            //        long Old = ROIB.ID;
            //        switch (ROIB.DrawingType)
            //        {

            //            case EDrawingtypes.Rectang:
            //                GraphicsWindow.GraphicsWindow.DataRoi dataROI = new GraphicsWindow.GraphicsWindow.DataRoi();
            //                dataROI.Key = GlobFuncs.ConvertLongToGuid(ROIB.ID);
            //                dataROI.Angle = (float)ROIB.Phi;
            //                dataROI.CenterPointX = (float)ROIB.Center.Row;
            //                dataROI.CenterPointY = (float)ROIB.Center.Col;
            //                dataROI.ShapeWidth = (float)ROIB.Width;
            //                dataROI.ShapeHeight = (float)ROIB.Height;
            //                dataROI.RoiType = (GraphicsWindow.GraphicsWindow.ERoiTypes)ROIB.RoiType;
            //                dataROI.ConnectType = (GraphicsWindow.GraphicsWindow.EConnectTypes)ROIB.ConnectType;
            //                dataROI.ColorRoi = ROIB.Color;
            //                SmartWindow.AddRoi(dataROI);
            //                break;
            //        }
            //    }
            //}

        }
        private void ReviewAllROIS_Master(bool isViewResult = false)
        {
            if (Action == null || Action.ActionType == EActionTypes.MainAction || !GlobVar.GroupActions.IsMasterMode) return;
            if (Action.ROIs != null && Action.ROIs.Count > 0)
            {
                Dictionary<long, object> pROIs = new Dictionary<long, object>();
                List<GraphicsWindow.GraphicsWindow.DataRoi> ListRoi = new List<GraphicsWindow.GraphicsWindow.DataRoi>();
                foreach (object ROI in Action.ROIs.Values)
                {
                    cDrawingBaseType ROIB = (cDrawingBaseType)ROI;
                    long OldID = ROIB.ID;
                    switch (ROIB.DrawingType)
                    {
                        case EDrawingtypes.Rectang:
                            {
                                cRectangType Rec = (cRectangType)ROI;
                                GraphicsWindow.GraphicsWindow.DataRoi DataRoi = new GraphicsWindow.GraphicsWindow.DataRoi();
                                DataRoi.Angle = (float)Rec.Phi;
                                DataRoi.ShapeWidth = (float)Rec.Width;
                                DataRoi.ShapeHeight = (float)Rec.Height;
                                DataRoi.Key = GlobFuncs.ConvertLongToGuid(Rec.ID);
                                DataRoi.ConnectType = (GraphicsWindow.GraphicsWindow.EConnectTypes)Rec.ConnectType;
                                DataRoi.CenterPointX = (float)Rec.Center.Row;
                                DataRoi.CenterPointY = (float)Rec.Center.Col;
                                DataRoi.ColorRoi = ROIB.Color;
                                DrawingObjects.Add(Rec.ID, DataRoi);
                                ListRoi.Add(DataRoi);
                                //SmartWindow.DrawROI(DataRoi);
                                if (DrawingObjects.Count == 1)
                                {
                                    CurrentDrawingObject = DrawingObjects[Rec.ID];
                                }
                                break;
                            }
                        case EDrawingtypes.Ellipse:
                            {
                                cEllipseType Ell = (cEllipseType)ROI;
                                GraphicsWindow.GraphicsWindow.DataRoi DataRoi = new GraphicsWindow.GraphicsWindow.DataRoi();
                                DataRoi.Angle = (float)Ell.Phi;
                                DataRoi.ShapeWidth = (float)Ell.Radius1;
                                DataRoi.ShapeHeight = (float)Ell.Radius2;
                                DataRoi.Key = GlobFuncs.ConvertLongToGuid(Ell.ID);
                                DataRoi.ConnectType = (GraphicsWindow.GraphicsWindow.EConnectTypes)Ell.ConnectType;
                                DataRoi.CenterPointX = (float)Ell.Center.Row;
                                DataRoi.CenterPointY = (float)Ell.Center.Col;
                                DataRoi.ColorRoi = ROIB.Color;
                                DrawingObjects.Add(Ell.ID, DataRoi);
                                ListRoi.Add(DataRoi);
                                //SmartWindow.DrawROI(DataRoi);
                                if (DrawingObjects.Count == 1)
                                {
                                    CurrentDrawingObject = DrawingObjects[Ell.ID];
                                }
                                break;
                            }
                    }
                }
                SmartWindow.DrawROI(ListRoi);
                SwitchRoi();
            }
            else
                Action.ROIs = new Dictionary<long, object>();
            //{
            //    Dictionary<long, object> pROIS = new Dictionary<long, object>();
            //    foreach (object ROI in ROIS.Values.ToList())
            //    {
            //        //ListData_ROI.Add((GraphicsWindow.GraphicsWindow.DataRoi)ROI);
            //        cRectangType ROIB = (cRectangType)ROI;
            //        long Old = ROIB.ID;
            //        switch (ROIB.DrawingType)
            //        {

            //            case EDrawingtypes.Rectang:
            //                GraphicsWindow.GraphicsWindow.DataRoi dataROI = new GraphicsWindow.GraphicsWindow.DataRoi();
            //                dataROI.Key = GlobFuncs.ConvertLongToGuid(ROIB.ID);
            //                dataROI.Angle = (float)ROIB.Phi;
            //                dataROI.CenterPointX = (float)ROIB.Center.Row;
            //                dataROI.CenterPointY = (float)ROIB.Center.Col;
            //                dataROI.ShapeWidth = (float)ROIB.Width;
            //                dataROI.ShapeHeight = (float)ROIB.Height;
            //                dataROI.RoiType = (GraphicsWindow.GraphicsWindow.ERoiTypes)ROIB.RoiType;
            //                dataROI.ConnectType = (GraphicsWindow.GraphicsWindow.EConnectTypes)ROIB.ConnectType;
            //                dataROI.ColorRoi = ROIB.Color;
            //                SmartWindow.AddRoi(dataROI);
            //                break;
            //        }
            //    }
            //}

        }

        //private void UpdateIDForShapeList (long _OldID, long _newID, )
        private void mnuClearAll_Click(object sender, EventArgs e)
        {
            SmartWindow.ClearAllRoi();
            if (ROIS != null)
            ROIS.Clear();
        }
        private void mnuAddRectangSub_Click(object sender, EventArgs e)
        {

        }
        private void mnuIsViewMasterRoi_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void SmartWindow_MouseClick(object sender, MouseEventArgs e)
        {
            //CurrentDrawingObject = DrawingObjects.FirstOrDefault(x => x.Key == GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)).Value;
            //cRectangType ROISelected = new cRectangType();
            //cEllipseType ROICircleSelected = new cEllipseType();

            //if (Action != null && Action.ROIs != null && Action.ROIs.Count > 0 && SmartWindow.ListDataRoiOutput.Count > 0)
            //{
            //    if (CurrentDrawingObject.RoiType == GraphicsWindow.GraphicsWindow.ERoiTypes.Circle)
            //    {
            //        ROICircleSelected = ((cEllipseType)Action.ROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)]);
            //        var DataRoiSelected = SmartWindow.ListDataRoiOutput.Find(X => X.Key == SmartWindow.KeySelect);
            //        ROICircleSelected.Center.Col = DataRoiSelected.CenterPointY;
            //        ROICircleSelected.Center.Row = DataRoiSelected.CenterPointX;
            //        ROICircleSelected.Radius2 = DataRoiSelected.ShapeHeight;
            //        ROICircleSelected.Radius1 = DataRoiSelected.ShapeWidth;
            //        ROICircleSelected.Phi = DataRoiSelected.Angle;
            //        ROICircleSelected.ConnectType = (EConnectTypes)DataRoiSelected.ConnectType;
            //        ROICircleSelected.DrawingType = (EDrawingtypes)DataRoiSelected.RoiType;
            //        ROICircleSelected.ID = GlobFuncs.ConvertGuidToLong(DataRoiSelected.Key);
            //        ROICircleSelected.Color = DataRoiSelected.ColorRoi;
            //        Action.ROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)] = ROICircleSelected;
            //    }
            //    else
            //    {
            //        ROISelected = ((cRectangType)Action.ROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)]);
            //        var DataRoiSelected = SmartWindow.ListDataRoiOutput.Find(X => X.Key == SmartWindow.KeySelect);
            //        ROISelected.Center.Col = DataRoiSelected.CenterPointY;
            //        ROISelected.Center.Row = DataRoiSelected.CenterPointX;
            //        ROISelected.Height = DataRoiSelected.ShapeHeight;
            //        ROISelected.Width = DataRoiSelected.ShapeWidth;
            //        ROISelected.Phi = DataRoiSelected.Angle;
            //        ROISelected.ConnectType = (EConnectTypes)DataRoiSelected.ConnectType;
            //        ROISelected.DrawingType = (EDrawingtypes)DataRoiSelected.RoiType;
            //        ROISelected.ID = GlobFuncs.ConvertGuidToLong(DataRoiSelected.Key);
            //        ROISelected.Color = DataRoiSelected.ColorRoi;
            //        Action.ROIs[GlobFuncs.ConvertGuidToLong(SmartWindow.KeySelect)] = ROISelected;
            //    }
            //}
            //if (e.Button == MouseButtons.Middle && mnuMultiSelect.Visible == true)
            //    mnuMultiSelect.PerformClick();
            //if (isCustomDraw)
            //{
            //    ControlPaint.DrawReversibleFrame(new Rectangle(PointToScreen(SelectionRectangle.Location), SelectionRectangle.Size), BackColor, FrameStyle.Dashed);
            //    Invalidate();
            //}
            //else
            //

            //    Point mnuLocation = GraphicsWindow.GraphicsWindow.MousePosition;
            //    Point NewRoiLocation = new Point((int)SmartWindow.PointImage.X, (int)SmartWindow.PointImage.Y);
            //    rowRB = NewRoiLocation.X;
            //    colRB = NewRoiLocation.Y;
            //    if (e.Button == MouseButtons.Right && GlobVar.Draw)
            //        mnuMenuShape.Show(mnuLocation);
            //    else if (!_isGetPossition)
            //        GetRegionInMousePoint(e);


            //}
            //if (CurrentDrawingObject != null)
            //    SwitchRoi();

        }

        private void mnuCopyROI_Click(object sender, EventArgs e)
        {
            CopyROI();
        }
        private void mnuPatseRoi_Click(object sender, EventArgs e)
        {
            PasteROI();
        }
        private void CopyROI()
        {
            ROICopy = new List<object>();
            btnPaste.Enabled = (ROICopy != null && ROICopy.Count > 0);
            if (CurrentDrawingObject == null) return;
            object copyROI = GetROI(CurrentDrawingObject.Key);
            if (copyROI != null)
                ROICopy.Add(copyROI);
            if (_multiDrawingObjects != null && _multiDrawingObjects.Count > 0)
                foreach (GraphicsWindow.GraphicsWindow.DataRoi drawingObject in _multiDrawingObjects.Values)
                {
                    copyROI = GetROI(drawingObject.Key);
                    if (copyROI != null && drawingObject.Key != currentDrawingObject.Key)
                        ROICopy.Add(copyROI);
                }
            btnPaste.Enabled = (ROICopy != null && ROICopy.Count > 0);
        }    
        private void PasteROI (bool isLink = false, bool isOrigin = false)
        {
            GetExtend(currentDrawingObject, out extendDataCopy);
            foreach (object @object in ROICopy)
            {
                cDrawingBaseType ROI = (cDrawingBaseType)@object;

                if (isOrigin)
                    AddShape(ROI.DrawingType, ROI.ConnectType, ROI.Center.Row, ROI.Center.Col,
                        EAnimationTypes.e2D, true, isLink, true, @object, ROI.RoiType);
                else
                    AddShape(ROI.DrawingType, ROI.ConnectType,
                                ROI.Center.Row + extendDataCopy.Row,
                                ROI.Center.Col + extendDataCopy.Col,
                                EAnimationTypes.e2D, true, isLink, true, @object, ROI.RoiType);
            }
        }    
        private void GetExtend(GraphicsWindow.GraphicsWindow.DataRoi oldDrawingObject,
            out cExtendData extend)
        {
            extend = new cExtendData();
            if (oldDrawingObject == null)
                return;
            if (ROIS != null && ROIS.TryGetValue(GlobFuncs.ConvertGuidToLong(oldDrawingObject.Key), out object value))
            {
                cDrawingBaseType drawingBase = (cDrawingBaseType)value;
                extend.Row = rowRB - drawingBase.Center.Row;
                extend.Col = colRB - drawingBase.Center.Col;
            }    
        }

        private void mnuChangeName_Click(object sender, EventArgs e)
        {
            if (CurrentDrawingObject == null || GlobVar.GroupActions == null)
                return;
            //Lấy ra roi hiện tại
            if (GetROIS() == null) return;
            if (ROIS.TryGetValue(GlobFuncs.ConvertGuidToLong(CurrentDrawingObject.Key), out object currentROI))
            {
                cDrawingBaseType currentBaseType = (cDrawingBaseType)currentROI;
                FrmInputTextValue frmInputTextValue = new FrmInputTextValue();
                frmInputTextValue.RTCKey = currentBaseType.ID.ToString();
                frmInputTextValue.RTCValue = currentBaseType.Name;
                frmInputTextValue.RTCIsAcceptEmptyValue = false;
                frmInputTextValue.OnBeforeCheckValueEvents -= OnBeforeCheckValueEvents_ROI;
                frmInputTextValue.OnBeforeCheckValueEvents += OnBeforeCheckValueEvents_ROI;
                if (frmInputTextValue.ShowDialog() == DialogResult.OK)
                {
                    currentBaseType.Name = frmInputTextValue.RTCValue;
                    SetRoiTrainFlagValue();
                    SetROIs();
                    CalcRegions();
                }
            }
        }
        private void OnBeforeCheckValueEvents_ROI(ref bool isAccept, string key, string inputValue)
        {
            isAccept = false;
            if (GetROIS() == null) return;

            if (ROIS != null)
            {
                if (long.TryParse(key, out long roiID))
                    foreach (object value in ROIS.Values)
                    {
                        cDrawingBaseType drawingBaseType = (cDrawingBaseType)value;
                        if (drawingBaseType.ID == roiID)
                            continue;
                        else if (drawingBaseType.Name.Trim().ToLower() == inputValue.Trim().ToLower())
                        {
                            cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists, new[] { "roi name" }, new[] { "Tên roi" }));
                            return;
                        }
                    }
            }
            isAccept = true;
        }

        
    }
}
