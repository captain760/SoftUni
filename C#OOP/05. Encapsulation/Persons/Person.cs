using System;
using System.Text.RegularExpressions;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            private set 
            {
                if (value<650)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                salary = value; 
            }
        }

        public string FirstName
        {
            get { return firstName; }
           private set 
            {
                if (Regex.Match(value, "[A-Z][a-z]{2,}").Success)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!"); 
                }
                
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set 
            {
                if (Regex.Match(value, "[A-Z][a-z]{2,}").Success)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                
            }
        }

        public int Age
        {
            get { return age; }
           private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value; 
            }
        }
        public void IncreaseSalary(decimal percentage)
        {
            if (Age<30)
            {
                Salary += Salary*percentage / 200 ;
            }
            else
            {
                Salary += Salary*percentage / 100 ;
            }
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}