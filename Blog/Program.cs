using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433; Database=BLog; User Id=sa; Password=1q2w3e4r@#$";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            var post = new Post()
            {
                CategoryId = 1,
                AuthorId = 1,
                Title = "Teste",
                Summary = "Testando",
                Body = "Corpo de teste",
                Slug = "slug-teste",
                CreateDate = new DateTime(2020, 9, 18),
                LastUpdateDate = new DateTime(2020, 9, 18)
            };

            Controller.ReadPostWithTag(connection);
            connection.Close();
        }
    }
}
