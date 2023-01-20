using DataEntity;
using DomainModel.User;

namespace Repository
{
    public interface IUserOperation
    {
        Task<IEnumerable<UserDTO>> GetAllUser();
        Task<UserDTO> GetUserById(int userId);
        Task<UserDTO> Add(UserDTO user);
        Task<UserDTO> Update(UserDTO userChanges);
        Task DeleteUserByIdAsync(int userId);
        public Task<UserModel> Validate(string username, string password);
    }
}
