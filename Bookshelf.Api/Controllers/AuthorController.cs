using Bookshelf.Application.Features.Author.Commands;
using Bookshelf.Application.Features.Author.Queries.GetAllAuthors;
using Bookshelf.Application.Features.Author.Queries.GetAuthorDetail;
using Bookshelf.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookshelf.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/<AuthorController>
    [HttpGet]
    public async Task<ActionResult<PaginatedList<AuthorDto>>> Get([FromQuery]int pageNumber=1,[FromQuery] int pageSize=10)
    {
        var authors = await _mediator.Send(new GetAuthorQuery(pageNumber, pageSize));

        return Ok(authors);
    }

    // GET api/<AuthorController>/author-5
    [HttpGet("author-{id}")]
    public async Task<ActionResult<AuthorDetailDto>> Get(int id)
    {
        var author = await _mediator.Send(new GetAuthorDetailQuery(id));
        return Ok(author);
    }

    // POST api/<AuthorController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAuthorCommand request)
    {
        var authorId = await _mediator.Send(request);

        return CreatedAtAction(nameof(Get), new {Id = authorId });
    }

    // PUT api/<AuthorController>/5
    [HttpPut()]
    public async Task<ActionResult> Put( [FromBody] UpdateAuthorCommand request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    // DELETE api/<AuthorController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteAuthorCommand(id));
        return NoContent(); 
    }
}
