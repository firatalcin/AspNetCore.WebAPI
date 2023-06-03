﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBook(bool trackChanges);
        Book GetOneBookById(int id, bool trackChanges);
        Book CreateOneBook(Book book);
        void UpdateOneBook(int id, Book booki, bool trackChanges);
        void DeleteOneBook(int id, bool trackChanges);
    }
}