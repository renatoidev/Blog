using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Create();
            System.Console.WriteLine("Tag criada com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }

        public static void Create()
        {
            var repository = new Repository<Tag>(Database.Connection);
            Console.Write("Nome da tag: ");
            var name = Console.ReadLine();
            Console.Write("Slug da tag: ");
            var slug = Console.ReadLine();

            var tag = new Tag()
            {
                Name = name,
                Slug = slug
            };

            repository.Create(tag);
        }
    }
}