using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolovovStroy
{
    public class BwCreator
    {
        public static void DrawBarcode(string code, PictureBox pictureBox, int resolution = 20)
        {
            int numberCount = 25;
            float height = 25.93f * resolution;
            float lineHeight = 22.85f * resolution;
            float leftOffset = 3.63f * resolution;
            float rightOffset = 2.31f * resolution;

            float longLineHeight = lineHeight + 1.65f * resolution;
            float fontHeight = 2.75f * resolution;
            float lineToFontOffset = 0.165f * resolution;
            float lineWidthDelta = 0.15f * resolution;
            float lineWidthFull = 1.35f * resolution;
            float lineOffset = 0.2f * resolution;

            float width = leftOffset + rightOffset + 6 * (lineWidthDelta + lineOffset) + numberCount * (lineWidthFull + lineOffset);

            Bitmap bitmap = new Bitmap((int)width, (int)height);
            Graphics g = Graphics.FromImage(bitmap);

            Font font = new Font("Arial", fontHeight, FontStyle.Regular, GraphicsUnit.Pixel);

            StringFormat fontFormat = new StringFormat();
            fontFormat.Alignment = StringAlignment.Center;
            fontFormat.LineAlignment = StringAlignment.Center;

            float x = leftOffset;
            for (int i = 0; i < numberCount; i++)
            {
                int number = Convert.ToInt32(code[i].ToString());
                if (number != 0)
                {
                    g.FillRectangle(Brushes.Black, x, 0, number * lineWidthDelta, lineHeight);
                }
                RectangleF fontRect = new RectangleF(x, lineHeight + lineToFontOffset, lineWidthFull, fontHeight);
                g.DrawString(code[i].ToString(), font, Brushes.Black, fontRect, fontFormat);
                x += lineWidthFull + lineOffset;

                if (i == 0 || i == numberCount / 2 || i == numberCount - 1)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        g.FillRectangle(Brushes.Black, x, 0, lineWidthDelta, longLineHeight);
                        x += lineWidthDelta + lineOffset;
                    }
                }
            }

            pictureBox.Image = bitmap;
        }
            
    }
}

