using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class BooksController : ControllerBase

    {
        private readonly DataContext _context;
        public BooksController(DataContext context)
        {
            _context=context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
           var books= _context.Books.ToListAsync();
           return await books;
        }

        [HttpGet("{id}")]
         public async Task<ActionResult<Book>> GetBook(Guid id)
         {
             return await _context.Books.FindAsync(id);

         }
       [HttpPost]
        public async Task PostBook([FromBody] Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
           
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Book book,Guid id)
        {
           if (id!=book.ID)
           {
               return BadRequest();
           }
           _context.Entry(book).State= EntityState.Modified;
           await _context.SaveChangesAsync();
           return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

             _context.Books.Remove(book);
             await _context.SaveChangesAsync();
             return NoContent();
        }
    }
}