using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.Storing
{
    public partial class PIZZASTORE2Context : DbContext
    {
        public PIZZASTORE2Context()
        {
        }

        public PIZZASTORE2Context(DbContextOptions<PIZZASTORE2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust2> Crust2 { get; set; }
        public virtual DbSet<Order2> Order2 { get; set; }
        public virtual DbSet<OrderJunction2> OrderJunction2 { get; set; }
        public virtual DbSet<Pizza2> Pizza2 { get; set; }
        public virtual DbSet<PizzaJunction2> PizzaJunction2 { get; set; }
        public virtual DbSet<PizzaOrderJunction2> PizzaOrderJunction2 { get; set; }
        public virtual DbSet<Size2> Size2 { get; set; }
        public virtual DbSet<Store2> Store2 { get; set; }
        public virtual DbSet<Toppings2> Toppings2 { get; set; }
        public virtual DbSet<User2> User2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost;database=PIZZASTORE2;user id=sa;password=Dragoon123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crust2>(entity =>
            {
                entity.HasKey(e => e.CrustId)
                    .HasName("PK_CrustId");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order2>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderID");

                entity.ToTable("ORDER2");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<OrderJunction2>(entity =>
            {
                entity.HasKey(e => e.OrderJunctionId)
                    .HasName("PK_OrderJunctionID");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderJunction2)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_junctionOrder2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderJunction2)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_junctionUser");
            });

            modelBuilder.Entity<Pizza2>(entity =>
            {
                entity.HasKey(e => e.PizzaId)
                    .HasName("PK_Pizza_PizzaId");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizza2)
                    .HasForeignKey(d => d.CrustId)
                    .HasConstraintName("FK_Pizza_CrustId");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pizza2)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_Pizza_SizeId");
            });

            modelBuilder.Entity<PizzaJunction2>(entity =>
            {
                entity.HasKey(e => e.JunctionId)
                    .HasName("PK_PizzaJunction");

                entity.Property(e => e.JunctionId).HasColumnName("junctionId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaJunction2)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_junctionPizza");

                entity.HasOne(d => d.Toppings)
                    .WithMany(p => p.PizzaJunction2)
                    .HasForeignKey(d => d.ToppingsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_junctionToppings");
            });

            modelBuilder.Entity<PizzaOrderJunction2>(entity =>
            {
                entity.HasKey(e => e.PizzaOrderjunctionId)
                    .HasName("PK_PizzaOrderJunction");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PizzaOrderJunction2)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_junctionOrder");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaOrderJunction2)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_junctionPizzaOrder");
            });

            modelBuilder.Entity<Size2>(entity =>
            {
                entity.HasKey(e => e.SizeId)
                    .HasName("PK_Pizza_SizeId");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnName("SIZE")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Store2>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK_StoreID");

                entity.ToTable("STORE2");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Toppings2>(entity =>
            {
                entity.HasKey(e => e.ToppingsId)
                    .HasName("PK_Toppings_ToppingId");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<User2>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserID");

                entity.ToTable("USER2");

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
