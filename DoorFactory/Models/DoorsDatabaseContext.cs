using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoorFactory.Models
{
    public partial class DoorsDatabaseContext : DbContext
    {
        public DoorsDatabaseContext()
        {
        }

        public DoorsDatabaseContext(DbContextOptions<DoorsDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assemblage> Assemblage { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DelieveryInfo> DelieveryInfo { get; set; }
        public virtual DbSet<DoorCategories> DoorCategories { get; set; }
        public virtual DbSet<Doors> Doors { get; set; }
        public virtual DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<MaterialInOrder> MaterialInOrder { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<MaterialsCategory> MaterialsCategory { get; set; }
        public virtual DbSet<MaterialsCome> MaterialsCome { get; set; }
        public virtual DbSet<MaterialsDoor> MaterialsDoor { get; set; }
        public virtual DbSet<MaterialsMovements> MaterialsMovements { get; set; }
        public virtual DbSet<MatrialInStorage> MatrialInStorage { get; set; }
        public virtual DbSet<OpeningStyles> OpeningStyles { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<ProviderOrder> ProviderOrder { get; set; }
        public virtual DbSet<Storages> Storages { get; set; }
        public virtual DbSet<StyleTypes> StyleTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MQON2DE;Database=DoorsDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Assemblage>(entity =>
            {
                entity.Property(e => e.AssemblageId).HasColumnName("AssemblageID");

                entity.Property(e => e.AssemblageDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Assemblage)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_56");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Assemblage)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("R_57");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("XPKCities");

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Colors>(entity =>
            {
                entity.HasKey(e => e.ColorId)
                    .HasName("XPKColors");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.CustomersId).HasColumnName("CustomersID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DelieveryInfo>(entity =>
            {
                entity.Property(e => e.DelieveryInfoId).HasColumnName("DelieveryInfoID");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.DelieveryInfo)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_65");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DelieveryInfo)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_66");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.DelieveryInfo)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("R_83");
            });

            modelBuilder.Entity<DoorCategories>(entity =>
            {
                entity.HasKey(e => e.DoorsCategoriesId)
                    .HasName("XPKDoorCategories");

                entity.Property(e => e.DoorsCategoriesId).HasColumnName("DoorsCategoriesID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doors>(entity =>
            {
                entity.HasKey(e => e.DoorId)
                    .HasName("XPKDoors");

                entity.Property(e => e.DoorId).HasColumnName("DoorID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DoorName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DoorsCategoriesId).HasColumnName("DoorsCategoriesID");

                entity.Property(e => e.OpeningStylesId).HasColumnName("OpeningStylesID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StyleTypesId).HasColumnName("StyleTypesID");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Doors)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_85");

                entity.HasOne(d => d.DoorsCategories)
                    .WithMany(p => p.Doors)
                    .HasForeignKey(d => d.DoorsCategoriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_46");

                entity.HasOne(d => d.OpeningStyles)
                    .WithMany(p => p.Doors)
                    .HasForeignKey(d => d.OpeningStylesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_52");

                entity.HasOne(d => d.StyleTypes)
                    .WithMany(p => p.Doors)
                    .HasForeignKey(d => d.StyleTypesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_53");
            });

            modelBuilder.Entity<EmployeeRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("XPKEmployeeRoles");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("XPKEmployees");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_2");
            });

            modelBuilder.Entity<MaterialInOrder>(entity =>
            {
                entity.Property(e => e.MaterialinorderId).HasColumnName("materialinorder_id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.ProviderOrderId).HasColumnName("provider_order_id");

                entity.Property(e => e.ProviderPrice)
                    .HasColumnName("provider_Price")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.MaterialInOrder)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("R_27");

                entity.HasOne(d => d.ProviderOrder)
                    .WithMany(p => p.MaterialInOrder)
                    .HasForeignKey(d => d.ProviderOrderId)
                    .HasConstraintName("R_75");
            });

            modelBuilder.Entity<Materials>(entity =>
            {
                entity.HasKey(e => e.MaterialId)
                    .HasName("XPKMaterials");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialCategoryId).HasColumnName("MaterialCategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.MaterialCategory)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.MaterialCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_78");
            });

            modelBuilder.Entity<MaterialsCategory>(entity =>
            {
                entity.HasKey(e => e.MaterialCategoryId)
                    .HasName("XPKMaterialsCategory");

                entity.Property(e => e.MaterialCategoryId).HasColumnName("MaterialCategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MaterialsCome>(entity =>
            {
                entity.HasKey(e => e.MaterialsGoneId)
                    .HasName("XPKMaterialsGone");

                entity.Property(e => e.MaterialsGoneId).HasColumnName("materials_gone_id");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.MaterialinorderId).HasColumnName("materialinorder_id");

                entity.Property(e => e.MaterialinstorageId).HasColumnName("materialinstorage_id");

                entity.Property(e => e.MaterialsCount).HasColumnName("materials_count");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MaterialsCome)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_76");

                entity.HasOne(d => d.Materialinorder)
                    .WithMany(p => p.MaterialsCome)
                    .HasForeignKey(d => d.MaterialinorderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_28");

                entity.HasOne(d => d.Materialinstorage)
                    .WithMany(p => p.MaterialsCome)
                    .HasForeignKey(d => d.MaterialinstorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_29");
            });

            modelBuilder.Entity<MaterialsDoor>(entity =>
            {
                entity.ToTable("Materials_Door");

                entity.Property(e => e.DoorId).HasColumnName("DoorID");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.HasOne(d => d.Door)
                    .WithMany(p => p.MaterialsDoor)
                    .HasForeignKey(d => d.DoorId)
                    .HasConstraintName("R_61");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.MaterialsDoor)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_60");
            });

            modelBuilder.Entity<MaterialsMovements>(entity =>
            {
                entity.HasKey(e => e.MaterialsMovementId)
                    .HasName("XPKMaterialsMovements");

                entity.Property(e => e.MaterialsMovementId).HasColumnName("materials_movement_id");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("date");

                entity.Property(e => e.MaterialimstorageIdFrom).HasColumnName("materialimstorage_id_from");

                entity.Property(e => e.MaterialimstorageIdTo).HasColumnName("materialimstorage_id_to");

                entity.Property(e => e.MaterialsCount).HasColumnName("materials_count");

                entity.HasOne(d => d.MaterialimstorageIdFromNavigation)
                    .WithMany(p => p.MaterialsMovementsMaterialimstorageIdFromNavigation)
                    .HasForeignKey(d => d.MaterialimstorageIdFrom)
                    .HasConstraintName("R_70");

                entity.HasOne(d => d.MaterialimstorageIdToNavigation)
                    .WithMany(p => p.MaterialsMovementsMaterialimstorageIdToNavigation)
                    .HasForeignKey(d => d.MaterialimstorageIdTo)
                    .HasConstraintName("R_71");
            });

            modelBuilder.Entity<MatrialInStorage>(entity =>
            {
                entity.HasKey(e => e.MaterialinstorageId)
                    .HasName("XPKMatrialInStorage");

                entity.Property(e => e.MaterialinstorageId).HasColumnName("materialinstorage_id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.StorageId).HasColumnName("storage_id");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.MatrialInStorage)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_25");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.MatrialInStorage)
                    .HasForeignKey(d => d.StorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_24");
            });

            modelBuilder.Entity<OpeningStyles>(entity =>
            {
                entity.Property(e => e.OpeningStylesId).HasColumnName("OpeningStylesID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");

                entity.Property(e => e.DoorId).HasColumnName("DoorID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Door)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.DoorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_82");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("R_81");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("XPKOrders");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomersId).HasColumnName("CustomersID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderTotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentDeadline).HasColumnType("date");

                entity.HasOne(d => d.Customers)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_79");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_80");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.ProviderId).HasColumnName("provider_id");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Provider)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_36");
            });

            modelBuilder.Entity<ProviderOrder>(entity =>
            {
                entity.Property(e => e.ProviderOrderId).HasColumnName("provider_order_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ProviderId).HasColumnName("provider_id");

                entity.Property(e => e.ProviderorderDate)
                    .HasColumnName("providerorder_date")
                    .HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ProviderOrder)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_74");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ProviderOrder)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_73");
            });

            modelBuilder.Entity<Storages>(entity =>
            {
                entity.HasKey(e => e.StorageId)
                    .HasName("XPKStorages");

                entity.Property(e => e.StorageId).HasColumnName("storage_id");

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("R_35");
            });

            modelBuilder.Entity<StyleTypes>(entity =>
            {
                entity.Property(e => e.StyleTypesId).HasColumnName("StyleTypesID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
