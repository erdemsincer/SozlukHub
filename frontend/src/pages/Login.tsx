import React, { useState } from 'react';
import { jwtDecode } from 'jwt-decode';
import api from '../services/authApi.';
import './Login.css';


interface JwtPayload {
    name?: string;
    sub?: string;
    nameid?: string;
    username?: string;
    [key: string]: any;
}

const Login: React.FC = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await api.post('/auth/login', {
                email,
                password,
            });

            const token = response.data.token;
            localStorage.setItem('token', token);

            const decoded = jwtDecode<JwtPayload>(token);
            localStorage.setItem('username', decoded.name || decoded.username || 'Kullanıcı');

            alert(`✅ Giriş başarılı, hoş geldin ${decoded.name || decoded.username || 'kullanıcı'}!`);
            window.location.href = '/';
        } catch (err: any) {
            console.error(err);
            alert('❌ Giriş başarısız: ' + (err.response?.data || 'Sunucu hatası'));
        }
    };

    return (
        <div className="login-wrapper">
            <form className="login-form" onSubmit={handleSubmit}>
                <h2>Giriş Yap</h2>
                <input
                    type="email"
                    placeholder="E-posta"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />
                <input
                    type="password"
                    placeholder="Şifre"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
                <button type="submit">Giriş</button>
            </form>
        </div>
    );
};

export default Login;
