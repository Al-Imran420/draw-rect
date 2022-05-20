using System;
using System.Collections.Generic;
using RestAPI.Models;

namespace RestAPI.SVGData
{
    public interface SVGdata
    {
        List<SVG> GetSVG();

        SVG GetSVG(Guid id);

        SVG AddSVG(SVG svg);

        void DeleteSVG(SVG svg);

        SVG EditSVG(SVG svg);
    }
}
