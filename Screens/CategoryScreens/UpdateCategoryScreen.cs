using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Update();
            System.Console.WriteLine("Categoria alterada com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }

        public static void Update()
        {
            var repository = new Repository<Category>(Database.Connection);

            Console.Write("Id da categoria: ");
            var id = int.Parse(Console.ReadLine());

            var category = repository.Get(id);

            Console.Write("Novo nome da categoria: ");
            var name = Console.ReadLine();
            Console.Write("Novo slug da categoria: ");
            var slug = Console.ReadLine();

            category.Name = name;
            category.Slug = slug;

            repository.Update(category);
        }
    }
}