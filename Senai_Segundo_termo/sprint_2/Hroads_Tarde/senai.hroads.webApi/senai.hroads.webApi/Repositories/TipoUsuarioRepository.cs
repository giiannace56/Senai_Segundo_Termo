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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        hroadsContext _context = new hroadsContext();
        public void Atualizar(int id, TiposUsuario tipoAtualizado)
        {
            TiposUsuario tipoBuscado = _context.TiposUsuarios.Find(id);

            if (tipoAtualizado.TiposUsuarios != null)
            {
                tipoBuscado.TiposUsuarios = tipoAtualizado.TiposUsuarios;
            }

            _context.TiposUsuarios.Update(tipoBuscado);

            _context.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return _context.TiposUsuarios.FirstOrDefault(e => e.IdTiposUsuarios == id);
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            _context.TiposUsuarios.Add(novoTipoUsuario);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario tipoBuscado = _context.TiposUsuarios.Find(id);

            _context.TiposUsuarios.Remove(tipoBuscado);

            _context.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _context.TiposUsuarios.Include(e => e.Usuarios).ToList();
        }
    }
}
