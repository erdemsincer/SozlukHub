import * as React from 'react';
import './Layout.css';
import { Outlet } from 'react-router-dom';

const Layout: React.FC = () => {
    const [isLoggedIn, setIsLoggedIn] = React.useState(false);
    const [username, setUsername] = React.useState<string | null>(null);

    React.useEffect(() => {
        const token = localStorage.getItem('token');
        const name = localStorage.getItem('username');

        if (token) {
            setIsLoggedIn(true);
            if (name) setUsername(name);
        }
    }, []);

    const handleLogout = () => {
        localStorage.removeItem('token');
        localStorage.removeItem('username');
        window.location.href = '/login';
    };

    return (
        <div className="app-layout">
            <header className="app-header">
                <h1 className="logo">SozlukHub</h1>
                <nav className="nav-links">
                    <a href="/">Anasayfa</a>
                    {isLoggedIn ? (
                        <>
                            <span className="welcome-text">Merhaba, {username || 'Kullanıcı'}</span>
                            <button onClick={handleLogout} className="logout-btn">Çıkış Yap</button>
                        </>
                    ) : (
                        <>
                            <a href="/login">Giriş</a>
                            <a href="/register">Kayıt Ol</a>
                        </>
                    )}
                </nav>
            </header>
            <main className="app-content">
                <Outlet /> {/* 🔥 Sayfalar buraya render edilecek */}
            </main>
            <footer className="app-footer">
                © {new Date().getFullYear()} SozlukHub. Tüm hakları saklıdır.
            </footer>
        </div>
    );
};

export default Layout;
