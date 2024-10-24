namespace Library.Contracts.Users;
public record TokenResponse(string AccessToken, string RefreshToken, DateTime Expiry);