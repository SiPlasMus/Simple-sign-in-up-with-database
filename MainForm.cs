using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSQLApp
{
    public partial class MainForm : Form
    {
        public MainForm(string name)
        {
            InitializeComponent();

            //DB db = new DB();
            //MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `id` = @uID", db.GetConnection());
            //command.Parameters.Add("@uID", MySqlDbType.VarChar).Value = id;

            label1.Text = "Welcome, " + name + '!';

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
    }
}
