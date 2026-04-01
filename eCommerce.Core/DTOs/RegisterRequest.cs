using eCommerce.Core.Enums;

namespace eCommerce.Core.DTOs;

public record RegisterRequest(
    string? Email,
    string? PersonName,
    string? Password,
    GenderOptions Gender
);