import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5601/api', // ✅ AuthService portuna göre ayarla
    headers: {
        'Content-Type': 'application/json',
    },
});

export default api;
