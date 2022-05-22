using System;
using System.Collections.Generic;
using RestAPI.Models;

namespace RestAPI.SVGData
{
    public interface SVGdata
    {
        List<SVG> GetAllSVG();

        SVG GetSVG(Guid id);

        SVG EditSVG(SVG svg);

        SVG AddSVG(SVG svg);

        void DeleteSVG(SVG svg);
    }
}
