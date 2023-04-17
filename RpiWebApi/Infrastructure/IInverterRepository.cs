using RpiWebApi.DTO.Inverter;

namespace RpiWebApi.Infrastructure
{
    public interface IInverterRepository
    {
        #region Initialization / Detection

        IReadOnlyList<Inverter> GetAll();
        bool IsDetected(Inverter inverter);
        ISet<OperationType> GetSupportedOperations(Inverter inverter);
        string GetVersion(Inverter inverter);

        #endregion

        #region Read Operations

        string GetStatus(Inverter inverter);
        double GetReferenceFrequency(Inverter inverter);

        #endregion

        #region Write operations

        // Write operations
        void Start(Inverter inverter);
        void Stop(Inverter inverter);
        void Reverse(Inverter inverter);
        void Reset(Inverter inverter);
        void EmergencyStop(Inverter inverter);
        void SetReferenceFrequency(Inverter inverter, double newFrequency);

        #endregion
    }
}
