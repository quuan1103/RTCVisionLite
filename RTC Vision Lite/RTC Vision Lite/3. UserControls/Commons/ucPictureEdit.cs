using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Properties;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public delegate void PictureSelectedChanged(object sender, RTCE_PictureSelectedEventArgs e);
public delegate void GetImageClickEvents(string fileName);
namespace RTC_Vision_Lite.Commons
{
   
    public partial class ucPictureEdit : UserControl
    {
        public event PictureSelectedChanged OnPictureSelectedChanged;
        public event GetImageClickEvents OnGetImageClickEvents;
        public ucPictureEdit()
        {
            InitializeComponent();
        }
        #region PROPERTIES

        private string _imageFileName;
        /// <summary>
        /// Thiết lập đường dẫn file ảnh
        /// </summary>
        public string RTCImageFileName
        {
            get => _imageFileName;
            set
            {
                _imageFileName = value;
                RTCImage = new cImage
                {
                    FileName = _imageFileName
                };
            }
        }
        /// <summary>
        /// Thiết lập có hay không hiển thị đường dẫn file ảnh
        /// </summary>
        public bool RTCShowFileName
        {
            get => lblImageName.Visible;
            set => lblImageName.Visible = value;
        }
        /// <summary>
        /// Thiết lập có hay không hiển thị nút view ảnh
        /// </summary>
        public bool RTCShowViewImageButton
        {
            get => btnViewImage.Visible;
            set => btnViewImage.Visible = value;
        }
        /// <summary>
        /// Thiết lập có hay không hiển thị nút lấy ảnh
        /// </summary>
        public bool RTCShowGetFileButton
        {
            get => btnGetImage.Visible;
            set => btnGetImage.Visible = value;
        }
        /// <summary>
        /// Thiết lập kiểu hiển thị ảnh
        /// </summary>
        public PictureBoxSizeMode RTCPictureSizeMode
        {
            get => picImage.SizeMode;
            set => picImage.SizeMode = value;
        }
        private cImage _RTCImage = null;
        /// <summary>
        /// Đối tượng ảnh đang làm việc
        /// </summary>
        public cImage RTCImage
        {
            get { return _RTCImage; }
            set
            {
                _RTCImage = value;
                picImage.Image = Resources.NoImage;
                lblImageName.Text = string.Empty;
                lblResult.Visible = false;

                if (_RTCImage == null) return;

                if (File.Exists(_RTCImage.FileName))
                {
                    try
                    {
                        picImage.Image = Image.FromFile(_RTCImage.FileName);
                        lblImageName.Text = Path.GetFileName(_RTCImage.FileName);

                        lblResult.Text = _RTCImage.Passed ? "Passed" : "Failed";
                        lblResult.BackColor = _RTCImage.Passed ? Color.Green : Color.Red;
                        lblResult.Visible = _RTCImage.Ran;
                    }
                    catch
                    {
                        picImage.Image = Resources.NoImage;
                        lblImageName.Text = string.Empty;
                    }
                }
            }
        }

        #endregion
        #region EVENTS

        private void picImage_Click(object sender, EventArgs e)
        {
            if (OnPictureSelectedChanged != null)
            {
                RTCE_PictureSelectedEventArgs eRTC = new RTCE_PictureSelectedEventArgs();
                eRTC.RTCImage = RTCImage;
                OnPictureSelectedChanged(sender, eRTC);
            }
        }
        private void btnViewImage_Click(object sender, EventArgs e)
        {
            if (RTCImage != null && File.Exists(RTCImage.FileName))
                Process.Start(RTCImage.FileName, "-p");
        }
        private void btnGetImage_Click(object sender, EventArgs e)
        {
            RTCImageFileName = GlobFuncs.GetFileName(cFilterFileName.ImageFilter, GlobVar.RTCVision.Paths.OldPathChooseFolder);
            if (File.Exists(RTCImageFileName) && OnGetImageClickEvents != null)
                OnGetImageClickEvents(RTCImageFileName);
        }

        #endregion
    }
}
