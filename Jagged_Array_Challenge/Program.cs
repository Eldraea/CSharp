/*
Programs.cs
------------------------------------------------------------------------------------------------------------------------------------------------------
Created by Eldr@e@
-----------------------------------------------------------------------------------------------------------------------------------------------------
Create a jagged array which contains three "friends arrays", in which two family members should be stored.
Introduce family members from different families to each other via console (four introductions)
------------------------------------------------------------------------------------------------------------------------------------------------------
Created on: 27/07/2021
-----------------------------------------------------------------------------------------------------------------------------------------------------
Last Updated on: 27/07/2021
-----------------------------------------------------------------------------------------------------------------------------------------------------
 */

using System;

namespace Jagged_Array_Challenge
{
    class Program
    {

        public static String[][] creatingArrays()
        {
            String[][] myJaggedArray = new String[3][];
            myJaggedArray[0] = new string[]{ "Rosemary", "Myron"};
            myJaggedArray[1] = new string[] { "Mary", "Manuel" };
            myJaggedArray[2] = new string[] { "Jeremy", "Aurelie" };


            return myJaggedArray;
        }

        public static void introductions(String [][] myJaggedArray)
        {
            for (int i = 0; i < myJaggedArray.Length-1;i++)
            {
                for(int j=0; j <myJaggedArray[i].Length; j++)
                {
                    Console.WriteLine(myJaggedArray[i][j] + " has been introduced to " + myJaggedArray[i+1][j ]);
                }
            }
        }

        public static void run()
        {
            introductions(creatingArrays());
        }
        static void Main(string[] args)
        {
            run();
        }
    }
}
