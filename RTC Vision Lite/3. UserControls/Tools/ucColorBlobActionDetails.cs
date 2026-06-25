using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTCConst;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucColorBlobActionDetails : ucBaseActionDetail
    {
        public ucColorBlobActionDetails()
        {
            InitializeComponent();
            // Cập nhật visibility ngay sau khi khởi tạo
            this.Load += (s, e) => UpdateColorSpaceVisibility();
        }

        private void ucTolerance1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Khi người dùng chọn Color Space khác → ẩn/hiện nhóm HSV hoặc RGB tương ứng.
        /// </summary>
        private void RTCColorSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateColorSpaceVisibility();
        }

        /// <summary>
        /// Ẩn/hiện các control HSV và RGB dựa theo giá trị hiện tại của RTCColorSpace.
        /// - HSV: Hue, Saturation, Intensity (label5, label8, label9, RTCHueToleranceOut, RTCSaturationToleranceOut, RTCIntensityToleranceOut)
        /// - RGB: Red, Green, Blue   (label12, label11, label10, RTCRedToleranceOut, RTCGreenToleranceOut, RTCBlueToleranceOut)
        /// </summary>
        private void UpdateColorSpaceVisibility()
        {
            string selected = RTCColorSpace.SelectedItem?.ToString() ?? string.Empty;
            bool isHSV = selected == cBlobColorTool.ColorSpace_HSV;
            bool isRGB = selected == cBlobColorTool.ColorSpace_RGB
                      || selected == cBlobColorTool.ColorSpace_BGR;

            // HSV group — chỉ cho nhập khi chọn HSV
            RTCHueToleranceOut.Enabled = isHSV;
            RTCSaturationToleranceOut.Enabled = isHSV;
            RTCIntensityToleranceOut.Enabled = isHSV;

            // RGB/BGR group — chỉ cho nhập khi chọn RGB hoặc BGR
            RTCRedToleranceOut.Enabled = isRGB;
            RTCGreenToleranceOut.Enabled = isRGB;
            RTCBlueToleranceOut.Enabled = isRGB;
        }
    }
}
