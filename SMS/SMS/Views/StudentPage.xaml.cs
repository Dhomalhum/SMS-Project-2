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
    public partial class StudentPage : ContentPage
    {
        private DatabaseService _db;
        private int _studentId;
        private UserType _userType;

        public StudentPage(int studentId)
        {
            InitializeComponent();
            _db = new DatabaseService();
            _studentId = studentId;
            InitData(_studentId);

            _userType = AppService.GetUserType();
            if (_userType == UserType.Student)
            {
                contactBtn.IsVisible = false;
                enrollBtn.IsVisible = false;
            }
        }

        private void InitData(int studentId)
        {
            var student = _db.GetStudent(studentId);
            studentIdLbl.Text = student.Id.ToString();
            firstNameEntry.Text = student.FirstName.ToString();
            lastNameEntry.Text = student.LastName.ToString();
            DOBEntry.Text = student.DOB.ToString("yyyy-MM-dd");
            countryEntry.Text = student.Country.ToString();
            phoneEntry.Text = student.Phone.ToString();
            emailEntry.Text = student.Email.ToString();
        }

        void OnUpdateClicked(object sender, EventArgs e)
        {
            SaveData(_studentId);
            messageLbl.Text = "Student is successfully updated";
        }

        private void SaveData(int studentId)
        {
            var student = _db.GetStudent(studentId);
            student.FirstName = firstNameEntry.Text;
            student.LastName = lastNameEntry.Text;
            student.DOB = DateTime.Parse(DOBEntry.Text);
            student.Country= countryEntry.Text;
            student.Phone = phoneEntry.Text;
            student.Email = emailEntry.Text;

            _db.UpdateStudent(student);
        }

        async void OnViewSubjectsClicked(object sender, EventArgs e)
        {
            //display subjects that a student studies
            await Navigation.PushAsync(new ViewSubjectsPage(_studentId));
        }

        async void OnEnrollSubjectsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddStudentSubjectPage(_studentId));
        }

        async void OnContactClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactStudentPage(_studentId));
        }
    }
}
