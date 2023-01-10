using DataEntity;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryHandler.MsSql.EF
{
    public class UserOperation : IuserOperation
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserOperation(ApplicationDbContext employeeDbContext)
        {
            this.applicationDbContext = employeeDbContext ?? throw new ArgumentNullException(nameof(employeeDbContext));
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get => this.applicationDbContext;
        }

        public async Task<UserModel> Validate(string username, string password)
        {
            UserDTO userDTO = await ApplicationDbContext.Users.FirstOrDefaultAsync(x => x.UserName == username.Trim().ToLower() && x.Password == password.Trim().ToLower());
            
            if (userDTO == null)
            {
                return new UserModel() { Id = 0, UserName = "", Password = "" };
            };
            UserModel userModel = new UserModel() { Id = userDTO.Id, UserName = userDTO.UserName, Password = userDTO.Password };

            return await Task.FromResult(userModel);

        }
    }
}
