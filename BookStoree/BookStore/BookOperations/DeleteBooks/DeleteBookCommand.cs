using System.Linq;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using BookStore.Common;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata;
using System;

namespace BookStore.BookOperations.DeleteBooks
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDBContext _context;
        public int bookID;

        public DeleteBookCommand(BookStoreDBContext context)
        {
            _context = context;
        }   

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == bookID);
            if (book is null)
                throw new InvalidOperationException("kitap bulunamadı");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
