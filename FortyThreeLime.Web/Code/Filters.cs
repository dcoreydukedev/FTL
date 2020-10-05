/*************************************************************************
 * Author: DCoreyDuke
 * Custom Filters
 ************************************************************************/


using Microsoft.AspNetCore.Mvc.Filters;

namespace FortyThreeLime.Web
{

    /// <summary>
    /// Add Custom Headers To Every Request
    /// Sender Header and Token Header Together provide strong response validation
    /// </summary>
    public class AddAdminHeaderAttribute : ResultFilterAttribute, IResultFilter
    {
        internal string Token { get; } = @"juy934-_43LIME-0ab345";

        private string _Sender;

        public AddAdminHeaderAttribute(string sender)
        {
            this._Sender = sender;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }


        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("FortyThreeLime-Sender", this._Sender);
            filterContext.HttpContext.Response.Headers.Add("43LimeMobileApp-Token", this.Token);
        }
    }


}
