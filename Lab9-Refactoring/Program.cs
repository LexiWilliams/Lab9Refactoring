using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab9_Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nameList = new List<string> { "Ally", "Billy", "Dave", "Joe", "Kay", "Phillip" };
            List<string> hometownList = new List<string> { "Nashville", "Houston", "Boston", "Sacramento", "Columbus", "Olympia" };
            List<string> favoriteFoodList = new List<string> { "pizza", "tacos", "sushi", "pb&j", "spaghetti", "ice cream" };
            List<string> petList = new List<string> { "1 dog", "3 dogs", "1 cat", "no pets", "7 parakeets", "2 bunnies" };

            bool runAgain = true;
            while (runAgain)
            {
                int studentNumber = GetNumber("Welcome to the July 2019 C# class. Which student would you like to learn about? Enter a name or a student number.", nameList);
                int infoType = GetInfoType($"What would you like to know about {nameList[studentNumber]}? Enter hometown, favorite food, or pets.");
                PrintInfo(infoType, studentNumber, hometownList, favoriteFoodList, petList, nameList);
                runAgain = RunAgain("If you would like to know about another student type: student\nIf you would like to add info about a new student type: add\nIf you are done type: bye",
                             studentNumber, nameList, hometownList, favoriteFoodList, petList);
            }
        }
        public static int GetNumber(string message, List<string> list)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                if (number - 1 >= 0 && number - 1 < list.Count)
                {
                    int index = number - 1;
                    return index;
                }
                else
                {
                    Console.WriteLine("That input is not valid");
                    return GetNumber(message, list);
                }
            }
            else
            {
                foreach (string name in list)
                {
                    bool check = input.Contains(name);
                    if (check)
                    {
                        int nameLoation = list.IndexOf(input);
                        return nameLoation;
                    }
                }
                Console.WriteLine("That input is not valid.");
                return GetNumber(message, list);
            }
        }
        public static int GetInfoType(string message)
        {
            Console.WriteLine(message);
            string whatInfo = Console.ReadLine().ToLower();
            if (whatInfo == "hometown")
            {
                return 1;
            }
            else if (whatInfo == "favorite food")
            {
                return 2;
            }
            else if (whatInfo == "pets")
            {
                return 3;
            }
            else
            {
                Console.WriteLine("That isnt an option.");
                return GetInfoType(message);
            }




        }
        public static void PrintInfo(int number, int studentNumber, List<string> list1, List<string> list2, List<string> list3, List<string> list4)
        {
            if (number == 1)
            {
                Console.WriteLine($"{list4[studentNumber]}'s hometown is {list1[studentNumber]}.");
            }
            else if (number == 2)
            {
                Console.WriteLine($"{list4[studentNumber]}'s favorite food is {list2[studentNumber]}.");
            }
            else if (number == 3)
            {
                Console.WriteLine($"{list4[studentNumber]} has {list3[studentNumber]}.");
            }
        }
        public static bool RunAgain(string message, int studentNumber, List<string> list1, List<string> list2, List<string> list3, List<string> list4)
        {
            Console.WriteLine(message);
            string studentInfo = Console.ReadLine().ToLower();
            if (studentInfo == "student")
            {
                return true;
            }
            else if (studentInfo == "add")
            {
                int nameIndex = AppendToListName("What is the name of the student?", list1);
                AppendToList("What is their hometown?", list1, list2, nameIndex);
                AppendToList("What is their favorite food?", list1, list3, nameIndex);
                AppendToList("What pets do they have?", list1, list4, nameIndex);
                return RunAgain("If you would like to know about another student type: student\nIf you would like to add info about a new student type: add\nIf you are done type: bye",
                          studentNumber, list1, list2, list3, list4);
            }
            if (studentInfo == "bye")
            {
                Console.WriteLine("Goodbye!");
                return false;
            }
            else
            {
                Console.WriteLine("That isn't an option.");
                return RunAgain(message, studentNumber, list1, list2, list3, list4);
            }
        }
        public static int AppendToListName(string message, List<string> list1)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (Regex.IsMatch(input, @"^[a-zA-Z0-9]+[ ]*[a-zA-Z0-9]*$"))
            {
                int nameIndex = System.Math.Abs(BinarySearch(list1, input));
                return nameIndex;
                //do not need to return list for it to be remembered by program, only doing this for the lab requirement
            }
            else
            {
                Console.WriteLine("That isn't a valid input.");
                return AppendToListName(message, list1);
            }
        }
        public static List<string> AppendToList(string message, List<string> list1, List<string> list2, int index1)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (Regex.IsMatch(input, @"^[a-zA-Z0-9]+[ ]*[a-zA-Z0-9]*$"))
            {
                list2.Insert(index1, input);
                return list2;
            }
            else
            {
                Console.WriteLine("That isn't a valid input.");
                return AppendToList(message, list1, list2, index1);
            }
        }
        public static int BinarySearch(List<string> list, string input)
        {
            var nameIndex = list.BinarySearch(input);
            if (nameIndex < 0)
            {
                list.Insert(~nameIndex, input);
                return nameIndex;
            }
            else
            {
                list.Insert(nameIndex, input);
                return nameIndex;
            }
        }
    }
}

