using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.UserRoleScreen
{
    public static class ListUserRoleScreen
    {
        public static void Load()
        {
            System.Console.WriteLine("Lista de Vínculos entre Usuário e Perfil");
            List();
            Console.ReadKey();
            Menu.Load();
        }

        public static void List()
        {
            var query = @"SELECT 
                            [User].*,
                            [Role].*
                        FROM 
                            [User]
                        INNER JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                        INNER JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = Database.Connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else
                    {
                        usr.Roles.Add(role);
                    }

                    return user;
                }, splitOn: "Id"
            );

            foreach (var item in items)
            {
                if (item.Roles.Count > 0)
                {
                    System.Console.WriteLine($"{item.Name}");
                    foreach (var role in item.Roles)
                        Console.WriteLine($" - {role.Name}");
                    System.Console.WriteLine();
                }
            }
        }
    }
}