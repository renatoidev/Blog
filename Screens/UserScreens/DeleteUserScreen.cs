using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Delete();
            Console.WriteLine("Usuário excluído com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }
        public static void Delete()
        {
            var repository = new Repository<User>(Database.Connection);

            Console.Write("Id do usuário a ser deletado: ");
            var id = int.Parse(Console.ReadLine());

            var user = repository.Get(id);

            repository.Delete(user);
        }
    }
}