using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestAPI.SVGData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SVGjsonController : ControllerBase
    {
        private SVGdata _svgData;
        public SVGjsonController(SVGdata svgData)
        {
            _svgData = svgData;
        }

        // GET: api/values
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetSVG()
        {
            return Ok(_svgData.GetSVG());
        }

    }
}
