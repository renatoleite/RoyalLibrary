namespace Infrastructure.DataAccess.Scripts
{
    public static class BooksScripts
    {
        private const string QueryBooksColumn = @"
			SELECT
				book_id,
				title,
				first_name as FirstName,
				last_name as LastName,
				total_copies as TotalCopies,
				copies_in_use as CopiesInUse,
				type,
				isbn,
				category
			FROM
				dbo.books";

        private const string QueryPagination = @$"
			OFFSET @page ROWS
			FETCH NEXT @items ROWS ONLY;";

        public const string QueryTotalBooks = $@"
			SELECT
				count(book_id)
			FROM
				dbo.books";

        public const string QueryListBooksByAuthor =
            $@"{QueryBooksColumn}
				WHERE
					first_name LIKE @authorNameOrLastName
					or last_name LIKE @authorNameOrLastName
					ORDER BY book_id
				{QueryPagination}";

        public const string QueryListBooksByISBN =
            $@"{QueryBooksColumn}
				WHERE
					isbn LIKE @isbnCode
					ORDER BY book_id
				{QueryPagination}";

        public const string QueryListBooksByTitle =
            $@"{QueryBooksColumn}
				WHERE
					title LIKE @title
				ORDER BY book_id
				{QueryPagination}";

        public const string QueryListBooksByType =
            $@"{QueryBooksColumn}
				WHERE
					type LIKE @type
				ORDER BY book_id
				{QueryPagination}";

        public const string QueryListBooksByCategory =
            $@"{QueryBooksColumn}
				WHERE
					category LIKE @category
				ORDER BY book_id
				{QueryPagination}";
    }
}
