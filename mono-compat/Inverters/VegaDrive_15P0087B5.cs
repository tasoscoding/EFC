using System;
using Modbus_Poll_CS;
using System.IO.Ports;

namespace EFC
{
    namespace Engines
    {
        public class VegaDrive_15P0087B5 : IEngine
        {
            private String port;
            private byte address;

            public short ReadRegister(ushort reg)
            {
                modbus link = new modbus();
                link.Open(port, 9600, 8, Parity.None, StopBits.Two);
                short[] val = new short[1];
                bool ret = link.SendFc3(address, reg, 1, ref val);
                if (!ret) throw new EngineMessageException(
                    "Read from register 0x" + reg.ToString("x") + " failed: " + link.modbusStatus);
                link.Close();
                return val[0];
            }

            public void WriteRegister(ushort reg, short value)
            {
                modbus link = new modbus();
                link.Open(port, 9600, 8, Parity.None, StopBits.Two);
                short[] val = { value };
                bool ret = link.SendFc3(address, reg, 1, ref val);
                if (!ret) throw new EngineMessageException(
                    "Writing 0x" + value.ToString("x") + 
                    " to register 0x" + reg.ToString("x") + " failed: " + link.modbusStatus);
                link.Close();
            }

            public VegaDrive_15P0087B5(String port, byte address)
            {
                this.port = port;
                this.address = address;
            }

            public void EmergencyStop()
            {
                WriteRegister(0x6, 0b10000);
            }

            public void Reset()
            {
                WriteRegister(0x6, 0b01000);
            }

            public void Reverse()
            {
                WriteRegister(0x6, 0b00100);
            }

            public void Start()
            {
                WriteRegister(0x6, 0b00010);
            }

            public EngineStatus Status()
            {
                short s = ReadRegister(0x6);
                switch (s)
                {
                    case 0b00001:
                        return EngineStatus.Stopped;
                    case 0b00010:
                        return EngineStatus.Running;
                    case 0b00100:
                        return EngineStatus.Reverse;
                    default:
                        throw new EngineMessageException(
                            "The inverter responded with unknown status code " +
                            s.ToString() + " in register 0x6");
                }
            }

            public void Stop()
            {
                WriteRegister(0x6, 0b00001);
            }
        }
    }
}