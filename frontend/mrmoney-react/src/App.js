import './App.css';

import backgroundImage from "./assets/tomioka-1920-1080.png";

function App() {
  return (
    <div className='container' style={{ backgroundImage: `url(${backgroundImage})`, backgroundRepeat: 'no-repeat' }}>
      <div className='form-login'>
        <form>
          <h3>LOGIN</h3>
          <input type='text' placeholder='Username'/>
          
          <input type='text' placeholder='Username'/>
          
          <input type='submit' placeholder='Username'/>
        </form>
      </div>
    </div>
  );
}

export default App;
