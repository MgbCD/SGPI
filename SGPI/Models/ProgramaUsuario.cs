using System;
using System.Collections.Generic;

#nullable disable

namespace SGPI.Models
{
    public partial class ProgramaUsuario
    {
        public int IdProgramaUsuario { get; set; }
        public int IdPrograma { get; set; }
        public int IdUsuario { get; set; }

        public virtual Programa IdProgramaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
