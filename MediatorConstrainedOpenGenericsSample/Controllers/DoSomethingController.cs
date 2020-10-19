using MediatorConstrainedOpenGenericsSample.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MediatorConstrainedOpenGenericsSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoSomethingController : ControllerBase
    {
        private readonly ISender _sender;

        public DoSomethingController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _sender.Send(new DoSomethingCommand()));
        }
    }
}
