import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { getAllTopics } from '../services/topicApi';
import './TopicList.css';

interface Topic {
    id: number;
    title: string;
}

const TopicList: React.FC = () => {
    const [topics, setTopics] = useState<Topic[]>([]);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchTopics = async () => {
            try {
                const data = await getAllTopics();
                setTopics(data);
            } catch (err) {
                console.error('❌ Topicler alınamadı:', err);
            }
        };
        fetchTopics();
    }, []);

    return (
        <div className="topic-list-container">
            <h2>📁 Tüm Konular</h2>
            <ul className="topic-grid">
                {topics.map((topic) => (
                    <li
                        key={topic.id}
                        className="topic-card"
                        onClick={() => navigate(`/topics/${topic.id}`)}
                    >
                        {topic.title}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default TopicList;
