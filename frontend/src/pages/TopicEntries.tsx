import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getEntriesByTopic } from '../services/entryApi';
import './TopicEntries.css';

interface Entry {
    id: number;
    title: string;
    content: string;
    username: string;
    createdAt: string;
}

const TopicEntries: React.FC = () => {
    const { topicId } = useParams<{ topicId: string }>();
    const [entries, setEntries] = useState<Entry[]>([]);
    const navigate = useNavigate();

    useEffect(() => {
        if (topicId) {
            getEntriesByTopic(Number(topicId))
                .then(setEntries)
                .catch((err) => console.error('❌ Hata:', err));
        }
    }, [topicId]);

    return (
        <div className="topic-entries-container">
            <h2>🧵 Topic #{topicId} İçerikleri</h2>
            {entries.length === 0 ? (
                <p>Henüz içerik yok.</p>
            ) : (
                entries.map((entry) => (
                    <div key={entry.id} className="entry-card">
                        <h3>{entry.title}</h3>
                        <p>
                            {entry.content.length > 200
                                ? `${entry.content.slice(0, 200)}...`
                                : entry.content}
                        </p>
                        <div className="entry-meta">
                            {entry.username} • {new Date(entry.createdAt).toLocaleString()}
                        </div>
                        <button
                            className="entry-detail-btn"
                            onClick={() => navigate(`/entry/${entry.id}`)}
                        >
                            Detaya Git →
                        </button>
                    </div>
                ))
            )}
        </div>
    );
};

export default TopicEntries;
