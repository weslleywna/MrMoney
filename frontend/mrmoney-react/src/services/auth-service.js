import axios from 'axios';

const authService = axios.create({
    baseURL: 'https://localhost:7267'
});

export default authService;