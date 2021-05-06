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
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        hroadsContext _context = new hroadsContext();
        public void Atualizar(int id, TiposHabilidade tipoAtualizado)
        {
            TiposHabilidade tipoBuscado = _context.TiposHabilidades.Find(id);

            if (tipoAtualizado.Tipos != null)
            {
                tipoBuscado.Tipos = tipoAtualizado.Tipos;
            }

            _context.TiposHabilidades.Update(tipoBuscado);

            _context.SaveChanges();
        }

        public TiposHabilidade BuscarPorId(int id)
        {
            return _context.TiposHabilidades.FirstOrDefault(e => e.IdTiposHabilidades == id);
        }

        public void Cadastrar(TiposHabilidade novoTipo)
        {
            _context.TiposHabilidades.Add(novoTipo);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposHabilidade tipoBuscado = _context.TiposHabilidades.Find(id);

            _context.TiposHabilidades.Remove(tipoBuscado);

            _context.SaveChanges();
        }

        public List<TiposHabilidade> Listar()
        {
            return _context.TiposHabilidades.ToList();
        }
    }
}
