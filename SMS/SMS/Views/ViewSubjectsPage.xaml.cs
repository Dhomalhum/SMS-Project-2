using SMS.Models;
using SMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SMS.Views
{
    public partial class ViewSubjectsPage : ContentPage
    {
        private int _studentId;
        private UserType _userType;

        public ViewSubjectsPage(int studentId = 0)
        {
            InitializeComponent();
            _userType = AppService.GetUserType();
            //if _studentId = 0 then display all subjects else display only subject that student study
            _studentId = studentId;

            InitData();
        }

        private void InitData()
        {
            var db = new DatabaseService();
            List<Subject> subjects;

            //if _studentId = 0 then display all subjects else display only subject that student study
            if (_studentId != 0)
            {
                subjects = db.GetStudent(_studentId).Subjects;
                var ss = db.GetAllStudentSubject();
            }
            else
                subjects = db.GetAllSubjects();

            if (subjects == null)
                subjects = new List<Subject>();

            ObservableCollection<Subject> subjectList = new ObservableCollection<Subject>();

            foreach (var s in subjects)
                subjectList.Add(s);

            subjectListView.ItemsSource = subjectList;

            //hide add button if the user is a student
            if ( (_userType == UserType.Student) || (_studentId != 0) )
                addSubjectBtn.IsVisible = false;
        }

        private async void OnItemTapped(object sender, EventArgs e)
        {
            if (_userType == UserType.Teacher)
            {
                await Navigation.PushAsync( new SubjectPage( ((Subject)subjectListView.SelectedItem).Code ));
            }
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSubjectPage());
        }
    }
}