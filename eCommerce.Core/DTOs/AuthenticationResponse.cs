namespace eCommerce.Core.DTOs;

public record AuthenticationResponse(
    Guid UserId,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool IsAuthenticated
);