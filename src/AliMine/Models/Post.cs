namespace AliMine.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgAlias { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
