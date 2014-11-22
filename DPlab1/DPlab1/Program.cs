using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPlab1
{
    class Program
    {
        static void Main(string[] args)
        {
            OriginMatrix matr = new OriginMatrix(4, 4);
            SparceMatrix smatr = new SparceMatrix(4, 4);
            InitMatrix.Init(matr, 10, 8);
            MatrixStatistic s1 = new MatrixStatistic(matr);
            Console.Write("{0} \ncount of big = {1} \nMax  = {2} \nSrednee = {3} \nSumm = {4}\n",
                            matr.ToString(), s1.CountOfbig, s1.Max, s1.Srznuch, s1.Summ);
            InitMatrix.Init(smatr, 4, 7);
            MatrixStatistic s2 = new MatrixStatistic(smatr);
            Console.Write("{0} \ncount of big = {1} \nMax  = {2} \nSrednee = {3} \nSumm = {4}\n", 
                            smatr.ToString(), s2.CountOfbig, s2.Max, s2.Srznuch, s2.Summ);
            
            
        }
    }
}
