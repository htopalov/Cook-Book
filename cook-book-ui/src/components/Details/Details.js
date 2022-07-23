import {  useParams, Link, useNavigate } from 'react-router-dom';
import * as recipeService from '../../services/recipeService';
import { useAuthContext } from '../../contexts/AuthContext';
import { useState, useEffect } from 'react';


const Details = () => {
    const[recipe, setRecipe] = useState({});
    const[ingredientsList, setIngredientsList] = useState([]);
    const [isOwner, setIsOwner] = useState(false);
    const { user } = useAuthContext();
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        recipeService.getRecipe(id, user.authToken)
            .then(r => {
                setRecipe(r);
                setIngredientsList(r.ingredientsList);
                if (recipe.userId === user.Id) {
                    setIsOwner(true);
                } 
            })
    }, []);

    const deleteRecipeHandler = () => {
        console.log(id);
        recipeService.deleteRecipe(id, user.authToken)
        .then(() => {
            navigate('/all');
        })
        .catch(err => console.log(err)) // use notification
        .finally(() => {
            console.log('deleted'); // use notification
        });
        
    };

    let ownerBtns = (
        <>
        <Link to={`/edit/${id}`} id="btn-edit" className="btn btn-primary">Edit</Link>
        <button onClick={deleteRecipeHandler} id="btn-delete" className="btn btn-primary">Delete</button>
        </>
    );

    let userBtn = (
        <button id="btn-like" className="btn btn-primary">Like</button>
    );

    return (
<div className="container">
    <div className="row">
        <div className="col-md-5 p-5 wow fadeInUp" data-wow-delay="0.2s">           
            <div className="project-info-box mt-5">
                <h1 className="ff-secondary text-primary fw-normal mt-5 mb-3">{recipe.name}</h1>
                <p className="mb-0 desc-container">{recipe.steps}</p>
            </div>
            <div className="project-info-box">
                    <div id="recipe-options">
                        { isOwner 
                            ? ownerBtns
                            : userBtn
                        }         
                     </div>
            </div>
            <div className="project-info-box">
                <p><b>Likes:</b> {recipe.likes} likes</p>
                <p><b>Cooking Time:</b> {recipe.cookingTime} min</p>
                <p><b>Portions:</b> {recipe.portions}</p>
                <p><b>Ingredients:</b></p>
                <ul id="ingredients-list">
                    {ingredientsList.map(x => {return <li className='text-primary' key={x}>{x}</li>})} 
                </ul>
            </div>
        </div>
        <div className="col-md-7 mt-5 p-5 wow fadeInUp" data-wow-delay="0.2s">
            <img src={recipe.image} alt="" className="rounded"/>
        </div>
    </div>
</div>
    );
}

export default Details;