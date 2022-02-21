using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.TagScreens
{
    public static class MenuTagScreen
    {

        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine(
                @"
Administração de Tags
---------------------
1 - Listar Tags
2 - Cadastrar Tag
3 - Atualizar Tag
4 - Deletar Tag
0 - Sair
---------------------
Escolha uma opção: ");

            var option = short.Parse(Console.ReadLine());
            HandleMenuTagOptions(option);
        }

        public static void HandleMenuTagOptions(short option)
        {
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: ListTagScreen.Load(); break;
                case 2: CreateTagScreen.Load(); break;
                case 3: UpdateTagScreen.Load(); break;
                case 4: DeleteTagScreen.Load(); break;
                default: Load(); break;
            }

        }
    }
}