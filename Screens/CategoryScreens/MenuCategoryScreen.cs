using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.CategoryScreens
{
    public static class MenuCategoryScreen
    {

        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine(
                @"
Administração de Categorias
---------------------------
1 - Listar 
2 - Cadastrar 
3 - Atualizar 
4 - Deletar 
0 - Sair
---------------------------
Escolha uma opção: ");

            var option = short.Parse(Console.ReadLine());
            HandleMenuCategoryOptions(option);
        }

        public static void HandleMenuCategoryOptions(short option)
        {
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: ListCategoryScreen.Load(); break;
                case 2: CreateCategoryScreen.Load(); break;
                case 3: UpdateCategoryScreen.Load(); break;
                case 4: DeleteCategoryScreen.Load(); break;
                default: Load(); break;
            }
        }
    }
}