using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLite.Net.Attributes;

namespace SMS.Models
{
    [Table("Student")]
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //Many to many relationship: https://bitbucket.org/twincoders/sqlite-net-extensions
        [ManyToMany(typeof(StudentSubject))]
        public List<Subject> Subjects { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}