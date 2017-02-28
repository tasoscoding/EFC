using Newtonsoft.Json;
using RpiWebApi.ResponseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpiWebApi.ResponseClass {
    public class OperationMessage {

        [JsonProperty("operation")]
        public string ΟperationType { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        public bool isValid() {
            return this.ΟperationType != null && this.Frequency != null;
        }
    }

    [Flags]
    public enum OperationType {
        Start,
        Stop, 
        Reverse,
        EmergencyStop,
        ChangeFrequency,
        Unknown
    }

    public class OperationConstructor {

        private OperationMessage opMessage;

        public OperationConstructor(OperationMessage operationMessage) {
            this.opMessage = operationMessage;
        }

        public Operation CreateOperation() {
            OperationType type;
            if (opMessage.ΟperationType.Equals("start")) {
                type = OperationType.Start;
            } else if (opMessage.ΟperationType.Equals("stop")) {
                type = OperationType.Stop;
            } else if (opMessage.ΟperationType.Equals("reverse")) {
                type = OperationType.Reverse;
            } else if (opMessage.ΟperationType.Equals("emergencystop")) {
                type = OperationType.EmergencyStop;
            } else if (opMessage.ΟperationType.Equals("changefrequency")) {
                type = OperationType.ChangeFrequency;
            } else {
                type = OperationType.Unknown;
            }

            Operation operation = new Operation();
            operation.operationType = type;

            if (opMessage.Frequency != null) {
                Int32.TryParse(opMessage.Frequency, out operation.frequency);
            }

            return operation;

        }
    }

    public class Operation {
        public OperationType operationType;
        public int frequency;
    }


}