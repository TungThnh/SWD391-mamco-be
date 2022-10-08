using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class mamcungappContext : DbContext
    {
        public mamcungappContext()
        {
        }

        public mamcungappContext(DbContextOptions<mamcungappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Combo> Combos { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<FoodType> FoodTypes { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersRole> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=foodappsql.database.windows.net;uid=foodapp;pwd=123123Jj;database=mamcungapp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Combo>(entity =>
            {
                entity.ToTable("combo");

                entity.Property(e => e.ComboId)
                    .ValueGeneratedNever()
                    .HasColumnName("ComboID");

                entity.Property(e => e.FoodId).HasColumnName("FoodID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Combos)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_combo_food");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK_customer_promotion");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food");

                entity.Property(e => e.FoodId)
                    .ValueGeneratedNever()
                    .HasColumnName("FoodID");

                entity.Property(e => e.DateIn).HasColumnType("datetime");

                entity.Property(e => e.DateOut).HasColumnType("datetime");

                entity.Property(e => e.FoodTypeId).HasColumnName("Food_Type_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FoodType)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.FoodTypeId)
                    .HasConstraintName("FK_food_food_types");
            });

            modelBuilder.Entity<FoodType>(entity =>
            {
                entity.ToTable("food_types");

                entity.Property(e => e.FoodTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Food_Type_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("materials");

                entity.Property(e => e.MaterialId)
                    .ValueGeneratedNever()
                    .HasColumnName("materialID");

                entity.Property(e => e.DateIn).HasColumnType("datetime");

                entity.Property(e => e.DateOut).HasColumnType("datetime");

                entity.Property(e => e.MaterialTypeId).HasColumnName("Material_Type_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaterialType)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.MaterialTypeId)
                    .HasConstraintName("FK_materials_material_type");
            });

            modelBuilder.Entity<MaterialType>(entity =>
            {
                entity.ToTable("material_type");

                entity.Property(e => e.MaterialTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Material_Type_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menu");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ListFood)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FoodId).HasColumnName("foodID");

                entity.Property(e => e.MaterialId).HasColumnName("materialID");

                entity.Property(e => e.PromoteCodeId).HasColumnName("PromoteCodeID");

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_order_customer");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_order_food");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_order_materials");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_detail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_order_detail_order");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("promotion");

                entity.Property(e => e.PromotionId)
                    .ValueGeneratedNever()
                    .HasColumnName("PromotionID");

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("rating");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DateRecorded)
                    .HasColumnType("datetime")
                    .HasColumnName("date_recorded");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.Score).HasColumnName("score");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.ResId);

                entity.ToTable("restaurant");

                entity.Property(e => e.ResId)
                    .ValueGeneratedNever()
                    .HasColumnName("resID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ComboId).HasColumnName("ComboID");

                entity.Property(e => e.FoodId).HasColumnName("FoodID");

                entity.Property(e => e.ListFood)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Combo)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.ComboId)
                    .HasConstraintName("FK_restaurant_combo");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_restaurant_food");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.RatingId)
                    .HasConstraintName("FK_restaurant_rating");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_restaurant_users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("users_roles");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_users_roles_roles");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_users_roles_users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
