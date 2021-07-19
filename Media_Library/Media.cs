using System;

namespace Media_Library
{
    public class Media
    {
        protected int Id;

        public Media()
        {
        }

        public string Name
        {
            get => default;
            set
            {
            }
        }

        public string Description
        {
            get => default;
            set
            {
            }
        }

        private int Type
        {
            get => default;
            set
            {
            }
        }

        protected int GetNextID()
        {
            Console.WriteLine("Media:GetNextID");
            return 1;
        }

        protected void StoreID()
        {
            Console.WriteLine("Media:StoreID");
        }

        public MediaInfo GetInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}
