import React, { Component } from 'react';
import { Route, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';

class PrivateRoute extends Component {
  render() {
    const { comp: Comp, ...rest } = this.props;
    return (
      <Route {...rest} render={props => (true ? <Comp {...props} /> : <Redirect to="/signIn" />)} />
    );
  }
}

const mapStateToProps = state => {
  return {
    logged: state.auth.logged,
  };
};

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(PrivateRoute);
