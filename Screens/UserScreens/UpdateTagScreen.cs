using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Update();
            System.Console.WriteLine("Usuário alterado com sucesso!");
            Console.ReadKey();
            Menu.Load();
        }

        public static void Update()
        {
            var repository = new Repository<User>(Database.Connection);

            Console.Write("Id do usuário: ");
            var id = int.Parse(Console.ReadLine());

            var user = repository.Get(id);

            Console.WriteLine("Novo usuário");

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Senha: ");
            var passwordHash = Console.ReadLine();

            Console.Write("Bio: ");
            var bio = Console.ReadLine();

            Console.Write("Imagem: ");
            var image = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();


            user.Name = name;
            user.Email = email;
            user.PasswordHash = passwordHash;
            user.Bio = bio;
            user.Image = image;
            user.Slug = slug;

            repository.Update(user);
        }
    }
}