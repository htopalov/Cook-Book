import RecipeCard from '../Recipes/RecipeCard';
import * as recipeService from '../../services/recipeService';
import { useAuthContext } from '../../contexts/AuthContext';
import { useState, useEffect } from 'react';

const Favorite = () => {
    const initialPage = 1;
    const recipesPerPage = 10;
    const[recipeList, setRecipeList] = useState([]);
    const[currentPage, setCurrentPage] = useState(initialPage);
    const[maxPage, setMaxPage] = useState(initialPage);
    const { user } = useAuthContext();
    const userId = user.id;


    useEffect(() => {
            recipeService.getFavouriteRecipes({currentPage, userId}, user.authToken)
            .then(res => {
                setRecipeList(res.recipes);
                setMaxPage(Math.ceil(res.totalRecipes / recipesPerPage));
            });
    }, [currentPage]);

    let nextBtn = (
        <button 
        className="btn btn-primary" 
        onClick={() => setCurrentPage(currentPage + 1)}>
        {`>>`}</button>
    );

    let previousBtn = (
        <button 
        className="btn btn-primary" 
        onClick={() => setCurrentPage(currentPage - 1)}>
        {`<<`}</button>
    );

    
    return (
        <div className="container-xxl py-5">
        <div className="container">
            <div className="text-center wow fadeInUp" data-wow-delay="0.1s">
                <h1 className="section-title ff-secondary text-center text-primary fw-normal mt-5 mb-5">Favorite Recipes</h1>
            </div>
            <div className="tab-className text-center wow fadeInUp" data-wow-delay="0.1s">
                <div className="tab-content">
                    <div id="tab-1" className="tab-pane fade show p-0 active">
                        <div className="row g-4">
                            {
                                recipeList.length > 0
                                ? recipeList.map(x => <RecipeCard key={x.id} recipe={x} />)
                                : <p className="current-page">No recipes</p>
                            }
                        </div>
                        <div className="d-flex justify-content-center mt-5">
                            { currentPage > 1 ? previousBtn : '' }
                                <span className="current-page">[{currentPage}]</span>
                            { currentPage < maxPage ? nextBtn : '' }
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    );
}

export default Favorite;