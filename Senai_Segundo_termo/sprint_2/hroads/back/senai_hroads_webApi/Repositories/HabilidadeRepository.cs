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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext _context = new HroadsContext();

        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = _context.Habilidades.Find(id);

            if (habilidadeAtualizada.Habilidade1 != null)
            {
                habilidadeBuscada.Habilidade1 = habilidadeAtualizada.Habilidade1;
            }

            _context.Habilidades.Update(habilidadeBuscada);

            _context.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            return _context.Habilidades.FirstOrDefault(e => e.IdHabilidade == id);
        }

        public void Cadastrar(Habilidade novahabilidade)
        {
            _context.Habilidades.Add(novahabilidade);
        }

        public void Deletar(int id)
        {
            Habilidade habilidadeBuscado = _context.Habilidades.Find(id);

            _context.Habilidades.Remove(habilidadeBuscado);

            _context.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return _context.Habilidades.Include(e => e.IdTipoNavigation).ToList();
        }
    }
}
