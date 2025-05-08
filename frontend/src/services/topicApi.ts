import axios from 'axios';

const topicApi = axios.create({
    baseURL: 'http://localhost:5603/api/Topic', // ✅ Büyük harf önemli!
    headers: {
        'Content-Type': 'application/json',
    },
});

// ✅ Interceptor ile token ekle
topicApi.interceptors.request.use((config) => {
    const token = localStorage.getItem('token');
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export default topicApi;
