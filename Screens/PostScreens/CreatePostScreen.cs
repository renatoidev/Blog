using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Create();
            System.Console.WriteLine("Post criado com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }

        public static void Create()
        {
            var repository = new Repository<Post>(Database.Connection);
            Console.WriteLine("Novo Post");

            Console.Write("Id da categoria: ");
            var categoryId = int.Parse(Console.ReadLine());
            Console.Write("Id do autor: ");
            var authorId = int.Parse(Console.ReadLine());
            Console.Write("Título: ");
            var title = Console.ReadLine();
            Console.Write("Sumário: ");
            var summary = Console.ReadLine();
            Console.Write("Corpo: ");
            var body = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            var createDate = DateTime.Now;
            var lastUpdateDate = DateTime.Now;

            var post = new Post()
            {
                CategoryId = categoryId,
                AuthorId = authorId,
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = createDate,
                LastUpdateDate = lastUpdateDate
            };

            repository.Create(post);
        }
    }
}