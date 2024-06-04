using Dapper;
using DataAccess.Models;
using System.Data.SqlClient;

namespace DataAccess.Dapper
{
    public class UserAttendanceRepository
    {
        public void AddUserAttendance(UserAttendance userattendance)
        {
            using (SqlConnection con = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
            {
                con.Open();
                string query = "INSERT INTO UserAttendance(UserId, AttendanceId) VALUES(@UserId, @AttendanceId)"; 
                con.Execute(query, new { userattendance.UserId, userattendance.AttendanceId });
            }
        }
        public List<UserAttendance> GetAllAttendances()
        {
            using (SqlConnection con = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
            {
                var query = "Select * from UserAttendance";
                con.Open();
                var userattendance = con.Query<UserAttendance>(query).ToList();
                return userattendance;
            }
        }
        public IEnumerable<Attendance> GetAttendancesByUserId(int userId)
        {
            using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
            {
                string sql = @"
                SELECT a.*, u.*
                FROM Attendance a
                INNER JOIN Users u ON a.UserId = u.Id
                WHERE a.UserId = @UserId";

                var attendances = connection.Query<Attendance, User, Attendance>(
                    sql,
                    (attendance, user) =>
                    {
                        attendance.User = user;
                        return attendance;
                    },
                    new { UserId = userId },
                    splitOn: "Id"
                );

                return attendances;
            }
        }


    }
}
