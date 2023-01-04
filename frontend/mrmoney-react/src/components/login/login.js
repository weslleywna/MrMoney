import '../../styles.css';
import './login.css';

import { Link } from 'react-router-dom';

function Login() {
    return (
        <div className='form-group'>
            <form>
                <h3 className='form-title'>LOGIN</h3>
                <input type='text' className='form-input' placeholder='Username' />

                <input type='password' className='form-input' placeholder='Password' />

                <input type='submit' className='form-input btn-group' />
            </form>
            <Link to='/create'>CADASTRAR</Link>
        </div>
    );
}

export default Login;
