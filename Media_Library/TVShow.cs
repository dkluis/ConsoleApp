using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    public class TVShow : Media, TVMaze, Serie
    {
        public TVShow(string name, string description, MediaTypes mediatype, int tvmazeid)
        {
            MediaName = name;
            MediaDescription = description;
            MediaType = mediatype;
            TVMazeID = tvmazeid;
            GetNextID();
        }

        public string SerieName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SeriePosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TVMazeID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool SaveTVShow()
        {
            //Write to DB
            return true;
        }
    }
}