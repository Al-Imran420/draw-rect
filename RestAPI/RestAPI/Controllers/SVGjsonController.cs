using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using RestAPI.SVGData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{

    [ApiController]
    public class SVGjsonController : ControllerBase
    {
        private SVGdata _svgData;

        public SVGjsonController(SVGdata svgData)
        {
            _svgData = svgData;
        }

        // GET: all SVG data
        [EnableCors("CorsePolicy")]
        [HttpGet]
        [Route("api/[controller]/all")]
        public IActionResult GetAllSVG()
        {
            return Ok(_svgData.GetAllSVG());
        }

        // GET: SVG data by id
        [EnableCors("CorsePolicy")]
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetSVG(Guid id)
        {
            var SVG = _svgData.GetSVG(id);

            if(SVG != null)
            {
                return Ok(SVG);
            }
            return NotFound($"SVG data Id:{id} was not found");
        }

        // POST: Create SVG data
        [EnableCors("CorsePolicy")]
        [HttpPost]
        [Route("api/[controller]/create")]
        public IActionResult AddSVG(SVG svg)
        {
            _svgData.AddSVG(svg);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "://" + svg.Id, svg);
        }

        // DELETE: SVG data by id
        [EnableCors("CorsePolicy")]
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteSVG(Guid id)
        {
            var SVG = _svgData.GetSVG(id);

            if (SVG != null)
            {
                _svgData.DeleteSVG(SVG);
                return Ok($"SVG data Id:{id} deleted successfully!");
            }
            return NotFound($"SVG data Id:{id} was not found!");
        }

        // PATCH: Update SVG data
        [EnableCors("CorsePolicy")]
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditSVG(Guid id, SVG svg)
        {
            var exestingSVG = _svgData.GetSVG(id);

            if (exestingSVG != null)
            {
                svg.Id = exestingSVG.Id;
                _svgData.EditSVG(svg);
            }
            return Ok(svg);
        }

    }
}
