using RpiWebApi.DTO.Inverter;

namespace RpiWebApi.Infrastructure
{
    public interface IDriver
    {
        #region Initialization / Detection

        /// Must be constant expression.
        string GetInverterModel();
        /// Evaluated at runtime.
        bool IsDetected();
        /// Evaluated at runtime.
        ISet<OperationType> GetSupportedOperations();
        string GetInverterVersion();

        #endregion

        #region Read Operations

        string GetStatus();
        double GetReferenceFrequency();

        #endregion

        #region Write operations

        // Write operations
        void Start();
        void Stop();
        void Reverse();
        void Reset();
        void EmergencyStop();
        void SetReferenceFrequency(double newFrequency);

        #endregion
    }
}
