using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public class MediaInfo
    {
        public string Name;
        public string Description;
        public MediaTypes Type;

        public MediaInfo()
        {
            Console.WriteLine("MediaInfo Struct Constructor");
        }
    }



}