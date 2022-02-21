using Dapper;

namespace Blog.Screens.PostTagScreen
{
    public static class CreatePostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            BindPostTag();
            Console.WriteLine("Post vinculado a Tag com sucesso");
            Console.ReadKey();
            Menu.Load();
        }

        public static void BindPostTag()
        {
            Console.Write("Id do post: ");
            var postId = int.Parse(Console.ReadLine());
            Console.Write("Id da tag: ");
            var tagId = int.Parse(Console.ReadLine());

            var query = @$"INSERT INTO [PostTag] VALUES ({postId}, {tagId})";

            var connection = Database.Connection;

            connection.Query(query);
        }
    }
}