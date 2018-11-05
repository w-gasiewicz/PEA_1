using System;
using System.Collections.Generic;
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
        public string ShowCities()//show graph as matrix
        {
            string show = "Ilość miast= " + Menu.cityQua + Environment.NewLine;
            show += "       ";
            for (int i = 0; i < Menu.cityQua; i++)
                show += "(" + i + ") ";
            show += Environment.NewLine;
            string temp = "Z";//help string to read next lines
            for (int i = 0; i < Menu.cityQua; i++)
            {
                temp = "(" + i + ")->";//cities
                for (int j = 0; j < Menu.cityQua; j++)
                {
                    temp += "[" + Menu.citiesArray[i, j] + "] ";//here we add to string cost of reach following city

                }
                show += temp + Environment.NewLine;
            }
            show += Environment.NewLine+"Miasta pionowo to miasta z których idziemy. np: z miasta 1 do miasta 2 trasa = "+Menu.citiesArray[1,2].ToString();
            return show;
        }
        public string ShowAlgorithmResult(List<int> resultList, int cost)
        {//this function prepares string with result to show in result winform.
            string result = "";

            for (int i = 0; i < resultList.Count-1; i++)
            {
                result += resultList[i].ToString() + " -> ";
            }
            result += resultList[resultList.Count-1].ToString();
            result +=  Environment.NewLine;
            result += "Najmniejszy koszt odwiedzenia wszystkich miast zgodnie z założeniami problemu komiwojażera to: " + cost + Environment.NewLine;

            return result;
        }
    }
}
