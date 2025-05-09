import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import entryApi from '../services/entryApi';
import userApi from '../services/userApi';
import reviewApi from '../services/reviewApi';
import './EntryDetail.css';

interface Entry {
    id: number;
    title: string;
    content: string;
    topicName?: string;
    username?: string;
    createdAt?: string;
    likeCount?: number;
    dislikeCount?: number;
    userId?: number;
}

interface UserProfile {
    id: number;
    username: string;
    avatarUrl?: string;
    bio?: string;
    createdAt?: string;
}

interface Comment {
    id: number;
    content: string;
    username: string;
    createdAt: string;
}

const EntryDetail: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [entry, setEntry] = useState<Entry | null>(null);
    const [user, setUser] = useState<UserProfile | null>(null);
    const [comments, setComments] = useState<Comment[]>([]);

    useEffect(() => {
        const fetchEntry = async () => {
            try {
                const response = await entryApi.get(`/Entry/${id}`);
                setEntry(response.data);

                if (response.data.userId) {
                    const userRes = await userApi.get(`/${response.data.userId}`);
                    setUser(userRes.data);
                }

                const commentRes = await reviewApi.get(`/review/entry/${id}`);
                setComments(commentRes.data);
            } catch (err: any) {
                console.error('❌ Entry detay alınamadı:', err.response?.data || err.message || err);
            }
        };

        fetchEntry();
    }, [id]);

    if (!entry) return <p>Yükleniyor...</p>;

    return (
        <div className="entry-detail">
            {user && (
                <div className="entry-user-info">
                    <img
                        src={user.avatarUrl || `https://ui-avatars.com/api/?name=${encodeURIComponent(user.username)}`}
                        alt={user.username}
                        className="avatar"
                    />
                    <div>
                        <h4>{user.username}</h4>
                        <p>{user.bio || 'Tanımsız kullanıcı'}</p>
                    </div>
                </div>
            )}

            <h2>{entry.title}</h2>
            <p>{entry.content}</p>

            <div className="meta">
                <p><strong>Konu:</strong> {entry.topicName || 'Bilinmiyor'}</p>
                <p><strong>Yazar:</strong> {entry.username || 'Anonim'} (ID: {entry.userId ?? 'N/A'})</p>
                <p><strong>Oluşturulma:</strong> {entry.createdAt ? new Date(entry.createdAt).toLocaleString() : 'Bilinmiyor'}</p>
                <p>
                    <strong>Beğeni:</strong> {entry.likeCount ?? 0} &nbsp;
                    <strong>Beğenmeme:</strong> {entry.dislikeCount ?? 0}
                </p>
            </div>

            <h3 style={{ marginTop: '32px' }}>
                💬 {comments.length} Yorum
            </h3>

            {comments.length === 0 ? (
                <p>Henüz yorum yapılmamış.</p>
            ) : (
                comments.map((c) => (
                    <div key={c.id} className="comment-card">
                        <div className="comment-meta">
                            <strong>{c.username}</strong> • {new Date(c.createdAt).toLocaleString()}
                        </div>
                        <p>{c.content}</p>
                    </div>
                ))
            )}
        </div>
    );
};

export default EntryDetail;
