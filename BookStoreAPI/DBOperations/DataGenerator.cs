using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations;

public class DataGenerator // Dbye verileri ekledik ve kaydettik
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            if (context.Books.Any()) return;

            context.Books.AddRange(
                new Book
                {
                    Id = 1,
                    Title = "Alamut Kalesi",
                    GenreId = 1, // Action
                    PageCount = 219,
                    PublishDate = new DateTime(2003, 11, 28)
                },
                new Book
                {
                    Id = 2,
                    Title = "The Wonderful Wizard of Oz",
                    GenreId = 2, // Science Fiction
                    PageCount = 345,
                    PublishDate = new DateTime(1900, 05, 17)
                },
                new Book
                {
                    Id = 3,
                    Title = "Beyaz Zambaklar Ülkesinde",
                    GenreId = 3, // Personel Growth
                    PageCount = 540,
                    PublishDate = new DateTime(2000, 12, 07)
                }
                );
            context.SaveChanges();
        }
    }

}
