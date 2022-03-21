namespace Journal.Repository.Model
{
    public class Comment : BaseEntity
    {
        public string Description { get; set; }
        public string Commentor { get; set; }
        public Post Post { get; set; }
    }
}
