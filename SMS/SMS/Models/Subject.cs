using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace SMS.Models
{
    [Table("Subject")]
    public class Subject
    {
        [PrimaryKey]
        [MaxLength(100)]
        public string Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [ManyToMany(typeof(StudentSubject))]
        public List<Student> Students { get; set; }

        public string FullName { get { return Code + " " + Name; } }
    }
}
