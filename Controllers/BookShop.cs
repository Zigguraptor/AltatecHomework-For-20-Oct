using AltatecHomework_For_20_Oct.DAL;
using AltatecHomework_For_20_Oct.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AltatecHomework_For_20_Oct.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookShopController : ControllerBase
    {
        private readonly BookDbContext _bookDbContext;

        public BookShopController(BookDbContext bookDbContext) =>
            _bookDbContext = bookDbContext;

        [HttpGet]
        public async Task<IActionResult> GetBooksAsync() => Ok(await _bookDbContext.Books.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> AddBookAsync(BookEntity bookEntity)
        {
            if (!ModelState.IsValid)
                UnprocessableEntity(ModelState);

            bookEntity.Guid = Guid.NewGuid();
            _bookDbContext.Add(bookEntity);
            await _bookDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookAsync(Guid guid)
        {
            var book = await _bookDbContext.Books.FindAsync(guid);
            if (book == null)
                return NotFound();

            _bookDbContext.Books.Remove(book);
            await _bookDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
