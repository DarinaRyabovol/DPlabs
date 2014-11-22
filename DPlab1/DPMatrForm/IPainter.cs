using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DPlab1;
using System.Drawing;

namespace DPMatrForm
{
    public interface IPainter
    {
        void InitBorder(int rows, int cols);
        void InitCell(int i, int j, string value);
        void InitEmptyCell(int i, int j);
    }

    public abstract class Painter : IPainter
    {

        public Painter(System.Windows.Forms.Form f, int xpos, int ypos)
        {
            parent = f;
            x = xpos;
            y = ypos;
        }


        public int Size
        {
            set
            {
                sizepx = value;
            }
            get
            {
                return sizepx;
            }
        }
        public System.Drawing.Color MyBorderColor
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
        public Color MyBackcolor
        {
            set
            {
                myBackcolor = value;
            }
            get
            {
                return myBackcolor;
            }
        }
        public Color CellBorder
        {
            set
            {
                cellBorder = value;
            }
            get
            {
                return cellBorder;
            }
        }
        public Color CellBackcolor
        {
            set
            {
                cellBorder = value;
            }
            get
            {
                return cellBorder;
            }
        }
        public Color EmptyCellBackcolor
        {
            set
            {
                emptyCellBackcolor = value;
            }
            get
            {
                return emptyCellBackcolor;
            }
        }
        public Color FontColor
        {
            set
            {
                fontColor = value;
            }
            get
            {
                return fontColor;
            }
        }


        public abstract bool isShadow();
        private void Update()
        {
            foreach (DPCell c in cells)
            {
                c.Parent = border;
            }
            parent.Update();
        }

        // Interface implementation
        public void InitEmptyCell(int i, int j)
        {
            DPCell cell = new DPCell();
            cell.Color = emptyCellBackcolor;
            cell.BackColor = emptyCellBackcolor;
            cell.ForeColor = FontColor;
            cell.Size_ = Size;
            cell.Location = new Point(6 + i * (sizepx + 1), 6 + j * (sizepx + 1));
            cell.Shadow = isShadow();
            cell.Text = "";
            cells.Add(cell);
            Update();
        }
        public void InitBorder(int row, int cols)
        {
            border = new BorderOfMatrix();
            border.BorderColor = myBorderColor;
            int sizeh = row * (sizepx + 2);
            int sizew = cols * (sizepx + 2);
            border.SizeW_ = sizew + 1;
            border.SizeH_ = sizeh + 1;
            border.Size = new Size(sizew + 5, sizeh + 5);
            border.Location = new Point(x, y);
            border.BackColor = myBackcolor;
            border.Parent = parent;
            border.Show();
        }
        public virtual void InitCell( int i, int j, string value)
        {
            DPCell cell = new DPCell();
            cell.Color = cellBorder;
            cell.BackColor = cellBackcolor;
            cell.ForeColor = FontColor;
            cell.Size_ = Size;
            cell.Location = new Point(6 + i * (sizepx + 1),6 + j * (sizepx + 1));
            cell.Shadow = isShadow();
            cell.Text = value;
            cells.Add(cell);
            Update();
        }

        // Colors
        private System.Drawing.Color myBorderColor = Color.ForestGreen;
        private Color myBackcolor = Color.SkyBlue;
        private Color cellBorder = Color.GreenYellow;
        private Color cellBackcolor = Color.Snow;
        private Color emptyCellBackcolor = Color.LightGoldenrodYellow;
        private System.Drawing.Color fontColor = Color.BurlyWood;

        // Elements
        private int sizepx = 60;
        private BorderOfMatrix border;
        private List<DPCell> cells = new List<DPCell>(0);
        private System.Windows.Forms.Form parent;
        private int x;
        private int y;

    }

    public class ColoredPainter : Painter
    {
        public ColoredPainter(System.Windows.Forms.Form f, int x, int y)
            : base(f, x, y)
        {
        }
        public override bool isShadow()
        {
            return false;
        }
    }


    public class ColoredPainterWithShadow : ColoredPainter
    {
        public ColoredPainterWithShadow(System.Windows.Forms.Form f, int x, int y)
            : base(f, x, y) { }
        public override bool isShadow()
        {
            return true;
        }
    }


    public class BlackPainter : Painter
    {
        public BlackPainter(System.Windows.Forms.Form f, int x, int y)
            : base(f, x, y)
        {
            MyBackcolor = Color.White;
            CellBackcolor = Color.White;
            CellBorder = Color.Black;
            EmptyCellBackcolor = Color.White;
            MyBorderColor = Color.Black;
            FontColor = Color.Black;
        }

        public override bool isShadow()
        {
            return false;
        }
    }


    public class BlackPainterWithShadow : BlackPainter
    {
        public BlackPainterWithShadow(System.Windows.Forms.Form f, int x, int y)
            : base(f, x, y)
        {
        }

        public override bool isShadow()
        {
            return true;
        }
    }
}
