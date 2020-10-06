/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Data;
using FortyThreeLime.Models.Entities;
using FortyThreeLime.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FortyThreeLime.API.Services
{
    public interface ICommandLogService : IAPIService
    {
        void AddCommandLog(CommandLogRecord log);
        void DeleteCommandLog(int id);
        void DeleteCommandLogs(string userId);
        void DeleteCommandLogs(string userId, int commandId);
        void DeleteCommandLogs(string userId, int commandId, long timestamp);
        CommandLogRecord GetCommandLog(int id);
        List<CommandLogRecord> GetCommandLogs();
        List<CommandLogRecord> GetCommandLogs(string userId);
        List<CommandLogRecord> GetCommandLogs(string userId, int commandId);
        List<CommandLogRecord> GetCommandLogs(string userId, int commandId, long timestamp);
        void UpdateCommandLog(CommandLogRecord u);
    }

    /// <summary>
    /// Data Service For Command Log
    /// </summary>
    public sealed class CommandLogService : ICommandLogService
    {

        private ApplicationDbContext _context;
        private ApplicationRepository<CommandLogRecord> _repo;

        

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLogService"/> class.
        /// </summary>
        /// <param name="repo">The CommandLog Repository</param>
        public CommandLogService(ApplicationDbContext context, ApplicationRepository<CommandLogRecord> repo)
        {
            this._context = context;
            this._repo = repo;
        }


        /// <summary>
        /// Gets the CommandLogs.
        /// </summary>
        /// <returns>List of CommandLogs</returns>
        public List<CommandLogRecord> GetCommandLogs()
        {
            return (List<CommandLogRecord>)_repo.GetAll();
        }

        /// <summary>
        /// Gets the CommandLog.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Specified CommandLog</returns>
        public CommandLogRecord GetCommandLog(int id)
        {
            return _repo.GetById(id);
        }

        /// <summary>
        /// Gets the command log records.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public List<CommandLogRecord> GetCommandLogs(string userId)
        {
            return _context.CommandLog.Where(u => u.UserId == userId).ToList();

        }

        /// <summary>
        /// Gets the command log.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="commandId">The command identifier.</param>
        /// <returns></returns>
        public List<CommandLogRecord> GetCommandLogs(string userId, int commandId)
        {
            return _context.CommandLog.Where(u => u.UserId == userId && u.CommandId == commandId).ToList();

        }

        /// <summary>
        /// Gets the command log.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="commandId">The command identifier.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns></returns>
        public List<CommandLogRecord> GetCommandLogs(string userId, int commandId, long timestamp)
        {
            return _context.CommandLog.Where(u => u.UserId == userId && u.CommandId == commandId && u.Timestamp == timestamp).ToList();

        }

        /// <summary>
        /// Adds the command log.
        /// </summary>
        /// <param name="log">The log.</param>
        public void AddCommandLog(CommandLogRecord log)
        {
            _repo.Add(log);
            //Add new log
            _context.CommandLog.Add(log);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the CommandLog.
        /// </summary>
        /// <param name="u">The CommandLog</param>
        public void UpdateCommandLog(CommandLogRecord u)
        {
            _repo.Update(u);
        }

        /// <summary>
        /// Deletes the CommandLog.
        /// </summary>
        /// <param name="id">The id of the CommandLog</param>
        public void DeleteCommandLog(int id)
        {
            _repo.Remove(id);
        }

        /// <summary>
        /// Deletes the command logs.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public void DeleteCommandLogs(string userId)
        {
            List<CommandLogRecord> CommandLogList = _context.CommandLog.Where(u => u.UserId == userId).ToList();

            if (CommandLogList.Count > 0)
            {
                foreach (CommandLogRecord commandLog in CommandLogList)
                {
                    DeleteCommandLog(commandLog.Id);
                }
            }
        }

        /// <summary>
        /// Deletes the command logs.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="commandId">The command identifier.</param>
        public void DeleteCommandLogs(string userId, int commandId)
        {
            List<CommandLogRecord> CommandLogList = _context.CommandLog.Where(u => u.UserId == userId && u.CommandId == commandId).ToList();

            if (CommandLogList.Count > 0)
            {
                foreach (CommandLogRecord commandLog in CommandLogList)
                {
                    DeleteCommandLog(commandLog.Id);
                }
            }
        }

        /// <summary>
        /// Deletes the command logs.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="commandId">The command identifier.</param>
        /// <param name="timestamp">The timestamp.</param>
        public void DeleteCommandLogs(string userId, int commandId, long timestamp)
        {
            List<CommandLogRecord> CommandLogList = _context.CommandLog.Where(u => u.UserId == userId && u.CommandId == commandId && u.Timestamp == timestamp).ToList();

            if (CommandLogList.Count > 0)
            {
                foreach (CommandLogRecord commandLog in CommandLogList)
                {
                    DeleteCommandLog(commandLog.Id);
                }
            }
        }

    }
}