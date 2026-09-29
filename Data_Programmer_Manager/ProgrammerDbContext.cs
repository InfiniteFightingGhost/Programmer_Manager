using Data_Programmer_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Programmer_Manager
{
    public class ProgrammerDbContext:DbContext
    {
        public ProgrammerDbContext(DbContextOptions<ProgrammerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Programmer> Programmers { get; set; } = null!;
        public DbSet<Program> Programs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Program>()
                .HasOne(p => p.Programmer)
                .WithMany(pr => pr.Programs)
                .HasForeignKey(p => p.ProgrammerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
