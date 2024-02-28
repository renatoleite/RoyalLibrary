using Domain;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.DataAccess.Scripts;
using Infrastructure.DataAccess.SqlServer.Context;

namespace Infrastructure.DataAccess.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IDbConnectionWrapper _dbConnectionWrapper;

        public BooksRepository(IDbConnectionWrapper dbConnectionWrapper)
        {
            _dbConnectionWrapper = dbConnectionWrapper;
        }

        public async Task<BooksListDTO> ListBooksByAuthor(string authorNameOrLastName, int page, int items, CancellationToken cancellationToken)
        {
            var books = await _dbConnectionWrapper.QuerySingleAsync<IEnumerable<Book>>(
                BooksScripts.QueryListBooksByAuthor,
                new
                {
                    authorNameOrLastName = $"%{authorNameOrLastName}%",
                    items, page = CalculatePagination(page, items)
                }, cancellationToken);

            var total = await _dbConnectionWrapper.QuerySingleOrDefaultAsync<int>(
                BooksScripts.QueryTotalBooks, new { }, cancellationToken);

            return new BooksListDTO(total, books);
        }

        public async Task<BooksListDTO> ListBooksByISBN(string isbnCode, int page, int items, CancellationToken cancellationToken)
        {
            var books = await _dbConnectionWrapper.QuerySingleAsync<IEnumerable<Book>>(
                BooksScripts.QueryListBooksByISBN,
                new
                {
                    isbnCode = $"%{isbnCode}%",
                    items, page = CalculatePagination(page, items)
                }, cancellationToken);

            var total = await _dbConnectionWrapper.QuerySingleOrDefaultAsync<int>(
                BooksScripts.QueryTotalBooks, new { }, cancellationToken);

            return new BooksListDTO(total, books);
        }

        public async Task<BooksListDTO> ListOwnedBooksByUserId(int userId, int page, int items, CancellationToken cancellationToken)
        {
            var books = await _dbConnectionWrapper.QuerySingleAsync<IEnumerable<Book>>(
                BooksScripts.QueryListOwnedBooksByUserId,
                new { userId, items, page = CalculatePagination(page, items) },
                cancellationToken);

            var total = await _dbConnectionWrapper.QuerySingleOrDefaultAsync<int>(
                BooksScripts.QueryTotalBooks, new { }, cancellationToken);

            return new BooksListDTO(total, books);
        }

        public async Task<BooksListDTO> ListLovedBooksByUserId(int userId, int page, int items, CancellationToken cancellationToken)
        {
            var books = await _dbConnectionWrapper.QuerySingleAsync<IEnumerable<Book>>(
                BooksScripts.QueryListLovedBooksByUserId,
                new { userId, items, page = CalculatePagination(page, items) },
                cancellationToken);

            var total = await _dbConnectionWrapper.QuerySingleOrDefaultAsync<int>(
                BooksScripts.QueryTotalBooks, new { }, cancellationToken);

            return new BooksListDTO(total, books);
        }

        public async Task<BooksListDTO> ListWantToReadBooksByUserId(int userId, int page, int items, CancellationToken cancellationToken)
        {
            var books = await _dbConnectionWrapper.QuerySingleAsync<IEnumerable<Book>>(
                BooksScripts.QueryListWantToReadBooksByUserId,
                new { userId, items, page = CalculatePagination(page, items) },
                cancellationToken);

            var total = await _dbConnectionWrapper.QuerySingleOrDefaultAsync<int>(
                BooksScripts.QueryTotalBooks, new { }, cancellationToken);

            return new BooksListDTO(total, books);
        }

        private int CalculatePagination(int page, int items) => page * items;
    }
}
