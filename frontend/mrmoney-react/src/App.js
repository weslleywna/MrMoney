import React, { useState } from 'react';

import './App.css';

import backgroundImage from "./assets/tomioka-1920-1080.png";

import Login from './components/login/login';
import CreateUser from './components/create-user/create-user';

function App() {
  const [toggle, setToggle] = useState('INITIAL');
  const [showLogin, setShowLogin] = useState('');
  return (
    <div className='container' style={{ backgroundImage: `url(${backgroundImage})`, backgroundRepeat: 'no-repeat' }}>

      {(toggle === 'INITIAL' || showLogin) && <button type='button' onClick={() => { setToggle('LOGIN'); setShowLogin(false); }}> LOGIN </button >}
      {(toggle === 'INITIAL' || !showLogin) && <button type='button' onClick={() => { setToggle('CREATE'); setShowLogin(true); }}> CRIAR </button >}

      {toggle === 'LOGIN' && <Login></Login>}
      {toggle === 'CREATE' && <CreateUser></CreateUser>}

    </div>
  );
}

export default App;
