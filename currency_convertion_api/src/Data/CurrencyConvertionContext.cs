using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data
{
    public class CurrencyConvertionContext : DbContext
    {
        public CurrencyConvertionContext (DbContextOptions<CurrencyConvertionContext> options ) : base(options)
        {
        }

        public DbSet<EntriesModelInput> EntriesModel { get; set; }
    }
}