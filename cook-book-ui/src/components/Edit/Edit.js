import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useAuthContext } from '../../contexts/AuthContext';
import * as recipeService from '../../services/recipeService';

const Edit = () => {
    const [recipe, setRecipe] = useState({});
    const [list, setList] = useState([]);   
    const [ingredient, setIngredient] = useState('');
    const navigate = useNavigate();
    let { id } = useParams();
    let { user } = useAuthContext();

    useEffect(() => {
        recipeService.getRecipe(id, user.authToken)
            .then(r => {
                setRecipe(r);
                setList(r.ingredientsList);
            })
    }, []);


    const submitHandler = (e) => {
        e.preventDefault();
        let formData = new FormData(e.currentTarget);

        let name = formData.get('recipeName');
        let cookingTime = formData.get('time');
        let portions = formData.get('portions');
        let description = formData.get('description');
        let steps = formData.get('steps');
        let ingredients = list.filter(x=> x !== '');
        let image = formData.get('image');
        let userId = user.id;

        let formSend = new FormData();
        let data = {
            name,
            cookingTime,
            portions,
            description,
            steps,
            image,
            ingredients,
            userId
        };

        Object.keys(data).forEach(key => {
            formSend.append(key,data[key]);
        });

        recipeService.updateRecipe(recipe.id, formSend, user.authToken)
        .then(() => {
            navigate(`/details/${recipe.id}`);
        })
        .catch(err => console.log(err));

    };

    const onClickAddHandler = (e) => {
        e.preventDefault();
        setList([...list, ingredient]);
    };

    const onIngredientBlurHandler = (e) => {
        setIngredient(e.target.value);
        e.target.value = '';
    };

    const removeIngredientClickHandler = (ingredient)=> {
        setList(list => [...list].filter(x=> x!== ingredient));
    };

    return (
        <div className="container-xxl py-5 px-0 wow fadeInUp" data-wow-delay="0.1s">
        <div className="row g-0">
            <div className="col-md-6 bg-dark d-flex align-items-center">
                <div className="p-5 wow fadeInUp" data-wow-delay="0.2s">
                    <h5 className="section-title ff-secondary text-start text-primary fw-normal mt-5 mb-5">Edit Recipe</h5>
                    <form onSubmit={submitHandler}>
                        <div className="row g-3">
                            <div className="col-md-6">
                                <div className="form-floating">
                                    <input type="text" className="form-control" name='recipeName' id="name" placeholder="Recipe name" defaultValue={recipe.name}/>
                                    <label htmlFor="name">Recipe name</label>
                                </div>
                            </div>
                            <div className="col-md-6">
                                <div className="form-floating">
                                    <input type="number" className="form-control" name='time' id="cooking-time" placeholder="Cooking time" min={1} defaultValue={recipe.cookingTime} />
                                    <label htmlFor="cooking-time">Cooking time in minutes</label>
                                </div>
                            </div>
                            <div className="col-md-6">
                                <div className="form-floating input-group">
                                    <input onBlur={onIngredientBlurHandler} type="text" className="form-control" id="ingredient-weight" placeholder="Ingredient - weight" />
                                    <button className="btn btn-primary py-3" onClick={onClickAddHandler}>Add</button>
                                    <label htmlFor="ingredient-weight">Ingredient - weight</label>
                                </div>
                            </div>
                            <div className="col-md-6">
                                    <div className="form-floating">
                                    <div className="form-floating">
                                    <input name='portions' type="number" className="form-control" id="portions" placeholder="Portions" min={1} defaultValue={recipe.portions} />
                                    <label htmlFor="portions">Portions</label>
                                </div>
                                    </div>
                            </div>
                            <div className="col-12">
                                <div className="form-floating">
                                    <textarea name='description' className="form-control" placeholder="Short description" id="description" defaultValue={recipe.description}></textarea>
                                    <label htmlFor="description">Short description</label>
                                </div>
                            </div>
                            <div className="col-12">
                                <div className="form-floating">
                                    <textarea name='steps' className="form-control" placeholder="Steps to prepare" id="prep-steps" defaultValue={recipe.steps}></textarea>
                                    <label htmlFor="prep-steps">Steps to prepare</label>
                                </div>
                            </div>
                            <div className="col-12">
                                    <label className="text-white mb-1">Dish Image</label>
                                    <input type="file" name='image' className="form-control" id="dish-img" placeholder="Image" />
                            </div>
                            <div className="col-12">
                                <button className="btn btn-primary w-100 py-3" type="submit">Send</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        <div className="col-md-6 bg-dark mt-5">
            <div className="p-5 wow fadeInUp" data-wow-delay="0.2s">
                <h5 className="section-title ff-secondary text-start text-primary fw-normal mb-5">Ingredients list</h5>
                <ul id="ingredients-list">
                    {list.map(x => {return <li className='text-primary' key={x}><button onClick={() => {removeIngredientClickHandler(x)}} className="btn btn-danger btn-sm">X</button> {x}</li>})}
                </ul>
            </div>
        </div>
    </div>
</div>
    );
}

export default Edit;