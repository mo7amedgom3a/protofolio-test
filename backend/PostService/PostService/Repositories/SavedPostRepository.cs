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
        private readonly IMongoCollection<Post> _postCollection;
        private readonly IMapper _mapper;

        public SavedPostRepository(MongoDBContext mongoDBContext, IMapper mapper)
        {
            _savedPostCollection = mongoDBContext.SavedPosts;
            _postCollection = mongoDBContext.Posts;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SavedPost>> GetSavedPostsByUserIdAsync(string userId)
        {
            var savedPosts = await _savedPostCollection
                .Find(savedPost => savedPost.UserId == userId)
                .SortByDescending(savedPost => savedPost.SavedAt)
                .ToListAsync();
            return savedPosts;
        }

        public async Task SavePostAsync(string postId, string userId)
        {
            var post = await _postCollection.Find(post => post.Id == postId).FirstOrDefaultAsync();
            if (post == null)
            {
                return;
            }
            var savedPost = new SavedPost
            {
                postDto = _mapper.Map<PostDto>(post),
                UserId = userId
            };

            await _savedPostCollection.InsertOneAsync(savedPost);
        }

        public async Task UnsavePostAsync(string postId, string userId)
        {
            var savePost = await _savedPostCollection.Find(savedPost => savedPost.postDto.Id == postId && savedPost.UserId == userId).FirstOrDefaultAsync();
            if (savePost == null)
            {
                return;
            }
            await _savedPostCollection.DeleteOneAsync(savedPost => savedPost.postDto.Id == postId && savedPost.UserId == userId);
        }

        public async Task RemoveSavedPostAsync(string userId, string postId)
        {
            var savePost = await _savedPostCollection.Find(savedPost => savedPost.UserId == userId && savedPost.postDto.Id == postId).FirstOrDefaultAsync();
            if (savePost == null)
            {
                return;
            }
            await _savedPostCollection.DeleteOneAsync(savedPost => savedPost.UserId == userId && savedPost.postDto.Id == postId);
        }

        public async Task UpdateUserInformationInSavedPostsAsync(UserUpdatedEvent userUpdatedEvent)
        {
            var filter = Builders<SavedPost>.Filter.Eq(savedPost => savedPost.UserId, userUpdatedEvent.UserId);
            var update = Builders<SavedPost>.Update
            .Set(savedPost => savedPost.postDto.userMetadata.Name, userUpdatedEvent.Name)
            .Set(savedPost => savedPost.postDto.userMetadata.Bio, userUpdatedEvent.Bio)
            .Set(savedPost => savedPost.postDto.userMetadata.ImageUrl, userUpdatedEvent.ImageUrl);

            var updateResult = await _savedPostCollection.UpdateManyAsync(filter, update);

            if (updateResult.IsAcknowledged)
            {
            return;
            }
            else
            {
            throw new Exception("Failed to update user information in saved posts.");
            }
        }
    }
}