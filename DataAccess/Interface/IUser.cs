using BackendStageTwo.Models;

namespace BackendStageTwo.DataAccess.Interface
{
    public interface IUser
    {
        Task <User> CreateAsync (User user);
        Task<User> UpdateAsync (User user);
        Task<bool> DeleteAsync (int user_id);
        Task<User> GetAsync (int user_id);
        Task<IQueryable<User>> GetAllAsync();

    }
}
