using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLists
{
    public class UniversityManager
    {
        private List<University> universityList;
        private List<Student> studentList;

        public UniversityManager()
        {
            universityList = new List<University>();
            studentList = new List<Student>();

            //Let's add some universities
            universityList.Add(new University(1, "Yale"));
            universityList.Add(new University(2, "Beijing Tech"));

            //Let's add some students
            studentList.Add(new Student(1, "Carla", "Female", 17, 1));
            studentList.Add(new Student(2, "Tony", "Male", 21, 1));
            studentList.Add(new Student(3, "Leïa", "Female", 19, 2));
            studentList.Add(new Student(4, "James", "Trans-Gender", 25, 2));
            studentList.Add(new Student(5, "Linda", "Female", 22, 2));
        }


        public List<University> getUniversityList()
        {
            return this.universityList;
        }

        public List<Student> getStudentList()
        {
            return this.studentList;
        }

        public void maleStudents()
        {
            IEnumerable<Student> maleStudents = from student in studentList where student.getGender() == "Male" select student;
            foreach( Student student in maleStudents)
            {
                student.print();
            }
        }

        public void femaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in studentList where student.getGender() == "Female" select student;
            foreach (Student student in femaleStudents)
            {
                student.print();
            }
        }

        public void transGenderStudents()
        {
            IEnumerable<Student> transGenderStudents = from student in studentList where student.getGender() == "Trans-Gender" select student;
            foreach (Student student in transGenderStudents)
            {
                student.print();
            }
        }

        public void sortStudentsByAge()
        {
            var studentsByAge = from student in studentList orderby student.getAge() select student;
            foreach (Student student in studentsByAge)
            {
                student.print();
            }
        }

        public void allStudentsFromBeijingTech()
        {
            var studentsFromBeijingTech = from student in studentList join university in universityList on student.getUniversityId() equals university.getId() where university.getName()== "Beijing Tech" select student;
            foreach (Student student in studentsFromBeijingTech)
            {
                student.print();
            }
        }

        public void allStudentsFromThatId(int id)
        {
            var studentsFromThatUni = from student in studentList join university in universityList on student.getUniversityId() equals university.getId() where university.getId() == id select student;
            foreach (Student student in studentsFromThatUni)
            {
                student.print();
            }
        }

        public void sortStudentsByAgeDescending()
        {
            var studentsByAgeDescending = from student in studentList orderby student.getAge() descending select student;
            foreach(Student student in studentsByAgeDescending)
            {
                student.print();
            }
        }

        public void studentsAndUniversitiesNewCollection()
        {
            var newCollection = from student in studentList join university in universityList on student.getUniversityId() equals university.getId() select new { StudentName = student.getName(), UniversityName = university.getName() };
            foreach (var entry in newCollection)
            {
                Console.WriteLine(entry.StudentName + " is in " + entry.UniversityName);
            }
        }


    }
}
