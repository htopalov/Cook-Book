const baseUrl = 'https://localhost:7001';

export const create = async (recipe, authToken) => {
    let response = await fetch(`${baseUrl}/api/recipe/create`, {
        method: 'POST',
        headers: {
            'AuthToken': authToken,
        },
        body: recipe
    });
    if (response.ok) {
        let result = await response.json();
        return result;
    } else{
        throw response.status;
    }
};

export const getRecipe = async (recipeId, authToken) => {
    let response = await fetch(`${baseUrl}/api/recipe/details?id=${recipeId}`,{
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

export const deleteRecipe = async(recipeId, authToken) => {
    let response = await fetch(`${baseUrl}/api/recipe/delete?id=${recipeId}`, {
        method: 'DELETE',
        headers: {
            'AuthToken': authToken
        }
    });

    if (response.status !== 204) {
        let result = await response.json();
        throw result; 
    }
};

export const updateRecipe = async(recipeId, recipe, authToken) => {
    let response = await fetch(`${baseUrl}/api/recipe/edit?id=${recipeId}`,{
        method: 'PUT',
        headers: {
            'AuthToken': authToken
        },
        body: recipe
    });

    if (response.status !== 200) {
        let result = await response.json();
        throw result; 
    }
};

export const getAll = async(recipesRequest,authToken) => {
    let response = await fetch(`${baseUrl}/api/recipe/all`,{
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'AuthToken': authToken
        },
        body: JSON.stringify(recipesRequest)
    });

    if (response.ok) {
        let result = await response.json();
        return result;
    } else {
        throw response.status;
    }
};

export const getMyRecipes = async(recipesRequest, authToken) =>{
    let response = await fetch(`${baseUrl}/api/recipe/all`,{
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'AuthToken': authToken
        },
        body: JSON.stringify(recipesRequest)
    });

    if (response.ok) {
        let result = await response.json();
        return result;
    } else {
        throw response.status;
    }
}