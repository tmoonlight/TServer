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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                label1.Location = new Point(startpoint.X - 50, label1.Location.Y);
            }
            else
            if (e.KeyCode == Keys.Right)
            {
                label1.Location = new Point(startpoint.X + 50, label1.Location.Y);
            }
            else
            if (e.KeyCode == Keys.Up)
            {
                label1.Location = new Point(label1.Location.X, startpoint.Y - 50);
            }
            else
            if (e.KeyCode == Keys.Down)
            {
                label1.Location = new Point(label1.Location.X, startpoint.Y + 50);
            }
            UploadPos();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            resetPoint();
            UploadPos();
        }

        public Point startpoint;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.startpoint = new Point(label1.Left, label1.Top);
        }

        void resetPoint()
        {
            //label1.Left = startpoint.X;
            //label1.Top = startpoint.Y;
            label1.Location = startpoint;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //将操作上传至服务器
        public void sendByteAndReveive(string str)
        {
            Socket sendfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sendfd.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"),1234));
            sendfd.Send(System.Text.Encoding.Default.GetBytes("serv echo " + str));

        }
        //持续获取服务器数据，
        public void reveiveByte()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UploadPos();
        }

        private void UploadPos()
        {
            sendByteAndReveive(string.Format("{0}:{1}", label1.Location.X.ToString(),
                            label1.Location.Y.ToString()));
        }
    }
}
