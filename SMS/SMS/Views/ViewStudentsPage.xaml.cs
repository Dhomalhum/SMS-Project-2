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
    public partial class ViewStudentsPage : ContentPage
    {
        public ViewStudentsPage()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            var db = new DatabaseService();
            var students = db.GetAllStudents();
            ObservableCollection<Student> studentList = new ObservableCollection<Student>();

            foreach (var s in students)
                studentList.Add(s);

            studentListView.ItemsSource = studentList;
        }

        async void OnItemTapped(object sender, EventArgs e)
        {
            var student = (Student)studentListView.SelectedItem;
            await Navigation.PushAsync( new StudentPage(student.Id) );
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddStudentPage());
        }

    }
}
