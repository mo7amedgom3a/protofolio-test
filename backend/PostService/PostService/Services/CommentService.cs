using AutoMapper;
using MongoDB.Driver;
using PostService.DTOs;
using PostService.Interfaces;
using PostService.Models;
using PostService.Repositories;
using PostService.AsyncDataService;
using PostService.AsyncDataService.Models;
namespace PostService.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public CommentService(
        ICommentRepository commentRepository,
        IPostRepository postRepository,
        IMapper mapper,
        IMessageBusClient messageBusClient)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _postRepository = postRepository;
            _messageBusClient = messageBusClient;
        }

        public async Task AddCommentToPostAsync(string postId, CreateCommentDto comment)
        {
            await _commentRepository.AddCommentAsync(postId, comment);
            var comments = _commentRepository.GetCommentsByPostIdAsync(postId);
            var post = await _postRepository.GetPostByIdAsync(postId);
            var lastComment = comments.Result.Last();
            var commentCreatedMessage = new PostCommentedEvent
            {
                PostId = postId,
                CommentId = lastComment.Id,
                CommentContent = lastComment.Content,
                SenderUserId = lastComment.userMetadata.UserId,
                RecipientUserId = post.AuthorId,
                CommentedAt = lastComment.CreatedAt
            };
            _messageBusClient.PublishEvent(commentCreatedMessage, "PostCommentedEvent");
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