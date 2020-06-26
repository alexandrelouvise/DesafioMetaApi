using DesafioMetaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioMetaAPI.Infra.Data.Config
{
    public class DesafioMetaAPIDbContext : DbContext
    {
        public DbSet<Contato> Contao { get; set; }
        protected DesafioMetaAPIDbContext() { }

        public DesafioMetaAPIDbContext(DbContextOptions<DesafioMetaAPIDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();


        }
    }
}
