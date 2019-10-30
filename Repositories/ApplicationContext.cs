using Banco.Services.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Services.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContaCorrente>().HasKey(e => e.Id);
            modelBuilder.Entity<ContaCorrente>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ContaCorrente>().HasMany(e => e.Lancamentos).WithOne(e => e.ContaCorrente);
            
            modelBuilder.Entity<Lancamento>().HasKey(e => e.Id);
            modelBuilder.Entity<Lancamento>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Lancamento>().HasOne(e => e.ContaCorrente).WithMany(e => e.Lancamentos);
        }
    }
}
