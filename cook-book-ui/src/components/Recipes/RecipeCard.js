import {Link} from 'react-router-dom'

const RecipeCard = ({recipe}) => {
    return (
    <div className="col-lg-6">
        <div className="d-flex align-items-center card-holder">
            <img className="flex-shrink-0 img-fluid rounded small-img" src={recipe.image} alt="recipe" style={{"width": 80}}/>
            <div className="w-100 d-flex flex-column text-start ps-4">
                <h5 className="d-flex justify-content-between border-bottom pb-2">
                    <span className="text-primary">{recipe.name}</span>
                    <Link to={`/details/${recipe.id}`}><span className="text-light fw-normal">Details</span></Link>
                </h5>
                <small className="fst-italic rec-desc">{recipe.description}</small>
            </div>
        </div>
    </div>
    )
}

export default RecipeCard;