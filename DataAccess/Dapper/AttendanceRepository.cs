using System;
using System.Data.SqlClient;
using Dapper;
using DataAccess.Models;

namespace DataAccess.Dapper
{
    public class AttendanceRepository
    {
        private string _connectionString = "Data Source=.;Initial Catalog=SalsaManagment2;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public AttendanceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddAttendance(Attendance attendance)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("Insert Into Attendance (Date, Absent, UserId) Values(@Date, @Absent, @UserId)",attendance);
                connection.Close();
            }
        }
    }
}
