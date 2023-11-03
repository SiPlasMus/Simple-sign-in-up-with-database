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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 50);

            usernameField.Text = "Enter your name";
            usersurnameField.Text = "Enter your surname";
            usernameField.ForeColor = Color.Gray;
            usersurnameField.ForeColor = Color.Gray;

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void usernameField_Enter(object sender, EventArgs e)
        {
            if(usernameField.Text == "Enter your name")
            {
                usernameField.Text = "";
                usernameField.ForeColor = Color.Black;
            }
        }

        private void usernameField_Leave(object sender, EventArgs e)
        {
            if (usernameField.Text == "") 
            {
                usernameField.Text = "Enter your name";
                usernameField.ForeColor = Color.Gray;
            }
        }

        private void usersurnameField_Enter(object sender, EventArgs e)
        {
            if (usersurnameField.Text == "Enter your surname")
            {
                usersurnameField.Text = "";
                usersurnameField.ForeColor = Color.Black;
            }
        }

        private void usersurnameField_Leave(object sender, EventArgs e)
        {
            if (usersurnameField.Text == "")
            {
                usersurnameField.Text = "Enter your surname";
                usersurnameField.ForeColor = Color.Gray;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (usernameField.Text == "Enter your name")
            {
                MessageBox.Show("Enter the name!");
                return;
            }
            if (usersurnameField.Text == "Enter your surname")
            {
                MessageBox.Show("Enter the surname!");
                return;
            }
            if (loginField.Text == "")
            {
                MessageBox.Show("Enter the login!");
                return;
            }
            if (passField.Text == "")
            {
                MessageBox.Show("Enter the password!");
                return;
            }
            if (isLoginExists())
            {
                //MessageBox.Show("Login already exists");
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `name`, `surname`) VALUES (@login, @password, @name, @surname)", db.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = usernameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = usersurnameField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Success");
            else
                MessageBox.Show("Failure");

            db.closeConnection();   
        }

        public Boolean isLoginExists()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login already exists");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm log = new LoginForm();
            log.Show();
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
