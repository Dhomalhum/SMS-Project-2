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
    public partial class AddStudentSubjectPage : ContentPage
    {
        private int _studentId;
        private DatabaseService _db;
        private List<Subject> _subjects;

        public AddStudentSubjectPage(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
            _db = new DatabaseService();
            InitData(_studentId);
        }

        private void InitData(int studentId)
        {
            var student = _db.GetStudent(studentId);
            firstNameLbl.Text = student.FirstName;
            lastNameLbl.Text = student.FirstName;
           _subjects = _db.GetAllSubjects();
            foreach (var s in _subjects)
                if ( (student.Subjects == null) || !student.Subjects.Contains(s) )
                    subjectsPicker.Items.Add(s.FullName);
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            var subject = _subjects[subjectsPicker.SelectedIndex];
            _db.AddStudentSubject(_studentId, subject.Code);

            messageLbl.Text = "Subject added";
        }

    }
}
