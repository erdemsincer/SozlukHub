import React, { useState } from 'react';
import './Login.css';

const Login: React.FC = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        alert(`Email: ${email}\nPassword: ${password}`);
        // TODO: Buraya API isteði gelecek
    };

    return (
        <div className="login-wrapper">
            <form className="login-form" onSubmit={handleSubmit}>
                <h2>Giriþ Yap</h2>
                <input
                    type="email"
                    placeholder="E-posta"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />
                <input
                    type="password"
                    placeholder="Þifre"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
                <button type="submit">Giriþ</button>
                <p className="register-link">Hesabýn yok mu? <a href="/register">Kayýt Ol</a></p>
            </form>
        </div>
    );
};

export default Login;
