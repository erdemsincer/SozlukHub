import * as React from 'react';

import './Layout.css';

interface LayoutProps {
    children: React.ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => {
    return (
        <div className="app-layout">
            <header className="app-header">
                <h1>SozlukHub</h1>
                <nav>
                    <a href="/">Anasayfa</a>
                    <a href="/login">Giris</a>
                    <a href="/register">Kayit Ol</a>
                </nav>
            </header>
            <main className="app-content">
                {children}
            </main>
        </div>
    );
};

export default Layout;
