using ServiceOrders.Application.DTOs.Auth;
using ServiceOrders.Application.Interfaces;

namespace ServiceOrders.Application.Services;

public sealed class AuthService : IAuthService
{
    private readonly IAuthRepository _repository;

    private readonly IJwtService _jwtService;

    public AuthService(IAuthRepository repository, IJwtService jwtService)
    {
        _repository = repository;
        _jwtService = jwtService;
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
    {
        var user =
        await _repository.GetByUsernameAsync(
        request.UserName);

        if (user is null)
            return null;

        var valid =
        BCrypt.Net.BCrypt.Verify(
        request.Password,
        user.Password);

        if (!valid)
            return null;

        return new LoginResponseDto
        {
            Token = _jwtService.GenerateToken(user),
            Username = user.UserName,
            FullName = user.FullName
        };
    }

    public async Task<UserInfoDto?> GetCurrentUserAsync(string username)
    {
        var user =
        await _repository.GetByUsernameAsync(username);

        if (user is null)
            return null;

        return new UserInfoDto
        {
            Id = user.Id,
            Username = user.UserName,
            FullName = user.FullName
        };
    }
}
