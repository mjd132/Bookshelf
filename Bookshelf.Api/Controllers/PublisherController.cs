using Bookshelf.Application.Features.Publisher.Commands;
using Bookshelf.Application.Features.Publisher.Queries.GetAllPublishers;
using Bookshelf.Application.Features.Publisher.Queries.GetPublisherDetails;
using Bookshelf.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookshelf.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly IMediator _mediator;

    public PublisherController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/<PublisherController>
    [HttpGet]
    public async Task<PaginatedList<PublisherDto>> Get([FromQuery]int pageNumber ,[FromQuery] int pageSize)
    {
        var publishers = await _mediator.Send(new GetPublisherQuery(pageNumber,pageSize));
        return publishers;
    }

    // GET api/<PublisherController>/5
    [HttpGet("publisher-{id}")]
    public async Task<PublisherDetailsDto> Get(int id)
    {
        var publisher = await _mediator.Send(new GetPublisherDetailsQuery(id));

        return publisher;
    }

    // POST api/<PublisherController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePublisherCommand request)
    {
        var publisherId = await _mediator.Send(request);
        return CreatedAtAction(nameof (Get),new {Id = publisherId});
    }

    // PUT api/<PublisherController>/5
    [HttpPut()]
    public async Task<IActionResult> Put( [FromBody] UpdatePublisherCommand request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    // DELETE api/<PublisherController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeletePublisherCommand(id));
        return NoContent();
    }
}
