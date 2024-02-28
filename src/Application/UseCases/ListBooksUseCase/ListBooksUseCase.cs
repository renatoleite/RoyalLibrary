using Application.Shared;
using Application.UseCases.ListBooksUseCase.Models;
using Application.UseCases.ListBooksUseCase.OperationsChain;
using Application.UseCases.ListBooksUseCase.OperationsChain.Abstractions;
using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ListBooksUseCase
{
    public class ListBooksUseCase : IListBooksUseCase
    {
        private readonly ILogger<ListBooksUseCase> _logger;
        private readonly IBooksRepository _booksRepository;

        public ListBooksUseCase(ILogger<ListBooksUseCase> logger, IBooksRepository bookRepository)
        {
            _logger = logger;
            _booksRepository = bookRepository;
        }

        public async Task<Output<BooksListDTO>> ExecuteAsync(ListBooksInput input, CancellationToken cancellationToken)
        {
            try
            {
                var listBooks = CreateBooksChain();
                return new Output<BooksListDTO>(await listBooks.Handle(input, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{UseCase} - An unexpected error has occurred", nameof(ListBooksUseCase));
                throw;
            }
        }

        private IHandler CreateBooksChain()
        {
            var listBooks = new ListBooksByAuthor(_booksRepository);

            listBooks
                .SetNext(new ListBooksByISBN(_booksRepository))
                .SetNext(new ListLovedBooksByUser(_booksRepository))
                .SetNext(new ListOwnedBooksByUser(_booksRepository))
                .SetNext(new ListWantToReadBooksByUser(_booksRepository));

            return listBooks;
        }
    }
}
