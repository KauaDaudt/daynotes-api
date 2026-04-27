using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DayNotes.API.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<DayNotes.API.Data.AppDbContext>
    {
        public DayNotes.API.Data.AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DayNotes.API.Data.AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=daynotes.db");

            return new DayNotes.API.Data.AppDbContext(optionsBuilder.Options);
        }
    }
}