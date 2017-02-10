namespace RpiWebApi.EngineClasses {

    public class EngineOperationResult {
        private bool isOperationSuccessful;

        public EngineOperationResult(bool successful) {
            this.isOperationSuccessful = successful;
        }

        public bool isSuccessful() {
            return isOperationSuccessful;
        }

        public virtual EngineOutput GetOutput() {
            return null;
        }

    }

    public class EngineOutputValueResult : EngineOperationResult {
        private NumericValue numericValue;

        public EngineOutputValueResult(NumericValue value) : base(true) {
            this.numericValue = value;
        }

        public override EngineOutput GetOutput() {
            return numericValue;
        }
    }
}