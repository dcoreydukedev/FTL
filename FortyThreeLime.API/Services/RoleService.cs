/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Models.Entities;
using FortyThreeLime.Repository;
using System.Collections.Generic;
using FortyThreeLime.Data;
using System.Linq;

namespace FortyThreeLime.API.Services
{
    /// <summary>
    /// Provides Role Data
    /// </summary>
    internal sealed class RoleService : IAPIService
    {

        private ApplicationRepository<Role> _repo;
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        public RoleService()
        {
            _repo = new ApplicationRepository<Role>();
            this._context = new ApplicationDbContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="repo">The Role Repository.</param>
        public RoleService(ApplicationRepository<Role> repo)
        {
            _repo = repo;
            this._context = new ApplicationDbContext();
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>List of Role Objects</returns>
        public List<Role> GetAllRoles()
        {
            return (List<Role>)_repo.GetAll();
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>The specified Role</returns>
        public Role GetRole(int roleId)
        {
            return _repo.GetById(roleId);
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <returns>The specified Role Object</returns>
        public Role GetRole(string roleName)
        {
            return _context.Roles.Single(x => x.RoleName == roleName);
        }

        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        public Role CreateRole(string roleName)
        {
            Role r = new Role(roleName);
            _repo.Add(r);
            return r;
        }

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        public void DeleteRole(string roleName)
        {
            Role role = _context.Roles.Single(x => x.RoleName == roleName);
            _repo.Remove(role.Id);
        }
    }
}