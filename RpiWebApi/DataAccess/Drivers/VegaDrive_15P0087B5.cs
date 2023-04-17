using System.IO.Ports;
using Modbus_Poll_CS;
using RpiWebApi.DTO.Inverter;
using RpiWebApi.DTO.Inverter.Exceptions;
using RpiWebApi.Infrastructure;

namespace RpiWebApi.DataAccess.Drivers
{
    public class VegaDrive_15P0087B5: DriverBase, IDriver
    {
        public VegaDrive_15P0087B5(ConnectionParams connectionParams):
            base(connectionParams)
        {
        }

        #region Initialization / Detection

        public string GetInverterModel()
        {
            return "VegaDrive 15P0087B5";
        }

        public bool IsDetected()
        {
            try
            {
                short model = ReadRegister(0x00);
                switch (model) {
                    case 7:
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ISet<OperationType> GetSupportedOperations()
        {
            return new HashSet<OperationType>
            {
                OperationType.Start,
                OperationType.Stop,
                OperationType.Reverse,
                OperationType.EmergencyStop,
                OperationType.ChangeFrequency,
            };
        }

        public string GetInverterVersion() {
            short version = ReadRegister(0x03);
            switch (version) {
                case 1:  // Return values in the manual are bonkers.
                    return "Version 1.0e";
                case 5:
                    return "Version 5.0e";
                default:
                    throw new EngineMessageException(
                        $"The inverter responded with unknown version code {version} in register 0x03");
            }
        }

        #endregion

        #region Read Operations

        public string GetStatus()
        {
            short s = ReadRegister(0x6);
            switch (s)
            {
                case 0:
                    return EngineStatus.Stopped;
                case 1:
                    return EngineStatus.Running;
                case 2:
                    return EngineStatus.Reverse;
                case 4:
                    return EngineStatus.Fault;
                case 8:
                    return EngineStatus.Accelerating;
                case 10:
                    return EngineStatus.Decelerating;
                case 11:
                    return EngineStatus.SpeedReached;
                case 14:
                    return EngineStatus.DcBraking;
                default:
                    throw new EngineMessageException(
                        $"The inverter responded with unknown status code {s} in register 0x6");
            }
        }

        public double GetReferenceFrequency()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Write operations

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

        public void Stop()
        {
            WriteRegister(0x6, 0x1);
        }

        public void SetReferenceFrequency(double newFrequency)
        {
            WriteRegister(0x05, (short)Math.Round(newFrequency));
        }

        #endregion

        #region Private methods

        private short ReadRegister(ushort reg)
        {
            var modbusConnectionParams = (ModbusConnectionParams)connectionParams;
            Modbus link = new Modbus();
            link.Open(modbusConnectionParams.Port, 9600, 8, Parity.None, StopBits.Two);
            short[] val = new short[1];
            bool ret = link.SendFc3(modbusConnectionParams.Address, reg, 1, ref val);
            if (!ret) throw new EngineMessageException(
                $"Read from register 0x{reg:x)} failed: {link.modbusStatus}");
            link.Close();
            return val[0];
        }

        private bool WriteRegister(ushort reg, short value)
        {
            var modbusConnectionParams = (ModbusConnectionParams)connectionParams;
            Modbus link = new Modbus();
            bool ret = link.Open(modbusConnectionParams.Port, 9600, 8, Parity.None, StopBits.Two);
            if (!ret) throw new EngineMessageException (
                $"Opening port {modbusConnectionParams.Port} failed: {link.modbusStatus}");
            short[] val = { value };
            ret = link.SendFc16(modbusConnectionParams.Address, reg, 1, val);
            if (!ret) throw new EngineMessageException(
                $"Writing 0x{value:x)} to register 0x{reg:x)} failed: {link.modbusStatus}");
            link.Close();
            return ret;
        }

        #endregion
    }
}
