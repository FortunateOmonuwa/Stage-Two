using BackendStageTwo.Models;

namespace BackendStageTwo.DataAccess.Interface
{
    public interface IUser
    {
        Task <User> CreateAsync (User user);
        Task<User> UpdateAsync (User user);
        Task<bool> DeleteAsync (string user_id);
        Task<User> GetAsync (string user_id);
        Task<IQueryable<User>> GetAllAsync();

    }
}
