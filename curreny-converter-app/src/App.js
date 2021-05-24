import { useEffect, useState } from 'react';
import { BrowserRouter } from 'react-router-dom';
import Home from './containers/Home';
import Header from './components/Header';

import CurrencyContext from './Contexts/CurrencyContext';

import './App.css';

function App() {

  const [ currencies, setCurrencies ] = useState([]);
  
  useEffect(() => {
    fetch("https://localhost:5001/api/currencies")
      .then(response => response.json())
      .then(response  => setCurrencies(response));

    // Apparently, Axios enforces CORS and the server-side should
    // respond with the necessary Header but no success until now...

    // api.get('currencies', {
    //   crossdomain: true
    // }).then(response => {
    //     console.log(response)
    //     // setCurrencies(response.data);
    //   })

  }, []);

  return (
    <div className="App">
      <BrowserRouter>
        <Header />
        <CurrencyContext.Provider value={currencies}>
          <Home />      
        </CurrencyContext.Provider>
      </BrowserRouter>
    </div>
  );
}

export default App;
