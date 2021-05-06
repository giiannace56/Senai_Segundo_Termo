using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sp_medical_group_tarde.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int IdTiposUsuarios { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha deve ser informado!")]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTiposUsuariosNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
