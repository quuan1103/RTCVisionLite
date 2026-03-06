using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserManager.Classes
{
    public class cPermissionDetail
    {
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }
        public bool Execute { get; set; }

        public cPermissionDetail()
        {
            Add = false;
            Edit = false;
            Delete = false;
            View = false;
            Execute = false;
        }
    }
    public partial class cPermission
    {
        public Guid ID { get; set; }
        public int OrderNum { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public cPermissionDetail Settings { get; set; }
        public cPermissionDetail GeneralSettings { get; set; }
        public cPermissionDetail RunOptionsSettings { get; set; }
        public cPermissionDetail ViewOptionsSettings { get; set; }
        public cPermissionDetail ViewStyleSettings { get; set; }
        public cPermissionDetail ReportLogErrorSettings { get; set; }
        public cPermissionDetail ImageOptionsSettings { get; set; }
        public cPermissionDetail UpdateOptionsSettings { get; set; }
        public cPermissionDetail SecurityOptionsSettings { get; set; }
        public cPermissionDetail SettingTools { get; set; }
        public cPermissionDetail AcceptResult { get; set; }
        public cPermissionDetail Report { get; set; }
        public cPermissionDetail User { get; set; }
        public cPermissionDetail Permission { get; set; }
        public cPermissionDetail Department { get; set; }
        public cPermissionDetail Position { get; set; }
        public cPermissionDetail Templates { get; set; }
        public cPermissionDetail Model { get; set; }
        public cPermissionDetail CleanImage { get; set; }
        public cPermissionDetail MovingTools { get; set; }
        public cPermissionDetail LinkValueTools { get; set; }

        public cPermission()
        {
            ID = Guid.NewGuid();
            Name = string.Empty;
            Note = string.Empty;
            Settings = new cPermissionDetail();
            GeneralSettings = new cPermissionDetail();
            RunOptionsSettings = new cPermissionDetail();
            ViewOptionsSettings = new cPermissionDetail();
            ViewStyleSettings = new cPermissionDetail();
            ReportLogErrorSettings = new cPermissionDetail();
            ImageOptionsSettings = new cPermissionDetail();
            UpdateOptionsSettings = new cPermissionDetail();
            SecurityOptionsSettings = new cPermissionDetail();
            SettingTools = new cPermissionDetail();
            AcceptResult = new cPermissionDetail();
            Report = new cPermissionDetail();
            User = new cPermissionDetail();
            Permission = new cPermissionDetail();
            Department = new cPermissionDetail();
            Position = new cPermissionDetail();
            Templates = new cPermissionDetail();
            Model = new cPermissionDetail();
            CleanImage = new cPermissionDetail();
            MovingTools = new cPermissionDetail();
            LinkValueTools = new cPermissionDetail();
        }
    }
}
