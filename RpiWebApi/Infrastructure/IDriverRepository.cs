using RpiWebApi.DTO.Inverter;

namespace RpiWebApi.Infrastructure
{
    public interface IDriverRepository
    {
        IDriver Connect(string modelId, ConnectionParams connectionParams);
    }
}
