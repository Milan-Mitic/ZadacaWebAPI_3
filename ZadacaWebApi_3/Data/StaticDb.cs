using ZadacaWebApi_3.Models;

namespace ZadacaWebApi_3.Data
{
    public class StaticDb
    {
        public static List<Book> books = new List<Book>()
        {
            new Book() { Author = "Author1", Title = "Title1"},
            new Book() { Author = "Author2", Title = "Title2"},
            new Book() { Author = "Author3", Title = "Title3"},
            new Book() { Author = "Author4", Title = "Title4"},
            new Book() { Author = "Author5", Title = "Title5"}
        };
    }
}
