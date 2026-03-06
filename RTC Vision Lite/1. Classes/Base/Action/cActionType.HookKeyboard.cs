using RTCConst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        internal List<int> keys = null;
        internal void Run_HookKeyboard()
        {
            Passed.rtcValue = true;
            CtrlKey.rtcValue = false;
            ShiftKey.rtcValue = false;
            AltKey.rtcValue = false;
            WindowKey.rtcValue = false;
            KeyValues.rtcValue = new List<string>();
            if (GlobVar.IsSimulatorMode)
                KeyValues.rtcValue = SimulatorValue.rtcValue;
            else if (keys != null && keys.Count > 0)
            {
                foreach (int key in keys)
                {
                    if (key == (int)Keys.LControlKey || key == (int)Keys.RControlKey)
                        CtrlKey.rtcValue = true;
                    else if (key == (int)Keys.LMenu || key == (int)Keys.RMenu)
                        AltKey.rtcValue = true;
                    else if (key == (int)Keys.LShiftKey || key == (int)Keys.RShiftKey)
                        ShiftKey.rtcValue = true;
                    else if (key == (int)Keys.LWin || key == (int)Keys.RWin)
                        WindowKey.rtcValue = true;
                    else
                    {
                        switch (key)
                        {
                            case (int)Keys.Enter:
                                {
                                    KeyValues.rtcValue.Add(cKeyBoard.Enter);
                                    break;
                                }
                            case (int)Keys.Back:
                                {
                                    KeyValues.rtcValue.Add(Keys.Back.ToString());
                                    break;
                                }
                            case (int)Keys.Space:
                                {
                                    KeyValues.rtcValue.Add(Keys.Space.ToString());
                                    break;
                                }
                            case (int)Keys.F1:
                                {
                                    KeyValues.rtcValue.Add(Keys.F1.ToString());
                                    break;
                                }
                            case (int)Keys.F2:
                                {
                                    KeyValues.rtcValue.Add(Keys.F2.ToString());
                                    break;
                                }
                            case (int)Keys.F3:
                                {
                                    KeyValues.rtcValue.Add(Keys.F3.ToString());
                                    break;
                                }
                            case (int)Keys.F4:
                                {
                                    KeyValues.rtcValue.Add(Keys.F4.ToString());
                                    break;
                                }
                            case (int)Keys.F5:
                                {
                                    KeyValues.rtcValue.Add(Keys.F5.ToString());
                                    break;
                                }
                            case (int)Keys.F6:
                                {
                                    KeyValues.rtcValue.Add(Keys.F6.ToString());
                                    break;
                                }
                            case (int)Keys.F7:
                                {
                                    KeyValues.rtcValue.Add(Keys.F7.ToString());
                                    break;
                                }
                            case (int)Keys.F8:
                                {
                                    KeyValues.rtcValue.Add(Keys.F8.ToString());
                                    break;
                                }
                            case (int)Keys.F9:
                                {
                                    KeyValues.rtcValue.Add(Keys.F9.ToString());
                                    break;
                                }
                            case (int)Keys.F10:
                                {
                                    KeyValues.rtcValue.Add(Keys.F10.ToString());
                                    break;
                                }
                            case (int)Keys.F11:
                                {
                                    KeyValues.rtcValue.Add(Keys.F11.ToString());
                                    break;
                                }
                            case (int)Keys.F12:
                                {
                                    KeyValues.rtcValue.Add(Keys.F12.ToString());
                                    break;
                                }
                            case (int)Keys.Insert:
                                {
                                    KeyValues.rtcValue.Add(Keys.Insert.ToString());
                                    break;
                                }
                            case (int)Keys.Pause:
                                {
                                    KeyValues.rtcValue.Add(Keys.Pause.ToString());
                                    break;
                                }
                            case (int)Keys.Home:
                                {
                                    KeyValues.rtcValue.Add(Keys.Home.ToString());
                                    break;
                                }
                            case (int)Keys.PageUp:
                                {
                                    KeyValues.rtcValue.Add(Keys.PageUp.ToString());
                                    break;
                                }
                            case (int)Keys.PageDown:
                                {
                                    KeyValues.rtcValue.Add(Keys.PageDown.ToString());
                                    break;
                                }
                            case (int)Keys.Delete:
                                {
                                    KeyValues.rtcValue.Add(Keys.Delete.ToString());
                                    break;
                                }
                            case (int)Keys.End:
                                {
                                    KeyValues.rtcValue.Add(Keys.End.ToString());
                                    break;
                                }
                            case (int)Keys.PrintScreen:
                                {
                                    KeyValues.rtcValue.Add(Keys.PrintScreen.ToString());
                                    break;
                                }
                            case (int)Keys.Clear:
                                {
                                    KeyValues.rtcValue.Add(Keys.Clear.ToString());
                                    break;
                                }
                            case (int)Keys.OemClear:
                                {
                                    KeyValues.rtcValue.Add(Keys.OemClear.ToString());
                                    break;
                                }
                            case (int)Keys.Print:
                                {
                                    KeyValues.rtcValue.Add(Keys.Print.ToString());
                                    break;
                                }
                            case (int)Keys.NumLock:
                                {
                                    KeyValues.rtcValue.Add(Keys.NumLock.ToString());
                                    break;
                                }
                            case (int)Keys.CapsLock:
                                {
                                    KeyValues.rtcValue.Add(Keys.CapsLock.ToString());
                                    break;
                                }
                            case (int)Keys.Tab:
                                {
                                    KeyValues.rtcValue.Add(Keys.Tab.ToString());
                                    break;
                                }
                            case (int)Keys.Escape:
                                {
                                    KeyValues.rtcValue.Add(Keys.Print.ToString());
                                    break;
                                }
                            case (int)Keys.NumPad0:
                                {
                                    KeyValues.rtcValue.Add("0");
                                    break;
                                }
                            case (int)Keys.NumPad1:
                                {
                                    KeyValues.rtcValue.Add("1");
                                    break;
                                }
                            case (int)Keys.NumPad2:
                                {
                                    KeyValues.rtcValue.Add("2");
                                    break;
                                }
                            case (int)Keys.NumPad3:
                                {
                                    KeyValues.rtcValue.Add("3");
                                    break;
                                }
                            case (int)Keys.NumPad4:
                                {
                                    KeyValues.rtcValue.Add("4");
                                    break;
                                }
                            case (int)Keys.NumPad5:
                                {
                                    KeyValues.rtcValue.Add("5");
                                    break;
                                }
                            case (int)Keys.NumPad6:
                                {
                                    KeyValues.rtcValue.Add("6");
                                    break;
                                }
                            case (int)Keys.NumPad7:
                                {
                                    KeyValues.rtcValue.Add("7");
                                    break;
                                }
                            case (int)Keys.NumPad8:
                                {
                                    KeyValues.rtcValue.Add("8");
                                    break;
                                }
                            case (int)Keys.NumPad9:
                                {
                                    KeyValues.rtcValue.Add("9");
                                    break;
                                }
                            case (int)Keys.Add:
                                {
                                    KeyValues.rtcValue.Add("+");
                                    break;
                                }
                            case (int)Keys.Subtract:
                                {
                                    KeyValues.rtcValue.Add("-");
                                    break;
                                }
                            case (int)Keys.Divide:
                                {
                                    KeyValues.rtcValue.Add("/");
                                    break;
                                }
                            case (int)Keys.Multiply:
                                {
                                    KeyValues.rtcValue.Add("*");
                                    break;
                                }
                            case (int)Keys.Play:
                                {
                                    KeyValues.rtcValue.Add(Keys.Play.ToString());
                                    break;
                                }
                            case (int)Keys.Zoom:
                                {
                                    KeyValues.rtcValue.Add(Keys.Zoom.ToString());
                                    break;
                                }
                            case (int)Keys.VolumeDown:
                                {
                                    KeyValues.rtcValue.Add(Keys.VolumeDown.ToString());
                                    break;
                                }
                            case (int)Keys.VolumeUp:
                                {
                                    KeyValues.rtcValue.Add(Keys.VolumeUp.ToString());
                                    break;
                                }
                            case (int)Keys.Left:
                                {
                                    KeyValues.rtcValue.Add(Keys.Left.ToString());
                                    break;
                                }
                            case (int)Keys.Right:
                                {
                                    KeyValues.rtcValue.Add(Keys.Right.ToString());
                                    break;
                                }
                            case (int)Keys.Up:
                                {
                                    KeyValues.rtcValue.Add(Keys.Up.ToString());
                                    break;
                                }
                            case (int)Keys.Down:
                                {
                                    KeyValues.rtcValue.Add(Keys.Down.ToString());
                                    break;
                                }
                            case (int)Keys.Apps:
                                {
                                    KeyValues.rtcValue.Add(Keys.Apps.ToString());
                                    break;
                                }

                            default:
                                {
                                    KeyValues.rtcValue.Add(((char)key).ToString());
                                    break;
                                }
                        }
                        KeyValues.rtcValue = KeyValues.rtcValue;
                    }
                }
            }
        }
    }
}
