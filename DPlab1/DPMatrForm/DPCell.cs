using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DPMatrForm
{
   public class DPCell : Control
    {
       private int _size = 0;
       private Color _color = Color.Black;
       public Color Color
       {
           set
           {
               _color = value;
               Init();
           }
           get
           {
               return _color;
           }
       }
       private Rectangle clientRect;
       private Rectangle shadowRect;
       private float fontsize;
       private float border;
       private float shadowShift;
       private bool shadow = false;
       private SolidBrush shadowBrush = new SolidBrush(Color.LightGray);
       public bool Shadow
       {
           set
           {
               shadow = value;
           }
           get
           {
               return shadow;
           }
       }
       public int Size_
       {
           set
           {
               _size = value;
               Init();

           }
           get
           {
               return _size;
           }
       }
       private void Init()
       {
           float coord = border;
           shadowShift = border + _size / 50;
           fontsize = 19 * _size / 100;
           border = _size / 20;
           clientRect = new Rectangle(new Point((int)coord, (int)coord), new System.Drawing.Size(_size, _size));
           shadowRect = new Rectangle(new Point((int)shadowShift + (int)coord, (int)shadowShift + (int)coord), new System.Drawing.Size(_size, _size));
           this.Location = new Point(0, 0);
           this.Size = new System.Drawing.Size(_size, _size);
       }       
       public DPCell()
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
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(new Point(0, 0), new Size(this._size, this._size)));
            Pen p = new Pen(_color, border);
            Pen p1 = new Pen(shadowBrush, border + 1);
            Font f = new System.Drawing.Font("Arial", fontsize);
            Font f1 = new System.Drawing.Font("Arial", fontsize + 3);
            StringFormat style = new StringFormat();
            style.Alignment = StringAlignment.Center;
            style.LineAlignment = StringAlignment.Center;
            if (shadow)
            {
                e.Graphics.DrawRectangle(p1, shadowRect);
                e.Graphics.DrawRectangle(p, clientRect);
                e.Graphics.DrawString(Text, f1, shadowBrush, shadowRect, style);
                e.Graphics.DrawString(Text, f, new SolidBrush(this.ForeColor), clientRect, style);
            }
            else
            {
                e.Graphics.DrawRectangle(p, clientRect);
                e.Graphics.DrawString(Text, f, new SolidBrush(this.ForeColor), clientRect, style);
            }
        }

    }
}
