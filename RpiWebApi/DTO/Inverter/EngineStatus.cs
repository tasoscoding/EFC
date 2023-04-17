namespace RpiWebApi.DTO.Inverter
{
    public static class EngineStatus
    {
        public static readonly String Accelerating = "Accelerating";
        public static readonly String DcBraking = "DC braking";
        public static readonly String Decelerating = "Decelerating";
        public static readonly String Disconnected = "Disconnected";
        public static readonly String Fault = "Fault";
        public static readonly String Reverse = "Reverse";
        public static readonly String Running = "Running";
        public static readonly String SpeedReached = "Speed reached";
        public static readonly String Stopped = "Stopped";
        public static readonly String Undefined = "Undefined";
    }
}
