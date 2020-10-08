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
    

    /// <summary>
    /// Data Service For Command Log
    /// </summary>
    public sealed class CommandLogService 
    {

        private ApplicationDbContext _context;
        private Repository<CommandLogRecord> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLogService"/> class.
        /// </summary>
        public CommandLogService()
        {
            this._context = ApplicationDbContext.Create();
            this._repo = new Repository<CommandLogRecord>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLogService"/> class.
        /// </summary>
        public CommandLogService(ApplicationDbContext context, Repository<CommandLogRecord> repo)
        {
            this._context = context;
            this._repo = repo;
        }


        /// <summary>
        /// Gets the CommandLogs.
        /// </summary>
        /// <returns>List of CommandLogs</returns>
        public async Task<List<CommandLogRecord>> GetCommandLogs()
        {
            return (List<CommandLogRecord>) await _repo.GetAllAsync();
        }

        /// <summary>
        /// Gets the CommandLog.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Specified CommandLog</returns>
        public async Task<CommandLogRecord> GetCommandLog(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        /// <summary>
        /// Gets the command log records.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<List<CommandLogRecord>> GetCommandLogs(string userId)
        {
            return await _context.CommandLog.Where(u => u.UserId == userId).ToListAsync();

        }

        /// <summary>
        /// Gets the command log.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="commandId">The command identifier.</param>
        /// <returns></returns>
        public async Task<List<CommandLogRecord>> GetCommandLogs(string userId, int commandId)
        {
            return await _context.CommandLog.Where(u => u.UserId == userId && u.CommandId == commandId).ToListAsync();

        }

        /// <summary>
        /// Gets the command log.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="commandId">The command identifier.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns></returns>
        public async Task<List<CommandLogRecord>> GetCommandLogs(string userId, int commandId, long timestamp)
        {
            return await _context.CommandLog.Where(u => u.UserId == userId && u.CommandId == commandId && u.Timestamp == timestamp).ToListAsync();

        }

        /// <summary>
        /// Adds the command log.
        /// </summary>
        /// <param name="log">The log.</param>
        public async Task AddCommandLog(CommandLogRecord log)
        {
           await _repo.AddAsync(log);
           
        }

        /// <summary>
        /// Updates the CommandLog.
        /// </summary>
        /// <param name="u">The CommandLog</param>
        public async Task UpdateCommandLog(CommandLogRecord u)
        {
            await _repo.UpdateAsync(u);
        }

        /// <summary>
        /// Deletes the CommandLog.
        /// </summary>
        /// <param name="id">The id of the CommandLog</param>
        public async Task DeleteCommandLog(int id)
        {
            await _repo.DeleteAsync(id);
        }

    }
}