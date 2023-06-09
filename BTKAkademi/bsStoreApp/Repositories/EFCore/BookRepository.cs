﻿using Entities.Models;
using Repositories.Contracts;
using Repositories.EFCore.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book)
        {
            Create(book);
        }

        public void DeleteOneBook(Book book)
        {
            Delete(book);
        }

        public IQueryable<Book> GetAllBook(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(x => x.Id);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            return FindByCondition(x => x.Equals(id), trackChanges).SingleOrDefault();
        }

        public void UpdateOneBook(Book book)
        {
            Update(book);
        }
    }
}
