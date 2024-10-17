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
            var sessionId = Request.HttpContext.Session.GetCurrentSessionId();

            var vm = await squaresRepository.GetByIdAsync(sessionId);

            return Ok(vm);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(SquareItemModel model)
        {
            var sessionId = Request.HttpContext.Session.GetCurrentSessionId();

            var vm = await squaresRepository.AddAsync(sessionId, model);

            return Ok(vm);
        }
    }
}
