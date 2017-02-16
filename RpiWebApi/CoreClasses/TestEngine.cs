using System;
using RpiWebApi.EngineClasses;

namespace RpiWebApi.CoreClasses {
    public class TestEngine : IEngine {
        public EngineOperationResult EmergencyStop() {
            return new EngineOperationResult(true);
        }

        public EngineOperationResult GetCurrentValue() {
            NumericValue value = new NumericValue();
            value.value = 5;
            return new EngineOutputValueResult(value);
        }

        public EngineOperationResult GetFrequencyValue() {
            NumericValue value = new NumericValue();
            value.value = 7;
            return new EngineOutputValueResult(value);
        }

        public EngineOperationResult GetInverterModel() {
            return new EngineOutputConstantResult<EngineModel>(new EngineModel(-1));
        }

        public EngineOperationResult GetRpmValue() {
            NumericValue value = new NumericValue();
            value.value = 12;
            return new EngineOutputValueResult(value);
        }

        public EngineOperationResult GetStatus() {
            return new EngineOutputConstantResult<EngineStatus>(new EngineStatus(-1));
        }

        public EngineOperationResult GetVoltageValue() {
            NumericValue value = new NumericValue();
            value.value = 14;
            return new EngineOutputValueResult(value);
        }

        public EngineOperationResult Reset() {
            return new EngineOperationResult(true);
        }

        public EngineOperationResult Reverse() {
            return new EngineOperationResult(false);
        }

        public EngineOperationResult SetReferenceFrequency(int newFrequency) {
            return new EngineOperationResult(true);
        }

        public EngineOperationResult Start() {
            return new EngineOperationResult(true);
        }

        public EngineOperationResult Stop() {
            return new EngineOperationResult(true);
        }
    }
}