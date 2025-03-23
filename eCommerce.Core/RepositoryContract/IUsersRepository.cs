using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.RepositoryContract
{
    public interface IUsersRepository
    {
        /// <summary>
        /// Method to add user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<ApplicationUser?> AddUser(ApplicationUser user);

        /// <summary>
        /// Method to sign in the user based on given email/passwrod
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<ApplicationUser?> GetUserByEmailPass( string? email, string? password );
    }
}
