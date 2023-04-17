using RpiWebApi.DTO.Inverter;
using RpiWebApi.Infrastructure;

namespace RpiWebApi.DataAccess
{
    public class InverterRepository : IInverterRepository
    {
        private const string _const_ConfigurationInvertersKey = "Inverters";
        private const string _const_ConfigurationInverterModelKey = "Model";
        private const string _const_ConfigurationConnectionParamsKey = "Connection";
        private const string const_ConfigurationErrorModelId = "Configuration error";

        public InverterRepository(
            IConfiguration configuration,
            IDriverRepository driverRepository)
        {
            Configuration = configuration;
            DriverRepository = driverRepository;
        }

        public IConfiguration Configuration { get; }
        public IDriverRepository DriverRepository { get; }

        public IReadOnlyList<Inverter> GetAll()
        {
            return Configuration.GetSection(_const_ConfigurationInvertersKey)
                .GetChildren()
                .Select(cs => new Inverter(
                    cs.GetValue<string>(_const_ConfigurationInverterModelKey) ?? const_ConfigurationErrorModelId,
                    ConnectionParams.FromConfiguration(cs.GetSection(_const_ConfigurationConnectionParamsKey))))
                .ToList();
        }

        public ISet<OperationType> GetSupportedOperations(Inverter inverter)
        {
            return DriverRepository.Connect(inverter.Model, inverter.connectionParams)
                .GetSupportedOperations();
        }

        public string GetVersion(Inverter inverter)
        {
            return DriverRepository.Connect(inverter.Model, inverter.connectionParams)
                .GetInverterVersion();
        }

        public bool IsDetected(Inverter inverter)
        {
            return DriverRepository.Connect(inverter.Model, inverter.connectionParams)
                .IsDetected();
        }

        #region Read operations

        public double GetReferenceFrequency(Inverter inverter)
        {
            return DriverRepository.Connect(inverter.Model, inverter.connectionParams)
                .GetReferenceFrequency();
        }

        public string GetStatus(Inverter inverter)
        {
            var driverContext = DriverRepository.Connect(inverter.Model, inverter.connectionParams);
            
            if (!driverContext.IsDetected())
            {
                return EngineStatus.Disconnected;
            }

            return driverContext.GetStatus();
        }

        #endregion

        #region Write operations

        public void EmergencyStop(Inverter inverter)
        {
            DriverRepository.Connect(inverter.Model, inverter.connectionParams)
                .EmergencyStop();
        }

        public void Reset(Inverter inverter)
        {
            DriverRepository.Connect(inverter.Model, inverter.connectionParams)
                .Reset();
        }

        public void Reverse(Inverter inverter)
        {
            DriverRepository.Connect(inverter.Model, inverter.connectionParams)
                .Reverse();
        }

        public void SetReferenceFrequency(Inverter inverter, double newFrequency)
        {
            DriverRepository.Connect(inverter.Model, inverter.connectionParams)
                .SetReferenceFrequency(newFrequency);
        }

        public void Start(Inverter inverter)
        {
            DriverRepository.Connect(inverter.Model, inverter.connectionParams)
                .Start();
        }

        public void Stop(Inverter inverter)
        {
            DriverRepository.Connect(inverter.Model, inverter.connectionParams)
                .Stop();
        }

        #endregion
    }
}