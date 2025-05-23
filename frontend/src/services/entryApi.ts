import axios from 'axios';

const entryApi = axios.create({
    baseURL: 'http://localhost:5604/api', // EntryService
    headers: { 'Content-Type': 'application/json' },
});

entryApi.interceptors.request.use((config) => {
    const token = localStorage.getItem('token');
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});
export const getEntriesByTopic = async (topicId: number) => {
    const response = await entryApi.get(`/Entry/topic/${topicId}`);
    return response.data;
};
export default entryApi;
