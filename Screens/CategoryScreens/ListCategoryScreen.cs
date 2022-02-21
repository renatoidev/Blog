using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.CategoryScreens
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.Write(@"
Lista de Categorias
-------------------
1 - Lista simples
2 - Lista detalhada
0 - Sair
Escolha uma opção: ");
            var option = short.Parse(Console.ReadLine());
            List(option);
            Console.ReadKey();
            Menu.Load();
        }
        public static void List(short option)
        {
            var query = @"SELECT 
                            [Category].*,
                            [Post].*
                        FROM
                            [Category]

                        INNER JOIN [CategoryPost] ON [CategoryId] = [Category].[Id]
                        INNER JOIN [Post] ON [PostId] = [Post].[Id]";

            var categories = new List<Category>();

            var items = Database.Connection.Query<Category, Post, Category>(
                query,
                (category, post) =>
                {
                    var ctg = categories.FirstOrDefault(x => x.Id == category.Id);
                    if (ctg == null)
                    {
                        ctg = category;
                        ctg.Posts.Add(post);
                        categories.Add(ctg);
                    }
                    else
                    {
                        ctg.Posts.Add(post);
                    }

                    return category;
                }, splitOn: "Id"
            );
            switch (option)
            {
                case 0: MenuCategoryScreen.Load(); break;
                case 1:
                    {
                        foreach (var item in items)
                        {
                            if (item.Posts.Count > 0)
                            {
                                System.Console.WriteLine($"{item.Name} ({item.Posts.Count})");
                            }
                        }

                        break;
                    }

                case 2:
                    {
                        foreach (var item in items)
                        {
                            if (item.Posts.Count > 0)
                            {
                                System.Console.WriteLine($"{item.Name}");
                                foreach (var post in item.Posts)
                                    System.Console.WriteLine($"- {post.Title}");
                            }
                        }

                        break;
                    }

                default: Load(); break;
            }

            // var repository = new Repository<Category>(Database.Connection);

            // var items = repository.Get();
            // foreach (var item in items)
            //     Console.WriteLine($"{item.Name} ({item.Posts.Count})");
        }
    }
}