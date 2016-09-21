using SMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SMS.Views
{
    public partial class StudentMainPage : ContentPage
    {
        private DatabaseService _db;
        public StudentMainPage()
        {
            InitializeComponent();
            _db = new DatabaseService();
        }

        private async void OnViewDetailsClicked(object sender, EventArgs e)
        {
            object data;
            App.Current.Properties.TryGetValue("username", out data);
            var username = data.ToString();
            var student = _db.GetStudent(username);

            await Navigation.PushAsync(new StudentPage(student.Id));
        }

        private async void OnViewSubjectsClicked(object sender, EventArgs e)
        {
            object data;
            App.Current.Properties.TryGetValue("username", out data);
            var username = data.ToString();
            var student = _db.GetStudent(username);

            await Navigation.PushAsync(new ViewSubjectsPage(student.Id));
        }

        async void LogoutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync( new Login() );
        }
    }
}
