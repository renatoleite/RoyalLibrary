using Application.UseCases.ListBooksUseCase.Models;
using Domain.Dtos;

namespace Application.UseCases.ListBooksUseCase.OperationsChain.Abstractions
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        Task<BooksListDTO> Handle(ListBooksInput request, CancellationToken cancellationToken);
    }
}
