using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    /// <summary>
    /// Class for displaying a splash form
    /// </summary>
    public class Splasher
    {
        private readonly Form _splashForm;
        /// <summary>
        /// Your application name.
        /// </summary>
        public string Caption { get => _splashForm.Name; set => _splashForm.Name = value; }
        /// <summary>
        /// Your application version.
        /// </summary>
        public string Description { get => (string)_splashForm.Tag; set => _splashForm.Tag = value; }

        /// <summary>
        /// Display the ApplicationName in the normal splash form.
        /// </summary>
        /// <param name="appName">Your application name</param>
        public Splasher(string appName)
        {
            _splashForm = new SplashForm();
            _splashForm.Name = appName;
        }

        /// <summary>
        /// Display the ApplicationName in the normal splash form.
        /// </summary>
        /// <param name="appName">Your application name</param>
        /// <param name="appVersion">Your application version</param>
        public Splasher(string appName, string appVersion)
        {
            _splashForm = new SplashForm()
            {
                Name = appName,
                Tag = appVersion
            };
        }

        /// <summary>
        /// Displays the form you created.
        /// </summary>
        /// <param name="yourSplashForm"></param>
        public Splasher(Form yourSplashForm)
        {
            _splashForm = yourSplashForm;
        }

        /// <summary>
        /// Display the splash form in a another thread.
        /// </summary>
        public async Task ShowAsync()
        {
            Task.Run(() => { Application.Run(_splashForm); });
        }

        /// <summary>
        /// Close the splash form. Note: Activate() your form after this method!
        /// </summary>
        public void Close()
        {
            if (_splashForm.InvokeRequired)
                _splashForm.Invoke((MethodInvoker)(() => _splashForm.Close()));
            else
                _splashForm.Close();
        }
    }
    public class SplashScreen
    {
        private readonly frmSplashScreen _splashForm;
        /// <summary>
        /// Your application name.
        /// </summary>

        public SplashScreen()
        {
            _splashForm = new frmSplashScreen();
        }
        public string Status
        {
            set {
                if (_splashForm.lblStatus.IsHandleCreated)
                {
                    if (_splashForm.lblStatus.InvokeRequired)
                    {
                        _splashForm.lblStatus.Invoke(new Action(() =>
                        {
                            _splashForm.lblStatus.Text = "Đang tải dữ liệu...";
                        }));
                    }
                    else
                    {
                        _splashForm.lblStatus.Text = "Đang tải dữ liệu...";
                    }
                }
            }
        }

        public void Show()
        {
            Task.Run(() => { Application.Run(_splashForm); });
        }
        /// <summary>
        /// Close the splash form. Note: Activate() your form after this method!
        /// </summary>
        public void Close()
        {
            if (_splashForm.InvokeRequired)
                _splashForm.Invoke((MethodInvoker)(() => _splashForm.Close()));
            else
                _splashForm.Close();
        }
    }
}
