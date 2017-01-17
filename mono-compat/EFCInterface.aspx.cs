using System;
using System.Web.UI;
using Modbus_Poll_CS;
using System.IO.Ports;

public partial class EFCInterface: Page
{
    protected void send_click(object sender, EventArgs e)
    {
        modbus link = new modbus();
        string port = "COM3";
        link.Open(port, 9600, 8, Parity.None, StopBits.Two);
        string input = inputbox.Text;
        string[] values = input.Split(' ');
        ushort addr = Convert.ToUInt16(values[0]);
        bool ret;
        if (values.Length > 1)
        {
            short[] val = { Convert.ToInt16(values[1]) };
            ret = link.SendFc16(1, addr, 1, val);
            if (ret) write("Successfully wrote ");
            else write("Failed to write ");
            writeLine(values[1] + " to address " + values[0]);
        }
        else
        {
            short[] val = new short[1];
            ret = link.SendFc3(1, addr, 1, ref val);
            if (ret) writeLine("Read from " + values[0] + ": " + val[0].ToString());
            else writeLine("Read from " + values[0] + " failed");
        }
        if (!ret) writeLine("Status: " + link.modbusStatus);
        link.Close();
    }

    void write(string s)
    {
        outputbox.Text += s;
    }

    void writeLine(string s)
    {
        outputbox.Text += s + "\n";
    }
}
