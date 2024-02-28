using Application.Shared;
using Application.UseCases.ListBooksUseCase.Models;
using Domain.Dtos;

namespace Application.UseCases.ListBooksUseCase
{
    public interface IListBooksUseCase
    {
        Task<Output<BooksListDTO>> ExecuteAsync(ListBooksInput input, CancellationToken cancellationToken);
    }
}
