using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DPMatrForm
{
    public abstract class DrawingMatrix 
    {
        public DrawingMatrix(IMatrix m, IPainter painter)
        {
            this.matrix = m;
            myPainter = painter;
        }

        protected IPainter Painter
        {
            get
            {
                return myPainter;
            }
        }
        public void Write(int number, int rowPosition, int colPosition)
        {
            matrix.Write(number, rowPosition, colPosition);
        }
        public int Read(int rowPosition, int colPosition)
        {
            return matrix.Read(rowPosition, colPosition);
        }
        public int GetNumberOfColumns()
        {
            return matrix.GetNumberOfColumns();
        }
        public int GetNumberOfRows()
        {
            return matrix.GetNumberOfRows();
        }
        public void SetPainter(IPainter painter)
        {
            myPainter = painter;
        }
        public virtual void Paint()
        {
            myPainter.InitBorder(GetNumberOfRows(), GetNumberOfColumns());
        }

        private IMatrix matrix;
        private IPainter myPainter;
    }

    public class OriginDrawingMatrix : DrawingMatrix
    {
        public OriginDrawingMatrix(IMatrix m, IPainter painter) : base(m, painter) { }
        public override void Paint()
        {
            base.Paint();

            for (int i = 0; i < GetNumberOfRows(); i++)
            {
                for (int j = 0; j < GetNumberOfColumns(); j++)
                {
                    Painter.InitCell(i, j, Convert.ToString(Read(i, j)));
                }
            }
        }
    }

    public class SparceDrawingMatrix : DrawingMatrix
    {
        public SparceDrawingMatrix(IMatrix m, IPainter painter) : base(m, painter) { }
        public override void Paint()
        {
            base.Paint();

            for (int i = 0; i < GetNumberOfRows(); i++)
            {
                for (int j = 0; j < GetNumberOfColumns(); j++)
                {
                    if (Read(i, j) != 0)
                    {
                        Painter.InitCell(i, j, Convert.ToString(Read(i, j)));
                    }
                    else
                    {
                        Painter.InitEmptyCell(i, j);
                    }
                }
            }
        }
    }
}
