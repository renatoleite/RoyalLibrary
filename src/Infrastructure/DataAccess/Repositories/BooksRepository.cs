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
            var books = await _dbConnectionWrapper.QueryAsync<Book>(
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
            var books = await _dbConnectionWrapper.QueryAsync<Book>(
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

        public async Task<BooksListDTO> ListBooksByTitle(string title, int page, int items, CancellationToken cancellationToken)
        {
            var books = await _dbConnectionWrapper.QueryAsync<Book>(
                BooksScripts.QueryListBooksByTitle,
                new { title = $"%{title}%", items, page = CalculatePagination(page, items) },
                cancellationToken);

            var total = await _dbConnectionWrapper.QuerySingleOrDefaultAsync<int>(
                BooksScripts.QueryTotalBooks, new { }, cancellationToken);

            return new BooksListDTO(total, books);
        }

        public async Task<BooksListDTO> ListBooksByType(string type, int page, int items, CancellationToken cancellationToken)
        {
            var books = await _dbConnectionWrapper.QueryAsync<Book>(
                BooksScripts.QueryListBooksByType,
                new { type = $"%{type}%", items, page = CalculatePagination(page, items) },
                cancellationToken);

            var total = await _dbConnectionWrapper.QuerySingleOrDefaultAsync<int>(
                BooksScripts.QueryTotalBooks, new { }, cancellationToken);

            return new BooksListDTO(total, books);
        }

        public async Task<BooksListDTO> ListBooksByCategory(string category, int page, int items, CancellationToken cancellationToken)
        {
            var books = await _dbConnectionWrapper.QueryAsync<Book>(
                BooksScripts.QueryListBooksByCategory,
                new { category = $"%{category}%", items, page = CalculatePagination(page, items) },
                cancellationToken);

            var total = await _dbConnectionWrapper.QuerySingleOrDefaultAsync<int>(
                BooksScripts.QueryTotalBooks, new { }, cancellationToken);

            return new BooksListDTO(total, books);
        }

        private int CalculatePagination(int page, int items) => page * items;
    }
}
