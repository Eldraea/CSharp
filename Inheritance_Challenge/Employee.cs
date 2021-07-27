/*
Employee.cs
----------------------------------------------------------------------------------------------------------------------------------------------------
Created by Eldr@e@
----------------------------------------------------------------------------------------------------------------------------------------------------
The Employee class
----------------------------------------------------------------------------------------------------------------------------------------------------
Created on: 27/07/2021
----------------------------------------------------------------------------------------------------------------------------------------------------
Last Updated on: 27/07/2021
----------------------------------------------------------------------------------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Challenge
{
    class Employee
    {

        private String lastName;
        private String firstName;
        private float salary;


        public Employee(String lastName, String firstName, float salary)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.salary = salary;
        }

        public String getLastName()
        {
            return this.lastName;
        }

        public String getFirstName()
        {
            return this.firstName;
        }

        public float getSalary()
        {
            return this.salary;
        }

        public void setLastName(String name)
        {
            this.lastName = name;
        }

        public void setFirstName(String name)
        {
            this.firstName = name;
        }

        public void setSalary(float salary)
        {
            this.salary = salary;
        }

        public virtual void work()
        {
            Console.WriteLine("I am working!");
        }

        public void pause()
        {
            Console.WriteLine("It's time for a pause!");
        }
    }
}
