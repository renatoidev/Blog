using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.RoleScreens
{
    public static class MenuRoleScreen
    {

        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine(
                @"
Administração de Perfis
---------------------
1 - Listar Perfil
2 - Cadastrar Perfil
3 - Atualizar Perfil
4 - Deletar Perfil
0 - Sair
---------------------
Escolha uma opção: ");

            var option = short.Parse(Console.ReadLine());
            HandleMenuRoleOptions(option);
        }

        public static void HandleMenuRoleOptions(short option)
        {
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: ListRoleScreen.Load(); break;
                case 2: CreateRoleScreen.Load(); break;
                case 3: UpdateRoleScreen.Load(); break;
                case 4: DeleteRoleScreen.Load(); break;
                default: Load(); break;
            }
        }
    }
}