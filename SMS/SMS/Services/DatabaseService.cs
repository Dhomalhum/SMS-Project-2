using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using SMS.Models;
using Xamarin.Forms;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;

namespace SMS.Services
{
    public class DatabaseService
    {
        private SQLiteConnection _db;

        public DatabaseService()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            _db.CreateTable<User>();
            _db.CreateTable<Student>();
            _db.CreateTable<Subject>();
            _db.CreateTable<StudentSubject>();

            if (_db.Table<User>().Count() == 0)
                CreateDatabase();
        }

        public void CreateDatabase()
        {

            // insert an admin user
            var user = new User() { Username = "admin", Password = "123456", Type = 1 };
            _db.Insert(user);

            user = new User() { Username = "mohamed@gmail.com", Password = "123456", Type = 2 };
            _db.Insert(user);

            // insert some students
            var student = new Student() { FirstName = "Mohamed", LastName = "Alhi", Country = "Saudi Arabia", DOB = new DateTime(1993, 1, 1), Email = "mohamed@gmail.com", Phone = "012345678" };
            _db.Insert(student);
            student = new Student() { FirstName = "Jack", LastName = "Smith", Country = "Australia", DOB = new DateTime(1992, 2, 2), Email = "jack@gmail.com", Phone = "012345678" };
            _db.Insert(student);
            student = new Student() { FirstName = "John", LastName = "Smith", Country = "Australia", DOB = new DateTime(1993, 3, 3), Email = "john@gmail.com", Phone = "0400000000" };
            _db.Insert(student);

            var subject = new Subject() { Code = "001", Name = "Programming" };
            _db.Insert(subject);

            subject = new Subject() { Code = "002", Name = "Database" };
            _db.Insert(subject);

            subject = new Subject() { Code = "003", Name = "Web" };
            _db.Insert(subject);

        }

        public bool Validate(string username, string password)
        {
            //check if user and password are valid.
            return _db.Table<User>().Where(x => x.Username == username && x.Password == password).Count() > 0;
        }

        public User GetUser(string username)
        {
            return _db.Table<User>().FirstOrDefault(x => x.Username == username);
        }

        public void AddStudent(string firstname, string lastname, string country, DateTime DOB)
        {
            var student = new Student() { FirstName = firstname, LastName = lastname, Country = country, DOB = DOB };
            _db.Insert(student);
        }

        public void AddStudent(Student student)
        {
            _db.Insert(student);
        }

        public void UpdateStudent(Student s)
        {
            _db.Update(s, typeof(Student));
        }

        public Student GetStudent(int id)
        {
            return _db.GetAllWithChildren<Student>().Where(x => x.Id == id).FirstOrDefault();
        }

        public Student GetStudent(string email)
        {
            return _db.GetAllWithChildren<Student>().FirstOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public List<Student> GetAllStudents()
        {
            return _db.GetAllWithChildren<Student>().ToList(); ;
        }

        public void AddSubject(string code, string name)
        {
            var subject = new Subject() { Code = code, Name = name };
            _db.Insert(subject);
        }

        public List<Subject> GetAllSubjects()
        {
            return _db.GetAllWithChildren<Subject>().ToList(); ;
        }

        public Subject GetSubject(string code)
        {
            return _db.GetAllWithChildren<Subject>().FirstOrDefault(x => x.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
        }

        public void UpdateSubject(Subject s)
        {
            _db.Update(s, typeof(Subject));
        }

        public void AddStudentSubject(int studentId, string code)
        {
            var ss = new StudentSubject { StudentId = studentId, SubjectCode = code };
            _db.Insert(ss);
        }

        public List<StudentSubject> GetAllStudentSubject()
        {
            return _db.GetAllWithChildren<StudentSubject>().ToList();
        }
    }
}
