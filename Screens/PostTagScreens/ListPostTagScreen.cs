using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.PostTagScreen
{
    public static class ListPostTagScreen
    {
        public static void Load()
        {
            System.Console.WriteLine("Lista de Vínculos entre Post e Tag");
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
                        INNER JOIN [PostTag] ON [PostTag].[PostId]  = [Post].[Id]
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
                    System.Console.WriteLine($"{item.Title}");
                    foreach (var tag in item.Tags)
                        Console.WriteLine($" - {tag.Name}");
                    System.Console.WriteLine();
                }
            }
        }
    }
}