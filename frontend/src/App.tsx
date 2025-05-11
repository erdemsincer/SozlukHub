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
import HomePage from './pages/HomePage';

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route index element={<HomePage />} /> {/* ✅ index → "/" demek */}
                    <Route path="login" element={<Login />} />
                    <Route path="register" element={<Register />} />
                    <Route path="entry/create" element={<CreateEntry />} />
                    <Route path="entry/list" element={<EntryList />} />
                    <Route path="entry/:id" element={<EntryDetail />} />
                    <Route path="topics" element={<TopicList />} />
                    <Route path="topics/:topicId" element={<TopicEntries />} />
                </Route>
            </Routes>
        </BrowserRouter>

    );
}

export default App;
