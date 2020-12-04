using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_AE3.Models
{
    public class PlaceMyBetContext: DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public PlaceMyBetContext()
        {
        }
        public PlaceMyBetContext(DbContextOptions options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=placemybet2;Uid=root;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Usuario>().HasData(new Usuario("Carla@gmail.com", "Carla", "Arbiol", 30));
            modelbuilder.Entity<Usuario>().HasData(new Usuario("Irene@gmail.com", "Irene", "Gomez", 12));
            modelbuilder.Entity<Evento>().HasData(new Evento(1, "Madrid", "Betis", "2020-07-20"));
            modelbuilder.Entity<Evento>().HasData(new Evento(2, "Valencia", "PSG", "2020-04-19"));
            modelbuilder.Entity<Mercado>().HasData(new Mercado(1, 1.5, 7.10, 250, 100, 2.5, 1));
            modelbuilder.Entity<Mercado>().HasData(new Mercado(2, 2.3, 1.6, 150, 50, 1.5, 1));
            modelbuilder.Entity<Apuesta>().HasData(new Apuesta(1, 2.1, 1.75, 125, "2020-03-13", 1, "Carla@gmail.com", "over"));
            modelbuilder.Entity<Apuesta>().HasData(new Apuesta(2, 3.3, 1.1, 100, "2020-04-14", 2, "Irene@gmail.com", "under"));

        }
    }
}