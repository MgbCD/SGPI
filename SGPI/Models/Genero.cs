using System;
using System.Collections.Generic;

#nullable disable

namespace SGPI.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdGenero { get; set; }
        public string Genero1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
