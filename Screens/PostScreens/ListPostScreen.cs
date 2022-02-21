using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.PostScreens
{
    public static class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.Write(@"
Lista de Posts
--------------
1 - Listar simplificado
2 - Listar detalhado
0 - Sair
--------------
Escolha sua opção: ");
            List(short.Parse(Console.ReadLine()));
            Console.ReadKey();
            Menu.Load();
        }
        public static void List(short option)
        {
            var postRepository = new Repository<Post>(Database.Connection);
            var categoryRepository = new Repository<Category>(Database.Connection);


            switch (option)
            {
                case 0: Menu.Load(); break;
                case 1:
                    {

                        var posts = postRepository.Get();

                        foreach (var post in posts)
                        {
                            Console.WriteLine($"{post.Title} - {categoryRepository.Get(post.CategoryId).Name}");
                        }
                        break;
                    }
                case 2:
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
                                System.Console.Write($"{item.Title} (");

                                for (int i = 0; i < item.Tags.Count; i++)
                                {
                                    if (i == item.Tags.Count - 1)
                                    {
                                        Console.Write($"{item.Tags[i].Name}");
                                    }
                                    else
                                    {
                                        Console.Write($"{item.Tags[i].Name}, ");
                                    }
                                }
                                System.Console.WriteLine(")");
                            }
                        }
                        break;
                    }
                default: ListPostScreen.Load(); break;
            }
        }
    }
}