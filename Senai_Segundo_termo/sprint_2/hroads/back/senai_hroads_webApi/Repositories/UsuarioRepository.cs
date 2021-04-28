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
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadsContext _context = new HroadsContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }

            _context.Usuarios.Update(usuarioBuscado);

            _context.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            _context.Usuarios.Add(novoUsuario);
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(usuarioBuscado);

            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.Include(e => e.IdTipoUsuarioNavigation).ToList();
        }
    }
}
