using Microsoft.EntityFrameworkCore;
using NWSocial.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Data
{
    public class NWSContext : DbContext
    {
        public NWSContext(DbContextOptions<NWSContext> options) : base(options)
        {

        }

        public DbSet<Guild> guilds { get; set; }
    }
}
