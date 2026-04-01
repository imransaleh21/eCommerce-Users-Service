using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.Enums;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

/// <summary>
/// Implements the IUsersRepository interface to provide functionality for managing user-related operations,
/// such as adding new users and retrieving users based on their email and password. 
/// This class serves as a concrete implementation of the repository pattern for user management in the eCommerce application.
/// </summary>
public class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;
    public UsersRepository(DapperDbContext dapperDbContext)
    {
        _dbContext = dapperDbContext;
    }
    /// <summary>
    /// Adds a new user to the repository. This method is responsible for taking an ApplicationUser object and adding it to the underlying data store.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public  async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        string query = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") " +
            "VALUES (@UserId, @Email, @PersonName, @Gender, @Password)";
        int rowsAffected = await _dbContext.GetDbConnection.ExecuteAsync(query, user);
        if (rowsAffected == 0) return null;
        return user;
    }

    /// <summary>
    /// Retrieves a user from the repository based on the provided email and password. This method is responsible for querying the underlying data store to find a user 
    /// that matches the given email and password combination, and returning the corresponding ApplicationUser object if found.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\"" +
            "WHERE \"Email\" = @Email AND \"Password\"= @Password";
        ApplicationUser? authUser = await _dbContext.GetDbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, 
            new {Email = email, Password = password }
            );

        if (authUser is not null) return authUser;
        else return null;
    }
}
