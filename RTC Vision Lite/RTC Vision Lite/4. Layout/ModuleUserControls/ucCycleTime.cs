using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Layout
{
    public partial class ucCycleTime : UserControl
    {
        public ucCycleTime()
        {
            InitializeComponent();
        }
        private Stopwatch _stopwatch;
        public void Reset()
        {
            if (lblCycleTime.InvokeRequired)
                lblCycleTime.Invoke((MethodInvoker)delegate
                {
                    lblCycleTime.Text = "-----";
                });
            else
                lblCycleTime.Text = "-----";
        }
        public void SetTime(double elapsedMilliseconds)
        {
            if (lblCycleTime.InvokeRequired)
                lblCycleTime.Invoke((MethodInvoker)delegate
                {
                    lblCycleTime.Text = elapsedMilliseconds / 1000 + "(s)";
                });
            else
                lblCycleTime.Text = elapsedMilliseconds / 1000 + "(s)";
        }
        public void Start()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }
        public void Stop()
        {
            Reset();
            if (_stopwatch != null)
            {
                _stopwatch.Stop();
                if (lblCycleTime.InvokeRequired)
                    lblCycleTime.Invoke((MethodInvoker)delegate
                    {
                        lblCycleTime.Text = _stopwatch.ElapsedMilliseconds / 1000 + "(s)";
                    });
                else
                    lblCycleTime.Text = _stopwatch.ElapsedMilliseconds / 1000 + "(s)";
            }
            _stopwatch = null;
        }
    }
}
