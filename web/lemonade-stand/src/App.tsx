import React, { useEffect, useState } from 'react';
import logo from './images/logo.png';
import './App.css';
import { LemonadeService } from './http/lemonadeService';
import lemonade from './types/lemonade';
import Order from './components/order';

function App() {
  const [items, setItems] = useState<lemonade[]>([]);

  useEffect(() => {
    const service = new LemonadeService();
    service.getLemonades().then(lemonades => {
      setItems(lemonades);
    });
    
  },[]);

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} alt="logo" />
      </header>
      <Order items={items} />
    </div>
  );
}

export default App;
