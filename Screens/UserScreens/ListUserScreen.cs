using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine("Lista de Usuários");
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
                    System.Console.Write($"{item.Name} - {item.Email} (");

                    for (int i = 0; i < item.Roles.Count; i++)
                    {
                        if (i == item.Roles.Count - 1)
                        {
                            Console.Write($"{item.Roles[i].Name}");
                        }
                        else
                        {
                            Console.Write($"{item.Roles[i].Name}, ");
                        }
                    }
                    System.Console.WriteLine(")");
                }

                // foreach (var role in item.Roles)
                //     Console.Write($"{role.Name}, ");
            }

        }
    }
}
