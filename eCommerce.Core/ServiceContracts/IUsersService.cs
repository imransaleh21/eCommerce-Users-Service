using eCommerce.Core.DTOs;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Defines the contract for user authentication and registration operations within the application.
/// </summary>
/// <remarks>Implementations of this interface should ensure that user credentials and registration data are
/// validated and handled securely. Methods provide asynchronous operations for logging in and registering users,
/// returning authentication responses that include user details and tokens when successful.</remarks>
public interface IUsersService
{
    /// <summary>
    /// Authenticates a user based on the provided login request and returns an authentication response containing user details 
    /// with a token if authentication is successful.
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login (LoginRequest loginRequest);
    /// <summary>
    /// Registers a new user account using the specified registration details.
    /// </summary>
    /// <param name="registerRequest">The registration request containing user information such as username, password, and email address. All fields
    /// must be valid and cannot be null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an AuthenticationResponse object
    /// with the outcome of the registration process, or null if registration fails.</returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}
