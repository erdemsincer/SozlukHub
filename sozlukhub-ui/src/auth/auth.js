import jwt_decode from "jwt-decode";

export const saveToken = (token) => {
    localStorage.setItem("token", token);
};

export const getToken = () => {
    return localStorage.getItem("token");
};

export const removeToken = () => {
    localStorage.removeItem("token");
};

export const getUserFromToken = () => {
    const token = getToken();
    if (!token) return null;

    try {
        return jwt_decode(token);
    } catch (err) {
        return null;
    }
};
