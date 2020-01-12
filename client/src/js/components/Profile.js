import React, { Component } from 'react';
import { connect } from 'react-redux';

class Profile extends Component {
  render() {
    return <h1>Profile</h1>;
  }
}

const mapStateToProps = state => {
  return {
    ...state.auth,
  };
};

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(Profile);
