using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SolovovStroy
{
    public partial class FormMain : Form
    {
        int currentRow = 0;
        string path = @"C:\Users\student\Desktop\Выходной ДЭ\товары\";
        DataTable tovar;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        public void SetData()
        {
            var data = tovar.Rows[currentRow].ItemArray;
            textBox1Articul.Text = data[3].ToString();
            textBox1Name.Text = data[1].ToString();
            textBox1Cost.Text = data[2].ToString();
            pictureBox1.Image = Image.FromFile(path + data[4].ToString());
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if(currentRow + 1 < tovar.Rows.Count)
            {
                currentRow += 1;
                SetData();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (currentRow > 0)
            {
                currentRow--;
                SetData();
            }
        }

        private void button1BW_Click(object sender, EventArgs e)
        {
            BwCreator.DrawBarcode(textBox1Articul.Text, pictureBox: pictureBoxBW);
            using(PrintDialog pd = new PrintDialog())
            {
                if(pd.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }

        public void UpdateData()
        {
            using (DataBase db = new DataBase())
            {
                tovar = db.ExecuteSql("select * from tovar");
            }
            SetData();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBoxBW.Image, 0, 0, 200, 200);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            textBox1Cost.Text = textBox1Cost.Text.Replace(',','.');
            var tvRow = tovar.Rows[currentRow].ItemArray;
            string article = tvRow[3].ToString();
            using (DataBase db = new DataBase())
            {
                db.ExecuteSql($"update tovar set name_t='{textBox1Name.Text}', articul='{textBox1Articul.Text}', prise={textBox1Cost.Text} where articul = '{article}'");
            }
            UpdateData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (DataBase db = new DataBase())
            {
                db.ExecuteSql($"delete from tovar where articul = {textBox1Articul.Text}");
            }
            UpdateData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.OpenNewForm(new FormAddTovar(this), false);
        }
    }
}
