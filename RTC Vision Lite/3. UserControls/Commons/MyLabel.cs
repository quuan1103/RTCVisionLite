using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Commons
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   My label. </summary>
    ///
    /// <remarks>   DATRUONG, 20/08/2021. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class MyLabel : Label
    {
        private readonly Timer _Timer = null;

        private int _RTCInterval = 100;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC interval. </summary>
        ///
        /// <value> The RTC interval. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int RTCInterval
        {
            get => _RTCInterval;
            set
            {
                _RTCInterval = value;
                if (_Timer != null) _Timer.Interval = value == 0 ? 100 : value;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC fade out speed. </summary>
        ///
        /// <value> The RTC fade out speed. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int RTCFadeOutSpeed { get; set; } = 5;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the RTC border left is visible.
        /// </summary>
        ///
        /// <value> True if RTC border left visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RTCBorderLeftVisible { get; set; } = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the RTC border right is visible.
        /// </summary>
        ///
        /// <value> True if RTC border right visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RTCBorderRightVisible { get; set; } = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the RTC border top is visible. </summary>
        ///
        /// <value> True if RTC border top visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RTCBorderTopVisible { get; set; } = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the RTC border bottom is visible.
        /// </summary>
        ///
        /// <value> True if RTC border bottom visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RTCBorderBottomVisible { get; set; } = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the RTC use custom border. </summary>
        ///
        /// <value> True if RTC use custom border, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RTCUseCustomBorder { get; set; } = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the color of the RTC border left. </summary>
        ///
        /// <value> The color of the RTC border left. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Color RTCBorderLeftColor { get; set; } = Color.White;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the color of the RTC border right. </summary>
        ///
        /// <value> The color of the RTC border right. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Color RTCBorderRightColor { get; set; } = Color.White;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the color of the RTC border top. </summary>
        ///
        /// <value> The color of the RTC border top. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Color RTCBorderTopColor { get; set; } = Color.White;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the color of the RTC border bottom. </summary>
        ///
        /// <value> The color of the RTC border bottom. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Color RTCBorderBottomColor { get; set; } = Color.White;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC border left dash style. </summary>
        ///
        /// <value> The RTC border left dash style. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DashStyle RTCBorderLeftDashStyle { get; set; } = DashStyle.Solid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC border right dash style. </summary>
        ///
        /// <value> The RTC border right dash style. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DashStyle RTCBorderRightDashStyle { get; set; } = DashStyle.Solid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC border top dash style. </summary>
        ///
        /// <value> The RTC border top dash style. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DashStyle RTCBorderTopDashStyle { get; set; } = DashStyle.Solid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC border bottom dash style. </summary>
        ///
        /// <value> The RTC border bottom dash style. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DashStyle RTCBorderBottomDashStyle { get; set; } = DashStyle.Solid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC border top padding. </summary>
        ///
        /// <value> The RTC border top padding. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int RTCBorderTopPadding { get; set; } = 1;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC border bottom padding. </summary>
        ///
        /// <value> The RTC border bottom padding. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int RTCBorderBottomPadding { get; set; } = 1;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC border left padding. </summary>
        ///
        /// <value> The RTC border left padding. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int RTCBorderLeftPadding { get; set; } = 1;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC border right padding. </summary>
        ///
        /// <value> The RTC border right padding. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int RTCBorderRightPadding { get; set; } = 1;



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the RTC horizontal alignment. </summary>
        ///
        /// <value> The RTC horizontal alignment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   DATRUONG, 20/08/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MyLabel()
        {
            _Timer = new Timer();
            _Timer.Interval = 100;
            _Timer.Enabled = false;
            _Timer.Tick -= TimerTick;
            _Timer.Tick += TimerTick;
        }

        

        private void TimerTick(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(new Action(FadeOutLabel));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fade out label. </summary>
        ///
        /// <remarks>   DATRUONG, 20/08/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FadeOutLabel()
        {
            if (this.ForeColor.A <= 0)
            {
                _Timer.Enabled = false;
                this.Visible = false;
                return;
            }
            this.ForeColor = Color.FromArgb(this.ForeColor.A - RTCFadeOutSpeed, this.ForeColor.R, this.ForeColor.G, this.ForeColor.B);
            this.Invalidate();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   DATRUONG, 20/08/2021. </remarks>
        ///
        /// <param name="container">    The container. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MyLabel(IContainer container)
        {
            container.Add(this);
            _Timer = new Timer();
            _Timer.Interval = 100;
            _Timer.Enabled = false;
            _Timer.Tick -= TimerTick;
            _Timer.Tick += TimerTick;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Rectangle rc = this.ClientRectangle;
            StringFormat fmt = new StringFormat(StringFormat.GenericTypographic);
            using (var br = new SolidBrush(this.ForeColor))
            {
                e.Graphics.DrawString(this.Text, this.Font, br, rc, fmt);
                //this.ViewInfo.UpdatePaintAppearance();
            }
            //using (GraphicsCache cache = new GraphicsCache(e.Graphics, this.ScaleDPI))
            //{
            //    cache.SetActiveSkinInfo(this.GetActiveLookAndFeel());
            //    this.ViewInfo.GInfo.AddGraphics(e.Graphics, this.ScaleDPI);
            //    if (this.ViewInfo.IsPaintAppearanceDirty)
            //        this.ViewInfo.UpdatePaintAppearance();
            //    if (!string.IsNullOrEmpty(this.Text) && this.ViewInfo.TextRect.Width == 0)
            //        using (SolidBrush brush = new SolidBrush(this.ForeColor))
            //            e.Graphics.DrawString(this.Text, this.Font, brush, cache.x,this.GetTextBaselineY());

            //    this.Painter.Draw(new ControlGraphicsInfoArgs((BaseControlViewInfo)this.ViewInfo, cache, this.ViewInfo.Bounds));
            //    this.ViewInfo.GInfo.ReleaseGraphics();
            //}

            //float x = 0;
            //float y = 0;
            //using (SolidBrush brush = new SolidBrush(this.ForeColor))
            //{
            //    switch (this.Appearance.TextOptions.HAlignment)
            //    {
            //        case HorzAlignment.Default:
            //            x += Padding.Left;
            //            break;
            //        case HorzAlignment.Near:
            //            x += Padding.Left;
            //            break;
            //        case HorzAlignment.Center:
            //            x += ((float)this.ClientRectangle.Width / 2);
            //            break;
            //        case HorzAlignment.Far:
            //            x += (this.ClientRectangle.Width - Padding.Right);
            //            break;
            //        default:
            //            x += Padding.Left;
            //            break;
            //    }

            //    switch (this.Appearance.TextOptions.VAlignment)
            //    {
            //        case VertAlignment.Default:
            //            y += Padding.Top;
            //            break;
            //        case VertAlignment.Top:
            //            y += Padding.Top;
            //            break;
            //        case VertAlignment.Center:
            //            y += ((float)e.ClipRectangle.Height / 2);
            //            break;
            //        case VertAlignment.Bottom:
            //            y += (e.ClipRectangle.Height - Padding.Bottom);
            //            break;
            //        default:
            //            y += Padding.Top;
            //            break;
            //    }

            //    e.Graphics.DrawString(this.Text, this.Font, brush, x, y);
            //}

            if (RTCUseCustomBorder)
            {
                if (RTCBorderTopVisible)
                {
                    using (var brush = new SolidBrush(RTCBorderTopColor))
                    using (var pen = new Pen(brush) { DashStyle = RTCBorderTopDashStyle })
                    {
                        e.Graphics.DrawLine(pen, new Point(RTCBorderLeftPadding, RTCBorderTopPadding),
                            new Point(e.ClipRectangle.Width - RTCBorderRightPadding, RTCBorderTopPadding));
                    }
                }

                if (RTCBorderBottomVisible)
                {
                    using (var brush = new SolidBrush(RTCBorderBottomColor))
                    using (var pen = new Pen(brush) { DashStyle = RTCBorderBottomDashStyle })
                    {
                        e.Graphics.DrawLine(pen, new Point(RTCBorderLeftPadding, e.ClipRectangle.Height - RTCBorderBottomPadding),
                            new Point(e.ClipRectangle.Width - RTCBorderRightPadding, e.ClipRectangle.Height - RTCBorderBottomPadding));
                    }
                }

                if (RTCBorderLeftVisible)
                {
                    using (var brush = new SolidBrush(RTCBorderLeftColor))
                    using (var pen = new Pen(brush) { DashStyle = RTCBorderLeftDashStyle })
                    {
                        e.Graphics.DrawLine(pen, new Point(RTCBorderLeftPadding, RTCBorderTopPadding),
                            new Point(RTCBorderLeftPadding, e.ClipRectangle.Height - RTCBorderBottomPadding));
                    }
                }

                if (RTCBorderRightVisible)
                {
                    using (var brush = new SolidBrush(RTCBorderRightColor))
                    using (var pen = new Pen(brush) { DashStyle = RTCBorderRightDashStyle })
                    {
                        e.Graphics.DrawLine(pen, new Point(e.ClipRectangle.Width - RTCBorderRightPadding, RTCBorderTopPadding),
                            new Point(RTCBorderLeftPadding, e.ClipRectangle.Width - RTCBorderRightPadding));
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the 'true' operation. </summary>
        ///
        /// <remarks>   DATRUONG, 20/08/2021. </remarks>
        ///
        /// <param name="_ValueText">   The value text. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RunTrue(string _ValueText)
        {
            this.Text = _ValueText;
            this.ForeColor = Color.Blue;
            this.Visible = true;
            _Timer.Enabled = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the 'fail' operation. </summary>
        ///
        /// <remarks>   DATRUONG, 20/08/2021. </remarks>
        ///
        /// <param name="_ValueText">   The value text. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RunFail(string _ValueText)
        {
            this.Text = _ValueText;
            this.ForeColor = Color.Red;
            this.Visible = true;
            _Timer.Enabled = true;
        }
    }
}

