using Dapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Dapper
{
    public class LinksRepository
    {
        private string _connectionString = "Data Source=.;Initial Catalog=SalsaManagment2;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public CreateLinksModel CreateLink(Links uploadLink)
        {
            CreateLinksModel model = new CreateLinksModel();
            string query = "INSERT INTO Links (Url, CreatedBy) VALUES (@Url, @CreatedBy)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    connection.Execute(query, uploadLink);
                    model.succesful = true;
                }
                catch (Exception ex)
                {
                    model.succesful = false;
                    model.msg = "Link did not added. " + ex.Message;
                }
            }
            return model;
        }

        public List<Links> GetLinks()
        {
            string query = "SELECT * FROM Links";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Links>(query).ToList();
                return result;
            }
        }

        public Links GetLink(int id)
        {
            string query = "SELECT * FROM Links WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.QueryFirstOrDefault<Links>(query, new { Id = id });
                return result;
            }
        }

        public void UpdateLinks(Links uploadlink)
        {
            string query = "UPDATE Links SET Url = @Url WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query, uploadlink);
            }
        }

        public void DeleteLink(int linkId)
        {
            string query = "DELETE FROM Links WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query, new { Id = linkId });
            }
        }
    }
}
