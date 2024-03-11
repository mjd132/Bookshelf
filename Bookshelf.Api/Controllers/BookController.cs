using Bookshelf.Application.Features.Book.Commands;
using Bookshelf.Application.Features.Book.Queries.GetAllBook;
using Bookshelf.Application.Features.Book.Queries.GetBookDetails;
using Bookshelf.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookshelf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<BookDto>>> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var booksPaginated = await _mediator.Send(new GetBookQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return booksPaginated;

        }

        // GET api/<BookController>/book-5
        [HttpGet("book-{id}")]
        public async Task<ActionResult<BookDetailsDto>> Get(int id)
        {
            var response = await _mediator.Send(new GetBookDetailsQuery(id));

            return Ok(response);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand request)
        {
            var response = await _mediator.Send(request);

            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateBookCommand request)
        {

            await _mediator.Send(request);
            return NoContent();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            await _mediator.Send(new DeleteBookCommand(id));
            return NoContent();

        }
    }
}
