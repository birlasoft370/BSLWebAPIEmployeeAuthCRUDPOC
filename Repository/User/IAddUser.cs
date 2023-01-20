using DataEntity;

namespace Repository
{
    public interface IAddUser
    {
        Task<UserDTO> ExecuteAsync(UserDTO user);
    }
}
