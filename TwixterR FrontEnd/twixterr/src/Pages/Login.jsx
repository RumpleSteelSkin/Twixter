import { useState, useContext } from "react";
import { login } from "../api";
import AuthContext from "../Context/AuthContext.jsx";

const Login = () => {
    const [formData, setFormData] = useState({ email: "", password: "" });
    const { loginUser } = useContext(AuthContext);

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await login(formData);
            loginUser(response.token);
            alert("Giriş başarılı!");
        } catch (error) {
            alert("Hata oluştu: " + error.response.data);
        }
    };

    return (
        <div>
            <h2>Giriş Yap</h2>
            <form onSubmit={handleSubmit}>
                <input type="email" name="email" placeholder="E-posta" onChange={handleChange} required />
                <input type="password" name="password" placeholder="Şifre" onChange={handleChange} required />
                <button type="submit">Giriş Yap</button>
            </form>
        </div>
    );
};

export default Login;
