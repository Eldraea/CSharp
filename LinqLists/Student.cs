using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLists
{
    public class Student
    {

        private int id;
        private String name;
        private String gender;
        private int age;
        //foreign key
        private int universityId;


        public Student( int id, String name, String gender, int age, int universityId)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.universityId = universityId;
        }
        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }
         
        public String getName()
        {
            return this.name;
        }


        public void setName(String name)
        {
            this.name = name;
        }

        public String getGender()
        {
            return this.gender;
        }

        public void setGender(String gender)
        {
            this.gender = gender;
        }

        public int getAge()
        {
            return this.age;
        }

        public void setAge(int age)
        {
            this.age = age;
        }

        public int getUniversityId()
        {
            return universityId;
        }

        public void setUniversityId(int universityId)
        {
            this.universityId = universityId;
        }

        public void print()
        {
            Console.WriteLine("Student: " + getName());
            Console.WriteLine("ID: " + getId());
            Console.WriteLine("Gender: " + getGender());
            Console.WriteLine("Age: " + getAge());
            Console.WriteLine("UniversityId: " + getUniversityId());
        }
    }

}
