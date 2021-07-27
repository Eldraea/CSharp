using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_Challenge
{
    public class Student
    {
        private int id;
        private String name;
        private int GPA;


        public Student(int id, String name, int GPA)
        {
            this.id = id;
            this.name = name;
            this.GPA = GPA;
        }

        public int getId()
        {
            return this.id;
        }

        public String getName()
        {
            return this.name;
        }

        public int getGPA()
        {
            return this.GPA;
        }

        public void setId(int value)
        {
            this.id = value;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void setGPA(int value)
        {
            this.GPA = value;
        }


    }
}
