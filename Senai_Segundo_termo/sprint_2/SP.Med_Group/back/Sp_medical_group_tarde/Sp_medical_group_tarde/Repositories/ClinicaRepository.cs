using Sp_medical_group_tarde.Context;
using Sp_medical_group_tarde.Domains;
using Sp_medical_group_tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_medical_group_tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(int id, Clinica ClinicaAtualizado)
        {
            Clinica ClinicaBuscada = BuscarPorId(id);

            if (ClinicaAtualizado.Cnpj != null)
            {
                ClinicaBuscada.Cnpj = ClinicaAtualizado.Cnpj;
            }

            if (ClinicaAtualizado.Endereco != null)
            {
                ClinicaBuscada.Endereco = ClinicaAtualizado.Endereco;
            }

            if (ClinicaAtualizado.NomeFantasia != null)
            {
                ClinicaBuscada.NomeFantasia = ClinicaAtualizado.NomeFantasia;
            }

            if (ClinicaAtualizado.RazaoSocial != null)
            {
                ClinicaBuscada.RazaoSocial = ClinicaAtualizado.RazaoSocial;
            }

            ctx.Clinicas.Update(ClinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.Find(id);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
