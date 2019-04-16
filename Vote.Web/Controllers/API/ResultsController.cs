using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vote.Web.Controllers.API
{

    [Route("api/[Controller]")]

    public class ResultsController : Controller
    {

        public ResultsController (ResultRepository resultRepository)
        {
                
        }
    }
}
