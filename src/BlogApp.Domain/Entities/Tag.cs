namespace BlogApp.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
