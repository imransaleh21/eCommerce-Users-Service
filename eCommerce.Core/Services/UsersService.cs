using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
      ApplicationUser? applicationUser = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (applicationUser == null)  return null;
        return _mapper.Map<AuthenticationResponse>(applicationUser) with { IsAuthenticated = true, Token = "AuthToken" };
    }
    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        // Create a new ApplicationUser object from the RegisterRequest using AutoMapper
        ApplicationUser newUser = _mapper.Map<ApplicationUser>(registerRequest);
        newUser.UserId = Guid.NewGuid();

        ApplicationUser? registerUser = await _usersRepository.AddUser(newUser);
        if (registerUser == null) return null;
        return _mapper.Map<AuthenticationResponse>(newUser) with { IsAuthenticated = true, Token = "AuthToken" };
    }
}
