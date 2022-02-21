using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class UpdatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Update();
            System.Console.WriteLine("Post alterado com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }

        public static void Update()
        {
            var repository = new Repository<Post>(Database.Connection);

            Console.Write("Id do post: ");
            var id = int.Parse(Console.ReadLine());

            var post = repository.Get(id);

            Console.Write($"Novos dados do Post - {post.Title}");

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
            var lastUpdateDate = DateTime.Now;

            post.CategoryId = categoryId;
            post.AuthorId = authorId;
            post.Title = title;
            post.Summary = summary;
            post.Body = body;
            post.Slug = slug;
            post.LastUpdateDate = lastUpdateDate;

            repository.Update(post);
        }
    }
}