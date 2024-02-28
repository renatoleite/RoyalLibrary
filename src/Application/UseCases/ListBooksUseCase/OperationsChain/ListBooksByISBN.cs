﻿using Application.UseCases.ListBooksUseCase.Models;
using Application.UseCases.ListBooksUseCase.OperationsChain.Abstractions;
using Domain.Dtos;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.ListBooksUseCase.OperationsChain
{
    public class ListBooksByISBN : AbstractHandler
    {
        public ListBooksByISBN(IBooksRepository booksRepository) : base(booksRepository)
        {
        }

        public async override Task<BooksListDTO> Handle(ListBooksInput request, CancellationToken cancellationToken)
        {
            if (request.Operation == Operation.ListBooksByISBN)
                return await _booksRepository.ListBooksByISBN(request.Term, request.Page, request.Items, cancellationToken);

            return await base.Handle(request, cancellationToken);
        }
    }
}
