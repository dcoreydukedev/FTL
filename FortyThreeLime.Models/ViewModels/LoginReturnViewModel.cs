/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: Data Object Returned to the Client 
 *              who sent the login request
 ************************************************************************/
using System;
using FortyThreeLime.Models.Entities;

namespace FortyThreeLime.Models.ViewModels
{
    /// <summary>
    /// Data Object Returned to the Client who sent the login request
    /// </summary>
    public class LoginReturnViewModel : IViewModel
    {
        public Guid LoginToken { get; set; }
        public Application App { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public long LoginTime { get; set; }

    }

}
