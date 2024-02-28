using Domain.Dtos;

namespace Domain.Interfaces.Repositories
{
    public interface IBooksRepository
    {
        Task<BooksListDTO> ListBooksByAuthor(string authorNameOrLastName, int page, int items, CancellationToken cancellationToken);
        Task<BooksListDTO> ListBooksByISBN(string isbnCode, int page, int items, CancellationToken cancellationToken);
        Task<BooksListDTO> ListBooksByTitle(string title, int page, int items, CancellationToken cancellationToken);
        Task<BooksListDTO> ListBooksByType(string type, int page, int items, CancellationToken cancellationToken);
        Task<BooksListDTO> ListBooksByCategory(string category, int page, int items, CancellationToken cancellationToken);
    }
}
