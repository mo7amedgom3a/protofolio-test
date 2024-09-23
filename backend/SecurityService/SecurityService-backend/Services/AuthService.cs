using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SecurityServiceBackend.DTOs;
using SecurityServiceBackend.Interfaces;
using SecurityServiceBackend.Models;
using SecurityServiceBackend.AsyncDataServices;

namespace SecurityServiceBackend.Services
{
    public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(IUserRepository userRepository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ApplicationUser> RegisterAsync(RegisterDTO registerUserDto)
    {
        var user = _mapper.Map<ApplicationUser>(registerUserDto);

        var result = await _userRepository.CreateUserAsync(user, registerUserDto.Password);
        if (result.Succeeded)
        {
            
    }

    public async Task<string> LoginAsync(LoginDTO loginDTO)
    {
        var user = await _userRepository.FindByUsernameAsync(loginDTO.Username);
        if (user == null || !await _userRepository.CheckPasswordAsync(user, loginDTO.Password))
        {
            return null; // Login failed
        }

        // Generate JWT token
        return _jwtTokenGenerator.GenerateToken(user);
    }
}

}