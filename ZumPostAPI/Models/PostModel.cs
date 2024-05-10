namespace ZumPostAPI.Models
{
    public class PostModel
    {
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public int Id { get; set; }
        public int Likes { get; set; }
        public float Popularity { get; set; }
        public int Reads { get; set; }
        public string[] Tags { get; set; }
    }
}
