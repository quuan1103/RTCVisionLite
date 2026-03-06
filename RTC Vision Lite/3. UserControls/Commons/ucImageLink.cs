using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCEnums;
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
    public partial class ucImageLink : UserControl
    {
        public event ButtonLinkClickEvent OnButtonLinkClickEvent;
        public event ButtonRemoveLinkClickEvent OnButtonRemoveLinkClickEvent;
        public event ButtonLinkEndSelectedPropertyLinkEvent OnButtonLinkEndSelectedPropertyLinkEvent;

        public string Caption
        {
            get
            {
                return groupBox2.Text;
            }
            set
            {
                groupBox2.Text = value;
            }
        }

        private string _PropertyName;

        public string PropertyName
        {
            get { return _PropertyName; }
            set
            {
                _PropertyName = value;
                PreviewData();
            }
        }

        private cAction _Action;

        public cAction Action
        {
            get { return _Action; }
            set
            {
                _Action = value;
                PreviewData();
            }
        }

        private void PreviewData()
        {
            lblRef.Text = $@"
                               <html>
                                <head>
                                    <style>
                                        body {{
                                            font-family: Microsoft Sans Serif;
                                            font-size: 8.25pt;
                                        }}
                                        .highlight {{
                                            color: blue;
                                            font-family: Microsoft Sans Serif;
                                            font-size: 8.25pt;
                                        }}
                                    </style>
                                </head>
                                <body>
                                    Source:
                                </body>
                                </html>";
            GlobFuncs.EnableControl(btnRemoveLink, false);
            if(Action != null && _PropertyName != string.Empty)
            {
                RTCVariableType rtcvar = (RTCVariableType)Action.GetType().GetProperty(_PropertyName).GetValue(Action, null);
                if(rtcvar != null && rtcvar.rtcIDRef != Guid.Empty)
                {
                    lblRef.Text = $@"
                               <html>
                                <head>
                                    <style>
                                        body {{
                                            font-family: Microsoft Sans Serif;
                                            font-size: 8pt;
                                        }}
                                        .highlight {{
                                            color: blue;
                                            font-family: Microsoft Sans Serif;
                                            font-size: 8.25pt;
                                        }}
                                        .space {{
                                            margin-left: 10px;
                                        }}
                                    </style>
                                </head>
                                <body>
                                     <span>Source:</span><span class=""highlight"">   {rtcvar.rtcRef}     </span>
                                </body>
                                </html>";
                    GlobFuncs.EnableControl(btnRemoveLink, true);
                }
            }
        }

        public ucImageLink()
        {
            InitializeComponent();
            Action = null;
            PropertyName = string.Empty;
            //tl.LargeImageList = GlobVar.imlActionType16;

        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (PropertyName == "" || Action == null) { return; }
            RTCE_ButtonLinkClickEventArgs eRTC = new RTCE_ButtonLinkClickEventArgs();
            eRTC.PropertyName = PropertyName;
            if(OnButtonLinkClickEvent != null)
            {
                OnButtonLinkClickEvent(sender, eRTC);
            }
        }

        private void btnRemoveLink_Click(object sender, EventArgs e)
        {
            if (PropertyName == "" || Action == null) { return; }
            RTCE_ButtonRemoveLinkClickEventArgs eRTC = new RTCE_ButtonRemoveLinkClickEventArgs();
            eRTC.PropertyName = PropertyName;
            if(OnButtonRemoveLinkClickEvent != null)
            {
                OnButtonRemoveLinkClickEvent(sender, eRTC);
            }
        }

            //public void ViewData()
            //{
            //    try
            //    {
            //        ETupleStyle eTupleStyle = ((RTCVariableType)Action.GetType().GetProperty(PropertyName).GetValue(Action, null)).TupleStyle;
            //        tl.SuspendLayout();
            //        tl.
            //    }
            //}
    }
}
