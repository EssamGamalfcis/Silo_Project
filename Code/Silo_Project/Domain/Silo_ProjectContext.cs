using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain
{
    public partial class Silo_ProjectContext : DbContext
    {
        public Silo_ProjectContext()
        {
        }

        public Silo_ProjectContext(DbContextOptions<Silo_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<DocumentsType> DocumentsType { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemAmountType> ItemAmountType { get; set; }
        public virtual DbSet<ItemToDocuments> ItemToDocuments { get; set; }
        public virtual DbSet<ItemWarehouse> ItemWarehouse { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<RoleMenu> RoleMenu { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Silo> Silo { get; set; }
        public virtual DbSet<SiloToDocuments> SiloToDocuments { get; set; }
        public virtual DbSet<SiloToStore> SiloToStore { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreToCategory> StoreToCategory { get; set; }
        public virtual DbSet<StoreToDocuments> StoreToDocuments { get; set; }
        public virtual DbSet<StoreToItem> StoreToItem { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserContract> UserContract { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3L6MHQI;Initial Catalog=Silo_Project;Persist Security Info=True;User ID=sa_company;pwd=Essam2016;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasColumnName("Cat_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.Property(e => e.DocId)
                    .HasColumnName("Doc_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContractCode)
                    .IsRequired()
                    .HasColumnName("Contract_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Doc)
                    .WithOne(p => p.Contract)
                    .HasForeignKey<Contract>(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_Voucher");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.Property(e => e.DocId)
                    .HasColumnName("Doc_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DocCode)
                    .IsRequired()
                    .HasColumnName("Doc_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocDate)
                    .HasColumnName("Doc_Date")
                    .HasColumnType("date");

                entity.Property(e => e.DocStatusFlag).HasColumnName("Doc_Status_Flag");

                entity.Property(e => e.FromSiloId).HasColumnName("From_Silo_Id");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToSiloId).HasColumnName("To_Silo_Id");

                entity.HasOne(d => d.Doc)
                    .WithOne(p => p.Documents)
                    .HasForeignKey<Documents>(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documents_Contract");

                entity.HasOne(d => d.DocNavigation)
                    .WithOne(p => p.Documents)
                    .HasForeignKey<Documents>(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documents_Documents_Type");
            });

            modelBuilder.Entity<DocumentsType>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("Documents_Type");

                entity.Property(e => e.DocId).HasColumnName("Doc_Id");

                entity.Property(e => e.DocTypeName)
                    .IsRequired()
                    .HasColumnName("Doc_Type_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId)
                    .HasColumnName("Item_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.ItemCurrnetAmount).HasColumnName("Item_Currnet_Amount");

                entity.Property(e => e.ItemDescription)
                    .HasColumnName("Item_Description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("Item_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnName("Item_Price");

                entity.Property(e => e.ItemStartAmount).HasColumnName("Item_Start_Amount");

                entity.Property(e => e.ItemWarehouseId).HasColumnName("Item_Warehouse_Id");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Category");

                entity.HasOne(d => d.ItemNavigation)
                    .WithOne(p => p.Item)
                    .HasForeignKey<Item>(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Item_Amount_Type");

                entity.HasOne(d => d.ItemWarehouse)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ItemWarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Item_Warehouse");
            });

            modelBuilder.Entity<ItemAmountType>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("Item_Amount_Type");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.AmountTypeDescription)
                    .IsRequired()
                    .HasColumnName("Amount_Type_Description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemToDocuments>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.DocId });

                entity.ToTable("Item_To_Documents");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.DocId).HasColumnName("Doc_Id");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.ItemToDocuments)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_To_Documents_Documents");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemToDocuments)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_To_Documents_Item");
            });

            modelBuilder.Entity<ItemWarehouse>(entity =>
            {
                entity.ToTable("Item_Warehouse");

                entity.Property(e => e.ItemWarehouseId).HasColumnName("Item_Warehouse_Id");

                entity.Property(e => e.ItemWarehouseAddress)
                    .HasColumnName("Item_Warehouse_Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemWarehouseName)
                    .IsRequired()
                    .HasColumnName("Item_Warehouse_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.Property(e => e.MenuId).HasColumnName("Menu_Id");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            });

            modelBuilder.Entity<Pages>(entity =>
            {
                entity.HasKey(e => e.PageId);

                entity.Property(e => e.PageId).HasColumnName("Page_Id");

                entity.Property(e => e.MenueId).HasColumnName("Menue_Id");

                entity.Property(e => e.PageName)
                    .IsRequired()
                    .HasColumnName("Page_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PageUrl)
                    .IsRequired()
                    .HasColumnName("Page_URL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Menue)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.MenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pages_Menus");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("PK_Permission");

                entity.Property(e => e.PermissionId).HasColumnName("Permission_Id");

                entity.Property(e => e.PermissionDescription)
                    .HasColumnName("Permission_Description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionName)
                    .IsRequired()
                    .HasColumnName("Permission_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleMenu>(entity =>
            {
                entity.HasKey(e => new { e.PageId, e.RoleId });

                entity.ToTable("Role_Menu");

                entity.Property(e => e.PageId).HasColumnName("Page_Id");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.RoleMenu)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Menu_Pages");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMenu)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Menu_Roles");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId });

                entity.ToTable("Role_Permission");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.PermissionId).HasColumnName("Permission_Id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Permission_Permissions");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Permission_Roles1");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("Role_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Silo>(entity =>
            {
                entity.Property(e => e.SiloId).HasColumnName("Silo_Id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SiloName)
                    .IsRequired()
                    .HasColumnName("Silo_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SiloToDocuments>(entity =>
            {
                entity.HasKey(e => new { e.SiloId, e.DocId });

                entity.ToTable("Silo_To_Documents");

                entity.Property(e => e.SiloId).HasColumnName("Silo_Id");

                entity.Property(e => e.DocId).HasColumnName("Doc_Id");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.SiloToDocuments)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Silo_To_Documents_Documents");

                entity.HasOne(d => d.Silo)
                    .WithMany(p => p.SiloToDocuments)
                    .HasForeignKey(d => d.SiloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Silo_To_Documents_Silo");
            });

            modelBuilder.Entity<SiloToStore>(entity =>
            {
                entity.HasKey(e => new { e.SiloId, e.StoreId });

                entity.ToTable("Silo_To_Store");

                entity.Property(e => e.SiloId).HasColumnName("Silo_Id");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.HasOne(d => d.Silo)
                    .WithMany(p => p.SiloToStore)
                    .HasForeignKey(d => d.SiloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Silo_To_Store_Silo");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.SiloToStore)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Silo_To_Store_Store");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StoreToCategory>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.CatId });

                entity.ToTable("Store_To_Category");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.StoreToCategory)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_To_Category_Category");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreToCategory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_To_Category_Store");
            });

            modelBuilder.Entity<StoreToDocuments>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.DocId });

                entity.ToTable("Store_To_Documents");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.Property(e => e.DocId).HasColumnName("Doc_Id");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.StoreToDocuments)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_To_Documents_Documents");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreToDocuments)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_To_Documents_Store");
            });

            modelBuilder.Entity<StoreToItem>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ItemId });

                entity.ToTable("Store_To_Item");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.StoreToItem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_To_Item_Item");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreToItem)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_To_Item_Store");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.SiloId).HasColumnName("Silo_Id");

                entity.Property(e => e.UserFname)
                    .IsRequired()
                    .HasColumnName("User_FName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLname)
                    .IsRequired()
                    .HasColumnName("User_LName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasColumnName("User_Phone")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Silo)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.SiloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Silo");
            });

            modelBuilder.Entity<UserContract>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DocId })
                    .HasName("PK_User_Charge");

                entity.ToTable("User_Contract");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.DocId).HasColumnName("Doc_Id");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.UserContract)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Contract_Contract");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserContract)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Contract_User");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("User_Role");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role_User");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.Property(e => e.DocId).HasColumnName("Doc_Id");

                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherDate)
                    .HasColumnName("Voucher_Date")
                    .HasColumnType("date");

                entity.Property(e => e.VoucherTypeName)
                    .IsRequired()
                    .HasColumnName("Voucher_Type_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
