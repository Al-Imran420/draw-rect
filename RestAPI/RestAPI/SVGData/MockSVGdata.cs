using System;
using System.Collections.Generic;
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
                XCord = 250,
                YCord = 200,
            },
            new SVG()
            {
                Id = Guid.NewGuid(),
                XCord = 350,
                YCord = 300,
            }
        };



        public SVG AddSVG(SVG svg)
        {
            throw new NotImplementedException();
        }

        public void DeleteSVG(SVG svg)
        {
            throw new NotImplementedException();
        }

        public SVG EditSVG(SVG svg)
        {
            throw new NotImplementedException();
        }

        public SVG GetSVG(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<SVG> GetSVG()
        {
            return defaultsvg;
        }
    }
}
