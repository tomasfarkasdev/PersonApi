using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PersonApi.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }

        public DbSet<Persons> Peresons { get; set; }

        public DbSet<TimeOffs> TimeOffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persons>().ToTable("Persons");
            modelBuilder.Entity<TimeOffs>().ToTable("TimeOffs");

        }
    }
}
