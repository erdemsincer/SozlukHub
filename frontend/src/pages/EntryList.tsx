import React, { useEffect, useState } from 'react';
import entryApi from '../services/entryApi';
import './EntryList.css';

interface Entry {
    id: number;
    title: string;
    content: string;
    topicId: number;
    topicName?: string;
    username?: string;
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
            <h2>📝 Entry Listesi</h2>
            {entries.length === 0 ? (
                <p className="empty">Henüz entry yok.</p>
            ) : (
                entries.map((entry) => (
                    <div key={entry.id} className="entry-card">
                        <div className="entry-header">
                            <div className="avatar">{entry.username?.charAt(0).toUpperCase() || '?'}</div>
                            <div>
                                <h3>{entry.title}</h3>
                                <span className="meta">
                                    <strong>Konu:</strong> {entry.topicName || `#${entry.topicId}`} &nbsp;|&nbsp;
                                    <strong>Yazan:</strong> {entry.username || 'Bilinmiyor'}
                                </span>
                            </div>
                        </div>
                        <p className="entry-content">{entry.content}</p>
                    </div>
                ))
            )}
        </div>
    );
};

export default EntryList;
