using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.PostScreens
{
    public static class MenuPostScreen
    {

        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine(
                @"
Administração de Posts
---------------------
1 - Listar 
2 - Cadastrar 
3 - Atualizar 
4 - Deletar 
0 - Sair
---------------------
Escolha uma opção: ");

            var option = short.Parse(Console.ReadLine());
            HandleMenuPostOptions(option);
        }

        public static void HandleMenuPostOptions(short option)
        {
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: ListPostScreen.Load(); break;
                case 2: CreatePostScreen.Load(); break;
                case 3: UpdatePostScreen.Load(); break;
                case 4: DeletePostScreen.Load(); break;
                default: Load(); break;
            }

        }
    }
}