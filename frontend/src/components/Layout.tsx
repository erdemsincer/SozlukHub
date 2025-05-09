import * as React from 'react';
import './Layout.css';

interface LayoutProps {
    children: React.ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => {
    const [isLoggedIn, setIsLoggedIn] = React.useState(false);
    const [username, setUsername] = React.useState<string | null>(null);

    React.useEffect(() => {
        const token = localStorage.getItem('token');
        const name = localStorage.getItem('username'); // token decode yerine localde tutmuþ olabilirsin

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
                            <span className="welcome-text">Merhaba, {username || 'Kullanýcý'}</span>
                            <button onClick={handleLogout} className="logout-btn">Çýkýþ Yap</button>
                        </>
                    ) : (
                        <>
                            <a href="/login">Giriþ</a>
                            <a href="/register">Kayýt Ol</a>
                        </>
                    )}
                </nav>
            </header>
            <main className="app-content">
                {children}
            </main>
            <footer className="app-footer">
                © {new Date().getFullYear()} SozlukHub. Tüm haklarý saklýdýr.
            </footer>
        </div>
    );
};

export default Layout;
