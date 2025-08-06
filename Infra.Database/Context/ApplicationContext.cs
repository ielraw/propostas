using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                var conn = _configuration.GetConnectionString("DefaultConnection");
                dbContextOptionsBuilder.UseSqlServer(conn, options =>
                {
                    options.MigrationsAssembly("Infra.Database");
                    options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();
        }

        public DbSet<Proposta> Propostas { get; set; }

        public DbSet<Contratacao> Contratacoes { get; set; }


    }
}
