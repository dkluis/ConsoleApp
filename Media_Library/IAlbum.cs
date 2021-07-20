using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public interface IAlbum
    {
        string AlbumName { get; set; }
        int AlbumTrack { get; set; }
    }
}