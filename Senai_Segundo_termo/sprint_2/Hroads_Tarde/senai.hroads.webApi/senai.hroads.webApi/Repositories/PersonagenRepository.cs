using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagenRepository : IPersonagemRepository
    {
        hroadsContext _context = new hroadsContext();
        public void Atualizar(int id, Personagen personagemAtualizado)
        {
            Personagen personagemBuscado = _context.Personagens.Find(id);

            if (personagemAtualizado.Nomes != null)
            {
                personagemBuscado.Nomes = personagemAtualizado.Nomes;
                personagemBuscado.IdClasses = personagemAtualizado.IdClasses;
                personagemBuscado.VidaMaxima = personagemAtualizado.VidaMaxima;
                personagemBuscado.ManaMaxima = personagemAtualizado.ManaMaxima;
                personagemBuscado.DataAtualizacao = DateTime.Now;
            }

            _context.Personagens.Update(personagemBuscado);

            _context.SaveChanges();
        }

        public Personagen BuscarPorId(int id)
        {
            return _context.Personagens.FirstOrDefault(e => e.IdPersonagem == id);
        }

        public void Cadastrar(Personagen novoPersonagem)
        {
            _context.Personagens.Add(novoPersonagem);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Personagen personagemBuscado = _context.Personagens.Find(id);

            _context.Personagens.Remove(personagemBuscado);

            _context.SaveChanges();
        }

        public List<Personagen> Listar()
        {
            return _context.Personagens.Include(e => e.IdClassesNavigation).ToList();
        }
    }
}
