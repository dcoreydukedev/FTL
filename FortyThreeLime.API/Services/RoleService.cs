/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Models.Entities;
using FortyThreeLime.Repository;
using System.Collections.Generic;
using FortyThreeLime.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FortyThreeLime.API.Services
{

    public interface IRoleService : IAPIService, IDataService
    {
        Role CreateRole(string roleName);
        Task<Role> CreateRoleAsync(string roleName);
        void DeleteRole(string roleName);
        Task DeleteRoleAsync(string roleName);
        Role GetRole(int roleId);
        Role GetRole(string roleName);
        Task<Role> GetRoleAsync(int roleId);
        Task<Role> GetRoleAsync(string roleName);
        List<Role> GetRoles();
        Task<List<Role>> GetRolesAsync();
    }

    /// <summary>
    /// Provides Role Data
    /// </summary>
    public sealed class RoleService : IRoleService
    {

        private Repository<Role> _repo;
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        public RoleService()
        {
            _repo = new Repository<Role>();
            _context = ApplicationDbContext.Create();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="context">The Application DB Context</param>
        /// <param name="repo">The Role Repository.</param>
        public RoleService(ApplicationDbContext context, Repository<Role> repo)
        {
            _repo = repo;
            this._context = context;
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>List of Roles</returns>
        public List<Role> GetRoles()
        {
            return (List<Role>)_repo.GetAll();
        }

        /// <summary>
        /// Gets all roles asynchronously.
        /// </summary>
        /// <returns>List of Roles</returns>
        public async Task<List<Role>> GetRolesAsync()
        {
            return (List<Role>)await _repo.GetAllAsync();
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
        /// Gets the role asynchronously.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>The specified Role</returns>
        public async Task<Role> GetRoleAsync(int roleId)
        {
            return await _repo.GetByIdAsync(roleId);
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
        /// Gets the role asynchronously.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <returns>The specified Role Object</returns>
        public async Task<Role> GetRoleAsync(string roleName)
        {
            return await _context.Roles.SingleAsync(x => x.RoleName == roleName);
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
        /// Creates the role asynchronously.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        public async Task<Role> CreateRoleAsync(string roleName)
        {
            Role r = new Role(roleName);
            await _repo.AddAsync(r);
            return r;
        }

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        public void DeleteRole(string roleName)
        {
            Role role = _context.Roles.Single(x => x.RoleName == roleName);
            _repo.Delete(role.Id);
        }

        /// <summary>
        /// Deletes the role asynchronously.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        public async Task DeleteRoleAsync(string roleName)
        {
            Role role = await _context.Roles.SingleAsync(x => x.RoleName == roleName);
            await _repo.DeleteAsync(role.Id);
        }
    }
}