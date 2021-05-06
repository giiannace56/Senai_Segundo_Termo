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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        hroadsContext _context = new hroadsContext();
        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = _context.Habilidades.Find(id);

            if (habilidadeAtualizada.Tecnicas != null)
            {
                habilidadeBuscada.Tecnicas = habilidadeAtualizada.Tecnicas;
            }

            _context.Habilidades.Update(habilidadeBuscada);

            _context.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            return _context.Habilidades.FirstOrDefault(e => e.IdHabilidades == id);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            _context.Habilidades.Add(novaHabilidade);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Habilidade habilidadeBuscado = _context.Habilidades.Find(id);

            _context.Habilidades.Remove(habilidadeBuscado);

            _context.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return _context.Habilidades.ToList();
        }
    }
}
