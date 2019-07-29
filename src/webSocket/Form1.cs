using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace webSocket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var wssv = new WebSocketServer("ws://localhost:9001/");
            wssv.AddWebSocketService<Laputa>("/methodName");
            wssv.Start();
        }

        public class Laputa : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                //to get data from client e.Data
                var msg = e.Data == "BALUS"
                          ? "I've been balused already..."
                          : "I'm not available now.";

                Send(Environment.UserName);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //wssv.Stop();
        }
    }
}
