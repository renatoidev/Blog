using Dapper;

namespace Blog.Screens.UserRoleScreen
{
    public static class MenuUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine(@"
Administração de Vínculos
-------------------------
1 - Listar vínculos
2 - Vincular Usuário a Perfil
0 - Sair
Escolha uma opção: ");
            var option = short.Parse(Console.ReadLine());
            HandleMenuUserRoleOptions(option);
        }

        public static void HandleMenuUserRoleOptions(short option)
        {
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: ListUserRoleScreen.Load(); break;
                case 2: CreateUserRoleScreen.Load(); break;
                default: Load(); break;
            }
        }


    }
}