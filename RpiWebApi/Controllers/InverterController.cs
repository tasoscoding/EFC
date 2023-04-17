using Microsoft.AspNetCore.Mvc;
using RpiWebApi.Infrastructure;

namespace RpiWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InverterController : ControllerBase
    {
        public IInverterRepository InverterRepository { get; }
        private Inverter localInverter { get; }

        public InverterController(
            IInverterRepository inverterRepository)
        {
            InverterRepository = inverterRepository;
            localInverter = inverterRepository.GetAll().First();
        }

        #region Read operations

        [HttpGet]
        [Route("reference-frequency")]
        public ActionResult<double> ReferenceFrequency() {
            return InverterRepository.GetReferenceFrequency(localInverter);
        }

        [HttpGet]
        [Route("status")]
        public ActionResult<string> Status() {
            return InverterRepository.GetStatus(localInverter);
        }

        #endregion

        #region Write operations

        [HttpPut]
        [Route("emergency-stop")]
        public ActionResult EmergencyStop() {
            InverterRepository.EmergencyStop(localInverter);
            return Ok();
        }

        [HttpPut]
        [Route("reference-frequency")]
        public ActionResult ReferenceFrequency(double frequency) {
            InverterRepository.SetReferenceFrequency(localInverter, frequency);
            return Ok();
        }

        [HttpPut]
        [Route("reset")]
        public ActionResult Reset() {
            InverterRepository.Reset(localInverter);
            return Ok();
        }

        [HttpPut]
        [Route("reverse")]
        public ActionResult Reverse() {
            InverterRepository.Reverse(localInverter);
            return Ok();
        }

        [HttpPut]
        [Route("start")]
        public ActionResult Start() {
            InverterRepository.Start(localInverter);
            return Ok();
        }

        [HttpPut]
        [Route("stop")]
        public ActionResult Stop() {
            InverterRepository.Stop(localInverter);
            return Ok();
        }

        #endregion
    }
}
