using BrightIdeasSoftware;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
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

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmApplyActionToOtherCAMs : FrmBase
    {

        public FrmApplyActionToOtherCAMs()
        {
            InitializeComponent();

            tl.TreeColumnRenderer.IsShowLines = false;

        }
        private DataTable _Data;

        public DataTable Data
        {
            get { return _Data; }
            set
            {

                _Data = value;
                PreviewData();
            }
        }
        public class Cams
        {
            public Guid ID { get; set; }
            public bool SelectCam { get; set; }
            public string CamName { get; set; }
            public List<Cams> child = new List<Cams>();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            DataRow[] rows = Data.Select(cColName.Select + "=True");
            if (rows == null || rows.Count() <= 0)
            {
                cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.War_NotSelected,
                                    new string[] { cStrings.CAM }, new string[] { cStrings.CAMV }));
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void FrmApplyActionToOtherCAMs_Load(object sender, EventArgs e)
        {
        }
        public void PreviewData()
        {
            tl.BeginUpdate();
            List<Cams> root = new List<Cams>();
            foreach (DataRow row in _Data.Rows)
            {
                Cams newNode = new Cams();
                newNode.ID = GlobFuncs.Object2Guid(row["ID"], new Guid());
                newNode.SelectCam = GlobFuncs.Object2Bool(row["Select"]);
                newNode.CamName = GlobFuncs.Object2Str(row["Name"]);
                root.Add(newNode);
            }
            tl.Roots = root;
            tl.EndUpdate();
        }

        private void tlCAMs_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Column == colSelect)
            {
                e.SubItem.Text = "";
            }
        }

        private void tlCAMs_SubItemChecking(object sender, SubItemCheckingEventArgs e)
        {
            if (e.Column == colSelect)
            {
                {
                    bool Value = !((Cams)(e.RowObject)).SelectCam;
                    Guid IDCheck = ((Cams)(e.RowObject)).ID;
                    DataRow Rows = Data.Select($"ID = '{IDCheck}'")[0];
                    Rows["Select"] = Value;
                }
            }
        }


    }
}

