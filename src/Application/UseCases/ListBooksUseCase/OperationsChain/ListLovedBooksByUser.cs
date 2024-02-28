using Application.UseCases.ListBooksUseCase.Models;
using Application.UseCases.ListBooksUseCase.OperationsChain.Abstractions;
using Domain.Dtos;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.ListBooksUseCase.OperationsChain
{
    public class ListLovedBooksByUser : AbstractHandler
    {
        public ListLovedBooksByUser(IBooksRepository booksRepository) : base(booksRepository)
        {
        }

        public async override Task<BooksListDTO> Handle(ListBooksInput request, CancellationToken cancellationToken)
        {
            if (request.Operation == Operation.ListLovedBooksByUserId)
                return await _booksRepository.ListLovedBooksByUserId(request.UserId, request.Page, request.Items, cancellationToken);

            return await base.Handle(request, cancellationToken);
        }
    }
}
