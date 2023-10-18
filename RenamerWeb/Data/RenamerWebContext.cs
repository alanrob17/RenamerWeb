using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RenamerWeb.Models;

namespace RenamerWeb.Data
{
    public class RenamerWebContext : DbContext
    {
        public RenamerWebContext (DbContextOptions<RenamerWebContext> options)
            : base(options)
        {
        }

        public DbSet<RenamerWeb.Models.Photo>? Photo { get; set; } = default!;
    }
}
