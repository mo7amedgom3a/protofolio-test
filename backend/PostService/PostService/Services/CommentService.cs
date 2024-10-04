using AutoMapper;
using MongoDB.Driver;
using PostService.DTOs;
using PostService.Interfaces;
using PostService.Models;
using PostService.Repositories;

namespace PostService.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository,IPostRepository postRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public Task AddCommentToPostAsync(string postId, CreateCommentDto comment)
        {
            return _commentRepository.AddCommentAsync(postId, comment);
        }

        public Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(string postId)
        {
            return _commentRepository.GetCommentsByPostIdAsync(postId);
        }
        public async Task UpdateCommentAsync(string postId, UpdateCommentDto comment)
        {
            var commentModel = _mapper.Map<Comment>(comment);
            var oldComment = await _commentRepository.GetCommentByIdAsync(comment.CommentId);

            commentModel.PostId = postId;
            commentModel.CreatedAt = oldComment.CreatedAt;
            commentModel.UpdatedAt = DateTime.UtcNow;
            commentModel.AuthorId = oldComment.userMetadata.UserId;
            commentModel.Id = oldComment.Id;
            await _commentRepository.UpdateCommentAsync(postId, commentModel);
        }
        public Task DeleteCommentAsync(string postId, string commentId)
        {
            return _commentRepository.DeleteCommentAsync(postId, commentId);
        }
    }
}