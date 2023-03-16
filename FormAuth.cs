using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolovovStroy
{
    public partial class FormAuth : Form
    {
        public int count = 0;
        DataTable users;

        public FormAuth()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            CheckCount();

            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            using (DataBase db = new DataBase())
            {
                users = db.ExecuteSql($"select * from users where login_user = '{login}' and pass = '{password}'");

                var data = users.Rows[0].ItemArray;
                if (users.Rows.Count > 0)
                {
                    if (data[1].ToString() == "Администратор")
                    {
                        this.OpenNewForm(new FormMain(), true);
                    }

                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
        }

        public void CheckCount()
        {
            if (count >= 2)
            {
                this.Enabled = false;
                new FormCaptcha(this).Show();
            }
            count++;
        }

        private void buttonRegistr_Click(object sender, EventArgs e)
        {
            this.OpenNewForm(new FormRegistr(), true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Enabled = true;
            count = 0;
        }
    }
}
