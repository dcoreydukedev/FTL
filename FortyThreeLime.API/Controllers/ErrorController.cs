/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FortyThreeLime.API.ViewModels;

namespace FortyThreeLime.API.Controllers
{
    public class ErrorController : Controller
    {
        public async Task<IActionResult> Error()
        {
            return await Task.Run(() => View(@"~/Views/Error/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }));
        }
    }
}
