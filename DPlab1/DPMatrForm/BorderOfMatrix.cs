using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DPMatrForm
{
    public class BorderOfMatrix : Control
    {
        private Color myBorderColor = Color.Black;
        private int _sizeW = 0;
        private int _sizeH = 0;
        public int SizeW_
        {
            set
            {
                _sizeW = value;
                Init();
            }
            get
            {
                return _sizeW;
            }
        }
        public int SizeH_
        {
            set
            {
                _sizeH = value;
                Init();
            }
            get
            {
                return _sizeH;
            }
        }
        public Color BorderColor
        {
            set
            {
                myBorderColor = value;
            }
            get
            {
                return myBorderColor;
            }
        }
        private Rectangle clientRect;
        private void Init()
        {
            this.Location = new Point(4, 4);
            clientRect = new Rectangle(new Point(3, 3), new System.Drawing.Size(_sizeW, _sizeH));
            this.Size = new Size(_sizeW + 5, _sizeH + 5);
        }
        public BorderOfMatrix() : base()
        {
            Init();
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            this.Invalidate();
            this.Update();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), clientRect);
            Pen myPen = new Pen(myBorderColor, 4);
            e.Graphics.DrawRectangle(myPen, clientRect);
        }
    }
}
