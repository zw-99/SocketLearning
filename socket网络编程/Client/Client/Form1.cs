using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Socket socketSend;
        private void btnStart_Click(object sender, EventArgs e)
        {
            //创建啊一个负责通信的Socket
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(txtServer.Text);
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
            //获得要连接的远程服务器应用程序的IP地址和端口号
            try
            {
                socketSend.Connect(point);
                ShowMsg("与服务器连接成功");
            }
            catch
            {
                ShowMsg("远程服务器拒绝连接");
                MessageBox.Show("远程服务器拒绝连接,请检查服务器是否开启");
            }
            //开启一个新线程不停地接收服务器发来的信息
            Thread th = new Thread(Recive);
            th.IsBackground = true;
            th.Start();
        }

        void ShowMsg(string str)
        {
            txtLog.AppendText(str + "    " + DateTime.Now.ToString() + "\r\n");
        }

        
        /// <summary>
        /// 客户端给服务器发送信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string str = txtMsg.Text.Trim();
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                socketSend.Send(buffer);
                txtMsg.Text = "";
                txtMsg.Focus();
            }
            catch
            {
                MessageBox.Show("信息发送失败,请检查与服务器是否连接成功");
            }
        }


        /// <summary>
        /// 不停地接收服务器发来的信息
        /// </summary>
        void Recive()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    //实际接收到的有效字节数
                    int r = socketSend.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    //表示发送的文字信息                 
                    if (buffer[0] == 0)
                    {
                        
                        string str = Encoding.UTF8.GetString(buffer, 1, r-1);
                        ShowMsg(socketSend.RemoteEndPoint + ":" + str);
                    }
                    //表示发送的文件
                    else if(buffer[0] == 1)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        ////默认保存路径
                        //ofd.InitialDirectory = @"";
                        sfd.Title = "请选择文件要保存的位置";
                        sfd.Filter = "所有文件|*.*";
                        sfd.ShowDialog(this);
                        string path = sfd.FileName;
                        using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            fsWrite.Write(buffer, 1, r - 1);
                        }
                        MessageBox.Show("保存成功");
                    }
                    //表示发送震动
                    else if(buffer[0] == 2)
                    {
                        zhendong();
                    }
                }
            }
            catch
            { }
        }

        void zhendong()
        {
            for(int i=0;i<500;i++)
            {
                this.Location = new Point(200, 200);
                this.Location = new Point(300, 300);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
