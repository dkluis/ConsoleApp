using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public interface Serie
    {
        string SerieName { get; set; }
        int Position { get; set; }
    }
}