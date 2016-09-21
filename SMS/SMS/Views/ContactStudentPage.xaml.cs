using SMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SMS.Views
{
    public partial class ContactStudentPage : ContentPage
    {
        private int _studentId;
        private DatabaseService _db;

        public ContactStudentPage(int studentId)
        {
            InitializeComponent();
            _db = new DatabaseService();
            _studentId = studentId;
            InitData(_studentId);
        }

        private void InitData(int studentId)
        {
            var student = _db.GetStudent(studentId);
            studentIdLbl.Text = student.Id.ToString();
            firstNameLbl.Text = student.FirstName;
            lastNameLbl.Text = student.FirstName;
            phoneLbl.Text = student.Phone;
            emailLbl.Text = student.Email;
        }

        private void OnSMSClicked(object sender, EventArgs e)
        {
            RestService.SendSMS(new List<string> { phoneLbl.Text}, contentEditor.Text);
            messageLbl.Text = "SMS sent";
        }

        private async void OnEmailClicked(object sender, EventArgs e)
        {
            RestService.SendEmail("SMS notification", emailLbl.Text, contentEditor.Text);
            messageLbl.Text = "Email sent";
        }
    }
}