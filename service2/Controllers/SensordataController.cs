using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace service2.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class SensorDataController : ControllerBase
    {
        public ILogger<SensorDataController> _logger { get; }

        public SensorDataController(ILogger<SensorDataController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(SensorData model)
        {
            return Ok();

        }


        [HttpGet]
        public ActionResult<IEnumerable<SensorData>> Get([FromQuery]string location = null, [FromQuery]DateTime? from = null)
        {
            if (from == null)
            {
                from = DateTime.Now.AddDays(-7);
            }
            return new List<SensorData> {
                new SensorData
            {
                 Location=location,
                 Value=1,
                 Timestamp=DateTime.Now
            }
            };
        }


    }
}