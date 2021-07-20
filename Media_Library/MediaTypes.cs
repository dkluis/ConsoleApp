using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public enum MediaTypes
    {
        TVShow,
        TVShowSerie,
        Movie,
        MovieSerie,
        Book,
        BookSerie,
        Music,
        MusicAlbum,
        Unknown
    }

    class MediaTypeUtils
    {
        public string ConvertMediaTypeToString(MediaTypes mediatype)
        {
            return mediatype.ToString();
        }

        public int ConvertMediaTypeToInt(MediaTypes mediatype)
        {
            return Convert.ToInt32(mediatype);
        }

        public MediaTypes ParseStringToMediaType(string mediatype)
        {
            MediaTypes md = (MediaTypes)Enum.Parse(typeof(MediaTypes), mediatype, true);
            return md;
        }
    }
}
