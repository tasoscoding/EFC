using System;

namespace RpiWebApi.EngineClasses {
    public class EngineConstant { }


    public class EngineStatus : EngineConstant {
        public static readonly String Stopped = "stopped";
        public static readonly String Running = "running";
        public static readonly String Reverse = "reverse";
        public static readonly String Fault = "fault";
        public static readonly String Accelerating = "accelerating";
        public static readonly String Decelerating = "develerating";
        public static readonly String SpeedReached = "speedreached";
        public static readonly String DcBreaking = "dcbreaking";

        public String Status { get; private set; }

        public EngineStatus(int statusCode) {
            this.Status = Stopped;
        }
    }

    public class EngineModel : EngineConstant {
        public static readonly String VegaDrive = "vegadrive";

        public String Model { get; private set; }

        public EngineModel(int modelCode) {
            this.Model = VegaDrive;
        }
    }
}