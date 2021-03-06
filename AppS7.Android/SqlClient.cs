using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using AppS7.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SqlClient))]
namespace AppS7.Droid
{
    class SqlClient : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documetPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }

    }
}