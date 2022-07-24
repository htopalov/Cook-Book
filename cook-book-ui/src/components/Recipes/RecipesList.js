import RecipeCard from "./RecipeCard";
import * as recipeService from '../../services/recipeService';
import { useAuthContext } from '../../contexts/AuthContext';
import { useState, useEffect } from 'react';
import { useLocation } from "react-router-dom";

const RecipesList = () => {
    const location = useLocation();
    const path = location.pathname;
    const[recipeList, setRecipeList] = useState([]);
    const { user } = useAuthContext();

    useEffect(() => {
        if (path === '/all') {
            recipeService.getAll(user.authToken)
            .then(res => {
                setRecipeList(res);       
            });
        } else {
            recipeService.getMyRecipes(user.id, user.authToken)
            .then(res => {
                setRecipeList(res);
            })
        }
    }, [path]);

    return (
        <div className="container-xxl py-5">
        <div className="container">
            <div className="text-center wow fadeInUp" data-wow-delay="0.1s">
                <h1 className="section-title ff-secondary text-center text-primary fw-normal mt-5 mb-5">Recipes</h1>
            </div>
            <div className="tab-className text-center wow fadeInUp" data-wow-delay="0.1s">
                <div className="tab-content">
                    <div id="tab-1" className="tab-pane fade show p-0 active">
                        <div className="row g-4">
                            {recipeList.map(x => <RecipeCard key={x.id} recipe={x} />)}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    );
}

export default RecipesList;