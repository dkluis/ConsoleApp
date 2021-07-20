using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public interface ISerie
    {
        string SerieName { get; set; }
        double SeriePosition { get; set; }
    }
}