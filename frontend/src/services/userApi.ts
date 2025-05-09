import axios from 'axios';

const userApi = axios.create({
    baseURL: 'http://localhost:5602/api/User', // 🔗 UserService portunu kullan
    headers: {
        'Content-Type': 'application/json',
    },
});

// ✅ Token gerekiyorsa ekle
userApi.interceptors.request.use((config) => {
    const token = localStorage.getItem('token');
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export default userApi;
