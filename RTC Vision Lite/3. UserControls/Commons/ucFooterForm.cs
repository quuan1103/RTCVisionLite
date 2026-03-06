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
    public delegate void UserControl_Common_ButtonClickEvents(object sender, EventArgs e);

    public partial class ucFooterForm : UserControl
    {
        public ucFooterForm()
        {
            InitializeComponent();

        }
        #region Properties

        private bool _RTCbtnHelpVisible;
        /// <summary>
        /// Visbile Help Button
        /// </summary>
        [Browsable(true)]
        [Category("RTCProperties")]
        public bool RTCbtnHelpVisible
        {
            get { return btnHelp.Visible; }
            set
            {
                _RTCbtnHelpVisible = value;
                btnHelp.Visible = _RTCbtnHelpVisible;
            }
        }

        private bool _RTCbtnApplyVisible;
        /// <summary>
        /// Visbile Apply Button
        /// </summary>
        public bool RTCbtnApplyVisible
        {
            get { return btnApply.Visible; }
            set
            {
                _RTCbtnApplyVisible = value;
                btnApply.Visible = _RTCbtnApplyVisible;
            }
        }

        private bool _RTCbtnOKVisible;
        /// <summary>
        /// Visbile OK Button
        /// </summary>
        [Browsable(true)]
        [Category("RTCProperties")]
        public bool RTCbtnOKVisible
        {
            get { return btnOK.Visible; }
            set
            {
                _RTCbtnOKVisible = value;
                btnOK.Visible = _RTCbtnOKVisible;
            }
        }

        private bool _RTCbtnSaveVisible;
        /// <summary>
        /// Visbile Save Button
        /// </summary>
        [Browsable(true)]
        [Category("RTCProperties")]
        public bool RTCbtnSaveVisible
        {
            get { return btnSave.Visible; }
            set
            {
                _RTCbtnSaveVisible = value;
                btnSave.Visible = _RTCbtnSaveVisible;
            }
        }

        private bool _RTCbtnCancelVisible;
        /// <summary>
        /// Visbile Cancel Button
        /// </summary>

        [Browsable(true)]
        [Category("RTCProperties")]
        public bool RTCbtnCancelVisible
        {
            get { return btnCancel.Visible; }
            set
            {
                _RTCbtnCancelVisible = value;
                btnCancel.Visible = _RTCbtnCancelVisible;
            }
        }

        private bool _RTCbtnHelpEnabled;
        /// <summary>
        /// Visbile Help Button
        /// </summary>
        [Browsable(true)]
        [Category("RTCProperties")]
        public bool RTCbtnHelpEnabled
        {
            get { return btnHelp.Enabled; }
            set
            {
                _RTCbtnHelpEnabled = value;
                btnHelp.Enabled = _RTCbtnHelpEnabled;
            }
        }

        private bool _RTCbtnApplyEnabled;
        /// <summary>
        /// Visbile Apply Button
        /// </summary>

        [Browsable(true)]
        [Category("RTCProperties")]
        public bool RTCbtnApplyEnabled
        {
            get { return btnApply.Enabled; }
            set
            {
                _RTCbtnApplyEnabled = value;
                btnApply.Enabled = _RTCbtnApplyEnabled;
            }
        }

        private bool _RTCbtnOKEnabled;
        /// <summary>
        /// Visbile OK Button
        /// </summary>

        [Browsable(true)]
        [Category("RTCProperties")]
        public bool RTCbtnOKEnabled
        {
            get { return btnOK.Enabled; }
            set
            {
                _RTCbtnOKEnabled = value;
                btnOK.Enabled = _RTCbtnOKEnabled;
            }
        }

        private bool _RTCbtnSaveEnabled;
        /// <summary>
        /// Visbile Save Button
        /// </summary>

        [Browsable(true)]
        [Category("RTCProperties")]
        public bool RTCbtnSaveEnabled
        {
            get { return btnSave.Enabled; }
            set
            {
                _RTCbtnSaveEnabled = value;
                btnSave.Enabled = _RTCbtnSaveEnabled;
            }
        }

        private bool _RTCbtnCancelEnabled;
        /// <summary>
        /// Visbile Cancel Button
        /// </summary>

        [Browsable(true)]
        [Category("RTCProperties")]
        public bool RTCbtnCancelEnabled
        {
            get { return btnCancel.Enabled; }
            set
            {
                _RTCbtnCancelEnabled = value;
                btnCancel.Enabled = _RTCbtnCancelEnabled;
            }
        }
        #endregion

        #region Events
        [Browsable(true)]
        public UserControl_Common_ButtonClickEvents OnOKClick;
        [Browsable(true)]
        public UserControl_Common_ButtonClickEvents OnSaveClick;
        [Browsable(true)]
        public UserControl_Common_ButtonClickEvents OnCancelClick;
        [Browsable(true)]
        public UserControl_Common_ButtonClickEvents OnApplyClick;
        [Browsable(true)]
        public UserControl_Common_ButtonClickEvents OnHelpClick;
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (OnCancelClick != null)
                OnCancelClick(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (OnSaveClick != null)
                OnSaveClick(sender, e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (OnHelpClick != null)
                OnHelpClick(sender, e);
        }
    }
}
