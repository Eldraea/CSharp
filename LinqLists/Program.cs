using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqLists
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentsXML =
                @"<Students>
                    <Student>
                        <Name>Theïa</Name>
                        <Age>21</Age>
                        <Gender>Female</Gender>
                        <University>Harvard</University>
                    </Student>
                    <Student>
                        <Name>Kane</Name>
                        <Age>19</Age>
                        <Gender>Male</Gender>
                        <University>MIT</University>
                    </Student>
                    <Student>
                        <Name>Arisa</Name>
                        <Age>22</Age>
                        <Gender>Trans-Gender</Gender>
                        <University>NYU</University>
                    </Student>
                    <Student>
                        <Name>Freya</Name>
                        <Age>24</Age>
                        <Gender>Female</Gender>
                        <University>MIT</University>
                    </Student>
                    <Student>
                        <Name>Léon</Name>
                        <Age>21</Age>
                        <Gender>Male</Gender>
                        <University>NYU</University>
                    </Student>
                    <Student>
                        <Name>Jake.L</Name>
                        <Age>17</Age>
                        <Gender>Trans-Gender</Gender>
                        <University>Harvard</University>
                    </Student>
                    <Student>
                        <Name>Isobel</Name>
                        <Age>28</Age>
                        <Gender>Female</Gender>
                        <University>NYU</University>
                    </Student>
                    <Student>
                        <Name>Gengis-Khan</Name>
                        <Age>26</Age>
                        <Gender>Male</Gender>
                        <University>Harvard</University>
                    </Student>
                    <Student>
                        <Name>Guan-Yu</Name>
                        <Age>21</Age>
                        <Gender>Trans-Gender</Gender>
                        <University>MIT</University>
                    </Student>
                </Students>
                ";
            UniversityManager universityManager = new UniversityManager();

            Console.WriteLine("Male Students:");
            universityManager.maleStudents();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Female Students:");
            universityManager.femaleStudents();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Trans-Gender Students:");
            universityManager.transGenderStudents();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Students ordered by age:");
            universityManager.sortStudentsByAge();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Students from Beijing Tech: ");
            universityManager.allStudentsFromBeijingTech();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Students from Yale");
            universityManager.allStudentsFromThatId(1);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Students order by age descending: ");
            universityManager.sortStudentsByAgeDescending();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("New Collection: ");
            universityManager.studentsAndUniversitiesNewCollection();

            XDocument studentsXdoc = new XDocument();
            studentsXdoc = XDocument.Parse(studentsXML);

            var studentList = from student in studentsXdoc.Descendants("Student")
                              select new
                              {
                                  Name = student.Element("Name").Value,
                                  Age = student.Element("Age").Value,
                                  Gender = student.Element("Gender").Value,
                                  University = student.Element("University").Value
                              };
            var studentListOrdered = from student in studentList orderby student.Age descending select student;

            foreach(var entry in studentListOrdered)
            {
                Console.WriteLine("Student: " + entry.Name);
                Console.WriteLine("Age: " + entry.Age);
                Console.WriteLine("Gender: " + entry.Gender);
                Console.WriteLine("University: " + entry.University);
            }



            Console.ReadKey();
        }
    }
}
