import React from 'react';
import { Link } from "react-router-dom";
  
const Navbar = () => {
    return ( 


    <nav className="navbar navbar-expand-lg fixed-top navbar-dark bg-dark">
    <div className="container-fluid">
        <Link to="/" className="navbar-brand" href="#">Navbar</Link>
      <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span className="navbar-toggler-icon"></span>
      </button>
      <div className="collapse navbar-collapse" id="navbarSupportedContent">
        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
          <li className="nav-item">
          <Link to="/"className="nav-link active" aria-current="page" href="#">Acasa</Link>
          </li>
          <li className="nav-item">
          <Link to="/explore" className="nav-link" href="#">Exploreaza</Link>
          </li>
          <li className="nav-item">
          <Link to="/saved" className="nav-link" href="#">Saved</Link>
          </li>
          <li className="nav-item">
          <Link to="/profile" className="nav-link" href="#">Profil</Link>
          </li>

        </ul>
        <form className="d-flex">
          <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
          <button className="btn btn-outline-success" type="submit">Search</button>
        </form>
      </div>
    </div>
  </nav>


   );
}
 
export default Navbar;