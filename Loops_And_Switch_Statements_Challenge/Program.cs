/*
Program.cs
----------------------------------------------------------------------------------------------------------------------------------------------------
Created by: Eldr@e@
----------------------------------------------------------------------------------------------------------------------------------------------------
Create an appplication that takes two input values:
    1. Any input value (1st input)
    2. Ask the dta type of the input value.(2nd input)
It will print to the console the optiions like belo to take input for the second input value:
    *Press 1 for String
    *Press 2 for Integer
    *Press 3 for Boolean
If the input value for the second input is 1 then the application should check, if it is a complete alphabetic entry (so no numbers accepted)
If the input value for the second input is 2 then the application should check if the entered first input is a valid integer or not.
Based on the input, the first vale and the selection of data type using the second input, the application should return whether the entered first
value is of data type selected by the user or not.
Please make sure to use a switch statement. To check the valid string you can write your custom logic.
------------------------------------------------------------------------------------------------------------------------------------------------------
Created on: 27/07/2021
----------------------------------------------------------------------------------------------------------------------------------------------------
Last update on: 27/07/2021
----------------------------------------------------------------------------------------------------------------------------------------------------
 */
using System;

namespace Loops_And_Switch_Statements_Challenge
{
    class Program
    {

        public static void printMenu()
        {
            Console.WriteLine("Would you please make a choice:");
            Console.WriteLine("Press 1 for String");
            Console.WriteLine("Press 2 for Integer");
            Console.WriteLine("Press 3 for Boolean");

        }

        public static void readInputUser(string secondInput)
        {
            char firstInput = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (firstInput)
            {
                case '1':
                    Console.WriteLine(isString(secondInput));
                    break;
                case '2':
                    Console.WriteLine(isInteger(secondInput));
                    break;
                case '3':
                    Console.WriteLine(isBoolean(secondInput));
                    break;
                default:
                    Console.WriteLine("I am sorry you must be mistaken. Please retry!");
                    break;
            }
            
        }

        public static string isString(string secondInput)
        {
            if (secondInput == "")
                return "It is an empty but valid string";
            return "It is a valid String";
        }

        public static string isBoolean(string secondInput)
        {
            if (secondInput != "True" && secondInput != "true"&& secondInput != "1" && secondInput != "0" && secondInput != "False" && secondInput != "false")
                return "It is an invalid Boolean";
            return "It is a valid Boolean";
        }

        public static string isInteger(string secondInput)
        {
            try
            {
                long nmyNumber = Int64.Parse(secondInput);
                    return "It is a valid Integer";
            }
            catch
            {
                return "It is not a valid Integer";
            }
        }

        public static void run()
        {
            Console.WriteLine("Please enter something: ");
            string secondtInput = Console.ReadLine();
            printMenu();
            readInputUser(secondtInput);

        }
        static void Main(string[] args)
        {

            run();
        }
    }
}
