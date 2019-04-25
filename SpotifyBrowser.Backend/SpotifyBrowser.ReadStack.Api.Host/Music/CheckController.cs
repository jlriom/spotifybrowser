using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SpotifyBrowser.ReadStack.Api.Host.Music
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        [HttpGet("ThrowException")]
        public void ThrowException()
        {
            throw new Exception("This is an exception");
        }
    }
}