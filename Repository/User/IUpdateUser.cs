using DataEntity;

namespace Repository
{
    public interface IUpdateUser
    {
        Task<UserDTO> ExecuteAsync(UserDTO user);
    }
}
