using RpiWebApi.EngineClasses;
using RpiWebApi.ResponseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpiWebApi.CoreClasses {
     public class OperationExecutor {
        private static OperationExecutor executor;

        private OperationExecutor() { }

        public static OperationExecutor GetInstance() {
            if (executor == null) {
                executor = new OperationExecutor();
            }
            return executor;
        }

        public EngineOperationResult ExecuteOperation(Operation operation) {
            IEngine engine = new TestEngine();

            OperationType type = operation.operationType;
            if ( type == OperationType.Start) {
                return engine.Start();
            } else if (type == OperationType.Stop) {
                return engine.Stop();
            } else if (type == OperationType.Reverse) {
                return engine.Reverse();
            } else if (type == OperationType.EmergencyStop ) {
                return engine.EmergencyStop();
            } else if (type == OperationType.ChangeFrequency) {
                return engine.SetReferenceFrequency(operation.frequency);
            } else {
                return new EngineOperationResult(false);
            }

        } 

    }
}