using senai.inlock.webApi_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IEstudioRepository
    {

        //CRUD

        List<Estudios> Listar();

        Estudios ListarId(int id);

        void Cadastrar(Estudios novoEstudio);

        void DeletarId(int id);

        void AtualizarId(int id, Estudios EstudioAtt);
    }
}
