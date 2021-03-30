using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Books.Any()) return;
            
            var Books = new List<Book>
            {
                new Book
                {
                    Title = "Past Activity 1"
                    
                },
                new Book
                {
                    Title = "Past Activity 2"
                 
                },


       
        };
             await context.Books.AddRangeAsync(Books);
            await context.SaveChangesAsync();
        }
    }
}