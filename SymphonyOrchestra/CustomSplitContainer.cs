using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymphonyOrchestra
{
    public class CustomSplitContainer : SplitContainer
    {
        private Color splitterColor = Color.Gray;
        private int splitterThickness = 3; // Толщина линии разделителя

        public Color SplitterColor
        {
            get { return splitterColor; }
            set
            {
                splitterColor = value;
                Invalidate();
            }
        }

        public int SplitterThickness
        {
            get { return splitterThickness; }
            set
            {
                splitterThickness = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Отрисовка разделительной линии в указанном цвете и толщине
            using (Pen splitterPen = new Pen(SplitterColor, SplitterThickness))
            {
                if (Orientation == Orientation.Horizontal)
                {
                    int splitterY = SplitterRectangle.Y + SplitterRectangle.Height / 2;
                    e.Graphics.DrawLine(splitterPen, SplitterRectangle.X, splitterY, SplitterRectangle.Right, splitterY);
                }
                else
                {
                    int splitterX = SplitterRectangle.X + SplitterRectangle.Width / 2;
                    e.Graphics.DrawLine(splitterPen, splitterX, SplitterRectangle.Y, splitterX, SplitterRectangle.Bottom);
                }
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
