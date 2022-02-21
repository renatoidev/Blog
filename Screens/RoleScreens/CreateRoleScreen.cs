using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Create();
            System.Console.WriteLine("Perfil criado com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }

        public static void Create()
        {
            var repository = new Repository<Role>(Database.Connection);
            Console.Write("Nome do perfil: ");
            var name = Console.ReadLine();
            Console.Write("Slug do perfil: ");
            var slug = Console.ReadLine();

            var role = new Role()
            {
                Name = name,
                Slug = slug
            };

            repository.Create(role);
        }
    }
}