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
    public class UsuarioRepository : IUsuarioRepository
    {
        hroadsContext _context = new hroadsContext();
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);

            if (usuarioAtualizado.EmailsUsuarios != null)
            {
                usuarioBuscado.EmailsUsuarios = usuarioAtualizado.EmailsUsuarios;
                usuarioBuscado.SenhasUsuarios = usuarioAtualizado.SenhasUsuarios;
                usuarioBuscado.IdTiposUsuarios = usuarioAtualizado.IdTiposUsuarios;
            }

            _context.Usuarios.Update(usuarioBuscado);

            _context.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(e => e.IdUsuarios == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            _context.Usuarios.Add(novoUsuario);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(usuarioBuscado);

            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.Include(e => e.IdTiposUsuariosNavigation).ToList();
        }
    }
}
