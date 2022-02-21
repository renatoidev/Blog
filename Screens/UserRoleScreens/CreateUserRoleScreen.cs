using Dapper;

namespace Blog.Screens.UserRoleScreen
{
    public static class CreateUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            BindUserRole();
            Console.WriteLine("Usuário vinculado com sucesso");
            Console.ReadKey();
            Menu.Load();
        }

        public static void BindUserRole()
        {
            Console.Write("Id do usuário: ");
            var userId = int.Parse(Console.ReadLine());
            Console.Write("Id do perfil: ");
            var roleId = int.Parse(Console.ReadLine());

            var query = @$"DECLARE @userId INT
                        SET @userId = {userId}
                        DECLARE @roleId INT
                        SET @roleId = {roleId}
                        INSERT INTO [UserRole] VALUES (@userId, @roleId)";

            var connection = Database.Connection;

            connection.Query(query);

        }
    }
}