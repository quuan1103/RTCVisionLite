//using CommonTools;
using BrightIdeasSoftware;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public delegate void FocusedNodeChanged(object sender, RTCE_ActionList_FocusedNodeChangedEventArgs e);
    internal enum ESmallViewMode
    {
        Small = 0,
        Normal = 1,
        Large = 2
    }
    public partial class ucActionList : UserControl
    {
        private class MyActionNode
        {
            public string ActionName { get; set; }
            public string ActionCaption { get; set; }
            public bool IsLocate { get; set; }
            public bool IsConstructor { get; set; }
            public bool IsUpdate { get; set; }
            public bool IsNew { get; set; }
            public string Description { get; set; }
            public string UpdateDescription { get; set; }
            public int Type { get; set; }
        }
        private List<cAction> copyActions = new List<cAction>();
        private List<ActionTools> copyNodes = new List<ActionTools>();

        public static int NameAcID = -1;
        public static int DescriptionID = -1;
        private ESmallViewMode _smallViewMode = ESmallViewMode.Small;
        private cAction currentActionSelect = null;

        private List<Guid> viewedActions = new List<Guid>();
        private List<cAction> coppyActions = new List<cAction>();
        public event FocusedNodeChanged OnFocusedNodeChanged;
        private bool _isCanAddTool = true;
        private bool _isCanEditTool = true;
        private bool _isCanDeleteTool = true;
        private bool _isCanMovingTool = true;
        private bool _isCanLinkTool = true;
        private object draggingNode;
        public string MasterPropertyTypeName = string.Empty;
        private List<ActionTools> roots = new List<ActionTools>();

        public cAction masterAction;
        private class MyLine
        {
            public Point Begin;
            public Point End;
            public bool HaveBeginNode;
            public bool HaveEndNode;
        }
        private ActionTools DrawLinkLineNode;
        private List<MyLine> ParentLine = new List<MyLine>();
        private List<MyLine> ChildLine = new List<MyLine>();
        List<ActionTools> NodeChild = new List<ActionTools>();
        List<ActionTools> NodeParent = new List<ActionTools>();
        private bool IsDrawLine = false;
       // Graphics Graphics;
        // private ArrayList nodes = new ArrayList();



        [DefaultValue(false)]
        public EModeViewGrid ModelViewGrid { get; set; }
        public ucActionList()
        {
            InitializeComponent();
            tl.SelectedObject = tl.Roots;
            ModelViewGrid = EModeViewGrid.MainView;
            NameAcID = this.NameAc.Index;
            DescriptionID = this.colDescription.Index;
            tl.ClearObjects();
            tl.AllowDrop = true;
            tl.TreeColumnRenderer.IsShowLines = false;
            tl.SmallImageList = GlobVar.imlActionType16;
            tl.LargeImageList = GlobVar.imlActionType32;
            tl.StateImageList = tl.SmallImageList;
            tl.IsSimpleDropSink = true;
            tl.IsSimpleDragSource = true;
            //tl.HighlightBackgroundColor = Color.White;
            SimpleDropSink sink1 = (SimpleDropSink)tl.DropSink;
            sink1.AcceptExternal = true;
            sink1.CanDropBetween = true;
            tl.OwnerDraw = true;
            tl.OwnerDrawnHeader = true;
            //tl.DrawItem -= Tl_DrawItem;
            //tl.DrawItem += Tl_DrawItem;
            tl.DrawSubItem += (sender, e) =>
            {
                // Đoạn code này chỉ để kiểm tra sự kiện có chạy hay không
                MessageBox.Show("DrawColumnHeader triggered");
            };

           // Graphics = tl.CreateGraphics();
        }
        private void Tl_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();

            // Lấy Graphics để vẽ các đường line
           // Graphics g = e.Graphics;

            // Lấy vị trí của item hiện tại
            Rectangle bounds = e.Bounds;

            // Áp dụng quy tắc của bạn để quyết định vẽ đường line
            // Ví dụ: vẽ một đường ngang từ giữa của item
            Pen pen = new Pen(Color.Red, 2); // Màu đỏ và độ dày 2 pixel
            //g.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);

            // Gọi phương thức mặc định để vẽ item
            e.DrawText();
        }

        public void ViewData()
        {
            try
            {
                //roots = new List<ActionTools>();
                tl.BeginUpdate();
                //SetcontrolsValueWhenStart();
                ActionTools mainNode = null;


                cAction action = null;
                viewedActions = new List<Guid>();
                GlobVar.LockEvents = true;

                var orderedList = GlobVar.GroupActions.Actions.OrderBy(x => x.Value.STT).ToList();
                foreach (var t in orderedList)
                {
                    action = t.Value;
                    if (viewedActions.Contains(action.ID)) continue;

                    switch (action.ActionType)
                    {
                        case EActionTypes.MainAction:
                            mainNode = ViewData_ActionDetail(action, mainNode);
                            viewedActions.Add(action.ID);
                            break;
                        case EActionTypes.Branch:
                            ViewData_Branch(action, mainNode);
                            break;
                        case EActionTypes.Switch:
                            ViewData_Branch(action, mainNode);
                            break;
                        case EActionTypes.PassFail:
                            ViewData_Branch(action, mainNode);
                            break;
                        case EActionTypes.CounterLoop:
                            ViewData_Branch(action, mainNode);
                            break;
                        default:
                            //MyObjectViewItem ChildenNode = new MyObjectViewItem();
                            //ChildenNode.Name = action.Name.rtcValue;
                            //ChildenNode.Description = ChildenNode.Name;
                            //ChildenNode.Enable = true;
                            //ChildenNode.RunCount = string.Empty;
                            //ChildenNode.FailCount = string.Empty;
                            //ChildenNode.ProcessTime = string.Empty;
                            //ChildenNode.TotalTime = string.Empty;
                            //ChildenNode.AbortCause = string.Empty;
                            //ChildenNode.NodeType = (ENodeTypes)action.ActionType;
                            //ChildenNode.ID = action.ID;
                            //ChildenNode.IDGroup = GlobVar.GroupActions.ID;
                            //if (action.ActionType == EActionTypes.BranchItem)
                            //    ChildenNode.IDGroup = action.IDBranch;
                            ViewData_ActionDetail(action, mainNode);
                            viewedActions.Add(action.ID);
                            break;
                    }
                }

                tl.Roots = roots;
                tl.CanExpandGetter = x => (x as ActionTools).child.Count > 0;
                tl.ChildrenGetter = x => (x as ActionTools).child;
                tl.ExpandAll();
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                tl.EndUpdate();
                tl.Invalidate(true);
                GlobVar.LockEvents = false;
                tl.FocusedItem = null;
                if (tl.GetItemCount() > 0)
                    tl.SelectedObject = roots[0];
            }
        }

        private void ViewData_Branch(cAction branchAction, ActionTools parentNode)
        {
            branchAction.MyNode = ViewData_ActionDetail(branchAction, parentNode);
            viewedActions.Add(branchAction.ID);
            var listBranchItem = GlobVar.GroupActions.Actions.Values.Where(x => x.IDBranch == branchAction.ID).OrderBy(x => x.STT).ToList();
            if (listBranchItem.Any())
                foreach (cAction action in listBranchItem)
                    ViewData_BranchItem(action, branchAction.MyNode);
        }

        private void ViewData_BranchItem(cAction branchItemAction, ActionTools parentNode)
        {
            branchItemAction.MyNode = ViewData_ActionDetail(branchItemAction, parentNode);
            viewedActions.Add(branchItemAction.ID);
            var listActionInBranchItem = GlobVar.GroupActions.Actions.Values.Where(x => x.IDBranchItem == branchItemAction.ID).OrderBy(x => x.STT).ToList();
            if (listActionInBranchItem.Any())
                foreach (cAction action in listActionInBranchItem)
                {
                    switch (action.ActionType)
                    {
                        case EActionTypes.Branch:
                            ViewData_Branch(action, branchItemAction.MyNode);
                            break;
                        case EActionTypes.Switch:
                            ViewData_Branch(action, branchItemAction.MyNode);
                            break;
                        case EActionTypes.PassFail:
                            ViewData_Branch(action, branchItemAction.MyNode);
                            break;
                        case EActionTypes.CounterLoop:
                            ViewData_Branch(action, branchItemAction.MyNode);
                            break;
                        default:
                            ViewData_ActionDetail(action, branchItemAction.MyNode);
                            viewedActions.Add(action.ID);
                            break;
                    }
                }
        }

        public cAction _Action;
        ActionTools item;
        public ActionTools ViewData_ActionDetail(cAction action, ActionTools ParentNode, ActionTools positionNode = null, bool isBelow = true)
        {
            try
            {
                _Action = action;

                if (action.ActionType == EActionTypes.MainAction)
                {
                    item = new ActionTools();
                    item.Name = action.Name.rtcValue;
                    item.Description = action.Name.rtcValue;
                    item.Enable = action.Enable.rtcValue;//action.Enable.rtcValue;
                    item.RunCount = string.Empty;
                    item.FailCount = string.Empty;
                    item.ProcessTime = string.Empty;
                    item.TotalTime = string.Empty;
                    item.AbortCause = string.Empty;
                    item.NodeType = ENodeTypes.Group;
                    item.ActionType = action.ActionType;
                    item.ID = action.ID;
                    item.Parent = ParentNode;
                    //if (action.ActionType == EActionTypes.BranchItem)
                    //    item.IDGroup = action.IDBranch;
                    roots.Add(item);
                    action.MyNode = item;
                    tl.Roots = roots;
                    tl.AddObject(item);


                }
                else
                {
                    item = new ActionTools();
                    item.Name = action.Name.rtcValue;
                    item.Description = action.Name.rtcValue;
                    item.Enable = action.Enable.rtcValue;//action.Enable.rtcValue;
                    item.RunCount = string.Empty;
                    item.FailCount = string.Empty;
                    item.ProcessTime = string.Empty;
                    item.TotalTime = string.Empty;
                    item.AbortCause = string.Empty;
                    item.NodeType = ENodeTypes.Action;
                    item.ActionType = action.ActionType;
                    item.ID = action.ID;
                    item.Parent = ParentNode;
                    ParentNode.child.Add(item);
                    action.MyNode = item;
                    tl.Roots = new List<ActionTools>() { ParentNode };

                }
                //tl.GetSubItem(0, 1);
                //tl.DrawSubItem

                return item;
            }
            catch (Exception ex)
            {
                return item;
            }
            finally
            {
                tl.Update();
                tl.Refresh();
                tl.CanExpandGetter = x => (x as ActionTools).child.Count > 0;
                tl.ChildrenGetter = x => (x as ActionTools).child;
                tl.ExpandAll();


            }
            //action.MyNode = ParentNode;

        }
        public cAction GetActionFromNode(ActionTools node)
        {
            try
            {
                cAction action = null;
                if (node == null)
                    return action;
                if (GlobVar.GroupActions != null && GlobVar.GroupActions.Actions.ContainsKey(node.ID))
                    action = GlobVar.GroupActions.Actions[node.ID];

                return action;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public void AddNewNode(cAction action, ActionTools parentNode = null, ActionTools SelectedNode = null, bool isMoveNode = true, Boolean isReNumberOrder = true)
        {
            try
            {
                //GlobFuncs.EnableControl
                if (action == null) return;
                //_Action = action;
                // xác định lại node cha
                if (parentNode == null && tl.SelectedObject != null)
                {
                    cAction focusedAction = GetActionFormNode((ActionTools)tl.SelectedObject);
                    if (focusedAction != null)
                        if (focusedAction.ActionType == EActionTypes.BranchItem)
                            parentNode = (ActionTools)tl.SelectedObject;
                        else if (focusedAction.IDBranchItem != Guid.Empty && GlobVar.GroupActions.Actions.ContainsKey(focusedAction.IDBranchItem))
                            parentNode = GlobVar.GroupActions.Actions[focusedAction.IDBranchItem].MyNode;
                }
                parentNode = parentNode ?? tl.Roots.Cast<ActionTools>().ToList()[0];
                ActionTools newnode = new ActionTools();
                newnode.Name = action.Name.rtcValue;
                newnode.Description = newnode.Name;
                newnode.Enable = action.Enable.rtcValue;
                newnode.RunCount = string.Empty;
                newnode.FailCount = string.Empty;
                newnode.ProcessTime = string.Empty;
                newnode.TotalTime = string.Empty;
                newnode.AbortCause = string.Empty;
                newnode.NodeType = ENodeTypes.Action;
                newnode.ID = action.ID;
                newnode.IDBranch = action.IDBranch;
                newnode.IDBranchItem = action.IDBranchItem;
                newnode.IDGroup = GlobVar.GroupActions.ID;
                newnode.ActionType = action.ActionType;
                newnode.Parent = parentNode;
                //newnode.IDGroup = GlobVar.GroupActions.ID;
                if (action.ActionType == EActionTypes.Branch)
                {
                    newnode.IDGroup = action.IDBranch;

                }
                else if (action.ActionType == EActionTypes.BranchItem)
                {
                    newnode.IDGroup = action.IDBranch;
                    //newnode.ID = action.IDBranchItem;
                }
                //if (action.ActionType == EActionTypes.BranchItem)
                //{
                // action.MyNode = parentNode;
                //}
                //else
                //{
                //    action.MyNode = newnode;
                //}
                int IndexNode = parentNode.child.IndexOf((ActionTools)tl.SelectedObject);
                parentNode.child.Insert(IndexNode + 1, newnode);
                tl.BeginUpdate();
                tl.UpdateObject((ActionTools)action.MyNode);
                tl.RefreshObject(action.MyNode);
                tl.EndUpdate();

                action.MyNode = newnode;
                switch (action.ActionType)
                {
                    case EActionTypes.Branch:
                        {
                            var ListBranchActions = GlobVar.GroupActions.Actions.Values.Where(x => x.ActionType == EActionTypes.BranchItem && x.IDBranch == action.ID).OrderBy(x => x.STT).ToList();
                            if (ListBranchActions.Any())
                            {
                                for (int i = 0; i < ListBranchActions.Count(); i++)
                                    AddNewNode(ListBranchActions[i], action.MyNode, null, false, false);
                            }
                            break;
                        }
                    case EActionTypes.Switch:
                        {
                            var ListBranchActions = GlobVar.GroupActions.Actions.Values.Where(x => x.ActionType == EActionTypes.BranchItem && x.IDBranch == action.ID).OrderBy(x => x.STT).ToList();
                            if (ListBranchActions.Any())
                            {
                                for (int i = 0; i < ListBranchActions.Count(); i++)
                                    AddNewNode(ListBranchActions[i], action.MyNode, null, false, false);
                            }
                            break;
                        }

                    case EActionTypes.PassFail:
                        {
                            var ListBranchActions = GlobVar.GroupActions.Actions.Values.Where(x => x.ActionType == EActionTypes.BranchItem && x.IDBranch == action.ID).OrderBy(x => x.STT).ToList();
                            if (ListBranchActions.Any())
                            {
                                for (int i = 0; i < ListBranchActions.Count(); i++)
                                    AddNewNode(ListBranchActions[i], action.MyNode, null, false, false);
                            }
                            break;
                        }
                    case EActionTypes.CounterLoop:
                        {
                            var ListBranchActions = GlobVar.GroupActions.Actions.Values.Where(x => x.ActionType == EActionTypes.BranchItem && x.IDBranch == action.ID).OrderBy(x => x.STT).ToList();
                            if (ListBranchActions.Any())
                            {
                                for (int i = 0; i < ListBranchActions.Count(); i++)
                                    AddNewNode(ListBranchActions[i], action.MyNode, null, false);
                            }
                            break;
                        }

                }
                //else
                //    newnode.IDGroup = action.IDBranchItem;

                //ViewData_ActionDetail(action, parentNode);
                if (isReNumberOrder)
                    NumberedOrderAction(tl.Roots.Cast<ActionTools>().ToList());
                if (tl.SelectedObject != null)
                {
                    cAction focusedAction = GetActionFromNode((ActionTools)tl.FocusedObject);
                    if (focusedAction != null && focusedAction.ActionType == EActionTypes.PassFail)
                        ((ucPassFailActionDetails)focusedAction.ViewInfo).LoadLinkData();
                    else if (focusedAction != null && focusedAction.ActionType == EActionTypes.ResetTool)
                        ((ucResetToolActionDetail)focusedAction.ViewInfo).LoadLinkData();
                    tl.Expand(tl.FocusedObject);
                }
            }

            finally
            {

                tl.Update();
                tl.Refresh();
                tl.CanExpandGetter = x => (x as ActionTools).child.Count > 0;
                tl.ChildrenGetter = x => (x as ActionTools).child;
                tl.ExpandAll();
                GlobVar.Draw = false;
            }

        }

        public cAction GetActionFormNode(ActionTools node)
        {
            try
            {
                cAction action = null;
                if (node == null)
                    return action;
                ENodeTypes eNodeTypes = node.NodeType;
                if (GlobVar.GroupActions.Actions.ContainsKey(node.ID))
                    action = GlobVar.GroupActions.Actions[node.ID];
                return action;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void tl_FocusedNodeChange(object sender, RTCE_ActionList_FocusedNodeChangedEventArgs e)
        {
            if (e.node == null || GlobVar.LockEvents)
                return;
            EnableAllActionButton(e.node);
            RTCE_ActionList_FocusedNodeChangedEventArgs eRTC = new RTCE_ActionList_FocusedNodeChangedEventArgs();
            eRTC.node = e.node;
            eRTC.Oldnode = e.Oldnode;
            eRTC.Action = GetActionFormNode(e.node);
            GlobVar.CurrentTool = eRTC.Action != null ? eRTC.Action.STT : -1;
            if (e.node != null)
            {
                eRTC.PropertyLinkName = e.PropertyLinkName;
                if (OnFocusedNodeChanged != null)
                {
                    OnFocusedNodeChanged(sender, eRTC);
                }
            }
        }

        public void ChangeModeView(EModeViewGrid eModeViewGrid,
            string[] PropertyType,
            EHTupleStyle eHTupleStyle = EHTupleStyle.None,
            bool Obligatory = false)
        {
            try
            {
                tl.BeginUpdate();
                RemoveEventCustomCellStyle();
                switch (eModeViewGrid)
                {
                    case EModeViewGrid.MainView:
                        tl.BackColor = Color.White;
                        this.colTreeLine.IsVisible = true;
                        this.colActive.IsVisible = true;
                        this.colRunCount.IsVisible = true;
                        this.colFailCount.IsVisible = true;
                        this.colProcessTime.IsVisible = true;
                        this.colTotalTime.IsVisible = true;
                        this.colAbortCause.IsVisible = true;
                        break;
                    case EModeViewGrid.DetailView:
                        tl.BackColor = Color.CornflowerBlue;
                        this.colTreeLine.IsVisible = false;
                        this.colActive.IsVisible = false;
                        this.colRunCount.IsVisible = false;
                        this.colFailCount.IsVisible = false;
                        this.colProcessTime.IsVisible = false;
                        this.colTotalTime.IsVisible = false;
                        this.colAbortCause.IsVisible = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                SetEventCustomCellStyle();
                //SetHideShow(tl.)
                tl.EndUpdate();
                tl.ResumeLayout();

            }
        }

        public void RemoveEventCustomCellStyle()
        {
            tl.CellEditStarting -= tl_CustomNodeCellEdit;

        }
        public void SetEventCustomCellStyle()
        {
            tl.CellEditStarting += tl_CustomNodeCellEdit;

        }
        private void tl_CustomNodeCellEdit(object sender, CellEditEventArgs e)
        {
            if (GlobVar.LockEvents) return;
            if (e.Column == this.colActive)
            {
                ENodeTypes eNodeType = GlobFuncs.GetNodeType((ActionTools)e.RowObject, this.NodeType);
                if (eNodeType != ENodeTypes.Action)
                {
                    e.Column.PutValue(e.RowObject, null);
                    TextBox txtOut = new TextBox();
                    txtOut.Bounds = e.CellBounds;
                    e.Control = txtOut;

                }
                else if (e.Column == this.colbtnViewList)
                    CustomNodeCellEdit_Column_btnViewList(e);
            }
        }

        private void CustomNodeCellEdit_Column_btnViewList(CellEditEventArgs e)
        {
            SStringBuilderItem dataItem = null;
            TextBox txt = new TextBox();
            PropertyInfo propertyInfo = null;
            ENodeTypes eNodeTypes = GlobFuncs.GetNodeType((ActionTools)e.RowObject, this.NodeType);
            cAction Action = GetActionFormNode((ActionTools)e.RowObject);
            switch (eNodeTypes)
            {
                case ENodeTypes.Operand:
                    {
                        dataItem = null;
                        if (Action.DataItems != null)
                            dataItem = Action.DataItems.FirstOrDefault(x => x.Name == this.NameAc.GetValue(e.RowObject).ToString());
                        if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                            dataItem = Action.MyExpression.Operands.FirstOrDefault(x => x.Name == this.NameAc.GetValue(e.RowObject).ToString());
                        if (dataItem == null || dataItem.DataItems == null || dataItem.DataItems.Count <= 0)
                        {
                            txt = new TextBox();
                            txt.Bounds = e.CellBounds;
                            e.Control = txt;
                        }
                        else
                        {
                            Button btnViewList = new Button();
                            btnViewList.Bounds = e.CellBounds;
                            btnViewList.Text = "ViewList";
                        }
                        break;

                    }
                case ENodeTypes.DataItemParent:
                    {
                        dataItem = null;
                        if (tl.GetParent(e.RowObject) == null)
                        {
                            txt = new TextBox();
                            txt.Bounds = e.CellBounds;
                        }
                        else
                        {
                            if (Action.DataItems != null)
                                dataItem = Action.DataItems.FirstOrDefault(x => x.Name == this.NameAc.GetValue(e.RowObject).ToString());
                            if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                                dataItem = Action.MyExpression.Operands.FirstOrDefault(x => x.Name == this.NameAc.GetValue(e.RowObject).ToString());
                            if (dataItem == null)
                            {
                                propertyInfo = Action.GetType().GetProperty(this.NameAc.GetValue(tl.GetParent(e.RowObject)).ToString());
                                if (propertyInfo != null)
                                {
                                    RTCVariableType value = (RTCVariableType)propertyInfo.GetValue(Action, null);
                                    if (value.DataItems != null && value.DataItems.Count > 0)
                                    {
                                        Button btnViewList = new Button();
                                        btnViewList.Bounds = e.CellBounds;
                                        btnViewList.Text = "ViewList";
                                    }
                                    else
                                    {
                                        txt = new TextBox();
                                        txt.Bounds = e.CellBounds;
                                        e.Control = txt;
                                    }
                                }
                                else
                                {
                                    if (dataItem.DataItems == null || dataItem.DataItems.Count <= 0)
                                    {
                                        txt = new TextBox();
                                        txt.Bounds = e.CellBounds;
                                        e.Control = txt;
                                    }
                                    else
                                    {
                                        Button btnViewList = new Button();
                                        btnViewList.Bounds = e.CellBounds;
                                        btnViewList.Text = "ViewList";
                                    }
                                }

                            }
                            else
                            {
                                Button btnViewList = new Button();
                                btnViewList.Bounds = e.CellBounds;
                                btnViewList.Text = "ViewList";
                            }

                        }
                        break;
                    }
                case ENodeTypes.DataItemParentView:

                    {
                        dataItem = null;
                        if (tl.GetParent(e.RowObject) == null)
                        {
                            txt = new TextBox();
                            txt.Bounds = e.CellBounds;
                        }
                        else
                        {
                            if (Action.DataItems != null)
                                dataItem = Action.DataItems.FirstOrDefault(x => x.Name == this.NameAc.GetValue(e.RowObject).ToString());
                            if (Action.MyExpression != null && Action.MyExpression.Operands != null)
                                dataItem = Action.MyExpression.Operands.FirstOrDefault(x => x.Name == this.NameAc.GetValue(e.RowObject).ToString());
                            if (dataItem == null)
                            {
                                propertyInfo = Action.GetType().GetProperty(this.NameAc.GetValue(tl.GetParent(e.RowObject)).ToString());
                                if (propertyInfo != null)
                                {
                                    RTCVariableType value = (RTCVariableType)propertyInfo.GetValue(Action, null);
                                    if (value.DataItems != null && value.DataItems.Count > 0)
                                    {
                                        Button btnViewList = new Button();
                                        btnViewList.Bounds = e.CellBounds;
                                        btnViewList.Text = "ViewList";
                                    }
                                    else
                                    {
                                        txt = new TextBox();
                                        txt.Bounds = e.CellBounds;
                                        e.Control = txt;
                                    }
                                }
                                else
                                {
                                    if (dataItem.DataItems == null || dataItem.DataItems.Count <= 0)
                                    {
                                        txt = new TextBox();
                                        txt.Bounds = e.CellBounds;
                                        e.Control = txt;
                                    }
                                    else
                                    {
                                        Button btnViewList = new Button();
                                        btnViewList.Bounds = e.CellBounds;
                                        btnViewList.Text = "ViewList";
                                    }
                                }

                            }
                            else
                            {
                                Button btnViewList = new Button();
                                btnViewList.Bounds = e.CellBounds;
                                btnViewList.Text = "ViewList";
                            }

                        }
                        break;
                    }


                case ENodeTypes.DataItem:
                    {
                        TextBox txtData = new TextBox();
                        txtData.Bounds = e.CellBounds;
                        e.Control = new TextBox();
                        break;
                    }
                case ENodeTypes.DataItemView:
                    {
                        TextBox txtOut = new TextBox();
                        txtOut.Bounds = e.CellBounds;
                        e.Control = txtOut;
                        break;
                    }
                default:
                    {
                        propertyInfo = Action.GetType().GetProperty(this.NameAc.GetValue(e.RowObject).ToString());
                        if (!(propertyInfo is null))
                        {
                            RTCVariableType value = (RTCVariableType)propertyInfo.GetValue(Action, null);
                            {
                                if (value.DataItems != null && value.DataItems.Count > 0)
                                {
                                    Button btnViewList = new Button();
                                    btnViewList.Bounds = e.CellBounds;
                                    btnViewList.Text = "ViewList";
                                }
                                else
                                {
                                    TextBox txtOut = new TextBox();
                                    txtOut.Bounds = e.CellBounds;
                                    e.Control = txtOut;
                                    break;
                                }
                            }
                        }
                        break;
                    }
            }

        }



        private void EnableAllActionButton(ActionTools node)
        {
            GlobFuncs.EnableControl(btnDeleteAll, !GlobVar.GroupActions.IsRun && _isCanDeleteTool);
            GlobFuncs.VisibleControl(popDeleteAllTools, !GlobVar.GroupActions.IsRun && _isCanDeleteTool);
            if (node == null)
                return;
            if (!GlobVar.GroupActions.Actions.ContainsKey(Guid.Parse(this.ID.GetValue(node).ToString())))
            {
                return;
            }
            cAction action = GlobVar.GroupActions.Actions[Guid.Parse(this.ID.GetValue(node).ToString())];
            if (action != null)
            {
                cAction defaultAction = GlobVar.GroupActions.Actions.Values.FirstOrDefault(x =>
                x.IDBranch == (action.ActionType == EActionTypes.Switch ? action.ID : action.IDBranch) &&
                x.BranchItemType != null &&
                x.BranchItemType.rtcValue == cStrings.DefaultCase);

                GlobFuncs.VisibleControl(popDefaultBranch, action.ActionType == EActionTypes.Switch && defaultAction == null && _isCanAddTool);
                GlobFuncs.EnableControl(btnAddDefaultBranch, action.ActionType == EActionTypes.Switch && defaultAction == null && _isCanAddTool);
                GlobFuncs.VisibleControl(popAddBranch, action.ActionType == EActionTypes.Switch && _isCanAddTool);
                GlobFuncs.EnableControl(btnAddBranch, action.ActionType == EActionTypes.Switch && _isCanAddTool);
                GlobFuncs.VisibleControl(popSep1, !GlobVar.GroupActions.IsRun && _isCanEditTool);
                GlobFuncs.VisibleControl(popSep2, !GlobVar.GroupActions.IsRun && _isCanEditTool);
                GlobFuncs.VisibleControl(popSep3, !GlobVar.GroupActions.IsRun && _isCanEditTool);

                GlobFuncs.VisibleControl(toolStripSeparator4, !GlobVar.GroupActions.IsRun && _isCanEditTool);
                GlobFuncs.VisibleControl(toolStripSeparator5, !GlobVar.GroupActions.IsRun && _isCanEditTool);
                GlobFuncs.VisibleControl(toolStripSeparator6, !GlobVar.GroupActions.IsRun && _isCanEditTool);

                GlobFuncs.VisibleControl(popSetHightLights, !GlobVar.GroupActions.IsRun && _isCanEditTool);
                GlobFuncs.VisibleControl(popRemoveAllHighLights, !GlobVar.GroupActions.IsRun && _isCanEditTool);

                GlobFuncs.VisibleControl(popLockMoveTools, !GlobVar.GroupActions.IsRun && _isCanMovingTool);
                GlobFuncs.VisibleControl(popMoveUp, !GlobVar.GroupActions.IsRun && _isCanMovingTool && action.ActionType != EActionTypes.MainAction);
                GlobFuncs.VisibleControl(popMoveDown, !GlobVar.GroupActions.IsRun && _isCanMovingTool && action.ActionType != EActionTypes.MainAction);


                GlobFuncs.VisibleControl(popCopyTool, !GlobVar.GroupActions.IsRun && _isCanAddTool && action.ActionType != EActionTypes.MainAction);

                GlobFuncs.VisibleControl(popPasteTool, !GlobVar.GroupActions.IsRun && _isCanAddTool);
                GlobFuncs.VisibleControl(PopInsertTools, !GlobVar.GroupActions.IsRun && _isCanAddTool);

                if (action.ActionType == EActionTypes.BranchItem)
                {
                    if (GlobVar.GroupActions.Actions.TryGetValue(action.IDBranch, out cAction parentAction))
                    {

                        // xách định xem nó thuộc cha nào
                        if (parentAction.ActionType == EActionTypes.Switch)
                        {
                            GlobFuncs.VisibleControl(popSep2, !GlobVar.GroupActions.IsRun && _isCanAddTool);
                            GlobFuncs.VisibleControl(popAddBranch, !GlobVar.GroupActions.IsRun && _isCanAddTool);
                            GlobFuncs.VisibleControl(popDeleteBranch, !GlobVar.GroupActions.IsRun && _isCanAddTool);
                            GlobFuncs.VisibleControl(popDeleteAllBranch, !GlobVar.GroupActions.IsRun && _isCanAddTool);
                            GlobFuncs.EnableControl(btnAddBranch, !GlobVar.GroupActions.IsRun && _isCanAddTool);
                            GlobFuncs.EnableControl(btnDeleteBranch, !GlobVar.GroupActions.IsRun && _isCanAddTool);
                            GlobFuncs.EnableControl(btnDeteAllBranch, !GlobVar.GroupActions.IsRun && _isCanAddTool);
                        }
                    }
                    else
                    {
                        GlobFuncs.VisibleControl(popDefaultBranch, !GlobVar.GroupActions.IsRun && _isCanDeleteTool);
                        GlobFuncs.EnableControl(btnDeleteBranch, !GlobVar.GroupActions.IsRun && _isCanDeleteTool);
                    }
                }

                else if (action.ActionType == EActionTypes.Switch)
                {
                    GlobFuncs.VisibleControl(popSep1, !GlobVar.GroupActions.IsRun && _isCanEditTool);
                    GlobFuncs.VisibleControl(popMoveUp, !GlobVar.GroupActions.IsRun && _isCanAddTool);
                    GlobFuncs.VisibleControl(popMoveDown, !GlobVar.GroupActions.IsRun && _isCanEditTool);
                    GlobFuncs.VisibleControl(popDeleteTool, !GlobVar.GroupActions.IsRun && _isCanDeleteTool);

                    GlobFuncs.EnableControl(btnUp, !GlobVar.GroupActions.IsRun && _isCanMovingTool);
                    GlobFuncs.EnableControl(btnDown, !GlobVar.GroupActions.IsRun && _isCanMovingTool);
                    GlobFuncs.EnableControl(btnDelete, !GlobVar.GroupActions.IsRun && _isCanDeleteTool);
                }
                else if (action.ActionType == EActionTypes.MainAction)
                {

                    GlobFuncs.EnableControl(btnUp, false);
                    GlobFuncs.EnableControl(btnDown, false);
                    GlobFuncs.EnableControl(btnDelete, false);
                    GlobFuncs.EnableControl(btnDeleteBranch, false);
                    GlobFuncs.EnableControl(btnDeteAllBranch, false);
                }
                else
                {
                    GlobFuncs.VisibleControl(popMoveUp, !GlobVar.GroupActions.IsRun && _isCanMovingTool);
                    GlobFuncs.VisibleControl(popMoveUp, !GlobVar.GroupActions.IsRun && _isCanMovingTool);
                    GlobFuncs.VisibleControl(popDeleteTool, !GlobVar.GroupActions.IsRun && _isCanDeleteTool);

                    GlobFuncs.EnableControl(btnUp, !GlobVar.GroupActions.IsRun && _isCanMovingTool);
                    GlobFuncs.EnableControl(btnDown, !GlobVar.GroupActions.IsRun && _isCanMovingTool);
                    GlobFuncs.EnableControl(btnDelete, !GlobVar.GroupActions.IsRun && _isCanDeleteTool);

                }
            }
            GlobFuncs.VisibleControl(popSep1, popMoveUp.Visible || popMoveDown.Visible);
            GlobFuncs.VisibleControl(popSep2,
                popAddBranch.Visible || popDefaultBranch.Visible || popDeleteBranch.Visible ||
                popDeleteAllBranch.Visible);
            GlobFuncs.VisibleControl(toolStripSeparator4, popDeleteTool.Visible || popDeleteAllTools.Visible);
            GlobFuncs.VisibleControl(toolStripSeparator5, popLockMoveTools.Visible);
            GlobFuncs.VisibleControl(toolStripSeparator6, popCopyTool.Visible || popPasteTool.Visible || PopInsertTools.Visible);
            GlobFuncs.VisibleControl(toolStripSeparator7, popSetHightLights.Visible || popRemoveAllHighLights.Visible);



        }


        private void tl_Click(object sender, EventArgs e)
        {
            //if (tl.FocusedObject == null || GlobVar.LockEvents)
            //    return;

            //RTCE_ActionList_FocusedNodeChangedEventArgs eRTC = new RTCE_ActionList_FocusedNodeChangedEventArgs();
            //eRTC.node = (MyObjectViewItem)tl.FocusedObject;
            //eRTC.Action = GetActionFormNode((MyObjectViewItem)tl.FocusedObject);
            //GlobVar.CurrentTool = eRTC.Action != null ? eRTC.Action.STT : -1;
            //if (tl.FocusedObject != null)
            //{
            //    if (OnFocusedNodeChanged != null)
            //    {
            //        OnFocusedNodeChanged(sender, eRTC);
            //    }
            //}

        }
        private void TheRichNumber()
        {
            Random random = new Random();
            string LuckyNumberTogetVietLot = string.Empty;
            int[] numbers = new int[12];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 != 0) // Vị trí chẵn (do mảng bắt đầu từ 0)
                {
                    numbers[i] = random.Next(0, 10); // Số ngẫu nhiên từ 0 đến 9
                    if (numbers[i - 1] == 5) // Kiểm tra nếu số lẻ là 5 và vị trí chẵn liền kề tồn tại
                    {
                        numbers[i] = random.Next(0, 6); // Đặt số ở vị trí chẵn liền kề nhỏ hơn 6
                    }
                }
                else // Vị trí lẻ
                {

                    numbers[i] = random.Next(0, 6); // Số ngẫu nhiên từ 0 đến 5

                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                LuckyNumberTogetVietLot += numbers[i].ToString();
            }
            MessageBox.Show(LuckyNumberTogetVietLot, "Con số làm giàu là: ");
        }
        private void tl_SelectionChanged(object sender, EventArgs e)
        {
            // TheRichNumber();
            try
            {
                if (tl.SelectedObject == null || GlobVar.LockEvents)
                    return;

                RTCE_ActionList_FocusedNodeChangedEventArgs eRTC = new RTCE_ActionList_FocusedNodeChangedEventArgs();
                eRTC.node = (ActionTools)tl.SelectedObject;
                eRTC.Action = GetActionFormNode((ActionTools)tl.SelectedObject);
                GlobVar.CurrentTool = eRTC.Action != null ? eRTC.Action.STT : -1;

                if (GlobVar.CurrentTool != eRTC.Action.STT)
                {
                    txtSearch.Text = string.Empty;
                }
                if (tl.SelectedIndex != -1)
                {
                    //if (eRTC.Action.HighLights.rtcValue)
                    //{
                    //    var style = new SimpleItemStyle
                    //    {
                    //        BackColor = Color.LightYellow,
                    //    };
                    //    tl.ApplyRowStyle(tl.SelectedItem, style);
                    //}


                    if (OnFocusedNodeChanged != null)
                    {
                        OnFocusedNodeChanged(sender, eRTC);

                    }
                }

                // Graphics.DrawLine(pen, new Point(500, 500), new Point(600, 600));


            }
            finally
            {
                tl.Refresh();
                //int targetIndex = tl.IndexOf(tl.FocusedObject);
                //// Lấy vị trí của các item
                //Rectangle rectTarget = tl.GetItemRect(targetIndex);
                //Rectangle rectTop = tl.GetItemRect(0);

                //// Tạo đối tượng Pen để vẽ đường line
                //using (Pen pen = new Pen(Color.Red, 5))
                //{
                //    //Lấy đối tượng Graphics từ TreeListView
                //    using (Graphics g = tl.CreateGraphics())
                //    {
                //       // Vẽ đường line từ điểm(rectTarget.X + columnWidth, rectTarget.Y) đến(columnWidth, rectTop.Y)
                //        g.DrawLine(pen,
                //                   new Point(rectTarget.X + colDescription.Width, rectTarget.Y),
                //                   new Point(colDescription.Width, rectTop.Y));
                //        AbstractOverlay a = new AbstractOverlay();
                //        a.Draw(tl ,g, rectTarget);
                //        tl.AddOverlay(a);
                //    }

                //}
                ////}    

            }

        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            if (tl.SelectedObjects == null || tl.SelectedObjects.Count <= 0)
            {
                cMessageBox.Warning(cMessageContent.War_NotSelectedToolToMoveUp);
                return;
            }
            object focusedNode = tl.SelectedObject;
            ActionTools ParentNode = ((ActionTools)(focusedNode)).Parent;
            if (ParentNode == null)
                return;

            List<ActionTools> AllNode = tl.SelectedObjects.Cast<ActionTools>().ToList();
            var orderList = AllNode.OrderBy(x => tl.IndexOf(x)).ToList();
            int backNodeIndex;
            foreach (ActionTools treeListNode in orderList)
            {
                ENodeTypes eNodeType = GlobFuncs.GetNodeType(treeListNode, this.NodeType);
                if (eNodeType != ENodeTypes.Action)
                    continue;
                backNodeIndex = ParentNode.child.IndexOf(treeListNode) - 1;
                if (backNodeIndex < 0)
                    break;
                ParentNode.child.Remove(treeListNode);
                ParentNode.child.Insert(backNodeIndex, treeListNode);
                tl.RefreshObject(ParentNode);
            }
            // NumberedOrderAction(ParentNode.child);
            NumberedOrderAction(tl.Objects.Cast<ActionTools>().ToList());
            tl.SelectObject(focusedNode);
            //tl_SelectionChanged(sender, e);

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (tl.SelectedObjects == null || tl.SelectedObjects.Count <= 0)
            {
                cMessageBox.Warning(cMessageContent.War_NotSelectedToolToMoveUp);
                return;
            }
            object focusedNode = tl.SelectedObject;
            ActionTools ParentNode = ((ActionTools)(focusedNode)).Parent;
            if (ParentNode == null)
                return;
            object backNode = null;
            List<ActionTools> AllNode = tl.SelectedObjects.Cast<ActionTools>().ToList();
            var orderList = AllNode.OrderBy(x => tl.IndexOf(x)).ToList();
            int backNodeIndex;
            foreach (ActionTools treeListNode in orderList)
            {
                ENodeTypes eNodeType = GlobFuncs.GetNodeType(treeListNode, this.NodeType);
                if (eNodeType != ENodeTypes.Action)
                    continue;
                backNodeIndex = ParentNode.child.IndexOf(treeListNode) + 1;
                if (backNodeIndex >= ParentNode.child.Count)
                    break;
                ParentNode.child.Remove(treeListNode);
                ParentNode.child.Insert(backNodeIndex, treeListNode);
                tl.RefreshObject(ParentNode);
            }
            //NumberedOrderAction(ParentNode.child);
            NumberedOrderAction(tl.Objects.Cast<ActionTools>().ToList());
            tl.SelectObject(focusedNode);
            //tl_SelectionChanged(sender, e);
        }

        private void tl_MouseDown(object sender, MouseEventArgs e)
        {

            if (contextMenuStrip.InvokeRequired)
                contextMenuStrip.Invoke((MethodInvoker)delegate
                {
                    contextMenuStrip.Hide();
                });
            else contextMenuStrip.Hide();

            tl.ContextMenuStrip = null;
            DisableAllActionButton();
            if (GlobVar.GroupActions.IsRun)
                return;
            if (sender is TreeListView tree)
            {
                var rowinfo = tl.MouseMoveHitTest;
                if (rowinfo != null && rowinfo.Item != null)
                {
                    popMoveUp.Visible = false;
                    popMoveDown.Visible = false;
                    popAddBranch.Visible = false;
                    popDefaultBranch.Visible = false;
                    popDeleteTool.Visible = false;
                    popDeleteBranch.Visible = false;
                    popDeleteAllBranch.Visible = false;
                    popSep1.Visible = false;
                    popSep2.Visible = false;
                    popDeleteAllTools.Visible = true;
                    EnableAllActionButton((ActionTools)rowinfo.RowObject);
                    if (!GlobVar.GroupActions.Actions.ContainsKey(Guid.Parse(this.ID.GetValue((ActionTools)rowinfo.RowObject).ToString())))
                    {
                        return;
                    }
                    cAction action = GlobVar.GroupActions.Actions[Guid.Parse(this.ID.GetValue((ActionTools)rowinfo.RowObject).ToString())];

                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        //tl.SelectedObject = action?.MyNode;
                        tl.SelectedColumn = NameAc;
                        if (!ModifierKeys.HasFlag(Keys.Control))
                            tl.ClearHotItem();
                        tl.SelectObject(tl.FocusedItem);
                        tl.ContextMenuStrip = contextMenuStrip;
                    }
                }
            }
        }

        private void DisableAllActionButton()
        {
            GlobFuncs.EnableControl(btnUp, false);
            GlobFuncs.EnableControl(btnDown, false);
            GlobFuncs.EnableControl(btnAddBranch, false);
            GlobFuncs.EnableControl(btnAddDefaultBranch, false);

            GlobFuncs.EnableControl(btnDelete, false);
            GlobFuncs.EnableControl(btnDeleteBranch, false);
            GlobFuncs.EnableControl(btnDeteAllBranch, false);
            GlobFuncs.EnableControl(btnDeleteAll, false);
        }
        internal void EnableAllActionButton()
        {
            EnableAllActionButton((ActionTools)tl.SelectedObject);
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (GlobVar.GroupActions.IsRun)
            {
                e.Cancel = true;
                return;
            }
            GlobVar.LockEvents = true;
            popSmallViewMode.Checked = _smallViewMode == ESmallViewMode.Small;
            popNomalViewMode.Checked = _smallViewMode == ESmallViewMode.Normal;
            popLargeViewMode.Checked = _smallViewMode == ESmallViewMode.Large;
            popPasteTool.Enabled = copyNodes != null && copyNodes.Count > 0;
            popSetHightLights.Visible = false;
            if (tl.SelectedObject != null)
            {
                EnableAllActionButton((ActionTools)tl.SelectedObject);
            }
            GlobVar.LockEvents = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTools();
        }

        public void DeleteTools()
        {
            try
            {
                ActionTools SelectedNode = (ActionTools)tl.FocusedObject;
                ActionTools ParentNode = (ActionTools)SelectedNode.Parent;


                if (tl.SelectedItem == null || tl.SelectedIndices.Count <= 0)
                {
                    cMessageBox.Warning(cMessageContent.War_NotSelectedToolToDelete);
                    return;
                }
                if (cMessageBox.Question_YesNo(cMessageContent.Que_DeleteObject) == DialogResult.No)
                    return;
                GlobVar.LockEvents = true;
                // int NodeIndex = 0;
                List<ActionTools> AllNode = tl.SelectedObjects.Cast<ActionTools>().ToList();
                foreach (ActionTools treeListNode in AllNode)
                {
                    if (ParentNode == null)
                        return;
                    cAction action = GetActionFormNode(treeListNode);
                    if (action.ActionType == EActionTypes.MainAction)
                        continue;
                    GlobVar.GroupActions.RemoveAction(Guid.Parse(this.ID.GetValue((ActionTools)treeListNode).ToString()));
                    //NodeIndex = ParentNode.child.IndexOf(treeListNode);
                    ParentNode.child.Remove(treeListNode);
                    tl.BeginUpdate();
                    tl.RefreshObject(ParentNode);
                    tl.EndUpdate();
                }
                List<ActionTools> Parent = tl.Objects.Cast<ActionTools>().ToList();
                NumberedOrderAction(Parent);
                tl.SelectedObject = ParentNode;
                GlobVar.LockEvents = false;
                //if (Parent[0].child.Count > 0)
                //{
                //    var FoccusNode = Parent[0].child[NodeIndex - 1];
                //    tl.SelectedObject = null;
                //    tl.SelectedObject = FoccusNode;
                //}
                //else
                //{
                //    var FoccusNode = Parent[0];
                //    tl.SelectedObject = null;
                //    tl.SelectedObject = FoccusNode;
                //}
            }
            finally
            {
                GlobVar.LockEvents = false;
                tl.Refresh();

            }
        }
        private void NumberedOrderAction(List<ActionTools> Nodes)
        {
            GlobVar.GroupActions.STT = 1;
            foreach (cAction _Action in GlobVar.GroupActions.Actions.Values)
            {
                _Action.IDBranch = Guid.Empty;
                _Action.IDBranchItem = Guid.Empty;
            }
            NumberedOrderAction_Run(Nodes);
            GlobVar.GroupActions.RebuildPassFailLinkItem();
            GlobVar.GroupActions.RebuildResetToolsItem();
            if (tl.SelectedObject != null)
            {
                cAction FocusAction = GetActionFormNode((ActionTools)tl.SelectedObject);

                if (FocusAction != null && FocusAction.ActionType == EActionTypes.PassFail && FocusAction.ViewInfo != null)
                    ((ucPassFailActionDetails)FocusAction.ViewInfo).LoadLinkData();
            }
            GlobVar.GroupActions.DataChanged = true;

        }
        private void NumberedOrderAction_Run(List<ActionTools> Nodes)
        {
            if (Nodes == null || Nodes.Count <= 0) { return; }
            foreach (ActionTools item in Nodes)
            {
                ENodeTypes eNodeType = GlobFuncs.GetNodeType(item, this.NodeType);
                //int test = tl.IndexOf(item);
                //TreeNode Node = tl.GetModelObject(tl.IndexOf(item)) as TreeNode;
                if (eNodeType == ENodeTypes.Group)
                {
                    //GlobVar.GroupActions.MainAction.Level = Node.Level;
                    NumberedOrderAction(item.child);
                }
                else if (eNodeType == ENodeTypes.Action)
                {
                    if (!GlobVar.GroupActions.Actions.TryGetValue(Guid.Parse(this.ID.GetValue(item).ToString()), out cAction Action))
                        return;
                    if (Action != null)
                    {
                        Action.STT = GlobVar.GroupActions.STT;
                        GlobVar.GroupActions.STT += 1;
                        if (Action.MyNode.Parent != null)
                        {
                            var test = Guid.Parse(Action.MyNode.Parent.ID.ToString());
                            cAction parentAction = GlobVar.GroupActions.Actions[Guid.Parse(Action.MyNode.Parent.ID.ToString())];
                            if (parentAction.ActionType == EActionTypes.Branch ||
                               parentAction.ActionType == EActionTypes.Switch ||
                               parentAction.ActionType == EActionTypes.PassFail ||
                               parentAction.ActionType == EActionTypes.CounterLoop)
                                Action.IDBranch = parentAction.ID;
                            else if (parentAction.ActionType == EActionTypes.BranchItem)
                                Action.IDBranchItem = parentAction.ID;
                        }
                        //}
                        NumberedOrderAction_Run(item.child);

                    }
                    ;
                }

            }

        }
        public void DrawLinkLine(ActionTools Node)
        {
            DrawLinkLineNode = null;
            if (GlobVar.GroupActions == null ||
                GlobVar.GroupActions.IsRun ||
                Node == null)
                return;

            IsDrawLine = false;

            if (GlobVar.LockEvents ||
                GlobVar.IsLinkMode ||
                GlobVar.IsLinkStringBuilderItemMode ||
                GlobVar.IsLinkCsvWriteValue ||
                GlobVar.IsLinkImageFilterMode)
            {
                return;
            }
            ParentLine.Clear();
            ChildLine.Clear();

            //if (TreeLine.VisibleIndex == -1)
            //    return;
            DrawLinkLineNode = Node;
            //Check xem node này có là node cha hay ko
            cAction ActionSrc = GetActionFromNode(Node);
            cAction action = null;
            if (ActionSrc == null) return;
            NodeChild = new List<ActionTools>();
            var orderedList = GlobVar.GroupActions.Actions.OrderBy(x => x.Value.STT).ToList();
            for (int i = 0; i < orderedList.Count; i++)
            {
                bool isHaveChild = false;
                action = orderedList[i].Value;
                if (action.ID == ActionSrc.ID)
                    continue;

                foreach (PropertyInfo nProperty in action.GetType().GetProperties())
                {
                    RTCVariableType rtcValue = (RTCVariableType)action.GetType().GetProperty(nProperty.Name)?.GetValue(action, null);

                    if (rtcValue == null || rtcValue.rtcIDRef == Guid.Empty)
                    {
                        continue;
                    }

                    if (rtcValue.rtcIDRef == ActionSrc.ID)
                    {
                        NodeChild.Add(action.MyNode);
                        isHaveChild = true;
                        //NodeChild.Add(FindActionNode(GlobVar.GroupActions.ID, action.ID, i == 0 ? ENodeTypes.Group : ENodeTypes.Action));
                        break; // Chỉ cần nhận nó có tiếp nhận 1 giá trị nào đó từ cha mà thôi
                    }
                }

                if (action.DataItems != null && !isHaveChild)
                    foreach (var dataItem in action.DataItems)
                    {
                        if (dataItem.RefID == Guid.Empty) continue;
                        if (dataItem.RefID == ActionSrc.ID)
                        {
                            NodeChild.Add(action.MyNode);
                            break; // Chỉ cần nhận nó có tiếp nhận 1 giá trị nào đó từ cha mà thôi
                        }
                    }

                if (action.MyExpression != null && action.MyExpression.Operands != null && !isHaveChild)
                    foreach (var operandItem in action.MyExpression.Operands)
                    {
                        if (operandItem.RefID == Guid.Empty) continue;
                        if (operandItem.RefID == ActionSrc.ID)
                        {
                            NodeChild.Add(action.MyNode);
                            break; // Chỉ cần nhận nó có tiếp nhận 1 giá trị nào đó từ cha mà thôi
                        }
                    }
            }
            // Tìm tất cả các node cha có thể có của node này
            NodeParent = new List<ActionTools>();
            for (int i = 0; i < orderedList.Count; i++)
            {
                action = orderedList[i].Value;
                if (action.ID == ActionSrc.ID)
                    continue;

                foreach (PropertyInfo nProperty in ActionSrc.GetType().GetProperties())
                {
                    RTCVariableType rtcValue = (RTCVariableType)ActionSrc.GetType().GetProperty(nProperty.Name)?.GetValue(ActionSrc, null);

                    if (rtcValue == null || rtcValue.rtcIDRef == Guid.Empty)
                    {
                        continue;
                    }

                    if (rtcValue.rtcIDRef == action.ID)
                    {
                        NodeParent.Add(action.MyNode);
                        //NodeParent.Add(FindActionNode(GlobVar.GroupActions.ID, Action.ID, i == 0 ? ENodeTypes.Group : ENodeTypes.Action));
                        break; // Chỉ cần nhận nó có tiếp nhận 1 giá trị nào đó từ cha mà thôi
                    }
                }

                if (ActionSrc.DataItems != null)
                    foreach (var dataItem in ActionSrc.DataItems)
                    {
                        if (dataItem.RefID == Guid.Empty) continue;
                        if (dataItem.RefID == action.ID)
                        {
                            NodeParent.Add(action.MyNode);
                            break; // Chỉ cần nhận nó có tiếp nhận 1 giá trị nào đó từ cha mà thôi
                        }
                    }

                if (ActionSrc.MyExpression != null && ActionSrc.MyExpression.Operands != null)
                    foreach (var operandItem in ActionSrc.MyExpression.Operands)
                    {
                        if (operandItem.RefID == Guid.Empty) continue;
                        if (operandItem.RefID == action.ID)
                        {
                            NodeParent.Add(action.MyNode);
                            break; // Chỉ cần nhận nó có tiếp nhận 1 giá trị nào đó từ cha mà thôi
                        }
                    }
            }

            //// Tiến hành vẽ các đường liên kết
            //// Vẽ đường liên kết cha
            //bool BothParentAndChild = ((NodeChild.Count > 0) && (NodeParent.Count > 0));
            //// + Xác định trung điểm của Node đang đứng
            //TreeListNode ReplaceNode = null;
            //if (tl.ViewInfo.RowsInfo[Node] == null)
            //{
            //    if (tl.TopVisibleNodeIndex >= 0)
            //        ReplaceNode = tl.GetNodeByVisibleIndex(tl.TopVisibleNodeIndex);

            //    if (tl.ViewInfo.RowsInfo[Node] == null || ReplaceNode == null || tl.ViewInfo.RowsInfo[ReplaceNode] == null)
            //    {
            //        tl.Invalidate();
            //        return;
            //    }
            //}

            //Rectangle r;
            //DevExpress.XtraTreeList.ViewInfo.CellInfo cellInfo = null;
            //if (ReplaceNode != null)
            //    cellInfo = tl.ViewInfo.RowsInfo[ReplaceNode].Cells.Count > TreeLine.VisibleIndex ?
            //        (tl.ViewInfo.RowsInfo[ReplaceNode].Cells[TreeLine.VisibleIndex] as
            //            DevExpress.XtraTreeList.ViewInfo.CellInfo) : null;
            //else
            //    cellInfo = tl.ViewInfo.RowsInfo[Node].Cells.Count > TreeLine.VisibleIndex ?
            //        (tl.ViewInfo.RowsInfo[Node].Cells[TreeLine.VisibleIndex] as
            //            DevExpress.XtraTreeList.ViewInfo.CellInfo) : null;
            //if (cellInfo == null)
            //    return;

            //r = cellInfo.Bounds;

            //int XCenterSrc = r.Left;
            //int YCenterSrc = r.Top + (int)(r.Height / 2);
            //int Extend = BothParentAndChild ? 5 : 0;

            //int X, Y = 0;
            //MyLine mLine = new MyLine();
            //bool isHaveBeginNode = true;
            //if (tl.ViewInfo.RowsInfo[Node] != null)
            //    foreach (TreeListNode item in NodeParent)
            //    {
            //        isHaveBeginNode = true;
            //        TreeListNode item1 = item;
            //        //if (tl.ViewInfo.RowsInfo[item] == null) continue;
            //        if (tl.ViewInfo.RowsInfo[item] == null && tl.TopVisibleNodeIndex >= 0)
            //        {
            //            item1 = tl.GetNodeByVisibleIndex(tl.TopVisibleNodeIndex);
            //            isHaveBeginNode = false;
            //        }
            //        if (tl.ViewInfo.RowsInfo[item1] == null)
            //            continue;


            //        Rectangle rp = (tl.ViewInfo.RowsInfo[item1].Cells[TreeLine.VisibleIndex] as DevExpress.XtraTreeList.ViewInfo.CellInfo).Bounds;
            //        X = rp.Left;
            //        Y = rp.Top + (int)(rp.Height / 2);

            //        MyLine getLine = ParentLine.FirstOrDefault(x =>
            //            x.Begin.X == X && x.Begin.Y == Y && x.End.X == XCenterSrc && x.End.Y == YCenterSrc - Extend);
            //        if (getLine == null)
            //        {
            //            mLine = new MyLine
            //            {
            //                Begin = new Point(X, Y),
            //                End = new Point(XCenterSrc, YCenterSrc - Extend),
            //                HaveBeginNode = isHaveBeginNode
            //            };
            //            ParentLine.Add(mLine);
            //        }
            //    }

            //if (NodeChild.Count > 0)
            //{
            //    bool isHaveEndNode = false;
            //    foreach (TreeListNode item in NodeChild)
            //    {
            //        isHaveEndNode = true;
            //        TreeListNode item1 = item;
            //        if (tl.ViewInfo.RowsInfo[item] == null)
            //        {
            //            item1 = null;
            //            action = GetActionFromNode(item);
            //            orderedList = GlobVar.GroupActions.Actions.OrderByDescending(x => x.Value.STT).ToList();
            //            foreach (var bottomAction in orderedList)
            //            {
            //                if (bottomAction.Value.STT > action.STT) continue;
            //                if (tl.ViewInfo.RowsInfo[bottomAction.Value.MyNode] == null) continue;
            //                item1 = bottomAction.Value.MyNode;
            //                isHaveEndNode = false;
            //                break;
            //            }
            //        }
            //        if (item1 == null) continue;
            //        //if (tl.ViewInfo.RowsInfo[item] == null)
            //        //    item1 = tl.GetNodeByVisibleIndex(tl.index);
            //        Rectangle rp = (tl.ViewInfo.RowsInfo[item1].Cells[TreeLine.VisibleIndex] as DevExpress.XtraTreeList.ViewInfo.CellInfo).Bounds;
            //        X = rp.Left;
            //        Y = rp.Top + (int)(rp.Height / 2);
            //        mLine = new MyLine
            //        {
            //            Begin = new Point(XCenterSrc, YCenterSrc + Extend),
            //            End = new Point(X, Y),
            //            HaveEndNode = isHaveEndNode
            //        };
            //        ChildLine.Add(mLine);
            //    }
            //}

            tl.Invalidate();
        }

        internal void DeleteAllTool()
        {
            try
            {
                if (cMessageBox.Question_YesNo(cMessageContent.Que_DeleteObject) == DialogResult.No)
                    return;
                if (cMessageBox.Question_YesNo(cMessageContent.Que_DeleteObject) == DialogResult.No)
                    return;
                GlobVar.LockEvents = true;
                tl.BeginUpdate();
                GlobVar.GroupActions.RemoveAllAction();
                List<ActionTools> Parent = tl.Roots.Cast<ActionTools>().ToList();
                RemoveAllActionNode(Parent);
                tl.RefreshObject(Parent[0]);
                NumberedOrderAction(Parent);
                GlobVar.LockEvents = false;

                tl.FocusedObject = Parent[0];

            }
            finally
            {
                GlobVar.LockEvents = false;
                tl.EndUpdate();
            }
        }

        private void RemoveAllActionNode(List<ActionTools> Nodes)
        {

            if (Nodes == null || Nodes.Count <= 0) { return; }
            List<ActionTools> ListRemove = new List<ActionTools>();
            ActionTools MainNode = tl.Objects.Cast<ActionTools>().ToList()[0];
            MainNode.child.Clear();
            //foreach (MyObjectViewItem item in Nodes)
            //{
            //    ENodeTypes eNodeType = GlobFuncs.GetNodeType(item, this.NodeType);
            //    if (eNodeType == ENodeTypes.Group)
            //    {
            //        RemoveAllActionNode(item.child);
            //    }    
            //    else if (eNodeType == ENodeTypes.Action)
            //    {
            //        ListRemove.Add(item);
            //    }    
            //} 
            //for (int i = 0; i<ListRemove.Count(); i++)
            //{
            //    //MainNode.child.RemoveAt(i);
            //}    

        }
        internal void LockEditTools()
        {
            popLockMoveTools.Checked = !popLockMoveTools.Checked;
        }
        private void tl_DragEnter(object sender, DragEventArgs e)
        {
            // Kiểm tra xem dữ liệu có phải là một node hợp lệ không
            e.Effect = e.AllowedEffect;
        }
        private void tl_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                OLVListItem draggedItem = (OLVListItem)e.Data.GetData(typeof(OLVListItem));

                if (draggedItem == null) return;
                if ((ENodeTypes)this.NodeType.GetValue(draggedItem.RowObject) != ENodeTypes.Action)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
                else
                {
                    Guid IDAction = Guid.Parse(this.ID.GetValue(draggedItem.RowObject).ToString());
                    cAction Action = GlobVar.GroupActions.Actions[IDAction];
                    if (Action.ActionType == EActionTypes.BranchItem)
                    {
                        cAction ActionBranch = GlobVar.GroupActions.Actions[Action.IDBranch];
                        if (Action.ActionType == EActionTypes.Branch ||
                            ActionBranch.ActionType == EActionTypes.PassFail ||
                            ActionBranch.ActionType == EActionTypes.CounterLoop)
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }
                    }
                }

                ActionTools draggedNode = (ActionTools)draggedItem.RowObject;
                ActionTools parentNode = (ActionTools)draggedNode.Parent;
                Point dropLocation = tl.PointToClient(new Point(e.X, e.Y));
                OLVListItem targetItem = tl.GetItemAt(dropLocation.X, dropLocation.Y) as OLVListItem;
                if (targetItem == null) return;
                ActionTools targetNode = (ActionTools)targetItem.RowObject;
                if (IsAncestor(draggedNode, targetNode))
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                // Loại bỏ draggedNode từ node cha cũ
                if (parentNode != null)
                {
                    parentNode.child.Remove(draggedNode);
                }


                // Thêm draggedNode vào node mới
                targetNode.child.Add(draggedNode);

                // Tạm thời tắt cập nhật giao diện người dùng

                // Xóa tất cả các node và cập nhật lại dữ liệu

                //tl.Roots = new List<MyObjectViewItem>() { parentNode };// Thay YourRootNodes bằng dữ liệu cây của bạn
                // tl.RefreshObject(targetNode);
                tl.RefreshObject(parentNode);
                tl.SelectedObject = targetNode;
                e.Effect = DragDropEffects.Move;
                // Kích hoạt lại cập nhật giao diện người dùng



            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần thiết
            }
            finally
            {
                tl.ExpandAll();
                GlobVar.GroupActions.DataChanged = true;
                e.Effect = DragDropEffects.Move;
            }
        }
        private bool IsAncestor(ActionTools potentialAncestor, ActionTools node)
        {
            // Kiểm tra xem potentialAncestor có phải là tổ tiên của node không
            while (node != null)
            {
                if (node == potentialAncestor)
                {
                    return true;
                }
                node = node.Parent;
            }
            return false;
        }
        private ActionTools FindParentNode(List<ActionTools> nodes, ActionTools targetNode)
        {
            foreach (ActionTools node in nodes)
            {
                if (node.child.Contains(targetNode))
                {
                    // Tìm thấy node cha
                    return node;
                }

                // Tiếp tục tìm kiếm trong các node con nếu có
                ActionTools parentNode = FindParentNode(node.child, targetNode);
                if (parentNode != null)
                {
                    return parentNode;
                }
            }

            // Không tìm thấy node cha
            return null;
        }
        private bool IsNodeChildOf(OLVListItem node, OLVListItem potentialParent)
        {
            // Kiểm tra xem node có phải là con của potentialParent không
            OLVListItem current = node;

            while (current != null)
            {
                if (current == potentialParent)
                {
                    return true;
                }
                current = current;
            }

            return false;
        }

        private void tl_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //draggingNode = e.Item;
            //tl.DoDragDrop(e.Item, DragDropEffects.Move);
            draggingNode = e.Item;
            tl.DoDragDrop(e.Item, DragDropEffects.Move);
            //{
            //    e
            //}

        }
        private void tl_ModelCanDrop(object sender, ModelDropEventArgs e)
        {

            e.Handled = true;
            e.Effect = DragDropEffects.None;
            if (e.SourceListView == GlobVar.tl_Template)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                if (e.SourceModels.Contains(e.TargetModel))
                    e.InfoMessage = "Cannot drop on self";
                else
                {
                    var sourceModels = e.SourceModels.Cast<ActionTools>();
                    ActionTools target = e.TargetModel as ActionTools;
                    if (sourceModels.Any(x => IsAncestor(x, target)))
                        e.InfoMessage = "Cannot drop on descendant (think of the temporal paradoxes!)";
                    else if (((ActionTools)e.SourceModels[0]).ActionType == EActionTypes.BranchItem)

                    {
                        e.InfoMessage = "Cannot drop this tool";
                    }
                    else
                        e.Effect = DragDropEffects.Move;
                }
            }


        }
        private void tl_CanDrop(object sender, OlvDropEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }

        private void tl_DragOver(object sender, DragEventArgs e)
        {

            Point targetPoint = tl.PointToClient(new Point(e.X, e.Y));
            var targetNode = tl.GetItemAt(targetPoint.X, targetPoint.Y) as OLVListItem;

            if (targetNode != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        private void popSmallViewMode_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (!item.Checked)
            {

                GlobVar.LockEvents = true;
                item.Checked = true;
                GlobVar.LockEvents = false;
                return;
            }
            try
            {
                GlobVar.LockEvents = true;
                switch (item.Name)
                {
                    case "popSmallViewMode":
                        {
                            _smallViewMode = ESmallViewMode.Small;
                            popNomalViewMode.Checked = false;
                            popLargeViewMode.Checked = false;
                            break;

                        }
                    case "popNomalViewMode":
                        {
                            _smallViewMode = ESmallViewMode.Normal;
                            popSmallViewMode.Checked = false;
                            popLargeViewMode.Checked = false;
                            break;

                        }
                    case "popLargeViewMode":
                        {
                            _smallViewMode = ESmallViewMode.Large;
                            popSmallViewMode.Checked = false;
                            popNomalViewMode.Checked = false;
                            break;
                        }
                }
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
            SetSmallView();
        }

        private void SetSmallView()
        {
            if (tl.InvokeRequired)
            {
                tl.Invoke((MethodInvoker)delegate
                {
                    tl.BeginUpdate();
                    SetNodeHeight(tl.Roots.Cast<ActionTools>().ToList());
                    UpdateFont();
                    tl.EndUpdate();
                });
            }
            else
            {
                tl.BeginUpdate();
                SetNodeHeight(tl.Roots.Cast<ActionTools>().ToList());
                UpdateFont();
                tl.EndUpdate();

            }

        }

        internal void UpdateFont()
        {
            if (tl.InvokeRequired)
            {
                tl.Invoke(new Action(() =>
                    {
                        switch (_smallViewMode)
                        {
                            case ESmallViewMode.Small:
                                tl.Font = CommonData.GetFontStyle(cFontStyle.ListOfToolOfModelSmall);
                                break;
                            case ESmallViewMode.Normal:
                                tl.Font = CommonData.GetFontStyle(cFontStyle.ListOfToolOfModelNomal);
                                break;
                            case ESmallViewMode.Large:
                                tl.Font = CommonData.GetFontStyle(cFontStyle.ListOfToolOfModelLarge);
                                break;
                            default:
                                tl.Font = CommonData.GetFontStyle(cFontStyle.ListOfToolOfModelNomal);
                                break;
                        }
                    }));
            }
            else
                switch (_smallViewMode)
                {
                    case ESmallViewMode.Small:
                        tl.Font = CommonData.GetFontStyle(cFontStyle.ListOfToolOfModelSmall);
                        break;
                    case ESmallViewMode.Normal:
                        tl.Font = CommonData.GetFontStyle(cFontStyle.ListOfToolOfModelNomal);
                        break;
                    case ESmallViewMode.Large:
                        tl.Font = CommonData.GetFontStyle(cFontStyle.ListOfToolOfModelLarge);
                        break;
                    default:
                        tl.Font = CommonData.GetFontStyle(cFontStyle.ListOfToolOfModelNomal);
                        break;
                }

        }

        private void SetNodeHeight(List<ActionTools> Nodes)
        {
            if (Nodes == null || Nodes.Count <= 0)
                return;
            switch (_smallViewMode)
            {
                case ESmallViewMode.Small:
                    tl.StateImageList = GlobVar.imlActionType16;
                    tl.SmallImageList = GlobVar.imlActionType16;
                    tl.RowHeight = 20;
                    break;
                case ESmallViewMode.Normal:
                    tl.StateImageList = GlobVar.imlActionType24;
                    tl.SmallImageList = GlobVar.imlActionType24;
                    tl.RowHeight = 24;
                    break;
                case ESmallViewMode.Large:
                    tl.StateImageList = GlobVar.imlActionType32;
                    tl.SmallImageList = GlobVar.imlActionType32;
                    tl.RowHeight = 32;
                    break;
                default:
                    tl.StateImageList = GlobVar.imlActionType24;
                    tl.SmallImageList = GlobVar.imlActionType24;
                    tl.RowHeight = 24;
                    break;
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DeleteAllTool();
        }

        private void btnDeleteBranch_Click(object sender, EventArgs e)
        {
            DeleteBranch();
        }
        private void DeleteBranch()
        {
            try
            {
                GlobVar.LockEvents = true;
                ActionTools SelectedNode = (ActionTools)tl.SelectedObject;
                ActionTools ParentNode = (ActionTools)SelectedNode.Parent;
                if (tl.SelectedObject == null)
                {
                    cMessageBox.Warning(cMessageContent.War_NotSelectedToolToDelete);
                    return;
                }
                if (cMessageBox.Question_YesNo(cMessageContent.Que_DeleteAllTool) == DialogResult.No)
                    return;
                GlobVar.GroupActions.RemoveAction(Guid.Parse(this.ID.GetValue((ActionTools)tl.SelectedObject).ToString()));
                ParentNode.child.Remove(SelectedNode);
                tl.BeginUpdate();
                tl.RefreshObject(tl.SelectedObject);
                tl.EndUpdate();
                NumberedOrderAction(tl.Objects.Cast<ActionTools>().ToList());
                GlobVar.LockEvents = false;

            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        private void btnDeteAllBranch_Click(object sender, EventArgs e)
        {
            DeleteAllBranch();

        }
        private void DeleteAllBranch()
        {
            try
            {
                GlobVar.LockEvents = true;
                if (tl.FocusedObject == null) return;
                cAction action = GlobVar.GroupActions.Actions[Guid.Parse(this.ID.GetValue((ActionTools)tl.FocusedObject).ToString())];
                cAction parentAction = null;
                if (action.ActionType == EActionTypes.BranchItem)
                    parentAction = GlobVar.GroupActions.Actions[action.IDBranch];
                else if (action.ActionType == EActionTypes.Switch)
                    parentAction = action;
                if (parentAction == null) return;
                if (cMessageBox.Question_YesNo(cMessageContent.Que_DeleteAllTool) == DialogResult.No)
                    return;
                var listBranchRemove = GlobVar.GroupActions.Actions.Values.Where(x => x.IDBranch == parentAction.ID).ToList();
                if (listBranchRemove.Any())
                {
                    listBranchRemove = listBranchRemove.OrderByDescending(x => x.STT).ToList();
                    foreach (var actionItem in listBranchRemove)
                    {
                        GlobVar.GroupActions.RemoveAction(actionItem.ID);
                        tl.RemoveObjects(listBranchRemove);

                    }
                }
                NumberedOrderAction(tl.Objects.Cast<ActionTools>().ToList());
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }

        private void tl_FormatRow(object sender, FormatRowEventArgs e)
        {
            //tl.SuspendLayout();
            //tl.BeginUpdate();
            //string ActionName = colName.GetValue(e.Item.RowObject).ToString();
            //if (ActionName == "MainAction")
            //{
            //    e.Item.c = false;
            //    e.ListView.UseSubItemCheckBoxes = false;
            //    e.ListView.TriStateCheckBoxes = false;
            //    //e.ListView.CheckBoxes = false;
            //}
            //tl.ResumeLayout();
            //tl.EndUpdate();

        }

        private void tl_FormatCell(object sender, FormatCellEventArgs e)
        {
            //var test = tl.Cursor;
            ENodeTypes eNodeTypes = GlobFuncs.GetNodeType((ActionTools)e.Model, this.NodeType);
            if (e.Column == colEnable)
            {
                if (((ActionTools)e.Model).ActionType == EActionTypes.MainAction)
                {
                    ImageDecoration image = new ImageDecoration(GlobVar.imlActionType24.Images["blank"], 255, ContentAlignment.MiddleCenter);
                    e.SubItem.Decoration = image;
                }
            }
            if (GlobVar.IsLinkMode ||
                    GlobVar.IsLinkStringBuilderItemMode ||
                    GlobVar.IsLinkCsvWriteValue ||
                    GlobVar.IsLinkImageFilterMode)
            {
                if ((masterAction != null && eNodeTypes == ENodeTypes.Action && (ActionTools)e.Model != masterAction.MyNode) ||
                    eNodeTypes == ENodeTypes.Property)
                {
                    e.SubItem.BackColor = Color.Gainsboro;
                    e.SubItem.ForeColor = Color.Black;
                }
                else if (masterAction != null && e.Model == masterAction.MyNode)
                {
                    e.SubItem.Font = new Font(e.SubItem.Font, FontStyle.Bold);
                    e.SubItem.BackColor = Color.LightYellow;
                }
            }
            if (eNodeTypes == ENodeTypes.Action || eNodeTypes == ENodeTypes.Group)
            {
                cAction actionFromNode = GetActionFromNode((ActionTools)e.Model);
                if (actionFromNode != null && actionFromNode.HighLights != null && actionFromNode.HighLights.rtcValue)
                {
                    e.SubItem.BackColor = Color.Yellow;
                }
                else if (actionFromNode != null && actionFromNode.IsCanEdit != null && !actionFromNode.IsCanEdit.rtcValue)
                {
                    e.SubItem.BackColor = Color.Yellow;
                }
            }
            if (e.Column == colDescription && ((ActionTools)e.Item.RowObject).AbortCause != string.Empty && ((ActionTools)e.Item.RowObject).AbortCause != null)
            {
                // Tô màu cho ô
                e.SubItem.BackColor = Color.Red; // Màu đỏ (hoặc bất kỳ màu nào bạn muốn)
                e.SubItem.ForeColor = Color.White; // Màu chữ trắng (hoặc bất kỳ màu nào phù hợp)
            }
            if (e.Column == colDescription)
            {
                ActionTools tool = (ActionTools)e.Item.RowObject;
                switch (tool.NodeType)
                {
                    case ENodeTypes.Property:
                        if (tool.State == EPropertyState.Input)
                        {
                            e.Item.ImageSelector = tl.StateImageList.Images.IndexOfKey("Input");
                        }
                        else if (tool.State == EPropertyState.Output)
                        {
                            e.Item.ImageSelector = tl.StateImageList.Images.IndexOfKey("Output");
                        }
                        break;
                    default:
                        e.Item.ImageSelector = tl.StateImageList.Images.IndexOfKey(Enum.GetName(typeof(EActionTypes), tool.ActionType));
                        break;
                }

                cAction actionFromNode = GetActionFromNode(tool);
                if (actionFromNode != null && actionFromNode.ActionType == EActionTypes.BranchItem)
                {
                    cAction branchAction = GlobVar.GroupActions.Actions[actionFromNode.IDBranch];
                    if (branchAction.IsCanRun)
                        if (actionFromNode.IsCanRun)
                        {
                            e.SubItem.BackColor = Color.LimeGreen;
                        }
                }

            }
            //int Target = tl.IndexOf(tl.SelectedObject);
            //Rectangle test = tl.GetItemRect(0);
            //Rectangle test1 = tl.GetItemRect(Target);
            //Pen pen = new Pen(Color.Red, 5);
            //Graphics.DrawLine(pen, new Point(test1.X + colDescription.Width, test1.Y), new Point(colDescription.Width, test.Y));


        }
        private void ucTemplateTools_OnAddAction(object sender, RTCE_AddActionEventArgs e)
        {
            if (GlobVar.GroupActions != null)
                AddNewNode(GlobVar.GroupActions.CreateAction(e.ActionTypes, EObjectTypes.Action));
        }
        private void tl_ModelDropped(object sender, ModelDropEventArgs e)
        {
            try
            {

                if (popLockMoveTools.Checked || GlobVar.IsLinkMode || GlobVar.IsLinkImageFilterMode ||
                GlobVar.IsLinkCsvWriteValue || GlobVar.IsLinkStringBuilderItemMode || !_isCanMovingTool)
                {
                    return;
                }
                if (e.SourceListView == GlobVar.tl_Template)
                {
                    string a = ((RTC_Vision_Lite.UserControls.ucTemplateTools.MyActionNode)(e.SourceModels[0])).ActionName;
                    string value = a.Replace("/", "");
                    EActionTypes ActionTypes = (EActionTypes)Enum.Parse(typeof(EActionTypes), value);
                    ActionTools parentNode = (ActionTools)tl.GetParent(e.TargetModel);

                    switch (e.DropTargetLocation)
                    {
                        case DropTargetLocation.AboveItem:
                            AddNewNode(GlobVar.GroupActions.CreateAction(ActionTypes, EObjectTypes.Action), parentNode, null);

                            break;
                        case DropTargetLocation.BelowItem:
                            AddNewNode(GlobVar.GroupActions.CreateAction(ActionTypes, EObjectTypes.Action), parentNode, null);
                            break;
                        case DropTargetLocation.Background:
                            AddNewNode(GlobVar.GroupActions.CreateAction(ActionTypes, EObjectTypes.Action), null, null);
                            break;
                        case DropTargetLocation.Item:
                            AddNewNode(GlobVar.GroupActions.CreateAction(ActionTypes, EObjectTypes.Action), parentNode, (ActionTools)e.TargetModel);

                            break;
                        default:
                            return;
                    }
                }
                else
                {
                    switch (e.DropTargetLocation)
                    {
                        case DropTargetLocation.AboveItem:
                            MoveObjectsToSibling(
                                e.ListView as TreeListView,
                                e.SourceListView as TreeListView,
                                (ActionTools)e.TargetModel,
                                e.SourceModels,
                                0);
                            break;
                        case DropTargetLocation.BelowItem:
                            MoveObjectsToSibling(
                                e.ListView as TreeListView,
                                e.SourceListView as TreeListView,
                                (ActionTools)e.TargetModel,
                                e.SourceModels,
                                1);
                            break;
                        case DropTargetLocation.Background:
                            MoveObjectsToRoots(
                                e.ListView as TreeListView,
                                e.SourceListView as TreeListView,
                                e.SourceModels);
                            break;
                        case DropTargetLocation.Item:
                            MoveObjectsToChildren(
                                e.ListView as TreeListView,
                                e.SourceListView as TreeListView,
                                (ActionTools)e.TargetModel,
                                e.SourceModels);
                            break;
                        default:
                            return;
                    }

                    e.RefreshObjects();
                }
            }
            finally
            {

                NumberedOrderAction(tl.Objects.Cast<ActionTools>().ToList());
                tl.ExpandAll();
            }

        }
        private void MoveObjectsToChildren(TreeListView targetTree, TreeListView sourceTree, ActionTools target, IList toMove)
        {
            foreach (ActionTools x in toMove)
            {
                ActionTools Parent = x.Parent;
                if (Parent == null)
                    sourceTree.RemoveObject(x);
                else
                {
                    Parent.child.Remove(x);
                    target.child.Add(x);
                    x.Parent = target;

                }
            }
            tl.RefreshObject(target);
        }
        private void MoveObjectsToRoots(TreeListView targetTree, TreeListView sourceTree, IList toMove)
        {
            foreach (ActionTools x in toMove)
            {
                ActionTools Parent = x.Parent;
                if (Parent != null)
                {
                    Parent.child.Remove(x);
                    x.Parent = sourceTree.Roots.Cast<ActionTools>().FirstOrDefault();
                    sourceTree.AddObject(x);
                }
            }
        }
        private void MoveObjectsToSibling(TreeListView targetTree, TreeListView sourceTree, ActionTools target, IList toMove, int siblingOffset)
        {
            // There are lots of things to get right here:
            // - sourceTree and targetTree may be the same
            // - target may be a root (which means that all moved objects will also become roots)
            // - one or more moved objects may be roots (which means the roots of the sourceTree will change)

            ArrayList sourceRoots = sourceTree.Roots as ArrayList;
            ArrayList targetRoots = targetTree == sourceTree ? sourceRoots : targetTree.Roots as ArrayList;
            ActionTools mainNode = tl.Roots.Cast<ActionTools>().FirstOrDefault();
            if (target == mainNode)
            {
                foreach (ActionTools x in toMove)
                {
                    ActionTools parent = x.Parent;
                    if (parent == null)
                        sourceRoots.Remove(x);
                    else
                    {
                        parent.child.Remove(x);
                    }
                    x.Parent = target;
                }

                target.child.InsertRange(target.child.IndexOf(target) + siblingOffset, toMove.Cast<ActionTools>());

                if (targetTree == sourceTree)
                {
                    sourceTree.Roots = sourceRoots;
                }
                else
                {
                    sourceTree.Roots = sourceRoots;
                    targetTree.Roots = targetRoots;
                }
            }
            else
            {
                foreach (ActionTools x in toMove)
                {
                    ActionTools parent = x.Parent;
                    if (parent == null)
                        sourceRoots.Remove(x);
                    else
                    {
                        parent.child.Remove(x);
                    }
                    x.Parent = target.Parent;
                }
                if (target.Parent == null)
                {
                    targetRoots.InsertRange(targetRoots.IndexOf(target) + siblingOffset, toMove);
                }
                else
                {
                    target.Parent.child.InsertRange(target.Parent.child.IndexOf(target) + siblingOffset, toMove.Cast<ActionTools>());
                }
                if (targetTree == sourceTree)
                {
                    sourceTree.Roots = sourceRoots;
                }
                else
                {
                    sourceTree.Roots = sourceRoots;
                    targetTree.Roots = targetRoots;
                }
            }
            // Now add to the moved objects to children of their parent (or to the roots collection
            // if the target is a root)

        }
        private void tl_Dropped(object sender, OlvDropEventArgs e)
        {
            NumberedOrderAction(tl.Objects.Cast<ActionTools>().ToList());
        }
        private void tl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                (GlobVar.IsLinkMode || GlobVar.IsLinkStringBuilderItemMode || GlobVar.IsLinkImageFilterMode || GlobVar.IsLinkCsvWriteValue)
                && tl.SelectedObject != null)
            {
                ENodeTypes eNodeType = (ENodeTypes)this.NodeType.GetValue(tl.SelectedObject);
                if (eNodeType == ENodeTypes.Action || eNodeType == ENodeTypes.Group)
                {
                    cAction action = null;
                    action = eNodeType == ENodeTypes.Group ? GlobVar.GroupActions.MainAction : GetActionFormNode((ActionTools)tl.SelectedObject);
                    if (action == null)
                        return;
                    var isView = currentActionSelect != action;
                    if (isView)
                        ViewData_ActionDetail_Properties(action);
                }
            }
        }
        private void ViewData_ActionDetail_Properties(cAction action)
        {
            try
            {
                GlobVar.LockEvents = true;
                tl.BeginUpdate();
                if (action.MyNode.child != null && action.MyNode.child.Count > 0)
                {
                    ENodeTypes eNodeTypes = (ENodeTypes)this.NodeType.GetValue(action.MyNode.child[0]);
                    if (eNodeTypes != ENodeTypes.Group && eNodeTypes != ENodeTypes.Action)
                        return;
                }
                var orderProperty = action.GetType().GetProperties().Where(x => ((RTCVariableType)x.GetValue(action, null)) != null);
                var lstOrderProperty = orderProperty.OrderBy(x => ((RTCVariableType)x.GetValue(action, null)).rtcState).ToList();
                int iNodePositionIndex = 0;
                for (int i1 = 0; i1 < lstOrderProperty.Count; i1++)
                {
                    PropertyInfo nProperty = lstOrderProperty[i1];
                    RTCVariableType rtcvar = (RTCVariableType)action.GetType().GetProperty(nProperty.Name).GetValue(action, null);

                    if (rtcvar == null || !rtcvar.rtcActive)
                        continue;
                    string dataType = nProperty.PropertyType.Name;
                    bool isVisible = false;
                    if (MasterPropertyTypeName == nameof(SListDouble) || MasterPropertyTypeName == nameof(SListString) || MasterPropertyTypeName == nameof(SListObject))
                    {
                        isVisible = (dataType == nameof(SString)) ||
                                    (dataType == nameof(SDouble)) ||
                                    (dataType == nameof(SInt)) ||
                                    (dataType == nameof(SBool)) ||
                                    (dataType == nameof(SListObject)) ||
                                    (dataType == nameof(SListDouble)) ||
                                    (dataType == nameof(SListString));
                    }
                    else if (MasterPropertyTypeName == nameof(SString))
                    {
                        isVisible = (dataType == nameof(SString)) ||
                                    (dataType == nameof(SListObject)) ||
                                    (dataType == nameof(SListDouble)) ||
                                    (dataType == nameof(SListString));
                    }
                    else if (MasterPropertyTypeName == nameof(SDouble))
                    {
                        isVisible = (dataType == nameof(SString)) ||
                                    (dataType == nameof(SDouble)) ||
                                    (dataType == nameof(SInt)) ||
                                    (dataType == nameof(SListObject)) ||
                                    (dataType == nameof(SListDouble)) ||
                                    (dataType == nameof(SListString));
                    }
                    else if (MasterPropertyTypeName == nameof(SInt))
                    {
                        isVisible = (dataType == nameof(SString)) ||
                                    (dataType == nameof(SInt)) ||
                                    (dataType == nameof(SListObject)) ||
                                    (dataType == nameof(SListDouble)) ||
                                    (dataType == nameof(SListString));
                    }
                    else if (MasterPropertyTypeName == nameof(SBool))
                    {
                        isVisible = (dataType == nameof(SString)) ||
                                    (dataType == nameof(SBool)) ||
                                    (dataType == nameof(SListObject)) ||
                                    (dataType == nameof(SListDouble)) ||
                                    (dataType == nameof(SListString));
                    }
                    else if (MasterPropertyTypeName == nameof(SImage))
                    {
                        isVisible = (dataType == nameof(SImage)
                                    || dataType == nameof(SGrayImage)
                                    || dataType == nameof(SBgrImage));
                    }
                    else if (MasterPropertyTypeName == nameof(SGrayImage))
                    {
                        isVisible = (dataType == nameof(SGrayImage));

                    }
                    else if (MasterPropertyTypeName == nameof(SBgrImage))
                    {
                        isVisible = (dataType == nameof(SBgrImage));
                    }

                    else if (MasterPropertyTypeName == nameof(SListImage))
                    {
                        isVisible = (dataType == nameof(SImage));

                    }
                    else if (MasterPropertyTypeName == nameof(SListVector))
                    {
                        isVisible = (dataType == nameof(SListVector));
                    }

                    if (!isVisible)
                        continue;
                    ActionTools propNode = new ActionTools()
                    {
                        IDGroup = GlobVar.GroupActions.ID,
                        ID = action.ID,
                        rtcIDRef = rtcvar.rtcIDRef,
                        Name = nProperty.Name,
                        DataType = nProperty.PropertyType.Name,
                        NodeType = ENodeTypes.Property,
                        Enable = true,
                        ActionType = action.ActionType,
                        rtcSystem = rtcvar.rtcSystem,
                        State = rtcvar.rtcState,
                        AbortCause = string.Empty,
                        Description = "[" + nProperty.Name + "] " + (rtcvar.rtcIDRef != Guid.Empty ? rtcvar.rtcValueViewFull + " " + rtcvar.rtcRef : rtcvar.rtcValueViewFull),

                    };
                    action.MyNode.child.Insert(0, propNode);

                }
                if (action.DataItems != null)
                    foreach (var dataItem in action.DataItems)
                    {
                        ActionTools propNode = new ActionTools()
                        {
                            IDGroup = GlobVar.GroupActions.ID,
                            ID = action.ID,
                            rtcIDRef = dataItem.RefID,
                            Name = dataItem.Name,
                            DataType = dataItem.GetType().Name,
                            NodeType = ENodeTypes.Operand,
                            ActionType = action.ActionType,
                            Enable = true,
                            AbortCause = string.Empty,

                            rtcSystem = false,
                            Description = "[" + dataItem.Name + "] " + (dataItem.RefID != Guid.Empty ? dataItem.ValueView + " " + dataItem.Ref : dataItem.ValueView),

                        };
                        action.MyNode.child.Insert(0, propNode);


                    }
                if (action.MyExpression != null && action.MyExpression.Operands != null)
                    foreach (var operandItem in action.MyExpression.Operands)
                    {
                        ActionTools propNode = new ActionTools()
                        {
                            IDGroup = GlobVar.GroupActions.ID,
                            ID = action.ID,
                            rtcIDRef = operandItem.RefID,
                            Name = operandItem.Name,
                            DataType = operandItem.GetType().Name,
                            NodeType = ENodeTypes.Operand,
                            ActionType = action.ActionType,
                            Enable = true,
                            rtcSystem = false,
                            AbortCause = string.Empty,
                            Description = "[" + operandItem.Name + "] " + (operandItem.RefID != Guid.Empty ? operandItem.ValueView + " " + operandItem.Ref : operandItem.ValueView),

                        };
                        action.MyNode.child.Insert(0, propNode);
                    }
            }
            finally
            {
                tl.RefreshObject(action.MyNode);
                GlobVar.LockEvents = false;
                tl.EndUpdate();
                tl.Refresh();
                tl.CanExpandGetter = x => (x as ActionTools).child.Count > 0;
                tl.ChildrenGetter = x => (x as ActionTools).child;
                tl.ExpandAll();

            }
        }
        public void ViewData_ActionDetail_ClearProperties(List<ActionTools> Nodes)
        {
            try
            {
                tl.BeginUpdate();
                ViewData_ActionDetail_ClearProperties_Process(Nodes);
            }
            finally
            {
                tl.RefreshObject(Nodes);
                tl.EndUpdate();
            }
        }

        private void ViewData_ActionDetail_ClearProperties_Process(List<ActionTools> nodes)
        {
            List<ActionTools> Roots = tl.Roots.Cast<ActionTools>().ToList();
            if (nodes == null || nodes.Count <= 0)
                return;
            List<ActionTools> deleteNodes = new List<ActionTools>();
            for (int i = 0; i < nodes.Count; i++)
            {
                ActionTools node = nodes[i];
                ENodeTypes eNodeTypes = GlobFuncs.GetNodeType(node, this.NodeType);
                if (eNodeTypes != ENodeTypes.Action && eNodeTypes != ENodeTypes.Group)
                {
                    deleteNodes.Add(node);
                }
                else
                    ViewData_ActionDetail_ClearProperties_Process(node.child);
            }
            for (int i = 0; i < deleteNodes.Count; i++)
            {
                RemoveNode(Roots, deleteNodes[i]);
            }
            //tl.VirtualMode = true;
            tl.Roots = Roots;
            tl.Refresh();
        }
        private void RemoveNode(List<ActionTools> Node, ActionTools Nodechild)
        {
            if (Node.Count > 0)
            {
                foreach (ActionTools item in Node)
                {
                    if (item.child.Contains(Nodechild))
                    {
                        item.child.Remove(Nodechild);
                        return;
                    }
                    RemoveNode(item.child, Nodechild);
                }
            }

        }


        private void tl_FormatCell_1(object sender, FormatCellEventArgs e)
        {
            if (e.Column == colEnable)
            {
                cAction action = GetActionFormNode((ActionTools)e.Item.RowObject);
                //if(action.ActionType == EActionTypes.MainAction)

            }
        }


        private void tl_SubItemChecking(object sender, SubItemCheckingEventArgs e)
        {
            if (e.Column == colEnable)
            {
                cAction action = GetActionFormNode((ActionTools)e.RowObject);
                bool Checked = e.NewValue == CheckState.Checked ? true : false;
                action.Enable.rtcValue = Checked;
            }
        }

        private void popSmallViewMode_Click(object sender, EventArgs e)
        {

        }

        private void popAddBranch_Click(object sender, EventArgs e)
        {
            AddNewBranch();
        }
        public void AddNewBranch(bool isDefaultBranch = false)
        {
            if (tl.FocusedObject == null) return;
            cAction action = GlobVar.GroupActions.Actions[Guid.Parse(this.ID.GetValue(tl.FocusedObject).ToString())];
            cAction parentAction = null;
            if (action.ActionType == EActionTypes.BranchItem)
                parentAction = GlobVar.GroupActions.Actions[action.IDBranch];
            else if (action.ActionType == EActionTypes.Switch)
                parentAction = action;
            if (parentAction == null || parentAction.ActionType != EActionTypes.Switch) return;
            int stt = -1;
            if (isDefaultBranch)
            {
                foreach (cAction actionItem in GlobVar.GroupActions.Actions.Values)
                    if (actionItem.ActionType == EActionTypes.BranchItem &&
                        actionItem.IDBranch == parentAction.ID &&
                        actionItem.STT >= stt)
                    {
                        stt = actionItem.STT;
                        action = actionItem;
                    }
            }
            else
            {
                if (action.ActionType == EActionTypes.BranchItem && action.BranchItemType.rtcValue != cStrings.DefaultCase)
                    stt = action.STT;
                if (stt == -1)
                {
                    cAction defaultAction = GlobVar.GroupActions.Actions.Values.FirstOrDefault(x =>
                    x.IDBranch == parentAction.ID &&
                    x.BranchItemType.rtcValue == cStrings.DefaultCase);
                    if (defaultAction != null)
                    {
                        action = defaultAction;
                        stt = defaultAction.STT - 1;
                    }
                    else
                        foreach (cAction actionItem in GlobVar.GroupActions.Actions.Values)
                            if (actionItem.ActionType == EActionTypes.BranchItem &&
                                action.IDBranch == parentAction.ID &&
                                actionItem.STT >= stt)
                            {
                                stt = actionItem.STT;
                                action = actionItem;
                            }
                }
            }
            if (stt == -1) stt = GlobVar.GroupActions.STT;
            GlobVar.GroupActions.STT += 1;
            foreach (cAction actionItem in GlobVar.GroupActions.Actions.Values)
                if (actionItem.STT > stt) actionItem.STT += 1;
            cAction newAction = new cAction(EActionTypes.BranchItem, EObjectTypes.Action, GlobVar.GroupActions.frmHsmartWindow, GlobVar.GroupActions)
            {
                STT = stt + 1
            };
            parentAction.STTBranch += 1;
            newAction.Name.rtcValue = cStrings.CASE + " " + parentAction.STTBranch.ToString();
            newAction.IDBranch = parentAction.ID;
            newAction.BranchItemType.rtcValue = isDefaultBranch ? cStrings.DefaultCase : cStrings.Case;
            newAction.DataItems = new List<SStringBuilderItem>();
            SStringBuilderItem newItem = new SStringBuilderItem
            {
                Name = cStrings.value
            };
            newAction.DataItems.Add(newItem);
            GlobVar.GroupActions.AddAction(newAction);
            if (action.ActionType != EActionTypes.BranchItem)
                ViewData_ActionDetail(newAction, parentAction.MyNode);
            else
                ViewData_ActionDetail(newAction, parentAction.MyNode, action.MyNode, action.BranchItemType.rtcValue != cStrings.DefaultCase);
        }

        private void btnAddBranch_Click(object sender, EventArgs e)
        {
            AddNewBranch();
        }

        private void btnAddDefaultBranch_Click(object sender, EventArgs e)
        {
            AddNewBranch(true);
        }

        private void PopInsertTools_Click(object sender, EventArgs e)
        {
            InsertTools();
        }
        public void InsertTools()
        {
            FrmActionsChoose frmActionsChoose = new FrmActionsChoose();

            frmActionsChoose.OldMode = _frmActionsChooseOldMode;
            frmActionsChoose.OldFileName = _frmActionsChooseOldFileName;
            frmActionsChoose.OldSelect = _frmActionsChooseOldSelect;
            frmActionsChoose.ListToolIdChoose = _frmActionsChooseOldListToolIdChoose;

            if (frmActionsChoose.ShowDialog() == DialogResult.OK)
            {
                {
                    if (frmActionsChoose.ListToolIdChoose?.Count <= 0)
                        return;
                    GroupActionsData groupActionsData = new GroupActionsData();
                    try
                    {
                        GlobVar.LockEvents = true;
                        GlobFuncs.ShowWaitForm("Inserting...");
                        _frmActionsChooseOldMode = frmActionsChoose.OldMode;
                        _frmActionsChooseOldFileName = frmActionsChoose.OldFileName;
                        _frmActionsChooseOldSelect = frmActionsChoose.OldSelect;
                        _frmActionsChooseOldListToolIdChoose = frmActionsChoose.ListToolIdChoose;

                        tl.BeginUpdate();

                        if (!groupActionsData.Connect(frmActionsChoose.GroupActions.FileName))
                        {
                            cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.Err_NotConnectObject,
                                new[] { frmActionsChoose.GroupActions.FileName },
                                new[] { frmActionsChoose.GroupActions.FileName }));
                            return;
                        }
                        if (frmActionsChoose.ListToolIdChoose == null)
                            return;
                        Dictionary<Guid, Guid> ListToolIdAdded = new Dictionary<Guid, Guid>(); //Key: OldID; Value: NewID
                        int count = 1;
                        foreach (Guid actionId in frmActionsChoose.ListToolIdChoose)
                            InsertTool(groupActionsData, frmActionsChoose.GroupActions.Actions[actionId], ListToolIdAdded, frmActionsChoose.ListToolIdChoose, ref count);

                        foreach (Guid actionId in ListToolIdAdded.Values)
                        {
                            cAction cloneAction = GlobVar.GroupActions.Actions[actionId];
                            var properties = cloneAction.GetType().GetProperties().Where(x =>
                                ((RTCVariableType)x.GetValue(cloneAction, null)) != null && ((RTCVariableType)x.GetValue(cloneAction, null)).rtcIDRef != Guid.Empty).ToList();
                            if (properties.Any())
                                for (int i1 = 0; i1 < properties.Count; i1++)
                                {
                                    PropertyInfo nProperty = properties[i1];
                                    RTCVariableType rtcvar =
                                        (RTCVariableType)cloneAction.GetType().GetProperty(nProperty.Name).GetValue(cloneAction, null);

                                    if (rtcvar != null)
                                    {
                                        if (ListToolIdAdded.ContainsKey(rtcvar.rtcIDRef))
                                            rtcvar.rtcIDRef = ListToolIdAdded[rtcvar.rtcIDRef];
                                        else if (nProperty.Name == nameof(cloneAction.InputImage))
                                        {
                                            rtcvar.rtcIDRef = GlobVar.GroupActions.IDMainAction;
                                            rtcvar.rtcPropNameRef = nameof(cloneAction.InputImage);
                                            rtcvar.rtcRefIndex = string.Empty;
                                            //rtcvar.rtcRef = GlobFuncs.BuildRefString_Property_PropName(GlobVar.GroupActions,
                                            //    GlobVar.GroupActions.MainAction, rtcvar.rtcPropNameRef);
                                        }
                                        else if (nProperty.Name == nameof(cloneAction.InputGrayImage))
                                        {
                                            rtcvar.rtcIDRef = GlobVar.GroupActions.IDMainAction;
                                            rtcvar.rtcPropNameRef = nameof(cloneAction.InputGrayImage);
                                            rtcvar.rtcRefIndex = string.Empty;
                                            //rtcvar.rtcRef = GlobFuncs.BuildRefString_Property_PropName(GlobVar.GroupActions,
                                            //    GlobVar.GroupActions.MainAction, rtcvar.rtcPropNameRef);
                                        }
                                        else if (nProperty.Name == nameof(cloneAction.InputBgrImage))
                                        {
                                            rtcvar.rtcIDRef = GlobVar.GroupActions.IDMainAction;
                                            rtcvar.rtcPropNameRef = nameof(cloneAction.InputBgrImage);
                                            rtcvar.rtcRefIndex = string.Empty;
                                            //rtcvar.rtcRef = GlobFuncs.BuildRefString_Property_PropName(GlobVar.GroupActions,
                                            //    GlobVar.GroupActions.MainAction, rtcvar.rtcPropNameRef);
                                        }
                                        else
                                        {
                                            rtcvar.rtcIDRef = Guid.Empty;
                                            rtcvar.rtcPropNameRef = string.Empty;
                                            rtcvar.rtcRefIndex = string.Empty;
                                            rtcvar.rtcRef = string.Empty;
                                        }
                                    }
                                }

                            properties = cloneAction.GetType().GetProperties().Where(x =>
                                ((RTCVariableType)x.GetValue(cloneAction, null)) != null &&
                                ((RTCVariableType)x.GetValue(cloneAction, null)).ParentIDResets != null &&
                                ((RTCVariableType)x.GetValue(cloneAction, null)).ParentIDResets.Count > 0).ToList();
                            if (properties.Any())
                                for (int i1 = 0; i1 < properties.Count; i1++)
                                {
                                    PropertyInfo nProperty = properties[i1];
                                    RTCVariableType rtcvar =
                                        (RTCVariableType)cloneAction.GetType().GetProperty(nProperty.Name).GetValue(cloneAction, null);
                                    List<Guid> removes = new List<Guid>();
                                    for (int i = 0; i < rtcvar.ParentIDResets.Count; i++)
                                    {
                                        if (ListToolIdAdded.ContainsKey(rtcvar.ParentIDResets[i]))
                                            rtcvar.ParentIDResets[i] = ListToolIdAdded[rtcvar.ParentIDResets[i]];
                                        else
                                            removes.Add(rtcvar.ParentIDResets[i]);
                                    }

                                    foreach (Guid idResetRemove in removes)
                                        rtcvar.ParentIDResets.Remove(idResetRemove);
                                }

                            if (cloneAction.DataItems != null)
                                foreach (SStringBuilderItem dataItem in cloneAction.DataItems)
                                    dataItem.RefID = ListToolIdAdded.ContainsKey(dataItem.RefID) ? ListToolIdAdded[dataItem.RefID] : Guid.Empty;
                            if (cloneAction.MyExpression != null && cloneAction.MyExpression.Operands != null)
                                foreach (SStringBuilderItem dataItem in cloneAction.MyExpression.Operands)
                                    dataItem.RefID = ListToolIdAdded.ContainsKey(dataItem.RefID) ? ListToolIdAdded[dataItem.RefID] : Guid.Empty;
                            if (cloneAction.StringBuilders != null)
                                foreach (SStringBuilderItem dataItem in cloneAction.StringBuilders)
                                    dataItem.RefID = ListToolIdAdded.ContainsKey(dataItem.RefID) ? ListToolIdAdded[dataItem.RefID] : Guid.Empty;
                            if (cloneAction.ListResetTools != null)
                            {
                                List<cLinkPassFail> removes = new List<cLinkPassFail>();
                                foreach (cLinkPassFail linkPassFail in cloneAction.ListResetTools)
                                {
                                    if (ListToolIdAdded.ContainsKey(linkPassFail.rtcIDref))
                                        linkPassFail.rtcIDref = ListToolIdAdded[linkPassFail.rtcIDref];
                                    else
                                        removes.Add(linkPassFail);
                                }
                                foreach (cLinkPassFail remove in removes)
                                    cloneAction.ListResetTools.Remove(remove);
                            }

                            if (cloneAction.LinkPassFail != null)
                            {
                                List<cLinkPassFail> removes = new List<cLinkPassFail>();
                                foreach (cLinkPassFail linkPassFail in cloneAction.LinkPassFail)
                                {
                                    linkPassFail.rtcIDGetResult = ListToolIdAdded.ContainsKey(linkPassFail.rtcIDGetResult) ? ListToolIdAdded[linkPassFail.rtcIDGetResult] : Guid.Empty;

                                    if (ListToolIdAdded.ContainsKey(linkPassFail.rtcIDref))
                                        linkPassFail.rtcIDref = ListToolIdAdded[linkPassFail.rtcIDref];
                                    else
                                        removes.Add(linkPassFail);
                                }
                                foreach (cLinkPassFail remove in removes)
                                    cloneAction.LinkPassFail.Remove(remove);
                            }
                            if (cloneAction.LinkProperty != null)
                            {
                                List<cLinkProperty> removes = new List<cLinkProperty>();
                                foreach (cLinkProperty linkProperty in cloneAction.LinkProperty)
                                {
                                    linkProperty.SourceID = ListToolIdAdded.ContainsKey(linkProperty.SourceID) ? ListToolIdAdded[linkProperty.SourceID] : Guid.Empty;

                                    if (ListToolIdAdded.ContainsKey(linkProperty.SourceID))
                                        linkProperty.SourceID = ListToolIdAdded[linkProperty.SourceID];
                                    else
                                        removes.Add(linkProperty);
                                }
                                foreach (cLinkProperty remove in removes)
                                    cloneAction.LinkProperty.Remove(remove);
                            }
                        }

                        NumberedOrderAction(tl.Roots.Cast<ActionTools>().ToList());

                        cAction focusedAction = GetActionFromNode((ActionTools)tl.SelectedObject);
                        if (focusedAction != null)
                        {
                            if (focusedAction.ActionType == EActionTypes.PassFail)
                                ((ucPassFailActionDetails)focusedAction.ViewInfo).LoadLinkData();
                            else if (focusedAction.ActionType == EActionTypes.ResetTool)
                                ((ucResetToolActionDetail)focusedAction.ViewInfo).LoadLinkData();
                        }
                    }
                    finally
                    {
                        GlobVar.LockEvents = false;
                        groupActionsData.Disconnect();
                        groupActionsData = null;
                        tl.EndUpdate();
                        GlobFuncs.CloseWaitForm();
                    }
                }
            }
        }
        private void InsertTool(GroupActionsData groupActionsData, cAction action, Dictionary<Guid, Guid> listToolIdAdded,
            List<Guid> listToolIdChoose, ref int count)
        {
            if (listToolIdAdded.ContainsKey(action.ID))
                return;
            cAction cloneAction = groupActionsData.CloneAction(action);
            if (cloneAction == null)
                return;
            cloneAction.Name.rtcValue = action.Name.rtcValue;
            cloneAction.frmHsmartWindow = GlobVar.fHsmartWindow;
            cloneAction.MyGroup = GlobVar.GroupActions;
            cloneAction.WindowHandle.rtcValue = GlobVar.fHsmartWindow.SmartWindow;

            if (action.ActionType != EActionTypes.BranchItem &&
                GlobVar.GroupActions.Actions.Values.FirstOrDefault(x => x.Name.rtcValue.ToLower() == cloneAction.Name.rtcValue.ToLower()) != null)
                GlobVar.GroupActions.GenerateActionName(cloneAction);

            ActionTools originParentNode = (ActionTools)tl.FocusedObject;//GlobVar.GroupActions.MainAction.MyNode;

            if (GetActionFromNode((ActionTools)tl.FocusedObject).ActionType == EActionTypes.BranchItem)
                originParentNode = (ActionTools)tl.FocusedObject;
            else if (originParentNode.Parent != null &&
                     GetActionFromNode(originParentNode.Parent).ActionType == EActionTypes.BranchItem)// Kiểm tra xem parent node này có thuộc vào 1 nhánh nào đó hay không
                originParentNode = originParentNode.Parent;
            else
                originParentNode = GlobVar.GroupActions.MainAction.MyNode;
            // Khởi tạo ID cho actiion clone này
            cloneAction.ID = Guid.NewGuid();
            // Thêm nó vào danh sách listToolIdAdded
            listToolIdAdded.Add(action.ID, cloneAction.ID);
            // Check xem CloneAction này có phải là 1 tool phân nhánh hay không
            if (cloneAction.IDBranch != Guid.Empty)
                if (listToolIdAdded.ContainsKey(cloneAction.IDBranch))
                {
                    cloneAction.IDBranch = listToolIdAdded[cloneAction.IDBranch];
                    originParentNode = GlobVar.GroupActions.Actions[cloneAction.IDBranch].MyNode;
                }
                else
                    return;
            // Check xem CloneAction này có phải là 1 tool thuộc phân nhánh hay không
            if (cloneAction.IDBranchItem != Guid.Empty)
                cloneAction.IDBranchItem = listToolIdAdded.ContainsKey(cloneAction.IDBranchItem)
                    ? listToolIdAdded[cloneAction.IDBranchItem]
                    : Guid.Empty;
            if (cloneAction.IDBranchItem != Guid.Empty)
                originParentNode = GlobVar.GroupActions.Actions[cloneAction.IDBranchItem].MyNode;
            // Thêm tool này vào danh sách tool hiện tại
            GlobVar.GroupActions.AddAction(cloneAction);
            // Thêm vào TreeList

            ActionTools newNode = new ActionTools();
            newNode.IDGroup = GlobVar.GroupActions.ID;
            newNode.ID = cloneAction.ID;
            newNode.rtcIDRef = Guid.Empty;
            newNode.Name = cloneAction.Name.rtcValue;
            newNode.DataType = cloneAction.GetType().ToString();
            newNode.NodeType = ENodeTypes.Action;
            newNode.Enable = true;
            newNode.rtcSystem = false;
            newNode.Description = cloneAction.Name.rtcValue;
            newNode.Active = cloneAction.Enable.rtcValue;
            newNode.ActionType = cloneAction.ActionType;
            newNode.Parent = originParentNode;
            originParentNode.child.Add(newNode);
            //TreeListNode actionNode = tl.AppendNode(new object[] { GlobVar.GroupActions.ID, cloneAction.ID, Guid.Empty,
            //        cloneAction.Name.rtcValue,
            //        cloneAction.GetType().ToString(),ENodeTypes.Action,true,false,
            //        cloneAction.Name.rtcValue,"",cloneAction.Enable.rtcValue},
            //    originParentNode);
            //try
            //{
            //    if (tl.FocusedNode.Level == 1 && originParentNode.Level == 0)
            //    {
            //        tl.SetNodeIndex(actionNode, tl.GetNodeIndex(tl.FocusedNode) + count);
            //        count += 1;
            //    }
            //    //else tl.SetNodeIndex(actionNode, tl.GetNodeIndex(originParentNode));
            //}
            //catch
            //{
            //}
            //actionNode.ImageIndex = GlobVar.imlActionType32.Images.IndexOfKey(Enum.GetName(typeof(EActionTypes), cloneAction.ActionType));
            //actionNode.SelectImageIndex = actionNode.ImageIndex;
            //((MyTreeListNode)actionNode).Height = 36;
            cloneAction.MyNode = newNode;
            //if (originParentNode != null)
            //    originParentNode.ExpandAll();

            var branchItems = action.MyGroup.Actions.Values.OrderBy(x => x.STT).Where(x => x.IDBranch == action.ID).ToList();
            if (branchItems != null)
                foreach (cAction branchItem in branchItems)
                    InsertTool(groupActionsData, branchItem, listToolIdAdded, listToolIdChoose, ref count);
            var actionOfBranchItems = action.MyGroup.Actions.Values.OrderBy(x => x.STT).Where(x => x.IDBranchItem == action.ID).ToList();
            if (actionOfBranchItems != null)
                foreach (cAction branchItem in actionOfBranchItems)
                    if (listToolIdChoose.Contains(branchItem.ID))
                        InsertTool(groupActionsData, branchItem, listToolIdAdded, listToolIdChoose, ref count);
            tl.RefreshObject(originParentNode);
        }
        private int _frmActionsChooseOldMode = 0;
        private string _frmActionsChooseOldFileName = string.Empty;
        private bool _frmActionsChooseOldSelect = true;
        private List<Guid> _frmActionsChooseOldListToolIdChoose = null;

        private void popDeleteTool_Click(object sender, EventArgs e)
        {
            DeleteTools();
        }

        private void popDeleteAllTools_Click(object sender, EventArgs e)
        {
            DeleteAllTool();
        }

        private void popSetHightLights_Click(object sender, EventArgs e)
        {
            if (tl.SelectedObject == null || tl.SelectedObjects.Count <= 0)
                return;

            cAction action = GetActionFromNode((ActionTools)tl.FocusedObject);
            if (action != null && action.HighLights != null)
            {
                action.HighLights.rtcValue = !action.HighLights.rtcValue;
                if (action.ViewInfo != null && action != action.MyGroup.MainAction)
                    ((ucBaseActionDetail)action.ViewInfo).UpdatePropertyValueToAllControls(nameof(action.HighLights));
                tl.Refresh();
            }

        }

        private void popRemoveAllHighLights_Click(object sender, EventArgs e)
        {
            foreach (cAction action in GlobVar.GroupActions.Actions.Values)
                if (action.HighLights != null)
                    action.HighLights.rtcValue = false;
            tl.Refresh();
        }

        private void tl_CellClick(object sender, CellClickEventArgs e)
        {
            tl.SelectedObject = e.Model;
        }

        private void popCopyTool_Click(object sender, EventArgs e)
        {
            CopyTools();
        }
        internal void CopyTools()
        {
            copyNodes = new List<ActionTools>();
            if (tl.SelectedObject == null || tl.SelectedObjects.Count <= 0)
                return;

            var copyNodes1 = tl.SelectedObjects;
            foreach (ActionTools node in copyNodes1)
            {
                ActionTools cloneNode = CloneNode(node);
                copyNodes.Add(cloneNode);
            }
        }
        private ActionTools CloneNode(ActionTools sourceNode)
        {
            try
            {
                // Sao chép nút hiện tại
                ActionTools cloneNode = sourceNode.Copy();

                // Sao chép các nút con nếu có
                if (sourceNode.child != null && sourceNode.child.Count > 0)
                {
                    cloneNode.child = new List<ActionTools>(); // Khởi tạo danh sách nút con
                    foreach (ActionTools node in sourceNode.child)
                    {
                        ActionTools clonedChildNode = CloneNode(node);
                        if (clonedChildNode != null)
                        {
                            cloneNode.child.Add(clonedChildNode);
                        }
                    }
                }

                return cloneNode;
            }
            catch (Exception ex)
            {
                // Log lỗi (nếu cần)
                return null;
            }
        }

        private void popPasteTool_Click(object sender, EventArgs e)
        {
            PasteTools();
        }
        internal void PasteTools()
        {
            if (copyNodes == null ||
                copyNodes.Count <= 0 ||
                GlobVar.IsLinkMode ||
                GlobVar.IsLinkImageFilterMode ||
                GlobVar.IsLinkCsvWriteValue ||
                GlobVar.IsLinkStringBuilderItemMode)
                return;
            if (tl.SelectedObject == null)
                tl.SelectedObject = GlobVar.GroupActions.MainAction.MyNode;
            cAction focusedAction = GetActionFromNode((ActionTools)tl.SelectedObject);

            try
            {
                GlobVar.LockEvents = true;
                tl.BeginUpdate();

                Dictionary<Guid, Guid> oldGuids = new Dictionary<Guid, Guid>();

                foreach (ActionTools node in copyNodes)
                    PasteTool_CloneTools(node, oldGuids);
                foreach (ActionTools node in copyNodes)
                    PasteTool_RebuildRefID(node, oldGuids);
                int count = 0;
                foreach (ActionTools node in copyNodes)
                {
                    count += 1;
                    ActionTools copyNode = CopyNodeWithChildren(node, GlobVar.GroupActions.MainAction.MyNode, oldGuids);

                    //if (focusedAction.ActionType == EActionTypes.BranchItem)
                    //{
                    //    tl.Move(copyNode, focusedAction.MyNode);
                    //    focusedAction.MyNode.ExpandAll();
                    //}
                    //else
                    //{
                    //    if (tl.GetParent(focusedAction.MyNode) != null)
                    //        tl.MoveNode(copyNode, tl.GetParent(focusedAction.MyNode));
                    //    tl.SetNodeIndex(copyNode, tl.GetNodeIndex(focusedAction.MyNode) + count);
                    //}

                    //copyNode.ExpandAll();
                    tl.RefreshObject(copyNode);
                }

                NumberedOrderAction(tl.Roots.Cast<ActionTools>().ToList());

                //GlobVar.GroupActions.RebuildPassFailLinkItem();

                if (focusedAction != null)
                {
                    if (focusedAction.ActionType == EActionTypes.PassFail)
                        ((ucPassFailActionDetails)focusedAction.ViewInfo).LoadLinkData();
                    else if (focusedAction.ActionType == EActionTypes.ResetTool)
                        ((ucResetToolActionDetail)focusedAction.ViewInfo).LoadLinkData();
                }
            }
            finally
            {
                GlobVar.LockEvents = false;
                tl.EndUpdate();
            }
        }
        private ActionTools CopyNodeWithChildren(ActionTools sourceNode, ActionTools targetNodes, Dictionary<Guid, Guid> oldGuids)
        {
            ActionTools result = null;

            var stack = new Stack<(ActionTools SourceNode, ActionTools TargetNodes)>();
            stack.Push((sourceNode, targetNodes));
            while (stack.Any())
            {
                var operation = stack.Pop();
                var newNode = CopyNode(operation.SourceNode, operation.TargetNodes, oldGuids);
                if (result == null) result = newNode;

            }

            return result;
        }
        private ActionTools CopyNode(ActionTools sourceNode, ActionTools targetNodes, Dictionary<Guid, Guid> oldGuids)
        {
            ActionTools newNode = new ActionTools();

            newNode = sourceNode.Copy();

            if (oldGuids.ContainsKey((Guid)ID.GetValue(sourceNode)))
            {
                GlobVar.GroupActions.Actions[oldGuids[(Guid)newNode.ID]].MyNode = newNode;
                newNode.Description = GlobVar.GroupActions.Actions[oldGuids[(Guid)newNode.ID]].Name.rtcValue;
                newNode.Name = GlobVar.GroupActions.Actions[oldGuids[(Guid)newNode.ID]].Name.rtcValue;
                newNode.ID = oldGuids[(Guid)newNode.ID];
                newNode.Parent = targetNodes;
            }
            targetNodes.child.Add(newNode);

            return targetNodes;
        }
        private void PasteTool_CloneTools(ActionTools node, Dictionary<Guid, Guid> oldGuids)
        {
            if (node == null)
                return;
            if (oldGuids == null)
                oldGuids = new Dictionary<Guid, Guid>();

            GroupActionsData groupActionsData = new GroupActionsData();
            cAction sourceAction = GetActionFromNode(node);
            cAction cloneAction = groupActionsData.CloneAction(sourceAction);
            if (cloneAction == null)
                return;
            oldGuids.Add(sourceAction.ID, cloneAction.ID);
            // Kiểm tra xem các thành phần có chứa các thông tin ID của tool mới
            // có phần nào chứa ID cũ của các tool source được copy hay không để làm lại
            if (oldGuids.ContainsKey(cloneAction.IDBranch))
                cloneAction.IDBranch = oldGuids[cloneAction.IDBranch];
            if (oldGuids.ContainsKey(cloneAction.IDBranchItem))
                cloneAction.IDBranchItem = oldGuids[cloneAction.IDBranchItem];
            if (node.child != null && node.child.Count > 0)
                foreach (ActionTools childNode in node.child)
                    PasteTool_CloneTools(childNode, oldGuids);
        }
        private void PasteTool_RebuildRefID(ActionTools node, Dictionary<Guid, Guid> oldGuids)
        {
            if (node == null || oldGuids == null)
                return;
            cAction sourceAction = GetActionFromNode(node);
            if (sourceAction != null && oldGuids.ContainsKey(sourceAction.ID))
            {
                cAction cloneAction = GlobVar.GroupActions.Actions[oldGuids[sourceAction.ID]];

                var properties = cloneAction.GetType().GetProperties().Where(x =>
                    ((RTCVariableType)x.GetValue(cloneAction, null)) != null &&
                    oldGuids.ContainsKey(((RTCVariableType)x.GetValue(cloneAction, null)).rtcIDRef)).ToList();
                if (properties.Any())
                    for (int i1 = 0; i1 < properties.Count; i1++)
                    {
                        PropertyInfo nProperty = properties[i1];
                        RTCVariableType rtcvar =
                            (RTCVariableType)cloneAction.GetType().GetProperty(nProperty.Name).GetValue(cloneAction, null);

                        if (rtcvar != null)
                            rtcvar.rtcIDRef = oldGuids[rtcvar.rtcIDRef];
                    }

                if (cloneAction.DataItems != null)
                    foreach (SStringBuilderItem dataItem in cloneAction.DataItems)
                        dataItem.RefID = oldGuids.ContainsKey(dataItem.RefID) ? oldGuids[dataItem.RefID] : Guid.Empty;
                if (cloneAction.MyExpression != null && cloneAction.MyExpression.Operands != null)
                    foreach (SStringBuilderItem dataItem in cloneAction.MyExpression.Operands)
                        dataItem.RefID = oldGuids.ContainsKey(dataItem.RefID) ? oldGuids[dataItem.RefID] : Guid.Empty;
            }

            if (node.child != null && node.child.Count > 0)
                foreach (ActionTools childNode in node.child)
                    PasteTool_RebuildRefID(childNode, oldGuids);
        }

        private void popExpand_Click(object sender, EventArgs e)
        {
            tl.Expand(tl.SelectedObject);
        }

        private void popCosllape_Click(object sender, EventArgs e)
        {
            tl.Collapse(tl.SelectedObject);
        }

        private void popExpandAll_Click(object sender, EventArgs e)
        {
            tl.ExpandAll();
        }

        private void popCollapseAll_Click(object sender, EventArgs e)
        {
            tl.CollapseAll();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //tl.ExpandAll();
            string SSearch = txtSearch.Text.Trim().ToLower();
            //TextMatchFilter filter = TextMatchFilter.Contains(tl, SSearch);

            //tl.ModelFilter = filter;
            //HighlightTextRenderer textRenderer = new HighlightTextRenderer(filter);

            //textRenderer.FillBrush = new SolidBrush(Color.Red);
            //textRenderer.FramePen = new Pen(Color.Red, 1);

            //// Thiết lập các thuộc tính khác (nếu cần)
            ////textRenderer.hight = Color.Red; // Đặt màu tô sáng thành màu đỏ

            //// Áp dụng bộ tô sáng cho TreeListView
            //tl.DefaultRenderer = textRenderer;
            //tl.RebuildColumns();
            tl.ModelFilter = new ModelFilter(model =>
            {
                var item = model as ActionTools; // Thay YourModelClass bằng lớp đối tượng của bạn

                return item.Description.Trim().ToLower().Contains(SSearch);
            });

        }

        private void popLockMoveTools_Click(object sender, EventArgs e)
        {
            LockEditTools();
        }


    }
}


