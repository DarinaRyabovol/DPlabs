using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPMatrForm
{
    public interface IVisited
    {
        void accept(IVisitor v);
    }
    public interface IVisitor
    {
        void visitOriginMatrix(IMatrix m);
        void visitSparceMatrix(IMatrix m);
    }

    public class DrawVisitor : IVisitor
    {
        public DrawVisitor(IPainter painter)
        {
            myPainter = painter;
        }

        public void visitOriginMatrix(IMatrix m)
        {
            myPainter.InitBorder(m.GetNumberOfRows(), m.GetNumberOfColumns());
            for (int i = 0; i < m.GetNumberOfRows(); i++)
            {
                for (int j = 0; j < m.GetNumberOfColumns(); j++)
                {
                    myPainter.InitCell(i, j, Convert.ToString(m.Read(i, j)));
                }
            }
        }
        public void visitSparceMatrix(IMatrix m)
        {
            myPainter.InitBorder(m.GetNumberOfRows(), m.GetNumberOfColumns());

            for (int i = 0; i < m.GetNumberOfRows(); i++)
            {
                for (int j = 0; j < m.GetNumberOfColumns(); j++)
                {
                    if (m.Read(i, j) != 0)
                    {
                        myPainter.InitCell(i, j, Convert.ToString(m.Read(i, j)));
                    }
                    else
                    {
                        myPainter.InitEmptyCell(i, j);
                    }
                }
            }
        }

        private IPainter myPainter;
    }
}
