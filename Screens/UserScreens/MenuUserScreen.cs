using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreens
{
    public static class MenuUserScreen
    {

        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine(
                @"
Administração de Usuários
---------------------
1 - Listar Usuários
2 - Cadastrar Usuário
3 - Atualizar Usuário
4 - Deletar Usuário
0 - Sair
---------------------
Escolha uma opção: ");

            var option = short.Parse(Console.ReadLine());
            HandleMenuUserOptions(option);
        }

        public static void HandleMenuUserOptions(short option)
        {
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: ListUserScreen.Load(); break;
                case 2: CreateUserScreen.Load(); break;
                case 3: UpdateUserScreen.Load(); break;
                case 4: DeleteUserScreen.Load(); break;
                default: Load(); break;
            }

        }
    }
}