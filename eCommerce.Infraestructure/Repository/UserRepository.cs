using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Infraestructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infraestructure.Repository
{
    internal class UserRepository : IUsersRepository
    {
        private readonly DapperDbContext? _dbContext;
        public UserRepository(DapperDbContext? dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            //SQL query to insert user into the database
            //string query = "INSERT INTO public.\"Users\" (\"UserId\", \"Email\", \"Password\", \"PersonName\") VALUES (@UserId, @Email, @Password, @PersonName)";
            string query = @"INSERT INTO public.""Users"" (""UserId"", ""Email"", ""Password"", ""PersonName"")
                           VALUES (@UserId, @Email, @Password, @PersonName)";
            int? rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
            if (rowCountAffected > 0)
            {
                return user;
            }
            else
                return null;
        }

        public async Task<ApplicationUser?> GetUserByEmailPass(string? email, string? password)
        {
            string query = @"SELECT * FROM public.""Users"" WHERE ""Email"" = @Email AND ""Password"" = @Password";
            var user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Email = email, Password = password });
            return user;
        }
    }
}
