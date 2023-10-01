using AutoMapper;
using LogixMovie.Application.Dtos;
using LogixMovie.Application.Services.Interfaces;
using LogixMovie.Common.Helpers;
using LogixMovie.Domain.Entities;
using LogixMovie.Domain.Models;
using LogixMovie.Domain.Repositories;

namespace LogixMovie.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMovieRepository movieRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<bool> RegisterAsync(UserDto user)
        {
            User existingEmail = await _userRepository.FindAsync(u => u.Email == user.Email);
            bool isEmailAvailable = existingEmail == null;

            if (isEmailAvailable)
            {
                string passwordHashed = PasswordHandler.HashPassword(user.Password, out var salt);

                return await _userRepository.AddUserAsync(new User
                {
                    Email = user.Email,
                    Password = passwordHashed,
                    Salt = Convert.ToBase64String(salt)
                });
            }

            return false;
        }

        public async Task<AuthenticateDto> AuthenticateAsync(UserDto user)
        {
            AuthenticateDto authenticateUser = new();

            var userDetail = await _userRepository.FindAsync(u => u.Email == user.Email);

            if (userDetail == null) return authenticateUser;

            bool isPasswordValid = PasswordHandler.VerifyPassword(user.Password, userDetail.Password, userDetail.Salt);

            if (isPasswordValid)
            {
                var token = JsonWebToken.GenerateJSONWebToken(userDetail);
                authenticateUser = new AuthenticateDto
                {
                    UserId = userDetail.Id,
                    Email = userDetail.Email,
                    Token = token
                };
            }

            return authenticateUser;
        }

        public async Task UserLikeOrDislikeMovieAsync(LikeOrDislikeMovieDto request)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            var movie = await _movieRepository.GetByIdAsync(request.MovieId);

            if(user != null && movie != null)
            {
                await _userRepository.UserLikeOrDislikeMovieAsync(_mapper.Map<LikeOrDislikeMovie>(request));
            }
        }

        public async Task<UserLikeOrDislikeMovieDto> GetListUserLikeOrDislikeMovieAsync(int userId)
        {
            var result = await _userRepository.GetListUserLikeOrDislikeMovieAsync(userId);

            return _mapper.Map<UserLikeOrDislikeMovieDto>(result);
        }
    }
}

