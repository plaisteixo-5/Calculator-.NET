using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;
        public PostRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public List<Post> GetByCategory(int id)
        {
            var query = @"
                SELECT
                    *
                FROM
                    [Post]
                WHERE
                    [Post].[CategoryId] = @Id";

            var items = _connection.Query<Post>(query,
            new
            {
                Id = id
            }).ToList();

            return items;
        }
        public List<Post> GetPostsWithTag()
        {
            var query = @"
            SELECT
                [Post].*,
                [Tag].*
            FROM
                [Post]
            INNER JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
            INNER JOIN [Tag] ON [Tag].[Id] = [PostTag].[TagId]";

            var posts = new List<Post>();
            var items = _connection.Query<Post, Tag, Post>(query,
            (post, tag) =>
            {
                var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                if (pst == null)
                {
                    posts.Add(post);
                    post.Tags.Add(tag);
                }
                else if (tag != null)
                    pst.Tags.Add(tag);
                return post;
            });

            return posts;
        }
    }
}