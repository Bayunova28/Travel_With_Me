using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string Username = TxtUsername.Text;
            string Password = TxtPassword.Text;

            if (TxtUsername.Text == Username && TxtPassword.Text == Password) 
            {
                MessageBox.Show("Selamat datang di Travel With Me!");
            }
            else if (TxtUsername.Text == "" || TxtPassword.Text == "")
            {
                MessageBox.Show("Username atau Password salah");
            }
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
    }
}
