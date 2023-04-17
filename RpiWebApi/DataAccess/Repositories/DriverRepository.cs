using RpiWebApi.DTO.Inverter;
using RpiWebApi.Infrastructure;

namespace RpiWebApi.DataAccess
{
    public class DriverRepository: IDriverRepository
    {
        public IDriver Connect(string modelId, ConnectionParams connectionParams)
        {
            switch (modelId.ToLowerInvariant())
            {
                case "vegadrive 15p0087b5":
                    return new Drivers.VegaDrive_15P0087B5(connectionParams);
                case "mock":
                    return new Drivers.Mock(connectionParams);
                default:
                    throw new Exception($"Inverter model {modelId} is not yet supported by the system");
            }
        }
    }
}
