using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SMS.Views
{
    public partial class TeacherMainPage : ContentPage
    {
        public TeacherMainPage()
        {
            InitializeComponent();
        }

        async void OnViewStudentsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync( new ViewStudentsPage());
        }

        async void OnViewSubjectsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewSubjectsPage());
        }

        async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}
