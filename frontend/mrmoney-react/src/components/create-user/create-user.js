import '../../styles.css';
import './create-user.css';

import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';

import authService from '../../services/auth-service';

function CreateUser() {
    let navigate = useNavigate();
    const [name, setName] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    async function createUser(e) {
        e.preventDefault();
        await authService.post(`/auth`, {
            name: name,
            username: username,
            password: password
        })
            .then(response => {
                navigate("/", { replace: true });
            }).catch((error) => {
                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    console.log(error.response.data);
                    console.log(error.response.status);
                    console.log(error.response.headers);
                } else if (error.request) {
                    // The request was made but no response was received
                    // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
                    // http.ClientRequest in node.js
                    console.log(error.request);
                } else {
                    // Something happened in setting up the request that triggered an Error
                    console.log('Error', error.message);
                }
            });;
    }

    return (
        <div className='form-group'>
            <form onSubmit={createUser}>
                <h3 className='form-title'>CADASTRAR</h3>
                <input className='form-input' type='text' placeholder='nome' onChange={e => setName(e.target.value)} value={name}></input>
                <input className='form-input' type='text' placeholder='username' onChange={e => setUsername(e.target.value)} value={username}></input>
                <input className='form-input' type='password' placeholder='senha' onChange={e => setPassword(e.target.value)} value={password}></input>
                <input className='form-input btn-group' type='submit' placeholder='Cadastrar' value='Cadastrar'></input>
            </form>
            <Link to='/'>FAZER LOGIN</Link>
        </div >
    );
}

export default CreateUser;
