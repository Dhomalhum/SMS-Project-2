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
    public partial class SubjectPage : ContentPage
    {
        private DatabaseService _db;
        private string _code;

        public SubjectPage( string code )
        {
            InitializeComponent();
            _db = new DatabaseService();
            _code = code;
            InitData(_code);
        }

        private void InitData(string _code)
        {
            var subject = _db.GetSubject(_code);
            codeLbl.Text = subject.Code;
            nameEntry.Text = subject.Name;
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            SaveData();
            await Navigation.PushAsync(new ViewSubjectsPage());
        }

        private void SaveData()
        {
            Subject s = new Subject() { Code = _code, Name = nameEntry.Text };
            _db.UpdateSubject(s);
        }

    }
}
