import * as React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import Login from './pages/Login';
import Register from './pages/Register';
import CreateEntry from './pages/CreateEntry'; 
import EntryList from './pages/EntryList';
import EntryDetail from './pages/EntryDetail';
import TopicList from './pages/TopicList';
import TopicEntries from './pages/TopicEntries';


function App() {
    return (
        <BrowserRouter>
            <Layout>
                <Routes>
                    <Route
                        path="/"
                        element={<h2 style={{ textAlign: 'center', marginTop: '40px' }}>Ana Sayfa</h2>}
                    />
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="/entry/create" element={<CreateEntry />} /> {/* ✅ burası */}
                    <Route path="/entry/list" element={<EntryList />} />
                    <Route path="/entry/:id" element={<EntryDetail />} />
                    <Route path="/topics" element={<TopicList />} />
                    <Route path="/topics/:topicId" element={<TopicEntries />} />

                </Routes>
            </Layout>
        </BrowserRouter>
    );
}

export default App;
