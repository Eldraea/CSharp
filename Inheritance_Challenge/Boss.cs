/*
Boss.cs
----------------------------------------------------------------------------------------------------------------------------------------------------
Created by Eldr@e@
----------------------------------------------------------------------------------------------------------------------------------------------------
The Boss class
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
    class Boss: Employee
    {
        private String companyCar;
        
        public Boss(String lastName, String firstName, float salary, String companyCar) : base(lastName, firstName, salary)
        {
            this.companyCar = companyCar;
        }

        public String getCompanyCar()
        {
            return this.companyCar;
        }

        public void setCompanyCar(String companyCar)
        {
            this.companyCar = companyCar;
        }

        public void lead()
        {
            Console.WriteLine("I am leading!");
        }
    }
}
