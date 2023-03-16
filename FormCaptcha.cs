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
    public partial class FormCaptcha : Form
    {
        FormAuth auth;
        string result = "";
        string str = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";

        public FormCaptcha(FormAuth form)
        {
            auth = form;
            InitializeComponent();
        }

        private void SetStringCaptcha()
        {
            result = "";
            char[] chars = str.ToCharArray();
            Random random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                result += chars[random.Next(0, chars.Length)];
            }
        }

        private void SetCaptcha()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);

            SetStringCaptcha();

            using (Font myFont = new Font("Microsoft Sans Serif", 20, FontStyle.Bold))
            {
                Point[] points2 =
                {
                    new Point(0, 20),
                    new Point(20, 10),
                    new Point(40, 20),
                    new Point(60, 10),
                    new Point(80, 20),
                    new Point(100, 10),
                };

                Point[] points1 =
                {
                    new Point(0, 30),
                    new Point(20, 20),
                    new Point(40, 30),
                    new Point(60, 20),
                    new Point(80, 30),
                    new Point(100, 20),
                };

                Point[] points3 =
                {
                    new Point(0, 40),
                    new Point(20, 30),
                    new Point(40, 40),
                    new Point(60, 30),
                    new Point(80, 40),
                    new Point(100, 30),
                };

                g.Clear(Color.Black);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.DrawString(result, myFont, Brushes.Green, new Point(0, pictureBox1.Height / 4));
                //g.DrawCurve(new Pen(Color.Red, (float)1.5), points1);
                //g.DrawCurve(new Pen(Color.Red, (float)1.5), points2);
                //g.DrawCurve(new Pen(Color.Red, (float)1.5), points3);
                g.DrawLine(new Pen(Color.Red, (float)1.5), new Point(0, 15), new Point(300, 15));
                g.DrawLine(new Pen(Color.Red, (float)1.5), new Point(0, 30), new Point(300, 30));
                g.DrawLine(new Pen(Color.Red, (float)1.5), new Point(0, 45), new Point(300, 45));

                pictureBox1.Image = bitmap;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != result)
            {
                MessageBox.Show("Попробуйте еще раз ввести капчу");
                SetCaptcha();
                return;
            }
            else
            {
                auth.Enabled = true;
                auth.count = 0;
                this.Close();
            }
        }

        private void FormCaptcha_Load(object sender, EventArgs e)
        {
            SetCaptcha();
        }
    }
}
