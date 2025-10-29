using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;

namespace University.Infrastructure.Persistence {
  public class AppDbContext: DbContext {
    public AppDbContext(DbContextOptions < AppDbContext > options) : base(options) {}

    public DbSet < Student > Students {
      get;
      set;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity < Student > ().HasKey(s =>s.Id);
      modelBuilder.Entity < Student > ().Property(s =>s.FullName).HasMaxLength(100).IsRequired();
      modelBuilder.Entity < Student > ().Property(s =>s.Email).HasMaxLength(200).IsRequired();
    }
  }
}