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
        public static readonly String Undefined = "undefined";

        public String Status { get; private set; }

        public EngineStatus(int statusCode) {
            this.Status = new EngineStatusTranslator(statusCode).translateCode();
        }
    }

    internal class EngineStatusTranslator {
        private int code;

        public EngineStatusTranslator(int code) {
            this.code = code;
        }

        public String translateCode() {
            if (code == 0) {
                return EngineStatus.Stopped;
            } else if (code == 1) {
                return EngineStatus.Running;
            } else if (code == 2) {
                return EngineStatus.Reverse;
            } else if (code == 4) {
                return EngineStatus.Fault;
            } else if (code == 8) {
                return EngineStatus.Accelerating;
            } else if (code == 10) {
                return EngineStatus.Decelerating;
            } else if (code == 11) {
                return EngineStatus.SpeedReached;
            } else if (code == 14) {
                return EngineStatus.DcBreaking;
            } else
                return EngineStatus.Undefined;
        }
    }

    public class EngineModel : EngineConstant {
        public static readonly String VegaDrive = "vegadrive";
        public static readonly String Undefined = "undefined";

        public String Model { get; private set; }

        public EngineModel(int modelCode) {
            this.Model = new EngineModelTranslator(modelCode).translateCode();
        }
    }

    internal class EngineModelTranslator {
        private int code;

        public EngineModelTranslator(int modelCode) {
            this.code = modelCode;
        }

        public String translateCode() {
            if (code == 7) {
                return EngineModel.VegaDrive;
            } else return EngineModel.Undefined;
        }
    }
}