import { useState } from "react";
import { register } from "../api";

const Register = () => {
    const [formData, setFormData] = useState({
        userName: "",
        email: "",
        password: "",
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await register(formData);
            alert("Kayıt başarılı! Token: " + response.token);
        } catch (error) {
            alert("Hata oluştu: " + error.response.data);
        }
    };

    return (
        <div>
            <h2>Kayıt Ol</h2>
            <form onSubmit={handleSubmit}>
                <input type="text" name="userName" placeholder="Kullanıcı Adı" onChange={handleChange} required />
                <input type="email" name="email" placeholder="E-posta" onChange={handleChange} required />
                <input type="password" name="password" placeholder="Şifre" onChange={handleChange} required />
                <button type="submit">Kayıt Ol</button>
            </form>
        </div>
    );
};

export default Register;
