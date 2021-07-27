/*
Program.cs
-----------------------------------------------------------------------------------------------------------------------------------------------------
Created by Eldr@e@
----------------------------------------------------------------------------------------------------------------------------------------------------
Create a main class with the Main Method, then a base clas Employee with the properties: Name, FirstName, Salary, and the methods Work() and Pause().
Create a deriving class Boss with the property companyCar and the method lead().
Create another deriving class of employees - trainees with the properties workingHours and schoolHours and a method learn().
Override thhe methods work() of the trainee class so that it indicates the working hours of the trainee.
Don't forget to create constructors
Create an object of each of three classes( with arbitrary values) and call the methods, lead() of the boss and work() of the trainee.
-----------------------------------------------------------------------------------------------------------------------------------------------------
Created on: 27/07/2021
-----------------------------------------------------------------------------------------------------------------------------------------------------
Last Updated on: 27/07/2021
----------------------------------------------------------------------------------------------------------------------------------------------------
 */


using System;

namespace Inheritance_Challenge
{
    class Program
    {

        public static void run()
        {
            Employee employee1 = new Employee("Doe", "John", 23000);
            Trainee trainee1 = new Trainee("Doe", "Jane", 15000, 661, 400);
            Boss boss1 = new Boss("Wick", "John", 100000000, "Secret Rent");
            boss1.work();
            boss1.pause();
            boss1.lead();
            trainee1.work();
            trainee1.pause();
            trainee1.learn();
            employee1.work();
            employee1.pause();

        }
        static void Main(string[] args)
        {
            run();
            
        }
    }
}
