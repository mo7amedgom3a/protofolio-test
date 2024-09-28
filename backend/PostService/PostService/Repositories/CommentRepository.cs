// Repositories/CommentRepository.cs
using MongoDB.Driver;
using PostService.DTOs;
using PostService.Interfaces;
using PostService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
namespace PostService.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IMongoCollection<Comment> _commentsCollection;
        private readonly IMongoCollection<Post> _postsCollection;
        private readonly IMapper _mapper;


        public CommentRepository(MongoDBContext database, IMapper mapper)
        {
            _commentsCollection = database.Comments;
            _postsCollection = database.Posts;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(string postId)
        {
            var post = await _postsCollection.Find(p => p.Id == postId).FirstOrDefaultAsync();
            if (post == null)
            {
               return null;
            }
            var comments = await _commentsCollection.Find(c => c.PostId == postId).ToListAsync();
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

public async Task<CommentDto> GetCommentByIdAsync(string commentId)
        {
            var comment = await _commentsCollection.Find(c => c.Id == commentId).FirstOrDefaultAsync();
            return _mapper.Map<CommentDto>(comment);
        }
        public async Task AddCommentAsync(string postId, CreateCommentDto comment)
        {
            var newComment = _mapper.Map<Comment>(comment);
            newComment.PostId = postId;
            newComment.CreatedAt = DateTime.UtcNow;
            newComment.UpdatedAt = DateTime.UtcNow;

            await _commentsCollection.InsertOneAsync(newComment);

            // Add the comment's ID to the Post's CommentIds list
            var filter = Builders<Post>.Filter.Eq(p => p.Id, postId);
            var update = Builders<Post>.Update.Push(p => p.CommentIds, newComment.Id);
            await _postsCollection.UpdateOneAsync(filter, update);
        }

        public async Task UpdateCommentAsync(string postId, Comment comment)
        {
            await _commentsCollection.ReplaceOneAsync(c => c.Id == comment.Id, comment);
        }

        public async Task DeleteCommentAsync(string postId, string commentId)
        {
            // Delete the comment from the Comments collection
            var filter = Builders<Comment>.Filter.Eq(c => c.Id, commentId);
            await _commentsCollection.DeleteOneAsync(filter);

            // Remove the comment's ID from the Post's CommentIds list
            var postFilter = Builders<Post>.Filter.Eq(p => p.Id, postId);
            var update = Builders<Post>.Update.Pull(p => p.CommentIds, commentId);
            await _postsCollection.UpdateOneAsync(postFilter, update);
        }
    }
}
