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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HroadsContext _context = new HroadsContext();

        public void Atualizar(int id, TipoUsuario tipoAtualizado)
        {
            TipoUsuario tipoBuscado = _context.TipoUsuarios.Find(id);

            if (tipoAtualizado.Tipo != null)
            {
                tipoBuscado.Tipo = tipoAtualizado.Tipo;
            }

            _context.TipoUsuarios.Update(tipoBuscado);

            _context.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return _context.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            _context.TipoUsuarios.Add(novoTipoUsuario);
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoBuscado = _context.TipoUsuarios.Find(id);

            _context.TipoUsuarios.Remove(tipoBuscado);

            _context.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return _context.TipoUsuarios.Include(e => e.Usuarios).ToList();
        }
    }
}
