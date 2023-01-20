using DataEntity;
using DomainModel.User;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace RepositoryHandler.MsSql.EF.User
{
    public class UserOperation : IUserOperation
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserOperation(ApplicationDbContext employeeDbContext)
        {
            applicationDbContext = employeeDbContext ?? throw new ArgumentNullException(nameof(employeeDbContext));
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get => applicationDbContext;
        }

        public async Task<UserDTO> Add(UserDTO user)
        {
            await ApplicationDbContext.Users.AddAsync(user);
            await ApplicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserByIdAsync(int userId)
        {
            UserDTO user = await ApplicationDbContext.Users.FindAsync(userId);
            if (user != null)
            {
                ApplicationDbContext.Users.Remove(user);
                await ApplicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUser()
        {
            var result = await ApplicationDbContext.Users.ToListAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            return await ApplicationDbContext.Users.FindAsync(userId);
        }

        public async Task<UserDTO> Update(UserDTO userChanges)
        {
            var user = ApplicationDbContext.Users.Attach(userChanges);
            user.State = EntityState.Modified;
            await ApplicationDbContext.SaveChangesAsync();
            return userChanges;
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
