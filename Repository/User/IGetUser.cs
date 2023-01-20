using DataEntity;

namespace Repository
{
    public interface IGetUser
    {
        Task<IEnumerable<UserDTO>> ExecuteAsync();
    }
}
