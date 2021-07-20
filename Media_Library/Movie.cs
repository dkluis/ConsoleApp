using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public class Movie : Media, Serie
    {
        public string SerieName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SeriePosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool Save()
        {
            // Movie specific save function
            return base.Save();
        }
    }


}