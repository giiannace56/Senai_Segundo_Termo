using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi.Domains;

#nullable disable

namespace senai.hroads.webApi.Contexts
{
    public partial class hroadsContext : DbContext
    {
        public hroadsContext()
        {
        }

        public hroadsContext(DbContextOptions<hroadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassesHabilidade> ClassesHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagen> Personagens { get; set; }
        public virtual DbSet<TiposHabilidade> TiposHabilidades { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263. //
                optionsBuilder.UseSqlServer("Data Source=LAB08DESK501\\SQLEXPRESS; Initial Catalog= HRoads; user ID=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClasses)
                    .HasName("PK__Classes__57010672080657FF");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.Cargos)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClassesHabilidade>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.IdHabilidades).HasColumnName("idHabilidades");

                entity.HasOne(d => d.IdClassesNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClasses)
                    .HasConstraintName("FK__ClassesHa__idCla__3F466844");

                entity.HasOne(d => d.IdHabilidadesNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHabilidades)
                    .HasConstraintName("FK__ClassesHa__idHab__403A8C7D");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidades)
                    .HasName("PK__Habilida__A5B0BFF589ABF162");

                entity.Property(e => e.IdHabilidades).HasColumnName("idHabilidades");

                entity.Property(e => e.Tecnicas)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personagen>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72E9FC72DA9");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.DataAtualizacao).HasColumnType("date");

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.ManaMaxima)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nomes)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VidaMaxima)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClassesNavigation)
                    .WithMany(p => p.Personagens)
                    .HasForeignKey(d => d.IdClasses)
                    .HasConstraintName("FK__Personage__idCla__4316F928");
            });

            modelBuilder.Entity<TiposHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTiposHabilidades)
                    .HasName("PK__TiposHab__B078A372E5426C86");

                entity.Property(e => e.IdTiposHabilidades).HasColumnName("idTiposHabilidades");

                entity.Property(e => e.Tipos)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTiposUsuarios)
                    .HasName("PK__TiposUsu__568086D5E1806933");

                entity.Property(e => e.IdTiposUsuarios).HasColumnName("idTiposUsuarios");

                entity.Property(e => e.TiposUsuarios)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios)
                    .HasName("PK__Usuarios__3940559AAC1DA3DA");

                entity.HasIndex(e => e.EmailsUsuarios, "UQ__Usuarios__0C474291E8054058")
                    .IsUnique();

                entity.Property(e => e.IdUsuarios).HasColumnName("idUsuarios");

                entity.Property(e => e.EmailsUsuarios)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("emailsUsuarios");

                entity.Property(e => e.IdTiposUsuarios).HasColumnName("idTiposUsuarios");

                entity.Property(e => e.SenhasUsuarios)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senhasUsuarios");

                entity.HasOne(d => d.IdTiposUsuariosNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTiposUsuarios)
                    .HasConstraintName("FK__Usuarios__idTipo__4F7CD00D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
