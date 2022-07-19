import React, { useState } from 'react';

import './App.css';

import backgroundImage from "./assets/tomioka-1920-1080.png";

import Login from './components/login/login';
import CreateUser from './components/create-user/create-user';

function App({componentName = ''}) {
  const [showComponent, setShowComponent] = useState('');
  const [hide, setHide] = useState(false);
  console.log(componentName);
  //setShowComponent(componentName);
  return (
    <div className='container' style={{ backgroundImage: `url(${backgroundImage})`, backgroundRepeat: 'no-repeat' }}>

      { !hide && <button type='button' onClick={() => { setShowComponent('LOGIN'); setHide(true) }}> LOGIN </button> }
      { !hide && <button type='button' onClick={() => { setShowComponent('CREATE'); setHide(true) }}> CRIAR </button> }

      {showComponent === 'CREATE' && <CreateUser></CreateUser>}
      {showComponent === 'LOGIN' && <Login></Login>}

    </div>
  );
}

export default App;
