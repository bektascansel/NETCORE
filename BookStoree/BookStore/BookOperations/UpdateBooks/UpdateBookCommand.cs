using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using BookStore.Common;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata;

namespace BookStore.BookOperations.UpdateBooks
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        private readonly BookStoreDBContext _context;
        public int BookID;

        public UpdateBookCommand(BookStoreDBContext context)
        {
            _context = context;
        }   

        public void handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookID);
            if (book is null)
                throw new InvalidOperationException("güncellenecek kitap bulunamadı");

           
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _context.SaveChanges();

        }
       
        //update edilmesini istediğimiz entityleri burada belirtiyoruz.
        public class UpdateBookModel
        {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
  
        }


    }


  
}
