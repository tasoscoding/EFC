using RpiWebApi.DTO.Inverter;
using RpiWebApi.Infrastructure;

namespace RpiWebApi.DataAccess.Drivers
{
    public class Mock: DriverBase, IDriver
    {
        double referenceFrequency = 60.0;
        string status = EngineStatus.Stopped;

        public Mock(ConnectionParams connectionParams):
            base(connectionParams)
        {
        }

        #region Initialization / Detection

        public string GetInverterModel()
        {
            return "Mock";
        }

        public bool IsDetected()
        {
            return true;
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
            return "v0.0/healthy";
        }

        #endregion

        #region Read operations

        public double GetReferenceFrequency()
        {
            return referenceFrequency;
        }

        public string GetStatus()
        {
            return status;
        }

        #endregion

        #region Write operations

        public void EmergencyStop()
        {
            status = EngineStatus.Stopped;
        }

        public void Reset()
        {
            status = EngineStatus.Stopped;
        }

        public void Reverse()
        {
            status = EngineStatus.Reverse;
        }

        public void SetReferenceFrequency(double newFrequency)
        {
            referenceFrequency = newFrequency;
        }

        public void Start()
        {
            status = EngineStatus.Running;
        }

        public void Stop()
        {
            status = EngineStatus.Stopped;
        }

        #endregion
    }
}
