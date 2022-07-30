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