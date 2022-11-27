using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using BookStore.Common;
using BookStore.BookOperations.GetBooks;
using AutoMapper;

namespace BookStore.BookOperations.CreateBooks
{
    public class CreateBookCommand
    {
        public CreateBookModel Model;
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title ==Model.Title);
            if (book != null)
                throw new InvalidOperationException("kitap zaten mevcut");

            //model ile gelen veriyi book nesnesine mapleme yapar bizim elle mapleme yapmamıza gerek kalmaz 
            book = _mapper.Map<Book>(Model); //new Book();
            /*
            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PageCount=Model.PageCount;
            */

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
