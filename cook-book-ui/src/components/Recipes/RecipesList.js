import RecipeCard from "./RecipeCard";

const Recipes = (data) => {
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
                         {data.map(x => <RecipeCard key={x._id} recipe={x} />)}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    );
}

export default Recipes;