using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace _232test1
{
    public partial class Form1 : Form
    {
        private SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.Two);

        public Form1()
        {
            InitializeComponent();
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            output.Text += port.ReadExisting() + "\n";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            output.Text += "Incoming Data:\n";

            // Attach a method to be called when there
            // is data waiting in the port's buffer
            port.DataReceived += new
              SerialDataReceivedEventHandler(port_DataReceived);

            // Begin communications
            port.Open();


        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            port.Write((0x06000714).ToString());
            // port.Write(Convert.ToInt16(data.Text).ToString());
        }
    }

}

//  https://www.codeproject.com/articles/20929/simple-modbus-protocol-in-c-net