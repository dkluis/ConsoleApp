using System;
using System.Collections.Generic;
using System.Text;

namespace Media_Library
{
    class TVmaze
    {
        protected (bool, int) FindShow(string name)
        {
            Console.WriteLine($"Finding a Show on TVMaze via API {name}");
            return (true, 1);
        }
    }
}
