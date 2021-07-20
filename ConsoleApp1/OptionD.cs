using System;
using UILib;
using Media_Library;

namespace ConsoleApp
{
    class OptionD
    {
        public void Main()
        {
            Console.Clear();
            bool success;

            TVShow show1 = new TVShow("TVShow Name", "TVShow Description", MediaTypes.TVShow, 1);
            show1.DisplayMediaInfo();
            //success = show1.Save();
            //success = show1.PlexMove();
            Environment.Exit(1);

            /*
            Media media1 = new Media();
            Book book1 = new Book();
            Movie movie1 = new Movie();
            Music music1 = new Music();
            */
        }
    }
}
