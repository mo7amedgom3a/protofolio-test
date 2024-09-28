using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PostService.Models
{
    public class SavedPost
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PostId { get; set; }  // Reference to the Post
        public string UserId { get; set; }  // Reference to the User who saved the post
        public DateTime SavedAt { get; set; } = DateTime.UtcNow;
    }
}
