using PostService.DTOs;

namespace PostService.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllPostsAsync();
        Task<PostDto> GetPostByIdAsync(string id);
        Task CreatePostAsync(CreatePostDto postDto);
        Task UpdatePostAsync(string id, UpdatePostDto postDto);
        Task DeletePostAsync(string id);

        // Reaction
        Task AddOrUpdateReactionAsync(string postId, ReactionDto reactionDto);
        Task RemoveReactionAsync(string postId, string userId);

        // Saved Posts
        Task SavePostAsync(SavePostDto savePostDto);
        Task RemoveSavedPostAsync(string userId, string postId);
    }
}
