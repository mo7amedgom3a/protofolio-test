using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PostService.Models
{
    public class SavedPost
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("PostId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PostId { get; set; }  // Reference to the Post
        [BsonElement("UserId")]
        public string UserId { get; set; }  // Reference to the User who saved the post
        public DateTime SavedAt { get; set; } = DateTime.UtcNow;
    }
}
