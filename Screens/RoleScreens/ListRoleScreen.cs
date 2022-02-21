using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine("Lista de Perfis");
            List();
            Console.ReadKey();
            Menu.Load();
        }
        public static void List()
        {
            var repository = new Repository<Role>(Database.Connection);

            var items = repository.Get();
            foreach (var item in items)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}