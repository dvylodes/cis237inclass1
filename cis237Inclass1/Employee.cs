using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class Employee
    {


        public string FirstName;
        public string LastName;
        public decimal WeeklySalary;

        public string FirstNameString
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        public string LastNameString
        {
            get { return LastName; }
            set { LastName = value; }
        }

        public decimal WeeklySalaryDecimal
        {
            get { return WeeklySalary; }
            set { WeeklySalary = value; }
        }

        // *************************************************
        //                 Public Methods
        // *************************************************

        // returns the Firstname and Lastname when printing myEmployee
        // usint the override keyword, the method will override the automatic one that comes 
        // with ever single object that is created.
        public override string ToString()
        {
            // the this keyword is used to reference 'this' class. 
            // it allows us to reference things that are declard at this classes 'class level'
            return this.FirstName + " " + this.LastName;
        }

        public decimal YearlySalary()
        {
            return this.WeeklySalary * 52;
        }

        // *************************************************
        //                  Constructor
        // *************************************************
        public Employee(string firstNameString, string lastNameString, decimal weeklySalaryDecimal)
        {
            this.FirstName = firstNameString;
            this.LastName = lastNameString;
            this.WeeklySalary = WeeklySalary;
        }

        // Defualt Constructor
        // an empty constructor
        // we must add it back once we create another constructor
        public Employee()
        {
            // do nothing
        }
    }
}
