using EntryService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EntryService.Data
{
    public class EntryDbContext : DbContext
    {
        public EntryDbContext(DbContextOptions<EntryDbContext> options) : base(options) { }

        public DbSet<Entry> Entries => Set<Entry>();
    }
}
