namespace ServiceOrders.Application.DTOs.Auth;

public sealed class UserInfoDto
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;
}
