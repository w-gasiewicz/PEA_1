using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEA_1
{
    class Generate
    {
        private Random rand = new Random();
        public int[,] GeneratingNewCities(int qua,int from,int to)
        {//function generates given number of cities with random distances between them
            int[,] tab;
            tab = new int[qua, qua];

            for(int i=0;i<qua;i++)
            {
                for(int j=0;j<i;j++)
                {
                    tab[i,j]= rand.Next(from, to);
                    tab[j, i] = tab[i, j];
                }
            }
            return tab;
        }
    }
}
