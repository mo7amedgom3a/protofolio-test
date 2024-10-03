using MongoDB.Driver;
using PostService.DTOs;
using PostService.Interfaces;
using PostService.Models;
using AutoMapper;

namespace PostService.Repositories
{
    public class SavedPostRepository : ISavedPostRepository
    {
        private readonly IMongoCollection<SavedPost> _savedPostCollection;
        private readonly IMapper _mapper;

        public SavedPostRepository(MongoDBContext mongoDBContext, IMapper mapper)
        {
            _savedPostCollection = mongoDBContext.SavedPosts;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SavedPost>> GetSavedPostsByUserIdAsync(string userId)
        {
            var savedPosts = await _savedPostCollection.Find(savedPost => savedPost.UserId == userId).ToListAsync();
            return savedPosts;
        }

        public async Task SavePostAsync(string postId, string userId)
        {
            var savePost = await _savedPostCollection.Find(savedPost => savedPost.PostId == postId && savedPost.UserId == userId).FirstOrDefaultAsync();
            if (savePost != null)
            {
                return;
            }
            var savedPost = new SavedPost
            {
                PostId = postId,
                UserId = userId
            };

            await _savedPostCollection.InsertOneAsync(savedPost);
        }

        public async Task UnsavePostAsync(string postId, string userId)
        {
            var savePost = await _savedPostCollection.Find(savedPost => savedPost.PostId == postId && savedPost.UserId == userId).FirstOrDefaultAsync();
            if (savePost == null)
            {
                return;
            }
            await _savedPostCollection.DeleteOneAsync(savedPost => savedPost.PostId == postId && savedPost.UserId == userId);
        }

        public async Task RemoveSavedPostAsync(string userId, string postId)
        {
            var savePost = await _savedPostCollection.Find(savedPost => savedPost.UserId == userId && savedPost.PostId == postId).FirstOrDefaultAsync();
            if (savePost == null)
            {
                return;
            }
            await _savedPostCollection.DeleteOneAsync(savedPost => savedPost.UserId == userId && savedPost.PostId == postId);
        }
    }
}