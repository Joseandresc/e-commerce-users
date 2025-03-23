using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infraestructure.Repository
{
    internal class UserRepository : IUsersRepository
    {
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            user.CreatedAt = DateTime.Now;
            
            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailPass(string? email, string? password)
        {
            return new ApplicationUser()
            {
                Email = email,
                Password = password,
                UserId = Guid.NewGuid(),
                PersonName = "Person name",
                Gender = GenderOptions.Male.ToString(),
            };
        }
    }
}
