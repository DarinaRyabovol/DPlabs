using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPlab1
{
    public interface IMatrix
    {
        void Write(int number, int rowPosition, int colPosition);
        int Read(int rowPosition, int colPosition);
        int GetNumberOfColumns();
        int GetNumberOfRows();
    }

    public abstract class Matrix : IMatrix
    {
        private int rows;
        private int columns;
        private IVector[] vectors;
        public abstract IVector Create(int rows);
        public virtual void Write(int nubmer, int rowPosition, int colPosition)
        {
            vectors[colPosition].Write(nubmer, rowPosition);
        }
        public virtual int Read(int rowPosition, int colPosition)
        {
            return vectors[colPosition].Read(rowPosition);
        }
        public virtual int GetNumberOfColumns()
        {
            return columns;
        }
        public virtual int GetNumberOfRows()
        {
            return rows;
        }
        public virtual string ToString()
        {
            string matrix = new string('\n', 1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix += Read(i, j);
                    matrix += ' ';
                }
                matrix += '\n';
            }
            return matrix;
        }
        public Matrix(int Rows, int Columns)
        {
            rows = Rows;
            columns = Columns;
            vectors = new IVector[Columns];
            for (int i = 0; i < columns; i++)
            {
                vectors[i] = Create(Rows);
            }
        }
    }

    public class OriginMatrix : Matrix 
    {
        public OriginMatrix(int cols, int row) : base(row, cols) {}

        public override IVector Create(int rows)
        {
            return new OriginVector(rows);
        }
    }

    public class SparceMatrix : Matrix
    {
        public SparceMatrix(int cols, int row) : base(row, cols){}
        public override IVector Create(int rows)
        {
            return new SparceVector(rows);
        }

    }
  
}
