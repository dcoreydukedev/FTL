/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: DTO for AppAuth (DTO = Data Transfer Object)
 ************************************************************************/
using System;
using FortyThreeLime.Models.Entities;

namespace FortyThreeLime.Models.Domain
{
    /// <summary>
    ///  DTO for AppAuth
    /// </summary>
    [Serializable]
    public class AppAuthDTO
    {
        public string LoginToken { get; set; }
        public bool LoginTokenActive { get; set; }
        public Application App { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LoginExpires { get; set; }
        public DateTime? LogoutTime { get; set; }


        private AppAuthDTO()
        {
            
        }

        public AppAuthDTO(string loginToken, bool loginTokenActive, Application app, User user, Role role, DateTime loginTime, DateTime loginExpires, DateTime? logoutTime) : this()
        {
            this.LoginToken = loginToken;
            this.LoginTokenActive = loginTokenActive;
            this.App = app;
            this.User = user;
            this.Role = role;
            this.LoginTime = loginTime;
            this.LoginExpires = loginExpires;
            this.LogoutTime = logoutTime;
        }

    }

}
