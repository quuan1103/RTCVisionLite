using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
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
    public partial class ucSnapImageActionDetail : ucBaseActionDetail
    {
        public ucSnapImageActionDetail()
        {
            InitializeComponent();
        }
        internal void ViewTemplates()
        {
            try
            {
                GlobVar.LockEvents = true;
                GlobFuncs.ClearComboBox(RTCTemplateName);
                if (Action == null)
                    return;

                DataTable dataTable = Lib.GetDataTable(
                    $"SELECT DISTINCT {cColName.Name} FROM {cTableName_SaveTemplate.CameraSettingTemplate} ORDER BY {cColName.Name}",
                    Action.MyGroup.MyCam.MyProject.FileName);
                if (dataTable == null)
                    return;

                foreach (DataRow row in dataTable.Rows)
                    GlobFuncs.AddComboBoxValue(RTCTemplateName, GlobFuncs.GetDataRowValue_String(row, cColName.Name));

                GlobFuncs.SetComboBoxText(RTCTemplateName, Action.TemplateName.rtcValue);
                GlobVar.LockEvents = false;
                LoadTemplateDetailToTreeList();
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }

        private object GetParamValue(DataRow row)
        {
            string dataType = GlobFuncs.GetDataRowValue_String(row, cColName.DataType);
            switch (dataType)
            {
                case cDataTypes.TEXT:
                    return GlobFuncs.GetDataRowValue_String(row, cColName.ValueT);
                case cDataTypes.INTEGER:
                    return GlobFuncs.GetDataRowValue_Int(row, cColName.ValueI);
                default:
                    return GlobFuncs.GetDataRowValue_Double(row, cColName.ValueD);
            }
        }
        internal void LoadTemplateDetailToTreeList()
        {
            if (GlobVar.LockEvents)
                return;
            if (tlCameraSettings.InvokeRequired)
                tlCameraSettings.Invoke(new MethodInvoker(LoadTemplateDetailToTreeList));
            else
            {
                string templateName = GlobFuncs.GetComboBoxText(RTCTemplateName);
                tlCameraSettings.ClearObjects();
                if (Action == null || string.IsNullOrEmpty(templateName))
                    return;

                DataTable dataTable = Lib.GetDataTable(
                    $"SELECT * FROM {cTableName_SaveTemplate.CameraSettingTemplate} WHERE {cColName.Name}='{RTCTemplateName.Text}' ORDER BY {cColName.ParamName}",
                    Action.MyGroup.MyCam.MyProject.FileName);
                if (dataTable == null)
                    return;
                foreach (DataRow row in dataTable.Rows)
                {
                    CameraSettings cam = new CameraSettings();
                    cam.PropName = GlobFuncs.GetDataRowValue_String(row, cColName.ParamName);
                    cam.Value = GetParamValue(row).ToString();
                    tlCameraSettings.AddObject(cam);
                   
                }
            }
        }

        private void RTCTemplateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTemplateDetailToTreeList();
        }

        private void btnRefreshTemplate_Click(object sender, EventArgs e)
        {
            ViewTemplates();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (Action != null)
                Action.Run_SnapImage_Test();
        }
    }
}
