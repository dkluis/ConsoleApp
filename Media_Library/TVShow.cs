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
            Console.WriteLine("TVShow Class: Constructor");
        }

        public string SerieName { get; set; }
        public int SeriePosition { get; set; }
        public int TVMazeID { get; set; }
        public int TVMazeEpisode { get; set; }
        public string TVMazeSerieStatus { get; set; }

        public override bool Save()
        {
            // TVShow specific save function
            Console.WriteLine("TVShow Class: Save");
            return true;
        }

        public override bool PlexMove()
        {
            Console.WriteLine("TVShow Class: PlexMove");
            return base.PlexMove();
        }

        public void DisplayTVShow()
        {
            Console.WriteLine($"Name: {MediaName}, Description: {MediaDescription}, Type: {MediaType}");
            Console.WriteLine($"Serie Name: {SerieName}, Serie Pos: {SeriePosition}");
            Console.WriteLine($"TVMaze ID: {TVMazeID}, TVMaze Serie Status: {TVMazeSerieStatus}");

        }
    }
}