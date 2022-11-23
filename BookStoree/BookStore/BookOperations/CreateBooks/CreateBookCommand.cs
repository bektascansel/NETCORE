using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using BookStore.Common;
using BookStore.BookOperations.GetBooks;

namespace BookStore.BookOperations.CreateBooks
{
    public class CreateBookCommand
    {
        public CreateBookModel Model;
        private readonly BookStoreDBContext _context;
        public CreateBookCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title ==Model.Title);
            if (book != null)
                throw new InvalidOperationException("kitap zaten mevcut");

            book = new Book();
            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PageCount=Model.PageCount;

            _context.Books.Add(book);
            _context.SaveChanges();
        }




    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }

        public  int  GenreId { get; set; }
    }
}
