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
        public static int cityQua;//number of cities
        public static int[,] citiesArray;//matrix for graph

        private Generate _startGenerate = new Generate();//variable to start generating new instantion
        private bool _testMode = false;//variable to make us know that testmode is activated
        private List<int> _algorithmResult;//list for path with algorithms result
        private Stopwatch _stopwatch;//variable to measuring time

        public Menu()
        {
            InitializeComponent();
            AlgorithmKind_combo.DropDownStyle = ComboBoxStyle.DropDownList; AlgorithmKind_combo.SelectedIndex = 0;
            TestingProgressBar.Maximum = 100;
            TestingProgressBar.Visible = false; Tests_lbl.Visible = false;
        }

        private void ReadFromFile_btn_Click(object sender, EventArgs e)
        {//clicking read from file button starts readfromfile method
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
                       line=line.Trim();//delete all leading and trailing white-space characters from actuall line
                        space = line.IndexOf(" ");
                        if (j==cityQua-1)
                        { citiesArray[counter, j] = Convert.ToInt32(line); break; }
                        temp = line.Substring(space);
                        temp2 = line.Remove(line.Length - temp.Length, temp.Length);

                        if (run.IsNumeric(temp2) == false)//checking that we're going to add number to the matrix
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
        {//here we check that given upper limit of distances is correct
            try
            {
                if(Convert.ToInt32(From_txt.Text)>=Convert.ToInt32(To_txt.Text))
                {
                    MessageBox.Show("Niepoprawny zakres odległości!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    From_txt.Clear(); To_txt.Clear();//clear distances textboxes
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); From_txt.Clear(); To_txt.Clear(); }
        }

        private void Generate_btn_Click(object sender, EventArgs e)
        {//here we generate graph
            try
            {
                cityQua = Convert.ToInt32(CityQua_txt.Text);
                citiesArray = new int[Convert.ToInt32(CityQua_txt.Text), Convert.ToInt32(CityQua_txt.Text)];
                citiesArray = _startGenerate.GeneratingNewCities(cityQua, Convert.ToInt32(From_txt.Text), Convert.ToInt32(To_txt.Text));//we call generate graph function with numbers of cities and range of distances
                if (!_testMode)
                {//in test mode we dont need to show result every time algorithm run
                    ShowResult sr = new ShowResult(run.ShowCities());
                    sr.ShowDialog();
                }

                graphStatus_lbl.Text = "Wygenerowany";
                graphStatus_lbl.ForeColor = Color.Green;
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CityQua_txt_KeyPress(object sender, KeyPressEventArgs e)
        {//function allow to write only numbers in this textbox(number of cities)
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void From_txt_KeyPress(object sender, KeyPressEventArgs e)
        {            //function allow to write only numbers in this textbox(min distances range)
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void To_txt_KeyPress(object sender, KeyPressEventArgs e)
        {            //function allow to write only numbers in this textbox(max distance range)
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
            TestingProgressBar.Visible = false; Tests_lbl.Visible = false;
        }

        private void StartTesting_btn_Click(object sender, EventArgs e)
        {//functions start testing
            TestingProgressBar.Value = 0;
            TestingProgressBar.Step = 1;
            testStatus_label.Text = "Aktywne";
            testStatus_label.ForeColor = Color.Green;
            TestingProgressBar.Visible = true; Tests_lbl.Visible = true;
            _testMode = true;

            double testingTime = 0;
            
            //in this loop for given cities number and distances range we run the chosen algorithm 100 times.
            //Each time for a new random set
            for (int i=0;i<100;i++)
            {
                Generate_btn.PerformClick();
                _stopwatch = Stopwatch.StartNew();
                Start_btn.PerformClick();
                _stopwatch.Stop();
                testingTime += Convert.ToDouble(_stopwatch.ElapsedMilliseconds);
                TestingProgressBar.PerformStep();
            }
            WorkTime_txt.Text = (testingTime / 100).ToString();
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
        {//start selcted algorithm and show result of it with ShowResult class
            try
            {
                if (AlgorithmKind_combo.SelectedItem.ToString().Contains("Przegląd zupełny"))
                {//here we're doing brute force algorithm
                    _algorithmResult = new List<int>(cityQua);
                    BruteForce bf = new BruteForce();
                    int cost = 0;

                    if (!_testMode)
                    {
                        _stopwatch = Stopwatch.StartNew();//start measuring time
                        cost= bf.BruteForceAlgorithm();
                        _stopwatch.Stop();//stop measuring time
                        _algorithmResult = bf.GetRoute();
                    
                        WorkTime_txt.Text = _stopwatch.Elapsed.TotalMilliseconds.ToString();
                        ShowResult sr = new ShowResult(run.ShowAlgorithmResult(_algorithmResult, cost));
                        sr.ShowDialog();
                    }
                    else
                        bf.BruteForceAlgorithm();
                }
                else if (AlgorithmKind_combo.SelectedItem.ToString().Contains("Branch"))
                {//here we're doing branch & bound algorithm
                    _algorithmResult = new List<int>(cityQua);
                    BranchAndBound bb = new BranchAndBound();
                    if (!_testMode)
                    {
                        _stopwatch = Stopwatch.StartNew();//start measuring time
                    _algorithmResult = bb.Start();
                        _stopwatch.Stop();//stop measuring time

                    WorkTime_txt.Text = _stopwatch.Elapsed.TotalMilliseconds.ToString();
                        ShowResult sr = new ShowResult(run.ShowAlgorithmResult(_algorithmResult, bb.GetCost()));
                        sr.ShowDialog();
                    }
                    else
                        bb.Start();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ShowGraph_btn_Click(object sender, EventArgs e)
        {
            if(graphStatus_lbl.Text!="Niewygenerowany")
            {//if graph was generated or loaded from file we can show it
                ShowResult sr = new ShowResult(run.ShowCities());
                sr.ShowDialog();
            }
            else { MessageBox.Show("Nie wygenerowano grafu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
