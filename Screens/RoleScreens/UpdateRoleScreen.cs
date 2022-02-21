using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Update();
            System.Console.WriteLine("Perfil alterado com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }

        public static void Update()
        {
            var repository = new Repository<Role>(Database.Connection);

            Console.Write("Id do perfil: ");
            var id = int.Parse(Console.ReadLine());

            var role = repository.Get(id);

            Console.Write("Novo nome do perfil: ");
            var name = Console.ReadLine();
            Console.Write("Novo slug do perfil: ");
            var slug = Console.ReadLine();

            role.Name = name;
            role.Slug = slug;

            repository.Update(role);
        }
    }
}