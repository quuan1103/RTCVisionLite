using BrightIdeasSoftware;
using RTC_Vision_Lite.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public class MyTreeList : TreeListView
    {
        public MyTreeList()
        {
            // Đăng ký sự kiện vẽ tiêu đề cột.
            this.OwnerDraw = true; // Bắt buộc để sự kiện vẽ tùy chỉnh hoạt động.
            this.OwnerDrawnHeader = true; // Bắt buộc để sự kiện vẽ tùy chỉnh hoạt động.
            this.DrawColumnHeader += MyTreeListView_DrawColumnHeader;
        }
        private bool _LockCalc;
        public bool LockCalc
        {
            get { return _LockCalc; }
            set
            {
                _LockCalc = value;
                if (!LockCalc) this.Refresh();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //if (LockCalc) return; // Nếu LockCalc là true, không vẽ


            // Vẽ các đường liên kết giữa các node
            foreach (OLVListItem item in Items)
            {
                DrawConnections(e.Graphics, item);
            }
            base.OnPaint(e);

        }

        private void DrawConnections(Graphics g, OLVListItem item)
        {
            ActionTools node = item.RowObject as ActionTools;
            if (node == null || node.Parent == null) return;

            OLVListItem parentItem = ModelToItem(node.Parent);

            if (parentItem != null)
            {
                Point startPoint = new Point(item.Bounds.Left, item.Bounds.Top + item.Bounds.Height / 2);
                Point endPoint = new Point(parentItem.Bounds.Right, parentItem.Bounds.Top + parentItem.Bounds.Height / 2);

                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.DrawLine(pen, startPoint, endPoint);
                }
            }
        }
        private void MyTreeListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            using (Brush backgroundBrush = new SolidBrush(Color.FromArgb(230, 230, 230)))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            // Thiết lập khoảng cách cho văn bản.
            Rectangle textBounds = new Rectangle(
                e.Bounds.X + 5, e.Bounds.Y,
                e.Bounds.Width - 10, e.Bounds.Height);

            TextRenderer.DrawText(
                e.Graphics,
                e.Header.Text,
                e.Font,
                textBounds,
                Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            // Vẽ khung bao quanh ô tiêu đề.
            using (Pen borderPen = new Pen(Color.DimGray))
            {
                e.Graphics.DrawRectangle(borderPen,
                    new Rectangle(e.Bounds.X, e.Bounds.Y,
                                  e.Bounds.Width , e.Bounds.Height ));
            }

            // Đảm bảo không vẽ mặc định.
            e.DrawDefault = false;
        }
    }

}

    



