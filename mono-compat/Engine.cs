using System;

namespace EFC
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
    
    [Flags]
    public enum EngineStatus
    {
        Stopped = 0b00,
        Running = 0b01,
        Reverse = 0b10
        Fault = 0b11,
        Accelerating = 0b100,
        Decelerating = 0b101,
        SpeedReached = 0b110,
        DcBreaking = 0b111
    }

    public enum EngineModel {
        VegaDrive = 7
    }

    public enum EngineVersion {
        Version_1_0_E = 313045,
        Version_5_0_E = 353045        
    }




    public interface IEngine
    {
        EngineStatus Status();
        void Start();
        void Stop();
        void Reverse();
        void Reset();
        void EmergencyStop();

        EngineModel GetInverterModel();
        EngineVersion GetInverterVersion();
        void SetReferneceFrequenct(int newFrequency);

    }
}