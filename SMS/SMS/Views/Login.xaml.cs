using SMS.Models;
using SMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SMS.Views
{
    public partial class Login : ContentPage
    {
        private DatabaseService _db;
        public Login()
        {
            InitializeComponent();
            _db = new DatabaseService();
            var students = _db.GetAllStudents();
        }

        async void OnLogin(object sender, EventArgs e)
        {
            var result = _db.Validate(usernameEntry.Text, passwordEntry.Text);
            if (result)
            {
                //save user information in app properties to use in other pages
                //https://developer.xamarin.com/guides/xamarin-forms/working-with/application-class/#Properties_Dictionary
                var user = _db.GetUser(usernameEntry.Text);
                Application.Current.Properties["username"] = usernameEntry.Text;
                Application.Current.Properties["userType"] = user.Type;

                if (user.Type == (int)UserType.Student)
                    await Navigation.PushAsync(new StudentMainPage());
                else
                    await Navigation.PushAsync(new TeacherMainPage());
            }
            else
                messageLabel.Text = "Invalid credentials";                
        }
    }
}