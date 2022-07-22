const baseUrl = 'https://localhost:7001';

export const create = async (recipe, authToken, userId) => {
    let response = await fetch(`${baseUrl}/api/recipe/create`, {
        method: 'POST',
        headers: {
            'content-Type': 'application/json',
            'AuthToken': authToken,
        },
        body: JSON.stringify({...recipe, userId})
    });
    if (response.ok) {
        let result = await response.json();
        return result;
    } else{
        throw response.status;
    }
};

export const getRecipe = async (recipeId, authToken) => {
    let response = await fetch(`${baseUrl}/api/recipe?id=${recipeId}`,{
        method: 'GET',
        headers: {
            'AuthToken': authToken
        }
    });
    if (response.ok) {
        let result = await response.json();
        return result;
    } else{
        throw response.status;
    }
};