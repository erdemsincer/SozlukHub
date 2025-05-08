import React, { useState } from 'react';
import './Login.css';

const Login: React.FC = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        alert(`Email: ${email}\nPassword: ${password}`);
        // TODO: Buraya API iste�i gelecek
    };

    return (
        <div className="login-wrapper">
            <form className="login-form" onSubmit={handleSubmit}>
                <h2>Giri� Yap</h2>
                <input
                    type="email"
                    placeholder="E-posta"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />
                <input
                    type="password"
                    placeholder="�ifre"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
                <button type="submit">Giri�</button>
                <p className="register-link">Hesab�n yok mu? <a href="/register">Kay�t Ol</a></p>
            </form>
        </div>
    );
};

export default Login;
