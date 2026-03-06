using BrightIdeasSoftware;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Properties;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
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

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucImageFilterActionDetail : RTC_Vision_Lite.UserControls.ucBaseActionDetail
    {
        public ucImageFilterActionDetail()
        {
            InitializeComponent();
            //LoadListFilterType();
        }
        public class MyImageFilterProperty
        {
            public Guid ID { get; set; }
            public string Delete { get; set; }
            public bool Active { get; set; }
            public int OrderNum { get; set; }
            public string FilterType { get; set; }
            public int MaskHeight { get; set; }
            public int MaskWidth { get; set; }
            public int Iterations { get; set; }
            public int InRangeOutputPixel { get; set; }
            public int OutRangeOutputPixel { get; set; }
            public double ScaleFactor { get; set; }
            public string GrayValue { get; set; }
            public Guid IDRefRegion { get; set; }
            public string PropNameRefRegion { get; set; }
            public string ThresholdRange { get; set; }
            public string Margin { get; set; }
            public bool Enable { get; set; }
            public string Result { get; set; }
        }
        ComboBox cbFilterType = new ComboBox();
        private void LoadListFilterType()
        {
            cbFilterType.Items.Clear();
            string sKey = nameof(Action.FilterType) + "|" + Enum.GetName(typeof(EActionTypes), Action.ActionType);
            string[] values = CommonData.GetPropertyValues(sKey).Split(cStrings.SepGDung);
            cbFilterType.Items.AddRange(values);
            cbFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        internal void LoadFilterProperty()
        {
            if (Action == null)
                return;
            try
            {
                GlobVar.LockEvents = true;
                LoadListFilterType();
                tlFilterList.SuspendLayout();
                tlFilterList.ClearObjects();
                if (Action != null && Action.ImageFilterProperty != null)
                {
                    var orderList = from filter in Action.ImageFilterProperty
                                    orderby filter.OrderNum
                                    select filter;
                    foreach (cImageFilterProperty filterProperty in orderList)
                    {
                        MyImageFilterProperty newNode = new MyImageFilterProperty();
                        newNode.ID = filterProperty.ID;
                        newNode.Delete = "Remove";
                        newNode.Active = filterProperty.Active;
                        newNode.OrderNum = filterProperty.OrderNum;
                        newNode.FilterType = filterProperty.FilterType;
                        newNode.MaskWidth = filterProperty.MaskWidth;
                        newNode.MaskHeight = filterProperty.MaskHeight;
                        newNode.Iterations = filterProperty.Iterations;
                        newNode.ThresholdRange = GlobFuncs.Ve2Str(filterProperty.ThresholdRange.rtcValue);
                        newNode.GrayValue = GlobFuncs.Ve2Str(filterProperty.GrayValue.rtcValue);
                        newNode.InRangeOutputPixel = filterProperty.InRangeOutputPixel;
                        newNode.OutRangeOutputPixel = filterProperty.OutRangeOutputPixel;
                        newNode.ScaleFactor = filterProperty.ScaleFactor;
                        newNode.Margin = filterProperty.Margin;
                        newNode.IDRefRegion = filterProperty.IDRefRegion;
                        newNode.Enable = true; ;
                        newNode.Result = cStrings.None;
                        tlFilterList.AddObject(newNode);
                    }    
                }
                List<MyImageFilterProperty> AllNode = tlFilterList.Objects.Cast<MyImageFilterProperty>().ToList();
                if (AllNode.Count > 0)
                    tlFilterList.FocusedObject = AllNode[0];
                GetRegionLinkText();
            }
            finally
            {
                tlFilterList.ResumeLayout();
                GlobVar.LockEvents = false;
            }
        }

        private void GetRegionLinkText()
        {
            lblRegionLink.Text = string.Empty;
            if (tlFilterList.FocusedObject != null)
            {
                cImageFilterProperty filterProperty = GetFilterPropertyByNode((MyImageFilterProperty)tlFilterList.FocusedObject);
                if (filterProperty != null && filterProperty.IDRefRegion != Guid.Empty)
                    lblRegionLink.Text = "Region Link: " + filterProperty.PropNameRefRegion + " [MainAction: " +
                                         GlobVar.GroupActions.Actions[filterProperty.IDRefRegion].Name.rtcValue + "]";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFilter();
        }
        private void AddFilter()
        {
            if (Action == null)
                return;
            if (Action.ImageFilterProperty == null)
                Action.ImageFilterProperty = new List<cImageFilterProperty>();
            cImageFilterProperty filterProperty = new cImageFilterProperty();
            // Thêm vào mảng
            Action.ImageFilterProperty.Add(filterProperty);
            // Lấy node hiện tại
            MyImageFilterProperty currentNode = (MyImageFilterProperty)tlFilterList.FocusedObject;
            // Thêm 1 node mới
            MyImageFilterProperty newNode = new MyImageFilterProperty();


            newNode.ID = filterProperty.ID;
            newNode.Delete = "Remove";
            newNode.Active = filterProperty.Active;
            newNode.OrderNum = filterProperty.OrderNum;
            newNode.FilterType = filterProperty.FilterType;
            newNode.MaskWidth = filterProperty.MaskWidth;
            newNode.MaskHeight = filterProperty.MaskHeight;
            newNode.Iterations = filterProperty.Iterations;
            newNode.ThresholdRange = GlobFuncs.Ve2Str(filterProperty.ThresholdRange.rtcValue);
            newNode.GrayValue = GlobFuncs.Ve2Str(filterProperty.GrayValue.rtcValue);
            newNode.InRangeOutputPixel = filterProperty.InRangeOutputPixel;
            newNode.OutRangeOutputPixel = filterProperty.OutRangeOutputPixel;
            newNode.ScaleFactor = filterProperty.ScaleFactor;
            newNode.Margin = filterProperty.Margin;
            newNode.IDRefRegion = filterProperty.IDRefRegion;
            newNode.Enable = true; ;
            newNode.Result = cStrings.None;

            tlFilterList.AddObject(newNode);
            //Dịch chuyển tới vị trí đang đứng
            //if (currentNode != null)
            //    tlFilterList.SetNodeIndex(newNode, tlFilterList.GetNodeIndex(currentNode) + 1);
            // Đánh lại STT
            RetypeOrderNumber();
            // Focus vào node mới
            tlFilterList.FocusedObject = newNode;
        }
        private void RetypeOrderNumber()
        {
            List<MyImageFilterProperty> lstImageFilterNode = tlFilterList.Objects.Cast<MyImageFilterProperty>().ToList();
            if (lstImageFilterNode != null && lstImageFilterNode.Count > 0)
            {
                int orderNumber = 0;
                foreach (MyImageFilterProperty node in lstImageFilterNode)
                {
                    cImageFilterProperty filterProperty = GetFilterPropertyByNode(node);
                    if (filterProperty != null)
                    {
                        orderNumber += 1;
                        filterProperty.OrderNum = orderNumber;
                        colOrderNum.PutValue(node, orderNumber);
                    }
                }
            }
        }
        private cImageFilterProperty GetFilterPropertyByNode(MyImageFilterProperty node)
        {
            if (Action == null || node == null)
                return null;
            string id = colID.GetValue(node)?.ToString();
            if (Guid.TryParse(id, out Guid guid))
                if (Action.ImageFilterProperty.FirstOrDefault(x => x.ID == guid) != null)
                    return Action.ImageFilterProperty.FirstOrDefault(x => x.ID == guid);

            return null;
        }

        private void tlFilterList_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.Column == colFilterType)
                return;

        }

        private void RemoveFilter()
        {
            if (Action == null || Action.ImageFilterProperty == null || tlFilterList.FocusedObject == null)
                return;
                cImageFilterProperty filterProperty = GetFilterPropertyByNode((MyImageFilterProperty)tlFilterList.FocusedObject);
                if (filterProperty == null) return;
                Action.ImageFilterProperty.Remove(filterProperty);
                tlFilterList.RemoveObject(tlFilterList.FocusedObject);
                RetypeOrderNumber();
            
        }

        private void tlFilterList_CellEditStarting(object sender, CellEditEventArgs e)
        {
            MyImageFilterProperty focusNode = (MyImageFilterProperty)tlFilterList.SelectedObject;
            if (focusNode == null)
                return;
            if (e.Column == this.colFilterType)
            {
                cbFilterType = new ComboBox();
                LoadListFilterType();
                cbFilterType.Bounds = e.CellBounds;
                cbFilterType.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
                cbFilterType.SelectedIndex = cbFilterType.Items.IndexOf(((MyImageFilterProperty)e.RowObject).FilterType);
                e.Control = cbFilterType;
                //e.NewValue = cbFilterType.SelectedItem;
            }
            else
            {
                e.Cancel = true;
                if (e.Column == this.btnDelete)
                {
                    RemoveFilter();
                    return;
                }
                if ((bool)focusNode.Enable)
                {
                    cImageFilterProperty filterProperty = GetFilterPropertyByNode(focusNode);
                    if (filterProperty == null) return;

                    e.Cancel = e.Column != colRegion && GlobVar.IsLinkImageFilterMode;
                    if (e.Cancel)
                        return;

                    if (e.Column == colActive ||
                        e.Column == colOrderNum)
                    {
                        e.Cancel = false;
                        return;
                    }
                    else if (e.Column == colRegion &&
                             filterProperty.FilterType == cImageFilterType.PaintRegion)
                    {
                        e.Cancel = false;
                        return;
                    }
                 else
                    {
                        TextBox EditValue = new TextBox();
                        EditValue.Text = e.Value?.ToString();
                        EditValue.Bounds = e.CellBounds;
                        e.Control = EditValue;
                    }
                    DataRow reference = CommonData.GetReferenceProperty(
                        Enum.GetName(typeof(EActionTypes), Action.ActionType), nameof(filterProperty.FilterType),
                        filterProperty.FilterType);
                    if (reference != null)
                    {
                        string setEnable = reference[cColName.PropSetEnable]?.ToString();
                        if (setEnable != null)
                        {
                            string[] setEnables = setEnable.Split(',');
                            e.Cancel = !setEnables.Contains(e.Column.AspectName);
                        }
                    }
                }
            }
           

        }
        

        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (Action == null && tlFilterList.FocusedObject == null)
                return;
            cImageFilterProperty filterProperty = GetFilterPropertyByNode((MyImageFilterProperty)tlFilterList.FocusedObject);
            if (filterProperty == null)
                return;
            ComboBox comboBox = (ComboBox)sender;
            filterProperty.FilterType = comboBox.Text;
            colFilterType.PutValue(tlFilterList.FocusedObject, comboBox.Text);
            //tlFilterList.Refresh();
            tlFilterList.FinishCellEdit();
        }

        private void tlFilterList_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            MyImageFilterProperty currentRow = (MyImageFilterProperty)e.RowObject;
            cImageFilterProperty filterProperty = GetFilterPropertyByNode(currentRow);
            if (e.Column == colFilterType)
            {
                if (cbFilterType.SelectedItem == null)
                    return;
                e.NewValue = cbFilterType.SelectedItem;

            }

            else if (e.Column == colMaskWidth)
            {
                filterProperty.MaskWidth = GlobFuncs.Object2Int(e.NewValue);
                currentRow.MaskWidth = GlobFuncs.Object2Int(e.NewValue);
            }
            else if (e.Column == colMaskHeight)
            {
                filterProperty.MaskHeight = GlobFuncs.Object2Int(e.NewValue);
                currentRow.MaskHeight = GlobFuncs.Object2Int(e.NewValue);

            }
            else if (e.Column == colIterations)
            {
                filterProperty.Iterations = GlobFuncs.Object2Int(e.NewValue);
                currentRow.Iterations = GlobFuncs.Object2Int(e.NewValue);

            }
            else if (e.Column == colOutRangeOutputPixel)
            {
                filterProperty.OutRangeOutputPixel = GlobFuncs.Object2Int(e.NewValue);
                currentRow.OutRangeOutputPixel = GlobFuncs.Object2Int(e.NewValue);

            }
            else if (e.Column == colScaleFactor)
            {
                filterProperty.ScaleFactor = GlobFuncs.Object2Int(e.NewValue);
                currentRow.ScaleFactor = GlobFuncs.Object2Int(e.NewValue);
            }
            else if (e.Column == colGreyValue)
            {
                //filterProperty.GrayValue.rtcValue = GlobFuncs.Object2Double(((MyImageFilterProperty)e.RowObject).ScaleFactor, 1);
                string grayValue = GlobFuncs.Object2Str(e.NewValue);
                currentRow.GrayValue = grayValue;

                string[] grayValues = grayValue.Split(',');
                List<double> ThresholdRange = new List<double>();
                if (!ValidateNodeValueIListDouble_ValueList(grayValues, filterProperty.GrayValue))
                    e.NewValue = GlobFuncs.ListDouble2Str(filterProperty.GrayValue.rtcValue);

            }
            else if (e.Column == colThresholdRange)
            {
                string thresholdRange = GlobFuncs.Object2Str(e.NewValue);
                currentRow.ThresholdRange = thresholdRange;

                string[] thresholdRanges = thresholdRange.Split(',');
                List<double> hThresholdRange = new List<double>();
                if (!ValidateNodeValue_RangeMinMaxLIMIT(thresholdRanges, filterProperty.ThresholdRange))
                    e.NewValue = GlobFuncs.ListDouble2Str(filterProperty.ThresholdRange.rtcValue);

            }
            tlFilterList.UpdateObject(currentRow);
        }
        private bool ValidateNodeValue_RangeMinMaxLIMIT(string[] sValues, SListDouble sHTuple)
        {
            string sErr = string.Empty;
            if (sValues.Count() != 4) sErr = RTC_Vision_Lite.Properties.Resources.TheNumberOfElementsIsnotEnough;
            if (sErr != string.Empty)
                foreach (string item in sValues)
                    if (!GlobFuncs.IsNumeric(item))
                    {
                        sErr = RTC_Vision_Lite.Properties.Resources.ValueMustBeANumber;
                        break;
                    }

            if (sErr == string.Empty && double.Parse(sValues[0]) > double.Parse(sValues[1])) sErr = RTC_Vision_Lite.Properties.Resources.MinValueMustBeSmaller;
            if (sErr == string.Empty && double.Parse(sValues[2]) > double.Parse(sValues[3])) sErr = RTC_Vision_Lite.Properties.Resources.MinValueLIMITMustBeLessThanMaxValueLIMIT;
            if (sErr == string.Empty && double.Parse(sValues[0]) < double.Parse(sValues[2])) sErr = RTC_Vision_Lite.Properties.Resources.MinValueMustBeLessThanOrEqualsMinValueLIMIT;
            if (sErr == string.Empty && double.Parse(sValues[1]) > double.Parse(sValues[3])) sErr = RTC_Vision_Lite.Properties.Resources.MaxValueMustBeLessThanOrEqualsMaxValueLIMIT;

            if (sErr != string.Empty)
            {
                cMessageBox.Warning(sErr);
                return false;
            }
            List<double> hTuple = new List<double> ();
            hTuple.Add(double.Parse(sValues[0]));
            hTuple.Add(double.Parse(sValues[1]));
            hTuple.Add(double.Parse(sValues[2]));
            hTuple.Add(double.Parse(sValues[3]));
            
            sHTuple.rtcValue = hTuple;
            return true;
        }
        private bool ValidateNodeValueIListDouble_ValueList(string[] sValues, SListDouble sListDouble)
        {
            List<double> _double = new List<double>();
            foreach (var sValue in sValues)
            {
                if (int.TryParse(sValue, out int iValue))
                    _double.Add(iValue);
                else if (long.TryParse(sValue, out long lValue))
                    _double.Add(lValue);
                else if (double.TryParse(sValue, out double dValue))
                    _double.Add(dValue);
                else if (!string.IsNullOrEmpty(sValue))
                    _double.Add(0);
            }
            sListDouble.rtcValue = _double;
            return true;
        }
        private void tlFilterList_ButtonClick(object sender, CellClickEventArgs e)
        {
            if ( e.Column == btnDelete)
            {
                RemoveFilter();
            }
        }

        private void btnRunStringBuilder_Click(object sender, EventArgs e)
        {
            Action?.Run_ImageFilter_Test();
            foreach (MyImageFilterProperty Node in tlFilterList.Objects)
                colResult.PutValue(Node, cStrings.None);
            //foreach (int i in Action.ImageFilter_NGIndex)
            //    colRegion
            //foreach (MyImageFilterProperty Node in tlFilterList.Objects)
            //    colResult.PutValue(Node, cStrings.None);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (cMessageBox.Question_YesNo(cMessageContent.BuildMessage(cMessageContent.Que_DeleteObject,
                new string[] { "filter Item" }, new string[] { "Bộ lọc" })) == DialogResult.No)
                return;
            Reset();

        }

        private void Reset()
        {
            if (Action == null) return;
            Action.ImageFilterProperty = new List<cImageFilterProperty>();
            tlFilterList.ClearObjects();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (Action == null || Action.ImageFilterProperty == null) return;
            MyImageFilterProperty focusedNode = (MyImageFilterProperty)tlFilterList.FocusedObject;
            if (focusedNode == null) return;
            int Idex = tlFilterList.IndexOf(focusedNode);
            List<MyImageFilterProperty> AllNode = tlFilterList.Roots.Cast<MyImageFilterProperty>().ToList();
            if (Idex < AllNode.Count - 1)
            {
                AllNode.RemoveAt(Idex);
                AllNode.Insert(Idex + 1, focusedNode);
                tlFilterList.Roots = AllNode;
                RetypeOrderNumber();
            }
            //tlFilterList.ModelToItem(focusedNode).in
            //tlFilterList.index
            //var test = tlFilterList.Roots.;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (Action == null || Action.ImageFilterProperty == null) return;
            MyImageFilterProperty focusedNode = (MyImageFilterProperty)tlFilterList.FocusedObject;
            if (focusedNode == null) return;
            int Idex = tlFilterList.IndexOf(focusedNode);
            List<MyImageFilterProperty> AllNode = tlFilterList.Roots.Cast<MyImageFilterProperty>().ToList();
            if (Idex > 0)
            {
                AllNode.RemoveAt(Idex);
                AllNode.Insert(Idex - 1, focusedNode);
                tlFilterList.Roots = AllNode;
                RetypeOrderNumber();
            }
        }

        private void ucImageFilterActionDetail_Load(object sender, EventArgs e)
        {

        }

        private void tlFilterList_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (Action == null || e.Model == null) { return; }
            e.Item.BackColor = Color.White;
            e.Item.ForeColor = Color.Black;

            // Xác lập background color
            string result = ((MyImageFilterProperty)(e.Model)).Result;
            if (result == cStrings.NG)
            {
                e.SubItem.BackColor = Color.Red;
                e.SubItem.ForeColor = Color.White;
            }

            if (GlobVar.IsLinkImageFilterMode)
            {
                if (((MyImageFilterProperty)(e.Model)).Enable)
                    e.SubItem.ForeColor = Color.Black;
                else
                    e.SubItem.ForeColor = Color.Silver;
            }
            if (e.Column == btnDelete)
            {
                e.SubItem.ImageSelector = imageList1.Images.IndexOfKey("Remove");
                e.SubItem.Text = "";
            }
            if (e.Column == colActive)
            {
                e.SubItem.Text = "";
            }
            if (e.Column == colActive || e.Column == colOrderNum || e.Column == colFilterType || e.Column == btnDelete)
                return;

            cImageFilterProperty filterProperty = GetFilterPropertyByNode((MyImageFilterProperty)e.Model);
            if (filterProperty == null) return;
            DataRow reference = CommonData.GetReferenceProperty(Enum.GetName(typeof(EActionTypes), Action.ActionType), nameof(filterProperty.FilterType), filterProperty.FilterType);
            if (reference != null)
            {
                string setEnable = reference[cColName.PropSetEnable]?.ToString();
                if (!string.IsNullOrEmpty(setEnable))
                {
                    string[] setEnables = setEnable.Split(',');
                    if (!setEnables.Contains(e.Column.AspectName))
                        e.SubItem.ForeColor = e.SubItem.BackColor;
                }
                else
                    e.SubItem.ForeColor = e.SubItem.BackColor;
            }


        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            if (tlFilterList.Roots != null && tlFilterList.Items.Count == cMaxColumnCount.Csv)
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ColumnIsMaximum, new string[] { "csv" }, new string[] { "csv" }));
                return;
            }
            CloneFilter();
        }
        private void CloneFilter()
        {
            if (Action == null)
                return;
            if (Action.ImageFilterProperty == null)
                Action.ImageFilterProperty = new List<cImageFilterProperty>();
            // Lấy node hiện tại
            MyImageFilterProperty currentNode = (MyImageFilterProperty)tlFilterList.FocusedObject;
            if (currentNode == null)
                return;
            // Lấy đối tượng cần clone
            int CurrentIndex = tlFilterList.IndexOf(currentNode);

            cImageFilterProperty currentFilterProperty = GetFilterPropertyByNode(currentNode);
            cImageFilterProperty filterProperty = currentFilterProperty.Clone();
            // Thêm vào mảng
            Action.ImageFilterProperty.Add(filterProperty);
            // Thêm 1 node mới
            MyImageFilterProperty newNode = new MyImageFilterProperty();
            newNode.ID = filterProperty.ID;
            newNode.Delete = "Remove";
            newNode.Active = filterProperty.Active;
            newNode.OrderNum = filterProperty.OrderNum;
            newNode.FilterType = filterProperty.FilterType;
            newNode.MaskWidth = filterProperty.MaskWidth;
            newNode.MaskHeight = filterProperty.MaskHeight;
            newNode.Iterations = filterProperty.Iterations;
            newNode.ThresholdRange = GlobFuncs.Ve2Str(filterProperty.ThresholdRange.rtcValue);
            newNode.GrayValue = GlobFuncs.Ve2Str(filterProperty.GrayValue.rtcValue);
            newNode.InRangeOutputPixel = filterProperty.InRangeOutputPixel;
            newNode.OutRangeOutputPixel = filterProperty.OutRangeOutputPixel;
            newNode.ScaleFactor = filterProperty.ScaleFactor;
            newNode.Margin = filterProperty.Margin;
            newNode.IDRefRegion = filterProperty.IDRefRegion;
            newNode.Enable = true; ;
            newNode.Result = cStrings.None;
            //Dịch chuyển tới vị trí đang đứng
            // Đánh lại STT
            List<MyImageFilterProperty> roots = tlFilterList.Roots.Cast<MyImageFilterProperty>().ToList();
            //Dịch chuyển tới vị trí đang đứng
            if (currentNode != null)
                roots.Insert(CurrentIndex, newNode);
            else
                roots.Add(newNode);
            tlFilterList.Roots = roots;
            RetypeOrderNumber();
            // Focus vào node mới
        }

        private void tlFilterList_SubItemChecking(object sender, SubItemCheckingEventArgs e)
        {
            if (Action == null && e.RowObject == null)
                return;
            cImageFilterProperty filterProperty = GetFilterPropertyByNode((MyImageFilterProperty)e.RowObject);
            if (filterProperty == null)
                return;
            filterProperty.Active = e.NewValue == CheckState.Checked ? true : false;
        }

        private void tlFilterList_CellClick_1(object sender, CellClickEventArgs e)
        {
            tlFilterList.SelectedObject = e.Model;
        }
    }
   
}
