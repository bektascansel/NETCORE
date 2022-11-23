using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.DBOperations;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.CreateBooks;
using BookStore.BookOperations.GetBookDetails;
using BookStore.BookOperations.UpdateBooks;
using static BookStore.BookOperations.UpdateBooks.UpdateBookCommand;
using BookStore.BookOperations.DeleteBooks;

namespace BookStore.BookController
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        /*private static List<Book> BookList = new List<Book>(){

          new Book{
              Id=1,
              Title="lean Startup",
              GenreId=1, //personal grouth
              PageCount=200,


          },

          new Book{
              Id=2,
              Title="herland",
              GenreId=2, //personal grouth
              PageCount=250,


          },

          new Book{
              Id=3,
              Title="dune",
              GenreId=3, //personal grouth
              PageCount=500,


          }
        };
        DataGenerater üzerinde yapıldı.

       */




        //database üzerinden işlemleri yapabilmemiz için ilk olarak nesne yarattık.
        private readonly BookStoreDBContext _context;


        public BookController(BookStoreDBContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult GetBooks()
        {   
            /*
            //Linq Order By Metodunu kullanarak listeler üzerinde belirtilen değere göre sıralama işlemi yapılmasını sağlayabiliriz
            var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            _context.SaveChanges();
            return bookList;
            */

            GetBookQuery query=new GetBookQuery(_context);
            var result=query.Handle();
            return Ok(result);
        }






        //http requestleri karşılayacak olan endpointler

        //tüm bookları geri döndüren endpoint 

        /*
        [HttpGet]
        public List<Book> GetBooks()
        {
           //Linq Order By Metodunu kullanarak listeler üzerinde belirtilen değere göre sıralama işlemi yapılmasını sağlayabiliriz
           var bookList=BookList.OrderBy(x=>x.Id).ToList<Book>();
           return bookList;
        }
        */


        /*route üzerinden ıd alınarak book dondurme 
        [HttpGet("{id}")]
        public Book GetById(int id)
        {    
            //Linq Order By Metodunu kullanarak listeler üzerinde belirtilen değere göre sıralama işlemi yapılmasını sağlayabiliriz
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            _context.SaveChanges();

            return book;
        }
        */
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookDetailViewModel result;
            try
            {
                GetBookDetailQuery getBookDetailQuery = new GetBookDetailQuery(_context);
                getBookDetailQuery.BookId = id;

                result=getBookDetailQuery.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);

           
        }

        /*
        [HttpGet]
        public Book Get([FromQuery] string id)
        {
           //Linq Order By Metodunu kullanarak listeler üzerinde belirtilen değere göre sıralama işlemi yapılmasını sağlayabiliriz
           var book=BookList.Where(book=>book.Id==Convert.ToInt32(id)).SingleOrDefault();
           return book;
        }
        */

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel createBookModel)
        {
            CreateBookCommand command = new CreateBookCommand(_context);

            try
            {
                command.Model = createBookModel;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();

        }
        /*post metodu ile biz listemize yeni bir kitap ekleyecegiz 
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            //ilk önce gelen verinin bizim database sistemimizde olup olmadığına bakılır.
            //eğer var ise post işlemi engellenmelidir.
            var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            if (book != null)
                return BadRequest();

            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();

        }
        */
        //put metodu ile de listemizde yer alan elemanı güncelleme işlemi gerçekleştireceğiz
        //güncelleme işlemi yapacagız. güncellemeyi route üzerinden yapmak istiyoruz.
        //hangi id üzerinde işlem yapacagımızı ve yeni değerlerin ne olacağını belirtmemiz gerekiyor.

        [HttpPut("{id}")]
        //kitapın tüm bilgilerinin güncellenmesi isteniyor. diğer türlü Book.name yazılabilirdi
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBookModel)
        {
            try
            {
                UpdateBookCommand command= new UpdateBookCommand(_context);
                command.BookID = id;
                command.Model = updateBookModel;
                command.handle();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }



        //delete işlmei:

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
                deleteBookCommand.bookID = id;
                deleteBookCommand.Handle();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }


    }


}