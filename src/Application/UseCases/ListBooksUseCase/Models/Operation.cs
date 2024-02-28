namespace Application.UseCases.ListBooksUseCase.Models
{
    public enum Operation
    {
        ListBooksByAuthor,
        ListBooksByISBN,
        ListOwnedBooksByUserId,
        ListLovedBooksByUserId,
        ListWantToReadBooksByUserId
    }
}
