using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Create();
            System.Console.WriteLine("Categoria criada com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }

        public static void Create()
        {
            var repository = new Repository<Category>(Database.Connection);
            Console.Write("Nome da categoria: ");
            var name = Console.ReadLine();
            Console.Write("Slug da categoria: ");
            var slug = Console.ReadLine();

            var category = new Category()
            {
                Name = name,
                Slug = slug
            };

            repository.Create(category);
        }
    }
}