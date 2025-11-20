export const API_URL = "http://localhost:5282/api/";

export const sendVerificationEmail = async (email) => {
    const response = await fetch(`${API_URL}/send-verification-email`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            Email: email,
        })
    });

    if (!response.ok) {
        throw new Error("Не удалось получить данные пользователя");
    }

    const data = await response.json();
    return data;
};

export const createUser = async (email, password, name, lastName, claims) => {
    const response = await fetch(`${API_URL}/create-user`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            Email: email,
            Password: password,
            Name: name,
            LastName: lastName,
            Claims: claims
        })
    });

    if (!response.ok) {
        throw new Error("Не удалось создать пользователя");
    }

    const data = await response.json();
    return data;
};

export const login = async (email, password) => {
    const response = await fetch(`${API_URL}/login`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            Email: email,
            Password: password
        })
    });

    if (!response.ok) {
        throw new Error("Не удалось войти в систему");
    }

    const data = await response.json();
    return data;
};