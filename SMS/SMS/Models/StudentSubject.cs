using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace SMS.Models
{
    [Table("StudentSubject")]
    public class StudentSubject
    {
        [ForeignKey(typeof(Student))]
        public int StudentId { get; set; }

        [ForeignKey(typeof(Subject))]
        public string SubjectCode { get; set; }
    }
}
