using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cis237Inclass1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Declaring a variable fo the type Employee (which is a class) and
            //instanciating a new instance of EMployee and assigning it to the variable
            //Using the NEW keyword means that m
            Employee myEmployee = new Employee();

            //Use the properties to assign values.
            myEmployee.FirstName = "David";
            myEmployee.LastName = "Barnes";
            myEmployee.WeeklySalary = 2048.34m;
            //Output the first name of the employee using the property
            Console.WriteLine(myEmployee.FirstName);
            //Output the entire employee, which will call the ToSTring method implicitly
            //This would work even without overriding the ToString method in the Employee Class,
            //However it would only spit out the namespace and name of class instead of something useful
            Console.WriteLine(myEmployee);

            //Create an array of type E#Mployee 
            Employee[] employees = new Employee[10];

            employees[0] = new Employee("James", "Kirk", 453.00m);
            employees[1] = new Employee("Jean-Luc", "Picard", 290.00m);
            employees[2] = new Employee("Benjamin", "Sisko", 530.00m);
            employees[3] = new Employee("Kathryn", "Janeway", 359.00m);
            employees[4] = new Employee("Johnathan", "Archer", 742.00m);

            //a foreach loop. It is useful for doing a collection of objects.
            //Each object in the array 'employees' will get assigned to the local
            //variable 'employee' inside the loop.
            foreach (Employee employee in employees)
            {
                //Run a check to make sure the spot in the array is not empty
                if(employee != null)
                {
                    //Print the employee
                    Console.WriteLine(employee.ToString() + " " + employee.YearlySalary());
                }
            }

            //Use the CSV Processor method that we wrote into main to load the
            // employees from the csv file
            ImportCSV("employees.csv", employees);

            //Instanciacte a new UI Class
            UserInterface ui = new UserInterface();

            StaticUserInterface.GetUserInput();

            //Get the user input from the UI class
            //int choice = ui.GetUserInput();
            //Could use the instance one above, but to demonstrate using a static
            //class, we are calling the static version.
            //If you HATE static classes and want to avoid them, feel free to 
            //comment the below line, and uncomment the above line.
            int choice = StaticUserInterface.GetUserInput();

            //While the choice that they entered is not 2, we will loop to
            //continue to get the next choice of what they want to do,
            while (choice != 2)
            {
                //if the choice they made is 1, (which for us is the only choice)
                if(choice == 1)
                {
                    //Create string to concat the output
                    string allOutput = "";
                    
                    //Loop through all the employees just like above only instead of 
                    //Writing out the employees, we concating them togethor
                    foreach(Employee employee in employees)
                    {
                        if (employee != null)
                        {
                            allOutput += employee.ToString() + " " +
                                employee.YearlySalary() +
                                Environment.NewLine;
                        }
                    }
                    //Once the concat is done, have the UI class print out the result
                    ui.PrintAllOutput(allOutput);
                }
                //get the next choice from the user.
                choice = ui.GetUserInput();
            }
        }

        static bool ImportCSV(string pathToCsvFile, Employee[] employees)
        {
            //Declare a variable for the stream reader. Not going to instanciate it yet.
            StreamReader streamReader = null;

            //start a try since the path to the file could be incorrect, and thus
            //throw an exception
            try
            {
                //Declare a string for each line we will read in.
                string line;

                //Instanciate the streamReader. If the path to file is incorrect it will
                //throw and exception that we can reach
                streamReader = new StreamReader(pathToCsvFile);

                //Setup a counter that we aren't using yet.
                int counter = 0;

                //While there is a line to read, read the line and put it in the line var.
                while((line = streamReader.ReadLine()) != null)
                {
                    //Call the process line method and send over the read in line
                    //the employees array (which is passed by reference automatically),
                    //and the counter, which will be used as the index of the array.
                    //We are also incrementing the counter after we sent it in with the ++ operator
                    processsLine(line, employees, counter++);
                }

                //All the reads are succesful return true
                return true;

            }
            catch(Exception e)
            {
                //Output the exception string, and the stack trace.
                //The stack trace is all of the method calls that lead to 
                //Where the exception occured.
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);

                //Return false, reading failed
                return false;
            }
            //Used to ensure the code within it gets excecuted regardless of whether the
            //try succeeds or the catch get excecutd.
            finally
            {
                //Check to make sure that the streamReader is actually instaciated before
                //Trying to call a method on it
                if(streamReader !=null)
                {
                    //Close the streamReader because its the right thing to do.
                    streamReader.Close();
                }
            }



            return true;


        }

        static void processsLine(string line, Employee[] employees, int index)
        {
            //declare a string array and assign the split line to it
            string[] parts = line.Split(',');

            //Assign the parts to local variables that mean something
            string firstName = parts[0];
            string lastName = parts[0];
            decimal salary = decimal.Parse(parts[2]);

            //Use hte variables to instanciate a new Employee and assign it to
            //the spot in the employees array indexed by the index that was passed in
            employees[index] = new Employee(firstName, lastName, salary);
        }

    }
}
