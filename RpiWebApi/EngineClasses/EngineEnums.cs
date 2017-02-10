using System;

namespace RpiWebApi.EngineClasses {
    [Flags]
    public enum EngineStatus  {
        Stopped = 0,
        Running = 1,
        Reverse = 2,
        Fault = 4,
        Accelerating = 8,
        Decelerating = 10,
        SpeedReached = 1,
        DcBreaking = 14
    }

    public enum EngineModel {
        VegaDrive = 7
    }

    public enum EngineVersion {
        Version_1_0_E = 313045,
        Version_5_0_E = 353045
    }
}