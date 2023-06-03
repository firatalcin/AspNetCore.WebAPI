using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _loggerService;

        public BookManager(IRepositoryManager manager, ILoggerService loggerService)
        {
            _manager = manager;
            _loggerService = loggerService;
        }

        public Book CreateOneBook(Book book)
        {
            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);

            if (entity is null)
            {
                string message = $"The book with id:{id} could not found";
                _loggerService.LogInfo(message);
                throw new Exception(message);
            }
              

            _manager.Book.DeleteOneBook(entity);
            _manager.Save();

        }

        public IEnumerable<Book> GetAllBook(bool trackChanges)
        {
            return _manager.Book.GetAllBook(false);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            return _manager.Book.GetOneBookById(id, false);
        }

        public void UpdateOneBook(int id, Book book, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id,trackChanges);

            if (entity is null)
            {
                string message = $"Book with id:{id} could not found.";
                _loggerService.LogInfo(message);
                throw new Exception(message);
            }
                

           

            entity.Title = book.Title;
            entity.Price = book.Price;
            _manager.Book.Update(entity);
            _manager.Save();
        }
    }
}
