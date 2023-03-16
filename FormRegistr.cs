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
    public partial class FormRegistr : Form
    {
        public FormRegistr()
        {
            InitializeComponent();
        }

        private void FormRegistr_Load(object sender, EventArgs e)
        {
            comboBoxPost.Items.Add("Администратор");
            comboBoxPost.Items.Add("Менеджер");
            comboBoxPost.SelectedIndex = 0;
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string post = comboBoxPost.SelectedItem.ToString();
            try
            {
                using (DataBase db = new DataBase())
                {
                    db.ExecuteSqlNonQuery($"insert into users values((select id from roles where name_roles = '{post}'),'{login}','{password}')");
                }
            }

            catch
            {
                MessageBox.Show("Не удалось добавить пользователя");
            }
        }

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            this.OpenNewForm(new FormAuth(), true);
        }
    }
}
