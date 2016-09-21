using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SMS.Models;
using System.IO;
using SQLite.Net;
using Xamarin.Forms;
using SMS.Droid.Models;

[assembly: Dependency(typeof(SQLite_Android))]
namespace SMS.Droid.Models
{
    public class SQLite_Android : ISQLite
    {
        /// <summary>
        /// Gets the connection for Android. More information can be found here
        //ref:https://developer.xamarin.com/guides/xamarin-forms/working-with/databases/
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection GetConnection()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SMS_db_1");
            // Create the connection
            var conn = new SQLiteConnection(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), path);
            // Return the database connection
            return conn;
        }
    }
}