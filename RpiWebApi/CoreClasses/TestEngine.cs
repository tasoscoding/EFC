using System;
using RpiWebApi.EngineClasses;

namespace RpiWebApi.CoreClasses {
    public class TestEngine : IEngine {

        #region Operations

        public EngineOperationResult EmergencyStop() {
            return new EngineOperationResult(true);
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

        #endregion

        #region GetValues

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

        public EngineOperationResult GetRpmValue() {
            NumericValue value = new NumericValue();
            value.value = 12;
            return new EngineOutputValueResult(value);
        }

        public EngineOperationResult GetVoltageValue() {
            NumericValue value = new NumericValue();
            value.value = 14;
            return new EngineOutputValueResult(value);
        }

        #endregion

        #region GetConstants
        public EngineOperationResult GetInverterModel() {
            return new EngineOutputConstantResult<EngineModel>(new EngineModel(0));
        }


        public EngineOperationResult GetStatus() {
            return new EngineOutputConstantResult<EngineStatus>(new EngineStatus(0));
        }

        #endregion
    }
}