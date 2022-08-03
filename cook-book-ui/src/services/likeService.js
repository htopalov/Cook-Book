const baseUrl = 'https://localhost:7001';

export const addLike = async (like, authToken) => {
    let response = await fetch(`${baseUrl}/api/like/add`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'AuthToken': authToken,
        },
        body: JSON.stringify(like)
    });
    if (response.status !== 204) {
        throw response.status;
    }
};

export const checkLikes = async (request, authToken) => {
    let response = await fetch(`${baseUrl}/api/like/hasliked`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'AuthToken': authToken,
        },
        body: JSON.stringify(request)
    });
    if (response.status !== 200) {
        return true;
    } else {
        return false;
    }
};