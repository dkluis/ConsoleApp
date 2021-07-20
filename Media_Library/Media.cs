using System;

namespace Media_Library
{
    public class Media
    {
        protected int MediaID;
        protected string MediaName;
        protected string MediaDescription;
        protected MediaTypes MediaType;
        protected string PlexPath;
        protected string PlexFullPath;

        protected void GetNextID()
        {
            Console.WriteLine("Media Class: GetNextID");
            MediaID = 1;
        }

        public virtual bool Save()
        {
            // Generic Save function to be overriden for each sub class.
            Console.WriteLine("Media Class: Save");
            return true;
        }

        public virtual bool PlexMove()
        {
            Console.WriteLine("Media Class: PlexMove");
            return true;
        }

        public virtual MediaInfo GetMediaInfo()
        {
            MediaInfo returnvalue = new MediaInfo();
            return returnvalue; 
        }

        public virtual void DisplayMediaInfo()
        {
            Console.WriteLine($"MediaID: {MediaID}");
            Console.WriteLine($"MediaName: {MediaName}");
            Console.WriteLine($"MediaDescription: {MediaDescription}");
            Console.WriteLine($"MediaType: {MediaType.ToString()}");
            Console.WriteLine($"PlexPath: {PlexPath}");
            Console.WriteLine($"PlexFullPath: {PlexFullPath}");
        }
    }
}
