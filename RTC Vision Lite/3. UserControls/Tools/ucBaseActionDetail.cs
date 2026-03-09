//using CommonTools;
using RTC_Vision_Lite.Commons;
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
using BrightIdeasSoftware;
using System.Collections;
using System.IO.Ports;
using System.Windows.Forms.VisualStyles;
using RTC_Vision_Lite.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Runtime.CompilerServices;
using CommonTools;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucBaseActionDetail : UserControl
    {
        public event ButtonLinkEndSelectedPropertyLinkEvent OnButtonLinkEndSelectedPropertyLinkEvent;
        public event PropertiesRowCellClick OnPropertiesRowCellClickbtnLink;
        public event PropertiesRowCellClick OnPropertiesRowCellClickbtnRemoveLink;
        public event PropertyValueChanged OnPropertyValueChanged;


        public StringBuilderDetail_BtnLinkClickEvent OnStringBuiderDetail_BtnLinkClickEvent;
        public StringBuilderDetail_BtnRemoveLinkClickEvent OnStringBuiderDetail_BtnRemoveLinkClickEvent;
        public CsvWriteDetail_BtnLinkValueClickEvent OnCsvWriteBtnLinkValueClickEvent;
        public ExcelWriteDetail_BtnLinkValueClickEvent OnExcelWriteBtnLinkValueClickEvent;


        private bool ShowEditor;
        public ucBaseActionDetail()
        {

            //tlvAction.GridLines = false;
            OLVColumn buttonColumn = new OLVColumn();

            // buttonColumn.AspectName = "YourAspectName";
            InitializeComponent();
            PageSetup.SelectedTab = General;
            HideShowPropertiesButtonByActionType();
            //HeaderFormatStyle headerFormatStyle = new HeaderFormatStyle();
            //headerFormatStyle.SetBackColor(Color.LightSlateGray);
            ////tlvAction.GridLines = true;
            //tlvAction.HeaderFormatStyle = headerFormatStyle;
            //tlvAction.OwnerDraw = true;
            //tlvAction.OwnerDrawnHeader = true;
            //tlvAction.BorderStyle = BorderStyle.
            //colRefIndex.AspectToStringConverter = delegate (object x) { return "Click me"; };
            SetEventCustomCellStyle();
            SetEffectButtonMain();
            var c = GlobFuncs.GetAll(this, typeof(Label), "lblSetupPassed", false);
            if (c != null && c.Any())
            {
                Label label = (Label)c.First();
                label.Visible = !Action.RunOnlyROISelected;
                c = GlobFuncs.GetAll(this, typeof(TextBox), "RTCName", false);
                if (c != null && c.Any())
                {
                    TextBox textBox = (TextBox)c.First();
                    textBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    textBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                }
                c = GlobFuncs.GetAll(this, typeof(ucImageLink), "ucImageLink", false);
                if (c != null && c.Any())
                {
                    ucImageLink imageLink = (ucImageLink)c.First();
                    imageLink.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    imageLink.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                }
                c = GlobFuncs.GetAll(this, typeof(ucOrigin), "ucOrigin", false);
                if (c != null && c.Any())
                {
                    ucOrigin origin = (ucOrigin)c.First();
                    origin.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    origin.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                }
            }

           // tlvAction.DrawColumnHeader += tlvAction_DrawColumnHeader;
            tlvAction.DrawSubItem += treeListView1_DrawSubItem;

        }
        private void tlvAction_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (Brush backgroundBrush = new SolidBrush(Color.LightGray))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            // Thiết lập vùng padding cho văn bản tiêu đề để tránh dính sát viền.
            Rectangle textBounds = new Rectangle(
                e.Bounds.X + 5, e.Bounds.Y,
                e.Bounds.Width - 10, e.Bounds.Height);

            // Vẽ văn bản tiêu đề, căn giữa dọc và canh trái, với màu đen.
            TextRenderer.DrawText(
                e.Graphics,
                e.Header.Text,
                e.Font,
                textBounds,
                Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.VerticalCenter);

            // Vẽ đường kẻ giữa các tiêu đề cột, ngoại trừ cột cuối cùng.

            using (Pen borderPen = new Pen(Color.Gray))
            {
                Rectangle adjustedBounds = new Rectangle(
                    e.Bounds.X,
                    e.Bounds.Y,
                    e.Bounds.Width,
                    e.Bounds.Height - 1);

                e.Graphics.DrawRectangle(borderPen, adjustedBounds);
            }
            // Đặt DrawDefault thành true để giữ các hiệu ứng mặc định (nếu cần).
            e.DrawDefault = false;  // Có thể thử bật/tắt tùy nhu cầu.
        }
        private void treeListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Vẽ nội dung mặc định của ô
            e.DrawDefault = true;

            // Vẽ đường phân cách ở bên phải ô, ngoại trừ cột cuối cùng
            if (e.ColumnIndex < tlvAction.Columns.Count - 1)
            {
                using (Pen pen = new Pen(Color.Gray))
                {
                    int x = e.Bounds.Right - 1; // Vị trí của đường line
                    e.Graphics.DrawLine(pen, x, e.Bounds.Top, x, e.Bounds.Bottom);
                }
            }
        }

        private cAction _Action;
        [DefaultValue(null)]

        public cAction Action
        {
            get => _Action;
            set
            {
                _Action = value;
                CreateComboOperandTypes();
                ViewActionProperties();
                ViewActionLinkSummary();
                BindingDataToControls();
                HideShowPropertiesButtonByActionType();
                HideShowSetUpButtonByActionType();
                BindingDataToControls_SetActionToAllControlsNeedAction();
                //foreach(TreeNode Nodes in tlAct.Nodes )
                //{
                //    //Nodes.CheckBoxVisible
                //}    


            }
        }
        public void Resumelayout()
        {
            this.ResumeLayout();
        }
        public void SuspendLayOut()
        {
            this.SuspendLayout();
        }
        private bool _isRun;
        public bool IsRun
        {
            get => _isRun;
            set
            {
                _isRun = value;

                GlobFuncs.EnableControl(ScrollableGeneral, !_isRun);
                GlobFuncs.EnableControl(ScrollableROI, !_isRun);
                GlobFuncs.EnableControl(ScrollablePassFail, !_isRun);
                GlobFuncs.EnableControl(ScrollableEndPointAndType, !_isRun);
                GlobFuncs.EnableControl(ScrollableMethod, !_isRun);
                GlobFuncs.EnableControl(btnClearAll, !_isRun);
                GlobFuncs.EnableControl(btnSelectAll, !_isRun);
                GlobFuncs.EnableControl(btnRestoreDefault, !_isRun);
                GlobFuncs.EnableControl(btnRunAction, !_isRun);
                GlobFuncs.EnableControl(btnRun, !_isRun);
                GlobFuncs.EnableControl(chkIsCanEdit, !_isRun);
                // GlobFuncs.EnableControl(IsShowHightLightProperties, !_isRun);
                //GlobFuncs.EnableControl(popAp, !_isRun);
            }
        }

        private void HideShowSetUpButtonByActionType()
        {
            btnGeneral.Visible = false;
            btnMethod.Visible = false;
            btnROI.Visible = false;
            btnEndPoint.Visible = false;
            btnPass.Visible = false;
            btnDisplay.Visible = false;

            btnSEP1.Visible = false;
            btnSEP2.Visible = false;
            btnSEP3.Visible = false;
            btnSEP4.Visible = false;
            btnSEP5.Visible = false;
            if (Action == null)
                return;
            switch (Action.ActionType)
            {
                case EActionTypes.Blob:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnPass.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.GaugeDualROI:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnPass.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.PhotometricStereo:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Pattern:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.TrainRoi;
                        btnPass.Visible = true;
                        btnPass.Text = cStrings.SearchROIAndPassFail;
                        btnPass.Width = 200;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Metrology:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ROIAndPassFail;
                        btnROI.Width = 100;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.PixelCount:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ROIAndPassFail;
                        btnROI.Width = 100;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Brightness:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ROIAndPassFail;
                        btnROI.Width = 100;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.PassFail:
                    {
                        btnGeneral.Visible = true;
                        btnPass.Visible = true;
                        btnSEP4.Visible = true;

                        btnSEP6.Visible = true;
                        btnRunAction.Visible = true;
                        break;
                    }
                case EActionTypes.AffineImage:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnROI.Width = 80;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;

                        btnSEP6.Visible = true;
                        btnRunAction.Visible = true;
                        break;
                    }
                case EActionTypes.BlobMultipleROI:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ROIAndPassFail;
                        btnROI.Width = 100;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.StringBuilder:
                    {
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Inputs;
                        btnPass.Visible = true;
                        btnPass.Text = cStrings.Format;
                        btnDisplay.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        btnSEP6.Visible = true;
                        btnRunAction.Visible = true; ;
                        break;
                    }
                case EActionTypes.BlobFilter:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnROI.Width = 80;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.DistanceMeasurement:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = true;
                        btnPass.Text = cStrings.PassFail;
                        btnPass.Width = 200;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Math:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnROI.Width = 80;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.LineFind:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = true;
                        btnPass.Text = cStrings.PassFail;
                        btnPass.Width = 200;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ImageFilter:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnROI.Width = 80;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.RegionProcessing:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnROI.Width = 80;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Branch:
                    {
                        btnGeneral.Visible = true;


                        btnDisplay.Visible = true;

                        btnSEP6.Visible = true;
                        btnSEP5.Visible = true;
                        btnRunAction.Visible = true;
                        break;
                    }
                case EActionTypes.Switch:
                    {
                        btnGeneral.Visible = true;

                        btnDisplay.Visible = true;
                        btnSEP6.Visible = true;
                        btnRunAction.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.DataInstance:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP6.Visible = true;
                        btnRunAction.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.DataSet:
                    {
                        btnGeneral.Visible = true;

                        btnDisplay.Visible = true;
                        btnSEP6.Visible = true;
                        btnRunAction.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ChangeJob:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.BranchItem:
                    {
                        btnGeneral.Visible = true;
                        PageActionSetting.SelectedTab = TabProperties;
                        //if (GlobVar.GroupActions.Actions.TryGetValue(Action.IDBranch, out cAction branchAction))

                        break;
                    }
                case EActionTypes.ColorBlob:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnMethod.Visible = false;

                        btnPass.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP2.Visible = false;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CalibrateEdgetoEdge:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ROIAndPassFail;
                        btnROI.Width = 100;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP2.Visible = false;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.OCR:
                    {
                        btnGeneral.Visible = true;
                        btnPass.Visible = false;
                        btnPass.Text = cStrings.ROIAndPassFail;
                        btnPass.Width = 100;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP6.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CodeReader:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;

                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Alignment:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ManualAlignment:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.HandEye:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Count:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.PassFail;
                        btnROI.Width = 80;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.DataArchive:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Inputs;

                        btnPass.Visible = true;
                        btnPass.Text = cStrings.Destination;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.DataArchiveRead:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Source;
                        btnPass.Text = cStrings.Output;
                        btnPass.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.SLMPRead:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ReadData;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.SLMPWrite:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.SendData;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ModBusRead:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ReadData;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ModBusWrite:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.SendData;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.TCPIPRead:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ReadData;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.TCPIPWrite:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.SendData;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.UpdRead:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ReadData;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.UpdWrite:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.SnapImage:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ResetTool:
                    {
                        btnGeneral.Visible = true;
                        btnPass.Visible = true;
                        btnPass.Text = cStrings.ResetTools;

                        btnSEP4.Visible = true;
                        break;
                    }
                case EActionTypes.CalibrationCheckBoard:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ImageSetting;
                        btnROI.Width = 100;
                        btnPass.Visible = true;
                        btnPass.Text = cStrings.CalibrateSetting;
                        btnPass.Width = 100;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.PoseManipulation:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ImageArchive:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Destination;
                        btnROI.Width = 80;
                        btnSEP1.Visible = true;
                        break;
                    }
                case EActionTypes.SaveImage:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.LoadConfig:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.SaveObject:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.LoadObject:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Origin:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = true;
                        btnPass.Text = cStrings.PassFail;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP2.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.DeformablePattern:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.TrainRoi;
                        btnPass.Visible = true;
                        btnPass.Text = cStrings.SearchROIAndPassFail;
                        btnPass.Width = 200;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        btnSEP6.Visible = true;
                        btnRunAction.Visible = true;
                        break;
                    }
                case EActionTypes.ImageMath:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnROI.Width = 80;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.RunProgram:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.LinkValue:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CounterLoop:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ImageSplit:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnROI.Width = 80;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.SendMessage:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnROI.Width = 80;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.LiveCam:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.StopLiveCam:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CycleTimeStart:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CycleTimeStop:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Return:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ColorBlobMultipleROI:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ROIAndPassFail;
                        btnROI.Width = 100;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.RunDLL:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Wait:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.SystemInfo:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.SaveProject:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Stop:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.RunDeep:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.HookKeyboard:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.COMReader:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.COMWriter:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CSTLightRead:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CSTLightWrite:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.DialogMessage:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.FTPUpload:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.FTPDownload:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.VariationModel:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnROI.Width = 200;
                        btnPass.Visible = true;
                        btnPass.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CorrelationPattern:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.TrainRoi;
                        btnPass.Visible = true;
                        btnPass.Text = cStrings.SearchROIAndPassFail;
                        btnPass.Width = 200;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        btnSEP6.Visible = true;
                        btnRunAction.Visible = true;
                        break;
                    }
                case EActionTypes.ViewResult:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.LoadImage:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.DetectFileStatus:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ViewText:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.DrawingROI:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CameraSettings:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.OpticalFlowImage:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        btnSEP6.Visible = true;
                        btnRunAction.Visible = true;
                        break;
                    }
                case EActionTypes.RunCommand:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;

                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;

                        btnSEP5.Visible = true;
                        break;
                    }
               
                case EActionTypes.ClearWindows:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.WindownSettings:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CsvWrite:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.ExcelWrite:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.OkNgCounter:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.CameraIOReader:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.Script:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.MXComponentRead:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.ReadData;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.MXComponentWrite:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.SendData;
                        btnPass.Visible = false;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.SaveConfig:
                    {
                        btnGeneral.Visible = true;
                        btnROI.Visible = true;
                        btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP1.Visible = true;
                        btnSEP4.Visible = false;
                        btnSEP5.Visible = true;
                        break;
                    }

                case EActionTypes.IOControllerRead:
                    {
                        btnGeneral.Visible = true;
                        //btnROI.Visible = true;
                        //btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        //btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.IOControllerWrite:
                    {
                        btnGeneral.Visible = true;
                        //btnROI.Visible = true;
                        //btnROI.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        //btnSEP1.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.AdlinkIOReader:
                case EActionTypes.AdlinkIOWriter:
                    {
                        btnGeneral.Visible = true;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.POCIORead:
                    {
                        btnGeneral.Visible = true;
                        btnGeneral.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                case EActionTypes.POCIOWrite:
                    {
                        btnGeneral.Visible = true;
                        btnGeneral.Text = cStrings.Setting;
                        btnDisplay.Visible = true;
                        btnSEP5.Visible = true;
                        break;
                    }
                //case EActionTypes.PassFail:
                //    {
                //        btnGeneral.Visible = true;
                //        btnPass.Visible = true;
                //        btnSEP4.Visible = true;

                //        btnSEP6.Visible = true;
                //        btnRunAction.Visible = true;
                //        break;
                //    }
                case EActionTypes.None:

                    break;
                default:
                    break;

            }


        }

        internal void RefreshPropertiesList()
        {
            tlvAction.Invoke(new Action(() =>
            {
                tlvAction.Refresh();
            }));
        }

        public class cButtonName
        {
            public const string btnTest = "btnTest";
        }
        internal void CloseAllConnectionInControls()
        {
            if (Action.ActionType == EActionTypes.TCPIPRead ||
                Action.ActionType == EActionTypes.TCPIPWrite ||
                Action.ActionType == EActionTypes.UpdRead ||
                Action.ActionType == EActionTypes.UpdWrite ||
                Action.ActionType == EActionTypes.CodeReader ||
                Action.ActionType == EActionTypes.COMReader ||
                Action.ActionType == EActionTypes.COMWriter ||
                Action.ActionType == EActionTypes.ModBusRead ||
                Action.ActionType == EActionTypes.ModBusWrite ||
                Action.ActionType == EActionTypes.IOControllerRead ||
                Action.ActionType == EActionTypes.IOControllerWrite ||
                Action.ActionType == EActionTypes.SLMPRead ||
                Action.ActionType == EActionTypes.SLMPWrite ||
                Action.ActionType == EActionTypes.CSTLightRead ||
                Action.ActionType == EActionTypes.CSTLightWrite ||
                Action.ActionType == EActionTypes.VSTLightWrite)
            {
                var c = GlobFuncs.GetAll(this, typeof(Button), cButtonName.btnTest);
                if (c != null && c.Any())
                {
                    Button button = (Button)c.First();
                    if (button.InvokeRequired)
                        button.Invoke((MethodInvoker)delegate
                        {
                            if (button.Text == cStrings.Stop)

                                button.PerformClick();
                        });
                    else if (button.Text == cStrings.Stop)
                        button.PerformClick();
                }


            }
        }





        public void RaiseOnSetActionEvent(object p)
        {
            ViewActionLinkSummary();
            BindingDataToControls_SetActionToAllControlsNeedAction();
        }

        public void BindingDataToControls()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(BindingDataToControls));
                return;
            }
            try
            {
                if (Action == null) { return; }
                GlobVar.LockEvents = true;
                GlobFuncs.BeginControlUpdate(this);
                //GlobVar.Draw = false;
                BindingToControls_TextBox();
                BindingToControls_Button();
                BindingControls_NumericUpDown();
                BindingDataToControls_TrackBarControl();
                BindingControls_Label();
                BindingControls_Checkbox();
                BindingDataToControls_RangeMaxMin();
                BindingDataToControls_Combobox();
                BindingControl_RangeMaxMinLimit();
                BindingControl_ImageLink();
                BindingControl_ObjectLink();
                BindingControl_Tolerance();
                BindingControl_Point();
                BindingControl_Line();
                BindingDataToControls_ToolName();
                BindingDataToControls_Link();
                BindingDataToControls_ProgramName();
                BindingDataToControls_ProjectName();
                BindingDataToControls_OriginLink();
                BindingDataToControls_RadioButton();
                RemoveEventToControls();
                BinddingEventToControls();
                //SListString a = new SListString(EHTupleStyle.Line);
                //a.rtcValue = new List<string> { "Value1", "Value2", "Value3", "Value 4" };
                //SDoubleList a = new SDoubleList(EHTupleStyle.RangeMinMax);
                //a.rtcValue = new List<double> { 1, 2, 3, 4, 5 };
                //var test = a.GetType().Name;
                //SRegion a = new SRegion("", EHTupleStyle.None);
                //a.rtcValue = new Dictionary<Guid, List<double>>
                //{
                //    { Guid.NewGuid(), new List<double> { 1, 2, 3, 4 } }
                //};
                GlobVar.LockEvents = true;
                switch (Action.ActionType)
                {
                    case EActionTypes.ImageFilter:
                        ((ucImageFilterActionDetail)Action.ViewInfo).LoadFilterProperty();
                        break;
                    case EActionTypes.PassFail:
                        ((ucPassFailActionDetails)Action.ViewInfo).LoadLinkData();
                        break;
                    case EActionTypes.ResetTool:
                        ((ucResetToolActionDetail)Action.ViewInfo).LoadLinkData();
                        break;
                    case EActionTypes.SnapImage:
                        ((ucSnapImageActionDetail)Action.ViewInfo).ViewTemplates();
                        break;
                    case EActionTypes.DataSet:
                        ((ucDataSetActionDetail)Action.ViewInfo).LoadLinkProperty();
                        break;
                    case EActionTypes.CsvWrite:
                        ((ucCsvWriteActionDetail)Action.ViewInfo).LoadColumnProperty();
                        break;
                    case EActionTypes.MainAction:
                        ((ucMainActions)Action.ViewInfo).PreviewData_ViewListFiles();
                        break;
                    case EActionTypes.LinkValue:
                        ((ucPropertyLinkActionDetail)Action.ViewInfo).LoadLinkProperty();
                        break;
                    case EActionTypes.StringBuilder:
                        ((ucStringBuilderDetail)Action.ViewInfo).LoadStringBuilderItems();
                        break;
                }

            }
            finally
            {
                GlobVar.LockEvents = false;
                GlobFuncs.EndControlUpdate(this);
            }
        }
        private void BindingDataToControls_Link()
        {
            var controls = GlobFuncs.GetAllUserControl(this, typeof(ucLink));
            if (controls != null && controls.Any())
            {
                foreach (Control item in controls)
                {
                    ucLink link = (ucLink)item;
                    link.OnButtonLinkClickEvent -= Raise_OnButtonLinkClickEvent;
                    link.OnButtonLinkClickEvent += Raise_OnButtonLinkClickEvent;
                    link.OnButtonRemoveLinkClickEvent -= Raise_OnButtonRemoveLinkClickEvent;
                    link.OnButtonRemoveLinkClickEvent += Raise_OnButtonRemoveLinkClickEvent;
                    if (link.RTCIsPreviewValue && link.RTCCanEditValue)
                    {
                        link.txtValue.KeyDown -= TextEditOnUserControl_KeyDownEvents;
                        link.txtValue.KeyDown += TextEditOnUserControl_KeyDownEvents;
                    }
                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(link.RTCPropertyName)?.GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    if (propertyInfo.rtcReadOnly)
                        link.Enabled = false;
                }
            }
        }

        private void BindingDataToControls_ProgramName()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucProgramName));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var propgramName = (ucProgramName)item;
                    propgramName.RTCProject = GlobVar.CurrentProject;
                    propgramName.OnProgramNameValueChangedEvent -= Raise_OnProgramNameValueChangedEvent;
                    propgramName.OnProgramNameValueChangedEvent += Raise_OnProgramNameValueChangedEvent;

                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propgramName.RTCPropertyName)?.GetValue(Action, null);
                    PropertyInfo propertyInfoValue = null;
                    if (propertyInfo == null) { continue; }
                    propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                    propgramName.ProgramName = propertyInfoValue.GetValue(propertyInfo, null)?.ToString();
                    if (propertyInfo.rtcReadOnly)
                        propgramName.Enabled = false;
                }
            }
        }
        private void TextEditOnUserControl_KeyDownEvents(object sender, KeyEventArgs e)
        {
            try
            {
                if (GlobVar.LockEvents || e == null || e.KeyCode != Keys.Enter) return;
                TextBox textedit = (TextBox)sender;
                string sValue = string.Empty;
                if (textedit.Text != null)
                    sValue = textedit.Text;

                if (textedit.Name == cPropertyName.Name && (textedit.Text == null || sValue == ""))
                    return;

                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(textedit.Name)?.GetValue(Action, null);
                if (propertyInfo == null) { return; }
                PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                if (propertyInfoValue == null) return;
                if (propertyInfoValue.PropertyType.Name == nameof(String))
                {
                    propertyInfoValue.SetValue(propertyInfo, sValue);
                }
                else if (propertyInfoValue.PropertyType.Name == nameof(Double))
                {
                    if (sValue.Trim() == "") sValue = "0";
                    propertyInfoValue.SetValue(propertyInfo, double.Parse(sValue));
                }
                else if (propertyInfoValue.PropertyType.Name == nameof(Int32))
                {
                    if (sValue.Trim() == "") sValue = "0";
                    propertyInfoValue.SetValue(propertyInfo, int.Parse(sValue));
                }
                else if (propertyInfoValue.PropertyType.Name == nameof(List<double>))
                {
                    string[] arr = sValue.Split(',');
                    List<double> value = new List<double>(Lib.ToInt(sValue));
                    try
                    {
                        if (arr.Length != 0)
                        {
                            foreach (var t in arr)
                                value.Append(double.Parse(t));
                            propertyInfoValue.SetValue(propertyInfo, value);
                        }
                    }
                    catch
                    {
                        propertyInfoValue.SetValue(propertyInfo, value);
                    }
                }
                //if (Action.AutoRun) RunAction();
                ////if (textedit.Tag != null && int.Parse(textedit.Tag.ToString()) == 1) RunAction();
                //UpdateReferencePropertyControls(PropertyName);

                //UpdatePropertyValueToPropertyGrid(PropertyName);

                if (textedit.Name == cPropertyName.Name)
                {
                    Action.MyNode.Description = sValue;
                    GlobVar.tl.RefreshObject(Action.MyNode);
                    return;
                }
                if (textedit.Name != string.Empty)
                {
                    Action.SetActionValueToROIPropertiesSelected();

                    if (Action.AutoRun) RunAction();

                    UpdateReferencePropertyControls(textedit.Name);
                    UpdatePropertyValueToPropertyGrid(textedit.Name);
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }

        public void Raise_OnProgramNameValueChangedEvent(string propName, string value, bool isMutiChoose = true)
        {
            if (Action != null && !string.IsNullOrEmpty(propName))
            {
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propName).GetValue(Action, null);
                if (propertyInfo == null) { return; }
                PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                propertyInfoValue.SetValue(propertyInfo, value);

                if (propName == nameof(Action.ProgramName) && Action.ProgramID != null)
                {
                    Action.ProgramID.rtcValue = Guid.Empty.ToString();
                    string[] propgramNames = value.Split(cChars.Comma);
                    foreach (string programName in propgramNames)
                    {
                        if (programName == cStrings.This)
                        {
                            if (string.IsNullOrEmpty(Action.ProgramID.rtcValue))
                                Action.ProgramID.rtcValue = Action.MyGroup.MyCam.ID.ToString();
                            else if (isMutiChoose)
                                Action.ProgramID.rtcValue = $"{Action.ProgramID.rtcValue},{Action.MyGroup.MyCam.ID.ToString()}";
                            else
                                Action.ProgramID.rtcValue = Action.MyGroup.MyCam.ID.ToString();
                        }
                        else if (GlobVar.CurrentProject?.CAMs.Values.FirstOrDefault(x => x.Name == value) != null)
                        {
                            string programId = GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == value)
                                .ID.ToString();

                            if (string.IsNullOrEmpty(Action.ProgramID.rtcValue))
                                Action.ProgramID.rtcValue = programId.ToString();
                            else if (isMutiChoose)
                                Action.ProgramID.rtcValue = $"{Action.ProgramID.rtcValue},{programId}";
                            else
                                Action.ProgramID.rtcValue = programId.ToString();
                        }
                    }
                }
                Action.SetActionValueToROIPropertiesSelected();

                if (Action.AutoRun)
                    RunAction();

                UpdatePropertyValueToPropertyGrid(propName);
            }
        }

        private void BindingDataToControls_ToolName()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucToolName));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var toolName = (ucToolName)item;
                    toolName.OnToolNameComboboxValueChanged -= Raise_OnToolNameComboboxValueChangedEvent;
                    toolName.OnToolNameComboboxValueChanged += Raise_OnToolNameComboboxValueChangedEvent;

                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(toolName.RTCPropertyName)?.GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    if (propertyInfo.rtcReadOnly)
                        toolName.Enabled = false;
                }
            }
        }
        public void Raise_OnToolNameComboboxValueChangedEvent(string propName, string toolName, Guid toolID)
        {
            if (Action != null && !string.IsNullOrEmpty(propName))
            {
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propName).GetValue(Action, null);
                if (propertyInfo == null) { return; }
                PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                propertyInfoValue.SetValue(propertyInfo, toolName);

                if (Action.ToolID != null)
                    Action.ToolID.rtcValue = toolID.ToString();

                Action.SetActionValueToROIPropertiesSelected();

                if (Action.AutoRun)
                    RunAction();

                UpdatePropertyValueToPropertyGrid(propName);
                if (Action.ToolID != null)
                    UpdatePropertyValueToPropertyGrid(nameof(Action.ToolID));
            }
        }
        private void BindingControl_Point()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucPoint));
            if (c != null && c.Any())
            {
                ucPoint Point = null;
                foreach (Control item in c)
                {
                    Point = (ucPoint)item;
                    Point.OnButtonLinkClickEvent -= Raise_OnButtonLinkClickEvent;
                    Point.OnButtonLinkClickEvent += Raise_OnButtonLinkClickEvent;
                    Point.OnButtonRemoveLinkClickEvent -= Raise_OnButtonRemoveLinkClickEvent;
                    Point.OnButtonRemoveLinkClickEvent += Raise_OnButtonRemoveLinkClickEvent;
                    Point.OnSValueChangeEvent -= Raise_OnSValueChangeEvent;
                    Point.OnSValueChangeEvent += Raise_OnSValueChangeEvent;

                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(Point.RTCPropertyName).GetValue(Action, null);
                    if (propertyInfo == null) { continue; }

                    GlobVar.LockEvents = true;
                    Point.UpdateHTupleValue(((SListDouble)propertyInfo).rtcValue);
                    GlobVar.LockEvents = false;

                    if (propertyInfo.rtcReadOnly)
                        Point.Enabled = false;
                }
            } 
        }
        private void BindingControl_Line()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucLine));
            if (c != null && c.Any())
            {
                ucLine Line = null;
                foreach (Control item in c)
                {
                    Line = (ucLine)item;
                    Line.OnButtonLinkClickEvent -= Raise_OnButtonLinkClickEvent;
                    Line.OnButtonLinkClickEvent += Raise_OnButtonLinkClickEvent;
                    Line.OnButtonRemoveLinkClickEvent -= Raise_OnButtonRemoveLinkClickEvent;
                    Line.OnButtonRemoveLinkClickEvent += Raise_OnButtonRemoveLinkClickEvent;
                    Line.OnSHTupleValueChangeEvent -= Raise_OnSValueChangeEvent;
                    Line.OnSHTupleValueChangeEvent += Raise_OnSValueChangeEvent;

                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(Line.RTCPropertyName).GetValue(Action, null);
                    if (propertyInfo == null) { continue; }

                    GlobVar.LockEvents = true;
                    Line.UpdateHTupleValue(((SListDouble)propertyInfo).rtcValue);
                    GlobVar.LockEvents = false;

                    if (propertyInfo.rtcReadOnly)
                        Line.Enabled = false;
                }
            }
        }

        private void BindingControl_Tolerance()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucTolerance));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var tolerance = (ucTolerance)item;
                    tolerance.OnCheckboxValueChangeEvent -= Raise_OnCheckboxValueChangEvent;
                    tolerance.OnCheckboxValueChangeEvent += Raise_OnCheckboxValueChangEvent;
                    tolerance.OnSValueChangeEvent -= Raise_OnSValueChangeEvent;
                    tolerance.OnSValueChangeEvent += Raise_OnSValueChangeEvent;
                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(tolerance.RTCPropertyName)?.GetValue(Action, null);
                    if (propertyInfo != null)
                    {
                        GlobVar.LockEvents = true;
                        tolerance.UpdateValue(((SListDouble)propertyInfo).rtcValue);
                        GlobVar.LockEvents = false;
                        if (propertyInfo.rtcReadOnly)
                        {
                            tolerance.txtMinus.Enabled = false;
                            tolerance.txtNominal.Enabled = false;
                            tolerance.txtPlus.Enabled = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(tolerance.RTCCheckboxPropertyName))
                    {
                        propertyInfo = (RTCVariableType)Action.GetType().GetProperty(tolerance.RTCCheckboxPropertyName)?.GetValue(Action, null);
                        if (propertyInfo != null)
                        {
                            GlobVar.LockEvents = true;
                            tolerance.UpdateCheckboxValue((bool)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null));
                            GlobVar.LockEvents = false;
                            if (propertyInfo.rtcReadOnly)
                                tolerance.chkEnable.Enabled = false;
                        }
                    }
                }
            }
        }

        private void BindingControl_ImageLink()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucImageLink));
            if (c != null && c.Any())
            {
                ucImageLink imglink = null;
                foreach (Control item in c)
                {
                    imglink = (ucImageLink)item;
                    imglink.OnButtonLinkEndSelectedPropertyLinkEvent -= Raise_OnButtonLinkEndSelectedPropertyLinkEvent;
                    imglink.OnButtonLinkEndSelectedPropertyLinkEvent += Raise_OnButtonLinkEndSelectedPropertyLinkEvent;

                    imglink.OnButtonLinkClickEvent -= Raise_OnButtonLinkClickEvent;
                    imglink.OnButtonLinkClickEvent += Raise_OnButtonLinkClickEvent;

                    imglink.OnButtonRemoveLinkClickEvent -= Raise_OnButtonRemoveLinkClickEvent;
                    imglink.OnButtonRemoveLinkClickEvent += Raise_OnButtonRemoveLinkClickEvent;
                    var testt = Action.GetType().GetProperty(imglink.PropertyName);
                    //var test = Action.GetType().GetProperty(imglink.PropertyName).GetValue(Action, null);
                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(imglink.PropertyName).GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    if (propertyInfo.rtcReadOnly)
                        imglink.Enabled = false;
                }
            }
        }
        //Quân sửa
        private void BindingControl_ObjectLink()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucObjectLink));
            if (c != null && c.Any())
            {
                ucObjectLink objectLink = null;
                foreach (Control item in c)
                {
                    objectLink = (ucObjectLink)item;

                    objectLink.OnButtonLinkEndSelectedPropertyLinkEvent -= Raise_OnButtonLinkEndSelectedPropertyLinkEvent;
                    objectLink.OnButtonLinkEndSelectedPropertyLinkEvent += Raise_OnButtonLinkEndSelectedPropertyLinkEvent;

                    objectLink.OnButtonLinkClickEvent -= Raise_OnButtonLinkClickEvent;
                    objectLink.OnButtonLinkClickEvent += Raise_OnButtonLinkClickEvent;

                    objectLink.OnButtonRemoveLinkClickEvent -= Raise_OnButtonRemoveLinkClickEvent;
                    objectLink.OnButtonRemoveLinkClickEvent += Raise_OnButtonRemoveLinkClickEvent;

                    objectLink.RTCAction = Action;

                    var property = Action?.GetType().GetProperty(objectLink.RTCPropertyName);
                    RTCVariableType propertyInfo = (RTCVariableType)property?.GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    if (propertyInfo.rtcReadOnly)
                        objectLink.Enabled = false;
                }
            }
        }
        //private void BindingControl_ObjectLink()
        //{
        //    var c = GlobFuncs.GetAllUserControl(this, typeof(ucObjectLink));
        //    if (c != null && c.Any())
        //    {
        //        ucObjectLink objectLink = null;
        //        foreach (Control item in c)
        //        {
        //            objectLink = (ucObjectLink)item;

        //            objectLink.OnButtonLinkEndSelectedPropertyLinkEvent -= Raise_OnButtonLinkEndSelectedPropertyLinkEvent;
        //            objectLink.OnButtonLinkEndSelectedPropertyLinkEvent += Raise_OnButtonLinkEndSelectedPropertyLinkEvent;

        //            objectLink.OnButtonLinkClickEvent -= Raise_OnButtonLinkClickEvent;
        //            objectLink.OnButtonLinkClickEvent += Raise_OnButtonLinkClickEvent;

        //            objectLink.OnButtonRemoveLinkClickEvent -= Raise_OnButtonRemoveLinkClickEvent;
        //            objectLink.OnButtonRemoveLinkClickEvent += Raise_OnButtonRemoveLinkClickEvent;

        //            // gán Action để btnLink_Click hoạt động
        //            objectLink.RTCAction = Action;

        //            // kiểm tra property tương ứng và trạng thái readonly giống ImageLink
        //            var prop = Action?.GetType().GetProperty(objectLink.RTCPropertyName);
        //            if (prop == null) { continue; }

        //            RTCVariableType propertyInfo = (RTCVariableType)prop.GetValue(Action, null);
        //            if (propertyInfo == null) { continue; }

        //            if (propertyInfo.rtcReadOnly)
        //                objectLink.Enabled = false;
        //        }
        //    }
        //}

        protected void Raise_OnButtonRemoveLinkClickEvent(object sender, RTCE_ButtonRemoveLinkClickEventArgs e)
        {
            MyPropertiesItem Node = FindPropertyNode(e.PropertyName);
            if (Action == null || Node == null) { return; }

            RTCE_ActionDetailProperties_RowCellClickEventArgs eRTC = new RTCE_ActionDetailProperties_RowCellClickEventArgs();
            eRTC.Node = Node;
            eRTC.Base = this;
            eRTC.IDRef = (Guid)(this.IDref.GetValue(Node));
            eRTC.ActionType = (ENodeTypes)(this.NodeType.GetValue(Node));
            eRTC.Enable = (bool)(this.Enable.GetValue(Node));
            eRTC.ActionName = (string)(this.PropName.GetValue(Node));
            eRTC.Type = (string)(this.Type.GetValue(Node));
            eRTC.Value = (string)(this.Value.GetValue(Node));
            eRTC.IsSytem = (bool)(this.IsSystem.GetValue(Node));
            eRTC.ValueStyle = ((RTCVariableType)Action.GetType().GetProperty(e.PropertyName).GetValue(Action, null)).ValueStyle;
            eRTC.CIDRef = this.IDref;
            eRTC.CActionType = this.NodeType;
            eRTC.CEnable = this.Enable;
            eRTC.CActionName = this.PropName;
            eRTC.CType = this.Type;
            eRTC.CValue = this.Value;
            eRTC.CIsSystem = this.IsSystem;
            eRTC.TreeList = this.tlvAction;
            eRTC.action = this.Action;
            if (OnPropertiesRowCellClickbtnRemoveLink != null)
            {
                OnPropertiesRowCellClickbtnRemoveLink(this, eRTC);
            }
        }

        protected void Raise_OnButtonLinkClickEvent(object sender, RTCE_ButtonLinkClickEventArgs e)
        {
            MyPropertiesItem Node = FindPropertyNode(e.PropertyName);
            if (Action == null || Node == null) { return; }

            RTCE_ActionDetailProperties_RowCellClickEventArgs eRTC = new RTCE_ActionDetailProperties_RowCellClickEventArgs();
            eRTC.Node = Node;
            eRTC.Base = this;
            eRTC.IDRef = (Guid)(this.IDref.GetValue(Node));
            eRTC.ActionType = (ENodeTypes)(this.NodeType.GetValue(Node));
            eRTC.Enable = (bool)(this.Enable.GetValue(Node));
            eRTC.ActionName = (string)(this.PropName.GetValue(Node));
            eRTC.Type = (string)(this.Type.GetValue(Node));
            eRTC.Value = (string)(this.Value.GetValue(Node));
            eRTC.IsSytem = (bool)(this.IsSystem.GetValue(Node));
            eRTC.ValueStyle = ((RTCVariableType)Action.GetType().GetProperty(e.PropertyName).GetValue(Action, null)).ValueStyle;
            eRTC.CIDRef = this.IDref;
            eRTC.CActionType = this.NodeType;
            eRTC.CEnable = this.Enable;
            eRTC.CActionName = this.PropName;
            eRTC.CType = this.Type;
            eRTC.CValue = this.Value;
            eRTC.CIsSystem = this.IsSystem;
            eRTC.TreeList = this.tlvAction;
            eRTC.action = this.Action;
            if (OnPropertiesRowCellClickbtnLink != null)
            {
                OnPropertiesRowCellClickbtnLink(this, eRTC);
            }

        }

        private void Raise_OnButtonLinkEndSelectedPropertyLinkEvent(Guid groupID, Guid actionID, string propertyname)
        {
            if (OnButtonLinkEndSelectedPropertyLinkEvent != null)
            {
                OnButtonLinkEndSelectedPropertyLinkEvent(groupID, actionID, propertyname);
            }
        }

        private void BindingControl_RangeMaxMinLimit()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucRangeMaxMinLimit));
            if (c != null && c.Any())
            {

                foreach (Control item in c)
                {
                    var RangeMaxMinLimit = (ucRangeMaxMinLimit)item;
                    RangeMaxMinLimit.OnValueChangeEvents -= Raise_OnSValueChangeEvent;
                    RangeMaxMinLimit.OnValueChangeEvents += Raise_OnSValueChangeEvent;
                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(RangeMaxMinLimit.RTCPropertyName)?.GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    GlobVar.LockEvents = true;
                    
                    RangeMaxMinLimit.SetValue((SListDouble)propertyInfo);
                    GlobVar.LockEvents = false;
                    if (propertyInfo.rtcReadOnly)
                        RangeMaxMinLimit.Enabled = false;

                }
            }
        }

        private void Raise_OnValueChangeEvent(object sender, RTCE_SValueChangeEventArgs e)
        {
            if (Action != null && e.PropertyName != string.Empty)
            {
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(e.PropertyName).GetValue(Action, null);
                if (propertyInfo == null) { return; }
                PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                propertyInfoValue.SetValue(propertyInfo, e.Value.rtcValue);
                Action.SetActionValueToROIPropertiesSelected();
                if (Action.AutoRun) RunAction();
                UpdatePropertyValueToPropertyGrid(e.PropertyName);

            }
        }

        private void BindingDataToControls_SetActionToAllControlsNeedAction()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucImageLink));
            if (c != null && c.Any())
            {
                ucImageLink control = null;
                foreach (Control item in c)
                {
                    control = (ucImageLink)item;
                    control.Action = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucOrigin));
            if (c != null && c.Any())
            {
                ucOrigin control = null;
                foreach (Control item in c)
                {
                    control = (ucOrigin)item;
                    control.Action = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucRangeMaxMin));
            if (c != null && c.Any())
            {
                ucRangeMaxMin control = null;
                foreach (Control item in c)
                {
                    control = (ucRangeMaxMin)item;
                    control.RTCAction = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucRangeMaxMinLimit));
            if (c != null && c.Any())
            {
                ucRangeMaxMinLimit control = null;
                foreach (Control item in c)
                {
                    control = (ucRangeMaxMinLimit)item;
                    control.RTCAction = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucPoint));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var control = (ucPoint)item;
                    control.RTCAction = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucTolerance));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var control = (ucTolerance)item;
                    control.RTCAction = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucLine));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var control = (ucLine)item;
                    control.RTCAction = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucToolName));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var control = (ucToolName)item;
                    control.RTCAction = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucProgramName));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var control = (ucProgramName)item;
                    control.RTCAction = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucProjectName));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var control = (ucProjectName)item;
                    control.RTCAction = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucMultiLink));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var control = (ucMultiLink)item;
                    control.RTCAction = this.Action;
                }
            }
            c = GlobFuncs.GetAllUserControl(this, typeof(ucLink));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var control = (ucLink)item;
                    control.RTCAction = this.Action;
                }
            }

        }

        private void BindingDataToControls_RadioButton()
        {
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;
            var c = GlobFuncs.GetAll(this, typeof(RadioButton));
            if (c != null && c.Any())
            {
                RadioButton radioGroup = null;
                foreach (Control item in c)
                {
                    radioGroup = (RadioButton)item;

                    if (!radioGroup.Name.StartsWith(cStrings.RTC)) continue;

                    string propertyName = radioGroup.Name.Substring(3, radioGroup.Name.Length - 3);

                    propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName).GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                    object oValue = propertyInfoValue.GetValue(propertyInfo, null);
                    radioGroup.Checked = oValue.ToString() == radioGroup.Text;
                    radioGroup.CheckedChanged -= NormalEditControl_ValueChangedEvents;
                    radioGroup.CheckedChanged += NormalEditControl_ValueChangedEvents;

                    radioGroup.Enabled = !propertyInfo.rtcReadOnly;

                    UpdateReferencePropertyControls(propertyName);
                }
            }
        }
        private void BindingDataToControls_Combobox()
        {
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;
            var c = GlobFuncs.GetAll(this, typeof(ComboBox));
            if (c != null && c.Any())
            {
                ComboBox combo = null;
                foreach (Control item in c)
                {
                    combo = (ComboBox)item;
                    if (!combo.Name.StartsWith(cStrings.RTC)) continue;
                    if (combo.Name.StartsWith(cStrings.RTCEnum))
                        BindingDataControl_ComboBox_Enum(combo);
                    else
                        BindingDataControl_ComboBox_Normal(combo);
                }
            }
        }
        
        public void BindingDataControl_ComboBox_Normal(ComboBox combo)
        {
            combo.SelectedIndexChanged -= NormalEditControl_ValueChangedEvents;
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;
            //combo.DropDownStyle = ComboBoxStyle.DropDownList;
            string PropertyName = combo.Name.Substring(3, combo.Name.Length - 3);
            string sKey = PropertyName + "|" + Enum.GetName(typeof(EActionTypes), Action.ActionType);
            string[] sValues = CommonData.GetPropertyValues(sKey).Split(cStrings.SepGDung);
            if (PropertyName == nameof(Action.COMName) || PropertyName == nameof(Action.SerialPort))
                sValues = SerialPort.GetPortNames();
            else if (PropertyName == nameof(Action.Model) && (Action.ActionType == EActionTypes.VSTLightRead ||
                Action.ActionType == EActionTypes.VSTLightWrite))
                sValues = CommonData.GetVstModelList();
            combo.Items.Clear();

            foreach (string sValue in sValues)
                combo.Items.Add(sValue);
            propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
            if (propertyInfo == null) { return; }
            propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            if (propertyInfoValue.PropertyType == typeof(List<string>))
                combo.SelectedItem = GlobFuncs.Object2Str(propertyInfoValue.GetValue(propertyInfo, null));
            else
            {
                var test = propertyInfoValue.GetValue(propertyInfo, null);
                combo.SelectedItem = propertyInfoValue.GetValue(propertyInfo, null);
            }
            combo.SelectedIndexChanged += NormalEditControl_ValueChangedEvents;
            if (propertyInfo.rtcReadOnly)
                combo.Enabled = false;
            UpdateReferencePropertyControls(PropertyName);
        }
        
        public void BindingDataControl_ComboBox_Enum(ComboBox combo)
        {
            combo.SelectedIndexChanged -= NormalEditControl_ValueChangedEvents;
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;
            string PropertyName = combo.Name.Substring(7, combo.Name.Length - 7);
            string sKey = PropertyName + "|" + Enum.GetName(typeof(EActionTypes), Action.ActionType);
            string[] sValues = CommonData.GetPropertyValues(sKey).Split(cStrings.SepGDung);
            combo.Items.Clear();
            foreach (string sValue in sValues)
                combo.Items.Add(sValue);
            propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
            if (propertyInfo == null) { return; }
            propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            combo.SelectedIndex = (int)propertyInfoValue.GetValue(propertyInfo, null);
            combo.SelectedIndexChanged += NormalEditControl_ValueChangedEvents;
            if (propertyInfo.rtcReadOnly)
                combo.Enabled = false;
            UpdateReferencePropertyControls(PropertyName);
        }



        private void BindingDataToControls_RangeMaxMin()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucRangeMaxMin));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var RangeMaxMin = (ucRangeMaxMin)item;
                    RangeMaxMin.OnCheckboxValueChangeEvent -= Raise_OnCheckboxValueChangEvent;
                    RangeMaxMin.OnCheckboxValueChangeEvent += Raise_OnCheckboxValueChangEvent;
                    RangeMaxMin.OnSValueChangeEvent -= Raise_OnSValueChangeEvent;
                    RangeMaxMin.OnSValueChangeEvent += Raise_OnSValueChangeEvent;
                    //  var test = Action.GetType().GetProperty(RangeMaxMin.RTCValuePropertyName)?.GetValue(Action, null);
                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(RangeMaxMin.RTCValuePropertyName)?.GetValue(Action, null);
                    if (propertyInfo != null)
                    {

                        GlobVar.LockEvents = true;
                        if (propertyInfo.GetType().Name == "SListDouble")
                            RangeMaxMin.UpdateValue(((SListDouble)propertyInfo).rtcValue);
                        else
                            RangeMaxMin.UpdateMixValue(((SListObject)propertyInfo).rtcValue);

                        GlobVar.LockEvents = false;
                        if (propertyInfo.rtcReadOnly)
                        {
                            RangeMaxMin.txtRangeMax.Enabled = false;
                            RangeMaxMin.txtRangeMax.Enabled = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(RangeMaxMin.RTCCheckboxPropertyName))
                    {
                        propertyInfo = (RTCVariableType)Action.GetType().GetProperty(RangeMaxMin.RTCCheckboxPropertyName)?.GetValue(Action, null);
                        {
                            if (propertyInfo != null)
                            {
                                GlobVar.LockEvents = true;
                                RangeMaxMin.UpdateCheckboxValue((bool)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null));
                                GlobVar.LockEvents = false;
                                if (propertyInfo.rtcReadOnly)
                                    RangeMaxMin.chkEnable.Enabled = false;
                            }
                        }
                    }

                }
            }

        }
        private void BindingDataToControls_ProjectName()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucProjectName));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var projectName = (ucProjectName)item;
                    projectName.OnProgramNameValueChangedEvent -= Raise_OnProgramNameValueChangedEvent;
                    projectName.OnProgramNameValueChangedEvent += Raise_OnProgramNameValueChangedEvent;

                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(projectName.RTCPropertyName)?.GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    if (propertyInfo.rtcReadOnly)
                        projectName.Enabled = false;
                }
            }
        }
        private void BindingDataToControls_OriginLink()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucOrigin));
            if (c != null && c.Any())
            {
                ucOrigin OriginLink = null;
                foreach (Control item in c)
                {
                    OriginLink = (ucOrigin)item;
                    OriginLink.OnButtonLinkEndSelectedPropertyLinkEvent -= Raise_OnButtonLinkEndSelectedPropertyLinkEvent;
                    OriginLink.OnButtonLinkEndSelectedPropertyLinkEvent += Raise_OnButtonLinkEndSelectedPropertyLinkEvent;
                    OriginLink.OnButtonLinkClickEvent -= Raise_OnButtonLinkClickEvent;
                    OriginLink.OnButtonLinkClickEvent += Raise_OnButtonLinkClickEvent;
                    OriginLink.OnButtonRemoveLinkClickEvent -= Raise_OnButtonRemoveLinkClickEvent;
                    OriginLink.OnButtonRemoveLinkClickEvent += Raise_OnButtonRemoveLinkClickEvent;

                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(OriginLink.PropertyName).GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    if (propertyInfo.rtcReadOnly)
                        OriginLink.Enabled = false;
                }
            }
        }

        private void Raise_OnSValueChangeEvent(object sender, RTCE_SValueChangeEventArgs e)
        {
            if (Action != null && e.PropertyName != string.Empty)
            {
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(e.PropertyName).GetValue(Action, null);
                if (propertyInfo == null) { return; }
                PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

                switch (Action.GetType().GetProperty(e.PropertyName).PropertyType.Name)
                {
                    case nameof(SListDouble):
                        propertyInfoValue.SetValue(propertyInfo, e.Value.rtcValue);
                        break;
                    case nameof(SListObject):
                        propertyInfoValue.SetValue(propertyInfo, e.ObjectValue.rtcValue);
                        break;
                }
                Action.SetActionValueToROIPropertiesSelected();
                if (Action.AutoRun) RunAction();
                UpdatePropertyValueToPropertyGrid(e.PropertyName);
            }
        }

        public void Raise_OnCheckboxValueChangEvent(object sender, RTCE_CheckboxValueChangeEventArgs e)
        {
            if (Action != null && e.PropertyName != string.Empty)
            {
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(e.PropertyName).GetValue(Action, null);
                if (propertyInfo == null) { return; }
                PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                propertyInfoValue.SetValue(propertyInfo, e.Value);
                Action.SetActionValueToROIPropertiesSelected();
                if (Action.AutoRun) RunAction();
                UpdatePropertyValueToPropertyGrid(e.PropertyName);
            }
        }

        private void BindingControls_Checkbox()
        {
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;
            var c = GlobFuncs.GetAll(this, typeof(CheckBox));
            if (c != null && c.Any())
            {
                CheckBox chk = null;
                foreach (Control item in c)
                {
                    chk = (CheckBox)item;
                    if (!chk.Name.StartsWith(cStrings.RTC)) continue;

                    string PropertyName = chk.Name.Substring(3, chk.Name.Length - 3);
                    var test = Action.GetType().GetProperty(PropertyName);
                    propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                    chk.Checked = (bool)propertyInfoValue.GetValue(propertyInfo, null);
                    chk.CheckedChanged -= NormalEditControl_ValueChangedEvents;
                    chk.CheckedChanged += NormalEditControl_ValueChangedEvents;
                    if (propertyInfo.rtcReadOnly)
                        chk.Enabled = false;
                    UpdateReferencePropertyControls(PropertyName);
                }
            }
        }

        private void NormalEditControl_ValueChangedEvents(object sender, EventArgs e)
        {
            string PropertyName = string.Empty;
            switch (sender.GetType().Name)
            {
                case nameof(TextBox):
                    TextBox_TextChanged(sender, e, out PropertyName);
                    break;
                case nameof(CheckBox):
                    CheckBox_EditVaLueChanged(sender, e, out PropertyName);
                    break;
                case nameof(ComboBox):
                    if (((ComboBox)sender).Name.StartsWith(cStrings.RTCEnum))
                        ComboBox_SelectedIndexChanged(sender, e, out PropertyName);
                    else
                        ComboBox_SelectedValueChanged(sender, e, out PropertyName);
                    break;
                case nameof(TrackBar):
                    TrackBarControl_EditValueChanged(sender, e, out PropertyName);
                    break;
                case nameof(RadioButton):
                    RadioButton_CheckedChange(sender, e, out PropertyName);
                    break;
                default:
                    break;

            }

            if (PropertyName != string.Empty)
            {
                Action.SetActionValueToROIPropertiesSelected();
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
                if (Action.AutoRun && PropertyName != cPropertyName.Name && propertyInfo.rtcRunWhenChange)
                    RunAction();
                UpdateReferencePropertyControls(PropertyName);
                UpdatePropertyValueToPropertyGrid(PropertyName);
            }
        }
        private void TrackBarControl_EditValueChanged(object sender, EventArgs e, out string propertyname)
        {
            propertyname = string.Empty;
            if (GlobVar.LockEvents) return;
            TrackBar rangeTB = (TrackBar)sender;
            string PropertyName = rangeTB.Name.Substring(3, rangeTB.Name.Length - 3);
            RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
            if (propertyInfo == null) { return; }
            PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            if (propertyInfoValue.PropertyType.Name == typeof(List<double>).Name)
            {
                List<double> val = ((SListDouble)propertyInfo).rtcValue;
                val[0] = rangeTB.Value;
                propertyInfoValue.SetValue(propertyInfo, val);
            }
            else
                propertyInfoValue.SetValue(propertyInfo, rangeTB.Value);
            propertyname = PropertyName;

            //if (Action.AutoRun) RunAction();
            //UpdateReferencePropertyControls(PropertyName);
            //UpdatePropertyValueToPropertyGrid(PropertyName);
        }
        private void RadioButton_CheckedChange(object sender, EventArgs e, out string propertyname)
        {
            propertyname = string.Empty;
            if (GlobVar.LockEvents) return;
            RadioButton radioGroup = (RadioButton)sender;
            string PropertyName = radioGroup.Name.Substring(3, radioGroup.Name.Length - 3);
            RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
            if (propertyInfo == null) { return; }
            PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            if (radioGroup.Name == "RTCCounterType")
            {
                if (radioGroup.Checked)
                {
                    propertyInfoValue.SetValue(propertyInfo, radioGroup.Text);
                    propertyname = PropertyName;
                }
                else
                {
                    propertyInfoValue.SetValue(propertyInfo, "NG");
                    propertyname = PropertyName;
                }
            }
            else
            {
                propertyInfoValue.SetValue(propertyInfo, radioGroup.Text);
                propertyname = PropertyName;
            }
        }
        public void UpdateBranchOpennds()
        {
            ViewActionProperties();
        }
        private void TextBox_TextChanged(object sender, EventArgs e, out string propertyname)
        {
            try
            {
                propertyname = string.Empty;
                if (GlobVar.LockEvents) return;
                TextBox textbox = (TextBox)sender;
                if (textbox.Text.Trim() == "")
                {
                    return;
                }
                string tag = textbox.Name.Substring(textbox.Name.Length - 1, 1);
                int Number;
                string PropertyName = string.Empty;
                bool isNumertic = int.TryParse(tag, out Number);
                if (isNumertic)
                {
                    PropertyName = textbox.Name.Substring(3, textbox.Name.Length - 4);
                }
                else
                    PropertyName = textbox.Name.Substring(3, textbox.Name.Length - 3);
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
                if (propertyInfo == null) { return; }
                PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

                if (propertyInfoValue.PropertyType.Name == typeof(string).Name)
                {
                    propertyInfoValue.SetValue(propertyInfo, textbox.Text);
                }
                else if (propertyInfoValue.PropertyType.Name == typeof(double).Name)
                {
                    propertyInfoValue.SetValue(propertyInfo, double.Parse(textbox.Text.ToString()));
                }
                else if (propertyInfoValue.PropertyType.Name == typeof(int).Name)
                {
                    propertyInfoValue.SetValue(propertyInfo, int.Parse(textbox.Text.ToString()));
                }
                else if (propertyInfoValue.PropertyType.Name == typeof(List<double>).Name)
                {
                    String[] arr = textbox.Text.ToString().Split(',');
                    List<double> value = new List<double>();
                    try
                    {
                        if (arr.Length != 0)
                        {
                            for (int i = 0; i < arr.Length; i++)
                            {
                                value.Add(int.Parse(arr[i]));
                            }
                            if (isNumertic)
                            {
                                value = (List<double>)propertyInfoValue.GetValue(propertyInfoValue, null);
                            }
                            propertyInfoValue.SetValue(propertyInfo, value);
                        }
                    }
                    catch
                    {
                        propertyInfoValue.SetValue(propertyInfoValue, value);
                    }
                }
                if (PropertyName == cPropertyName.Name) Action.MyNode.Description = textbox.Text;
                propertyname = PropertyName;
            }
            catch (Exception ex)
            {
                propertyname = string.Empty;

            }
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e, out string propertyName)
        {
            propertyName = string.Empty;
            if (GlobVar.LockEvents) return;
            ComboBox combo = (ComboBox)sender;
            string PropertyName = combo.Name.Substring(3, combo.Name.Length - 3);
            RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
            if (propertyInfo == null) { return; }
            PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            if (propertyInfoValue.PropertyType == typeof(List<string>))
                propertyInfoValue.SetValue(propertyInfo, new List<string> { combo.SelectedItem.ToString() });
            else
                propertyInfoValue.SetValue(propertyInfo, combo.SelectedItem);
            propertyName = PropertyName;
            if (OnPropertyValueChanged != null)
                OnPropertyValueChanged(PropertyName);
            if (Action.ActionType == EActionTypes.Pattern && propertyName == nameof(Action.PlacementMode))
            {
                switch (Action.PlacementMode.rtcValue)
                {
                    case cPlacementMode.WherePlacedOnImage:
                        {
                            if (Action.frmHsmartWindow != null)
                            {

                            }
                            //Action.frmHsmartWindow.ViewReferencePointRectangle();
                            break;
                        }
                    default:
                        {
                            if (Action.frmHsmartWindow != null)
                            {

                            }
                            //Action.frmHsmartWindow.ClearReferencePointRectangle();
                            break;
                        }
                }
            }


        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e, out string propertyName)
        {

            propertyName = string.Empty;
            if (GlobVar.LockEvents) return;
            ComboBox combo = (ComboBox)sender;
            string PropertyName = combo.Name.Substring(7, combo.Name.Length - 7);
            RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
            if (propertyInfo == null) return;
            PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            propertyInfoValue.SetValue(propertyInfo, combo.SelectedIndex);
            propertyName = PropertyName;
            if (OnPropertyValueChanged != null)
                OnPropertyValueChanged(PropertyName);
        }

        private void CheckBox_EditVaLueChanged(object sender, EventArgs e, out string propertyname)
         {
            propertyname = string.Empty;
            if (GlobVar.LockEvents) return;
            CheckBox checkbox = (CheckBox)sender;
            string PropertyName = checkbox.Name.Substring(3, checkbox.Name.Length - 3);
            RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
            if (propertyInfo == null) return;
            PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            propertyInfoValue.SetValue(propertyInfo, checkbox.Checked);
            propertyname = PropertyName;
            switch (Action.ActionType)
            {
                case EActionTypes.GaugeDualROI:
                    {
                        if (PropertyName == nameof(Action.RepeatMeasurement))
                        {
                            //Action.InitRoiForGaugeDualRoi();
                        }
                        break;
                    }
                case EActionTypes.CalibrateEdgetoEdge:
                    {
                        if (propertyname == cPropertyName.SmartFeature)
                        {
                            if (Action.ROIs != null) Action.ROIs.Clear();
                            if (Action.ROIProperties != null) Action.ROIProperties.Clear();
                            if (Action.ShapeList != null) Action.ShapeList.rtcValue = new List<object>();
                            //((ucCalibrateEdgeToEdgeActionDetails)this).btnGet
                        }
                        break;
                    }
                default:
                    break;
            }

        }

        //private void TextBox_TextChanged(object sender, EventArgs e, out string propertyname)
        //{
        //    try
        //    {
        //        propertyname = string.Empty;
        //        if (GlobVar.LockEvents) return;
        //        TextBox textbox = (TextBox)sender;
        //        if (textbox.Text == null || textbox.Text.Trim() == "")
        //        {
        //            errorProvider1.SetIconAlignment(textbox, ErrorIconAlignment.MiddleRight);
        //            errorProvider1.SetError(textbox, cMessageContent.War_ToolNameIsExits);
        //            return;
        //        }
        //        string tag = textbox.Name.Substring(textbox.Name.Length - 1, 1);
        //        int number;
        //        string PropertyName = string.Empty;
        //        bool isNumberic = int.TryParse(tag, out number);
        //        if (isNumberic)
        //        {
        //            PropertyName = textbox.Name.Substring(3, textbox.Name.Length - 4);

        //        }
        //        else
        //            PropertyName = textbox.Name.Substring(3, textbox.Name.Length - 3);
        //        RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
        //        if(propertyInfo == null) { return; }
        //        PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

        //        if(propertyInfoValue.PropertyType.Name == typeof(string).Name)
        //    }
        //    catch
        //    {

        //    }
        //}

        private void BindingControls_Label()
        {
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;
            var c = GlobFuncs.GetAll(this, typeof(Label));
            if (c != null && c.Any())
            {

                foreach (Control item in c)
                {
                    var label = (Label)item;
                    if (!label.Name.StartsWith(cStrings.RTC)) continue;
                    label.Text = string.Empty;
                    string PropertyName = label.Name.Substring(3, label.Name.Length - 3);
                    propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                    if (propertyInfoValue != null)
                    {
                        if (propertyInfo.GetType().Name == nameof(SListString))
                        {
                            List<String> value = (List<string>)propertyInfoValue.GetValue(propertyInfo, null);
                            if (value != null & value.Count > 0)
                                for (int i = 0; i < value.Count; i++)
                                    label.Text = label.Text + (label.Text == string.Empty ? "" : ",") + GlobFuncs.Ve2Str(value[i]);
                        }
                        else if (propertyInfo.GetType().Name == nameof(SListDouble))
                        {
                            List<double> value = (List<double>)propertyInfoValue.GetValue(propertyInfo, null);
                            if (value != null & value.Count > 0)
                                for (int i = 0; i < value.Count; i++)
                                    label.Text = label.Text + (label.Text == string.Empty ? "" : ",") + GlobFuncs.Ve2Str(value[i]);
                        }
                        else
                        {
                            label.Text = propertyInfoValue.GetValue(propertyInfo, null).ToString();
                        }
                    }
                    else
                        ((Label)item).Text = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)
                            ?.GetValue(propertyInfo, null).ToString();
                    if (propertyInfo.rtcReadOnly)
                        label.Enabled = false;
                    UpdateReferencePropertyControls(PropertyName);

                }
            }
        }

        private void BindingControls_NumericUpDown()
        {
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;
            var c = GlobFuncs.GetAll(this, typeof(NumericUpDown));
            if (c != null && c.Any())
            {
                NumericUpDown numericUpDown = null;
                foreach (Control item in c)
                {
                    numericUpDown = (NumericUpDown)item;
                    if (!numericUpDown.Name.StartsWith(cStrings.RTC)) continue;

                    string PropertyName = numericUpDown.Name.Substring(3, numericUpDown.Name.Length - 3);

                    propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                    decimal value = decimal.TryParse((propertyInfoValue.GetValue(propertyInfo, null).ToString()), out decimal result) ?  result > 0 ? result : 0 : 0;
                    numericUpDown.Value = value;
                    numericUpDown.ValueChanged -= NumbericUpDown_ValueChangeEvents;
                    numericUpDown.ValueChanged += NumbericUpDown_ValueChangeEvents;

                    numericUpDown.Enabled = !propertyInfo.rtcReadOnly;

                    UpdateReferencePropertyControls(PropertyName);
                }
            }
        }
        private void BindingDataToControls_TrackBarControl()
        {
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;
            var c = GlobFuncs.GetAll(this, typeof(TrackBar));
            if (c != null && c.Any())
            {
                TrackBar rangetb = null;
                foreach (Control item in c)
                {
                    rangetb = (TrackBar)item;
                    if (!rangetb.Name.StartsWith(cStrings.RTC)) continue;
                    string PropertyName = rangetb.Name.Substring(3, rangetb.Name.Length - 3);
                    propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
                    propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

                    if (propertyInfoValue.PropertyType.Name == typeof(List<double>).Name)
                    {
                        if (((List<double>)propertyInfoValue.GetValue(propertyInfo, null)) != null &&
                            ((List<double>)propertyInfoValue.GetValue(propertyInfo, null)).Count > 0)
                        {
                            ((TrackBar)item).Value = Lib.ToInt(((List<double>)propertyInfoValue.GetValue(propertyInfo, null))[0]);
                        }
                    }
                    else
                    {
                        object value = propertyInfoValue.GetValue(propertyInfo, null);
                        if (value == null || value.ToString() == string.Empty || !int.TryParse(value.ToString(), out int iResult))
                        {
                            ((TrackBar)item).Value = ((TrackBar)item).Minimum;
                        }
                        else
                            ((TrackBar)item).Value = int.Parse(value.ToString());
                    }
                    rangetb.ValueChanged -= NormalEditControl_ValueChangedEvents;
                    rangetb.ValueChanged += NormalEditControl_ValueChangedEvents;
                    if (propertyInfo.rtcReadOnly)
                        rangetb.Enabled = false;
                    UpdateReferencePropertyControls(PropertyName);
                }
            }
        }

        private void NumbericUpDown_ValueChangeEvents(object sender, EventArgs e)
        {
            try
            {
                if (GlobVar.LockEvents || e == null) return;
                NumericUpDown spinEdit = (NumericUpDown)sender;
                int iValue = 0;
                if (spinEdit.Value != null)
                    int.TryParse(spinEdit.Value.ToString(), out iValue);

                if (!spinEdit.Validate()) return;


                string PropertyName = spinEdit.Name.Substring(3, spinEdit.Name.Length - 3);

                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
                if (propertyInfo == null) { return; }
                PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                propertyInfoValue.SetValue(propertyInfo, iValue);

                if (PropertyName != string.Empty)
                {
                    Action.SetActionValueToROIPropertiesSelected();

                    //if (Action.ActionType == EActionTypes.GaugeDualROI &&
                    //    PropertyName == nameof(Action.NumberOfRois) &&
                    //    Action.RepeatMeasurement.rtcValue)
                    //{
                    //    Action.InitRoiForGaugeDualRoi();
                    //    GlobVar.fHsmartWindow?.ClearAllROIs();
                    //    GlobVar.fHsmartWindow?.ReViewAllROIs();
                    //}

                    if (Action.AutoRun) RunAction();

                    UpdateReferencePropertyControls(PropertyName);
                    UpdatePropertyValueToPropertyGrid(PropertyName);
                    if (OnPropertyValueChanged != null)
                        OnPropertyValueChanged(PropertyName);
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }

        private void BindingToControls_Button()
        {
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;
            var c = GlobFuncs.GetAll(this, typeof(Button));
            if (c != null && c.Any())
            {
                Button btn = null;
                foreach (Control item in c)
                {
                    btn = (Button)item;
                    if (!btn.Name.StartsWith(cStrings.RTC)) continue;
                    string PropertyName = btn.Name.Substring(3, btn.Name.Length - 3);
                    propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);

                    propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

                    btn.Click -= Button_Click;
                    btn.Click += Button_Click;
                    if (propertyInfo.rtcReadOnly)
                        btn.Enabled = false;
                    UpdateReferencePropertyControls(PropertyName);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            Button button = (Button)sender;
            string PropertyName = button.Name.Substring(3, button.Name.Length - 3);
            RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName)?.GetValue(Action, null);
            if (propertyInfo == null) { return; }
            PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            propertyInfoValue.SetValue(propertyInfo, true);
            RunAction(false, true);
            if (Action.ActionType == EActionTypes.Metrology && PropertyName == nameof(Action.TabPassActive))
                Action.TabPassActive.rtcValue = false;
            ReviewAllPropertyValueToViewInfo();
        }

        private void Button_KeyDownEvents(object sender, KeyEventArgs e)
        {

            try
            {
                if (GlobVar.LockEvents || e == null || e.KeyCode != Keys.Enter) return;
                Button button = (Button)sender;
                string sValue = string.Empty;
                string oldName = Action?.Name.rtcValue;
                if (button.Text != null)
                    sValue = button.Text;

                //if (button.Invalidated()) return;
                string PropertyName = button.Name.Substring(3, button.Name.Length - 3);
                if (PropertyName == cPropertyName.Name && (button.Text == null || sValue == ""))
                    return;

                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName)?.GetValue(Action, null);
                if (propertyInfo == null) { return; }

                PropertyInfo properInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                if (properInfoValue == null) { return; }

                if (properInfoValue.PropertyType.Name == nameof(String))
                {
                    properInfoValue.SetValue(propertyInfo, sValue);
                }
                else if (properInfoValue.PropertyType.Name == nameof(Double))
                {
                    if (sValue.Trim() == "") sValue = "0";
                    properInfoValue.SetValue(propertyInfo, double.Parse(sValue));
                }
                else if (properInfoValue.PropertyType.Name == nameof(Int32))
                {
                    if (sValue.Trim() == "") sValue = "0";
                    properInfoValue.SetValue(propertyInfo, int.Parse(sValue));

                }
                else if (properInfoValue.PropertyType.Name == nameof(SListString))
                {
                    string[] arr = new string[] { };
                    if (Action.ActionType == EActionTypes.Math &&
                        Action.AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Split &&
                        (sValue == cChars.Comma.ToString() || sValue == cChars.Semicolon.ToString()))
                        arr = new string[] { sValue };
                    else if (sValue.Contains(cChars.Comma))
                        arr = sValue.Split(cChars.Comma);
                    else
                        arr = sValue.Split(cChars.Semicolon);
                    SListString value = new SListString();
                    foreach (var t in arr)
                        if (!string.IsNullOrEmpty(t))
                        {
                            if (bool.TryParse(t, out bool bValue))
                                value.rtcValue.Append(t);
                            else
                                value.rtcValue.Append(t);
                        }
                    properInfoValue.SetValue(propertyInfo, value);

                }
                else if (properInfoValue.PropertyType.Name == nameof(SListDouble))
                {
                    string[] arr = new string[] { };
                    if (Action.ActionType == EActionTypes.Math &&
                        Action.AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Split &&
                        (sValue == cChars.Comma.ToString() || sValue == cChars.Semicolon.ToString()))
                        arr = new string[] { sValue };
                    else if (sValue.Contains(cChars.Comma))
                        arr = sValue.Split(cChars.Comma);
                    else
                        arr = sValue.Split(cChars.Semicolon);
                    SListDouble value = new SListDouble();
                    foreach (var t in arr)
                        if (!string.IsNullOrEmpty(t))
                        {
                            if (double.TryParse(t, out double dvalue))
                                value.rtcValue.Append(double.Parse(t));
                            else if (int.TryParse(t, out int ivalue))
                                value.rtcValue.Append(int.Parse(t));
                            else if (long.TryParse(t, out long lValue))
                                value.rtcValue.Append(long.Parse(t));
                        }
                    properInfoValue.SetValue(propertyInfo, value);
                }
                if (PropertyName == cPropertyName.Name)
                {
                    Action.MyNode.Description = sValue;
                    return;
                }
                if (PropertyName != cPropertyName.Name)
                {
                    //Action.se
                }


            }
            catch (Exception ex)
            {

            }
        }


        internal void ReviewAllPropertyValueToViewInfo_Ref_ToControls(List<PropertyInfo> ListOutputPropertyInfo)
        {
            for (int i = 0; i < ListOutputPropertyInfo.Count(); i++)
            {
                UpdatePropertyValueToControls(ListOutputPropertyInfo[i].Name);
            }
        }
        public void ReviewAllPropertyValueToViewInfo()
        {
            try
            {
                GlobVar.LockEvents = true;
                if (this.InvokeRequired)
                    this.Invoke((MethodInvoker)delegate
                    {
                        ReviewAllPropertyValueToViewInfo_Process();
                    });
                else
                    ReviewAllPropertyValueToViewInfo_Process();
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        private void ReviewAllPropertyValueToViewInfo_Process()
        {
            try
            {
                GlobVar.LockEvents = true;
                tlvAction.BeginUpdate();
                if (Action == null || Action.ViewInfo == null)
                    return;
                // 1: Cập nhật hiển thị cho các property của chính tool này
                // + Ouput lên chính nó
                // + Các property có ref đến 1 property của tool khã
                // + các property dạng input nhưng cho phép rtcisReBinding
                var test = Action.GetType().GetProperties().Where(x => (
                (RTCVariableType)x.GetValue(Action, null)) != null &&
                ((RTCVariableType)x.GetValue(Action, null)).rtcActive
                &&
                (
                 ((RTCVariableType)x.GetValue(Action, null)).rtcState == EPropertyState.Output));
                var ListOutputPropertyInfo = Action.GetType().GetProperties().Where(x => (
                (RTCVariableType)x.GetValue(Action, null)) != null &&
                ((RTCVariableType)x.GetValue(Action, null)).rtcActive &&
                (
                 (((RTCVariableType)x.GetValue(Action, null)).rtcState == EPropertyState.Output) ||
                 (((RTCVariableType)x.GetValue(Action, null)).rtcIDRef != Guid.Empty) ||
                   ((RTCVariableType)x.GetValue(Action, null)).rtcIsReBinding
                )
                ).ToList();
                if (ListOutputPropertyInfo != null && ListOutputPropertyInfo.Count > 0)
                {
                    ReviewAllPropertyValueToViewInfo_OutputValue_ToPropertyGrid(ListOutputPropertyInfo);
                    ReviewAllPropertyValueToViewInfo_OutputValue_ToControls(ListOutputPropertyInfo);
                }
                // 2. cập nhật hiển thị các DataItem 
                if (Action.DataItems != null)
                    ReviewAllPropertyValueToViewInfo_DataItem_ToPropertyGrid(Action.DataItems);

                // 3. Cập nhật hiển thị các Operand
                if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                    ReviewAllPropertyValueToViewInfo_DataItem_ToPropertyGrid(Action.MyExpression.Operands);
                UpdateValueToOtherActionsLink();
                ViewPassedToControls();
                switch (Action.ActionType)
                {
                    case EActionTypes.PassFail:
                        ((ucPassFailActionDetails)Action.ViewInfo).LoadLinkData(true);
                        break;
                    case EActionTypes.ImageFilter:
                        ((ucImageFilterActionDetail)Action.ViewInfo).LoadFilterProperty();
                        break;
                    case EActionTypes.ResetTool:
                        ((ucResetToolActionDetail)Action.ViewInfo).LoadLinkData();
                        break;
                    case EActionTypes.DataSet:
                        ((ucDataSetActionDetail)Action.ViewInfo).LoadLinkProperty();
                        break;
                    case EActionTypes.CsvWrite:
                        ((ucCsvWriteActionDetail)Action.ViewInfo).LoadColumnProperty();
                        break;
                    case EActionTypes.LinkValue:
                        ((ucPropertyLinkActionDetail)Action.ViewInfo).LoadLinkProperty();
                        break;
                    case EActionTypes.StringBuilder:
                        GlobVar.LockEvents = true;
                        ((ucStringBuilderDetail)Action.ViewInfo).LoadStringBuilderItems();
                        GlobVar.LockEvents = false;
                        break;
                    default:
                        break;
                }

            }
            finally
            {
                tlvAction.EndUpdate();
            }
        }

        private void ViewPassedToControls()
        {
            if (this.Controls.Find("RTC" + cPropertyName.Passed, true).FirstOrDefault() is Label Lbl && Action.Passed != null)
            {
                Lbl.Text = Action.Passed.rtcValue ? cStrings.Passed : cStrings.Fail;
                Lbl.ForeColor = Action.Passed.rtcValue ? Color.LightGreen : Color.Red;
            }
        }

        private void UpdateValueToOtherActionsLink()
        {
            foreach (cAction action in Action.MyGroup.Actions.Values)
            {
                var listPropertyRefInfo = action.GetType().GetProperties().Where(x =>
                ((RTCVariableType)x.GetValue(action, null)) != null &&
                ((RTCVariableType)x.GetValue(action, null)).rtcIDRef == Action.ID).ToList();

                if (listPropertyRefInfo.Any())
                {
                    action.UpdateValueToOrtherActionsLink_Value(listPropertyRefInfo);
                    if (action.ViewInfo != null)
                    {
                        ((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo_Ref_ToPropertyGrid(listPropertyRefInfo);
                        ((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo_Ref_ToControls(listPropertyRefInfo);

                    }
                }

            }
        }

        public void ReviewAllPropertyValueToViewInfo_Ref_ToPropertyGrid(List<PropertyInfo> ListOutputPropertyInfo)
        {
            if (Action == null)
                return;
            tlvAction.Invoke(new Action(() =>
            {

                try
                {

                    PropertyInfo nProperty;
                    MyPropertiesItem Node = null;
                    RTCVariableType rtcvar = null;
                    for (int i = 0; i < ListOutputPropertyInfo.Count(); i++)
                    {
                        nProperty = ListOutputPropertyInfo[i];
                        Node = FindPropertyNode(nProperty.Name);
                        rtcvar = (RTCVariableType)Action.GetType().GetProperty(nProperty.Name).GetValue(Action, null);
                        if (Node == null) continue;
                        this.Value.PutValue(Node, rtcvar.rtcIDRef != Guid.Empty ? rtcvar.rtcValueView + " " + rtcvar.rtcRef : rtcvar.rtcValueView);
                    }
                }
                catch
                {

                }
            }));
        }

        public void ReviewAllPropertyValueToViewInfo_DataItem_ToPropertyGrid(List<SStringBuilderItem> ListOutputPropertyInfo)
        {
            if (Action == null)
                return;
            tlvAction.Invoke(new Action(() =>
            {
                try
                {
                    for (int i = 0; i < ListOutputPropertyInfo.Count(); i++)
                    {
                        var nProperty = ListOutputPropertyInfo[i];
                        var Node = FindPropertyNode(nProperty.Name);
                        if (Node == null) continue;
                        this.Value.PutValue(Node, nProperty.RefID != Guid.Empty ? nProperty.ValueView + " " + nProperty.Ref : nProperty.ValueView);
                        this.colRefIndex.PutValue(Node, nProperty.RefIndex);
                    }
                }
                finally
                {
                    tlvAction.LockCalc = false;
                }
            }));
        }

        public void ReviewAllPropertyValueToViewInfo_OutputValue_ToControls(List<PropertyInfo> ListOutputPropertyInfo)
        {
            if (Action == null) return;
            for (int i = 0; i < ListOutputPropertyInfo.Count(); i++)
            {
                UpdatePropertyValueToControls(ListOutputPropertyInfo[i].Name);
                UpdateReferencePropertyControls(ListOutputPropertyInfo[i].Name);
            }
        }

        /// <summary>
        /// View kết quả của các biến output action lêm giao diện hiển thị của nó
        /// </summary>
        /// <param name="ListOutputPropertyInfo"></param>
        public void ReviewAllPropertyValueToViewInfo_OutputValue_ToPropertyGrid(List<PropertyInfo> ListOutputPropertyInfo)
        {
            if (Action == null) return;
            try
            {
                //tlvAction.MenuLabelLockGroupingOn;
                for (int i = 0; i < ListOutputPropertyInfo.Count(); i++)
                {
                    var nProperty = ListOutputPropertyInfo[i];
                    RTCVariableType value = (RTCVariableType)Action.GetType().GetProperty(nProperty.Name)?.GetValue(Action, null);
                    if (Value == null) return;
                    var node = FindPropertyNode(nProperty.Name);
                    //var test = FindNode(nProperty.Name);
                    if (node == null) continue;
                    //test.RowObject.GetType().GetProperty("Value").SetValue(this.Value, value.rtcIDRef != Guid.Empty ? value.rtcValueView + " " + value.rtcRef : value.rtcValueView);
                    //if (Node == null) continue;
                    this.Value.PutValue(node, value.rtcIDRef != Guid.Empty ? value.rtcValueView + " " + value.rtcRef : value.rtcValueView);
                    colRefIndex.PutValue(node, value.rtcRefIndex);
                    foreach( MyPropertiesItem childnode in node.child)
                    {
                        string sPropName = (this.PropName).GetValue(childnode).ToString();
                        Object obj = value.GetType().GetProperty(sPropName)?.GetValue(value, null);
                        this.Value.PutValue(childnode, sPropName + (obj != null && obj.ToString() != "" ? " = " + obj.ToString() : ""));
                    }

                }
            }
            finally
            {
                tlvAction.LockCalc = false;
            }
        }
        private MyPropertiesItem FindPropertyNode(String PropertyName)
        {
            {
                foreach (MyPropertiesItem item in tlvAction.Objects)
                {
                    string nodeValue = item.Name;
                    ENodeTypes NodeType = (ENodeTypes)item.NodeType;

                    if (nodeValue.Equals(PropertyName, StringComparison.OrdinalIgnoreCase) && NodeType != null && (ENodeTypes)NodeType == ENodeTypes.Property)
                    {
                        // Trả về node nếu tìm thấy
                        return item;
                    }
                }
                // Trả về null nếu không tìm thấy node
                return null;
            }
        }
        private OLVListItem FindNode(string propNameValue)
        {
            foreach (OLVListItem item in tlvAction.Objects)
            {
                // Kiểm tra giá trị của cột PropName
                object propNameObject = item.RowObject.GetType().GetProperty("Name").GetValue(item.RowObject, null);
                string propName = propNameObject != null ? propNameObject.ToString() : null;

                // So sánh giá trị của cột PropName với giá trị mong muốn
                if (propName == propNameValue)
                {
                    return item; // Trả về Node nếu tìm thấy
                }
            }

            return null; // Trả về null nếu không tìm thấy Node nào với giá trị PropName cần tìm
        }


        private void UpdatePropertyValueToControls(string propertyName)
        {
            if (UpdatePropertyValueToControls_LabelControl(propertyName)) return;
            if (UpdatePropertyValueToControls_RangeMaxMin(propertyName)) return;
            if (UpdatePropertyValueToControls_RangeMaxMinLimit(propertyName)) return;
            if (UpdatePropertyValueToControls_Tolerance(propertyName)) return;
            if (UpdatePropertyValueToControls_ImageLink(propertyName)) return;
            //Quân thêm
            if (UpdatePropertyValueToControls_ObjectLink(propertyName)) return;
            if (UpdatePropertyValueToControls_Origin(propertyName)) return;
            if (UpdatePropertyValueToControls_AloneControls(propertyName)) return;
            if (UpdatePropertyValueToControls_Line(propertyName)) return;

        }
        private bool UpdatePropertyValueToControls_Line(string propertyname)
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucLine));
            if (c != null && c.Any())
            {
                ucLine line = null;
                foreach (Control item in c)
                {
                    line = (ucLine)item;
                    if (line.RTCPropertyName == propertyname)
                    {
                        RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyname).GetValue(Action, null);
                        line.UpdateHTupleValue((List<double>)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue).GetValue(propertyInfo, null));
                        return true;
                    }
                }
            }

            return false;
        }
        private bool UpdatePropertyValueToControls_AloneControls(string propertyName)
        {
            if (propertyName == nameof(Action.Passed))
                return true;
            var c = GlobFuncs.GetAll(this, typeof(CheckBox), propertyName);
            if (c != null && c.Any())
            {
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
                foreach (Control item in c)
                {
                    GlobVar.LockEvents = true;
                    if (propertyInfo != null)
                        item?.Invoke(new Action(() => ((CheckBox)item).Checked = (bool)propertyInfo.GetType()
                            .GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null)));
                    GlobVar.LockEvents = false;
                    return true;
                }
            }

            c = GlobFuncs.GetAll(this, typeof(Label), propertyName);
            if (c != null && c.Any())
            {
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
                foreach (Control item in c)
                {
                    GlobVar.LockEvents = true;
                    if (propertyInfo != null)
                    {
                        if (propertyInfo.GetType().Name == nameof(SListDouble))
                        {
                            SListDouble value = (SListDouble)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null);
                            if (value != null && value.rtcValue.Count > 0)
                            {
                                item?.Invoke(new Action(() => ((Label)item).Text = GlobFuncs.Ve2Str(value)));
                            }
                            else
                                item?.Invoke(new Action(() => ((Label)item).Text = string.Empty));
                        }
                        else
                            item?.Invoke(new Action(() => ((Label)item).Text = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)
                                ?.GetValue(propertyInfo, null).ToString()));
                    }

                    GlobVar.LockEvents = false;
                    return true;
                }
            }
            //c = GlobFuncs.GetAll(this, typeof(ListBox), propertyName);
            //if (c != null && c.Any())
            //{
            //    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
            //    foreach (Control item in c)
            //    {
            //        GlobVar.LockEvents = true;
            //        ((ListBox)item).Items.Clear();
            //        if (propertyInfo != null)
            //        {
            //            if (propertyInfo.GetType().Name == nameof(SListDouble))
            //            {
            //                List<double> value = (List<double>)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null);
            //                if (value != null && value.Count > 0)
            //                {
            //                    for (int i = 0; i < value.Count; i++)
            //                    {
            //                        switch (value)
            //                        {
            //                            case HTupleType.DOUBLE:
            //                                item?.Invoke(new Action(() => ((ListBoxControl)item).Items.Add(value.TupleSelect(i).D)));
            //                                break;
            //                            case HTupleType.INTEGER:
            //                                item?.Invoke(new Action(() => ((ListBoxControl)item).Items.Add(value.TupleSelect(i).I)));
            //                                break;
            //                            case HTupleType.LONG:
            //                                item?.Invoke(new Action(() => ((ListBoxControl)item).Items.Add(value.TupleSelect(i).L)));
            //                                break;
            //                            case HTupleType.STRING:
            //                                item?.Invoke(new Action(() => ((ListBoxControl)item).Items.Add(value.TupleSelect(i).S)));
            //                                break;
            //                            default:
            //                                item?.Invoke(new Action(() => ((ListBoxControl)item).Items.Add(value.TupleSelect(i).ToString())));
            //                                break;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //                item?.Invoke(new Action(() => ((ListBoxControl)item).Items.Add(new HTuple((string)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)
            //                    ?.GetValue(propertyInfo, null)))));
            //        }

            //        GlobVar.LockEvents = false;
            //        return true;
            //    }
            //}
            c = GlobFuncs.GetAll(this, typeof(TextBox), propertyName);
            if (c != null && c.Any())
            {
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
                foreach (Control item in c)
                {
                    item?.Invoke(new Action(() => ((TextBox)item).Text = string.Empty));

                    GlobVar.LockEvents = true;

                    if (propertyInfo != null)
                    {
                        var test = propertyInfo.GetType().Name;
                        if (propertyInfo.GetType().Name == nameof(SListDouble))
                        {
                            List<double> value = (List<double>)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)
                                ?.GetValue(propertyInfo, null);
                            if (value != null && value.Count > 0)
                                for (int i = 0; i < value.Count; i++)
                                    item?.Invoke(new Action(() =>
                                        ((TextBox)item).Text = ((TextBox)item).Text +
                                                                      (((TextBox)item).Text.ToString() ==
                                                                       string.Empty
                                                                          ? ""
                                                                          : ",") + GlobFuncs.Ve2Str(value[i])));
                        }
                        else if (propertyInfo.GetType().Name == nameof(SListString))
                        {
                            List<string> value = (List<String>)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)
                                ?.GetValue(propertyInfo, null);
                            if (value != null && value.Count > 0)
                                for (int i = 0; i < value.Count; i++)
                                    item?.Invoke(new Action(() =>
                                        ((TextBox)item).Text = ((TextBox)item).Text +
                                                                      (((TextBox)item).Text.ToString() ==
                                                                       string.Empty
                                                                          ? ""
                                                                          : ",") + GlobFuncs.Ve2Str(value[i])));
                        }
                        else if (propertyInfo.GetType().Name == nameof(SListObject))
                        {
                            List<object> value = (List<object>)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)
                                ?.GetValue(propertyInfo, null);
                            if (value != null && value.Count > 0)
                                for (int i = 0; i < value.Count; i++)
                                    item?.Invoke(new Action(() =>
                                        ((TextBox)item).Text = ((TextBox)item).Text +
                                                                      (((TextBox)item).Text.ToString() ==
                                                                       string.Empty
                                                                          ? ""
                                                                          : ",") + GlobFuncs.Ve2Str(value[i])));
                        }
                    }
                    GlobVar.LockEvents = false;
                    return true;
                }
            }
            c = GlobFuncs.GetAll(this, typeof(ComboBox), propertyName);
            if (c != null && c.Any())
            {
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
                foreach (Control item in c)
                {
                    GlobVar.LockEvents = true;
                    if (propertyInfo != null)
                        item?.Invoke(new Action(() =>
                            ((ComboBox)item).SelectedItem = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)
                                ?.GetValue(propertyInfo, null).ToString()));
                    GlobVar.LockEvents = false;
                    return true;
                }
            }
            //c = GlobFuncs.GetAll(this, typeof(RangeTrackBarControl), propertyName);
            //if (c != null && c.Any())
            //{
            //    PropertyInfo propertyInfo = Action.GetType().GetProperty(propertyName);
            //    foreach (Control item in c)
            //    {
            //        GlobVar.LockEvents = true;
            //        if (propertyInfo != null)
            //        {
            //            if (propertyInfo.PropertyType.Name == nameof(SHTuple))
            //            {
            //                SHTuple propertyValue = (SHTuple)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
            //                if (propertyValue != null)
            //                    item?.Invoke(new Action(() =>
            //                        ((RangeTrackBarControl)item).Value =
            //                        new TrackBarRange(1, propertyValue.rtcValue[0])));
            //            }
            //            else
            //            {
            //                object value = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null);
            //                if (value == null || value.ToString() == string.Empty || !int.TryParse(value.ToString(), out int iResult))
            //                {
            //                    item?.Invoke(new Action(() => ((RangeTrackBarControl)item).Value = new TrackBarRange(1, 1)));
            //                }
            //                else
            //                    item?.Invoke(new Action(() => ((RangeTrackBarControl)item).Value = new TrackBarRange(1, int.Parse(value.ToString()))));
            //            }
            //        }

            //        GlobVar.LockEvents = false;
            //        return true;
            //    }
            //}

            //c = GlobFuncs.GetAll(this, typeof(TrackBarControl), propertyName);
            //if (c != null && c.Any())
            //{
            //    PropertyInfo propertyInfo = Action.GetType().GetProperty(propertyName);
            //    foreach (Control item in c)
            //    {
            //        GlobVar.LockEvents = true;
            //        if (propertyInfo != null)
            //        {
            //            if (propertyInfo.PropertyType.Name == nameof(SHTuple))
            //            {
            //                SHTuple propertyValue = (SHTuple)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
            //                if (propertyValue != null)
            //                    item?.Invoke(new Action(() => ((TrackBarControl)item).Value = propertyValue.rtcValue[0]));
            //            }
            //            else
            //            {
            //                object value = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null);
            //                if (value == null || value.ToString() == string.Empty || !int.TryParse(value.ToString(), out int iResult))
            //                    item?.Invoke(new Action(() => ((TrackBarControl)item).Value = ((TrackBarControl)item).Properties.Minimum));
            //                else
            //                    item?.Invoke(new Action(() => ((TrackBarControl)item).Value = int.Parse(value.ToString())));
            //            }
            //        }

            //        GlobVar.LockEvents = false;
            //        return true;
            //    }
            //}

            return false;
        }

        private bool UpdatePropertyValueToControls_Tolerance(string propertyName)
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucTolerance));
            if (c != null && c.Any())
            {
                ucTolerance tolerance = null;
                foreach (Control item in c)
                {
                    tolerance = (ucTolerance)item;
                    if (tolerance.RTCCheckboxPropertyName == propertyName)
                    {
                        RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName).GetValue(Action, null);
                        tolerance.UpdateCheckboxValue((bool)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue).GetValue(propertyInfo, null));
                        return true;
                    }
                    else if (tolerance.RTCPropertyName == propertyName)
                    {
                        RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName).GetValue(Action, null);
                        tolerance.UpdateValue((List<double>)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue).GetValue(propertyInfo, null));
                        return true;
                    }
                }
            }

            return false;
        }

        public void UpdatePropertyValueToAllControls(string propertyName)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    UpdatePropertyValueToControls(propertyName);
                    UpdatePropertyValueToPropertyGrid(propertyName);
                }));
            else
            {
                UpdatePropertyValueToControls(propertyName);
                UpdatePropertyValueToPropertyGrid(propertyName);
            }
        }
        private bool UpdatePropertyValueToControls_Origin(string propertyName)
        {
            var c = GlobFuncs.GetAllControls(this, typeof(ucOrigin));
            if (c != null || c.Any())
            {
                ucOrigin origin = null;
                foreach (Control item in c)
                {
                    origin = (ucOrigin)item;
                    if (origin.PropertyName == propertyName)
                    {
                        GlobVar.LockEvents = true;
                        origin.Action = Action;
                        GlobVar.LockEvents = false;
                        return true;
                    }
                }

            }
            return false;
        }

        private bool UpdatePropertyValueToControls_ImageLink(string propertyName)
        {
            var c = GlobFuncs.GetAllControls(this, typeof(ucImageLink));
            if (c != null || c.Any())
            {
                ucImageLink imagelink = null;
                foreach (Control item in c)
                {
                    imagelink = (ucImageLink)item;
                    if (imagelink.PropertyName == propertyName)
                    {
                        GlobVar.LockEvents = true;
                        imagelink.Action = Action;
                        GlobVar.LockEvents = false;
                        return true;
                    }
                }

            }
            return false;
        }
        //QUÂN THÊM
        private bool UpdatePropertyValueToControls_ObjectLink(string propertyName)
        {
            var c = GlobFuncs.GetAllControls(this, typeof(ucObjectLink));
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    var objectlink = (ucObjectLink)item;
                    if (objectlink.RTCPropertyName == propertyName)
                    {
                        GlobVar.LockEvents = true;
                        objectlink.RTCAction = Action;
                        GlobVar.LockEvents = false;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool UpdatePropertyValueToControls_RangeMaxMinLimit(string propertyname)
        {
            var c = GlobFuncs.GetAllControls(this, typeof(ucRangeMaxMinLimit));
            if (c == null || !c.Any()) return false;
            {
                ucRangeMaxMinLimit rangemaxmin = null;

                foreach (Control item in c)
                {
                    rangemaxmin = (ucRangeMaxMinLimit)item;
                    if (rangemaxmin.RTCPropertyName == propertyname)
                    {
                        RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyname).GetValue(Action, null);
                        List<double> value = (List<double>)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue).GetValue(propertyInfo, null);
                        GlobVar.LockEvents = true;
                        rangemaxmin.RTCEndValue = value[1];
                        rangemaxmin.RTCBeginValue = value[0];
                        rangemaxmin.RTCMax = value[3];
                        rangemaxmin.RTCMin = value[2];
                        GlobVar.LockEvents = false;
                        return true;
                    }
                }
            }
            return false;
        }
        private bool UpdatePropertyValueToControls_RangeMaxMin(string propertyName)
        {
            var c = GlobFuncs.GetAllControls(this, typeof(ucRangeMaxMin));
            if (c == null || !c.Any()) return false;

            foreach (Control item in c)
            {
                ucRangeMaxMin rangeMaxMin = (ucRangeMaxMin)item;
                if (rangeMaxMin.RTCCheckboxPropertyName == propertyName)
                {
                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName).GetValue(Action, null);
                    if (propertyInfo != null)
                    {
                        rangeMaxMin.UpdateCheckboxValue((bool)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null));
                        return true;
                    }
                }
                else if (rangeMaxMin.RTCValuePropertyName == propertyName)
                {
                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
                    if (propertyInfo != null)
                        if (propertyInfo.GetType().Name == "SListDouble")
                            rangeMaxMin.UpdateValue((List<double>)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null));
                        else
                            rangeMaxMin.UpdateMixValue((List<object>)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null));
                    return true;
                }
                else if (rangeMaxMin.RTCActualPropertyName == propertyName)
                {
                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
                    if (propertyInfo != null)
                    {
                        switch (propertyInfo.GetType().Name)
                        {
                            case nameof(SInt):
                                {
                                    SInt intValue = (SInt)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
                                    rangeMaxMin.UpdateActualValue(new List<double> { intValue.rtcValue });
                                    break;
                                }
                            case nameof(SDouble):
                                {
                                    SDouble doubleValue = (SDouble)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
                                    rangeMaxMin.UpdateActualValue(new List<double> { doubleValue.rtcValue });
                                    break;
                                }
                            case nameof(SListDouble):
                                {
                                    var test = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null);
                                    rangeMaxMin.UpdateActualValue((List<double>)propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null));
                                    break;
                                }

                        }
                    }
                    return true;
                }
            }

            return false;
        }

        private bool UpdatePropertyValueToControls_LabelControl(string propertyName)
        {
            var c = GlobFuncs.GetAllControls(this, typeof(Label));
            if (c == null || !c.Any()) return true;
            foreach (Control item in c)
            {
                if (((Label)item).Name == cStrings.RTC + propertyName)
                {
                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyName)?.GetValue(Action, null);
                    if (propertyInfo != null)
                    {
                        object obj = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue)?.GetValue(propertyInfo, null);
                        if (obj != null)
                            if (propertyName == nameof(Action.Passed))
                                ((Label)item).Text =
                                    GlobFuncs.GetBoolValueFromObject(obj) ? cStrings.Passed : cStrings.Fail;
                            else if (obj.GetType() == typeof(List<string>))
                                ((Label)item).Text = GlobFuncs.Ve2Str(obj);
                            else
                                ((Label)item).Text = obj.ToString();
                    }
                    return true;
                }
                
            }
            return false;
        }

        public void BindingToControls_TextBox()
        {
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;
            var c = GlobFuncs.GetAll(this, typeof(TextBox));
            if (c != null && c.Any())
            {
                TextBox txt = null;
                foreach (Control item in c)
                {
                    txt = (TextBox)item;
                    if (!txt.Name.StartsWith(cStrings.RTC)) continue;
                    txt.Text = string.Empty;
                    string PropertyName = txt.Name.Substring(3, txt.Name.Length - 3);
                    propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
                    if (propertyInfo == null) { continue; }
                    propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

                    if (propertyInfoValue != null)
                    {
                        if (propertyInfo.GetType().Name == nameof(SListString))
                        {
                            List<string> value = (List<string>)propertyInfoValue.GetValue(propertyInfo, null);
                            if (value != null && value.Count > 0)
                                for (int i = 0; i < value.Count; i++)
                                    txt.Text = txt.Text + (txt.Text.ToString() == string.Empty ? "" : ",") + GlobFuncs.Ve2Str(value[i]);
                        }
                        else if (propertyInfo.GetType().Name == nameof(SListDouble))
                        {
                            List<double> value = (List<double>)propertyInfoValue.GetValue(propertyInfo, null);
                            if (value != null && value.Count > 0)
                                for (int i = 0; i < value.Count; i++)
                                    txt.Text = txt.Text + (txt.Text.ToString() == string.Empty ? "" : ",") + GlobFuncs.Ve2Str(value[i]);
                        }
                        else if (propertyInfo.GetType().Name == nameof(SListObject))
                        {
                            List<object> value = (List<object>)propertyInfoValue.GetValue(propertyInfo, null);
                            if (value != null && value.Count > 0)
                                for (int i = 0; i < value.Count; i++)
                                    txt.Text = txt.Text + (txt.Text.ToString() == string.Empty ? "" : ",") + GlobFuncs.Ve2Str(value[i]);
                        }
                        else
                        {
                            txt.Text = propertyInfoValue.GetValue(propertyInfo, null).ToString();
                        }
                    }
                    txt.KeyDown -= TextBox_KeyDownEvents;
                    txt.KeyDown += TextBox_KeyDownEvents;
                    txt.LostFocus -= TextBox_LostFocusEvents;
                    txt.LostFocus += TextBox_LostFocusEvents;


                    txt.Enabled = !propertyInfo.rtcReadOnly;
                    if (PropertyName == cPropertyName.Name)
                    {
                        txt.Enabled = Action._CanChangeName;
                        txt.Validating += ToolName_Validating;
                    }
                    UpdateReferencePropertyControls(PropertyName);
                }
            }

        }

        private void TextBox_LostFocusEvents(object sender, EventArgs e)
        {
            try
            {
                TextBox textbox = (TextBox)sender;
                string sValue = string.Empty;
                string oldName = Action?.Name.rtcValue;
                if (textbox.Text != null)
                    sValue = textbox.Text.ToString();
                //if (textbox.Invalidated()) return;
                string PropertyName = textbox.Name.Substring(3, textbox.Name.Length - 3);
                if (PropertyName == cPropertyName.Name && (textbox.Text == null || sValue == ""))
                    return;

                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName)?.GetValue(Action, null);
                if (propertyInfo == null) { return; }

                PropertyInfo properInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                if (properInfoValue == null) { return; }

                if (properInfoValue.PropertyType.Name == nameof(String))
                {
                    properInfoValue.SetValue(propertyInfo, sValue);
                }
                else if (properInfoValue.PropertyType.Name == nameof(Double))
                {
                    if (sValue.Trim() == "") sValue = "0";
                    properInfoValue.SetValue(propertyInfo, double.Parse(sValue));
                }
                else if (properInfoValue.PropertyType.Name == nameof(Int32))
                {
                    if (sValue.Trim() == "") sValue = "0";
                    properInfoValue.SetValue(propertyInfo, int.Parse(sValue));

                }
                else if (propertyInfo.GetType().Name == nameof(SListString))
                {
                    string[] arr = new string[] { };
                    if (Action.ActionType == EActionTypes.Math &&
                        Action.AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Split &&
                        (sValue == cChars.Comma.ToString() || sValue == cChars.Semicolon.ToString()))
                        arr = new string[] { sValue };
                    else if (sValue.Contains(cChars.Comma))
                        arr = sValue.Split(cChars.Comma);
                    else
                        arr = sValue.Split(cChars.Semicolon);
                    List<string> value = new List<string>();
                    foreach (var t in arr)
                        if (!string.IsNullOrEmpty(t))
                        {
                            if (bool.TryParse(t, out bool bValue))
                                value.Add(t);
                            else
                                value.Add(t);
                        }
                    properInfoValue.SetValue(propertyInfo, value);

                }
                else if (propertyInfo.GetType().Name == nameof(SListDouble))
                {
                    string[] arr = new string[] { };
                    if (Action.ActionType == EActionTypes.Math &&
                        Action.AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Split &&
                        (sValue == cChars.Comma.ToString() || sValue == cChars.Semicolon.ToString()))
                        arr = new string[] { sValue };
                    else if (sValue.Contains(cChars.Comma))
                        arr = sValue.Split(cChars.Comma);
                    else
                        arr = sValue.Split(cChars.Semicolon);
                    SListDouble value = new SListDouble();
                    foreach (var t in arr)
                        if (!string.IsNullOrEmpty(t))
                        {
                            if (double.TryParse(t, out double dvalue))
                                value.rtcValue.Append(double.Parse(t));
                            else if (int.TryParse(t, out int ivalue))
                                value.rtcValue.Append(int.Parse(t));
                            else if (long.TryParse(t, out long lValue))
                                value.rtcValue.Append(long.Parse(t));
                        }
                    properInfoValue.SetValue(propertyInfo, value);
                }
                if (PropertyName == cPropertyName.Name)
                {
                    Action.MyNode.Description = sValue;
                    return;
                }
                if (PropertyName != cPropertyName.Name)
                {

                    Action.SetActionValueToROIPropertiesSelected();

                    if (Action.AutoRun) RunAction();
                    UpdateReferencePropertyControls(PropertyName);
                    UpdatePropertyValueToPropertyGrid(PropertyName);
                    if (OnPropertyValueChanged != null)
                        OnPropertyValueChanged(PropertyName);

                    //Action.test.row
                }


            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        public void RemoveEventToControls()
        {
            RemoveEventToControls_Button();
            RemoveEventToControls_Checkbox();
            RemoveEventToControls_Label();
        }
        private void RemoveEventToControls_Button()
        {
            var c = GlobFuncs.GetAll(this, typeof(Button), "btnRunMultiROI", false);
            if (c != null && c.Any())
            {
                Button button = (Button)c.First();
                button.Click -= btnRunMultiROI_Clicked;

            }
        }
        private void RemoveEventToControls_Label()
        {
            var c = GlobFuncs.GetAll(this, typeof(Label), "lblSetupPassed", false);
            if (c != null && c.Any())
            {
                Label labelcontrol = (Label)c.First();
                labelcontrol.Click -= lblSetupPassed_Clicked;
            }
            c = GlobFuncs.GetAll(this, typeof(Label), "lblSetPropertiesToOtherROI", false);
            if (c != null && c.Any())
            {
                Label labelcontrol = (Label)c.First();
                labelcontrol.Click -= lblSetPropertiesToOtherROI_Clicked;
            }
        }
        private void RemoveEventToControls_Checkbox()
        {
            var c = GlobFuncs.GetAll(this, typeof(CheckBox), "chkRunOnlyROISelect", false);
            if (c != null && c.Any())
            {
                CheckBox checkedit = (CheckBox)c.First();
                checkedit.CheckedChanged -= chkRunOnlyROISelect_CheckedChanged;
            }
        }
        private void BinddingEventToControls()
        {
            BinddingEventToControls_Button();
            BinddingEventToControls_Checkbox();
            BinddingEventToControls_Label();
        }
        private void BinddingEventToControls_Button()
        {
            var c = GlobFuncs.GetAll(this, typeof(Button), "btnRunMultiROI", false);
            if (c != null && c.Any())
            {
                Button button = (Button)c.First();
                button.Click -= btnRunMultiROI_Clicked;
                button.Click += btnRunMultiROI_Clicked;
            }
            if (Action.ActionType == EActionTypes.CalibrateEdgetoEdge)
            {
                c = GlobFuncs.GetAll(this, typeof(Button), "btnGetLineCalibEtoE", false);
                //if (c != null && c.Any())
                //{
                //    Button button = (Button)c.First();
                //    button.Click -= btnGetLineCalibEtoE_Clicked;
                //    button.Click += btnGetLineCalibEtoE_Clicked;
                //}
            }
        }
        private void BinddingEventToControls_Label()
        {
            var c = GlobFuncs.GetAll(this, typeof(Label), "lblSetupPassed", false);
            if (c != null && c.Any())
            {
                Label labelcontrol = (Label)c.First();
                labelcontrol.Cursor = Cursors.Hand;
                labelcontrol.Click += lblSetupPassed_Clicked;
            }

            c = GlobFuncs.GetAll(this, typeof(Label), "lblSetPropertiesToOtherROI", false);
            if (c != null && c.Any())
            {
                Label labelcontrol = (Label)c.First();
                labelcontrol.Cursor = Cursors.Hand;
                labelcontrol.Click += lblSetPropertiesToOtherROI_Clicked;
            }
        }
        private void BinddingEventToControls_Checkbox()
        {
            var c = GlobFuncs.GetAll(this, typeof(CheckBox), "chkRunOnlyROISelect", false);
            if (c != null && c.Any())
            {
                CheckBox checkedit = (CheckBox)c.First();
                checkedit.Checked = Action.RunOnlyROISelected;
                checkedit.CheckedChanged -= chkRunOnlyROISelect_CheckedChanged;
                checkedit.CheckedChanged += chkRunOnlyROISelect_CheckedChanged;
            }
        }
        private void chkRunOnlyROISelect_CheckedChanged(object sender, EventArgs e)
        {
            Action.RunOnlyROISelected = ((CheckBox)sender).Checked;
            var c = GlobFuncs.GetAll(this, typeof(Label), "lblSetupPassed", false);
            if (c != null && c.Any())
            {
                Label labelcontrol = (Label)c.First();
                labelcontrol.Visible = !Action.RunOnlyROISelected;
            }
        }
        private void lblSetupPassed_Clicked(object sender, EventArgs e)
        {
            frmSetupPassed frmSetupPassed = new frmSetupPassed();
            frmSetupPassed.RTCSetupPassed = true;
            frmSetupPassed.Action = Action;
            if (frmSetupPassed.ShowDialog() == DialogResult.OK)
            {
                if (Action.frmHsmartWindow != null)
                {
                    Action.frmHsmartWindow.ClearAllRoi();
                    Action.frmHsmartWindow.ReviewAllROIS(true);
                }
            }
        }
        private void lblSetPropertiesToOtherROI_Clicked(object sender, EventArgs e)
        {
            if (Action.ROIProperties == null || Action.ROIProperties.Count <= 0) return;

            frmSetupPassed frmSetupPassed = new frmSetupPassed();
            frmSetupPassed.RTCSetupPassed = false;
            frmSetupPassed.Action = Action;
            frmSetupPassed.ShowDialog();
        }
        private void btnRunMultiROI_Clicked(object sender, EventArgs e)
        {
            RunAction();
        }
        private void UpdateReferencePropertyControls(string PropertyName)
        {
            UpdateReferencePropertyControls_Process(PropertyName);

        }

        private void UpdateReferencePropertyControls_Process(string PropertyName)
        {
            if (Action.GetType().GetProperty(PropertyName) == null)
                return;
            RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null);
            if (propertyInfo == null) { return; }
            PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            string PropertyValue = GlobFuncs.Object2Str(propertyInfoValue.GetValue(propertyInfo, null));
            DataRow[] Reference = CommonData.GetReferenceProperties(Enum.GetName(typeof(EActionTypes),
                Action.ActionType), PropertyName, PropertyValue);

            if (Reference == null || Reference.Count() == 0) return;
            string SecondaryPropertyValue = string.Empty;
            RTCVariableType SecondarypropertyInfo = null;
            PropertyInfo SecondarypropertyInfoValue = null;

            string PrimaryPropFlag = string.Empty;
            string SecondaryPropFlag = string.Empty;
            string PrimaryPropFlagValue = string.Empty;
            string SecondaryPropFlagValue = string.Empty;

            string[] PropSetEnable = new string[] { };
            string[] PropSetDisable = new string[] { };
            string[] PropSetVisible = new string[] { };
            string[] PropSetInvisible = new string[] { };
            string[] PropSetValue = new string[] { };
            string[] PropGetValue = new string[] { };
            string[] PropFixedValue = new string[] { };
            bool Result = false;
            foreach (DataRow r in Reference)
            {
                PrimaryPropFlag = r[cColName.PrimaryPropFlag].ToString();
                SecondaryPropFlag = r[cColName.SecondaryPropFlag].ToString();
                PrimaryPropFlagValue = r[cColName.PrimaryPropFlagValue].ToString();
                SecondaryPropFlagValue = r[cColName.SecondaryPropFlagValue].ToString();
                PropSetEnable = r[cColName.PropSetEnable].ToString().Split(cStrings.SepPhay);
                PropSetDisable = r[cColName.PropSetDisable].ToString().Split(cStrings.SepPhay);
                PropSetVisible = r[cColName.PropSetVisible].ToString().Split(cStrings.SepPhay);
                PropSetInvisible = r[cColName.PropSetInvisible].ToString().Split(cStrings.SepPhay);
                PropSetValue = r[cColName.PropSetValue].ToString().Split(cStrings.SepPhay);
                PropGetValue = r[cColName.PropGetValue].ToString().Split(cStrings.SepPhay);
                PropFixedValue = r[cColName.FixedValue].ToString().Split(cStrings.SepPhay);

                Result = false;
                if (PrimaryPropFlag != "" && PropertyName == PrimaryPropFlag)
                {
                    if (!CheckContainsValue(PrimaryPropFlagValue, PropertyValue, cStrings.SepGDung)) continue;
                    if (SecondaryPropFlag != "")
                    {
                        SecondarypropertyInfo = (RTCVariableType)Action.GetType().GetProperty(SecondaryPropFlag).GetValue(Action, null);
                        SecondarypropertyInfoValue = SecondarypropertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

                        SecondaryPropertyValue = GlobFuncs.Object2Str(SecondarypropertyInfoValue.GetValue(SecondarypropertyInfo, null));
                        if (!CheckContainsValue(SecondaryPropFlagValue, SecondaryPropertyValue, cStrings.SepGDung)) continue;
                    }
                    Result = true;
                }
                else if (SecondaryPropFlag != "" && PropertyName == SecondaryPropFlag)
                {
                    if (!CheckContainsValue(SecondaryPropFlagValue, PropertyValue, cStrings.SepGDung)) continue;
                    if (PrimaryPropFlag != "")
                    {
                        SecondarypropertyInfo = (RTCVariableType)Action.GetType().GetProperty(PrimaryPropFlag).GetValue(Action, null);
                        SecondarypropertyInfoValue = SecondarypropertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

                        SecondaryPropertyValue = GlobFuncs.Object2Str(SecondarypropertyInfoValue.GetValue(SecondarypropertyInfo, null));
                        if (!CheckContainsValue(PrimaryPropFlagValue, SecondaryPropertyValue, cStrings.SepGDung)) continue;
                    }
                    Result = true;
                }
                else if (PropGetValue.Contains(PropertyName))
                {
                    if (PrimaryPropFlag != "")
                    {
                        SecondarypropertyInfo = (RTCVariableType)Action.GetType().GetProperty(PrimaryPropFlag).GetValue(Action, null);
                        SecondarypropertyInfoValue = SecondarypropertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

                        SecondaryPropertyValue = GlobFuncs.Object2Str(SecondarypropertyInfoValue.GetValue(SecondarypropertyInfo, null));
                        if (!CheckContainsValue(PrimaryPropFlagValue, SecondaryPropertyValue, cStrings.SepGDung)) continue;
                    }
                    if (SecondaryPropFlag != "")
                    {
                        SecondarypropertyInfo = (RTCVariableType)Action.GetType().GetProperty(SecondaryPropFlag).GetValue(Action, null);
                        SecondarypropertyInfoValue = SecondarypropertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

                        SecondaryPropertyValue = GlobFuncs.Object2Str(SecondarypropertyInfoValue.GetValue(SecondarypropertyInfo, null));
                        if (!CheckContainsValue(SecondaryPropFlagValue, SecondaryPropertyValue, cStrings.SepGDung)) continue;
                    }
                    if (PropSetValue.Length > 0 && PropSetValue.Length == PropGetValue.Length)
                        for (int i = 0; i < PropSetValue.Length; i++)
                        {
                            SetValueControlsByPropertyName(PropSetValue[i], PropGetValue[i]);
                        }
                    continue;

                }
                if (!Result) continue;
                // bắt đầu xét đến việc set trạng thái của các control khác theo yêu cầu
                // ưu tiên việc visible trước sau đó mới đến enable 
                foreach (string s in PropSetVisible) if (s != string.Empty) VisibleControlsByPropertyName(s.Trim());
                foreach (string s in PropSetInvisible) if (s != string.Empty) InvisibleControlsByPropertyName(s.Trim());
                foreach (string s in PropSetEnable) if (s != string.Empty) EnableControlsByPropertyName(s.Trim());
                foreach (string s in PropSetDisable) if (s != string.Empty) DisableControlsByPropertyName(s.Trim());
                foreach (string s in PropFixedValue) if (s != string.Empty) FixedValueByPropertyName(s.Trim());

                if (PropSetValue.Length > 0 && PropSetValue.Length == PropGetValue.Length)
                    for (int i = 0; i < PropSetValue.Length; i++)
                    {
                        SetValueControlsByPropertyName(PropSetValue[i], PropGetValue[i]);
                    }
            }




        }
        private void FixedValueByPropertyName(string PropertyName)
        {
            // tách tên thuộc tính
            List<string> values = PropertyName.Split(cChars.VerticalBar).ToList();
            if (values.Count <= 1)
                return;
            PropertyName = values[0];
            values.RemoveAt(0);
            var c = GlobFuncs.GetAll(this, PropertyName);
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    if (item.GetType() == typeof(ComboBox))
                    {
                        ComboBox comboBox = (ComboBox)item;
                        comboBox.Items.Clear();
                        foreach (string s in values)
                            comboBox.Items.Add(s);
                        if (comboBox.Items.Count > 0)
                            comboBox.SelectedIndex = 0;

                    }
                }
            }
        }
        private void EnableControlsByPropertyName(string PropertyName)
        {
            var c = GlobFuncs.GetAll(this, PropertyName);
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    item.Enabled = true;
                }
            }
            c = GlobFuncs.GetAll(this, PropertyName, false);
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    item.Enabled = true;
                }
            }
        }

        private void DisableControlsByPropertyName(string PropertyName)
        {
            var c = GlobFuncs.GetAll(this, PropertyName);
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    item.Enabled = false;
                }
            }
            c = GlobFuncs.GetAll(this, PropertyName, false);
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    item.Enabled = false;
                }
            }
        }

        private void InvisibleControlsByPropertyName(string PropertyName)
        {
            var c = GlobFuncs.GetAll(this, PropertyName);
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    item.Visible = false;
                }
            }
            c = GlobFuncs.GetAll(this, PropertyName, false);
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    item.Visible = false;
                }
            }
        }

        private void VisibleControlsByPropertyName(string PropertyName)
        {
            var c = GlobFuncs.GetAll(this, PropertyName);
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    item.Visible = true;
                }
            }
            c = GlobFuncs.GetAll(this, PropertyName, false);
            if (c != null && c.Any())
            {
                foreach (Control item in c)
                {
                    item.Visible = true;
                }
            }
        }

        private void SetValueControlsByPropertyName(string PropSetValue, string PropGetValue)
        {
            if (PropSetValue == string.Empty || PropGetValue == string.Empty)
                return;
            string PropertyValue = string.Empty;
            PropertyInfo PropGetValue_Value = null;
            RTCVariableType PropGetValueInfo = (RTCVariableType)Action.GetType().GetProperty(PropGetValue)?.GetValue(Action, null);
            if (PropGetValueInfo == null)
                PropertyValue = PropGetValue;
            else
            {
                PropGetValue_Value = PropGetValueInfo.GetType().GetProperty(cPropertyName.rtcValue);
                PropertyValue = GlobFuncs.Object2Str(PropGetValue_Value.GetValue(PropGetValueInfo, null));
            }
            var c = GlobFuncs.GetAll(this, PropSetValue);
            if (c != null && c.Any())
            {
                GlobVar.LockEvents = true;
                Control item = c.First();
                if (item.GetType() == typeof(CheckBox))
                    GlobFuncs.SetCheckBoxValue((CheckBox)item, bool.Parse(PropertyValue));
                else if (item.GetType() == typeof(TextBox))
                    GlobFuncs.SetTextBoxValueByStyle((TextBox)item, PropertyValue);
                else if (item.GetType() == typeof(ComboBox))
                    GlobFuncs.SetComboBoxValue((ComboBox)item, PropertyValue);
                else if (item.GetType() == typeof(ucRangeMaxMinLimit))
                    ((ucRangeMaxMinLimit)item).SetValue((SListDouble)PropGetValueInfo);
                GlobVar.LockEvents = false;
            }
        }

        private bool CheckContainsValue(string parentString, string propName, char sep)
        {
            if (parentString.Contains(sep))
            {
                return parentString.StartsWith(propName + sep)
                    || parentString.EndsWith(sep + propName) || parentString.Contains(sep + propName + sep);
            }
            else
            {
                return parentString == propName;
            }
        }

        private void ToolName_Validating(object sender, CancelEventArgs e)
        {
            if (GlobVar.LockEvents) return;
            TextBox textbox = (TextBox)sender;
            if (textbox.Text == null || textbox.Text.Trim() == "")
            {
                textbox.Text = Action.Name.rtcValue;
                e.Cancel = false;
            }
            else
            {
                foreach (cAction item in GlobVar.GroupActions.Actions.Values)
                    if (item.ID != Action.ID && item.Name.rtcValue.ToLower() == textbox.Text.Trim().ToLower())
                    {
                        errorProvider1.SetIconAlignment(textbox, ErrorIconAlignment.MiddleRight);
                        errorProvider1.SetError(textbox, cMessageContent.War_ToolNameIsExists);
                        e.Cancel = true;
                    }
                    else
                        errorProvider1.SetError(textbox, "");
            }

        }

        private void TextBox_KeyDownEvents(object sender, KeyEventArgs e)
        {
            try
            {
                
                if (GlobVar.LockEvents || e == null || e.KeyCode != Keys.Enter) return;
                TextBox textbox = (TextBox)sender;
                string sValue = string.Empty;
                string oldName = Action?.Name.rtcValue;
                if (textbox.Text != null)
                    sValue = textbox.Text.ToString();
                //if (textbox.Invalidated()) return;
                string PropertyName = textbox.Name.Substring(3, textbox.Name.Length - 3);
                if (PropertyName == cPropertyName.Name && (textbox.Text == null || sValue == ""))
                    return;

                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(PropertyName)?.GetValue(Action, null);
                if (propertyInfo == null) { return; }

                PropertyInfo properInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                if (properInfoValue == null) { return; }

                if (properInfoValue.PropertyType.Name == nameof(String))
                {
                    properInfoValue.SetValue(propertyInfo, sValue);
                }
                else if (properInfoValue.PropertyType.Name == nameof(Double))
                {
                    if (sValue.Trim() == "") sValue = "0";
                    properInfoValue.SetValue(propertyInfo, double.Parse(sValue));
                }
                else if (properInfoValue.PropertyType.Name == nameof(Int32))
                {
                    if (sValue.Trim() == "") sValue = "0";
                    properInfoValue.SetValue(propertyInfo, int.Parse(sValue));

                }
                else if (propertyInfo.GetType().Name == nameof(SListString))
                {
                    string[] arr = new string[] { };
                    if (Action.ActionType == EActionTypes.Math &&
                        Action.AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Split &&
                        (sValue == cChars.Comma.ToString() || sValue == cChars.Semicolon.ToString()))
                        arr = new string[] { sValue };
                    else if (sValue.Contains(cChars.Comma))
                        arr = sValue.Split(cChars.Comma);
                    else
                        arr = sValue.Split(cChars.Semicolon);
                    List<string> value = new List<string>();
                    foreach (var t in arr)
                        if (!string.IsNullOrEmpty(t))
                        {
                            if (bool.TryParse(t, out bool bValue))
                                value.Add(t);
                            else
                                value.Add(t);
                        }
                    properInfoValue.SetValue(propertyInfo, value);

                }
                else if (propertyInfo.GetType().Name == nameof(SListDouble))
                {
                    string[] arr = new string[] { };
                    if (Action.ActionType == EActionTypes.Math &&
                        Action.AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Split &&
                        (sValue == cChars.Comma.ToString() || sValue == cChars.Semicolon.ToString()))
                        arr = new string[] { sValue };
                    else if (sValue.Contains(cChars.Comma))
                        arr = sValue.Split(cChars.Comma);
                    else
                        arr = sValue.Split(cChars.Semicolon);
                    List<double> value = new List<double>();
                    foreach (var t in arr)
                        if (!string.IsNullOrEmpty(t))
                        {
                            if (double.TryParse(t, out double dvalue))
                                value.Add(double.Parse(t));
                            else if (int.TryParse(t, out int ivalue))
                                value.Add(int.Parse(t));
                            else if (long.TryParse(t, out long lValue))
                                value.Add(long.Parse(t));
                        }
                    properInfoValue.SetValue(propertyInfo, value);
                }
                else if (propertyInfo.GetType().Name == nameof(SListObject))
                {
                    string[] arr = new string[] { };
                    if (Action.ActionType == EActionTypes.Math &&
                        Action.AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Split &&
                        (sValue == cChars.Comma.ToString() || sValue == cChars.Semicolon.ToString()))
                        arr = new string[] { sValue };
                    else if (sValue.Contains(cChars.Comma))
                        arr = sValue.Split(cChars.Comma);
                    else
                        arr = sValue.Split(cChars.Semicolon);
                    List<object> value = new List<object>();
                    foreach (var t in arr)
                        if (!string.IsNullOrEmpty(t))
                        {
                            if (double.TryParse(t, out double dvalue))
                                value.Add(double.Parse(t));
                            else if (int.TryParse(t, out int ivalue))
                                value.Add(int.Parse(t));
                            else if (long.TryParse(t, out long lValue))
                                value.Add(long.Parse(t));
                            else if (bool.TryParse(t, out bool bValue))
                                value.Add(t);
                            else
                                value.Add(t);
                        }
                    properInfoValue.SetValue(propertyInfo, value);
                }
                if (PropertyName == cPropertyName.Name)
                {
                    Action.MyNode.Description = sValue;
                    return;
                }
                if (PropertyName != cPropertyName.Name)
                {

                    Action.SetActionValueToROIPropertiesSelected();

                    if (Action.AutoRun) RunAction();
                    UpdateReferencePropertyControls(PropertyName);
                    UpdatePropertyValueToPropertyGrid(PropertyName);
                    if (OnPropertyValueChanged != null)
                        OnPropertyValueChanged(PropertyName);

                    //Action.test.row
                }
                textbox.LostFocus -= TextBox_LostFocusEvents;

            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }

        [DefaultValue(0)]
        public int PageActionSettingTabIndex
        {
            get => PageActionSetting.SelectedIndex;
            set => PageActionSetting.SelectedIndex = value;
        }

        private void HideShowPropertiesButtonByActionType()
        {
            for (int i = 0; i < LayoutPropButton.ColumnStyles.Count - 2; i++)
            {
                LayoutPropButton.ColumnStyles[i].SizeType = SizeType.Absolute;
                LayoutPropButton.ColumnStyles[i].Width = 0;
                btnRun.Visible = false;
                btnAddInput.Visible = false;
                btnAddOutput.Visible = false;
                btnSnap.Visible = false;
                btnDisplayProp.Visible = false;
                btnTrain.Visible = false;
            }
            if (Action == null)
                return;
            LayoutPropButton.ColumnStyles[(int)EPropButtonPossition.Run].Width = 55;
            btnRun.Visible = true;
        }


        private void ViewActionProperties()
        {
            try
            {
                GlobVar.LockEvents = true;
                //TabProperties.SuspendLayout();
                //TabProperties.Controls.Clear();
                //tlAct.BeginUpdate();
                //tlAct.SuspendLayout();
                //tlAct.Nodes.Clear();
                tlvAction.TreeColumnRenderer.IsShowLines = false;
             
                tlvAction.Items.Clear();

                if (Action == null) return;

                //object node = null;
                ArrayList Root = new ArrayList();
                List<object> Nodes = new List<object> { };
                // propNode = null;
                //var test = Action.GetType().GetProperties();
                var orderedProperty = Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(Action, null)) != null);
                var listOrderedProperty =
                    (from item in orderedProperty
                     orderby ((RTCVariableType)item.GetValue(Action, null)).rtcSystem descending,
                     ((RTCVariableType)item.GetValue(Action, null)).rtcState,
                     item.Name
                     select item).ToList();

                PropertyInfo nProperty;
                for (int i1 = 0; i1 < listOrderedProperty.Count; i1++)
                {
                    nProperty = listOrderedProperty[i1];
                    RTCVariableType rtcvar = (RTCVariableType)Action.GetType().GetProperty(nProperty.Name).GetValue(Action, null);

                    if (rtcvar == null || !rtcvar.rtcActive || rtcvar.rtcHidden)
                    {
                        continue;
                    }
                    MyPropertiesItem node = new MyPropertiesItem();
                    node.IDref = rtcvar.rtcIDRef;
                    node.NodeType = ENodeTypes.Property;
                    node.Enable = true;
                    node.DisplayOutput = rtcvar.rtcDisplay;
                    node.Name = nProperty.Name;
                    node.Type = nProperty.PropertyType.Name;
                    node.Value = rtcvar.rtcIDRef != Guid.Empty ? rtcvar.rtcValueView + " " + rtcvar.rtcRef : rtcvar.rtcValueView;
                    node.RefIndex = rtcvar.rtcRefIndex;
                    node.State = (EPropertyState)rtcvar.rtcState;
                    node.ReadOnly = rtcvar.rtcReadOnly;
                    node.Log = rtcvar.rtcDisplayValueInHistory;
                    node.System = rtcvar.rtcSystem;
                    node.IsCanLink = rtcvar.rtcIsCanLink;
                    node.Value = rtcvar.rtcValueView;


                    tlvAction.AddObject(node);

                    //if(rtcvar.rtcRoiLegend != EROILegend.None)
                    //{
                    //    propNode.StateImageIndex
                    //}

                    if (nProperty.Name == nameof(Action.Expression))
                    {
                        if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                            foreach (SStringBuilderItem operandItem in Action.MyExpression.Operands)
                            {
                                MyPropertiesItem _node = new MyPropertiesItem();
                                _node.IDref = operandItem.RefID;
                                _node.NodeType = ENodeTypes.Property;
                                _node.Enable = true;
                                _node.DisplayOutput = false;
                                _node.Name = operandItem.Name;
                                _node.Type = operandItem.GetItemType();
                                _node.Value = operandItem.RefID != Guid.Empty ? operandItem.ValueView + " " + operandItem.Ref : operandItem.ValueView;
                                _node.RefIndex = operandItem.RefIndex;
                                _node.State = EPropertyState.Operand;
                                _node.ReadOnly = operandItem.RefID != Guid.Empty ? true : false;
                                _node.Log = false;
                                _node.System = false;
                                _node.IsCanLink = true;
                                _node.Value = operandItem.ValueView;



                                tlvAction.AddObject(_node);
                            }
                    }
                }

                if (Action.DataItems != null)
                    foreach (SStringBuilderItem datItem in Action.DataItems)
                    {
                        MyPropertiesItem _node = new MyPropertiesItem();
                        _node.IDref = datItem.RefID;
                        _node.NodeType = ENodeTypes.Property;
                        _node.Enable = true;
                        _node.DisplayOutput = false;
                        _node.Name = datItem.Name;
                        _node.Type = datItem.GetItemType();
                        _node.Value = datItem.RefID != Guid.Empty ? datItem.ValueView + " " + datItem.Ref : datItem.ValueView;
                        _node.RefIndex = datItem.RefIndex;
                        _node.State = EPropertyState.Operand;
                        _node.ReadOnly = datItem.RefID != Guid.Empty ? true : false;
                        _node.Log = false;
                        _node.System = false;
                        _node.IsCanLink = true;
                        _node.Value = datItem.ValueView;



                        tlvAction.AddObject(_node);

                    }

                //Quân sửa
                EnsureObjectLinkPropertyNodes();
                //}
            }

            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                GlobVar.LockEvents = false;
                //tlAct.ResumeLayout();
                //tlAct.EndUpdate();
         

            }
        }

        //Quân sửa
        private void EnsureObjectLinkPropertyNodes()
        {
            if (Action == null) return;

            var controls = GlobFuncs.GetAllControls(this, typeof(ucObjectLink));
            if (controls == null || !controls.Any()) return;

            foreach (Control control in controls)
            {
                var objectLink = (ucObjectLink)control;
                string propertyName = objectLink.RTCPropertyName;
                if (string.IsNullOrEmpty(propertyName))
                    continue;

                bool isExists = tlvAction.Objects != null &&
                                tlvAction.Objects.Cast<MyPropertiesItem>()
                                    .Any(x => x != null &&
                                              x.NodeType == ENodeTypes.Property &&
                                              x.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
                if (isExists)
                    continue;

                PropertyInfo prop = Action.GetType().GetProperty(propertyName);
                RTCVariableType rtcvar = (RTCVariableType)prop?.GetValue(Action, null);
                if (rtcvar == null || !rtcvar.rtcActive || rtcvar.rtcHidden)
                    continue;

                MyPropertiesItem node = new MyPropertiesItem();
                node.IDref = rtcvar.rtcIDRef;
                node.NodeType = ENodeTypes.Property;
                node.Enable = true;
                node.DisplayOutput = rtcvar.rtcDisplay;
                node.Name = propertyName;
                node.Type = prop.PropertyType.Name;
                node.Value = rtcvar.rtcIDRef != Guid.Empty ? rtcvar.rtcValueView + " " + rtcvar.rtcRef : rtcvar.rtcValueView;
                node.RefIndex = rtcvar.rtcRefIndex;
                node.State = (EPropertyState)rtcvar.rtcState;
                node.ReadOnly = rtcvar.rtcReadOnly;
                node.Log = rtcvar.rtcDisplayValueInHistory;
                node.System = rtcvar.rtcSystem;
                node.IsCanLink = rtcvar.rtcIsCanLink;

                tlvAction.AddObject(node);
            }
        }

        private void CreateComboOperandTypes()
        {
            if (Action == null) return;
            switch (Action.ActionType)
            {
                case EActionTypes.Branch:
                    {
                        break;
                    }
                case EActionTypes.Switch:
                    {
                        break;
                    }
                case EActionTypes.BranchItem:
                    {
                        break;
                    }
            }
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            UpdateTabActiveValue(false, false, false);
            PageSetup.SelectedTab = General;
            GlobVar.Draw = false;
            SetEffectButtonMain();
            Action.frmHsmartWindow.ReViewImage();

        }

        private void UpdateTabActiveValue(bool bTabRoiActive, bool bTabPassActive, bool bTabSearchSetup)
        {
            if (Action == null) return;
            RTCVariableType propertyInfo = null;
            PropertyInfo propertyInfoValue = null;

            if (Action.TabRoiActive != null)
            {
                propertyInfo = (RTCVariableType)Action.GetType().GetProperty(cPropertyName.TabRoiActive).GetValue(Action, null);
                if (propertyInfo == null) return;
                propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                propertyInfoValue.SetValue(propertyInfo, bTabRoiActive);
                UpdatePropertyValueToPropertyGrid(cPropertyName.TabRoiActive);
            }

            if (Action.TabPassActive != null)
            {
                propertyInfo = (RTCVariableType)Action.GetType().GetProperty(cPropertyName.TabPassActive).GetValue(Action, null);
                if (propertyInfo == null) return;
                propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                propertyInfoValue.SetValue(propertyInfo, bTabPassActive);
                UpdatePropertyValueToPropertyGrid(cPropertyName.TabPassActive);

            }

            if (Action.TabSearchActive != null)
            {
                propertyInfo = (RTCVariableType)Action.GetType().GetProperty(cPropertyName.TabSearchActive).GetValue(Action, null);
                if (propertyInfo == null) return;
                propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                propertyInfoValue.SetValue(propertyInfo, bTabSearchSetup);
                UpdatePropertyValueToPropertyGrid(cPropertyName.TabSearchActive);
            }
        }

        public void UpdatePropertyValueToPropertyGrid(string propertyname, bool onlychildNode = false)
        {
            if (tlvAction.InvokeRequired)
                tlvAction.Invoke((MethodInvoker)delegate
                {
                    UpdatePropertyValueToPropertyGrid_Process(propertyname, onlychildNode);
                });
            else
            {
                UpdatePropertyValueToPropertyGrid_Process(propertyname, onlychildNode);

            }
        }

        private void UpdatePropertyValueToPropertyGrid_Process(string propertyname, bool onlyChildNode = false)
        {
            try
            {
                tlvAction.LockCalc = true;
                if (Action == null) return;
                if (Action.GetType().GetProperty(propertyname) != null)
                {
                    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(propertyname)?.GetValue(Action, null);
                    if (propertyInfo == null) return;
                    MyPropertiesItem node = FindPropertyNode(propertyname);
                    if (node == null) return;
                    this.Value.PutValue(node, propertyInfo.rtcIDRef != Guid.Empty ? propertyInfo.rtcValueView + "" + propertyInfo.rtcRef : propertyInfo.rtcValueView);
                }
                else
                {
                    SStringBuilderItem sbItem = null;
                    if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                        sbItem = Action.MyExpression.Operands.FirstOrDefault(x => x.Name == propertyname);
                    if (sbItem == null && Action.DataItems != null)
                        sbItem = Action.DataItems.FirstOrDefault(x => x.Name == propertyname);
                    if (sbItem != null)
                    {
                        MyPropertiesItem Node = FindPropertyNode(propertyname);
                        if (Node == null) return;
                        this.Value.PutValue(Node, sbItem.RefID != Guid.Empty ? sbItem.ValueView + " " + sbItem.Ref : sbItem.ValueView);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                tlvAction.LockCalc = false;
            }
        }

        //private Node FindPropertyNode(String PropertyName)
        //{
        //    try
        //    {
        //        Node myNode = tlAct.
        //    }
        //}

        public void SetEffectButtonMain()
        {
            btnGeneral.Font = new Font(btnGeneral.Font, PageSetup.SelectedTab == General ? FontStyle.Bold : FontStyle.Regular);
            btnMethod.Font = new Font(btnMethod.Font, PageSetup.SelectedTab == Method ? FontStyle.Bold : FontStyle.Regular);
            btnROI.Font = new Font(btnROI.Font, PageSetup.SelectedTab == ROI ? FontStyle.Bold : FontStyle.Regular);
            btnEndPoint.Font = new Font(btnEndPoint.Font, PageSetup.SelectedTab == EndPointAndType ? FontStyle.Bold : FontStyle.Regular);
            btnPass.Font = new Font(btnPass.Font, PageSetup.SelectedTab == PassFail ? FontStyle.Bold : FontStyle.Regular);
            btnDisplay.Font = new Font(btnDisplay.Font, PageSetup.SelectedTab == Display ? FontStyle.Bold : FontStyle.Regular);

            if (Action != null)
            {
                if (Action.TabRoiActive != null) Action.TabRoiActive.rtcValue = (PageSetup.SelectedTab == ROI);
                if (Action.TabPassActive != null) Action.TabPassActive.rtcValue = (PageSetup.SelectedTab == PassFail);
                if (Action.TabMethodActive != null) Action.TabMethodActive.rtcValue = (PageSetup.SelectedTab == Method);

                Action.frmHsmartWindow.VisibleOrHideControlByContext();
            }
        }

        private void btnROI_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateTabActiveValue(true, false, false);
                PageSetup.SelectedTab = ROI;
                SetEffectButtonMain();
                Action.frmHsmartWindow.ClearAllRoi();
                Action.frmHsmartWindow.ReViewImage() ;
                Action.frmHsmartWindow.ReviewAllROIS();
                if (Action.ActionType == EActionTypes.StringBuilder)
                {
                    try
                    {
                        GlobFuncs.BeginControlUpdate(ROI);
                        ((ucStringBuilderDetail)Action.ViewInfo).flpOptions.Top =
                            ((ucStringBuilderDetail)Action.ViewInfo).PanButton.Top + ((ucStringBuilderDetail)Action.ViewInfo).PanButton.Height;
                        ((ucStringBuilderDetail)Action.ViewInfo).groupInput.Visible = true;
                        ((ucStringBuilderDetail)Action.ViewInfo).ucStringBuilderItemProperty.Visible = Action.StringBuilders != null && Action.StringBuilders.Count > 0;
                        ((ucStringBuilderDetail)Action.ViewInfo).panFormat.Visible = false;
                        ((ucStringBuilderDetail)Action.ViewInfo).PanButton.Visible = true;

                        btnROI.Font = new Font(btnROI.Font, FontStyle.Bold);
                    }
                    finally
                    {
                        GlobFuncs.EndControlUpdate(ROI);
                    }
                }
                else if (Action.RunWhenROIButtonClick)
                    RunAction();

            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }

        }

        public void RunAction(bool widthShowMessage = false, bool forceRun = false)
        {

            if (GlobVar.GroupActions.IsRun) return;
            if (GlobVar.GroupActions.IsRun && !forceRun) return;

            if (Action != null)
            {
                GlobVar.GroupActions.Actions[Action.ID] = Action;
                GlobVar.GroupActions.Setting_Run(ERunActionMode.CurentAction, false, "", widthShowMessage);
            }

        }

        private enum EPropButtonPossition
        {
            Run, Train, Snap, AddInput, AddOutput, Display
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            if (Action.ActionType != EActionTypes.StringBuilder)
            {
                UpdateTabActiveValue(false, true, false);
                PageSetup.SelectedTab = PassFail;
            }
            else
            {
                UpdateTabActiveValue(true, false, false);
                PageSetup.SelectedTab = ROI;
            }
            SetEffectButtonMain();
            //Action.frmHsmartWindow.ListDataRoi = 
            Action.frmHsmartWindow.ClearAllRoi();
            Action.frmHsmartWindow.ReViewImage();
            Action.frmHsmartWindow.ReviewAllROIS();
            if (Action.ActionType == EActionTypes.StringBuilder)
            {
                try
                {
                    GlobFuncs.BeginControlUpdate(ROI);
                    ((ucStringBuilderDetail)Action.ViewInfo).groupInput.Visible = false;
                    ((ucStringBuilderDetail)Action.ViewInfo).flpOptions.Top = ((ucStringBuilderDetail)Action.ViewInfo).PanButton.Top;
                    ((ucStringBuilderDetail)Action.ViewInfo).ucStringBuilderItemProperty.Visible = false;
                    ((ucStringBuilderDetail)Action.ViewInfo).panFormat.Visible = true;
                    ((ucStringBuilderDetail)Action.ViewInfo).PanButton.Visible = false;

                    btnROI.Font = new Font(btnROI.Font, FontStyle.Regular);
                    btnPass.Font = new Font(btnPass.Font, FontStyle.Bold);
                }
                finally
                {
                    GlobFuncs.EndControlUpdate(ROI);
                }
            }
            else if (Action.RunWhenPassFailButtonClick)
                RunAction();
        }
        bool isPrePageProperty = false;

        private Dictionary<int, int> OldtlActColumnWidth = null;
        //Hieutest


        private void btnDisplayProp_Click(object sender, EventArgs e)
        {

        }
     
        private void SetVisiableColumnIndex()
        {
            //if (OldtlActColumnWidth == null)
            //{
            //    OldtlActColumnWidth = new Dictionary<int, int>();
            //    for (int i = 0; i < tlvAction.Columns.Count; i++)
            //        if (tlvAction.Columns.Cast<OLVColumn>().ToList()[i].IsVisible)
            //            OldtlActColumnWidth.Add(tlvAction.Columns[i].Index, tlvAction.Columns[i].Width);
            //}
            //else
            //{
            //    for (int i = 0; i < tlvAction.Columns.Count - 1; i++)
            //        if (tlvAction.Columns.Cast<OLVColumn>().ToList()[i].IsVisible)
            //            OldtlActColumnWidth[tlvAction.Columns[i].Index] = tlvAction.Columns[i].Width;
            //}
            switch (PageActionSetting.SelectedIndex)
            {
                case 0:
                    if (PageSetup.SelectedTab == Display)
                    {
                        this.btnRemoveLink.IsVisible = false;
                        btnLink.IsVisible = false;
                        btnViewList.IsVisible = false;
                        Type.IsVisible = false;
                        //var test = tlvAction.Columns;
                        DisplayOutput.IsVisible = true;
                        PropName.IsVisible = true;
                        Value.IsVisible = true;
                        colRefIndex.IsVisible = true;
                        ReadOnly.IsVisible = true;
                        colImage.DisplayIndex = 0;
                        DisplayOutput.DisplayIndex = 1;
                        //DisplayOutputData.DisplayIndex = 1;
                        PropName.DisplayIndex = 2;
                        Value.DisplayIndex = 3;
                        colRefIndex.DisplayIndex = 4;
                        ReadOnly.DisplayIndex = 5;

                        //DisplayOutput.Width = OldtlActColumnWidth[DisplayOutput.Index];
                        ////  DisplayOutputData.Width = OldtlActColumnWidth[DisplayOutputData.Index];
                        //PropName.Width = OldtlActColumnWidth[PropName.Index];
                        //Value.Width = OldtlActColumnWidth[Value.Index];
                        //colRefIndex.Width = OldtlActColumnWidth[colRefIndex.Index];
                        //ReadOnly.Width = OldtlActColumnWidth[ReadOnly.Index];
                        tlvAction.CheckBoxes = true;
                        //this.btnRemoveLink.Width = 0;
                        //btnLink.Width = 0;
                        //btnViewList.Width = 0;
                        //Type.Width = 0;

                    }
                    break;
                case 1:
                    {

                        DisplayOutput.IsVisible = false;
                        ReadOnly.IsVisible = false;
                        colImage.DisplayIndex = 0;
                        PropName.DisplayIndex = 1;
                        Type.DisplayIndex = 2;
                        Value.DisplayIndex = 3;
                        colRefIndex.DisplayIndex = 4;
                        btnRemoveLink.DisplayIndex = 5;
                        btnLink.DisplayIndex = 6;
                        btnViewList.DisplayIndex = 7;
                        colImage.IsVisible = true;
                        PropName.IsVisible = true;
                        Value.IsVisible = true;
                        Type.IsVisible = true;
                        colRefIndex.IsVisible = true;
                        btnLink.IsVisible = true;
                        btnViewList.IsVisible = true;
                        btnRemoveLink.IsVisible = true;
                        //DisplayOutput.Width = 0;
                        //PropName.Width = OldtlActColumnWidth[PropName.Index];
                        //Type.Width = OldtlActColumnWidth[Type.Index];
                        //Value.Width = OldtlActColumnWidth[Value.Index];
                        //colRefIndex.Width = OldtlActColumnWidth[colRefIndex.Index];
                        //btnLink.Width = OldtlActColumnWidth[btnLink.Index];
                        //btnViewList.Width = OldtlActColumnWidth[btnViewList.Index];
                        tlvAction.CheckBoxes = false;

                    }
                    break;
                default:
                    break;

            }
           // tlvAction.RebuildColumns();


        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (PageSetup.SelectedTab != Display)
            {
                try
                {
                    ShowEditor = false;
                    GlobFuncs.BeginControlUpdate(this);
                    UpdateTabActiveValue(false, false, false);
                    PageSetup.SelectedTab = Display;
                    SetVisiableColumnIndex();
                    tlvAction.Dock = DockStyle.None;
                    tlvAction.Parent = groupDisplayOutput;
                    tlvAction.Dock = DockStyle.Fill;
                    panel3.BringToFront();
                    tlvAction.BringToFront();
                    SetEffectButtonMain();
                }
                finally
                {
                    tlvAction.Refresh();
                    tlvAction.Update();

                    GlobFuncs.EndControlUpdate(this);
                }
            }
            Action.frmHsmartWindow.ClearAllRoi();
            Action.frmHsmartWindow.ReViewImage();
        }
        private void PageActionSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (PageActionSetting.SelectedIndex)
            {
                case 0:
                    try
                    {
                        ShowEditor = false;
                        GlobFuncs.BeginControlUpdate(TabSetUp);
                        if (PageSetup.SelectedTab == Display && isPrePageProperty)
                        {
                            isPrePageProperty = false;
                            SetVisiableColumnIndex();
                            tlvAction.Dock = DockStyle.None;
                            tlvAction.Parent = groupDisplayOutput;
                            tlvAction.Dock = DockStyle.Fill;

                            tlvAction.BringToFront();
                        }
                    }
                    finally
                    {
                        //tlvAction.Refresh();
                        //tlvAction.Update();
                        GlobFuncs.EndControlUpdate(TabSetUp);
                        tlvAction.RebuildColumns();
                    }
                    break;
                case 1:
                    try
                    {
                        ShowEditor = true;
                        isPrePageProperty = true;
                        GlobFuncs.BeginControlUpdate(TabProperties);
                        SetVisiableColumnIndex();
                        tlvAction.Dock = DockStyle.None;
                        tlvAction.Parent = TabProperties;
                        tlvAction.Dock = DockStyle.Fill;
                        tlvAction.BringToFront();
                        //panel3.BringToFront();
                    }
                    finally
                    {
                        //tlvAction.Refresh();
                        //tlvAction.Update();
                        GlobFuncs.EndControlUpdate(TabProperties);
                        tlvAction.RebuildColumns();
                    }
                    break;
                case 2:
                    try
                    {
                        isPrePageProperty = false;
                        GlobFuncs.BeginControlUpdate(LinkSummary);

                    }
                    finally
                    {
                        // tlvAction.Refresh();
                        GlobFuncs.EndControlUpdate(LinkSummary);
                        tlvAction.RebuildColumns();
                    }
                    break;
                default:
                    break;
            }
            
        }
        private void tlvAction_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (Action == null || this.NodeType == null) { return; }
            ENodeTypes eNodeType = GlobFuncs.GetNodePropertyType((MyPropertiesItem)e.Model, this.NodeType);
            EPropertyState eNodeState = GlobFuncs.GetNodeState((MyPropertiesItem)e.Model, this.State);
            bool _IsVisible = (bool)this.Enable.GetValue(e.Item.RowObject);
            if (_IsVisible)
            {
                var test = e.Item.ListView;
            }
            //if (eNodeState == EPropertyState.Operand) return;

            //switch (eNodeType)
            //{
            //    case ENodeTypes.Property:
            //        {
            //            if (e.Model is MyPropertiesItem dataObject)
            //            {
            //                RTCVariableType rtcvar = (RTCVariableType)Action.GetType().GetProperty(this.PropName.GetStringValue(dataObject)).GetValue(Action, null);

            //                if (rtcvar.rtcState == EPropertyState.Input)
            //                {
            //                    e.Item.ImageIndex = rtcvar.rtcSaveToFileConfig ? Selecticon.Images.IndexOfKey(cPropertyState.SaveInput) : Selecticon.Images.IndexOfKey(cPropertyState.Input);


            //                }
            //                else if (rtcvar.rtcState == EPropertyState.Output)
            //                    e.Item.ImageIndex = Selecticon.Images.IndexOfKey(cPropertyState.Output);
            //                else if (rtcvar.rtcSystem)
            //                    e.Item.ImageIndex = Selecticon.Images.IndexOfKey(cPropertyState.System);
            //                else
            //                    e.Item.ImageIndex = -1;
            //                if (rtcvar.rtcDisplay)
            //                {
            //                    e.Item.Checked = true;

            //                }
            //                else
            //                {
            //                    //e.Item. = true;
            //                    e.Item.CheckState = CheckState.Checked;
            //                }
            //            }
            //            break;
            //        }
            //    case ENodeTypes.PropertyDetail:
            //        e.Item.ImageIndex = -1;
            //        break;
            //    default:
            //        break;
            //}




        }



        private void btnClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                tlvAction.SuspendLayout();
                tlvAction.LockCalc = true;
                foreach (MyPropertiesItem item in tlvAction.Objects.Cast<MyPropertiesItem>().ToList())
                    this.DisplayOutput.PutValue(item, false);
            }
            finally
            {
                tlvAction.LockCalc = false;
                tlvAction.Update();
                tlvAction.ResumeLayout();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                tlvAction.LockCalc = true;
                foreach (MyPropertiesItem item in tlvAction.Objects.Cast<MyPropertiesItem>().ToList())
                    this.DisplayOutput.PutCheckState(item, CheckState.Checked);
            }
            finally
            {
                tlvAction.LockCalc = false;
                tlvAction.Update();
            }
        }

        private void btnRestoreDefault_Click(object sender, EventArgs e)
        {
            try
            {
                tlvAction.SuspendLayout();
                tlvAction.LockCalc = true;
                cAction actionD = new cAction(Action.ActionType, Action.ObjectType, Action.frmHsmartWindow, GlobVar.GroupActions);
                foreach (MyPropertiesItem item in tlvAction.Objects.Cast<MyPropertiesItem>().ToList())
                {
                    RTCVariableType propertyInfo = (RTCVariableType)actionD.GetType().GetProperty(this.PropName.GetValue(item).ToString()).GetValue(actionD, null);
                    PropertyInfo propertyInfo_Value = propertyInfo.GetType().GetProperty(cPropertyName.rtcDisplay);
                    this.DisplayOutput.PutValue(item, propertyInfo_Value.GetValue(propertyInfo, null));
                }

            }
            finally
            {
                tlvAction.LockCalc = false;
                tlvAction.Update();
                tlvAction.ResumeLayout();
            }
        }

        private void tlvAction_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                var hitTest = tlvAction.HitTest(e.X, e.Y);

                // Kiểm tra xem có hàng và cột nào được chọn hay không
                if (hitTest.Item != null && hitTest.SubItem != null)
                {
                    // Lấy chỉ số cột từ subItem
                    int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);

                    // Lấy đối tượng OLVColumn của cột tương ứng
                    OLVColumn clickedColumn = tlvAction.GetColumn(columnIndex);
                    foreach (ToolStripItem item in popApplyTo.DropDownItems)
                    {
                        item.Click -= popTheEntireClick;
                        item.Click -= popTheActionClick;
                    }
                    popApplyTo.DropDownItems.Clear();
                    if (clickedColumn == PropName && e.Button == MouseButtons.Right)
                    {
                        string propName = hitTest.SubItem.Text;
                        RTCVariableType rtcVariableType = (RTCVariableType)Action.GetType().GetProperty(propName)?.GetValue(Action, null);
                        if (rtcVariableType == null || rtcVariableType.rtcSystem)
                            return;

                        if (rtcVariableType.rtcState != EPropertyState.Input)
                        {
                            popViewValue1.Tag = propName;
                            //tlvAction.ContextMenuStrip = cmsViewValue;
                            //cmsViewValue.Show(tlAct, e.Location);
                            //tlAct.FocusedNode = pressedHitInfo.Node;
                            return;
                        }

                        ToolStripItem toolStripItem = popApplyTo.DropDownItems.Add("The Entire Tool Contains This Property Name", null, popTheEntireClick);
                        toolStripItem.Tag = propName;
                        var listToolsHavePropertyName =
                            GlobVar.GroupActions.Actions.Values.Where(x => x.GetType().GetProperty(propName).GetValue(x) != null).ToList();
                        if (listToolsHavePropertyName.Any())
                            foreach (var action in listToolsHavePropertyName)
                                if (action.ID != Action.ID)
                                {
                                    toolStripItem = popApplyTo.DropDownItems.Add(action.Name.rtcValue, null, popTheActionClick);
                                    toolStripItem.Tag = action.ID.ToString() + cStrings.SepGDung + propName;
                                }

                        popSaveToFileConfig.Visible = popSaveToFileConfig.Visible && (rtcVariableType.rtcState == EPropertyState.Input ||
                                                                                  rtcVariableType.rtcState == EPropertyState.Operand ||
                                                                                  rtcVariableType.rtcState == EPropertyState.DataItem);
                        popSaveToFileConfig.Text = rtcVariableType.rtcSaveToFileConfig
                            ? cStrings.RemoveFromConfigFile
                            : cStrings.SaveToFileConfig;
                        popViewValue1.Tag = propName;

                        tlvAction.ContextMenuStrip = contextMenuStrip;
                        contextMenuStrip.Show(tlvAction, e.Location);

                    }
                }
              
            }
            catch (Exception ex)
            {

                GlobFuncs.SaveErr(ex);
            }
        }
        public void RemoveEventCustomCellStyle()
        {
            tlvAction.CellEditStarting -= tlvAction_CellEditStarting;

        }
        public void SetEventCustomCellStyle()
        {
            tlvAction.CellEditStarting += tlvAction_CellEditStarting;
        }

        private void tlvAction_CellEditStarting(object sender, CellEditEventArgs e)
        {

            if (GlobVar.GroupActions.IsRun)
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = false;
            tlvAction.SuspendLayout();
            tlvAction.BeginUpdate();
            TextBox txt = new TextBox();
           
            //if (Action.MyCsharpScript != null && Action.MyCsharpScript.Operands != null &&
            //    Action.MyCsharpScript.Operands.FirstOrDefault(x => x.Name == propName) != null &&
            //    Action.MyCsharpScript.Operands.FirstOrDefault(x => x.Name == propName).RefID == Guid.Empty)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            if (Action == null || e.Column == null || this.NodeType == null)
            {
                tlvAction.ResumeLayout();
                tlvAction.EndUpdate();
                e.Cancel = true;
                return;
            }
            if (e.Column != this.btnLink && e.Column != this.btnViewList && e.Column != this.Value && e.Column != this.DisplayOutput && e.Column != this.Type && e.Column != this.colRefIndex && e.Column != ReadOnly)
            {
                tlvAction.ResumeLayout();
                tlvAction.EndUpdate();
                e.Cancel = true;
                return;
            }
            //if (e.ListViewItem == null || (e.Column != this.btnLink && e.Column != btnRemoveLink && e.Column != this.btnViewList || !Action.IsCanEdit.rtcValue))
            //{
            //    tlvAction.FinishCellEdit();
            //    return;
            //}
            if (GlobFuncs.GetNodePropertyType((MyPropertiesItem)e.RowObject, this.NodeType) == ENodeTypes.PropertyDetail)
            {
                if (e.Column != this.Value)
                {
                    txt.Bounds = e.CellBounds;
                    e.Control = txt;
                }
            }
            else
            {

                //if(!Action.IsShowOnlyHighLightProperties.rtcValue)
                //    foreach(MyPropertiesItem item in ()e.RowObject)
                //if (e.Column == this.btnViewList)
                //{
                //    CustomNodeCellEdit_Column_btnViewList(e);
                //}
                if (GlobFuncs.GetPropertyNodeState((MyPropertiesItem)e.RowObject, State) == EPropertyState.Output)
                {
                    if (e.Column != DisplayOutput)
                    {

                        if (e.Column == this.ReadOnly) this.ReadOnly.PutValue(e.RowObject, null);
                        e.Cancel = true;
                    }
                }
                //else if (e.Column == this.btnLink)
                //{
                //    if (!(bool)this.colIsCanLink.GetValue(e.RowObject))
                //        e.Control = new TextBox();
                //    else
                //        CustomNodeCellEdit_Column_btnLink(e);

                //}

                else if (e.Column == this.Value)
                {
                   string propName = Lib.ToString(this.PropName.GetValue(tlvAction.FocusedObject));
                    RTCVariableType rtcVariableType = (RTCVariableType)Action.GetType().GetProperty(propName)?.GetValue(Action, null);
                    if (rtcVariableType != null && rtcVariableType.rtcIDRef == Guid.Empty && rtcVariableType.rtcState != EPropertyState.Output)
                    {
                        CustomNodeCellEdit_Column_Value(e);
                        //RepositoryItemTextEdit txt = (RepositoryItemTextEdit)cellInfo.Item;
                        return;
                    }
                    if (Action.DataItems != null &&
                        Action.DataItems.FirstOrDefault(x => x.Name == propName) != null &&
                        Action.DataItems.FirstOrDefault(x => x.Name == propName).RefID == Guid.Empty)
                    {
                        CustomNodeCellEdit_Column_Value(e);
                        return;
                    }
                     if (Action.MyExpression != null && Action.MyExpression.Operands != null &&
                        Action.MyExpression.Operands.FirstOrDefault(x => x.Name == propName) != null &&
                        Action.MyExpression.Operands.FirstOrDefault(x => x.Name == propName).RefID == Guid.Empty)
                    {
                        CustomNodeCellEdit_Column_Value(e);
                        return;
                    }
                    e.Cancel = true;
                    


                }    
                   
                else if (e.Column == this.Type)
                    CustomNodeCellEdit_ColumnType(e);
                else
                    e.Cancel = true;


            }
            tlvAction.EndUpdate();
            tlvAction.ResumeLayout();
            //tlvAction.FinishCellEdit();

        }

        private void CustomNodeCellEdit_ColumnType(CellEditEventArgs e)
        {
            ComboBox cbOperandType = new ComboBox();
            cbOperandType.Items.Add("Boolean");
            cbOperandType.Items.Add("Integer");
            cbOperandType.Items.Add("Real");
            cbOperandType.Items.Add("String");
            FocusingCol = e.Column;
            EPropertyState eNodeState = (EPropertyState)this.State.GetValue(e.ListViewItem.RowObject);
            if ((Action.ActionType == EActionTypes.Branch ||
                Action.ActionType == EActionTypes.Switch ||
                (Action.ActionType == EActionTypes.BranchItem && Action.DataItems != null && Action.DataItems.Any())) &&
                    eNodeState == EPropertyState.Operand)
            {
                cbOperandType.Bounds = e.CellBounds;
                cbOperandType.SelectedIndex = cbOperandType.Items.IndexOf(e.Value);
                cbOperandType.SelectedIndexChanged += cbOperandTypeIndexChanged;
                e.Control = cbOperandType;
                e.NewValue = cbOperandType.SelectedItem;
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void cbOperandTypeIndexChanged(object sender, EventArgs e)
        {
            MyPropertiesItem _FocusNode = (MyPropertiesItem)tlvAction.FocusedObject;
            if (_FocusNode == null || FocusingCol != this.Type)
                return;
            ComboBox comboBox = (ComboBox)sender;
            EPropertyState ePropertyState = GlobFuncs.GetPropertyNodeState(_FocusNode, this.State);
            if (ePropertyState != EPropertyState.Operand) return;
            string _OperandName = this.PropName.GetValue(_FocusNode).ToString();
            switch (Action.ActionType)
            {
                case EActionTypes.Branch:
                    if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                    {
                        SStringBuilderItem _Operand = Action.MyExpression.Operands.Find(x => x.Name == _OperandName);
                        if (_Operand == null) return;
                        if (comboBox.Text == cDataTypes.Boolean)
                        {
                            _Operand.ValueStyle = EHTupleStyle.Boolean;
                            _Operand.ListStringValue = new List<string>() { cStrings.False };
                        }
                        else if (comboBox.Text == cDataTypes.Integer)
                        {
                            _Operand.ValueStyle = EHTupleStyle.Integer;
                            _Operand.ListDoubleValue = new List<double>() { 0 };

                        }
                        else if (comboBox.Text == cDataTypes.Real)
                        {
                            _Operand.ValueStyle = EHTupleStyle.Real;
                            _Operand.ListDoubleValue = new List<double>() { 0 };

                        }
                        else if (comboBox.Text == cDataTypes.String)
                        {
                            _Operand.ValueStyle = EHTupleStyle.String;
                            _Operand.ListStringValue = new List<string>() { string.Empty };
                        }
                        _Operand.RefID = Guid.Empty;
                        this.IDref.PutValue(_FocusNode, _Operand.RefID);
                        this.Type.PutValue(_FocusNode, _Operand.GetItemType());
                        this.Value.PutValue(_FocusNode, _Operand.ValueView);


                    }
                    break;
                case EActionTypes.Switch:
                    if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                    {
                        SStringBuilderItem _Operand = Action.MyExpression.Operands.Find(x => x.Name == _OperandName);
                        if (_Operand == null) return;
                        if (comboBox.Text == cDataTypes.Boolean)
                        {
                            _Operand.ValueStyle = EHTupleStyle.Boolean;
                            _Operand.ListStringValue = new List<string>() { cStrings.False };
                        }
                        else if (comboBox.Text == cDataTypes.Integer)
                        {
                            _Operand.ValueStyle = EHTupleStyle.Integer;
                            _Operand.ListDoubleValue = new List<double>() { 0 };

                        }
                        else if (comboBox.Text == cDataTypes.Real)
                        {
                            _Operand.ValueStyle = EHTupleStyle.Real;
                            _Operand.ListDoubleValue = new List<double>() { 0 };

                        }
                        else if (comboBox.Text == cDataTypes.String)
                        {
                            _Operand.ValueStyle = EHTupleStyle.String;
                            _Operand.ListStringValue = new List<string>() { string.Empty };
                        }
                        _Operand.RefID = Guid.Empty;
                        this.IDref.PutValue(_FocusNode, _Operand.RefID);
                        this.Type.PutValue(_FocusNode, _Operand.GetItemType());
                        this.Value.PutValue(_FocusNode, _Operand.ValueView);

                    }
                    break;
                default:
                    if (Action.DataItems != null)
                    {
                        SStringBuilderItem dataItem = Action.DataItems.Find(x => x.Name == _OperandName);
                        if (dataItem == null) return;
                        switch (comboBox.Text)
                        {
                            case cDataTypes.Boolean:
                                dataItem.ValueStyle = EHTupleStyle.Boolean;
                                dataItem.ListStringValue = new List<string>() { cStrings.False };
                                break;
                            case cDataTypes.BooleanList:
                                dataItem.ValueStyle = EHTupleStyle.BooleanList;
                                dataItem.ListStringValue = new List<string>() { };
                                break;
                            case cDataTypes.Integer:
                                dataItem.ValueStyle = EHTupleStyle.Integer;
                                dataItem.ListDoubleValue = new List<double>() { 0 };
                                break;
                            case cDataTypes.IntegerList:
                                dataItem.ValueStyle = EHTupleStyle.IntegerList;
                                dataItem.ListDoubleValue = new List<double>() { };
                                break;
                            case cDataTypes.Real:
                                dataItem.ValueStyle = EHTupleStyle.Real;
                                dataItem.ListDoubleValue = new List<double>() { 0 };
                                break;
                            case cDataTypes.RealList:
                                dataItem.ValueStyle = EHTupleStyle.RealList;
                                dataItem.ListDoubleValue = new List<double>() { };
                                break;
                            case cDataTypes.String:
                                dataItem.ValueStyle = EHTupleStyle.String;
                                dataItem.ListStringValue = new List<string>() { string.Empty };
                                break;
                            case cDataTypes.StringList:
                                dataItem.ValueStyle = EHTupleStyle.StringList;
                                dataItem.ListStringValue = new List<string>() { };
                                break;
                        }
                    }
                    break;
            }
            RunAction();
        }

        private void CustomNodeCellEdit_Column_btnViewList(CellEditEventArgs e)
        {
            SStringBuilderItem dataItem = null;
            TextBox txt = new TextBox();
            PropertyInfo propertyInfo = null;
            EPropertyState eNodeState = GlobFuncs.GetPropertyNodeState((MyPropertiesItem)e.RowObject, this.State);
            switch (eNodeState)
            {
                case EPropertyState.Operand:
                    {
                        dataItem = null;
                        if (Action.DataItems != null)
                            dataItem = Action.DataItems.FirstOrDefault(x => x.Name == this.PropName.GetValue(e.RowObject).ToString());
                        if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                            dataItem = Action.MyExpression.Operands.FirstOrDefault(x => x.Name == this.PropName.GetValue(e.RowObject).ToString());
                        if (dataItem == null || dataItem.DataItems == null || dataItem.DataItems.Count <= 0)
                        {
                            txt = new TextBox();
                            txt.Bounds = e.CellBounds;
                            e.Control = txt;
                        }
                        else
                        {
                            Button btnViewList = new Button();
                            btnViewList.Bounds = e.CellBounds;
                            btnViewList.Text = "ViewList";
                        }
                        break;

                    }
                case EPropertyState.DataItemParent:
                    {
                        dataItem = null;
                        if (tlvAction.GetParent(e.RowObject) == null)
                        {
                            txt = new TextBox();
                            txt.Bounds = e.CellBounds;
                        }
                        else
                        {
                            if (Action.DataItems != null)
                                dataItem = Action.DataItems.FirstOrDefault(x => x.Name == this.PropName.GetValue(e.RowObject).ToString());
                            if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                                dataItem = Action.MyExpression.Operands.FirstOrDefault(x => x.Name == this.PropName.GetValue(e.RowObject).ToString());
                            if (dataItem == null)
                            {
                                propertyInfo = Action.GetType().GetProperty(this.PropName.GetValue(tlvAction.GetParent(e.RowObject)).ToString());
                                if (propertyInfo != null)
                                {
                                    RTCVariableType value = (RTCVariableType)propertyInfo.GetValue(Action, null);
                                    if (value.DataItems != null && value.DataItems.Count > 0)
                                    {
                                        Button btnViewList = new Button();
                                        btnViewList.Bounds = e.CellBounds;
                                        btnViewList.Text = "ViewList";
                                    }
                                    else
                                    {
                                        txt = new TextBox();
                                        txt.Bounds = e.CellBounds;
                                        e.Control = txt;
                                    }
                                }
                                else
                                {
                                    if (dataItem.DataItems == null || dataItem.DataItems.Count <= 0)
                                    {
                                        txt = new TextBox();
                                        txt.Bounds = e.CellBounds;
                                        e.Control = txt;
                                    }
                                    else
                                    {
                                        Button btnViewList = new Button();
                                        btnViewList.Bounds = e.CellBounds;
                                        btnViewList.Text = "ViewList";
                                    }
                                }

                            }
                            else
                            {
                                Button btnViewList = new Button();
                                btnViewList.Bounds = e.CellBounds;
                                btnViewList.Text = "ViewList";
                            }

                        }
                        break;
                    }
                case EPropertyState.DataItemParentView:

                    {
                        dataItem = null;
                        if (tlvAction.GetParent(e.RowObject) == null)
                        {
                            txt = new TextBox();
                            txt.Bounds = e.CellBounds;
                        }
                        else
                        {
                            if (Action.DataItems != null)
                                dataItem = Action.DataItems.FirstOrDefault(x => x.Name == this.PropName.GetValue(e.RowObject).ToString());
                            if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                                dataItem = Action.MyExpression.Operands.FirstOrDefault(x => x.Name == this.PropName.GetValue(e.RowObject).ToString());
                            if (dataItem == null)
                            {
                                propertyInfo = Action.GetType().GetProperty(this.PropName.GetValue(tlvAction.GetParent(e.RowObject)).ToString());
                                if (propertyInfo != null)
                                {
                                    RTCVariableType value = (RTCVariableType)propertyInfo.GetValue(Action, null);
                                    if (value.DataItems != null && value.DataItems.Count > 0)
                                    {
                                        Button btnViewList = new Button();
                                        btnViewList.Bounds = e.CellBounds;
                                        btnViewList.Text = "ViewList";
                                    }
                                    else
                                    {
                                        txt = new TextBox();
                                        txt.Bounds = e.CellBounds;
                                        e.Control = txt;
                                    }
                                }
                                else
                                {
                                    if (dataItem.DataItems == null || dataItem.DataItems.Count <= 0)
                                    {
                                        txt = new TextBox();
                                        txt.Bounds = e.CellBounds;
                                        e.Control = txt;
                                    }
                                    else
                                    {
                                        Button btnViewList = new Button();
                                        btnViewList.Bounds = e.CellBounds;
                                        btnViewList.Text = "ViewList";
                                    }
                                }

                            }
                            else
                            {
                                Button btnViewList = new Button();
                                btnViewList.Bounds = e.CellBounds;
                                btnViewList.Text = "ViewList";
                            }

                        }
                        break;
                    }


                case EPropertyState.DataItem:
                    {
                        TextBox txtData = new TextBox();
                        txtData.Bounds = e.CellBounds;
                        e.Control = new TextBox();
                        break;
                    }
                case EPropertyState.DataItemView:
                    {
                        TextBox txtOut = new TextBox();
                        txtOut.Bounds = e.CellBounds;
                        e.Control = txtOut;
                        break;
                    }
                default:
                    {
                        propertyInfo = Action.GetType().GetProperty(this.PropName.GetValue(e.RowObject).ToString());
                        if (!(propertyInfo is null))
                        {
                            RTCVariableType value = (RTCVariableType)propertyInfo.GetValue(Action, null);
                            {
                                if (value.DataItems != null && value.DataItems.Count > 0)
                                {
                                    Button btnViewList = new Button();
                                    btnViewList.Bounds = e.CellBounds;
                                    btnViewList.Text = "ViewList";
                                }
                                else
                                {
                                    TextBox txtOut = new TextBox();
                                    txtOut.Bounds = e.CellBounds;
                                    e.Control = txtOut;
                                    break;
                                }
                            }
                        }
                        break;
                    }
            }

        }


        private OLVColumn FocusingCol = null;
        private void CustomNodeCellEdit_Column_Value(CellEditEventArgs e)
        {
           
            EPropertyState eNodeState = GlobFuncs.GetPropertyNodeState((MyPropertiesItem)e.RowObject, this.State);
            ComboBox cbBool = new ComboBox();
            cbBool.Items.Add(cStrings.True);
            cbBool.DropDownStyle = ComboBoxStyle.DropDownList;

            cbBool.Items.Add(cStrings.False);
            //cbBool.SelectedIndexChanged -= ComboBoxSelectedIndexChanged;
            //cbBool.SelectedIndexChanged += ComboBoxSelectedIndexChanged;

            // cbBool.SelectedIndexChanged -= 
            TextBox txt = new TextBox();
            txt.Bounds = e.CellBounds;
            txt.KeyDown -= TextBoxKeyDown;
            txt.KeyDown += TextBoxKeyDown;

            switch (eNodeState)
            {
                case EPropertyState.DataItemParentView:
                    {
                        e.Cancel = true;
                        break;
                    }
                case EPropertyState.DataItemView:
                    {
                        //TextBox txtData = new TextBox();
                        //txtData.Bounds = e.CellBounds;
                        //e.Control = new TextBox();
                        e.Cancel = true;
                        break;
                    }
                case EPropertyState.Output:
                    {

                        e.Cancel = true;
                        break;
                    }
                case EPropertyState.Input:
                    {
                        string sValues = string.Empty;
                        string[] Values = { };
                        string sPropName = this.PropName.GetValue(e.RowObject).ToString();
                        PropertyInfo propertyInfo = Action.GetType().GetProperty(sPropName);
                        if (propertyInfo == null)
                        {
                            e.Cancel = true;
                            return;
                        }

                        RTCVariableType rtcVar = (RTCVariableType)propertyInfo.GetValue(Action, null);
                        FocusingCol = e.Column;
                        switch (propertyInfo.PropertyType.Name)
                        {
                            case nameof(SBool):
                                {
                                    this.Value.PutValue(e.RowObject, ((SBool)rtcVar).rtcValue);
                                    //tlvAction.UpdateObject(e.RowObject);
                                    if (!rtcVar.rtcReadOnly)
                                    {
                                        cbBool.Bounds = e.CellBounds;
                                        //cbBool.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
                                        cbBool.SelectedIndex = cbBool.Items.IndexOf(((MyPropertiesItem)e.RowObject).Value);
                                        cbBool.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
                                        e.Control = cbBool;
                                        e.NewValue = cbBool.SelectedItem;
                                    }
                                    break;
                                }
                            case nameof(SString):
                                {
                                    this.Value.PutValue(e.RowObject, ((SString)rtcVar).rtcValue);
                                    //tlvAction.UpdateObject(e.RowObject);
                                    // lẤY GIÁ TRJ NẾU CÓ
                                    if (!rtcVar.rtcReadOnly)
                                    {
                                        sValues = CommonData.GetPropertyValues(sPropName + cStrings.SepGDung + Action.ActionType.ToString());
                                        if (sValues != "")
                                        {
                                            Values = sValues.Split(cStrings.SepGDung);
                                            ComboBox CB = new ComboBox();
                                            CB.Items.AddRange(Values);
                                            //CB.Text = this.Value.GetValue(e.RowObject).ToString();
                                            CB.Bounds = e.CellBounds;
                                            CB.DropDownStyle = ComboBoxStyle.DropDownList;

                                            CB.SelectedIndex = CB.Items.IndexOf(e.Value);
                                            CB.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
                                            e.Control = CB;
                                            e.NewValue = CB.SelectedItem;
                                            //tlvAction.FinishCellEdit();
                                            // e.RowObject.GetType().GetProperty(e.Column.AspectName)?.SetValue(e.RowObject, CB.Text);

                                        }
                                        else
                                        {
                                            this.Value.PutValue(e.RowObject, ((SString)rtcVar).rtcValue);
                                            tlvAction.RefreshObject(e.RowObject);
                                            txt.Text = e.Value.ToString();
                                            e.Control = txt;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            case nameof(SListDouble):
                                {
                                    this.Value.PutValue(e.RowObject, GlobFuncs.ListDouble2Str(((SListDouble)rtcVar).rtcValue));
                                    tlvAction.RefreshObject(e.RowObject);
                                    txt.Text = e.Value.ToString();
                                    e.Control = txt;
                                    break;
                                }
                            case nameof(SListString):
                                {
                                    txt = new TextBox();
                                    this.Value.PutValue(e.RowObject, GlobFuncs.ListString2StrWithType(((SListString)rtcVar).rtcValue));
                                    tlvAction.RefreshObject(e.RowObject);
                                    txt.Text = e.Value.ToString();
                                    txt.Bounds = e.CellBounds;
                                    txt.KeyDown += TextBoxKeyDown;

                                    e.Control = txt;
                                    break;
                                }
                            case nameof(SListObject):
                                {
                                    this.Value.PutValue(e.RowObject, GlobFuncs.ListObject2StrWithType(((SListObject)rtcVar).rtcValue));
                                    tlvAction.RefreshObject(e.RowObject);
                                    txt.Text = e.Value.ToString();
                                    txt.Bounds = e.CellBounds;
                                    e.Control = txt;
                                    break;
                                }
                            case nameof(SImage):
                                {
                                    txt.Text = e.Value.ToString();
                                    e.Control = txt;
                                    break;
                                }
                            case nameof(SDouble):
                                {
                                    this.Value.PutValue(e.RowObject, ((SDouble)rtcVar).rtcValue);
                                    //tlvAction.UpdateObject(e.RowObject);
                                    txt.Text = e.Value.ToString();
                                    e.Control = txt;
                                    break;
                                }
                            case nameof(SInt):
                                {
                                    this.Value.PutValue(e.RowObject, ((SInt)rtcVar).rtcValue);
                                    tlvAction.RefreshObject(e.RowObject);
                                    txt.Text = e.Value.ToString();
                                    e.Control = txt;
                                    break;
                                }
                            default:
                                {
                                    e.Cancel = true;
                                    break;
                                }

                        }
                        break;

                    }
                case EPropertyState.None:
                    {
                        string sValues = string.Empty;
                        string[] Values = { };

                        string sPropName = this.PropName.GetValue(e.RowObject).ToString();
                        PropertyInfo propertyInfo = Action.GetType().GetProperty(sPropName);
                        FocusingCol = e.Column;
                        if (propertyInfo == null)
                        {
                            e.Cancel = true;
                            return;
                        }

                        RTCVariableType rtcVar = (RTCVariableType)propertyInfo.GetValue(Action, null);
                        switch (propertyInfo.PropertyType.Name)
                        {
                            case nameof(SBool):
                                {
                                    this.Value.PutValue(e.RowObject, ((SBool)rtcVar).rtcValue);
                                    //tlvAction.UpdateObject(e.RowObject);
                                    if (!rtcVar.rtcReadOnly)
                                    {
                                        cbBool.Bounds = e.CellBounds;
                                        //cbBool.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
                                        cbBool.SelectedIndex = cbBool.Items.IndexOf(((MyPropertiesItem)e.RowObject).Value);
                                        cbBool.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
                                        e.Control = cbBool;
                                        e.NewValue = cbBool.SelectedItem;
                                    }
                                    break;
                                }
                            case nameof(SString):
                                {
                                    this.Value.PutValue(e.RowObject, ((SString)rtcVar).rtcValue);
                                    //tlvAction.UpdateObject(e.RowObject);
                                    // lẤY GIÁ TRJ NẾU CÓ
                                    if (!rtcVar.rtcReadOnly)
                                    {
                                        sValues = CommonData.GetPropertyValues(sPropName + cStrings.SepGDung + Action.ActionType.ToString());
                                        if (sValues != "")
                                        {
                                            Values = sValues.Split(cStrings.SepGDung);
                                            ComboBox CB = new ComboBox();
                                            CB.Items.AddRange(Values);
                                            //CB.Text = this.Value.GetValue(e.RowObject).ToString();
                                            CB.Bounds = e.CellBounds;
                                            CB.DropDownStyle = ComboBoxStyle.DropDownList;

                                            CB.SelectedIndex = CB.Items.IndexOf(e.Value);
                                            CB.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
                                            e.Control = CB;
                                            e.NewValue = CB.SelectedItem;
                                            //tlvAction.FinishCellEdit();
                                            // e.RowObject.GetType().GetProperty(e.Column.AspectName)?.SetValue(e.RowObject, CB.Text);

                                        }
                                        else
                                        {
                                            this.Value.PutValue(e.RowObject, ((SString)rtcVar).rtcValue);
                                            tlvAction.UpdateObject(e.RowObject);
                                            txt.Text = e.Value.ToString();
                                            e.Control = txt;
                                            //tlvAction.FinishCellEdit();
                                            break;

                                        }

                                    }
                                    break;
                                }
                            case nameof(SListString):
                                {
                                    this.Value.PutValue(e.RowObject, GlobFuncs.ListString2StrWithType(((SListString)rtcVar).rtcValue));
                                    tlvAction.UpdateObject(e.RowObject);
                                    txt.Text = e.Value.ToString();
                                    txt.Bounds = e.CellBounds;
                                    e.Control = txt;
                                    //tlvAction.FinishCellEdit();
                                    break;
                                }
                            case nameof(SListDouble):
                                {
                                    txt.Text = e.Value.ToString();
                                    txt.Bounds = e.CellBounds;
                                    e.Control = txt;

                                    //tlvAction.FinishCellEdit();
                                    break;
                                }

                        }
                        break;





                    }
                default:
                    {
                        string dataItemName = this.PropName.GetValue(e.RowObject).ToString();
                        SStringBuilderItem dataItem = null;
                        FocusingCol = e.Column;
                        if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                            dataItem = Action.MyExpression.Operands.FirstOrDefault(x => x.Name == dataItemName);
                        if (dataItem == null && Action.DataItems != null)
                            dataItem = Action.DataItems.FirstOrDefault(x => x.Name == dataItemName);
                        if (dataItem != null)
                            switch (dataItem.ValueStyle)
                            {
                                case EHTupleStyle.Boolean:
                                    {
                                        e.Control = cbBool;
                                        cbBool.DropDownStyle = ComboBoxStyle.DropDownList;

                                        break;
                                    }
                                default:
                                    {
                                        txt.Text = e.Value.ToString();
                                        txt.Bounds = e.CellBounds;
                                        e.Control = txt;
                                        e.NewValue = txt.Text;
                                        break;
                                    }
                            }
                        break;
                    }
            }
        } 



        public void TextBoxKeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode != Keys.Enter)
            //    return;
            //MyPropertiesItem focusNode = (MyPropertiesItem)tlvAction.FocusedObject;
            //if (focusNode == null || FocusingCol != this.Value)
            //    return;
            //TextBox textbox = (TextBox)sender;
            //string sValue = textbox.ToString();
            //EPropertyState ePropertyState = GlobFuncs.GetPropertyNodeState(focusNode, this.State);
            //if (ePropertyState == EPropertyState.Operand)
            //{
            //    string openrandName = this.PropName.GetValue(focusNode).ToString();
            //    SStringBuilderItem openandItem = null;

            //    switch (Action.ActionType)
            //    {
            //        case EActionTypes.Branch:
            //            if (Action.MyExpression != null && Action.MyExpression.Operands != null)
            //                openandItem = Action.MyExpression.Operands.Find(X => X.Name == openrandName);
            //            break;
            //        case EActionTypes.Switch:
            //            if (Action.MyExpression != null && Action.MyExpression.Operands != null)
            //                openandItem = Action.MyExpression.Operands.Find(X => X.Name == openrandName);
            //            break;
            //    }
            //    if (openandItem == null) return;
            //    string[] arrValues = new string[] { };
            //    if (sValue.Contains(cChars.Comma))
            //        arrValues = sValue.Split(cChars.Comma);
            //    else
            //        arrValues = sValue.Split(cChars.Comma);
            //    double dValue = 0;
            //    int iValue = 0;
            //    bool bValue = false;
                
            //    switch (openandItem.ValueStyle)
            //    {
            //        case EHTupleStyle.Boolean:
            //            if (bool.TryParse(sValue, out bValue))

            //                openandItem.ListStringValue = new List<string>() { bValue.ToString() };
            //            else
            //                openandItem.ListStringValue = new List<string>() { cStrings.@false };
            //            break;
            //        case EHTupleStyle.BooleanList:
            //            foreach (var arrValue in arrValues)
            //                if (bool.TryParse(arrValue, out bValue))

            //                    openandItem.ListStringValue.Add(bValue.ToString());
            //                else
            //                    openandItem.ListStringValue.Add( cStrings.@false);
            //            break;
            //        case EHTupleStyle.Integer:
            //            if (int.TryParse(sValue, out iValue))

            //                openandItem.ListDoubleValue = new List<double>() { iValue };
            //            else
            //                openandItem.ListDoubleValue = new List<double>() { 0};
            //            break;
            //        case EHTupleStyle.IntegerList:
            //            foreach( var arrValue in arrValues )
            //            if (int.TryParse(arrValue, out iValue))
            //                openandItem.ListDoubleValue.Add(iValue);
            //            break;

            //        case EHTupleStyle.String:
            //            openandItem.ListStringValue = new List<String>() { sValue };
            //            break;
            //        case EHTupleStyle.StringList:
            //            foreach (var arrValue in arrValues)
            //                openandItem.ListStringValue.Add( arrValue);
            //            break;
            //        case EHTupleStyle.Real:
            //            if (double.TryParse(sValue, out dValue))
            //                openandItem.ListDoubleValue = new List<double>() { dValue };
            //            else
            //                openandItem.ListDoubleValue = new List<double>() { 0 };
            //            break;
            //        case EHTupleStyle.RealList:
            //            foreach (var arrValue in arrValues)
            //                if (double.TryParse(arrValue, out dValue))
            //                    openandItem.ListDoubleValue.Add(dValue);
            //            break;
            //    }
            //    // tlvAction.FinishCellEdit();
            //    //
            //    openandItem.ListDoubleValue = openandItem.ListDoubleValue;
            //    openandItem.ListStringValue = openandItem.ListStringValue;
            //    this.Value.PutValue(focusNode, openandItem.ValueView.ToString());
            //    if (Action.AutoRun)
            //        RunAction();
            //}
            //else
            //{
            //    string sPropName = this.PropName.GetValue(focusNode).ToString();
            //    RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(sPropName)?.GetValue(Action, null);
            //    if (propertyInfo != null)
            //    {
            //        PropertyInfo propertyInfo_Value = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            //        //switch (propertyInfo.GetType().Name)
            //        //{
            //        //    case nameof(SBool):
            //        //        if (!(propertyInfo_Value is null))
            //        //            propertyInfo_Value.SetValue(propertyInfo, bool.Parse(textbox.SelectedItem.ToString()));
            //        //        this.Value.PutValue(focusNode, bool.Parse(textbox.SelectedItem.ToString()));
            //        //        //tlvAction.UpdateObject(focusNode);
            //        //        //tlvAction.RefreshObject(focusNode);
            //        //        break;
            //        //    case nameof(SString):
            //        //        if (!(propertyInfo_Value is null))
            //        //            propertyInfo_Value.SetValue(propertyInfo, textbox.SelectedItem.ToString());
            //        //        this.Value.PutValue(focusNode, textbox.SelectedItem.ToString());
            //        //        //tlvAction.RefreshObject(focusNode);

            //        //        break;
            //        //    case nameof(SInt):
            //        //        if (!(propertyInfo_Value is null))
            //        //            propertyInfo_Value.SetValue(propertyInfo, int.Parse(textbox.SelectedItem.ToString()));
            //        //        this.Value.PutValue(focusNode, int.Parse(textbox.SelectedItem.ToString()));
            //        //        // tlvAction.RefreshObject(focusNode);

            //        //        break;
            //        //    case nameof(SDouble):
            //        //        if (!(propertyInfo_Value is null))
            //        //            propertyInfo_Value.SetValue(propertyInfo, double.Parse(textbox.SelectedItem.ToString()));
            //        //        this.Value.PutValue(focusNode, double.Parse(textbox.SelectedItem.ToString()));
            //        //        //tlvAction.RefreshObject(focusNode);

            //        //        break;
            //        //    default:
            //        //        break;

            //        //}
            //        //tlvAction.FinishCellEdit();

            //    }
            //    //this.Value.PutValue(this.Value, oper)
            //    if (Action.AutoRun)
            //        RunAction();
            //    UpdateReferencePropertyControls(sPropName);
            //    UpdatePropertyValueToControls(sPropName);
            //    UpdatePropertyValueToPropertyGrid(sPropName, true);
            //    if (sPropName == nameof(Action.Enable))
            //    {
            //        this.Enable.PutValue(Action.MyNode, Action.Enable.rtcValue);
            //        tlvAction.UpdateObject(Action.MyNode);
            //    }
            //}
            //tlvAction.FinishCellEdit();


        }
    



        private bool ValidateNodeValue_RangeMinMaxLimit(object Node, string[] sValues, SListDouble sListDouble)
        {
            string sErr = string.Empty;
            if (sValues.Count() != 4) sErr = RTC_Vision_Lite.Properties.Resources.TheNumberOfElementsIsnotEnough;
            if (sErr != string.Empty)
                foreach (string item in sValues)
                    if (!GlobFuncs.IsNumeric(item))
                    {
                        sErr = RTC_Vision_Lite.Properties.Resources.ValueMustBeANumber;
                        break;
                    }
            if (sErr == string.Empty && double.Parse(sValues[0]) >= double.Parse(sValues[1])) sErr = RTC_Vision_Lite.Properties.Resources.MinValueMustBeSmaller;
            if (sErr == string.Empty && double.Parse(sValues[2]) >= double.Parse(sValues[3])) sErr = RTC_Vision_Lite.Properties.Resources.MinValueLIMITMustBeLessThanMaxValueLIMIT;
            if (sErr == string.Empty && double.Parse(sValues[0]) >= double.Parse(sValues[1])) sErr = RTC_Vision_Lite.Properties.Resources.MinValueMustBeLessThanOrEqualsMinValueLIMIT;
            if (sErr == string.Empty && double.Parse(sValues[0]) >= double.Parse(sValues[1])) sErr = RTC_Vision_Lite.Properties.Resources.MaxValueMustBeLessThanOrEqualsMaxValueLIMIT;

            if (sErr != string.Empty)
            {
                cMessageBox.Warning(sErr);
                this.Value.PutValue(Node, sListDouble.rtcValueView);
                return false;
            }
            List<double> listDouble = new List<double>();
            listDouble.Add(double.Parse(sValues[0]));
            listDouble.Add(double.Parse(sValues[1]));
            listDouble.Add(double.Parse(sValues[2]));
            listDouble.Add(double.Parse(sValues[3]));
            sListDouble.rtcValue = listDouble;
            UpdateNodePropertyValue(Node, sListDouble);
            return true;



        }
        private bool ValidateNodeValue_Point(object Node, string[] sValues, SListDouble sListDouble)
        {
            string sErr = string.Empty;
            if (sValues.Count() != 0 || sValues.Count() % 2 != 0) sErr = RTC_Vision_Lite.Properties.Resources.TheNumberOfElementsIsnotEnough;
            if (sErr != string.Empty)
                foreach (string item in sValues)
                    if (!GlobFuncs.IsNumeric(item))
                    {
                        sErr = RTC_Vision_Lite.Properties.Resources.ValueMustBeANumber;
                        break;
                    }

            if (sErr != string.Empty)
            {
                cMessageBox.Warning(sErr);
                this.Value.PutValue(Node, sListDouble.rtcValueView);
                return false;
            }
            List<double> listDouble = new List<double>();
            for (int i = 0; i < sValues.Count(); i++)
            {
                listDouble.Add(double.Parse(sValues[i]));
            }
            sListDouble.rtcValue = listDouble;
            UpdateNodePropertyValue(Node, sListDouble);
            return true;
        }
        private bool ValidateNodeValue_Rectang(object Node, string[] sValues, SListDouble sListDouble)
        {
            string sErr = string.Empty;
            if (sValues.Count() != 5) sErr = RTC_Vision_Lite.Properties.Resources.TheNumberOfElementsIsnotEnough;
            if (sErr != string.Empty)
                foreach (string item in sValues)
                    if (!GlobFuncs.IsNumeric(item))
                    {
                        sErr = RTC_Vision_Lite.Properties.Resources.ValueMustBeANumber;
                        break;
                    }

            if (sErr != string.Empty)
            {
                cMessageBox.Warning(sErr);
                this.Value.PutValue(Node, sListDouble.rtcValueView);
                return false;
            }
            List<double> listDouble = new List<double>();
            for (int i = 0; i < sValues.Count(); i++)
            {
                listDouble.Add(double.Parse(sValues[i]));
            }
            sListDouble.rtcValue = listDouble;
            UpdateNodePropertyValue(Node, sListDouble);
            return true;
        }
        private void ValidateNodeValue_StringRange(object Node, string[] sValues, SListString sListString)
        {
            List<string> ListString = new List<string>();
            for (int i = 0; i < sValues.Count(); i++)
            {
                if (sValues[i].StartsWith("'")) sValues[i] = sValues[i].Substring(1);
                if (sValues[i].EndsWith("'")) sValues[i] = sValues[i].Substring(0, sValues[i].Length - 1);
                ListString.Add(sValues[i]);
            }
            sListString.rtcValue = ListString;
            UpdateNodePropertyValue(Node, sListString);

        }
        private void ValidateNodeValue_ValueList(object Node, string[] sValues, SListString sListString)
        {
            List<string> ListString = new List<string>();
            foreach (var sValue in sValues)
            {
                ListString.Add(sValue.ToString());
            }
            sListString.rtcValue = ListString;
            UpdateNodePropertyValue(Node, sListString);
        }
        private bool ValidateNodeValue_ValueList(object Node, string[] sValues, SListDouble sListDouble)
        {
            List<double> ListDouble = new List<double>();
            foreach (var sValue in sValues)
            {
                if (int.TryParse(sValue, out int iValue))
                    ListDouble.Add(iValue);
                else if (long.TryParse(sValue, out long lValue))
                {
                    ListDouble.Add(lValue);
                }
                else if (double.TryParse(sValue, out double dValue))
                    ListDouble.Add(dValue);

            }
            sListDouble.rtcValue = ListDouble;
            UpdateNodePropertyValue(Node, sListDouble);
            return true;
        }
        private bool ValidateNodeValue_Origin(object Node, string[] sValues, SListDouble sListDouble)
        {
            string sErr = string.Empty;
            if (sValues.Count() <3) sErr = RTC_Vision_Lite.Properties.Resources.TheNumberOfElementsIsnotEnough;
            if (sErr != string.Empty)
                foreach (string item in sValues)
                    if (!GlobFuncs.IsNumeric(item))
                    {
                        sErr = RTC_Vision_Lite.Properties.Resources.ValueMustBeANumber;
                        break;
                    }

            if (sErr != string.Empty)
            {
                cMessageBox.Warning(sErr);
                this.Value.PutValue(Node, sListDouble.rtcValueView);
                return false;
            }
            List<double> listDouble = new List<double>();
            for (int i = 0; i < sValues.Count(); i++)
            {
                listDouble.Add(double.Parse(sValues[i]));
            }
            sListDouble.rtcValue = listDouble;
            UpdateNodePropertyValue(Node, sListDouble);
            return true;
        }
        private bool ValidateNodeValue_Line(object Node, string[] sValues, SListDouble sListDouble)
        {
            string sErr = string.Empty;
            if (sValues.Count() != 4) sErr = RTC_Vision_Lite.Properties.Resources.TheNumberOfElementsIsnotEnough;
            if (sErr != string.Empty)
                foreach (string item in sValues)
                    if (!GlobFuncs.IsNumeric(item))
                    {
                        sErr = RTC_Vision_Lite.Properties.Resources.ValueMustBeANumber;
                        break;
                    }

            if (sErr != string.Empty)
            {
                cMessageBox.Warning(sErr);
                this.Value.PutValue(Node, sListDouble.rtcValueView);
                return false;
            }
            List<double> listDouble = new List<double>();
            for (int i = 0; i < sValues.Count(); i++)
            {
                listDouble.Add(double.Parse(sValues[i]));
            }
            sListDouble.rtcValue = listDouble;
            UpdateNodePropertyValue(Node, sListDouble);
            return true;
        }
        private bool ValidateNodeValue_None(object Node, string[] sValues, SListDouble sListDouble)
        {
            string sErr = string.Empty;
            if (sValues.Count() != 4) sErr = RTC_Vision_Lite.Properties.Resources.TheNumberOfElementsIsnotEnough;
            if (sErr != string.Empty)
                foreach (string item in sValues)
                    if (!GlobFuncs.IsNumeric(item))
                    {
                        sErr = RTC_Vision_Lite.Properties.Resources.ValueMustBeANumber;
                        break;
                    }

            if (sErr != string.Empty)
            {
                cMessageBox.Warning(sErr);
                this.Value.PutValue(Node, sListDouble.rtcValueView);
                return false;
            }
            List<double> listDouble = new List<double>();
            for (int i = 0; i < sValues.Count(); i++)
            {
                listDouble.Add(double.Parse(sValues[i]));
            }
            sListDouble.rtcValue = listDouble;
            UpdateNodePropertyValue(Node, sListDouble);
            return true;
        }

        private bool ValidateNodeValue_RangeMinMax(object Node, string[] sValues, SListDouble sListDouble)
        {
            double dMax = 0;
            double dMin = 0;
            if (sValues.Length < 2)
            {
                cMessageBox.Warning(cMessageContent.War_MustHave2Value);
                return false;
            }    
            if (!GlobFuncs.IsNumeric(sValues[0]) && sValues[0].ToLower() != cStrings.Inf.ToLower())
            {
                cMessageBox.Warning(cMessageContent.War_OnlyAcceptNumericOrInf);
                return false;
            }
            if (!GlobFuncs.IsNumeric(sValues[1]) && sValues[1].ToLower() != cStrings.Inf.ToLower())
            {
                cMessageBox.Warning(cMessageContent.War_OnlyAcceptNumericOrInf);
                return false;
            }
            if (sValues[0].ToLower() == cStrings.Inf.ToLower() && sValues[1].ToLower() != cStrings.Inf.ToLower())
            {
                cMessageBox.Warning(RTC_Vision_Lite.Properties.Resources.MinValueMustBeSmaller);
                return false;
            }
            List<double> listDouble = new List<double>() { };
            double.TryParse(sValues[0], out dMin);
            listDouble.Add(dMin);
            double.TryParse(sValues[1], out dMax);
            listDouble.Add(dMax);
            sListDouble.rtcValue = listDouble;
            UpdateNodePropertyValue(Node, sListDouble);

            return true;
        }

        private void UpdateNodePropertyValue(object Node, SListDouble Value)
        {
            MyPropertiesItem UpdateNode = (MyPropertiesItem)Node;
            this.Value.PutValue(Node, Value.rtcValueView);
            foreach (MyPropertiesItem childnode in UpdateNode.child)
            {
                string sPropName = this.PropName.GetValue(childnode).ToString();
                if (sPropName != cPropertyName.rtcValueView) continue;
                Object obj = Value.GetType().GetProperty(sPropName).GetValue(Value, null);
                this.Value.PutValue(UpdateNode, obj.ToString());
            }
            
            tlvAction.RefreshObject(Node);
            var test = tlvAction.Roots;

        }
        private void UpdateNodePropertyValue(object Node, SListString Value)
        {
            MyPropertiesItem UpdateNode = (MyPropertiesItem)Node;
            this.Value.PutValue(Node, Value.rtcValueView);
            foreach (MyPropertiesItem childnode in UpdateNode.child)
            {
                string sPropName = this.PropName.GetValue(childnode).ToString();
                if (sPropName != cPropertyName.rtcValueView) continue;
                Object obj = Value.GetType().GetProperty(sPropName).GetValue(Value, null);
                this.Value.PutValue(UpdateNode, obj.ToString());
            }
            tlvAction.RefreshSelectedObjects();

        }
        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            //var test = tlvAction.CellEditKeyEngine.GetType().GetProperties();
            MyPropertiesItem focusNode = (MyPropertiesItem)tlvAction.FocusedObject;
            if (focusNode == null || FocusingCol != this.Value)
                return;
            ComboBox comboBox = (ComboBox)sender;
            EPropertyState ePropertyState = GlobFuncs.GetPropertyNodeState(focusNode, this.State);
            if (ePropertyState == EPropertyState.Operand)
            {
                string openrandName = this.PropName.GetValue(focusNode).ToString();
                SStringBuilderItem openandItem = null;

                switch (Action.ActionType)
                {
                    case EActionTypes.Branch:
                        if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                            openandItem = Action.MyExpression.Operands.Find(X => X.Name == openrandName);
                        break;
                    case EActionTypes.Switch:
                        if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                            openandItem = Action.MyExpression.Operands.Find(X => X.Name == openrandName);
                        break;
                }
                if (openandItem == null) return;
                switch (openandItem.ValueStyle)
                {
                    case EHTupleStyle.Boolean:
                        openandItem.ListStringValue = new List<string>() { comboBox.SelectedValue.ToString() };
                        break;
                    case EHTupleStyle.Integer:
                        openandItem.ListDoubleValue = new List<double>() { int.Parse(comboBox.SelectedValue.ToString()) };
                        break;
                    case EHTupleStyle.String:
                        openandItem.ListStringValue = new List<String>() { (comboBox.SelectedValue.ToString()) };
                        break;
                    case EHTupleStyle.Real:
                        openandItem.ListDoubleValue = new List<double>() { int.Parse(comboBox.SelectedValue.ToString()) };
                        break;
                }
                // tlvAction.FinishCellEdit();
                //
                this.Value.PutValue(focusNode, openandItem.ValueView.ToString());
                if (Action.AutoRun)
                    RunAction();
            }
            else
            {
                string sPropName = this.PropName.GetValue(focusNode).ToString();
                RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(sPropName)?.GetValue(Action, null);
                if (propertyInfo != null)
                {
                    PropertyInfo propertyInfo_Value = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                    switch (propertyInfo.GetType().Name)
                    {
                        case nameof(SBool):
                            if (!(propertyInfo_Value is null))
                                propertyInfo_Value.SetValue(propertyInfo, bool.Parse(comboBox.SelectedItem.ToString()));
                            this.Value.PutValue(focusNode, bool.Parse(comboBox.SelectedItem.ToString()));
                            //tlvAction.UpdateObject(focusNode);
                            //tlvAction.RefreshObject(focusNode);
                            break;
                        case nameof(SString):
                            if (!(propertyInfo_Value is null))
                                propertyInfo_Value.SetValue(propertyInfo, comboBox.SelectedItem.ToString());
                            this.Value.PutValue(focusNode, comboBox.SelectedItem.ToString());
                            //tlvAction.RefreshObject(focusNode);

                            break;
                        case nameof(SInt):
                            if (!(propertyInfo_Value is null))
                                propertyInfo_Value.SetValue(propertyInfo, int.Parse(comboBox.SelectedItem.ToString()));
                            this.Value.PutValue(focusNode, int.Parse(comboBox.SelectedItem.ToString()));
                            // tlvAction.RefreshObject(focusNode);

                            break;
                        case nameof(SDouble):
                            if (!(propertyInfo_Value is null))
                                propertyInfo_Value.SetValue(propertyInfo, double.Parse(comboBox.SelectedItem.ToString()));
                            this.Value.PutValue(focusNode, double.Parse(comboBox.SelectedItem.ToString()));
                            //tlvAction.RefreshObject(focusNode);

                            break;
                        default:
                            break;

                    }
                    //tlvAction.FinishCellEdit();

                }
                //this.Value.PutValue(this.Value, oper)
                if (Action.AutoRun)
                    RunAction();
                UpdateReferencePropertyControls(sPropName);
                UpdatePropertyValueToControls(sPropName);
                UpdatePropertyValueToPropertyGrid(sPropName, true);
                if (sPropName == nameof(Action.Enable))
                {
                    this.Enable.PutValue(focusNode, Action.Enable.rtcValue);
                    GlobVar.FrmActions.ucActionList.colEnable.PutValue(Action.MyNode, Action.Enable.rtcValue);
                    //tlvAction.UpdateObject(Action.MyNode);
                }
            }
            tlvAction.FinishCellEdit();


        }

        private void CustomNodeCellEdit_Column_btnLink(CellEditEventArgs e)
        {
            EPropertyState eNodeState = GlobFuncs.GetPropertyNodeState((MyPropertiesItem)e.RowObject, this.State);
            switch (eNodeState)
            {
                case EPropertyState.DataItemParentView:
                    {
                        TextBox txtOut = new TextBox();
                        txtOut.Bounds = e.CellBounds;
                        e.Control = txtOut;
                        break;
                    }
                case EPropertyState.DataItemView:
                    {
                        TextBox txtOut = new TextBox();
                        txtOut.Bounds = e.CellBounds;
                        e.Control = txtOut;
                        break;
                    }
                default:
                    {
                        Button btnLink = new Button();
                        btnLink.Bounds = e.CellBounds;
                        btnLink.Text = "Link";
                        Button btnReadOnly = new Button();
                        btnReadOnly.Bounds = e.CellBounds;
                        btnReadOnly.Text = "ReadOnly";
                        e.Control = (bool)this.Enable.GetValue(e.RowObject) ? btnLink : btnReadOnly;
                        break;
                    }

            }


        }

        private void btnRunAction_Click(object sender, EventArgs e)
        {
            RunAction(false, true);
        }
        private void tlvAction_CellClick(object sender, CellClickEventArgs e)
        {
            GlobFuncs.BeginControlUpdate(tlvAction);

            try
            {
                if (tlvAction.FocusedObject == null)
                {
                    return;
                }
                string sPropName = string.Empty;
                if (GlobVar.GroupActions.IsRun || Action == null)
                {
                    return;
                }
                if (e.Column == this.Value)
                {
                    MyPropertiesItem FocusNode = (MyPropertiesItem)tlvAction.FocusedObject;

                    sPropName = FocusNode.Name;
                    ENodeTypes eNodeTypes = FocusNode.NodeType;
                    EPropertyState eNodeState = FocusNode.State;
                    if (eNodeState == EPropertyState.Operand || eNodeState == EPropertyState.DataItemParent)
                    {
                        return;
                    }
                    else
                    {
                        PropertyInfo propertyInfo = Action.GetType().GetProperty(sPropName);
                        if (propertyInfo == null)
                        {
                            return;
                        }
                        RTCVariableType rtcVar = (RTCVariableType)propertyInfo.GetValue(Action, null);
                        if ((rtcVar.rtcSystem && rtcVar.rtcReadOnly) ||
                            rtcVar.rtcState == EPropertyState.Output ||
                            rtcVar.rtcReadOnly ||
                            rtcVar.rtcIDRef != Guid.Empty)
                        {
                            return;
                        }
                        switch (propertyInfo.PropertyType.Name)
                        {
                            case nameof(SString):
                                {
                                    Value.PutValue(e.Model, ((SString)rtcVar).rtcValue);
                                    break;
                                }
                            case nameof(SBool):
                                {
                                    Value.PutValue(e.Model, ((SBool)rtcVar).rtcValue.ToString());
                                    break;
                                }
                            case nameof(SInt):
                                {
                                    Value.PutValue(e.Model, ((SInt)rtcVar).rtcValue);
                                    break;
                                }
                            case nameof(SDouble):
                                {
                                    Value.PutValue(e.Model, ((SDouble)rtcVar).rtcValue.ToString());
                                    break;
                                }
                            case nameof(SDateTime):
                                {
                                    Value.PutValue(e.Model, ((SDateTime)rtcVar).rtcValue.ToString());
                                    break;
                                }
                            case nameof(SListDouble):
                                {
                                    Value.PutValue(e.Model, GlobFuncs.Ve2Str(((SListDouble)rtcVar).rtcValue));
                                    break;
                                }
                            case nameof(SListObject):
                                {
                                    Value.PutValue(e.Model, GlobFuncs.Ve2Str(((SListObject)rtcVar).rtcValue));
                                    break;
                                }
                            case nameof(SListString):
                                {
                                    Value.PutValue(e.Model, GlobFuncs.Ve2Str(((SListString)rtcVar).rtcValue));
                                    break;
                                }

                        }
                    }
                    tlvAction.EndUpdate();
                    return;
                }
                if (e.Item == null || (e.Column != this.btnLink &&
                   e.Column != this.btnRemoveLink &&
                   e.Column != this.btnViewList ||
                   !Action.IsCanEdit.rtcValue))
                {
                    return;
                }
                if (e.Column == this.btnRemoveLink)
                {
                    Guid IDRef = (Guid)(this.IDref.GetValue(e.Item.RowObject));
                    if (IDRef == Guid.Empty)
                    {
                        return;
                    }
                }
                if (e.Column == this.btnViewList)
                {
                    ViewDataItemList((MyPropertiesItem)(e.Item.RowObject));
                    return;
                }
                //if (e.Item == null || (e.Column != this.btnLink && e.Column != btnRemoveLink && e.Column != this.btnViewList || !Action.IsCanEdit.rtcValue)) return;
                EPropertyState propertyState = (EPropertyState)(this.State?.GetValue(e.Item.RowObject));
                sPropName = this.PropName.GetValue(e.Item.RowObject).ToString();

                if (propertyState == EPropertyState.Input || propertyState == EPropertyState.None)
                {
                    RTCE_ActionDetailProperties_RowCellClickEventArgs eRTC = new RTCE_ActionDetailProperties_RowCellClickEventArgs();
                    eRTC.Node = (MyPropertiesItem)e.Item.RowObject;
                    eRTC.Base = this;
                    eRTC.IDRef = (Guid)(this.IDref.GetValue(e.Item.RowObject));
                    eRTC.ActionType = (ENodeTypes)this.NodeType.GetValue(e.Item.RowObject);
                    eRTC.Enable = (bool)this.Enable.GetValue(e.Item.RowObject);
                    eRTC.ActionName = (string)this.PropName.GetValue(e.Item.RowObject);
                    eRTC.Type = (string)this.Type.GetValue(e.Item.RowObject);
                    eRTC.Value = this.Value.GetValue(e.Item.RowObject)?.ToString();
                    eRTC.IsSytem = (bool)this.IsSystem.GetValue(e.Item.RowObject);
                    eRTC.ValueStyle = ((RTCVariableType)Action.GetType().GetProperty(eRTC.ActionName).GetValue(Action, null)).ValueStyle;
                    eRTC.CIDRef = this.IDref;
                    eRTC.CActionType = this.NodeType;
                    eRTC.CEnable = this.Enable;
                    eRTC.CType = this.Type;
                    eRTC.CValue = this.Value;
                    eRTC.CIsSystem = this.IsSystem;
                    eRTC.CActionName = this.PropName;
                    eRTC.TreeList = this.tlvAction;
                    eRTC.action = this.Action;

                    if (e.Column == this.btnLink)
                    {
                        if (OnPropertiesRowCellClickbtnLink != null)
                        {
                            OnPropertiesRowCellClickbtnLink(sender, eRTC);
                        }
                    }
                    else if (e.Column == this.btnRemoveLink)
                    {
                        if (OnPropertiesRowCellClickbtnRemoveLink != null)
                        {
                            OnPropertiesRowCellClickbtnRemoveLink(sender, eRTC);
                        }
                    }
                    PropertyInfo propertyInfo = Action.GetType().GetProperty(sPropName);
                    if (propertyInfo == null)
                    {
                        return;
                    }
                    RTCVariableType rtcvar = (RTCVariableType)propertyInfo.GetValue(Action, null);
                    if (e.Column == this.Value)
                    {
                        if ((rtcvar.rtcSystem && rtcvar.rtcReadOnly) ||
                            rtcvar.rtcState == EPropertyState.Output ||
                            rtcvar.rtcReadOnly ||
                            rtcvar.rtcIDRef != Guid.Empty)
                        {
                            return;
                        }
                        //TextBox textBox = new TextBox();

                        //// Đặt vị trí và kích thước của TextBox dựa trên vị trí của cell
                        ////Rectangle cellBounds = tlvAction.getce
                        ////textBox.Location = new Point(cellBounds.Left + treeListView1.Left, cellBounds.Top + treeListView1.Top);
                        //textBox.Size = new Size(50, 100);

                        //// Thêm TextBox vào TreeListView
                        //tlvAction.Controls.Add(textBox);

                        //// Focus vào TextBox để người dùng có thể nhập liệu
                        //textBox.Focus();
                        switch (propertyInfo.PropertyType.Name)
                        {
                            case nameof(SString):
                                {
                                    this.Value.PutValue(e.Item.RowObject, ((SString)rtcvar).rtcValue);
                                    break;
                                }
                            case nameof(SBool):
                                {
                                    this.Value.PutValue(e.Item.RowObject, ((SBool)rtcvar).rtcValue);

                                    //tlvAction.UpdateObject(e.Item.RowObject);
                                    //tlvAction.RefreshObject(e.Item.RowObject);
                                    break;
                                }
                            case nameof(SInt):
                                {
                                    this.Value.PutValue(e.Item.RowObject, ((SInt)rtcvar).rtcValue);

                                    //tlvAction.UpdateObject(e.Item.RowObject);
                                    //tlvAction.RefreshObject(e.Item.RowObject);
                                    break;
                                }
                            case nameof(SDouble):
                                {
                                    this.Value.PutValue(e.Item.RowObject, ((SDouble)rtcvar).rtcValue);
                                    //tlvAction.UpdateObject(e.Item.RowObject);

                                    break;
                                }
                            case nameof(SListDouble):
                                {
                                    this.Value.PutValue(e.Item.RowObject, GlobFuncs.ListDouble2Str(((SListDouble)rtcvar).rtcValue));
                                    //tlvAction.UpdateObject(e.Item.RowObject);

                                    break;
                                }
                            case nameof(SListString):
                                {
                                    this.Value.PutValue(e.Item.RowObject, GlobFuncs.ListString2StrWithType(((SListString)rtcvar).rtcValue));
                                    //tlvAction.UpdateObject(e.Item.RowObject);

                                    break;
                                }
                            case nameof(SListObject):
                                {
                                    this.Value.PutValue(e.Item.RowObject, GlobFuncs.ListObject2StrWithType(((SListObject)rtcvar).rtcValue));
                                    //tlvAction.RefreshObject(e.Item.RowObject);
                                    break;
                                }
                        }

                    }
                    tlvAction.UpdateObject(e.Item.RowObject);
                    tlvAction.RefreshObject(e.Item.RowObject);
                    //else
                    //{
                    //    if (OnPropertiesRowCellClickbtnLink != null)
                    //}    


                }
                else if (Action.ActionType == EActionTypes.Branch ||
                    Action.ActionType == EActionTypes.Switch ||
                    (Action.ActionType == EActionTypes.BranchItem && Action.DataItems != null && Action.DataItems.Count > 0))
                {
                    RTCE_StringBuilderItem_RowCellClickEventArgs eRTC = new RTCE_StringBuilderItem_RowCellClickEventArgs();
                    SStringBuilderItem rsbItem = null;
                    switch (Action.ActionType)
                    {
                        case EActionTypes.Branch:
                            {
                                rsbItem = Action.MyExpression.Operands.Find(x =>
                                x.Name == (string)this.PropName.GetValue(e.Model));
                                break;
                            }
                        case EActionTypes.Switch:
                            {
                                rsbItem = Action.MyExpression.Operands.Find(x =>
                                x.Name == (string)this.PropName.GetValue(e.Model));
                                break;
                            }
                        case EActionTypes.BranchItem:
                            {
                                rsbItem = Action.DataItems.Find(x =>
                                x.Name == (string)this.PropName.GetValue(e.Model));
                                break;
                            }
                    }
                    if (rsbItem == null)
                    {
                        return;
                    }

                    eRTC.Action = Action;
                    eRTC.Node = (MyPropertiesItem)e.Model;
                    eRTC.Base = this;
                    eRTC.SBItem = rsbItem;
                    eRTC.cActionName = this.PropName;
                    eRTC.CEnable = this.Enable;
                    eRTC.CValue = this.Value;
                    eRTC.CIDRef = this.IDref;
                    eRTC.treeList = tlvAction;
                    if (e.Column == this.btnLink)
                    {
                        if (OnStringBuiderDetail_BtnLinkClickEvent != null)
                        {
                            OnStringBuiderDetail_BtnLinkClickEvent(this, eRTC);
                        }
                    }
                    if (e.Column == this.btnRemoveLink)
                    {
                        if (OnStringBuiderDetail_BtnRemoveLinkClickEvent != null)
                        {
                            OnStringBuiderDetail_BtnRemoveLinkClickEvent(this, eRTC);
                        }
                    }


                }
            }
            finally
            {
                GlobFuncs.EndControlUpdate(tlvAction);

            }

        }

        private void ViewDataItemList(MyPropertiesItem Node)
        {
            if (Node == null) return;
            if (Node.child != null && Node.child.Count > 0)
            {
                Node.child.Clear();
                tlvAction.RefreshObject(Node);
                return;
            }
            EPropertyState eNodeState = GlobFuncs.GetNodeState(Node, this.State);
            SStringBuilderItem dataItem = null;
            PropertyInfo propertyInfo = null;
            bool isView = false;
            switch (eNodeState)
            {
                case EPropertyState.Operand:
                    if (Action.DataItems != null)
                        dataItem = Action.DataItems.FirstOrDefault(x =>
                            x.Name == this.PropName.GetValue(Node).ToString());
                    if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                        dataItem = Action.MyExpression.Operands.FirstOrDefault(x =>
                            x.Name == this.PropName.GetValue(Node).ToString());
                    break;
                case EPropertyState.DataItemParent:
                    {
                        if (tlvAction.GetParent(Node) != null)
                        {
                            if (Action.DataItems != null)
                                dataItem = Action.DataItems.FirstOrDefault(x =>
                                    x.Name == this.PropName.GetValue((tlvAction.GetParent(Node))).ToString());
                            if (dataItem == null && Action.MyExpression != null && Action.MyExpression.Operands != null)
                                dataItem = Action.MyExpression.Operands.FirstOrDefault(x =>
                                    x.Name == this.PropName.GetValue((tlvAction.GetParent(Node))).ToString());
                            if (dataItem == null)
                            {
                                propertyInfo = Action.GetType().GetProperty(this.PropName.GetValue((tlvAction.GetParent(Node))).ToString());
                                if (propertyInfo != null)
                                {
                                    RTCVariableType rtcvar = (RTCVariableType)propertyInfo.GetValue(Action, null);
                                    int iIndex = int.Parse(this.PropName.GetValue(Node).ToString().Replace("[", "")
                                        .Replace("]", "")) - 1;
                                    dataItem = rtcvar.DataItems[iIndex];
                                    propertyInfo = null;
                                }
                            }
                        }
                        break;
                    }
                case EPropertyState.DataItemParentView:
                    {
                        if (tlvAction.GetParent(Node) != null)
                        {
                            if (Action.DataItems != null)
                                dataItem = Action.DataItems.FirstOrDefault(x =>
                                    x.Name == this.PropName.GetValue(tlvAction.GetParent(Node)).ToString());
                            if (dataItem == null && Action.MyExpression != null && Action.MyExpression.Operands != null)
                                dataItem = Action.MyExpression.Operands.FirstOrDefault(x =>
                                    x.Name == this.PropName.GetValue(tlvAction.GetParent(Node)).ToString());
                            if (dataItem == null)
                            {
                                propertyInfo = Action.GetType().GetProperty(this.PropName.GetValue(tlvAction.GetParent(Node)).ToString());
                                if (propertyInfo != null)
                                {
                                    RTCVariableType rtcvar = (RTCVariableType)propertyInfo.GetValue(Action, null);
                                    int iIndex = int.Parse(this.PropName.GetValue(Node).ToString().Replace("[", "")
                                        .Replace("]", "")) - 1;
                                    dataItem = rtcvar.DataItems[iIndex];
                                    propertyInfo = null;
                                }
                            }
                        }
                        isView = true;
                        break;
                    }
                default:
                    propertyInfo = Action.GetType().GetProperty(this.PropName.GetValue(Node).ToString());
                    isView = (eNodeState != EPropertyState.Input);
                    break;
            }

            if (dataItem != null)
                ViewDataItemList_DataItem(dataItem, Node, isView);
            else if (propertyInfo != null)
                ViewDataItemList_PropertyInfo(propertyInfo, Node, isView);
        }

        private void ViewDataItemList_PropertyInfo(PropertyInfo propertyInfo, MyPropertiesItem ParentNode, bool isView)
        {
            RTCVariableType rtcvar = (RTCVariableType)propertyInfo.GetValue(Action, null);
            int iCount = 1;

            if (rtcvar.DataItems != null && rtcvar.DataItems.Count > 0)
            {
                foreach (var dataItem1 in rtcvar.DataItems)
                {
                    var eNodeState = EPropertyState.None;
                    if (isView)
                        eNodeState = dataItem1.DataItems == null || dataItem1.DataItems.Count <= 1
                            ? EPropertyState.DataItemView
                            : EPropertyState.DataItemParentView;
                    else
                        eNodeState = dataItem1.DataItems == null || dataItem1.DataItems.Count <= 1
                            ? EPropertyState.DataItem
                            : EPropertyState.DataItemParent;

                    MyPropertiesItem dataNode = new MyPropertiesItem();
                    dataNode.IDref = Guid.Empty;
                    dataNode.NodeType = ENodeTypes.None;
                    dataNode.Enable = true;
                    dataNode.DisplayOutput = false;
                    dataNode.Name = "[" + iCount.ToString() + "]";
                    dataNode.Type = dataItem1.GetItemType();
                    dataNode.Value = dataItem1.ValueView;
                    dataNode.RefIndex = "";
                    dataNode.State = eNodeState;
                    dataNode.ReadOnly = false;
                    dataNode.DisplayOutputValueInHistory = false;
                    dataNode.System = true;
                    dataNode.IsCanLink = false;
                    ParentNode.child.Add(dataNode);

                    tlvAction.RefreshObject(ParentNode);
                    tlvAction.EndUpdate();
                    tlvAction.Refresh();
                    tlvAction.CanExpandGetter = x => (x as MyPropertiesItem).child.Count > 0;
                    tlvAction.ChildrenGetter = x => (x as MyPropertiesItem).child;
                    tlvAction.ExpandAll();
                }
            }
        }

        private void ViewDataItemList_DataItem(SStringBuilderItem dataItem, MyPropertiesItem ParentNode, bool isView)
        {
            try
            {
                int iCount = 1;
                if (dataItem.DataItems != null && dataItem.DataItems.Count > 0)
                {
                    foreach (var dataItem1 in dataItem.DataItems)
                    {
                        var eNodeState = EPropertyState.None;
                        if (isView)
                            eNodeState = dataItem1.DataItems == null || dataItem1.DataItems.Count <= 1
                                ? EPropertyState.DataItemView
                                : EPropertyState.DataItemParentView;
                        else
                            eNodeState = dataItem1.DataItems == null || dataItem1.DataItems.Count <= 1
                                ? EPropertyState.DataItem
                                : EPropertyState.DataItemParent;

                        MyPropertiesItem dataNode = new MyPropertiesItem();
                        dataNode.IDref = Guid.Empty;
                        dataNode.NodeType = ENodeTypes.None;
                        dataNode.Enable = true;
                        dataNode.DisplayOutput = false;
                        dataNode.Name = "[" + iCount.ToString() + "]";
                        dataNode.Type = dataItem1.GetItemType();
                        dataNode.Value = dataItem1.ValueView;
                        dataNode.RefIndex = "";
                        dataNode.State = eNodeState;
                        dataNode.ReadOnly = false;
                        dataNode.DisplayOutputValueInHistory = false;
                        dataNode.System = true;
                        dataNode.IsCanLink = false;
                        ParentNode.child.Add(dataNode);
                        iCount += 1;
                        tlvAction.RefreshObject(ParentNode);
                        tlvAction.EndUpdate();
                        tlvAction.Refresh();
                        tlvAction.CanExpandGetter = x => (x as MyPropertiesItem).child.Count > 0;
                        tlvAction.ChildrenGetter = x => (x as MyPropertiesItem).child;
                        tlvAction.ExpandAll();
                    }
                }

            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }


        private void tlvAction_FormatCell(object sender, FormatCellEventArgs e)
        {

            if (Action == null || e.Column == null || this.NodeType == null)
                return;
            
            if(e.Column == colImage)
            {
                if (((MyPropertiesItem)e.Model).State == EPropertyState.Input)
                {

                    e.SubItem.ImageSelector = Selecticon.Images.IndexOfKey("Input");
                }
                else if (((MyPropertiesItem)e.Model).State == EPropertyState.Output)
                {

                    e.SubItem.ImageSelector = Selecticon.Images.IndexOfKey("Output");
                }
                else if (((MyPropertiesItem)e.Model).System)
                {
                    e.SubItem.ImageSelector = Selecticon.Images.IndexOfKey("System");
                }
                e.SubItem.Text = "";
            }    
            //if (e.Column != this.btnLink
            //    && e.Column != this.btnViewList
            //    && e.Column != this.Value
            //    && e.Column != this.DisplayOutput
            //    && e.Column != this.Type
            //    && e.Column != this.colRefIndex
            //    && e.Column != ReadOnly
            //    && e.Column != btnRemoveLink)
            //    return;
            if ((ENodeTypes)this.NodeType.GetValue(e.Model) == ENodeTypes.Property &&
                ((EPropertyState)this.State.GetValue(e.Model) != EPropertyState.Operand))
            {
                if ((bool)this.Enable.GetValue(e.Model)) //&& !(bool)e.Node.GetValue(this.IsSystem)
                {
                    RTCVariableType rtcValue = (RTCVariableType)Action.GetType()
                        .GetProperty((string)this.PropName.GetValue(e.Model))?.GetValue(Action, null);

                    if (rtcValue != null && rtcValue.rtcIDRef != Guid.Empty)
                        e.SubItem.ForeColor = Color.Blue;
                    else
                        e.SubItem.ForeColor = Color.Black;

                    if (rtcValue.rtcIsHighLight)
                    {
                        e.SubItem.BackColor = Color.Yellow;
                     
                    }
                    else if (rtcValue.rtcSaveToFileConfig)
                    {
                        e.SubItem.BackColor = Color.Cyan;
                    }
                }
                else
                    e.SubItem.ForeColor = Color.Silver;
            }
            if (GlobFuncs.GetNodePropertyType((MyPropertiesItem)e.Model, this.NodeType) == ENodeTypes.PropertyDetail)
            {

            }
            else
            {
                //if(!Action.IsShowOnlyHighLightProperties.rtcValue)
                //    foreach(MyPropertiesItem item in ()e.RowObject)
                // if(e.Column == this.btnViewList)
                if (GlobFuncs.GetPropertyNodeState((MyPropertiesItem)e.Item.RowObject, State) == EPropertyState.Output)
                {
                    if (e.Column != DisplayOutput)
                    {
                        e.ListView.CreateControl();
                        if (e.Column == this.ReadOnly) this.ReadOnly.PutValue(e.Item.RowObject, null);

                    }
                }
                else if (e.Column == this.btnLink)
                {
                    if (!(bool)this.colIsCanLink.GetValue(e.Item.RowObject))
                    {
                        e.SubItem.Text = "";
                    }
                    else
                    {
                        e.SubItem.ImageSelector = Selecticon.Images.IndexOfKey("LinkProperty");

                        //e.Item.ima = 1;
                        //e.Item. = false;
                    }

                }
                else if (e.Column == this.DisplayOutput)
                {
                    e.SubItem.Text = "";
                }
                //}
                else if (e.Column == this.btnRemoveLink)
                {
                    CustumNodeCell_Column_btnRemoveLink(e);
                }
                else if (e.Column == this.btnViewList)
                {
                    CustumNodeCell_Column_btnViewList(e);
                }
                if (GlobVar.IsLinkMode || GlobVar.IsLinkStringBuilderItemMode)
                {
                    if (tlvAction.GetParent(e.Model) != null)
                    {
                        if (((MyPropertiesItem)(tlvAction.GetParent(e.Model))).Enable) //&& !(bool)e.Node.ParentNode.GetValue(this.IsSystem)
                        {
                            e.SubItem.ForeColor = Color.Black;
                        }
                        else
                        {
                            e.SubItem.ForeColor = Color.Silver;
                        }
                    }
                    else
                    {
                        if (((MyPropertiesItem)(e.Model)).Enable) //&& !(bool)e.Node.ParentNode.GetValue(this.IsSystem)
                        {
                            e.SubItem.ForeColor = Color.Black;
                        }
                        else
                        {
                            e.SubItem.ForeColor = Color.Silver;
                        }
                    }
                }
                else
                {
                    e.SubItem.ForeColor = Color.Black;
                }
            }
        }

        private void CustumNodeCell_Column_btnViewList(FormatCellEventArgs e)
        {
            SStringBuilderItem dataItem = null;
            PropertyInfo propertyInfo = null;
            EPropertyState eNodeState = (EPropertyState)this.State.GetValue(e.Item.RowObject);
            switch (eNodeState)
            {
                case EPropertyState.Operand:
                    {
                        dataItem = null;
                        if (Action.DataItems != null)
                            dataItem = Action.DataItems.FirstOrDefault(x =>
                                x.Name == this.PropName.GetValue(e.Item.RowObject).ToString());
                        if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                            dataItem = Action.MyExpression.Operands.FirstOrDefault(x =>
                                x.Name == this.PropName.GetValue(e.Item.RowObject).ToString());

                        if (dataItem == null || dataItem.DataItems == null || dataItem.DataItems.Count <= 0)
                            e.SubItem.Text = "";
                        else
                        {
                            ImageDecoration image = new ImageDecoration(Selecticon.Images[8], 255, System.Drawing.ContentAlignment.MiddleCenter);
                            e.SubItem.Decoration = image;
                        }

                        break;
                    }
                case EPropertyState.DataItemParent:
                    {
                        dataItem = null;
                        if (tlvAction.GetParent(e.Item.RowObject) == null)
                            e.SubItem.Text = "";

                        else
                        {
                            if (Action.DataItems != null)
                                dataItem = Action.DataItems.FirstOrDefault(x =>
                                    x.Name == this.PropName.GetValue(tlvAction.GetParent(e.Item.RowObject)).ToString());
                            if (dataItem == null && Action.MyExpression != null && Action.MyExpression.Operands != null)
                                dataItem = Action.MyExpression.Operands.FirstOrDefault(x =>
                                    x.Name == this.PropName.GetValue(tlvAction.GetParent(e.Item.RowObject)).ToString());

                            if (dataItem == null)
                            {
                                propertyInfo = Action.GetType().GetProperty(this.PropName.GetValue(tlvAction.GetParent(e.Item.RowObject)).ToString());
                                if (propertyInfo != null)
                                {
                                    RTCVariableType value = (RTCVariableType)propertyInfo.GetValue(Action, null);
                                    if (value.DataItems != null && value.DataItems.Count > 0)
                                    {
                                        ImageDecoration image = new ImageDecoration(Selecticon.Images[8], 255, System.Drawing.ContentAlignment.MiddleCenter);
                                        e.SubItem.Decoration = image;
                                    }
                                    else
                                        e.SubItem.Text = "";
                                }
                                else
                                    e.SubItem.Text = "";
                            }
                            else
                            {
                                if (dataItem.DataItems == null || dataItem.DataItems.Count <= 0)
                                    e.SubItem.Text = "";
                                else
                                {
                                    ImageDecoration image = new ImageDecoration(Selecticon.Images[8], 255, System.Drawing.ContentAlignment.MiddleCenter);
                                    e.SubItem.Decoration = image;
                                }
                            }
                        }

                        break;
                    }
                case EPropertyState.DataItemParentView:
                    {
                        dataItem = null;
                        if (tlvAction.GetParent(e.Item.RowObject) == null)
                            e.SubItem.Text = "";

                        else
                        {
                            if (Action.DataItems != null)
                                dataItem = Action.DataItems.FirstOrDefault(x =>
                                x.Name == this.PropName.GetValue(tlvAction.GetParent(e.Item.RowObject)).ToString());

                            if (dataItem == null && Action.MyExpression != null && Action.MyExpression.Operands != null)
                                dataItem = Action.MyExpression.Operands.FirstOrDefault(x =>
                                x.Name == this.PropName.GetValue(tlvAction.GetParent(e.Item.RowObject)).ToString());

                            if (dataItem == null)
                            {
                                propertyInfo = Action.GetType().GetProperty(this.PropName.GetValue(tlvAction.GetParent(e.Item.RowObject)).ToString());
                                if (propertyInfo != null)
                                {
                                    RTCVariableType value = (RTCVariableType)propertyInfo.GetValue(Action, null);
                                    if (value.DataItems != null && value.DataItems.Count > 0)
                                    {
                                        ImageDecoration image = new ImageDecoration(Selecticon.Images[8], 255, System.Drawing.ContentAlignment.MiddleCenter);
                                        e.SubItem.Decoration = image;
                                    }
                                    else
                                        e.SubItem.Text = "";
                                }
                                else
                                    e.SubItem.Text = "";
                            }
                            else
                            {
                                if (dataItem.DataItems == null || dataItem.DataItems.Count <= 0)
                                    e.SubItem.Text = "";
                                else
                                {
                                    ImageDecoration image = new ImageDecoration(Selecticon.Images[8], 255, System.Drawing.ContentAlignment.MiddleCenter);
                                    e.SubItem.Decoration = image;
                                }
                            }
                        }
                        break;
                    }
                case EPropertyState.DataItem:
                    {
                        e.SubItem.Text = "";
                        break;
                    }
                case EPropertyState.DataItemView:
                    {
                        e.SubItem.Text = "";
                        break;
                    }
                default:
                    {
                        propertyInfo = Action.GetType().GetProperty(this.PropName.GetValue(e.Item.RowObject).ToString());
                        if (!(propertyInfo is null))
                        {
                            RTCVariableType value = (RTCVariableType)propertyInfo.GetValue(Action, null);
                            if (value.DataItems != null && value.DataItems.Count > 0)
                            {
                                ImageDecoration image = new ImageDecoration(Selecticon.Images[8], 255, System.Drawing.ContentAlignment.MiddleCenter);
                                e.SubItem.Decoration = image;
                            }
                            else
                                e.SubItem.Text = "";
                        }
                        break;
                    }
            }
        }

        private void CustumNodeCell_Column_btnRemoveLink(FormatCellEventArgs e)
        {
            EPropertyState eNodeState = GlobFuncs.GetNodeState((MyPropertiesItem)e.Model, this.State);
            switch (eNodeState)
            {
                case EPropertyState.DataItemParentView:
                    e.SubItem.Text = "";
                    break;
                case EPropertyState.DataItemView:
                    e.SubItem.Text = "";
                    break;
                default:
                    ImageDecoration image = new ImageDecoration(Selecticon.Images[6], 255, System.Drawing.ContentAlignment.MiddleCenter);
                    if (Guid.Parse(this.IDref.GetValue(e.Model).ToString()) != Guid.Empty)
                        e.SubItem.Decoration = image;
                    break;
            }
        }

        private void tlvAction_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            try
            {
                GlobFuncs.BeginControlUpdate(tlvAction);
                //tlvAction.SuspendLayout();
                //tlvAction.BeginUpdate();
                if (e.Control.GetType() == typeof(TextBox))
                {

                    object FocusNode = tlvAction.FocusedObject;
                    if (FocusNode == null || FocusingCol != this.Value)
                    {
                        e.Cancel = true;
                        //tlvAction.SuspendLayout();
                        //tlvAction.BeginUpdate();
                        return;
                    }
                    //tlvAction.FinishCellEdit();
                    TextBox textBox = (TextBox)e.Control;
                    string sValue = textBox.Text;
                    string oldName = Action?.Name.rtcValue;
                    if (sValue.ToLower() == cStrings.NoValueWithBracket.ToLower())
                    {
                        e.Cancel = true;
                        //tlvAction.SuspendLayout();
                        //tlvAction.BeginUpdate();
                        return;
                    }
                    string sPropName = this.PropName.GetValue(FocusNode).ToString();
                    EPropertyState eNodeState = GlobFuncs.GetPropertyNodeState((MyPropertiesItem)FocusNode, this.State);
                    if (eNodeState == EPropertyState.Operand)
                    {
                        string operandName = this.Value.GetValue(FocusNode).ToString();
                        SStringBuilderItem operandItem = null;
                        switch (Action.ActionType)
                        {
                            case EActionTypes.BranchItem:
                                if (Action.DataItems != null)
                                    operandItem = Action.DataItems.Find(x => x.Name == sPropName);
                                break;
                            default:
                                {
                                    if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                                        operandItem = Action.MyExpression.Operands.Find(x => x.Name == sPropName);
                                    break;
                                }
                        }
                        if (operandItem == null) return;
                        string[] arrValues = new string[] { };
                        if (sValue.Contains(cChars.Comma))
                        {
                            arrValues = sValue.Split(cChars.Comma);
                        }
                        else
                        {
                            arrValues = sValue.Split(cChars.Semicolon);
                        }
                        double dValue = 0;
                        int iValue = 0;
                        bool bValue = false;
                        operandItem.ListDoubleValue = new List<double>() { };
                        operandItem.ListStringValue = new List<string>() { };
                        switch (operandItem.ValueStyle)
                        {
                            case EHTupleStyle.Boolean:
                                if (bool.TryParse(sValue, out bValue))
                                    operandItem.ListStringValue = new List<string>() { bValue.ToString() };
                                else
                                    operandItem.ListStringValue = new List<string>() { cStrings.@False };
                                break;
                            case EHTupleStyle.BooleanList:
                                foreach (var arrValue in arrValues)
                                    if (bool.TryParse(arrValue, out bValue))
                                        operandItem.ListStringValue.Add(bValue.ToString());
                                    else
                                        operandItem.ListStringValue.Add(cStrings.@False);
                                break;
                            case EHTupleStyle.Integer:
                                if (int.TryParse(sValue, out iValue))
                                    operandItem.ListDoubleValue = new List<double>() { iValue };
                                else
                                    operandItem.ListDoubleValue = new List<double>() { 0 };
                                break;
                            case EHTupleStyle.IntegerList:
                                foreach (var arrValue in arrValues)
                                    if (int.TryParse(arrValue, out iValue))
                                        operandItem.ListDoubleValue = new List<double>() { iValue };
                                break;
                            case EHTupleStyle.String:
                                operandItem.ListStringValue = new List<string>() { sValue };
                                break;
                            case EHTupleStyle.StringList:
                                foreach (var arrValue in arrValues)
                                    operandItem.ListStringValue.Add(arrValue);
                                break;
                            case EHTupleStyle.Real:
                                if (double.TryParse(sValue, out dValue))
                                    operandItem.ListDoubleValue = new List<double>() { dValue };
                                else
                                    operandItem.ListDoubleValue = new List<double>() { 0 };
                                break;
                            case EHTupleStyle.RealList:
                                foreach (var arrValue in arrValues)
                                    if (double.TryParse(arrValue, out dValue))
                                        operandItem.ListDoubleValue.Add(dValue);
                                break;

                        }
                        e.NewValue = operandItem.ValueView.ToString();
                        //this.Value.PutValue(FocusNode, operandItem.ValueView.ToString());


                        if (Action.AutoRun)
                            RunAction();


                    }
                    else
                    {
                        RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(sPropName).GetValue(Action, null);
                        PropertyInfo propertyInfo_Value = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                        string sErr = string.Empty;
                        string[] sValues = { };
                        sValues = GlobFuncs.GetValuesFromValueView(textBox.Text);
                        SListDouble sListDouble = new SListDouble();
                        SListString sListString = new SListString();
                        SListObject sListObject = new SListObject();
                        switch (propertyInfo.GetType().Name)
                        {
                            case nameof(SListString):
                                sListString = (SListString)propertyInfo;
                                switch (propertyInfo.ValueStyle)
                                {
                                    case EHTupleStyle.StringRange:
                                        {

                                            ValidateNodeValue_StringRange(FocusNode, sValues, sListString);
                                            e.NewValue = sListString.rtcValueView;
                                            break;
                                        }

                                    case EHTupleStyle.ValueList:
                                        {
                                            ValidateNodeValue_ValueList(FocusNode, sValues, sListString);
                                            e.NewValue = sListString.rtcValueView;

                                            break;
                                        }
                                    case EHTupleStyle.None:
                                        {
                                            ValidateNodeValue_ValueList(FocusNode, sValues, sListString);
                                            e.NewValue = sListString.rtcValueView;

                                            break;
                                        }
                                }
                                propertyInfo_Value.SetValue(propertyInfo, sListString.rtcValue);
                                break;
                            case nameof(SListObject):
                                sListObject = (SListObject)propertyInfo;
                                propertyInfo_Value.SetValue(propertyInfo, sListObject.rtcValue);

                                break;
                            case nameof(SListDouble):
                                
                                sValues = GlobFuncs.GetValuesFromValueView(textBox.Text.ToString());
                                sListDouble = (SListDouble)propertyInfo;

                                //sListString = (SListString)propertyInfo;
                                switch (propertyInfo.ValueStyle)
                                {
                                    case EHTupleStyle.RangeMinMax:
                                        if (!ValidateNodeValue_RangeMinMax(FocusNode, sValues, sListDouble))
                                        {
                                            e.Cancel = true; ;
                                            return;
                                        }
                                        else
                                            e.NewValue = sListDouble.rtcValueView;
                                        
                                        break;
                                    case EHTupleStyle.RangeMinMaxLimit:
                                        if (!ValidateNodeValue_RangeMinMaxLimit(FocusNode, sValues, sListDouble))
                                        {
                                            e.Cancel = true; ;
                                            return;
                                        }
                                        else
                                            e.NewValue = sListDouble.rtcValueView;


                                        break;
                                    case EHTupleStyle.PointList:
                                        if (!ValidateNodeValue_Point(FocusNode, sValues, sListDouble))
                                        {
                                            e.Cancel = true; ;
                                            return;
                                        }
                                        else
                                            e.NewValue = sListDouble.rtcValueView;

                                        break;
                                    case EHTupleStyle.Point:
                                        if (!ValidateNodeValue_Point(FocusNode, sValues, sListDouble))
                                        {
                                            e.Cancel = true; ;
                                            return;
                                        }
                                        else
                                            e.NewValue = sListDouble.rtcValueView;

                                        break;
                                    case EHTupleStyle.Rectangle:
                                        if (!ValidateNodeValue_Rectang(FocusNode, sValues, sListDouble))
                                        {
                                            e.Cancel = true; ;
                                            return;
                                        }
                                        else
                                            e.NewValue = sListDouble.rtcValueView;

                                        break;
                                    case EHTupleStyle.Origin:
                                        if (!ValidateNodeValue_Origin(FocusNode, sValues, sListDouble))
                                        {
                                            e.Cancel = true; ;
                                            return;
                                        }
                                        else
                                            e.NewValue = sListDouble.rtcValueView;

                                        break;
                                    case EHTupleStyle.Line:
                                        if (!ValidateNodeValue_Line(FocusNode, sValues, sListDouble))
                                        {
                                            e.Cancel = true; ;
                                            return;
                                        }
                                        else
                                            e.NewValue = sListDouble.rtcValueView;

                                        break;
                                    case EHTupleStyle.None:
                                        if (!ValidateNodeValue_ValueList(FocusNode, sValues, sListDouble))
                                        {
                                            e.Cancel = true; ;
                                            return;
                                        }
                                        else
                                            e.NewValue = sListDouble.rtcValueView;
                                        break;

                                    //case EHTupleStyle.ValueList:
                                    //    if (!ValidateNodeValue_Rectang(FocusNode, sValues, sListDouble)) return;
                                    //    break;

                                }
                                propertyInfo_Value.SetValue(propertyInfo, sListDouble.rtcValue);
                                break;
                            case nameof(SString):
                                {
                                    propertyInfo_Value.SetValue(propertyInfo, textBox.Text.ToString());
                                    this.Value.PutValue(FocusNode, textBox.Text.ToString());
                                    {
                                        if ((Action.ActionType == EActionTypes.Branch || Action.ActionType == EActionTypes.Switch) && sPropName == nameof(Action.Expression))
                                        {
                                            tlvAction.ClearObjects();
                                            Action.RunExpresion();
                                            this.Value.PutValue(FocusNode, Action.MyExpression.Expression);
                                            propertyInfo_Value.SetValue(propertyInfo, Action.MyExpression.Expression);
                                        }
                                    }
                                }
                                break;
                            case nameof(SInt):
                                propertyInfo_Value.SetValue(propertyInfo, Lib.ToInt(textBox.Text));
                                this.Value.PutValue (FocusNode, Lib.ToInt(textBox.ToString()));
                                break;
                            case nameof(SDouble):
                                propertyInfo_Value.SetValue(propertyInfo, Lib.ToInt(textBox.Text));
                                this.Value.PutValue(FocusNode, Lib.ToInt(textBox.ToString()));
                                break;
                        }
                        if (Action.AutoRun)
                            RunAction();

                    }

                }
                else if (e.Control.GetType() == typeof(ComboBox))
                {
                    if (e.Column == Value)
                    {
                        ComboBox Combobox = (ComboBox)e.Control;
                        if (Combobox.SelectedItem == null)
                        {
                            //tlvAction.SuspendLayout();
                            //tlvAction.BeginUpdate();
                            return;
                        }
                        e.NewValue = Combobox.SelectedItem;
                        Combobox.SelectedIndexChanged += ComboBoxSelectedIndexChanged;

                    }
                    else if (e.Column == Type)
                    {
                        ComboBox Combobox = (ComboBox)e.Control;


                        if (Combobox.SelectedItem == null)
                        {
                            //tlvAction.BeginUpdate();
                            return;
                        }
                        e.NewValue = Combobox.SelectedItem;
                        Combobox.SelectedIndexChanged += cbOperandTypeIndexChanged;
                    }
                }

            }
            
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                GlobFuncs.EndControlUpdate(tlvAction);

            }
        }

        private void ScrollableGeneral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            RunAction();
        }

        public void ViewActionLinkSummary()
        {
            if (Action == null) return;
            tl_LinkSummary.ClearObjects();
            LinkSummary Node = new LinkSummary();
            LinkSummary PropNode = new LinkSummary();

            Node.NodeType = ENodeTypes.Group;
            Node.PropName = GlobFuncs.BuildRefString_Property(GlobVar.GroupActions, Action, null);
            Node.Ref = "";
            var PropertyHaveRefs = Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(Action, null)) != null &&
            ((RTCVariableType)x.GetValue(Action, null)).rtcActive && ((RTCVariableType)x.GetValue(Action, null)).rtcIDRef != Guid.Empty);

            foreach (PropertyInfo nProperty in PropertyHaveRefs)
            {
                RTCVariableType rtcvar = (RTCVariableType)Action.GetType().GetProperty(nProperty.Name).GetValue(Action, null);
                if (rtcvar == null || !rtcvar.rtcActive || rtcvar.rtcIDRef == Guid.Empty) { continue; };
                PropNode = new LinkSummary();
                PropNode.NodeType = ENodeTypes.Property;
                PropNode.PropName = nProperty.Name;
                PropNode.Ref = rtcvar.rtcRef;
                Node.child.Add(PropNode);
            }
            var PropertyParentRefs = Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(Action, null)) != null &&
             ((RTCVariableType)x.GetValue(Action, null)).rtcActive && ((RTCVariableType)x.GetValue(Action, null)).rtcIsParent);
            foreach (PropertyInfo nProperty in PropertyParentRefs)
            {
                foreach (cAction item in GlobVar.GroupActions.Actions.Values)
                {
                    if (item.ID != Action.ID)
                    {
                        PropertyParentRefs = item.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(item, null)) != null &&
                            ((RTCVariableType)x.GetValue(item, null)).rtcActive && ((RTCVariableType)x.GetValue(item, null)).rtcIDRef == Action.ID);

                        foreach (PropertyInfo nPropertyc in PropertyParentRefs)
                        {
                            RTCVariableType rtcvar = (RTCVariableType)Action.GetType().GetProperty(nProperty.Name).GetValue(Action, null);
                            if (rtcvar == null || !rtcvar.rtcActive || rtcvar.rtcIDRef == Guid.Empty) { continue; };
                            PropNode = new LinkSummary();
                            PropNode.NodeType = ENodeTypes.Property;
                            PropNode.PropName = nProperty.Name;
                            PropNode.Ref = GlobFuncs.BuildRefString_Property(GlobVar.GroupActions, item, nPropertyc);
                            Node.child.Add(PropNode);
                        }

                    }
                }
            }
            List<SStringBuilderItem> dataItems = null;
            if (Action.DataItems != null && Action.DataItems.Count > 0)
                dataItems = Action.DataItems;
            else if (Action.MyExpression?.Operands?.Count > 0)
                dataItems = Action.MyExpression.Operands;
            if (dataItems != null)
            {
                // Lấy ra danh sách biến có link đến thằng khác
                var dataItemHaveRefs = dataItems.Where(x => x.RefID != Guid.Empty).ToList();
                foreach (SStringBuilderItem dataItem in dataItemHaveRefs)
                {
                    PropNode = new LinkSummary();
                    PropNode.NodeType = ENodeTypes.Property;
                    PropNode.PropName = dataItem.Name;
                    PropNode.Ref = dataItem.Ref;
                    Node.child.Add(PropNode);
                }
                foreach (SStringBuilderItem dataItem in dataItems)
                {
                    PropertyParentRefs = Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(Action, null)) != null &&
                    ((RTCVariableType)x.GetValue(Action, null)).rtcIDRef == Action.ID);
                }
            }
            tl_LinkSummary.AddObject(Node);
            tl_LinkSummary.Refresh();
            tl_LinkSummary.CanExpandGetter = x => (x as LinkSummary).child.Count > 0;
            tl_LinkSummary.ChildrenGetter = x => (x as LinkSummary).child;
            tl_LinkSummary.ExpandAll();
        }
        public bool IsTabRoiActive()
        {
            return PageSetup.SelectedTab == ROI;
        }
        public int GetPageActionSettingTabIndexDefault()
        {
            switch (Action.ActionType)
            {
                case EActionTypes.Branch:
                case EActionTypes.BranchItem:
                case EActionTypes.DataInstance:
                case EActionTypes.Switch:
                case EActionTypes.StopProgram:
                case EActionTypes.Wait:
                case EActionTypes.LiveCam:
                case EActionTypes.StopLiveCam:
                case EActionTypes.CycleTimeStart:
                case EActionTypes.CycleTimeStop:
                case EActionTypes.Stop:
                case EActionTypes.SaveProject:
                case EActionTypes.SystemInfo:
                case EActionTypes.HookKeyboard:
                case EActionTypes.Ping:
                case EActionTypes.Script:
                case EActionTypes.CustomProcedure:
                    return 1;
                default:
                    return 0;
            }
        }

        private void tl_LinkSummary_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Column == LinkSummary_Image)
            {
                if (((LinkSummary)e.Model).NodeType != ENodeTypes.Group)
                {
                    var PropertyHaveRefs = Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(Action, null)) != null &&
                     ((RTCVariableType)x.GetValue(Action, null)).rtcActive && ((RTCVariableType)x.GetValue(Action, null)).rtcIDRef != Guid.Empty);
                    foreach (PropertyInfo nProperty in PropertyHaveRefs)
                    {
                        RTCVariableType rtcvar = (RTCVariableType)Action.GetType().GetProperty(nProperty.Name).GetValue(Action, null);
                        if (rtcvar == null || !rtcvar.rtcActive || rtcvar.rtcIDRef == Guid.Empty) { continue; }
                        ImageDecoration image = new ImageDecoration(imlLinkSummary.Images[1], 255, System.Drawing.ContentAlignment.MiddleCenter);
                        e.SubItem.Decoration = image;
                    }
                    var PropertyParentRefs = Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(Action, null)) != null &&
                         ((RTCVariableType)x.GetValue(Action, null)).rtcActive && ((RTCVariableType)x.GetValue(Action, null)).rtcIsParent);
                    foreach (PropertyInfo nProperty in PropertyParentRefs)
                    {
                        foreach (cAction item in GlobVar.GroupActions.Actions.Values)
                        {
                            if (item.ID != Action.ID)
                            {
                                PropertyParentRefs = item.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(item, null)) != null &&
                                    ((RTCVariableType)x.GetValue(item, null)).rtcActive && ((RTCVariableType)x.GetValue(item, null)).rtcIDRef == Action.ID);

                                foreach (PropertyInfo nPropertyc in PropertyParentRefs)
                                {
                                    RTCVariableType rtcvar = (RTCVariableType)Action.GetType().GetProperty(nProperty.Name).GetValue(Action, null);
                                    if (rtcvar == null || !rtcvar.rtcActive || rtcvar.rtcIDRef == Guid.Empty) { continue; };
                                    ImageDecoration image = new ImageDecoration(imlLinkSummary.Images[0], 255, System.Drawing.ContentAlignment.MiddleCenter);
                                    e.SubItem.Decoration = image;
                                }

                            }
                        }
                    }
                    List<SStringBuilderItem> dataItems = null;
                    if (Action.DataItems != null && Action.DataItems.Count > 0)
                        dataItems = Action.DataItems;
                    else if (Action.MyExpression?.Operands?.Count > 0)
                        dataItems = Action.MyExpression.Operands;
                    if (dataItems != null)
                    {
                        // Lấy ra danh sách biến có link đến thằng khác
                        var dataItemHaveRefs = dataItems.Where(x => x.RefID != Guid.Empty).ToList();
                        foreach (SStringBuilderItem dataItem in dataItemHaveRefs)
                        {
                            ImageDecoration image = new ImageDecoration(imlLinkSummary.Images[1], 255, System.Drawing.ContentAlignment.MiddleCenter);
                            e.SubItem.Decoration = image;
                        }

                    }

                }
            }
        }
        private void popSaveToFileConfig_Click(object sender, EventArgs e)
        {
            string propName = ((MyPropertiesItem)tlvAction.FocusedObject).Name;
            if (Action == null)
                return;
            RTCVariableType rtcVariableType = (RTCVariableType)Action.GetType().GetProperty(propName)?.GetValue(Action, null);
            if (rtcVariableType == null)
                return;
            if (popSaveToFileConfig.Text == cStrings.SaveToFileConfig)
                rtcVariableType.rtcSaveToFileConfig = true;
            else
                rtcVariableType.rtcSaveToFileConfig = false;
            if (Action.IsMultiROI)
            {
                var roiProperties = Action.ROIProperties.Values.Where(x => x.Selected).FirstOrDefault();
                if (roiProperties == null)
                    return;
                RTCVariableType propertyInfo_ROI = (RTCVariableType)roiProperties.GetType().GetProperty(propName).GetValue(roiProperties, null);
                if (propertyInfo_ROI == null)
                    return;
                propertyInfo_ROI.rtcSaveToFileConfig = rtcVariableType.rtcSaveToFileConfig;
            }
            Action.MyGroup.Actions[Action.ID] = Action;
            tlvAction.Refresh();

        }

        private void popViewValue1_Click(object sender, EventArgs e)
        {
            if (Action == null)
                return;
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Tag != null)
            {
                string propertyName = GlobFuncs.Object2Str(item.Tag).Trim();
                if (string.IsNullOrEmpty(propertyName))
                    return;
                GlobFuncs.ViewValueInForm(Action, propertyName);
            }
        }

        private void popSetHighLight_Click(object sender, EventArgs e)
        {
            if (tlvAction.FocusedObject == null)
                return;
            EPropertyState ePropertyState = GlobFuncs.GetNodeState((MyPropertiesItem)tlvAction.FocusedObject, this.State);
            if (ePropertyState == EPropertyState.DataItemParentView ||
                ePropertyState == EPropertyState.DataItemView)
                return;
            string propName = ((MyPropertiesItem)tlvAction.FocusedObject).Name;

            SStringBuilderItem currentDataItem = null;
            RTCVariableType currentVariableType = (RTCVariableType)this.Action.GetType().GetProperty(propName)?.GetValue(this.Action, null);
            object currentValue = null;
            if (currentVariableType != null)
                currentVariableType.rtcIsHighLight = true;
            else
            {
                if (this.Action.MyExpression != null && this.Action.MyExpression.Operands != null)
                    currentDataItem = this.Action.MyExpression.Operands.FirstOrDefault(x => x.Name == propName);
                else if (this.Action.DataItems != null)
                    currentDataItem = this.Action.DataItems.FirstOrDefault(x => x.Name == propName);
                if (currentDataItem != null)
                    currentDataItem.IsHightLight = true;

            }
        }

        private void popRemoveHighLight_Click(object sender, EventArgs e)
        {
            if (tlvAction.FocusedObject == null)
                return;
            EPropertyState ePropertyState = ((MyPropertiesItem)tlvAction.FocusedObject).State;
            if (ePropertyState == EPropertyState.DataItemParentView ||
                ePropertyState == EPropertyState.DataItemView)
                return;
            string propName = this.PropName.GetValue(tlvAction.FocusedObject).ToString();
            SStringBuilderItem currentDataItem = null;
            RTCVariableType currentVariableType = (RTCVariableType)this.Action.GetType().GetProperty(propName)?.GetValue(this.Action, null);
            if (currentVariableType != null)
                currentVariableType.rtcIsHighLight = false;
            else
            {
                if (this.Action.MyExpression != null && this.Action.MyExpression.Operands != null)
                    currentDataItem = this.Action.MyExpression.Operands.FirstOrDefault(x => x.Name == propName);
                else if (this.Action.DataItems != null)
                    currentDataItem = this.Action.DataItems.FirstOrDefault(x => x.Name == propName);
                if (currentDataItem != null)
                    currentDataItem.IsHightLight = false;
            }
        }

        private void popRemoveAllHighLight_Click(object sender, EventArgs e)
        {
            var properties = Action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(Action, null)) != null &&
                                                                        ((RTCVariableType)x.GetValue(Action, null)).rtcIsHighLight);
            foreach (PropertyInfo nProperty in properties)
            {
                RTCVariableType rtcvar = (RTCVariableType)Action.GetType().GetProperty(nProperty.Name).GetValue(Action, null);
                rtcvar.rtcIsHighLight = false;
            }
        }
        private void popTheEntireClick(object sender, EventArgs e)
        {
            ToolStripItem toolStripItem = (ToolStripItem)sender;
            string propName = toolStripItem.Tag.ToString();
            var listToolsHavePropertyName =
                GlobVar.GroupActions.Actions.Values.Where(x => x.GetType().GetProperty(propName).GetValue(x) != null).ToList();
            if (listToolsHavePropertyName.Any())
                foreach (var action in listToolsHavePropertyName)
                    if (action.ID != Action.ID)
                    {
                        RTCVariableType propertyInfo = (RTCVariableType)action.GetType().GetProperty(propName).GetValue(action, null);
                        PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
                        RTCVariableType propertyInfoSrc = (RTCVariableType)Action.GetType().GetProperty(propName).GetValue(Action, null);
                        PropertyInfo propertyInfoSrcValue = propertyInfoSrc.GetType().GetProperty(cPropertyName.rtcValue);
                        propertyInfoValue.SetValue(propertyInfo, propertyInfoSrcValue.GetValue(propertyInfoSrc));

                        if (action.ViewInfo != null)
                            ((ucBaseActionDetail)action.ViewInfo).UpdatePropertyValueToAllControls(propName);
                    }
        }
        private void popTheActionClick(object sender, EventArgs e)
        {
            ToolStripItem toolStripItem = (ToolStripItem)sender;
            string[] tags = toolStripItem.Tag.ToString().Split(cStrings.SepGDung);
            Guid id = Guid.Parse(tags[0]);
            string propName = tags[1];
            cAction action = GlobVar.GroupActions.Actions[id];
            RTCVariableType propertyInfo = (RTCVariableType)action.GetType().GetProperty(propName).GetValue(action, null);
            PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);
            RTCVariableType propertyInfoSrc = (RTCVariableType)Action.GetType().GetProperty(propName).GetValue(Action, null);
            PropertyInfo propertyInfoSrcValue = propertyInfoSrc.GetType().GetProperty(cPropertyName.rtcValue);
            propertyInfoValue.SetValue(propertyInfo, propertyInfoSrcValue.GetValue(propertyInfoSrc));

            if (action.ViewInfo != null)
                ((ucBaseActionDetail)action.ViewInfo).UpdatePropertyValueToAllControls(propName);
        }

        private void popApplyValueToAllTools_Click(object sender, EventArgs e)
        {
            try
            {
                if (tlvAction.FocusedObject == null)
                    return;
                EPropertyState ePropertyState = ((MyPropertiesItem)tlvAction.FocusedObject).State;
                if (ePropertyState == EPropertyState.DataItemParentView ||
                    ePropertyState == EPropertyState.DataItemView)
                    return;
                string propName = this.PropName.GetValue(tlvAction.FocusedObject).ToString();


                SStringBuilderItem currentDataItem = null;
                RTCVariableType currentVariableType = (RTCVariableType)this.Action.GetType().GetProperty(propName)?.GetValue(this.Action, null);
                object currentValue = null;
                if (currentVariableType != null)
                {
                    PropertyInfo currentPropertyInfoValue =
                        currentVariableType.GetType().GetProperty(cPropertyName.rtcValue);
                    currentValue = currentPropertyInfoValue.GetValue(currentVariableType, null);
                }
                else
                {
                    if (this.Action.MyExpression != null && this.Action.MyExpression.Operands != null)
                        currentDataItem = this.Action.MyExpression.Operands.FirstOrDefault(x => x.Name == propName);
                    else if (this.Action.DataItems != null)
                        currentDataItem = this.Action.DataItems.FirstOrDefault(x => x.Name == propName);
                }

                if (currentVariableType == null && currentDataItem == null)
                    return;

                if (cMessageBox.Question_YesNo(cMessageContent.Que_ApplyPropertyValueToAllTools) == DialogResult.No)
                    return;
                GlobFuncs.ShowWaitForm(cStrings.Applying);

                foreach (cAction action in GlobVar.GroupActions.Actions.Values)
                    if (action.ID != this.Action.ID)
                    {
                        SStringBuilderItem dataItem = null;
                        RTCVariableType rtcvar = (RTCVariableType)action.GetType().GetProperty(propName)?.GetValue(action, null);
                        if (rtcvar != null)
                        {
                            PropertyInfo propertyInfoValue =
                                rtcvar.GetType().GetProperty(cPropertyName.rtcValue);
                            if (currentVariableType != null)
                                propertyInfoValue.SetValue(rtcvar, currentValue);
                            else if (currentDataItem != null)
                                if(propertyInfoValue.GetType() == typeof(List<string>))
                                propertyInfoValue.SetValue(rtcvar, currentDataItem.ListStringValue);
                                else
                                    propertyInfoValue.SetValue(rtcvar, currentDataItem.ListDoubleValue);

                        }
                        else
                        {
                            if (action.MyExpression != null && action.MyExpression.Operands != null)
                                dataItem = action.MyExpression.Operands.FirstOrDefault(x => x.Name == propName);
                            else if (action.DataItems != null)
                                dataItem = action.DataItems.FirstOrDefault(x => x.Name == propName);
                            if (dataItem != null)
                                if (currentVariableType != null)
                                {
                                    dataItem.ListDoubleValue = GlobFuncs.Ve2Double(currentValue);
                                    dataItem.ListStringValue = new List<string>() { GlobFuncs.Object2Str(currentValue) };
                                }
                                else if (currentDataItem != null)
                                {
                                    dataItem.ListStringValue = currentDataItem.ListStringValue;
                                    dataItem.ListDoubleValue = currentDataItem.ListDoubleValue;
                                }

                        }
                        if (action.ViewInfo != null && action.ActionType != EActionTypes.MainAction)
                            //((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                            ((ucBaseActionDetail)action.ViewInfo).UpdatePropertyValueToAllControls(propName);
                    }
            }
            finally
            {
                GlobFuncs.CloseWaitForm();
            }

        }

        private void popClearAllSaveConfig_Click(object sender, EventArgs e)
        {
            if (Action == null) return;
            var listPropertiesSaveConfig = Action.GetType().GetProperties()
                .Where(x => ((RTCVariableType)x.GetValue(Action, null)) != null && ((RTCVariableType)x.GetValue(Action, null)).rtcSaveToFileConfig).ToList();
            if (!listPropertiesSaveConfig.Any())
                return;

            foreach (PropertyInfo propertyInfo in listPropertiesSaveConfig)
            {
                string propName = propertyInfo.Name;
                RTCVariableType rtcVariableType = (RTCVariableType)Action.GetType().GetProperty(propName)?.GetValue(Action, null);
                if (rtcVariableType == null)
                    continue;
                rtcVariableType.rtcSaveToFileConfig = false;

                // Kiểm tra xem action này có phải là 1 tool dạng multiROI hay không
                if (Action.IsMultiROI)
                {
                    // Lấy ROI hiện tại
                    var roiProperties = Action.ROIProperties.Values.Where(x => x.Selected).FirstOrDefault();
                    if (roiProperties == null)
                        continue;
                    // Set thông tin lưu config cho thuộc tính của ROI này
                    RTCVariableType propertyInfo_ROI = (RTCVariableType)roiProperties.GetType().GetProperty(propName).GetValue(roiProperties, null);
                    if (propertyInfo_ROI == null)
                        continue;
                    propertyInfo_ROI.rtcSaveToFileConfig = rtcVariableType.rtcSaveToFileConfig;
                }
                tlvAction.Refresh();
                Action.MyGroup.Actions[Action.ID] = Action;
            }
        }

        private void tlvAction_SubItemChecking(object sender, SubItemCheckingEventArgs e)
        {
            GlobFuncs.BeginControlUpdate(tlvAction);
            tlvAction.SuspendLayout();
            MyPropertiesItem FocusNode = (MyPropertiesItem)e.RowObject;
            if (FocusNode == null || (e.Column != this.DisplayOutput && e.Column != this.DisplayOutputValueHistory && e.Column != this.ReadOnly)) return;

            string sPropName = FocusNode.Name;
            RTCVariableType propertyInfo = (RTCVariableType)Action.GetType().GetProperty(sPropName).GetValue(Action, null);
            if (e.Column == this.DisplayOutput)
            {
                PropertyInfo propertyInfo_Value = propertyInfo.GetType().GetProperty(cPropertyName.rtcDisplay);
                propertyInfo_Value.SetValue(propertyInfo, e.NewValue == CheckState.Checked ? true : false);
            }
            else if (e.Column == this.DisplayOutputValueHistory)
            {
                PropertyInfo propertyInfo_Value = propertyInfo.GetType().GetProperty(cPropertyName.rtcDisplayValueInHistory);
                propertyInfo_Value.SetValue(propertyInfo, e.NewValue == CheckState.Checked ? true : false);
            }
            else
            {
                PropertyInfo propertyInfo_Value = propertyInfo.GetType().GetProperty(cPropertyName.rtcReadOnly);
                propertyInfo_Value.SetValue(propertyInfo, e.NewValue == CheckState.Checked ? true : false);

               // UpdateReadonlyToControls(sPropName);
            }
            tlvAction.ResumeLayout();
            GlobFuncs.EndControlUpdate(tlvAction);
        }

        private void tlvAction_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int test = e.Column;
        }

        private void chkIsShowOnlyHighLightProperties_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents || Action == null)
                return;
            Action.IsShowOnlyHighLightProperties.rtcValue = chkIsShowOnlyHighLightProperties.Checked;
            tlvAction.BeginUpdate();
            ShowOnlyHighLight();
            tlvAction.EndUpdate();
        }
        private void ShowOnlyHighLight()
        {
            if (Action.IsShowOnlyHighLightProperties.rtcValue)
            {
                tlvAction.UseFiltering = true;

                tlvAction.ModelFilter = new ModelFilter(model =>
                {
                    var item = model as MyPropertiesItem; // Thay YourModelClass bằng lớp đối tượng của bạn
                    RTCVariableType rtcValue = (RTCVariableType)Action.GetType()
                                      .GetProperty((string)this.PropName.GetValue(model))?.GetValue(Action, null);
                    return rtcValue.rtcIsHighLight;
                });
            }
            else
            {
                tlvAction.ModelFilter = null;
            }    
        }

        private void btnSEP2_Click(object sender, EventArgs e)
        {

        }

        private void btnMethod_Click(object sender, EventArgs e)
        {

        }
    }
}


