using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using BookStore.Common;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBookQuery
    {
        private readonly BookStoreDBContext _dbContext;
        public GetBookQuery(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        //asıl işi yapacak olan handle oluşturulacak.

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();

            //booklisti booksviewmodele dönüştürmemiz lazım
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PageCount = book.PageCount,
                });
            }

            _dbContext.SaveChanges();
            return vm;
        }

       }

      public class BooksViewModel
    { 
        //ıd aslında uı da kullanıcıya birşey ifade etmediğinden burada kullanmamıza gerek yok
        //public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }  
        public string Genre { get; set; }

   


    }
}
