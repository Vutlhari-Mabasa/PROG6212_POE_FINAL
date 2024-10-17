using PROG6212_Part1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HRApplication.Data
{
    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> options) : base(options) { }

        public DbSet<Claim> Claims { get; set; }

    }
}
