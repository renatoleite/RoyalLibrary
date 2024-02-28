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

        [HttpGet("users/{userId}/owned")]
        public async Task<IActionResult> ListOwnedBooksByUser(int userId, int page, int items, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _useCase.ExecuteAsync(new ListBooksInput
                {
                    UserId = userId,
                    Items = items,
                    Page = page,
                    Operation = Operation.ListOwnedBooksByUserId
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

        [HttpGet("users/{userId}/loved")]
        public async Task<IActionResult> ListLovedBooksByUser(int userId, int page, int items, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _useCase.ExecuteAsync(new ListBooksInput
                {
                    UserId = userId,
                    Items = items,
                    Page = page,
                    Operation = Operation.ListLovedBooksByUserId
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


        [HttpGet("users/{userId}/want-read")]
        public async Task<IActionResult> ListWantToReadBooksByUser(int userId, int page, int items, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _useCase.ExecuteAsync(new ListBooksInput
                {
                    UserId = userId,
                    Items = items,
                    Page = page,
                    Operation = Operation.ListWantToReadBooksByUserId
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
