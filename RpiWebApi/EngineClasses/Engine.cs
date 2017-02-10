using RpiWebApi.EngineClasses;
using System;

namespace RpiWebApi.EngineClasses
{
    [System.Serializable]
    public class EngineMessageException : System.Exception
    {
        public EngineMessageException() { }
        public EngineMessageException( string message ) : base( message ) { }
        public EngineMessageException( string message, System.Exception inner ) : base( message, inner ) { }
        protected EngineMessageException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
    }

    public interface IEngine
    {
        /*
            EngineOperationResult GetStatus();
            EngineOperationResult GetInverterModel();
            EngineOperationResult GetInverterVersion();
        */

        EngineOperationResult Start();
        EngineOperationResult Stop();
        EngineOperationResult Reverse();
        EngineOperationResult Reset();
        EngineOperationResult EmergencyStop();

        EngineOperationResult SetReferenceFrequency(int newFrequency);

        EngineOperationResult GetVoltageValue();
        EngineOperationResult GetCurrentValue();
        EngineOperationResult GetRpmValue();
        EngineOperationResult GetFrequencyValue();

    }
}