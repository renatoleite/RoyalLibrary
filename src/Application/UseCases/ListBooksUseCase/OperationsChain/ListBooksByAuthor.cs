using Application.UseCases.ListBooksUseCase.Models;
using Application.UseCases.ListBooksUseCase.OperationsChain.Abstractions;
using Domain.Dtos;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.ListBooksUseCase.OperationsChain
{
    public class ListBooksByAuthor : AbstractHandler
    {
        public ListBooksByAuthor(IBooksRepository booksRepository) : base(booksRepository)
        {
        }

        public async override Task<BooksListDTO> Handle(ListBooksInput request, CancellationToken cancellationToken)
        {
            if (request.Operation == Operation.ListBooksByAuthor)
                return await _booksRepository.ListBooksByAuthor(request.Term, request.Page, request.Items, cancellationToken);

            return await base.Handle(request, cancellationToken);
        }
    }
}
