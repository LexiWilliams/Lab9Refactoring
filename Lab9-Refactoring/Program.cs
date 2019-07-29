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

        //lines 109-110, 115 fix
        public static List<StudentInfo> allstudentInfo = new List<StudentInfo>
            {
            new StudentInfo("Ally", "Nashville","pizza", "1 dog"),
            new StudentInfo("Billy","Houston","tacos","3 dogs"),
            new StudentInfo("Dave","Boston","sushi","1 cat"),
            new StudentInfo("Joe", "Sacramento","pb&j","no pets"),
            new StudentInfo("Kay","Columbus","spaghetti","7 parakeets"),
            new StudentInfo("Phillip","Olympia","ice cream","2 bunnies")
            };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the July 2019 C# class.");
            List<StudentInfo> studentInfoAlphabetical = allstudentInfo.OrderBy(o => o.StudentName).ToList();


            bool runAgain = true;
            while (runAgain)
            {
                runAgain = ListOrAdd("Would you like to\n1.Learn about a student\n2.Add a new student\n3.Quit program", studentInfoAlphabetical);
                
            }
        }
        #region Methods
        public static List<StudentInfo> AddStudent(List<StudentInfo> allStudentInfo)
        {
            StudentInfo studentInfo = new StudentInfo();
            Console.WriteLine("");

            bool askAgain = true;
            while (askAgain)
            {
                Console.WriteLine("What is the name of the student?");
                string name = Console.ReadLine();
                if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    studentInfo.StudentName = name;
                    askAgain = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid name.");
                    Console.WriteLine("");
                    askAgain = true;
                }
            }
            askAgain = true;
            while (askAgain)
            {
                Console.WriteLine("What is their hometown?");
                string hometown = Console.ReadLine();
                if (Regex.IsMatch(hometown, @"^[a-zA-Z]+[ ]*[a-zA-Z]*[ ]*[a-zA-Z]*$"))
                {
                    studentInfo.Hometown = hometown;
                    askAgain = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid hometown.");
                    Console.WriteLine("");
                    askAgain = true;
                }
            }
            askAgain = true;
            while (askAgain)
            {
                Console.WriteLine("What is their favorite food?");
                string favoriteFood = Console.ReadLine();
                if (Regex.IsMatch(favoriteFood, @"^[a-zA-Z]+[ ]*[a-zA-Z]*[ ]*[a-zA-Z]*$"))
                {
                    studentInfo.FavoriteFood = favoriteFood;
                    askAgain = false;

                }
                else
                {
                    Console.WriteLine("That is not a valid food.");
                    Console.WriteLine("");
                    askAgain = true;
                }
            }
            askAgain = true;
            while (askAgain)
            {
                Console.WriteLine("What pets do they have?");
                string pets = Console.ReadLine();
                if (Regex.IsMatch(pets, @"^[a-zA-Z0-9]+[ ]*[a-zA-Z0-9]*[ ]*[a-zA-Z0-9]*$"))
                {
                    studentInfo.Pets = pets;
                    askAgain = false;

                }
                else
                {
                    Console.WriteLine("That is not a valid pet.");
                    Console.WriteLine("");
                    askAgain = true;
                }
                allStudentInfo.Add(studentInfo);
              
                //sort list by studentName property alphabetically, then add in new list in correct place
                Console.WriteLine("");
                studentInfo.PrintStudentInfo();
                
            }

            return allstudentInfo.OrderBy(o => o.StudentName).ToList();
        }
        public static bool ListOrAdd(string message, List<StudentInfo> allStudentInfo)
        {
            Console.WriteLine(message);
            if (int.TryParse(Console.ReadLine(), out int taskNumber))
            {
                if (taskNumber == 1) //list
                {
                    int numOfStudents = PrintAllStudentNames(allstudentInfo);
                    PrintStudentInfo("Which student would you like to know abbout?", numOfStudents, allstudentInfo);

                    return true;

                }
                else if(taskNumber == 2) //add
                {
                    allstudentInfo = AddStudent(allstudentInfo);
                    return true;
                }
                else if(taskNumber==3) //quit
                {
                    Console.WriteLine("Goodbye.");
                    return false;
                }
                else
                {
                    Console.WriteLine("That isn't an option.");
                   return ListOrAdd(message, allstudentInfo);
                }
            }
            else
            {
                Console.WriteLine("That isn't an option.");
                return ListOrAdd(message, allstudentInfo);
            }
        }
        public static int PrintAllStudentNames(List<StudentInfo> allStudentInfo)
        {
            Console.WriteLine("");
            int count = 0;
            foreach (StudentInfo x in allstudentInfo)
            {
                count++;
                Console.WriteLine($"{count}. {x.StudentName}");
            }
            return count;
        }
        public static void PrintStudentInfo(string message, int numOfStudents, List<StudentInfo> allStudentInfo)
        {
            Console.WriteLine(message);
            string studentNumber = Console.ReadLine();
            Console.WriteLine("");
            if (int.TryParse(studentNumber, out int studentNumberInt))
            {
                int indexOfStudent = studentNumberInt - 1;
                if (indexOfStudent < numOfStudents && indexOfStudent >=0)
                {
                    Console.WriteLine($"Student's name: {allstudentInfo[indexOfStudent].StudentName}");
                    Console.WriteLine($"Student's hometown: {allstudentInfo[indexOfStudent].Hometown}");
                    Console.WriteLine($"Student's favorite food: {allstudentInfo[indexOfStudent].FavoriteFood}");
                    Console.WriteLine($"Student's pets: {allstudentInfo[indexOfStudent].Pets}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("That is not a valid input\n ");
                PrintStudentInfo(message, numOfStudents, allStudentInfo);
            }
        }



        //public static bool RunAgain(string message, List<StudentInfo> allStudentInfo)
        //{
        //    Console.WriteLine(message);
        //    string input = Console.ReadLine().ToLower();
        //    if (int.TryParse(input, out int number))
        //    {

        //        if (number == 1)
        //        {

        //            return true;
        //        }
        //        else if (number == 2)
        //        {

        //        }
        //        if (number == 3)
        //        {
        //            Console.WriteLine("Goodbye!");
        //            return false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("That isn't an option.");
        //            return RunAgain(message, allStudentInfo);
        //        }
        //    }

        //}


        //old methods
        //public static int GetNumber(string message, List<string> list)
        //{
        //    Console.WriteLine(message);
        //    foreach (string name in list)
        //    {
        //        Console.WriteLine($"{list.IndexOf(name)+1}: {name}");
        //    }
        //    string input = Console.ReadLine();
        //    if (int.TryParse(input, out int number))
        //    {
        //        if (number - 1 >= 0 && number - 1 < list.Count)
        //        {
        //            int index = number - 1;
        //            return index;
        //        }
        //        else
        //        {
        //            Console.WriteLine("That input is not valid");
        //            return GetNumber(message, list);
        //        }
        //    }
        //    else
        //    {
        //        foreach (string name in list)
        //        {
        //            bool check = input.Contains(name);
        //            if (check)
        //            {
        //                int nameLoation = list.IndexOf(input);
        //                return nameLoation;
        //            }
        //        }
        //        Console.WriteLine("That input is not valid.");
        //        return GetNumber(message, list);
        //    }
        //}
        //public static int GetInfoType(string message)
        //{
        //    Console.WriteLine(message);
        //    string whatInfo = Console.ReadLine().ToLower();
        //    if (whatInfo == "hometown")
        //    {
        //        return 1;
        //    }
        //    else if (whatInfo == "favorite food")
        //    {
        //        return 2;
        //    }
        //    else if (whatInfo == "pets")
        //    {
        //        return 3;
        //    }
        //    else
        //    {
        //        Console.WriteLine("That isnt an option.");
        //        return GetInfoType(message);
        //    }




        //}
        //public static void PrintInfo(int number, int studentNumber, List<string> list1, List<string> list2, List<string> list3, List<string> list4)
        //{
        //    if (number == 1)
        //    {
        //        Console.WriteLine($"{list4[studentNumber]}'s hometown is {list1[studentNumber]}.");
        //    }
        //    else if (number == 2)
        //    {
        //        Console.WriteLine($"{list4[studentNumber]}'s favorite food is {list2[studentNumber]}.");
        //    }
        //    else if (number == 3)
        //    {
        //        Console.WriteLine($"{list4[studentNumber]} has {list3[studentNumber]}.");
        //    }
        //}
        ////public static bool RunAgain(string message, List<StudentInfo> allStudentInfo)
        //{
        //    Console.WriteLine(message);
        //    string studentInfo = Console.ReadLine().ToLower();
        //    if (studentInfo == "student")
        //    {

        //        return true;
        //    }
        //    else if (studentInfo == "add")
        //    {
        //        AddStudent(allStudentInfo);
        //        return RunAgain("If you would like to know about another student type: student\nIf you would like to add info about a new student type: add\nIf you are done type: bye",
        //                  allStudentInfo);
        //    }
        //    if (studentInfo == "bye")
        //    {
        //        Console.WriteLine("Goodbye!");
        //        return false;
        //    }
        //    else
        //    {
        //        Console.WriteLine("That isn't an option.");
        //        return RunAgain(message, allStudentInfo);
        //    }
        //}
        //////public static int AppendToListName(string message, List<string> list1)
        //////{
        //////    Console.WriteLine(message);
        //////    string input = Console.ReadLine();
        //////    if (Regex.IsMatch(input, @"^[a-zA-Z0-9]+[ ]*[a-zA-Z0-9]*$"))
        //////    {
        //////        int nameIndex = System.Math.Abs(BinarySearch(list1, input));
        //////        return nameIndex;
        //////        //do not need to return list for it to be remembered by program, only doing this for the lab requirement
        //////    }
        //////    else
        //////    {
        //////        Console.WriteLine("That isn't a valid input.");
        //////        return AppendToListName(message, list1);
        //////    }
        //////}
        //public static List<string> AppendToList(string message, List<string> list1, List<string> list2, int index1)
        //{
        //    Console.WriteLine(message);
        //    string input = Console.ReadLine();
        //    if (Regex.IsMatch(input, @"^[a-zA-Z0-9]+[ ]*[a-zA-Z0-9]*$"))
        //    {
        //        list2.Insert(index1, input);
        //        return list2;
        //    }
        //    else
        //    {
        //        Console.WriteLine("That isn't a valid input.");
        //        return AppendToList(message, list1, list2, index1);
        //    }
        //}
        //public static int BinarySearch(List<string> list, string input)
        //{
        //    var nameIndex = list.BinarySearch(input);
        //    if (nameIndex < 0)
        //    {
        //        list.Insert(~nameIndex, input);
        //        return nameIndex;
        //    }
        //    else
        //    {
        //        list.Insert(nameIndex, input);
        //        return nameIndex;
        //    }
        //}
        #endregion
    }
}

