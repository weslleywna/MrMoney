import React from 'react';

import './App.css';

import backgroundImage from "./assets/tomioka-1920-1080.png";

import AppRoutes from './routes/app-route';

function App() {
  return (
    <div className='container' style={{ backgroundImage: `url(${backgroundImage})`, backgroundRepeat: 'no-repeat' }}>

      <AppRoutes></AppRoutes>

    </div>
  );
}

export default App;
