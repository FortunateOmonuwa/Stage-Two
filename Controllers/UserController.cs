using AutoMapper;
using BackendStageTwo.DataAccess.DTO;
using BackendStageTwo.DataAccess.Interface;
using BackendStageTwo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackendStageTwo.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;
        public UserController(IUser user , IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }


        [HttpGet("{user_id}")]
        public async Task<IActionResult> GetUserByID(string user_id)
        {
            try
            {
                var user = await _user.GetAsync(user_id);
                if(user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Source + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO newUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<User>(newUser);
                    await _user.CreateAsync(user);
                    return CreatedAtAction(nameof(GetUserByID), new {user_id = user.Id }, user);
                }
                else
                {
                    return BadRequest("Invalid data provided");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Source + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _user.GetAllAsync();
                if (users == null)
                {
                    return NotFound("No users were found");
                }
                else
                {
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Source + ex.Message);
            }
        }
        [HttpDelete("{user_id}")]
        public async Task<IActionResult> DeleteUser(string user_id)
        {
            try
            {
                var user = await _user.GetAsync(user_id);
                if(user == null)
                {
                    return NotFound($"User with Id: {user_id} doesn't exist");
                }
                else
                {
                    await _user.DeleteAsync(user_id);
                    return Ok("User successfully deleted");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Source + ex.Message);
            }
        }

        [HttpPut("{user_id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserCreateDTO user, string user_id)
        {
            try
            {
                var confirmUser = await _user.GetAsync(user_id);
                if (ModelState.IsValid && confirmUser != null)
                {
                    var updatedUser = _mapper.Map<User>(user);
                    updatedUser.Id = Convert.ToInt32( user_id);

                    await _user.UpdateAsync(updatedUser);
                    return Ok(updatedUser);
                }
                else
                {
                    return BadRequest("Invalid data provided");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Source + ex.Message);
            }
        }
    }
}
