using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext;
public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly  IDbConnection _dbConnection;
    public DapperDbContext(IConfiguration configuration)
    {
        // Initialize the DapperDbContext with the provided configuration,
        // which is used to retrieve the database connection string and establish a connection to the PostgreSQL database.
        _configuration = configuration;
        // Retrieve the connection string for the PostgreSQL database from the configuration and create a new NpgsqlConnection using that connection string,
        // which will be used for database operations in the DapperDbContext.
        string? connectionString = _configuration.GetConnectionString("PostgreSqlConnection");
        _dbConnection = new NpgsqlConnection(connectionString);
    }
    public IDbConnection GetDbConnection => _dbConnection;
}
