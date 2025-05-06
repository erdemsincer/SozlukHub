import { useState } from "react";
import axios from "../api/axiosInstance";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post("auth/login", {
                email,
                password,
            });

            const token = response.data; // API sadece token döndürüyor
            localStorage.setItem("token", token);

            alert("✅ Giriş başarılı!");
            navigate("/");
        } catch (error) {
            console.error(error);
            alert("❌ Giriş başarısız! Email veya şifre yanlış olabilir.");
        }
    };

    return (
        <div style={{ maxWidth: 400, margin: "auto", padding: 20 }}>
            <h2>Giriş Yap</h2>
            <form onSubmit={handleLogin}>
                <div>
                    <input
                        type="email"
                        placeholder="E-posta"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                        style={{ width: "100%", marginBottom: 10 }}
                    />
                </div>
                <div>
                    <input
                        type="password"
                        placeholder="Şifre"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                        style={{ width: "100%", marginBottom: 10 }}
                    />
                </div>
                <button type="submit" style={{ width: "100%" }}>
                    Giriş Yap
                </button>
            </form>
        </div>
    );
};

export default LoginPage;
