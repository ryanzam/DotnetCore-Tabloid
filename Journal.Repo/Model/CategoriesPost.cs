namespace Journal.Repository.Model
{
    public class CategoriesPost
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}
