using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPlab1
{
    public class InitMatrix
    {
        public static void Init(Matrix matrix, int numberOfElements, int maxElem)
        {
            Random r = new Random();
            if (numberOfElements + 1> (matrix.GetNumberOfColumns() * matrix.GetNumberOfRows()))
                return;
            for (int i = 0; i < numberOfElements; i++)
            {
                int k = r.Next(matrix.GetNumberOfRows());
                int l = r.Next(matrix.GetNumberOfColumns());
                while (matrix.Read(k, l) > 0)
                {
                    k = r.Next(matrix.GetNumberOfRows());
                    l = r.Next(matrix.GetNumberOfColumns());
                }
                matrix.Write(r.Next(maxElem) + 1, k, l);
            }
        }
        public static void Init(Matrix source, Matrix dest)
        {
            for (int i = 0; i < source.GetNumberOfRows(); i++)
            {
                for (int j = 0; j < source.GetNumberOfColumns(); j++)
                {
                    dest.Write(source.Read(i, j), i, j);
                }
            }
        }
    }
}
