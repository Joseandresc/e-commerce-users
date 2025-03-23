using eCommerce.Core.DTO;                      // Contains Data Transfer Objects (DTOs) used to transfer data between layers
using eCommerce.Core.Entities;                 // Contains entity classes that represent database models
using eCommerce.Core.RepositoryContract;       // Contains interfaces for data access (repository pattern)
using eCommerce.Core.ServiceContracts;         // Contains interfaces for service layer contracts

namespace eCommerce.Core.Services
{
    // UsersService implements the IUsersService interface, providing business logic for user-related operations.
    public class UsersService : IUsersService
    {
        // Dependency: IUsersRepository is injected to handle data access related to users.
        private readonly IUsersRepository _usersRepository;

        // Constructor that takes in an IUsersRepository instance via dependency injection.
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        // Asynchronously processes a login request.
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            // Retrieve the user by email and password using the repository.
            ApplicationUser? applicationUser = await _usersRepository.GetUserByEmailPass(loginRequest.Email, loginRequest.Password);

            // If no matching user is found, return null indicating failed authentication.
            if (applicationUser == null)
            {
                return null;
            }

            // If user is found, create and return an AuthenticationResponse with user details and a dummy token.
            return new AuthenticationResponse(
                applicationUser.UserId,
                applicationUser.Email,
                applicationUser.PersonName,
                applicationUser.Gender,
                "dummy token", // In a real-world application, you would generate a valid token here.
                Success: true);
        }

        // Asynchronously processes a registration request.
        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            // Create a new ApplicationUser entity using the data from the registration request.
            ApplicationUser applicationUser = new ApplicationUser()
            {
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,  // In a real application, passwords should be hashed.
                Gender = registerRequest.Gender.ToString(),
            };

            // Add the new user to the repository (i.e., persist it to the database).
            ApplicationUser? registerUser = await _usersRepository.AddUser(applicationUser);

            // If registration fails (user could not be added), return null.
            if (registerUser == null)
            {
                return null;
            }

            // Return an AuthenticationResponse for the newly registered user.
            return new AuthenticationResponse(
                registerUser.UserId,
                registerUser.PersonName,
                registerUser.Email,
                registerUser.Gender,
                "Dummy token",  // In a real application, generate a valid token.
                Success: true);
        }
    }
}
