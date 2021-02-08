using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ServicesT3EJ1
{
    public partial class Form1 : Form
    {
        private int port = 2609;
        private IPAddress ip = IPAddress.Parse("127.0.0.1");
        public Form1()
        {
            InitializeComponent();
            this.btnHora.Tag = "hora";
            this.btnFecha.Tag = "fecha";
            this.btnTodo.Tag = "todo";
            this.btnApagar.Tag = "apagar";
        }

        private void Connect(Object sender,EventArgs e)
        {
            Form2 ipDialog = new Form2();
            DialogResult result = ipDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    this.ip = IPAddress.Parse(ipDialog.txtIp.Text);
                    this.port = int.Parse(ipDialog.txtPort.Text);
                    this.lblError.Text = "";
                }
                catch (Exception ex) when (ex is FormatException || ex is OverflowException || ex is ArgumentNullException || ex is IOException)
                {
                    this.lblError.Text = "Invalid ip or port";
                }
            }
        }

        private void send(Object sender, EventArgs e)
        {
            if (this.ip != null)
            {
                if (this.txtCommand.Text.Length > 0)
                {
                    SendCommand("");
                }
            }
        }

        private void SendCommand(String command)
        {
            try
            {
                this.lblError.Text = "";
                this.lblServer.Text = "";
                string msg = "";
                IPEndPoint iPEndPoint = new IPEndPoint(ip, port);
                Socket clientScoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientScoket.Connect(iPEndPoint);
                using (NetworkStream ns = new NetworkStream(clientScoket))
                using (StreamReader reader = new StreamReader(ns))
                using (StreamWriter writer = new StreamWriter(ns))
                {
                    //msg = reader.ReadLine();
                    //this.lblServer.Text += msg + Environment.NewLine;
                    if (command.Length <= 0)
                    {
                        string cmmd = this.txtCommand.Text;
                    }
                    writer.WriteLine(command);
                    writer.Flush();
                    msg = reader.ReadLine();
                    this.lblServer.Text += msg + Environment.NewLine;
                    this.txtCommand.Text = "";
                }
                clientScoket.Close();
            }
            catch (Exception ex) when (ex is IOException || ex is SocketException ||ex is ArgumentOutOfRangeException ||ex is ArgumentNullException ||ex is ArgumentException ||ex is OutOfMemoryException ||ex is ObjectDisposedException)
            {
                this.lblError.Text = "Error while trying to comunicate with the server!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void BtnHora_Click(object sender, EventArgs e)
        {
            SendCommand(((Button)sender).Tag.ToString());
        }
    }
}
