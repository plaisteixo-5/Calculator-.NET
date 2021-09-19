using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        private readonly SqlConnection _connection;
        public TagRepository(SqlConnection connection) : base(connection) =>
            _connection = connection;

        public List<Tag> GetTagWithPosts()
        {
            var query = @"
            SELECT
                [Tag].*,
                [Post].*
            FROM
                [Tag]
            INNER JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
            INNER JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]";

            var tags = new List<Tag>();

            var items = _connection.Query<Tag, Post, Tag>(query,
            (tag, post) =>
            {
                var tg = tags.FirstOrDefault(x => x.Id == tag.Id);
                if (tg == null)
                {
                    tg = tag;
                    if (post != null)
                        tg.Posts.Add(post);
                    tags.Add(tg);
                }
                else if (post != null)
                    tg.Posts.Add(post);

                return tag;
            }, splitOn: "Id");

            return tags;
        }
    }
}