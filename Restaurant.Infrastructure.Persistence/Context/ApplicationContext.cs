
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.Core;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables & Primary Keys

            modelBuilder.Entity<Ingredient>()
                .ToTable("Ingredients")
                .HasKey(i => i.IngredientId);

            modelBuilder.Entity<Dish>()
                .ToTable("Dishes")
                .HasKey(d => d.DishId);

            modelBuilder.Entity<Table>()
                .ToTable("Tables")
                .HasKey(t => t.TableId);

            modelBuilder.Entity<Order>()
                .ToTable("Orders")
                .HasKey(o => o.OrderId);
            #endregion

            #region Relationships

            modelBuilder.Entity<Dish>()
                .HasMany(d => d.Ingredients)
                .WithMany(i => i.Dishes)
                .UsingEntity("DishesIngredients");

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Dishes)
                .WithMany(d => d.Orders)
                .UsingEntity("OrdersDishes");
            #endregion


        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedAt = DateTime.Now;
                        break;
                }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
