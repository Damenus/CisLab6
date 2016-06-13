using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//http://technotif.com/creating-simple-udp-server-client-transfer-data-using-c-vb-net/
//http://www.centrumxp.pl/dotNet/761,Mini-Paint-w-C.aspx

namespace CisLab6
{
    public partial class Form1 : Form
    {
        Graphics graphics;        
        bool mouseIsDown = false;
        bool connect = false;
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

                if(connect)
                {
                    //Byte[] sendBytes = Encoding.Convert(e.X);
                }
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

        UdpClient udpClient;

        private void clien()
        {
            int port = Int32.Parse(textBox2.Text);
            var host = textBox1.Text;
            udpClient = new UdpClient();
            try
            {

                udpClient.Connect(host, port);
                connect = true;

                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");

                udpClient.Send(sendBytes, sendBytes.Length);

                

                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);

                // Uses the IPEndPoint object to determine which of these two hosts responded.
                Console.WriteLine("This is the message you received " +
                                             returnData.ToString());
                Console.WriteLine("This message was sent from " +
                                            RemoteIpEndPoint.Address.ToString() +
                                            " on their port number " +
                                            RemoteIpEndPoint.Port.ToString());

               // udpClient.Close();
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                connect = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //udpClient = new UdpClient();
            //udpClient.Connect(textBox1.Text, 8080);
            //Byte[] senddata = Encoding.ASCII.GetBytes("Hello World");
           // udpClient.Send(senddata, senddata.Length);
            Task mainTask = Task.Run(
               () =>
               {
                   clien();
               });
            textBox3.Text = "Connect";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            udpClient.Close();
            connect = false;
            textBox3.Text = "Disconnect";
        }

    }
}
