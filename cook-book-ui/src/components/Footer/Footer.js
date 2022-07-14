const Footer = () => {
    return (
        <div className="container-fluid bg-dark text-light footer pt-5 mt-5 wow fadeIn" data-wow-delay="0.1s">
        <div className="container">
            <div className="copyright">
                <div className="row">
                    <div className="col-md-6 text-center text-md-start mb-3 mb-md-0">
                        <p>Cook Book &copy; {new Date().getFullYear()}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    );
}

export default Footer;