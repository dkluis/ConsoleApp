using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public class Music : Media, Album, Plex
    {
        public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FullFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}