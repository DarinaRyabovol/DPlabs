using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DPlab1;

namespace DPMatrForm
{
    public abstract class Decorator : IMatrix
    {
        public Decorator(IMatrix m)
        {
            matrix = m;
        }

        public IMatrix Matrix
        {
            get
            {
                return matrix;
            }
        }

        public abstract void Write(int number, int rowPosition, int colPosition);
        public abstract int Read(int rowPosition, int colPosition);
        public virtual int GetNumberOfColumns()
        {
            return matrix.GetNumberOfColumns();
        }
        public virtual int GetNumberOfRows()
        {
            return matrix.GetNumberOfRows();
        }

        private IMatrix matrix;
    }

    public class RenumberRowsDecorator : Decorator
    {
        public RenumberRowsDecorator(IMatrix m)
            : base(m)
        {
            Random r = new Random(System.DateTime.Now.Second);
            irow = r.Next() % m.GetNumberOfRows();
            jrow = r.Next() % m.GetNumberOfRows();
            while (jrow == irow)
            {
                jrow = r.Next() % m.GetNumberOfRows();
            }

        }

        public override int Read(int rowPosition, int colPosition)
        {
            if (rowPosition == irow)
            {
                return Matrix.Read(jrow, colPosition);
            }
            if (rowPosition == jrow)
            {
                return Matrix.Read(irow, colPosition);
            }
            return Matrix.Read(rowPosition, colPosition);
        }
        public override void Write(int number, int rowPosition, int colPosition)
        {
            if (rowPosition == irow)
            {
                Matrix.Write(number, jrow, colPosition);
                return;
            }
            if (rowPosition == jrow)
            {
                Matrix.Write(number, irow, colPosition);
                return;
            }
            Matrix.Write(number, rowPosition, colPosition);
            return;

        }

        private int irow;
        private int jrow;
    }

    public class RenumberColsDecorator : Decorator
    {
        public RenumberColsDecorator(IMatrix m)
            : base(m)
        {
            Random r = new Random(System.DateTime.Now.Second);
            icol = r.Next() % m.GetNumberOfRows();
            jcol = r.Next() % m.GetNumberOfRows();
            while (jcol == icol)
            {
                jcol = r.Next() % m.GetNumberOfRows();
            }

        }

        public override int Read(int rowPosition, int colPosition)
        {
            if (colPosition == icol)
            {
                return Matrix.Read(rowPosition, jcol);
            }
            if (colPosition == jcol)
            {
                return Matrix.Read(rowPosition, icol);
            }
            return Matrix.Read(rowPosition, colPosition);
        }
        public override void Write(int number, int rowPosition, int colPosition)
        {
            if (colPosition == icol)
            {
                Matrix.Write(number, rowPosition, jcol);
                return;
            }
            if (colPosition == jcol)
            {
                Matrix.Write(number, rowPosition, icol);
                return;
            }
            Matrix.Write(number, rowPosition, colPosition);
            return;

        }

        private int icol;
        private int jcol;

    }

    public class TransposeDecorator : Decorator
    {
        public TransposeDecorator(IMatrix m) : base(m) { }

        public override int GetNumberOfColumns()
        {
            return Matrix.GetNumberOfRows();
        }
        public override int GetNumberOfRows()
        {
            return Matrix.GetNumberOfColumns();
        }
        public override int Read(int rowPosition, int colPosition)
        {
            return Matrix.Read(colPosition, rowPosition);
        }
        public override void Write(int number, int rowPosition, int colPosition)
        {
            Matrix.Write(number, colPosition, rowPosition);
        }
    }
}
