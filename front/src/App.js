import './App.css';
import React, { useState, useEffect } from 'react';
import Report from './Paginas/Report';
import * as GestorDeDados from './DataManager';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {

  const [data, setData] = useState({ movimentacoes: null });

  const fetchData = async () => {
    const response = await GestorDeDados.GetMovimentacao();   
    setData({ movimentacoes: response });
  };
 
  useEffect( () => {     
    fetchData() 
  }, [] );

  return (

    <div className="App">
       {data.movimentacoes ? <Report data={data}/> : <div>Nenhum report a ser exibido.</div> }
    </div>
  );          
}

export default App;
