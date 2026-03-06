using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCEnums;
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
    public delegate void ConfigureInput_DataChangedEvent(SStringBuilderItem SBItem);
    public partial class ucConfigureInputBase : UserControl
    {
        public ucConfigureInputBase()
        {
            InitializeComponent();
        }
        public ConfigureInput_DataChangedEvent OnConfigureInputDataChanged;

        #region PROPERTIES
        private string _RTCCaption;

        public string RTCCaption
        {
            get { return groupControl.Text; }
            set
            {
                _RTCCaption = value;
                groupControl.Text = _RTCCaption;
            }
        }

        private SStringBuilderItem _RTCSBItem;

        public SStringBuilderItem RTCSBItem
        {
            get { return _RTCSBItem; }
            set
            {
                _RTCSBItem = value;
                BindingDataToControl();
                LayoutControls(true);
            }
        }

        #endregion

        #region FUNCTIONS

        #region EVENTS

        private void RaiseEventDataChanged()
        {
            if (OnConfigureInputDataChanged != null)
                OnConfigureInputDataChanged(_RTCSBItem);
        }
        private void TextBox_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (GlobVar.LockEvents) return;
                TextBox textedit = (TextBox)sender;
                if (textedit.Text == null || textedit.Text.Trim() == "")
                {
                    errProvider.SetError(textedit, cMessageContent.War_ToolNameIsEmpty);
                    return;
                }

                if (!textedit.CausesValidation) return;

                PropertyInfo propertyInfo = _RTCSBItem.GetType().GetProperty(textedit.Name);
                if (propertyInfo == null) { return; }
                propertyInfo.SetValue(_RTCSBItem, textedit.Text);
                RaiseEventDataChanged();
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }

        public void ComboboxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (GlobVar.LockEvents) return;
                ComboBox combo = (ComboBox)sender;

                if (!combo.CausesValidation) return;

                PropertyInfo propertyInfo = _RTCSBItem.GetType().GetProperty(combo.Name);
                if (propertyInfo == null) { return; }
                propertyInfo.SetValue(_RTCSBItem, combo.SelectedIndex);
                RaiseEventDataChanged();
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        public void CheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (GlobVar.LockEvents) return;
                CheckBox checkedit = (CheckBox)sender;

                if (!checkedit.CausesValidation) return;

                PropertyInfo propertyInfo = _RTCSBItem.GetType().GetProperty(checkedit.Name);
                if (propertyInfo == null) { return; }
                propertyInfo.SetValue(_RTCSBItem, checkedit.Checked);
                RaiseEventDataChanged();
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        public void NumbericUpdown_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (GlobVar.LockEvents) return;
                NumericUpDown spinedit = (NumericUpDown)sender;

                if (!spinedit.CausesValidation) return;

                PropertyInfo propertyInfo = _RTCSBItem.GetType().GetProperty(spinedit.Name);
                if (propertyInfo == null) { return; }
                propertyInfo.SetValue(_RTCSBItem, int.Parse(spinedit.Value.ToString()));
                RaiseEventDataChanged();
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        private void InputDelimiterValueChanged(object sender)
        {
            //_RTCSBItem.ElementDelimiter = ((ucInputDelimiterStringBulderItem)sender).RTCSBItem.ElementDelimiter;
            RaiseEventDataChanged();
        }
        private void NormalEditControl_ValueChangedEvents(object sender, EventArgs e)
        {
            LayoutControls();
            string PropertyName = string.Empty;
            switch (sender.GetType().Name)
            {
                case nameof(TextBox):
                    TextBox_EditValueChanged(sender, e);
                    break;
                case nameof(RadioButton):
                    //RadioGroup_SelectedIndexChanged(sender, e, out PropertyName);
                    break;
                case nameof(CheckBox):
                    CheckEdit_EditValueChanged(sender, e);
                    break;
                case nameof(NumericUpDown):
                    NumbericUpdown_EditValueChanged(sender, e);
                    break;
                //case nameof(RangeTrackBarControl):
                //    //RangeTrackBarControl_EditValueChanged(sender, e, out PropertyName);
                //    break;
                case nameof(ComboBox):
                    ComboboxEdit_SelectedIndexChanged(sender, e);
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void BinddingDataToControls_TextEdit()
        {
            object propertyInfo = null;
            var c = GlobFuncs.GetAllControls(this, typeof(TextBox));
            if (c != null && c.Count() > 0)
            {
                TextBox txt = null;
                foreach (Control item in c)
                {
                    txt = (TextBox)item;
                    string PropertyName = txt.Name;
                    txt.TextChanged -= NormalEditControl_ValueChangedEvents;
                    if (_RTCSBItem == null) { continue; }
                    var c1 = _RTCSBItem.GetType().GetProperties().Where(x => x.Name == PropertyName);
                    if (c1 == null || c1.Count() <= 0) { continue; }
                    propertyInfo = _RTCSBItem.GetType().GetProperty(PropertyName).GetValue(_RTCSBItem, null);
                    if (propertyInfo == null) { continue; }
                    txt.Text = propertyInfo.ToString();
                    txt.TextChanged += NormalEditControl_ValueChangedEvents;
                }
            }
        }
        private void BinddingDataToControls_ComboboxEdit()
        {
            object propertyInfo = null;
            var c = GlobFuncs.GetAllControls(this, typeof(ComboBox));
            if (c != null && c.Count() > 0)
            {
                ComboBox combo = null;
                foreach (Control item in c)
                {
                    combo = (ComboBox)item;
                    combo.SelectedIndexChanged -= NormalEditControl_ValueChangedEvents;

                    if (_RTCSBItem == null) { continue; }
                    var c1 = _RTCSBItem.GetType().GetProperties().Where(x => x.Name == combo.Name);
                    if (c1 == null || c1.Count() <= 0) { continue; }

                    propertyInfo = _RTCSBItem.GetType().GetProperty(combo.Name).GetValue(_RTCSBItem, null);
                    if (propertyInfo == null) { continue; }
                    combo.SelectedIndex = combo.Items.IndexOf(propertyInfo.ToString());
                    combo.SelectedIndexChanged += NormalEditControl_ValueChangedEvents;
                }
            }
        }
        private void BinddingDataToControls_CheckEdit()
        {
            object propertyInfo = null;
            var c = GlobFuncs.GetAllControls(this, typeof(CheckBox));
            if (c != null && c.Count() > 0)
            {
                CheckBox checkedit = null;
                foreach (Control item in c)
                {
                    checkedit = (CheckBox)item;
                    checkedit.CheckedChanged -= NormalEditControl_ValueChangedEvents;

                    if (_RTCSBItem == null) { continue; }
                    var c1 = _RTCSBItem.GetType().GetProperties().Where(x => x.Name == checkedit.Name);
                    if (c1 == null || c1.Count() <= 0) { continue; }
                    propertyInfo = _RTCSBItem.GetType().GetProperty(checkedit.Name).GetValue(_RTCSBItem, null);
                    if (propertyInfo == null) { continue; }
                    checkedit.Checked = (bool)propertyInfo;
                    checkedit.CheckedChanged += NormalEditControl_ValueChangedEvents;
                }
            }
        }
        private void BinddingDataToControls_SpinEdit()
        {
            object propertyInfo = null;
            var c = GlobFuncs.GetAllControls(this, typeof(NumericUpDown));
            if (c != null && c.Count() > 0)
            {
                NumericUpDown spinedit = null;
                foreach (Control item in c)
                {
                    spinedit = (NumericUpDown)item;
                    spinedit.ValueChanged -= NormalEditControl_ValueChangedEvents;

                    if (_RTCSBItem == null) { continue; }
                    var c1 = _RTCSBItem.GetType().GetProperties().Where(x => x.Name == spinedit.Name);
                    if (c1 == null || c1.Count() <= 0) { continue; }
                    propertyInfo = _RTCSBItem.GetType().GetProperty(spinedit.Name).GetValue(_RTCSBItem, null);
                    if (propertyInfo == null) { continue; }
                    spinedit.Value = GlobFuncs.Object2Int(propertyInfo);
                    spinedit.ValueChanged += NormalEditControl_ValueChangedEvents;
                }
            }
        }

        private void OnTrallingTextValueChangedEvents(object sender)
        {
            _RTCSBItem.Tralling = ((ucTrallingText)sender).RTCSBItem.Tralling;
            RaiseEventDataChanged();
        }
        private void OnLeadingTextValueChangedEvents(object sender)
        {
            _RTCSBItem.Leading = ((ucLeadingText)sender).RTCSBItem.Leading;
            RaiseEventDataChanged();
        }

        private void BindingDataToControls_Tralling()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucTrallingText));
            if (c != null && c.Any())
            {
                ucTrallingText trallingText = null;
                foreach (Control item in c)
                {
                    trallingText = (ucTrallingText)item;
                    trallingText.OnTrallingTextValueChangedEvents -= OnTrallingTextValueChangedEvents;

                    if (_RTCSBItem == null) { continue; }
                    trallingText.RTCSBItem = _RTCSBItem;
                    trallingText.OnTrallingTextValueChangedEvents += OnTrallingTextValueChangedEvents;
                }
            }
        }
        private void BindingDataToControls_Leading()
        {
            var c = GlobFuncs.GetAllUserControl(this, typeof(ucLeadingText));
            if (c != null && c.Any())
            {
                ucLeadingText leadingText = null;
                foreach (Control item in c)
                {
                    leadingText = (ucLeadingText)item;
                    leadingText.OnLeadingTextValueChangedEvents -= OnLeadingTextValueChangedEvents;

                    if (_RTCSBItem == null) { continue; }
                    leadingText.RTCSBItem = _RTCSBItem;
                    leadingText.OnLeadingTextValueChangedEvents += OnLeadingTextValueChangedEvents;
                }
            }
        }
        private void BindingDataToControls_Delimiter()
        {
            //var c = GlobFuncs.GetAllUserControl(this, typeof(ucInputDelimiterStringBulderItem));
            //if (c != null && c.Any())
            //{
            //    ucInputDelimiterStringBulderItem delimiter = null;
            //    foreach (Control item in c)
            //    {
            //        delimiter = (ucInputDelimiterStringBulderItem)item;
            //        delimiter.OnInputDelimiterValueChangedEvents -= InputDelimiterValueChanged;

            //        if (_RTCSBItem == null) { continue; }
            //        delimiter.RTCSBItem = _RTCSBItem;
            //        delimiter.OnInputDelimiterValueChangedEvents += InputDelimiterValueChanged;
            //    }
            //}
        }
        private void BindingDataToControl()
        {
            try
            {
                GlobVar.LockEvents = true;

                BinddingDataToControls_TextEdit();
                BinddingDataToControls_ComboboxEdit();
                BinddingDataToControls_CheckEdit();
                BinddingDataToControls_SpinEdit();
                BindingDataToControls_Delimiter();
                BindingDataToControls_Leading();
                BindingDataToControls_Tralling();
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        private void LayoutControls_DisableAll()
        {
            //var c = GlobFuncs.GetAllControls(this);
            //if (c != null && c.Count() > 0)
            //    foreach (Control item in c)
            //        item.Enabled = false;
        }
        private void LayoutControls_EnableAll()
        {
            //var c = GlobFuncs.GetAllControls(this);
            //if (c != null && c.Count() > 0)
            //    foreach (Control item in c)
            //        item.Enabled = true;
        }
        public void LayoutControls(bool _DisableAll = false)
        {
            //Disable toàn bộ control
            if (_DisableAll) LayoutControls_DisableAll();
            if (_RTCSBItem == null) return;
            LayoutControls_EnableAll();
            switch (_RTCSBItem.ValueStyle)
            {
                case EHTupleStyle.Rectangle:
                    ((ucConfigureRectangleInput)this).MiniumLength.Enabled = ((ucConfigureRectangleInput)this).UseMiniumLength.Checked;
                    ((ucConfigureRectangleInput)this).PadWith.Enabled = ((ucConfigureRectangleInput)this).UseMiniumLength.Checked;
                    break;
                case EHTupleStyle.RectangleList:
                    ((ucConfigureRectangleListInput)this).MiniumLength.Enabled = ((ucConfigureRectangleListInput)this).UseMiniumLength.Checked;
                    ((ucConfigureRectangleListInput)this).PadWith.Enabled = ((ucConfigureRectangleListInput)this).UseMiniumLength.Checked;
                    ((ucConfigureRectangleListInput)this).ElementDelimiter.LayoutControls();
                    break;
                case EHTupleStyle.Origin:
                    ((ucConfigureOriginInput)this).MaximumLength.Enabled = ((ucConfigureOriginInput)this).UseLimitInput.Checked;
                    ((ucConfigureOriginInput)this).MiniumLength.Enabled = ((ucConfigureOriginInput)this).UseMiniumLength.Checked;
                    ((ucConfigureOriginInput)this).PadWith.Enabled = ((ucConfigureOriginInput)this).UseMiniumLength.Checked;
                    break;
                case EHTupleStyle.OriginList:
                    ((ucConfigureOriginListInput)this).MiniumLength.Enabled = ((ucConfigureOriginListInput)this).UseMiniumLength.Checked;
                    ((ucConfigureOriginListInput)this).PadWith.Enabled = ((ucConfigureOriginListInput)this).UseMiniumLength.Checked;
                    ((ucConfigureOriginListInput)this).ElementDelimiter.LayoutControls();
                    break;
                case EHTupleStyle.BooleanList:
                    ((ucConfigureBooleanListInput)this).ElementDelimiter.LayoutControls();
                    break;
                case EHTupleStyle.Integer:
                    ((ucConfigureIntegerInput)this).MiniumLength.Enabled = ((ucConfigureIntegerInput)this).UseMiniumLength.Checked;
                    ((ucConfigureIntegerInput)this).PadWith.Enabled = ((ucConfigureIntegerInput)this).UseMiniumLength.Checked;
                    break;
                case EHTupleStyle.IntegerList:
                    ((ucConfigureIntegerListInput)this).MiniumLength.Enabled = ((ucConfigureIntegerListInput)this).UseMiniumLength.Checked;
                    ((ucConfigureIntegerListInput)this).PadWith.Enabled = ((ucConfigureIntegerListInput)this).UseMiniumLength.Checked;
                    ((ucConfigureIntegerListInput)this).ElementDelimiter.LayoutControls();
                    break;
                case EHTupleStyle.String:
                    ((ucConfigureStringInput)this).MaximumLength.Enabled = ((ucConfigureStringInput)this).UseLimitInput.Checked;
                    ((ucConfigureStringInput)this).MinimumLength.Enabled = ((ucConfigureStringInput)this).UsePadOutput.Checked;
                    ((ucConfigureStringInput)this).PadWith.Enabled = ((ucConfigureStringInput)this).UsePadOutput.Checked;
                    break;
                case EHTupleStyle.StringList:
                    ((ucConfigureStringListInput)this).MaxiumLength.Enabled = ((ucConfigureStringListInput)this).UseLimitInput.Checked;
                    ((ucConfigureStringListInput)this).MiniumLength.Enabled = ((ucConfigureStringListInput)this).UsePadOutput.Checked;
                    ((ucConfigureStringListInput)this).PadWith.Enabled = ((ucConfigureStringListInput)this).UsePadOutput.Checked;
                    ((ucConfigureStringListInput)this).ElementDelimiter.LayoutControls();
                    break;
                case EHTupleStyle.DateAndTime:
                    ((ucConfigureDateTimeInput)this).DecimalPlaces.Enabled = ((ucConfigureDateTimeInput)this).UseDecimalPlaces.Checked;
                    break;
                case EHTupleStyle.Point:
                    ((ucConfigurePointInput)this).MiniumLength.Enabled = ((ucConfigurePointInput)this).UseMiniumLength.Checked;
                    ((ucConfigurePointInput)this).PadWith.Enabled = ((ucConfigurePointInput)this).UseMiniumLength.Checked;
                    break;
                case EHTupleStyle.PointList:
                    ((ucConfigurePointListInput)this).MiniumLength.Enabled = ((ucConfigurePointListInput)this).UseMiniumLength.Checked;
                    ((ucConfigurePointListInput)this).PadWith.Enabled = ((ucConfigurePointListInput)this).UseMiniumLength.Checked;
                    ((ucConfigurePointListInput)this).ElementDelimiter.LayoutControls();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
