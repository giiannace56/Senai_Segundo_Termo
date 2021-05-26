import './App.css';
import { Component } from 'react';

class Git extends Component
{
  constructor(propriedades)
  {
    super(propriedades)
    this.state =
    {
      listaRepositorios : [],
      nomeRepositorio : ''
    }
  }

  buscarRepositorios = (dados) =>
  {
    dados.preventDefault();

    console.log('DEU BOM')

    fetch('https://api.github.com/users/' + this.state.nomeRepositorio + '/repos')

    .then(request => request.json())

    .then(list => this.setState({ listaRepositorios : list }))

    .catch( erro => console.log(erro) )
  }

  atualizaroNome = async (nome) => 
  {
    await this.setState({ nomeRepositorio : nome.target.value })
    console.log(this.state.nomeRepositorio)
  }

  render()
  {
  return (
    <div className="App">
      <main>
        <div>
          <h2> Busque pelo seu Repositorio </h2>
          <form onSubmit={this.buscarRepositorios}>
            <div>
              <input
              type="text"
              value={this.state.nomeRepositorio}
              onChange={this.atualizaroNome}
              placeholder="Buscar pelo seu Git"
              />
              <button type="submit" onClick={this.buscarRepositorios}> Localizar </button>
            </div>
          </form>
        </div>
        <section>
          <table>
            <thead>
              <tr>
                <th> ID </th>
                <th> NOME </th>
                <th> DESCRIÇÃO </th>
                <th> DATA DE CRIAÇÃO </th>
                <th> TAMANHO </th>
              </tr>
            </thead>
            <tbody class="cabecalho">
              {  this.state.listaRepositorios.map( (repositorio) => {           
                  return(
                    <tr key={repositorio.id}>
                      <td>{repositorio.id}</td>
                      <td>{repositorio.name}</td>
                      <td>{repositorio.description}</td>
                      <td>{repositorio.created_at}</td>
                      <td>{repositorio.size}</td>
                    </tr>
                  )
                })
              }
            </tbody>
          </table>        
        </section>
      </main>
    </div>
    )
  }
}

export default Git;
