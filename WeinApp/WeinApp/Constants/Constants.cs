using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeinApp.Services
{
    public static class Constants
    {
        public const string DatabaseFilename = "WeinApp.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

        public static string Username = "user";
        public static string Password = "password";
    }
}