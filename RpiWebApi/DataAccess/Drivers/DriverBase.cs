using RpiWebApi.DTO.Inverter;

namespace RpiWebApi.DataAccess.Drivers
{
    public class DriverBase
    {
        public ConnectionParams connectionParams { get; set; }

        public DriverBase(ConnectionParams connectionParams)
        {
            this.connectionParams = connectionParams;
        }
    }
}