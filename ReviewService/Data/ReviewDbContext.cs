using Microsoft.EntityFrameworkCore;
using ReviewService.Entities;
using System.Collections.Generic;

namespace ReviewService.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options) : base(options) { }

        public DbSet<Review> Reviews => Set<Review>();
    }
}
