using MongoDB.Driver;
using PostService.Models;

namespace PostService.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(string id);
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task UpdatePostAsyncById(string id, UpdateDefinition<Post> update);
        Task DeletePostAsync(string id);
        // Add more methods as needed
    }
}
