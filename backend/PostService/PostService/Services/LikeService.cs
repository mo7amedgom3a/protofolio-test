using AutoMapper;
using PostService.DTOs;
using PostService.Interfaces;
using PostService.Models;

namespace PostService.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public LikeService(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Like>> GetLikesByPostIdAsync(string postId)
        {
            return await _likeRepository.GetLikesByPostIdAsync(postId);
        }

        public async Task LikePostAsync(string postId, string userId)
        {
            await _likeRepository.LikePostAsync(postId, userId);
        }

        public async Task DislikePostAsync(string postId, string userId)
        {
            await _likeRepository.DislikePostAsync(postId, userId);
        }
    }
}