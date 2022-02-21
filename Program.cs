// See https://aka.ms/new-console-template for more information

using Blog;
using Blog.Repositories;
using Blog.Screens;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

Database.Connection = new SqlConnection(CONNECTION_STRING);
Database.Connection.Open();

Menu.Load();

Database.Connection.Close();


static void GetWithRoles(SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var items = repository.GetWithRoles();

    foreach (var item in items)
    {
        System.Console.WriteLine(item.Name);
        foreach (var role in item.Roles)
        {
            System.Console.WriteLine($"-  {role.Name}");
        }
    }
}
