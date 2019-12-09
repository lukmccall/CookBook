import React, { Component } from 'react';
import '../../css/navbar.scss';
import {Link} from 'react-router-dom';

export default class Navbar extends Component {
  state={
      isOpen: false
  }

  handleClick=()=>{
    this.setState({
        isOpen: !this.state.isOpen
    })
  }

  closeNavbar=()=>{
    this.setState({
        isOpen: false
    })
  }
  
    render() {
    return (
      <nav>
        <div className="logoBtn">
        <div className="btn" onClick={this.handleClick}>
          <i className="fas fa-caret-square-down"></i>
          </div>
            <div className="logo"><i className="fas fa-utensils"></i>
            <span className="title">CookBook</span></div>
            <div className="btn">
            <Link to="/signIn" onClick={this.closeNavbar}>
          <i className="fas fa-sign-in-alt"></i>
          </Link>
          </div>
        </div>
        <ul className={this.state.isOpen ? 'showNav' : 'undefined'}>
          <li><Link to="/" onClick={this.closeNavbar}>HOME</Link></li>
          <li><Link to="/about" onClick={this.closeNavbar}>ABOUT</Link></li>
          <li><Link to="/projects" onClick={this.closeNavbar}>PROJECT</Link></li>
          <li><Link to="/contact" onClick={this.closeNavbar}>CONTACT</Link></li>
        </ul>
        <div className='signIn'>
        <Link to="/signIn">
            <span className="signIn-text">Sign in</span>
            <i className="fas fa-sign-in-alt"></i>
            </Link>
        </div>
      </nav>
    );
  }
}
