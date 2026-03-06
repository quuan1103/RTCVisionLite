using BrightIdeasSoftware;
using CommonTools;

//using CommonTools;
using RTC_Vision_Lite.Classes;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RTC_Vision_Lite.UserControls
{
    public partial class ucTemplateTools : UserControl
    {
        public class MyActionNode
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
            public List<MyActionNode> childNode = new List<MyActionNode>();
        }
        public bool IsDaNap { get; set; }
        private bool _isLocate;
        public bool IsLocate
        {
            get => _isLocate;
            set => _isLocate = value;
        }

        public event AddAction OnAddAction;

        public cAction _action;
        private ArrayList _roots = new ArrayList();
        private List<MyActionNode> _rootsa = new List<MyActionNode>();
        public ucTemplateTools()
        {
            InitializeComponent();
            tl_template.LargeImageList = GlobVar.imlActionType24;
            tl_template.TreeColumnRenderer.IsShowLines = false;
            tl_template.IsSimpleDropSink = true;
            tl_template.IsSimpleDragSource = true;
            //tl.HighlightBackgroundColor = Color.White;
            SimpleDropSink sink1 = (SimpleDropSink)tl_template.DropSink;
            sink1.AcceptExternal = true;
            sink1.CanDropBetween = true;
            GlobVar.tl_Template = this.tl_template;



        }
        MyActionNode groupNode;
        MyActionNode node;
        public void ShowAction()
        {
            try
            {
                tl_template.BeginUpdate();
                if (IsDaNap)
                    ShowHideActionByContext_Run();
                    //ShowHideActionByContext_Run(tl_template.Roots.Cast<MyActionNode>().ToList());

                //ShowHideActionByContext_Run(tl_template.Nodes.;
                else
                {
                    IsDaNap = false;
                    tl_template.Roots = null;
                    if (CommonData.ActionList == null) return;

                    string Groupname = string.Empty;
                    //TreeNode ParentNode = null;
                    //TreeNode GroupNode = null;
                    //TreeNode ActionNode = null;

                    foreach (DataRow groupRow in CommonData.ActionGroupList.Rows)
                    {
                        DataRow[] dataRows = CommonData.ActionList.Select($"{cColName.GroupName}='{GlobFuncs.GetDataRowValue_String(groupRow, cColName.GroupName)}'");
                        foreach (DataRow row in dataRows)
                            if (!GlobFuncs.Object2Bool(row[cColName.IsHide]))
                            {
                                if (GlobVar.BuildMode == EBuildMode.Demo && GlobVar.ListToolDemo[0] != cStrings.AllTools && !GlobVar.ListToolDemo.Contains(row[cColName.ActionName].ToString()))
                                    continue;
                                if (Groupname.ToLower() != row[cColName.GroupName].ToString().ToLower())
                                {
                                    var _match = _rootsa.Where(x => x.ActionName.Contains(row[cColName.GroupName].ToString())).ToList();
                                    if (_match.Count < 1)
                                    {
                                        groupNode = new MyActionNode();

                                        groupNode.ActionName = row[cColName.GroupName].ToString();
                                        groupNode.ActionCaption = row[cColName.GroupName].ToString();
                                        //groupNode.Type = (int)Enum.Parse(typeof(EActionTypes), row[cColName.ActionName].ToString());
                                        groupNode.IsLocate = bool.Parse(row[cColName.IsLocate].ToString());
                                        groupNode.IsConstructor = bool.Parse(row[cColName.IsConstructor].ToString());
                                        groupNode.IsNew = bool.Parse(row[cColName.IsNew].ToString());
                                        groupNode.IsUpdate = bool.Parse(row[cColName.IsUpdate].ToString());
                                        groupNode.UpdateDescription = row[cColName.UpdateDescription].ToString();
                                        groupNode.Description = row[cColName.Description].ToString();

                                        //var match = _rootsa.Where(x => x.ActionName == groupNode.ActionName).ToList();
                                        //if (match.Count < 1)
                                        _rootsa.Add(groupNode);
                                    }
                                    //Node _node = new Node(new object[] { "", ENodeTypes.Group, "", row[cColName.IsLocate], false, false, false, "", row[cColName.GroupName], null });
                                    //tl_template.Nodes.Add(_node);
                                    //Groupname = row[cColName.GroupName].ToString();
                                    //GroupNode.ImageIndex = -1;
                                    //GroupNode.SelectedImageIndex = -1;
                                }
                                node = new MyActionNode();
                                node.ActionName = row[cColName.ActionName].ToString();
                                node.ActionCaption = row[cColName.ActionCaption].ToString();
                                var test = Enum.Parse(typeof(EActionTypes), row[cColName.ActionName].ToString());
                                node.Type = (int)Enum.Parse(typeof(EActionTypes), row[cColName.ActionName].ToString());
                                node.IsLocate = bool.Parse(row[cColName.IsLocate].ToString());
                                node.IsConstructor = bool.Parse(row[cColName.IsConstructor].ToString());
                                node.IsNew = bool.Parse(row[cColName.IsNew].ToString());
                                node.IsUpdate = bool.Parse(row[cColName.IsUpdate].ToString());
                                node.UpdateDescription = row[cColName.UpdateDescription].ToString();
                                node.Description = row[cColName.Description].ToString();
                                //_roots
                                groupNode.childNode.Add(node);



                            }
                        tl_template.Roots = _rootsa;
                        tl_template.CanExpandGetter = x => (x as MyActionNode).childNode.Count > 0;
                        tl_template.ChildrenGetter = x => (x as MyActionNode).childNode;
                    }
                    IsDaNap = true;
                }
            }
            catch(Exception ex)
            {
               
            }
            finally
            {
                tl_template.EndUpdate();
            }
        }

        private void ShowHideActionByContext_Run()
        {
            string SSearch = txtSearch.Text.Trim().ToLower();
            if(SSearch == string.Empty)
            {
                tl_template.CollapseAll();
            }    
            else
            {
                tl_template.ExpandAll();
            }    
            //if (node == null) return;
            //foreach (MyActionNode _node in node)
            //{
            //    string caption = GlobFuncs.Object2Str(node.Nodes);

            //    if (node.HasChildren)
            //        node.Vi
            //    if (_node != null)
            //    {
            //        ShowHideActionByContext_Run(_node.childNode);
            //        if (!string.IsNullOrEmpty(SSearch))
            //            tl_template.ExpandAll();
            //        else
            //            tl_template.CollapseAll();
            //    }
            //}
             //ApplyFilter(SSearch);
             tl_template.ModelFilter = TextMatchFilter.Contains(tl_template, SSearch);

            //foreach (OLVListItem item in tl_template.Items)
            //{
            //    item.
            //}    
        }
        private bool FilterNode(object model, string searchText)
        {
            bool isMatch = ((MyActionNode)model).ActionName.ToLower().Contains(searchText);

            // Kiểm tra các node con.
            var children = tl_template.GetChildren(model);
            foreach (var child in children)
            {
                // Nếu có node con thỏa mãn, cha cần được mở rộng.
                if (FilterNode(child, searchText))
                {
                    tl_template.Expand(model); // Mở rộng cha.
                    isMatch = true;
                }
                //else
                //{
                //    if (tl_template.CanExpand(model) && tl_template.IsExpanded(model))
                //    {
                //        tl_template.Collapse(model);
                //    }// Mở rộng cha.
                //    isMatch = true;
                //}
                //else
                //{
                //    tl_template.Collapse(model);
                //}    
            }
            return isMatch;
        }
        public void ApplyFilter(string searchText)
        {
            tl_template.ModelFilter = new ModelFilter(model =>
            {
                return FilterNode(model, searchText);
            });

            // Cập nhật giao diện sau khi áp dụng lọc.
            tl_template.Refresh();

        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void tl_template_DoubleClick(object sender, EventArgs e)
        {
            OLVListItem FocusItem = tl_template.FocusedItem as OLVListItem;
            if (FocusItem == null || Lib.ToString(colActionType.GetValue(FocusItem.RowObject))== "0")
            {
                if(tl_template.IsExpanded(FocusItem.RowObject))
                {
                    tl_template.Collapse(FocusItem.RowObject);
                }  
                else
                    tl_template.Expand(FocusItem.RowObject);
                return;
            }


            string a = ((MyActionNode)(tl_template.FocusedObject)).ActionName;
            string value = a.Replace("/","");
            RTCE_AddActionEventArgs eRTC = new RTCE_AddActionEventArgs();
            eRTC.ActionTypes = (EActionTypes)Enum.Parse(typeof(EActionTypes), value);
            if (OnAddAction != null)
                OnAddAction(this, eRTC);
        }
        //public cAction GetActionFormNode(Node node)
        //{
        //    return null;
        //    //try
        //    //{
        //    //    cAction action = null;
        //    //    if (node == null)
        //    //        return action;
        //    //    ENodeTypes eNodeTypes = GlobFuncs.GetNodeType(node, tl_template.Columns["NodeType"]);
        //    //    Guid idAction = _action.ID;
        //    //    if (GlobVar.GroupActions.Actions.ContainsKey(idAction))
        //    //        action = GlobVar.GroupActions.Actions[idAction];

        //    //    return action;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return null;
        //    //}
        //}

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            if (tl_template.FocusedObject == null || this.colActionType.GetValue(this.tl_template.SelectedObject).ToString() == "")
            {
                cMessageBox.Warning(RTC_Vision_Lite.Properties.Resources.NotChooseCamera);
                return;
            }

            if (CommonData.ActionList != null)
            {
                bool isConstructor =
                    GlobFuncs.Object2Bool(this.colIsConstructor.GetValue(this.tl_template.FocusedObject));
                if (isConstructor)
                {
                    cMessageBox.Warning(cMessageContent.Nor_ToolUnderConstruction);
                    return;
                }
            }

            RTCE_AddActionEventArgs eRTC = new RTCE_AddActionEventArgs();
            eRTC.ActionTypes = (EActionTypes)this.colActionType.GetValue(this.tl_template.FocusedObject);

            if (OnAddAction != null)
                OnAddAction(this, eRTC);
        }

        

        private void tl_template_FormatCell_1(object sender, FormatCellEventArgs e)
        {
            if (e.Column == colCaption)
            {
                if (Lib.ToInt(((MyActionNode)e.Item.RowObject).Type) > 0)
                {
                    e.Item.ImageSelector = GlobVar.imlActionType24.Images.IndexOfKey(Enum.GetName(typeof(EActionTypes), (int)Enum.Parse(typeof(EActionTypes), ((MyActionNode)e.Model).ActionName)));
                    BorderDecoration Padding = new BorderDecoration();
                    Padding.BoundsPadding = new Size(100, 0);
                    e.SubItem.Decoration = Padding;
                }
            }
        }

        private void tl_template_CellClick(object sender, CellClickEventArgs e)
        {
            tl_template.SelectedObject = e.Model;
            
        }
        internal void UpdateFont()
        {
            if (tl_template.InvokeRequired)
            {
                tl_template.Invoke(new Action(() =>
                {
                    tl_template.Font = CommonData.GetFontStyle(cFontStyles.ListOfToolOfProgram);
                }));
            }
            else
                tl_template.Font = CommonData.GetFontStyle(cFontStyles.ListOfToolOfProgram);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowAction();
        }
    }
}
