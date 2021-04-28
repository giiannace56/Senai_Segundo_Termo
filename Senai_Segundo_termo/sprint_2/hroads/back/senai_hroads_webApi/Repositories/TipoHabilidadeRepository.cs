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
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext _context = new HroadsContext();

        public void Atualizar(int id, TipoHabilidade tipoAtualizado)
        {
            TipoHabilidade tipoBuscado = _context.TipoHabilidades.Find(id);

            if (tipoAtualizado.Tipo != null)
            {
                tipoBuscado.Tipo = tipoAtualizado.Tipo;
            }

            _context.TipoHabilidades.Update(tipoBuscado);

            _context.SaveChanges();
        }

        public TipoHabilidade BuscarPorId(int id)
        {
            return _context.TipoHabilidades.FirstOrDefault(e => e.IdTipo == id);
        }

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            _context.TipoHabilidades.Add(novoTipoHabilidade);
        }

        public void Deletar(int id)
        {
            TipoHabilidade tipoBuscado = _context.TipoHabilidades.Find(id);

            _context.TipoHabilidades.Remove(tipoBuscado);

            _context.SaveChanges();
        }

        public List<TipoHabilidade> Listar()
        {
            return _context.TipoHabilidades.Include(e => e.Habilidades).ToList();
        }
    }
}
