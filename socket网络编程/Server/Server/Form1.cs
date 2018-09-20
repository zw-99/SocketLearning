﻿using System;
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
using System.Threading;
using System.IO;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //当点击开始监听的时候，在服务器端创建一个负责监视IP地址和端口号的Socket
                Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Any;    //IPAddress.Parse(txtServer.Text); 
                //创建端口号对象
                IPEndPoint point = new IPEndPoint(ip,Convert.ToInt32(txtPort.Text));
                //监听
                socketWatch.Bind(point);
                ShowMsg("监听成功");
                socketWatch.Listen(10);
                //新建线程等待用户连接
                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start(socketWatch);
            }
            catch
            { }
        }

        //将远程连接客户端的IP地址和Socket存入集合中
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();


        Socket socketSend;
        /// <summary>
        /// 等待客户端的连接，并且创建一个负责通信的Socket
        /// </summary>
        /// <param name="o"></param>
        void Listen(object o)
        {
            Socket socketWatch = o as Socket;
            while (true)
            {
                try
                {
                    //等待客户端的连接，并且创建一个负责通信的Socket
                    socketSend = socketWatch.Accept();
                    //将远程连接客户端的IP地址和Socket存入集合中
                    dicSocket.Add(socketSend.RemoteEndPoint.ToString(), socketSend);
                    cobUsers.Items.Add(socketSend.RemoteEndPoint.ToString());
                    //例如：192.168.1.3:连接成功
                    ShowMsg(socketSend.RemoteEndPoint.ToString() + ":" + "连接成功");
                    //开启新线程与客户端通信
                    Thread th = new Thread(Recive);
                    th.IsBackground = true;
                    th.Start(socketSend);
                }
                catch
                { }
            }
        }


        /// <summary>
        /// 服务器不停地接受客户端发送的消息
        /// </summary>
        /// <param name="o"></param>
        void Recive (object o)
        {
            Socket socketSend = o as Socket;
            while(true)
            {
                try
                {
                    //客户端连接成功后，服务器接受客户端发送的信息
                    byte[] buffer = new byte[1024 * 1024 * 3];
                    //实际接受到的字节数
                    int r = socketSend.Receive(buffer);
                    //当 r 实际接受到的东西为空时，跳出循环
                    if (r == 0)
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, r);
                    ShowMsg(socketSend.RemoteEndPoint.ToString() + ":" + str);
                }
                catch
                { }
            }
        }

        void ShowMsg(string str)
        {
            txtLog.AppendText(str + "   " + DateTime.Now.ToString() +"\r\n");
        }


        /// <summary>
        /// 服务端给客户端发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                string str = txtMsg.Text;
                byte[] buffer = Encoding.UTF8.GetBytes(str);

                List<byte> list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);
                //将泛型集合转换为数组
                byte[] newBuffer = list.ToArray();
                //获得用户在下拉框中选中的IP地址
                string ip = cobUsers.SelectedItem.ToString();
                dicSocket[ip].Send(newBuffer);
                txtMsg.Text = "";
                txtMsg.Focus();
                //socketSend.Send(buffer);
            }
            catch
            { }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //设置初始目录
            //ofd.InitialDirectory = @"";
            ofd.Title = "全选择要发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();
            txtPath.Text = ofd.FileName;
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            //获得要发送文件的路径
            string path = txtPath.Text;
            using (FileStream fsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = fsRead.Read(buffer, 0, buffer.Length);
                List<byte> list = new List<byte>();
                list.Add(1);
                list.AddRange(buffer);
                //将泛型集合转换为数组
                byte[] newBuffer = list.ToArray();
                //r 为实际读取文件的大小，但没加上标志位的大小
                dicSocket[cobUsers.SelectedItem.ToString()].Send(newBuffer, 0, r+1, SocketFlags.None);
            }
        }

        private void btnZD_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1];
            buffer[0] = 2;
            dicSocket[cobUsers.SelectedItem.ToString()].Send(buffer);
        }
    }
}
