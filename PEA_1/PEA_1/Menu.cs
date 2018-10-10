using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEA_1
{
    public partial class Menu : Form
    {
        Functions run= new Functions();
        public static int cityQua;
        private Generate start = new Generate();
        public static int[,] citiesArray;
        private bool testMode = false;
      //  public List<List<int>> cityList;

        public Menu()
        {
            InitializeComponent();
        }

        private void ReadFromFile_btn_Click(object sender, EventArgs e)
        {
            ReadFromFile(run.ChooseFile());
            ShowResult sr = new ShowResult(run.ShowCities());
            sr.ShowDialog();
        }

        private void ReadFromFile(string path)
        {//function reads data from given file
            if (path == "") return;
            StreamReader sr = new StreamReader(path);
            string line,temp,temp2;
            int space;//index of space sign
            int counter = 0;//counts cities
            int i = 0;//loop counter
            while ((line = sr.ReadLine()) != null)//while there is some value in current line
            {
                if (i == 0)//data from first line
                {
                    try
                    {
                        cityQua = Convert.ToInt32(line);

                        citiesArray = new int[cityQua, cityQua];
                        //moze zamiast talicy lepsza bd lista to wtedy to nizej
                       /* cityList = new List<List<int>>(cityQua);
                        for(int k=0;k<cityQua;k++)
                        {
                            cityList.Add(new List<int>());
                        }*/
                    }
                    catch(Exception ex) { MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }//catch incorrect city quantity
                }
                else
                {
                    for(int j=0;j<4;j++)
                    {
                        space = line.IndexOf(" ");
                        temp = line.Substring(space);
                        temp2 = line.Remove(line.Length - temp.Length, temp.Length);

                        if (run.IsNumeric(temp2) == false)//spawdzamy czy bedziemy dodawac liczbe
                        {
                            MessageBox.Show("Plik niepoprawny!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        line = line.Remove(0, line.Length - temp.Length + 1);
                        citiesArray[counter, j] = Convert.ToInt32(temp2);
                        if (j == 3)
                            citiesArray[counter, j+1] = Convert.ToInt32(line);      
                    }
                    counter++;
                }
                i++;
            }
        }

        private void To_txt_Leave(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(From_txt.Text)>=Convert.ToInt32(To_txt.Text))
                {
                    MessageBox.Show("Niepoprawny zakres odległości!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    From_txt.Clear(); To_txt.Clear();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); From_txt.Clear(); To_txt.Clear(); }
        }

        private void Generate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                cityQua = Convert.ToInt32(CityQua_txt.Text);
                citiesArray = new int[Convert.ToInt32(CityQua_txt.Text), Convert.ToInt32(CityQua_txt.Text)];
                citiesArray = start.GeneratingNewCities(Convert.ToInt32(CityQua_txt.Text), Convert.ToInt32(From_txt.Text), Convert.ToInt32(To_txt.Text));
                if (!testMode)
                {
                    ShowResult sr = new ShowResult(run.ShowCities());
                    sr.ShowDialog();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CityQua_txt_KeyPress(object sender, KeyPressEventArgs e)
        {//function allow to write only numbers in this textbox
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void From_txt_KeyPress(object sender, KeyPressEventArgs e)
        {            //function allow to write only numbers in this textbox
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void To_txt_KeyPress(object sender, KeyPressEventArgs e)
        {            //function allow to write only numbers in this textbox
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void EndTestingMode_btn_Click(object sender, EventArgs e)
        {//set testingMode to false
            testMode = false;
            testStatus_label.Text = "Nieaktywne";
            testStatus_label.ForeColor = Color.Red;
        }

        private void StartTesting_btn_Click(object sender, EventArgs e)
        {
            testMode = true;
            testStatus_label.Text = "Aktywne";
            testStatus_label.ForeColor = Color.Green;
        }
    }
}
