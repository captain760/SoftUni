using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WoodMasters2.Core.Data.Entities;

namespace WoodMasters2.Core.Data
{
    public class WMDbContext : IdentityDbContext<Master>
    {
        public WMDbContext(DbContextOptions<WMDbContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<MasterPiece> MasterPieces { get; set; } = null!;
        public DbSet<Stain> Stains { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Wood> Woods { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString)
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MasterMasterPiece>()
                .HasKey(x => new { x.MasterId, x.MasterPieceId });
            builder.Entity<MasterAddress>()
                .HasKey(x => new { x.MasterId, x.AddressId });
            builder.Entity<MasterPieceCategory>()
                .HasKey(x => new { x.MasterPieceId, x.CategoryId });
            builder.Entity<MasterPieceWood>()
                .HasKey(x => new { x.MasterPieceId, x.WoodId });
            builder.Entity<WoodStain>()
                .HasKey(x => new { x.WoodId, x.StainId });
            builder.Entity<WoodSupplier>()
                .HasKey(x => new { x.WoodId, x.SupplierId });

            builder.Entity<Master>()
                .Property(m => m.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<Master>()
                .Property(m => m.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Entity<MasterPiece>()
                .Property(mp=>mp.Price)
                .HasColumnType("decimal")
                .HasPrecision(2);

            builder.Entity<MasterPiece>()
               .Property(mp => mp.Rating)
               .HasColumnType("decimal")
               .HasPrecision(2);

            base.OnModelCreating(builder);
        }
    }
}