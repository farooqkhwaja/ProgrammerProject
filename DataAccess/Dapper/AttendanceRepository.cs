using System.Data.SqlClient;
using Dapper;
using DataAccess.Models;

namespace DataAccess.Dapper
{
    public class AttendanceRepository
    {
        public void AddAttendance(Attendance attendance)
        {
            using(var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
            {
                connection.Open();
                connection.Execute("Insert Into Attendance (Date, Absent, UserId) Values(@Date, @Absent, @UserId)", attendance);
                connection.Close();
            }
        }
    }
}
