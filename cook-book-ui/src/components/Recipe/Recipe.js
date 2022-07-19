import { Link } from 'react-router-dom';

const Recipe = (recipe) => {
    return (
<div className="container">
    <div className="row">
        <div className="col-md-5 p-5 wow fadeInUp" data-wow-delay="0.2s">           
            <div className="project-info-box mt-5">
                <h1 className="ff-secondary text-primary fw-normal mt-5 mb-3">Chineese chicken</h1>
                <p className="mb-0">Vivamus pellentesque, felis in aliquam ullamcorper, lorem tortor porttitor erat, hendrerit porta nunc tellus eu lectus. Ut vel imperdiet est. Pellentesque condimentum, dui et blandit laoreet, quam nisi tincidunt tortor.</p>
            </div>
            <div className="project-info-box">
                    <div id="recipe-options">
                         <Link to="/edit" id="btn-edit" className="btn btn-primary">Edit</Link>
                         <button id="btn-delete" className="btn btn-primary">Delete</button>
                         <button id="btn-like" className="btn btn-primary">Like</button>
                     </div>
            </div>
            <div className="project-info-box">
                <p><b>Likes:</b> 5 likes</p>
                <p><b>Cooking Time:</b> 5 min</p>
                <p><b>Portions:</b> 6</p>
                <p><b>Ingredients:</b> 
                    <ul id="ingredients-list">
                        <li>Chicken - 1 kg</li>
                        <li>Rise - 500 gr</li>
                        <li>Salt - 10 gr</li>
                        <li>Onion - 400 gr</li>
                        <li>Black pepper - 10 gr</li>
                        <li>Water - 2 lt</li>
                        <li>Carrots - 300 gr</li>
                    </ul>
                </p>
            </div>
        </div>
        <div className="col-md-7 mt-5 p-5 wow fadeInUp" data-wow-delay="0.2s">
            <img src="https://via.placeholder.com/400x300/FFB6C1/000000" alt="" className="rounded"/>
        </div>
    </div>
</div>
    );
}

export default Recipe;