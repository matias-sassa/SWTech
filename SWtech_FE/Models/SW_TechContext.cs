using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tech_Challenge.Models
{
    public partial class SW_TechContext : DbContext
    {
        public SW_TechContext()
        {
        }

        public SW_TechContext(DbContextOptions<SW_TechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atm> Atm { get; set; }
        public virtual DbSet<Biblioteca> Biblioteca { get; set; }
        public virtual DbSet<Farmacia> Farmacia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // SASSA To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0M3P130;Database=SW_Tech;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Atm>(entity =>
            {
                entity.ToTable("atm");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Altura).HasColumnName("altura");

                entity.Property(e => e.Banco)
                    .IsRequired()
                    .HasColumnName("banco")
                    .HasMaxLength(50);

                entity.Property(e => e.Barrio)
                    .HasColumnName("barrio")
                    .HasMaxLength(50);

                entity.Property(e => e.Calle).HasColumnName("calle");

                entity.Property(e => e.Calle2)
                    .HasColumnName("calle2")
                    .HasMaxLength(50);

                entity.Property(e => e.CodigoPostal).HasColumnName("codigo_postal");

                entity.Property(e => e.CodigoPostalArgentino)
                    .HasColumnName("codigo_postal_argentino")
                    .HasMaxLength(50);

                entity.Property(e => e.Comuna)
                    .HasColumnName("comuna")
                    .HasMaxLength(50);

                entity.Property(e => e.Dolares).HasColumnName("dolares");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Localidad)
                    .IsRequired()
                    .HasColumnName("localidad")
                    .HasMaxLength(50);

                entity.Property(e => e.Long).HasColumnName("long");

                entity.Property(e => e.NoVidente).HasColumnName("no_vidente");

                entity.Property(e => e.Red)
                    .IsRequired()
                    .HasColumnName("red")
                    .HasMaxLength(50);

                entity.Property(e => e.Terminales).HasColumnName("terminales");

                entity.Property(e => e.Ubicacion).HasColumnName("ubicacion");
            });

            modelBuilder.Entity<Biblioteca>(entity =>
            {
                entity.ToTable("biblioteca");

                entity.Property(e => e.BibliotecaId).HasColumnName("bibliotecaID");

                entity.Property(e => e.Altura)
                    .HasColumnName("altura")
                    .HasMaxLength(50);

                entity.Property(e => e.Barrio)
                    .IsRequired()
                    .HasColumnName("barrio")
                    .HasMaxLength(50);

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasColumnName("calle")
                    .HasMaxLength(50);

                entity.Property(e => e.Calle2)
                    .HasColumnName("calle_2")
                    .HasMaxLength(50);

                entity.Property(e => e.CodigoPostal).HasColumnName("codigo_postal");

                entity.Property(e => e.CodigoPostalArgentino)
                    .HasColumnName("codigo_postal_argentino")
                    .HasMaxLength(50);

                entity.Property(e => e.Comuna)
                    .IsRequired()
                    .HasColumnName("comuna")
                    .HasMaxLength(50);

                entity.Property(e => e.DireccionNormalizada)
                    .HasColumnName("direccion_normalizada")
                    .HasMaxLength(100);

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Long).HasColumnName("long");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(50);

                entity.Property(e => e.Piso)
                    .HasColumnName("piso")
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Farmacia>(entity =>
            {
                entity.ToTable("farmacia");

                entity.Property(e => e.FarmaciaId).HasColumnName("farmaciaID");

                entity.Property(e => e.Barrio)
                    .HasColumnName("barrio")
                    .HasMaxLength(50);

                entity.Property(e => e.CalleAltura).HasColumnName("calle_altura");

                entity.Property(e => e.CalleCruce)
                    .HasColumnName("calle_cruce")
                    .HasMaxLength(50);

                entity.Property(e => e.CalleNombre)
                    .HasColumnName("calle_nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.CodigoPostal).HasColumnName("codigo_postal");

                entity.Property(e => e.CodigoPostalArgentino)
                    .HasColumnName("codigo_postal_argentino")
                    .HasMaxLength(50);

                entity.Property(e => e.Comuna)
                    .HasColumnName("comuna")
                    .HasMaxLength(50);

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Long).HasColumnName("long");

                entity.Property(e => e.Objeto)
                    .IsRequired()
                    .HasColumnName("objeto")
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(50);
            });
        }
    }
}
