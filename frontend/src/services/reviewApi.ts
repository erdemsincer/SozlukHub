import axios from 'axios';

const reviewApi = axios.create({
    baseURL: 'http://localhost:5607/api', // ReviewService portu
    headers: {
        'Content-Type': 'application/json',
    },
});

export default reviewApi;
