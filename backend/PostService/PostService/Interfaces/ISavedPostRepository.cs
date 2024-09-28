using PostService.Models;

namespace PostService.Interfaces
{
    public interface ISavedPostRepository
    {
        Task<IEnumerable<SavedPost>> GetSavedPostsByUserIdAsync(string userId);
        Task SavePostAsync(SavedPost savedPost);
        Task RemoveSavedPostAsync(string postId, string userId);
    }
}
