using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InsertNew
{
    class insertnew
    {
        static void Main(string[] args)
        {
            List<string> nameList = new List<string> { "Ally", "Billy", "Dave", "Joe", "Kay", "Phillip" };
            List<string> hometownList = new List<string> { "Nashville", "Houston", "Boston", "Sacramento", "Columbus", "Olympia" };
            List<string> favoriteFoodList = new List<string> { "pizza", "tacos", "sushi", "pb&j", "spaghetti", "ice cream" };
            List<string> petList = new List<string> { "1 dog", "3 dogs", "1 cat", "no pets", "7 parakeets", "2 bunnies" };
            string input = Console.ReadLine();
           
            foreach (string x in nameList)
            {
                Console.WriteLine(x);
            }
            BinarySearch(nameList, input);
            for (int i = 0; i <= nameList.Count() - 1; i++)
            {
                Console.WriteLine(nameList[i]);
            }
        }

        public static List<string> AppendToList(string message, List<string> list1)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            list1.Add(input);
            return list1;
        }

        public static List<string> BinarySearch(List<string> list, string input)
        {
            var binarySearchIndex = list.BinarySearch(input);
            if (binarySearchIndex < 0)
            {
                list.Insert(~binarySearchIndex, input);
                return list;
            }
            else
            {
                list.Insert(binarySearchIndex, input);
                return list;
            }
        }
    }
}


