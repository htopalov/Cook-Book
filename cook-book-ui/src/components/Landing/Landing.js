import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import * as recipeService from '../../services/recipeService.js';

const Landing = () => {
    const[recipes,setRecipes] = useState([]);
    useEffect(()=> {
        recipeService.getGuestRecipes()
        .then(res=>setRecipes(res))
    },[]);

    const guestRecipe = (recipe, index) =>{
        return (
        <div key={recipe.id} className="col-6 text-start">
            <Link to={`/details/${recipe.id}`}>
                  <img
                      className={`img-fluid rounded ${index === 1 || index === 2 ? 'w-75' : 'w-100'} wow zoomIn guest-rec-img`}
                      data-wow-delay="0.1s"
                      src={recipe.image}
                      alt="guest-recipe"/>
            </Link>
        </div>
        );
    };

    return (
        <>
        <div className="container-xxl py-5 bg-dark hero-header mb-5">
        <div className="container my-5 py-5">
            <div className="row align-items-center g-5">
                <div className="col-lg-6 text-center text-lg-start">
                    <h1 className="display-3 text-white animated slideInLeft">Welcome to the world of recipes</h1>
                    <p className="text-white animated slideInLeft mb-4 pb-2">Digital cook book where you can share your taste</p>
                </div>
                <div className="col-lg-6 text-center text-lg-end overflow-hidden">
                    <img className="img-fluid" src="./img/hero.png" alt="" />
                </div>
            </div>
        </div>
    </div>
      <div className="container">
          <div className="container-xxl py-5">
          <h5 className="section-title ff-secondary text-start text-primary fw-normal">Check out some of the dishes</h5>
          <div className="row g-5 align-items-center">
              <div className="col-lg-6">
                  <div className="row g-3">
                    {recipes.map((r, i)=> guestRecipe(r,i))}
                  </div>
              </div>
              <div className="col-lg-6">
                  <h5 className="section-title ff-secondary text-start text-primary fw-normal">About Us</h5>
                  <p className="mb-4">Cooking is not difficult. Everyone has taste, even if they don't realize it. Even if you're not a great chef, there's nothing to stop you understanding the difference between what tastes good and what doesn't.</p>
                  <p className="mb-4">Gerard Depardieu</p>
              </div>
          </div>
      </div>
  </div>
  </>
    );
}

export default Landing;