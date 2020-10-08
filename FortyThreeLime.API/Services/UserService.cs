/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Data;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortyThreeLime.API.Services
{

    public interface IUserService : IAPIService, IDataService
    {
        User CreateUser(User u);
        Task<User> CreateUserAsync(User u);
        void DeleteUser(string userId);
        Task DeleteUserAsync(string userId);
        int GetCount();
        Task<int> GetCountAsync();
        User GetUser(int id);
        User GetUser(string userId);
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(string userId);
        List<User> GetUsers();
        Task<List<User>> GetUsersAsync();
        bool IsUserInRole(string userId, string roleName);
        Task<bool> IsUserInRoleAsync(string userId, string roleName);
        User LoginUser(string userId);
        Task<User> LoginUserAsync(string userId);
        User LogoutUser(string userId);
        Task<User> LogoutUserAsync(string userId);
        void UpdateUser(User u);
        Task UpdateUserAsync(User u);
        bool UserExists(string userId);
        Task<bool> UserExistsAsync(string userId);
    }

    /// <summary>
    /// Provides User Data
    /// </summary>
    public sealed class UserService : IUserService
    {
        private ApplicationDbContext _context;
        private Repository<User> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        public UserService()
        {
            this._context = ApplicationDbContext.Create();
            this._repo = new Repository<User>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="context">The Application DB Context</param>
        /// <param name="repo">The User Repository.</param>
        public UserService(ApplicationDbContext context, Repository<User> repo)
        {
            this._context = context;
            this._repo = repo;
        }


        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>List of Users</returns>
        public List<User> GetUsers()
        {
            return (List<User>)_repo.GetAll();
        }

        /// <summary>
        /// Gets the users asynchronously.
        /// </summary>
        /// <returns>List of Users</returns>
        public async Task<List<User>> GetUsersAsync()
        {
            return (List<User>)await _repo.GetAllAsync();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Specified User</returns>
        public User GetUser(int id)
        {
            return _repo.GetById(id);
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <param name="userId">The 4 character User Id</param>
        /// <returns>The Specified User</returns>
        public User GetUser(string userId)
        {
            return _context.Users.Single(u => u.UserId == userId);

        }

        /// <summary>
        /// Gets the user asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Specified User</returns>
        public async Task<User> GetUserAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        /// <summary>
        /// Gets the user asynchronously.
        /// </summary>
        /// <param name="userId">The 4 character User Id</param>
        /// <returns>The Specified User</returns>
        public async Task<User> GetUserAsync(string userId)
        {
            return await _context.Users.SingleAsync(u => u.UserId == userId);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="u">The user to create</param>
        /// <returns>The Newly Created User</returns>
        public User CreateUser(User u)
        {
            _repo.Add(u);
            return GetUser(u.UserId);
        }

        /// <summary>
        /// Creates the user asynchronously.
        /// </summary>
        /// <param name="u">The user to create</param>
        /// <returns>The Newly Created User</returns>
        public async Task<User> CreateUserAsync(User u)
        {
            await _repo.AddAsync(u);
            return await GetUserAsync(u.UserId);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="u">The user</param>
        public void UpdateUser(User u)
        {
            _repo.Update(u);
        }

        /// <summary>
        /// Updates the user asynchronously.
        /// </summary>
        /// <param name="u">The user</param>
        public async Task UpdateUserAsync(User u)
        {
            await _repo.UpdateAsync(u);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The id of the user</param>
        private void DeleteUser(int id)
        {
            _repo.Delete(id);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The Id of the user</param>
        public void DeleteUser(string userId)
        {
            User user = _context.Users.Single(u => u.UserId == userId);
            if (user != null)
            {
                DeleteUser(user.Id);
            }
        }

        /// <summary>
        /// Deletes the user asynchronously.
        /// </summary>
        /// <param name="id">The id of the user</param>
        private async Task DeleteUserAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        /// <summary>
        /// Deletes the user asynchronously.
        /// </summary>
        /// <param name="userId">The Id of the user</param>
        public async Task DeleteUserAsync(string userId)
        {
            User user = await _context.Users.SingleAsync(u => u.UserId == userId);
            if (user != null)
            {
                await DeleteUserAsync(user.Id);
            }
        }

        /// <summary>
        /// Logs in the user.
        /// </summary>
        /// <param name="userId">The 4 character user identifier.</param>
        public User LoginUser(string userId)
        {
            User user = _context.Users.Single(u => u.UserId == userId);
            if (user != null)
            {
                user.IsOnline = true;
                UpdateUser(user);
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Logs in the user asynchronously
        /// </summary>
        /// <param name="userId">The 4 character user identifier.</param>
        public async Task<User> LoginUserAsync(string userId)
        {
            User user = await _context.Users.SingleAsync(u => u.UserId == userId);
            if (user != null)
            {
                user.IsOnline = true;
                await UpdateUserAsync(user);
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Logs out the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public User LogoutUser(string userId)
        {
            User user = _context.Users.Single(u => u.UserId == userId);
            if (user != null)
            {
                user.IsOnline = false;
                UpdateUser(user);
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Logs out the user asynchronously
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public async Task<User> LogoutUserAsync(string userId)
        {
            User user = await _context.Users.SingleAsync(u => u.UserId == userId);
            if (user != null)
            {
                user.IsOnline = false;
                await UpdateUserAsync(user);
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Determines whether is user in role
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>
        ///   <c>true</c> if [is user in role] otherwise, <c>false</c>.
        /// </returns>
        public bool IsUserInRole(string userId, string roleName)
        {
            User user = _context.Users.Single(u => u.UserId == userId);
            Role role = _context.Roles.Single(r => r.RoleName == roleName);
            if (user != null && role != null)
            {
                return user.RoleId == role.Id;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether is user in role asynchronously
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>
        ///   <c>true</c> if [is user in role] otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> IsUserInRoleAsync(string userId, string roleName)
        {
            User user = await _context.Users.SingleAsync(u => u.UserId == userId);
            Role role = await _context.Roles.SingleAsync(r => r.RoleName == roleName);
            if (user != null && role != null)
            {
                return user.RoleId == role.Id;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Does The User Exist
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public bool UserExists(string userId)
        {
            return _context.Users.Single(u => u.UserId == userId) != null;

        }

        /// <summary>
        /// Does The User Exist
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public async Task<bool> UserExistsAsync(string userId)
        {
            return await _context.Users.SingleAsync(u => u.UserId == userId) != null;
        }

        /// <summary>
        /// Get A Count Of Users
        /// </summary>
        /// <returns>number of users n db</returns>
        public int GetCount()
        {
            return _repo.GetCount();
        }

        /// <summary>
        /// Gets the count asynchronously.
        /// </summary>
        /// <returns>number of users in db</returns>
        public async Task<int> GetCountAsync()
        {
            return await _repo.GetCountAsync();
        }
    }
}