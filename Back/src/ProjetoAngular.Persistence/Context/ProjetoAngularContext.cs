using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoAngular.Domain;

namespace ProjetoAngular.Persistence.Context
{
    
    public class ProjetoAngularContext : DbContext
    {
        public ProjetoAngularContext(DbContextOptions<ProjetoAngularContext> options) : base (options)
        {
        
        }
        
        public DbSet<Evento> Evento{get;set;}
        public DbSet<Lote> Lote{get;set;}
        public DbSet<Palestrante> Palestrante{get;set;}
        public DbSet<PalestranteEvento> PalestranteEvento{get;set;}
        public DbSet<RedeSocial> RedeSocial{get;set;}

        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>().HasKey(PE => new {PE.EventoId, PE.PalestranteId});
            modelBuilder.Entity<Evento>().HasMany(e => e.RedeSocial).WithOne(rs => rs.Evento).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Palestrante>().HasMany(e => e.RedeSocial).WithOne(rs => rs.Palestrante).OnDelete(DeleteBehavior.Cascade);
        }
    }
}