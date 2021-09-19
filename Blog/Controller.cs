using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{

    public class Controller
    {

        // User
        // ============================================================================
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine($"Nome: {item.Name}");
                Console.WriteLine($"Email: {item.Email}");
                Console.WriteLine("################################");
            }
        }
        public static void ReadUsers(SqlConnection connection, int id)
        {
            var repository = new Repository<User>(connection);
            var item = repository.Get(id);

            Console.WriteLine($"Nome: {item.Name}");
            Console.WriteLine($"Email: {item.Email}");
        }
        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine($"Nome: {item.Name}");
                Console.WriteLine($"Email: {item.Email}");
                Console.Write("Perfil: ");

                int listRoleSize = item.Roles.Count;
                for (int i = 0; i < listRoleSize; i++)
                {
                    if (i == listRoleSize - 1) Console.WriteLine($"{item.Roles[i].Name}");
                    else Console.Write($"{item.Roles[i].Name}, ");
                }
                Console.WriteLine("################################");

            }
        }
        public static void CreateUser(SqlConnection connection, User user)
        {
            var repository = new Repository<User>(connection);
            repository.Create(user);
        }

        // Category
        // ============================================================================
        public static void ReadCategory(SqlConnection connection, int id = 0)
        {
            var repository = new Repository<Category>(connection);

            if (id != 0)
            {
                var item = repository.Get(id);
                Console.WriteLine($"{item.Name}");
            }
            else
            {
                var items = repository.Get();

                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Name}");
                }
            }
        }
        public static void CreateCategory(SqlConnection connection, Category category)
        {
            var repository = new Repository<Category>(connection);

            try
            {
                repository.Create(category);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Post
        // ============================================================================
        public static void ReadPosts(SqlConnection connection)
        {
            var repository = new Repository<Post>(connection);
            var categoryRepository = new Repository<Category>(connection);
            var posts = repository.Get();

            foreach (var post in posts)
            {
                Console.WriteLine($"\t - Post Title: {post.Title}");
                Console.WriteLine($"\t - Categroy Post: {categoryRepository.Get(post.CategoryId).Name}");
                Console.WriteLine($"\t - Summary: {post.Summary}");
                Console.WriteLine($"\t - Body: {post.Body}");
                Console.WriteLine($"\t - Slug: {post.Slug}");
                Console.WriteLine($"\t - Created Date: {post.CreateDate}");
                Console.WriteLine($"\t - Last uptaded date: {post.LastUpdateDate}");
                Console.WriteLine("=============================================================");

            }
        }
        public static void ReadPostsByCategory(SqlConnection connection, int id)
        {
            var repository = new PostRepository(connection);
            var categoryRepository = new Repository<Category>(connection);
            var posts = repository.GetByCategory(id);

            Console.WriteLine($"Category: {categoryRepository.Get(id).Name}");
            foreach (var post in posts)
            {
                Console.WriteLine($"\t - Post Title: {post.Title}");
                Console.WriteLine($"\t - Summary: {post.Summary}");
                Console.WriteLine($"\t - Body: {post.Body}");
                Console.WriteLine($"\t - Slug: {post.Slug}");
                Console.WriteLine($"\t - Created Date: {post.CreateDate}");
                Console.WriteLine($"\t - Last uptaded date: {post.LastUpdateDate}");
                Console.WriteLine("=============================================================");
            }
        }
        public static void ReadPostWithTag(SqlConnection connection)
        {
            var repository = new PostRepository(connection);
            var posts = repository.GetPostsWithTag();

            foreach (var post in posts)
            {
                Console.WriteLine($"\t - Post Title: {post.Title}");
                if (post.Tags.Count != 0)
                {
                    Console.Write("\t - Tag: ");
                    for (int i = 0; i < post.Tags.Count; i++)
                    {
                        if (i == post.Tags.Count - 1) Console.WriteLine($"{post.Tags[i].Name}");
                        else Console.Write($"{post.Tags[i].Name}, ");
                    }
                }
                Console.WriteLine($"\t - Summary: {post.Summary}");
                Console.WriteLine($"\t - Body: {post.Body}");
                Console.WriteLine($"\t - Slug: {post.Slug}");
                Console.WriteLine($"\t - Created Date: {post.CreateDate}");
                Console.WriteLine($"\t - Last uptaded date: {post.LastUpdateDate}");
                Console.WriteLine("=============================================================");

            }
        }
        public static void CreatePost(SqlConnection connection, Post post)
        {
            var repository = new Repository<Post>(connection);

            try
            {
                repository.Create(post);
            }
            catch (SqlException m)
            {
                Console.WriteLine(m.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Role
        // ============================================================================
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items) Console.WriteLine(item.Name);
        }
        public static void CreateRole(SqlConnection connection, Role role)
        {
            var repository = new Repository<Role>(connection);
            repository.Create(role);
        }
        // Tag
        // ============================================================================
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items) Console.WriteLine(item.Name);
        }
        public static void ReadTagsWithPosts(SqlConnection connection)
        {
            var repository = new TagRepository(connection);
            var items = repository.GetTagWithPosts();

            foreach (var item in items)
            {
                Console.WriteLine($"A tag {item.Name} tem {item.Posts.Count} posts");
            }
        }
        public static void CreateTag(SqlConnection connection, Role role)
        {
            var repository = new Repository<Role>(connection);
            repository.Create(role);
        }

        // ============================================================================
        // public static void ReadUser()
        // {
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(1);

        //         Console.WriteLine(user.Name);
        //     }
        // }
        // public static void CreateUser()
        // {

        //     var user = new User()
        //     {
        //         Bio = "Equipa Balta.io",
        //         Email = "hello@balta.io",
        //         Image = "https://...",
        //         Name = "Equipe balta.io",
        //         PasswordHash = "HASH",
        //         Slug = "equipe-balta"
        //     };

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var valueReturned = connection.Insert<User>(user);

        //         Console.WriteLine(valueReturned);
        //     }
        // }
        // public static void UpdateUser()
        // {

        //     var user = new User()
        //     {
        //         Id = 2,
        //         Bio = "Equipa | Balta.io",
        //         Email = "hello@balta.io",
        //         Image = "https://...",
        //         Name = "Equipe de suporte balta.io",
        //         PasswordHash = "HASH",
        //         Slug = "equipe-balta"
        //     };

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var valueReturned = connection.Update<User>(user);

        //         Console.WriteLine(valueReturned);
        //     }
        // }
        // public static void DeleteUser()
        // {

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(2);
        //         var valueReturned = connection.Delete<User>(user);

        //         Console.WriteLine(valueReturned);
        //     }
        // }
        // ============================================================================
    }
}