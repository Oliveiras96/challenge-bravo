using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data
{
    public class CurrencyConvertionContext : DbContext
    {
        public CurrencyConvertionContext (DbContextOptions<CurrencyConvertionContext> options ) : base(options)
        {
        }

        // DbSet its virtual so we can mock it
        public virtual DbSet<EntriesModelInput> EntriesModel { get; set; }
    }
}