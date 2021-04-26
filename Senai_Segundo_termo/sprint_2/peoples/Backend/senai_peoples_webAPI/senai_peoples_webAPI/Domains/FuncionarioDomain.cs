using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webAPI.Domains
{
    public class FuncionarioDomain
    {
        /// <summary>
        /// Esta é a classe que representa a entidade(tabela) "funcionarios"
        /// </summary>
        public int idFuncionario { get; set; }

        [Required(ErrorMessage = "Nome do funcionário é obrigatório!")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Sobrenome do funcionário é obrigatório!")]
        public string sobrenome { get; set; }
        public DateTime dataNascimento { get; set; }
    }
}
