using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public class Movie : Media, Serie, Plex
    {
        public string SerieName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FullFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}