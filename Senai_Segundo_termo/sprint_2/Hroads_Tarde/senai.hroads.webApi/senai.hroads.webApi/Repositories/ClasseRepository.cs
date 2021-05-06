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
    public class ClasseRepository : IClasseRepository
    {
        hroadsContext _context = new hroadsContext();
        public void Atualizar(int id, Class classeAtualizada)
        {
            Class classeBuscada = _context.Classes.Find(id);

            if (classeAtualizada.Cargos != null)
            {
                classeBuscada.Cargos = classeAtualizada.Cargos;
            }

            _context.Classes.Update(classeBuscada);

            _context.SaveChanges();
        }

        public Class BuscarPorId(int id)
        {
            return _context.Classes.FirstOrDefault(e => e.IdClasses == id);
        }

        public void Cadastrar(Class novaClasse)
        {
            _context.Classes.Add(novaClasse);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Class classeBuscado = _context.Classes.Find(id);

            _context.Classes.Remove(classeBuscado);

            _context.SaveChanges();
        }

        public List<Class> Listar()
        {
            return _context.Classes.Include(e => e.Personagens).ToList();
        }
    }
}
