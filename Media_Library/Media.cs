using System;

namespace Media_Library
{
    public class Media
    {
        private int id;

        public Media()
        {
            id = GetNextID();
        }

        public Media(string name = null, string description = null)
        {
            if (name != null)
            {
                Name = name;
            }
            if (description != null)
            {
                Description = description;
            }
            StoreID();
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

        private int GetNextID()
        {
            Console.WriteLine("Media:GetNextID");
            return 1;
        }

        private void StoreID()
        {
            Console.WriteLine("Media:StoreID");
        }

        public MediaInfo GetInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}
