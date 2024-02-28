namespace Infrastructure.DataAccess.Scripts
{
    public static class BooksScripts
    {
        private const string QueryBooksColumn = @"
			SELECT
				b.book_id,
				title,
				first_name as FirstName,
				last_name as LastName,
				total_copies as TotalCopies,
				copies_in_use as CopiesInUse,
				[type],
				isbn,
				category
			FROM
				dbo.books b";

        private const string QueryPagination = @$"
			OFFSET @page ROWS
			FETCH NEXT @items ROWS ONLY;";

        public const string QueryTotalBooks = $@"
			SELECT
				count(b.book_id)
			FROM
				dbo.books b";

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

        public const string QueryListOwnedBooksByUserId =
            $@"{QueryBooksColumn}
				INNER JOIN user_books ub on ub.book_id = b.book_id
				WHERE
					ub.user_id = @userId and
					ub.own = 1
				ORDER BY book_id
				{QueryPagination}";

        public const string QueryListLovedBooksByUserId =
            $@"{QueryBooksColumn}
				INNER JOIN user_books ub on ub.book_id = b.book_id
				WHERE
					ub.user_id = @userId and
					ub.love = 1
				ORDER BY book_id
				{QueryPagination}";

        public const string QueryListWantToReadBooksByUserId =
            $@"{QueryBooksColumn}
				INNER JOIN user_books ub on ub.book_id = b.book_id
				WHERE
					ub.user_id = @userId and
					ub.want_to_read = 1
				{QueryPagination}";
    }
}
