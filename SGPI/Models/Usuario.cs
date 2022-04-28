using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SGPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Entrevista = new HashSet<Entrevistum>();
            Homologacions = new HashSet<Homologacion>();
            Pagos = new HashSet<Pago>();
            ProgramaUsuarios = new HashSet<ProgramaUsuario>();
        }

        public int IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [MinLength(2)]
        public string Apellido { get; set; }
        public int IdGenero { get; set; }
        public int IdTipoDocumento { get; set; }
        public int Documento { get; set; }
        public int IdPrograma { get; set; }
        [EmailAddress(ErrorMessage = "Error con el correo")]
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int IdRol { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }
        public bool Egresado { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Programa IdProgramaNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Entrevistum> Entrevista { get; set; }
        public virtual ICollection<Homologacion> Homologacions { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<ProgramaUsuario> ProgramaUsuarios { get; set; }
    }
}
