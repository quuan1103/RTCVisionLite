using RTC_Vision_Lite.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmProjectSaveAs : FrmBase
    {
        public string ModelName { get; set; }
        public int OrderNumber { get; set; }
        public bool IsKeepPath { get; set; }
        public FrmProjectSaveAs()
        {
            InitializeComponent();
            ModelName = string.Empty;
            OrderNumber = 0;
            IsKeepPath = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã nhập tên model hay chưa
            if (string.IsNullOrEmpty(txtModelName.Text.Trim()) || string.IsNullOrWhiteSpace(txtModelName.Text.Trim()))
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                                    new string[] { "model name" }, new string[] { "Tên model" }));
                txtModelName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtOrderNumber.Text.Trim()) || string.IsNullOrWhiteSpace(txtOrderNumber.Text.Trim()))
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                                    new string[] { "order number model" }, new string[] { "số thứ tự model" }));
                txtOrderNumber.Focus();
                return;
            }
            // Kiểm tra xem tên model này đã tồn tại hay chưa
            foreach (cProjectTypes project in GlobVar.DicProjects.Values)
                if (project.ProjectName.ToLower() == txtModelName.Text.Trim().ToLower())
                {
                    cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists,
                        new string[] { "model name" }, new string[] { "Tên model" }));
                    txtModelName.Focus();
                    return;
                }

            ModelName = txtModelName.Text.Trim();
            OrderNumber = (int)txtOrderNumber.Value;
            IsKeepPath = !chkReplacePath.Checked;
            DialogResult = DialogResult.OK;
        }

        private void FrmProjectSaveAs_Load(object sender, EventArgs e)
        {
            //Lấy order number mới
            int iNewOrderNumber = 0;
            if (GlobVar.DicProjects != null)
                foreach (var item in GlobVar.DicProjects.Values)
                    if (item.OrderNum >= iNewOrderNumber)
                        iNewOrderNumber = item.OrderNum;

            iNewOrderNumber += 1;
            txtOrderNumber.Minimum = iNewOrderNumber;
            txtOrderNumber.Maximum = 1000000;
            txtOrderNumber.Value = iNewOrderNumber;
        }

        private void txtModelName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
