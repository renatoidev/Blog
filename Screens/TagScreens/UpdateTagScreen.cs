using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Update();
            System.Console.WriteLine("Tag alterada com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }

        public static void Update()
        {
            var repository = new Repository<Tag>(Database.Connection);

            Console.Write("Id da tag: ");
            var id = int.Parse(Console.ReadLine());

            var tag = repository.Get(id);

            Console.Write("Novo nome da tag: ");
            var name = Console.ReadLine();
            Console.Write("Novo slug da tag: ");
            var slug = Console.ReadLine();

            tag.Name = name;
            tag.Slug = slug;

            repository.Update(tag);
        }
    }
}