using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._0
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Graphics g;
        Brush brush;
        int w = 251;
        int h = 251;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            g = Graphics.FromImage(image);
            brush = new SolidBrush(Color.FromArgb(50, 50, 50));
            timer1.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            image.Dispose();
            g.Dispose();
            brush.Dispose();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

                int x = Control.MousePosition.X - this.w / 2;
                int y = Control.MousePosition.Y - this.h / 2;
                g.FillRectangle(brush, new Rectangle(0, 0, this.w, this.h));
                g.CopyFromScreen(x, y, 0, 0, new Size(this.w, this.h));
                Color color = this.image.GetPixel(125, 125);

                using (Pen pen = new Pen(Color.Red))
                {
                    g.DrawRectangle(pen, this.w / 2, this.h / 2, 2, 2);
                }
                textBox1.Text = color.ToString();
                pictureBox1.Image = image;
        }
    }
}
