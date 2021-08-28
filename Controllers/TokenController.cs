using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_desafio21dias.ModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_desafio21dias.Controllers
{
    [ApiController]
    [Route("/token")]
    public class TokenController : ControllerBase
    {
        [HttpHead]
        public ActionResult Index() { 
            return StatusCode(204);
        }
    }
}
