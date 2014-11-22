using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPlab1
{
    class MatrixStatistic
    {
        private Matrix myMatrix;
        private int summ, max, count;
        private double srznuch;
        public int Summ
        {
            get
            {
                return summ;
            }
        }
        public int Max
        {
            get {
                return max;
            }
        }
        public int CountOfbig
        {
            get
            {
                return count;
            }
        }
        public double Srznuch
        {
            get
            {
                return srznuch;
            }
        }
        private void calculateSumm()
        {
            summ = 0;
            for (int i = 0; i < myMatrix.GetNumberOfColumns(); i++)
                for (int j = 0; j < myMatrix.GetNumberOfRows(); j++)
                    summ += myMatrix.Read(j, i);
        }
        private void calculateSrznuch()
        {
            srznuch = (double)summ / (myMatrix.GetNumberOfColumns()) / (myMatrix.GetNumberOfRows());
        }
        private void findElements()
        {
            max = myMatrix.Read(0, 0);
            count = 0;
            for(int i = 0; i < myMatrix.GetNumberOfColumns(); i++)
                for (int j = 0; j < myMatrix.GetNumberOfRows(); j++)
                {
                    if (myMatrix.Read(j, i) != 0)
                    {
                        count ++;
                    }
                    if (myMatrix.Read(j, i) > max)
                        max = myMatrix.Read(j, i);
                }
        }
        public MatrixStatistic(Matrix m)
        {
            myMatrix = m;
            calculateSumm();
            calculateSrznuch();
            findElements();
        }
    }
}
