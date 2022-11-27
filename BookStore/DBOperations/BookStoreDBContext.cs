using Microsoft.EntityFrameworkCore;
namespace BookStore.DBOperations
{

    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
        {

        }


        //aradaki baglantıyı kurduk.
        //bu contexte book entitysini ekledik 
        //ben bu database'e Book nesnesini kullanmak istiyorum adı da books olsun 
        public DbSet<Book> Books { get; set; }

    }


}