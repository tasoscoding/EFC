namespace RpiWebApi.DTO.Inverter
{
    public class ConnectionParams
    {
        private const string _const_ConnectionTypeConfigurationKey = "Type";
        private const string _const_ModbusPortConfigurationKey = "Port";
        private const string _const_ModbusAddressConfigurationKey = "Address";

        public static ConnectionParams FromConfiguration(IConfiguration configuration)
        {
            string? connectionType = configuration[_const_ConnectionTypeConfigurationKey];
            switch (connectionType?.ToLowerInvariant())
            {
                case "mock":
                    return new MockConnectionParams();
                case "modbus": {
                    string? port = configuration.GetValue<string>(_const_ModbusPortConfigurationKey);
                    byte address = configuration.GetValue<byte>(_const_ModbusAddressConfigurationKey);
                    if (port == null)
                        throw new ArgumentNullException($"Invalid Modbus connection configuration (No port specified).");
                    return new ModbusConnectionParams(port, address);
                }
                default:
                    throw new NotImplementedException($"Unknown connection type: {connectionType}");
            }
        }
    }

    public class MockConnectionParams: ConnectionParams
    {
    }

    public class ModbusConnectionParams: ConnectionParams
    {
        public string Port { get; set; }
        public byte Address { get; set; }

        public ModbusConnectionParams(string port, byte address)
        {
            Port = port;
            Address = address;
        }
    }
}
