using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEA_1
{
    class Functions
    {
        public string ChooseFile()
        {
            //choose file with data
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            return ofd.FileName;// save path to file
        }
        public Boolean IsNumeric(string text)
        {
            int number;
            bool isNumber = int.TryParse(text, out number);//check that given value is int value
            return isNumber;
        }
        public string ShowCities()//wyswitlanie grafu w fomie mcierzy
        {
            string show = "Ilość miast= " + Menu.cityQua + Environment.NewLine;
            show += "       ";
            for (int i = 0; i < Menu.cityQua; i++)
                show += "(" + i + ") ";
            show += Environment.NewLine;
            string temp = "";//pomocniczy string do zczytywania kolejnych linii
            for (int i = 0; i < Menu.cityQua; i++)
            {
                temp = "(" + i + ")->";//wierzcholki
                for (int j = 0; j < Menu.cityQua; j++)
                {
                    temp += "[" + Menu.citiesArray[i, j] + "] ";

                }
                show += temp + Environment.NewLine;
            }

            return show;
        }
    }
}
