namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FashionShopDbContext : DbContext
    {
        public FashionShopDbContext()
            : base("name=FashionShop")
        {
        }

        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        //public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public virtual DbSet<DanhMucSP> DanhMucSP { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            //modelBuilder.Entity<Color>()
            //    .HasMany(e => e.ChiTietHoaDon)
            //    .WithRequired(e => e.Color)
            //    .HasForeignKey(e => e.ID_Color)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DanhMucSP>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucSP>()
                .HasMany(e => e.SanPham)
                .WithRequired(e => e.DanhMucSP)
                .HasForeignKey(e => e.ID_DanhMuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDon)
                .WithRequired(e => e.HoaDon)
                .HasForeignKey(e => e.ID_HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuType>()
                .HasMany(e => e.Menu)
                .WithOptional(e => e.MenuType)
                .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietHoaDon)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.ID_SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Size>()
                .HasMany(e => e.ChiTietHoaDon)
                .WithRequired(e => e.Size)
                .HasForeignKey(e => e.ID_Size)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HoaDon)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ID_User);
        }
    }
}
