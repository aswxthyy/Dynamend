﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamend.Desktop.Data
{
    internal class DataContext
    {
        private readonly SQLiteConnection _connection;
        private readonly string _dbName = "data.db";
        private readonly string _systemAppDataPah = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private readonly string _appDataPath;
        private readonly string _dbPath;
        public DataContext()
        {
            _appDataPath = Path.Combine(_systemAppDataPah, "Dynamend");
            _dbPath = Path.Combine(_appDataPath, _dbName);

            Directory.CreateDirectory(_appDataPath);
            _connection = new SQLiteConnection($"Data Source={_dbPath}");
        }

        public SQLiteConnection GetConnection()
        {
            if(_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }
    }
}
