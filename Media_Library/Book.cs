using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public class Book : Media, GoodRead, Serie, Plex
    {
        public int Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SerieName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FullFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}