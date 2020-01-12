import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';

import Home from './components/Home';
import Contact from './components/Contact';
import SignIn from './components/SignIn';
import About from './components/About';
import Project from './components/Project';
import Profile from './components/Profile';
import PriavateRoute from './PrivateRoute';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';

class SubPages extends Component {
  render() {
    return (
      <Switch>
        <Route exact path="/" component={Home} />
        <Route exact path="/contact" component={Contact} />
        <Route exact path="/about" component={About} />
        <Route exact path="/project" component={Project} />
        <Route exact path="/signIn" component={SignIn} />
        <PriavateRoute exact path="/profile" comp={Profile} />
      </Switch>
    );
  }
}

const mapStateToProps = state => {
  return {
    ...state.auth,
  };
};

const mapDispatchToProps = {};

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(SubPages));
