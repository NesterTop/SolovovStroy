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
    public partial class FormAddTovar : Form
    {
        FormMain main;
        public FormAddTovar(FormMain form)
        {
            main = form;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string prise = textBox2.Text;
            string article = textBox3.Text;
            string photo = textBox4.Text;
            string quantity = textBox5.Text;

            using(DataBase db = new DataBase())
            {
                try
                {
                    db.ExecuteSqlNonQuery($"insert into tovar values('{name}',{prise},'{article}','{photo}',{quantity})");
                    main.UpdateData();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить запись");
                }
            }
        }
        public bool CheckLength(string str)
        {
            if (str.Length == 25)
            {
                return true;
            }
            else return false;
        }

        private void FormAddTovar_Load(object sender, EventArgs e)
        {

        }
    }
}
