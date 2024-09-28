using MongoDB.Driver;
using PostService.Interfaces;
using PostService.Models;

namespace PostService.Repositories
{
    public class SavedPostRepository : ISavedPostRepository
    {
        private readonly IMongoCollection<SavedPost> _savedPosts;

        public SavedPostRepository(MongoDBContext context)
        {
            _savedPosts = context.SavedPosts;
        }

        public async Task<IEnumerable<SavedPost>> GetSavedPostsByUserIdAsync(string userId)
        {
            return await _savedPosts.Find(savedPost => savedPost.UserId == userId).ToListAsync();
        }

        public async Task SavePostAsync(SavedPost savedPost)
        {
            await _savedPosts.InsertOneAsync(savedPost);
        }

        public async Task RemoveSavedPostAsync(string postId, string userId)
        {
            await _savedPosts.DeleteOneAsync(savedPost => savedPost.PostId == postId && savedPost.UserId == userId);
        }
    }
}