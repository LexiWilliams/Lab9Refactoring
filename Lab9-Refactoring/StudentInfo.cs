using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_Refactoring
{
    class StudentInfo
    {
        #region Fields
        private string studentName;
        private string hometown;
        private string favoriteFood;
        private string pets;
        #endregion
        #region Properties
        public string StudentName
        {
            get
            {
                return studentName;
            }
            set
            {
                studentName = value;
            }
        }
        public string Hometown
        {
            get
            {
                return hometown;
            }
            set
            {
                hometown = value;
            }
        }
        public string FavoriteFood
        {
            get
            {
                return favoriteFood;
            }
            set
            {
                favoriteFood = value;
            }
        }
        public string Pets
        {
            get
            {
                return pets;
            }
            set
            {
                pets = value;
            }
        }
        #endregion
        #region Constructors
        public StudentInfo()
        {

        }
        public StudentInfo(string name, string home, string food, string pet)
        {
            studentName = name;
            hometown = home;
            favoriteFood = food;
            pets = pet;
        }
        #endregion
        #region Methods
        public void PrintStudentInfo()
        {
            Console.WriteLine($"Student name: {studentName}");
            Console.WriteLine($"Hometown: {hometown}");
            Console.WriteLine($"favorite food: {favoriteFood}");
            Console.WriteLine($"Pets: {pets}");
            Console.WriteLine("");
        }
        #endregion
    }
}