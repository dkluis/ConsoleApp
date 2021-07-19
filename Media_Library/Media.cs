using System;

namespace Media_Library
{
    public class Media
    {
        protected int Id;

        public Media()
        {
        }

        protected string Name
        {
            get => default;
            set
            {
            }
        }

        protected string Description
        {
            get => default;
            set
            {
            }
        }

        protected int Type
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
    }
}
