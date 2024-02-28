using Domain.Entities;

namespace Domain.Dtos
{
    public class BooksListDTO
    {
        public BooksListDTO(int totalBooks, IEnumerable<Book> books)
        {
            TotalBooks = totalBooks;
            Books = books.Select(b => new BookDTO(b.Title, b.Authors, b.Type, b.ISBN, b.Category, b.AvailableCopies));
        }

        public int TotalBooks { get; set; }
        public IEnumerable<BookDTO> Books { get; set; }
    }
}
