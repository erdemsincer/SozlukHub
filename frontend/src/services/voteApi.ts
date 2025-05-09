import axios from 'axios';

const voteApi = axios.create({
    baseURL: 'http://localhost:5605/api/vote',
    headers: {
        'Content-Type': 'application/json',
    },
});

voteApi.interceptors.request.use((config) => {
    const token = localStorage.getItem('token');
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

// 🟢 Oy sayısını çekmek için eklenen fonksiyon
export const getVoteCount = async (entryId: number) => {
    const response = await voteApi.get(`/entry/${entryId}`);
    return response.data;
};

export default voteApi;
