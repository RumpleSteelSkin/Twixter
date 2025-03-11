﻿import axios from "axios";

const API_URL = "http://localhost:5183/api/Authorization";

export const register = async (userData) => {
    const response = await axios.post(`${API_URL}/Register`, userData);
    return response.data;
};

export const login = async (userData) => {
    const response = await axios.post(`${API_URL}/Login`, userData);
    return response.data;
};
