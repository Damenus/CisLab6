﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//http://www.centrumxp.pl/dotNet/761,Mini-Paint-w-C.aspx

namespace CisLab6
{
    public partial class Form1 : Form
    {
        Graphics graphics;        
        bool mouseIsDown = false;        
        Color col = Color.Black;
        Point p = Point.Empty;
        

        public Form1()
        {
            InitializeComponent();
            button3.BackColor = col;            
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
                mouseIsDown = true;
                p = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseIsDown)
            {                          
                var pioro = new Pen(col);
                graphics.DrawLine(pioro, p, e.Location);
                p = e.Location;
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = colorDialog1.Color;
                col = colorDialog1.Color;
            }
        }

    }
}
