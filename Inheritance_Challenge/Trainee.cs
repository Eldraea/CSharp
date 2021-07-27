/*
Trainee.cs
----------------------------------------------------------------------------------------------------------------------------------------------------
Created by Eldr@e@
----------------------------------------------------------------------------------------------------------------------------------------------------
The Trainee class
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
    class Trainee: Employee
    {

        private int workingHours;
        private int schoolHours;

        public Trainee(String firstName, String lastName, float salary, int workingHours, int schoolHours):base( lastName, firstName, salary)
        {
            this.workingHours = workingHours;
            this.schoolHours = schoolHours;
        }

        public int getWorkingHours()
        {
            return this.workingHours;
        }

        public int getSchoolHours()
        {
            return this.schoolHours;
        }

        public void setWorkingHours(int hours)
        {
            this.workingHours = hours;
        }

        public void setSchoolHours(int hours)
        {
            this.schoolHours = hours;
        }

        public void learn()
        {
            Console.WriteLine("I am learning !");
        }

        public override void work()
        {
            Console.WriteLine("I am working. Still " + getWorkingHours() + " hours to go.");
        }
    }
}
