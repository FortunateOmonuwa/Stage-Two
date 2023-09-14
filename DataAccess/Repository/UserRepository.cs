using BackendStageTwo.DataAccess.Context;
using BackendStageTwo.DataAccess.Interface;
using BackendStageTwo.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BackendStageTwo.DataAccess.Repository
{
    public class UserRepository : IUser
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context; 
        }
        public async Task<User> CreateAsync(User user)
        {
            try
            {
                if(user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                else if(!Regex.IsMatch(user.Name, "^[a-zA-Z]+$"))
                {
                    throw new ArgumentException("Name should contain only alphabets.", nameof(user.Name));
                }
                else
                {                   
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return user;                  
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Source}/n {ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(int user_id)
        {
            try
            {
                var user =  await  _context.Users.FirstOrDefaultAsync(id => id.Id == user_id);
                if(user == null)
                {
                    return false;
                }
                else
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Source}/n {ex.Message}");
            }
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if(users != null)
                {
                    return users.AsQueryable();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Source}/n {ex.Message}");
            }
        }

        public async Task<User> GetAsync(int user_id)
        {
            try
            {
               var  user = await _context.Users.FirstOrDefaultAsync (d => d.Id == user_id);
                if(user == null)
                {
                    throw new Exception($"User with Id: {user_id} doesn't exists");
                }
                else
                {
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Source}/n {ex.Message}");
            }
        }

        public async Task<User> UpdateAsync(User updatedUser)
        {
            try
            {
                if (!Regex.IsMatch(updatedUser.Name, "^[a-zA-Z ]+$"))
                {
                    throw new ArgumentException("Name should contain only alphabets.", nameof(updatedUser.Name));
                }
                else
                {
                    var existingUser = await _context.Users.FindAsync(updatedUser.Id);
                    if (existingUser == null)
                    {
                        throw new Exception($"User with ID {updatedUser.Id} not found");
                    }

                    existingUser.Name = updatedUser.Name;
                   

                    await _context.SaveChangesAsync();
                    return existingUser;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Source}/n {ex.Message}");
            }
        }

    }
}
