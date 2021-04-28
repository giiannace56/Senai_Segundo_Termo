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
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext _context = new HroadsContext();

        public void Atualizar(int id, Classe classeAtualizada)
        {
            Classe classeBuscada = _context.Classes.Find(id);

            if (classeAtualizada.NomeClasse != null)
            {
                classeBuscada.NomeClasse = classeAtualizada.NomeClasse;
            }

            _context.Classes.Update(classeBuscada);

            _context.SaveChanges();
        }

        public Classe BuscarPorId(int id)
        {
            return _context.Classes.FirstOrDefault(e => e.IdClasse == id);
        }

        public void Cadastrar(Classe novaclasse)
        {
            _context.Classes.Add(novaclasse);
        }

        public void Deletar(int id)
        {
            Classe classeBuscado = _context.Classes.Find(id);

            _context.Classes.Remove(classeBuscado);

            _context.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return _context.Classes.Include(e => e.Personagens).ToList();
        }
    }
}
