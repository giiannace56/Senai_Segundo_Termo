using Microsoft.EntityFrameworkCore;
using senai_hroads_webApi.Contexts;
using senai_hroads_webApi.Domains;
using senai_hroads_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {

        HroadsContext _context = new HroadsContext();

        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = _context.Personagens.Find(id);

            if (personagemAtualizado.Nome != null)
            {
                personagemBuscado.Nome = personagemAtualizado.Nome;
                personagemBuscado.IdClasse = personagemAtualizado.IdClasse;
                personagemBuscado.CapMaxVida = personagemAtualizado.CapMaxVida;
                personagemBuscado.CapMaxMana = personagemAtualizado.CapMaxMana;
                personagemBuscado.DataAtualizacao = DateTime.Now;
            }

            _context.Personagens.Update(personagemBuscado);

            _context.SaveChanges();
        }

        public Personagem BuscarPorId(int id)
        {
            return _context.Personagens.FirstOrDefault(e => e.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            _context.Personagens.Add(novoPersonagem);
        }

        public void Deletar(int id)
        {
            Personagem personagemBuscado = _context.Personagens.Find(id);

            _context.Personagens.Remove(personagemBuscado);

            _context.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return _context.Personagens.Include(e => e.IdClasseNavigation).ToList();
        }
    }
}
