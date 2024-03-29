﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGame.Data.Entities;
using VideoGame.Models;

namespace VideoGame.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Riesgo> Riesgos { get; set; }
        public DbSet<OpcionesMejora> OpcionesMejoras { get; set; }
        public DbSet<Desarrollador> Desarrolladores { get; set; }
        public DbSet<productorInterno> productorInternos { get; set; }
        public DbSet<VideoGame.Models.DesarrolladorViewModel> DesarrolladorViewModel { get; set; }
    }
}
