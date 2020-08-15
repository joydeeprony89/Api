using System;
using System.Threading.Tasks;
using Api.Businesss;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwoApiController : ControllerBase
    {
        private readonly IItemService itemService;

        public TwoApiController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet("ItemsByName")]
        public async Task<IActionResult> Get(int pageNo = 1, int pageSize = 10, string itemName = "")
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(itemName) && ( itemName.Length < 3 || itemName.Length > 12)) 
                    return BadRequest("Please enter text between 3 to 12 characters");
                return Ok(await itemService.Get(pageNo, pageSize, itemName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string categoryName)
        {
            try
            {
                return Ok(await itemService.Delete(categoryName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
