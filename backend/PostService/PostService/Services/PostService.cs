using AutoMapper;
using PostService.DTOs;
using PostService.Interfaces;
using PostService.Models;

namespace PostService.Services
{
    public class Postservice : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public Postservice(IPostRepository postRepository, IMapper mapper, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<PostDto> GetPostByIdAsync(string id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null) throw new KeyNotFoundException("Post not found");
            return _mapper.Map<PostDto>(post);
        }

        public async Task CreatePostAsync(CreatePostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.CreatePostAsync(post);
        }

        public async Task UpdatePostAsync(string id, UpdatePostDto postDto)
        {
            var existingPost = await _postRepository.GetPostByIdAsync(id);
            if (existingPost == null) throw new KeyNotFoundException("Post not found");

            _mapper.Map(postDto, existingPost);
            existingPost.UpdatedAt = DateTime.UtcNow;

            await _postRepository.UpdatePostAsync(existingPost);
        }

        public async Task DeletePostAsync(string id)
        {
            await _postRepository.DeletePostAsync(id);
        }

        public Task SavePostAsync(SavePostDto savePostDto)
        {
            throw new NotImplementedException();
        }

        public Task RemoveSavedPostAsync(string userId, string postId)
        {
            throw new NotImplementedException();
        }

        public Task AddOrUpdateReactionAsync(string postId, ReactionDto reactionDto)
        {
            throw new NotImplementedException();
        }

        public Task RemoveReactionAsync(string postId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
