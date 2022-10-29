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

namespace FormServerSonzogni
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
            Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(ip, 9999);
            try
            {
                socket.Bind(endpoint);
                MessageBox.Show("server avviato con successo");
                socket.Listen(10);
                int i = 0;
                while (i < 3)
                {
                    Socket num = socket.Accept();
                    MessageBox.Show("client connesso con sucesso");
                    int NumCas = 0;
                    Random rn = new Random();
                    NumCas = rn.Next(1, 1000);
                    listView1.Items.Add(num.LocalEndPoint.ToString() + " " + NumCas.ToString());
                    byte[] BNumCas = BitConverter.GetBytes(NumCas);
                    num.Send(BNumCas);
                    num.Shutdown(SocketShutdown.Both);
                    num.Close();
                    i++;
                }
            }

            catch(Exception errore)
            {
                MessageBox.Show(errore.Message);
            }
        }
    }
}
