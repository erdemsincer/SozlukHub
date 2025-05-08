import React, { useState } from 'react';
import api from '../services/api';
import './Login.css'; // Aynı CSS'i kullanabiliriz

const Register: React.FC = () => {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleRegister = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await api.post('/auth/register', {
                username,
                email,
                password,
            });

            alert('✅ Kayıt başarılı! Şimdi giriş yapabilirsin.');
            window.location.href = '/login';
        } catch (err: any) {
            console.error(err);
            alert('❌ Kayıt başarısız: ' + err.response?.data || 'Sunucu hatası');
        }
    };

    return (
        <div className="login-wrapper">
            <form className="login-form" onSubmit={handleRegister}>
                <h2>Kayıt Ol</h2>
                <input
                    type="text"
                    placeholder="Kullanıcı Adı"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    required
                />
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
                <button type="submit">Kayıt Ol</button>
                <p className="register-link">Zaten hesabın var mı? <a href="/login">Giriş Yap</a></p>
            </form>
        </div>
    );
};

export default Register;
