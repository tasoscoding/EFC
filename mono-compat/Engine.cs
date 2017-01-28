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
    }
    public interface IEngine
    {
        EngineStatus Status();
        void Start();
        void Stop();
        void Reverse();
        void Reset();
        void EmergencyStop();
    }
}