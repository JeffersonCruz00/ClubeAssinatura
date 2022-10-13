using AutoMapper;
using ClubeAss.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace ClubeAss.API.Customer.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
   
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _mediator.Send(new CustomerListRequest());

            return StatusCode(HttpStatusCode.OK.GetHashCode(), response);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post(CustomerAddRequest cliente)
        {
            var response = await _mediator.Send(cliente);

            return StatusCode(response.StatusCode.GetHashCode(), response.Content);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new CustomerGetRequest(id));

            return StatusCode(HttpStatusCode.OK.GetHashCode(), response);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CustomerUpdateRequest request)
        {
            var response = await _mediator.Send(request);

            return StatusCode(response.StatusCode.GetHashCode(), response.Content);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new CustomerDeleteRequest(id));

            return StatusCode(response.StatusCode.GetHashCode(), response.Content);
        }
    }
}