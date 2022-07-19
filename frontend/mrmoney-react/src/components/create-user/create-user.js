import '../../styles.css';
import './create-user.css';

import React, { useState } from 'react';

import App from '../../App';

function CreateUser() {
    const [toggle, setToggle] = useState('');
    let teste = async function teste() {
        const response = await fetch(`https://localhost:7267/auth`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: 'teste', username: 'teste', password: 'teste' })
        });
        return await response.json();
    };
    return (
        <div className='form-group'>
            <form onSubmit={teste()}>
                <h3 className='form-title'>CADASTRAR</h3>
                <input className='form-input' type='text' placeholder='nome'></input>
                <input className='form-input' type='text' placeholder='username'></input>
                <input className='form-input' type='password' placeholder='senha'></input>
                <input className='form-input btn-group' type='submit' placeholder='Cadastrar' value='Cadastrar'></input>
            </form>
            <a href='www.google.com' onClick={() => {setToggle(true)}}>Fazer Login</a>
            {toggle && <App componentName={'CREATE'}></App>}
        </div>
    );
}

export default CreateUser;
