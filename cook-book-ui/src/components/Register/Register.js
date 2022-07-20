import { useNavigate } from 'react-router';
import * as authService from '../../services/authService';

const Register = () => {
    const navigate = useNavigate();

    const registerSubmitHandler = (e) => {
        e.preventDefault();

        let { email, password } = Object.fromEntries(new FormData(e.currentTarget));

        authService.register(email, password)
            .then(() => {
                navigate('/login');
            })
            .catch(err => console.log(err));
    }


    return (
        <div className="container-xxl py-5 px-0 wow fadeInUp" data-wow-delay="0.1s">
        <div className="row g-0">
            <div className="col-md-6 bg-dark d-flex align-items-center">
                <div className="p-5 wow fadeInUp" data-wow-delay="0.2s">
                    <h2 className="section-title ff-secondary text-start text-primary fw-normal mt-5 mb-5">Sign Up</h2>
                    <form method='POST' onSubmit={registerSubmitHandler}>
                        <div className="row g-3">
                            <div className="col-md-12">
                                <div className="form-floating">
                                    <input type="email" className="form-control" name="email" id="email" placeholder="Your Email" required />
                                    <label htmlFor="email">Email</label>
                                </div>
                            </div>
                            <div className="col-12">
                                <div className="form-floating">
                                <input type="password" className="form-control" name="password" id="password" placeholder="Password" required />
                                    <label htmlFor="password">Password</label>
                                </div>
                            </div>
                            <div className="col-12">
                                <button className="btn btn-primary w-100 py-3" type="submit">Sign Up</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    );
}

export default Register;