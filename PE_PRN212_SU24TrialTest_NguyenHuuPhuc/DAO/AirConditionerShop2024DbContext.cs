using DAO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;

namespace DAO
{
    public partial class AirConditionerShop2024DbContext : DbContext
    {
        private static AirConditionerShop2024DbContext instance = null;
        private static readonly object instanceLock = new object();

        public AirConditionerShop2024DbContext(DbContextOptions<AirConditionerShop2024DbContext> options) : base(options)
        {
        }

        public static AirConditionerShop2024DbContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<AirConditionerShop2024DbContext>();
                        var connectionString = "server =(local); database=AirConditionerShop2024DB;uid=sa;pwd=123; TrustServerCertificate=True";
                        Trace.WriteLine($"Connection String: {connectionString}"); // Log the connection string
                        Console.WriteLine($"Connection String: {connectionString}"); // Log the connection string
                        Trace.WriteLine($"Connection String: {connectionString}"); // Log the connection string
                        optionsBuilder.UseSqlServer(connectionString);

                        instance = new AirConditionerShop2024DbContext(optionsBuilder.Options);
                    }
                    return instance;
                }
            }
        }

        private static string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", true, true)
                 .Build();
            var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

            return strConn;
        }

        public virtual DbSet<AirConditioner> AirConditioners { get; set; }
        public virtual DbSet<StaffMember> StaffMembers { get; set; }
        public virtual DbSet<SupplierCompany> SupplierCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirConditioner>(entity =>
            {
                entity.HasKey(e => e.AirConditionerId).HasName("PK__AirCondi__EE2EB73981EF473E");

                entity.ToTable("AirConditioner");

                entity.Property(e => e.AirConditionerId).ValueGeneratedNever();
                entity.Property(e => e.AirConditionerName).HasMaxLength(200);
                entity.Property(e => e.FeatureFunction).HasMaxLength(250);
                entity.Property(e => e.SoundPressureLevel).HasMaxLength(80);
                entity.Property(e => e.SupplierId).HasMaxLength(20);
                entity.Property(e => e.Warranty).HasMaxLength(60);

                entity.HasOne(d => d.Supplier).WithMany(p => p.AirConditioners)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__AirCondit__Suppl__3C69FB99");
            });

            modelBuilder.Entity<StaffMember>(entity =>
            {
                entity.HasKey(e => e.MemberId).HasName("PK__StaffMem__0CF04B388D5F6D4D");

                entity.ToTable("StaffMember");

                entity.HasIndex(e => e.EmailAddress, "UQ__StaffMem__49A14740F81F9E0D").IsUnique();

                entity.Property(e => e.MemberId)
                    .ValueGeneratedNever()
                    .HasColumnName("MemberID");
                entity.Property(e => e.EmailAddress).HasMaxLength(60);
                entity.Property(e => e.FullName).HasMaxLength(60);
                entity.Property(e => e.Password).HasMaxLength(40);
            });

            modelBuilder.Entity<SupplierCompany>(entity =>
            {
                entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B462EFE597");

                entity.ToTable("SupplierCompany");

                entity.Property(e => e.SupplierId).HasMaxLength(20);
                entity.Property(e => e.PlaceOfOrigin).HasMaxLength(60);
                entity.Property(e => e.SupplierDescription).HasMaxLength(250);
                entity.Property(e => e.SupplierName).HasMaxLength(80);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
