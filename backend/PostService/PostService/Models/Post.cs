using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PostService.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }        
        public string AuthorId { get; set; }  // Reference to User Service
        public string Title { get; set; }
        public string Content { get; set; }
        public string Code { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public List<string> CommentIds { get; set; } = new List<string>();
        public int Likes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsSaved { get; set; }  // To track saved state of the post
    }
}
