using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.TagScreens
{
    public static class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine("Lista de Tags");
            List();
            Console.ReadKey();
            Menu.Load();
        }
        public static void List()
        {
            var query = @"SELECT 
                            [Post].*,
                            [Tag].*
                        FROM
                            [Post]
                        INNER JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                        INNER JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";

            var posts = new List<Post>();

            var items = Database.Connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;
                        if (post != null)
                            pst.Tags.Add(tag);
                        posts.Add(pst);
                    }
                    else
                    {
                        pst.Tags.Add(tag);
                    }

                    return post;
                }, splitOn: "Id"
            );

            foreach (var item in items)
            {
                if (item.Tags.Count > 0)
                {
                    System.Console.WriteLine($"{item.Title} ({item.Tags.Count})");
                }
            }
        }
    }
}