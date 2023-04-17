namespace RpiWebApi.DTO.Inverter.Exceptions
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
}