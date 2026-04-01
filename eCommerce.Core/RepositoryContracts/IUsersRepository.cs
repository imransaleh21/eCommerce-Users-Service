using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;
/// <summary>
/// Defines the contract for a repository that manages user-related operations, such as adding new users and retrieving users based on their email and password.
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Adds a new user to the repository.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    /// <summary>
    /// Retrieves a user from the repository based on the provided email and password.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
}
