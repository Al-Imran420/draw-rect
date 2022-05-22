using System;
using System.Collections.Generic;
using System.Linq;
using RestAPI.Models;

namespace RestAPI.SVGData
{
    public class MockSVGdata : SVGdata
    {

        private List<SVG> defaultsvg = new List<SVG>()
        {
            new SVG()
            {
                Id = Guid.NewGuid(),
                XCord = 600,
                YCord = 400,
            }
        };

        public List<SVG> GetAllSVG()
        {
            return defaultsvg;
        }

        public SVG GetSVG(Guid id)
        {
            return defaultsvg.SingleOrDefault(x => x.Id == id);
        }

        public SVG AddSVG(SVG svg)
        {
            svg.Id = Guid.NewGuid();
            defaultsvg.Add(svg);
            return svg;
        }

        public SVG EditSVG(SVG svg)
        {
            var exestingSVG = GetSVG(svg.Id);
            exestingSVG.XCord = svg.XCord;
            exestingSVG.YCord = svg.YCord;
            return svg;
        }

        public void DeleteSVG(SVG svg)
        {
            defaultsvg.Remove(svg);
        }
    }
}
