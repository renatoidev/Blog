using Dapper;

namespace Blog.Screens.PostTagScreen
{
    public static class MenuPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine(@"
Administração de Vínculos
-------------------------
1 - Listar vínculos
2 - Vincular Post a Tag
0 - Sair
Escolha uma opção: ");
            var option = short.Parse(Console.ReadLine());
            HandleMenuPostTagOptions(option);
        }

        public static void HandleMenuPostTagOptions(short option)
        {
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: ListPostTagScreen.Load(); break;
                case 2: CreatePostTagScreen.Load(); break;
                default: Load(); break;
            }
        }


    }
}