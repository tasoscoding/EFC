using System;
using System.Windows.Forms;
using Modbus_Poll_CS;
using System.IO.Ports;

namespace _232test1
{
    public partial class Form1 : Form
    {
        private modbus link = new modbus();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            link.Open("COM3", 9600, 8, Parity.None, StopBits.Two);
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string[] values = data.Text.Split(' ');
            UInt16 addr = Convert.ToUInt16(values[0]);
            bool ret;
            if (values.Length > 1)
            {
                short[] val = {Convert.ToInt16(values[1])};
                ret = link.SendFc16(1, addr, 1, val);
                if (ret) output.Text += "Successfully wrote ";
                else output.Text += "Failed to write ";
                output.Text += values[1] + " to address " + values[0] + "\n";
            }
            else
            {
                short[] val = new short[1];
                ret = link.SendFc3(1, addr, 1, ref val);
                if (ret) output.Text += "Read from " + values[0] + ": " + val[0].ToString() + "\n";
                else output.Text += "Read from " + values[0] + " failed\n";
            }
            if (!ret) output.Text += "Status: " + link.modbusStatus + "\n";
        }

    }

}
