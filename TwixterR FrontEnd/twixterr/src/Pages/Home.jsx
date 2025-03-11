import { useContext, useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import AuthContext from "../context/AuthContext";
import { jwtDecode } from "jwt-decode";
import { LogOut } from "lucide-react";

const Home = () => {
    const { token, logoutUser } = useContext(AuthContext);
    const navigate = useNavigate();
    const [currentTime, setCurrentTime] = useState(new Date());
    const [userData, setUserData] = useState(null);


    useEffect(() => {
        if (!token) {
            navigate("/login");
        } else {
            try {
                const decodedToken = jwtDecode(token);
                setUserData({
                    userName: decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] || "Bilinmiyor",
                    userId: decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"] || "Bilinmiyor",
                    email: decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"] || "Bilinmiyor",
                    exp: decodedToken.exp ? new Date(decodedToken.exp * 1000).toLocaleString() : "Bilinmiyor",
                });

                if (decodedToken.exp * 1000 < Date.now()) {
                    logoutUser();
                    navigate("/login");
                }
            } catch (error) {
                console.error("Token çözülemedi:", error);
                setUserData(null);
                navigate("/login");
            }
        }
    }, [token, navigate, logoutUser]);

    useEffect(() => {
        const interval = setInterval(() => {
            setCurrentTime(new Date());
        }, 1000);
        return () => clearInterval(interval);
    }, []);

    return (
        <div className="min-h-screen bg-black flex flex-col items-center justify-center p-4 text-white">

            <div className="absolute top-4 right-4 bg-gray-800 p-3 rounded-md text-lg font-mono">
                {currentTime.toLocaleTimeString()}
            </div>

            <h1 className="text-4xl font-bold mb-6">
                Hoşgeldin, {userData?.userName || "Kullanıcı"}!
            </h1>

            <div className="bg-gray-900 p-6 rounded-lg shadow-md w-full max-w-lg text-center">
                <p className="text-gray-400">
                    Kullanıcı Adı:{" "}
                    <span className="text-white font-semibold">
                        {userData?.userName}
                    </span>
                </p>
                <p className="text-gray-400">
                    E-posta:{" "}
                    <span className="text-white font-semibold">
                        {userData?.email}
                    </span>
                </p>
                <p className="text-gray-400">
                    Token Bitiş Süresi:{" "}
                    <span className="text-white font-semibold">
                        {userData?.exp}
                    </span>
                </p>
                <p className="text-gray-400">
                    Kullanıcı Id:{" "}
                    <span className="text-white font-semibold">
                        {userData?.userId}
                    </span>
                </p>
            </div>

            <button
                onClick={logoutUser}
                className="mt-6 flex items-center gap-2 bg-red-600 hover:bg-red-700 text-white font-semibold py-3 px-6 rounded-lg transition-all"
            >
                <LogOut className="w-5 h-5"/>
                Çıkış Yap
            </button>
        </div>
    );
};

export default Home;
