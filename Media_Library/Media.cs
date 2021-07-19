using System;

namespace Media_Library
{
    public class Media
    {
        public Media()
        {
        }

        protected int MediaID;
        protected string MediaName;
        protected string MediaDescription;
        protected MediaTypes MediaType;
        protected string PlexPath;
        protected string PlexFullPath;

        protected void GetNextID()
        {
            Console.WriteLine("Media:GetNextID");
            MediaID = 1;
        }

        protected void StoreID()
        {
            Console.WriteLine("Media:StoreID");
        }
    }
}
