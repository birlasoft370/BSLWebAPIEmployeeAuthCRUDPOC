using DataEntity;

namespace Repository
{
    public interface IGetUserById
    {
        Task<UserDTO> ExecuteAsync(int id);
    }
}
