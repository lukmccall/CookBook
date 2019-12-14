import React, { Component } from 'react';
import Navbar from './components/Navbar';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './components/Home';
import Contact from './components/Contact';
import SignIn from './components/SignIn';
import About from './components/About';

export class App extends Component {
  render() {
    return (
      <Router>
        <div className="main">
          <Navbar />
          <Switch>
            <Route exact path="/" component={Home} />
            <Route exact path="/contact" component={Contact} />
            <Route exact path="/about" component={About} />
            <Route exact path="/signIn" component={SignIn} />
          </Switch>
        </div>
      </Router>
    );
  }
}
