using System;
using Newtonsoft.Json;

namespace RpiWebApi.EngineClasses {

    public class NumericValue : EngineOutput {
        public int value { get; set; }
    }
}