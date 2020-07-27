using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.Storing
{
    public partial class PIZZASTOREContext : DbContext
    {
        public PIZZASTOREContext()
        {
        }

        public PIZZASTOREContext(DbContextOptions<PIZZASTOREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Crust1> Crust1 { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderJunction> OrderJunction { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Size1> Size1 { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }
        public virtual DbSet<Toppings1> Toppings1 { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=PIZZASTORE;user id=sa;password=Dragoon123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crust>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Crust1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Crust", "Pizzas");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDER");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<OrderJunction>(entity =>
            {
                entity.Property(e => e.OrderJunctionId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.SizeId).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Diameter).HasColumnName("diameter");

                entity.Property(e => e.Size1)
                    .IsRequired()
                    .HasColumnName("SIZE")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Size1>(entity =>
            {
                entity.HasKey(e => e.SizeId)
                    .HasName("PK_Pizza_SizeId");

                entity.ToTable("SIZE", "Pizzas");

                entity.Property(e => e.SizeId).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Diameter).HasColumnName("diameter");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnName("SIZE")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("STORE");

                entity.Property(e => e.StoreId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.Property(e => e.ToppingsId).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<Toppings1>(entity =>
            {
                entity.HasKey(e => e.ToppingsId)
                    .HasName("PK_Toppings_ToppingId");

                entity.ToTable("Toppings", "Pizzas");

                entity.Property(e => e.ToppingsId).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
