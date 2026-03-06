using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTCConst;
using RTCEnums;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucExcelWriteActionDetail : ucBaseActionDetail
    {
        private ComboBox cbDataType = new ComboBox();
        private TextBox txtDisable = new TextBox();
        private ComboBox cbValue = new ComboBox();
        private TextBox txtEnable = new TextBox();
        private ComboBox cbSortMort = new ComboBox();
        public ucExcelWriteActionDetail()
        {
            InitializeComponent();
            tlColumnList.SmallImageList = base.Selecticon;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tlColumnList.Objects != null && tlColumnList.Items.Count == cMaxColumnCount.Csv)
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ColumnIsMaximum, new string[] { "csv" }, new string[] { "csv" }));
                return;
            }

            AddColumn();
        }
        private void LoadListDataType()
        {
            cbDataType.Items.Clear();
            cbDataType.Items.Add(cDataTypes.String);
            cbDataType.Items.Add(cDataTypes.StringList);
            cbDataType.Items.Add(cDataTypes.Boolean);
            cbDataType.Items.Add(cDataTypes.BooleanList);
            cbDataType.Items.Add(cDataTypes.Integer);
            cbDataType.Items.Add(cDataTypes.IntegerList);
            cbDataType.Items.Add(cDataTypes.Real);
            cbDataType.Items.Add(cDataTypes.RealList);
            cbDataType.Items.Add(cDataTypes.DateAndTime);
            cbDataType.Items.Add(cDataTypes.Origin);
            cbDataType.Items.Add(cDataTypes.OriginList);
            cbDataType.Items.Add(cDataTypes.Point);
            cbDataType.Items.Add(cDataTypes.PointList);
            cbDataType.Items.Add(cDataTypes.Rectangle);
            cbDataType.Items.Add(cDataTypes.RectangleList);
        }
        private void LoadSortMode()
        {
            cbSortMort.Items.Clear();
            cbSortMort.Items.Add("None");
            cbSortMort.Items.Add("By Number");
            cbSortMort.Items.Add("By Text");
        }    
        internal void LoadColumnProperty()
        {
            if (Action == null)
                return;
            try
            {
                GlobVar.LockEvents = true;
                LoadListDataType();

                tlColumnList.SuspendLayout();
                tlColumnList.ClearObjects();
                //Hiển thị danh sách các filter
                if (Action != null && Action.Columns != null)
                {
                    var orderList = from column in Action.Columns
                                    orderby column.OrderNum
                                    select column;

                    foreach (cColumnProperty columnProperty in orderList)
                    {
                        CSVWrite newNode = new CSVWrite();
                        newNode.ID = columnProperty.ID;
                        //string.Empty,
                        newNode.Active = columnProperty.Active;
                        newNode.OrderNum = columnProperty.OrderNum;
                        newNode.ColumnName = columnProperty.Name;
                        newNode.DataType = columnProperty.DataType;
                        newNode.Format = columnProperty.Format;
                        newNode.Enable = true;
                        newNode.Delete = string.Empty;
                        // newNode.Dis    columnProperty.DisplayFormat,
                        newNode.Value = columnProperty.RefID != Guid.Empty ? columnProperty.Ref : columnProperty.Value;
                        newNode.Link = columnProperty.RefID.ToString();
                        newNode.IsRowToCol = columnProperty.IsRowToCol;
                        newNode.SortMode = columnProperty.SortMode;
                        tlColumnList.AddObject(newNode);

                    }
                }
                if (tlColumnList.Items.Count > 0)
                    tlColumnList.FocusedItem = tlColumnList.Items[0];
            }
            finally
            {
                tlColumnList.ResumeLayout();
                GlobVar.LockEvents = false;
            }
        }
        private void AddColumn()
        {
            if (Action == null)
                return;
            if (Action.Columns == null)
                Action.Columns = new List<cColumnProperty>();
            cColumnProperty columnProperty = new cColumnProperty(Action.Columns);
            // Thêm vào mảng
            Action.Columns.Add(columnProperty);
            // Lấy node hiện tại
            CSVWrite currentNode = (CSVWrite)tlColumnList.FocusedObject;
            int CurrentIndex = tlColumnList.IndexOf(currentNode);
            // Thêm 1 node mới
            CSVWrite newNode = new CSVWrite();
            newNode.ID = columnProperty.ID;
            //string.Empty,
            newNode.Active = columnProperty.Active;
            newNode.OrderNum = columnProperty.OrderNum;
            newNode.ColumnName = columnProperty.Name;
            newNode.DataType = columnProperty.DataType;
            newNode.Format = columnProperty.Format;
            newNode.Enable = true;
            newNode.Delete = string.Empty;
            // newNode.Dis    columnProperty.DisplayFormat,
            newNode.Value = columnProperty.RefID != Guid.Empty ? columnProperty.Ref : columnProperty.Value;
            newNode.Link = columnProperty.RefID.ToString();
            newNode.IsRowToCol = columnProperty.IsRowToCol;
            newNode.SortMode = columnProperty.SortMode;
            List<CSVWrite> roots = tlColumnList.Roots.Cast<CSVWrite>().ToList();
            //Dịch chuyển tới vị trí đang đứng
            if (currentNode != null)
                roots.Insert(CurrentIndex, newNode);
            else
                roots.Add(newNode);
            // Đánh lại STT
            // Focus vào node mới
            tlColumnList.Roots = roots;
            RetypeOrderNumber();
        }

        private void tlColumnList_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if (e.Column == colLink)
            {
                cColumnProperty currentColumn = GetColumnPropertyByNode((CSVWrite)e.Model);
                if (currentColumn.RefID == Guid.Empty)
                {
                    e.SubItem.ImageSelector = "LinkProperty";
                    e.SubItem.Text = "";
                }
                else
                {
                    e.SubItem.ImageSelector = "RemoveLink";
                    e.SubItem.Text = "";
                }    
            }    
            if (e.Column == colDelete)
            {
                e.SubItem.ImageSelector = "Remove";
            }    

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (Action == null || Action.Columns == null) return;
            CSVWrite focusedNode = (CSVWrite)tlColumnList.FocusedObject;
            if (focusedNode == null) return;
            int Idex = tlColumnList.IndexOf(focusedNode);
            List<CSVWrite> AllNode = tlColumnList.Roots.Cast<CSVWrite>().ToList();
            if (Idex > 0)
            {
                AllNode.RemoveAt(Idex);
                AllNode.Insert(Idex - 1, focusedNode);
                tlColumnList.Roots = AllNode;
                RetypeOrderNumber();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (Action == null || Action.Columns == null) return;
            CSVWrite focusedNode = (CSVWrite)tlColumnList.FocusedObject;
            if (focusedNode == null) return;
            int Idex = tlColumnList.IndexOf(focusedNode);
            List<CSVWrite> AllNode = tlColumnList.Roots.Cast<CSVWrite>().ToList();
            if (Idex < AllNode.Count - 1)
            {
                AllNode.RemoveAt(Idex);
                AllNode.Insert(Idex + 1, focusedNode);
                tlColumnList.Roots = AllNode;
                RetypeOrderNumber();
            }
        }
        private void RetypeOrderNumber()
        {
            List<CSVWrite> lstImageFilterNode = tlColumnList.Objects.Cast<CSVWrite>().ToList();
            if (lstImageFilterNode != null && lstImageFilterNode.Count > 0)
            {
                int orderNumber = 0;
                foreach (CSVWrite node in lstImageFilterNode)
                {
                    cColumnProperty filterProperty = GetColumnPropertyByNode(node);
                    if (filterProperty != null)
                    {
                        orderNumber += 1;
                        filterProperty.OrderNum = orderNumber;
                        colOrderNum.PutValue(node, orderNumber);
                    }
                }
            }
        }
        private cColumnProperty GetColumnPropertyByNode(CSVWrite node)
        {
            if (Action == null || node == null || Action.Columns == null)
                return null;
            string id = node.ID.ToString();
            if (Guid.TryParse(id, out Guid guid))
                if (Action.Columns.FirstOrDefault(x => x.ID == guid) != null)
                    return Action.Columns.FirstOrDefault(x => x.ID == guid);

            return null;
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
            Action.Columns = new List<cColumnProperty>();
            tlColumnList.ClearObjects();
        }
        private void btnClone_Click(object sender, EventArgs e)
        {
            if (tlColumnList.Objects != null && tlColumnList.Items.Count == cMaxColumnCount.Csv)
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ColumnIsMaximum, new string[] { "csv" }, new string[] { "csv" }));
                return;
            }
            CloneColumn();
        }
        private void CloneColumn()
        {
            if (Action == null)
                return;
            if (Action.Columns == null)
                Action.Columns = new List<cColumnProperty>();
            // Lấy node hiện tại
            CSVWrite currentNode = (CSVWrite)tlColumnList.FocusedObject;
            if (currentNode == null)
                return;
            // Lấy đối tượng cần clone
            int CurrentIndex = tlColumnList.IndexOf(currentNode);
            cColumnProperty currentColumn = GetColumnPropertyByNode(currentNode);
            cColumnProperty columnProperty = currentColumn.Clone();
            // Thêm vào mảng
            Action.Columns.Add(columnProperty);
            // Thêm 1 node mới
            CSVWrite newNode = new CSVWrite();
            newNode.Active = columnProperty.Active;
            newNode.OrderNum = columnProperty.OrderNum;
            newNode.ColumnName = columnProperty.Name;
            newNode.DataType = columnProperty.DataType;
            newNode.Format = columnProperty.Format;
            newNode.Enable = true;
            newNode.Value = columnProperty.RefID != Guid.Empty ? columnProperty.Ref : columnProperty.Value;
            newNode.Link = columnProperty.RefID.ToString();
            newNode.IsRowToCol = columnProperty.IsRowToCol;
            newNode.SortMode = columnProperty.SortMode;
            //Dịch chuyển tới vị trí đang đứng
            // Đánh lại STT
            List<CSVWrite> roots = tlColumnList.Roots.Cast<CSVWrite>().ToList();
            //Dịch chuyển tới vị trí đang đứng
            if (currentNode != null)
                roots.Insert(CurrentIndex, newNode);
            else
                roots.Add(newNode);
            tlColumnList.Roots = roots;
            RetypeOrderNumber();
            // Focus vào node mới
        }
        private void tlColumnList_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if(e.Column == colLink)
            {
                cColumnProperty currentColumn = GetColumnPropertyByNode((CSVWrite)e.Item.RowObject);

                if (currentColumn.RefID == Guid.Empty)
                {
                    try
                    {
                        if (Action == null || tlColumnList.FocusedObject == null) { return; }
                        cColumnProperty columnProperty = GetColumnPropertyByNode((CSVWrite)tlColumnList.FocusedObject);
                        if (columnProperty == null) return;
                        if (columnProperty.RefID != Guid.Empty)
                        {
                            // Remove link
                            columnProperty.RefID = Guid.Empty;
                            columnProperty.PropName = string.Empty;
                            colLink.PutValue(tlColumnList.FocusedObject, Guid.Empty);
                        }
                        else
                        {
                            // Thực hiện thao tác link value
                            if (OnExcelWriteBtnLinkValueClickEvent != null)
                            {
                                RTCE_ExcelWrite_RowCellClickEventArgs eventArgs =
                                    new RTCE_ExcelWrite_RowCellClickEventArgs
                                    {
                                        View = this,
                                        TreeList = tlColumnList,
                                        Action = Action,
                                        ColumnProperty = columnProperty,
                                        ValueColumn = colValue,
                                        IdColumn = colID,
                                        EnableColumn = colEnable,
                                        ColumnPropertyNode = (CSVWrite)tlColumnList.FocusedObject
                                    };
                                OnExcelWriteBtnLinkValueClickEvent(this, eventArgs);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        GlobFuncs.SaveErr(ex);
                    }
                } 
                else
                {
                    cColumnProperty columnProperty = GetColumnPropertyByNode((CSVWrite)tlColumnList.FocusedObject);
                    if (columnProperty == null)
                        return;
                    columnProperty.RefID = Guid.Empty;
                    columnProperty.PropName = string.Empty;
                    UpdateColumnPropertyInfo(columnProperty, (CSVWrite)tlColumnList.FocusedObject);
                  
                }    
            }    

        }
        internal void UpdateColumnPropertyInfo(cColumnProperty columnProperty, CSVWrite node)
        {
            if (node != null)
            {
                colDataType.PutValue(node, columnProperty.DataType);
                colValue.PutValue(node, columnProperty.RefID != Guid.Empty ? columnProperty.Ref : columnProperty.Value);
                colFormat.PutValue(node, columnProperty.Format);
                colLink.PutValue(node, columnProperty.RefID);
            }
        }
        private void tlColumnList_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            cColumnProperty columnProperty = GetColumnPropertyByNode((CSVWrite)e.RowObject);

            if (e.Column == colDataType)
            {
                if (columnProperty.RefID != Guid.Empty)
                {
                    e.Cancel = true;
                }
                else
                {

                    cbDataType = new ComboBox();
                    LoadListDataType();
                    cbDataType.Bounds = e.CellBounds;
                    cbDataType.SelectedIndexChanged += ComboboxDataType_SelectedIndexChange;
                    cbDataType.SelectedIndex = cbDataType.Items.IndexOf(((CSVWrite)e.RowObject).DataType);
                    e.Control = cbDataType;
                    e.NewValue = cbDataType.SelectedItem;
                }
            }
            else if (e.Column == this.colValue)
            {
                if (columnProperty.RefID != Guid.Empty ||
                    columnProperty.DataType == cDataTypes.DateAndTime)
                {
                    e.Cancel = true;
                }

                else if (columnProperty.DataType == cDataTypes.Boolean ||
                         columnProperty.DataType == cDataTypes.BooleanList)
                {
                    cbValue = new ComboBox();
                    switch (columnProperty.DataType)
                    {
                        case cDataTypes.Boolean:
                            {
                                cbValue.Items.Add(cStrings.True);
                                cbValue.Items.Add(cStrings.False);
                                break;
                            }
                        case cDataTypes.BooleanList:
                            {
                                cbValue.Items.Add(cStrings.True);
                                cbValue.Items.Add(cStrings.False);
                                break;
                            }
                        default:
                            {
                                e.Cancel = true;
                                break;
                            }
                    }
                    cbValue.Bounds = e.CellBounds;
                    cbValue.SelectedIndexChanged += ComboboxValue_SelectedIndexChange;
                    cbValue.SelectedIndex = cbValue.Items.IndexOf(((CSVWrite)e.RowObject).Value == null ? string.Empty : ((CSVWrite)e.RowObject).Value);
                    e.Control = cbValue;
                    e.NewValue = cbValue.SelectedItem;
                }
                else
                {
                    txtEnable = new TextBox();
                    txtEnable.Bounds = e.CellBounds;
                    txtEnable.Text = e.Value.ToString();
                    txtEnable.KeyDown += TextboxEnable_Keydown;
                    e.Control = txtEnable;
                    e.NewValue = txtEnable.Text;
                }
            }
            else if (e.Column == this.colSortMode)
            {
                if(columnProperty.DataType != cDataTypes.AutoNumber && columnProperty.DataType != cDataTypes.Boolean && columnProperty.DataType != cDataTypes.BooleanList)
                {
                    cbSortMort = new ComboBox();
                    LoadSortMode();
                    cbSortMort.Bounds = e.CellBounds;
                    cbSortMort.SelectedIndexChanged += ComboboxSortMode_SelectedIndexChange;
                    cbSortMort.SelectedIndex = cbSortMort.Items.IndexOf(((CSVWrite)e.RowObject).SortMode);
                    e.Control = cbDataType;
                    e.NewValue = cbDataType.SelectedItem;
                }    
                else
                {
                    e.Cancel = true;
                }    
            }    
            else if (e.Column == this.colName)
            {
                txtEnable = new TextBox();
                txtEnable.Bounds = e.CellBounds;
                txtEnable.Text = e.Value.ToString();
                txtEnable.KeyDown += TextboxEnable_Keydown;
                e.Control = txtEnable;
                e.NewValue = txtEnable.Text;
            }    
            else
                e.Cancel = true;
        }
        private void TextboxEnable_Keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Action == null && tlColumnList.FocusedObject == null)
                    return;
                cColumnProperty columnProperty = GetColumnPropertyByNode((CSVWrite)tlColumnList.FocusedObject);
                if (columnProperty == null)
                    return;
                TextBox TextBox = (TextBox)sender;
                if(tlColumnList.SelectedColumn == colName)
                {
                    columnProperty.Name = TextBox.Text;
                }
                else if (tlColumnList.SelectedColumn == colValue)
                {
                    columnProperty.Value = TextBox.Text;

                }
                tlColumnList.FinishCellEdit();
            }
        }
        //private void TextboxEnable_TextChanged(object sender, EventArgs e)
        //{
        //    if (Action == null && tlColumnList.FocusedObject == null)
        //        return;
        //    cColumnProperty columnProperty = GetColumnPropertyByNode((CSVWrite)tlColumnList.FocusedObject);
        //    if (columnProperty == null)
        //        return;
        //    TextBox TextBox = (TextBox)sender;
        //    columnProperty.Value = TextBox.Text;
        //    tlColumnList.FinishCellEdit();
        //}
        private void ComboboxSortMode_SelectedIndexChange(object sender, EventArgs e)
        {
            if (Action == null && tlColumnList.FocusedObject == null)
                return;
            cColumnProperty columnProperty = GetColumnPropertyByNode((CSVWrite)tlColumnList.FocusedObject);
            if (columnProperty == null)
                return;
            ComboBox comboBox = (ComboBox)sender;
            columnProperty.SortMode = comboBox.Text;
            tlColumnList.FinishCellEdit();
        }
        private void ComboboxValue_SelectedIndexChange(object sender, EventArgs e)
        {
            if (Action == null && tlColumnList.FocusedObject == null)
                return;
            cColumnProperty columnProperty = GetColumnPropertyByNode((CSVWrite)tlColumnList.FocusedObject);
            if (columnProperty == null)
                return;
            ComboBox comboBox = (ComboBox)sender;
            columnProperty.Value = comboBox.Text;
            tlColumnList.FinishCellEdit();
        }
        private void ComboboxDataType_SelectedIndexChange(object sender, EventArgs e)
        {
            if (Action == null && tlColumnList.FocusedObject == null)
                return;
            cColumnProperty columnProperty = GetColumnPropertyByNode((CSVWrite)tlColumnList.FocusedObject);
            if (columnProperty == null)
                return;
            ComboBox comboBox = (ComboBox)sender;
            columnProperty.DataType = comboBox.Text;
            switch (columnProperty.DataType)
            {
                case cDataTypes.Boolean:
                    {
                        GlobVar.LockEvents = true;
                        columnProperty.Format = CDataFormat.BooleanOkNg;
                        colFormat.PutValue(tlColumnList.FocusedObject, columnProperty.Format);
                        GlobVar.LockEvents = false;
                        break;
                    }
                case cDataTypes.BooleanList:
                    {
                        GlobVar.LockEvents = true;
                        columnProperty.Format = CDataFormat.BooleanOkNg;
                        colFormat.PutValue(tlColumnList.FocusedObject, columnProperty.Format);
                        GlobVar.LockEvents = false;
                        break;
                    }
                case cDataTypes.DateAndTime:
                    {
                        GlobVar.LockEvents = true;
                        columnProperty.Format = cDateTimeFormats.yyyyddMM;
                        colFormat.PutValue(tlColumnList.FocusedObject, columnProperty.Format);
                        GlobVar.LockEvents = false;
                        break;
                    }
                default:
                    {
                        GlobVar.LockEvents = true;
                        columnProperty.Format = string.Empty;
                        colFormat.PutValue(tlColumnList.FocusedObject, columnProperty.Format);
                        GlobVar.LockEvents = false;
                        break;
                    }
            }
            tlColumnList.FinishCellEdit();
        }
        private void tlColumnList_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            cColumnProperty ColumnProperty = GetColumnPropertyByNode((CSVWrite)e.RowObject);
            if (e.Column == colDataType)
            {
                if (cbDataType.SelectedItem == null)
                    return;
                e.NewValue = cbDataType.SelectedItem;
                tlColumnList.Refresh();
                cbDataType.SelectedIndexChanged += ComboboxDataType_SelectedIndexChange;

            }
            else if (e.Column ==  colValue)
            {
                if(e.Control == cbValue)
                {
                    e.NewValue = cbValue.SelectedItem;
                    tlColumnList.Refresh();
                    cbValue.SelectedIndexChanged += ComboboxValue_SelectedIndexChange;
                }    
                if(e.Control == txtEnable)
                {
                    e.NewValue = txtEnable.Text;
                    tlColumnList.Refresh();
                    txtEnable.KeyDown += TextboxEnable_Keydown;
                }    
            }  
            else if (e.Column == colName)
            {
                e.NewValue = txtEnable.Text;
                tlColumnList.Refresh();
                ColumnProperty.Name = txtEnable.Text;
                txtEnable.KeyDown += TextboxEnable_Keydown;
            }    
            else if (e.Column == colSortMode)
            {
                e.NewValue = cbSortMort.SelectedItem;
                tlColumnList.Refresh();
                cbSortMort.SelectedIndexChanged += ComboboxSortMode_SelectedIndexChange;
            }    
        }
        private void btnRunStringBuilder_Click(object sender, EventArgs e)
        {
            Action?.Run_SaveCsv_Test();
        }

        private void tlColumnList_SubItemChecking(object sender, BrightIdeasSoftware.SubItemCheckingEventArgs e)
        {
            cColumnProperty columnProperty = GetColumnPropertyByNode((CSVWrite)e.RowObject);
            if(e.Column == colRowToCol)
            {
                columnProperty.IsRowToCol = e.NewValue == CheckState.Checked ? true : false;
            }    
        }

        
    }
}

