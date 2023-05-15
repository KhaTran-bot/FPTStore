using FPTStore.Data;
using FPTStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FPTStore.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Book>> Genres()
        {
            return await _db.Book.ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetBooks(string sTerm = "", int genreId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Book> books = await (from book in _db.Book

                                             where string.IsNullOrWhiteSpace(sTerm) || (book != null && book.Title.ToLower().StartsWith(sTerm))
                                             select new Book
                                             {
                                                 Id = book.Id,
                                                 ImageUrl = book.ImageUrl,
                                                 Author = book.Author,
                                                 Title = book.Title,
                                                 Price = book.Price,
                                             }
                         ).ToListAsync();

            if (genreId > 0)
            {

                books = books.Where(a => a.Id == genreId).ToList();
            }
            return books;
        }
    }
}
