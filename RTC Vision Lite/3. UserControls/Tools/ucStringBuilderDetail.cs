using Emgu.CV.CvEnum;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using ThridLibray;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucStringBuilderDetail : ucBaseActionDetail
    {
        public ucStringBuilderDetail()
        {

            InitializeComponent();
            PageSetup.SelectedTab = General;
            ucStringBuilderItemProperty.OnStringBuilderItem_DataChangedEvent -= OnStringBuilderItem_DataChangedEvent;
            ucStringBuilderItemProperty.OnStringBuilderItem_DataChangedEvent += OnStringBuilderItem_DataChangedEvent;
            tlStringItem.TreeColumnRenderer.IsShowLines = false;

            
        }
        ComboBox cbType = new ComboBox();
        TextBox txtValue = new TextBox();
        ComboBox cbBoolValue = new ComboBox();
        public void ShowStringResult()
        {
            if (Action == null || Action.StringBuilders == null)
            {
                if (lblOutput.InvokeRequired)
                {
                    lblOutput.Invoke((MethodInvoker)delegate
                    {
                        lblOutput.Text = string.Empty;
                        lblOutputHeader.Text = string.Empty;
                    });
                }
                else
                {
                    lblOutput.Text = string.Empty;
                    lblOutputHeader.Text = string.Empty;
                }
            }
            else
            {
                if (lblOutput.InvokeRequired)
                {
                    lblOutput.Invoke((MethodInvoker)delegate
                    {
                        lblOutput.Text = Action.OutputString.rtcValue;
                        lblOutputHeader.Text = Action.OutputHeaderString.rtcValue;
                    });
                }
                else
                {
                    lblOutput.Text = Action.OutputString.rtcValue;
                    lblOutputHeader.Text = Action.OutputHeaderString.rtcValue;
                }
            }

            //Clipboard.SetText(Action.OutputStringSend.rtcValue);
        }
        public void LoadStringBuilderItems()
        {
            tlStringItem.Invoke(new Action(() =>
            {
                try
                {
                    tlStringItem.SuspendLayout();
                    tlStringItem.ClearObjects();
                    // Hiển thị danh sách các link 
                    if (Action != null && Action.StringBuilders != null)
                    {
                        var orderList = from sbItem in Action.StringBuilders
                                        orderby sbItem.OrderNum
                                        select sbItem;

                        foreach (SStringBuilderItem sbItem in orderList)
                        {
                            MyPropertiesItem newNode = new MyPropertiesItem();
                         
                                tlStringItem.SuspendLayout();
                                newNode.STT = sbItem.OrderNum;
                                newNode.Delete = "Remove";
                                newNode.Name = sbItem.Name;
                                newNode.Type = sbItem.GetItemType();
                                newNode.Value = sbItem.RefID != Guid.Empty ? sbItem.ValueView + " " + sbItem.Ref : sbItem.ValueView;
                                newNode.IDref = sbItem.RefID;
                                newNode.RefPropName = sbItem.RefPropName;
                                newNode.Enable = true;
                                tlStringItem.AddObject(newNode);
                                tlStringItem.SelectedObject = newNode;
                            
                        }
                    }
                    List<MyPropertiesItem> AllNode = tlStringItem.Objects.Cast<MyPropertiesItem>().ToList();
                    if (AllNode.Count > 0)
                    {
                        tlStringItem.SelectedObject = AllNode[0];
                    }
                    tlStringItem_SelectionChanged(null, null);
                    if (Action != null && !GlobVar.LockEvents && Action.AutoRun)
                        RunAction();
                }
                finally
                {
                    tlStringItem.ResumeLayout();
                }
            }));
        }
        public void LoadDataToComboBoxType()
        {
            cbType.Items.Clear();
            cbType.Items.AddRange(new object[] { "Boolean", "Boolean List", "Date And Time", "Integer","Integer List", "Origin",
                "Origin List", "Point", "Point List", "Real", "Real ListRectangle", "Rectangle List", "String", "String List"});
        }
        private void OnStringBuilderItem_DataChangedEvent(SStringBuilderItem rsbItem)
        {
            if (Action.AutoRun)
                RunAction();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Action == null) { return; }
            if (Action.StringBuilders == null) { Action.StringBuilders = new List<SStringBuilderItem>(); }
            int _OrderNum = 0;
            if (Action.StringBuilders.Count > 0)
                _OrderNum = Action.StringBuilders[Action.StringBuilders.Count - 1].OrderNum + 1;
            else
                _OrderNum += 1;
            SStringBuilderItem _RSBItem = new SStringBuilderItem(EHTupleStyle.Boolean);
            _RSBItem.OrderNum = _OrderNum;
            _RSBItem.Name = _RSBItem.Name + " " + _OrderNum.ToString();
            Action.StringBuilders.Add(_RSBItem);
            _RSBItem.Node = AddStringBuilderItemToTreeList(_RSBItem);
            _RSBItem.ColValue = this.colValue;
        }
        private MyPropertiesItem AddStringBuilderItemToTreeList(SStringBuilderItem _SBItem)
        {
            MyPropertiesItem newNode = new MyPropertiesItem();
            try
            {
                tlStringItem.SuspendLayout();
                newNode.STT = _SBItem.OrderNum;
                newNode.Delete = "Remove";
                newNode.Name = _SBItem.Name;
                newNode.Type = _SBItem.GetItemType();
                newNode.Value = _SBItem.RefID != Guid.Empty ? _SBItem.ValueView + " " + _SBItem.Ref : _SBItem.ValueView;
                newNode.IDref = _SBItem.RefID;
                newNode.RefPropName = _SBItem.RefPropName;
                newNode.Enable = true;
                tlStringItem.AddObject(newNode);
                tlStringItem.SelectedObject = newNode;
            }
            finally
            {
                tlStringItem.ResumeLayout();
            }

            if (Action.AutoRun) RunAction();

            return newNode;
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            if (Action == null || Action.StringBuilders == null) return;
            MyPropertiesItem focusedNode = (MyPropertiesItem)tlStringItem.SelectedObject;
            if (focusedNode == null) return;
            int orderNum = 0;
            if (Action.StringBuilders.Count > 0)
                orderNum = Action.StringBuilders[Action.StringBuilders.Count - 1].OrderNum + 1;
            else
                orderNum += 1;

            SStringBuilderItem rsbItem = Action.StringBuilders.Find(x => x.OrderNum == (int)focusedNode.STT);
            SStringBuilderItem sbItemClone = new SStringBuilderItem(EHTupleStyle.Boolean)
            {
                OrderNum = orderNum,
            };

            sbItemClone.Name = sbItemClone.Name + " " + orderNum.ToString();
            sbItemClone.ValueStyle = rsbItem.ValueStyle;
            sbItemClone.Leading = rsbItem.Leading;
            sbItemClone.Tralling = rsbItem.Tralling;
            sbItemClone.TrueText = rsbItem.TrueText;
            sbItemClone.FalseText = rsbItem.FalseText;
            sbItemClone.DateFormat = rsbItem.DateFormat;
            sbItemClone.TimeFormat = rsbItem.TimeFormat;
            sbItemClone.DelimiterDate = rsbItem.DelimiterDate;
            sbItemClone.DelimiterTime = rsbItem.DelimiterTime;
            sbItemClone.UseDecimalPlaces = rsbItem.UseDecimalPlaces;
            sbItemClone.DecimalPlaces = rsbItem.DecimalPlaces;
            sbItemClone.UseMiniumLength = rsbItem.UseMiniumLength;
            sbItemClone.MiniumLength = rsbItem.MiniumLength;
            sbItemClone.UseLimitInput = rsbItem.UseLimitInput;
            sbItemClone.MaximumLength = rsbItem.MaximumLength;
            sbItemClone.UsePadOutput = rsbItem.UsePadOutput;
            sbItemClone.PadOutPut = rsbItem.PadOutPut;
            sbItemClone.PadWith = rsbItem.PadWith;
            sbItemClone.GroupingBracket = rsbItem.GroupingBracket;
            sbItemClone.XYDelimiter = rsbItem.XYDelimiter;
            sbItemClone.ElementDelimiter = rsbItem.ElementDelimiter;
            sbItemClone.RefID = rsbItem.RefID;
            sbItemClone.RefPropName = rsbItem.RefPropName;
            sbItemClone.RefIndex = rsbItem.RefIndex;
            sbItemClone.IscanReset = rsbItem.IscanReset;
            sbItemClone.IsDataItem = rsbItem.IsDataItem;
            sbItemClone.ValueView = rsbItem.ValueView;
            sbItemClone.ValueViewFull = rsbItem.ValueViewFull;
            sbItemClone.Ref = rsbItem.Ref;
            sbItemClone.ListDoubleValue = rsbItem.ListDoubleValue;
            sbItemClone.ListDoubleValue = rsbItem.ListDoubleValue;

            Action.StringBuilders.Add(sbItemClone);
            sbItemClone.Node = AddStringBuilderItemToTreeList(sbItemClone);
            sbItemClone.ColValue = this.colValue;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (Action == null || Action.ImageFilterProperty == null) return;
            MyPropertiesItem focusedNode = (MyPropertiesItem)tlStringItem.FocusedObject;
            if (focusedNode == null) return;
            int Idex = tlStringItem.IndexOf(focusedNode);
            List<MyPropertiesItem> AllNode = tlStringItem.Roots.Cast<MyPropertiesItem>().ToList();
            if (Idex > 0)
            {
                AllNode.RemoveAt(Idex);
                AllNode.Insert(Idex - 1, focusedNode);
                tlStringItem.Roots = AllNode;
                ReOrderNum();
            }
        }
        private void ReOrderNum()
        {
            if (Action == null || Action.StringBuilders == null) return;
            int orderNum = 1;
            int oldOrderNum = 1;
            List<MyPropertiesItem> lstStringItemNode = tlStringItem.Objects.Cast<MyPropertiesItem>().ToList();
            foreach (MyPropertiesItem node in  lstStringItemNode)
            {
                oldOrderNum = node.STT;
                this.colSTT.PutValue(node, orderNum);
                SStringBuilderItem sbItem = Action.StringBuilders.Find(x => x.OrderNum == oldOrderNum);
                sbItem.OrderNum = orderNum;
                orderNum += 1;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (Action == null || Action.ImageFilterProperty == null) return;
            MyPropertiesItem focusedNode = (MyPropertiesItem)tlStringItem.FocusedObject;
            if (focusedNode == null) return;
            int Idex = tlStringItem.IndexOf(focusedNode);
            List<MyPropertiesItem> AllNode = tlStringItem.Roots.Cast<MyPropertiesItem>().ToList();
            if (Idex < AllNode.Count - 1)
            {
                AllNode.RemoveAt(Idex);
                AllNode.Insert(Idex + 1, focusedNode);
                tlStringItem.Roots = AllNode;
                ReOrderNum();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Action == null) return;
            Action.StringBuilders = new List<SStringBuilderItem>();
            Action.LeadingText.rtcValue = string.Empty;
            Action.TrallingText.rtcValue = string.Empty;
            Action.Terminator.rtcValue = (int)ETermiator.None;
            Action.DelimiterType.rtcValue = (int)EDelimiterTypes.Standard;
            Action.DelimiterStandard.rtcValue = (int)EDelimiter.None;
            Action.DelimiterCustom.rtcValue = string.Empty;
            Action.DecimalSeparator.rtcValue = (int)EDecimalSeparator.Comma;

            BindingDataToControls();
        }

        private void tlStringItem_SelectionChanged(object sender, EventArgs e)
        {
            if (Action == null || tlStringItem.FocusedObject == null)
            {
                GlobFuncs.VisibleControl(ucStringBuilderItemProperty, false);
                return;
            }
            SStringBuilderItem sbItem = Action.StringBuilders.Find(x => x.OrderNum == ((MyPropertiesItem)tlStringItem.FocusedObject).STT);
            ViewItemProperties(sbItem);
            GlobFuncs.VisibleControl(ucStringBuilderItemProperty, true);

            var orderList = (from sbItem1 in Action.StringBuilders
                             orderby sbItem1.OrderNum
                             select sbItem1).ToList();

            if (sbItem.OrderNum == orderList[0].OrderNum)
            {
                GlobFuncs.EnableControl(btnUp, false);
                GlobFuncs.EnableControl(btnDown, true);
            }
            else if (sbItem.OrderNum == orderList[orderList.Count - 1].OrderNum)
            {
                GlobFuncs.EnableControl(btnUp, true);
                GlobFuncs.EnableControl(btnDown, false);
            }
            else
            {
                GlobFuncs.EnableControl(btnUp, true);
                GlobFuncs.EnableControl(btnDown, true);
            }
        }
        private void ViewItemProperties(SStringBuilderItem rsbItem)
        {
            try
            {
                GlobFuncs.BeginControlUpdate(this);
                ucStringBuilderItemProperty.RTCSBItem = rsbItem;
            }
            finally
            {
                GlobFuncs.EndControlUpdate(this);
            }
        }

        private void tlStringItem_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (Action == null || Action.StringBuilders == null || Action.StringBuilders.Count <= 0 || e.Column == null || e.RowObject == null)
            {
                e.Cancel = true;
                return;
            }
            SStringBuilderItem rsbItem = Action.StringBuilders.Find(x => x.OrderNum == ((MyPropertiesItem)e.RowObject).STT);
            if (rsbItem == null)
            {
                e.Cancel = true;
                return;
            }
     
            if (e.Column == colType || e.Column == colValue || e.Column == colItemName)
            {
                if (e.Column == this.colType)
                {
                    cbType = new ComboBox();
                    LoadDataToComboBoxType();
                    cbType.Bounds = e.CellBounds;
                    cbType.DropDownStyle = ComboBoxStyle.DropDownList;
                    e.Control = cbType;
                    cbType.SelectedItem = e.Value;
                    cbType.SelectedIndexChanged -= CbType_SelectedIndexChanged;
                    cbType.SelectedIndexChanged += CbType_SelectedIndexChanged;

                }
                if (e.Column == colValue)
                {
                    if (rsbItem.ValueStyle == EHTupleStyle.Boolean)
                    {
                        cbBoolValue = new ComboBox();
                        cbBoolValue.Items.Add(cStrings.True);
                        cbBoolValue.Items.Add(cStrings.False);
                        cbBoolValue.Bounds = e.CellBounds;
                        cbBoolValue.DropDownStyle = ComboBoxStyle.DropDownList;
                        cbBoolValue.SelectedIndexChanged -= ComboBoxBoolValueSelectedValueChanged;
                        cbBoolValue.SelectedIndexChanged += ComboBoxBoolValueSelectedValueChanged;
                        e.Control = cbBoolValue;
                    }
                    else
                    {
                        txtValue = new TextBox();
                        txtValue.Text = e.Value.ToString();
                        txtValue.Bounds = e.CellBounds;
                        e.Control = txtValue;
                    }
                }
                if (e.Column == colItemName)
                {
                    TextBox txtItemName = new TextBox();
                    txtItemName.Text = e.Value.ToString();
                    txtItemName.Bounds = e.CellBounds;
                    e.Control = txtItemName;
                }
            }
            else
            {
                e.Cancel = true;
            }    
        }
        private void ComboBoxBoolValueSelectedValueChanged(object sender, EventArgs e)
        {
            MyPropertiesItem focusNode = (MyPropertiesItem)tlStringItem.FocusedObject;
            if (focusNode == null) return;
            ComboBox comboBox = (ComboBox)sender;
            SStringBuilderItem rsbItem = Action.StringBuilders.Find(x => x.OrderNum == focusNode.STT);
            if (bool.TryParse(comboBox.Text, out bool value))
                rsbItem.ListStringValue = new List<string> { value.ToString() };
            ucStringBuilderItemProperty.RTCSBItem = rsbItem;
            if (Action.AutoRun)
                RunAction();
        }
        private void tlStringItem_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            MyPropertiesItem focusNode = (MyPropertiesItem)tlStringItem.FocusedObject;
            SStringBuilderItem rsbItem = Action.StringBuilders.Find(x => x.OrderNum == focusNode.STT);

            if (e.Column == this.colType)
            {
                ComboBox Combobox = (ComboBox)e.Control;


                if (Combobox.SelectedItem == null)
                {
                    //tlvAction.BeginUpdate();
                    return;
                }
                e.NewValue = Combobox.SelectedItem;
            }
            if (e.Column == colItemName)
            {
                TextBox textedit = (TextBox)e.Control;
                rsbItem.Name = textedit.Text;
            }
            if (e.Column == this.colValue)
            {
                if (e.Control.GetType() == typeof(ComboBox))
                {
                    ComboBox Combobox = (ComboBox)e.Control;


                    if (Combobox.SelectedItem == null)
                    {
                        //tlvAction.BeginUpdate();
                        return;
                    }
                    e.NewValue = Combobox.SelectedItem;
                }
                else
                {

                    if (focusNode == null)
                        return;
                    TextBox textedit = (TextBox)e.Control;
                    switch (rsbItem.ValueStyle)
                    {
                        case EHTupleStyle.DateAndTime:
                        case EHTupleStyle.BooleanList:
                        case EHTupleStyle.StringList:
                        case EHTupleStyle.String:
                            {
                                rsbItem.ListStringValue = GlobFuncs.String2ListString(textedit.Text, cChars.Comma);
                                break;
                            }
                        case EHTupleStyle.Rectangle:
                        case EHTupleStyle.RectangleList:
                        case EHTupleStyle.RealList:
                        case EHTupleStyle.Real:
                        case EHTupleStyle.Point:
                        case EHTupleStyle.PointList:
                        case EHTupleStyle.Origin:
                        case EHTupleStyle.OriginList:
                        case EHTupleStyle.Integer:
                        case EHTupleStyle.IntegerList:
                            {
                                rsbItem.ListDoubleValue = GlobFuncs.Str2DoubleArr(textedit.Text, cChars.Comma);
                                break;
                            }
                    }
                    ucStringBuilderItemProperty.RTCSBItem = rsbItem;
                    if (Action.AutoRun) RunAction();
                }
            }


        }

        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Action == null || tlStringItem.SelectedObject == null) { return; }
            var comboBoxEdit = sender as ComboBox;

            SStringBuilderItem sbItem = Action.StringBuilders.Find(x => x.OrderNum == ((MyPropertiesItem)(tlStringItem.SelectedObject)).STT);
            if (comboBoxEdit != null)
                sbItem.ValueStyle = sbItem.GetValueType((string)comboBoxEdit.Text);
            this.colValue.PutValue(tlStringItem.SelectedObject, sbItem.RefID != Guid.Empty ? sbItem.ValueView + " " + sbItem.Ref : sbItem.ValueView);
            this.colType.PutValue(tlStringItem.SelectedObject, sbItem.GetItemType());
            ViewItemProperties(sbItem);
            tlStringItem.FinishCellEdit();
            if (Action.AutoRun) RunAction();
        }

        private void tlStringItem_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (Action == null) { return; }
            MyPropertiesItem FocusedNode = (MyPropertiesItem)tlStringItem.FocusedObject;
            if (FocusedNode == null) return;
            SStringBuilderItem _SBItem = Action.StringBuilders.Find(x => x.OrderNum == FocusedNode.STT);
            if (_SBItem == null) return;

            if (e.Model != null && (e.Column == this.colLink || e.Column == this.colRemove || e.Column == this.colDelete))
            {
                RTCE_StringBuilderItem_RowCellClickEventArgs eRTC = new RTCE_StringBuilderItem_RowCellClickEventArgs();
                eRTC.View = this;
                eRTC.Action = Action;
                eRTC.Node = FocusedNode;
                eRTC.SBItem = _SBItem;
                eRTC.CEnable = colEnable;
                eRTC.CValue = colValue;
                eRTC.CIDRef = colRefID;
                eRTC.treeList = tlStringItem;
                if (e.Column == this.colLink)
                {
                    if ( OnStringBuiderDetail_BtnLinkClickEvent != null)
                    {
                        OnStringBuiderDetail_BtnLinkClickEvent(this, eRTC);
                    }
                }
                else if (e.Column == this.colRemove)
                {
                    if (OnStringBuiderDetail_BtnRemoveLinkClickEvent != null)
                    {
                        OnStringBuiderDetail_BtnRemoveLinkClickEvent(this, eRTC);
                    }
                }
                else
                {
                    Action.StringBuilders.Remove(_SBItem);
                    tlStringItem.RemoveObject(FocusedNode);
                    ReOrderNum();
                    if (Action.AutoRun) RunAction();
                }
            }
            if(e.Column == colValue)
            {
                SStringBuilderItem _RSBItem = Action.StringBuilders.Find(x => x.OrderNum == FocusedNode.STT);
                if (_RSBItem == null || _RSBItem.RefID != Guid.Empty)
                {
                    return;
                }
                else
                {
                    switch (_RSBItem.ValueStyle)
                    {
                        case EHTupleStyle.DateAndTime:
                        case EHTupleStyle.BooleanList:
                        case EHTupleStyle.Boolean:
                        case EHTupleStyle.StringList:
                        case EHTupleStyle.String:
                            {
                                colValue.PutValue(FocusedNode, GlobFuncs.Ve2Str(_RSBItem.ListStringValue));
                                break;
                            }
                        case EHTupleStyle.Rectangle:
                        case EHTupleStyle.RectangleList:
                        case EHTupleStyle.RealList:
                        case EHTupleStyle.Real:
                        case EHTupleStyle.Point:
                        case EHTupleStyle.PointList:
                        case EHTupleStyle.Origin:
                        case EHTupleStyle.OriginList:
                        case EHTupleStyle.Integer:
                        case EHTupleStyle.IntegerList:
                            {
                                colValue.PutValue(FocusedNode, GlobFuncs.Ve2Str(_RSBItem.ListDoubleValue));
                                break;
                            }
                    }
                }
            }   
         
        }

        private void tlStringItem_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if(e.Column == colDelete)
            {

                e.Item.ImageSelector = Selecticon.Images.IndexOfKey("Delete");
                e.Item.Text = "";
            }    
            else if(e.Column == colLink)
            {
                e.SubItem.ImageSelector = Selecticon.Images.IndexOfKey("LinkProperty");
            }
            else if (e.Column == colRemove)
            {
                if(((MyPropertiesItem)e.Model).IDref != Guid.Empty)
                {
                    e.SubItem.ImageSelector = Selecticon.Images.IndexOfKey("RemoveLink");
                }
            }
        }

        private void btnRunStringBuilder_Click(object sender, EventArgs e)
        {
            RunAction();
        }
    }
}

