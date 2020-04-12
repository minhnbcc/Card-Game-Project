using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Cards
{
    public partial class Menu : Form
    {
        //public static Menu MenuInstance;

        public Menu()
        {
            //MenuInstance = this;
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            //Menu menu = new Menu();

            Menu menu = new Menu();
            this.Visible = false;
            PaiGow pai = new PaiGow()
            {
                TopMost = true
            };
            pai.Show();
            pai.TopMost = false;

            //this.Close();
            //this.Hide();
            //this.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to exit", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Instruction ins = new Instruction();
            ins.Show();
        }
    }
}
