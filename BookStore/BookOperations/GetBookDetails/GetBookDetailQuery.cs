using System.Collections.Generic;
using System.Linq;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using BookStore.Common;
using BookStore.BookOperations.GetBooks;
using System;
using AutoMapper;

namespace BookStore.BookOperations.GetBookDetails
{
    public class GetBookDetailQuery
    {
        public int BookId { get; set; } 
        private readonly BookStoreDBContext _context;
        private readonly Mapper _mapper;
        private BookStoreDBContext context;
        private IMapper mapper;

        public GetBookDetailQuery(BookStoreDBContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetBookDetailQuery(BookStoreDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public GetBookDetailViewModel Handle()
        { 
            var book = _context.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book == null)
                throw new InvalidOperationException("Kitap bulunmaadı.");
            GetBookDetailViewModel vm = _mapper.Map<GetBookDetailViewModel>(book);//new GetBookDetailViewModel();
            /*
            vm.Title = book.Title;
            vm.PageCount=book.PageCount;
            vm.Genre=((GenreEnum)book.Id).ToString();
            */

            return vm;
            

        }

    }

    public class GetBookDetailViewModel
    {
        public int PageCount;
        public string Genre;
        public string Title;
    }
}
