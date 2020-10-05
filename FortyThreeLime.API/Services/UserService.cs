/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Data;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Repository;
using FortyThreeLime.API.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace FortyThreeLime.API.Services
{
    /// <summary>
    /// Provides User Data
    /// </summary>
    internal sealed class UserService : IAPIService
    {
        private ApplicationDbContext _context;
        private ApplicationRepository<User> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        public UserService()
        {
            this._context = new ApplicationDbContext();
            this._repo = new ApplicationRepository<User>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repo">The User Repository.</param>
        public UserService(ApplicationRepository<User> repo)
        {
            this._context = new ApplicationDbContext();
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
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Specified User</returns>
        public User GetUser(int id)
        {
            return _repo.GetById(id);
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
        /// Gets the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public User GetUser(string userId)
        {
            return _context.Users.Where(u => u.UserId == userId).SingleOrDefault();

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
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The id of the user</param>
        private void DeleteUser(int id)
        {
            _repo.Remove(id);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The Id of the user</param>
        public void DeleteUser(string userId)
        {
            User user = _context.Users.Where(u => u.UserId == userId).SingleOrDefault();
            if(user != null)
            {
                DeleteUser(user.Id);
            }
        }


        /// <summary>
        /// Logs in the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public User LoginUser(string userId)
        {
            User user = _context.Users.Where(u => u.UserId == userId).SingleOrDefault();
            if(user != null)
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
        /// Logs out the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public User LogoutUser(string userId)
        {
            User user = _context.Users.Where(u => u.UserId == userId).SingleOrDefault();
            if (user != null)
            {
                user.IsOnline = false;
                user.IsActive  = true;
                UpdateUser(user);
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
            User user = _context.Users.Where(u => u.UserId == userId).SingleOrDefault();
            Role role = _context.Roles.Where(r => r.RoleName == roleName).SingleOrDefault();
            if(user != null && role != null)
            {
                return role.RoleName == roleName;
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
            User user = _context.Users.Where(u => u.UserId == userId).SingleOrDefault();
            return user == null;
        }
    }
}