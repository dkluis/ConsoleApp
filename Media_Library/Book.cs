using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public class Book : Media, IGoodRead, ISerie
    {
        public double SeriePosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SerieName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool Save()
        {
            // Book specific save function
            return base.Save();
        }
    }
}