using Microsoft.AspNetCore.Mvc;
using Wizardworks.Demo.Core.Feature.Squares.Model;
using Wizardworks.Demo.Core.Feature.Squares.Repository;
using Wizardworks.Demo.Core.Infrastructure.Extensions;

namespace Wizardworks.Demo.API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SquaresController(ISquaresRepository squaresRepository) : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var userId = Request.GetCurrentUserId();

            var vm = await squaresRepository.GetByIdAsync(userId);

            return Ok(vm);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(SquareItemModel model)
        {
            var userId = Request.GetCurrentUserId();

            var vm = await squaresRepository.AddAsync(userId, model);

            return Ok(vm);
        }
    }
}
