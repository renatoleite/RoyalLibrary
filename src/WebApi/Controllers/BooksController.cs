using Application.UseCases.ListBooksUseCase;
using Application.UseCases.ListBooksUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : Controller
    {
        private IListBooksUseCase _useCase { get; set; }

        public BooksController(IListBooksUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("authors/{author}")]
        public async Task<IActionResult> ListBooksByAuthor(string author, int page, int items, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _useCase.ExecuteAsync(new ListBooksInput
                {
                    Term = author, Items = items,
                    Page = page, Operation = Operation.ListBooksByAuthor
                }, cancellationToken);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("isbn/{isbnCode}")]
        public async Task<IActionResult> ListBooksByISBN(string isbnCode, int page, int items, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _useCase.ExecuteAsync(new ListBooksInput
                {
                    Term = isbnCode,
                    Items = items,
                    Page = page,
                    Operation = Operation.ListBooksByISBN
                }, cancellationToken);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> ListBooksByCategory(string category, int page, int items, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _useCase.ExecuteAsync(new ListBooksInput
                {
                    Term = category,
                    Items = items,
                    Page = page,
                    Operation = Operation.ListBooksByCategory
                }, cancellationToken);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> ListBooksByTitle(string title, int page, int items, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _useCase.ExecuteAsync(new ListBooksInput
                {
                    Term = title,
                    Items = items,
                    Page = page,
                    Operation = Operation.ListBooksByTitle
                }, cancellationToken);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("type/{type}")]
        public async Task<IActionResult> ListBooksByType(string type, int page, int items, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _useCase.ExecuteAsync(new ListBooksInput
                {
                    Term = type,
                    Items = items,
                    Page = page,
                    Operation = Operation.ListBooksByType
                }, cancellationToken);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
