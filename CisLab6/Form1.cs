using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CisLab6
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        SolidBrush brush;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(System.Drawing.Color.Red, 5);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.DrawLine(pen, 10, 10, 100, 100);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
