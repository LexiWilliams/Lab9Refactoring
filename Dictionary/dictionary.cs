using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class dictionary
    {
        static void Main(string[] args)
        {
            IDictionary<int, string> d = new Dictionary<int, string>();

            d.Add(new KeyValuePair<int, string>(1, "TVs"));
            d.Add(new KeyValuePair<int, string>(2, "Appliances"));
            d.Add(new KeyValuePair<int, string>(3, "Mobile"));

            IDictionary<int, string> names = new Dictionary<int, string> { {1, "one"},{2, "two" },{3, "three" },{4, "four" } };
            IDictionary<int, string> hometowns = new Dictionary<int, string> { {1, "white lake" }, {2, "monroe", {3, "Birmingham" },{4, "Detroit" } };
            IDictionary<int, string> 

        }
    }
}
