import './create-user.css';

function CreateUser() {
    let teste = async function teste() {
        const response = await fetch(`https://localhost:7267/auth`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: 'teste', username: 'teste', password: 'teste' })
        });
        return await response.json();
    };
    return (
        <div className='container'>
            <form onSubmit={teste()}>
                <input type='text' placeholder='nome'></input>
                <input type='text' placeholder='username'></input>
                <input type='password' placeholder='senha'></input>
                <input type='submit' placeholder='Cadastrar' value='Cadastrar'></input>
            </form>
        </div>
    );
}

export default CreateUser;
