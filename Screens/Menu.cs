using Blog.Models;
using Blog.Screens.CategoryScreens;
using Blog.Screens.PostScreens;
using Blog.Screens.PostTagScreen;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserRoleScreen;
using Blog.Screens.UserScreens;

namespace Blog.Screens
{
    public static class Menu
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine(@"
----- Blog -----
1 - Usuário
2 - Categoria
3 - Tag
4 - Perfil
5 - Vincular Usuário ao Perfil
6 - Post
7 - Vincular Post a Tag
0 - Sair
---------------
Escolha uma opção: ");
            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }

        private static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: MenuUserScreen.Load(); break;
                case 2: MenuCategoryScreen.Load(); break;
                case 3: MenuTagScreen.Load(); break;
                case 4: MenuRoleScreen.Load(); break;
                case 5: MenuUserRoleScreen.Load(); break;
                case 6: MenuPostScreen.Load(); break;
                case 7: MenuPostTagScreen.Load(); break;
                default: Load(); break;
            }
        }
    }
}