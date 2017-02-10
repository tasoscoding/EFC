using Newtonsoft.Json;
using RpiWebApi.EngineClasses;
using System;
using System.Collections.Generic;
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

        [JsonProperty("frequency")]
        public int Frequency { get; set; }

        [JsonProperty("voltage")]
        public int Voltage { get; set; }

        [JsonProperty("rpm")]
        public int Rpm { get; set; }

        [JsonProperty("current")]
        public int Current { get; set; }
    }

    public class InverterStatusResponseFormatter {

        private InverterStatusResponse response;

        public InverterStatusResponseFormatter(InverterStatusResponse invStatusResposnse) {
            this.response = invStatusResposnse;
        }

        public void FormatMessage(EngineStatus status, EngineModel model, EngineVersion version) {
            if (status == EngineStatus.Accelerating) {
                response.EngineStatus = "Accelerating";
            } else if (status == EngineStatus.Decelerating) {
                response.EngineStatus = "Decelerating";
            } else if (status == EngineStatus.Reverse) {
                response.EngineStatus = "Reverse";
            } else if (status == EngineStatus.Stopped) {
                response.EngineStatus = "Stopped";
            } else if (status == EngineStatus.SpeedReached) {
                response.EngineStatus = "Speed Reached";
            } else if (status == EngineStatus.Fault) {
                response.EngineStatus = "Fault";
            } else if (status == EngineStatus.Running) {
                response.EngineStatus = "Running";
            }

            if (model == EngineModel.VegaDrive) {
                response.EngineModel = "VegaDrive";
            }

            if (version == EngineVersion.Version_1_0_E) {
                response.EngineVersion = "Version 10_E";
            } else if (version == EngineVersion.Version_5_0_E) {
                response.EngineVersion = "Version 50_E";
            }

            response.TimeStamp = DateTime.Now.ToString();
        }
    }
}