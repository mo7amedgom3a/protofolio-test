namespace PostService.DTOs
{
    public class CommentDto
    {
        public string Id { get; set; }
        public string AuthorId { get; set; }
        public string PostId { get; set; }
        public string Content { get; set; }
        public string CodeSection { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
