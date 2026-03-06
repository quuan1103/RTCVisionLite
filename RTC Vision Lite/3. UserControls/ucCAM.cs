using RTC_Vision_Lite.Classes;
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

namespace RTC_Vision_Lite.UserControls
{
    public delegate void ucCAMButtonClickEvent(object CAMsender, object sender, EventArgs e);
    public partial class ucCAM : UserControl
    {
        public event ucCAMButtonClickEvent OnMaximizeButtonClickEvent;
        public event ucCAMButtonClickEvent OnMinimizeButtonClickEvent;
        public event ucCAMButtonClickEvent OnSetupToolsButtonClickEvent;
        public event ucCAMButtonClickEvent OnRunButtonClickEvent;
        public event ucCAMButtonClickEvent OnStopButtonClickEvent;
        public ucCAM()
        {
            InitializeComponent();
        }

        private cCAMTypes _myCAM;

        public cCAMTypes MyCAM
        {
            get => _myCAM;
            set
            {
                _myCAM = value;
            }
        }

        private bool _IsAlignCAM;

        public bool IsAlignCAM
        {
            get => _IsAlignCAM;
            set
            {
                _IsAlignCAM = value;
            }
        }

        private string _FileName_ImageTemplate;

        public string FileName_ImageTemplate
        {
            get => _FileName_ImageTemplate;
            set => _FileName_ImageTemplate = value;
        }

        public void RebuildWindow()
        {
            if (MyCAM.IsHide || !MyCAM.IsActive)
                return;

            if(!string.IsNullOrEmpty(_FileName_ImageTemplate) && File.Exists(_FileName_ImageTemplate))
            {
                //LayoutCAM
            }
        }
        #region EVENTS

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (OnSetupToolsButtonClickEvent != null)
            {
                OnSetupToolsButtonClickEvent(this, sender, e);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (OnMinimizeButtonClickEvent != null)
            {
                OnMinimizeButtonClickEvent(this, sender, e);
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if(OnMaximizeButtonClickEvent != null)
            {
                OnMaximizeButtonClickEvent(this, sender, e);
            }
        }
        #endregion
    }
}
