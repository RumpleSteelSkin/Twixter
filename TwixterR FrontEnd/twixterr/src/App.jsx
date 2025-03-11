import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Register from "./pages/Register";
import Login from "./pages/Login";
import LogoutButton from "./Components/LogoutButton.jsx";

const App = () => {
    return (
        <Router>
            <nav>
                <Link to="/register">Kayıt Ol</Link>
                <Link to="/login">Giriş Yap</Link>
            </nav>
            <Routes>
                <Route path="/register" element={<Register />} />
                <Route path="/login" element={<Login />} />
            </Routes>
            <LogoutButton/>
        </Router>
    );
};

export default App;
