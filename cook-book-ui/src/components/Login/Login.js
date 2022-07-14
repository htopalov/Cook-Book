const Login = () => {
    return (
        <div className="container-xxl py-5 px-0 wow fadeInUp" data-wow-delay="0.1s">
        <div className="row g-0">
            <div className="col-md-6 bg-dark d-flex align-items-center">
                <div className="p-5 wow fadeInUp mb-5 mt-4" data-wow-delay="0.2s">
                    <h2 className="section-title ff-secondary text-start text-primary fw-normal mt-5 mb-5">Login</h2>
                    <form>
                        <div className="row g-3">
                            <div className="col-md-6">
                                <div className="form-floating">
                                    <input type="email" className="form-control" id="email" placeholder="example@mail.com" required />
                                    <label htmlFor="email">Your Email</label>
                                </div>
                            </div>
                            <div className="col-md-6">
                                <div className="form-floating">
                                    <input type="password" className="form-control" id="password" placeholder="Your Password" required />
                                    <label htmlFor="password">Your Password</label>
                                </div>
                            </div>
                            <div className="col-12">
                                <button className="btn btn-primary w-100 py-3" type="submit">Send</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    );
}

export default Login;