using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSLFightReplayer
{
    public partial class IncorrectNumberOfFightsPopup : Form
    {
        public IncorrectNumberOfFightsPopup(string message)
        {
            InitializeComponent();
            MessageLabel.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void IncorrectNumberOfFightsPopup_Load(object sender, EventArgs e)
        {
            Text = "Error";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}