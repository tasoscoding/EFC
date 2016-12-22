using System;
using Modbus_Poll_CS;
using System.IO.Ports;

namespace mono_compat
{
    class Program
    {
        static void Main(string[] args)
        {
            modbus link = new modbus();
            string port = (args.Length > 0) ? args[0] : "COM3";
            link.Open(port, 9600, 8, Parity.None, StopBits.Two);
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exit") break;
                string[] values = input.Split(' ');
                ushort addr = Convert.ToUInt16(values[0]);
                bool ret;
                if (values.Length > 1)
                {
                    short[] val = { Convert.ToInt16(values[1]) };
                    ret = link.SendFc16(1, addr, 1, val);
                    if (ret) Console.Write("Successfully wrote ");
                    else Console.Write("Failed to write ");
                    Console.WriteLine(values[1] + " to address " + values[0]);
                }
                else
                {
                    short[] val = new short[1];
                    ret = link.SendFc3(1, addr, 1, ref val);
                    if (ret) Console.WriteLine("Read from " + values[0] + ": " + val[0].ToString());
                    else Console.WriteLine("Read from " + values[0] + " failed");
                }
                if (!ret) Console.WriteLine("Status: " + link.modbusStatus);
            }
            link.Close();
        }
    }
}
