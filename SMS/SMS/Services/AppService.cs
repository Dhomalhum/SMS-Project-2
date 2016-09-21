using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class AppService
    {
        public static UserType GetUserType()
        {
            //check user login type
            object type;
            App.Current.Properties.TryGetValue("userType", out type);
            if ((type == null) || type.ToString().Equals(UserType.Student.ToString("D"), StringComparison.OrdinalIgnoreCase))
            {
                return UserType.Student;
            }
            else
                return  UserType.Teacher;
        }
    }
}
