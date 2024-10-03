using MongoDB.Driver;
using PostService.DTOs;
using PostService.Interfaces;
using PostService.Models;
using AutoMapper;

namespace PostService.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly IMongoCollection<Like> _likeCollection;
        private readonly IMongoCollection<Post> _postCollection;
        private readonly IMapper _mapper;

        public LikeRepository(MongoDBContext mongoDBContext, IMapper mapper)
        {
            _likeCollection = mongoDBContext.Likes;
            _postCollection = mongoDBContext.Posts;

            _mapper = mapper;
        }

        public async Task<IEnumerable<Like>> GetLikesByPostIdAsync(string postId)
        {
            var likes = await _likeCollection.Find(like => like.PostId == postId).ToListAsync();
            return likes;
        }

        public async Task LikePostAsync(string postId, string userId)
        {
            //var post = await _postCollection.Find(post => post.Id == postId).FirstOrDefaultAsync();
            var likePost = await _likeCollection.Find(like => like.PostId == postId && like.UserId == userId).FirstOrDefaultAsync();
            if (likePost != null)
            {
                return;
            }
            var like = new Like
            {
                PostId = postId,
                UserId = userId
            };

            await _likeCollection.InsertOneAsync(like);
            // Increment the likes count of the post
            await _postCollection.UpdateOneAsync(post => post.Id == postId, Builders<Post>.Update.Inc(post => post.Likes, 1));
        }

        public async Task DislikePostAsync(string postId, string userId)
        {
            var likePost = await _likeCollection.Find(like => like.PostId == postId && like.UserId == userId).FirstOrDefaultAsync();
            if (likePost == null)
            {
                return;
            }
            await _likeCollection.DeleteOneAsync(like => like.PostId == postId && like.UserId == userId);
            // Decrement the likes count of the post
            await _postCollection.UpdateOneAsync(post => post.Id == postId, Builders<Post>.Update.Inc(post => post.Likes, -1));
        }
    }
}