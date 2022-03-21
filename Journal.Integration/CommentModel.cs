namespace Journal.Model
{
    public class CommentModel
    {
        public string Description { get; set; }
        public string Commentor { get; set; }
        public PostModel Post { get; set; }
    }
}
