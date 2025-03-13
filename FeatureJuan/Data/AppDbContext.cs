using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeatureJuan.Models;
using Microsoft.EntityFrameworkCore;

namespace FeatureJuan.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Divisao> Divisoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipe>()
                .HasOne(e => e.Divisao)
                .WithMany(d => d.Equipes)
                .HasForeignKey(e => e.DivisaoId);

            modelBuilder.Entity<Divisao>().HasData(
                new Divisao { DivisaoId = 1, Nome = "Brasileirão Série A" },
                new Divisao { DivisaoId = 2, Nome = "Brasileirão Série B" },
                new Divisao { DivisaoId = 3, Nome = "La Liga" },
                new Divisao { DivisaoId = 4, Nome = "Premier League" },
                new Divisao { DivisaoId = 5, Nome = "Ligue 1" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }

}