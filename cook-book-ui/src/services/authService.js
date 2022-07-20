const baseUrl = 'https://localhost:7001';

export const login = async(email,password) => {
    let response = await fetch(`${baseUrl}/api/account/login`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({email, password})
    });

    let result = await response.json();

    if (!response.ok) {
        throw result.message;
    } else {
        return result;
    }
};

export const register = async(email, password) => {
    let response = await fetch(`${baseUrl}/api/account/register`,{
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({email, password})
    });

    if (!response.ok) {
        throw 'Email already taken';
    }
};

export const logout = (token) => {
    return fetch(`${baseUrl}/api/account/logout`, {
        headers: {
            'AuthToken': token,
        }
    })
};

export const getUser = () => {
    let email = localStorage.getItem('email');
    let id = localStorage.getItem('id');
    return {email,id};
};

export const isAuthenticated = () => {
    return Boolean(getUser());
};