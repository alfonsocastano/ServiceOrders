using ServiceOrders.Application.DTOs.Auth;

namespace ServiceOrders.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);

    Task<UserInfoDto> GetCurrentUserAsync(string username);
}
