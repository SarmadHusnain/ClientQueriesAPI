using ClientQueriesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ClientQueriesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClientQuery> ClientQueries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientQuery>()
                .Property(e => e.Services)
                .HasConversion(
                    
                    v => JsonSerializer.Serialize(v ?? new List<string>(), new JsonSerializerOptions()),
                    v => JsonSerializer.Deserialize<List<string>>(string.IsNullOrEmpty(v) ? "[]" : v, new JsonSerializerOptions()) ?? new List<string>()
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
