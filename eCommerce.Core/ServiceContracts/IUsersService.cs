using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts
{
    /// <summary>
    /// Business logic for user handling, such as login/registration
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Method to handle user login and returns Auth response object that contains the status
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
       Task <AuthenticationResponse?> Login(LoginRequest loginRequest);
        /// <summary>
        /// Method to handle user registration and returns authenticationresponse type
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
       Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
