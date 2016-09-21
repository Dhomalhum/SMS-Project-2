using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;

namespace SMS.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(100)]
        public int Type { get; set; } //1: teacher, 2: student
    }
}
