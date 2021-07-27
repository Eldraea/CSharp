/*
 Program.cs
----------------------------------------------------------------------------------------------------------------------------------------------------
Created by Eldr@e@
----------------------------------------------------------------------------------------------------------------------------------------------------
Write a program that will iterate through each element of the students array and insert them into a hashtable.
If a student with the same ID already exists in the hashtable skip it and display the followinf error: "Sorry, a sutent with the same ID already exists"
Hint: Use the method ContainsKey() to check whether a student with the same ID already exists.
--------------------------------------------------------------------------------------------------------------------------------------------------------
Created on: 27/07/2021
--------------------------------------------------------------------------------------------------------------------------------------------------------
Last Updated on: 27/07/2021
--------------------------------------------------------------------------------------------------------------------------------------------------------
 */

using System;
using System.Collections;

namespace HashTable_Challenge
{
    class Program
    {
        public static Student[] myArrayOfStudents()
        {
            Student[] myStudents = new Student[5];
            myStudents[0] = new Student(1, "Denis", 88);
            myStudents[1] = new Student(2, "Olaf", 97);
            myStudents[2] = new Student(6, "Ragner", 65);
            myStudents[3] = new Student(1, "Luise", 73);
            myStudents[4] = new Student(4, "Levi", 58);

            return myStudents;
        }

        public static Hashtable  myHashTable()
        {
            Hashtable students = new Hashtable();

            foreach (Student student in myArrayOfStudents())
            {
                if (!students.ContainsKey((student.getId())))
                    students.Add(student.getId(), student);
                else
                    Console.WriteLine("Sorry, a sudent with the same id already exists");
            }

            return students;

        }

        public static void printMyHashTable()
        {

            foreach( DictionaryEntry student in ( myHashTable()))
            {
                Student temp = (Student)student.Value;
                Console.WriteLine(temp.getId());
                Console.WriteLine(temp.getName());
                Console.WriteLine(temp.getGPA());
            }
        }

        public static void run()
        {
            printMyHashTable();
        }

        static void Main(string[] args)
        {

            run();

        }
    }
}
