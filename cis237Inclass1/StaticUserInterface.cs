using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    //Add static keywork to make this class static
    static class StaticUserInterface
    {
        //this method had to become static because the class is.
        static public int GetUserInput()
        {
            //Call the printMenu method, and qualify it using the name of this
            // class instead of the keyword 'this'. IT does the same thing as 'this'
            //but since 'this' for instances and static class can't have isntances
            //we must use the class name. 
            StaticUserInterface.printMainMenu(); // call the printMainMenu method that is private to this class

            string input = Console.ReadLine(); // read input from the console

            // continue to loop while the input is not a valid choice
            while (input != "1" && input != "2")
            {
                // since it is not valid, output a message saying so
                Console.Clear();
                Console.WriteLine("That is not a valid input!");
                Console.WriteLine("Please try again.");
                Console.WriteLine();

                System.Threading.Thread.Sleep(2000); // 2 second pause before continuing
                Console.Clear();

                StaticUserInterface.printMainMenu(); // call the printMainMenu method that is private to this class
                input = Console.ReadLine(); // read user input

            }
            return Int32.Parse(input); // parse the input as an integer
        }

        static public void PrintAllOutput(string allOutput)
        {
            Console.WriteLine(allOutput);
        }

        static private void printMainMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Print List");
            Console.WriteLine("2. Exit");
        }
    }
}

