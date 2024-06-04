using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace DataAccess;

internal static class DbConfigurations
{
    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    string relativePath = @"Database\SalsaDb.db";
    string absolutePath = Path.Combine(baseDirectory, relativePath);

    // Create the SQLite connection string
    string sqliteConnectionString = $"Data Source={absolutePath};Version=3;";

    internal static string SalsaManagement2ConnectionString = "Data Source=.;Initial Catalog=SalsaManagment2;Integrated Security=True;Connect Timeout=30;Encrypt=False";
}