using Newtonsoft.Json.Linq;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCBase.Drawing;
using RTCConst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucOrigin : UserControl
    {
        public event ButtonLinkClickEvent OnButtonLinkClickEvent;
        public event ButtonLinkEndSelectedPropertyLinkEvent OnButtonLinkEndSelectedPropertyLinkEvent;
        public event ButtonRemoveLinkClickEvent OnButtonRemoveLinkClickEvent;

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
        public class ColoredLabel : Label
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                // Vẽ văn bản với màu chữ tùy chỉnh
                using (Brush brush = new SolidBrush(Color.FromArgb(152, 152, 152)))
                {
                    e.Graphics.DrawString(this.Text, this.Font, brush, new PointF(0, 0));
                }
            }
        }
        public ucOrigin()
        {
            InitializeComponent();
            Action = null;
            PropertyName = string.Empty;
        }

        public void PreviewData()

        {
            lblvalue.Text = $@"
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
                                            margin-right: 10px;
                                        }}
                                        .space {{
                                            margin-left: 10px;
                                        }}
                                    </style>
                                </head>
                                <body>
                                   
                                    <span class=""space"">X:</span><span class=""highlight"">   0   </span>
                                    Y: <span class=""highlight"">   0  </span>
                                    Angle: <span class=""highlight"">   0   </span>
                                </body>
                                </html>";
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
            btnRemoveLink.Enabled = false;
            if (Action != null && _PropertyName != string.Empty && Action.GetType().GetProperty(_PropertyName).PropertyType.Name == "SListDouble")
            {
                SListDouble rtcvar = (SListDouble)Action.GetType().GetProperty(_PropertyName).GetValue(Action, null);
                //Action.ToolOrigin
                //RTCVariableType rtcvar = (RTCVariableType)Action.GetType().GetProperty(_PropertyName).GetValue(Action, null);
                if (rtcvar != null && rtcvar.rtcValue != null && rtcvar.rtcValue.Count >= 3)
                {
                    lblvalue.Text = $@"
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
                                            margin-right: 10px;
                                        }}
                                        .space {{
                                            margin-left: 10px;
                                        }}
                                    </style>
                                </head>
                                <body>
                                    Current Tool Origin:            
                                        <span class=""space"">X:</span>     <span class=""highlight"">   {rtcvar.rtcValue[0]}   </span> 
                                        Y:      <span class=""highlight"">   {rtcvar.rtcValue[1]}   </span> 
                                        Angle:      <span class=""highlight"">   {rtcvar.rtcValue[2]}   </span>
                                </body>
                                </html>";

                }

                if (rtcvar != null && rtcvar.rtcIDRef != Guid.Empty)
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
                                     <span>Source:</span>  :<span class=""highlight"">   {rtcvar.rtcRef}     </span>
                                </body>
                                </html>";

                    btnRemoveLink.Enabled = true;
                    //Tuple<PointF, double> toolOrigin = Tuple.Create(new PointF(Lib.ToInt(Action.ToolOrigin.rtcValue[0]), Lib.ToInt(Action.ToolOrigin.rtcValue[1])),
                    //Action.ToolOrigin.rtcValue[2]);
                    //Dictionary<long, RTCRectangle> DataShape = GlobFuncs.GenShapeList(Action.ShapeListOriginal);
                    //Action.InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble( Action.SetOrigin.Run(DataShape.Values.Cast<RTCRectangle>().ToList(), toolOrigin));
                }
            }
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
    }
}
