using Newtonsoft.Json;
using RpiWebApi.EngineClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RpiWebApi.ResponseClass {


    public class InverterStatusResponse {

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("status",NullValueHandling = NullValueHandling.Ignore)]
        public string EngineStatus { get; set; }

        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public string EngineModel { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string EngineVersion { get; set; }

        [JsonProperty("frequency", NullValueHandling = NullValueHandling.Ignore)]
        public int Frequency { get; set; }

        [JsonProperty("voltage", NullValueHandling = NullValueHandling.Ignore)]
        public int Voltage { get; set; }

        [JsonProperty("rpm", NullValueHandling = NullValueHandling.Ignore)]
        public int Rpm { get; set; }

        [JsonProperty("current", NullValueHandling = NullValueHandling.Ignore)]
        public int Current { get; set; }

        public InverterStatusResponse() {
            TimeStamp = DateTime.Now.ToString();
        }
    }
}