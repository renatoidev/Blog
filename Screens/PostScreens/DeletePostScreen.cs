using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Delete();
            Console.WriteLine("Post excluído com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }
        public static void Delete()
        {
            var repository = new Repository<Post>(Database.Connection);

            Console.Write("Id do post a ser deletada: ");
            var id = int.Parse(Console.ReadLine());

            var post = repository.Get(id);

            repository.Delete(post);
        }
    }
}