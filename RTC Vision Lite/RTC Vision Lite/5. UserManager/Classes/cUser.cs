using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.UserManager.Classes
{
    public partial class cUser
    {
        public Guid ID { get; set; }
        public int OrderNum { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PassWordE { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid IDPermission { get; set; }
        public cPermission Permission;
        public Guid IDDepartment { get; set; }
        public cDepartment Department;
        public Guid IDPosition { get; set; }
        public cPosition Position;
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public bool IsLogged = false;
        public bool IsKeepLoggedInOneSession = true;
        public cUser()
        {
            ID = Guid.NewGuid();
            OrderNum = 0;
            UserName = string.Empty;
            PassWord = string.Empty;
            PassWordE = string.Empty;
            Name = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            IDPermission = Guid.Empty;
            IDDepartment = Guid.Empty;
            IDPosition = Guid.Empty;
            Permission = new cPermission();
            Department = new cDepartment();
            Position = new cPosition();
            Note = string.Empty;
            IsActive = false;
        }
    }
}
