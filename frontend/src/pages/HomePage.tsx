import React, { useEffect, useState } from 'react';
import { getAllTopics } from '../services/topicApi';
import { getEntriesByTopic } from '../services/entryApi';
import { useNavigate } from 'react-router-dom';
import './HomePage.css';

interface Topic {
    id: number;
    title: string;
}

interface Entry {
    id: number;
    title: string;
    content: string;
    username: string;
    createdAt: string;
}

const HomePage: React.FC = () => {
    const [topics, setTopics] = useState<Topic[]>([]);
    const [selectedTopicId, setSelectedTopicId] = useState<number | null>(null);
    const [entries, setEntries] = useState<Entry[]>([]);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchTopics = async () => {
            const res = await getAllTopics();
            setTopics(res);
            if (res.length > 0) setSelectedTopicId(res[0].id);
        };
        fetchTopics();
    }, []);

    useEffect(() => {
        if (selectedTopicId) {
            getEntriesByTopic(selectedTopicId).then(setEntries);
        }
    }, [selectedTopicId]);

    return (
        <div className="home-container">
            <aside className="topic-sidebar">
                <h3>📚 Başlıklar</h3>
                <ul>
                    {topics.map((t) => (
                        <li
                            key={t.id}
                            className={t.id === selectedTopicId ? 'active' : ''}
                            onClick={() => setSelectedTopicId(t.id)}
                        >
                            {t.title}
                        </li>
                    ))}
                </ul>
            </aside>

            <section className="entry-content">
                <h2>📝 Entry'ler</h2>
                {entries.length === 0 ? (
                    <p className="empty-entry">Bu başlıkta henüz entry yok.</p>
                ) : (
                    entries.map((e) => (
                        <div
                            key={e.id}
                            className="entry-card"
                            onClick={() => navigate(`/entry/${e.id}`)}
                        >
                            <h4 className="entry-title">{e.title}</h4>
                            <p className="entry-preview">{e.content.slice(0, 150)}...</p>
                            <span className="meta">
                                ✍️ <strong>{e.username}</strong> • {new Date(e.createdAt).toLocaleString()}
                            </span>
                        </div>
                    ))
                )}
            </section>
        </div>
    );
};

export default HomePage;
