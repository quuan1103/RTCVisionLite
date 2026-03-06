using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmASCIITable : FrmBase
    {
        public FrmASCIITable()
        {
            InitializeComponent();
            ucFooterForm.OnCancelClick -= btnCancelClickEvents;
            ucFooterForm.OnCancelClick += btnCancelClickEvents;
        }
        private TextBox _RTCTexEditSetValue = null;

        public TextBox RTCTexEditSetValue
        {
            get { return _RTCTexEditSetValue; }
            set
            {
                _RTCTexEditSetValue = value;
            }
        }
        private void FrmASCIITable_Load(object sender, EventArgs e)
        {
            try
            {
                tlASCII.BeginUpdate();
                tlASCII.ClearObjects();
                int _iRow = 1;
                int _iColHex = 0;
                int _iColASCII = 1;
                bool _bFinishAddRow = false;
                if (CommonData.ASCIITable != null)
                {
                    foreach (DataRow _Row in CommonData.ASCIITable.Rows)
                    {
                        if (_bFinishAddRow)
                        {

                            tlASCII.GetColumn(_iColHex).PutValue(tlASCII.Objects.Cast<ASC>().ToList()[_iRow - 1], _Row[cColName.HEX]);
                            tlASCII.GetColumn(_iColASCII).PutValue(tlASCII.Objects.Cast<ASC>().ToList()[_iRow - 1], _Row[cColName.ASCII]);
                        }
                        else
                        {
                            ASC newNode = new ASC();
                            newNode.Hex = _Row[cColName.HEX].ToString();
                            newNode.ASCII = _Row[cColName.ASCII].ToString();
                            tlASCII.AddObject(newNode);
                        }
                        _iRow += 1;
                        if (_iRow > 32)
                        {
                            _bFinishAddRow = true;
                            _iRow = 1;
                            _iColHex += 2;
                            _iColASCII += 2;
                        }

                    }
                }
            }
            finally
            {
                tlASCII.EndUpdate();
            }
        }
        public class ASC
        {
            public string Hex { get; set; }
            public string Hex2 { get; set; }
            public string Hex3 { get; set; }
            public string Hex4 { get; set; }
            public string Hex5 { get; set; }
            public string Hex6 { get; set; }
            public string Hex7 { get; set; }
            public string Hex8 { get; set; }

            public string ASCII { get; set; }

            public string ASCII2 { get; set; }
            public string ASCII3 { get; set; }
            public string ASCII4 { get; set; }
            public string ASCII5 { get; set; }
            public string ASCII6 { get; set; }
            public string ASCII7 { get; set; }
            public string ASCII8 { get; set; }



        }


        private void btnCancelClickEvents(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tlASCII_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (_RTCTexEditSetValue == null || CommonData.ASCIITable==null) return;

            if (e.Model == null || e.Column == null) return;

            string _Hex = string.Empty;

            int _iCol = e.Column.Index;
            if (_iCol % 2 == 0)
                _Hex = e.Column.GetValue(e.Model).ToString();
            else
                _Hex = tlASCII.GetColumn(_iCol -1).GetValue(e.Model).ToString();

            if (_Hex!=string.Empty)
            {
                DataRow _RowASCII = CommonData.ASCIITable.Rows.Find(_Hex);
                if (_RowASCII != null)
                {
                    string sValue = _RowASCII[cColName.Value].ToString();
                    if (sValue.StartsWith(cGroupingBracketValues.SquareBracketB) && sValue.EndsWith(cGroupingBracketValues.SquareBracketE))
                    {
                        _RTCTexEditSetValue.Text = _RTCTexEditSetValue.Text + sValue;
                        txtCustom.Text = txtCustom.Text + sValue;
                        textBox1.Text = textBox1.Text + sValue;
                    }    
                    else
                    {
                        _RTCTexEditSetValue.Text = _RTCTexEditSetValue.Text + (char)GlobVar.DicASCII[_Hex];
                        txtCustom.Text = txtCustom.Text + (char)GlobVar.DicASCII[_Hex];
                        textBox1.Text = textBox1.Text + (char)GlobVar.DicASCII[_Hex];

                    }


                }
            }
        }
    }
}
