
using Newtonsoft.Json;
using RpiWebApi.CoreClasses;
using RpiWebApi.EngineClasses;
using RpiWebApi.ResponseClass;
using System.Collections.Generic;
using System.Web.Http;

namespace RpiWebApi.Controllers
{
    public class InverterController : ApiController
    {
        [HttpGet]
        [Route("api/inverter/status")]
        public IHttpActionResult Status() {
                InverterStatusResponse response = new InverterStatusResponse();
                IEngine engine = new TestEngine();
                
                NumericValue currentValue;
                NumericValue frequencyValue;
                NumericValue voltageValue;

                ConstantValue<EngineModel> model;
                ConstantValue<EngineStatus> status;

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

                EngineOperationResult modelResult = engine.GetInverterModel();
                if (modelResult.isSuccessful()) {
                    model = (ConstantValue<EngineModel>)modelResult.GetOutput();
                    response.EngineModel = model.constant.Model;
                }

                EngineOperationResult statusResult = engine.GetStatus();
                if (statusResult.isSuccessful()) {
                    status = (ConstantValue<EngineStatus>)statusResult.GetOutput();
                    response.EngineStatus = status.constant.Status;
                }

                return Ok(response);
            
        }

        [HttpPost]
        [Route("api/inverter/operation")]
        public IHttpActionResult Operation([FromBody] OperationMessage operationMessage) {
            if (operationMessage != null && operationMessage.isValid()) {
                OperationConstructor constructor = new OperationConstructor(operationMessage);
                Operation operation = constructor.CreateOperation();
                OperationExecutor executor = OperationExecutor.GetInstance();

                EngineOperationResult engineResult = executor.ExecuteOperation(operation);

                if (engineResult.isSuccessful()) {
                    return Ok();
                } else {
                    return BadRequest("Bad operation");
                }
            } else {
                return BadRequest("Wrong Json Format");
            }
            
        }

        [HttpGet]
        [Route("api/inverter/value")]
        public IHttpActionResult Value() {
            return null;
        }
    }
}
