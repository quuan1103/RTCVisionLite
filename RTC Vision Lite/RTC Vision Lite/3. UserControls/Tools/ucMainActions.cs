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
using RTCConst;
using RTCHikSdk;
using System.Runtime.InteropServices;
using Basler.Pylon;
using RTCDahuaSdk;
using RTC_Vision_Lite.Properties;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;
using RTC_Vision_Lite.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public delegate void MainActionForceSave();
    public partial class ucMainActions : UserControl
    {
        #region VARIALLES
        int FadeOutSpeed = 5;
        Bitmap bitmap;
        Image Input_Image;
        public event MainActionForceSave OnMainActionForceSave;
        public cAction Action { get; set; }

        private bool _LockEvents = false;
        private bool _isPreviewData = false;
        private bool _ViewedValueComputer = false;
        private bool _FirstTimeDetect = true;
        private Dictionary<string, string> NameDevices;
        private bool IsCheckedCamera;
        public bool ViewedValueComputer
        {
            get { return _ViewedValueComputer; }
            set
            {
                _ViewedValueComputer = value;
            }
        }

        private bool _ViewedValueCAM = false;
        public bool ViewedValueCAM
        {
            get { return _ViewedValueCAM; }
            set
            {
                _ViewedValueCAM = value;
            }
        }

        private cSourceImageSettings _cSourceImageSettings;

        public cSourceImageSettings SourceImageSettings
        {
            get { return _cSourceImageSettings; }
            set
            {
                _cSourceImageSettings = value;
                _LockEvents = true;
               // btnComputer_Click(null,null);
                PreviewData();
                _LockEvents = false;
            }
        }
        private bool _IsClickComputer = false;
        private bool _IsClickCamera = false;
        #endregion


        public ucMainActions()
        {
            InitializeComponent();
            //lblSetDefault.ForeColor = Color.White;
            //lblLive_Run.ForeColor = Color.White;
            //lblLive_Stop.ForeColor = Color.White;
            //lblSnap.ForeColor = Color.White;
            //lblTriggerBySoftware.ForeColor = Color.White;
            //lblOpenImageFolder.ForeColor = Color.White;
            //chkAutoSaveImage.ForeColor = Color.White;

            lblLive_Stop.Visible = false;
            lblLive_Run.Visible = false;
            lblSnap.Visible = false;
            lblTriggerBySoftware.Visible = false;
            chkAutoSaveImage.Visible = false;
            lblOpenImageFolder.Visible = false;
            _LockEvents = true;
            ListFiles.AutoGenerateColumns = false;
            PreviewData();
            GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected = false;

            PageSetting.Appearance = TabAppearance.FlatButtons;
            PageSetting.ItemSize = new Size(0, 1);
            PageSetting.SizeMode = TabSizeMode.Fixed;

            _LockEvents = false;
        }

      
        private void btnComputer_Click(object sender, EventArgs e)
        {
            if (_LockEvents || SourceImageSettings == null)
                return;
            if (SourceImageSettings.CameraSettings.IsConnected)
                DisconnectCamera();
            SourceImageSettings.ComputerSettings.CurrentImgIndex = -1;
            GetCurrentImgIndex(ListFiles.CurrentRow);
            SourceImageSettings.ImageSourceType = EImageSourceTypes.Computer;
            _LockEvents = true;
            pageMain.SelectedIndex = 0;
            ucCameraSettings1.GroupActions = null;

            lblLive_Stop.Visible = false;
            lblLive_Run.Visible = false;
            lblSnap.Visible = false;
            lblTriggerBySoftware.Visible = false;
            chkAutoSaveImage.Visible = false;
            lblOpenImageFolder.Visible = false;
            GlobVar.fHsmartWindow?.UpdateLiveControlsVisible();
            PageSetting.SelectedTab = tabComputer;
            PreviewData_DefaultImageSourceType();
            EnabelorDisableAllCameraControlByConnect();
            IsCheckedCamera = false;
            _LockEvents = false;

        }
        private void btnCamera_Click(object sender, EventArgs e)
        {
            if (_LockEvents || SourceImageSettings == null)
                return;
            GlobFuncs.BeginControlUpdate(this);
            IsCheckedCamera = true;
            pageMain.SelectedIndex = 0;
            //ucCameraSettings1.GroupActions = null;
            SourceImageSettings.ImageSourceType = EImageSourceTypes.Camera;
            _LockEvents = true;
            PageSetting.SelectedIndex = 1;
            _LockEvents = false;
            GlobVar.fHsmartWindow?.UpdateLiveControlsVisible();
            PreviewData_DefaultImageSourceType();
            EnabelorDisableAllCameraControlByConnect();
            GlobFuncs.EndControlUpdate(this);

        }
        private void EnabelorDisableAllCameraControlByConnect()
        {
            bool enabled = SourceImageSettings.CameraSettings?.IsConnected ?? false;
            bool enabledCamInfo = enabled && SourceImageSettings.CameraSettings?.PropCompare?.Count > 0;
            lblLive_Run.Visible = false;
            lblLive_Stop.Visible = enabled;
            lblSnap.Visible = enabled;
            lblTriggerBySoftware.Visible = enabled;
            chkAutoSaveImage.Visible = enabled;
            lblOpenImageFolder.Visible = enabled;

            btnDetectInterfaces.Enabled = true;
            cbSdkMode.Enabled = true;
            cbDevices.Enabled = true;
            cbInterfaces.Enabled = cbSdkMode.SelectedIndex == 0 || cbSdkMode.SelectedIndex == 1;
            btnAddNewDeviceManual.Enabled = true;
            btnConnect.Visible = !enabled;
            btnDisconnect.Visible = enabled;
            //ucCameraSettings1.GroupActions = null;

        }

        private void PreviewData_DefaultImageSourceType()
        {
            switch (SourceImageSettings.DefaultImageSourceType)
            {
                case EImageSourceTypes.Computer:
                    {
                        btnComputer.Image = RTC_Vision_Lite.Properties.Resources.DefaultSticker5;
                        btnCamera.Image = null;
                        btnCamera.TextAlign = ContentAlignment.MiddleCenter;
                        btnComputer.ImageAlign = ContentAlignment.MiddleLeft;
                        break;
                     }
                case EImageSourceTypes.Camera:
                    {
                        btnCamera.Image = RTC_Vision_Lite.Properties.Resources.DefaultSticker5;
                        btnComputer.Image = null;
                        btnComputer.TextAlign = ContentAlignment.MiddleCenter;
                        btnCamera.ImageAlign = ContentAlignment.MiddleLeft ;
                        break;
                    }
                default:
                    {
                        btnCamera.Image = null;
                        btnComputer.Image = null;
                        btnComputer.TextAlign = ContentAlignment.MiddleCenter;
                        btnCamera.TextAlign = ContentAlignment.MiddleCenter;

                        break;
                    }
            }
            if (PageSetting.SelectedTab == tabCamera)
                lblSetDefault.Enabled = SourceImageSettings.DefaultImageSourceType != EImageSourceTypes.Camera;
            else
                lblSetDefault.Enabled = SourceImageSettings.DefaultImageSourceType != EImageSourceTypes.Computer;
            lblSetDefault.Text = !lblSetDefault.Enabled ? cStrings.RemoveDefault : cStrings.SetDefault;
            lblSetDefault.Enabled = true;
            lblSetDefault.Refresh();
        }
        private bool _isRun;
        public bool IsRun
        {
            get => _isRun;
            set
            {
                _isRun = value;
                //bool isCanEditTool = cUser.C
                GlobFuncs.EnableControl(btnComputer, !_isRun);
                GlobFuncs.EnableControl(btnCamera, !_isRun);
                GlobFuncs.EnableControl(pageMain, !_isRun);
                GlobFuncs.EnableControl(tpImageSeting, !_isRun);
                //GlobFuncs.EnableControl(tp, !_isRun);




            }
        }

        public void UpdateLiveControlsVisible()
        {
            if (GlobVar.GroupActions != null && GlobVar.GroupActions.SourceImageSettings != null)
            {
                if (lblLive_Run.InvokeRequired)
                {
                    lblLive_Run.Invoke((MethodInvoker)delegate
                        {
                            lblLive_Run.Visible = !GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsLive && GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                            lblLive_Stop.Visible = GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsLive && GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                            lblSnap.Visible = GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                        });
                }
                else
                {
                    lblLive_Run.Visible = !GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsLive && GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                    lblLive_Stop.Visible = GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsLive && GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                    lblSnap.Visible = GlobVar.GroupActions.SourceImageSettings.CameraSettings.IsConnected;
                }
            }
            else
            {
                if (lblLive_Run.InvokeRequired)
                {
                    lblLive_Run.Invoke((MethodInvoker)delegate
                    {
                        lblLive_Run.Visible = false;
                        lblLive_Run.Visible = false;
                        lblSnap.Visible = false;
                    });
                    }
                else
                {
                    lblLive_Run.Visible = false;
                    lblLive_Run.Visible = false;
                    lblSnap.Visible = false;
                }
            }    
        }
        

        public void DisconnectCamera(bool isWithFormEffect = false)
        {
            GlobVar.GroupActions.DisconnectCamera();
            if (isWithFormEffect)
            
            {
                btnConnect.Visible = false;
                btnDisconnect.Visible = false;
                lblNoticeConnect.RunTrue(cStrings.Disconnected);
                FadeTimer.Enabled = true;
            }
            EnabelorDisableAllCameraControlByConnect();
            if (GlobVar.GroupActions != null && GlobVar.GroupActions.frmHsmartWindow != null)
                GlobVar.GroupActions.frmHsmartWindow.UpdateLiveControlsVisible();
        }

        public void PreviewData()
        {
            try
            {
                //GlobVar.GroupActions.DisconnectCamera();
                GlobVar.LockEvents = true;
                //if (_isPreviewData)
                //    return;
             
                    
                if (SourceImageSettings == null)
                    return;
                LoadListTemplateToCombo();

                cbSdkMode.SelectedIndex = (int)SourceImageSettings.CameraSettings.SdkMode;
                cbSdkMode_SelectedValueChanged(cbSdkMode, null);

                chkEnableSnap.Checked = SourceImageSettings.IsEnableSnap;
                chkIsTriggerBySoftware.Checked = SourceImageSettings.IsTriggerBySoftware;
                chkAutoSetDefaultCamSettingWhenConnect.Checked = SourceImageSettings.CameraSettings.isAutoSetDefaultCAMSettingWhenConnect;


                switch (SourceImageSettings.Trigger.TriggerMode)
                {
                    case ETriggerMode.IO:
                        break;
                    case ETriggerMode.TCPIP:
                        break;
                    case ETriggerMode.COM:
                        break;
                    case ETriggerMode.PLCMitsu:
                        break;
                    default:
                        break;
                }
                cbInterfaces.Text = SourceImageSettings.CameraSettings.InterfaceName;
                cbDevices.Text = SourceImageSettings.CameraSettings.DeviceName;
                
                switch (SourceImageSettings.ImageSourceType)
                {
                    case EImageSourceTypes.Computer:
                        if (!_ViewedValueComputer)
                        {
                            if (SourceImageSettings.ComputerSettings.IsFolder == true)
                            {
                                radChooseFile.Checked = false;
                                radChooseFolder.Checked = true;
                                PreviewData_ViewListFiles();
                                ShowHideControlTabComputer();
                                PageSetting.SelectedTab = tabComputer;
                                _ViewedValueComputer = true;
                            }
                            else
                            {
                                btnComputer_Click(null, null);
                                if (SourceImageSettings.ComputerSettings.IsFolder == true)
                                    radChooseFolder.Checked = true;
                                else

                                    radChooseFile.Checked = true;
                                PreviewData_ViewListFiles();
                                ShowHideControlTabComputer();
                                PageSetting.SelectedTab = tabComputer;
                                _ViewedValueComputer = true;
                            }
                        }
                        break;

                    case EImageSourceTypes.Camera:
                        if(!_ViewedValueCAM)
                        {
                            btnCamera_Click(null, null);
                            EnabelorDisableAllCameraControlByConnect();
                            ViewPropValue();
                            PageSetting.SelectedTab = tabCamera;

                            _ViewedValueCAM = true;
                        }
                        break;
                    default:
                        break;
                }
                chkAutoSaveImage.Checked = SourceImageSettings.CameraSettings.IsAutoSaveImage;
                if(GlobVar.GroupActions.MyCam != null)
                {
                    chkIsGetResultByRunningTool.Checked = GlobVar.GroupActions.MyCam.IsGetResultByRunningTool;
                    lblErrMessage.Text = string.Empty;
                    PreviewData_DefaultImageSourceType();
                    ShowDeviceInfo();
                    _isPreviewData = true;
                }    
                
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }

        private void ViewPropValue()
        {
            try
            {
                GlobVar.LockEvents = true;
                ucCameraSettings1.GroupActions = GlobVar.GroupActions; 
            }
            finally
            {
                GlobVar.LockEvents = false;
            }

        }

        private cModel model;
        private BindingList<cModel> _lstmodel = new BindingList<cModel>();
        #region CAMERA SETTINGS TEMPLATE
        public void LoadListTemplateToCombo()
        {
            cbTemplateSettingCam.Items.Clear();
            DataTable dataTable = Lib.GetDataTable("SELECT DISTINCT Name FROM CameraSettingTemplate ORDER BY Name",
                GlobVar.CurrentProject.FileName);
            if(dataTable !=null)
                foreach(DataRow row in dataTable.Rows)
                {
                    cbTemplateSettingCam.Items.Add(GlobFuncs.GetDataRowValue_String(row, cColName.Name));
                }    
        }
        #endregion
        public void PreviewData_ViewListFiles()
        {
            try
            {
                GlobVar.LockEvents = true;
                ListFiles.DataSource = null;
                _lstmodel = new BindingList<cModel>();
                model = new cModel();
                if (SourceImageSettings != null)
                {
                    int iSTT = 1;
                    //DataGridViewRow row = new DataGridViewRow();
                    int index = -1;
                    foreach (cImage item in SourceImageSettings.ComputerSettings.Images)
                    {
                        model = new cModel();
                        model.STT = iSTT;
                        model.FileName = item.FileName;
                        _lstmodel.Add(model);
                        if (iSTT - 1 == SourceImageSettings.ComputerSettings.CurrentImgIndex)
                            index = iSTT - 1;
                        iSTT += 1;
                    }
                    ListFiles.DataSource = _lstmodel;
                    if (index > -1)
                    {
                        ListFiles.Rows[index].Selected = true;
                        GetCurrentImgIndex(ListFiles.Rows[index]);
                    }
                    else if (ListFiles.Rows?.Count > 0)
                    {
                        ListFiles.Rows[ListFiles.Rows[0].Index].Selected = true;
                        SourceImageSettings.ComputerSettings.CurrentImgIndex = 0;
                        GetCurrentImgIndex(ListFiles.Rows[0]);
                    }
                    //var list = ListFiles.DataSource;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                GlobVar.LockEvents = false;
                //var list = ListFiles.DataSource;
            }
        }
       
        private void GetCurrentImgIndex(DataGridViewRow row)
        {
            lblErrMessage.Text = string.Empty;
            if (row == null) return;
            string filename = (string)row.Cells[1].Value;
            if (File.Exists(filename))
            {
                try
                {
                    Input_Image = Image.FromFile(filename);
                    bitmap = new Bitmap(Input_Image);
                    GlobVar.GroupActions.frmHsmartWindow.SmartWindow.Image = bitmap;
                    GlobVar.GroupActions.frmHsmartWindow.SmartWindow.FitImage = true;
                    GlobVar.GroupActions.frmHsmartWindow.FileName = filename;
                    GlobVar.GroupActions.Actions[GlobVar.GroupActions.IDMainAction].InputImage.rtcValue = bitmap;
                    int newIndex = SourceImageSettings.ComputerSettings.Images.FindIndex(x => x.FileName.ToLower() == filename.ToLower());
                    if (SourceImageSettings.ComputerSettings.CurrentImgIndex != newIndex)
                    {
                        GlobVar.GroupActions.DataChanged = true;
                        SourceImageSettings.ComputerSettings.CurrentImgIndex = newIndex;
                    }
                    GlobVar.GroupActions.frmHsmartWindow.SmartWindow.Image = bitmap;
                    //GlobFuncs.ResizeImage(GlobVar.GroupActions.frmHsmartWindow.SmartWindow);
                    GlobVar.GroupActions.SetImageToAllAction(bitmap);
                }
                catch (Exception ex)
                {
                    GlobFuncs.SaveErr(ex);
                    GlobVar.GroupActions.frmHsmartWindow.SmartWindow.Image = null;
                }
            }
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (OpenFileImage.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in OpenFileImage.FileNames)
                {
                    if (SourceImageSettings.ComputerSettings.Images.FirstOrDefault(x => x.FileName == item) != null)
                        continue;

                    cImage image = new cImage
                    {
                        FileName = item
                    };
                    SourceImageSettings.ComputerSettings.Images.Add(image);
                }
                PreviewData_ViewListFiles();
                ShowHideControlTabComputer();
            }
        }

        private void ShowHideControlTabComputer()
        {
            if(SourceImageSettings != null)
            {
                switch(SourceImageSettings.ImageSourceType)
                {
                    case EImageSourceTypes.Computer:
                        if(SourceImageSettings.ComputerSettings.IsFolder)
                        {
                            if (!txtPath.Visible && ListFiles.Top < txtPath.Bottom)
                            {
                                txtPath.Visible = true;
                                btnChooseFolder.Visible = true;
                            }
                            panSelectFiles.Visible = false;
                        }
                        else
                        {
                            if(txtPath.Visible || ListFiles.Top > txtPath.Top)
                            {
                                txtPath.Visible = false;
                                btnChooseFolder.Visible = false;
                            }
                            panSelectFiles.Visible = true;
                            btnSelectFiles.Visible = (radChooseFile.Checked == true);
                            btnRemoveAll.Enabled = ListFiles.Rows.Count > 0;
                            btnRemoveFile.Enabled = ListFiles.SelectedRows.Count > 0;
                        }
                        break;
                    case EImageSourceTypes.Camera:
                        break;
                    default:
                        break;
                }    
            }    
        }

        public Image TakePicture(bool _IsPreView = false)
        {
            Image _Image = GlobVar.GroupActions.SnapImage(false, _IsPreView);
            return _Image;
        }

        private void pageMain_Selected(object sender, TabControlEventArgs e)
        {
        }

       
        

        public void ShowMasterMode()
        {
            if (GlobVar.GroupActions.frmHsmartWindow != null)
                GlobVar.GroupActions.frmHsmartWindow.ShowMasterMode();
        }
        internal void ReviewImage()
        {
            if (SourceImageSettings != null)
                if (SourceImageSettings.ImageSourceType == EImageSourceTypes.Computer)
                    if (ListFiles.Rows?.Count > 0)
                        GetCurrentImgIndex(ListFiles.Rows[0]);
        }





  

        private void btnDetectInterfaces_Click(object sender, EventArgs e)
        {
            try
            {
                GlobFuncs.ShowWaitForm(cMessageContent.Nor_DetectInterfaces);
                _LockEvents = true;
                DetectInterfaces();
            }
            catch (Exception ex)
            {
                _FirstTimeDetect = false;
                _LockEvents = false;
            }
            finally
            {
                GlobFuncs.CloseWaitForm();
            }
        }
        #region CAMERA FUNCTIONS
        private void DetectInterfaces(bool withWaitForm = false)
        {
            if (withWaitForm)
                GlobFuncs.ShowWaitForm(cMessageContent.Nor_DetectInterfaces);
            try
            {
                if (SourceImageSettings == null) return;
                switch (cbSdkMode.SelectedIndex)
                {
                    case 0: //Hikrobot
                        {
                            cbDevices.Items.Clear();
                            MyHikCamera.MV_CC_DEVICE_INFO_LIST deviceInfoList = GlobFuncs.GetHikrobotDeviceInfoList();
                            if (deviceInfoList.nDeviceNum > 0)
                            {
                                // ch:在窗体列表中显示设备名 | en:Display device name in the form list
                                for (int i = 0; i < deviceInfoList.nDeviceNum; i++)
                                {
                                    MyHikCamera.MV_CC_DEVICE_INFO device = (MyHikCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(deviceInfoList.pDeviceInfo[i], typeof(MyHikCamera.MV_CC_DEVICE_INFO));
                                    if (device.nTLayerType == MyHikCamera.MV_GIGE_DEVICE)
                                    {
                                        MyHikCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyHikCamera.MV_GIGE_DEVICE_INFO)MyHikCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyHikCamera.MV_GIGE_DEVICE_INFO));

                                        if (gigeInfo.chUserDefinedName != "")
                                        {
                                            cbDevices.Items.Add("GEV: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")");
                                        }
                                        else
                                        {
                                            cbDevices.Items.Add("GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " " +
                                                "(" + gigeInfo.chSerialNumber + ")");
                                        }
                                    }
                                    else if (device.nTLayerType == MyHikCamera.MV_USB_DEVICE)
                                    {
                                        MyHikCamera.MV_USB3_DEVICE_INFO usbInfo = (MyHikCamera.MV_USB3_DEVICE_INFO)MyHikCamera.ByteToStruct(device.SpecialInfo.stUsb3VInfo, typeof(MyHikCamera.MV_USB3_DEVICE_INFO));
                                        if (usbInfo.chUserDefinedName != "")
                                        {
                                            cbDevices.Items.Add("U3V: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")");
                                        }
                                        else
                                        {
                                            cbDevices.Items.Add("U3V: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")");
                                        }
                                    }
                                }
                            }
                            break;
                           
                        }
                    case 1: // Hikrobot GenTL 
                        {
                            System.GC.Collect();
                            cbDevices.Items.Clear();
                            cbInterfaces.Items.Clear();
                            List<string> Interfacelist = GlobFuncs.GetHikrobotGenICamTLInterfaces();
                            foreach (string interfaceName in Interfacelist)
                                cbInterfaces.Items.Add(interfaceName);
                            break;
                        }
                    case 2: //Basler
                        {
                            cbDevices.Items.Clear();
                            Dictionary<string, ICameraInfo> foundCameraInfos = GlobFuncs.GetBaslerCameraInfos();
                            if (foundCameraInfos != null)
                                foreach (string CameraName in foundCameraInfos.Keys)
                                    cbDevices.Items.Add(CameraName);
                            break;
                        }
                    //case 3: //Dahua
                    //    {
                    //        cbDevices.Items.Clear();
                    //        List<IDeviceInfo> deviceInfos = MyDahuaCamera.GetListDeviceInfos();
                    //        if (deviceInfos != null) ;
                    //        foreach (IDeviceInfo deviceInfo in deviceInfos)
                    //            cbDevices.Items.Add(deviceInfo.Key);
                    //        break;
                    //    }
                }
                if(cbSdkMode.SelectedIndex == 1)
                {
                    if (SourceImageSettings.CameraSettings.InterfaceName != string.Empty &&
                        cbInterfaces.Items.IndexOf(SourceImageSettings.CameraSettings.InterfaceName) >= 0)
                        cbInterfaces.SelectedIndex = cbInterfaces.Items.IndexOf(SourceImageSettings.CameraSettings.InterfaceName);
                    else if (cbInterfaces.Items.Count > 0)
                        cbInterfaces.SelectedIndex = 0;

                    SourceImageSettings.CameraSettings.InterfaceName = cbInterfaces.Text;
                    _LockEvents = false;
                    cbInterfacesEditValueChanged();
                }
                else
                {
                    if (cbDevices.Items.Count < 0)
                        cbDevices.SelectedIndex = -1;
                    else if (cbDevices.Items.IndexOf(cbDevices.Text) > 0)
                        cbDevices.SelectedIndex = cbDevices.Items.IndexOf(cbDevices.Text);
                    else
                        cbDevices.SelectedIndex = -1;
                }
                _FirstTimeDetect = false;
            }
            finally
            {

                if (withWaitForm)
                    GlobFuncs.CloseWaitForm();
            }
           

        }
        private void DetectDevices_HikrobotGenTl()
        {
            System.GC.Collect();
            cbDevices.Items.Clear();
            cbDevices.Text = string.Empty;
            string interfaceName = Lib.ToString(cbInterfaces.Text);
            SourceImageSettings.CameraSettings.InterfaceName = interfaceName;
            MyHikCamera.MV_GENTL_DEV_INFO_LIST gentlDevInfoList = new MyHikCamera.MV_GENTL_DEV_INFO_LIST();
            MyHikCamera.MV_GENTL_IF_INFO stIFInfo = GlobFuncs.GetHikrobotGenICamTLInterfaceInfo(interfaceName);
            int nRet = MyHikCamera.MV_CC_EnumDevicesByGenTL_NET(ref stIFInfo, ref gentlDevInfoList);
            if (0 != nRet)
                for (int i = 0; i < gentlDevInfoList.nDeviceNum; i++)
                {
                    MyHikCamera.MV_GENTL_DEV_INFO device =
                        (MyHikCamera.MV_GENTL_DEV_INFO)Marshal.PtrToStructure(gentlDevInfoList.pDeviceInfo[i],
                        typeof(MyHikCamera.MV_GENTL_DEV_INFO));

                    if (device.chUserDefinedName != "")
                        cbDevices.Items.Add("Dev: " + device.chUserDefinedName + " (" +
                            device.chSerialNumber + ")");
                    else
                        cbDevices.Items.Add("Dev: " + device.chVendorName + " " + device.chModelName + " (" +
                            device.chSerialNumber + ")");
                }
            //Add danh sách các device thêm chủ động bằng tay
            if (SourceImageSettings.CameraSettings.ManualCameras != null)
                foreach (InterfaceCamera interfaceCamera in SourceImageSettings.CameraSettings.ManualCameras)
                    if (interfaceCamera.NameInterface == interfaceName)
                    {
                        cbDevices.Items.Add(interfaceCamera.NameDevice);
                        if (!NameDevices.ContainsKey(interfaceCamera.NameDevice))
                            NameDevices.Add(interfaceCamera.NameDevice, interfaceCamera.NameDevice);

                    }
            if (cbDevices.Items.Count > 0)
            {
                if (SourceImageSettings.CameraSettings.DeviceName != string.Empty &&
                    cbDevices.Items.IndexOf(SourceImageSettings.CameraSettings.DeviceName) >= 0)
                    cbDevices.SelectedIndex = cbDevices.Items.IndexOf(SourceImageSettings.CameraSettings.DeviceName);
                else
                    cbDevices.SelectedIndex = 0;
            }
        }
        public void ConnectCamera()
        {
            if(SourceImageSettings.CameraSettings.SdkMode != ESdkModes.Basler &&
               SourceImageSettings.CameraSettings.SdkMode != ESdkModes.Hikrobot &&
               SourceImageSettings.CameraSettings.SdkMode != ESdkModes.Dahua &&
               string.IsNullOrEmpty(cbInterfaces.Text.Trim()))
            {
                cMessageBox.Warning(RTC_Vision_Lite.Properties.Resources.NotChooseInterface);
                return;
            }    
            if(string.IsNullOrEmpty(cbDevices.Text.Trim()))
            {
                cMessageBox.Warning(RTC_Vision_Lite.Properties.Resources.NotChooseCamera);
                return;
            }
            try
            {
                GlobFuncs.ShowWaitForm(cStrings.ConnectingCamera);
                string errMessage = string.Empty;

                string deviceNameOrigin = SourceImageSettings.CameraSettings.DeviceNameOrigin;
                if (NameDevices != null
                    && NameDevices.ContainsKey(cbDevices.Text))
                    deviceNameOrigin = NameDevices[cbDevices.Text];
                if (GlobVar.GroupActions.ConnectCamera(cbInterfaces.Text, cbDevices.Text, deviceNameOrigin, ref errMessage))
                {
                   // lblNoticeConnect.RunTrue(Resources.Connected);
                    // GlobFuncs.ChangeWaitFormDescription(cStrings.LoadCameraSettings);


                    ucCameraSettings1.GroupActions = GlobVar.GroupActions;
                    btnConnect.Visible = false;
                    btnDisconnect.Visible = true;
                    lblNoticeConnect.RunTrue(cStrings.Connected);
                    FadeTimer.Enabled = true;
                    EnabelorDisableAllCameraControlByConnect();
                    btnDisconnect.Left = btnConnect.Left;
                    btnDisconnect.Top = btnConnect.Top;
                    btnDisconnect.BringToFront();
                    btnDetectInterfaces.Enabled = false;
                    cbInterfaces.Enabled = false;
                    cbSdkMode.Enabled = false;
                    cbDevices.Enabled = false;
                    btnAddNewDeviceManual.Enabled = false;
                }
                else
                {
                    btnConnect.Visible = false;
                    btnDisconnect.Visible = false;
                    lblNoticeConnect.RunFail(Resources.Connected);
                    FadeTimer.Enabled = true;
                    btnDetectInterfaces.Enabled = true;
                    cbSdkMode.Enabled = true;
                    cbDevices.Enabled = true;
                    cbInterfaces.Enabled = cbSdkMode.SelectedIndex == 0 || cbSdkMode.SelectedIndex == 1;
                    btnAddNewDeviceManual.Enabled = true;
                    GlobFuncs.CloseWaitForm();
                    if (!string.IsNullOrEmpty(errMessage))
                        cMessageBox.Error(errMessage);
                }
            }
            finally
            {
                GlobFuncs.CloseWaitForm();
            }
        }
        #endregion
        private void cbInterfacesEditValueChanged()
        {
            if (_LockEvents)
                return;
            cbDevices.Items.Clear();
            if (SourceImageSettings == null)
                return;
            switch (SourceImageSettings.CameraSettings.SdkMode)
            {
                case ESdkModes.HikrobotGenTL:
                    {
                        DetectDevices_HikrobotGenTl();
                        break;
                    }
            }
            if (cbDevices.Items.Count <= 0)
                cbDevices.SelectedIndex = -1;
            else if (cbDevices.Items.IndexOf(cbDevices.Text) > 0)
                cbDevices.SelectedIndex = cbDevices.Items.IndexOf(cbDevices.Text);
            else
                cbDevices.SelectedIndex = -1;

        }

      

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectCamera();
            btnTriggerBySoftware.Enabled = SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera &&
                                           SourceImageSettings.CameraSettings.IsConnected &&
                                           SourceImageSettings.IsTriggerBySoftware;
        }

        private void lblLive_Run_Click(object sender, EventArgs e)
        {
            if (SourceImageSettings != null && SourceImageSettings.CameraSettings.IsConnected)
            {
                GlobVar.GroupActions.SetLiveCamera(true);
                lblLive_Stop.Visible = SourceImageSettings.CameraSettings.IsConnected && SourceImageSettings.CameraSettings.IsLive;
                lblLive_Run.Visible = SourceImageSettings.CameraSettings.IsConnected && !SourceImageSettings.CameraSettings.IsLive;
                GlobVar.GroupActions.frmHsmartWindow.UpdateLiveControlsVisible();
            }
        }

        private void lblLive_Stop_Click(object sender, EventArgs e)
        {
            if(SourceImageSettings != null && SourceImageSettings.CameraSettings.IsConnected)
            {
                GlobVar.GroupActions.SetLiveCamera(false);
                lblLive_Stop.Visible = SourceImageSettings.CameraSettings.IsConnected && SourceImageSettings.CameraSettings.IsLive;
                lblLive_Run.Visible = SourceImageSettings.CameraSettings.IsConnected && !SourceImageSettings.CameraSettings.IsLive;
                GlobVar.GroupActions.frmHsmartWindow.UpdateLiveControlsVisible();
            }
        }

        private void lblSnap_Click(object sender, EventArgs e)
        {
            if (GlobVar.GroupActions.ConnectCamera())
                GlobVar.GroupActions.SnapImage(true, true);
                
        }

        private void cbSdkMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            DisconnectCamera();
            cbInterfaces.Enabled = cbInterfaces.SelectedIndex == 1;
            if(SourceImageSettings !=null)
            {
                SourceImageSettings.CameraSettings.SdkMode = (ESdkModes)cbSdkMode.SelectedIndex;
                ucCameraSettings1.GroupActions = null;
            }
            btnDetectInterfaces.PerformClick();
            if (cbDevices.Items.Count <= 0)
                cbDevices.SelectedIndex = -1;
            else if (SourceImageSettings != null)
            {
                cbDevices.SelectedIndex = cbDevices.Items.IndexOf(SourceImageSettings.CameraSettings.DeviceName) >= 0
                    ? cbDevices.Items.IndexOf(SourceImageSettings.CameraSettings.DeviceName)
                    : 0;
            }
            else if (cbDevices.Items.IndexOf(cbDevices.Text) >= 0)
                cbDevices.SelectedIndex = cbDevices.Items.IndexOf(cbDevices.Text);
            else
                cbDevices.SelectedIndex = 0;
            ShowDeviceInfo();
        }

        internal void ShowDeviceInfo()
        {
            GlobVar.GroupActions.GetDeviceInfo(out DeviceInfo deviceInfo);
            lblDeviceInfo.Visible = false;
            if(deviceInfo != null)
            {
                lblDeviceInfo.Visible = deviceInfo.IsExists;
                if (deviceInfo.IsExists)
                    lblDeviceInfo.Text =
                        $"Manufaturer: <b>{deviceInfo.Manufacturer}</b> - " +
                        $"Model: <b>{deviceInfo.ModelName}</b> - " +
                        $"Serial Number: <b>{deviceInfo.SerialNumber}</b> - " +
                        $"Version: <b>{deviceInfo.Version}</b>";
            }
        }

        private void cbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            SourceImageSettings.CameraSettings.DeviceName = cbDevices.Text;

            if (NameDevices != null && NameDevices.ContainsKey(cbDevices.Text))
                SourceImageSettings.CameraSettings.DeviceNameOrigin = NameDevices[cbDevices.Text];

            ShowDeviceInfo();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectCamera(true);
            btnTriggerBySoftware.Enabled = SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera &&
                                           SourceImageSettings.CameraSettings.IsConnected &&
                                           SourceImageSettings.IsTriggerBySoftware;
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => FadaOutLabel()));
        }

        private void FadaOutLabel()
        {
            if (lblNoticeConnect.ForeColor.A <= 0)
            {
                FadeTimer.Enabled = false;
                lblNoticeConnect.Visible = false;
                if (lblNoticeConnect.Text == cStrings.Connected)
                {
                    btnConnect.Visible = false;
                    btnDisconnect.Visible = true;
                }
                else
                {
                    btnDisconnect.Visible = false;
                    btnConnect.Visible = true;
                }
                return;
            }
            btnConnect.Visible = false;
            btnDisconnect.Visible = false;
            lblNoticeConnect.ForeColor = Color.FromArgb(lblNoticeConnect.ForeColor.A - FadeOutSpeed, lblNoticeConnect.ForeColor.R, lblNoticeConnect.ForeColor.G, lblNoticeConnect.ForeColor.B);
            lblNoticeConnect.Invalidate();
        }

        private void radChooseFile_CheckedChanged(object sender, EventArgs e)
        {
            if(_LockEvents || SourceImageSettings == null)
            {
                return;
            }
            SourceImageSettings.ComputerSettings.IsFolder = radChooseFolder.Checked == true ? true : false;
            if(SourceImageSettings.ComputerSettings.IsFolder)
            {
                txtPathEndClick();
            } 
            else
            {
                SourceImageSettings.ComputerSettings.Images.Clear();
                PreviewData_ViewListFiles();
                ShowHideControlTabComputer();
            }
        }

        private void txtPathEndClick()
        {
            SourceImageSettings.ComputerSettings.FolderPath = txtPath.Text;
            if(System.IO.Directory.Exists(SourceImageSettings.ComputerSettings.FolderPath))
            {
                SourceImageSettings.ComputerSettings.Images.Clear();
                DirectoryInfo directoryInfo = new DirectoryInfo(SourceImageSettings.ComputerSettings.FolderPath);
                var c = GlobFuncs.GetFilesByExtensions(directoryInfo, ".jpg", "jpeg", ".png", ".bmp");
                string s = string.Empty;
                if(c != null && c.Count() > 0)
                {
                    foreach(FileInfo item in c)
                    {
                        cImage image = new cImage();
                        image.FileName = item.FullName;
                        SourceImageSettings.ComputerSettings.Images.Add(image);
                    }    
                }    
            }  
            else
            {
                SourceImageSettings.ComputerSettings.Images.Clear();
            }
            PreviewData_ViewListFiles();
            ShowHideControlTabComputer();
           // var test = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void btnChoosePath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "Choose Folder";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtPath.Text = dialog.FileName;
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            txtPathEndClick();
        }

        private void listFiles_SelectionChanged(object sender, EventArgs e)
        {
            int test = ListFiles.Rows.Count;
            if (GlobVar.LockEvents) return;
            if (ListFiles.CurrentRow != null && ListFiles.CurrentRow.Index >= 0)
                GetCurrentImgIndex(ListFiles.CurrentRow);
        }

        private void radChooseFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (radChooseFile.Checked == true)
            {
                txtPath.Visible = true;
                btnChooseFolder.Visible = false;
            }
            else
            {
                txtPath.Visible = true;
                btnChooseFolder.Visible = true;
            }
        }

        private void ucMainActions_Load(object sender, EventArgs e)
        {
            //radChooseFile_CheckedChanged(null, null);
            //btnComputer_Click(null, e);

        }

        private void chkAutoSaveImage_CheckedChanged(object sender, EventArgs e)
        {
            if (SourceImageSettings != null)
            {
                //SourceImageSettings.CameraSettings.IsAutoSaveImage = chkAutoSaveImage.Checked;
                //if (SourceImageSettings.CameraSettings.IsLive &&
                //SourceImageSettings.CameraSettings.WorkerObject !== null
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            DialogResult dlgr = cMessageBox.Question_YesNo(string.Format(RTC_Vision_Lite.Properties.Resources.QuestionDeleteAll, "image"));
            if(dlgr == DialogResult.Yes)
            {
                ListFiles.Rows.Clear();
            }
            else
            {
                return;
            }
            if(SourceImageSettings != null)
            {
                SourceImageSettings.ComputerSettings.Images.Clear();
                PreviewData_ViewListFiles();
                ShowHideControlTabComputer();
            }    
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (SourceImageSettings != null && ListFiles.SelectedRows.Count > 0)
            {
                SourceImageSettings.ComputerSettings.Images.RemoveAt(
                    SourceImageSettings.ComputerSettings.Images.FindIndex(x => x.FileName == ListFiles.SelectedRows[0].Cells["FileName"].Value.ToString()));
                 DataGridViewRow selectedRow = ListFiles.SelectedRows[0];
                ListFiles.Rows.Remove(ListFiles.SelectedRows[0]);
                ShowHideControlTabComputer();
            }
        }

        private void chkEnableSnap_CheckedChanged(object sender, EventArgs e)
        {
            SourceImageSettings.IsEnableSnap = chkEnableSnap.Checked;
        }

        private void chkIsGetResultByRunningTool_CheckedChanged(object sender, EventArgs e)
        {
            GlobVar.GroupActions.MyCam.IsGetResultByRunningTool = chkIsGetResultByRunningTool.Checked;
        }

        private void chkIsUseSetOKButton_CheckedChanged(object sender, EventArgs e)
        {
            GlobVar.GroupActions.MyCam.IsGetResultByRunningTool = chkIsGetResultByRunningTool.Checked;

        }

        private void chkIsTriggerBySoftware_CheckedChanged(object sender, EventArgs e)
        {
            SourceImageSettings.IsTriggerBySoftware = chkIsTriggerBySoftware.Checked;
            btnTriggerBySoftware.Enabled = SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera &&
                SourceImageSettings.CameraSettings.IsConnected &&
                SourceImageSettings.IsTriggerBySoftware;
        }

        private void lblOpenImageFolder_Click(object sender, EventArgs e)
        {
            if (SourceImageSettings != null &&
                Directory.Exists(SourceImageSettings.CameraSettings.SaveImageFolder_Origin))
                Process.Start(SourceImageSettings.CameraSettings.SaveImageFolder_Origin);
        }

        private void lblTriggerBySoftware_Click(object sender, EventArgs e)
        {
            if (GlobVar.GroupActions.ConnectCamera())
                GlobVar.GroupActions.TriggerBySoftware(true);
        }
        internal void SaveDefaultCameraSettings()
        {
            if (IsCheckedCamera)
                ucCameraSettings1.SavePropValueToDefault();
        }

        private void lblSetDefault_Click(object sender, EventArgs e)
        {
            if (SourceImageSettings != null)
            {
                SourceImageSettings.DefaultImageSourceType = lblSetDefault.Text == cStrings.SetDefault ? SourceImageSettings.ImageSourceType : EImageSourceTypes.None;
                PreviewData_DefaultImageSourceType();
                GlobVar.GroupActions.DataChanged = true;
            }
        }

        private void btnIpConfig_Click(object sender, EventArgs e)
        {

        }
    }

}



