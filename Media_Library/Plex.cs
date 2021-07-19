using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public interface Plex
    {
        string Path { get; set; }
        string FullFilePath { get; set; }
    }
}