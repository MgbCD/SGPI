using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SGPI.Models
{
    public partial class SGPI_DBContext : DbContext
    {
        public SGPI_DBContext()
        {
        }

        public SGPI_DBContext(DbContextOptions<SGPI_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entrevistum> Entrevista { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Homologacion> Homologacions { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Programa> Programas { get; set; }
        public virtual DbSet<ProgramaUsuario> ProgramaUsuarios { get; set; }
        public virtual DbSet<Programacion> Programacions { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2GEITJB\\SQLEXPRESS;Database=SGPI_DB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Entrevistum>(entity =>
            {
                entity.HasKey(e => e.IdEntrevista)
                    .HasName("PK__Entrevis__CAF89ECC0C5BF8E8");

                entity.Property(e => e.IdEntrevista).HasColumnName("id_entrevista");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaEntrevista)
                    .HasColumnType("date")
                    .HasColumnName("fecha_entrevista");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrevista_Usario");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__99A8E4F9EC736605");

                entity.ToTable("Genero");

                entity.Property(e => e.IdGenero).HasColumnName("id_genero");

                entity.Property(e => e.Genero1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("genero");
            });

            modelBuilder.Entity<Homologacion>(entity =>
            {
                entity.HasKey(e => e.IdHomologacion)
                    .HasName("PK__Homologa__ABCC8EE3B9DE4D58");

                entity.ToTable("Homologacion");

                entity.Property(e => e.IdHomologacion).HasColumnName("id_homologacion");

                entity.Property(e => e.FechaHomologacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_homologacion");

                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");

                entity.Property(e => e.IdPrograma).HasColumnName("id_programa");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.Property(e => e.Universidad)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("universidad");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Homologacion_Modulo");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Homologacion_Programa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Homologacion_Usuario");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("PK__Modulo__B2584DFCDB1DF80A");

                entity.ToTable("Modulo");

                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");

                entity.Property(e => e.Creditos).HasColumnName("creditos");

                entity.Property(e => e.IdPrograma).HasColumnName("id_programa");

                entity.Property(e => e.Modulo1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("modulo");

                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modulo_Programa");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pago__0941B074954A54D3");

                entity.ToTable("Pago");

                entity.Property(e => e.IdPago).HasColumnName("id_pago");

                entity.Property(e => e.ComprobantePago)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comprobante_pago");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_Usuario");
            });

            modelBuilder.Entity<Programa>(entity =>
            {
                entity.HasKey(e => e.IdPrograma)
                    .HasName("PK__Programa__DC3C5BC1CA052D07");

                entity.ToTable("Programa");

                entity.Property(e => e.IdPrograma).HasColumnName("id_programa");

                entity.Property(e => e.Pensum)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("pensum");

                entity.Property(e => e.Programa1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("programa");
            });

            modelBuilder.Entity<ProgramaUsuario>(entity =>
            {
                entity.HasKey(e => e.IdProgramaUsuario)
                    .HasName("PK__Programa__F1061D08F1452CE6");

                entity.ToTable("ProgramaUsuario");

                entity.Property(e => e.IdProgramaUsuario).HasColumnName("id_programa_usuario");

                entity.Property(e => e.IdPrograma).HasColumnName("id_programa");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.ProgramaUsuarios)
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProgramaUsuario_Programa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ProgramaUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProgramaUsuario_Usuario");
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.IdProgramacion)
                    .HasName("PK__Programa__3B2418FB98069541");

                entity.ToTable("Programacion");

                entity.Property(e => e.IdProgramacion).HasColumnName("id_programacion");

                entity.Property(e => e.Bloque).HasColumnName("bloque");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");

                entity.Property(e => e.IdPrograma).HasColumnName("id_programa");

                entity.Property(e => e.Salon)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("salon ");

                entity.Property(e => e.Semestre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("semestre");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programacion_Modulo");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programacion_Programa");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__6ABCB5E02BC41812");

                entity.ToTable("Rol");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Rol1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PK__TipoDocu__9F38507C2113A9A3");

                entity.ToTable("TipoDocumento");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.TipoDocumento1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__4E3E04AD72980D49");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Egresado).HasColumnName("egresado");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdGenero).HasColumnName("id_genero");

                entity.Property(e => e.IdPrograma).HasColumnName("id_programa");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Genero");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Programa");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_TipoDocumento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
