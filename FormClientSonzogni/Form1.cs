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

namespace FormClientSonzogni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint EP = new IPEndPoint(ip,9999);
            int i = 0;
            while(i<3)
            {
                Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    socket.Connect(EP);
                    MessageBox.Show("connessione al server eseguita con successo");
                    byte[] BRecive = new byte[1024];
                    socket.Receive(BRecive);
                    int messaggio = BitConverter.ToInt32(BRecive, 0);
                    label2.Text = messaggio.ToString();
                    //MessageBox.Show(messaggio.ToString());
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    i++;
                }
                catch(Exception errore)
                {
                    MessageBox.Show(errore.Message);
                }
            }
        }
    }
}
