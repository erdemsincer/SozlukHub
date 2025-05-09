import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import entryApi from '../services/entryApi';
import './EntryList.css';

interface Entry {
    id: number;
    title: string;
    content: string;
    topicName: string;
    username: string;
    createdAt: string;
}

const EntryList: React.FC = () => {
    const [entries, setEntries] = useState<Entry[]>([]);

    useEffect(() => {
        const fetchEntries = async () => {
            try {
                const response = await entryApi.get('/entry');
                setEntries(response.data);
            } catch (err) {
                console.error('❌ Entry verileri alınamadı:', err);
            }
        };

        fetchEntries();
    }, []);

    return (
        <div className="entry-list">
            <h2 className="entry-title">📝 Topluluk Entry Listesi</h2>
            {entries.length === 0 ? (
                <p className="empty">Henüz entry bulunamadı.</p>
            ) : (
                entries.map((entry) => (
                    <div className="entry-card" key={entry.id}>
                        <div className="entry-header">
                            <div className="entry-avatar">
                                {entry.username?.charAt(0).toUpperCase() || '?'}
                            </div>
                            <div className="entry-header-content">
                                <h3 className="entry-heading">
                                    <Link to={`/entry/${entry.id}`}>{entry.title}</Link>
                                </h3>
                                <div className="entry-meta">
                                    <strong>{entry.username}</strong> &bull;{' '}
                                    {new Date(entry.createdAt).toLocaleString()} &bull;{' '}
                                    <em>{entry.topicName}</em>
                                </div>
                            </div>
                        </div>
                        <p className="entry-content">
                            {entry.content.length > 200
                                ? entry.content.slice(0, 200) + '...'
                                : entry.content}
                        </p>
                    </div>
                ))
            )}
        </div>
    );
};

export default EntryList;
