using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CommonTools;
//using BrightIdeasSoftware;

namespace RTC_Vision_Lite.UserControls
{
	public class TestTree : TreeListView
    {

        public event FocusedNodeChanged OnFocusedNodeChanged;

        private bool _LockCalc;

        public bool LockCalc
        {
            get { return _LockCalc; }
            set
            {
                _LockCalc = value;
                if (!_LockCalc) this.Refresh();
            }
        }
        ContextMenu m_contextMenu = null;
        public TestTree()
        {
            m_contextMenu = new ContextMenu();
            m_contextMenu.MenuItems.Add(new MenuItem("Collapse All Children", new EventHandler(OnCollapseAllChildren)));
            m_contextMenu.MenuItems.Add(new MenuItem("Expand All Children", new EventHandler(OnExpandAllChildren)));
            m_contextMenu.MenuItems.Add(new MenuItem("Delete Selected Node", new EventHandler(OnDeleteSelectedNode)));
            InitializeComponent();
        }

        private void OnCollapseAllChildren(object sender, EventArgs e)
        {
            BeginUpdate();
            if (MultiSelect && Nodes.Count > 0)
            {
                foreach (CommonTools.Node selnode in NodesSelection)
                {
                    foreach (CommonTools.Node node in selnode.Nodes)
                        node.Collapse();
                }
                NodesSelection.Clear();
            }
            if (FocusedNode != null && FocusedNode.HasChildren)
            {
                foreach (CommonTools.Node node in FocusedNode.Nodes)
                    node.Collapse();
            }
            EndUpdate();
        }
        private void OnExpandAllChildren(object sender, EventArgs e)
        {
            BeginUpdate();
            if (MultiSelect && NodesSelection.Count > 0)
            {
                foreach (CommonTools.Node selnode in NodesSelection)
                    selnode.ExpandAll();
                NodesSelection.Clear();
            }
            if (FocusedNode != null)
                FocusedNode.ExpandAll();
            EndUpdate();
        }

        private void OnDeleteSelectedNode(object sender, EventArgs e)
        {
            BeginUpdate();
            foreach (CommonTools.Node selnode in NodesSelection)
            {
                if (selnode != null && selnode.Owner != null)
                {
                    selnode.Collapse();
                    CommonTools.Node nextnode = CommonTools.NodeCollection.GetNextNode(selnode, 1);
                    if (nextnode == null)
                        nextnode = CommonTools.NodeCollection.GetNextNode(selnode, -1);
                    selnode.Owner.Remove(selnode);
                    FocusedNode = nextnode;
                }
            }
            EndUpdate();
        }

        protected override void BeforeShowContextMenu()
        {
            if (GetHitNode() == null)
                ContextMenu = null;
            else
                ContextMenu = m_contextMenu;
        }
        protected override object GetData(CommonTools.Node node, CommonTools.TreeListColumn column)
        {
            //object data = base.GetData(node, column);
            //if (data != null)
            //    return data;
            //column.
            if (column.Fieldname == "childCount")
            {
                if (node.HasChildren)
                    return node.Nodes.Count;
                return "<none>";
            }
            if (column.Fieldname == "visibleCount")
            {
                if (node.HasChildren)
                    return node.VisibleNodeCount;
                return "<none>";
            }
            return string.Empty;
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }
    }
	//public class TestTreeNode : Tr
 //   {
	//	const int minHeight = 5;
	//	int height;

	//	public TestTreeNode(int id, Node owner) : base(id, owner)
 //       {
	//		this.height = (owner.)
 //       }
 //   }
}
