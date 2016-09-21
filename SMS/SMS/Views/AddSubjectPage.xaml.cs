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
    public partial class AddSubjectPage : ContentPage
    {
        private DatabaseService _db;
        public AddSubjectPage()
        {
            InitializeComponent();
            _db = new DatabaseService();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            SaveData();
            await Navigation.PushAsync(new ViewSubjectsPage());
        }

        private void SaveData()
        {
            _db.AddSubject(codeEntry.Text, nameEntry.Text);
        }

    }
}
