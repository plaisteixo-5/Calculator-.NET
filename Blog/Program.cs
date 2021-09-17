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
            DeleteUser();
            connection.Close();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get();

            foreach (var user in users) Console.WriteLine(user.Name);
        }
        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);

                Console.WriteLine(user.Name);
            }
        }
        public static void CreateUser()
        {

            var user = new User()
            {
                Bio = "Equipa Balta.io",
                Email = "hello@balta.io",
                Image = "https://...",
                Name = "Equipe balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var valueReturned = connection.Insert<User>(user);

                Console.WriteLine(valueReturned);
            }
        }
        public static void UpdateUser()
        {

            var user = new User()
            {
                Id = 2,
                Bio = "Equipa | Balta.io",
                Email = "hello@balta.io",
                Image = "https://...",
                Name = "Equipe de suporte balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var valueReturned = connection.Update<User>(user);

                Console.WriteLine(valueReturned);
            }
        }
        public static void DeleteUser()
        {

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                var valueReturned = connection.Delete<User>(user);

                Console.WriteLine(valueReturned);
            }
        }
    }
}
