using Sp_medical_group_tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_medical_group_tarde.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> Listar();

        Consultum BuscarPorId(int id);

        void Cadastrar(Consultum novoConsultum);

        void Atualizar(int id, Consultum ConsultumAtualizado);
            
        void Deletar(int id);

        List<Consultum> Minhas(int idUsuario);

        void AlterStatus(int id, string ConsultumPermissao);

        void Prontuario(int id, Consultum novoProntuario);
    }
}
