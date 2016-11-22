using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WxOpenIdCore.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Ping";
        }

    }
}
