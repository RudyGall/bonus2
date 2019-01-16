using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bonus2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runP = true;
            string firstName = NameValid();
            DateTime dOB = DateValid();
            while (runP == true)
            {
                {
                    TimeSpan age = DateTime.Now - dOB;
                    Console.WriteLine(firstName + " is {0} Years and {1} Days old!", (int)(age.Days / 365.25), age.Days % 365.25);
                }
                runP = Continue();
            }
        }
        public static bool Continue()
        {
            Console.WriteLine("\nWould you like to run the application again? (Y or N)");
            string input = Console.ReadLine().ToLower();
            input = input.ToLower();
            bool goOn;
            if (input == "y")
            {
                goOn = true;
            }
            else if (input == "n")
            {
                Console.WriteLine("Thank you, Goodbye!");
                Console.ReadLine();
                goOn = false;
            }
            else
            {
                Console.WriteLine("I don't understand that, let's try again");
                goOn = Continue();
            }
            return goOn;
        }
        public static string NameValid()
        {
            bool responseValid = true;
            string firstName = "";
            while (responseValid)
            {
                Console.WriteLine("Please enter your first name");
                firstName = Console.ReadLine();

                if (!Regex.IsMatch(firstName, @"^[A-Z]+[A-z]{2,30}$"))
                {
                    Console.WriteLine("I'm sorry, this is not a valid name");
                }
                else
                {
                    Console.WriteLine("Name is valid");
                    break;
                }
            }
            return firstName;
        }
        public static DateTime DateValid()
        {
            bool respValid = true;
            Console.WriteLine("Please enter your birthdate. (MM/DD/YYYY)");
            DateTime dOB = DateTime.Parse(Console.ReadLine());
            while (respValid)
            {
                if (!Regex.IsMatch(dOB, @"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$"))
                {
                    Console.WriteLine("I'm sorry, this is not a valid date");
                }
                else
                {
                    Console.WriteLine("Date is Valid");
                    break;
                }
            }
            return dOB;
        }
    }
}