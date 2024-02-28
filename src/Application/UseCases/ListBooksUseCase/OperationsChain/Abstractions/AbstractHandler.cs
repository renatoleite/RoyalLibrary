using Application.UseCases.ListBooksUseCase.Models;
using Domain.Dtos;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.ListBooksUseCase.OperationsChain.Abstractions
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        protected readonly IBooksRepository _booksRepository;

        protected AbstractHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual Task<BooksListDTO> Handle(ListBooksInput request, CancellationToken cancellationToken)
        {
            if (this._nextHandler != null)
                return this._nextHandler.Handle(request, cancellationToken);
            
            return null;
        }
    }
}
