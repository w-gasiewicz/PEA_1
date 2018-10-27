using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PEA_1
{
    public partial class Menu : Form
    {
        Functions run= new Functions();
        public static int cityQua;
        public static int[,] citiesArray;

        private Generate _start = new Generate();
        private bool _testMode = false;
        private List<int> _algorithmResult;
        private Stopwatch stopwatch;

        public Menu()
        {
            InitializeComponent();
            AlgorithmKind_combo.DropDownStyle = ComboBoxStyle.DropDownList; AlgorithmKind_combo.SelectedIndex = 0;
        }

        private void ReadFromFile_btn_Click(object sender, EventArgs e)
        {//clicking readfrom file button starts readfromfile method
            try
            {
                ReadFromFile(run.ChooseFile());
                ShowResult sr = new ShowResult(run.ShowCities());
                sr.ShowDialog();

                graphStatus_lbl.Text = "Wygenerowany";
                graphStatus_lbl.ForeColor = Color.Green;
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                line = Regex.Replace(line,"[ ]{2,}"," ");//here we're deleting multiple spaces from input string
                if (i == 0)//data from first line
                {
                    try
                    {
                        cityQua = Convert.ToInt32(line);

                        citiesArray = new int[cityQua, cityQua];                        
                    }
                    catch(Exception ex) { MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }//catch incorrect city quantity
                }
                else
                {
                    for(int j=0;j<cityQua;j++)
                    {
                       line=line.Trim();
                        space = line.IndexOf(" ");
                        if (j==cityQua-1)
                        { citiesArray[counter, j] = Convert.ToInt32(line); break; }
                        temp = line.Substring(space);
                        temp2 = line.Remove(line.Length - temp.Length, temp.Length);

                        if (run.IsNumeric(temp2) == false)//spawdzamy czy bedziemy dodawac liczbe
                        {
                            MessageBox.Show("Plik niepoprawny!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        line = line.Remove(0, line.Length - temp.Length + 1);
                        citiesArray[counter, j] = Convert.ToInt32(temp2);
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
                citiesArray = _start.GeneratingNewCities(Convert.ToInt32(CityQua_txt.Text), Convert.ToInt32(From_txt.Text), Convert.ToInt32(To_txt.Text));
                if (!_testMode)
                {
                    ShowResult sr = new ShowResult(run.ShowCities());
                    sr.ShowDialog();
                }

                graphStatus_lbl.Text = "Wygenerowany";
                graphStatus_lbl.ForeColor = Color.Green;
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
            _testMode = false;
            testStatus_label.Text = "Nieaktywne";
            testStatus_label.ForeColor = Color.Red;
        }

        private void StartTesting_btn_Click(object sender, EventArgs e)
        {
            _testMode = true;
            testStatus_label.Text = "Aktywne";
            testStatus_label.ForeColor = Color.Green;
        }

        private void CityQua_txt_Leave(object sender, EventArgs e)
        {//method checks that we don't try to generate less than 2 cities
            if(CityQua_txt.Text != "")
            if (Convert.ToInt32(CityQua_txt.Text)<2)
            {
                CityQua_txt.Clear();
                MessageBox.Show("Nie można wygenerować mniej niż 2 miasta!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {//start selcted algorithm and show result o it with ShowResult class
            try
            {
                if (AlgorithmKind_combo.SelectedItem.ToString().Contains("Programowanie dynamiczne"))
                {
                    _algorithmResult = new List<int>(cityQua);
                    DP_algorithm StartHeldKarp = new DP_algorithm();
                    stopwatch = Stopwatch.StartNew();//start measuring time
                    _algorithmResult = StartHeldKarp.Held_Karp();
                    stopwatch.Stop();

                    WorkTime_txt.Text= stopwatch.Elapsed.TotalMilliseconds.ToString();
                    ShowResult sr=new ShowResult(run.ShowAlgorithmResult(_algorithmResult,StartHeldKarp.GetTotalCost()));
                    sr.ShowDialog();
                }
                else if (AlgorithmKind_combo.SelectedItem.ToString().Contains("Przegląd zupełny"))
                {
                    _algorithmResult = new List<int>(cityQua);
                    BruteForce bf = new BruteForce();
                    stopwatch = Stopwatch.StartNew();//start measuring time
                    int cost= bf.BruteForceAlgorithm();
                    _algorithmResult = bf.GetRoute();
                    stopwatch.Stop();

                    WorkTime_txt.Text = stopwatch.Elapsed.TotalMilliseconds.ToString();
                    ShowResult sr = new ShowResult(run.ShowAlgorithmResult(_algorithmResult, cost));
                    sr.ShowDialog();
                }          
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ShowGraph_btn_Click(object sender, EventArgs e)
        {
            if(graphStatus_lbl.Text!="Niewygenerowany")
            {
                ShowResult sr = new ShowResult(run.ShowCities());
                sr.ShowDialog();
            }
            else { MessageBox.Show("Nie wygenerowano grafu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
