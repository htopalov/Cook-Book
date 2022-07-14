const Register = () => {
    return (
        <div className="container-xxl py-5 px-0 wow fadeInUp" data-wow-delay="0.1s">
        <div className="row g-0">
            <div className="col-md-6 bg-dark d-flex align-items-center">
                <div className="p-5 wow fadeInUp" data-wow-delay="0.2s">
                    <h2 className="section-title ff-secondary text-start text-primary fw-normal mt-5 mb-5">Sign Up</h2>
                    <form>
                        <div className="row g-3">
                            <div className="col-md-6">
                                <div className="form-floating">
                                    <input type="text" className="form-control" id="username" placeholder="Username" required />
                                    <label htmlFor="username">Username</label>
                                </div>
                            </div>
                            <div className="col-md-6">
                                <div className="form-floating">
                                    <input type="email" className="form-control" id="email" placeholder="Your Email" required />
                                    <label htmlFor="email">Email</label>
                                </div>
                            </div>
                            <div className="col-12">
                                <div className="form-floating">
                                <input type="password" className="form-control" id="password" placeholder="Password" required />
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