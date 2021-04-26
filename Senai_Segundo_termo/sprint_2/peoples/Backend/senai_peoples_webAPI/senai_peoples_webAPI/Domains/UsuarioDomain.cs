using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webAPI.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Email do usuário obrigatório!")]
        [DataType(DataType.EmailAddress)] // deixa o email com o formato de email mesmo (tipo quando era feito no frontend)
        public string email { get; set; }

        [Required(ErrorMessage = "Senha do usuário obrigatório!")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Id de permissão obrigatório!")]
        public int idTipoUsuario { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }
    }
}
