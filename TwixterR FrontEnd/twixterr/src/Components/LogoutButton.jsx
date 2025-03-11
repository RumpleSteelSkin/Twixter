import { useContext } from "react";
import AuthContext from "../Context/AuthContext.jsx";

const LogoutButton = () => {
    const { logoutUser } = useContext(AuthContext);

    return <button onClick={logoutUser}>Çıkış Yap</button>;
};

export default LogoutButton;
