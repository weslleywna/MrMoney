import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import Login from '../components/login/login';
import CreateUser from '../components/create-user/create-user';

function AppRoutes() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<Login></Login>}></Route>
                <Route path='/create' element={<CreateUser></CreateUser>}></Route>
            </Routes>
        </BrowserRouter>
    );
}

export default AppRoutes;