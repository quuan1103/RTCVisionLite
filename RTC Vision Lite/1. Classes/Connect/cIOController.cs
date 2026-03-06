using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsIOControllerSDK.VC3000;
using NsIOControllerSDK.VC4000;

namespace RTC_Vision_Lite.Classes
{
    internal class cIOController
    {
        private CIOControllerSDK3000 IOController3000;
        private CIOControllerSDK4000 IOController4000;
        public bool IsVC3000 { get; set; }
        public bool IsPNP { get; set; }
        public string COMName { get; set; }
        public string Parity { get; set; }
        public string StopBits { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        private bool Connect()
        {
            return true;
            if (IsVC3000)
            {
                int nRet = CIOControllerSDK3000.MV_IO_WinIO_Init_CS();
                if (nRet != CIOControllerSDK3000.MV_OK)
                {
                    return false;
                    CIOControllerSDK3000.MV_IO_WinIO_DeInit_CS();
                }
                else
                    return true;
            }
            else
            {
                //IntPtr handle = new IntPtr();
                //if ((CIOControllerSDK4000.MV_IO_CreateHandle_CS(ref handle) != 0) || (IntPtr.Zero == handle))
                //{
                //    this.LOG(this.m_stSerial.strComName + "Failed to create handle");
                //}
                //else
                //{
                //    this.LOG(this.m_stSerial.strComName + "Succeeded to create handle.handle:0x" + Convert.ToString((int)handle, 0x10));
                //    CIOControllerSDK.m_hDeviceHandleList[this.cbComNo.SelectedIndex] = handle;
                //}
                //num = CIOControllerSDK.MV_IO_Open_CS(CIOControllerSDK.m_hDeviceHandleList[this.cbComNo.SelectedIndex], ref this.m_stSerial);
                //if (num != 0)
                //{
                //    this.LOG("Failed to open" + this.m_stSerial.strComName + ". Error: ：" + Convert.ToString(num, 0x10));
                //    CIOControllerSDK.MV_IO_Close_CS(CIOControllerSDK.m_hDeviceHandleList[this.cbComNo.SelectedIndex]);
                //    CIOControllerSDK.MV_IO_DestroyHandle_CS(CIOControllerSDK.m_hDeviceHandleList[this.cbComNo.SelectedIndex]);
                //    CIOControllerSDK.m_hDeviceHandleList[this.cbComNo.SelectedIndex] = IntPtr.Zero;
                //}
                //else
                //{
                //    this.LOG("Succeeded to open " + this.m_stSerial.strComName + "！");
                //    base.Invoke(() => this.btnEdgeDetection.Enabled = true);
                //    this.btnOpenOrCloseCom.Text = "Close Serial Port";
                //    if (this.RefreshFirmwareVersion() == 0)
                //    {
                //        this.LOG(this.m_stSerial.strComName + " succeeded to get firmware version " + this.lbFirmwareVersion.Text);
                //    }
                //    else
                //    {
                //        this.LOG(this.m_stSerial.strComName + " failed to get firmware version！");
                //        CIOControllerSDK.MV_IO_Close_CS(CIOControllerSDK.m_hDeviceHandleList[this.cbComNo.SelectedIndex]);
                //        CIOControllerSDK.MV_IO_DestroyHandle_CS(CIOControllerSDK.m_hDeviceHandleList[this.cbComNo.SelectedIndex]);
                //        this.EnableSerailParams();
                //        this.DisableIOParams();
                //        this.btnOpenOrCloseCom.Text = "Open Serial Port";
                //        CIOControllerSDK.m_hDeviceHandleList[this.cbComNo.SelectedIndex] = IntPtr.Zero;
                //    }
                //    this.GetIOParams();
                //    this.GetLightParams();

                //}
            }
        }
    }
}
