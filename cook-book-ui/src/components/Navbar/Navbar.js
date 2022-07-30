import { Link } from 'react-router-dom';
import { useAuthContext } from '../../contexts/AuthContext';

const Navbar = () => {
    const { user } = useAuthContext();

    let guestNavbar = (
        <div id="guest" className="navbar-nav ms-auto py-0 pe-4">
        <Link to="/login" className="nav-item nav-link">Login</Link>
        <Link to="/sign-up" className="nav-item nav-link">Sign up</Link>
    </div>
    );

    let userNavbar = (
        <div id="user" className="navbar-nav ms-auto py-0 pe-4">
        <Link to="/all" className="nav-item nav-link">Recipes</Link>
        <Link to="/my-recipes" className="nav-item nav-link">My Recipes</Link>
        <Link to="/favorite" className="nav-item nav-link">Favorite Recipes</Link>
        <Link to="/add" className="nav-item nav-link">Add Recipe</Link>
        <Link to="/logout" className="nav-item nav-link">Logout</Link>
    </div>
    );

    return (
        <div className="container-xxl position-relative p-0">
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark px-4 px-lg-5 py-3 py-lg-0">
            <Link to="/" className="navbar-brand p-0">
                <h1 className="text-primary m-0"><i className="fa fa-utensils me-3"></i>Cook Book</h1>
                </Link>
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                <span className="fa fa-bars"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarCollapse">
            {user.email
                        ? userNavbar
                        : guestNavbar
                    }
        
            </div>
        </nav>
    </div>
    );
}

export default Navbar;