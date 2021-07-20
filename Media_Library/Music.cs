using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public class Music : Media, IAlbum
    {
        public string AlbumName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AlbumTrack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool Save()
        {
            // Music specific save function
            return base.Save();
        }
    }
}