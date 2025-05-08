import { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "../api/axiosInstance";

const RegisterPage = () => {
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const handleRegister = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post("auth/register", {
                username,
                email,
                password,
            });

            const token = response.data;
            localStorage.setItem("token", token);

            alert("✅ Kayıt başarılı!");
            navigate("/");
        } catch (error) {
            console.error(error);
            alert("❌ Kayıt başarısız! Email veya kullanıcı adı kullanılıyor olabilir.");
        }
    };

    return (
        <div style={{ maxWidth: 400, margin: "auto", padding: 20 }}>
            <h2>Kayıt Ol</h2>
            <form onSubmit={handleRegister}>
                <input
                    type="text"
                    placeholder="Kullanıcı Adı"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    required
                    style={{ width: "100%", marginBottom: 10 }}
                />
                <input
                    type="email"
                    placeholder="E-posta"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                    style={{ width: "100%", marginBottom: 10 }}
                />
                <input
                    type="password"
                    placeholder="Şifre"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                    style={{ width: "100%", marginBottom: 10 }}
                />
                <button type="submit" style={{ width: "100%" }}>
                    Kayıt Ol
                </button>
            </form>
        </div>
    );
};

export default RegisterPage;
