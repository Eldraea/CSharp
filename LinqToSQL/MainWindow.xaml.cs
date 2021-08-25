using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSQLDataClassesDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();

            String connectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.MyDataBaseConnectionString"].ConnectionString;
            dataContext = new LinqToSQLDataClassesDataContext(connectionString);
            //insertUniversities();
            //insertStudents();
            //insertLectures();
            //insertStudentLectureAssociation();
            //getFreyaUniversity();
            //getFreyaLectures();
            //getAllStudentFromYale();
            //getAllUniversitiesWithTransGender();
            //updateFreya();
            getAllLecturesTaughtInMIT();
            //deleteGengisKhan();
        }

        public void insertUniversities()
        {
            dataContext.ExecuteCommand("DELETE FROM University");
            University yale = new University();
            University harvard = new University();
            University mit = new University();
            yale.Name = "Yale";
            harvard.Name = "Harvard";
            mit.Name = "MIT";
            dataContext.Universities.InsertOnSubmit(yale);
            dataContext.Universities.InsertOnSubmit(harvard);
            dataContext.Universities.InsertOnSubmit(mit);

            dataContext.SubmitChanges();

            
        }

        public void insertStudents()
        {
            dataContext.ExecuteCommand("DELETE FROM Student");

            University yale = dataContext.Universities.First(un => un.Name.Equals("Yale"));
            University harvard = dataContext.Universities.First(un => un.Name.Equals("Harvard"));
            University mit = dataContext.Universities.First(un => un.Name.Equals("MIT"));
            Student freya = new Student() { Name = "Freya", Gender = "Female", University = yale };
            Student meifang = new Student() { Name = "Gengis-Khan", Gender = "Male", University = harvard };
            Student gengiskhan = new Student() { Name = "Mei-Fang", Gender = "Trans-Gender", University = mit };

            dataContext.Students.InsertOnSubmit(freya);
            dataContext.Students.InsertOnSubmit(gengiskhan);
            dataContext.Students.InsertOnSubmit(meifang);

            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Students;

            
        }

        public void insertLectures()
        {
            dataContext.Lectures.InsertOnSubmit(new Lecture() { Name = "Mathematics" });
            dataContext.Lectures.InsertOnSubmit(new Lecture() { Name = "Litterature" });
            dataContext.Lectures.InsertOnSubmit(new Lecture(){ Name = "History" });

            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Lectures;
        }

        public void insertStudentLectureAssociation()
        {
            Student freya = dataContext.Students.First(un => un.Name.Equals("Freya"));
            Student gengiskhan = dataContext.Students.First(un => un.Name.Equals("Gengis-Khan"));
            Student meifang = dataContext.Students.First(un => un.Name.Equals("Mei-Fang"));

            Lecture math = dataContext.Lectures.First(un => un.Name.Equals("Mathematics"));
            Lecture litterature = dataContext.Lectures.First(un => un.Name.Equals("Litterature"));
            Lecture history = dataContext.Lectures.First(un => un.Name.Equals("History"));

            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture() { Student = freya, Lecture = math });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture() { Student = freya, Lecture = litterature });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture() { Student = freya, Lecture = history });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture() { Student = meifang, Lecture = math });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture() { Student = meifang, Lecture = history });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture() { Student = gengiskhan, Lecture = litterature });

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.StudentLectures;


            
        }

        public void getFreyaUniversity()
        {
            Student freya = dataContext.Students.First(un => un.Name.Equals("Freya"));
            University freyaUniversity = freya.University;

            List<University> universities = new List<University>();
            universities.Add(freyaUniversity);

            MainDataGrid.ItemsSource = universities;


        }

        public void getFreyaLectures()
        {
            Student freya = dataContext.Students.First(un => un.Name.Equals("Freya"));
            var freyaLecture = from studentlecture in freya.StudentLectures select studentlecture.Lecture;

            MainDataGrid.ItemsSource = freyaLecture;
        }

        public void getAllStudentFromYale()
        {
            var students = from student in dataContext.Students where student.University.Name == "Yale" select student;
            MainDataGrid.ItemsSource = students;
        }

        public void getAllUniversitiesWithTransGender()
        {
            var transgenderStudents = from student in dataContext.Students join university in dataContext.Universities on student.UniversityId equals university.Id where student.Gender == "Trans-Gender" select university;
            MainDataGrid.ItemsSource = transgenderStudents;
        }

        public void getAllLecturesTaughtInMIT()
        {
            var mitLectures = from studentLecture in dataContext.StudentLectures
                              join lecture in dataContext.Lectures on studentLecture.Lecture equals lecture
                              join student in dataContext.Students on studentLecture.Student equals student
                              where student.University.Name == "MIT"
                              select lecture;
            MainDataGrid.ItemsSource = mitLectures;
        }

        public void updateFreya()
        {
            Student freya = dataContext.Students.FirstOrDefault(un => un.Name.Equals("Freya"));
            freya.Name = "Arisa";

            dataContext.SubmitChanges();

        }

        public void deleteGengisKhan()
        {
            Student gengiskhan = dataContext.Students.FirstOrDefault(un => un.Name.Equals("Gengis-Khan"));
            dataContext.Students.DeleteOnSubmit(gengiskhan);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }
    }
}
