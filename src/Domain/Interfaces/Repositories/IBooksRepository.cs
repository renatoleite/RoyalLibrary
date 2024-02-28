using Domain.Dtos;

namespace Domain.Interfaces.Repositories
{
    public interface IBooksRepository
    {
        Task<BooksListDTO> ListBooksByAuthor(string authorNameOrLastName, int page, int items, CancellationToken cancellationToken);
        Task<BooksListDTO> ListBooksByISBN(string isbnCode, int page, int items, CancellationToken cancellationToken);
        Task<BooksListDTO> ListOwnedBooksByUserId(int userId, int page, int items, CancellationToken cancellationToken);
        Task<BooksListDTO> ListLovedBooksByUserId(int userId, int page, int items, CancellationToken cancellationToken);
        Task<BooksListDTO> ListWantToReadBooksByUserId(int userId, int page, int items, CancellationToken cancellationToken);
    }
}
