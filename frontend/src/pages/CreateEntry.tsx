import React, { useEffect, useState } from 'react';
import entryApi from '../services/entryApi';
import topicApi from '../services/topicApi';
import './CreateEntry.css';

interface Topic {
    id: number;
    title: string;
}

const CreateEntry: React.FC = () => {
    const [title, setTitle] = useState('');
    const [content, setContent] = useState('');
    const [topicId, setTopicId] = useState<number>(0);
    const [topics, setTopics] = useState<Topic[]>([]);

    useEffect(() => {
        const fetchTopics = async () => {
            try {
                const response = await topicApi.get('/');
                setTopics(response.data);
                if (response.data.length > 0) {
                    setTopicId(response.data[0].id);
                }
            } catch (err) {
                console.error('Topicler alınamadı', err);
            }
        };

        fetchTopics();
    }, []);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            await entryApi.post('/entry', {
                title,
                content,
                topicId,
            });

            alert('✅ Entry oluşturuldu');
            setTitle('');
            setContent('');
        } catch (err: any) {
            alert('❌ Hata: ' + (err.response?.data || 'Sunucu hatası'));
        }
    };

    return (
        <div className="login-wrapper">
            <form className="login-form" onSubmit={handleSubmit}>
                <h2>Entry Oluştur</h2>

                <input
                    type="text"
                    placeholder="Başlık"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    required
                />

                <textarea
                    placeholder="İçerikk"
                    value={content}
                    onChange={(e) => setContent(e.target.value)}
                    required
                />

                <select
                    value={topicId}
                    onChange={(e) => setTopicId(Number(e.target.value))}
                >
                    {topics.map((topic) => (
                        <option key={topic.id} value={topic.id}>
                            {topic.title}
                        </option>
                    ))}
                </select>

                <button type="submit">Kaydet</button>
            </form>
        </div>
    );
};

export default CreateEntry;
