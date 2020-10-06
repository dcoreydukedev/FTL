/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: AppAuth Entity. 
 *              Used To Track Logins
 ************************************************************************/
using FortyThreeLime.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace FortyThreeLime.Models.Entities
{
    public class AppAuth : IEntity<AppAuth>
    {

        public AppAuth()
        {

        }

        public AppAuth(LoginData data)
        {
            this.LoginToken = data.LoginToken;
            this.LoginTokenActive = data.LoginTokenActive;
            this.ApplicationId = data.App.Id;
            this.UserId = data.User.UserId;
            this.RoleId = data.Role.Id;
            this.LoginTime = data.LoginTime.ToString();
            this.LoginExpires = data.LoginExpires.ToString();
            this.LogoutTime = data.LogoutTime == null ? string.Empty : data.LogoutTime.ToString();

        }

        [Key]
        public int Id { get; set; }
        public string LoginToken { get; set; }
        public bool LoginTokenActive { get; set; }
        public int ApplicationId { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }
        public string LoginTime { get; set; }
        public string LoginExpires { get; set; }
        public string LogoutTime { get; set; }


        public virtual User User { get; set; }
        public virtual Application Application { get; set; }
        public virtual Role Role { get; set; }
    }
}
