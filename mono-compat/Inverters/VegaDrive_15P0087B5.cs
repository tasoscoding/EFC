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
                WriteRegister(0x6, 0x10);
            }

            public void Reset()
            {
                WriteRegister(0x6, 0x8);
            }

            public void Reverse()
            {
                WriteRegister(0x6, 0x4);
            }

            public void Start()
            {
                WriteRegister(0x6, 0x2);
            }

            public EngineStatus Status()
            {
                short s = ReadRegister(0x6);
                switch (s)
                {
                    case 0x1:
                        return EngineStatus.Stopped;
                    case 0x2:
                        return EngineStatus.Running;
                    case 0x4:
                        return EngineStatus.Reverse;
                    default:
                        throw new EngineMessageException(
                            "The inverter responded with unknown status code " +
                            s.ToString() + " in register 0x6");
                }
            }

            public void Stop()
            {
                WriteRegister(0x6, 0x1);
            }

            public EngineModel GetInverterModel() {
                short model = ReadRegister(0x00);
                switch (model) {
                    case 7:
                        return EngineModel.VegaDrive;
                    default:
                        throw new EngineMessageException("The inverter responded with unknown model code " + model.ToString() + "in register 0x0");
                }
            }

            public EngineVersion GetInverterVersion() {
                short version = ReadRegister(0x03);
                switch (version) {
                    case 1:  // Return values in the manual are bonkers.
                        return EngineVersion.Version_1_0_E;
                    case 5:
                        return EngineVersion.Version_5_0_E;
                    default:
                        throw new EngineMessageException("The inverter responded with unknown version code " + version.ToString() + " in register 0x03");
                }
            }

            public void SetReferneceFrequenct(int newFrequency) {
                WriteRegister(0x05, (short)newFrequency);
            }
        }
    }
}