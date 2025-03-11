import {BrowserRouter as Router, Routes, Route, useNavigate} from "react-router-dom";
import Register from "./pages/Register";
import Login from "./pages/Login";
import {useEffect} from "react";
import Home from "./Pages/Home.jsx";

const RedirectToLogin = () => {
    const navigate = useNavigate();
    useEffect(() => {
        navigate("/login");
    }, [navigate]);
    return null;
};

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<RedirectToLogin />} />
                <Route path="/register" element={<Register />} />
                <Route path="/login" element={<Login />} />
                <Route path="/home" element={<Home />} />
            </Routes>
        </Router>
    );
};

export default App;
