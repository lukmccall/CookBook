import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import '../../css/Navbar.scss';

export default class Navbar extends Component {
  state = {
    isOpen: false,
  };

  handleClick = () => {
    this.setState({
      isOpen: !this.state.isOpen,
    });
  };

  closeNavbar = () => {
    this.setState({
      isOpen: false,
    });
  };

  render() {
    return (
      <nav>
        <div className="navbar-buttons">
          <div className="navbar-btn" onClick={this.handleClick}>
            <i className="fas fa-caret-square-down"></i>
          </div>
          <div className="navbar-logo">
            <i className="fas fa-utensils"></i>
            <span className="navbar-title">CookBook</span>
          </div>
          <div className="navbar-btn">
            <Link to="/signIn" onClick={this.closeNavbar}>
              <i className="fas fa-sign-in-alt"></i>
            </Link>
          </div>
        </div>
        <ul className={this.state.isOpen ? 'navbar-show' : 'undefined'}>
          <li>
            <Link to="/" onClick={this.closeNavbar}>
              HOME
            </Link>
          </li>
          <li>
            <Link to="/about" onClick={this.closeNavbar}>
              ABOUT
            </Link>
          </li>
          <li>
            <Link to="/project" onClick={this.closeNavbar}>
              PROJECT
            </Link>
          </li>
          <li>
            <Link to="/contact" onClick={this.closeNavbar}>
              CONTACT
            </Link>
          </li>
        </ul>
        <div className="navbar-signIn">
          <Link to="/signIn">
            <span className="signIn-text">Sign in</span>
            <i className="fas fa-sign-in-alt"></i>
          </Link>
        </div>
      </nav>
    );
  }
}
