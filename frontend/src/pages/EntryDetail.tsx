import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import entryApi from '../services/entryApi';
import userApi from '../services/userApi';
import reviewApi from '../services/reviewApi';
import voteApi from '../services/voteApi';
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
    const [newComment, setNewComment] = useState('');
    const token = localStorage.getItem('token');

    const fetchEntryData = async () => {
        if (!id) return;
        try {
            const entryRes = await entryApi.get(`/Entry/${id}`);
            setEntry(entryRes.data);

            if (entryRes.data.userId) {
                const userRes = await userApi.get(`/${entryRes.data.userId}`);
                setUser(userRes.data);
            }

            const commentRes = await reviewApi.get(`/review/entry/${id}`);
            setComments(commentRes.data);
        } catch (err: any) {
            console.error('❌ Entry detay alınamadı:', err.response?.data || err.message || err);
        }
    };

    useEffect(() => {
        fetchEntryData();
    }, [id]);

    const handleCommentSubmit = async () => {
        if (!newComment.trim()) return alert('Yorum boş olamaz');
        if (!token) return alert('Giriş yapmadan yorum yapamazsın.');

        try {
            await reviewApi.post(
                '/review',
                { content: newComment, entryId: Number(id) },
                { headers: { Authorization: `Bearer ${token}` } }
            );
            setNewComment('');
            fetchEntryData(); // yorum sonrası yeniden yükle
        } catch (err: any) {
            alert('❌ Yorum gönderilemedi: ' + (err.response?.data || err.message));
        }
    };

    const handleVote = async (isUpvote: boolean) => {
        if (!token) return alert("Giriş yapmadan oy kullanamazsın.");
        try {
            await voteApi.post('', {
                entryId: Number(id),
                isUpvote
            });
            fetchEntryData(); // oy sonrası entry güncelle
        } catch (err: any) {
            if (err.response?.status === 400) {
                alert("Zaten oy verdin.");
            } else {
                alert("❌ Oy işlemi başarısız: " + (err.response?.data || err.message));
            }
        }
    };

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
                <div style={{ marginTop: '12px', display: 'flex', gap: '12px' }}>
                    <button
                        onClick={() => handleVote(true)}
                        style={{ backgroundColor: '#38A169', color: 'white', padding: '8px 14px', borderRadius: '8px', border: 'none' }}
                    >
                        👍 Beğen ({entry.likeCount ?? 0})
                    </button>
                    <button
                        onClick={() => handleVote(false)}
                        style={{ backgroundColor: '#E53E3E', color: 'white', padding: '8px 14px', borderRadius: '8px', border: 'none' }}
                    >
                        👎 Beğenme ({entry.dislikeCount ?? 0})
                    </button>
                </div>
            </div>

            <h3 style={{ marginTop: '32px' }}>💬 {comments.length} Yorum</h3>

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

            {token ? (
                <div className="comment-form">
                    <h4>✍🏻 Yorum Yap</h4>
                    <textarea
                        value={newComment}
                        onChange={(e) => setNewComment(e.target.value)}
                        rows={4}
                        placeholder="Yorumunuzu yazın..."
                    />
                    <button onClick={handleCommentSubmit}>Gönder</button>
                </div>
            ) : (
                <p className="login-info">
                    Yorum yapmak için <a href="/login">giriş yap</a> lütfen.
                </p>
            )}
        </div>
    );
};

export default EntryDetail;
