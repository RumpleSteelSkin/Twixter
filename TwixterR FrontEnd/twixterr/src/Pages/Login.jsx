import { useState, useContext } from "react";
import { login } from "../api";
import { Twitter } from 'lucide-react';
import AuthContext from "../Context/AuthContext.jsx";
import {Link, Navigate} from "react-router-dom";

const Login = () => {
    const [formData, setFormData] = useState({ email: "", password: "" });
    const [errorMessage, setErrorMessage] = useState("");  // Hata mesajı
    const [successMessage, setSuccessMessage] = useState("");  // Başarı mesajı
    const { loginUser } = useContext(AuthContext);

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };


    const [redirect, setRedirect] = useState(false);
    const handleSubmit = async (e) => {
        e.preventDefault();
        setErrorMessage("");
        setSuccessMessage("");

        try {
            const response = await login(formData);
            loginUser(response.token);
            setSuccessMessage("Giriş başarılı! Yönlendiriliyorsunuz...");

            setTimeout(() => {
                setRedirect(true); // 2 saniye sonra yönlendir
            }, 2000);
        } catch (error) {
            const message = error.response?.data?.detail || "Bilinmeyen bir hata oluştu!";
            setErrorMessage(message);
        }
    };

    if (redirect) {
        return <Navigate to="/home" replace />;
    }

    return (
        <div className="min-h-screen bg-black flex items-center justify-center p-4">
            <div className="w-full max-w-md space-y-8">
                <div className="text-center">
                    <Twitter className="h-12 w-12 text-[#1DA1F2] mx-auto"/>
                    <h2 className="mt-6 text-3xl font-bold text-white">
                        Twixter'a giriş yap
                    </h2>
                </div>

                {successMessage && (
                    <div className="text-green-500 bg-green-100 p-3 rounded-md text-center">
                        {successMessage}
                    </div>
                )}

                {errorMessage && (
                    <div className="text-red-500 bg-red-100 p-3 rounded-md text-center">
                        {errorMessage}
                    </div>
                )}

                <form className="mt-8 space-y-6" onSubmit={handleSubmit}>
                    <div className="space-y-4">
                        <div>
                            <input
                                type="email"
                                name="email"
                                required
                                className="w-full px-4 py-3 border border-gray-700 rounded-lg bg-black text-white placeholder-gray-500 focus:outline-none focus:border-[#1DA1F2] focus:ring-1 focus:ring-[#1DA1F2] transition-colors"
                                placeholder="E-posta"
                                onChange={handleChange}
                            />
                        </div>
                        <div>
                            <input
                                type="password"
                                name="password"
                                required
                                className="w-full px-4 py-3 border border-gray-700 rounded-lg bg-black text-white placeholder-gray-500 focus:outline-none focus:border-[#1DA1F2] focus:ring-1 focus:ring-[#1DA1F2] transition-colors"
                                placeholder="Şifre"
                                onChange={handleChange}
                            />
                        </div>
                    </div>

                    <div>
                        <button
                            type="submit"
                            className="w-full py-3 px-4 bg-[#1DA1F2] hover:bg-[#1a8cd8] text-white font-semibold rounded-lg transition-colors focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-[#1DA1F2]"
                        >
                            Giriş Yap
                        </button>
                    </div>

                    <div className="text-center space-y-4">
                        <a href="#" className="text-[#1DA1F2] hover:underline text-sm">
                            Şifreni mi unuttun? (WIP)
                        </a>
                        <div className="text-gray-500">
                            Henüz bir hesabın yok mu?{' '}
                            <Link to="/register" className="text-[#1DA1F2] hover:underline">
                                Kaydol
                            </Link>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default Login;
