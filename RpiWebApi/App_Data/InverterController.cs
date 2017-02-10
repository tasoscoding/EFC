
using Newtonsoft.Json;
using RpiWebApi.CoreClasses;
using RpiWebApi.EngineClasses;
using RpiWebApi.ResponseClass;
using System.Collections.Generic;
using System.Web.Http;

namespace RpiWebApi.App_Data
{
    public class InverterController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Status() {
            try {
                InverterStatusResponse response = new InverterStatusResponse();
                IEngine engine = new TestEngine();

                NumericValue currentValue;
                NumericValue frequencyValue;
                NumericValue voltageValue;


                EngineOperationResult currentResult = engine.GetCurrentValue();
                if (currentResult.isSuccessful()) {
                    currentValue = (NumericValue) currentResult.GetOutput();
                    response.Current = currentValue.value;
                }

                EngineOperationResult voltageResult = engine.GetVoltageValue();
                if (voltageResult.isSuccessful()) {
                    voltageValue = (NumericValue) voltageResult.GetOutput();
                    response.Voltage = voltageValue.value;
                }

                EngineOperationResult frequencyResult = engine.GetFrequencyValue();
                if (frequencyResult.isSuccessful()) {
                    frequencyValue = (NumericValue) frequencyResult.GetOutput();
                    response.Frequency = frequencyValue.value;
                }
                return Ok(response);
            } catch {
                return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult Operation([FromBody] OperationMessage operationMessage) {
            OperationConstructor constructor = new OperationConstructor(operationMessage);
            Operation operation = constructor.CreateOperation();

            OperationExecutor executor = OperationExecutor.GetInstance();
            EngineOperationResult engineResult = executor.ExecuteOperation(operation);

            if (engineResult.isSuccessful()) {
                return Ok();
            } else {
                return BadRequest();
            }
            
        }

        [HttpGet]
        public IHttpActionResult Value() {
            return null;
        }
    }
}
