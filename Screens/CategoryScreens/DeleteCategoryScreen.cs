using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Delete();
            Console.WriteLine("Categoria excluída com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }
        public static void Delete()
        {
            var repository = new Repository<Category>(Database.Connection);

            Console.Write("Id da categoria a ser deletada: ");
            var id = int.Parse(Console.ReadLine());

            var category = repository.Get(id);

            repository.Delete(category);
        }
    }
}