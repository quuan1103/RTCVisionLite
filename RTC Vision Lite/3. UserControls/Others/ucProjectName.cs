using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucProjectName : UserControl
    {

        #region PROPERTIES

        /// <summary>   Event queue for all listeners interested in onTextEditValueChanged events. </summary>
        public event ProgramNameValueChanged OnProgramNameValueChangedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a value indicating whether the RTC is use caption. </summary>
        ///
        /// <value> True if RTC is use caption, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool isUseCaption = true;
        public bool RTCIsUseCaption
        {
            get => isUseCaption;
            set
            {
                isUseCaption = value;
                tlpLayout.ColumnStyles[0].Width = value ? 100 : 0;
            }
        }


        public string RTCCaptionText
        {
            get => lblCaption.Text;
            set => lblCaption.Text = value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the width of the RTC caption. </summary>
        ///
        /// <value> The width of the RTC caption. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public float RTCCaptionWidth
        {
            get => tlpLayout.ColumnStyles[0].Width;
            set => tlpLayout.ColumnStyles[0].Width = value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC current program. </summary>
        ///
        /// <value> The RTC current program. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private cAction _RTCAction = null;

        public cAction RTCAction
        {
            get => _RTCAction;
            set
            {
                _RTCAction = value;
                PreviewData();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the RTC property. </summary>
        ///
        /// <value> The name of the RTC property. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RTCPropertyName { get; set; }

        #endregion

        #region FUNCTIONS

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   DATRUONG, 16/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ucProjectName()
        {
            InitializeComponent();
            RTCIsUseCaption = true;
            RTCCaptionText = "Model Name";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Preview data. </summary>
        ///
        /// <remarks>   DATRUONG, 16/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PreviewData()
        {
            try
            {
                GlobVar.LockEvents = true;
                cbValue.Items.Clear();
                if (GlobVar.DicProjects == null || RTCAction == null)
                    return;

                foreach (cProjectTypes project in GlobVar.DicProjects.Values)
                    if (RTCAction.MyGroup.MyCam.MyProject.ProjectName != project.ProjectName)
                        cbValue.Items.Add(project.ProjectName);

                string sOldName = string.Empty;
                RTCVariableType PropGetValueInfo = (RTCVariableType)RTCAction.GetType().GetProperty(RTCPropertyName)?.GetValue(RTCAction, null);
                if (PropGetValueInfo != null)
                {
                    PropertyInfo PropGetValue_Value = PropGetValueInfo.GetType().GetProperty(cPropertyName.rtcValue);
                    sOldName = GlobFuncs.Object2Str(PropGetValue_Value?.GetValue(PropGetValueInfo, null));
                }

                if (cbValue.Items.Count > 0)
                {
                    if (cbValue.Items.IndexOf(sOldName) >= 0)
                        cbValue.SelectedIndex = cbValue.Items.IndexOf(sOldName);
                    else
                        cbValue.SelectedIndex = 0;
                }
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        #endregion

        #region EVENTS

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by cbValue for selected index changed events. </summary>
        ///
        /// <remarks>   DATRUONG, 16/11/2021. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnProgramNameValueChangedEvent != null)
            {
                OnProgramNameValueChangedEvent(RTCPropertyName, cbValue.Text);
            }
        }
        #endregion
    }
}
