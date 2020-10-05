/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: UserTask represents a Task performed by a user
 *              The UserTask consists of a collection of CommandLogRecords
 *              ex: Load Truck UserTask consists of several Load Truck 
 *                  Button Commands
 * Note: UserTask may be called Task. The name 'UserTask' is used to avoid 
 *       clashing with C# Task Keyword
 ************************************************************************/
using System;
using System.Collections.Generic;
using FortyThreeLime.Models.Domain;
using FortyThreeLime.Models.Entities;

namespace FortyThreeLime.Models.ViewModels
{
    public class UserTask : IReportViewModel
    {
        private Timestamp _timestamp = new Timestamp();

        private DateTime _StartTime, _EndTime;
        private TimeSpan _TotalTime, _AvgTimePerStep;
        private string _UserTaskName, _Username;
        private int _NumberOfSteps, _LastStep;
        private List<CommandLogRecord> _Steps;

        public UserTask(List<CommandLogRecord> log)
        {
            if (log == null)
            {
                throw new ArgumentException("Value for log cannot be null", "log");
            }

            if (log.Count < 2)
            {
                throw new ArgumentException("Value for log must contain at least 2 records", "log");
            }

            if (string.IsNullOrEmpty(log[0].Command.Command))
            {
                throw new ArgumentException("Command Must Be Provided", "log");
            }

            if (string.IsNullOrEmpty(log[0].User.Username))
            {
                throw new ArgumentException("User Must Be Provided", "log");
            }


            this._NumberOfSteps = log.Count;
            this._LastStep = log.Count - 1;
            this._StartTime = _timestamp.GetDateTimeFromEpoch(log[0].Timestamp);
            this._EndTime = _timestamp.GetDateTimeFromEpoch(log[this._LastStep].Timestamp);
            this._TotalTime = (this._EndTime - this._StartTime).Duration();
            this._AvgTimePerStep = new TimeSpan(this._TotalTime.Ticks / this._NumberOfSteps).Duration();
            this._UserTaskName = log[0].Command.Command.ToString().Trim();
            this._Username = log[0].User.Username.ToString().Trim();
            this._Steps = log;
        }

        public DateTime StartTime
        {
            get
            {
                return this._StartTime;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return this._EndTime;
            }
        }

        public TimeSpan TotalTime
        {
            get
            {
                return this._TotalTime;
            }

        }

        public TimeSpan AvgTimePerStep
        {
            get
            {
                return this._AvgTimePerStep;
            }
        }

        public string UserTaskName
        {
            get
            {
                return this._UserTaskName;
            }
        }

        public string Username
        {
            get
            {
                return this._Username;
            }
        }

        public int NumberOfSteps
        {
            get
            {
                return this._NumberOfSteps;
            }
        }

        public List<CommandLogRecord> Steps
        {
            get
            {
                return this._Steps;
            }
        }
    }
    
}
