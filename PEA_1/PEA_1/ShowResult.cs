using System;
using System.Windows.Forms;

namespace PEA_1
{
    public partial class ShowResult : Form
    {
        public ShowResult(string text)
        {
            InitializeComponent();
            Results_txt.Text = text;
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Close();//close result window
        }
    }
}
