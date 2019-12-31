import React, { Component } from 'react';

export default class Error extends Component {
  render() {
    return (
      <li>
        <i className="fas fa-exclamation-circle"></i>
        {this.props.msg}
      </li>
    );
  }
}
