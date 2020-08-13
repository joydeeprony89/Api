using System;
using Api.Businesss;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConnectController : ControllerBase
    {
        private readonly IUserConnectService userConnectService;

        public UserConnectController(IUserConnectService userConnectService)
        {
            this.userConnectService = userConnectService;
        }

        [HttpGet("allmails")]
        public IActionResult GetAllMails()
        {
            try
            {
                var response = userConnectService.GetAllMails();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
