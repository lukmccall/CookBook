import React, { Component } from 'react';
import Navbar from './components/Navbar';
import { BrowserRouter as Router } from 'react-router-dom';
import SubPages from './SubPages';

export class App extends Component {
  render() {
    return (
      <Router>
        <div className="main">
          <Navbar />
          <SubPages />
        </div>
      </Router>
    );
  }
}
