namespace eCommerce.Core.DTOs;
public record UserResponseDTO(
    Guid UserId,
    string? Email,
    string? PersonName,
    string? Gender
);
