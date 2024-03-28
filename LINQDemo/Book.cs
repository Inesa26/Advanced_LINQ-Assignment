namespace LINQDemo
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Genre: {Genre}";
        }
    }
}
