using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace DataAccess;

internal static class DbConfigurations
{/*
    static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    static string relativePath = @"Database\SalsaDb.db";
    static string absolutePath = Path.Combine(baseDirectory, relativePath);*/

    //internal static string SalsaManagement2ConnectionString = $"Data Source={absolutePath};";

    internal static string SalsaManagement2ConnectionString = "Data Source=.;Initial Catalog=SalsaManagment2;Integrated Security=True;Connect Timeout=30;Encrypt=False";
}