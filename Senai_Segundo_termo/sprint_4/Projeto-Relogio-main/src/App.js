import React from 'react';
import './App.css';

// Define uma data formatada.
function DataFormatada(props) {
  return <h2>Horário Atual: {props.date.toLocaleTimeString()}</h2>
}

// Definindo a classe que será chamado na renderização.
class Clock extends React.Component{
  constructor(propos){
    super(propos)
    this.state ={
      // Define a data atual
      date : new Date()
    };
  }

  // Ciclo de vida que ocorre quando a Clock é inserida na DOM
  componentDidMount(){
    this.timerId = setInterval( () => {
      this.thick()
    }, 1000);
  }

  // Ciclo de vida quando o componente é removido da DOM
  componentWillUnmount(){
    clearInterval(this.timerId);
  }

  // Define no state date a data atual a cada thick
  thick(){
    this.setState({
      date : new Date()
    });
  }

  pause(){
    clearInterval(this.timerId);
    console.log(`Relógio ${this.timerID} pausado!`)
  }

  retomar(){
    this.timerId = setInterval( () => {
      this.thick()
    }, 1000);
    console.log(`Relógio ${this.timerID} retomado!`)
  }

  // Renderizar a data que vem da classe, com a alteração da data Formatada
  render(){
    return (
      <div>
        <h1>Relogio</h1>
        <DataFormatada date={this.state.date}></DataFormatada>
        <button style={{margin : "20px", backgroundColor : "red", color: "white", height : "25px", fontWeight: "600"}} onClick={() => this.pause()}>Pausar</button>
        <button style={{backgroundColor : "green", color : "white", height : "25px", fontWeight: "600"}} onClick={() => this.retomar()}>Retomar</button>
      </div>
    )
  }

}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Clock></Clock>
        <Clock></Clock>
      </header>
    </div>
  );
}

export default App;
