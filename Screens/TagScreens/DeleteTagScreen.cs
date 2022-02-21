using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Delete();
            Console.WriteLine("Tag excluída com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }
        public static void Delete()
        {
            var repository = new Repository<Tag>(Database.Connection);

            Console.Write("Id da tag a ser deletada: ");
            var id = int.Parse(Console.ReadLine());

            var tag = repository.Get(id);

            repository.Delete(tag);
        }
    }
}