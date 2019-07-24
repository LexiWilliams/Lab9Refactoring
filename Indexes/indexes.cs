using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexes
{
    class indexes
    {
        static void Main(string[] args)
        {
            List<string> nameList = new List<string> { "Bob", "Billy", "Kay", "Joe", "Ellie", "Benji" };
            int pos1 = nameList
            for(int i = 0; i < nameList.Count;i++)
            {
                Console.WriteLine($"{i} { nameList[i]}");
            }
            

            nameList.Sort();
            for (int i = 0; i < nameList.Count; i++)
            {
                Console.WriteLine($"{i} { nameList[i]}");
            }
        }
    }
}
