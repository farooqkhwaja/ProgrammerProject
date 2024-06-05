using System.Data.SqlClient;
using Dapper;
using DataAccess.Models;

namespace DataAccess.Dapper
{
    public class AttendanceRepository
    {
        public void AddAttendance(Attendance selectedAttendance)
        {
            using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
            {
                connection.Execute("INSERT INTO Attendance (Date,UserId) VALUES (@Date,@UserId)", new { Date = selectedAttendance.Date , UserId = selectedAttendance.UserId});
            }
        }
        public IEnumerable<Attendance> GetAttendanceByUserId(int Id)
        {
            using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
            {
                var query = $"SELECT Attendance.* FROM Attendance JOIN [User] ON Attendance.UserId = [User].Id WHERE [User].Id = {Id}";
                var result = connection.Query<Attendance>(query);
                return result;
            }
        }
        public List<Attendance> GetAttendanceList()
        {
            using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
            {
                var query = "SELECT * FROM Attendance";
                var result = connection.Query<Attendance>(query);
                return result.ToList();
            }

        }
        public List<(Attendance, string)> GetAttendanceWithCategoryList()
        {
            using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
            {
                var query = @"
            SELECT A.*, DC.CategoryName
            FROM Attendance A
            JOIN DanceCategory DC ON A.CategoryId = DC.Id";
                var result = connection.Query<Attendance, string, (Attendance, string)>(query,
                    (attendance, categoryName) => (attendance, categoryName),
                    splitOn: "CategoryName");
                return result.ToList();
            }
        }

    }
}
