using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using VoteService.Entities;

namespace VoteService.Data
{
    public class VoteDbContext : DbContext
    {
        public VoteDbContext(DbContextOptions<VoteDbContext> options) : base(options) { }

        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vote>()
                .HasIndex(v => new { v.EntryId, v.UserId })
                .IsUnique(); // 👈 Aynı kullanıcı aynı entry'e bir kez oy versin
        }
    }
}
