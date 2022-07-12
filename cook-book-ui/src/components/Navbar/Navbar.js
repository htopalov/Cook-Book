const Navbar = () => {
    return (
        <div className="container-xxl position-relative p-0">
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark px-4 px-lg-5 py-3 py-lg-0">
            <a href="/" className="navbar-brand p-0">
                <h1 className="text-primary m-0"><i className="fa fa-utensils me-3"></i>Cook Book</h1>
            </a>
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                <span className="fa fa-bars"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarCollapse">
                <div id="user" className="navbar-nav ms-auto py-0 pe-4">
                    <a href="/all" className="nav-item nav-link active">Recipes</a>
                    <a href="/my-recipes" className="nav-item nav-link">My Recipes</a>
                    <a href="/favourite" className="nav-item nav-link">Favourite Recipes</a>
                    <a href="/add" className="nav-item nav-link">Add Recipe</a>
                </div>
                <div id="guest" className="navbar-nav ms-auto py-0 pe-4">
                    <a href="/login" className="nav-item nav-link">Login</a>
                    <a href="/sign-up" className="nav-item nav-link">Sign up</a>
                </div>
            </div>
        </nav>
    </div>
    );
}

export default Navbar;