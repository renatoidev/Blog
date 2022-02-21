using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Delete();
            Console.WriteLine("Perfil excluído com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }
        public static void Delete()
        {
            var repository = new Repository<Role>(Database.Connection);

            Console.Write("Id do perfil a ser deletado: ");
            var id = int.Parse(Console.ReadLine());

            var role = repository.Get(id);

            repository.Delete(role);
        }
    }
}