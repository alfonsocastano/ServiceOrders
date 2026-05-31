namespace ServiceOrders.Application.DTOs.Auth;

public sealed class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;
}
