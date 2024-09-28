using MongoDB.Driver;
using PostService.Interfaces;
using PostService.Models;

namespace PostService.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IMongoCollection<Post> _posts;

        public PostRepository(MongoDBContext context)
        {
            _posts = context.Posts;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _posts.Find(post => true).ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(string id)
        {
            return await _posts.Find(post => post.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreatePostAsync(Post post)
        {
            await _posts.InsertOneAsync(post);
        }

        public async Task UpdatePostAsync(Post post)
        {
            await _posts.ReplaceOneAsync(p => p.Id == post.Id, post);
        }
        public async Task UpdatePostAsyncById(string id, UpdateDefinition<Post> update)
        {
            await _posts.UpdateOneAsync(p => p.Id == id, update);
        }
        public async Task DeletePostAsync(string id)
        {
            await _posts.DeleteOneAsync(post => post.Id == id);
        }
    }
}
