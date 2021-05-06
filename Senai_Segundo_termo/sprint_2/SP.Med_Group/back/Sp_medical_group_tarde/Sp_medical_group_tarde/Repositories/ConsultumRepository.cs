using Microsoft.EntityFrameworkCore;
using Sp_medical_group_tarde.Context;
using Sp_medical_group_tarde.Domains;
using Sp_medical_group_tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_medical_group_tarde.Repositories
{
    public class ConsultumRepository : IConsultaRepository
    {
        MedicalContext ctx = new MedicalContext();
        public void Atualizar(int id, Consultum ConsultumAtualizado)
        {
            Consultum ConsultumBuscado = ctx.Consulta.Find(id);

            if (ConsultumAtualizado.IdMedico != null)
            {
                ConsultumBuscado.IdMedico = ConsultumAtualizado.IdMedico;
            }

            if (ConsultumAtualizado.IdPaciente != null)
            {
                ConsultumBuscado.IdPaciente = ConsultumAtualizado.IdPaciente;
            }

            if (ConsultumAtualizado.IdSituacao != null)
            {
                ConsultumBuscado.IdSituacao = ConsultumAtualizado.IdSituacao;
            }

            if (ConsultumAtualizado.DataConsulta > DateTime.Now )
            {
                ConsultumBuscado.DataConsulta = ConsultumAtualizado.DataConsulta;
            }

            if (ConsultumAtualizado.HoraConsulta != null)
            {
                ConsultumBuscado.HoraConsulta = ConsultumAtualizado.HoraConsulta;
            }

            if (ConsultumAtualizado.Descricao != null)
            {
                ConsultumBuscado.Descricao = ConsultumBuscado.Descricao;
            }

            if (ConsultumAtualizado.Descricao == null)
            {
                ConsultumBuscado.Descricao = ConsultumBuscado.Descricao;
            }

            ctx.Consulta.Update(ConsultumBuscado);

            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(tu => tu.IdConsulta == id);
        }

        public void Cadastrar(Consultum novoConsultum)
        {
            ctx.Consulta.Add(novoConsultum);

            ctx.SaveChanges();
        }

        public void Deletar(int id) 
        {
            Consultum ConsultumBuscado = ctx.Consulta.Find(id);

            ctx.Consulta.Remove(ConsultumBuscado);

            ctx.SaveChanges();
        }

        public List<Consultum> Listar()
        {
            return ctx.Consulta.ToList();
        }

        public List<Consultum> Minhas(int idUsuario)
        {
            return ctx.Consulta

                .Include(p => p.IdMedicoNavigation)

                .Include(p => p.IdPacienteNavigation)

                .Include(p => p.IdSituacaoNavigation)

                .Where(p => p.IdConsulta == idUsuario)

                .ToList();
        }

        public void AlterStatus(int id, string ConsultumPermissao)  
        {
            Consultum ConsultumBuscado = ctx.Consulta

                .Include(p => p.IdMedicoNavigation)

                .Include(p => p.IdPacienteNavigation)

                .Include(p => p.IdSituacaoNavigation)

                .FirstOrDefault(p => p.IdConsulta == id);

            switch (ConsultumPermissao)
            {
                case "1" :
                    ConsultumBuscado.IdSituacao = 1;
                    break;

                case "2":
                    ConsultumBuscado.IdSituacao = 2;
                    break;

                case "3":
                    ConsultumBuscado.IdSituacao = 3;
                    break;

                default:
                    ConsultumBuscado.IdSituacao = ConsultumBuscado.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(ConsultumBuscado);

            ctx.SaveChanges();
        }

        public void Prontuario(int id, Consultum novoProntuario)
        {
            Consultum ConsultumBuscado = ctx.Consulta.Find(id);

            if (novoProntuario.Descricao != null)
            {
                ConsultumBuscado.Descricao = novoProntuario.Descricao;
            }

            ctx.Consulta.Update(ConsultumBuscado);

            ctx.SaveChanges();
        }
    }
}
