using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net;

namespace SMS.Models
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}