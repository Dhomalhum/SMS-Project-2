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
    public partial class AddStudentPage : ContentPage
    {
        private DatabaseService _db;

        public AddStudentPage()
        {
            InitializeComponent();
            _db = new DatabaseService();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            SaveData();
            await Navigation.PushAsync(new ViewStudentsPage());
        }

        private void SaveData()
        {
            var student = new Student();
            student.FirstName = firstNameEntry.Text;
            student.LastName = lastNameEntry.Text;
            student.DOB = DateTime.Parse(DOBEntry.Text);
            student.Country= countryEntry.Text;
            student.Phone = phoneEntry.Text;
            student.Email = emailEntry.Text;

            _db.AddStudent(student);
        }
    }
}